using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace App_Contable.Datos
{
    /// <summary>
    /// Gestiona la configuración, creación de conexiones y operaciones base con PostgreSQL.
    /// </summary>
    public class DbContext
    {
        private static IConfiguration? _configuration;

        /// <summary>
        /// Instancia centralizada de configuración para la aplicación.
        /// </summary>
        public static IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = ConstruirConfiguracion();
                }
                return _configuration;
            }
        }

        /// <summary>
        /// Fuerza la recarga del archivo de configuración.
        /// </summary>
        public static void RecargarConfiguracion()
        {
            _configuration = ConstruirConfiguracion();
        }

        /// <summary>
        /// Construye el proveedor de configuración buscando appsettings.json y con fallback a appsettings.example.json solo si el real no existe.
        /// </summary>
        private static IConfiguration ConstruirConfiguracion()
        {
            var builder = new ConfigurationBuilder();

            string baseDir = AppContext.BaseDirectory;
            string currentDir = Directory.GetCurrentDirectory();
            string? projectDir = Directory.GetParent(baseDir)?.Parent?.Parent?.FullName; // App-Contable
            string? solutionDir = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName; // Raíz de solución

            var candidateDirs = new[] { baseDir, currentDir, projectDir, solutionDir };

            // 1. Buscar si existe appsettings.json real
            string? realSettingsFile = null;
            foreach (var dir in candidateDirs)
            {
                if (!string.IsNullOrEmpty(dir))
                {
                    string realPath = Path.Combine(dir, "appsettings.json");
                    if (File.Exists(realPath))
                    {
                        realSettingsFile = realPath;
                        break;
                    }
                }
            }

            if (realSettingsFile != null)
            {
                // Si existe el archivo real, cargarlo EXCLUSIVAMENTE para evitar colisiones con valores de ejemplo
                builder.AddJsonFile(realSettingsFile, optional: false, reloadOnChange: true);
            }
            else
            {
                // Solo si NO existe appsettings.json, cargamos appsettings.example.json como fallback
                foreach (var dir in candidateDirs)
                {
                    if (!string.IsNullOrEmpty(dir))
                    {
                        string examplePath = Path.Combine(dir, "appsettings.example.json");
                        if (File.Exists(examplePath))
                        {
                            builder.AddJsonFile(examplePath, optional: true, reloadOnChange: true);
                            break;
                        }
                    }
                }
            }

            return builder.Build();
        }

        /// <summary>
        /// Normaliza la cadena de conexión aceptando tanto formato estándar ADO.NET como formato URL (postgres:// o postgresql://).
        /// </summary>
        public static string NormalizarCadenaConexion(string rawConnectionString)
        {
            if (string.IsNullOrWhiteSpace(rawConnectionString))
                return string.Empty;

            string connStr = rawConnectionString.Trim();

            // Quitar comillas exteriores accidentales
            if ((connStr.StartsWith("\"") && connStr.EndsWith("\"")) ||
                (connStr.StartsWith("'") && connStr.EndsWith("'")))
            {
                connStr = connStr.Substring(1, connStr.Length - 2).Trim();
            }

            // Quitar prefijo de comando "psql " o "DATABASE_URL=" si fue copiado completo de la terminal
            if (connStr.StartsWith("psql ", StringComparison.OrdinalIgnoreCase))
            {
                connStr = connStr.Substring(5).Trim('\"', '\'', ' ');
            }
            else if (connStr.StartsWith("DATABASE_URL=", StringComparison.OrdinalIgnoreCase))
            {
                connStr = connStr.Substring(13).Trim('\"', '\'', ' ');
            }

            // Manejo de URLs tipo postgresql://usuario:password@host:puerto/bd
            if (connStr.StartsWith("postgresql://", StringComparison.OrdinalIgnoreCase) ||
                connStr.StartsWith("postgres://", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    var uri = new Uri(connStr);
                    var builder = new NpgsqlConnectionStringBuilder
                    {
                        Host = uri.Host,
                        Port = uri.Port > 0 ? uri.Port : 5432,
                        Database = uri.AbsolutePath.TrimStart('/'),
                        SslMode = SslMode.Require
                    };

                    if (!string.IsNullOrEmpty(uri.UserInfo))
                    {
                        var userInfoParts = uri.UserInfo.Split(':', 2);
                        builder.Username = Uri.UnescapeDataString(userInfoParts[0]);
                        if (userInfoParts.Length > 1)
                        {
                            builder.Password = Uri.UnescapeDataString(userInfoParts[1]);
                        }
                    }

                    // Parsear query params si existen (?sslmode=require, etc.)
                    if (!string.IsNullOrEmpty(uri.Query))
                    {
                        string query = uri.Query.TrimStart('?');
                        var queryParams = query.Split('&', StringSplitOptions.RemoveEmptyEntries);
                        foreach (var param in queryParams)
                        {
                            var kv = param.Split('=', 2);
                            if (kv.Length == 2)
                            {
                                string key = kv[0].Trim().ToLowerInvariant();
                                string val = Uri.UnescapeDataString(kv[1].Trim());

                                if (key == "sslmode")
                                {
                                    if (Enum.TryParse<SslMode>(val, true, out var sslMode))
                                        builder.SslMode = sslMode;
                                }
                            }
                        }
                    }

                    return builder.ConnectionString;
                }
                catch
                {
                    // Si no se pudo parsear como URI, procesar con normalizador clave-valor
                }
            }

            // Sanitizar formato Clave-Valor si el Host contiene http://, https:// o :puerto
            try
            {
                var builder = new NpgsqlConnectionStringBuilder(connStr);

                if (!string.IsNullOrWhiteSpace(builder.Host))
                {
                    string host = builder.Host.Trim();

                    // Quitar prefijos http/https
                    if (host.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
                        host = host.Substring(7);
                    else if (host.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                        host = host.Substring(8);

                    // Separar :puerto si se ingresó dentro del Host
                    if (host.Contains(":") && !host.StartsWith("[") && int.TryParse(host.Split(':')[1], out int parsedPort))
                    {
                        builder.Host = host.Split(':')[0];
                        builder.Port = parsedPort;
                    }
                    else
                    {
                        builder.Host = host;
                    }
                }

                return builder.ConnectionString;
            }
            catch
            {
                return connStr;
            }
        }

        /// <summary>
        /// Obtiene la cadena de conexión configurada para PostgreSQL normalizada.
        /// </summary>
        public string ObtenerCadenaConexion()
        {
            string? connectionString = Configuration.GetConnectionString("DefaultConnection")
                                     ?? Configuration.GetConnectionString("PostgreSQL");

            // Si no está con esos nombres, buscar el primer valor en ConnectionStrings
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                var section = Configuration.GetSection("ConnectionStrings");
                foreach (var child in section.GetChildren())
                {
                    if (!string.IsNullOrWhiteSpace(child.Value))
                    {
                        connectionString = child.Value;
                        break;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                RecargarConfiguracion();
                connectionString = Configuration.GetConnectionString("DefaultConnection")
                                 ?? Configuration.GetConnectionString("PostgreSQL");

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    var section = Configuration.GetSection("ConnectionStrings");
                    foreach (var child in section.GetChildren())
                    {
                        if (!string.IsNullOrWhiteSpace(child.Value))
                        {
                            connectionString = child.Value;
                            break;
                        }
                    }
                }
            }

            return NormalizarCadenaConexion(connectionString ?? string.Empty);
        }

        /// <summary>
        /// Crea una nueva instancia de NpgsqlConnection sin abrir.
        /// </summary>
        public NpgsqlConnection CrearConexion()
        {
            string connectionString = ObtenerCadenaConexion();

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "No se encontró la cadena de conexión 'PostgreSQL'. Verifica que el archivo appsettings.json exista y contenga la sección 'ConnectionStrings:PostgreSQL'.");
            }

            return new NpgsqlConnection(connectionString);
        }

        /// <summary>
        /// Crea y abre de forma asíncrona una nueva conexión a la base de datos PostgreSQL.
        /// </summary>
        public async Task<NpgsqlConnection> ObtenerConexionAbiertaAsync()
        {
            var conexion = CrearConexion();
            await conexion.OpenAsync();
            return conexion;
        }

        /// <summary>
        /// Prueba la conexión real con PostgreSQL ejecutando una consulta de validación.
        /// </summary>
        public async Task<bool> ProbarConexionAsync()
        {
            var resultado = await ProbarConexionDetalladaAsync();
            if (!resultado.Exito)
            {
                throw new InvalidOperationException(resultado.Mensaje);
            }
            return true;
        }

        /// <summary>
        /// Prueba la conexión real con el servidor PostgreSQL y devuelve información detallada y la versión del servidor.
        /// </summary>
        public async Task<(bool Exito, string Mensaje, string VersionServidor)> ProbarConexionDetalladaAsync()
        {
            string connectionString = ObtenerCadenaConexion();

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return (false, "No se encontró la cadena de conexión en appsettings.json. Por favor crea el archivo configurando tus credenciales de PostgreSQL.", string.Empty);
            }

            if (connectionString.Contains("TU_HOST_SUPABASE_O_RENDER") || connectionString.Contains("TU_PASSWORD"))
            {
                return (false, "La cadena de conexión aún contiene valores de ejemplo ('TU_HOST_SUPABASE_O_RENDER' o 'TU_PASSWORD'). Configura las credenciales reales en appsettings.json.", string.Empty);
            }

            try
            {
                await using var conexion = new NpgsqlConnection(connectionString);
                await conexion.OpenAsync();

                await using var comando = new NpgsqlCommand("SELECT version();", conexion);
                var versionObj = await comando.ExecuteScalarAsync();
                string version = versionObj?.ToString() ?? "PostgreSQL";

                return (true, "Conexión establecida exitosamente.", version);
            }
            catch (NpgsqlException ex)
            {
                return (false, FormatearErrorDiagnostico(ex.Message), string.Empty);
            }
            catch (Exception ex)
            {
                return (false, FormatearErrorDiagnostico(ex.Message), string.Empty);
            }
        }

        /// <summary>
        /// Proporciona sugerencias claras para resolver errores comunes de red, DNS y credenciales.
        /// </summary>
        private static string FormatearErrorDiagnostico(string mensajeOriginal)
        {
            if (mensajeOriginal.Contains("The requested name is valid, but no data of the requested type was found") ||
                mensajeOriginal.Contains("WSANO_DATA") ||
                mensajeOriginal.Contains("No such host is known"))
            {
                return "Error de resolución DNS al buscar el Host de PostgreSQL:\n\n" +
                       "• Si usas Supabase: La conexión directa (db.[ref].supabase.co) usa IPv6. La mayoría de redes Windows requieren IPv4. Ve a Supabase -> Project Settings -> Database -> Connection Pooling (Session mode) y copia el host 'aws-0-[region].pooler.supabase.com' con el puerto 6543 o 5432.\n\n" +
                       "• Revisa que en el Host no hayas incluido prefijos como 'http://' ni el puerto dentro del nombre de dominio.";
            }

            if (mensajeOriginal.Contains("password authentication failed"))
            {
                return "Error de Autenticación: El usuario o la contraseña de la base de datos son incorrectos. Verifica las credenciales en appsettings.json.";
            }

            if (mensajeOriginal.Contains("database") && mensajeOriginal.Contains("does not exist"))
            {
                return "Base de Datos no encontrada: El nombre de la base de datos (Database=...) no existe en el servidor.";
            }

            return $"Error al conectar con la base de datos:\n{mensajeOriginal}";
        }
    }
}
