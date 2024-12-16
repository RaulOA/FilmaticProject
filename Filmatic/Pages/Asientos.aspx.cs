using Filmatic.Data;
using Filmatic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Services;
using System.Web.UI; 
namespace Filmatic
{
    public partial class Asientos : Page
    {

        string sessionItemData = "data_function";
        string sessionItemTicketSelectedByUser = "ticket_selected_by_user";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            alertMsg.Style.Add("display", "none");
            string idFunctionQS = Request.QueryString["idFunction"];

            totalAmount.InnerText = "0";

            if (!IsPostBack)
            {
                if (idFunctionQS == null || idFunctionQS.Length < 1)
                {
                   sectionSelectSeats.Style["display"] = "none";
                   ShowAlert("E", "Error", "No se ha encontrado la función");
                   return;
                }

                Boolean resultLoadDataFunction = LoadDataFunction(idFunctionQS);
                if (!resultLoadDataFunction)
                {
                    sectionSelectSeats.Style["display"] = "none";
                    return;
                }
                 
            }

            Boolean resultLoadDataTicketsSelectByUser = LoadSeatsSelectedByUser(idFunctionQS);
            if (!resultLoadDataTicketsSelectByUser)
            {
                sectionSelectSeats.Style["display"] = "none";
                return;
            }

            Boolean resultLoadDataTicketsNotAvailable = LoadSeatsNoAvailable(idFunctionQS);
            if (!resultLoadDataTicketsNotAvailable)
            {
                sectionSelectSeats.Style["display"] = "none";
                return;
            }
            LoadDataUser();
            UpdateTotalAmount();
             
        }

        protected void btnGoToPay_Click(object sender, EventArgs e)
        {
            string idFunctionQS = Request.QueryString["idFunction"];

            Response.Redirect($"/Pages/Payments/?idFunction={idFunctionQS}");
        }

        [WebMethod]
        public static string ReserveTickets(string idUser, string idFunction, List<Seats> jsonSeatsSelected)
        {
            try
            {

                using (var context = new CineMaxTicketsDB11Entities3())
                {
                    string listSeats = "";
                    //* Se crea el string para la lista de asientos seleccionados
                    jsonSeatsSelected.ForEach((item) =>
                    {
                        listSeats += $"{item.row}@@{item.col},";
                    });

                    context.sp_ManageCinemaTicketsByList(idUser, "R", idFunction, listSeats);
                }

                return SerializeData(new { message = "", error = 0, logged = false, col = "test", row = "test", });
            }
            catch (Exception e)
            {
                return SerializeData(new
                {
                    error = -1,
                    message = e.Message,
                    logged = false

                });
            }

        }

        private void UpdateTotalAmount()
        {
            sp_GetCinemaFunctionDataByID_Result dataFunction = Session[sessionItemData] as sp_GetCinemaFunctionDataByID_Result;
            List<Seats> ticketsSelectByUserSession = Session[sessionItemTicketSelectedByUser] as List<Seats>;
            decimal totalAmountTicket = 0;

            hdfPriceOfTicket.Value = dataFunction.function_ticket_price.ToString();

            if (dataFunction.function_ticket_price.HasValue)
            {
                totalAmountTicket = (decimal)(dataFunction.function_ticket_price * ticketsSelectByUserSession.Count());
            }

            totalAmount.InnerText = totalAmountTicket.ToString();

        }

        private Boolean LoadSeatsSelectedByUser(string _idFunction)
        {
            try
            {
                using (var context = new CineMaxTicketsDB11Entities3())
                {
                    List<sp_GetCinemaFunctionTicketsSelectedByUser_Result> dataTicketsSelectedByUser = context.sp_GetCinemaFunctionTicketsSelectedByUser(GetSessionUserData().id_usuario, _idFunction).ToList();
                    List<Seats> seatsSeelctedByUser= new List<Seats>();


                    dataTicketsSelectedByUser.ForEach((item) =>
                    {
                        seatsSeelctedByUser.Add(new Seats() { row = item.row_num_seat, col = item.col_num_seat });
                    });

                    hdfDataSeatsSelectedByUser.Value = SerializeData(seatsSeelctedByUser);
                    Session[sessionItemTicketSelectedByUser] = seatsSeelctedByUser;
                }

                return true;
            }
            catch (Exception e)
            {
                ShowAlert("E", "Error", $"Error al cargar la información de los tiquetes de la función {e.Message}");
                return false;
            }

        }

        private Boolean LoadDataUser()
        {
            try
            {
                User datUser = GetSessionUserData();
                hdfDataUser.Value = SerializeData(datUser);

                return true;
            }
            catch (Exception e)
            {
                ShowAlert("E", "Error", $"Error al cargar la información de los tiquetes de la función {e.Message}");
                return false;
            }
        }


        private Boolean LoadSeatsNoAvailable(string _idFunction)
        {
            try
            {
                using (var context = new CineMaxTicketsDB11Entities3())
                {
                  List<sp_GetCinemaFunctionTicketsNotAvaible_Result> dataNotAvailableTickets = context.sp_GetCinemaFunctionTicketsNotAvaible(GetSessionUserData().id_usuario, _idFunction).ToList();
                    List<Seats> seatsNoAvailable = new List<Seats>();

                    
                    dataNotAvailableTickets.ForEach((item) =>
                    {
                        seatsNoAvailable.Add(new Seats() { row = item.row_num_seat, col = item.col_num_seat });
                    });

                    hdfDataSeatsNoAvaible.Value = SerializeData(seatsNoAvailable);
                }

                return true;
            } catch (Exception e)
            {
                ShowAlert("E", "Error", $"Error al cargar la información de los tiquetes de la función {e.Message}");
                return false;
            }
        }
        

        private static string SerializeData(object _data)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                new JsonSerializer().Serialize(stringWriter, _data);
            }
            var jsonSeatsNoAvailableStr = stringBuilder.ToString();
            return jsonSeatsNoAvailableStr;
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
                    lblPrice.InnerText = result.function_ticket_price.ToString();
                    lblFunctionDate.InnerText = result.function_start_date?.ToString("D") ?? "Fecha invalida";
                    lblFunctionDate.InnerText += " a las ";
                    lblFunctionDate.InnerText += result.function_start_date?.ToString("h:mmtt") ?? "Fecha invalida";
                    imgPoster.Src = result.movie_url_poster;

                    // Se cargan los datos en la session
                    Session[sessionItemData] = result;
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

        


        /// <summary>
        /// Se encarga de obtener los datos en session del usuario loggedo y devolverlos
        /// Cuando no hay datos el IdUser es null
        /// </summary>
        /// <returns></returns>
        private User GetSessionUserData()
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
    public class Seats
    {
        public string row { get; set; }
        public string col { get; set; }
    }


}

