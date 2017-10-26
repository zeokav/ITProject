using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


public partial class newsale : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void addrow_Click(object sender, EventArgs e)
    {
        TextBox tb = new TextBox();
        TextBox tbquantity = new TextBox();
        TableRow row = new TableRow();
        TableCell c1 = new TableCell();
        TableCell c2 = new TableCell();
        c1.Controls.Add(tb);
        c2.Controls.Add(tbquantity);
        row.Controls.Add(c1);
        row.Controls.Add(c2);
        
    }
}

/*
 * using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Collections;




public partial class _Default1 : System.Web.UI.Page
{
    private int numOfRows = 1;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GenerateTable(numOfRows);
        }
    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ViewState["RowsCount"] != null)
        {
            numOfRows = Convert.ToInt32(ViewState["RowsCount"].ToString());
            GenerateTable(numOfRows);
        }
    }


    private void GenerateTable(int rowsCount)
    {


        //Creat the Table and Add it to the Page
        Table table = new Table();
        table.ID = "Table1";
        Page.Form.Controls.Add(table);


        const int colsCount = 3;


        // Now iterate through the table and add your controls


        for (int i = 0; i < rowsCount; i++)
        {
            TableRow row = new TableRow();
            for (int j = 0; j < colsCount; j++)
            {
                TableCell cell = new TableCell();
                TextBox tb = new TextBox();


                // Set a unique ID for each TextBox added
                tb.ID = "TextBoxRow_" + i + "Col_" + j;
                // Add the control to the TableCell
                cell.Controls.Add(tb);
                // Add the TableCell to the TableRow
                row.Cells.Add(cell);
            }


            // And finally, add the TableRow to the Table
            table.Rows.Add(row);
        }


        //Sore the current Rows Count in ViewState
        rowsCount++;
        ViewState["RowsCount"] = rowsCount;
    }
}
 * /
