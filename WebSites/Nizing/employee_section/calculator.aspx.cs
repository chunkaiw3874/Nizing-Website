using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class restricted_calculator : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    DataTable conductorListTable = new DataTable(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            conductorListTable.Columns.Add("ddlRawMat");
            conductorListTable.Columns.Add("txtCondCost");
            conductorListTable.Columns.Add("txtCondOD");
            conductorListTable.Columns.Add("txtCondStrandNumber");
            conductorListTable.Columns.Add("txtCondLength");
            conductorListTable.Columns.Add("lblCondWeight");
            conductorListTable.Columns.Add("lblCondCostPerMeter");
            conductorListTable.Columns.Add("txtCondCoreNumber");
            conductorListTable.Columns.Add("lblCondTotalCostPerMeter");
            conductorListTable.Columns.Add("lblCondTotalCost");
            ViewState["conductorListTable"] = conductorListTable;
        }
        else
        {
            conductorListTable = (DataTable)ViewState["conductorListTable"];            
        }
    }
    //protected void txtOD_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        double OD1 = 0;
    //        double OD2 = 0;
            
    //        if (txtOD1.Text.Trim() == "")
    //        {
    //            lblAns1.Text = "";
    //            txtOD1.Focus();
    //        }
    //        else if (txtOD2.Text.Trim() == "")
    //        {
    //            lblAns1.Text = "";
    //            txtOD2.Focus();
    //        }
    //        else
    //        {
    //            if (!double.TryParse(txtOD1.Text.Trim(), out OD1) && !double.TryParse(txtOD2.Text.Trim(), out OD2))
    //            {
    //                lblErrorMessage.Text = "數值格式錯誤，請重新輸入";
    //                txtOD1.Text = "";
    //                txtOD2.Text = "";
    //                txtOD1.Focus();
    //                lblAns1.Text = "";
    //            }
    //            else if (!double.TryParse(txtOD1.Text.Trim(), out OD1))
    //            {
    //                lblErrorMessage.Text = "數值格式錯誤，請重新輸入";
    //                txtOD1.Text = "";
    //                txtOD1.Focus();
    //                lblAns1.Text = "";
    //            }
    //            else if (!double.TryParse(txtOD2.Text.Trim(), out OD2))
    //            {
    //                lblErrorMessage.Text = "數值格式錯誤，請重新輸入";
    //                txtOD2.Text = "";
    //                txtOD2.Focus();
    //                lblAns1.Text = "";
    //            }
    //            else if (double.TryParse(txtOD1.Text.Trim(), out OD1) && double.TryParse(txtOD2.Text.Trim(), out OD2))
    //            {
    //                lblAns1.Text = (Math.Sqrt(OD2) * 1.155 * OD1).ToString();
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblErrorMessage.Text = ex.ToString();
    //    }
    //}
    //protected void ConvertKgAndM(object sender, EventArgs e)
    //{
    //    if (sender == txtCopperCoverter_Kg)
    //    {
    //        if (txtCopperCoverter_Kg.Text.Trim() == "")
    //        {
    //            txtCopperCoverter_M.Text = "";
    //        }
    //    }
    //}
    //protected void ddlRawMat_DataBound(object sender, EventArgs e)
    //{
    //    //if (!IsPostBack)
    //    //{
    //    //    //((DropDownList)grdStockCost.Rows[0].FindControl("ddlRawMat")).SelectedIndex = 5;
    //    //    ddlRawMat.SelectedIndex = 81;
    //    //}
    //}
    ////protected void ddlRawMat_SelectedIndexChanged(object sender, EventArgs e)
    ////{
    ////    try
    ////    {
    ////        using (SqlConnection conn = new SqlConnection(NZconnectionString))
    ////        {
    ////            conn.Open();
    ////            //Retrieve amount of goods on hand
    ////            SqlCommand cmdSelect = new SqlCommand("SELECT CONVERT(NVARCHAR, INVMB.MB064) MB064"
    ////                                                + " FROM INVMB"
    ////                                                + " WHERE INVMB.MB001=@NAME", conn);
    ////            cmdSelect.Parameters.AddWithValue("@NAME", ddlRawMat.SelectedValue.Trim());
    ////            SqlDataReader reader = cmdSelect.ExecuteReader();
    ////            if (reader.HasRows)
    ////            {
    ////                while (reader.Read())
    ////                {
    ////                    Label1.Text = reader.GetString(0);
    ////                }
    ////            }
    ////            else
    ////            {
    ////                Label1.Text = "";
    ////            }
    ////            if (!reader.IsClosed)
    ////            {
    ////                reader.Close();
    ////            }

    ////            //Retrieve all purchase order for this material
    ////            cmdSelect = new SqlCommand("SELECT PURTH.TH007, (PURTH.TH047/PURTH.TH007) COST"
    ////                                        + " FROM PURTH"
    ////                                        + " LEFT JOIN PURTG ON PURTH.TH001=PURTG.TG001 AND PURTH.TH002=PURTG.TG002"
    ////                                        + " WHERE PURTH.TH004 = @NAME"
    ////                                        + " ORDER BY PURTG.TG014 DESC", conn);
    ////            cmdSelect.Parameters.AddWithValue("@NAME", ddlRawMat.SelectedValue.Trim());
    ////            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
    ////            DataTable dt = new DataTable();
    ////            da.Fill(dt);
    ////            if (dt.Rows.Count > 0)
    ////            {
    ////                decimal sum = 0;
    ////                decimal leftover = 0;                    
    ////                decimal sumCost = 0;
    ////                decimal sumStock = 0;
    ////                for (int i = 0; i < dt.Rows.Count; i++)
    ////                {
    ////                    if (sum < Convert.ToDecimal(Label1.Text))
    ////                    {
    ////                        sum += Convert.ToDecimal(dt.Rows[i][0].ToString());
    ////                        if (sum >= Convert.ToDecimal(Label1.Text))
    ////                        {
    ////                            leftover = Convert.ToDecimal(Label1.Text) - (sum - Convert.ToDecimal(dt.Rows[i][0].ToString()));
    ////                        }
    ////                    }
    ////                    else
    ////                    {
    ////                        dt.Rows[i].Delete();
    ////                    }
    ////                }
    ////                dt.AcceptChanges();
    ////                for (int i = 0; i < dt.Rows.Count; i++)
    ////                {
    ////                    if (i != dt.Rows.Count - 1)
    ////                    {
    ////                        sumCost += Convert.ToDecimal(dt.Rows[i][0].ToString()) * Convert.ToDecimal(dt.Rows[i][1].ToString());
    ////                        sumStock += Convert.ToDecimal(dt.Rows[i][0].ToString());
    ////                    }
    ////                    else
    ////                    {
    ////                        sumCost += leftover * Convert.ToDecimal(dt.Rows[i][1].ToString());
    ////                        sumStock += leftover;
    ////                    }
    ////                }
    ////                Label2.Text = dt.Rows.Count.ToString();
    ////                if (sumStock != 0)
    ////                {
    ////                    Label3.Text = Math.Round((sumCost / sumStock), 4).ToString();
    ////                }
    ////                else
    ////                {
    ////                    Label3.Text = "0".ToString();
    ////                }
    ////            }
    ////            else
    ////            {
    ////                Label2.Text = "No PO for this item";
    ////                Label3.Text = "";
    ////            }
    ////        }
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        lblErrorMessage.Text = ex.ToString();
    ////    }
    ////}
    protected void btnAddCondCalc_Click(object sender, EventArgs e)
    {
        UserControl uc = (UserControl)LoadControl("~/employee_section/user_control/ConductorCalculatorInput.ascx");
        uc.ID = "condCalc";
        Panel1.Controls.Add(uc);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //double d = 0;
        //if (condCalc.ddlRawMatValue == "00" || condCalc.txtCondCoreNumberText == "" || condCalc.txtCondCostText == ""
        //    || condCalc.txtCondLengthText == "" || condCalc.txtCondODText == "" || condCalc.txtCondStrandNumberText == ""
        //    || !double.TryParse(condCalc.txtCondCoreNumberText, out d) || !double.TryParse(condCalc.txtCondCostText, out d)
        //    || !double.TryParse(condCalc.txtCondLengthText, out d) || !double.TryParse(condCalc.txtCondODText, out d)
        //    || !double.TryParse(condCalc.txtCondStrandNumberText, out d))
        //{
        //    lblErrorMessage.Text = "請確認資料正確性";
        //}
        //else
        //{
        //    DataRow row = conductorListTable.NewRow();
        //    row["ddlRawMat"] = condCalc.ddlRawMatText;
        //    row["txtCondCost"] = condCalc.txtCondCostText;
        //    row["txtCondOD"] = condCalc.txtCondODText;
        //    row["txtCondStrandNumber"] = condCalc.txtCondStrandNumberText;
        //    row["txtCondLength"] = condCalc.txtCondLengthText;
        //    row["lblCondWeight"] = condCalc.lblCondWeightText;
        //    row["lblCondCostPerMeter"] = condCalc.lblCondCostPerMeterText;
        //    row["txtCondCoreNumber"] = condCalc.txtCondCoreNumberText;
        //    row["lblCondTotalCostPerMeter"] = condCalc.lblCondTotalCostPerMeterText;
        //    row["lblCondTotalCost"] = condCalc.lblCondTotalCostText;
        //    conductorListTable.Rows.Add(row);
        //    grdConductorList.DataSource = conductorListTable;
        //    grdConductorList.DataBind();
        //    ViewState["conductorListTable"] = conductorListTable;
        //}
    }
    protected void grdConductorList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        conductorListTable = (DataTable)ViewState["conductorListTable"];
        conductorListTable.Rows[e.RowIndex].Delete();
        conductorListTable.AcceptChanges();
        grdConductorList.DataSource = conductorListTable;
        grdConductorList.DataBind();
        ViewState["conductorListTable"] = conductorListTable;
    }
}