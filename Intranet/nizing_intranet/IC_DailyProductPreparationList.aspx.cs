using System;
using System.Collections.Generic;
using System.Configuration;
/*
 *  如果gridview有增加column,搜尋"cells",找到所有cells[int]做為reference的item,and change the column number accordingly
 */
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class nizing_intranet_IC_DailyProductPreparationList : Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string erp2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["user"] = getId();
            lblSalesRecordId.Text = DateTime.Today.ToString("yyyyMMdd");
            lblgvSalesRecordDataCaption.Text = lblSalesRecordId.Text;
        }
        DisplaySalesRecordData(GetSalesRecordTable(lblSalesRecordId.Text));


        //debug only
        //if (Session["user"] == null)
        //{
        //    Session["user"] = "kevin";
        //}
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
        //Uncomment to disable edit function for past records
        if (DateTime.ParseExact(lblSalesRecordId.Text, "yyyyMMdd", CultureInfo.InvariantCulture) >= DateTime.Today)
        {
            foreach (GridViewRow row in gv.Rows)
            {
                row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gv, "Select$" + row.RowIndex.ToString(), true));
            }
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
        DisplaySalesRecordData(GetSalesRecordTable(lblSalesRecordId.Text));
        lblgvSalesRecordDataCaption.Text = lblSalesRecordId.Text;
    }

    private DataTable GetSalesRecordTable(string date, params string[] condition)
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
                " ,case" +
                " when TG.TG009= '' then TG.TG008" +
                " else TG.TG009" +
                " end '送貨地址'" +
                " ,MA.MA001 '客戶代號'" +
                " ,TH.TH001 '單別'" +
                " ,TH.TH002 '單號'" +
                " ,TH.TH003 '序號'" +
                " ,convert(decimal(20, 4), TH.TH012) '單價'" +
                " ,coalesce(main.modified_time,null) '最後編輯時間'" +
                " ,coalesce(main.no_receipt, 0) '不附單據'" +
                " ,coalesce(main.no_segments, 0) '不可有接頭'" +
                " ,coalesce(body.attach_ul, 0) '附UL'" +
                " ,case" +
                " when coalesce(main.packing_unit,'箱')= '箱' then convert(nvarchar(20),convert(decimal(20, 0), coalesce(main.packing_amount, 0)))" +
                " else convert(nvarchar(20), convert(decimal(20, 2), coalesce(main.packing_amount, 0)))" +
                " end as '包裝數量'" +
                " ,coalesce(main.packing_unit, '箱') '包裝單位'" +
                " ,coalesce(body.memo, '') '注意事項'" +
                " ,coalesce(body.require_attention, 0) '需要注意'" +
                " from COPTG TG" +
                " left join COPTH TH on TG.TG001 = TH.TH001 and TG.TG002 = TH.TH002" +
                " left join COPMA MA on TG.TG004 = MA.MA001" +
                " left join INVMC MC on TH.TH004 = MC.MC001 and TH.TH007 = MC.MC002" +
                " left join NZ_ERP2.dbo.IC_DailyProductPreparationList_ListMain main on TG.TG001=main.record_type and TG.TG002=main.record_id and MA.MA001=main.customer_id" +
                " left join NZ_ERP2.dbo.IC_DailyProductPreparationList_ListBody body on TH.TH001=body.record_type and TH.TH002 = body.record_id and TH.TH003 = body.record_no and MA.MA001=body.customer_id and TH.TH004 = body.product_id and CONVERT(DECIMAL(20,2),TH.TH008)= body.product_amount and convert(decimal(20,4),TH.TH012)= body.product_price and TH.TH007 = body.product_inv" +
                " where(TG.TG001 = 'A230'" +
                " or TG.TG001 = 'A233')" +
                " and SUBSTRING(TG.TG002,1,8)= @date" +
                " and TG.TG020 not like '%自取%'" +
                " and TG.TG020 not like '%自送%'" +
                " and TG.TG020 not like '%暫放%'" +
                " order by" +
                " (case" +
                " when TG.TG009= '' then TG.TG008" +
                " else TG.TG009" +
                " end)" +
                " ,coalesce(main.no_receipt, 0)" +
                " ,TH.TH001" +
                " ,TH.TH002";

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
        DateTime result = new DateTime();
        txtModalEditTime.Text = DateTime.TryParse(((Label)gvSalesRecordData.SelectedRow.FindControl("lblLastEditTime")).Text.Trim(), out result) == false ? "尚未更新" : "最後更新時間: " + result.ToString("yyyy/MM/dd HH:mm");
        hdnModalCustomerId.Value = ((HiddenField)gvSalesRecordData.SelectedRow.FindControl("lblCustomerId")).Value.Trim();
        hdnModalProductAmount.Value = ((Label)gvSalesRecordData.SelectedRow.FindControl("lblProductAmount")).Text.Trim();
        hdnModalProductPrice.Value = ((HiddenField)gvSalesRecordData.SelectedRow.FindControl("lblProductPrice")).Value.Trim();
        hdnModalProductInv.Value = ((Label)gvSalesRecordData.SelectedRow.FindControl("lblProductInv")).Text.Trim();
        lblModalRecordFullId.Text = ((HiddenField)gvSalesRecordData.SelectedRow.FindControl("lblSalesRecordType")).Value.Trim() + "-"
            + ((HiddenField)gvSalesRecordData.SelectedRow.FindControl("lblSalesRecordId")).Value.Trim() + "-"
            + ((HiddenField)gvSalesRecordData.SelectedRow.FindControl("lblSalesRecordItemNumber")).Value.Trim();
        lblModalCustomerName.Text = ((Label)gvSalesRecordData.SelectedRow.FindControl("lblCustomerName")).Text.Trim();
        lblModalProductId.Text = ((Label)gvSalesRecordData.SelectedRow.FindControl("lblProductId")).Text.Trim();
        ckxModalAttachUl.Checked = ((CheckBox)gvSalesRecordData.SelectedRow.FindControl("ckxAttachUl")).Checked;
        ckxModalNoReceipt.Checked = ((CheckBox)gvSalesRecordData.SelectedRow.FindControl("ckxNoReceipt")).Checked;
        ckxModalNoSegments.Checked = ((CheckBox)gvSalesRecordData.SelectedRow.FindControl("ckxNoSegments")).Checked;
        txtModalItemMemo.Text = ((Label)gvSalesRecordData.SelectedRow.FindControl("lblMemo")).Text.Trim();
        ckxModalRequireAttention.Checked = Convert.ToBoolean(Convert.ToInt16(((HiddenField)gvSalesRecordData.SelectedRow.FindControl("ckxRequireAttention")).Value.Trim()));

        if (!ckxModalNoReceipt.Checked)
        {
            //Check for Database records that fits the following condition:
            //同日期+同地址+不附單據
            //return: 包裝數量, 包裝單位            
            using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
            {
                conn.Open();
                string query = "select top 1 main.packing_amount '包裝數量'" +
                    " ,main.packing_unit '包裝單位'" +
                    " from IC_DailyProductPreparationList_ListMain main" +
                    " left join NZ.dbo.COPTG TG ON main.record_type=TG.TG001 and main.record_id=TG.TG002" +
                    " where substring(main.record_id,1,8)=@date" +
                    " and" +
                    " (case" +
                    " when TG.TG009= '' then TG.TG008" +
                    " else TG.TG009" +
                    " end) = @address" +
                    " and main.no_receipt='0'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@date", ((HiddenField)gvSalesRecordData.SelectedRow.FindControl("lblSalesRecordId")).Value.Trim().Substring(0, 8));
                cmd.Parameters.AddWithValue("@address", ((Label)gvSalesRecordData.SelectedRow.FindControl("lblCustomerDeliverAddress")).Text.Trim());
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    txtModalPackingAmount.Text = dt.Rows[0]["包裝數量"].ToString();
                    ddlModalPackingUnit.SelectedValue = dt.Rows[0]["包裝單位"].ToString();
                }
                else
                {
                    txtModalPackingAmount.Text = ((HiddenField)gvSalesRecordData.SelectedRow.FindControl("lblPackageAmount")).Value.Trim();
                    ddlModalPackingUnit.SelectedValue = ((HiddenField)gvSalesRecordData.SelectedRow.FindControl("lblPackageUnit")).Value.Trim();
                }
            }

        }
        else
        {
            txtModalPackingAmount.Text = ((HiddenField)gvSalesRecordData.SelectedRow.FindControl("lblPackageAmount")).Value.Trim();
            ddlModalPackingUnit.SelectedValue = ((HiddenField)gvSalesRecordData.SelectedRow.FindControl("lblPackageUnit")).Value.Trim();
        }

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#recordDetail').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "initModal", sb.ToString(), false);
        //upData.Update();
    }

    protected void btnSaveDetail_Click(object sender, EventArgs e)
    {
        string[] record = lblModalRecordFullId.Text.Split('-');
        using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
        {
            conn.Open();

            //1. Check for existing data that matches exactly to the submitted data
            //if exists then update
            //else insert
            //2. If submitted data不附單據 then check in ListMain for existing data that matches the following condition 同日期+同地址+不附單據
            //if exists then overwrite modifier/modified_time/packing_amount/packing_unit
            string query =
                //step 1
                "update IC_DailyProductPreparationList_ListMain" +
                " set modifier=@modifier" +
                " ,modified_time=getdate()" +
                " ,no_receipt=@noReceipt" +
                " ,no_segments=@noSegments" +
                " ,packing_amount=@packingAmount" +
                " ,packing_unit=@packingUnit" +
                " where record_type=@recordType" +
                " and record_id = @recordId" +
                " and customer_id=@customerId" +
                " if @@ROWCOUNT=0" +
                " insert into IC_DailyProductPreparationList_ListMain(modifier,modified_time,record_type,record_id,customer_id,no_receipt,no_segments,packing_amount,packing_unit)" +
                " values (@modifier,getdate(),@recordType,@recordId,@customerId,@noReceipt,@noSegments,@packingAmount,@packingUnit)" +
                " update IC_DailyProductPreparationList_ListBody" +
                " set modifier=@modifier" +
                " ,modified_time=getdate()" +
                " ,attach_ul=@attachUl" +
                " ,memo=@memo" +
                " ,require_attention=@requireAttention" +
                " where record_type=@recordType" +
                " and record_id=@recordId" +
                " and record_no=@recordNo" +
                " and customer_id=@customerId" +
                " and product_id=@productId" +
                " and product_amount=@productAmount" +
                " and product_price=@productPrice" +
                " and product_inv=@productInv" +
                " if @@ROWCOUNT=0" +
                " insert into IC_DailyProductPreparationList_ListBody(modifier,modified_time,record_type,record_id,record_no,customer_id,product_id,product_amount,product_price,product_inv,attach_ul,memo,require_attention)" +
                " values (@modifier,getdate(),@recordType,@recordId,@recordNo,@customerId,@productId,@productAmount,@productPrice,@productInv,@attachUl,@memo,@requireAttention)";
            //step 2
            if (!ckxModalNoReceipt.Checked)
            {
                query += " update main" +
                       " set main.modifier=@modifier" +
                       " ,main.modified_time=getdate()" +
                       " ,main.packing_amount=@packingAmount" +
                       " ,main.packing_unit=@packingUnit" +
                       " from IC_DailyProductPreparationList_ListMain main" +
                       " left join NZ.dbo.COPTG TG ON main.record_type=TG.TG001 and main.record_id=TG.TG002" +
                       " where substring(main.record_id,1,8)=@date" +
                       " and" +
                       " (case" +
                       " when TG.TG009= '' then TG.TG008" +
                       " else TG.TG009" +
                       " end) = @address" +
                       " and main.no_receipt='0'";
            }

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@modifier", Session["user"].ToString());
            cmd.Parameters.AddWithValue("@recordType", record[0]);
            cmd.Parameters.AddWithValue("@recordId", record[1]);
            cmd.Parameters.AddWithValue("@recordNo", record[2]);
            cmd.Parameters.AddWithValue("@customerId", hdnModalCustomerId.Value.Trim());
            cmd.Parameters.AddWithValue("@productId", lblModalProductId.Text.Trim());
            cmd.Parameters.AddWithValue("@productAmount", hdnModalProductAmount.Value.Trim());
            cmd.Parameters.AddWithValue("@productPrice", hdnModalProductPrice.Value.Trim());
            cmd.Parameters.AddWithValue("@productInv", hdnModalProductInv.Value.Trim());
            cmd.Parameters.AddWithValue("@attachUl", ckxModalAttachUl.Checked);
            cmd.Parameters.AddWithValue("@noReceipt", ckxModalNoReceipt.Checked);
            cmd.Parameters.AddWithValue("@noSegments", ckxModalNoSegments.Checked);
            cmd.Parameters.AddWithValue("@packingAmount", txtModalPackingAmount.Text.Trim());
            cmd.Parameters.AddWithValue("@packingUnit", ddlModalPackingUnit.SelectedValue);
            cmd.Parameters.AddWithValue("@memo", txtModalItemMemo.Text.Trim());
            cmd.Parameters.AddWithValue("@requireAttention", ckxModalRequireAttention.Checked);
            cmd.Parameters.AddWithValue("@date", record[1].Substring(0, 8));
            cmd.Parameters.AddWithValue("@address", ((Label)gvSalesRecordData.SelectedRow.FindControl("lblCustomerDeliverAddress")).Text.Trim());
            cmd.ExecuteNonQuery();
        }
        DisplaySalesRecordData(GetSalesRecordTable(lblSalesRecordId.Text));
    }

    protected void gridView_PreRender(object sender, EventArgs e)
    {
        GridDecorator.MergeRows(gvSalesRecordData);


        //gridview format完成後，計算總箱數
        decimal sum = 0;

        for (int i = 0; i < gvSalesRecordData.Rows.Count; i++)
        {
            if (((HiddenField)gvSalesRecordData.Rows[i].FindControl("lblPackageUnit")).Value.Trim() == "箱" && gvSalesRecordData.Rows[i].Cells[0].Visible == true)
            {
                sum += Convert.ToDecimal(((HiddenField)gvSalesRecordData.Rows[i].FindControl("lblPackageAmount")).Value.Trim());
            }
        }
        lblTotalPackedBoxes.Text = "共" + sum.ToString() + "箱";
    }

    public class GridDecorator
    {
        public static void MergeRows(GridView gv)
        {
            for (int rowIndex = gv.Rows.Count - 1; rowIndex >= 0; rowIndex--)
            {

                GridViewRow row = gv.Rows[rowIndex];

                DateTime result = new DateTime();

                if (Convert.ToDecimal(((HiddenField)row.FindControl("lblPackageAmount")).Value.Trim()) <= 0)
                {
                    row.BackColor = System.Drawing.Color.LightBlue;
                }

                if (Convert.ToBoolean(Convert.ToInt16(((HiddenField)row.FindControl("ckxRequireAttention")).Value.Trim())))
                {
                    row.BackColor = System.Drawing.Color.PaleVioletRed;
                }


                if (rowIndex < gv.Rows.Count - 1)
                {
                    GridViewRow previousRow = gv.Rows[rowIndex + 1];
                    //Package Cell Merge Condition:
                    //A: 同銷貨單 (單別+單號)
                    //B: 同地址、不附單據、已更新
                    if ((((HiddenField)row.FindControl("lblSalesRecordType")).Value.Trim() == ((HiddenField)previousRow.FindControl("lblSalesRecordType")).Value.Trim()
                        && ((HiddenField)row.FindControl("lblSalesRecordId")).Value.Trim() == ((HiddenField)previousRow.FindControl("lblSalesRecordId")).Value.Trim())
                        ||
                        (((Label)row.FindControl("lblCustomerDeliverAddress")).Text.Trim() == ((Label)previousRow.FindControl("lblCustomerDeliverAddress")).Text.Trim()
                        && ((CheckBox)row.FindControl("ckxNoReceipt")).Checked == false
                        && ((CheckBox)previousRow.FindControl("ckxNoReceipt")).Checked == false
                        && DateTime.TryParse(((Label)row.FindControl("lblLastEditTime")).Text.Trim(), out result) == true
                        && DateTime.TryParse(((Label)previousRow.FindControl("lblLastEditTime")).Text.Trim(), out result) == true
                        )
                        )
                    {
                        row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 :
                                               previousRow.Cells[0].RowSpan + 1;
                        previousRow.Cells[0].Visible = false;
                    }

                    //不可有接頭 Merge Condition:
                    //同銷貨單
                    if ((((HiddenField)row.FindControl("lblSalesRecordType")).Value.Trim() == ((HiddenField)previousRow.FindControl("lblSalesRecordType")).Value.Trim()
                        && ((HiddenField)row.FindControl("lblSalesRecordId")).Value.Trim() == ((HiddenField)previousRow.FindControl("lblSalesRecordId")).Value.Trim()))
                    {
                        row.Cells[11].RowSpan = previousRow.Cells[11].RowSpan < 2 ? 2 :
                                               previousRow.Cells[11].RowSpan + 1;
                        previousRow.Cells[11].Visible = false;
                    }

                }
            }
        }
    }
}