using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class nizing_intranet_HR09 : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtDept = new DataTable();
            DataTable dtEmployee = new DataTable();
            int rowCount = 0;
            int colCount = 4;

            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                string query = ";WITH DEPT"
                            + " AS"
                            + " ("
                            + " SELECT DISTINCT ME.ME001 'DEPT_ID',ME.ME002 'DEPT_NAME'"
                            + " FROM CMSME ME"
                            + " LEFT JOIN CMSMV MV ON ME.ME001=MV.MV004"
                            + " WHERE (MV.MV022>GETDATE() OR MV.MV022='')"
                            + " )"
                            + " SELECT CASE"
                            + " WHEN DEPT_ID LIKE 'B%' AND DEPT_ID='B-PC' THEN '1-1'"
                            + " WHEN DEPT_ID LIKE 'B%' AND DEPT_ID='B-QC' THEN '1-2'"
                            + " WHEN DEPT_ID LIKE 'B%' AND DEPT_ID='B-IC' THEN '1-3'"
                            + " WHEN DEPT_ID LIKE 'B%' THEN '1-4'"
                            + " WHEN DEPT_ID LIKE 'A%' AND DEPT_ID='A-ADM' THEN '2-1'"
                            + " WHEN DEPT_ID LIKE 'A%' AND DEPT_ID='A-SD' THEN '2-2'"
                            + " WHEN DEPT_ID LIKE 'A%' AND DEPT_ID='A-ED' THEN '2-3'"
                            + " WHEN DEPT_ID LIKE 'A%' THEN '2-4'"
                            + " ELSE '3'"
                            + " END AS 'SORT_ORDER'"
                            + " ,DEPT_ID,DEPT_NAME"
                            + " FROM DEPT"
                            + " ORDER BY SORT_ORDER, DEPT_ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtDept);
            }
            for (int x = 1; x <= 2; x++)
            {
                DataRow[] filteredResult = dtDept.Select("SORT_ORDER LIKE '" + x.ToString() + "%'");
                if (filteredResult.Count() % 4 == 0)
                {
                    rowCount = filteredResult.Count() / 4;
                }
                else
                {
                    rowCount = (filteredResult.Count() / 4) + 1;
                }
                for (int i = 0; i < rowCount; i++)
                {
                    HtmlGenericControl divRow = new HtmlGenericControl("div");
                    divRow.ID = "row" + i;
                    divRow.Attributes.Add("class", "row");
                    if (x == 1)
                    {                        
                        divReport_Section_Manufacture.Controls.Add(divRow);
                    }
                    else
                    {
                        divReport_Section_Office.Controls.Add(divRow);
                    }
                    for (int j = 0; j < colCount && i * 4 + j < filteredResult.Count(); j++)
                    {
                        int currentDeptNumber = i * 4 + j;
                        using (SqlConnection conn = new SqlConnection(NZconnectionString))
                        {
                            dtEmployee = new DataTable();
                            conn.Open();
                            string query = "SELECT LTRIM(RTRIM(MV.MV001)) 'ID', LTRIM(RTRIM(MV.MV002)) 'NAME'"
                                        + " FROM CMSMV MV"
                                        + " WHERE (MV.MV022>GETDATE() OR MV.MV022='')"
                                        + " AND MV.MV001<>'0000'"
                                        + " AND MV.MV001<>'0098'"
                                        + " AND MV.MV004=@DEPT"
                                        + " ORDER BY MV.MV001";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@DEPT", filteredResult[currentDeptNumber]["DEPT_ID"].ToString());
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dtEmployee);
                        }
                        HtmlGenericControl divCol = new HtmlGenericControl("div");
                        divCol.ID = divRow.ID + "col" + j;
                        divCol.Attributes.Add("class", "col-sm-3");
                        divRow.Controls.Add(divCol);
                        HtmlTable tb = new HtmlTable();
                        tb.ID = "tb" + divCol.ID;
                        tb.Attributes.Add("class", "table table-striped table-bordered col-xs-12");
                        divCol.Controls.Add(tb);
                        HtmlTableRow headerRow = new HtmlTableRow();
                        HtmlTableCell headerCell = new HtmlTableCell("th");
                        headerCell.InnerText = filteredResult[currentDeptNumber]["DEPT_NAME"].ToString().Trim() + ":" + dtEmployee.Rows.Count.ToString() + "人";
                        headerCell.ColSpan = 2;
                        headerCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
                        headerRow.Controls.Add(headerCell);
                        tb.Controls.Add(headerRow);
                        for (int k = 0; k < dtEmployee.Rows.Count; k++)
                        {
                            HtmlTableRow bodyRow = new HtmlTableRow();
                            HtmlTableCell bodyCell = new HtmlTableCell();
                            bodyCell.InnerText = dtEmployee.Rows[k]["ID"].ToString();
                            bodyCell.Attributes.Add("style", "text-align:center;");
                            bodyRow.Controls.Add(bodyCell); ;
                            bodyCell = new HtmlTableCell();
                            bodyCell.InnerText = dtEmployee.Rows[k]["NAME"].ToString();
                            bodyCell.Attributes.Add("style", "text-align:center;");
                            bodyRow.Controls.Add(bodyCell);
                            tb.Controls.Add(bodyRow);
                        }
                    }
                }
            }
        }
    }
    //protected void btnReport_Click(object sender, EventArgs e)
    //{
    //    DataTable dtDept = new DataTable();         //saves department data
    //    DataTable dtDayOffInfo = new DataTable();   //saves dayoff data for each department
    //    int rowCount = 0;                           //row count for the final display
    //    int colCount = 4;                           //col count for the final display
    //    using (SqlConnection conn = new SqlConnection(NZconnectionString))
    //    {
    //        conn.Open();
    //        string query = "SELECT DISTINCT ME.ME001 'DEPT_ID',ME.ME002 'DEPT_NAME'"
    //                    + " FROM CMSME ME"
    //                    + " LEFT JOIN CMSMV MV ON ME.ME001=MV.MV004"
    //                    + " WHERE SUBSTRING(MV.MV021,1,6)<=@YRMN"
    //                    + " AND"
    //                    + " ("
    //                    + " SUBSTRING(MV.MV022,1,6)>=@YRMN"
    //                    + " OR"
    //                    + " MV.MV022=''"
    //                    + " )"
    //                    + " ORDER BY ME.ME001";
    //        SqlCommand cmd = new SqlCommand(query, conn);
    //        cmd.Parameters.AddWithValue("@YRMN", ddlYear.SelectedValue + ddlMonth.SelectedValue);
    //        SqlDataAdapter da = new SqlDataAdapter(cmd);
    //        da.Fill(dtDept);
    //    }
        
    //    if (dtDept.Rows.Count % 4 == 0)
    //    {
    //        rowCount = dtDept.Rows.Count / 4;
    //    }
    //    else
    //    {
    //        rowCount = (dtDept.Rows.Count / 4) + 1;
    //    }

    //    //create table
    //    for (int i = 0; i < rowCount; i++)
    //    {
    //        HtmlGenericControl divRow = new HtmlGenericControl("div");
    //        divRow.ID = "row" + i;
    //        divRow.Attributes.Add("class", "row");
    //        divReport_Section.Controls.Add(divRow);
    //        for (int j = 0; j < colCount && i * 4 + j < dtDept.Rows.Count; j++)
    //        {
    //            int currentDeptNumber = i * 4 + j;
    //            using (SqlConnection conn = new SqlConnection(NZconnectionString))
    //            {
    //                dtDayOffInfo = new DataTable();
    //                conn.Open();
    //                string query = "SELECT"
    //                            + " PALTF.TF002 'DAYOFF_DATE'"
    //                            + " ,PALTF.TF007 'TIME_ELAPSED'"
    //                            + " ,CMSMV.MV002 'EMPLOYEE_NAME'"
    //                            + " FROM PALTF"
    //                            + " LEFT JOIN CMSMV ON PALTF.TF001=CMSMV.MV001"
    //                            + " LEFT JOIN PALMC ON PALTF.TF004=PALMC.MC001"
    //                            + " LEFT JOIN CMSME ON CMSMV.MV004=CMSME.ME001"
    //                            + " WHERE SUBSTRING(PALTF.TF002,1,4)=@YEAR"
    //                            + " AND SUBSTRING(PALTF.TF002,5,2)=@MONTH"
    //                            + " AND CMSMV.MV004=@DEPT"
    //                            + " ORDER BY PALTF.TF002,PALTF.TF001";
    //                SqlCommand cmd = new SqlCommand(query, conn);
    //                cmd.Parameters.AddWithValue("@YEAR", ddlYear.SelectedValue);
    //                cmd.Parameters.AddWithValue("@MONTH", ddlMonth.SelectedValue);
    //                cmd.Parameters.AddWithValue("@DEPT", dtDept.Rows[currentDeptNumber]["DEPT_ID"].ToString());
    //                SqlDataAdapter da = new SqlDataAdapter(cmd);
    //                da.Fill(dtDayOffInfo);
    //            }
    //            HtmlGenericControl divCol = new HtmlGenericControl("div");
    //            divCol.ID = divRow.ID + "col" + j;
    //            divCol.Attributes.Add("class", "col-sm-3");
    //            divRow.Controls.Add(divCol);
    //            HtmlTable tb = new HtmlTable();
    //            tb.ID = "tb" + divCol.ID;
    //            tb.Attributes.Add("class", "table table-striped table-bordered col-xs-12");
    //            divCol.Controls.Add(tb);
    //            HtmlTableRow headerRow = new HtmlTableRow();
    //            HtmlTableCell headerCell = new HtmlTableCell("th");
    //            headerCell.InnerText = dtDept.Rows[currentDeptNumber]["DEPT_NAME"].ToString().Trim();
    //            headerCell.ColSpan = 3;
    //            headerCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
    //            headerRow.Controls.Add(headerCell);
    //            tb.Controls.Add(headerRow);
    //            for (int k = 0; k < dtDayOffInfo.Rows.Count; k++)
    //            {
    //                HtmlTableRow bodyRow = new HtmlTableRow();
    //                HtmlTableCell bodyCell = new HtmlTableCell();
    //                bodyCell.InnerText = dtDayOffInfo.Rows[k]["DAYOFF_DATE"].ToString().Substring(4, 2) + "/" + dtDayOffInfo.Rows[k]["DAYOFF_DATE"].ToString().Substring(6, 2);
    //                bodyCell.Attributes.Add("style", "text-align:center;");
    //                bodyRow.Controls.Add(bodyCell);
    //                bodyCell = new HtmlTableCell();
    //                bodyCell.InnerText = (Convert.ToDecimal(dtDayOffInfo.Rows[k]["TIME_ELAPSED"].ToString().Substring(0, 2)) + (Convert.ToDecimal(dtDayOffInfo.Rows[k]["TIME_ELAPSED"].ToString().Substring(2, 2)) / 60)).ToString() + "hr";
    //                bodyCell.Attributes.Add("style", "text-align:center;");
    //                bodyRow.Controls.Add(bodyCell);
    //                bodyCell = new HtmlTableCell();
    //                bodyCell.InnerText = dtDayOffInfo.Rows[k]["EMPLOYEE_NAME"].ToString();
    //                bodyCell.Attributes.Add("style", "text-align:center;");
    //                bodyRow.Controls.Add(bodyCell);
    //                if (dtDayOffInfo.Rows[k]["DAYOFF_DATE"].ToString() == DateTime.Today.ToString("yyyyMMdd"))
    //                {
    //                    bodyRow.Style.Add("color", "red");
    //                }
    //                tb.Controls.Add(bodyRow);
    //            }
    //        }
    //    }
    //}
}