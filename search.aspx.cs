using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

public partial class search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submitbut_Click(object sender, EventArgs e)
    {
        if (genericnametextbox.Text == "" && tradenametextbox.Text == "")
        {
            errorText.Text = "Enter a Name";
        }
        else
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project;Integrated Security=True;Pooling=False";
            try
            {
                con.Open();
                if (genericnametextbox.Text != "")
                {
                    SqlCommand command = new SqlCommand("Select MedicineMaster.Med_ID, Inventory.Med_Remaining from MedicineMaster INNER JOIN Inventory ON Inventory.Med_ID = MedicineMaster.Med_ID  where MedicineMaster.Gen_Name=@gen", con);
                    command.Parameters.AddWithValue("@gen", genericnamelabel.Text);
                    SqlDataReader reader = command.ExecuteReader();
                    findmed.DataSource = reader;
                    DataBind();
                    if(!reader.Read())
                    {
                        errorText.Text = "No Records Found";
                    }
 
                }
                else
                {
                    SqlCommand command = new SqlCommand("Select MedicineMaster.Med_ID, Inventory.Med_Remaining from MedicineMaster INNER JOIN Inventory ON Inventory.Med_ID = MedicineMaster.Med_ID  where MedicineMaster.Trade_Name=@gen", con);
                    command.Parameters.AddWithValue("@gen", tradenametextbox.Text);
                    SqlDataReader reader = command.ExecuteReader();
                    findmed.DataSource = reader;
                    DataBind();
                    if (!reader.Read())
                    {
                        errorText.Text = "No Records Found";
                    }


                }
            }
            catch(Exception exp)
            {
                errorText.Text = exp.Message;
            }
            finally
            {
                con.Close();
            }
           
        }
    }
}