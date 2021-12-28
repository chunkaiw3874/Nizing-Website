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

public partial class nizing_intranet_PD03_RawMatsUsage : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    private enum Category {RAW, SMALL, LARGE};
    Category lastSelected = Category.RAW;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDropdownData();
            this.Form.DefaultButton = this.btnSubmit.UniqueID;
            rdoRawMatsCategory.Checked = true;
            
        }
    }

    private void LoadDropdownData()
    {
        for (int i = DateTime.Today.Year; i >= 2014; i--)
        {
            ddlStartYear.Items.Add(i.ToString());
            ddlEndYear.Items.Add(i.ToString());
        }
        ddlStartYear.SelectedValue = DateTime.Today.Year.ToString();
        ddlEndYear.SelectedValue = DateTime.Today.Year.ToString();

        //load raw mats dropdown
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            string query = "SELECT MA002 'ID', MA003 'NAME' FROM INVMA WHERE MA001 = 2 ORDER BY MA002";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ddlRawMatsCategory.Items.Add(new ListItem(dt.Rows[i][1].ToString().Trim(), dt.Rows[i][0].ToString().Trim()));
        }

        //load large category dropdown
        dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            string query = "SELECT MA002 'ID', MA003 'NAME' FROM INVMA WHERE MA001 = 4 ORDER BY MA002";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ddlLargeCategory.Items.Add(new ListItem(dt.Rows[i][1].ToString().Trim(), dt.Rows[i][0].ToString().Trim()));
        }

        //load small category dropdown
        dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            string query = "SELECT MA002 'ID', MA003 'NAME' FROM INVMA WHERE MA001 = 3 ORDER BY MA002";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ddlSmallCategory.Items.Add(new ListItem(dt.Rows[i][1].ToString().Trim(), dt.Rows[i][0].ToString().Trim()));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        performSearch();
    }

    protected void performSearch()
    {
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(buildSearchQeury(), conn);
            cmd.Parameters.AddWithValue("@beginDate", ddlStartYear.SelectedValue + "0101");
            cmd.Parameters.AddWithValue("@endDate", ddlEndYear.SelectedValue + "1231");
            if (rdoRawMatsCategory.Checked)
            {
                cmd.Parameters.AddWithValue("@category", ddlRawMatsCategory.SelectedValue);
            }
            else if (rdoLargeCategory.Checked)
            {
                cmd.Parameters.AddWithValue("@category", ddlLargeCategory.SelectedValue);
            }
            else if (rdoSmallCategory.Checked)
            {
                cmd.Parameters.AddWithValue("@category", ddlSmallCategory.SelectedValue);
            }            
            cmd.Parameters.AddWithValue("@ID", txtSearchID.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //Remove duplicate rows based conditions that the row has REPEATED ID and YEAR is null
            if (dt.Rows.Count > 0)
            {
                List<string> lst = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lst.Add(dt.Rows[i]["ID"].ToString());                    
                }
                var duplicates = lst.GroupBy(x => x)
                                            .Where(g => g.Count() > 1)
                                            .Select(y => y.Key)
                                            .ToList();
                List<int> rowsToDelete = new List<int>();
                foreach (string s in duplicates)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["ID"].ToString() == s && row["yr"].ToString() == "N/A")
                        {
                            row.Delete();
                        }
                    }
                    dt.AcceptChanges();
                }
            }

            gvResult.DataSource = dt;
            gvResult.DataBind();
        }
    }

    protected string buildSearchQeury()
    {
        string categoryCondition = "";
        string IDCondition = "";

        if (rdoRawMatsCategory.Checked)
        {
            categoryCondition = " WHERE MB.MB006=@category";
        }
        else if (rdoLargeCategory.Checked)
        {
            categoryCondition = " WHERE MB.MB008=@category";
        }
        if (rdoSmallCategory.Checked)
        {
            categoryCondition = " WHERE MB.MB007=@category";
        }
        
        if (rdoID.Checked)
        {
            IDCondition += " AND ID LIKE '%'+@ID+'%'";
        }
        if (ckxNoDisplayWhenInvAndSafeInvIsZero.Checked)
        {
            IDCondition += " AND (invAmount<>0 OR safeInv<>0 OR [01]<>0 OR [02]<>0 OR [03]<>0 OR [04]<>0 OR [05]<>0 OR [06]<>0 OR [07]<>0 OR [08]<>0 OR [09]<>0 OR [10]<>0 OR [11]<>0 OR [12]<>0)";
        }

        string query = ";WITH usageTable" +
            " AS" +
            " (" +
            " SELECT MB.MB001 'ID'" +
            " , MB.MB002 'name'" +
            " , CAST(COALESCE(MC.MC004, 0) AS DECIMAL) 'safeInv'" +
            " , CAST(COALESCE(SUM(MC.MC007), 0) AS DECIMAL) 'invAmount'" +
            " , MB.MB004 'unit'" +
            " , SUBSTRING(TC.TC014, 1, 4) 'yr'" +
            " , SUBSTRING(TC.TC014, 5, 2) 'mn'" +
            " , CAST(TE.TE005 AS DECIMAL) 'useAmount'" +
            " FROM INVMB MB" +
            " LEFT JOIN INVMC MC ON MB.MB001 = MC.MC001 AND MC.MC002 = 'INV-1'" +
            " LEFT JOIN MOCTE TE ON MB.MB001 = TE.TE004" +
            " LEFT JOIN MOCTC TC ON TE.TE001 = TC.TC001 AND TE.TE002 = TC.TC002 AND TC.TC014 BETWEEN @beginDate AND @endDate" +
            categoryCondition +
            " GROUP BY MB.MB001, MB.MB002, MC.MC004, MB.MB004, TC.TC014, TE.TE005, TE.TE001, TE.TE002, TE.TE003" +
            " )" +            
            " SELECT*" +
            " FROM" +
            " (" +
            " SELECT usage.ID" +
            " , usage.name" +
            " , COALESCE(usage.safeInv, 0) 'safeInv' " +
            " , COALESCE(usage.invAmount, 0) 'invAmount'" +
            " , COALESCE(usage.unit, 'N/A') 'unit'" +
            " , COALESCE(usage.yr, 'N/A') 'yr'" +
            " , COALESCE(usage.mn, 'N/A') 'mn'" +
            " , COALESCE(usage.useAmount, 0) 'useAmount'" +
            " FROM usageTable usage" +
            " ) AS SRC" +
            " PIVOT" +
            " (" +
            " SUM(useAmount)" +
            " FOR mn IN([01],[02],[03],[04],[05],[06],[07],[08],[09],[10],[11],[12])" +
            " ) AS DS" +
            " WHERE 1 = 1" +
            IDCondition +
            " ORDER BY ID, yr DESC";
        return query;
    }




    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        if (gvResult.Rows.Count > 0)
        {
            Export_Excel();
        }
    }

    #region export to excel methods
    private void Export_Excel()
    {
        string filename = "原物料年用量表-" + ddlStartYear.SelectedValue + "~" + ddlEndYear.SelectedValue;

        if (rdoRawMatsCategory.Checked)
        {
            filename += "-" + ddlRawMatsCategory.SelectedItem.Text.Trim();
        }
        else if (rdoLargeCategory.Checked)
        {
            filename += "-" + ddlLargeCategory.SelectedItem.Text.Trim();
        }
        else if (rdoSmallCategory.Checked)
        {
            filename += "-" + ddlSmallCategory.SelectedItem.Text.Trim();
        }
        else if (rdoID.Checked)
        {
            filename += "-" + txtSearchID.Text.Trim();
        }
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
        gvResult.RenderControl(hw);
        HttpContext.Current.Response.Write(tw.ToString());
        HttpContext.Current.Response.End();

        //gvResult.AllowPaging = true;
        //bindgv();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //用export_excel必須要有這個override
    }
    #endregion

    protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        replaceNullCellWithZero(e);
        compareInvAndSafeInvAmountWithColorChange(e, System.Drawing.Color.Red);
        calculateMonthlySubtotal(e);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((Label)e.Row.Cells[4].FindControl("Label6")).Text == "銷貨")
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    Label lbl = (Label)e.Row.Cells[i].FindControl("Label" + i.ToString());
                    lbl.BackColor = System.Drawing.ColorTranslator.FromHtml("#c3e8f4");
                    e.Row.Cells[i].Style.Add("background-color", "#c3e8f4");
                }
                
            }
            else
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {                    
                    Label lbl = (Label)e.Row.Cells[i].FindControl("Label" + i.ToString());
                    lbl.BackColor = System.Drawing.ColorTranslator.FromHtml("#faf0bb");
                    e.Row.Cells[i].Style.Add("background-color", "#faf0bb");
                }
            }
        }
    }

    protected void replaceNullCellWithZero(GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < e.Row.Cells.Count - 1; i++)
            {
                Label lbl = (Label)e.Row.Cells[i].FindControl("Label" + i.ToString());
                if (string.IsNullOrWhiteSpace(lbl.Text))
                {
                    lbl.Text = "0";
                }
            }
        }

    }

    protected void compareInvAndSafeInvAmountWithColorChange(GridViewRowEventArgs e, System.Drawing.Color c)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            double currentInv = 0;
            double safeInv = 0;

            if (double.TryParse(((Label)e.Row.FindControl("Label2")).Text, out safeInv) && double.TryParse(((Label)e.Row.FindControl("Label3")).Text, out currentInv))
            {
                if (currentInv < safeInv)
                {
                    ((Label)e.Row.FindControl("Label3")).ForeColor = c;
                    ((Label)e.Row.FindControl("Label3")).CssClass = "bold";
                }
                else
                {
                    ((Label)e.Row.FindControl("Label3")).ForeColor = System.Drawing.Color.Black;
                }
            }
        }
    }

    protected void calculateMonthlySubtotal(GridViewRowEventArgs e)
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
            double sept = 0;
            double oct = 0;
            double nov = 0;
            double dec = 0;

            if (!double.TryParse(((Label)e.Row.FindControl("Label6")).Text, out jan))
            {
                jan = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label7")).Text, out feb))
            {
                feb = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label8")).Text, out mar))
            {
                mar = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label9")).Text, out apr))
            {
                apr = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label10")).Text, out may))
            {
                may = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label11")).Text, out june))
            {
                june = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label12")).Text, out july))
            {
                july = 0;
            } 
            if (!double.TryParse(((Label)e.Row.FindControl("Label13")).Text, out aug))
            {
                aug = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label14")).Text, out sept))
            {
                sept = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label15")).Text, out oct))
            {
                oct = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label16")).Text, out nov))
            {
                nov = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label17")).Text, out dec))
            {
                dec = 0;
            }

            ((Label)e.Row.FindControl("Label18")).Text = (jan + feb + mar + apr + may + june + july + aug + sept + oct + nov + dec).ToString();
        }
    }
    protected void gvResult_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "";
            HeaderCell.ColumnSpan = 6;
            HeaderCell.CssClass = "stackedHeader-1";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "領料數量/月份";
            HeaderCell.ColumnSpan = 12;
            HeaderCell.CssClass = "stackedHeader-2";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "";
            HeaderCell.ColumnSpan = 1;
            HeaderCell.CssClass = "stackedHeader-2";
            HeaderGridRow.Cells.Add(HeaderCell);
            gvResult.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[4].Text = "小計";
            //GridView FooterGrid = (GridView)sender;
            //GridViewRow FooterGridRow = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Insert);
            //TableCell FooterCell = new TableCell();
            
        }
    }
    internal void GridViewAddFooter_sum(GridView _gd)
    {
        double sum = 0;
        if (_gd.Rows.Count > 0)
        {
            for (int i = 6; i < _gd.Rows[0].Cells.Count; i++)
            {
                sum = 0;
                for (int j = 1; j < _gd.Rows.Count; j++)
                {
                    sum += double.Parse(((Label)_gd.Rows[j].Cells[i].FindControl("Label" + i.ToString())).Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);                    
                }
                _gd.FooterRow.Cells[i].Text = sum.ToString("N0");
            }
        }
    }
    protected void gvResult_DataBound(object sender, EventArgs e)
    {
        GridViewAddFooter_sum(gvResult);
    }



}