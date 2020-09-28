using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InventorySearch : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["SunrizeConnectionString"].ConnectionString;

    List<string> noVisibleCostColumnList = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        //noVisibleCostColumnList.Add("dakai");

        if (!IsPostBack)
        {
            //debug only
            //Session["user"] = "kevin";

            Session["user"] = getId();

            DataTable dt = GetAccountCategory();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlCategory_Acct.Items.Add(new ListItem(dt.Rows[i]["MA002"].ToString() + "-" + dt.Rows[i]["MA003"].ToString(), dt.Rows[i]["MA002"].ToString()));
            }

        }

    }

    //protected override void Render(HtmlTextWriter writer)
    //{
    //    AddRowSelectToGridView(gvItemList);

    //    base.Render(writer);
    //}

    private DataTable GetAccountCategory()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT MA002, MA003 FROM INVMA WHERE MA001 = 1";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }

    protected string getId()
    {
        WindowsPrincipal principal = (WindowsPrincipal)User;
        WindowsIdentity identity = (WindowsIdentity)User.Identity;
        string[] name = identity.Name.Split('\\');
        return name[1];
    }

    //private void AddRowSelectToGridView(GridView gv)
    //{
    //    foreach (GridViewRow row in gv.Rows)
    //    {
    //        row.Cells[0].Controls[0].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gv, "Select$" + row.RowIndex.ToString(), true));
    //    }
    //}
    private string GetQueryString()
    {
        string query = "SELECT COALESCE(INVMB.MB001, '') [ITEM_ID]"
                    + " , COALESCE(INVMB.MB002, '') [ITEM_NAME]"
                    + " , COALESCE(INVMB.MB003, '') [ITEM_SPEC]"
                    //+ " , CONVERT(DECIMAL(20,2),COALESCE(INVMB.MB049,0)) [LAST_PURCHASE_PRICE]"
                    + " , CASE"
                    + " WHEN INVMB.MB064=0 THEN 0" +
                    " ELSE CONVERT(DECIMAL(20,4),INVMB.MB065/INVMB.MB064)" +
                    " END [INV_AVG_COST]"
                    + " , COALESCE(INVMB.MB048,'') [LAST_PURCHASE_CURRENCY]"
                    + " , CONVERT(DECIMAL(20,0),COALESCE(INVMC.MC007, 0)) [AMOUNT_IN_INV]"
                    + " , COALESCE(INVMB.MB004, '') [UNIT]"
                    + " , COALESCE(CMSMC.MC001,'') [INV_ID]"
                    + " , COALESCE(CMSMC.MC002, '') [INV_NAME]"
                    + " , COALESCE(INVMC.MC003, '') [INV_LOCATION]"
                    + " , CONVERT(DECIMAL(20,0),COALESCE(INVMC.MC004, 0)) [AMOUNT_SAFETY]"
                    //+ " , CONVERT(DECIMAL(20,0),COALESCE(INVMB.MB064, 0)) [AMOUNT_TOTAL]"
                    + " , COALESCE(INVMB.MB005, '') [CATEGORY_ACCT]"
                    + " , COALESCE(INVMB.MB006, '') [CATEGORY_RAW]"
                    + " , COALESCE(INVMB.MB007, '') [CATEGORY_SMALL]"
                    + " , COALESCE(INVMB.MB008, '') [CATEGORY_LARGE]"
                    + " FROM INVMB"
                    + " LEFT JOIN INVMC ON INVMB.MB001=INVMC.MC001"
                    + " LEFT JOIN CMSMC ON INVMC.MC002=CMSMC.MC001" +
                    " WHERE 1=1";
        string condition = "";
        char[] delimiters = new char[] { ',' };
        List<string> ID = new List<string>();
        List<string> Name = new List<string>();
        if (chkId.Checked == true)
        {

            //string[] start = txtId_Start.Text.Replace(" ", "").Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] middle = txtId_Middle.Text.Replace(" ", "").Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            //string[] end = txtId_End.Text.Replace(" ", "").Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            //for (int i = 0; i < start.Count(); i++)
            //{
            //    start[i] = (start[i] + '%');
            //}
            for (int i = 0; i < middle.Count(); i++)
            {
                middle[i] = ('%' + middle[i] + '%');
            }
            //for (int i = 0; i < end.Count(); i++)
            //{
            //    end[i] = ('%' + end[i]);
            //}
            //foreach (string str in start)
            //{
            //    ID.Add(str);
            //}
            foreach (string str in middle)
            {
                ID.Add(str);
            }
            //foreach (string str in end)
            //{
            //    ID.Add(str);
            //}
        }
        if (chkName.Checked == true)
        {
            //string[] start = txtName_Start.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] middle = txtName_Middle.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            //string[] end = txtName_End.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            //for (int i = 0; i < start.Count(); i++)
            //{
            //    start[i] = (start[i] + '%');
            //}
            for (int i = 0; i < middle.Count(); i++)
            {
                middle[i] = ('%' + middle[i] + '%');
            }
            //for (int i = 0; i < end.Count(); i++)
            //{
            //    end[i] = ('%' + end[i] + '%');
            //}

            //foreach (string str in start)
            //{
            //    Name.Add(str);
            //}
            foreach (string str in middle)
            {
                Name.Add(str);
            }
            //foreach (string str in end)
            //{
            //    Name.Add(str);
            //}
        }

        if (ID.Count != 0)
        {
            for (int i = 0; i < ID.Count; i++)
            {
                if (i == 0)
                {
                    condition += " AND (LTRIM(RTRIM(INVMB.MB001)) LIKE N'" + ID[i] + "'";
                    if (ID.Count == 1)
                    {
                        condition += ")";
                    }
                }
                else if (i == ID.Count - 1)
                {
                    condition += " OR LTRIM(RTRIM(INVMB.MB001)) LIKE N'" + ID[i] + "')";
                }
                else
                {
                    condition += " OR LTRIM(RTRIM(INVMB.MB001)) LIKE N'" + ID[i] + "'";
                }
            }
        }
        if (Name.Count != 0)
        {
            for (int i = 0; i < Name.Count; i++)
            {
                if (i == 0)
                {
                    condition += " AND (LTRIM(RTRIM(INVMB.MB002)) LIKE N'" + Name[i] + "'";
                    if (Name.Count == 1)
                    {
                        condition += ")";
                    }
                }
                else if (i == Name.Count - 1)
                {
                    condition += " OR LTRIM(RTRIM(INVMB.MB002)) LIKE N'" + Name[i] + "')";
                }
                else
                {
                    condition += " OR LTRIM(RTRIM(INVMB.MB002)) LIKE N'" + Name[i] + "'";
                }
            }
        }

        if (chkCategory.Checked == true)
        {
            condition += " AND INVMB.MB005=N'" + ddlCategory_Acct.Text.Trim() + "'";
        }
        if (!chkInvShowZero.Checked)
        {
            condition += " AND INVMB.MB064 <> 0";
        }
        if (!chkSafetyShowZero.Checked)
        {
            condition += " AND INVMC.MC004 <>0";
        }
        condition += " ORDER BY INVMB.MB001, CMSMC.MC001";
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
            gvItemList.DataSource = ds;
            gvItemList.DataBind();
        }
    }

    protected void gvItemList_PreRender(object sender, EventArgs e)
    {
        if (noVisibleCostColumnList.Contains(Session["user"].ToString()))
        {
            gvItemList.Columns[6].Visible = false;
        }

        foreach (GridViewRow row in gvItemList.Rows)
        {
            if (File.Exists(@"\\192.168.10.236\SmartERP_ProductImage\SUNRIZE\INV\" +
                ((Label)row.FindControl("lblItemId")).Text.Trim() + ".jpg"))
            {
                ((Image)row.FindControl("imgItemCover")).ImageUrl = @"data:image/jpg;base64," +
                    Convert.ToBase64String(File.ReadAllBytes(@"\\192.168.10.236\SmartERP_ProductImage\SUNRIZE\INV\" +
                    ((Label)row.FindControl("lblItemId")).Text.Trim() + ".jpg"));
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
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

    protected void gvItemList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //sb.Append(@"<script type='text/javascript'>");
        //sb.Append("$('#imagemodal').modal('show');");
        //sb.Append(@"</script>");


        //lblCoverImageTitle.Text = ((Label)gvItemList.SelectedRow.FindControl("lblItemId")).Text.Trim();
        //imgCoverImage.ImageUrl = ((Image)gvItemList.SelectedRow.FindControl("imgItemCover")).ImageUrl;

        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "initModal", sb.ToString(), false);
    }




    protected void gvItemList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemList.PageIndex = e.NewPageIndex;
        SqlSearch();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ResetParameter();
    }

    private void ResetParameter()
    {
        //txtId_Start.Text = string.Empty;
        txtId_Middle.Text = string.Empty;
        //txtId_End.Text = string.Empty;
        //txtName_Start.Text = string.Empty;
        txtName_Middle.Text = string.Empty;
        //txtName_End.Text = string.Empty;
    }

    protected void imgItemCover_Click(object sender, ImageClickEventArgs e)
    {
        GridViewRow row = (GridViewRow)((ImageButton)sender).NamingContainer;
        ((GridView)row.NamingContainer).SelectedIndex = row.RowIndex;

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#imagemodal').modal('show');");
        sb.Append(@"</script>");

        //lblModalItemId.Text = ((Label)gvItemList.SelectedRow.FindControl("lblItemId")).Text.Trim();
        //lblModalItemName.Text = ((Label)gvItemList.SelectedRow.FindControl("lblItemName")).Text.Trim();
        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //sb.Append(@"<script type='text/javascript'>");
        //sb.Append("$('#itemDetail').modal('show');");
        //sb.Append(@"</script>");
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "initModal", sb.ToString(), false);

        lblCoverImageTitle.Text = ((Label)gvItemList.SelectedRow.FindControl("lblItemId")).Text.Trim();
        imgCoverImage.ImageUrl = ((Image)gvItemList.SelectedRow.FindControl("imgItemCover")).ImageUrl;

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "initModal", sb.ToString(), false);
    }

}