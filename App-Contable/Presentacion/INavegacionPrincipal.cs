using System;
using System.Linq;
using System.Windows.Forms;

namespace App_Contable.Presentacion
{
    /// <summary>
    /// Contrato para formularios o contenedores que gestionan la navegación de vistas hijas en panel.
    /// </summary>
    public interface INavegacionPrincipal
    {
        void AbrirFormularioEnPanel(Form formHijo);
    }

    /// <summary>
    /// Asistente para resolver la navegación desacoplada dentro de contenedores de Windows Forms.
    /// </summary>
    public static class NavegacionHelper
    {
        /// <summary>
        /// Obtiene la instancia activa de INavegacionPrincipal recorriendo la jerarquía de controles
        /// o consultando los formularios abiertos de la aplicación.
        /// </summary>
        public static INavegacionPrincipal? ObtenerNavegacion(Control? control)
        {
            Control? actual = control;
            while (actual != null)
            {
                if (actual is INavegacionPrincipal nav)
                    return nav;
                actual = actual.Parent;
            }

            return Application.OpenForms.OfType<INavegacionPrincipal>().FirstOrDefault();
        }

        /// <summary>
        /// Abre un nuevo formulario dentro del panel principal si está disponible, o como ventana redimensionable si es independiente.
        /// </summary>
        public static void NavegarA(Control controlOrigen, Form nuevoFormulario)
        {
            var nav = ObtenerNavegacion(controlOrigen);
            if (nav != null)
            {
                nav.AbrirFormularioEnPanel(nuevoFormulario);
                return;
            }

            // Alternativa para ejecución independiente fuera del panel contenedor
            nuevoFormulario.TopLevel = true;
            nuevoFormulario.FormBorderStyle = FormBorderStyle.Sizable;
            nuevoFormulario.StartPosition = FormStartPosition.CenterScreen;
            nuevoFormulario.MaximizeBox = true;
            nuevoFormulario.MinimizeBox = true;
            nuevoFormulario.Show();
        }
    }
}

