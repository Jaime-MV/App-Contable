using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using App_Contable.Datos;
using App_Contable.Modelos;

namespace App_Contable.Logica
{
    /// <summary>
    /// Resultado estructurado tras la importación de un Libro Diario.
    /// </summary>
    public class ResultadoImportacion
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public string? Detalle { get; set; }
        public LibroDiarioInstancia? InstanciaImportada { get; set; }

        public int AsientosImportados => InstanciaImportada?.Asientos.Count ?? 0;
        public decimal TotalDebe => InstanciaImportada?.TotalDebe ?? 0m;
        public decimal TotalHaber => InstanciaImportada?.TotalHaber ?? 0m;
        public bool EstaCuadrado => InstanciaImportada != null && InstanciaImportada.Asientos.Count > 0 && Math.Round(TotalDebe, 2) == Math.Round(TotalHaber, 2);
    }

    /// <summary>
    /// Servicio de importación de Libros Diarios desde archivos CSV y PDF con máquina de estados estricta.
    /// </summary>
    public class LibroDiarioImportService
    {
        private static LibroDiarioImportService? _instancia;
        public static LibroDiarioImportService Instancia => _instancia ??= new LibroDiarioImportService();

        private readonly LibroDiarioStorageService _storageService = new();
        private const int AnioContableActivo = 2026;

        /// <summary>
        /// Procesa e importa un archivo de Libro Diario en formato CSV o PDF.
        /// </summary>
        public ResultadoImportacion ImportarArchivo(string rutaArchivo)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo) || !File.Exists(rutaArchivo))
            {
                return new ResultadoImportacion
                {
                    Exitoso = false,
                    Mensaje = "El archivo especificado no existe o la ruta es inválida."
                };
            }

            string extension = Path.GetExtension(rutaArchivo).ToLowerInvariant();

            try
            {
                return extension switch
                {
                    ".csv" => ImportarCsv(rutaArchivo),
                    ".pdf" => ImportarPdf(rutaArchivo),
                    _ => new ResultadoImportacion
                    {
                        Exitoso = false,
                        Mensaje = $"El formato '{extension}' no es admitido. Por favor selecciona un archivo .csv o .pdf."
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResultadoImportacion
                {
                    Exitoso = false,
                    Mensaje = $"Ocurrió un error al procesar el archivo: {ex.Message}",
                    Detalle = ex.ToString()
                };
            }
        }

        // ══════════════════════════════════════════════════════════════
        //  MÁQUINA DE ESTADOS — IMPORTACIÓN DESDE CSV
        // ══════════════════════════════════════════════════════════════

        private ResultadoImportacion ImportarCsv(string rutaArchivo)
        {
            using var stream = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var reader = new StreamReader(stream, Encoding.UTF8, true);

            var asientos = new List<AsientoContable>();
            AsientoContable? asientoActual = null;
            string? linea;
            int numeroLinea = 0;

            while ((linea = reader.ReadLine()) != null)
            {
                numeroLinea++;
                if (string.IsNullOrWhiteSpace(linea)) continue;

                var cols = SplitCsvLine(linea);
                if (!cols.Any()) continue;

                string col0 = cols.Count > 0 ? cols[0].Trim() : string.Empty;
                string col1 = cols.Count > 1 ? cols[1].Trim() : string.Empty;
                string col2 = cols.Count > 2 ? cols[2].Trim() : string.Empty;
                string col3 = cols.Count > 3 ? cols[3].Trim() : string.Empty;
                string col4 = cols.Count > 4 ? cols[4].Trim() : string.Empty;
                string col5 = cols.Count > 5 ? cols[5].Trim() : string.Empty;
                string col6 = cols.Count > 6 ? cols[6].Trim() : string.Empty;

                // 1. Ignorar fila de encabezado de tabla general (ej: FECHA,CUENTA,PARCIAL,DEBE,HABER)
                if (EsEncabezadoGeneral(col0, col1) || cols.Any(c => c.Equals("DEBE", StringComparison.OrdinalIgnoreCase) || c.Equals("HABER", StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }

                // 2. Detección de nuevo asiento:
                // Al leer una fila donde la columna 0 tenga fecha (ej: '1-ene', '3-ene') 
                // y la columna 1 contenga la palabra 'ASIENTO' (ej: 'ASIENTO #1', 'ASIENTO #2', 'PARTIDA 1')
                bool esNuevoAsiento = ContienePalabraAsiento(col1) || (ContienePalabraAsiento(col0) && !EsGlosa(col0));

                if (esNuevoAsiento)
                {
                    // Guardar y cerrar el asiento anterior (si existe y tiene movimientos)
                    if (asientoActual != null && asientoActual.Movimientos.Any())
                    {
                        asientos.Add(asientoActual);
                    }

                    string textoAsiento = ContienePalabraAsiento(col1) ? col1 : col0;
                    string textoFecha = ContienePalabraAsiento(col1) ? col0 : (cols.Count > 1 ? col1 : string.Empty);

                    int numAsiento = ExtraerNumeroAsiento(textoAsiento, asientos.Count + 1);
                    DateTime fecha = ParseFechaContable(textoFecha, AnioContableActivo);

                    asientoActual = new AsientoContable
                    {
                        NumeroAsiento = numAsiento,
                        Fecha = fecha,
                        Concepto = string.Empty,
                        Movimientos = new List<MovimientoContable>()
                    };

                    continue;
                }

                // Compatibilidad con CSV tabular estándar (ej: col0 tiene el número de asiento 1, 2, 3...)
                if (asientoActual == null)
                {
                    if (int.TryParse(col0, out int nAsiento) && nAsiento > 0)
                    {
                        DateTime f = ParseFechaContable(col1, AnioContableActivo);
                        asientoActual = new AsientoContable
                        {
                            NumeroAsiento = nAsiento,
                            Fecha = f,
                            Concepto = col4,
                            Movimientos = new List<MovimientoContable>()
                        };
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    // Cambio de número de asiento en formato tabular estándar
                    if (int.TryParse(col0, out int nAsiento) && nAsiento > 0 && nAsiento != asientoActual.NumeroAsiento)
                    {
                        if (asientoActual.Movimientos.Any())
                        {
                            asientos.Add(asientoActual);
                        }

                        DateTime f = ParseFechaContable(col1, AnioContableActivo);
                        asientoActual = new AsientoContable
                        {
                            NumeroAsiento = nAsiento,
                            Fecha = f,
                            Concepto = col4,
                            Movimientos = new List<MovimientoContable>()
                        };
                    }
                }

                // 3. Descarte de filas de control:
                // Si cualquier columna contiene 'Totales', 'TOTALES' o 'Sumas Iguales',
                // IGNORAR sus valores monetarios por completo. NO crear movimiento contable ni acumular en Debe/Haber.
                if (cols.Any(c => EsFilaTotales(c)))
                {
                    continue;
                }

                // 4. Glosa / Concepto:
                // Si la columna 1 comienza con 'c/' o 'c/Por...', asignarlo a la propiedad Concepto de ese asiento y pasar a la siguiente línea.
                if (EsGlosa(col1) || EsGlosa(col0))
                {
                    string glosaRaw = EsGlosa(col1) ? col1 : col0;
                    asientoActual.Concepto = LimpiarTextoGlosa(glosaRaw);
                    continue;
                }

                // 5. Movimientos contables:
                string cuentaRaw = col1;
                decimal parcial = 0m;
                decimal debe = 0m;
                decimal haber = 0m;

                if (cols.Count >= 7 && int.TryParse(col0, out _))
                {
                    // Formato exportado 7 columnas: NumeroAsiento,Fecha,CuentaCodigo,CuentaNombre,Concepto,Debe,Haber
                    cuentaRaw = col3;
                    LimpiarYParsearMonto(col5, out debe);
                    LimpiarYParsearMonto(col6, out haber);
                    if (string.IsNullOrWhiteSpace(asientoActual.Concepto) && !string.IsNullOrWhiteSpace(col4))
                    {
                        asientoActual.Concepto = col4;
                    }
                }
                else if (cols.Count >= 5)
                {
                    // Formato 5 columnas de Libro Diario: Fecha(0), Cuenta(1), Parcial(2), Debe(3), Haber(4)
                    cuentaRaw = col1;
                    LimpiarYParsearMonto(col2, out parcial);
                    LimpiarYParsearMonto(col3, out debe);
                    LimpiarYParsearMonto(col4, out haber);
                }
                else if (cols.Count >= 4)
                {
                    cuentaRaw = col1;
                    LimpiarYParsearMonto(col2, out debe);
                    LimpiarYParsearMonto(col3, out haber);
                }
                else if (cols.Count == 3)
                {
                    cuentaRaw = col1;
                    LimpiarYParsearMonto(col2, out debe);
                }

                if (string.IsNullOrWhiteSpace(cuentaRaw) && debe == 0 && haber == 0 && parcial == 0)
                {
                    continue;
                }

                string cuentaLimpia = LimpiarNombreCuenta(cuentaRaw);
                string? subcuenta = null;

                if (cuentaLimpia.Contains(" - "))
                {
                    var splitCuenta = cuentaLimpia.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                    cuentaLimpia = splitCuenta[0].Trim();
                    subcuenta = splitCuenta.Length > 1 ? splitCuenta[1].Trim() : null;
                }

                // Reglas estrictas de asignación:
                // a) El Debe solo suma montos de la columna Debe (> 0)
                if (debe > 0)
                {
                    asientoActual.Movimientos.Add(new MovimientoContable
                    {
                        CuentaPrincipal = cuentaLimpia,
                        Subcuenta = subcuenta,
                        Movimiento = TipoMovimiento.Debe,
                        Monto = debe
                    });
                }
                // b) El Haber solo suma montos de la columna Haber (> 0)
                else if (haber > 0)
                {
                    asientoActual.Movimientos.Add(new MovimientoContable
                    {
                        CuentaPrincipal = cuentaLimpia,
                        Subcuenta = subcuenta,
                        Movimiento = TipoMovimiento.Haber,
                        Monto = haber
                    });
                }
                // c) La columna Parcial pertenece exclusivamente a subcuentas informativas (Caja, Bancos, etc.)
                // NUNCA se suma a Debe ni Haber.
                else if (parcial > 0)
                {
                    if (asientoActual.Movimientos.Any())
                    {
                        var ultimoMov = asientoActual.Movimientos.Last();
                        ultimoMov.Subcuenta = string.IsNullOrWhiteSpace(ultimoMov.Subcuenta)
                            ? cuentaLimpia
                            : $"{ultimoMov.Subcuenta}, {cuentaLimpia}";
                    }
                }
            }

            // Guardar último asiento pendiente
            if (asientoActual != null && asientoActual.Movimientos.Any())
            {
                asientos.Add(asientoActual);
            }

            if (!asientos.Any())
            {
                return new ResultadoImportacion
                {
                    Exitoso = false,
                    Mensaje = "No se pudieron extraer asientos contables válidos del archivo CSV."
                };
            }

            // Asegurar que las glosas vacías tengan un texto descriptivo para cumplir validaciones
            foreach (var asiento in asientos)
            {
                if (string.IsNullOrWhiteSpace(asiento.Concepto))
                {
                    asiento.Concepto = $"Registro contable del asiento N° {asiento.NumeroAsiento}.";
                }
            }

            // Crear y persistir la instancia
            var minFecha = asientos.Min(a => a.Fecha);
            var maxFecha = asientos.Max(a => a.Fecha);
            string nombreArchivo = Path.GetFileNameWithoutExtension(rutaArchivo);

            var nuevaInstancia = new LibroDiarioInstancia
            {
                Id = Guid.NewGuid().ToString("N"),
                Nombre = $"Libro Diario — {nombreArchivo}",
                Empresa = "Empresa Importada",
                FechaInicio = minFecha,
                FechaFin = maxFecha < minFecha ? minFecha : maxFecha,
                DestinoGuardado = TipoDestinoLibro.Importado,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                Asientos = asientos
            };

            // Persistir inmediatamente en memoria y almacenamiento local
            _storageService.GuardarLibro(nuevaInstancia);

            var cultureUs = new CultureInfo("en-US");
            string estadoCuadre = nuevaInstancia.TotalDebe == nuevaInstancia.TotalHaber
                ? "✓ Cuadrado"
                : $"⚠ Descuadre de {Math.Abs(nuevaInstancia.TotalDebe - nuevaInstancia.TotalHaber).ToString("C2", cultureUs)}";

            return new ResultadoImportacion
            {
                Exitoso = true,
                InstanciaImportada = nuevaInstancia,
                Mensaje = $"Se importó exitosamente el archivo CSV con {asientos.Count} asiento(s) y {asientos.Sum(a => a.Movimientos.Count)} movimiento(s).\n\n" +
                          $"• Nombre asignado: {nuevaInstancia.Nombre}\n" +
                          $"• Total Debe: {nuevaInstancia.TotalDebe.ToString("C2", cultureUs)}\n" +
                          $"• Total Haber: {nuevaInstancia.TotalHaber.ToString("C2", cultureUs)}\n" +
                          $"• Estado: {estadoCuadre} · [Local · Importado]"
            };
        }

        // ══════════════════════════════════════════════════════════════
        //  MÉTODOS AUXILIARES DE PARSEO
        // ══════════════════════════════════════════════════════════════

        private static bool EsEncabezadoGeneral(string col0, string col1)
        {
            string c0 = col0.ToUpperInvariant();
            string c1 = col1.ToUpperInvariant();
            return (c0.Contains("FECHA") && c1.Contains("CUENTA")) ||
                   c0.Contains("NUMEROASIENTO") ||
                   c0.Contains("PARTIDA") && c1.Contains("FECHA");
        }

        private static bool ContienePalabraAsiento(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return false;
            string t = texto.ToUpperInvariant();
            return t.Contains("ASIENTO") || t.Contains("PARTIDA");
        }

        private static bool EsFilaTotales(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return false;
            string t = texto.Trim().ToLowerInvariant();
            return t.StartsWith("totales") || t.StartsWith("total") || t.StartsWith("sumas iguales");
        }

        private static bool EsGlosa(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return false;
            string t = texto.Trim().ToLowerInvariant();
            return t.StartsWith("c/") || t.StartsWith("c/ ") || t.StartsWith("c/por") || 
                   t.StartsWith("v/") || t.StartsWith("v/ ") || t.StartsWith("glosa:") || t.StartsWith("concepto:");
        }

        private static string LimpiarTextoGlosa(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return string.Empty;
            string t = texto.Trim();
            if (t.StartsWith("c/Por", StringComparison.OrdinalIgnoreCase))
                return "Por " + t.Substring(5).TrimStart(':', ' ', '-');
            if (t.StartsWith("c/ Por", StringComparison.OrdinalIgnoreCase))
                return "Por " + t.Substring(6).TrimStart(':', ' ', '-');
            if (t.StartsWith("c/", StringComparison.OrdinalIgnoreCase))
                return t.Substring(2).TrimStart(':', ' ', '-');
            if (t.StartsWith("v/", StringComparison.OrdinalIgnoreCase))
                return t.Substring(2).TrimStart(':', ' ', '-');
            return t;
        }

        private static string LimpiarNombreCuenta(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return string.Empty;
            string t = texto.Trim();
            if (t.StartsWith("a/", StringComparison.OrdinalIgnoreCase))
                return t.Substring(2).Trim();
            if (t.StartsWith("a /", StringComparison.OrdinalIgnoreCase))
                return t.Substring(3).Trim();
            if (t.StartsWith("a ", StringComparison.OrdinalIgnoreCase) && 
                !t.StartsWith("Acreedor", StringComparison.OrdinalIgnoreCase) && 
                !t.StartsWith("Accion", StringComparison.OrdinalIgnoreCase))
                return t.Substring(2).Trim();
            return t;
        }

        private static int ExtraerNumeroAsiento(string texto, int fallback)
        {
            if (string.IsNullOrWhiteSpace(texto)) return fallback;
            var match = Regex.Match(texto, @"\d+");
            if (match.Success && int.TryParse(match.Value, out int num))
            {
                return num;
            }
            return fallback;
        }

        private static DateTime ParseFechaContable(string texto, int anioPredeterminado = 2026)
        {
            if (string.IsNullOrWhiteSpace(texto)) return new DateTime(anioPredeterminado, 1, 1);
            string limpio = texto.Trim().ToLowerInvariant().Replace(".", "");

            // 1. Intentar parseo estándar
            if (DateTime.TryParse(limpio, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt) && dt.Year >= 2000)
                return dt;
            if (DateTime.TryParse(limpio, new CultureInfo("es-ES"), DateTimeStyles.None, out dt) && dt.Year >= 2000)
                return dt;

            // 2. Parseo para formatos abreviados: "1-ene", "01-ene", "15-feb", "3/ene", "1-ene-2026", etc.
            var meses = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "ene", 1 }, { "enero", 1 }, { "jan", 1 },
                { "feb", 2 }, { "febrero", 2 },
                { "mar", 3 }, { "marzo", 3 },
                { "abr", 4 }, { "abril", 4 }, { "apr", 4 },
                { "may", 5 }, { "mayo", 5 },
                { "jun", 6 }, { "junio", 6 },
                { "jul", 7 }, { "julio", 7 },
                { "ago", 8 }, { "agosto", 8 }, { "aug", 8 },
                { "sep", 9 }, { "set", 9 }, { "septiembre", 9 }, { "setiembre", 9 },
                { "oct", 10 }, { "octubre", 10 },
                { "nov", 11 }, { "noviembre", 11 },
                { "dic", 12 }, { "diciembre", 12 }, { "dec", 12 }
            };

            var partes = limpio.Split(new[] { '-', '/', ' ', '_' }, StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length >= 2)
            {
                if (int.TryParse(partes[0], out int dia))
                {
                    string mesStr = partes[1];
                    if (meses.TryGetValue(mesStr, out int mesNum))
                    {
                        int anio = anioPredeterminado;
                        if (partes.Length >= 3 && int.TryParse(partes[2], out int anioParsed))
                        {
                            anio = anioParsed < 100 ? 2000 + anioParsed : anioParsed;
                        }
                        return new DateTime(anio, mesNum, Math.Clamp(dia, 1, DateTime.DaysInMonth(anio, mesNum)));
                    }
                    else if (int.TryParse(mesStr, out int mesDirecto) && mesDirecto >= 1 && mesDirecto <= 12)
                    {
                        int anio = anioPredeterminado;
                        if (partes.Length >= 3 && int.TryParse(partes[2], out int anioParsed))
                        {
                            anio = anioParsed < 100 ? 2000 + anioParsed : anioParsed;
                        }
                        return new DateTime(anio, mesDirecto, Math.Clamp(dia, 1, DateTime.DaysInMonth(anio, mesDirecto)));
                    }
                }
            }

            return new DateTime(anioPredeterminado, 1, 1);
        }

        private static bool LimpiarYParsearMonto(string texto, out decimal monto)
        {
            monto = 0m;
            if (string.IsNullOrWhiteSpace(texto)) return false;

            string limpio = texto.Replace("$", "").Replace("USD", "").Replace(" ", "").Trim();

            if (decimal.TryParse(limpio, NumberStyles.Any, CultureInfo.InvariantCulture, out monto))
                return true;

            if (decimal.TryParse(limpio, NumberStyles.Any, new CultureInfo("es-ES"), out monto))
                return true;

            return false;
        }

        private static List<string> SplitCsvLine(string line)
        {
            var result = new List<string>();
            var sb = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (c == '"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        sb.Append('"');
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == ',' && !inQuotes)
                {
                    result.Add(sb.ToString().Trim());
                    sb.Clear();
                }
                else
                {
                    sb.Append(c);
                }
            }
            result.Add(sb.ToString().Trim());
            return result;
        }

        // ══════════════════════════════════════════════════════════════
        //  IMPORTACIÓN DESDE PDF
        // ══════════════════════════════════════════════════════════════

        private ResultadoImportacion ImportarPdf(string rutaArchivo)
        {
            var fileInfo = new FileInfo(rutaArchivo);
            if (fileInfo.Length == 0)
            {
                return new ResultadoImportacion
                {
                    Exitoso = false,
                    Mensaje = "El archivo PDF seleccionado está vacío."
                };
            }

            return new ResultadoImportacion
            {
                Exitoso = false,
                Mensaje = "Estructura de PDF no compatible para importación automática directa.\n\n" +
                          "Para importar un Libro Diario mediante PDF, asegúrate de utilizar documentos generados con la plantilla oficial del sistema contable que contengan texto seleccionable.\n\n" +
                          "💡 Sugerencia: Te recomendamos utilizar la importación en formato CSV / Excel para una carga inmediata, confiable y 100% compatible de partidas y movimientos."
            };
        }
    }
}

