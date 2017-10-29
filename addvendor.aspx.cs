using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class addvendor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Add_Vendor(object sender, EventArgs e)
    {
        string V_Name = Name.Text;
        string V_Addr = Address.Text;
        bool iserr = false;
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Vendor VALUES (@VA, @VN);", con);
            cmd.Parameters.AddWithValue("@VA", V_Addr);
            cmd.Parameters.AddWithValue("@VN", V_Name);
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc)
        {
            iserr = true;
            message.Text = exc.ToString();
        }
        finally
        {
            if (!iserr)
            {
                Response.Redirect(Request.RawUrl);
            }
            con.Close();
        }
    }
}