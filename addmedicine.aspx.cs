using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.Configuration;

public partial class addmedicine : System.Web.UI.Page
{
    SqlConnection conn;

    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
    }

    protected void Add_Medicine(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
        }
        catch (Exception exc)
        {
            Result.Text = "Could not enter: <br />" + exc.ToString();
        }
    }
}