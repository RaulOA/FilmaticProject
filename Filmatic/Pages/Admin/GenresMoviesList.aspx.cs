using Filmatic.Data;
using Filmatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Filmatic.Pages.Admin
{
    public partial class GenresMoviesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Boolean resultValidaAdminUser = ValidateUserIsAdmin();

            if (!resultValidaAdminUser) return;


            if (!IsPostBack)
            {
                using (var context = new CineMaxTicketsDB11Entities3())
                {
                    gv_GenresMovie.DataSource = context.sp_ManageDMLCinemaGenresMovie(GetSessionUserData().id_usuario, "S", null, null, null);
                    gv_GenresMovie.DataBind();
                }
            }

        }

        protected void gv_GenresMovie_RowDataBound(object sender, GridViewRowEventArgs e)
        {

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