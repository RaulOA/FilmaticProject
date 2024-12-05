using Filmatic.Data;
using Filmatic.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Filmatic.Pages.Admin
{
    public partial class GenresMoviesEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Boolean resultValidaAdminUser = ValidateUserIsAdmin();

            if (!resultValidaAdminUser) return;


            string codeGenreMovie = Request.QueryString["code"];

            if (codeGenreMovie == null || codeGenreMovie.Length < 1)
            {
                formTitle.InnerText = "Crear Genero Peliculas";
                txtCode.Visible = true;
                return;
            }


            formTitle.InnerText = $"Actualizando Genero Pelicula #{codeGenreMovie}";
            txtCode.Visible = false;

            txtCode.Attributes.Add("disabled", "");
            txtCode.Text = codeGenreMovie;

            if (!IsPostBack)
            {


                if (codeGenreMovie.Length < 1)
                {
                    return;
                }

                LoadFormDataFromDB(codeGenreMovie);

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string codeGenreMovie = Request.QueryString["code"];
            string titleGenreMovie = txtTitle.Text;
            string descriptionGenreMovie = txtDescription.Text;
            string resultSaveDataFromDB = SaveDataFromDB(codeGenreMovie, titleGenreMovie, descriptionGenreMovie);

            // Valida el resultado
            if (resultSaveDataFromDB != null)
            {
                ShowAlert("E", "Error al modificar la información!", resultSaveDataFromDB);
            }
            else
            {
                ShowAlert("S", "Se ha actualizado con éxito!", "");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            string codeGenreMovie = Request.QueryString["code"];
            string resultDeleteDataFromDB = DeleteDataFromDB(codeGenreMovie);

            // Valida el resultado
            if (resultDeleteDataFromDB != null)
            {
                ShowAlert("E", "Error al eliminar la información!", resultDeleteDataFromDB);
            }
            else
            {
                ShowAlert("S", "Se ha eliminado con éxito!", "");
                Response.Redirect("/Pages/Admin/GenresMoviesList");
                // Se debe redireccionar
            }
        }

        /// <summary>
        /// Se encarga de actualizar la información en base de datos
        /// </summary>
        /// <param name="_codeGenreMovie"></param>
        /// <param name="_titleGenreMovie"></param>
        /// <param name="_descriptionGenreMovie"></param>
        /// <returns></returns>
        private string SaveDataFromDB(string _codeGenreMovie, string _titleGenreMovie, string _descriptionGenreMovie)
        {
            using (var context = new CineMaxTicketsDB11Entities3())
            {
                try
                {
                    context.sp_ManageDMLCinemaGenresMovie(GetSessionUserData().IdUser, "U", _codeGenreMovie, _titleGenreMovie, _descriptionGenreMovie);
                    return null;
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }


        /// <summary>
        /// Se encarga de eliminar la información en base de datos
        /// </summary>
        /// <param name="_codeGenreMovie"></param>
        /// <returns></returns>
        private string DeleteDataFromDB(string _codeGenreMovie)
        {
            using (var context = new CineMaxTicketsDB11Entities3())
            {
                try
                {
                    context.sp_ManageDMLCinemaGenresMovie(GetSessionUserData().IdUser, "D", _codeGenreMovie, null, null);

                    return null;
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }

        }

        private void LoadFormDataFromDB(string _codeGenreMovie)
        {
            using (var context = new CineMaxTicketsDB11Entities3())
            {
                try
                {
                    sp_ManageDMLCinemaGenresMovie_Result dataGenreMovie = context.sp_ManageDMLCinemaGenresMovie(GetSessionUserData().IdUser, "S", _codeGenreMovie, null, null).FirstOrDefault();

                    if (dataGenreMovie == null)
                    {
                        ShowAlert("E", "Error al obtener datos", $"No se encontraron datos para la categoría {_codeGenreMovie}");
                        return;
                    };

                    txtCode.Text = dataGenreMovie.code;
                    txtTitle.Text = dataGenreMovie.title;
                    txtDescription.Text = dataGenreMovie.description;
                    ShowAlert("S", "Se han obtenido datos con éxito!", "");

                }
                catch (Exception e)
                {
                    ShowAlert("E", "Error al obtener datos", e.Message);
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
        private User GetSessionUserData()
        {
            User rUser = new User();
            rUser.IdUser = null;
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


            if (user.IdUser == null)
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