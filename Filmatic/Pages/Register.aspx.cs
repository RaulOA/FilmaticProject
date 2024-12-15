using Filmatic.Data;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace Filmatic
{
    public partial class _Register : Page
    {
        /// <summary>
        /// Método que se ejecuta cuando el usuario envía el formulario de registro.
        /// Realiza la validación de los datos y si son válidos, registra al usuario en la base de datos.
        /// </summary>
        /// <param name="sender">El objeto que invoca el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void RegisterUser(object sender, EventArgs e)
        {
            // Recopilación de datos del formulario
            string name = Request.Form["inputName"];
            string lastName = Request.Form["inputLastName"];
            string email = Request.Form["inputEmail"];
            string phoneNumber = Request.Form["inputPhoneNumber"];
            string idDocument = Request.Form["inputIdDocument"];
            string password = Request.Form["inputPassword"];
            string confirmPassword = Request.Form["inputConfirmPassword"];
            string birthDateString = Request.Form["inputBirthDate"];

            // Validación de los datos ingresados
            if (!ValidateInputs(name, lastName, email, phoneNumber, idDocument, password, confirmPassword, birthDateString, out string errorMessage))
            {
                ShowAlert(errorMessage);
                return;
            }

            // Intento de parseo de la fecha de nacimiento
            if (!DateTime.TryParse(birthDateString, out DateTime birthDate))
            {
                ShowAlert("La fecha de nacimiento no es válida.");
                return;
            }

            // Registro del usuario
            if (!CreateUser(name, lastName, email, phoneNumber, idDocument, password, birthDate))
            {
                ShowAlert("Hubo un problema al registrar el usuario.");
            }
            else
            {
                ShowAlert("Usuario registrado exitosamente.");
                //Response.Redirect("Pages/Login.aspx");
            }
        }

        /// <summary>
        /// Valida los datos ingresados en el formulario de registro.
        /// </summary>
        /// <param name="name">Nombre del usuario.</param>
        /// <param name="lastName">Apellido del usuario.</param>
        /// <param name="email">Correo electrónico del usuario.</param>
        /// <param name="phoneNumber">Número de teléfono del usuario.</param>
        /// <param name="idDocument">Número de documento de identificación del usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <param name="confirmPassword">Confirmación de la contraseña.</param>
        /// <param name="birthDateString">Fecha de nacimiento en formato string.</param>
        /// <param name="errorMessage">Mensaje de error a mostrar en caso de validación fallida.</param>
        /// <returns>Retorna verdadero si los datos son válidos, falso en caso contrario.</returns>
        private bool ValidateInputs(string name, string lastName, string email, string phoneNumber, string idDocument, string password, string confirmPassword, string birthDateString, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Validaciones de los campos usando expresiones regulares
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                errorMessage = "El nombre solo puede contener letras.";
                return false;
            }

            if (!Regex.IsMatch(lastName, @"^[a-zA-Z\s]+$"))
            {
                errorMessage = "Los apellidos solo pueden contener letras.";
                return false;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorMessage = "El correo electrónico no es válido.";
                return false;
            }

            if (!Regex.IsMatch(phoneNumber, @"^\d{8}$"))
            {
                errorMessage = "El número de teléfono debe tener exactamente 8 dígitos.";
                return false;
            }

            if (!Regex.IsMatch(idDocument, @"^\d{9}$"))
            {
                errorMessage = "La cédula debe tener exactamente 9 dígitos.";
                return false;
            }

            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$"))
            {
                errorMessage = "La contraseña debe tener al menos 6 caracteres, incluyendo mayúsculas, minúsculas, números y un símbolo.";
                return false;
            }

            if (password != confirmPassword)
            {
                errorMessage = "Las contraseñas no coinciden.";
                return false;
            }

            if (!DateTime.TryParse(birthDateString, out DateTime birthDate) || DateTime.Now.AddYears(-15) < birthDate)
            {
                errorMessage = "Debe ser mayor de 15 años para registrarse.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Crea un nuevo usuario en la base de datos llamando al procedimiento almacenado correspondiente.
        /// </summary>
        /// <param name="name">Nombre del usuario.</param>
        /// <param name="lastName">Apellido del usuario.</param>
        /// <param name="email">Correo electrónico del usuario.</param>
        /// <param name="phoneNumber">Número de teléfono del usuario.</param>
        /// <param name="idDocument">Número de documento de identificación del usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <param name="birthDate">Fecha de nacimiento del usuario.</param>
        /// <returns>Retorna verdadero si el usuario fue creado exitosamente, falso en caso contrario.</returns>
        private bool CreateUser(string name, string lastName, string email, string phoneNumber, string idDocument, string password, DateTime birthDate)
        {
            try
            {
                using (var context = new CineMaxTicketsDB11Entities3())
                {
                    // Generar el nombre de usuario como la primera letra del nombre + apellido
                    string generatedUsername = $"{name.Substring(0, 1).ToLower()}{lastName.ToLower()}";

                    // Eliminar espacios y caracteres especiales (si los hubiera)
                    generatedUsername = new string(generatedUsername.Where(c => char.IsLetterOrDigit(c)).ToArray());

                    // Llamada al procedimiento almacenado
                    int result = context.P_CreateUser(
                        lv_username: generatedUsername,
                        lv_password: password,
                        lv_name: name,
                        lv_lastname: lastName,
                        lv_email: email,
                        lv_phone_number: phoneNumber,
                        lv_id_document: idDocument,
                        lv_birthday_date: birthDate
                    );
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                // Logueo de errores en lugar de mostrar al usuario información sensible
                // Aquí podría implementarse un sistema de logging (ej. log4net, Serilog)
                Console.WriteLine($"Error al registrar el usuario: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Muestra una alerta en la página utilizando JavaScript.
        /// </summary>
        /// <param name="message">El mensaje que se mostrará en la alerta.</param>
        private void ShowAlert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{message}');", true);
        }
    }
}
