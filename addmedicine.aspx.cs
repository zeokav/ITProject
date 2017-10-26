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
        if (!IsPostBack)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Vendor_ID, Vendor_Name from Vendor", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                VendorDdl.DataSource = reader;
                VendorDdl.DataTextField = "Vendor_Name";
                VendorDdl.DataValueField = "Vendor_ID";
                this.DataBind();
            }
            catch (Exception exc)
            {
                Result.Text = "Could not enter: <br />" + exc.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

    }

    protected void Add_Medicine(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO MedicineMaster VALUES(@TN, @GN, @MF, @VID, @MP)", conn);
            cmd.Parameters.AddWithValue("@TN", TName.Text);
            cmd.Parameters.AddWithValue("@GN", GName.Text);
            cmd.Parameters.AddWithValue("@MF", Manufacturer.Text);
            cmd.Parameters.AddWithValue("@VID", VendorDdl.SelectedValue);
            cmd.Parameters.AddWithValue("@MP", Cost.Text);

            cmd.ExecuteNonQuery();
            Result.Text = "Added successfully!";
        }
        catch (Exception exc)
        {
            Result.Text = "Could not enter: <br />" + exc.ToString();
        }
        finally
        {
            conn.Close();
        }
    }

    protected void Reset_Form(object sender, EventArgs e)
    {
        TName.Text = GName.Text = Manufacturer.Text = Cost.Text = null;
    }
}