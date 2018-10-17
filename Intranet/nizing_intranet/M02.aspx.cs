using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System.Globalization;

public partial class nizing_intranet_M02 : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 0; i > (2011 - Convert.ToInt16(DateTime.Today.Year)); i--)
            {
                ddlYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
            }
            ddlYear.SelectedValue = DateTime.Today.Year.ToString();
            ddlMonth.SelectedValue = DateTime.Today.Month.ToString("D2");
        }
    }
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
    protected void R2_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoDDL.Checked)
        {
            txtStart.Enabled = false;
            txtEnd.Enabled = false;
            ddlYear.Enabled = true;
            ddlMonth.Enabled = true;
            rdoYear.Enabled = true;
            rdoMonth.Enabled = true;
        }
        else
        {
            txtStart.Enabled = true;
            txtEnd.Enabled = true;
            ddlYear.Enabled = false;
            ddlMonth.Enabled = false;
            rdoYear.Enabled = false;
            rdoMonth.Enabled = false;
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT TF.TF011 '生產線別'"
                +" ,MV.MV002 '生產人員'"
                +" ,TF.TF003 '單據日期'"
                +" ,TG.TG004 '品號'"
                +" ,TG.TG005 '品名'"
                +" ,TG.TG006 '規格'"
                +" ,TG.TG011 '入庫數量'"
                +" ,TG.TG007 '單位'"
                +" ,TG.TG010 '庫別'"
                +" ,MC.MC002 '庫別名稱'"
                +" ,TG.TG014+'-'+TG.TG015 '製令單號'"
                +" FROM MOCTF TF"
                +" LEFT JOIN CMSMV MV ON TF.TF200=MV.MV001"
                +" LEFT JOIN MOCTG TG ON TF.TF001=TG.TG001 AND TF.TF002=TG.TG002"
                +" LEFT JOIN CMSMC MC ON TG.TG010=MC.MC001";
            string condition = " WHERE TF.TF003>=@STARTDATE"
                        + " AND TF.TF003<=@ENDDATE";
            string order = " ORDER BY TF.TF011,TF.TF200,TF.TF003,TF.TF001,TF.TF002,TG.TG003";
            if (ddlPersonnel.SelectedValue.ToString() != "全部人員")
            {
                condition += " AND TF.TF200=@ID";
            }
            query += condition + order;

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", ddlPersonnel.SelectedValue.ToString());
            if (rdoDDL.Checked)
            {
                if (rdoYear.Checked)
                {
                    cmd.Parameters.AddWithValue("@STARTDATE", ddlYear.SelectedValue.ToString() + "0101");
                    cmd.Parameters.AddWithValue("@ENDDATE", ddlYear.SelectedValue.ToString() + "1231");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@STARTDATE", ddlYear.SelectedValue.ToString() + ddlMonth.SelectedValue.ToString() + "01");
                    cmd.Parameters.AddWithValue("@ENDDATE", ddlYear.SelectedValue.ToString() + ddlMonth.SelectedValue.ToString() + "31");
                }
            }
            else
            {
                cmd.Parameters.AddWithValue("@STARTDATE", txtStart.Text);
                cmd.Parameters.AddWithValue("@ENDDATE", txtEnd.Text);
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataView dv = dt.DefaultView;
                if (this.ViewState["SortExpression"] != null)
                {
                    dv.Sort = string.Format("{0} {1}", ViewState["SortExpression"].ToString(), this.ViewState["SortOrder"].ToString());
                }
            }
            grdReport.DataSource = dt;
            grdReport.DataBind();
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

    }
    protected void grdReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Sort"))
        {
            if (ViewState["SortExpression"] != null)
            {
                if (this.ViewState["SortExpression"].ToString() == e.CommandArgument.ToString())
                {
                    if (ViewState["SortOrder"].ToString() == "ASC")
                    {
                        ViewState["SortOrder"] = "DESC";
                    }
                    else
                    {
                        ViewState["SortOrder"] = "ASC";
                    }
                }
                else
                {
                    ViewState["SortOrder"] = "ASC";
                    ViewState["SortExpression"] = e.CommandArgument.ToString();
                }
            }
            else
            {
                ViewState["SortExpression"] = e.CommandArgument.ToString();
                ViewState["SortOrder"] = "ASC";
            }
        }
        btnReport_Click(sender, e);
    }
    protected void grdReport_DataBound(object sender, EventArgs e)
    {        
        GridViewAddFooter_sum(grdReport);
    }
    internal void GridViewAddFooter_sum(GridView _gd)
    {
        decimal sum = 0;
        decimal result;
        if (_gd.Rows.Count > 0)
        {            
            for (int i = 6; i <= 6; i++)
            {
                sum = 0;
                for (int j = 0; j < _gd.Rows.Count; j++)
                {
                    if (decimal.TryParse(((Label)_gd.Rows[j].Cells[i].FindControl("lblAmount")).Text, out result))
                    {
                        sum += result;
                    }
                }
                _gd.FooterRow.Cells[i].Text = sum.ToString();                
            }
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
    protected void grdReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            GridviewAddFooter("小計", e);
        }
    }
}