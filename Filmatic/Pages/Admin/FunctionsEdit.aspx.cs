using Filmatic.Data;
using Filmatic.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Filmatic
{
    public partial class CreateFunction : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Boolean resultValidaAdminUser = ValidateUserIsAdmin();

            if (!resultValidaAdminUser) return;

            string idFunctionQS = Request.QueryString["idFunction"];

            LoadDataMovies();
            LoadDataRooms();
            LoadDataFormatMovie();

            if (idFunctionQS == null || idFunctionQS.Length < 1)
            {
                formTitle.InnerText = "Crear Función";
                lblId.Visible = false;
                btnSave.Text = "Crear Función";
                return;
            }


            formTitle.InnerText = $"Actualizando Función #{idFunctionQS}";
            lblId.Visible = true;
            btnSave.Text = "Actualizar Función";

            lblId.Attributes.Add("disabled", "");
            lblId.Text = idFunctionQS;

            if (!IsPostBack)
            {
                

                if (idFunctionQS.Length < 1)
                {
                    return;
                }

                LoadFunctionData(idFunctionQS);
                

            }
        }


        private void LoadDataFormatMovie()
        {
            ddlFormatMovie.Items.Clear();
            ddlFormatMovie.Items.Add(new ListItem("2D", "2D"));
            ddlFormatMovie.Items.Add(new ListItem("3D", "3D"));
        }


        private void LoadDataMovies()
        {
            ddlIdMovie.Items.Clear();
            using (var context = new CineMaxTicketsDB11Entities3())
            {
                List< sp_ManageDMLCinemaCatMovies_Result > dataMovies = context.sp_ManageDMLCinemaCatMovies(GetSessionUserData().id_usuario, "S", null, null, null, null, null, null, null, null, null, null, null, null, null, null).ToList();

                dataMovies.ForEach(movie =>
                {
                    ddlIdMovie.Items.Add(new ListItem(movie.title, movie.id));
                });
            }
        }

        private void LoadDataRooms ()
        {
            ddlIdRoom.Items.Clear();

            using (var context = new CineMaxTicketsDB11Entities3())
            {
                List<sp_ManageDMLCinemaAgencyRooms_Result> dataAgencyRooms = context.sp_ManageDMLCinemaAgencyRooms(GetSessionUserData().id_usuario, "S", null, null, null, null, null, null, null, null ).ToList();
                dataAgencyRooms.ForEach(room =>
                {
                    ddlIdRoom.Items.Add(new ListItem(room.title, room.id));
                }); 
            }


        }

        protected void LoadFunctionData(string _idFunction)
        {

            // Simular datos cargados para mostrar en los campos.
            lblId.Text = _idFunction;
            //ddlIdRoom.SelectedValue = "1";  // ID de la sala
            //lblCreateAt.Text = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");  // Fecha de creación
            //lblDuration.Text = "2";  // Duración
            //lblStartDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-ddTHH:mm");  // Fecha de inicio
            //ddlIdMovie.SelectedValue = "10";  // ID de la película
            //lblFormatMovie.Text = "3D";  // Formato de la película
            //lblTicketPrice.Text = "7.50";  // Precio de la entrada
            //lblStatus.Text = "Activo";  // Estado


            using (var context = new CineMaxTicketsDB11Entities3())
            {
                sp_ManageDMLCinemaFunctions_Result dataFunction = context.sp_ManageDMLCinemaFunctions(
                    GetSessionUserData().id_usuario,"S",_idFunction,null,null,null,null,null,null).First();

                ddlFormatMovie.SelectedValue = dataFunction.format_movie;
                lblDuration.Text = dataFunction.duration.ToString().Replace(".", ",");
                lblTicketPrice.Text = dataFunction.ticket_price.ToString().Replace(".", ",");
                lblStartDate.Text  = dataFunction.start_date?.ToString("yyyy-MM-ddTHH:mm");
                lblCreateAt.Text = dataFunction.create_at.ToString("yyyy-MM-ddTHH:mm");
                lblStatus.Text = dataFunction.status;
            }


        }

        protected void SaveFunction(object sender, EventArgs e)
        {
            // Validar y procesar los datos ingresados por el usuario.
            if (Page.IsValid)
            {
                try
                {
                    string actionDML = "U";
                    string idFunctionQS = Request.QueryString["idFunction"];


                    if (idFunctionQS == null || idFunctionQS.Length < 1)
                    {
                        actionDML = "C";
                    }

                    string idFunction = idFunctionQS;
                    string idSala = ddlIdRoom.SelectedValue;
                    //DateTime fechaCreacion = DateTime.Parse(lblCreateAt.Text);
            
                    decimal duracion = 0;
                    decimal.TryParse(lblDuration.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out duracion);

                    DateTime fechaInicio = DateTime.Parse(lblStartDate.Text);
                    string idPelicula = ddlIdMovie.SelectedValue;
                    string formato = ddlFormatMovie.SelectedValue.Trim();
                    decimal precio; 
                    decimal.TryParse(lblTicketPrice.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out precio);

                    string estado = lblStatus.Text.Trim();
                 
                    // Aquí se procesan los datos para guardar o actualizar en la base de datos.
                    // Si es una edición (si hay un ID) o una nueva función.

                    using (var context = new CineMaxTicketsDB11Entities3())
                    {
                        context.sp_ManageDMLCinemaFunctions(
                            GetSessionUserData().id_usuario, 
                            actionDML,
                            idFunction,
                            idSala,
                            duracion,
                            fechaInicio,
                           idPelicula,
                           formato,
                           precio


                            );
                    }
                     ShowAlert("S", "Se ha actualizado con éxito!", "");
                    // Mostrar mensaje de éxito o redirigir a otra página.
                }
                catch (Exception error)
                {
                    ShowAlert("E", "Error al modificar la información!", error.Message);
                }
            }


        }

        /// <summary>
        /// Utilidad para mostrar alertar en el cliente
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_title"></param>
        /// <param name="_description"></param>
        private void ShowAlert(string _type, string _title, string _description)
        {
            // Reset and no show
            alertMsg.Style.Add("display", "none");
            alertMsg.InnerHtml = "";

            string bootrapAlertClass = "";

            switch (_type)
            {
                case "S": { bootrapAlertClass = "alert-success"; break; }
                case "E": { bootrapAlertClass = "alert-danger"; break; }
                case "I": { bootrapAlertClass = "alert-primary"; break; }
                case "W": { bootrapAlertClass = "alert-warning"; break; }
            }

            if (bootrapAlertClass == "") return;


            alertMsg.Style.Add("display", "inherit");
            alertMsg.Attributes.Add("class", $"alert {bootrapAlertClass}");

            alertMsg.InnerHtml = $"<h4 class=\"alert-heading\">{_title}</h4>";
            alertMsg.InnerHtml += $"<p>{_description}</p>";

        }


        /// <summary>
        /// Se encarga de obtener los datos en session del usuario loggedo y devolverlos
        /// Cuando no hay datos el IdUser es null
        /// </summary>
        /// <returns></returns>
        public User GetSessionUserData()
        {
            User rUser = new User();
            rUser.id_usuario = null;
            rUser.IsAdmin = false;

            if (Session == null) return rUser;

            if (Session["user_logged"] == null) return rUser;

            return Session["user_logged"] as User;
        }

        /// <summary>
        /// Valida si el usuario es Admin y está authorizado para visitar la pagina
        /// </summary>
        /// <returns></returns>
        private Boolean ValidateUserIsAdmin()
        {
            if (Session["user_logged"] == null)
            {
                Response.StatusCode = 401;
                Response.Redirect("/Pages/Login");
                return false;
            }

            User user = Session["user_logged"] as User;


            if (user.id_usuario == null)
            {
                Response.StatusCode = 401;
                Response.Redirect("/Pages/Login");
                return false;
            }


            if (!user.IsAdmin)
            {
                Response.StatusCode = 401;
                Response.Redirect("/Pages/Unauthorized");
                return false;
            }

            return true;
        }

    }
}
