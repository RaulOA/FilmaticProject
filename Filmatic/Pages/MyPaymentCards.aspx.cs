using Filmatic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Filmatic.Pages
{
    public partial class MyPaymentCards1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadDataPaymentCards();
            }
        }


        private void LoadDataPaymentCards()
        {
            using (var context = new CineMaxTicketsDB11Entities3())
            {
                gvPaymentCards.DataSource = context.sp_ManageDMLPaymentCards("USER02", "S", "USER02", null, null, null, null, null, null);
                gvPaymentCards.DataBind();
            }
        }

        protected void gvPaymentCards_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}