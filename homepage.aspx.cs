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
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
            try
            {
                con.Open();
                SetReq(con);
                SetExp(con);
            }
            catch(Exception exc)
            {
                errmsg.Text = "There was an error: " + exc.ToString();
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void SetReq(SqlConnection con)
    {
        SqlCommand cmd = new SqlCommand("Select Inventory.Med_ID, MedicineMaster.Trade_Name, Inventory.Med_Remaining, Inventory.Med_Threshold from MedicineMaster INNER JOIN Inventory on MedicineMaster.Med_ID=Inventory.Med_ID WHERE Inventory.Med_Remaining<Inventory.Med_Threshold", con);
        SqlDataReader reader = cmd.ExecuteReader();
        int cnt = 0;
        while (reader.Read())
        {
            cnt++;
        }
        if (reader.HasRows)
        {
            ReqStatus.Text = cnt.ToString() + " medicines need to be ordered.";
        }
        else
        {
            ReqStatus.Text = "Medicines are all stocked up!";
        }
        reader.Close();

        reader = cmd.ExecuteReader();
        req_gv.DataSource = reader;
        this.DataBind();

    }

    protected void SetExp(SqlConnection con)
    {

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