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

public partial class nizing_intranet_HR04 : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 0; i > (2012-Convert.ToInt16(DateTime.Today.Year)); i--)
            {
                ddlYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
            }
            ddlYear.SelectedIndex = 0;
            ddlType.SelectedIndex = 0;
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                string query = "SELECT CMSME.ME001 'ID', CMSME.ME002 'NAME'"
                            + " FROM CMSME"
                            + " ORDER BY CMSME.ME001";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddlDept.DataSource = dt;
                ddlDept.DataTextField = "NAME";
                ddlDept.DataValueField = "ID";
                ddlDept.DataBind();
            }
            ddlDept.Items.Insert(0, new ListItem("全部部門", "ALL"));
            ddlDept.SelectedIndex = 0;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string cmdText = "";
        string deptCondition = "";
        if (ddlDept.SelectedValue != "ALL")
        {
            deptCondition = " AND CMSME.ME001=@DEPT";
        }
        if (ddlType.SelectedValue == "底薪")
        {
            
            cmdText = "SELECT *"
                    + " FROM"
                    + " ("
                    + " SELECT PALTI.TI001 ID, CMSMV.MV002 NAME, CMSME.ME002 'DEPT', SUBSTRING(PALTI.TI002,5,2) MN, COALESCE((PALTI.TI023+PALTI.TI024),N'-') SA"
                    + " FROM PALTI"
                    + " LEFT JOIN CMSMV ON PALTI.TI001=CMSMV.MV001"
                    + " LEFT JOIN CMSME ON CMSMV.MV004=CMSME.ME001"
                    + " WHERE SUBSTRING(PALTI.TI002,1,4)=@YEAR"
                    + deptCondition
                    + " )"
                    + " AS SALARY"
                    + " PIVOT"
                    + " ("
                    + " SUM(SA)"
                    + " FOR"
                    + " MN IN ([01], [02], [03], [04], [05], [06], [07], [08], [09], [10], [11], [12]))"
                    + " AS PIVOTTABLE"
                    + " ORDER BY ID";
        }
        else
        {
            cmdText = "SELECT *"
                    + " FROM"
                    + " ("
                    + " SELECT PALTI.TI001 ID, CMSMV.MV002 NAME, CMSME.ME002 'DEPT', SUBSTRING(PALTI.TI002,5,2) MN, COALESCE((PALTI.TI040+PALTI.TI041),N'-') SA"
                    + " FROM PALTI"
                    + " LEFT JOIN CMSMV ON PALTI.TI001=CMSMV.MV001"
                    + " LEFT JOIN CMSME ON CMSMV.MV004=CMSME.ME001"
                    + " WHERE SUBSTRING(PALTI.TI002,1,4)=@YEAR"
                    + deptCondition
                    + " )"
                    + " AS SALARY"
                    + " PIVOT"
                    + " ("
                    + " SUM(SA)"
                    + " FOR"
                    + " MN IN ([01], [02], [03], [04], [05], [06], [07], [08], [09], [10], [11], [12]))"
                    + " AS PIVOTTABLE"
                    + " ORDER BY ID";
        }
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand(cmdText, conn);
            cmdSelect.Parameters.AddWithValue("@YEAR", ddlYear.SelectedValue);
            cmdSelect.Parameters.AddWithValue("@DEPT", ddlDept.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
            DataTable dt = new DataTable();
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
    protected void grdReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            double jan = 0;
            double feb = 0;
            double mar = 0;
            double apr = 0;
            double may = 0;
            double june = 0;
            double july = 0;
            double aug = 0;
            double sep = 0;
            double oct = 0;
            double nov = 0;
            double dec = 0;
            int i = 12;
            if (!double.TryParse(((Label)e.Row.FindControl("lbl3")).Text, out jan))
            {
                jan = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl4")).Text, out feb))
            {
                feb = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl5")).Text, out mar))
            {
                mar = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl6")).Text, out apr))
            {
                apr = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl7")).Text, out may))
            {
                may = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl8")).Text, out june))
            {
                june = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl9")).Text, out july))
            {
                july = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl10")).Text, out aug))
            {
                aug = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl11")).Text, out sep))
            {
                sep = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl12")).Text, out oct))
            {
                oct = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl13")).Text, out nov))
            {
                nov = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl14")).Text, out dec))
            {
                dec = 0;
                i -= 1;
            }

            ((Label)e.Row.FindControl("lbl15")).Text = Math.Round((jan + feb + mar + apr + may + june + july + aug + sep + oct + nov + dec), 2).ToString();
            ((Label)e.Row.FindControl("lbl16")).Text = Math.Round((Convert.ToDouble(((Label)e.Row.FindControl("lbl15")).Text) / i), 2).ToString();
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
    protected void grdReport_DataBound(object sender, EventArgs e)
    {
        GridViewAddFooter_sum(grdReport);
    }
    protected void grdReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            GridviewAddFooter("小計", e);
        }
    }
    internal void GridViewAddFooter_sum(GridView _gd)
    {
        decimal sum = 0;

        if (_gd.Rows.Count > 0)
        {
            for (int i = 3; i < _gd.Rows[0].Cells.Count; i++)
            {
                sum = 0;
                for (int j = 0; j < _gd.Rows.Count; j++)
                {
                    decimal temp = 0;
                    decimal? decimalValue = decimal.TryParse(((Label)_gd.Rows[j].Cells[i].FindControl("lbl" + i.ToString())).Text, out temp) ? temp:default(decimal?);
                    sum += temp;
                }
                if (i == 15 || i == 16)
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

    //protected void grdReport_DataBound(object sender, EventArgs e)
    //{
    //    decimal total = grdReport.AsEnumerable().Sum(row => row.Field<decimal>("Price"));
    //    grdReport.FooterRow.Cells[1].Text = "Total";
    //    grdReport.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
    //    grdReport.FooterRow.Cells[2].Text = total.ToString("N2");
        
    //}

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
        btnSubmit_Click(sender, e);
    }
}