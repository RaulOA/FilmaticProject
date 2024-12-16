using Filmatic.Data;
using Filmatic.Models;
using System;
using System.Web.UI.WebControls;

namespace Filmatic.Pages
{
    public partial class MyPaymentCards1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Verificar si no hay un usuario autenticado en la sesión
                if (Session["user_logged"] == null)
                {
                    // Redirigir al usuario a la página de inicio de sesión si no ha iniciado sesión
                    Response.Redirect("/Login.aspx");
                    return;
                }
                else
                {
                    LoadDataPaymentCards();
                }
            }
        }


        private void LoadDataPaymentCards()
        {
            using (var context = new CineMaxTicketsDB11Entities3())
            {
                gvPaymentCards.DataSource = context.sp_ManageDMLPaymentCards("GetSessionUserData().id_usuario", "S", "GetSessionUserData().id_usuario", null, null, null, null, null, null);
                gvPaymentCards.DataBind();
            }
        }

        protected void gvPaymentCards_RowDataBound(object sender, GridViewRowEventArgs e)
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