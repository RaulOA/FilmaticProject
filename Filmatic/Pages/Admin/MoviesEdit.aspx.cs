using Filmatic.Data;
using Filmatic.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls; 

namespace Filmatic.Pages.Admin
{
    public partial class moviesCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Boolean resultValidaAdminUser = ValidateUserIsAdmin();

            if (!resultValidaAdminUser) return;

            string idMovie = Request.QueryString["idMovie"];

            if (idMovie == null || idMovie.Length < 1)
            {
                formTitle.InnerText = "Crear Peliculas";
                lblMovieId.Visible = false;
                btnSave.Text = "Crear Pelicula";
                return;
            }


            formTitle.InnerText = $"Actualizando Pelicula #{idMovie}";
            lblMovieId.Visible = true;
            btnSave.Text = "Actualizar Pelicula";

            lblMovieId.Attributes.Add("disabled", "");
            lblMovieId.Text = idMovie;

            if (!IsPostBack)
            {
                if (idMovie.Length < 1)
                {
                    return;
                }

                LoadFormDataFromDB(idMovie);

            }

            LoadLanguageList();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            string idMovie = lblMovieId.Text;
            string titleMovie = lblMovieTitle.Text;
            string synopsisMovie = lblMovieSynopsis.Text;
            string countryMovie = lblMovieCountry.Text;
            string directorsMovie = lblMovieDirectors.Text;
            string actorsMovie = lblMovieActors.Text;
            string writersMovie = lblMovieWriters.Text;
            int yearMovie = Int16.Parse(lblMovieYear.Text);
            DateTime relased_dateMovie = DateTime.Parse(lblMovieReleaseDate.Text);
            string url_posterMovie = lblMoviePosterUrl.Text;
            string clasificationMovie = lblMovieClasification.Text;
            decimal durationMovie = 0;
            decimal.TryParse(lblMovieDuration.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out durationMovie);
            string languageMovi = ddlMovieLanguage.SelectedValue;
            string urlCarrouse= lblMovieCarrouselUrl.Text;

            string resultSaveDataFromDB = SaveDataFromDB(
                            idMovie,
                            titleMovie,
                            synopsisMovie,
                            countryMovie,
                            directorsMovie,
                            actorsMovie,
                            writersMovie,
                            yearMovie,
                            relased_dateMovie,
                            url_posterMovie,
                            clasificationMovie,
                            durationMovie,
                            languageMovi,
                            urlCarrouse
                );

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


        private void LoadLanguageList()
        {
            ddlMovieLanguage.Items.Clear();
            ddlMovieLanguage.Items.Add(new ListItem("Español", "ES"));
            ddlMovieLanguage.Items.Add(new ListItem("Ingles", "EN")); 
        }


        private void LoadFormDataFromDB(string _idMovie)
        {
            using (var context = new CineMaxTicketsDB11Entities3())
            {
                try
                {

                    sp_ManageDMLCinemaCatMovies_Result dataMovie = context.sp_ManageDMLCinemaCatMovies(
                        GetSessionUserData().id_usuario, 
                        "S",
                        _idMovie,
                        null,null,null,null,null,null,null,null,null,null,null,null,null
                    ).FirstOrDefault();

                    
                    if (dataMovie == null)
                    {
                        ShowAlert("E", "Error al obtener datos", $"No se encontraron datos para la categoría {_idMovie}");
                        return;
                    };

                    lblMovieId.Text = dataMovie.id;
                    lblMovieTitle.Text = dataMovie.title;
                    lblMovieSynopsis.Text = dataMovie.synopsis;
                    lblMovieCountry.Text = dataMovie.country;
                    lblMovieDirectors.Text = dataMovie.directors;
                    lblMovieActors.Text = dataMovie.actors;
                    lblMovieWriters.Text = dataMovie.writers;
                    lblMovieYear.Text = dataMovie.year.ToString();

                    lblMovieReleaseDate.Text = dataMovie.relased_date?.ToString("yyyy-MM-dd"); 
                    lblMoviePosterUrl.Text = dataMovie.url_poster;
                    lblMovieClasification.Text = dataMovie.clasification;
                    lblMovieCarrouselUrl.Text = dataMovie.url_carrousel;
                    lblMovieDuration.Text = dataMovie.duration?.ToString().Replace(",", ".");
                    ddlMovieLanguage.SelectedValue = dataMovie.language;
                    ShowAlert("S", "Se han obtenido datos con éxito!", "");

                }
                catch (Exception e)
                {
                    ShowAlert("E", "Error al obtener datos", e.Message);
                }
            }
        }


        /// <summary>
        /// Se encarga de actualizar la información en base de datos
        /// </summary>
        /// <param name="_codeGenreMovie"></param>
        /// <param name="_titleGenreMovie"></param>
        /// <param name="_descriptionGenreMovie"></param>
        /// <returns></returns>
        private string SaveDataFromDB(
            string _idMovie,
            string _titleMovie,
            string _synopsisMovie,
            string _countryMovie,
            string _directorsMovie,
            string _actorsMovie,
            string _writersMovie,
            int _yearMovie,
            DateTime _relased_dateMovie,
            string _url_posterMovie,
            string _clasificationMovie,
            decimal _durationMovie,
            string _languageMovie,
            string _urlCarrousel
            )
        {
            using (var context = new CineMaxTicketsDB11Entities3())
            {
                try
                {
                    string actionDML = "U";
                    string idMovie = Request.QueryString["idMovie"];


                    if (idMovie == null || idMovie.Length < 1)
                    {
                        actionDML = "C";
                    }

                    context.sp_ManageDMLCinemaCatMovies(
                        GetSessionUserData().id_usuario,
                       actionDML,
                        _idMovie,
                        _titleMovie,
                        _synopsisMovie,
                        _countryMovie,
                        _directorsMovie,
                        _actorsMovie,
                        _writersMovie,
                        _yearMovie,
                        _relased_dateMovie,
                        _url_posterMovie,
                        _clasificationMovie,
                        _durationMovie,
                        _languageMovie,
                        _urlCarrousel
                        );
                    return null;
                }
                catch (Exception e)
                {
                    return e.Message;
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