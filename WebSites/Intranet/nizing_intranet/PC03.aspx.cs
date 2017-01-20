using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class nizing_intranet_PC03 : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ddlCategory1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory1.SelectedValue.ToString() == "R")
        {
            ddlCategory2.Items.Clear();
            ddlCategory2.Items.Add("0.3");
            ddlCategory2.Items.Add("0.5");
            ddlCategory2.Items.Add("0.75");
            ddlCategory2.Items.Add("1.25");
            ddlCategory2.Items.Add("2");
            ddlCategory2.Items.Add("3.5");
            ddlCategory2.Items.Add("5.5");
            ddlCategory2.Items.Add("8");
            ddlCategory2.Items.Add("14");
        }
        else if (ddlCategory1.SelectedValue.ToString() == "3122-")
        {
            ddlCategory2.Items.Clear();
            ddlCategory2.Items.Add("16");
            ddlCategory2.Items.Add("18");
            ddlCategory2.Items.Add("20");
            ddlCategory2.Items.Add("22");            
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string query = GetQuery();
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand(query, conn);
            cmdSelect.Parameters.AddWithValue("@CONDITION", "301-" + ddlCategory1.SelectedValue.ToString() + ddlCategory2.SelectedValue.ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
            DataTable dt = new DataTable();
            da.Fill(dt);

            grdReport.DataSource = dt;
            grdReport.DataBind();
        }

        DataTable dtProd1 = new DataTable();
        DataTable dtProd2 = new DataTable();
        DataTable dtProd3 = new DataTable();

        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("WITH CTE1 AS"
                                        + " ("
                                        + " SELECT INVMB.MB001 押出半成品品號"
                                        + " ,CAST(SUM(INVMC.MC007) AS INT) 押出半成品數量"
                                        + " FROM INVMB"
                                        + " LEFT JOIN INVMC ON INVMB.MB001=INVMC.MC001"
                                        + " WHERE (INVMC.MC002=N'INV-1' OR INVMC.MC002=N'INV-11')"
                                        + " AND INVMB.MB001 = @CONDITION"
                                        + " GROUP BY INVMB.MB001"
                                        + " )"
                                        + " /*SECOND CTE USE FIRST CTE VALUE作為BOM的元件值以抓取使用此元件的主件*/"
                                        + " ,CTE2 AS"
                                        + " ("
                                        + " SELECT CTE1.*"
                                        + " ,BOMMD.MD001 編織半成品品號"
                                        + " ,CAST(SUM(INVMC.MC007) AS INT) 編織半成品數量"
                                        + " FROM BOMMD"
                                        + " RIGHT JOIN CTE1 ON CTE1.押出半成品品號=BOMMD.MD003"
                                        + " LEFT JOIN INVMC ON BOMMD.MD001=INVMC.MC001"
                                        + " AND (INVMC.MC002=N'INV-1' OR INVMC.MC002=N'INV-11')"
                                        + " GROUP BY CTE1.押出半成品品號,CTE1.押出半成品數量,BOMMD.MD001"
                                        + " )"
                                        + " /*THIRD CTE FOR 軸裝*/"
                                        + " ,CTE3 AS"
                                        + " ("
                                        + " SELECT CTE2.*"
                                        + " ,COALESCE(SUM(COPTD.TD008-COPTD.TD009),0) 軸裝未交數量"
                                        + " FROM CTE2"
                                        + " LEFT JOIN BOMMD ON CTE2.編織半成品品號=BOMMD.MD003"
                                        + " LEFT JOIN COPTD ON BOMMD.MD001=COPTD.TD004 AND COPTD.TD016<>N'Y' AND COPTD.TD016<>N'y'"
                                        + " GROUP BY CTE2.押出半成品品號"
                                        + " ,CTE2.押出半成品數量"
                                        + " ,CTE2.編織半成品品號"
                                        + " ,CTE2.編織半成品數量"
                                        + " )"
                                        + " SELECT *"
                                        + " FROM CTE3", conn);
            cmd.Parameters.AddWithValue("@CONDITION", "301-" + ddlCategory1.SelectedValue.ToString() + ddlCategory2.SelectedValue.ToString());
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                dtProd1.Load(dr);
            }
        }
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("WITH CTE1 AS"
+" ("
+" SELECT INVMB.MB001 押出半成品品號"
+" ,CAST(SUM(INVMC.MC007) AS INT) 押出半成品數量"
+" FROM INVMB"
+" LEFT JOIN INVMC ON INVMB.MB001=INVMC.MC001"
+" WHERE (INVMC.MC002=N'INV-1' OR INVMC.MC002=N'INV-11')"
+" AND INVMB.MB001 = @CONDITION"
+" GROUP BY INVMB.MB001"
+" )"
+" /*SECOND CTE USE FIRST CTE VALUE作為BOM的元件值以抓取使用此元件的主件*/"
+" ,CTE2 AS"
+" ("
+" SELECT CTE1.*"
+" ,BOMMD.MD001 編織半成品品號"
+" ,CAST(SUM(INVMC.MC007) AS INT) 編織半成品數量"
+" FROM BOMMD"
+" RIGHT JOIN CTE1 ON CTE1.押出半成品品號=BOMMD.MD003"
+" LEFT JOIN INVMC ON BOMMD.MD001=INVMC.MC001"
+" AND (INVMC.MC002=N'INV-1' OR INVMC.MC002=N'INV-11')"
+" GROUP BY CTE1.押出半成品品號,CTE1.押出半成品數量,BOMMD.MD001"
+" )"
+" /*THIRD CTE FOR 軸裝*/"
+" ,CTE3 AS"
+" ("
+" SELECT CTE2.*"
+" ,BOMMD.MD001 軸裝半成品"
+" ,COALESCE(SUM(COPTD.TD008-COPTD.TD009),0) 軸裝未交數量"
+" FROM CTE2"
+" LEFT JOIN BOMMD ON CTE2.編織半成品品號=BOMMD.MD003"
+" LEFT JOIN COPTD ON BOMMD.MD001=COPTD.TD004 AND COPTD.TD016<>N'Y' AND COPTD.TD016<>N'y'"
+" GROUP BY CTE2.押出半成品品號"
+" ,CTE2.押出半成品數量"
+" ,CTE2.編織半成品品號"
+" ,CTE2.編織半成品數量"
+" ,BOMMD.MD001"
+" )"
+" /*4TH CTE FOR 再加工1*/"
+" ,CTE4 AS"
+" ("
+" SELECT CTE3.押出半成品品號"
+" ,CTE3.押出半成品數量"
+" ,CTE3.編織半成品品號"
+" ,CTE3.編織半成品數量"
+" ,COALESCE(SUM(COPTD.TD008-COPTD.TD009),0) 再加工1未交數量"
+" FROM CTE3"
+" LEFT JOIN BOMMD ON CTE3.軸裝半成品=BOMMD.MD003"
+" LEFT JOIN COPTD ON BOMMD.MD001=COPTD.TD004 AND COPTD.TD016<>N'Y' AND COPTD.TD016<>N'y'"
+" GROUP BY "
+" CTE3.押出半成品品號"
+" ,CTE3.押出半成品數量"
+" ,CTE3.編織半成品品號"
+" ,CTE3.編織半成品數量"
+" )"
+" SELECT *"
+" FROM CTE4", conn);
            cmd.Parameters.AddWithValue("@CONDITION", "301-" + ddlCategory1.SelectedValue.ToString() + ddlCategory2.SelectedValue.ToString());
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                dtProd2.Load(dr);
            }
        }
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("WITH CTE1 AS"
                                        +" ("
                                        +" SELECT INVMB.MB001 押出半成品品號"
                                        +" ,CAST(SUM(INVMC.MC007) AS INT) 押出半成品數量"
                                        +" FROM INVMB"
                                        +" LEFT JOIN INVMC ON INVMB.MB001=INVMC.MC001"
                                        +" WHERE (INVMC.MC002=N'INV-1' OR INVMC.MC002=N'INV-11')"
                                        +" AND INVMB.MB001 = @CONDITION"
                                        +" GROUP BY INVMB.MB001"
                                        +" )"
                                        +" ,CTE2 AS"
                                        +" ("
                                        +" SELECT CTE1.*"
                                        +" ,BOMMD.MD001 編織半成品品號"
                                        +" ,CAST(SUM(INVMC.MC007) AS INT) 編織半成品數量"
                                        +" FROM BOMMD"
                                        +" RIGHT JOIN CTE1 ON CTE1.押出半成品品號=BOMMD.MD003"
                                        +" LEFT JOIN INVMC ON BOMMD.MD001=INVMC.MC001"
                                        +" AND (INVMC.MC002=N'INV-1' OR INVMC.MC002=N'INV-11')"
                                        +" GROUP BY CTE1.押出半成品品號,CTE1.押出半成品數量,BOMMD.MD001"
                                        +" )"
                                        +" ,CTE3 AS"
                                        +" ("
                                        +" SELECT CTE2.*"
                                        +" ,BOMMD.MD001 軸裝半成品"
                                        +" ,COALESCE(SUM(COPTD.TD008-COPTD.TD009),0) 軸裝未交數量"
                                        +" FROM CTE2"
                                        +" LEFT JOIN BOMMD ON CTE2.編織半成品品號=BOMMD.MD003"
                                        +" LEFT JOIN COPTD ON BOMMD.MD001=COPTD.TD004 AND COPTD.TD016<>N'Y' AND COPTD.TD016<>N'y'"
                                        +" GROUP BY CTE2.押出半成品品號"
                                        +" ,CTE2.押出半成品數量"
                                        +" ,CTE2.編織半成品品號"
                                        +" ,CTE2.編織半成品數量"
                                        +" ,BOMMD.MD001"
                                        +" )"
                                        +" ,CTE4 AS"
                                        +" ("
                                        +" SELECT CTE3.押出半成品品號"
                                        +" ,CTE3.押出半成品數量"
                                        +" ,CTE3.編織半成品品號"
                                        +" ,CTE3.編織半成品數量"
                                        +" ,BOMMD.MD001 再加工1品號"
                                        +" ,COALESCE(SUM(COPTD.TD008-COPTD.TD009),0) 再加工1未交數量"
                                        +" FROM CTE3"
                                        +" LEFT JOIN BOMMD ON CTE3.軸裝半成品=BOMMD.MD003"
                                        +" LEFT JOIN COPTD ON BOMMD.MD001=COPTD.TD004 AND COPTD.TD016<>N'Y' AND COPTD.TD016<>N'y'"
                                        +" GROUP BY "
                                        +" CTE3.押出半成品品號"
                                        +" ,CTE3.押出半成品數量"
                                        +" ,CTE3.編織半成品品號"
                                        +" ,CTE3.編織半成品數量"
                                        +" ,BOMMD.MD001"
                                        +" )"
                                        +" ,CTE5 AS"
                                        +" ("
                                        +" SELECT CTE4.押出半成品品號"
                                        +" ,CTE4.押出半成品數量"
                                        +" ,CTE4.編織半成品品號"
                                        +" ,CTE4.編織半成品數量"
                                        +" ,COALESCE(SUM(COPTD.TD008-COPTD.TD009),0) 再加工2未交數量"
                                        +" FROM CTE4"
                                        +" LEFT JOIN BOMMD ON CTE4.再加工1品號=BOMMD.MD003"
                                        +" LEFT JOIN COPTD ON BOMMD.MD001=COPTD.TD004 AND COPTD.TD016<>N'Y' AND COPTD.TD016<>N'y'"
                                        +" GROUP BY "
                                        +" CTE4.押出半成品品號"
                                        +" ,CTE4.押出半成品數量"
                                        +" ,CTE4.編織半成品品號"
                                        +" ,CTE4.編織半成品數量"
                                        +" )"
                                        +" SELECT *"
                                        +" FROM CTE5", conn);
            cmd.Parameters.AddWithValue("@CONDITION", "301-" + ddlCategory1.SelectedValue.ToString() + ddlCategory2.SelectedValue.ToString());
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                dtProd3.Load(dr);
            }
        }
        int rowAmount = Math.Max(dtProd1.Rows.Count,Math.Max(dtProd2.Rows.Count,dtProd3.Rows.Count));
        for (int i = 0; i < rowAmount; i++)
        {
            HtmlGenericControl tr = new HtmlGenericControl();
            tr.TagName = "tr";
            tr.ID = "tr" + (i + 1).ToString();
            tbOutstandingOrderSumBody.Controls.Add(tr);
            //押出半成品品號
            HtmlGenericControl td = new HtmlGenericControl();
            td.TagName = "td";
            td.ID = tr.ID + "_1";
            td.Attributes["style"] = "border-right:solid 1px #cccccc;padding-bottom:5px;";
            if (dtProd1.Rows[i][0] == DBNull.Value)
            {
                td.InnerText = "0";
            }
            else
            {
                td.InnerText = dtProd1.Rows[i][0].ToString();
            }
            tr.Controls.Add(td);
            //押出半成品數量
            td = new HtmlGenericControl();
            td.TagName = "td";
            td.ID = tr.ID + "_2";
            td.Attributes["style"] = "border-right:solid 1px #cccccc;padding-bottom:5px;";
            if (dtProd1.Rows[i][1] == DBNull.Value)
            {
                td.InnerText = "0";
            }
            else
            {
                td.InnerText = dtProd1.Rows[i][1].ToString();
            }
            tr.Controls.Add(td);
            //編織半成品品號
            td = new HtmlGenericControl();
            td.TagName = "td";
            td.ID = tr.ID + "_3";
            td.Attributes["style"] = "border-right:solid 1px #cccccc;padding-bottom:5px;";
            if (dtProd1.Rows[i][2] == DBNull.Value)
            {
                td.InnerText = "0";
            }
            else
            {
                td.InnerText = dtProd1.Rows[i][2].ToString();
            }
            tr.Controls.Add(td);
            //編織半成品數量
            td = new HtmlGenericControl();
            td.TagName = "td";
            td.ID = tr.ID + "_4";
            td.Attributes["style"] = "border-right:solid 1px #cccccc;padding-bottom:5px;";
            if (dtProd1.Rows[i][3] == DBNull.Value)
            {
                td.InnerText = "0";
            }
            else
            {
                td.InnerText = dtProd1.Rows[i][3].ToString();
            }
            tr.Controls.Add(td);
            //軸裝成品未交量
            td = new HtmlGenericControl();
            td.TagName = "td";
            td.ID = tr.ID + "_5";
            td.Attributes["style"] = "border-right:solid 1px #cccccc;padding-bottom:5px;";
            if (dtProd1.Rows[i][4] == DBNull.Value)
            {
                td.InnerText = "0";
            }
            else
            {
                td.InnerText = dtProd1.Rows[i][4].ToString();
            }
            tr.Controls.Add(td);
            //再加工1成品未交量
            td = new HtmlGenericControl();
            td.TagName = "td";
            td.ID = tr.ID + "_6";
            td.Attributes["style"] = "border-right:solid 1px #cccccc;padding-bottom:5px;";
            if (dtProd2.Rows[i][4] == DBNull.Value)
            {
                td.InnerText = "0";
            }
            else
            {
                td.InnerText = dtProd2.Rows[i][4].ToString();
            }
            tr.Controls.Add(td);
            //再加工2成品未交量
            td = new HtmlGenericControl();
            td.TagName = "td";
            td.ID = tr.ID + "_7";
            td.Attributes["style"] = "border-right:solid 1px #cccccc;padding-bottom:5px;";
            if (dtProd3.Rows[i][4] == DBNull.Value)
            {
                td.InnerText = "0";
            }
            else
            {
                td.InnerText = dtProd3.Rows[i][4].ToString();
            }            
            tr.Controls.Add(td);
        }

    }




    private string GetQuery()
    {
        string s = "";
        s = "WITH CTE1 AS"
+ " ("
+ " SELECT INVMB.MB001 押出半成品品號"
+ " ,CAST(SUM(INVMC.MC007) AS INT) 押出半成品數量"
+ " FROM INVMB"
+ " LEFT JOIN INVMC ON INVMB.MB001=INVMC.MC001"
+ " WHERE (INVMC.MC002=N'INV-1' OR INVMC.MC002=N'INV-11')"
+ " AND INVMB.MB001 = @CONDITION"
+ " GROUP BY INVMB.MB001"
+ " )"
+ " ,CTE2 AS"
+ " ("
+ " SELECT CTE1.*"
+ " ,BOMMD.MD001 編織半成品品號"
+ " ,CAST(SUM(INVMC.MC007) AS INT) 編織半成品數量"
+ " FROM BOMMD"
+ " RIGHT JOIN CTE1 ON CTE1.押出半成品品號=BOMMD.MD003"
+ " LEFT JOIN INVMC ON BOMMD.MD001=INVMC.MC001"
+ " AND (INVMC.MC002=N'INV-1' OR INVMC.MC002=N'INV-11')"
+ " GROUP BY CTE1.押出半成品品號,CTE1.押出半成品數量,BOMMD.MD001"
+ " )"
+ " ,CTE3 AS"
+ " ("
+ " SELECT CTE2.*"
+ " ,BOMMD.MD001 軸裝成品品號"
+ " ,CAST(SUM(INVMC.MC007) AS INT) 軸裝成品數量"
+ " FROM CTE2"
+ " LEFT JOIN BOMMD ON CTE2.編織半成品品號=BOMMD.MD003"
+ " LEFT JOIN INVMC ON BOMMD.MD001=INVMC.MC001"
+ " AND (INVMC.MC002=N'INV-1' OR INVMC.MC002=N'INV-11')"
+ " GROUP BY CTE2.押出半成品品號"
+ " ,CTE2.押出半成品數量"
+ " ,CTE2.編織半成品品號"
+ " ,CTE2.編織半成品數量"
+ " ,BOMMD.MD001"
+ " )"
+ " ,CTE4 AS"
+ " ("
+ " SELECT CTE3.*"
+ " ,CAST((COPTD.TD008-COPTD.TD009) AS INT) 軸裝預計出貨"
+ " ,COPTD.TD013 軸裝預交日期"
+ " ,COPMA.MA002 軸裝客戶簡稱"
+ " FROM CTE3"
+ " LEFT JOIN COPTD ON CTE3.軸裝成品品號=COPTD.TD004 AND COPTD.TD016<>N'Y' AND COPTD.TD016<>N'y'"
+ " LEFT JOIN COPTC ON COPTD.TD001=COPTC.TC001 AND COPTD.TD002=COPTC.TC002"
+ " LEFT JOIN COPMA ON COPTC.TC004=COPMA.MA001"
+ " )"
+ " ,CTE5 AS"
+ " ("
+ " SELECT CTE4.*"
+ " ,BOMMD.MD001 再加工1成品品號"
+ " ,CAST(SUM(INVMC.MC007) AS INT) 再加工1成品數量"
+ " FROM CTE4"
+ " LEFT JOIN BOMMD ON CTE4.軸裝成品品號=BOMMD.MD003 AND (BOMMD.MD001 LIKE N'1-%' OR BOMMD.MD001 LIKE N'D-%')"
+ " LEFT JOIN INVMC ON BOMMD.MD001=INVMC.MC001 "
+ " AND (INVMC.MC002=N'INV-1' OR INVMC.MC002=N'INV-11')"
+ " GROUP BY CTE4.押出半成品品號"
+ " ,CTE4.押出半成品數量"
+ " ,CTE4.編織半成品品號"
+ " ,CTE4.編織半成品數量"
+ " ,CTE4.軸裝成品品號"
+ " ,CTE4.軸裝成品數量"
+ " ,CTE4.軸裝預計出貨"
+ " ,CTE4.軸裝預交日期"
+ " ,CTE4.軸裝客戶簡稱"
+ " ,BOMMD.MD001"
+ " )"
+ " ,CTE6 AS"
+ " ("
+ " SELECT CTE5.*"
+ " ,CAST((COPTD.TD008-COPTD.TD009) AS INT) 再加工1預計出貨"
+ " ,COPTD.TD013 再加工1預交日期"
+ " ,COPMA.MA002 再加工1客戶簡稱"
+ " FROM CTE5"
+ " LEFT JOIN COPTD ON CTE5.再加工1成品品號=COPTD.TD004 AND COPTD.TD016<>N'Y' AND COPTD.TD016<>N'y'"
+ " LEFT JOIN COPTC ON COPTD.TD001=COPTC.TC001 AND COPTD.TD002=COPTC.TC002"
+ " LEFT JOIN COPMA ON COPTC.TC004=COPMA.MA001"
+ " )"
+ " ,CTE7 AS"
+ " ("
+ " SELECT CTE6.*"
+ " ,BOMMD.MD001 再加工2成品品號"
+ " ,CAST(SUM(INVMC.MC007) AS INT) 再加工2成品數量"
+ " FROM CTE6"
+ " LEFT JOIN BOMMD ON CTE6.再加工1成品品號=BOMMD.MD003 AND (BOMMD.MD001 LIKE N'1-%' OR BOMMD.MD001 LIKE N'D-%')"
+ " LEFT JOIN INVMC ON BOMMD.MD001=INVMC.MC001 "
+ " AND (INVMC.MC002=N'INV-1' OR INVMC.MC002=N'INV-11')"
+ " GROUP BY CTE6.押出半成品品號"
+ " ,CTE6.押出半成品數量"
+ " ,CTE6.編織半成品品號"
+ " ,CTE6.編織半成品數量"
+ " ,CTE6.軸裝成品品號"
+ " ,CTE6.軸裝成品數量"
+ " ,CTE6.軸裝預計出貨"
+ " ,CTE6.軸裝預交日期"
+ " ,CTE6.軸裝客戶簡稱"
+ " ,CTE6.再加工1客戶簡稱"
+ " ,CTE6.再加工1成品品號"
+ " ,CTE6.再加工1成品數量"
+ " ,CTE6.再加工1預交日期"
+ " ,CTE6.再加工1預計出貨"
+ " ,BOMMD.MD001"
+ " )"
+ " ,CTE8 AS"
+ " ("
+ " SELECT"
+ " CTE7.*"
+ " ,CAST((COPTD.TD008-COPTD.TD009) AS INT) 再加工2預計出貨"
+ " ,COPTD.TD013 再加工2預交日期"
+ " ,COPMA.MA002 再加工2客戶簡稱"
+ " FROM CTE7"
+ " LEFT JOIN COPTD ON CTE7.再加工2成品品號=COPTD.TD004 AND COPTD.TD016<>N'Y' AND COPTD.TD016<>N'y'"
+ " LEFT JOIN COPTC ON COPTD.TD001=COPTC.TC001 AND COPTD.TD002=COPTC.TC002"
+ " LEFT JOIN COPMA ON COPTC.TC004=COPMA.MA001"
+ " )"
+ " SELECT"
+ " CTE8.*"
+ " FROM CTE8"
+ " ORDER BY CTE8.押出半成品品號,CTE8.編織半成品品號,CTE8.軸裝成品品號,CTE8.軸裝預交日期,CTE8.軸裝客戶簡稱,CTE8.再加工1成品品號,CTE8.再加工1預交日期,CTE8.再加工1客戶簡稱,CTE8.再加工2成品品號,CTE8.再加工2預交日期,CTE8.再加工2客戶簡稱";
        return s;
    }
    protected void grdReport_RowCreated(object sender, GridViewRowEventArgs e)
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
        int sum1 = 0;
        int sum2 = 0;
        int sum3 = 0;
        if (_gd.Rows.Count > 0)
        {
            //for (int i = 1; i < 20; i++)
            //{
                sum1 = 0;
                sum2 = 0;
                sum3 = 0;
                for (int j = 0; j < _gd.Rows.Count; j++)
                {
                    sum1 += int.Parse(((Label)_gd.Rows[j].Cells[5].FindControl("Label6")).Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    sum2 += int.Parse(((Label)_gd.Rows[j].Cells[10].FindControl("Label11")).Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    //sum3 += int.Parse(((Label)_gd.Rows[j].Cells[15].FindControl("Label16")).Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                }
                _gd.FooterRow.Cells[5].Text = sum1.ToString("N0");
                _gd.FooterRow.Cells[10].Text = sum2.ToString("N0");
                //_gd.FooterRow.Cells[15].Text = sum3.ToString("N0");
            //}
        }
    }
    protected void grdReport_DataBound(object sender, EventArgs e)
    {
        GridViewAddFooter_sum(grdReport);
    }
}