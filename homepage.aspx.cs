using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class homepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
                            
            SetReq();
            SetExp();
   
        }
    }

    protected void SetReq()
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Inventory.Med_ID, MedicineMaster.Trade_Name, Inventory.Med_Remaining, Inventory.Med_Threshold from MedicineMaster INNER JOIN Inventory on MedicineMaster.Med_ID=Inventory.Med_ID WHERE Inventory.Med_Remaining<Inventory.Med_Threshold", con);
            SqlDataReader reader = cmd.ExecuteReader();

            req_gv.DataSource = reader;
            req_gv.DataBind();

            int cnt = req_gv.DataKeys.Count;
            if (cnt > 0)
            {
                ReqStatus.Text = cnt.ToString() + " medicines need to be ordered.";
            }
            else
            {
                ReqStatus.Text = "Medicines are all stocked up!";
            }

        }
        catch (Exception ec)
        {
            errmsg.Text = ec.ToString();
        }
        finally
        {
            con.Close();
        }
        
    }

    protected void SetExp()
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from BatchInfo WHERE Expiry_Date < @tod", con);
            cmd.Parameters.AddWithValue("@tod", DateTime.Now);
            SqlDataReader reader = cmd.ExecuteReader();

            exp_gv.DataSource = reader;
            exp_gv.DataBind();

            int cnt = exp_gv.DataKeys.Count;
            if (cnt > 0)
            {
                ExpStatus.Text = cnt.ToString() + " medicines expired.";
            }
            else
            {
                ExpStatus.Text = "No medicines expired!";
            }
        }
        catch (Exception ec)
        {
            errmsg.Text = ec.ToString();
        }
        finally
        {
            con.Close();
        }
    }

    protected void Show_Req(object sender, EventArgs e)
    {
        this.req_gv.Visible = !this.req_gv.Visible;
    }

    protected void Show_Exp(object sender, EventArgs e)
    {
        this.exp_gv.Visible = !this.exp_gv.Visible;
    }

    protected void req_gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowInfo")
        {
            int row;
            Int32.TryParse(e.CommandArgument.ToString(), out row);
            string med_id = req_gv.DataKeys[row].Value.ToString();

            Response.Redirect("lowdetails.aspx?med="+med_id);
        }
    }

}