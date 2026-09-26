using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using App_Contable.Modelos;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace App_Contable.Logica
{
    /// <summary>
    /// Servicio de exportación de instancias de Libro Diario en formatos CSV (Excel) y PDF (Documento Contable).
    /// </summary>
    public class LibroDiarioExportService
    {
        private static LibroDiarioExportService? _instancia;
        public static LibroDiarioExportService Instancia => _instancia ??= new LibroDiarioExportService();

        private static readonly CultureInfo UsCulture = new("en-US");

        // ══════════════════════════════════════════════════════════════
        //  EXPORTACIÓN A CSV (UTF-8 con BOM para Excel)
        // ══════════════════════════════════════════════════════════════

        /// <summary>
        /// Exporta la instancia de Libro Diario a un archivo CSV estructurado con codificación UTF-8 con BOM.
        /// </summary>
        public void ExportarCsv(LibroDiarioInstancia libro, string rutaArchivo)
        {
            if (libro == null) throw new ArgumentNullException(nameof(libro), "La instancia del libro diario no puede ser nula.");
            if (string.IsNullOrWhiteSpace(rutaArchivo)) throw new ArgumentException("La ruta de destino es inválida.", nameof(rutaArchivo));

            // Codificación UTF-8 con BOM para que Microsoft Excel reconozca tildes y caracteres especiales automáticamente
            using var writer = new StreamWriter(rutaArchivo, false, new UTF8Encoding(true));

            // Encabezados estándar de importación/exportación
            writer.WriteLine("NumeroAsiento,Fecha,CuentaCodigo,CuentaNombre,Concepto,Debe,Haber");

            foreach (var asiento in libro.Asientos.OrderBy(a => a.NumeroAsiento))
            {
                if (asiento.Movimientos.Any())
                {
                    foreach (var mov in asiento.Movimientos)
                    {
                        var cuentaDef = CatalogoCuentasConfig.ObtenerPorNombre(mov.CuentaPrincipal);
                        string codigo = cuentaDef?.Codigo ?? string.Empty;

                        string nombreCuenta = string.IsNullOrWhiteSpace(mov.Subcuenta)
                            ? mov.CuentaPrincipal
                            : $"{mov.CuentaPrincipal} - {mov.Subcuenta}";

                        string debeStr = mov.Debe > 0
                            ? mov.Debe.ToString("0.00", CultureInfo.InvariantCulture)
                            : "0.00";

                        string haberStr = mov.Haber > 0
                            ? mov.Haber.ToString("0.00", CultureInfo.InvariantCulture)
                            : "0.00";

                        string fechaStr = asiento.Fecha.ToString("yyyy-MM-dd");

                        writer.WriteLine($"{asiento.NumeroAsiento},{fechaStr},{EscapeCsv(codigo)},{EscapeCsv(nombreCuenta)},{EscapeCsv(asiento.Concepto)},{debeStr},{haberStr}");
                    }
                }
                else
                {
                    string fechaStr = asiento.Fecha.ToString("yyyy-MM-dd");
                    writer.WriteLine($"{asiento.NumeroAsiento},{fechaStr},,,{EscapeCsv(asiento.Concepto)},0.00,0.00");
                }
            }
        }

        private static string EscapeCsv(string? valor)
        {
            if (string.IsNullOrEmpty(valor)) return string.Empty;
            if (valor.Contains(',') || valor.Contains('"') || valor.Contains('\n') || valor.Contains('\r'))
            {
                return $"\"{valor.Replace("\"", "\"\"")}\"";
            }
            return valor;
        }

        // ══════════════════════════════════════════════════════════════
        //  EXPORTACIÓN A PDF (Documento Contable Profesional)
        // ══════════════════════════════════════════════════════════════

        /// <summary>
        /// Genera y exporta un documento contable formal de Libro Diario en formato PDF.
        /// </summary>
        public void ExportarPdf(LibroDiarioInstancia libro, string rutaArchivo)
        {
            if (libro == null) throw new ArgumentNullException(nameof(libro), "La instancia del libro diario no puede ser nula.");
            if (string.IsNullOrWhiteSpace(rutaArchivo)) throw new ArgumentException("La ruta de destino es inválida.", nameof(rutaArchivo));

            using var document = new PdfDocument();
            document.Info.Title = libro.Nombre;
            document.Info.Subject = "Libro Diario General";
            document.Info.Author = string.IsNullOrWhiteSpace(libro.Empresa) ? "Sistema Contable" : libro.Empresa;
            document.Info.CreationDate = DateTime.Now;

            const double marginLeft = 36;
            const double marginTop = 36;
            const double marginBottom = 40;
            const double usableWidth = 540; // 612 - 72

            // Fuentes
            var fntEmpresa = new XFont("Arial", 12, XFontStyleEx.Bold);
            var fntTitulo = new XFont("Arial", 14, XFontStyleEx.Bold);
            var fntSubtitulo = new XFont("Arial", 8.5, XFontStyleEx.Regular);
            var fntTh = new XFont("Arial", 8.5, XFontStyleEx.Bold);
            var fntPartidaHeader = new XFont("Arial", 8.5, XFontStyleEx.Bold);
            var fntRow = new XFont("Arial", 8.5, XFontStyleEx.Regular);
            var fntRowSub = new XFont("Arial", 7.5, XFontStyleEx.Italic);
            var fntGlosa = new XFont("Arial", 8, XFontStyleEx.Italic);
            var fntSubtotal = new XFont("Arial", 8.5, XFontStyleEx.Bold);
            var fntTotales = new XFont("Arial", 9.5, XFontStyleEx.Bold);
            var fntFooter = new XFont("Arial", 7.5, XFontStyleEx.Regular);

            // Pinceles y lápices
            var brNavy = new XSolidBrush(XColor.FromArgb(15, 23, 42));
            var brDark = new XSolidBrush(XColor.FromArgb(30, 41, 59));
            var brMuted = new XSolidBrush(XColor.FromArgb(100, 116, 139));
            var brBlue = new XSolidBrush(XColor.FromArgb(37, 99, 235));
            var brThBg = new XSolidBrush(XColor.FromArgb(201, 218, 236));
            var brPartidaBg = new XSolidBrush(XColor.FromArgb(241, 245, 249));
            var brSubtotalBg = new XSolidBrush(XColor.FromArgb(248, 250, 252));
            var brTotalBg = new XSolidBrush(XColor.FromArgb(226, 232, 240));

            var penBorder = new XPen(XColor.FromArgb(203, 213, 225), 0.75);
            var penLine = new XPen(XColor.FromArgb(226, 232, 240), 0.5);
            var penDouble = new XPen(XColor.FromArgb(15, 23, 42), 1);

            // Anchos de columna
            const double wFecha = 65;
            const double wPartida = 50;
            const double wCuenta = 235;
            const double wDebe = 95;
            const double wHaber = 95;

            double xFecha = marginLeft;
            double xPartida = xFecha + wFecha;
            double xCuenta = xPartida + wPartida;
            double xDebe = xCuenta + wCuenta;
            double xHaber = xDebe + wDebe;

            PdfPage currentPage = document.AddPage();
            currentPage.Size = PdfSharp.PageSize.Letter;
            XGraphics gfx = XGraphics.FromPdfPage(currentPage);
            double yPos = marginTop;

            void DibujarEncabezadoPagina()
            {
                // Nombre de la Empresa
                string empresa = string.IsNullOrWhiteSpace(libro.Empresa) ? "EMPRESA COMERCIAL, S.A. DE C.V." : libro.Empresa.ToUpperInvariant();
                gfx.DrawString(empresa, fntEmpresa, brNavy, new XPoint(marginLeft, yPos));
                yPos += 16;

                // Título del Libro Diario
                string tituloDoc = string.IsNullOrWhiteSpace(libro.Nombre) ? "LIBRO DIARIO GENERAL" : libro.Nombre.ToUpperInvariant();
                gfx.DrawString(tituloDoc, fntTitulo, brBlue, new XPoint(marginLeft, yPos));
                yPos += 16;

                // Metadatos y Período
                string periodo = $"Período: {libro.TextoPeriodo}  |  Moneda: Dólares de los Estados Unidos de América (USD)";
                gfx.DrawString(periodo, fntSubtitulo, brMuted, new XPoint(marginLeft, yPos));
                yPos += 14;

                // Línea divisoria superior
                gfx.DrawLine(penBorder, marginLeft, yPos, marginLeft + usableWidth, yPos);
                yPos += 8;

                // Tabla de Encabezados
                const double thHeight = 22;
                gfx.DrawRectangle(penBorder, brThBg, marginLeft, yPos, usableWidth, thHeight);

                gfx.DrawString("FECHA", fntTh, brNavy, new XPoint(xFecha + 8, yPos + 14));
                gfx.DrawString("PARTIDA", fntTh, brNavy, new XPoint(xPartida + 6, yPos + 14));
                gfx.DrawString("CUENTA / DESCRIPCIÓN", fntTh, brNavy, new XPoint(xCuenta + 8, yPos + 14));

                // Alineación derecha para Debe y Haber
                var szDebe = gfx.MeasureString("DEBE ($)", fntTh);
                gfx.DrawString("DEBE ($)", fntTh, brNavy, new XPoint(xDebe + wDebe - szDebe.Width - 8, yPos + 14));

                var szHaber = gfx.MeasureString("HABER ($)", fntTh);
                gfx.DrawString("HABER ($)", fntTh, brNavy, new XPoint(xHaber + wHaber - szHaber.Width - 8, yPos + 14));

                yPos += thHeight;
            }

            void VerificarSaltoPagina(double alturaRequerida)
            {
                if (yPos + alturaRequerida > currentPage.Height.Point - marginBottom)
                {
                    currentPage = document.AddPage();
                    currentPage.Size = PdfSharp.PageSize.Letter;
                    gfx = XGraphics.FromPdfPage(currentPage);
                    yPos = marginTop;
                    DibujarEncabezadoPagina();
                }
            }

            // Iniciar primera página
            DibujarEncabezadoPagina();

            // Iterar Asientos Contables
            foreach (var asiento in libro.Asientos.OrderBy(a => a.NumeroAsiento))
            {
                // Estimar altura del bloque del asiento: Encabezado(20) + Movimientos(18 c/u) + Glosa(18) + Subtotal(18)
                double alturaAsiento = 20 + (asiento.Movimientos.Count * 18) + 18 + 18;
                VerificarSaltoPagina(Math.Min(alturaAsiento, 120));

                // 1. Fila de Encabezado de Partida
                const double hPartida = 20;
                gfx.DrawRectangle(penBorder, brPartidaBg, marginLeft, yPos, usableWidth, hPartida);

                gfx.DrawString(asiento.Fecha.ToString("dd/MM/yyyy"), fntPartidaHeader, brDark, new XPoint(xFecha + 8, yPos + 13));
                gfx.DrawString($"Partida #{asiento.NumeroAsiento}", fntPartidaHeader, brBlue, new XPoint(xPartida + 6, yPos + 13));
                gfx.DrawString($"Asiento Contable #{asiento.NumeroAsiento}", fntPartidaHeader, brDark, new XPoint(xCuenta + 8, yPos + 13));

                yPos += hPartida;

                // 2. Movimientos Contables
                foreach (var mov in asiento.Movimientos)
                {
                    VerificarSaltoPagina(18);

                    const double hRow = 18;
                    gfx.DrawRectangle(penBorder, marginLeft, yPos, usableWidth, hRow);

                    // Cuenta Principal
                    gfx.DrawString(mov.CuentaPrincipal, fntRow, brNavy, new XPoint(xCuenta + 12, yPos + 12));

                    // Subcuenta (si existe)
                    if (!string.IsNullOrWhiteSpace(mov.Subcuenta))
                    {
                        gfx.DrawString($"({mov.Subcuenta})", fntRowSub, brMuted, new XPoint(xCuenta + 180, yPos + 12));
                    }

                    // Debe
                    if (mov.Debe > 0)
                    {
                        string strDebe = mov.Debe.ToString("$#,##0.00", UsCulture);
                        var sz = gfx.MeasureString(strDebe, fntRow);
                        gfx.DrawString(strDebe, fntRow, brNavy, new XPoint(xDebe + wDebe - sz.Width - 8, yPos + 12));
                    }
                    else
                    {
                        var sz = gfx.MeasureString("—", fntRow);
                        gfx.DrawString("—", fntRow, brMuted, new XPoint(xDebe + wDebe - sz.Width - 8, yPos + 12));
                    }

                    // Haber
                    if (mov.Haber > 0)
                    {
                        string strHaber = mov.Haber.ToString("$#,##0.00", UsCulture);
                        var sz = gfx.MeasureString(strHaber, fntRow);
                        gfx.DrawString(strHaber, fntRow, brNavy, new XPoint(xHaber + wHaber - sz.Width - 8, yPos + 12));
                    }
                    else
                    {
                        var sz = gfx.MeasureString("—", fntRow);
                        gfx.DrawString("—", fntRow, brMuted, new XPoint(xHaber + wHaber - sz.Width - 8, yPos + 12));
                    }

                    yPos += hRow;
                }

                // 3. Glosa / Concepto
                if (!string.IsNullOrWhiteSpace(asiento.Concepto))
                {
                    VerificarSaltoPagina(18);
                    const double hGlosa = 18;
                    gfx.DrawRectangle(penBorder, marginLeft, yPos, usableWidth, hGlosa);

                    string glosaTexto = $"V/ {asiento.Concepto}";
                    if (glosaTexto.Length > 85) glosaTexto = glosaTexto.Substring(0, 82) + "...";

                    gfx.DrawString(glosaTexto, fntGlosa, brMuted, new XPoint(xCuenta + 12, yPos + 12));
                    yPos += hGlosa;
                }

                // 4. Subtotales de la Partida
                VerificarSaltoPagina(18);
                const double hSubtot = 18;
                gfx.DrawRectangle(penBorder, brSubtotalBg, marginLeft, yPos, usableWidth, hSubtot);

                gfx.DrawString($"Subtotal Partida #{asiento.NumeroAsiento}:", fntSubtotal, brDark, new XPoint(xCuenta + 100, yPos + 12));

                string sDebe = asiento.TotalDebe.ToString("$#,##0.00", UsCulture);
                var szSubDebe = gfx.MeasureString(sDebe, fntSubtotal);
                gfx.DrawString(sDebe, fntSubtotal, brDark, new XPoint(xDebe + wDebe - szSubDebe.Width - 8, yPos + 12));

                string sHaber = asiento.TotalHaber.ToString("$#,##0.00", UsCulture);
                var szSubHaber = gfx.MeasureString(sHaber, fntSubtotal);
                gfx.DrawString(sHaber, fntSubtotal, brDark, new XPoint(xHaber + wHaber - szSubHaber.Width - 8, yPos + 12));

                yPos += hSubtot + 6; // Pequeña separación visual entre partidas
            }

            // 5. SUMAS IGUALES TOTALES
            VerificarSaltoPagina(36);
            yPos += 4;
            const double hTotales = 24;
            gfx.DrawRectangle(penDouble, brTotalBg, marginLeft, yPos, usableWidth, hTotales);

            gfx.DrawString("SUMAS IGUALES TOTALES:", fntTotales, brNavy, new XPoint(xCuenta + 60, yPos + 16));

            string totalDebeStr = libro.TotalDebe.ToString("$#,##0.00", UsCulture);
            var szTotDebe = gfx.MeasureString(totalDebeStr, fntTotales);
            gfx.DrawString(totalDebeStr, fntTotales, brNavy, new XPoint(xDebe + wDebe - szTotDebe.Width - 8, yPos + 16));

            string totalHaberStr = libro.TotalHaber.ToString("$#,##0.00", UsCulture);
            var szTotHaber = gfx.MeasureString(totalHaberStr, fntTotales);
            gfx.DrawString(totalHaberStr, fntTotales, brNavy, new XPoint(xHaber + wHaber - szTotHaber.Width - 8, yPos + 16));

            yPos += hTotales + 10;

            // Badge de cuadre final
            bool estaCuadrado = libro.Asientos.Count > 0 && Math.Round(libro.TotalDebe, 2) == Math.Round(libro.TotalHaber, 2);
            string estadoCuadre = estaCuadrado
                ? "✓ Documento Contable Cuadrado (Total Debe = Total Haber)"
                : $"⚠ Advertencia: El Libro Diario presenta una diferencia de {Math.Abs(libro.TotalDebe - libro.TotalHaber).ToString("$#,##0.00", UsCulture)}";

            var brBadge = estaCuadrado ? new XSolidBrush(XColor.FromArgb(22, 163, 74)) : new XSolidBrush(XColor.FromArgb(220, 38, 38));
            gfx.DrawString(estadoCuadre, fntSubtotal, brBadge, new XPoint(marginLeft, yPos + 4));

            // Numeración de páginas en pie de página para todas las páginas
            int totalPages = document.PageCount;
            for (int i = 0; i < totalPages; i++)
            {
                var page = document.Pages[i];
                using var pageGfx = XGraphics.FromPdfPage(page);

                double footerY = page.Height.Point - 20;
                pageGfx.DrawLine(penLine, marginLeft, footerY - 8, marginLeft + usableWidth, footerY - 8);

                string infoGen = $"Generado el {DateTime.Now:dd/MM/yyyy HH:mm} · Sistema Contable Computarizado";
                pageGfx.DrawString(infoGen, fntFooter, brMuted, new XPoint(marginLeft, footerY));

                string numPag = $"Página {i + 1} de {totalPages}";
                var szNum = pageGfx.MeasureString(numPag, fntFooter);
                pageGfx.DrawString(numPag, fntFooter, brMuted, new XPoint(marginLeft + usableWidth - szNum.Width, footerY));
            }

            document.Save(rutaArchivo);
        }
    }
}
