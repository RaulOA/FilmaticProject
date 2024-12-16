using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Filmatic.Pages.Admin.Reports
{
    public partial class ReportTicketsByFunctions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Remote;

                // Configurar el servidor del informe
                ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://localhost/ReportServer");
                ReportViewer1.ServerReport.ReportPath = "/MicrosoftReportsIIS/ReportTicketsByFunction";

                // Configurar los parámetros
                ReportParameter[] parameters = new ReportParameter[1];
                parameters[0] = new ReportParameter("rpLvIdFunction", "FUNC98761", false);
                ReportViewer1.ServerReport.SetParameters(parameters);

                // Procesar y mostrar el informe
                ReportViewer1.ServerReport.Refresh();
            }

        }
    }
}