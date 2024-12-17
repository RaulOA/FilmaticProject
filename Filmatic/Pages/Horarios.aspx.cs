using Filmatic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Filmatic
{
    public partial class Horarios : Page
    {
        string sesionStorageItemName = "DATA_FUNCTION_MOVIE";

        protected void Page_Load(object sender, EventArgs e)
        {
            string idMovieQS = Request.QueryString["movieId"];
            if (idMovieQS == null || idMovieQS.Length < 1)
            {
                ShowAlert("E", "Error", "No se ha encontrado datos para elegir función");
                containerData.Style["display"] = "none";
                return;
            }

            // Cargar de las funciones para la película
            if (!IsPostBack)
            {
                LoadDataFunctionByMovie(idMovieQS);

                List<sp_GetCinemaFunctionsDataByIDMovie_Result> dataFunctions = Session[sesionStorageItemName] as List<sp_GetCinemaFunctionsDataByIDMovie_Result>;

                int totalItemLoaded = LoadDataInDDlFechas(dataFunctions);

                if (ddlFechas.SelectedValue.Length <= 0) return;

                 
                LoadDataInDDlHorarios(dataFunctions);

                if (ddlHorarios.SelectedValue.Length <= 0) return;

                LoadDataInDDlSalas(dataFunctions);

            } 

        }


        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            List<sp_GetCinemaFunctionsDataByIDMovie_Result> dataFunctions = Session[sesionStorageItemName] as List<sp_GetCinemaFunctionsDataByIDMovie_Result>;

            string selectedDate = ddlFechas.SelectedValue;
            string selectedTime = ddlHorarios.SelectedValue;
            string selectedRoom = ddlSalas.SelectedValue;

            if (selectedDate == null ||  selectedDate.Length == 0)
            {
                ShowAlert("W", "", $"¡Se debe seleccionar fecha para continuar!");
                return;
            }


            if (selectedTime == null || selectedTime.Length == 0)
            {
                ShowAlert("W", "", $"¡Se debe seleccionar hora para continuar!");
                return;
            }


            if (selectedRoom == null || selectedRoom.Length == 0)
            {
                ShowAlert("W", "", $"¡Se debe seleccionar la sala para continuar!");
                return;
            }

            string functionId = GetFunctionIdFromData(dataFunctions, selectedDate, selectedTime, selectedRoom);
            if (functionId == null || functionId.Length == 0)
            {
                ShowAlert("E", "Error", $"No se encontraron datos de la función!");
                return;
            }
                ShowAlert("S", "Éxito", $"Se ha confirmado la función {functionId} correctamente!");

            
            Response.Redirect($"/Pages/Asientos?idFunction={functionId}");
        }

        private string GetDateFromDateTime(DateTime? _datetime)
        {
            return _datetime?.ToString("D") ?? "";  // Formats the date as "Year-Month-Day"
        }

        private string GetTimeFromDateTime(DateTime? _datetime)
        {
            return _datetime?.ToString("h:mmtt") ?? ""; // Formats the time as "Hour:Minute:Second"
        }



        private string GetFunctionIdFromData(List<sp_GetCinemaFunctionsDataByIDMovie_Result> _dataFunctions, string _date, string _time, string _room)
        {
            for (int i = 0; i < _dataFunctions.Count; i++)
            {
                sp_GetCinemaFunctionsDataByIDMovie_Result itemDataFunction = _dataFunctions[i];
                string itemDateValue = GetDateFromDateTime(itemDataFunction.function_start_date);
                string itemTimeValue = GetTimeFromDateTime(itemDataFunction.function_start_date);

                if (itemDateValue != _date) continue;
                if (itemTimeValue != _time) continue;
                if (itemDataFunction.id_room != _room) continue;

                return itemDataFunction.id_function;
            }

            return "";
        }


        private void LoadDataFunctionByMovie(string _idMovie)
        {
            try
            {
                using (var context = new CineMaxTicketsDB11Entities3())
                {

                    // Obtener las funciones de la película
                    var dataFunctionMovie = context.sp_GetCinemaFunctionsDataByIDMovie(_idMovie);
                    // Guardar en sesión
                    Session[sesionStorageItemName] = dataFunctionMovie.ToList();

                }
            }
            catch (Exception ex)
            {
                ShowAlert("E", "Error", ex.Message);
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



        protected void ddlFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<sp_GetCinemaFunctionsDataByIDMovie_Result> dataFunctions = Session[sesionStorageItemName] as List<sp_GetCinemaFunctionsDataByIDMovie_Result>;
            LoadDataInDDlHorarios(dataFunctions);

            if (ddlHorarios.SelectedValue.Length <= 0) return;

            LoadDataInDDlSalas(dataFunctions);
        }

        protected void ddlHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<sp_GetCinemaFunctionsDataByIDMovie_Result> dataFunctions = Session[sesionStorageItemName] as List<sp_GetCinemaFunctionsDataByIDMovie_Result>;
            LoadDataInDDlSalas(dataFunctions);
        }


        private int LoadDataInDDlFechas(List<sp_GetCinemaFunctionsDataByIDMovie_Result> _dataFunctions)
        {
            ddlFechas.Items.Clear();
            ddlHorarios.Items.Clear();
            ddlSalas.Items.Clear();

            ddlFechas.Items.Add(new ListItem("-- Selecciona la Fecha --", ""));
            ddlHorarios.Items.Add(new ListItem("-- Selecciona la Hora --", ""));
            ddlSalas.Items.Add(new ListItem("-- Selecciona la Sala --", ""));

            List<string> listDateLoaded = new List<string>();

            // Carga los datos de las fechas
            for (int i = 0; i < _dataFunctions.Count; i++)
            {
                sp_GetCinemaFunctionsDataByIDMovie_Result itemDataFunction = _dataFunctions[i];
                string itemDateLabel = GetDateFromDateTime(itemDataFunction.function_start_date);
                string itemDateValue = GetDateFromDateTime(itemDataFunction.function_start_date);

                if (listDateLoaded.Contains(itemDateValue)) continue;
                ddlFechas.Items.Add(new ListItem(itemDateLabel, itemDateValue));
                listDateLoaded.Add(itemDateValue);
            }


            //* Si solo hay un item lo selecciona
            if (listDateLoaded.Count() == 1) ddlFechas.SelectedValue = listDateLoaded[0];

            return listDateLoaded.Count();

        }

        private int LoadDataInDDlHorarios(List<sp_GetCinemaFunctionsDataByIDMovie_Result> _dataFunctions)
        {
            ddlHorarios.Items.Clear();
            ddlHorarios.Items.Add(new ListItem("-- Selecciona la Hora --", ""));

            ddlSalas.Items.Clear();
            ddlSalas.Items.Add(new ListItem("-- Selecciona la Sala --", ""));


            List<string> listTimeLoaded = new List<string>();

            //* Carga los datos de las horas
            for (int i = 0; i < _dataFunctions.Count; i++)
            {
                sp_GetCinemaFunctionsDataByIDMovie_Result itemDataFunction = _dataFunctions[i];

                string itemDateValue = GetDateFromDateTime(itemDataFunction.function_start_date);


                string itemTimeLabel = GetTimeFromDateTime(itemDataFunction.function_start_date);
                string itemTimeValue = GetTimeFromDateTime(itemDataFunction.function_start_date);


                //* Si la hora no es de la fecha seleccionada
                if (ddlFechas.SelectedValue != itemDateValue) continue;
                if (listTimeLoaded.Contains(itemTimeValue)) continue;

                ddlHorarios.Items.Add(new ListItem(itemTimeLabel, itemTimeValue));
                listTimeLoaded.Add(itemTimeValue);
            }


            //* Si solo hay un item lo selecciona
            if (listTimeLoaded.Count() == 1) ddlHorarios.SelectedValue = listTimeLoaded[0];

            return listTimeLoaded.Count();
        }


        private int LoadDataInDDlSalas(List<sp_GetCinemaFunctionsDataByIDMovie_Result> _dataFunctions)
        {
            ddlSalas.Items.Clear();
            ddlSalas.Items.Add(new ListItem("-- Selecciona la Sala --", ""));

            List<string> listRoomsLoaded = new List<string>();

            //* Carga los datos de las horas
            for (int i = 0; i < _dataFunctions.Count; i++)
            {
                sp_GetCinemaFunctionsDataByIDMovie_Result itemDataFunction = _dataFunctions[i];

                string itemDateValue = GetDateFromDateTime(itemDataFunction.function_start_date);
                string itemTimeValue = GetTimeFromDateTime(itemDataFunction.function_start_date);


                string itemRoomLabel = $"{itemDataFunction.room_title} [{itemDataFunction.function_format_movie}]";
                string itemRoomValue = itemDataFunction.id_room;


                //* Si la hora no es de la fecha seleccionada
                if (ddlFechas.SelectedValue != itemDateValue) continue;
                //* Si no es del horario seleccionado
                if (ddlHorarios.SelectedValue != itemTimeValue) continue;
                if (listRoomsLoaded.Contains(itemTimeValue)) continue;

                ddlSalas.Items.Add(new ListItem(itemRoomLabel, itemRoomValue));
                listRoomsLoaded.Add(itemRoomValue);
            }

            //* Si solo hay un item lo selecciona
            if (listRoomsLoaded.Count() == 1) ddlSalas.SelectedValue = listRoomsLoaded[0];

            return listRoomsLoaded.Count();
        }

        
    }


}
