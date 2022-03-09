using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class employee_section_user_control_ConductorCalculatorInput : System.Web.UI.UserControl
{
    public string ddlRawMatText
    {
        get
        {
            return ddlRawMat.SelectedItem.Text;
        }
        set
        {
            ddlRawMat.SelectedItem.Text = value.Trim();
        }
    }
    public string ddlRawMatValue
    {
        get
        {
            return ddlRawMat.SelectedValue;
        }
        set
        {
            ddlRawMat.SelectedValue = value.Trim();
        }
    }
    public string txtCondCostText
    {
        get
        {
            return txtCondCost.Text.Trim();
        }
        set
        {
            txtCondCost.Text = value.Trim();
        }
    }
    public string txtCondODText
    {
        get
        {
            return txtCondCost.Text.Trim();
        }
        set
        {
            txtCondCost.Text = value.Trim();
        }
    }
    public string txtCondStrandNumberText
    {
        get
        {
            return txtCondStrandNumber.Text.Trim();
        }
        set
        {
            txtCondStrandNumber.Text = value.Trim();
        }
    }
    public string txtCondLengthText
    {
        get
        {
            return txtCondLength.Text.Trim();
        }
        set
        {
            txtCondLength.Text = value.Trim();
        }
    }
    public string lblCondWeightText
    {
        get
        {
            return lblCondWeight.Text.Trim();
        }
        set
        {
            lblCondWeight.Text = value.Trim();
        }
    }
    public string lblCondCostPerMeterText
    {
        get
        {
            return lblCondCostPerMeter.Text.Trim();
        }
        set
        {
            lblCondCostPerMeter.Text = value.Trim();
        }
    }
    public string txtCondCoreNumberText
    {
        get
        {
            return txtCondCoreNumber.Text.Trim();
        }
        set
        {
            txtCondCoreNumber.Text = value.Trim();
        }
    }
    public string lblCondTotalCostPerMeterText
    {
        get
        {
            return lblCondTotalCostPerMeter.Text.Trim();
        }
        set
        {
            lblCondTotalCostPerMeter.Text = value.Trim();
        }
    }
    public string lblCondTotalCostText
    {
        get
        {
            return lblCondTotalCost.Text.Trim();
        }
        set
        {
            lblCondTotalCost.Text = value.Trim();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ddlRawMat_SelectedIndexChanged(object sender, EventArgs e)
    {
        string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

        try
        {
            //clear previous entries
            ClearEntry();
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                //Retrieve all purchase order for this material
                SqlCommand cmdSelect = new SqlCommand("SELECT PURTH.TH007, (PURTH.TH047/PURTH.TH007) COST, CONVERT(NVARCHAR, INVMB.MB064) MB064"
                                            + " FROM PURTH"
                                            + " LEFT JOIN PURTG ON PURTH.TH001=PURTG.TG001 AND PURTH.TH002=PURTG.TG002"
                                            + " LEFT JOIN INVMB ON PURTH.TH004=INVMB.MB001"
                                            + " WHERE PURTH.TH004 = @NAME"
                                            + " ORDER BY PURTG.TG014 DESC", conn);
                cmdSelect.Parameters.AddWithValue("@NAME", ddlRawMat.SelectedValue.Trim());
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    decimal sum = 0;
                    decimal leftover = 0;
                    decimal sumCost = 0;
                    decimal sumStock = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (sum < Convert.ToDecimal(dt.Rows[i][2].ToString()))
                        {
                            sum += Convert.ToDecimal(dt.Rows[i][0].ToString());
                            if (sum >= Convert.ToDecimal(dt.Rows[i][2].ToString()))
                            {
                                leftover = Convert.ToDecimal(dt.Rows[i][2].ToString()) - (sum - Convert.ToDecimal(dt.Rows[i][0].ToString()));
                            }
                        }
                        else
                        {
                            dt.Rows[i].Delete();
                        }
                    }
                    dt.AcceptChanges();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i != dt.Rows.Count - 1)
                        {
                            sumCost += Convert.ToDecimal(dt.Rows[i][0].ToString()) * Convert.ToDecimal(dt.Rows[i][1].ToString());
                            sumStock += Convert.ToDecimal(dt.Rows[i][0].ToString());
                        }
                        else
                        {
                            sumCost += leftover * Convert.ToDecimal(dt.Rows[i][1].ToString());
                            sumStock += leftover;
                        }
                    }
                    if (sumStock != 0)
                    {
                        txtCondCost.Text = Math.Round((sumCost / sumStock), 4).ToString();
                    }
                    else
                    {
                        txtCondCost.Text = "0".ToString();
                    }
                }
                else
                {
                    txtCondCost.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            
        }
    }

    protected void btnCondCalculate_Click(object sender, EventArgs e)
    {
        double d = 0;
        if (ddlRawMat.SelectedValue == "00")
        {
            lblCondErrorMessage.Text = "請選擇導體";
        }
        else if (txtCondCoreNumber.Text.Trim() == "" || txtCondLength.Text.Trim() == "" || txtCondOD.Text.Trim() == "" || txtCondStrandNumber.Text.Trim() == "")
        {
            lblCondErrorMessage.Text = "請輸入全部的資料";
        }
        else if (!double.TryParse(txtCondCost.Text.Trim(), out d) || !double.TryParse(txtCondCoreNumber.Text.Trim(), out d) || !double.TryParse(txtCondLength.Text.Trim(), out d) || !double.TryParse(txtCondOD.Text.Trim(), out d) || !double.TryParse(txtCondStrandNumber.Text.Trim(), out d))
        {
            lblCondErrorMessage.Text = "請確認全部輸入的資料皆為數字";
        }
        else
        {
            Calculate();            
        }
    }

    protected void Calculate()
    {
        lblCondWeight.Text = Convert.ToString(Math.Round(0.7854 * Convert.ToDouble(txtCondOD.Text.Trim()) * Convert.ToDouble(txtCondOD.Text.Trim()) * Convert.ToDouble(txtCondStrandNumber.Text.Trim()) * 0.001* Convert.ToDouble(txtCondLength.Text.Trim()) * 8.9, 4));
        lblCondCostPerMeter.Text = Convert.ToString(Math.Round(0.7854 * Convert.ToDouble(txtCondOD.Text.Trim()) * Convert.ToDouble(txtCondOD.Text.Trim()) * Convert.ToDouble(txtCondStrandNumber.Text.Trim()) * 0.001 * Convert.ToDouble(txtCondCost.Text.Trim()) * 8.9, 4));
        lblCondTotalCostPerMeter.Text = Convert.ToString(Math.Round(Convert.ToDouble(lblCondCostPerMeter.Text) * Convert.ToDouble(txtCondCoreNumber.Text.Trim()), 4));
        lblCondTotalCost.Text = Convert.ToString(Math.Round(Convert.ToDouble(lblCondTotalCostPerMeter.Text) * Convert.ToDouble(txtCondLength.Text.Trim()), 4));
    }
    protected void ClearEntry()
    {
        txtCondOD.Text = "";
        txtCondStrandNumber.Text = "";
        txtCondLength.Text = "";
        lblCondWeight.Text = "";
        lblCondCostPerMeter.Text = "";
        txtCondCoreNumber.Text = "";
        lblCondTotalCostPerMeter.Text = "";
        lblCondTotalCost.Text = "";
    }
}