using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class employee_section_report_SD_ProfitMarginByProductReport : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string erp2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = DateTime.Now.Year; i > 2015; i--)
            {
                ddlParameterYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlParameterYear.SelectedValue = DateTime.Now.Year.ToString();

            for (int i = 1; i < 13; i++)
            {
                ddlParameterMonth.Items.Add(new ListItem(i.ToString("D2"), i.ToString("D2")));
            }
            ddlParameterMonth.SelectedValue = DateTime.Now.Month.ToString("D2");

            DataTable dt = GetSalesId();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlParameterSales.Items.Add(new ListItem(dt.Rows[i]["id"].ToString().Trim() + " - " + dt.Rows[i]["name"].ToString().Trim()
                    , dt.Rows[i]["id"].ToString().Trim()));
            }
            ddlParameterSales.Items.Insert(0, new ListItem("全部人員", "all"));
            ddlParameterSales.SelectedIndex = 0;

            txtOperationCost.Text = GetOperationCost().ToString("0.00");
        }
    }

    private DataTable GetSalesId()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "select distinct tg.TG006 'id'" +
                " ,mv.MV002 'name'" +
                " from COPTG tg" +
                " left join CMSMV mv on tg.TG006=mv.MV001" +
                " where tg.TG006<>''" +
                " order by tg.TG006";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }

    private decimal GetOperationCost()
    {
        using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
        {
            conn.Open();

            string query = "";

            if (rdoMonth.Checked)
            {
                query = "select oc.operationCostPercent" +
                " from NizingOperationCostByMonth oc" +
                " where oc.year=@year" +
                " and oc.month=@month";
            }
            else
            {
                query = "select oc.operationCostPercent" +
                " from NizingOperationCostByYear oc" +
                " where oc.year=@year";
            }

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@year", Convert.ToInt32(ddlParameterYear.SelectedValue));
            cmd.Parameters.AddWithValue("@month", Convert.ToInt32(ddlParameterMonth.SelectedValue));

            return Convert.IsDBNull(cmd.ExecuteScalar()) || cmd.ExecuteScalar() == null ? 0 : (decimal)cmd.ExecuteScalar();
        }
    }

    protected void reportTypeChanged(object sender, EventArgs e)
    {
        if (rdoMonth.Checked)
        {
            ddlParameterMonth.Enabled = true;
        }
        else
        {
            ddlParameterMonth.Enabled = false;
        }

        txtOperationCost.Text = GetOperationCost().ToString("0.00");
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        decimal operationCost;
        if (decimal.TryParse((txtOperationCost.Text.Split('%'))[0], out operationCost))
        {
            txtOperationCost.Text = operationCost.ToString("0.00");
        }
        else
        {
            txtOperationCost.Text = "0.00";
        }
        UpdateOperationCost();
        GetData();
    }

    private void UpdateOperationCost()
    {
        using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
        {
            conn.Open();

            string query = "";

            if (rdoMonth.Checked)
            {
                query = "update NizingOperationCostByMonth" +
                    " set operationCostPercent=@oc" +
                    " where year=@year" +
                    " and month=@month" +
                    " if @@ROWCOUNT=0" +
                    " insert into NizingOperationCostByMonth" +
                    " values (@year, @month, @oc)";
            }
            else
            {
                query = "update NizingOperationCostByYear" +
                    " set operationCostPercent=@oc" +
                    " where year=@year" +
                    " if @@ROWCOUNT=0" +
                    " insert into NizingOperationCostByYear" +
                    " values (@year, @oc)";
            }

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@year", Convert.ToInt32(ddlParameterYear.SelectedValue));
            cmd.Parameters.AddWithValue("@month", Convert.ToInt32(ddlParameterMonth.SelectedValue));
            cmd.Parameters.AddWithValue("@oc", Convert.ToDecimal(txtOperationCost.Text.Trim()));

            cmd.ExecuteNonQuery();
        }
    }
    private void GetData()
    {
        DateTime baseDate;
        DateTime start;
        DateTime end;
        if (rdoMonth.Checked)
        {
            baseDate = DateTime.ParseExact(ddlParameterYear.SelectedValue + ddlParameterMonth.SelectedValue + "26", "yyyyMMdd", CultureInfo.InvariantCulture);
            start = baseDate.AddMonths(-1);
            end = baseDate.AddDays(-1);
        }
        else
        {
            baseDate = DateTime.ParseExact(ddlParameterYear.SelectedValue + "1226", "yyyyMMdd", CultureInfo.InvariantCulture);
            start = baseDate.AddYears(-1);
            end = baseDate.AddDays(-1);
        }

        string startDate = start.ToString("yyyyMMdd");
        string endDate = end.ToString("yyyyMMdd");
        lblDateRange.Text = startDate + " ~ " + endDate;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string salesIdCondition = "";
            if (ddlParameterSales.SelectedValue != "all")
            {
                salesIdCondition = " where d.業務=@salesId";
            }
            string query = ";with data" +
                " as" +
                " (" +
                " select ti.TI001 + '-' + ti.TI002 '單號'" +
                " ,SUBSTRING(ti.TI034, 1, 4) '年'" +
                " ,SUBSTRING(ti.TI034, 5, 2) '月'" +
                " ,'銷退' '類型'" +
                " ,ti.TI006 '業務'" +
                " ,tj.TJ004 '品號'" +
                " ,case " +
                " when tj.TJ008 = mb.MB004 then - tj.TJ007" +
                " else -(tj.TJ007 * (select MD004 from INVMD where MD001 = tj.TJ004 and MD002 = tj.TJ008)/ (select MD003 from INVMD where MD001 = tj.TJ004 and MD002 = tj.TJ008))" +
                " end as '數量'" +
                " ,mb.MB004 '單位'" +
                " ,-tj.TJ033 '金額'" +
                " ,lb.LB002 '成本年月'" +
                " ,coalesce(lb.LB010, 0) '單位成本'" +
                " ,case " +
                " when tj.TJ004 = 'P' then 0" +
                " when tj.TJ008 = mb.MB004 then - tj.TJ007 * coalesce(lb.LB010, 0)" +
                " else -(coalesce(lb.LB010, 0) * tj.TJ007 * (select MD004 from INVMD where MD001 = tj.TJ004 and MD002 = tj.TJ008)/ (select MD003 from INVMD where MD001 = tj.TJ004 and MD002 = tj.TJ008))" +
                " end as '銷貨成本'" +
                " from COPTI ti" +
                " left join COPTJ tj on ti.TI001 = tj.TJ001 and ti.TI002 = tj.TJ002" +
                " left join INVLB lb on tj.TJ004 = lb.LB001 and lb.LB002 = (select top 1 LB002 from INVLB where LB001 = tj.TJ004 and LB002<= SUBSTRING(ti.TI034, 1, 6) order by LB002 desc)" +
                " left join INVMB mb on tj.TJ004 = mb.MB001" +
                " where ti.TI019 = 'Y'" +
                " and ti.TI004<>'AA2446'" +
                " and ti.TI034 between @startDate and @endDate" +
                " union all" +
                " select tg.TG001 + '-' + tg.TG002 '單號'" +
                " ,SUBSTRING(tg.TG042, 1, 4) '年'" +
                " ,SUBSTRING(tg.TG042, 5, 2) '月'" +
                " ,'銷貨' '類型'" +
                " ,tg.TG006 '業務'" +
                " ,th.TH004 '品號'" +
                " ,case " +
                " when th.TH009 = mb.MB004 then th.TH008" +
                " else (th.TH008 * (select MD004 from INVMD where MD001 = th.TH004 and MD002 = th.TH009)/ (select MD003 from INVMD where MD001 = th.TH004 and MD002 = th.TH009))" +
                " end as '數量'" +
                " ,mb.MB004 '單位'" +
                " ,th.TH037 '金額'" +
                " ,lb.LB002 '成本年月'" +
                " ,coalesce(lb.LB010, 0) '單位成本'" +
                " ,case" +
                " when th.TH004 = 'P' then 0" +
                " when th.TH009 = mb.MB004 then th.TH008* coalesce(lb.LB010,0)" +
                " else (coalesce(lb.LB010, 0) * th.TH008 * (select MD004 from INVMD where MD001 = th.TH004 and MD002 = th.TH009)/ (select MD003 from INVMD where MD001 = th.TH004 and MD002 = th.TH009))" +
                " end as '銷貨成本'" +
                " from COPTG tg" +
                " left join COPTH th on tg.TG001 = th.TH001 and tg.TG002 = th.TH002" +
                " left join INVLB lb on th.TH004 = lb.LB001 and lb.LB002 = (select top 1 LB002 from INVLB where LB001 = th.TH004 and LB002<= SUBSTRING(tg.TG042, 1, 6) order by LB002 desc)" +
                " left join INVMB mb on th.TH004 = mb.MB001" +
                " where tg.TG023 = 'Y'" +
                " and tg.TG004<>'AA2446'" +
                " and tg.TG042 between @startDate and @endDate" +
                " )" +
                " select" +
                " d.業務 '業務'" +
                " ,mv.MV002 '業務名稱'" +
                " ,d.品號 '品號'" +
                " ,mb.MB002 '品名'" +
                " ,mb.MB003 '規格'" +
                " ,convert(decimal(20, 2), SUM(d.數量)) '銷售淨量'" +
                " ,mb.MB004 '單位'" +
                " , convert(decimal(20, 2), SUM(d.金額)) '銷售淨額'" +
                " , convert(decimal(20, 2), SUM(d.銷貨成本)) '銷貨成本'" +
                " ,case" +
                " when SUM(d.數量)= 0 then 0" +
                " else convert(decimal(20, 2), SUM(d.金額) - SUM(d.銷貨成本))" +
                " end as '銷貨毛利'" +
                " ,case" +
                " when SUM(d.數量)= 0 then '0.00%'" +
                " when SUM(d.金額)= 0 then '0.00%'" +
                " else CONVERT(NVARCHAR,(CONVERT(DECIMAL(6, 2), (SUM(d.金額) - SUM(d.銷貨成本)) * 100 / SUM(d.金額)))) + '%'" +
                " end as '毛利率'" +
                " from data d" +
                " left join CMSMV mv on d.業務 = mv.MV001" +
                " left join INVMB mb on d.品號 = mb.MB001" +
                salesIdCondition +
                " group by" +
                " d.業務" +
                " ,mv.MV002" +
                " ,d.品號" +
                " ,mb.MB002" +
                " ,mb.MB003" +
                " ,mb.MB004" +
                " order by d.業務" +
                " ,d.品號";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@salesId", ddlParameterSales.SelectedValue);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvData.DataSource = dt;
            gvData.DataBind();
        }
    }

    protected void btnResetParameter_Click(object sender, EventArgs e)
    {
        ResetParameter();
    }

    private void ResetParameter()
    {
        ddlParameterYear.SelectedValue = DateTime.Now.Year.ToString();
        ddlParameterMonth.SelectedValue = DateTime.Now.Month.ToString("D2");
        ddlParameterSales.SelectedIndex = 0;
        txtOperationCost.Text = string.Empty;
        gvData.DataSource = null;
        gvData.DataBind();
    }

    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((Label)e.Row.FindControl("lblOperationCost")).Text = Math.Round(Convert.ToDecimal(txtOperationCost.Text), 2).ToString("0.00") + "%";

            ((Label)e.Row.FindControl("lblNetProfitPercent")).Text =
                (decimal.Parse((((Label)e.Row.FindControl("lblGrossProfitPercent")).Text.Split('%'))[0])
                - decimal.Parse((((Label)e.Row.FindControl("lblOperationCost")).Text.Split('%'))[0]))
                .ToString("0.00") + "%";
        }
    }
    protected void gvData_DataBound(object sender, EventArgs e)
    {
        if (gvData.Rows.Count > 0)
        {
            gvData.FooterRow.Cells[5].Text = "小記";
            gvData.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;

            //加總
            decimal netSaleAmountSum = 0;
            decimal netSaleValueSum = 0;
            decimal netSaleCostSum = 0;
            decimal netGrossProfit = 0;
            decimal operationCost = 0;

            for (int i = 0; i < gvData.Rows.Count; i++)
            {
                netSaleAmountSum += Convert.ToDecimal(((Label)gvData.Rows[i].FindControl("lblNetSaleAmount")).Text);
                netSaleValueSum += Convert.ToDecimal(((Label)gvData.Rows[i].FindControl("lblNetSaleValue")).Text);
                netSaleCostSum += Convert.ToDecimal(((Label)gvData.Rows[i].FindControl("lblSaleCost")).Text);
                netGrossProfit += Convert.ToDecimal(((Label)gvData.Rows[i].FindControl("lblGrossProfit")).Text);
            }

            gvData.FooterRow.Cells[6].Text = netSaleAmountSum.ToString("0.00");
            gvData.FooterRow.Cells[7].Text = netSaleValueSum.ToString("0.00");
            gvData.FooterRow.Cells[8].Text = netSaleCostSum.ToString("0.00");
            gvData.FooterRow.Cells[9].Text = netGrossProfit.ToString("0.00");
            gvData.FooterRow.Cells[10].Text = netSaleValueSum == 0 ? "0.00%"
                : (netGrossProfit * 100 / netSaleValueSum).ToString("0.00") + "%";
            gvData.FooterRow.Cells[11].Text = decimal.TryParse(txtOperationCost.Text, out operationCost) ?
                Math.Round(operationCost, 2).ToString("0.00") + "%" :
                "0.00%";
            gvData.FooterRow.Cells[12].Text = (decimal.Parse((gvData.FooterRow.Cells[10].Text.Split('%'))[0])
                - decimal.Parse((gvData.FooterRow.Cells[11].Text.Split('%'))[0])).ToString("0.00") + "%";
        }
    }

    protected void TimeFrameChanged(object sender, EventArgs e)
    {
        txtOperationCost.Text = GetOperationCost().ToString("0.00");
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (gvData.Rows.Count > 0)
        {
            ExportToExcel(gvData);
        }
    }

    private void ExportToExcel(GridView gv)
    {
        HttpContext.Current.Response.Clear();
        string filename = ddlParameterSales.SelectedItem.Text.Replace(" ","")+ "利潤明細表" + lblDateRange.Text.Replace(" ", "");
        string strfileext = ".xls";
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + strfileext);
        HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");

        //先把分頁關掉
        //gvResult.AllowPaging = false;
        //bindgv();

        //Get the HTML for the control.
        gv.RenderControl(hw);
        HttpContext.Current.Response.Write(tw.ToString());
        HttpContext.Current.Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //用export_excel必須要有這個override
    }
}