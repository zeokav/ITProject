using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class graphs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand("Select Med_ID from MedicineMaster", con);
            SqlDataReader reader = command.ExecuteReader();
            medchart.DataSource = reader;
            medchart.DataTextField = "Med_ID";
            medchart.DataValueField = "Med_ID";
            medchart.DataBind();
            medchart.Items.Insert(0, new ListItem("Select", "Select"));
            //command = new SqlCommand("Select ")
            medchart.Items.Add(new ListItem("Month", "Month"));
        }
    }

    protected void medchart_SelectedIndexChanged(object sender, EventArgs e)
    {
        //SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
        //con.Open();
        //SqlCommand command = new SqlCommand("Select Sales.Purchase_Date, SUM() from MedicineMaster", con);
        //SqlDataReader reader = command.ExecuteReader();
        if(medchart.SelectedValue != "Month")
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
        }
        else
        {

        }
    }
}