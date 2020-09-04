﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sunrise_intranet_PD_PurchaseCostCalculator : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["SunrizeConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DataTable dt = new DataTable();
            //dt = GetPurchaseFormType();

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    ddlPurchaseFormType.Items.Add(dt.Rows[i]["單別"].ToString().Trim());
            //}

            //if (ddlPurchaseFormType.Items.Count > 0)
            //{
            //    ddlPurchaseFormType.SelectedValue = "A332";
            //}
        }

        if (gvPurchaseForm.Rows.Count == 0)
        {
            btnCalculateTotalCost.Enabled = false;
        }
    }

    private DataTable GetPurchaseFormType()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = "select mq.MQ001 '單別'" +
                " from CMSMQ mq" +
                " where mq.MQ003='33'" +
                " order by mq.MQ001";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }

    private DataTable GetPurchaseFormData(string type, string id)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = "select convert(decimal(4,0),td.TD003) '序號'" +
                " ,td.TD004 '品號'" +
                " ,td.TD005 '品名'" +
                " ,td.TD006 '規格'" +
                " ,tc.TC005 '幣別'" +
                " ,convert(decimal(20, 4), tc.TC006) '匯率'" +
                " ,convert(decimal(20, 4), td.TD010) '單價'" +
                " ,convert(decimal(20, 0), td.TD008) '數量'" +
                " ,convert(decimal(20, 4), td.TD011) '總價'" +
                " ,convert(decimal(20, 4), tc.TC019) '未稅採購金額'" +
                " from PURTC tc" +
                " left join PURTD td on tc.TC001 = td.TD001 and tc.TC002 = td.TD002" +
                " where tc.TC001 = @purchaseFormType" +
                " and tc.TC002=@purchaseFormId" +
                " order by td.TD003";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@purchaseFormType", type);
            cmd.Parameters.AddWithValue("@purchaseFormId", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }

    private void DisplayGridview(GridView gv, DataTable dt)
    {
        gv.DataSource = dt;
        gv.DataBind();
    }

    private void ClearGridview(GridView gv)
    {
        gv.DataSource = null;
        gv.DataBind();
    }

    private void ResetCalculationParameter()
    {
        btnCalculateTotalCost.Enabled = false;
        txtImportFormExchangeRate.Text = string.Empty;
        txtPurchaseFormExchangeRate.Text = string.Empty;
        lblImportFormCurrency.Text = string.Empty;
        lblPurchaseFormCurrency.Text = string.Empty;
        txtTransportCost.Text = string.Empty;
        lblTransportCostPercent.Text = string.Empty;
        txtPromotionCost.Text = string.Empty;
        lblPromotionCostPercent.Text = string.Empty;
        txtImportTax.Text = string.Empty;
        lblTransportCostPercent.Text = string.Empty;
        txtOtherCost.Text = string.Empty;
        lblOtherCostPercent.Text = string.Empty;
    }

    protected void btnSearchPurchaseForm_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetPurchaseFormData(txtPurchaseFormType.Text, txtPurchaseFormId.Text);
        if (dt.Rows.Count > 0)
        {
            DisplayGridview(gvPurchaseForm, dt);
            lblPurchaseFormCurrency.Text = dt.Rows[0]["幣別"].ToString().Trim();
            txtPurchaseFormExchangeRate.Text = dt.Rows[0]["匯率"].ToString().Trim();
            lblImportFormCurrency.Text = lblPurchaseFormCurrency.Text;
            btnCalculateTotalCost.Enabled = true;
        }
        else
        {
            ClearGridview(gvPurchaseForm);
            ResetCalculationParameter();
        }
    }

    protected void gvPurchaseForm_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    ((Label)e.Row.FindControl("lblCostExcludeMaterial")).Text = "111";
        //    decimal totalMaterialCost = Convert.ToDecimal(((HiddenField)e.Row.FindControl("hdnTotalMaterialCostBeforeTax")).Value);
        //    decimal materialCost = Convert.ToDecimal(((Label)e.Row.FindControl("lblItemTotalCost")).Text);
        //    decimal materialPercent = materialCost / totalMaterialCost;

        //    decimal transportCost;
        //    decimal promotionCost;
        //    decimal taxCost;
        //    decimal otherCost;

        //    if (decimal.TryParse(txtTransportCost.Text, out transportCost)
        //        && decimal.TryParse(txtPromotionCost.Text, out promotionCost)
        //        && decimal.TryParse(txtImportTax.Text, out taxCost)
        //        && decimal.TryParse(txtOtherCost.Text, out otherCost))
        //    {
        //        ((Label)e.Row.FindControl("lblCostExcludeMaterial")).Text = (
        //            Math.Round(transportCost * materialPercent, 4) +
        //            Math.Round(promotionCost * materialPercent, 4) +
        //            Math.Round(taxCost * materialPercent, 4) +
        //            Math.Round(otherCost * materialPercent, 4)
        //            ).ToString();
        //    }
        //    else
        //    {
        //        ((Label)e.Row.FindControl("lblCostExcludeMaterial")).Text = "132";
        //    }
        //}
    }

    protected void btnCalculateTotalCost_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtImportFormExchangeRate.Text))
        {
            txtImportFormExchangeRate.Text = txtPurchaseFormExchangeRate.Text;
        }
        if (string.IsNullOrWhiteSpace(txtTransportCost.Text))
        {
            txtTransportCost.Text = "0";
        }
        if (string.IsNullOrWhiteSpace(txtPromotionCost.Text))
        {
            txtPromotionCost.Text = "0";
        }
        if (string.IsNullOrWhiteSpace(txtImportTax.Text))
        {
            txtImportTax.Text = "0";
        }
        if (string.IsNullOrWhiteSpace(txtOtherCost.Text))
        {
            txtOtherCost.Text = "0";
        }

        decimal totalMaterialCost = Convert.ToDecimal(((HiddenField)gvPurchaseForm.Rows[1].FindControl("hdnTotalMaterialCostBeforeTax")).Value) * Convert.ToDecimal(txtImportFormExchangeRate.Text);
        decimal transportPercent = Math.Round(Convert.ToDecimal(txtTransportCost.Text) * 100 / totalMaterialCost, 2);
        decimal promotionPercent = Math.Round(Convert.ToDecimal(txtPromotionCost.Text) * 100 / totalMaterialCost, 2);
        decimal taxPercent = Math.Round(Convert.ToDecimal(txtImportTax.Text) * 100 / totalMaterialCost, 2);
        decimal otherPercent = Math.Round(Convert.ToDecimal(txtOtherCost.Text) * 100 / totalMaterialCost, 2);

        lblTransportCostPercent.Text = transportPercent.ToString() + "%";
        lblPromotionCostPercent.Text = promotionPercent.ToString() + "%";
        lblImportTaxPercent.Text = taxPercent.ToString() + "%";
        lblOtherCostPercent.Text = otherPercent.ToString() + "%";
    }

    protected void gvPurchaseForm_PreRender(object sender, EventArgs e)
    {
        GridView gv = (GridView)sender;
        decimal sum = 0;
        for (int i = 0; i < gvPurchaseForm.Rows.Count; i++)
        {
            decimal totalMaterialCost = Convert.ToDecimal(((HiddenField)gv.Rows[i].FindControl("hdnTotalMaterialCostBeforeTax")).Value);
            decimal materialCost = Convert.ToDecimal(((Label)gv.Rows[i].FindControl("lblItemTotalCost")).Text);
            decimal materialPercent = materialCost / totalMaterialCost;

            decimal transportCost;
            decimal promotionCost;
            decimal taxCost;
            decimal otherCost;

            if (decimal.TryParse(txtTransportCost.Text, out transportCost)
                && decimal.TryParse(txtPromotionCost.Text, out promotionCost)
                && decimal.TryParse(txtImportTax.Text, out taxCost)
                && decimal.TryParse(txtOtherCost.Text, out otherCost))
            {
                decimal total = transportCost * materialPercent +
                    promotionCost * materialPercent +
                    taxCost * materialPercent +
                    otherCost * materialPercent;

                ((Label)gv.Rows[i].FindControl("lblCostExcludeMaterial")).Text = Math.Round(total,0).ToString();

                sum += total;
            }
            else
            {
                ((Label)gv.Rows[i].FindControl("lblCostExcludeMaterial")).Text = "";
            }
        }
        lblTotalNonMaterialCost.Text = Math.Round(sum, 0).ToString();
    }
}