using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InventorySearch : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["SunriseConnectionString"].ConnectionString;
    
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        AddRowSelectToGridView(grdAcct);
        //AddRowSelectToGridView(grdRaw);
        //AddRowSelectToGridView(grdSmall);
        //AddRowSelectToGridView(grdLarge);

        base.Render(writer);
    }
    private void AddRowSelectToGridView(GridView gv)
    {
        foreach (GridViewRow row in gv.Rows)
        {

            row.Attributes["onmouseover"] = "this.style.cursor='hand';";

            row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

            row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gv, "Select$" + row.RowIndex.ToString(), true));

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        SqlSearch();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblErrorMessage.Text = ex.ToString();
    //    }
    //}

    private string GetQueryString()
    {
        string query = "SELECT COALESCE(INVMB.MB001, '') [ITEM_ID]"
                    + " , COALESCE(INVMB.MB002, '') [ITEM_NAME]"
                    + " , COALESCE(INVMB.MB003, '') [ITEM_SPEC]"
                    + " , COALESCE(INVMC.MC007, 0) [AMOUNT_IN_INV]"
                    + " , COALESCE(INVMB.MB004, '') [UNIT]"
                    + " , COALESCE(CMSMC.MC001,'') [INV_ID]"
                    + " , COALESCE(CMSMC.MC002, '') [INV_NAME]"
                    + " , COALESCE(INVMC.MC004, 0) [AMOUNT_SAFETY]"
                    + " , COALESCE(INVMB.MB064, 0) [AMOUNT_TOTAL]"
                    + " , COALESCE(INVMB.MB005, '') [CATEGORY_ACCT]"
                    + " , COALESCE(INVMB.MB006, '') [CATEGORY_RAW]"
                    + " , COALESCE(INVMB.MB007, '') [CATEGORY_SMALL]"
                    + " , COALESCE(INVMB.MB008, '') [CATEGORY_LARGE]"
                    + " FROM INVMB"
                    + " LEFT JOIN INVMC ON INVMB.MB001=INVMC.MC001"
                    + " LEFT JOIN CMSMC ON INVMC.MC002=CMSMC.MC001";
        string condition = "";
        char[] delimiters = new char[] { ',' };
        List<string> ID = new List<string>();
        List<string> Name = new List<string>();
        if (chkId.Checked == true)
        {
            
            string[] start = txtId_Start.Text.Replace(" ", "").Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] middle = txtId_Middle.Text.Replace(" ", "").Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] end = txtId_End.Text.Replace(" ", "").Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < start.Count(); i++)
            {
                start[i] = (start[i] + '%');
            }
            for (int i = 0; i < middle.Count(); i++)
            {
                middle[i] = ('%' + middle[i] + '%');
            }
            for (int i = 0; i < end.Count(); i++)
            {
                end[i] = ('%' + end[i]);
            }
            foreach (string str in start)
            {
                ID.Add(str);
            }
            foreach (string str in middle)
            {
                ID.Add(str);
            }
            foreach (string str in end)
            {
                ID.Add(str);
            }
        }
        if (chkName.Checked == true)
        {
            string[] start = txtName_Start.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] middle = txtName_Middle.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < start.Count(); i++)
            {
                start[i] = (start[i] + '%');
            }
            for (int i = 0; i < middle.Count(); i++)
            {
                middle[i] = ('%' + middle[i] + '%');
            }
            foreach (string str in start)
            {
                Name.Add(str);
            }
            foreach (string str in middle)
            {
                Name.Add(str);
            }
        }

        if (ID.Count != 0)
        {
            int i = 0;
            foreach (string str in ID)
            {
                if (i == 0)
                {
                    condition += " WHERE INVMB.MB001 LIKE N'" + str + "'";
                }
                else if (i < ID.Count)
                {
                    condition += " AND INVMB.MB001 LIKE N'" + str + "'";
                }
                i++;
            }
        }
        if (Name.Count != 0)
        {
            int i = 0;
            foreach (string str in Name)
            {
                if (ID.Count == 0 && i == 0)
                {
                    condition += " WHERE INVMB.MB002 LIKE N'" + str + "'";
                }
                else if (i < Name.Count)
                {
                    condition += " AND INVMB.MB002 LIKE N'" + str + "'";
                }
                i++;
            }
        }

        if (chkCategory.Checked == true)
        {
            if (txtCategory_Acct.Text.Trim() != "")
            {
                if (ID.Count == 0 && Name.Count == 0)
                {
                    condition += " WHERE INVMB.MB005=N'" + txtCategory_Acct.Text.Trim() + "'";
                }
                else
                {
                    condition += " AND INVMB.MB005=N'" + txtCategory_Acct.Text.Trim() + "'";
                }
            }
            //if (txtCategory_Raw.Text.Trim() != "")
            //{
            //    if (ID.Count == 0 && Name.Count == 0 && txtCategory_Acct.Text.Trim() == "")
            //    {
            //        condition += " WHERE INVMB.MB006=N'" + txtCategory_Raw.Text.Trim() + "'";
            //    }
            //    else
            //    {
            //        condition += " AND INVMB.MB006=N'" + txtCategory_Raw.Text.Trim() + "'";
            //    }
            //}
            //if (txtCategory_Small.Text.Trim() != "")
            //{
            //    if (ID.Count == 0 && Name.Count == 0 && txtCategory_Acct.Text.Trim() == "" && txtCategory_Raw.Text.Trim() == "")
            //    {
            //        condition += " WHERE INVMB.MB007=N'" + txtCategory_Small.Text.Trim() + "'";
            //    }
            //    else
            //    {
            //        condition += " AND INVMB.MB007=N'" + txtCategory_Small.Text.Trim() + "'";
            //    }
            //}
            //if (txtCategory_Large.Text.Trim() != "")
            //{
            //    if (ID.Count == 0 && Name.Count == 0 && txtCategory_Acct.Text.Trim() == "" && txtCategory_Raw.Text.Trim() == "" && txtCategory_Small.Text.Trim() == "")
            //    {
            //        condition += " WHERE INVMB.MB008=N'" + txtCategory_Large.Text.Trim() + "'";
            //    }
            //    else
            //    {
            //        condition += " AND INVMB.MB008=N'" + txtCategory_Large.Text.Trim() + "'";
            //    }
            //}
        }
        if (!chkInvShowZero.Checked)
        {
            if (ID.Count == 0 && Name.Count == 0 && txtCategory_Acct.Text.Trim() == "" 
                //&& txtCategory_Raw.Text.Trim() == "" && txtCategory_Small.Text.Trim() == "" && txtCategory_Large.Text.Trim() == ""
                )
            {
                condition += " WHERE INVMB.MB064 <> 0";
            }
            else
            {
                condition += " AND INVMB.MB064 <> 0";
            }
        }
        if (!chkSafetyShowZero.Checked)
        {
            if (ID.Count == 0 && Name.Count == 0 && txtCategory_Acct.Text.Trim() == "" 
                //&& txtCategory_Raw.Text.Trim() == "" && txtCategory_Small.Text.Trim() == "" && txtCategory_Large.Text.Trim() == "" 
                && chkInvShowZero.Checked == true)
            {
                condition += " WHERE INVMC.MC004 <> 0";
            }
            else
            {
                condition += " AND INVMC.MC004 <>0";
            }
        }
        condition += " ORDER BY INVMB.MB001, CMSMC.MC001";
        //string[] SearchWords = txtSearch.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        //string dynamicQuery = "";

        //if (rdoPIndex.Checked)
        //{
        //    if (rdoAnd.Checked)
        //    {
        //        for (int i = 0; i < SearchWords.Length; i++)
        //        {
        //            if (i != SearchWords.Length - 1)
        //            {
        //                dynamicQuery += " UPPER(INVMB.MB001) LIKE UPPER(N'%" + SearchWords[i] + "%') AND";
        //            }
        //            else
        //            {
        //                dynamicQuery += " UPPER(INVMB.MB001) LIKE UPPER(N'%" + SearchWords[i] + "%')";
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < SearchWords.Length; i++)
        //        {
        //            if (i != SearchWords.Length - 1)
        //            {
        //                dynamicQuery += " UPPER(INVMB.MB001) LIKE UPPER(N'%" + SearchWords[i] + "%') OR";
        //            }
        //            else
        //            {
        //                dynamicQuery += " UPPER(INVMB.MB001) LIKE UPPER(N'%" + SearchWords[i] + "%')";
        //            }
        //        }

        //    }

        //}
        //else
        //{
        //    if (rdoAnd.Checked)
        //    {
        //        for (int i = 0; i < SearchWords.Length; i++)
        //        {
        //            if (i != SearchWords.Length - 1)
        //            {
        //                dynamicQuery += " UPPER(INVMB.MB002) LIKE UPPER(N'%" + SearchWords[i] + "%') AND";
        //            }
        //            else
        //            {
        //                dynamicQuery += " UPPER(INVMB.MB002) LIKE UPPER(N'%" + SearchWords[i] + "%')";
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < SearchWords.Length; i++)
        //        {
        //            if (i != SearchWords.Length - 1)
        //            {
        //                dynamicQuery += " UPPER(INVMB.MB002) LIKE UPPER(N'%" + SearchWords[i] + "%') OR";
        //            }
        //            else
        //            {
        //                dynamicQuery += " UPPER(INVMB.MB002) LIKE UPPER(N'%" + SearchWords[i] + "%')";
        //            }
        //        }
        //    }
        //}

        //if (chkInvShowZero.Checked == true)
        //{
        //    if (chkSafetyShowZero.Checked == true)
        //    {
        //        query = "SELECT INVMB.MB001, INVMB.MB002, INVMB.MB003, INVMB.MB064, COALESCE(INVMC.MC004,0) MC004 FROM INVMB LEFT JOIN INVMC ON INVMB.MB001 = INVMC.MC001 WHERE (INVMC.MC002 = N'INV-1' OR INVMC.MC002 IS NULL) AND INVMB.MB005 LIKE N'%01' AND" + dynamicQuery;
        //    }
        //    else
        //    {
        //        query = "SELECT INVMB.MB001, INVMB.MB002, INVMB.MB003, INVMB.MB064, COALESCE(INVMC.MC004,0) MC004 FROM INVMB LEFT JOIN INVMC ON INVMB.MB001 = INVMC.MC001 WHERE (INVMC.MC002 = N'INV-1' OR INVMC.MC002 IS NULL) AND NOT(INVMC.MC004 = 0 OR INVMC.MC004 IS NULL) AND INVMB.MB005 LIKE N'%01' AND" + dynamicQuery;
        //    }
        //}
        //else
        //{
        //    if (chkSafetyShowZero.Checked == true)
        //    {
        //        query = "SELECT INVMB.MB001, INVMB.MB002, INVMB.MB003, INVMB.MB064, COALESCE(INVMC.MC004,0) MC004 FROM INVMB LEFT JOIN INVMC ON INVMB.MB001 = INVMC.MC001 WHERE (INVMC.MC002 = N'INV-1' OR INVMC.MC002 IS NULL) AND INVMB.MB005 LIKE N'%01' AND INVMB.MB064 <> 0 AND" + dynamicQuery;
        //    }
        //    else
        //    {
        //        query = "SELECT INVMB.MB001, INVMB.MB002, INVMB.MB003, INVMB.MB064, COALESCE(INVMC.MC004,0) MC004 FROM INVMB LEFT JOIN INVMC ON INVMB.MB001 = INVMC.MC001 WHERE (INVMC.MC002 = N'INV-1' OR INVMC.MC002 IS NULL) AND NOT(INVMC.MC004 = 0 OR INVMC.MC004 IS NULL) AND INVMB.MB005 LIKE N'%01' AND INVMB.MB064 <> 0 AND" + dynamicQuery;
        //    }
        //}
        query += condition;
        return query;
    }
    private void SqlSearch()
    {
        string query = GetQueryString();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdResult.DataSource = ds;
            grdResult.DataBind();
        }
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            SqlSearch();
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void btnCategory_Acct_Select_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT MA002 會計分類代號, MA003 會計分類名稱 FROM INVMA WHERE MA001 = 1", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grdAcct.DataSource = dt;
            grdAcct.DataBind();
        }
    }
    //protected void btnCategory_Raw_Select_Click(object sender, EventArgs e)
    //{
    //    using (SqlConnection conn = new SqlConnection(connectionString))
    //    {
    //        conn.Open();
    //        SqlCommand cmdSelect = new SqlCommand("SELECT MA002 原物半分類代號, MA003 原物半分類名稱 FROM INVMA WHERE MA001 = 2", conn);
    //        SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
    //        DataTable dt = new DataTable();
    //        da.Fill(dt);
    //        grdRaw.DataSource = dt;
    //        grdRaw.DataBind();
    //    }
    //}
    //protected void btnCategory_Small_Select_Click(object sender, EventArgs e)
    //{
    //    using (SqlConnection conn = new SqlConnection(connectionString))
    //    {
    //        conn.Open();
    //        SqlCommand cmdSelect = new SqlCommand("SELECT MA002 成品小分類代號, MA003 成品小分類名稱 FROM INVMA WHERE MA001 = 3", conn);
    //        SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
    //        DataTable dt = new DataTable();
    //        da.Fill(dt);
    //        grdSmall.DataSource = dt;
    //        grdSmall.DataBind();
    //    }
    //}
    //protected void btnCategory_Large_Select_Click(object sender, EventArgs e)
    //{
    //    using (SqlConnection conn = new SqlConnection(connectionString))
    //    {
    //        conn.Open();
    //        SqlCommand cmdSelect = new SqlCommand("SELECT MA002 成品大分類代號, MA003 成品大分類名稱 FROM INVMA WHERE MA001 = 4", conn);
    //        SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
    //        DataTable dt = new DataTable();
    //        da.Fill(dt);
    //        grdLarge.DataSource = dt;
    //        grdLarge.DataBind();
    //    }
    //}
    protected void grdAcct_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCategory_Acct.Text = grdAcct.SelectedRow.Cells[0].Text;
    }
    //protected void grdRaw_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    txtCategory_Raw.Text = grdRaw.SelectedRow.Cells[0].Text;
    //}
    //protected void grdSmall_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    txtCategory_Small.Text = grdSmall.SelectedRow.Cells[0].Text;
    //}
    //protected void grdLarge_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    txtCategory_Large.Text = grdLarge.SelectedRow.Cells[0].Text;
    //}
}