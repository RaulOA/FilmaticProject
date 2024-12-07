using Filmatic.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Filmatic.Pages
{
    public partial class CreatePaymentCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDateExp.Attributes.Add("pattern", "[0-9][2]\\/[0-9]*");
        }
        

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            using (var context = new CineMaxTicketsDB11Entities3())
            {
                try
                {
                    string representName = txtNameCard.Text;
                    string cardNumber = txtCardNumber.Text;
                    int cardExpMonth = 0;
                    int cardExpYear = 0;
                    string cvCard = txtCV.Text;


                    DateTime date;

                    // Parse the string as MM/yy format
                    if (DateTime.TryParseExact(txtDateExp.Text, "MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        cardExpYear = date.Year;
                        cardExpMonth = date.Month;
                         
                    }

                    var dataInsertPaymentCard = context.sp_ManageDMLPaymentCards("USER02", "C", "USER02", null, representName, cardNumber, cardExpYear, cardExpMonth, cvCard);
                    ShowAlert("S", "¡Se ha creado con éxito!", "");
                    Response.Redirect("/Pages/MyPaymentCards");

                }
                catch (Exception error)
                {
                    ShowAlert("E", "Error al obtener datos", error.Message);
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
    }
}