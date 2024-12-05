using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Filmatic
{
    public partial class Horarios : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar horarios disponibles
                ddlHorarios.Items.Add(new ListItem("Elige un horario", ""));
                ddlHorarios.Items.Add(new ListItem("10:00 AM", "1"));
                ddlHorarios.Items.Add(new ListItem("12:30 PM", "2"));
                ddlHorarios.Items.Add(new ListItem("3:00 PM", "3"));
                ddlHorarios.Items.Add(new ListItem("6:00 PM", "4"));
                ddlHorarios.Items.Add(new ListItem("9:00 PM", "5"));

                // Cargar salas disponibles
                ddlSalas.Items.Add(new ListItem("Elige una sala", ""));
                ddlSalas.Items.Add(new ListItem("Sala 1 - IMAX", "1"));
                ddlSalas.Items.Add(new ListItem("Sala 2 - 3D", "2"));
                ddlSalas.Items.Add(new ListItem("Sala 3 - Estándar", "3"));
                ddlSalas.Items.Add(new ListItem("Sala 4 - VIP", "4"));

                // Cargar cantidad de entradas disponibles
                ddlEntradas.Items.Add(new ListItem("Elige la cantidad", ""));
                ddlEntradas.Items.Add(new ListItem("1 entrada", "1"));
                ddlEntradas.Items.Add(new ListItem("2 entradas", "2"));
                ddlEntradas.Items.Add(new ListItem("3 entradas", "3"));
                ddlEntradas.Items.Add(new ListItem("4 entradas", "4"));
                ddlEntradas.Items.Add(new ListItem("5 entradas", "5"));
            }
        }
    }
}
