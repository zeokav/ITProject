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
            SqlCommand command = new SqlCommand("Select Med_ID, Trade_Name from MedicineMaster", con);
            SqlDataReader reader = command.ExecuteReader();
            medchart.DataSource = reader;
            medchart.DataTextField = "Trade_Name";
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
        msg.Text = "Showing graph for: " + medchart.SelectedItem.Text + " <br />";
        if (medchart.SelectedValue != "Month" && medchart.SelectedValue != "Select")
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand("Select Sales.Purchase_Date,SUM(SalesInfo.Quantity) as whatis from Sales,SalesInfo where SalesInfo.Sales_ID = Sales.Sales_ID AND SalesInfo.Med_ID=@id and  Sales.Purchase_Date > @temp group by  Sales.Purchase_Date ", con);
            command.Parameters.AddWithValue("@temp", DateTime.Now.AddDays(-30));
            command.Parameters.AddWithValue("@id", medchart.SelectedValue);
            SqlDataReader reader = command.ExecuteReader();
            if(!reader.Read())
            {
                er.Text = "No Value Found For the MedID";
            }
            reader.Close();
            SqlDataReader reader2 = command.ExecuteReader();
            Chart2.DataSource = reader2;
            Chart2.Series["Series1"].XValueMember = "Purchase_Date";
            Chart2.Series["Series1"].YValueMembers = "whatis";
            Chart2.ChartAreas[0].AxisX.LabelStyle.Format = "MM-dd";
            Chart2.DataBind();

            reader2.Close();

        }
        else if(medchart.SelectedValue != "Select")
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand("Select Sales.Purchase_Date,SUM(SalesInfo.Quantity) as whatis from Sales,SalesInfo where SalesInfo.Sales_ID = Sales.Sales_ID and  Sales.Purchase_Date > @temp group by  Sales.Purchase_Date ", con);
            command.Parameters.AddWithValue("@temp", DateTime.Now.AddDays(-30));
            SqlDataReader reader = command.ExecuteReader();
            Chart2.DataSource = reader;
            Chart2.Series["Series1"].XValueMember = "Purchase_Date";
            Chart2.Series["Series1"].YValueMembers = "whatis";
            Chart2.ChartAreas[0].AxisX.LabelStyle.Format = "MM-dd";
            Chart2.DataBind();
            reader.Close();
        }   
    }
}