using Filmatic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Filmatic.Pages
{
    public partial class Invoices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadDataInvoices();
            }
        }


        private void LoadDataInvoices()
        {
            using (var context = new CineMaxTicketsDB11Entities3())
            {
                gvInvoices.DataSource = context.sp_GetInvoicesByUser("USER02");
                gvInvoices.DataBind();
            }
        }
    }
}