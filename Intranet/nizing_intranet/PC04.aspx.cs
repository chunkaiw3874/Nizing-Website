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

public partial class nizing_intranet_PC04 : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Form.DefaultButton = this.btnSubmit.UniqueID;
            for (int i = DateTime.Today.Year; i >= 2014 ; i--)
            {
                ddlStartYear.Items.Add(i.ToString());
                ddlEndYear.Items.Add(i.ToString());    
            }
            for (int i = 1; i <= 12; i++)
            {
                ddlStartMonth.Items.Add(i.ToString("D2"));
                ddlEndMonth.Items.Add(i.ToString("D2"));
            }
            ddlStartYear.SelectedValue = DateTime.Today.Year.ToString();
            ddlStartMonth.SelectedIndex = 0;
            ddlEndYear.SelectedValue = DateTime.Today.Year.ToString();
            ddlEndMonth.SelectedValue = DateTime.Today.Month.ToString("D2");
            DataTable dt = new DataTable();
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
            ckxSmallCategory.Checked = true;
            ckxID.Checked = false;
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
            cmd.Parameters.AddWithValue("@beginDate", ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + "01");
            cmd.Parameters.AddWithValue("@endDate", ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue + "31");
            cmd.Parameters.AddWithValue("@smallCategory", ddlSmallCategory.SelectedValue);
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
                            //finds the row that has repeated ID and a NULL yr
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
        string smallCategoryCondition = "";
        string IDCondition = "";
        if (ckxSmallCategory.Checked)
        {
            smallCategoryCondition = " WHERE MB.MB007=@smallCategory";
        }
        if (ckxID.Checked)
        {
            IDCondition = " WHERE ID LIKE '%'+@ID+'%'";
        }


        string query = ";WITH SALESTABLE"
                    + " AS"
                    + " ("
                    + " SELECT MB.MB001 'ID'"
                    + " , CAST(COALESCE(MC.MC004,0) AS INT) 'safeInv'"
                    + " , CAST(COALESCE(SUM(MC.MC007),0) AS INT) 'invAmount'"
                    + " , SUBSTRING(TG.TG042,1,4) 'yr'"
                    + " , SUBSTRING(TG.TG042,5,2) 'mn'"
                    + " , CAST(TH.TH008 AS INT) 'saleAmount'"
                    + " FROM INVMB MB"
                    + " LEFT JOIN INVMC MC ON MB.MB001=MC.MC001 AND MC.MC002='INV-1'"
                    + " LEFT JOIN COPTH TH ON MB.MB001=TH.TH004"
                    + " LEFT JOIN COPTG TG ON TH.TH001=TG.TG001 AND TH.TH002=TG.TG002 AND TG.TG042 BETWEEN @beginDate AND @endDate"
                    + smallCategoryCondition
                    + " GROUP BY MB.MB001,MC.MC004,TH.TH008,TG.TG042,TH.TH001,TH.TH002,TH.TH003"
                    + " )"
                    + " SELECT *"
                    + " FROM"
                    + " ("
                    + " SELECT ID"
                    + " ,COALESCE(safeInv,0) 'safeInv'"
                    + " ,COALESCE(invAmount,0) 'invAmount'"
                    + " ,COALESCE(yr,'N/A') 'yr'"
                    + " ,COALESCE(mn,'N/A') 'mn'"
                    + " ,COALESCE(saleAmount,0) 'saleAmount'"
                    + " FROM SALESTABLE"
                    + " ) AS SRC"
                    + " PIVOT"
                    + " ("
                    + " SUM(saleAmount)"
                    + " FOR mn IN ([01],[02],[03],[04],[05],[06],[07],[08],[09],[10],[11],[12])"
                    + " ) AS DS"
                    + IDCondition
                    + " ORDER BY ID,yr";
        return query;
    }
    
    protected void ckxID_CheckedChanged(object sender, EventArgs e)
    {
        keepCkxSmallCateogyrInCheck();
    }
    protected void ckxSmallCategory_CheckedChanged(object sender, EventArgs e)
    {
        keepCkxSmallCateogyrInCheck();
    }
    protected void keepCkxSmallCateogyrInCheck()
    {
        if (!ckxID.Checked)
        {
            ckxSmallCategory.Checked = true;
        }
    }
    protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        replaceNullCellWithZero(e);
        compareInvAndSafeInvAmountWithColorChange(e, System.Drawing.Color.Red);
        calculateMonthlySubtotal(e);
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

            if (double.TryParse(((Label)e.Row.FindControl("Label1")).Text, out safeInv) && double.TryParse(((Label)e.Row.FindControl("Label2")).Text, out currentInv))
            {
                if (currentInv < safeInv)
                {
                    ((Label)e.Row.FindControl("Label2")).ForeColor = c;
                }
                else
                {
                    ((Label)e.Row.FindControl("Label2")).ForeColor = System.Drawing.Color.Black;
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
            double monthlySum = 0;

            if (!double.TryParse(((Label)e.Row.FindControl("Label4")).Text, out jan))
            {
                jan = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label5")).Text, out feb))
            {
                feb = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label6")).Text, out mar))
            {
                mar = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label7")).Text, out apr))
            {
                apr = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label8")).Text, out may))
            {
                may = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label9")).Text, out june))
            {
                june = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label10")).Text, out july))
            {
                july = 0;
            } 
            if (!double.TryParse(((Label)e.Row.FindControl("Label11")).Text, out aug))
            {
                aug = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label12")).Text, out sept))
            {
                sept = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label13")).Text, out oct))
            {
                oct = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label14")).Text, out nov))
            {
                nov = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("Label15")).Text, out dec))
            {
                dec = 0;
            }

            ((Label)e.Row.FindControl("lblAnnualSum")).Text = (jan + feb + mar + apr + may + june + july + aug + sept + oct + nov + dec).ToString();
        }
    }
    protected void gvResult_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            GridviewAddFooter("小計", e);
        }
    }
    internal void GridViewAddFooter_sum(GridView _gd)
    {
        double sum = 0;
        if (_gd.Rows.Count > 0)
        {
            for (int i = 4; i < _gd.Rows[0].Cells.Count; i++)
            {
                sum = 0;

                if (i != _gd.Rows[0].Cells.Count - 1)
                {
                    for (int j = 1; j < _gd.Rows.Count; j++)
                    {
                        sum += double.Parse(((Label)_gd.Rows[j].Cells[i].FindControl("Label" + i.ToString())).Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    }
                }
                else
                {
                    for (int j = 1; j < _gd.Rows.Count; j++)
                    {
                        sum += double.Parse(((Label)_gd.Rows[j].Cells[i].FindControl("lblAnnualSum")).Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    }
                }

                //if (i == 3)
                //{
                //_gd.FooterRow.Cells[i].Text = sum.ToString("C", new CultureInfo("zh-TW"));
                //}
                //else
                //{
                _gd.FooterRow.Cells[i].Text = sum.ToString("N0");
                //}
            }
        }
    }
    protected void gvResult_DataBound(object sender, EventArgs e)
    {
        GridViewAddFooter_sum(gvResult);
    }
    internal void GridviewAddFooter(string _strFooterName, GridViewRowEventArgs _gd)
    {
        int col = _gd.Row.Cells.Count;
        TableCellCollection tc = _gd.Row.Cells;
        tc.Clear();
        TableCell tc1;

        for (int i = 0; i < col; i++)
        {
            if (i == 3)
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
}