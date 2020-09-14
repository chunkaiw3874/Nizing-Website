using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class employee_section_report_SD_SalesBonusCalculator : System.Web.UI.Page
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

            txtOperationCost.Text = GetOperationCost().ToString("0.00");
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

        ResetParameter();
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
        string timeframeCondition = "";

        if (rdoMonth.Checked)
        {
            timeframeCondition = " and sbp.bonusType='月獎金' and sbp.bonusMonth=@month";
        }
        else
        {
            timeframeCondition = " and sbp.bonusType='年終獎金'";
        }

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = ";with data" +
                " as" +
                " (" +
                " select ti.TI006 '業務'" +
                " ,tj.TJ004 '品號'" +
                " ,case " +
                " when tj.TJ008 = mb.MB004 then - tj.TJ007" +
                " else -(tj.TJ007 * (select MD004 from INVMD where MD001 = tj.TJ004 and MD002 = tj.TJ008)/ (select MD003 from INVMD where MD001 = tj.TJ004 and MD002 = tj.TJ008))" +
                " end as '數量'" +
                " ,-tj.TJ033 '金額'" +
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
                " and ti.TI004 <> 'AA2446'" +
                " and ti.TI034 between @startDate and @endDate" +
                " union all" +
                " select tg.TG006 '業務'" +
                " ,th.TH004 '品號'" +
                " ,case " +
                " when th.TH009 = mb.MB004 then th.TH008" +
                " else (th.TH008 * (select MD004 from INVMD where MD001 = th.TH004 and MD002 = th.TH009)/ (select MD003 from INVMD where MD001 = th.TH004 and MD002 = th.TH009))" +
                " end as '數量'" +
                " ,th.TH037 '金額'" +
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
                " and tg.TG004 <> 'AA2446'" +
                " and tg.TG042 between @startDate and @endDate" +
                " )" +
                " select" +
                " d.業務 '業務'" +
                " ,mv.MV002 '業務名稱'" +
                " ,coalesce(convert(decimal(20, 2), SUM(d.金額)), '0.00') '銷售淨額'" +
                " ,case" +
                " when SUM(d.數量)= 0 then '0.00'" +
                " when SUM(d.金額)= 0 then '0.00'" +
                " else coalesce(CONVERT(NVARCHAR, (CONVERT(DECIMAL(5, 2), (SUM(d.金額) - SUM(d.銷貨成本)) * 100 / SUM(d.金額)))), '0.00') + '%'" +
                " end as '毛利率'" +
                " ,coalesce(sbp.bonusPercent, 0) '獎金成數'" +
                " from data d" +
                " left join CMSMV mv on d.業務 = mv.MV001" +
                " left join NZ_ERP2.dbo.NizingSalesBonusParameter sbp on d.業務=sbp.salesId and sbp.bonusYear=@year" +
                timeframeCondition +
                " group by" +
                " d.業務" +
                " ,mv.MV002" +
                " ,sbp.bonusPercent" +
                " order by d.業務";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);
            cmd.Parameters.AddWithValue("@year", endDate.Substring(0, 4));
            cmd.Parameters.AddWithValue("@month", Convert.ToInt32(endDate.Substring(4, 2)));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvData.DataSource = dt;
            gvData.DataBind();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        gvData.Visible = true;
        decimal operationCost;
        if (decimal.TryParse((txtOperationCost.Text.Split('%'))[0], out operationCost))
        {
            txtOperationCost.Text = operationCost.ToString("0.00");
        }
        else
        {
            txtOperationCost.Text = "0.00";
        }
        hdnDataYear.Value = ddlParameterYear.SelectedValue;
        hdnDataMonth.Value = ddlParameterMonth.SelectedValue;
        if (rdoMonth.Checked)
        {
            hdnBonusType.Value = "月獎金";
            lblBonusType.Text = hdnDataYear.Value + "/" + hdnDataMonth.Value + " " + hdnBonusType.Value + "計算";
        }
        else
        {
            hdnBonusType.Value = "年終獎金";
            lblBonusType.Text = hdnDataYear.Value + " " + hdnBonusType.Value + "計算";
        }

        btnUpdateBonusData.Visible = true;
        UpdateOperationCost();
        GetData();
        if (gvData.Rows.Count > 0)
        {
            btnUpdateBonusData.Enabled = true;
        }
    }

    protected void btnResetParameter_Click(object sender, EventArgs e)
    {
        ResetParameter();
    }

    protected void TimeFrameChanged(object sender, EventArgs e)
    {
        ResetParameter();
    }

    private void ResetParameter()
    {
        txtOperationCost.Text = GetOperationCost().ToString("0.00");
        lblBonusType.Text = string.Empty;
        btnUpdateBonusData.Visible = false;
        btnUpdateBonusData.Enabled = false;
        gvData.DataSource = null;
        gvData.DataBind();
        gvData.Visible = false;
    }

    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((Label)e.Row.FindControl("lblOperationCost")).Text = Math.Round(Convert.ToDecimal(txtOperationCost.Text), 2).ToString("0.00") + "%";
        }
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

    protected void gvData_DataBound(object sender, EventArgs e)
    {
        if (gvData.Rows.Count > 0)
        {
            CalculateBonus();
            gvData.FooterRow.BackColor = Color.Yellow;
        }
    }

    private void CalculateBonus()
    {
        decimal saleValueSum = 0;
        decimal bonusSum = 0;

        foreach (GridViewRow row in gvData.Rows)
        {
            decimal saleAmount = Convert.ToDecimal(((Label)row.FindControl("lblNetSaleValue")).Text);
            decimal grossProfit = Convert.ToDecimal((((Label)row.FindControl("lblGrossProfitPercent")).Text.Split('%'))[0]);
            decimal operationCost = Convert.ToDecimal((((Label)row.FindControl("lblOperationCost")).Text.Split('%'))[0]);
            decimal bonusPercent = Convert.ToDecimal((((TextBox)row.FindControl("txtBonusPercent")).Text.Split('%'))[0]);
            decimal bonus = Math.Round(saleAmount * (grossProfit - operationCost) / 100 * bonusPercent / 100, 0);

            ((Label)row.FindControl("lblBonus")).Text = bonus.ToString("0.00");

            saleValueSum += saleAmount;
            bonusSum += bonus;
        }

        gvData.FooterRow.Cells[1].Text = "小記";
        gvData.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
        gvData.FooterRow.Cells[2].Text = saleValueSum.ToString("C", CultureInfo.CreateSpecificCulture("zh-TW"));
        gvData.FooterRow.Cells[4].Text = "獎金概述";
        gvData.FooterRow.Cells[6].Text = bonusSum.ToString("C", CultureInfo.CreateSpecificCulture("zh-TW"));
        gvData.FooterRow.Cells[5].Text = saleValueSum == 0 ? "0.00%"
            : (bonusSum * 100 / saleValueSum).ToString("0.00") + "%";
    }

    protected void btnUpdateBonusData_Click(object sender, EventArgs e)
    {
        UpdateBonusData();
        CalculateBonus();
    }

    private void UpdateBonusData()
    {
        string query = "";

        if (hdnBonusType.Value == "月獎金")
        {
            query = "update NizingSalesBonusParameter" +
                " set bonusPercent=@bonus" +
                " where salesId=@salesId" +
                " and bonusType='月獎金'" +
                " and bonusYear=@year" +
                " and bonusMonth=@month" +
                " if @@ROWCOUNT=0" +
                " insert into NizingSalesBonusParameter" +
                " values (@salesId, '月獎金', @year, @month, @bonus)";
        }
        else if (hdnBonusType.Value == "年終獎金")
        {
            query = "update NizingSalesBonusParameter" +
                " set bonusPercent=@bonus" +
                " where salesId=@salesId" +
                " and bonusType='年終獎金'" +
                " and bonusYear=@year" +
                " if @@ROWCOUNT=0" +
                " insert into NizingSalesBonusParameter" +
                " values (@salesId, '年終獎金', @year, '', @bonus)";
        }

        foreach (GridViewRow row in gvData.Rows)
        {
            decimal bonus;

            if (decimal.TryParse((((TextBox)row.FindControl("txtBonusPercent")).Text.Split('%'))[0].Trim(), out bonus))
            {
                ((TextBox)row.FindControl("txtBonusPercent")).Text = bonus.ToString("0.00");
            }
            else
            {
                ((TextBox)row.FindControl("txtBonusPercent")).Text = "0.00";
            }

            using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@salesId", ((Label)row.FindControl("lblSalesId")).Text.Trim());
                cmd.Parameters.AddWithValue("@year", hdnDataYear.Value);
                cmd.Parameters.AddWithValue("@month", Convert.ToInt32(hdnDataMonth.Value));
                cmd.Parameters.AddWithValue("@bonus", Convert.ToDecimal(((TextBox)row.FindControl("txtBonusPercent")).Text));

                cmd.ExecuteNonQuery();
            }
        }
    }
}