using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Xml.Serialization;
using System.IO;

public partial class homepage : System.Web.UI.Page
{
    List<string> list = new List<string>();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            SetReq();
            SetExp();
            SetVend();
            SetRevenue();
        }
    }

    protected void Submit_Form(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO BatchInfo VALUES (@exp, @buy, @med)", con);
            cmd.Parameters.AddWithValue("@exp", Exp.Text);
            cmd.Parameters.AddWithValue("@buy", Buy.Text);
            cmd.Parameters.AddWithValue("@med", ddl.SelectedValue);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("UPDATE Inventory SET Med_Remaining=Med_Remaining+@qty WHERE Med_ID=@med", con);
            cmd.Parameters.AddWithValue("@med", ddl.SelectedValue);
            if(cb.Checked)
            {
                cmd.Parameters.AddWithValue("@qty", rbl.SelectedValue);
            }
            else
            {
                cmd.Parameters.AddWithValue("@qty", Qty.Text);
            }
            int rows = cmd.ExecuteNonQuery();

            if (rows == 0)
            {
                cmd = new SqlCommand("INSERT INTO Inventory VALUES (@med, 40, 15)", con);
                cmd.Parameters.AddWithValue("@med", ddl.SelectedValue);
                if (cb.Checked)
                {
                    cmd.Parameters.AddWithValue("@qty", rbl.SelectedValue);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@qty", Qty.Text);
                }
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception exc)
        {
            errmsg.Text = exc.ToString();
        }
        finally
        {
            con.Close();
            SetReq();
        }
    }

    protected void Refresh_Vend(object sender, EventArgs e)
    {
        SetVend();
    }

    protected void Reset_Form(object sender, EventArgs e)
    {
        Exp.Text = Buy.Text = null;
    }

    protected void Hide_Form(object sender, EventArgs e)
    {
        orderPanel.Visible = false;
    }

    protected void Hide_Check(object sender, EventArgs e)
    {
        rbl.Visible = !rbl.Visible;
        Qty.Visible = !Qty.Visible;
        QtyLabel.Visible = !QtyLabel.Visible;
    }

    protected void Refresh_Exp(object sender, EventArgs e)
    {
        SetExp();
    }

    protected void SetVend()
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select distinct BatchInfo.Med_ID from BatchInfo INNER JOIN MedicineMaster ON BatchInfo.Med_ID=MedicineMaster.Med_ID WHERE BatchInfo.Expiry_Date < @tod", con);
            cmd.Parameters.AddWithValue("@tod", DateTime.Today);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> meds = new List<string>();
            while (reader.Read())
            {
                meds.Add(reader["Med_ID"].ToString());
            }
            reader.Close();

            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach(string med in meds)
            {
                cmd = new SqlCommand("Select MedicineMaster.Trade_Name, Vendor.Vendor_Name from MedicineMaster INNER JOIN Vendor ON MedicineMaster.Vendor_ID=Vendor.Vendor_ID where MedicineMaster.Med_ID=@med", con);
                cmd.Parameters.AddWithValue("@med", med);

                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    dict[reader["Trade_Name"].ToString()] = reader["Vendor_Name"].ToString();
                }
                reader.Close();
            }

            vend_gv.DataSource = dict;
            vend_gv.DataBind();
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

    protected void SetRevenue()
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Sales_ID from Sales Where Purchase_Date = @tod", con);
            cmd.Parameters.AddWithValue("@tod", DateTime.Today);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> s_ids = new List<string>();

            while(reader.Read())
            {
                s_ids.Add(reader["Sales_ID"].ToString());
            }
	    
            reader.Close();
            Dictionary<string, int> sales = new Dictionary<string, int>();

            foreach (string id in s_ids)
            {
                cmd = new SqlCommand("Select * from SalesInfo WHERE Sales_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    try
                    {
                        sales[reader["Med_ID"].ToString()] += int.Parse(reader["Quantity"].ToString());
                    }
                    catch (KeyNotFoundException)
                    {
                        sales[reader["Med_ID"].ToString()] = int.Parse(reader["Quantity"].ToString());
                    }
                }
                reader.Close();
            }

            int cnt = 0;
            foreach (KeyValuePair<string, int> entry in sales)
            {
                cnt++;
                cmd = new SqlCommand("Select * from MedicineMaster where Med_ID = @med", con);
                cmd.Parameters.AddWithValue("@med", entry.Key);
                reader = cmd.ExecuteReader();
                reader.Read();
                float cost = float.Parse(reader["Med_Price"].ToString());
                rev.Text += "Medicine: " + reader["Trade_Name"] + ", Quantity: " + entry.Value + ", <strong>Earnings: " + (cost*entry.Value).ToString() + " </strong><br />";
                reader.Close();
            }
            if(cnt == 0)
            {
                rev.Text = "No purchases today!";
            }
        }
        catch (Exception exc)
        {
            errmsg.Text = exc.ToString();
        }
        finally
        {
            con.Close();
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
            SqlCommand cmd = new SqlCommand("Select * from BatchInfo INNER JOIN MedicineMaster ON BatchInfo.Med_ID=MedicineMaster.Med_ID WHERE BatchInfo.Expiry_Date < @tod", con);
            cmd.Parameters.AddWithValue("@tod", DateTime.Today);
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
        this.orderPanel.Visible = false;
    }

    protected void Show_Exp(object sender, EventArgs e)
    {
        this.exp_gv.Visible = !this.exp_gv.Visible;
    }

    protected void Show_Vend(object sender, EventArgs e)
    {
        this.vend_gv.Visible = !this.vend_gv.Visible;
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
        else if (e.CommandName == "PlaceOrder")
        {
            orderPanel.Visible = true;
            int row;
            Int32.TryParse(e.CommandArgument.ToString(), out row);
            string med_id = req_gv.DataKeys[row].Value.ToString();
            ddl.SelectedValue = med_id;
        }
    }





    protected void submitbut_Click(object sender, EventArgs e)
    {
        if (genericnametextbox.Text == "" && tradenametextbox.Text == "")
        {
            errorText.Text = "Enter a Name";
        }
        else if (genericnametextbox.Text != "" && tradenametextbox.Text != "")
        {
            errorText.Text = "Only Need To enter anyone value";
        }
        else
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
            if (Session["list"] != null)
                list = (List<string>)Session["list"];
            else
                list = new List<string>();

            HttpCookie cookie = Request.Cookies["history"];
            if(cookie == null)
            {
                HttpCookie cookie1 = new HttpCookie("history");
                if(genericnametextbox.Text.ToString() != "")
                {
                    list.Add(genericnametextbox.Text.ToString());
                }
                else
                {
                    list.Add(tradenametextbox.Text.ToString());
                }
                string combindedString = string.Join(" ", list.ToArray());
                cookie1["history"] = combindedString;
                Response.Cookies.Add(cookie1);
                cookie1.Expires = DateTime.Now.AddYears(1);
            }
            else
            {
                
                if (genericnametextbox.Text.ToString() != "")
                {
                    list.Add(genericnametextbox.Text.ToString());
                }
                else
                {
                    list.Add(tradenametextbox.Text.ToString());
                }
                string combindedString = string.Join(" ", list.ToArray());
                cookie["history"] = combindedString;
                cookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(cookie);
            }

            Session["list"] = list;
            Session["name"] = genericnametextbox.Text.ToString();
            Session["tra_name"] = tradenametextbox.Text.ToString();
            HistoryGrid.DataSource = list;
            HistoryGrid.DataBind();
            HistoryGrid.Width = Unit.Pixel(150);
            try
            {
                con.Open();
                if (genericnametextbox.Text != "")
                {
                    SqlCommand command = new SqlCommand("Select * from MedicineMaster INNER JOIN Inventory ON Inventory.Med_ID = MedicineMaster.Med_ID  where MedicineMaster.Gen_Name=@gen", con);
                    command.Parameters.AddWithValue("@gen", Session["name"]);
                    SqlDataReader reader = command.ExecuteReader();
                    findmed.DataSource = reader;
                    if (reader.HasRows)
                    {
                        resLabel.Visible = true;
                    }
                    else
                    {
                        resLabel.Visible = false;
                    }
                    DataBind();
                }
                else
                {
                    SqlCommand command = new SqlCommand("Select * from MedicineMaster INNER JOIN Inventory ON Inventory.Med_ID = MedicineMaster.Med_ID  where MedicineMaster.Trade_Name=@gen", con);
                    command.Parameters.AddWithValue("@gen", Session["tra_name"]);
                    SqlDataReader reader = command.ExecuteReader();
                    findmed.DataSource = reader;
                    if (reader.HasRows)
                    {
                        resLabel.Visible = true;
                    }
                    else
                    {
                        resLabel.Visible = false;
                    }
                    DataBind();
                }
                
            }
            catch (Exception exp)
            {
                errorText.Text = exp.Message;
            }
            finally
            {
                con.Close();
            }

        }
    }


    protected void history(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["history"];

        if (cookie == null)
        {
            historyLabel.Text = "No history to show!";
        }
        else
        {
            historyLabel.Text = "Found history: <br />";
            string value = cookie["history"];
            List<string> result = value.Split(' ').ToList();
            result.Reverse();
            HistoryGrid.DataSource = result;
            HistoryGrid.Width = Unit.Pixel(150);
            HistoryGrid.DataBind();
        }
    }

    protected void hg_cmd(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "AddToSearch")
        {
            HttpCookie cookie = Request.Cookies["history"];
            if (cookie == null)
            {
                historyLabel.Text = "Can't find cookie";
                return;
            }
            string value = cookie["history"];
            List<string> result = value.Split(' ').ToList();
            result.Reverse();

            int row;
            Int32.TryParse(e.CommandArgument.ToString(), out row);
            genericnametextbox.Text = result[row];
            
        }
    }
}