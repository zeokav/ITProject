﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if(!IsPostBack)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["medDb"].ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Med_ID, Trade_Name from MedicineMaster", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "med");
                ddl.DataSource = ds.Tables["med"];
                ddl.DataTextField = "Trade_Name";
                ddl.DataValueField = "Med_ID";
                ddl.DataBind();
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

            cmd = new SqlCommand("UPDATE Inventory SET Med_Remaining=Med_Remaining+40 WHERE Med_ID=@med", con);
            cmd.Parameters.AddWithValue("@med", ddl.SelectedValue);
            int rows = cmd.ExecuteNonQuery();

            if (rows == 0)
            {
                cmd = new SqlCommand("INSERT INTO Inventory VALUES (@med, 40, 15)", con);
                cmd.Parameters.AddWithValue("@med", ddl.SelectedValue);
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
        }
    }

    protected void Reset_Form(object sender, EventArgs e)
    {
        Exp.Text = Buy.Text = null;
    }
}