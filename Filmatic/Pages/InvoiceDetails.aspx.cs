using Filmatic.Data;
using Filmatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Filmatic.Pages
{
    public partial class InvoiceDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            alertMsg.Style["display"] = "none";
            string idInvoiceQS = Request.QueryString["idInvoice"];

            if (idInvoiceQS == null || idInvoiceQS.Length < 1)
            {
                sectionInvoiceDetails.Style["display"] = "none";
                ShowAlert("E", "Error", "No se ha encontrado la función");
                return;
            }

            if (!IsPostBack)
            {
                int idInvoice = Convert.ToInt32(idInvoiceQS);
                LoadDataInvoiceDetails(idInvoice);
                
            }

        }


        private void LoadDataInvoiceDetails(int _idInvoice)
        {
            using (var context = new CineMaxTicketsDB11Entities3())
            {
                gvInvoiceDetails.DataSource = context.sp_GetInvoiceDetailsByInvoiceId(GetSessionUserData().id_usuario, _idInvoice).ToList();
                gvInvoiceDetails.DataBind();
            }
        }

        public string GetDateFromDateTime(DateTime? _datetime)
        {
            return _datetime?.ToString("D") ?? "";  // Formats the date as "Year-Month-Day"
        }

        public string GetTimeFromDateTime(DateTime? _datetime)
        {
            return _datetime?.ToString("h:mmtt") ?? ""; // Formats the time as "Hour:Minute:Second"
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