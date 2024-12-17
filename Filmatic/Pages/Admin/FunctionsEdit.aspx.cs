using Filmatic.Data;
using Filmatic.Models;
using Microsoft.Ajax.Utilities;
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
    public partial class CreateFunction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Boolean resultValidaAdminUser = ValidateUserIsAdmin();

            if (!resultValidaAdminUser) return;

            string idFunctionQS = Request.QueryString["idFunction"];

            
            if (!IsPostBack)
            {
                LoadDataMovies();
                LoadDataRooms();
                LoadDataFormatMovie();
            }

            if (idFunctionQS == null || idFunctionQS.Length < 1)
            {

                formTitle.InnerText = "Crear Función";
              
                txtId.Visible = false;
                txtCreateAt.Visible = false;
                btnSave.Text = "Crear Función";
                btnGenerateFunctionTickets.Visible = false;
                return;
            }


            formTitle.InnerText = $"Actualizando Función #{idFunctionQS}";
            

            txtId.Attributes.Add("disabled", "");
            txtId.Text = idFunctionQS;

            if (!IsPostBack)
            {
                

                if (idFunctionQS.Length < 1)
                {
                    return;
                }

                string msgErrorLoadData = LoadFunctionData(idFunctionQS);

                if (!msgErrorLoadData.IsNullOrWhiteSpace())
                {
                    ShowAlert("E", "Error al cargar datos", msgErrorLoadData);
                } else
                {
                    btnSave.Text = "Actualizar Función";
                    txtId.Visible = true;
                    btnGenerateFunctionTickets.Visible = true;
                }


            }
        }

        protected void btnGenerateFunctionTickets_Click(object sender, EventArgs e)
        {
            string msgErrorGenerateTickets = GenerateFunctionTicketsData(txtId.Text);

            if (msgErrorGenerateTickets != null)
            {
                ShowAlert("E", "Error al generar los tickets!", msgErrorGenerateTickets);
            }
            else
            {
                ShowAlert("S", "Se han generado los tickets con éxito!", "");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string msgResultSaveData = SaveFunction();

            if (msgResultSaveData != null)
            {
                ShowAlert("E", "Error al modificar la información!", msgResultSaveData);
            }
            else
            {
                ShowAlert("S", "Se ha actualizado con éxito!", "");
            }
        }



        private void LoadDataFormatMovie()
        {
            ddlFormatMovie.Items.Clear(); 
            ddlFormatMovie.Items.Add(new ListItem("-- Selecciona el formato --", null));
            ddlFormatMovie.Items.Add(new ListItem("2D", "2D"));
            ddlFormatMovie.Items.Add(new ListItem("3D", "3D"));
        }


        private void LoadDataMovies()
        {
            ddlIdMovie.Items.Clear();
            ddlIdMovie.Items.Add(new ListItem("-- Selecciona la pélicula --", null));
            using (var context = new CineMaxTicketsDB11Entities3())
            {
                List< sp_ManageDMLCinemaCatMovies_Result > dataMovies = context.sp_ManageDMLCinemaCatMovies(GetSessionUserData().id_usuario, "S", null, null, null, null, null, null, null, null, null, null, null, null, null, null).ToList();

                dataMovies.ForEach(movie =>
                {
                    ddlIdMovie.Items.Add(new ListItem(movie.title, movie.id.Trim()));
                });
            }
        }

        private void LoadDataRooms ()
        {
            ddlIdRoom.Items.Clear();
            ddlIdRoom.Items.Add(new ListItem("-- Selecciona la sala --", null));
            using (var context = new CineMaxTicketsDB11Entities3())
            {
                List<sp_ManageDMLCinemaAgencyRooms_Result> dataAgencyRooms = context.sp_ManageDMLCinemaAgencyRooms(GetSessionUserData().id_usuario, "S", null, null, null, null, null, null, null, null ).ToList();
                dataAgencyRooms.ForEach(room =>
                {
                    ddlIdRoom.Items.Add(new ListItem(room.title, room.id.Trim()));
                }); 
            }


        }

        protected string GenerateFunctionTicketsData(string _idFunction)
        {
            try {
                using (var context = new CineMaxTicketsDB11Entities3())
                {
                    context.sp_CreateCinemaFunctionTickets(GetSessionUserData().id_usuario, _idFunction);
                    return null;
                }
            } catch(Exception e)
            {
                return e.Message;
            }

        }
        protected string LoadFunctionData(string _idFunction)
        {
            try
            {
                txtId.Text = _idFunction;

                using (var context = new CineMaxTicketsDB11Entities3())
                {
                    sp_ManageDMLCinemaFunctions_Result dataFunction = context.sp_ManageDMLCinemaFunctions(
                        GetSessionUserData().id_usuario,"S",_idFunction,null,null,null,null,null,null).First();
                    ddlFormatMovie.SelectedValue = dataFunction.format_movie;
                    txtDuration.Text = dataFunction.duration?.ToString("F2");
                    txtTicketPrice.Text = dataFunction.ticket_price.ToString("F2");
                    txtStartDate.Text  = dataFunction.start_date?.ToString("yyyy-MM-ddTHH:mm");
                    txtCreateAt.Text = dataFunction.create_at.ToString("yyyy-MM-ddTHH:mm");
                    ddlIdMovie.SelectedValue = dataFunction.id_movie.Trim();
                    ddlStatus.SelectedValue = dataFunction.status.Trim();
                    ddlIdRoom.SelectedValue = dataFunction.id_room.Trim();
                    ddlFormatMovie.SelectedValue = dataFunction.format_movie.Trim();
                }
                return null;
            }catch(Exception e)
            {
                return e.Message;
            }


        }

        private string SaveFunction()
        {
            try{

                // Validar y procesar los datos ingresados por el usuario.
                if (!Page.IsValid) return "Pagina no es válida";
                
                string actionDML = "U";
                string idFunctionQS = Request.QueryString["idFunction"];

                if (idFunctionQS == null || idFunctionQS.Length < 1)
                {
                    actionDML = "C";
                }

                string idFunction = idFunctionQS;
                string idSala = ddlIdRoom.SelectedItem.Value.Trim();
                //DateTime fechaCreacion = DateTime.Parse(txtCreateAt.Text);
            
                decimal duracion = 0;
                decimal.TryParse(txtDuration.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out duracion);

                DateTime fechaInicio = DateTime.Parse(txtStartDate.Text);
                string idPelicula = ddlIdMovie.SelectedItem.Value.Trim();
                string formato = ddlFormatMovie.SelectedItem.Value.Trim();
                decimal precio; 
                decimal.TryParse(txtTicketPrice.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out precio);
                 
                // Aquí se procesan los datos para guardar o actualizar en la base de datos.
                // Si es una edición (si hay un ID) o una nueva función.

                using (var context = new CineMaxTicketsDB11Entities3())
                {
                    var newData = context.sp_ManageDMLCinemaFunctions(
                        GetSessionUserData().id_usuario, 
                        actionDML,
                        idFunction,
                        idSala,
                        duracion,
                        fechaInicio,
                        idPelicula,
                        formato,
                        precio
                        ).FirstOrDefault();
                    if (actionDML == "C")
                    {
                        Response.Redirect($"?idFunction={newData.id}");
                    }
                }
                    

                return null;
                
            } catch (Exception e)
            {
                return e.Message;
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
