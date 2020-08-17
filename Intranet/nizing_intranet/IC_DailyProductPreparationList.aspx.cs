using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class nizing_intranet_IC_DailyProductPreparationList : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string erp2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblSalesRecordId.Text = DateTime.Today.ToString("yyyyMMdd");
            DisplaySalesRecordData(GetSalesRecordData(lblSalesRecordId.Text));
        }
    }

    /// <summary>
    /// Get user ID
    /// </summary>
    /// <returns></returns>
    protected string getId()
    {
        WindowsPrincipal principal = (WindowsPrincipal)User;
        WindowsIdentity identity = (WindowsIdentity)User.Identity;
        string[] name = identity.Name.Split('\\');
        return name[1];
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
                " ,convert(decimal(20,4),TH.TH012) '單價'" +
                " ,main.modified_time '最後編輯時間'" +
                " ,main.no_receipt '不附單據'" +
                " ,convert(nvarchar(20),main.packing_amount)+main.packing_unit '包裝'" +
                //" ,main.packing_unit '包裝單位'" +
                " ,body.attach_ul '附UL'" +
                " ,body.memo '注意事項'" +
                " from COPTG TG" +
                " left join COPTH TH on TG.TG001 = TH.TH001 and TG.TG002 = TH.TH002" +
                " left join COPMA MA on TG.TG004 = MA.MA001" +
                " left join INVMC MC on TH.TH004 = MC.MC001 and TH.TH007 = MC.MC002" +
                " left join NZ_ERP2.dbo.IC_DailyProductPreparationList_ListMain main on TG.TG001=main.record_id and TG.TG002=main.record_id and MA.MA001=main.customer_id" +
                " left join NZ_ERP2.dbo.IC_DailyProductPreparationList_ListBody body on TH.TH001 = body.record_type and TH.TH002 = body.record_id and TH.TH003 = body.record_no and TH.TH004 = body.product_id and CONVERT(DECIMAL(20,2),TH.TH008)= body.product_amount and convert(decimal(20,4),TH.TH012)= body.product_price and TH.TH007 = body.product_inv" +
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
        hdnModalCustomerId.Value = ((HiddenField)gvSalesRecordData.SelectedRow.FindControl("lblCustomerId")).Value.Trim();
        hdnModalProductAmount.Value = ((Label)gvSalesRecordData.SelectedRow.FindControl("lblProductAmount")).Text.Trim();
        hdnModalProductPrice.Value = ((HiddenField)gvSalesRecordData.SelectedRow.FindControl("lblProductPrice")).Value.Trim();
        hdnModalProductInv.Value = ((Label)gvSalesRecordData.SelectedRow.FindControl("lblProductInv")).Text.Trim();
        DataTable dt = new DataTable();
        dt = GetItemDetailData();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#recordDetail').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "initModal", sb.ToString(), false);
    }

    private DataTable GetItemDetailData()
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
        {
            conn.Open();
            
            
        }

        return dt;
    }
    protected void btnSaveDetail_Click(object sender, EventArgs e)
    {

    }
}