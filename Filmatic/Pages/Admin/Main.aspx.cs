using Filmatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Filmatic.Pages.Admin
{
    public partial class _Admin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Boolean resultValidaAdminUser = ValidateUserIsAdmin();
            if (!resultValidaAdminUser) return;
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
