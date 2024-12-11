using Filmatic.Data;
using Filmatic.Models;
using System;
using System.Linq;
using System.Web.UI;

namespace Filmatic
{
    public partial class UserEdit : Page
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
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Captura de los valores ingresados en los TextBox
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Llamar al método de validación
            if (!ValidateInputs(username, email, phone, password, confirmPassword))
            {
                return; // Si la validación falla, detener el proceso
            }

            // Recupera el objeto de sesión
            User userdata = (User)Session["user_logged"];

            if (userdata != null)
            {
                // Asigna los valores del usuario a variables
                string idUser = userdata.IdUser;

                try
                {
                    using (var context = new CineMaxTicketsDB11Entities3()) // Reemplaza con el nombre correcto de tu DbContext
                    {
                        // Llamada al procedimiento almacenado para actualizar el usuario
                        int result = context.P_UpdateUser(
                            lv_id_user: idUser,          // ID del usuario logueado
                            lv_username: username,       // Nuevo nombre de usuario (puede ser el mismo si no se ha cambiado)
                            lv_name: userdata.Name,      // Nombre actual (se puede modificar si es necesario)
                            lv_lastname: userdata.LastName, // Apellido actual (se puede modificar si es necesario)
                            lv_email: email,             // Nuevo email
                            lv_phone_number: phone,      // Nuevo número de teléfono
                            lv_password: password        // Nueva contraseña (si se quiere cambiar)
                        );

                        if (result > 0)
                        {
                            lblMessage.Text = "Datos actualizados correctamente.";
                        }
                        else
                        {
                            lblMessage.Text = "No se pudo actualizar la información del usuario.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Ocurrió un error: " + ex.Message;
                }
            }
            else
            {
                // Si el objeto no está en sesión (no se ha iniciado sesión o la sesión ha caducado)
                lblMessage.Text = "No hay un usuario logueado en la sesión.";
            }
        }


        // Método para validar los datos ingresados
        private bool ValidateInputs(string username, string email, string phone, string password, string confirmPassword)
        {
            // Validar que ningún campo esté vacío
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "Todos los campos son obligatorios.";
                return false;
            }

            // Validar que el email sea válido
            if (!IsValidEmail(email))
            {
                lblMessage.Text = "El correo electrónico no es válido.";
                return false;
            }

            // Validar que las contraseñas coincidan
            if (password != confirmPassword)
            {
                lblMessage.Text = "Las contraseñas no coinciden.";
                return false;
            }

            // Si todo está bien
            return true;
        }

        // Método para validar el formato del correo electrónico
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


    }
}