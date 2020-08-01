using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sunrise_employee_section_report_SD_PastCostsAndPrices : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["SunriseConnectionString"].ConnectionString;
    string itemListQueryString = "select ROW_NUMBER() OVER (ORDER BY MB.MB001) 'no'" +
            " ,MB.MB001 'itemId'" +
            " ,MB.MB002 'itemName'" +
            " ,MB.MB003 'itemSpec'" +
            " ,convert(decimal(20, 0), MB.MB064) 'inv'" +
            " ,MB.MB004 'itemUnit'" +
            " ,case" +
            " when MB.MB064=0 or MB.MB065=0 then 0" +
            " else convert(decimal(20,2),MB.MB065/MB.MB064)" +
            " end 'invAvgCost'" + 
            " from INVMB MB";
    string saleRecordQueryString = "select top 20 TG.TG042 'saleDate'" +
        " , MA.MA002 'customerName'" +
        " ,convert(nvarchar, convert(decimal(20,0),TH.TH008))+' '+TH.TH009 'saleAmount'" +
        " ,convert(decimal(20,2),TH.TH012) 'unitPrice'" +
        " from COPTH TH" +
        " LEFT JOIN COPTG TG ON TH.TH001=TG.TG001 AND TH.TH002=TG.TG002" +
        " LEFT JOIN COPMA MA ON TG.TG004=MA.MA001" +
        " where TH.TH004=@itemId" +
        " order by TG.TG042 desc";
    string purchaseRecordQueryString = "select top 20 TG.TG014 'purchaseDate'" +
        " , MA.MA002 'supplierName'" +
        " ,convert(nvarchar, convert(decimal(20,0),TH.TH007))+' '+TH.TH008 'purchaseAmount'" +
        " ,convert(decimal(20,2),TH.TH018) 'unitPrice'" +
        " from PURTH TH" +
        " LEFT JOIN PURTG TG ON TH.TH001=TG.TG001 AND TH.TH002=TG.TG002" +
        " LEFT JOIN PURMA MA ON TG.TG005=MA.MA001" +
        " where TH.TH004=@itemId" +
        " order by TG.TG014 desc";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnItemSearch_Click(object sender, EventArgs e)
    {
        string condition = "";
        txtInvAmount.Text = "";
        txtItemSpec.Text = "";
        gvSaleRecord.DataSource = null;
        gvSaleRecord.DataBind();
        gvPurchaseRecord.DataSource = null;
        gvPurchaseRecord.DataBind();
        if (((Button)sender).ID == "btnIdSearch")
        {
            txtItemName.Text = "";
            condition = " MB.MB001 like '%'+@itemId+'%'";
        }
        else if (((Button)sender).ID == "btnNameSearch")
        {
            txtItemId.Text = "";
            condition = " MB.MB002 like '%'+@itemName+'%'";
        }
        DataTable dt = new DataTable();
        dt = GetItemQueryResult(itemListQueryString, condition);
        DisplayItemList(dt);

        if(gvItemList.Rows.Count > 0)
        {
            DisplaySelectedGridRow(gvItemList.Rows[0]);
            DisplayPastRecord();
        }
    }

    private string AppendConditionToQuery(string query, params string[] condition)
    {
        for (int i = 0; i < condition.Length; i++)
        {
            if (i == 0)
            {
                query += " where " + condition[i];
            }
            else
            {
                query += " and " + condition[i];
            }
        }

        return query;
    }

    private DataTable GetItemQueryResult(string query, params string[] condition)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            //append conditions to the end of the query
            string fullQuery = AppendConditionToQuery(query, condition);

            SqlCommand cmd = new SqlCommand(fullQuery, conn);
            cmd.Parameters.AddWithValue("@itemId", txtItemId.Text.ToUpper().Trim()) ;
            cmd.Parameters.AddWithValue("@itemName", txtItemName.Text.ToUpper().Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }


        return dt;
    }

    private void DisplayItemList(DataTable dt)
    {
        gvItemList.DataSource = dt;
        gvItemList.DataBind();
    }

    protected void gvItemList_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvSaleRecord.DataSource = null;
        gvSaleRecord.DataBind();
        gvPurchaseRecord.DataSource = null;
        gvPurchaseRecord.DataBind();
        DisplaySelectedGridRow(gvItemList.SelectedRow);
        DisplayPastRecord();
    }
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        AddRowSelectToGridView(gvItemList);

        base.Render(writer);
    }
    private void AddRowSelectToGridView(GridView gv)
    {
        foreach (GridViewRow row in gv.Rows)
        {
            row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gv, "Select$" + row.RowIndex.ToString(), true));
        }
    }

    private void DisplaySelectedGridRow(GridViewRow row)
    {
        txtItemId.Text = ((Label)row.FindControl("lblItemId")).Text.Trim();
        txtItemName.Text = ((Label)row.FindControl("lblItemName")).Text.Trim();
        txtItemSpec.Text = ((Label)row.FindControl("lblItemSpec")).Text.Trim();
        txtInvAmount.Text = ((Label)row.FindControl("lblItemInv")).Text.Trim() + " " + ((Label)row.FindControl("lblItemUnit")).Text.Trim();
        txtInvAvgCost.Text = ((Label)row.FindControl("lblInvAvgCost")).Text.Trim();
    }

    private void DisplayPastRecord()
    {
        DataTable dt = new DataTable();
        dt = GetItemQueryResult(saleRecordQueryString);
        gvSaleRecord.DataSource = dt;
        gvSaleRecord.DataBind();
        dt = GetItemQueryResult(purchaseRecordQueryString);
        gvPurchaseRecord.DataSource = dt;
        gvPurchaseRecord.DataBind();
    }

    protected void gvSaleRecord_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "客戶賣價 (前20筆)";
            HeaderCell.ColumnSpan = HeaderGrid.Columns.Count;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderGrid.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }

    protected void gvPurchaseRecord_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "廠商進價 (前20筆)";
            HeaderCell.ColumnSpan = HeaderGrid.Columns.Count;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderGrid.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }

    }
}