using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class nizing_intranet_HR07 : System.Web.UI.Page
{
    string NZConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 2016; i < DateTime.Today.Year; i++)
            {
                ddlYear.Items.Add(i.ToString());
                ddlYear.SelectedIndex = ddlYear.Items.Count - 1;
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string order = "";
        if (rdoOrderByID.Checked)
        {
            order = "A.ASSESSED_ID";
        }
        else
        {
            order = "(A.ASSESSMENT_BONUS+A.UNUSEDDAYOFF_BONUS+A.ATTENDANCE_BONUS+A.RNP_BONUS+A.OTHER_BONUS-A.OTHER_DEDUCTION) DESC";
        }

        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "SELECT A.[ASSESS_YEAR] [年度],A.ASSESSED_ID [員工編號],MV.MV002 [員工姓名]"
                        + " ,A.ASSESSMENT_BONUS [年度考績],A.ASSESSMENT_MEMO [年度考績備註]"
                        + " ,A.UNUSEDDAYOFF_BONUS [休假未休],A.UNUSEDDAYOFF_MEMO [休假未休備註]"
                        + " ,A.ATTENDANCE_BONUS [年度全勤],A.ATTENDANCE_MEMO [年度全勤備註]"
                        + " ,A.RNP_BONUS [年度獎懲],A.RNP_MEMO [年度獎懲備註]"
                        + " ,A.OTHER_BONUS [其他加項],A.OTHER_BONUS_MEMO [其他加項備註]"
                        + " ,A.OTHER_DEDUCTION [其他減項],A.OTHER_DEDUCTION_MEMO [其他減項備註]"
                        + " ,(A.ASSESSMENT_BONUS+A.UNUSEDDAYOFF_BONUS+A.ATTENDANCE_BONUS+A.RNP_BONUS+A.OTHER_BONUS-A.OTHER_DEDUCTION) [總金額]"
                        + " FROM HR360_ASSESSMENTBONUS_BONUS_A A"
                        + " LEFT JOIN NZ.dbo.CMSMV MV ON A.ASSESSED_ID=MV.MV001"
                        + " WHERE A.[ASSESS_YEAR]=@YEAR"
                        + " ORDER BY " + order;
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@YEAR", ddlYear.SelectedItem.ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvBonusResult.DataSource = ds;
            gvBonusResult.DataBind();
        }
    }

    protected void gvBonusResult_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            GridviewAddFooter("小計", e);
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


    internal void GridViewAddFooter_sum(GridView _gd)
    {
        int sum = 0;
        if (_gd.Rows.Count > 0)
        {
            for (int i = 15; i < 16; i++)
            {
                sum = 0;
                for (int j = 0; j < _gd.Rows.Count; j++)
                {
                    sum += int.Parse(((Label)_gd.Rows[j].Cells[i].FindControl("lbl" + (i + 1).ToString())).Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                }
                _gd.FooterRow.Cells[i].Text = sum.ToString("N0");
            }
        }
    }
    protected void gvBonusResult_DataBound(object sender, EventArgs e)
    {
        GridViewAddFooter_sum(gvBonusResult);
    }
}