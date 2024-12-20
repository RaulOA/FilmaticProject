﻿using Filmatic.Data;
using Filmatic.Models;
using System;
using System.Linq;
using System.Web.UI;

namespace Filmatic
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user_logged"] != null)
            {
                Response.Redirect("/Pages/Billboard");
                return;
            }

            if (!IsPostBack)
            {
                alertMsgLogin.Style["display"] = "none";
            }
        }

        /// <summary>
        /// Cuando se da click en ingresar recupera los datos del formulario 
        /// Luego valida los mismo
        /// Dependiendo de la respuesta de la base de datos ingresa con exito o muetra mensaje de error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnClickLoginUser(object sender, EventArgs e)
        {



            string username = inputEmail.Value;
            string password = inputPassword.Value;

            if (username is null || password is null)
            {
                alertMsgLogin.Style["display"] = "inherit";
                alertMsgLogin.InnerHtml = "Se deben ingresar datos válidos!";
                return;
            }

            sp_LoginUser_Result dataLogin = LoginUser(username, password);

            if (dataLogin.id_usuario == null || dataLogin.mensaje_login != null)
            {
                // Muestra el mensaje
                alertMsgLogin.Style["display"] = "inherit";
                alertMsgLogin.InnerHtml = dataLogin.mensaje_login;
                return;
            }

            // Cuando datos están correcto se hace un Objecto de Usuario

            User userdata = new User();
            userdata.id_usuario = dataLogin.id_usuario;
            userdata.cedula = dataLogin.cedula;
            userdata.nombre = dataLogin.nombre;
            userdata.apellido = dataLogin.apellido;
            userdata.mail = dataLogin.mail;
            userdata.telefono = dataLogin.telefono;
            userdata.usuario = dataLogin.usuario;
            userdata.nacimiento = dataLogin.nacimiento;
            userdata.estado = dataLogin.estado;
            userdata.IsAdmin = dataLogin.admin == "1";

            // El objeto de usuario se carga en la session como user_logged
            Session["user_logged"] = userdata;


            // Se redirige a la pantalla principal
            Response.Redirect("/Pages/Billboard");

        }

        /// <summary>
        /// Se encarga de validar los datos ingresador por el usuario
        /// Si son válidos devuelve el registro de mismo
        /// De lo contario devuelve un mensaje de error a mostrar
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        private sp_LoginUser_Result LoginUser(string username, string password)
        {
            try
            {
                using (var context = new CineMaxTicketsDB11Entities3())
                {
                    // Llamada al procedimiento almacenado
                    var result = context.sp_LoginUser(
                        lv_username: username,
                        lv_password: password
                    );
                    return result.First();
                }
            }
            catch (Exception ex)
            {
                // Logueo de errores en lugar de mostrar al usuario información sensible
                // Aquí podría implementarse un sistema de logging (ej. log4net, Serilog)
                Console.WriteLine($"Error al registrar el validar datos usuario: {ex.Message}");
                sp_LoginUser_Result loginDataError = new sp_LoginUser_Result();
                loginDataError.mensaje_login = $"Ha ocurrido un error al validar los datos! {ex.Message}";
                return loginDataError;
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