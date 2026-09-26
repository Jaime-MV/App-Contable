using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App_Contable.Logica
{
    /// <summary>
    /// Utilidad institucional para copiar información estructurada de tablas contables (DataGridView)
    /// al portapapeles en formato TSV (Tab-Separated Values) compatible nativamente con Microsoft Excel.
    /// </summary>
    public static class PortapapelesContableHelper
    {
        /// <summary>
        /// Copia todas las celdas, filas y columnas visibles de una grilla contable al portapapeles,
        /// asegurando que se peguen alineadas en Microsoft Excel con notificación visual temporal sin bloqueo.
        /// </summary>
        /// <param name="dgv">DataGridView de origen con los datos contables.</param>
        /// <param name="botonNotificacion">Botón opcional que cambiará su estado temporalmente para notificar al usuario.</param>
        /// <param name="nombreReporte">Nombre descriptivo del reporte para feedback.</param>
        public static void CopiarGrillaAlPortapapeles(DataGridView dgv, Button? botonNotificacion = null, string? nombreReporte = null)
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                if (botonNotificacion != null)
                {
                    MostrarFeedbackBoton(botonNotificacion, "⚠ Sin datos", Color.FromArgb(254, 242, 242), Color.FromArgb(185, 28, 28));
                }
                return;
            }

            var sb = new StringBuilder();

            // 1. Extraer encabezados de columnas visibles en orden de visualización
            var columnasVisibles = dgv.Columns
                .Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .OrderBy(c => c.DisplayIndex)
                .ToList();

            var encabezados = columnasVisibles.Select(c => LimpiarTextoParaExcel(c.HeaderText));
            sb.AppendLine(string.Join("\t", encabezados));

            // 2. Recorrer fila por fila en el orden exacto de la grilla
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                var celdas = new List<string>();
                foreach (var col in columnasVisibles)
                {
                    var cell = row.Cells[col.Index];
                    string valor = cell.FormattedValue?.ToString() ?? string.Empty;
                    celdas.Add(LimpiarTextoParaExcel(valor));
                }

                sb.AppendLine(string.Join("\t", celdas));
            }

            // 3. Inyectar al portapapeles en formato UnicodeText para Excel
            try
            {
                Clipboard.SetText(sb.ToString(), TextDataFormat.UnicodeText);

                if (botonNotificacion != null)
                {
                    MostrarFeedbackBoton(botonNotificacion, "✓ ¡Copiado!", Color.FromArgb(240, 253, 244), Color.FromArgb(22, 101, 52));
                }
            }
            catch
            {
                // Fallback por si el portapapeles está bloqueado por otro proceso del sistema
                try
                {
                    Clipboard.SetDataObject(sb.ToString(), true);
                    if (botonNotificacion != null)
                    {
                        MostrarFeedbackBoton(botonNotificacion, "✓ ¡Copiado!", Color.FromArgb(240, 253, 244), Color.FromArgb(22, 101, 52));
                    }
                }
                catch { }
            }
        }

        private static string LimpiarTextoParaExcel(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return string.Empty;
            // Limpia saltos de línea internos o tabulaciones accidentales que quebrarían las celdas en Excel
            return texto.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ").Trim();
        }

        private static void MostrarFeedbackBoton(Button btn, string textoFeedback, Color backColor, Color foreColor)
        {
            string textoOriginal = btn.Text;
            Color backOriginal = btn.BackColor;
            Color foreOriginal = btn.ForeColor;

            btn.Text = textoFeedback;
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;

            var timer = new System.Windows.Forms.Timer { Interval = 2000 };
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();
                if (!btn.IsDisposed)
                {
                    btn.Text = textoOriginal;
                    btn.BackColor = backOriginal;
                    btn.ForeColor = foreOriginal;
                }
            };
            timer.Start();
        }
    }
}

