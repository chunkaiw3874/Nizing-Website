using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QC_scrap_SP01 : System.Web.UI.Page
{
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    private void Load_toplink(string eventName)
    {
        try
        {
            if (eventName == null)
            {
                toplink_add.Enabled = true;
                toplink_add.CssClass = "";
                toplink_search.Enabled = true;
                toplink_search.CssClass = "";
                toplink_edit.Enabled = false;
                toplink_edit.CssClass = "disabled";
                toplink_save.Enabled = false;
                toplink_save.CssClass = "disabled";
                toplink_cancel.Enabled = false;
                toplink_cancel.CssClass = "disabled";
                toplink_delete.Enabled = false;
                toplink_delete.CssClass = "disabled";
            }
            else if (eventName == "toplink_add")
            {
                toplink_add.Enabled = false;
                toplink_add.CssClass = "disabled";
                toplink_search.Enabled = false;
                toplink_search.CssClass = "disabled";
                toplink_edit.Enabled = false;
                toplink_edit.CssClass = "disabled";
                toplink_save.Enabled = true;
                toplink_save.CssClass = "";
                toplink_cancel.Enabled = true;
                toplink_cancel.CssClass = "";
                toplink_delete.Enabled = false;
                toplink_delete.CssClass = "disabled";
            }
            else if (eventName == "btnSearch_Search")
            {
                toplink_add.Enabled = true;
                toplink_add.CssClass = "";
                toplink_search.Enabled = true;
                toplink_search.CssClass = "";
                if (grdResult.Rows.Count > 0)
                {
                    toplink_edit.Enabled = true;
                    toplink_edit.CssClass = "";
                }
                else
                {
                    toplink_edit.Enabled = false;
                    toplink_edit.CssClass = "disabled";
                }
                toplink_save.Enabled = false;
                toplink_save.CssClass = "disabled";
                toplink_cancel.Enabled = false;
                toplink_cancel.CssClass = "disabled";
                if (grdResult.Rows.Count > 0)
                {                    
                    toplink_delete.Enabled = true;
                    toplink_delete.CssClass = "";
                }
                else
                {
                    toplink_delete.Enabled = false;
                    toplink_delete.CssClass = "disabled";
                }
            }
            else if (eventName == "toplink_edit")
            {
                toplink_add.Enabled = false;
                toplink_add.CssClass = "disabled";
                toplink_search.Enabled = false;
                toplink_search.CssClass = "disabled";
                toplink_edit.Enabled = false;
                toplink_edit.CssClass = "disabled";
                toplink_save.Enabled = true;
                toplink_save.CssClass = "";
                toplink_cancel.Enabled = true;
                toplink_cancel.CssClass = "";
                toplink_delete.Enabled = false;
                toplink_delete.CssClass = "disabled";                
            }
            else if (eventName == "toplink_save")
            {
                toplink_add.Enabled = true;
                toplink_add.CssClass = "";
                toplink_search.Enabled = true;
                toplink_search.CssClass = "";
                if (grdResult.Rows.Count > 0)
                {
                    toplink_edit.Enabled = true;
                    toplink_edit.CssClass = "";
                }
                else
                {
                    toplink_edit.Enabled = false;
                    toplink_edit.CssClass = "disabled";
                }
                toplink_save.Enabled = false;
                toplink_save.CssClass = "disabled";
                toplink_cancel.Enabled = false;
                toplink_cancel.CssClass = "disabled";
                if (grdResult.Rows.Count > 0)
                {
                    toplink_delete.Enabled = true;
                    toplink_delete.CssClass = "";
                }
                else
                {
                    toplink_delete.Enabled = false;
                    toplink_delete.CssClass = "disabled";
                }
            }
            else if (eventName == "toplink_cancel")
            {
                toplink_add.Enabled = true;
                toplink_add.CssClass = "";
                toplink_search.Enabled = true;
                toplink_search.CssClass = "";
                if (grdResult.Rows.Count > 0)
                {
                    toplink_edit.Enabled = true;
                    toplink_edit.CssClass = "";
                }
                else
                {
                    toplink_edit.Enabled = false;
                    toplink_edit.CssClass = "disabled";
                }
                toplink_save.Enabled = false;
                toplink_save.CssClass = "disabled";
                toplink_cancel.Enabled = false;
                toplink_cancel.CssClass = "disabled";
                if (grdResult.Rows.Count > 0)
                {
                    toplink_delete.Enabled = true;
                    toplink_delete.CssClass = "";
                }
                else
                {
                    toplink_delete.Enabled = false;
                    toplink_delete.CssClass = "disabled";
                }
            }
            else if (eventName == "toplink_delete")
            {
                toplink_add.Enabled = true;
                toplink_add.CssClass = "";
                toplink_search.Enabled = true;
                toplink_search.CssClass = "";
                if (grdResult.Rows.Count > 0)
                {
                    toplink_edit.Enabled = true;
                    toplink_edit.CssClass = "";
                }
                else
                {
                    toplink_edit.Enabled = false;
                    toplink_edit.CssClass = "disabled";
                }
                toplink_save.Enabled = false;
                toplink_save.CssClass = "disabled";
                toplink_cancel.Enabled = false;
                toplink_cancel.CssClass = "disabled";
                if (grdResult.Rows.Count > 0)
                {
                    toplink_delete.Enabled = true;
                    toplink_delete.CssClass = "";
                }
                else
                {
                    toplink_delete.Enabled = false;
                    toplink_delete.CssClass = "disabled";
                }
            }            
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    private string getPostBackControlName()
    {
        Control control = null;
        //first we will check the "__EVENTTARGET" because if post back made by       the controls
        //which used "_doPostBack" function also available in Request.Form collection.
        string ctrlname = Page.Request.Params["__EVENTTARGET"];
        if (ctrlname != null && ctrlname != String.Empty)
        {
            control = Page.FindControl(ctrlname);
        }
        // if __EVENTTARGET is null, the control is a button type and we need to
        // iterate over the form collection to find it
        else
        {
            string ctrlStr = String.Empty;
            Control c = null;
            foreach (string ctl in Page.Request.Form)
            {
                //handle ImageButton they having an additional "quasi-property" in their Id which identifies
                //mouse x and y coordinates
                if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                {
                    ctrlStr = ctl.Substring(0, ctl.Length - 2);
                    c = Page.FindControl(ctrlStr);
                }
                else
                {
                    c = Page.FindControl(ctl);
                }
                if (c is System.Web.UI.WebControls.Button ||
                         c is System.Web.UI.WebControls.ImageButton)
                {
                    control = c;
                    break;
                }
            }
        }
        if (control == null)
        {
            return null;
        }
        else
        {
            return control.ID;
        }

    }
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        AddRowSelectToGridView(grdResult);
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
        if (!IsPostBack)
        {
            txtId.ReadOnly = true;
            txtId.CssClass = "read-only";
            txtName.ReadOnly = true;
            txtName.CssClass = "read-only";
            ViewState["state"] = "new";
            ViewState["username"] = HttpContext.Current.User.Identity.Name;            
            Load_toplink(getPostBackControlName());
        }
    }
    protected void toplink_add_Click(object sender, ImageClickEventArgs e)
    {
        txtId.Text = "";
        txtId.ReadOnly = false;
        txtId.CssClass = "required-field";
        txtName.Text = "";
        txtName.ReadOnly = false;
        txtName.CssClass = "required-field";
        ViewState["state"] = "add";
        Load_toplink(getPostBackControlName());
    }
    protected void toplink_search_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["state"] = "search";
    }
    protected void ddlSearch_Item_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSearch_Item.SelectedValue == "CREATEDATE" || ddlSearch_Item.SelectedValue == "MODIFIEDDATE")
        {
            txtSearchContent.Attributes.Add("placeholder", "日期格式為 YYYY-MM-DD");
        }
        else
        {
            txtSearchContent.Attributes.Add("placeholder", "大小寫為不同字元");
        }
    }
    protected void btnSearch_AddCondition_Click(object sender, EventArgs e)
    {
        string[] condition = txtSearchCondition.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        if (ddlOperative.SelectedItem.Value == "LIKE")
        {
            if (condition.Length == 0)
            {
                txtSearchCondition.Text = "[" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'%" + txtSearchContent.Text + "%'";
            }
            else if (rdoAnd.Checked == true)
            {
                txtSearchCondition.Text += "\n" + rdoAnd.Text + " [" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'%" + txtSearchContent.Text + "%'";
            }
            else if (rdoOr.Checked == true)
            {
                txtSearchCondition.Text += "\n" + rdoOr.Text + " [" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'%" + txtSearchContent.Text + "%'";
            }

        }
        else
        {
            if (condition.Length == 0)
            {
                txtSearchCondition.Text = "[" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'" + txtSearchContent.Text + "'";
            }
            else if (rdoAnd.Checked == true)
            {
                txtSearchCondition.Text += "\n" + rdoAnd.Text + " [" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'" + txtSearchContent.Text + "'";
            }
            else if (rdoOr.Checked == true)
            {
                txtSearchCondition.Text += "\n" + rdoOr.Text + " [" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'" + txtSearchContent.Text + "'";
            }
        }
    }
    protected void btnSearch_ClearCondition_Click(object sender, EventArgs e)
    {
        txtSearchCondition.Text = "";
    }
    protected void btnSearch_Search_Click(object sender, EventArgs e)
    {
        string query = "SELECT [ID], [NAME], [CREATOR], [CREATEDATE], [MODIFIER], [MODIFIEDDATE] FROM [SCRAP_SP01_A]";
        string query_condition = "";
        try
        {
            if (txtSearchCondition.Text != "") //有搜尋條件
            {
                query_condition = " WHERE " + txtSearchCondition.Text.Replace("\n", " ").Trim();
            }
            else
            {

            }
            using (SqlConnection conn = new SqlConnection(ERP2connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query + query_condition, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grdResult.DataSource = ds;
                grdResult.DataBind();
                if (grdResult.Rows.Count != 0)
                {
                    grdResult.SelectedIndex = 0;
                    grdResult_SelectedIndexChanged(sender, e);
                }
            }
            Load_toplink(getPostBackControlName());
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }

    }
    protected void grdResult_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblErrorMessage.Text = "";
        txtId.Text = Server.HtmlDecode(((Label)grdResult.SelectedRow.Cells[0].FindControl("lbl0")).Text);
        txtId.ReadOnly = true;
        txtId.CssClass = "read-only";
        txtName.Text = Server.HtmlDecode(((Label)grdResult.SelectedRow.Cells[1].FindControl("lbl1")).Text);
        txtName.ReadOnly = true;
        txtName.CssClass = "read-only";
    }

    protected void toplink_edit_Click(object sender, ImageClickEventArgs e)
    {
        txtId.ReadOnly = true;
        txtId.CssClass = "read-only";
        txtName.ReadOnly = false;
        txtName.CssClass = "required-field";
        ViewState["state"] = "edit";
        Load_toplink(getPostBackControlName());
    }
    protected void toplink_save_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string[] userNameSplit = ViewState["username"].ToString().Split('\\');
            if (checkForAllNecessaryInformation())
            {
                if (ViewState["state"].ToString() == "add") //新增
                { 
                    using (SqlConnection conn = new SqlConnection(ERP2connectionString))
                    {
                        conn.Open();                    
                        
                        //check for duplicates
                        SqlCommand cmdSelect = new SqlCommand("SELECT [ID] FROM [SCRAP_SP01_A] WHERE [ID]=@ID", conn);
                        cmdSelect.Parameters.AddWithValue("@ID", txtId.Text.ToUpper().Trim());
                        SqlDataReader dr = cmdSelect.ExecuteReader();
                        if (dr.HasRows)
                        {
                            lblErrorMessage.Text = "代號已存在";
                            txtId.Focus();
                            if (!dr.IsClosed)
                            {
                                dr.Close();
                            }
                        }
                        else
                        {
                            if (!dr.IsClosed)
                            {
                                dr.Close();
                            }
                            SqlCommand cmdInsert = new SqlCommand("INSERT INTO SCRAP_SP01_A (CREATEDATE, CREATOR, ID, NAME)"
                                                                + " VALUES (GETDATE(), @CREATOR, @ID, @NAME)", conn);                            
                            cmdInsert.Parameters.AddWithValue("@CREATOR", userNameSplit[1]);
                            cmdInsert.Parameters.AddWithValue("@ID", txtId.Text.Trim().ToUpper());
                            cmdInsert.Parameters.AddWithValue("@NAME", txtName.Text.Trim());
                            cmdInsert.ExecuteNonQuery();
                            lblErrorMessage.Text = "";
                        }
                        if(!dr.IsClosed){
                            dr.Close();
                        }
                    }
                }
                else if (ViewState["state"].ToString() == "edit")
                {
                    using (SqlConnection conn = new SqlConnection(ERP2connectionString))
                    {
                        conn.Open();
                        SqlCommand cmdUpdate = new SqlCommand("UPDATE SCRAP_SP01_A SET MODIFIEDDATE=GETDATE(), MODIFIER=@MODIFIER"
                                                            +" ,NAME=@NAME WHERE ID=@ID", conn);
                        cmdUpdate.Parameters.AddWithValue("@MODIFIER", userNameSplit[1]);
                        cmdUpdate.Parameters.AddWithValue("@NAME", txtName.Text.Trim());
                        cmdUpdate.Parameters.AddWithValue("@ID", txtId.Text.Trim().ToUpper());
                        cmdUpdate.ExecuteNonQuery();
                        lblErrorMessage.Text = "";
                    }
                }
                
                txtId.ReadOnly = true;
                txtId.CssClass = "read-only";
                txtName.ReadOnly = true;
                txtName.CssClass = "read-only";
            }
            Load_toplink(getPostBackControlName());
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void toplink_cancel_Click(object sender, ImageClickEventArgs e)
    {
        txtId.Text = "";
        txtId.ReadOnly = true;
        txtId.CssClass = "read-only";
        txtName.Text = "";
        txtName.ReadOnly = true;
        txtName.CssClass = "read-only";
        Load_toplink(getPostBackControlName());
    }
    protected void toplink_delete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(ERP2connectionString))
            {
                SqlCommand cmdSearch = new SqlCommand("SELECT [ID] FROM [SCRAP_SP01_A] WHERE [ID] = @ID", conn);
                cmdSearch.Parameters.AddWithValue("@ID", txtId.Text.ToUpper().Trim());
                conn.Open();
                SqlDataReader reader = cmdSearch.ExecuteReader();

                if (reader.HasRows)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    SqlCommand cmdDelete = new SqlCommand("DELETE FROM [SCRAP_SP01_A] WHERE [ID] = @ID", conn);
                    cmdDelete.Parameters.AddWithValue("@ID", txtId.Text.ToUpper().Trim());
                    cmdDelete.ExecuteNonQuery();
                    //select first item (if exist) on grdResult after successful delete
                    if (grdResult.Rows.Count != 0)
                    {
                        grdResult.SelectedIndex = 0;
                    }
                    else
                    {
                        grdResult.SelectedIndex = -1;
                    }
                    refresh(sender, e);
                    Load_toplink(getPostBackControlName());
                }
                if (!reader.IsClosed)
                {
                    reader.Close();
                }
            }
            txtId.Text = "";
            txtId.ReadOnly = true;
            txtId.CssClass = "read-only";
            txtName.Text = "";
            txtName.ReadOnly = true;
            txtName.CssClass = "read-only";
        }
        catch (SqlException ex)
        {
            switch (ex.Number)
            {
                case 547:
                    lblErrorMessage.Text = "此項目連結至其他資料，不可刪除";
                    break;
                default:
                    lblErrorMessage.Text = "資料刪除錯誤";
                    break;
            }
        }        
    }
    protected bool checkForAllNecessaryInformation()
    {
        if (txtId.Text.Trim() == "")
        {
            lblErrorMessage.Text = "請輸入項目代號";
            return false;
        }
        else if (txtName.Text.Trim() == "")
        {
            lblErrorMessage.Text = "請輸入項目名稱";
            return false;
        }
        else
        {
            return true;
        }
    }
    protected void refresh(object sender, ImageClickEventArgs e)
    {
        if (grdResult.Rows.Count != 0)
        {
            int i = grdResult.SelectedIndex;
            btnSearch_Search_Click(sender, e);
            grdResult.SelectedIndex = i;
        }
    }
}