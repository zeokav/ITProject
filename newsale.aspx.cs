using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class newsale : System.Web.UI.Page
{
    List<String> list = new List<String>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Med_ID from MedicineMaster", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader["Med_ID"].ToString());
            }
            Session["rowcount"] = 0;
            con.Close();
        }
        else
        {
            int rowcount;
            int.TryParse(Session["rowcount"].ToString(), out rowcount);
            if (rowcount < 1) { return; }
            for (int i = 0; i < rowcount; i++)
            {
                TextBox tb = new TextBox();
                if (Session["medid" + i.ToString() + "0"] != null) { tb.Text = Session["medid" + i.ToString() + "0"].ToString(); }
                DropDownList tbquantity = new DropDownList();
                tbquantity.DataSource = list;
                DataBind();
                if (Session["medid" + i.ToString() + "1"] != null)
                {
                    int index;
                    int.TryParse(Session["medid" + i.ToString() + "1"].ToString(), out index);
                    tbquantity.SelectedIndex = index;
                }
                TableRow row = new TableRow();
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                c1.Controls.Add(tb);
                c2.Controls.Add(tbquantity);
                row.Controls.Add(c1);
                row.Controls.Add(c2);
                medsale.Rows.Add(row);
            }
        }
    }

    protected void addrow_Click(object sender, EventArgs e)
    {
        int count;
        int.TryParse(Session["rowcount"].ToString(), out count);
        if (count != 0)
        {
            int temp = 0;
            foreach (TableRow ro in medsale.Rows)
            {
                if (temp == count)
                {
                    int temp2 = 0;
                    Session["medid" + temp.ToString() + temp2.ToString()] = ((DropDownList)ro.Controls[0].Controls[0]).SelectedIndex;
                    temp2++;
                    Session["medid" + temp.ToString() + temp2.ToString()] = ((TextBox)ro.Controls[0].Controls[0]).Text;
                }
                temp++;
            }

        }
        TextBox tb = new TextBox();
        DropDownList tbquantity = new DropDownList();
        TableRow row = new TableRow();
        TableCell c1 = new TableCell();
        TableCell c2 = new TableCell();
        c1.Controls.Add(tb);
        c2.Controls.Add(tbquantity);
        row.Controls.Add(c1);
        row.Controls.Add(c2);
        medsale.Rows.Add(row);
        count += 1;
        Session["rowcount"] = count;
    }
    protected string RandomDigits(int length)
    {
        Random random = new Random();
        string s = string.Empty;
        for (int i = 0; i < length; i++)
            s = String.Concat(s, random.Next(10).ToString());
        return s;
    }

    protected void sub_Click(object sender, EventArgs e)
    {
        int t = 0;
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO MedicineMaster VALUES(@Sale_Id, @PurDate)", con);
        String mon = RandomDigits(9);
        cmd.Parameters.AddWithValue("@Sale_Id", mon);
        cmd.Parameters.AddWithValue("@PurDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        cmd.ExecuteNonQuery();
        foreach (TableRow row in medsale.Rows)
        {
            if (t == 0) { continue; }
            cmd = new SqlCommand("INSERT INTO MedicineMaster VALUES(@SaleId, @Med_ID,@Quantity)", con);
            cmd.Parameters.AddWithValue("@SaleId", mon);
            TextBox b0 = (TextBox)(row.Controls[0]).Controls[0];
            DropDownList b1 = (DropDownList)(row.Controls[1]).Controls[0];
            cmd.Parameters.AddWithValue("@Med_ID", b0.Text);
            cmd.Parameters.AddWithValue("@Quantity", b1.SelectedValue);
            cmd.ExecuteNonQuery();
        }
    }
}