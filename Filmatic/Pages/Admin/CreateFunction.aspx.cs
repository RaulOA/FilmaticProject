using System;
using System.Web.UI;

namespace Filmatic
{
    public partial class CreateFunction : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si no hay un usuario autenticado en la sesión
            if (Session["user_logged"] == null)
            {
                // Redirigir al usuario a la página de inicio de sesión si no ha iniciado sesión
                Response.Redirect("/Login.aspx");
                return;
            }
            if (!IsPostBack)
            {
                // Verificar si existe un ID de función en la URL para edición.
                string functionId = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(functionId))
                {
                    // Cargar la función existente en los controles.
                    LoadFunctionData(functionId);
                }
            }
        }

        protected void LoadFunctionData(string functionId)
        {

            // Simular datos cargados para mostrar en los campos.
            inputId.Text = functionId;
            ddlIdRoom.SelectedValue = "1";  // ID de la sala
            inputCreateAt.Text = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");  // Fecha de creación
            inputDuration.Text = "2";  // Duración
            inputStartDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-ddTHH:mm");  // Fecha de inicio
            ddlIdMovie.SelectedValue = "10";  // ID de la película
            inputFormatMovie.Text = "3D";  // Formato de la película
            inputTicketPrice.Text = "7.50";  // Precio de la entrada
            inputStatus.Text = "Activo";  // Estado
        }

        protected void SaveFunction(object sender, EventArgs e)
        {
            // Validar y procesar los datos ingresados por el usuario.
            if (Page.IsValid)
            {
                string id = inputId.Text.Trim();
                string idSala = ddlIdRoom.SelectedValue;
                DateTime fechaCreacion = DateTime.Parse(inputCreateAt.Text);
                double duracion = double.Parse(inputDuration.Text);
                DateTime fechaInicio = DateTime.Parse(inputStartDate.Text);
                string idPelicula = ddlIdMovie.SelectedValue;
                string formato = inputFormatMovie.Text.Trim();
                decimal precio = decimal.Parse(inputTicketPrice.Text);
                string estado = inputStatus.Text.Trim();

                // Aquí se procesan los datos para guardar o actualizar en la base de datos.
                // Si es una edición (si hay un ID) o una nueva función.

                if (!string.IsNullOrEmpty(id))
                {
                    // Actualizar función existente
                }
                else
                {
                    // Crear nueva función
                }

                // Mostrar mensaje de éxito o redirigir a otra página.
            }
        }
    }
}
