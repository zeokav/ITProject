using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            dv.DataItem;
        }
    }

    protected void Order_Med(object sender, EventArgs e)
    {
        lbl.Text = "Order placed! The vendor has been notified.";
    }
}