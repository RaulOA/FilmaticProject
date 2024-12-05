using Filmatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Filmatic
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
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
            rUser.IdUser = null;
            rUser.IsAdmin = false;

            if (Session == null) return rUser;

            if (Session["user_logged"] == null) return rUser;

            return Session["user_logged"] as User;
        }

        /// <summary>
        /// Se encarga de validar la data en session del usuario e identificar si está logeado
        /// </summary>
        /// <returns></returns>
        public Boolean UserIsLogged()
        {
            if (Session == null) return false;
            if (Session["user_logged"] == null) return false;

            if (GetSessionUserData().IdUser == null) return false;

            return true;
        }

        /// <summary>
        /// Se encarga saber si el usuario tiene el rol de Admin 
        /// </summary>
        /// <returns></returns>
        public Boolean UserIsAdmin()
        {
            return GetSessionUserData().IsAdmin;
        }


        /// <summary>
        /// Se encarga saber si el usuario tiene el rol de Admin 
        /// </summary>
        /// <returns></returns>
        public void ValidateUserIsAdmin()
        {
            if (GetSessionUserData().IsAdmin) return;

            Response.Redirect("/Pages/Unauthorized");
        }
    }
}