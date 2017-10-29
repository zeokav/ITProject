using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.Configuration;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Inventory Where Med_ID=@med", conn);
                cmd.Parameters.AddWithValue("@med", Request.QueryString.Get("med"));
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                rdr.Text = "Medicines Available: " + reader["Med_Remaining"] + "<br />";
                rdr.Text += "Minimum Recommended: " + reader["Med_Threshold"] + "<br /><br />";
            }
            catch (Exception exc)
            {
                lbl.Text = exc.ToString();
            }
            finally
            {
                conn.Close();
            }
        }
    }

    protected void Order_Med(object sender, EventArgs e)
    {
        lbl.Text = "Order placed! The vendor has been notified.";
    }
}