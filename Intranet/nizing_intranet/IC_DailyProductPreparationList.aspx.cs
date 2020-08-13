using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class nizing_intranet_IC_DailyProductPreparationList : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblSalesRecordId.Text = DateTime.Today.ToString("yyyyMMdd");
            DisplaySalesRecordData(GetSalesRecordData(lblSalesRecordId.Text));
        }
    }
    private void AddRowSelectToGridView(GridView gv)
    {
        foreach (GridViewRow row in gv.Rows)
        {
            row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gv, "Select$" + row.RowIndex.ToString(), true));
        }
    }
    protected override void Render(HtmlTextWriter writer)
    {
        AddRowSelectToGridView(gvSalesRecordData);

        base.Render(writer);
    }



    protected void btnSalesRecordDataSearch_Click(object sender, EventArgs e)
    {
        lblSalesRecordId.Text = hdnSalesRecordId.Value;
        //UpdatePanel1.Update();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "opennewwindow", "alert(" + txtSalesRecordId.Text + ");", true);        
        DisplaySalesRecordData(GetSalesRecordData(lblSalesRecordId.Text));
    }

    private DataTable GetSalesRecordData(string date)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = "select MA.MA002 '客戶簡稱'" +
                " ,TH.TH004 '品號'" +
                " ,TH.TH005 '品名'" +
                " ,TH.TH006 '規格'" +
                " ,CONVERT(DECIMAL(20,2),TH.TH008) '數量'" +
                " ,TH.TH009 '單位'" +
                " ,TH.TH007 '庫別'" +
                " ,MC.MC003 '儲位'" +
                //" ,TG.TG008 '送貨地址'" +
                //" ,TG.TG009 'ALT送貨地址'" +
                " ,case" +
                " when TG.TG009= '' then TG.TG008" +
                " else TG.TG009" +
                " end '送貨地址'" +
                " ,MA.MA001 '客戶代號'" +
                " ,TH.TH001 '單別'" +
                " ,TH.TH002 '單號'" +
                " ,TH.TH003 '序號'" +
                " from COPTG TG" +
                " left join COPTH TH on TG.TG001 = TH.TH001 and TG.TG002 = TH.TH002" +
                " left join COPMA MA on TG.TG004 = MA.MA001" +
                " left join INVMC MC on TH.TH004 = MC.MC001 and TH.TH007 = MC.MC002" +
                " where(TG.TG001 = 'A230'" +
                " or TG.TG001 = 'A233')" +
                " and SUBSTRING(TG.TG002,1,8)= @date" +
                " order by" +
                " (case" +
                " when TG.TG009= '' then TG.TG008" +
                " else TG.TG009" +
                " end)" +
                " ,MA.MA001";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@date", date);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }

    private void DisplaySalesRecordData(DataTable dt)
    {
        gvSalesRecordData.DataSource = dt;
        gvSalesRecordData.DataBind();
    }

    protected void gvSalesRecordData_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblModalRecordFullId.Text = ((HiddenField)gvSalesRecordData.SelectedRow.FindControl("lblSalesRecordType")).Value.Trim() + "-"
            + ((HiddenField)gvSalesRecordData.SelectedRow.FindControl("lblSalesRecordId")).Value.Trim() + "-"
            + ((HiddenField)gvSalesRecordData.SelectedRow.FindControl("lblSalesRecordItemNumber")).Value.Trim();
        lblModalCustomerName.Text = ((Label)gvSalesRecordData.SelectedRow.FindControl("lblCustomerName")).Text.Trim();
        lblModalProductId.Text = ((Label)gvSalesRecordData.SelectedRow.FindControl("lblProductId")).Text.Trim();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#recordDetail').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "initModal", sb.ToString(), false);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
}