using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class nizing_intranet_QC01 : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = -4; i < 1; i++)
            {
                ddlYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
            }
            ddlYear.SelectedValue = DateTime.Today.Year.ToString();
            ddlMonth.SelectedValue = DateTime.Today.Month.ToString("D2");
            ViewState["username"] = HttpContext.Current.User.Identity.Name;
        }
    }
    //protected void LoadData()
    //{
    //    DataTable dt = new DataTable();
    //    using (SqlConnection conn = new SqlConnection(NZconnectionString))
    //    {
    //        conn.Open();
    //        string query = "WITH CTE_RETURN(SALES, NUMBER)"
    //                + " AS"
    //                + " ("
    //                + " SELECT COPTI.TI006, COUNT(*)"
    //                + " FROM COPTI"
    //                + " WHERE COPTI.TI034 BETWEEN @StartDate AND @EndDate"
    //                + " GROUP BY COPTI.TI006"
    //                + " )"
    //                + " SELECT ROW_NUMBER() OVER (ORDER BY COALESCE(SUM(TI.TI037),0) DESC) 排名, MV.MV002 業務名稱, TI.TI006 業務代號, CONVERT(DECIMAL(20,2),SUM(TJ.TJ033)) 退貨金額, CTE_RETURN.NUMBER 退貨單數, COUNT(*) 退貨件數"
    //                + " FROM COPTI TI"
    //                + " LEFT JOIN COPTJ TJ ON TI.TI001 = TJ.TJ001 AND TI.TI002 = TJ.TJ002"
    //                + " LEFT JOIN CMSMV MV ON TI.TI006 = MV.MV001"
    //                + " LEFT JOIN CTE_RETURN ON TI.TI006 = CTE_RETURN.SALES"
    //                + " WHERE TI.TI034 BETWEEN @StartDate AND @EndDate"
    //                + " GROUP BY MV.MV002, TI.TI006, CTE_RETURN.NUMBER";
    //        SqlCommand cmdSelect = new SqlCommand(query, conn);
    //        //cmdSelect.Parameters.AddWithValue("@StartDate", startYear + startMonth);
    //        //cmdSelect.Parameters.AddWithValue("@EndDate", endYear + endMonth);
    //        cmdSelect.Parameters.AddWithValue("@StartDate", Request.QueryString["StartDate"]);
    //        cmdSelect.Parameters.AddWithValue("@EndDate", Request.QueryString["EndDate"]);
    //        SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
    //        //dt = new DataTable();
    //        da.Fill(dt);
    //        grdReport2.DataSource = dt;
    //        grdReport2.DataBind();
    //        //Chart2.DataSource = dt;
    //        ////Chart2.Titles.Add("退貨金額報告" + startYear + startMonth + " ~ " + endYear + endMonth);
    //        //Chart2.Series[0].ChartType = SeriesChartType.Column;
    //        //Chart2.Series[0].XValueMember = "業務名稱";
    //        //Chart2.Series[0].YValueMembers = "退貨金額";
    //        //Chart2.DataBind();
    //        query = "SELECT ROW_NUMBER() OVER (ORDER BY COPTI.TI034) RN"
    //                + " , (COPTJ.TJ001+N'-'+COPTJ.TJ002+N'-'+COPTJ.TJ003) ID"
    //                + " , COPTI.TI034"
    //                + " , COPTI.TI004"
    //                + " , COPMA.MA002"
    //                + " , CMSMV.MV002"
    //                + " , COPTJ.TJ004"
    //                + " , COPTJ.TJ005"
    //                + " , COPTJ.TJ007"
    //                + " , COPTJ.TJ008"
    //                + " , COPTI.TI008"
    //                + " , CONVERT(DECIMAL(20,4), COPTJ.TJ011) TJ011"
    //                + " , CONVERT(DECIMAL(20,2), COPTJ.TJ033) TJ033"
    //                + " , COPTI.TI020"
    //                + " FROM COPTI"
    //                + " 	LEFT JOIN COPMA ON COPTI.TI004=COPMA.MA001"
    //                + " 	LEFT JOIN CMSMV ON COPTI.TI006=CMSMV.MV001"
    //                + " 	LEFT JOIN COPTJ ON COPTI.TI001=COPTJ.TJ001 AND COPTI.TI002=COPTJ.TJ002"
    //                + " WHERE COPTI.TI034 BETWEEN @StartDate AND @EndDate"
    //                + " ORDER BY COPTI.TI034";
    //        cmdSelect = new SqlCommand(query, conn);
    //        //cmdSelect.Parameters.AddWithValue("@StartDate", startYear + startMonth);
    //        //cmdSelect.Parameters.AddWithValue("@EndDate", endYear + endMonth);
    //        cmdSelect.Parameters.AddWithValue("@StartDate", Request.QueryString["StartDate"]);
    //        cmdSelect.Parameters.AddWithValue("@EndDate", Request.QueryString["EndDate"]);
    //        da = new SqlDataAdapter(cmdSelect);
    //        dt = new DataTable();
    //        da.Fill(dt);
    //        grdReport1.DataSource = dt;
    //        grdReport1.DataBind();
    //    }

    //}
    protected void R1_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoYear.Checked == true)
        {
            ddlMonth.Enabled = false;
            ddlMonth.Visible = false;
        }
        else
        {
            ddlMonth.Enabled = true;
            ddlMonth.Visible = true;
        }
    }
    internal void GridviewAddFooter(string _strFooterName, GridViewRowEventArgs _gd)
    {
        int col = _gd.Row.Cells.Count;
        TableCellCollection tc = _gd.Row.Cells;
        tc.Clear();
        TableCell tc1;

        for (int i = 0; i < col; i++)
        {
            if (i == 0)
            {
                tc1 = new TableCell();
                tc1.Text = _strFooterName;
                tc.Add(tc1);
            }
            else
            {
                tc.Add(new TableCell());
            }
        }
    }
    protected void grdReport2_DataBound(object sender, EventArgs e)
    {
        GridViewAddFooter2_sum(grdReport2);
    }
    protected void grdReport2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            GridviewAddFooter("小計", e);
        }
    }
    internal void GridViewAddFooter2_sum(GridView _gd)
    {
        int sum = 0;
        if (_gd.Rows.Count > 0)
        {
            for (int i = 3; i < _gd.Rows[0].Cells.Count; i++)
            {
                sum = 0;
                for (int j = 0; j < _gd.Rows.Count; j++)
                {
                    sum += int.Parse(((Label)_gd.Rows[j].Cells[i].FindControl("Label" + (i + 3).ToString())).Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                }
                if (i == 3)
                {
                    _gd.FooterRow.Cells[i].Text = sum.ToString("C", new CultureInfo("zh-TW"));
                }
                else
                {
                    _gd.FooterRow.Cells[i].Text = sum.ToString("N0");
                }
            }
        }
    }

    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            lblErrorMessage.Text = "";
            string startYear = "";
            string startMonth = "";
            string endYear = "";
            string endMonth = "";
            if (rdoYear.Checked)
            {
                startYear = Convert.ToString(Convert.ToInt16(ddlYear.SelectedValue) - 1);
                startMonth = "1226";
                endYear = ddlYear.SelectedValue;
                endMonth = "1225";
            }
            else
            {
                if (ddlMonth.SelectedValue == "01")
                {
                    startYear = Convert.ToString(Convert.ToInt16(ddlYear.SelectedValue) - 1);
                    startMonth = "1226";
                }
                else
                {
                    startYear = ddlYear.SelectedValue;
                    startMonth = (Convert.ToInt16(ddlMonth.SelectedValue) - 1).ToString().PadLeft(2, '0') + "26";
                }
                endYear = ddlYear.SelectedValue;
                endMonth = ddlMonth.SelectedValue + "25";
            }
            lblScope.Text = startYear + startMonth + "~" + endYear + endMonth;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                string query = "WITH CTE_RETURN(SALES, NUMBER)"
                        + " AS"
                        + " ("
                        + " SELECT COPTI.TI006, COUNT(*)"
                        + " FROM COPTI"
                        + " WHERE COPTI.TI034 BETWEEN @StartDate AND @EndDate"
                        + " GROUP BY COPTI.TI006"
                        + " )"
                        + " SELECT ROW_NUMBER() OVER (ORDER BY COALESCE(SUM(TI.TI037),0) DESC) 排名, MV.MV002 業務名稱, TI.TI006 業務代號, CONVERT(DECIMAL(20,2),SUM(TJ.TJ033)) 退貨金額, CTE_RETURN.NUMBER 退貨單數, COUNT(*) 退貨件數"
                        + " FROM COPTI TI"
                        + " LEFT JOIN COPTJ TJ ON TI.TI001 = TJ.TJ001 AND TI.TI002 = TJ.TJ002"
                        + " LEFT JOIN CMSMV MV ON TI.TI006 = MV.MV001"
                        + " LEFT JOIN CTE_RETURN ON TI.TI006 = CTE_RETURN.SALES"
                        + " WHERE TI.TI034 BETWEEN @StartDate AND @EndDate"
                        + " GROUP BY MV.MV002, TI.TI006, CTE_RETURN.NUMBER";
                SqlCommand cmdSelect = new SqlCommand(query, conn);
                cmdSelect.Parameters.AddWithValue("@StartDate", startYear + startMonth);
                cmdSelect.Parameters.AddWithValue("@EndDate", endYear + endMonth);
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                //dt = new DataTable();
                da.Fill(dt);
                grdReport2.DataSource = dt;
                grdReport2.DataBind();
                Chart2.DataSource = dt;
                Chart2.Titles.Add("退貨金額報告" + startYear + startMonth + " ~ " + endYear + endMonth);
                Chart2.Series[0].ChartType = SeriesChartType.Column;
                Chart2.Series[0].XValueMember = "業務名稱";
                Chart2.Series[0].YValueMembers = "退貨金額";
                Chart2.DataBind();
                query = "SELECT ROW_NUMBER() OVER (ORDER BY COPTI.TI034) RN"
                        + " , (COPTJ.TJ001+N'-'+COPTJ.TJ002+N'-'+COPTJ.TJ003) ID"
                        + " , COPTI.TI034"
                        + " , COPTI.TI004"
                        + " , COPMA.MA002"
                        + " , CMSMV.MV002"
                        + " , COPTJ.TJ004"
                        + " , COPTJ.TJ005"
                        + " , COPTJ.TJ007"
                        + " , COPTJ.TJ008"
                        + " , COPTI.TI008"
                        + " , CONVERT(DECIMAL(20,4), COPTJ.TJ011) TJ011"
                        + " , CONVERT(DECIMAL(20,2), COPTJ.TJ033) TJ033"
                        + " , COPTI.TI020"
                        + " FROM COPTI"
                        + " 	LEFT JOIN COPMA ON COPTI.TI004=COPMA.MA001"
                        + " 	LEFT JOIN CMSMV ON COPTI.TI006=CMSMV.MV001"
                        + " 	LEFT JOIN COPTJ ON COPTI.TI001=COPTJ.TJ001 AND COPTI.TI002=COPTJ.TJ002"
                        + " WHERE COPTI.TI034 BETWEEN @StartDate AND @EndDate"
                        + " ORDER BY COPTI.TI034";
                cmdSelect = new SqlCommand(query, conn);
                cmdSelect.Parameters.AddWithValue("@StartDate", startYear + startMonth);
                cmdSelect.Parameters.AddWithValue("@EndDate", endYear + endMonth);
                da = new SqlDataAdapter(cmdSelect);
                dt = new DataTable();
                da.Fill(dt);
                grdReport1.DataSource = dt;                
                grdReport1.DataBind();
            }
            using (SqlConnection conn = new SqlConnection(ERP2connectionString))
            {
                conn.Open();
                int i = 0; //counter for foreach
                foreach (DataRow row in dt.Rows)
                {
                    string[] id = ((Label)grdReport1.Rows[i].Cells[1].FindControl("lblId")).Text.Split('-');
                    SqlCommand cmdSelect = new SqlCommand("SELECT PIC,CAUSE,RESPONSIBLE,HANDLE,DESCRIPTION,AMOUNT_GOOD,AMOUNT_REDO,AMOUNT_SCRAP,AMOUNT_OTHER,AMOUNT_LOSS,SIGNOFF"
                                            + " FROM QC_QC01_A"
                                            + " WHERE RETURN_TYPE=@TYPE AND RETURN_ID=@ID AND RETURN_ITEMNUMBER=@ITEMNUMBER", conn);
                    cmdSelect.Parameters.AddWithValue("@TYPE", id[0]);
                    cmdSelect.Parameters.AddWithValue("@ID", id[1]);
                    cmdSelect.Parameters.AddWithValue("@ITEMNUMBER", id[2]);
                    SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                    dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        ((DropDownList)grdReport1.Rows[i].Cells[8].FindControl("ddlPIC")).SelectedValue = dt.Rows[0][0].ToString();
                        ((DropDownList)grdReport1.Rows[i].Cells[9].FindControl("ddlCause")).SelectedValue = dt.Rows[0][1].ToString();
                        ((TextBox)grdReport1.Rows[i].Cells[10].FindControl("txtResponsible")).Text = dt.Rows[0][2].ToString().Trim();
                        ((TextBox)grdReport1.Rows[i].Cells[11].FindControl("txtHandle")).Text = dt.Rows[0][3].ToString().Trim();
                        ((TextBox)grdReport1.Rows[i].Cells[12].FindControl("txtDescription")).Text = dt.Rows[0][4].ToString().Trim();
                        ((TextBox)grdReport1.Rows[i].Cells[16].FindControl("txtAmount_Good")).Text = dt.Rows[0][5].ToString().Trim();
                        ((TextBox)grdReport1.Rows[i].Cells[17].FindControl("txtAmount_Redo")).Text = dt.Rows[0][6].ToString().Trim();
                        ((TextBox)grdReport1.Rows[i].Cells[18].FindControl("txtAmount_Scrap")).Text = dt.Rows[0][7].ToString().Trim();
                        ((TextBox)grdReport1.Rows[i].Cells[19].FindControl("txtAmount_Other")).Text = dt.Rows[0][8].ToString().Trim();
                        ((TextBox)grdReport1.Rows[i].Cells[20].FindControl("txtAmount_Loss")).Text = dt.Rows[0][9].ToString().Trim();
                        ((TextBox)grdReport1.Rows[i].Cells[21].FindControl("txtSignOff")).Text = dt.Rows[0][10].ToString().Trim();
                    }
                    else
                    {
                        ((TextBox)grdReport1.Rows[i].Cells[12].FindControl("txtDescription")).Text = row[13].ToString();
                    }
                    i++;
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (grdReport1.Rows.Count != 0)
            {
                string[] user = ViewState["username"].ToString().Split('\\');
                double doubleVerify = 0;
                int i = 1; //row index counter

                using (SqlConnection conn = new SqlConnection(ERP2connectionString))
                {
                    conn.Open();
                    foreach (GridViewRow row in grdReport1.Rows)
                    {
                        if (((TextBox)row.Cells[16].FindControl("txtAmount_Good")).Text.Trim() != "" && !double.TryParse(((TextBox)row.Cells[16].FindControl("txtAmount_Good")).Text.Trim(), out doubleVerify))
                        {
                            lblErrorMessage.Text = "請檢查第" + i + "排\"" + ((TextBox)row.Cells[16].FindControl("txtAmount_Good")).Text.Trim() + "\"非正確良品金額格式";
                            break;
                        }
                        else if (((TextBox)row.Cells[17].FindControl("txtAmount_Redo")).Text.Trim() != "" && !double.TryParse(((TextBox)row.Cells[17].FindControl("txtAmount_Redo")).Text.Trim(), out doubleVerify))
                        {
                            lblErrorMessage.Text = "請檢查第" + i + "排\"" + ((TextBox)row.Cells[17].FindControl("txtAmount_Redo")).Text.Trim() + "\"非正確重工金額格式";
                            break;
                        }
                        else if (((TextBox)row.Cells[18].FindControl("txtAmount_Scrap")).Text.Trim() != "" && !double.TryParse(((TextBox)row.Cells[18].FindControl("txtAmount_Scrap")).Text.Trim(), out doubleVerify))
                        {
                            lblErrorMessage.Text = "請檢查第" + i + "排\"" + ((TextBox)row.Cells[18].FindControl("txtAmount_Scrap")).Text.Trim() + "\"非正確報廢金額格式";
                            break;
                        }
                        else if (((TextBox)row.Cells[19].FindControl("txtAmount_Other")).Text.Trim() != "" && !double.TryParse(((TextBox)row.Cells[19].FindControl("txtAmount_Other")).Text.Trim(), out doubleVerify))
                        {
                            lblErrorMessage.Text = "請檢查第" + i + "排\"" + ((TextBox)row.Cells[19].FindControl("txtAmount_Other")).Text.Trim() + "\"非正確其他金額格式";
                            break;
                        }
                        else
                        {
                            lblErrorMessage.Text = "";
                            string[] id = ((Label)row.Cells[1].FindControl("lblId")).Text.Split('-');
                            SqlCommand cmdSelect = new SqlCommand("SELECT RETURN_TYPE, RETURN_ID"
                                                                + " FROM QC_QC01_A"
                                                                + " WHERE RETURN_TYPE=@TYPE AND RETURN_ID=@ID AND RETURN_ITEMNUMBER=@ITEMNUMBER", conn);
                            cmdSelect.Parameters.AddWithValue("@TYPE", id[0]);
                            cmdSelect.Parameters.AddWithValue("@ID", id[1]);
                            cmdSelect.Parameters.AddWithValue("@ITEMNUMBER", id[2]);
                            SqlDataReader reader = cmdSelect.ExecuteReader();
                            if (reader.HasRows)
                            {
                                if (!reader.IsClosed)
                                {
                                    reader.Close();
                                }
                                SqlCommand cmdUpdate = new SqlCommand("UPDATE QC_QC01_A"
                                                                    + " SET MODIFIEDDATE=GETDATE(),MODIFIER=@MODIFIER,PIC=@PIC,PIC_NAME=@NAME"
                                                                    + " ,CAUSE=@CAUSE,RESPONSIBLE=@RESPONSIBLE,HANDLE=@HANDLE"
                                                                    + " ,DESCRIPTION=@DESCRIPTION,AMOUNT_GOOD=@GOOD,AMOUNT_REDO=@REDO"
                                                                    + " ,AMOUNT_SCRAP=@SCRAP, AMOUNT_OTHER=@OTHER, AMOUNT_LOSS=@LOSS,SIGNOFF=@SIGNOFF"
                                                                    + " WHERE RETURN_TYPE=@TYPE AND RETURN_ID=@ID AND RETURN_ITEMNUMBER=@ITEMNUMBER", conn);
                                cmdUpdate.Parameters.AddWithValue("@TYPE", id[0]);
                                cmdUpdate.Parameters.AddWithValue("@ID", id[1]);
                                cmdUpdate.Parameters.AddWithValue("@ITEMNUMBER", id[2]);
                                cmdUpdate.Parameters.AddWithValue("@MODIFIER", user[1]);
                                cmdUpdate.Parameters.AddWithValue("@PIC", ((DropDownList)row.Cells[8].FindControl("ddlPIC")).SelectedValue);
                                cmdUpdate.Parameters.AddWithValue("@NAME", ((DropDownList)row.Cells[8].FindControl("ddlPIC")).SelectedItem.Text);
                                cmdUpdate.Parameters.AddWithValue("@CAUSE", ((DropDownList)row.Cells[9].FindControl("ddlCause")).SelectedValue);
                                cmdUpdate.Parameters.AddWithValue("@RESPONSIBLE", ((TextBox)row.Cells[10].FindControl("txtResponsible")).Text.Trim());
                                cmdUpdate.Parameters.AddWithValue("@HANDLE", ((TextBox)row.Cells[11].FindControl("txtHandle")).Text.Trim());
                                cmdUpdate.Parameters.AddWithValue("@DESCRIPTION", ((TextBox)row.Cells[12].FindControl("txtDescription")).Text.Trim());
                                if ((((TextBox)row.Cells[16].FindControl("txtAmount_Good")).Text.Trim()) == "")
                                {
                                    cmdUpdate.Parameters.AddWithValue("@GOOD", 0);
                                }
                                else
                                {
                                    cmdUpdate.Parameters.AddWithValue("@GOOD", Convert.ToDouble(((TextBox)row.Cells[16].FindControl("txtAmount_Good")).Text.Trim()));
                                }
                                if ((((TextBox)row.Cells[17].FindControl("txtAmount_Redo")).Text.Trim()) == "")
                                {
                                    cmdUpdate.Parameters.AddWithValue("@REDO", 0);
                                }
                                else
                                {
                                    cmdUpdate.Parameters.AddWithValue("@REDO", Convert.ToDouble(((TextBox)row.Cells[17].FindControl("txtAmount_Redo")).Text.Trim()));
                                }
                                if ((((TextBox)row.Cells[18].FindControl("txtAmount_Scrap")).Text.Trim()) == "")
                                {
                                    cmdUpdate.Parameters.AddWithValue("@SCRAP", 0);
                                }
                                else
                                {
                                    cmdUpdate.Parameters.AddWithValue("@SCRAP", Convert.ToDouble(((TextBox)row.Cells[18].FindControl("txtAmount_Scrap")).Text.Trim()));
                                }
                                if ((((TextBox)row.Cells[19].FindControl("txtAmount_Other")).Text.Trim()) == "")
                                {
                                    cmdUpdate.Parameters.AddWithValue("@OTHER", 0);
                                }
                                else
                                {
                                    cmdUpdate.Parameters.AddWithValue("@OTHER", Convert.ToDouble(((TextBox)row.Cells[19].FindControl("txtAmount_Other")).Text.Trim()));
                                }
                                cmdUpdate.Parameters.AddWithValue("@LOSS", ((TextBox)row.Cells[20].FindControl("txtAmount_Loss")).Text.Trim());
                                cmdUpdate.Parameters.AddWithValue("@SIGNOFF", ((TextBox)row.Cells[21].FindControl("txtSignOff")).Text.Trim());
                                cmdUpdate.ExecuteNonQuery();
                            }
                            else
                            {
                                if (!reader.IsClosed)
                                {
                                    reader.Close();
                                }
                                SqlCommand cmdInsert = new SqlCommand("INSERT INTO QC_QC01_A (CREATEDATE,CREATOR,RETURN_TYPE,RETURN_ID,RETURN_ITEMNUMBER,PIC,PIC_NAME,CAUSE,RESPONSIBLE,HANDLE,DESCRIPTION,AMOUNT_GOOD,AMOUNT_REDO,AMOUNT_SCRAP,AMOUNT_OTHER,AMOUNT_LOSS,SIGNOFF)"
                                                                    + "VALUES (GETDATE(),@CREATOR,@TYPE,@ID,@ITEMNUMBER,@PIC,@NAME,@CAUSE,@RESPONSIBLE,@HANDLE,@DESCRIPTION,@GOOD,@REDO,@SCRAP,@OTHER,@LOSS,@SIGNOFF)", conn);
                                cmdInsert.Parameters.AddWithValue("@TYPE", id[0]);
                                cmdInsert.Parameters.AddWithValue("@ID", id[1]);
                                cmdInsert.Parameters.AddWithValue("@ITEMNUMBER", id[2]);
                                cmdInsert.Parameters.AddWithValue("@CREATOR", user[1]);
                                cmdInsert.Parameters.AddWithValue("@PIC", ((DropDownList)row.Cells[8].FindControl("ddlPIC")).SelectedValue);
                                cmdInsert.Parameters.AddWithValue("@NAME", ((DropDownList)row.Cells[8].FindControl("ddlPIC")).SelectedItem.Text);
                                cmdInsert.Parameters.AddWithValue("@CAUSE", ((DropDownList)row.Cells[9].FindControl("ddlCause")).SelectedValue);
                                cmdInsert.Parameters.AddWithValue("@RESPONSIBLE", ((TextBox)row.Cells[10].FindControl("txtResponsible")).Text.Trim());
                                cmdInsert.Parameters.AddWithValue("@HANDLE", ((TextBox)row.Cells[11].FindControl("txtHandle")).Text.Trim());
                                cmdInsert.Parameters.AddWithValue("@DESCRIPTION", ((TextBox)row.Cells[12].FindControl("txtDescription")).Text.Trim());
                                if ((((TextBox)row.Cells[16].FindControl("txtAmount_Good")).Text.Trim()) == "")
                                {
                                    cmdInsert.Parameters.AddWithValue("@GOOD", 0);
                                }
                                else
                                {
                                    cmdInsert.Parameters.AddWithValue("@GOOD", Convert.ToDouble(((TextBox)row.Cells[16].FindControl("txtAmount_Good")).Text.Trim()));
                                }
                                if ((((TextBox)row.Cells[17].FindControl("txtAmount_Redo")).Text.Trim()) == "")
                                {
                                    cmdInsert.Parameters.AddWithValue("@REDO", 0);
                                }
                                else
                                {
                                    cmdInsert.Parameters.AddWithValue("@REDO", Convert.ToDouble(((TextBox)row.Cells[17].FindControl("txtAmount_Redo")).Text.Trim()));
                                }
                                if ((((TextBox)row.Cells[18].FindControl("txtAmount_Scrap")).Text.Trim()) == "")
                                {
                                    cmdInsert.Parameters.AddWithValue("@SCRAP", 0);
                                }
                                else
                                {
                                    cmdInsert.Parameters.AddWithValue("@SCRAP", Convert.ToDouble(((TextBox)row.Cells[18].FindControl("txtAmount_Scrap")).Text.Trim()));
                                }
                                if ((((TextBox)row.Cells[19].FindControl("txtAmount_Other")).Text.Trim()) == "")
                                {
                                    cmdInsert.Parameters.AddWithValue("@OTHER", 0);
                                }
                                else
                                {
                                    cmdInsert.Parameters.AddWithValue("@OTHER", Convert.ToDouble(((TextBox)row.Cells[19].FindControl("txtAmount_Other")).Text.Trim()));
                                }
                                cmdInsert.Parameters.AddWithValue("@LOSS", ((TextBox)row.Cells[20].FindControl("txtAmount_Loss")).Text.Trim());
                                cmdInsert.Parameters.AddWithValue("@SIGNOFF", ((TextBox)row.Cells[21].FindControl("txtSignOff")).Text.Trim());
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                        i++;
                    }
                }                
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }

}