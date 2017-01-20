using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QC_scrap_SP02 : System.Web.UI.Page
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
            ViewState.Clear();
            txtRecycle_Date.ReadOnly = true;
            txtRecycle_Date.CssClass = "read-only";
            ddlDept.Enabled = false;
            ddlType.Enabled = false;
            txtAmount.ReadOnly = true;
            txtAmount.CssClass = "read-only";
            txtPrice.ReadOnly = true;
            txtPrice.CssClass = "read-only";
            txtMemo.ReadOnly = true;
            txtMemo.CssClass = "read-only";
            ViewState["state"] = "new";            
            ViewState["username"] = HttpContext.Current.User.Identity.Name;
            Load_toplink(getPostBackControlName());
        }
        else
        {
            //if (sender == txtAmount)
            //{
            //    txtPrice.Focus();
            //}
            //else if (sender == txtPrice)
            //{
            //    txtMemo.Focus();
            //}
        }
    }
    protected void toplink_add_Click(object sender, ImageClickEventArgs e)
    {
        txtRecycle_Date.Text = "";
        txtRecycle_Date.ReadOnly = false;
        txtRecycle_Date.CssClass = "required-field";
        txtRecycle_Date.Focus();
        ddlDept.Enabled = true;
        ddlType.Enabled = true;
        txtAmount.Text = "";
        txtAmount.ReadOnly = false;
        txtAmount.CssClass = "required-field";
        txtPrice.Text = "";
        txtPrice.ReadOnly = false;
        txtPrice.CssClass = "required-field";
        calculateNet();
        txtMemo.Text = "";
        txtMemo.ReadOnly = false;
        txtMemo.CssClass = "";
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
        string query = "SELECT CONVERT(DATETIME, [RECYCLE_DATE], 112) [RECYCLE_DATE], [DEPARTMENT_ID], [DEPARTMENT_NAME], [TYPE_ID], [TYPE_NAME], [AMOUNT], [UNIT], [PRICE], [MEMO], [CREATOR], [CREATEDATE], [MODIFIER], [MODIFIEDDATE] FROM [SCRAP_SP02_A]";
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
            query_condition += " ORDER BY [RECYCLE_DATE] DESC";
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
        try
        {
            lblErrorMessage.Text = "";
            txtRecycle_Date.Text = Server.HtmlDecode((Convert.ToDateTime((((Label)grdResult.SelectedRow.Cells[0].FindControl("lbl0")).Text)).Date).ToString("yyyyMMdd"));
            txtRecycle_Date.ReadOnly = true;
            txtRecycle_Date.CssClass = "read-only";
            ddlDept.SelectedValue = Server.HtmlDecode(((Label)grdResult.SelectedRow.Cells[1].FindControl("lbl1")).Text);
            ddlDept.Enabled = false;
            ddlType.SelectedValue = Server.HtmlDecode(((Label)grdResult.SelectedRow.Cells[3].FindControl("lbl3")).Text);
            ddlType.Enabled = false;
            txtAmount.Text = Server.HtmlDecode(((Label)grdResult.SelectedRow.Cells[4].FindControl("lbl5")).Text);
            txtAmount.ReadOnly = true;
            txtAmount.CssClass = "read-only";
            lblUnit.Text = Server.HtmlDecode(((Label)grdResult.SelectedRow.Cells[5].FindControl("lbl6")).Text);
            txtPrice.Text = Server.HtmlDecode(((Label)grdResult.SelectedRow.Cells[6].FindControl("lbl7")).Text);
            txtPrice.ReadOnly = true;
            txtPrice.CssClass = "read-only";
            calculateNet();
            if (txtMemo.Text.Trim() == "&nbsp;")
            {
                txtMemo.Text = Server.HtmlDecode(((Label)grdResult.SelectedRow.Cells[8].FindControl("lbl8")).Text.Replace("&nbsp;", ""));
            }
            else
            {
                txtMemo.Text = Server.HtmlDecode(((Label)grdResult.SelectedRow.Cells[8].FindControl("lbl8")).Text);
            }
            txtMemo.ReadOnly = true;
            txtMemo.CssClass = "read-only";
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }

    protected void toplink_edit_Click(object sender, ImageClickEventArgs e)
    {
        txtRecycle_Date.ReadOnly = false;
        txtRecycle_Date.CssClass = "required-field";
        ddlDept.Enabled = true;
        ddlType.Enabled = true;
        txtAmount.ReadOnly = false;
        txtAmount.CssClass = "required-field";
        txtPrice.ReadOnly = false;
        txtPrice.CssClass = "required-field";
        txtMemo.ReadOnly = false;
        txtMemo.CssClass = "";
        ViewState["state"] = "edit";
        ViewState["txtRecycle_Date"] = txtRecycle_Date.Text.Trim();
        ViewState["ddlDept"] = ddlDept.SelectedValue;
        ViewState["ddlType"] = ddlType.SelectedValue;
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
                        SqlCommand cmdSelect = new SqlCommand("SELECT [RECYCLE_DATE] FROM [SCRAP_SP02_A] WHERE [RECYCLE_DATE]=@RECYCLE_DATE AND [DEPARTMENT_ID]=@DEPT_ID AND [TYPE_ID]=@TYPE_ID", conn);
                        cmdSelect.Parameters.AddWithValue("@RECYCLE_DATE", DateTime.ParseExact(txtRecycle_Date.Text.Trim(), "yyyyMMdd", null).ToString("yyyy-MM-dd"));
                        cmdSelect.Parameters.AddWithValue("@DEPT_ID", ddlDept.SelectedValue);
                        cmdSelect.Parameters.AddWithValue("@TYPE_ID", ddlType.SelectedValue);
                        SqlDataReader dr = cmdSelect.ExecuteReader();
                        if (dr.HasRows)
                        {
                            lblErrorMessage.Text = "紀錄已存在，如需變更，請於查詢後修改";
                            txtRecycle_Date.Focus();
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
                            SqlCommand cmdInsert = new SqlCommand("INSERT INTO SCRAP_SP02_A (CREATEDATE, CREATOR, RECYCLE_DATE, DEPARTMENT_ID, DEPARTMENT_NAME, TYPE_ID, TYPE_NAME, AMOUNT, UNIT, PRICE, MEMO)"
                                                                + " VALUES (GETDATE(), @CREATOR, @RECYCLE_DATE, @DEPARTMENT_ID, @DEPARTMENT_NAME, @TYPE_ID, @TYPE_NAME, @AMOUNT, @UNIT, @PRICE, @MEMO)", conn);
                            cmdInsert.Parameters.AddWithValue("@CREATOR", userNameSplit[1]);
                            cmdInsert.Parameters.AddWithValue("@RECYCLE_DATE", DateTime.ParseExact(txtRecycle_Date.Text.Trim(), "yyyyMMdd", null).ToString("yyyy-MM-dd"));
                            cmdInsert.Parameters.AddWithValue("@DEPARTMENT_ID", ddlDept.SelectedValue);
                            cmdInsert.Parameters.AddWithValue("@DEPARTMENT_NAME", ddlDept.SelectedItem.Text);
                            cmdInsert.Parameters.AddWithValue("@TYPE_ID", ddlType.SelectedValue);
                            cmdInsert.Parameters.AddWithValue("@TYPE_NAME", ddlType.SelectedItem.Text);
                            cmdInsert.Parameters.AddWithValue("@AMOUNT", txtAmount.Text.Trim());
                            cmdInsert.Parameters.AddWithValue("@UNIT", lblUnit.Text);
                            cmdInsert.Parameters.AddWithValue("@PRICE", txtPrice.Text.Trim());
                            cmdInsert.Parameters.AddWithValue("@MEMO", txtMemo.Text.Trim());
                            cmdInsert.ExecuteNonQuery();
                            lblErrorMessage.Text = "";
                        }
                        if (!dr.IsClosed)
                        {
                            dr.Close();
                        }
                    }
                }
                else if (ViewState["state"].ToString() == "edit")
                {
                    using (SqlConnection conn = new SqlConnection(ERP2connectionString))
                    {
                        conn.Open();
                        SqlCommand cmdUpdate = new SqlCommand("UPDATE SCRAP_SP02_A SET MODIFIEDDATE=GETDATE(), MODIFIER=@MODIFIER"
                                                            + " , RECYCLE_DATE=@RECYCLE_DATE, DEPARTMENT_ID=@DEPARTMENT_ID, DEPARTMENT_NAME=@DEPARTMENT_NAME, TYPE_ID=@TYPE_ID"
                                                            + " , TYPE_NAME=@TYPE_NAME, AMOUNT=@AMOUNT, UNIT=@UNIT, PRICE=@PRICE, MEMO=@MEMO"
                                                            + " WHERE RECYCLE_DATE=@oriRECYCLE_DATE AND DEPARTMENT_ID=@oriDEPARTMENT_ID AND TYPE_ID=@oriTYPE_ID", conn);
                        cmdUpdate.Parameters.AddWithValue("@MODIFIER", userNameSplit[1]);
                        cmdUpdate.Parameters.AddWithValue("@RECYCLE_DATE", DateTime.ParseExact(txtRecycle_Date.Text.Trim(), "yyyyMMdd", null).ToString("yyyy-MM-dd"));
                        cmdUpdate.Parameters.AddWithValue("@DEPARTMENT_ID", ddlDept.SelectedValue);
                        cmdUpdate.Parameters.AddWithValue("@DEPARTMENT_NAME", ddlDept.SelectedItem.Text);
                        cmdUpdate.Parameters.AddWithValue("@TYPE_ID", ddlType.SelectedValue);
                        cmdUpdate.Parameters.AddWithValue("@TYPE_NAME", ddlType.SelectedItem.Text);
                        cmdUpdate.Parameters.AddWithValue("@AMOUNT", txtAmount.Text.Trim());
                        cmdUpdate.Parameters.AddWithValue("@UNIT", lblUnit.Text);
                        cmdUpdate.Parameters.AddWithValue("@PRICE", txtPrice.Text.Trim());
                        cmdUpdate.Parameters.AddWithValue("@MEMO", txtMemo.Text.Trim());
                        cmdUpdate.Parameters.AddWithValue("@oriRECYCLE_DATE", DateTime.ParseExact(ViewState["txtRecycle_Date"].ToString(), "yyyyMMdd", null).ToString("yyyy-MM-dd"));
                        cmdUpdate.Parameters.AddWithValue("@oriDEPARTMENT_ID", ViewState["ddlDept"].ToString());
                        cmdUpdate.Parameters.AddWithValue("@oriTYPE_ID", ViewState["ddlType"].ToString());
                        cmdUpdate.ExecuteNonQuery();
                        lblErrorMessage.Text = "";
                    }
                }

                txtRecycle_Date.ReadOnly = true;
                txtRecycle_Date.CssClass = "read-only";
                ddlDept.Enabled = false;
                ddlType.Enabled = false;
                txtAmount.ReadOnly = true;
                txtAmount.CssClass = "read-only";
                txtPrice.ReadOnly = true;
                txtPrice.CssClass = "read-only";
                Load_toplink(getPostBackControlName());
            }            
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void toplink_cancel_Click(object sender, ImageClickEventArgs e)
    {
        txtRecycle_Date.Text = "";
        txtRecycle_Date.ReadOnly = true;
        txtRecycle_Date.CssClass = "read-only";
        ddlDept.Enabled = false;
        ddlType.Enabled = false;
        txtAmount.Text = "";
        txtAmount.ReadOnly = true;
        txtAmount.CssClass = "read-only";
        txtPrice.Text = "";
        txtPrice.ReadOnly = true;
        txtPrice.CssClass = "read-only";
        calculateNet();
        txtMemo.Text = "";
        txtMemo.ReadOnly = true;
        txtMemo.CssClass = "read-only";
        lblErrorMessage.Text = "";
        Load_toplink(getPostBackControlName());
    }
    protected void toplink_delete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(ERP2connectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT [RECYCLE_DATE] FROM [SCRAP_SP02_A] WHERE [RECYCLE_DATE]=@RECYCLE_DATE AND [DEPARTMENT_ID]=@DEPT_ID AND [TYPE_ID]=@TYPE_ID", conn);
                cmdSelect.Parameters.AddWithValue("@RECYCLE_DATE", DateTime.ParseExact(txtRecycle_Date.Text.Trim(), "yyyyMMdd", null).ToString("yyyy-MM-dd"));
                cmdSelect.Parameters.AddWithValue("@DEPT_ID", ddlDept.SelectedValue);
                cmdSelect.Parameters.AddWithValue("@TYPE_ID", ddlType.SelectedValue);
                SqlDataReader reader = cmdSelect.ExecuteReader();

                if (reader.HasRows)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    SqlCommand cmdDelete = new SqlCommand("DELETE FROM [SCRAP_SP02_A] WHERE [RECYCLE_DATE]=@RECYCLE_DATE AND [DEPARTMENT_ID]=@DEPT_ID AND [TYPE_ID]=@TYPE_ID", conn);
                    cmdDelete.Parameters.AddWithValue("@RECYCLE_DATE", DateTime.ParseExact(txtRecycle_Date.Text.Trim(), "yyyyMMdd", null).ToString("yyyy-MM-dd"));
                    cmdDelete.Parameters.AddWithValue("@DEPT_ID", ddlDept.SelectedValue);
                    cmdDelete.Parameters.AddWithValue("@TYPE_ID", ddlType.SelectedValue);
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
            txtRecycle_Date.Text = "";
            txtRecycle_Date.ReadOnly = true;
            txtRecycle_Date.CssClass = "read-only";
            ddlDept.Enabled = false;
            ddlType.Enabled = false;
            txtAmount.Text = "";
            txtAmount.ReadOnly = true;
            txtAmount.CssClass = "read-only";
            txtPrice.Text = "";
            txtPrice.ReadOnly = true;
            txtPrice.CssClass = "read-only";
            calculateNet();
            txtMemo.Text = "";
            txtMemo.ReadOnly = true;
            txtMemo.CssClass = "read-only";
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
        DateTime dateVerify;
        double doubleVeryfy;
        if (!DateTime.TryParseExact(txtRecycle_Date.Text.Trim(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateVerify))
        {
            lblErrorMessage.Text = "請確認回收日期正確性";
            txtRecycle_Date.Focus();
            return false;
        }
        else if (!double.TryParse(txtAmount.Text.Trim(), out doubleVeryfy))
        {
            lblErrorMessage.Text = "請確認回收數量正確性";
            txtAmount.Focus();
            return false;
        }
        else if (!double.TryParse(txtPrice.Text.Trim(), out doubleVeryfy))
        {
            lblErrorMessage.Text = "請確認單價正確性";
            txtPrice.Focus();
            return false;
        }
        else if (!double.TryParse(lblNet.Text.Trim(), out doubleVeryfy))
        {
            lblErrorMessage.Text = "總金額未算出";
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

    /*page-specific*/
    protected void calculateNet()
    {
        double amount = 0;
        double price = 0;

        if (double.TryParse(txtAmount.Text.Trim(), out amount) && double.TryParse(txtPrice.Text.Trim(), out price))
        {
            lblNet.Text = Math.Round((amount * price), 0).ToString();
        }
        else
        {
            lblNet.Text = "";
        }
    }

    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {
        calculateNet();
        txtPrice.Focus();
    }
    protected void txtPrice_TextChanged(object sender, EventArgs e)
    {
        calculateNet();
        txtMemo.Focus();
    }
}