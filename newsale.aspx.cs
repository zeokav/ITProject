using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


public partial class newsale : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void addrow_Click(object sender, EventArgs e)
    {
        TextBox tb = new TextBox();
        TextBox tbquantity = new TextBox();
        TableRow row = new TableRow();
        TableCell c1 = new TableCell();
        TableCell c2 = new TableCell();
        c1.Controls.Add(tb);
        c2.Controls.Add(tbquantity);
        row.Controls.Add(c1);
        row.Controls.Add(c2);
        medsale.Controls.Add(row);
    }
}