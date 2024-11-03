using Filmatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Filmatic
{
    public partial class _Billboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            welcomeMsg.Style["display"] = "none";
            loginMsg.Style["display"] = "none";


            if (Session["user_logged"] != null)
            {
                User userData = Session["user_logged"] as User;

                welcomeMsg.Style["display"] = "inherit";

                welcomeMsg.InnerHtml = "<h4>¡Bienvenido de nuevo!</h4>  " +
                    $"<p> Hola <strong>{userData.Name} {userData.LastName}</strong>, nos alegra verte de nuevo! </p>";

            } else
            {
                loginMsg.Style["display"] = "inherit";
            }

        }
    }
}