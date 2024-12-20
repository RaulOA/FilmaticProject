﻿using Filmatic.Data;
using Filmatic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Filmatic
{
    public partial class _Payments : Page
    {

        string sessionItemData = "data_function";
        string sessionItemTicketSelectedByUser = "ticket_selected_by_user";
        protected void Page_Load(object sender, EventArgs e)
        {
            alertMsg.Style["display"] = "none";
            string idFunctionQS = Request.QueryString["idFunction"];

            if (idFunctionQS == null || idFunctionQS.Length < 1)
            {
                sectionDetailsPaymen.Style["display"] = "none";
                ShowAlert("E", "Error", "No se ha encontrado la función");
                return;
            }

            if (!IsPostBack)
            {

                UpdateTotalAmount();
                LoadDataPaymentCards();


                Boolean resultLoadDataFunctions = LoadDataFunction(idFunctionQS);
                if (!resultLoadDataFunctions)
                {
                    return;
                }

                Boolean resultLoadDataTicketsSelectByUser = LoadSeatsSelectedByUser(idFunctionQS);
                if (!resultLoadDataTicketsSelectByUser)
                {
                    return;
                }
            }
        }


        protected void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                string idFunctionQS = Request.QueryString["idFunction"];

                if (idFunctionQS == null || idFunctionQS.Length < 1)
                {
                    sectionDetailsPaymen.Style["display"] = "none";
                    ShowAlert("E", "Error", "No se ha encontrado la función");
                    return;
                }

                using (var context = new CineMaxTicketsDB11Entities3())
                {
                    context.sp_CreateInvoice(GetSessionUserData().id_usuario, idFunctionQS, ddlPaymentCard.SelectedValue);
                    Response.Redirect("/Pages/Invoices");
                }

            } catch( Exception error)
            {
                ShowAlert("E", "Error", $"Error al crear la factura: {error.Message}");
            }
        }

        private void LoadDataPaymentCards()
        {
            ddlPaymentCard.Items.Clear();
            ddlPaymentCard.Items.Add(new ListItem("-- Selecciona la Tarjeta --", ""));
            using (var context = new CineMaxTicketsDB11Entities3())
            {
               List<sp_ManageDMLPaymentCards_Result> allPaymentsCards = context.sp_ManageDMLPaymentCards(GetSessionUserData().id_usuario, "S", GetSessionUserData().id_usuario, null, null, null, null, null, null).ToList();
                allPaymentsCards.ForEach((item) =>
                {
                    ddlPaymentCard.Items.Add(new ListItem($"{item.represent_name} - {item.card_number} [{item.card_month}/{item.card_year}]", item.id));

                });
            }
        }

        private Boolean LoadDataFunction(string _idFunction)
        {
            try
            {
                using (var context = new CineMaxTicketsDB11Entities3())
                {

                    sp_GetCinemaFunctionDataByID_Result result = context.sp_GetCinemaFunctionDataByID(_idFunction).FirstOrDefault();
                    hdfIdFunction.Value = result.id_function;
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

        private Boolean LoadSeatsSelectedByUser(string _idFunction)
        {
            try
            {
                using (var context = new CineMaxTicketsDB11Entities3())
                {
                    List<sp_GetCinemaFunctionTicketsSelectedByUser_Result> dataTicketsSelectedByUser = context.sp_GetCinemaFunctionTicketsSelectedByUser(GetSessionUserData().id_usuario, _idFunction).ToList();
                    List<Seats> seatsSeelctedByUser = new List<Seats>();

                    List <LineDetailPayment> listDetailLines = new List<LineDetailPayment>();

                    sp_GetCinemaFunctionDataByID_Result dataFunction = Session[sessionItemData] as sp_GetCinemaFunctionDataByID_Result;

                    dataTicketsSelectedByUser.ForEach((item) =>
                    {
                        listDetailLines.Add(new LineDetailPayment() { detail = $"Tiquete {item.row_num_seat}{item.col_num_seat}", price = dataFunction.function_ticket_price.ToString() });

                        seatsSeelctedByUser.Add(new Seats() { row = item.row_num_seat, col = item.col_num_seat });
                    });

                    gvDetailLinesPayment.DataSource = listDetailLines;
                    gvDetailLinesPayment.DataBind();

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

        private void UpdateTotalAmount()
        {
            sp_GetCinemaFunctionDataByID_Result dataFunction = Session[sessionItemData] as sp_GetCinemaFunctionDataByID_Result;
            List<Seats> ticketsSelectByUserSession = Session[sessionItemTicketSelectedByUser] as List<Seats>;
            decimal totalAmountTicket = 0;

            if (dataFunction.function_ticket_price.HasValue)
            {
                totalAmountTicket = (decimal)(dataFunction.function_ticket_price * ticketsSelectByUserSession.Count());
            }

            totalAmount.InnerText = totalAmountTicket.ToString();

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

        public class LineDetailPayment
        {
            public string detail { get; set; }
            public string price { get; set; }
        }

       
    }
}