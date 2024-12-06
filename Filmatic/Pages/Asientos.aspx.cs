using Filmatic.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI; 
namespace Filmatic
{
    public partial class Asientos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            alertMsg.Style.Add("display", "none");
            string idFunctionQS = Request.QueryString["idFunction"];



            if (idFunctionQS == null || idFunctionQS.Length < 1)
            {
                sectionSelectSeats.Style["display"] = "none";
               ShowAlert("E", "Error", "No se ha encontrado la función");
               return;
            }

            
            // ShowAlert("S", "Se encontro la función", $"La función: {idFunctionQS}");

            Boolean resultLoadDataFunction = LoadDataFunction(idFunctionQS);
            if (!resultLoadDataFunction)
            {
                sectionSelectSeats.Style["display"] = "none";
                return;
            }


            Boolean resultLoadDataTickets = LoadSeatsNoAvailable(idFunctionQS);
            if (!resultLoadDataTickets)
            {
                sectionSelectSeats.Style["display"] = "none";
                return;
            }
             
        }

        private Boolean LoadSeatsNoAvailable(string _idFunction)
        {
            try
            {
                using (var context = new CineMaxTicketsDB11Entities3())
                {
                  List<sp_GetCinemaFunctionTicketsNotAvaible_Result> dataNotAvailableTickets = context.sp_GetCinemaFunctionTicketsNotAvaible(_idFunction).ToList();
                    List<Seats> seatsNoAvailable = new List<Seats>();

                    
                    dataNotAvailableTickets.ForEach((item) =>
                    {
                        seatsNoAvailable.Add(new Seats() { row = item.row_num_seat, col = item.col_num_seat });
                    });

                     StringBuilder stringBuilder = new StringBuilder();
                    using (var stringWriter = new StringWriter(stringBuilder))
                    {
                        new JsonSerializer().Serialize(stringWriter, seatsNoAvailable);
                    }
                    var jsonSeatsNoAvailableStr = stringBuilder.ToString();
                    hdfDataSeatsNoAvaible.Value = jsonSeatsNoAvailableStr;
                }

                return true;
            } catch (Exception e)
            {

                ShowAlert("E", "Error", $"Error al cargar la información de los tiquetes de la función {e.Message}");
                return false;

            }

        }


        private Boolean LoadDataFunction(string _idFunction)
        {
            try
            {
                using (var context = new CineMaxTicketsDB11Entities3())
                {

                    sp_GetCinemaFunctionDataByID_Result result = context.sp_GetCinemaFunctionDataByID(_idFunction).FirstOrDefault();

                    lblMovieName.InnerText = result.movie_title;
                    lblTitleRoom.InnerText = result.room_title;
                    lblFunctionDate.InnerText = result.function_start_date?.ToString("D") ?? "Fecha invalida";
                    lblFunctionDate.InnerText += " a las ";
                    lblFunctionDate.InnerText += result.function_start_date?.ToString("h:mmtt") ?? "Fecha invalida";
                    // lblFunctionDate = result.function_start_date.Value.ToString("dd/MM/yyyy");

                }
                return true;
            }
            catch (Exception e)
            {

                ShowAlert("E", "Error", $"Error al cargar la información de la función{e.Message}");
                return false;
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

        protected void btnGoToPay_Click(object sender, EventArgs e)
        {

        }
    }

    public class Seats
    {
        public string row { get; set; }
        public string col { get; set; }
    }


}

