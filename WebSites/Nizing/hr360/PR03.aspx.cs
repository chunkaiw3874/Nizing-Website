using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class hr360_PR03 : System.Web.UI.Page
{
    //universal functions
    string HR360connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    //functions that do not need change, and needed on every page
    protected DataTable getPagePermission(string pageName)
    {
        try
        {
            DataRow[] dr = ((Session["permission"]) as DataTable).Select("MODULE_ID = '" + pageName + "'");
            DataTable dt = ((Session["permission"]) as DataTable).Clone();
            foreach (DataRow row in dr)
            {
                dt.ImportRow(row);
            }
            return dt;
        }
        catch
        {
            DataTable dtnothing = new DataTable();
            Response.Redirect("~/hr360/no_permission.aspx");
            return dtnothing;
        }
    }
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        AddRowSelectToGridView(grdResult);
        AddRowSelectToGridView(grdForm_Type);
        AddRowSelectToGridView(grdEmployee);
        AddRowSelectToGridView(grdCategory);

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
    private void Load_toplink(string eventName)
    {
        DataTable dt = getPagePermission(System.IO.Path.GetFileName(Request.PhysicalPath).Remove(System.IO.Path.GetFileName(Request.PhysicalPath).Length - 5));

        try
        {
            if (dt.Rows.Count != 0)
            {
                if (eventName == null)
                {
                    //enable and disable toplink base on user permission
                    if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                    {
                        toplink_add.Enabled = true;
                        toplink_add.CssClass = "";
                    }
                    else
                    {
                        toplink_add.Enabled = false;
                        toplink_add.CssClass = "disabled";
                    }
                    if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][8].ToString().ToUpper().Equals("TRUE"))
                    {
                        toplink_search.Enabled = true;
                        toplink_search.CssClass = "";
                    }
                    else
                    {
                        toplink_search.Enabled = false;
                        toplink_search.CssClass = "disabled";
                    }
                    toplink_edit.Enabled = false;
                    toplink_edit.CssClass = "disabled";
                    toplink_delete.Enabled = false;
                    toplink_delete.CssClass = "disabled";
                    toplink_print.Enabled = false;
                    toplink_print.CssClass = "disabled";
                    toplink_first_record.Enabled = false;
                    toplink_first_record.CssClass = "disabled";
                    toplink_previous.Enabled = false;
                    toplink_previous.CssClass = "disabled";
                    toplink_next.Enabled = false;
                    toplink_next.CssClass = "disabled";
                    toplink_last_record.Enabled = false;
                    toplink_last_record.CssClass = "disabled";
                    toplink_save.Enabled = false;
                    toplink_save.CssClass = "disabled";
                    toplink_cancel.Enabled = false;
                    toplink_cancel.CssClass = "disabled";
                    toplink_refresh.Enabled = false;
                    toplink_refresh.CssClass = "disabled";
                    toplink_copy.Enabled = false;
                    toplink_copy.CssClass = "disabled";

                }
                else if (eventName == "toplink_add")
                {
                    toplink_add.Enabled = false;
                    toplink_add.CssClass = "disabled";
                    toplink_search.Enabled = false;
                    toplink_search.CssClass = "disabled";
                    toplink_edit.Enabled = false;
                    toplink_edit.CssClass = "disabled";
                    toplink_delete.Enabled = false;
                    toplink_delete.CssClass = "disabled";
                    toplink_print.Enabled = false;
                    toplink_print.CssClass = "disabled";
                    toplink_first_record.Enabled = false;
                    toplink_first_record.CssClass = "disabled";
                    toplink_previous.Enabled = false;
                    toplink_previous.CssClass = "disabled";
                    toplink_next.Enabled = false;
                    toplink_next.CssClass = "disabled";
                    toplink_last_record.Enabled = false;
                    toplink_last_record.CssClass = "disabled";
                    toplink_save.Enabled = true;
                    toplink_save.CssClass = "";
                    toplink_cancel.Enabled = true;
                    toplink_cancel.CssClass = "";
                    toplink_refresh.Enabled = false;
                    toplink_refresh.CssClass = "disabled";
                    toplink_copy.Enabled = false;
                    toplink_copy.CssClass = "disabled";
                }
                else if (eventName == "btnSearch_Search")
                {
                    if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                    {
                        toplink_add.Enabled = true;
                        toplink_add.CssClass = "";
                    }
                    else
                    {
                        toplink_add.Enabled = false;
                        toplink_add.CssClass = "disabled";
                    }
                    if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][8].ToString().ToUpper().Equals("TRUE"))
                    {
                        toplink_search.Enabled = true;
                        toplink_search.CssClass = "";
                    }
                    else
                    {
                        toplink_search.Enabled = false;
                        toplink_search.CssClass = "disabled";
                    }
                    toplink_save.Enabled = false;
                    toplink_save.CssClass = "disabled";
                    toplink_cancel.Enabled = false;
                    toplink_cancel.CssClass = "disabled";
                    //whether there are still items in search result or not
                    if (grdResult.Rows.Count == 0)
                    {
                        toplink_edit.Enabled = false;
                        toplink_edit.CssClass = "disabled";
                        toplink_print.Enabled = false;
                        toplink_print.CssClass = "disabled";
                        toplink_delete.Enabled = false;
                        toplink_delete.CssClass = "disabled";
                        toplink_first_record.Enabled = false;
                        toplink_first_record.CssClass = "disabled";
                        toplink_previous.Enabled = false;
                        toplink_previous.CssClass = "disabled";
                        toplink_next.Enabled = false;
                        toplink_next.CssClass = "disabled";
                        toplink_last_record.Enabled = false;
                        toplink_last_record.CssClass = "disabled";
                        toplink_refresh.Enabled = false;
                        toplink_refresh.CssClass = "disabled";
                        toplink_copy.Enabled = false;
                        toplink_copy.CssClass = "disabled";
                    }
                    else
                    {
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][9].ToString().ToUpper().Equals("TRUE"))
                        {
                            toplink_edit.Enabled = true;
                            toplink_edit.CssClass = "";
                        }
                        else
                        {
                            toplink_edit.Enabled = false;
                            toplink_edit.CssClass = "disabled";
                        }
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][10].ToString().ToUpper().Equals("TRUE"))
                        {
                            toplink_print.Enabled = true;
                            toplink_print.CssClass = "";
                        }
                        else
                        {
                            toplink_print.Enabled = false;
                            toplink_print.CssClass = "disabled";
                        }
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][11].ToString().ToUpper().Equals("TRUE"))
                        {
                            toplink_delete.Enabled = true;
                            toplink_delete.CssClass = "";
                        }
                        else
                        {
                            toplink_delete.Enabled = false;
                            toplink_delete.CssClass = "disabled";
                        }
                        toplink_first_record.Enabled = true;
                        toplink_first_record.CssClass = "";
                        toplink_previous.Enabled = true;
                        toplink_previous.CssClass = "";
                        toplink_next.Enabled = true;
                        toplink_next.CssClass = "";
                        toplink_last_record.Enabled = true;
                        toplink_last_record.CssClass = "";
                        toplink_refresh.Enabled = true;
                        toplink_refresh.CssClass = "";
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                        {
                            toplink_copy.Enabled = true;
                            toplink_copy.CssClass = "";
                        }
                        else
                        {
                            toplink_copy.Enabled = false;
                            toplink_copy.CssClass = "disabled";
                        }
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
                    toplink_delete.Enabled = false;
                    toplink_delete.CssClass = "disabled";
                    toplink_print.Enabled = false;
                    toplink_print.CssClass = "disabled";
                    toplink_first_record.Enabled = false;
                    toplink_first_record.CssClass = "disabled";
                    toplink_previous.Enabled = false;
                    toplink_previous.CssClass = "disabled";
                    toplink_next.Enabled = false;
                    toplink_next.CssClass = "disabled";
                    toplink_last_record.Enabled = false;
                    toplink_last_record.CssClass = "disabled";
                    toplink_save.Enabled = true;
                    toplink_save.CssClass = "";
                    toplink_cancel.Enabled = true;
                    toplink_cancel.CssClass = "";
                    toplink_refresh.Enabled = false;
                    toplink_refresh.CssClass = "disabled";
                    toplink_copy.Enabled = false;
                    toplink_copy.CssClass = "disabled";
                }
                else if (eventName == "toplink_save")
                {
                    if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                    {
                        toplink_add.Enabled = true;
                        toplink_add.CssClass = "";
                    }
                    else
                    {
                        toplink_add.Enabled = false;
                        toplink_add.CssClass = "disabled";
                    }
                    if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][8].ToString().ToUpper().Equals("TRUE"))
                    {
                        toplink_search.Enabled = true;
                        toplink_search.CssClass = "";
                    }
                    else
                    {
                        toplink_search.Enabled = false;
                        toplink_search.CssClass = "disabled";
                    }
                    toplink_save.Enabled = false;
                    toplink_save.CssClass = "disabled";
                    toplink_cancel.Enabled = false;
                    toplink_cancel.CssClass = "disabled";
                    //whether there are still items in search result or not
                    if (grdResult.Rows.Count == 0)
                    {
                        toplink_edit.Enabled = false;
                        toplink_edit.CssClass = "disabled";
                        toplink_print.Enabled = false;
                        toplink_print.CssClass = "disabled";
                        toplink_delete.Enabled = false;
                        toplink_delete.CssClass = "disabled";
                        toplink_first_record.Enabled = false;
                        toplink_first_record.CssClass = "disabled";
                        toplink_previous.Enabled = false;
                        toplink_previous.CssClass = "disabled";
                        toplink_next.Enabled = false;
                        toplink_next.CssClass = "disabled";
                        toplink_last_record.Enabled = false;
                        toplink_last_record.CssClass = "disabled";
                        toplink_refresh.Enabled = false;
                        toplink_refresh.CssClass = "disabled";
                        toplink_copy.Enabled = false;
                        toplink_copy.CssClass = "disabled";
                    }
                    else
                    {
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][9].ToString().ToUpper().Equals("TRUE"))
                        {
                            toplink_edit.Enabled = true;
                            toplink_edit.CssClass = "";
                        }
                        else
                        {
                            toplink_edit.Enabled = false;
                            toplink_edit.CssClass = "disabled";
                        }
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][10].ToString().ToUpper().Equals("TRUE"))
                        {
                            toplink_print.Enabled = true;
                            toplink_print.CssClass = "";
                        }
                        else
                        {
                            toplink_print.Enabled = false;
                            toplink_print.CssClass = "disabled";
                        }
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][11].ToString().ToUpper().Equals("TRUE"))
                        {
                            toplink_delete.Enabled = true;
                            toplink_delete.CssClass = "";
                        }
                        else
                        {
                            toplink_delete.Enabled = false;
                            toplink_delete.CssClass = "disabled";
                        }
                        toplink_first_record.Enabled = true;
                        toplink_first_record.CssClass = "";
                        toplink_previous.Enabled = true;
                        toplink_previous.CssClass = "";
                        toplink_next.Enabled = true;
                        toplink_next.CssClass = "";
                        toplink_last_record.Enabled = true;
                        toplink_last_record.CssClass = "";
                        toplink_refresh.Enabled = true;
                        toplink_refresh.CssClass = "";
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                        {
                            toplink_copy.Enabled = true;
                            toplink_copy.CssClass = "";
                        }
                        else
                        {
                            toplink_copy.Enabled = false;
                            toplink_copy.CssClass = "disabled";
                        }
                    }
                }
                else if (eventName == "toplink_cancel")
                {
                    if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                    {
                        toplink_add.Enabled = true;
                        toplink_add.CssClass = "";
                    }
                    else
                    {
                        toplink_add.Enabled = false;
                        toplink_add.CssClass = "disabled";
                    }
                    if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][8].ToString().ToUpper().Equals("TRUE"))
                    {
                        toplink_search.Enabled = true;
                        toplink_search.CssClass = "";
                    }
                    else
                    {
                        toplink_search.Enabled = false;
                        toplink_search.CssClass = "disabled";
                    }
                    toplink_save.Enabled = false;
                    toplink_save.CssClass = "disabled";
                    toplink_cancel.Enabled = false;
                    toplink_cancel.CssClass = "disabled";
                    //whether there are still items in search result or not
                    if (grdResult.Rows.Count == 0)
                    {
                        toplink_edit.Enabled = false;
                        toplink_edit.CssClass = "disabled";
                        toplink_print.Enabled = false;
                        toplink_print.CssClass = "disabled";
                        toplink_delete.Enabled = false;
                        toplink_delete.CssClass = "disabled";
                        toplink_first_record.Enabled = false;
                        toplink_first_record.CssClass = "disabled";
                        toplink_previous.Enabled = false;
                        toplink_previous.CssClass = "disabled";
                        toplink_next.Enabled = false;
                        toplink_next.CssClass = "disabled";
                        toplink_last_record.Enabled = false;
                        toplink_last_record.CssClass = "disabled";
                        toplink_refresh.Enabled = false;
                        toplink_refresh.CssClass = "disabled";
                        toplink_copy.Enabled = false;
                        toplink_copy.CssClass = "disabled";
                    }
                    else
                    {
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][9].ToString().ToUpper().Equals("TRUE"))
                        {
                            toplink_edit.Enabled = true;
                            toplink_edit.CssClass = "";
                        }
                        else
                        {
                            toplink_edit.Enabled = false;
                            toplink_edit.CssClass = "disabled";
                        }
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][10].ToString().ToUpper().Equals("TRUE"))
                        {
                            toplink_print.Enabled = true;
                            toplink_print.CssClass = "";
                        }
                        else
                        {
                            toplink_print.Enabled = false;
                            toplink_print.CssClass = "disabled";
                        }
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][11].ToString().ToUpper().Equals("TRUE"))
                        {
                            toplink_delete.Enabled = true;
                            toplink_delete.CssClass = "";
                        }
                        else
                        {
                            toplink_delete.Enabled = false;
                            toplink_delete.CssClass = "disabled";
                        }
                        toplink_first_record.Enabled = true;
                        toplink_first_record.CssClass = "";
                        toplink_previous.Enabled = true;
                        toplink_previous.CssClass = "";
                        toplink_next.Enabled = true;
                        toplink_next.CssClass = "";
                        toplink_last_record.Enabled = true;
                        toplink_last_record.CssClass = "";
                        toplink_refresh.Enabled = true;
                        toplink_refresh.CssClass = "";
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                        {
                            toplink_copy.Enabled = true;
                            toplink_copy.CssClass = "";
                        }
                        else
                        {
                            toplink_copy.Enabled = false;
                            toplink_copy.CssClass = "disabled";
                        }
                    }
                }
                else if (eventName == "toplink_delete")
                {
                    if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                    {
                        toplink_add.Enabled = true;
                        toplink_add.CssClass = "";
                    }
                    else
                    {
                        toplink_add.Enabled = false;
                        toplink_add.CssClass = "disabled";
                    }
                    if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][8].ToString().ToUpper().Equals("TRUE"))
                    {
                        toplink_search.Enabled = true;
                        toplink_search.CssClass = "";
                    }
                    else
                    {
                        toplink_search.Enabled = false;
                        toplink_search.CssClass = "disabled";
                    }
                    toplink_save.Enabled = false;
                    toplink_save.CssClass = "disabled";
                    toplink_cancel.Enabled = false;
                    toplink_cancel.CssClass = "disabled";
                    //whether there are still items in search result or not
                    if (grdResult.Rows.Count == 0)
                    {
                        toplink_edit.Enabled = false;
                        toplink_edit.CssClass = "disabled";
                        toplink_print.Enabled = false;
                        toplink_print.CssClass = "disabled";
                        toplink_delete.Enabled = false;
                        toplink_delete.CssClass = "disabled";
                        toplink_first_record.Enabled = false;
                        toplink_first_record.CssClass = "disabled";
                        toplink_previous.Enabled = false;
                        toplink_previous.CssClass = "disabled";
                        toplink_next.Enabled = false;
                        toplink_next.CssClass = "disabled";
                        toplink_last_record.Enabled = false;
                        toplink_last_record.CssClass = "disabled";
                        toplink_refresh.Enabled = false;
                        toplink_refresh.CssClass = "disabled";
                        toplink_copy.Enabled = false;
                        toplink_copy.CssClass = "disabled";
                    }
                    else
                    {
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][9].ToString().ToUpper().Equals("TRUE"))
                        {
                            toplink_edit.Enabled = true;
                            toplink_edit.CssClass = "";
                        }
                        else
                        {
                            toplink_edit.Enabled = false;
                            toplink_edit.CssClass = "disabled";
                        }
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][10].ToString().ToUpper().Equals("TRUE"))
                        {
                            toplink_print.Enabled = true;
                            toplink_print.CssClass = "";
                        }
                        else
                        {
                            toplink_print.Enabled = false;
                            toplink_print.CssClass = "disabled";
                        }
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][11].ToString().ToUpper().Equals("TRUE"))
                        {
                            toplink_delete.Enabled = true;
                            toplink_delete.CssClass = "";
                        }
                        else
                        {
                            toplink_delete.Enabled = false;
                            toplink_delete.CssClass = "disabled";
                        }
                        toplink_first_record.Enabled = true;
                        toplink_first_record.CssClass = "";
                        toplink_previous.Enabled = true;
                        toplink_previous.CssClass = "";
                        toplink_next.Enabled = true;
                        toplink_next.CssClass = "";
                        toplink_last_record.Enabled = true;
                        toplink_last_record.CssClass = "";
                        toplink_refresh.Enabled = true;
                        toplink_refresh.CssClass = "";
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                        {
                            toplink_copy.Enabled = true;
                            toplink_copy.CssClass = "";
                        }
                        else
                        {
                            toplink_copy.Enabled = false;
                            toplink_copy.CssClass = "disabled";
                        }
                    }
                }
                else if (eventName == "toplink_copy")
                {
                    toplink_add.Enabled = false;
                    toplink_add.CssClass = "disabled";
                    toplink_search.Enabled = false;
                    toplink_search.CssClass = "disabled";
                    toplink_edit.Enabled = false;
                    toplink_edit.CssClass = "disabled";
                    toplink_delete.Enabled = false;
                    toplink_delete.CssClass = "disabled";
                    toplink_print.Enabled = false;
                    toplink_print.CssClass = "disabled";
                    toplink_first_record.Enabled = false;
                    toplink_first_record.CssClass = "disabled";
                    toplink_previous.Enabled = false;
                    toplink_previous.CssClass = "disabled";
                    toplink_next.Enabled = false;
                    toplink_next.CssClass = "disabled";
                    toplink_last_record.Enabled = false;
                    toplink_last_record.CssClass = "disabled";
                    toplink_save.Enabled = true;
                    toplink_save.CssClass = "";
                    toplink_cancel.Enabled = true;
                    toplink_cancel.CssClass = "";
                    toplink_refresh.Enabled = false;
                    toplink_refresh.CssClass = "disabled";
                    toplink_copy.Enabled = false;
                    toplink_copy.CssClass = "disabled";
                }
            }
        }
        catch
        {

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

    void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["txtForm_Type_Id"] = txtForm_Type_Id.Text.ToUpper().Trim();
        ViewState["lblForm_Type_Name"] = lblForm_Type_Name.Text;
        ViewState["txtId"] = txtId.Text.ToUpper().Trim();
        ViewState["txtDate"] = txtDate.Text.Trim();
        ViewState["txtEmployee_Id"] = txtEmployee_Id.Text.Trim().ToUpper();
        ViewState["lblEmployee_Name"] = lblEmployee_Name.Text;
        ViewState["txtCategory_Id"] = txtCategory_Id.Text.Trim().ToUpper();
        ViewState["txtCategory_Name"] = txtCategory_Name.Text;
        ViewState["txtCategory_Description"] = txtCategory_Description.Text;
        ViewState["ddlSeverity"] = ddlSeverity.SelectedValue.ToString();
        ViewState["txtAmount"] = txtAmount.Text.Trim();
        ViewState["ddlClear_Method"] = ddlClear_Method.SelectedValue.ToString();
        ViewState["txtDescription"] = txtDescription.Text.Trim();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.Attributes.Add("enctype", "multipart/form-data");
        if (!IsPostBack)
        {
            txtForm_Type_Id.Text = "";
            txtForm_Type_Id.ReadOnly = true;
            txtForm_Type_Id.CssClass = "read-only";
            btnForm_Type_Select.Enabled = false;
            lblForm_Type_Name.Text = "";
            txtId.Text = "";
            txtDate.Text = "";
            txtDate.ReadOnly = true;
            txtDate.CssClass = "read-only";
            txtEmployee_Id.Text = "";
            txtEmployee_Id.ReadOnly = true;
            txtEmployee_Id.CssClass = "read-only";
            btnEmployee_Select.Enabled = false;
            lblEmployee_Name.Text = "";
            txtCategory_Id.Text = "";
            txtCategory_Id.ReadOnly = true;
            txtCategory_Id.CssClass = "read-only";
            txtCategory_Name.Text = "";
            txtCategory_Description.Text = "";
            ddlSeverity.Enabled = false;
            txtAmount.Text = "";
            txtAmount.ReadOnly = true;
            txtAmount.CssClass = "read-only";
            ddlClear_Method.Enabled = false;
            txtDescription.Text = "";
            txtDescription.ReadOnly = true;
            txtDescription.CssClass = "read-only";
            lbxAttachment.Items.Clear();          
            btnUpload.Enabled = false;
            btnDelete.Enabled = false;
            lblErrorMessage.Text = "";

            Load_toplink(getPostBackControlName());
        }
        else
        {

        }
    }
    protected void toplink_add_Click(object sender, EventArgs e)
    {
        txtForm_Type_Id.Text = "";
        txtForm_Type_Id.ReadOnly = false;
        txtForm_Type_Id.CssClass = "required-field";
        btnForm_Type_Select.Enabled = true;
        lblForm_Type_Name.Text = "";
        txtId.Text = "";
        txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
        txtDate.ReadOnly = false;
        txtDate.CssClass = "required-field";
        txtEmployee_Id.Text = "";
        txtEmployee_Id.ReadOnly = false;
        txtEmployee_Id.CssClass = "required-field";
        btnEmployee_Select.Enabled = true;
        lblEmployee_Name.Text = "";
        txtCategory_Id.Text = "";
        txtCategory_Id.ReadOnly = false;
        txtCategory_Id.CssClass = "required-field";
        btnCategory_Select.Enabled = true;
        txtCategory_Name.Text = "";
        txtCategory_Description.Text = "";
        ddlSeverity.Enabled = true;
        txtAmount.Text = "";
        txtAmount.ReadOnly = false;
        txtAmount.CssClass = "required-field";
        ddlClear_Method.Enabled = true;
        txtDescription.Text = "";
        txtDescription.ReadOnly = false;
        txtDescription.CssClass = "";
        lbxAttachment.Items.Clear();
        btnUpload.Enabled = true;
        btnDelete.Enabled = true;
        lblErrorMessage.Text = "";

        //disable grdResult while in edit mode
        grdResult.Enabled = false;

        Load_toplink(getPostBackControlName());
    }
    //search-related functions
    protected void toplink_search_Click(object sender, EventArgs e)
    {
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
        string query = "SELECT [FORM_TYPE_ID] 獎懲單別, [FORM_TYPE_NAME] 獎懲單別名稱, [ID] 獎懲單號, [DATE] 獎懲日期, [EMPLOYEE_ID] 員工代號, [EMPLOYEE_NAME] 員工姓名, [CATEGORY_ID] 獎懲項目代號, [CATEGORY_NAME] 獎懲項目名稱, [DESCRIPTION] 獎懲項目說明, [DESCRIPTION] 細項說明, [SEVERITY] 輕重等級, [AMOUNT] 獎懲金額, [CLEAR_METHOD] 結清方式, [CREATEDATE] 建立日期, [CREATOR] 建立者, [MODIFIEDDATE] 修改日期, [MODIFIER] 修改者 FROM [HR360_PR03_A]";
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
            query_condition += " ORDER BY [HR360_PR03_A].[FORM_TYPE_ID] ASC, [HR360_PR03_A].[ID] DESC";
            using (SqlConnection conn = new SqlConnection(HR360connectionString))
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
        txtForm_Type_Id.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[0].Text);
        txtForm_Type_Id.ReadOnly = true;
        txtForm_Type_Id.CssClass = "read-only";
        btnForm_Type_Select.Enabled = false;
        lblForm_Type_Name.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[1].Text);
        txtId.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[2].Text);
        txtDate.Text = Convert.ToDateTime(Server.HtmlDecode(grdResult.SelectedRow.Cells[3].Text)).ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
        txtDate.ReadOnly = true;
        txtDate.CssClass = "read-only";
        txtEmployee_Id.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[4].Text);
        txtEmployee_Id.ReadOnly = true;
        txtEmployee_Id.CssClass = "read-only";
        btnEmployee_Select.Enabled = false;
        lblEmployee_Name.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[5].Text);
        txtCategory_Id.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[6].Text);
        txtCategory_Id.ReadOnly = true;
        txtCategory_Id.CssClass = "read-only";
        btnCategory_Select.Enabled = false;
        txtCategory_Name.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[7].Text);
        txtCategory_Description.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[8].Text);
        txtDescription.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[9].Text);
        txtDescription.ReadOnly = true;
        txtDescription.CssClass = "read-only";
        ddlSeverity.SelectedValue = Server.HtmlDecode(grdResult.SelectedRow.Cells[10].Text);
        ddlSeverity.Enabled = false;
        txtAmount.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[11].Text);
        txtAmount.ReadOnly = true;
        txtAmount.CssClass = "read-only";
        ddlClear_Method.SelectedValue = Server.HtmlDecode(grdResult.SelectedRow.Cells[12].Text);
        ddlClear_Method.Enabled = false;
        //load attachment list
        DataTable dt = new DataTable();
        lbxAttachment.Items.Clear();
        using (SqlConnection conn = new SqlConnection(HR360connectionString))
        {
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT [FILE_URL] FROM [HR360_PR03_B] WHERE [FORM_TYPE_ID]=@FORM_TYPE_ID AND [FORM_ID]=@FORM_ID", conn);
            cmdSelect.Parameters.AddWithValue("@FORM_TYPE_ID", txtForm_Type_Id.Text.Trim().ToUpper());
            cmdSelect.Parameters.AddWithValue("@FORM_ID", txtId.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
            da.Fill(dt);
        }
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                lbxAttachment.Items.Add(Path.GetFileName(row[0].ToString()));
            }
        }
        btnUpload.Enabled = false;
        btnDelete.Enabled = false;
    }
    //
    protected void toplink_edit_Click(object sender, EventArgs e)
    {
        if (txtForm_Type_Id.Text.Trim() == "")
        {
            lblErrorMessage.Text = "需先選擇單別後才能進行修改，修改時不得更改代號";
            txtForm_Type_Id.ReadOnly = false;
            txtForm_Type_Id.CssClass = "required-field";
            txtForm_Type_Id.Focus();
            btnForm_Type_Select.Enabled = true;
        }
        else
        {
            lblErrorMessage.Text = "";
            txtForm_Type_Id.ReadOnly = true;
            txtForm_Type_Id.CssClass = "read-only";
            btnForm_Type_Select.Enabled = false;
            txtDate.ReadOnly = false;
            txtDate.CssClass = "required-field";
            txtEmployee_Id.ReadOnly = false;
            txtEmployee_Id.CssClass = "required-field";
            btnEmployee_Select.Enabled = true;
            txtCategory_Id.ReadOnly = false;
            txtCategory_Id.CssClass = "required-field";
            btnCategory_Select.Enabled = true;
            ddlSeverity.Enabled = true;
            txtAmount.ReadOnly = false;
            txtAmount.CssClass = "required-field";
            ddlClear_Method.Enabled = true;
            txtDescription.ReadOnly = false;
            txtDescription.CssClass = "";
            btnUpload.Enabled = true;
            btnDelete.Enabled = true;
        }
        //disable gridview while editing
        grdResult.Enabled = false;

        Load_toplink(getPostBackControlName());
    }
    protected void toplink_print_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void toplink_first_record_Click(object sender, ImageClickEventArgs e)
    {
        if (grdResult.Rows.Count != 0)
        {
            grdResult.SelectedIndex = 0;
            grdResult_SelectedIndexChanged(sender, e);
        }
    }
    protected void toplink_previous_Click(object sender, ImageClickEventArgs e)
    {
        if (grdResult.Rows.Count != 0)
        {
            if (grdResult.SelectedIndex > 0)
            {
                grdResult.SelectedIndex--;
                grdResult_SelectedIndexChanged(sender, e);
            }
        }
    }
    protected void toplink_next_Click(object sender, ImageClickEventArgs e)
    {
        if (grdResult.Rows.Count != 0)
        {
            if (grdResult.SelectedIndex < grdResult.Rows.Count - 1)
            {
                grdResult.SelectedIndex++;
                grdResult_SelectedIndexChanged(sender, e);
            }
        }
    }
    protected void toplink_last_record_Click(object sender, ImageClickEventArgs e)
    {
        if (grdResult.Rows.Count != 0)
        {
            grdResult.SelectedIndex = grdResult.Rows.Count - 1;
            grdResult_SelectedIndexChanged(sender, e);
        }
    }
    protected void toplink_save_Click(object sender, EventArgs e)
    {
        bool isMatchFormType = false;
        bool isMatchEmployeeId = false;
        bool isMatchCategoryId = false;
        int i;
        DateTime dateValue;
        using (SqlConnection conn = new SqlConnection(HR360connectionString))
        {
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT [ID] FROM [HR360_PR01_A] WHERE [ID]=@ID", conn);
            cmdSelect.Parameters.AddWithValue("@ID", txtForm_Type_Id.Text.Trim().ToUpper());
            SqlDataReader dr = cmdSelect.ExecuteReader();
            if (dr.HasRows)
            {
                isMatchFormType = true;
            }
            if (!dr.IsClosed)
            {
                dr.Close();
            }
        }
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT [MV001] FROM [CMSMV] WHERE [MV001]=@ID", conn);
            cmdSelect.Parameters.AddWithValue("@ID", txtEmployee_Id.Text.Trim().ToUpper());
            SqlDataReader dr = cmdSelect.ExecuteReader();
            if (dr.HasRows)
            {
                isMatchEmployeeId = true;
            }
            if (!dr.IsClosed)
            {
                dr.Close();
            }
        }
        using (SqlConnection conn = new SqlConnection(HR360connectionString))
        {
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT [ID] FROM [HR360_PR02_A] WHERE [ID]=@ID", conn);
            cmdSelect.Parameters.AddWithValue("@ID", txtCategory_Id.Text.Trim().ToUpper());
            SqlDataReader dr = cmdSelect.ExecuteReader();
            if (dr.HasRows)
            {
                isMatchCategoryId = true;
            }
            if (!dr.IsClosed)
            {
                dr.Close();
            }
        }
        if (txtForm_Type_Id.Text.Trim() == "" || !isMatchFormType)
        {
            lblErrorMessage.Text = "請選擇正確的單別代號";
            txtForm_Type_Id.ReadOnly = false;
            txtForm_Type_Id.CssClass = "required-field";
            btnForm_Type_Select.Enabled = true;
        }
        else if(!DateTime.TryParseExact(txtDate.Text.Trim().ToUpper(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
        {
            lblErrorMessage.Text = "日期不符合yyyy/MM/dd的格式";
            txtDate.ReadOnly = false;
            txtDate.CssClass = "required-field";
            txtDate.Focus();
        }
        else if (txtEmployee_Id.Text.Trim() == "" || !isMatchEmployeeId)
        {
            lblErrorMessage.Text = "請選擇正確的員工代號";
            txtEmployee_Id.ReadOnly = false;
            txtEmployee_Id.CssClass = "required-field";
            txtEmployee_Id.Focus();
            btnEmployee_Select.Enabled = true;
        }
        else if (txtCategory_Id.Text.Trim() == "" || !isMatchCategoryId)
        {
            lblErrorMessage.Text = "請選擇正確的項目代號";
            txtCategory_Id.ReadOnly = false;
            txtCategory_Id.CssClass = "required-field";
            txtCategory_Id.Focus();
            btnCategory_Select.Enabled = true;
        }
        else if(!Int32.TryParse(txtAmount.Text, out i))
        {
            lblErrorMessage.Text = "獎懲金額須為整數";
            txtAmount.ReadOnly = false;
            txtAmount.CssClass = "required-field";
            txtAmount.Focus();
        }
        else
        {
            try
            {
                if (txtForm_Type_Id.ReadOnly == false) //新增
                {
                    using (SqlConnection conn = new SqlConnection(HR360connectionString))
                    {
                        SqlCommand cmdDuplicateSearch = new SqlCommand("SELECT [ID] FROM [HR360_PR03_A] WHERE [ID] = @ID AND [FORM_TYPE_ID]=@FORMTYPEID", conn);
                        cmdDuplicateSearch.Parameters.AddWithValue("@FORMTYPEID", txtForm_Type_Id.Text.Trim().ToUpper());
                        cmdDuplicateSearch.Parameters.AddWithValue("@ID", txtId.Text.ToUpper().Trim());
                        conn.Open();
                        SqlDataReader reader = cmdDuplicateSearch.ExecuteReader();

                        if (reader.HasRows)
                        {
                            lblErrorMessage.Text = "此代號已存在，已自動更新成最新單號，請再儲存一次";
                            if (!reader.IsClosed)
                            {
                                reader.Close();
                            }
                            //更新代號
                            DataTable dt = new DataTable();
                            SqlCommand cmdSelect = new SqlCommand("SELECT [PR01_A].[ID], [HR360_PR01_A].[NAME], [HR360_PR01_A].[CODE_FORMAT] FROM [HR360_PR01_A] LEFT JOIN [HR360_PR03_A] ON [HR360_PR01_A].[ID] = [HR360_PR03_A].[FORM_TYPE_ID] WHERE [HR360_PR01_A].[FORM_TYPE] = N'PR03: 獎懲罰建立作業' AND [HR360_PR01_A].[ID]=@ID", conn);
                            cmdSelect.Parameters.AddWithValue("@ID", txtForm_Type_Id.Text.Trim().ToUpper());
                            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                            da.Fill(dt);

                            string code_format = dt.Rows[0][2].ToString();                                
                            int year = 0;                                
                            int day = 0;
                            int seq = 0;
                            foreach (char c in code_format)
                            {
                                if (c == 'Y')
                                {
                                    year += 1;
                                }
                                else if (c == 'D')
                                {
                                    day += 1;
                                }
                                else if (c == '9')
                                {
                                    seq += 1;
                                }
                            }
                            string seqNo = txtDate.Text.Substring(4 - year, year) + txtDate.Text.Substring(5, 2);
                            if (day != 0)
                            {
                                seqNo += txtDate.Text.Substring(8, 2);
                            }

                            //check for the highest ID with the same Code prior to 流水號
                            dt = new DataTable();

                            cmdSelect = new SqlCommand("SELECT [HR360_PR03_A].[ID] FROM [HR360_PR03_A] LEFT JOIN [HR360_PR01_A] ON [HR360_PR03_A].[FORM_TYPE_ID] = [HR360_PR01_A].[ID] WHERE [PR01_A].[FORM_TYPE] = N'PR03: 獎懲罰建立作業' AND [HR360_PR03_A].[FORM_TYPE_ID]=@FORMTYPEID AND [HR360_PR03_A].[ID] LIKE @PRO3AID ORDER BY [HR360_PR03_A].[ID] DESC", conn);
                            cmdSelect.Parameters.AddWithValue("@FORMTYPEID", txtForm_Type_Id.Text.Trim().ToUpper());
                            cmdSelect.Parameters.AddWithValue("@PRO3AID", seqNo + "%");
                            da = new SqlDataAdapter(cmdSelect);
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0][0] != null)
                                {
                                    seqNo += (Convert.ToInt32(dt.Rows[0][0].ToString().Substring(dt.Rows[0][0].ToString().Count() - seq, seq)) + 1).ToString().PadLeft(seq, '0');
                                }
                            }
                            else
                            {
                                seqNo += "1".PadLeft(seq, '0');
                            }
                            txtId.Text = seqNo.Trim();
                        }
                        else
                        {
                            if (!reader.IsClosed)
                            {
                                reader.Close();
                            }
                            //insert form record
                            SqlCommand cmdInsert = new SqlCommand("INSERT INTO [HR360_PR03_A] VALUES (GETDATE(), @CREATOR, GETDATE(), @MODIFIER, @FORM_TYPE_ID, @FORM_TYPE_NAME, @ID, @DATE, @EMPLOYEE_ID, @EMPLOYEE_NAME, @CATEGORY_ID, @CATEGORY_NAME, @CATEGORY_DESCRIPTION, @SEVERITY, @AMOUNT, @CLEAR_METHOD, @DESCRIPTION)", conn);
                            cmdInsert.Parameters.AddWithValue("@CREATOR", Session["user_id"]);
                            cmdInsert.Parameters.AddWithValue("@MODIFIER", Session["user_id"]);
                            cmdInsert.Parameters.AddWithValue("@FORM_TYPE_ID", txtForm_Type_Id.Text.ToUpper().Trim());
                            cmdInsert.Parameters.AddWithValue("@FORM_TYPE_NAME", lblForm_Type_Name.Text);
                            cmdInsert.Parameters.AddWithValue("@ID", txtId.Text.ToUpper().Trim());
                            cmdInsert.Parameters.AddWithValue("@DATE", txtDate.Text.Trim().Replace('/', '-'));
                            cmdInsert.Parameters.AddWithValue("@EMPLOYEE_ID", txtEmployee_Id.Text.ToUpper().Trim());
                            cmdInsert.Parameters.AddWithValue("@EMPLOYEE_NAME", lblEmployee_Name.Text);
                            cmdInsert.Parameters.AddWithValue("@CATEGORY_ID", txtCategory_Id.Text.ToUpper().Trim());
                            cmdInsert.Parameters.AddWithValue("@CATEGORY_NAME", txtCategory_Name.Text.Trim());
                            cmdInsert.Parameters.AddWithValue("@CATEGORY_DESCRIPTION", txtCategory_Description.Text.Trim());
                            cmdInsert.Parameters.AddWithValue("@SEVERITY", ddlSeverity.SelectedValue.ToString());
                            cmdInsert.Parameters.AddWithValue("@AMOUNT", txtAmount.Text.Trim());
                            cmdInsert.Parameters.AddWithValue("@CLEAR_METHOD", ddlClear_Method.SelectedValue.ToString());
                            cmdInsert.Parameters.AddWithValue("@DESCRIPTION", txtDescription.Text.Trim());
                            cmdInsert.ExecuteNonQuery();
                            
                            lblErrorMessage.Text = "";
                            //enable grdResult after click                            
                            grdResult.Enabled = true;

                            Load_toplink(getPostBackControlName());
                        }
                    }
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(HR360connectionString))
                    {
                        conn.Open();
                        SqlCommand cmdUpdate = new SqlCommand("UPDATE [HR360_PR03_A] SET [MODIFIEDDATE]=GETDATE(), [MODIFIER] = @MODIFIER, [DATE]=@DATE, [EMPLOYEE_ID]=@EMPLOYEE_ID, [EMPLOYEE_NAME]=@EMPLOYEE_NAME, [CATEGORY_ID]=@CATEGORY_ID, [CATEGORY_NAME]=@CATEGORY_NAME, [CATEGORY_DESCRIPTION]=@CATEGORY_DESCRIPTION, [SEVERITY]=@SEVERITY, [AMOUNT]=@AMOUNT, [CLEAR_METHOD]=@CLEAR_METHOD, [DESCRIPTION]=@DESCRIPTION WHERE [ID]=@ID AND [FORM_TYPE_ID]=@FORM_TYPE_ID", conn);
                        cmdUpdate.Parameters.AddWithValue("@MODIFIER", Session["user_id"]);
                        cmdUpdate.Parameters.AddWithValue("@FORM_TYPE_ID", txtForm_Type_Id.Text.ToUpper().Trim());
                        cmdUpdate.Parameters.AddWithValue("@ID", txtId.Text.ToUpper().Trim());
                        cmdUpdate.Parameters.AddWithValue("@DATE", txtDate.Text.Trim().Replace('/', '-'));
                        cmdUpdate.Parameters.AddWithValue("@EMPLOYEE_ID", txtEmployee_Id.Text.ToUpper().Trim());
                        cmdUpdate.Parameters.AddWithValue("@EMPLOYEE_NAME", lblEmployee_Name.Text);
                        cmdUpdate.Parameters.AddWithValue("@CATEGORY_ID", txtCategory_Id.Text.ToUpper().Trim());
                        cmdUpdate.Parameters.AddWithValue("@CATEGORY_NAME", txtCategory_Name.Text.Trim());
                        cmdUpdate.Parameters.AddWithValue("@CATEGORY_DESCRIPTION", txtCategory_Description.Text.Trim());
                        cmdUpdate.Parameters.AddWithValue("@SEVERITY", ddlSeverity.SelectedValue.ToString());
                        cmdUpdate.Parameters.AddWithValue("@AMOUNT", txtAmount.Text.Trim());
                        cmdUpdate.Parameters.AddWithValue("@CLEAR_METHOD", ddlClear_Method.SelectedValue.ToString());
                        cmdUpdate.Parameters.AddWithValue("@DESCRIPTION", txtDescription.Text.Trim());
                        cmdUpdate.ExecuteNonQuery();

                        lblErrorMessage.Text = "";
                        //enable grdResult after click
                        grdResult.Enabled = true;
                        Load_toplink(getPostBackControlName());
                    }
                }
                txtForm_Type_Id.ReadOnly = true;
                txtForm_Type_Id.CssClass = "read-only";
                btnForm_Type_Select.Enabled = false;
                txtDate.ReadOnly = true;
                txtDate.CssClass = "read-only";
                txtEmployee_Id.ReadOnly = true;
                txtEmployee_Id.CssClass = "read-only";
                btnEmployee_Select.Enabled = false;
                txtCategory_Id.ReadOnly = true;
                txtCategory_Id.CssClass = "read-only";
                btnCategory_Select.Enabled = false;
                ddlSeverity.Enabled = false;
                txtAmount.ReadOnly = true;
                txtAmount.CssClass = "read-only";
                ddlClear_Method.Enabled = false;
                txtDescription.ReadOnly = true;
                txtDescription.CssClass = "read-only";
                btnUpload.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.ToString();
            }
        }
    }
    protected void toplink_cancel_Click(object sender, EventArgs e)
    {
        lblErrorMessage.Text = "";
        txtForm_Type_Id.Text = "";
        txtForm_Type_Id.ReadOnly = true;
        txtForm_Type_Id.CssClass = "read-only";
        btnForm_Type_Select.Enabled = false;
        lblForm_Type_Name.Text = "";
        txtId.Text = "";
        txtDate.Text = "";
        txtDate.ReadOnly = true;
        txtDate.CssClass = "read-only";
        txtEmployee_Id.Text = "";
        txtEmployee_Id.ReadOnly = true;
        txtEmployee_Id.CssClass = "read-only";
        btnEmployee_Select.Enabled = false;
        lblEmployee_Name.Text = "";
        txtCategory_Id.Text = "";
        txtCategory_Id.ReadOnly = true;
        txtCategory_Id.CssClass = "read-only";
        btnCategory_Select.Enabled = false;
        txtCategory_Name.Text = "";
        txtCategory_Description.Text = "";
        ddlSeverity.SelectedIndex = 0;
        ddlSeverity.Enabled = false;
        txtAmount.Text = "";
        txtAmount.ReadOnly = true;
        txtAmount.CssClass = "read-only";
        ddlClear_Method.SelectedIndex = 0;
        ddlClear_Method.Enabled = false;
        txtDescription.Text = "";
        txtDescription.ReadOnly = true;
        txtDescription.CssClass = "read-only";
        lbxAttachment.Items.Clear();
        btnUpload.Enabled = false;
        btnDelete.Enabled = false;

        //enable grdResult after click
        grdResult.Enabled = true;

        Load_toplink(getPostBackControlName());
    }
    protected void toplink_delete_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(HR360connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ID] FROM [HR360_PR03_A] WHERE [ID] = @ID AND [FORM_TYPE_ID]=@FORMTYPEID", conn);
                cmd.Parameters.AddWithValue("@FORMTYPEID", txtForm_Type_Id.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@ID", txtId.Text.ToUpper().Trim());
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    SqlCommand cmdDelete = new SqlCommand("DELETE FROM [HR360_PR03_B] WHERE [FORM_ID] = @ID AND [FORM_TYPE_ID]=@FORMTYPEID", conn);
                    cmdDelete.Parameters.AddWithValue("@FORMTYPEID", txtForm_Type_Id.Text.Trim().ToUpper());
                    cmdDelete.Parameters.AddWithValue("@ID", txtId.Text.ToUpper().Trim());
                    cmdDelete.ExecuteNonQuery();
                    string directory = @"~/HR360/PR03_attachment/" + txtForm_Type_Id.Text.Trim().ToUpper() + @"/" + txtId.Text.Trim() + @"/";
                    string[] files = Directory.GetFiles(Server.MapPath(directory));
                    foreach (string str in files)
                    {
                        File.Delete(str);
                    }
                    cmdDelete = new SqlCommand("DELETE FROM [HR360_PR03_A] WHERE [ID] = @ID AND [FORM_TYPE_ID]=@FORMTYPEID", conn);
                    cmdDelete.Parameters.AddWithValue("@FORMTYPEID", txtForm_Type_Id.Text.Trim().ToUpper());
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
                    toplink_refresh_Click(sender, (ImageClickEventArgs)e);

                    lblErrorMessage.Text = "";
                    
                    txtForm_Type_Id.Text = "";
                    lblForm_Type_Name.Text = "";
                    txtId.Text = "";
                    txtDate.Text = "";
                    txtEmployee_Id.Text = "";
                    lblEmployee_Name.Text = "";
                    txtCategory_Id.Text = "";
                    txtCategory_Name.Text = "";
                    txtCategory_Description.Text = "";
                    txtAmount.Text = "";
                    txtDescription.Text = "";

                    Load_toplink(getPostBackControlName());
                }
                else
                {
                    lblErrorMessage.Text = "此項目代號不存在";
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }
            }
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
        txtForm_Type_Id.ReadOnly = true;
        txtForm_Type_Id.CssClass = "read-only";
        btnForm_Type_Select.Enabled = false;
        txtDate.ReadOnly = true;
        txtDate.CssClass = "read-only";
        txtEmployee_Id.ReadOnly = true;
        txtEmployee_Id.CssClass = "read-only";
        btnEmployee_Select.Enabled = false;
        txtCategory_Id.ReadOnly = true;
        txtCategory_Id.CssClass = "read-only";
        btnCategory_Select.Enabled = false;
        ddlSeverity.Enabled = false;
        txtAmount.ReadOnly = true;
        txtAmount.CssClass = "read-only";
        ddlClear_Method.Enabled = false;
        txtDescription.ReadOnly = true;
        txtDescription.CssClass = "read-only";
        lbxAttachment.Items.Clear();
        btnUpload.Enabled = false;
        btnDelete.Enabled = false;
    }
    protected void toplink_refresh_Click(object sender, ImageClickEventArgs e)
    {
        if (grdResult.Rows.Count != 0)
        {
            int i = grdResult.SelectedIndex;
            btnSearch_Search_Click(sender, e);
            grdResult.SelectedIndex = i;
        }
    }
    protected void toplink_copy_Click(object sender, EventArgs e)
    {
        toplink_add_Click(sender, e);
        lblErrorMessage.Text = "";
        txtForm_Type_Id.Text = "";
        txtForm_Type_Id.ReadOnly = false;
        txtForm_Type_Id.CssClass = "required-field";
        btnForm_Type_Select.Enabled = true;
        txtDate.Text = ViewState["txtDate"].ToString();
        txtDate.ReadOnly = true;
        txtDate.CssClass = "read-only";
        txtEmployee_Id.Text = ViewState["txtEmployee_Id"].ToString();
        txtEmployee_Id.ReadOnly = true;
        txtEmployee_Id.CssClass = "read-only";
        btnEmployee_Select.Enabled = false;
        lblEmployee_Name.Text = ViewState["lblEmployee_Name"].ToString();
        txtCategory_Id.Text = ViewState["txtCategory_Id"].ToString();
        txtCategory_Id.ReadOnly = true;
        txtCategory_Id.CssClass = "read-only";
        btnCategory_Select.Enabled = false;
        txtCategory_Name.Text = ViewState["txtCategory_Name"].ToString();
        txtCategory_Description.Text = ViewState["txtCategory_Description"].ToString();
        ddlSeverity.SelectedValue = ViewState["ddlSeverity"].ToString();
        ddlSeverity.Enabled = false;
        txtAmount.Text = ViewState["txtAmount"].ToString();
        txtAmount.ReadOnly = true;
        txtAmount.CssClass = "read-only";
        ddlClear_Method.SelectedValue = ViewState["ddlClear_Method"].ToString();
        ddlClear_Method.Enabled = false;
        txtDescription.Text = ViewState["txtDescription"].ToString();
        txtDescription.ReadOnly = true;
        txtDescription.CssClass = "read-only";
        lbxAttachment.Items.Clear();
        btnUpload.Enabled = false;
        btnDelete.Enabled = false;
        //disable grdResult while in edit mode
        grdResult.Enabled = false;

        Load_toplink(getPostBackControlName());
    }

    //page specific methods
    protected void btnForm_Type_Select_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(HR360connectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT [ID] 單別代號, [NAME] 單別名稱 FROM [HR360_PR01_A] WHERE [FORM_TYPE] = N'PR03: 獎懲罰建立作業'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                DataTable dt = new DataTable();
                da.Fill(dt);

                grdForm_Type.DataSource = dt;
                grdForm_Type.DataBind();
            }
        }
        catch
        {

        }
    }
    protected void grdForm_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtForm_Type_Id.Text = Server.HtmlDecode(grdForm_Type.SelectedRow.Cells[0].Text);
        txtForm_Type_Id_TextChanged(sender, e);
    }
    protected void btnEmployee_Select_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT [MV001] 員工代號, [MV002] 員工姓名 FROM CMSMV WHERE [CMSMV].[MV022] = ''", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                DataTable dt = new DataTable();
                da.Fill(dt);

                grdEmployee.DataSource = dt;
                grdEmployee.DataBind();           
            }
        }
        catch
        {

        }
    }
    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtEmployee_Id.Text = Server.HtmlDecode(grdEmployee.SelectedRow.Cells[0].Text);
        txtEmployee_Id_TextChanged(sender, e);
    }

    protected void btnCategory_Select_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(HR360connectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT [ID] 獎懲項目代號, [NAME] 獎懲項目名稱, [DESCRIPTION] 獎懲項目說明 FROM [HR360_PR02_A]", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                DataTable dt = new DataTable();
                da.Fill(dt);

                grdCategory.DataSource = dt;
                grdCategory.DataBind();
            }
        }
        catch
        {

        }
    }
    protected void grdCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCategory_Id.Text = Server.HtmlDecode(grdCategory.SelectedRow.Cells[0].Text);
        txtCategory_Id_TextChanged(sender, e);
    }
    protected void txtForm_Type_Id_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblErrorMessage.Text = "";
            DateTime dateValue;

            if (txtForm_Type_Id.Text.Trim() == "")
            {
                txtId.Text = "";
                lblForm_Type_Name.Text = "";
                txtForm_Type_Id.Focus();
            }
            else
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(HR360connectionString))
                {
                    conn.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT [HR360_PR01_A].[ID], [HR360_PR01_A].[NAME], [HR360_PR01_A].[CODE_FORMAT] FROM [HR360_PR01_A] LEFT JOIN [HR360_PR03_A] ON [HR360_PR01_A].[ID] = [HR360_PR03_A].[FORM_TYPE_ID] WHERE [HR360_PR01_A].[FORM_TYPE] = N'PR03: 獎懲罰建立作業' AND [HR360_PR01_A].[ID]=@ID", conn);
                    cmdSelect.Parameters.AddWithValue("@ID", txtForm_Type_Id.Text.Trim().ToUpper());
                    SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                    da.Fill(dt);
                }


                if (dt.Rows.Count > 0)
                {
                    txtForm_Type_Id.Text = txtForm_Type_Id.Text.Trim().ToUpper();
                    lblForm_Type_Name.Text = dt.Rows[0][1].ToString();
                    if (txtDate.Text.Trim() == "" || !DateTime.TryParseExact(txtDate.Text.Trim().ToUpper(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                    {

                    }
                    else
                    {
                        string code_format = dt.Rows[0][2].ToString();
                        //string id = "";
                        int year = 0;
                        //int month = 2;
                        int day = 0;
                        int seq = 0;
                        foreach (char c in code_format)
                        {
                            if (c == 'Y')
                            {
                                year += 1;
                            }
                            else if (c == 'D')
                            {
                                day += 1;
                            }
                            else if (c == '9')
                            {
                                seq += 1;
                            }
                        }
                        string seqNo = txtDate.Text.Substring(4 - year, year) + txtDate.Text.Substring(5, 2);
                        if (day != 0)
                        {
                            seqNo += txtDate.Text.Substring(8, 2);
                        }

                        //check for the highest ID with the same Code prior to 流水號
                        dt = new DataTable();
                        using (SqlConnection conn = new SqlConnection(HR360connectionString))
                        {
                            conn.Open();
                            SqlCommand cmdSelect = new SqlCommand("SELECT [HR360_PR03_A].[ID] FROM [HR360_PR03_A] LEFT JOIN [HR360_PR01_A] ON [HR360_PR03_A].[FORM_TYPE_ID] = [HR360_PR01_A].[ID] WHERE [HR360_PR01_A].[FORM_TYPE] = N'PR03: 獎懲罰建立作業' AND [HR360_PR03_A].[FORM_TYPE_ID]=@FORMTYPEID AND [HR360_PR03_A].[ID] LIKE @PRO3AID ORDER BY [HR360_PR03_A].[ID] DESC", conn);
                            cmdSelect.Parameters.AddWithValue("@FORMTYPEID", txtForm_Type_Id.Text.Trim().ToUpper());
                            cmdSelect.Parameters.AddWithValue("@PRO3AID", seqNo + "%");
                            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                            da.Fill(dt);
                        }

                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0][0] != null)
                            {
                                seqNo += (Convert.ToInt32(dt.Rows[0][0].ToString().Substring(dt.Rows[0][0].ToString().Count() - seq, seq)) + 1).ToString().PadLeft(seq, '0');
                            }
                        }
                        else
                        {
                            seqNo += "1".PadLeft(seq, '0');
                        }
                        txtId.Text = seqNo.Trim();
                    }
                }
                else
                {
                    lblErrorMessage.Text = "此代號不存在";
                    lblForm_Type_Name.Text = "";
                    txtForm_Type_Id.Focus();
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void txtEmployee_Id_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblErrorMessage.Text = "";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT [MV001], [MV002] FROM CMSMV WHERE [CMSMV].[MV022] = '' AND [MV001]=@ID", conn);
                cmdSelect.Parameters.AddWithValue("@ID", txtEmployee_Id.Text.Trim().ToUpper());
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);                
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                txtEmployee_Id.Text = txtEmployee_Id.Text.Trim().ToUpper();
                lblEmployee_Name.Text = dt.Rows[0][1].ToString();
            }
            else
            {
                lblErrorMessage.Text = "此代號不存在";
                lblEmployee_Name.Text = "";
                txtEmployee_Id.Focus();                
            }
        }
        catch
        {

        }
    }
    protected void txtCategory_Id_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblErrorMessage.Text = "";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(HR360connectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT [ID], [NAME], [DESCRIPTION] FROM [HR360_PR02_A] WHERE [ID]=@ID", conn);
                cmdSelect.Parameters.AddWithValue("@ID", txtCategory_Id.Text.Trim().ToUpper());
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                txtCategory_Id.Text = txtCategory_Id.Text.Trim().ToUpper();
                txtCategory_Name.Text = dt.Rows[0][1].ToString();
                if (dt.Rows[0][2].ToString() == "&nbsp;")
                {
                    txtCategory_Description.Text = dt.Rows[0][2].ToString().Replace("&nbsp;", "");
                }
                else
                {
                    txtCategory_Description.Text = dt.Rows[0][2].ToString();
                }
            }
            else
            {
                lblErrorMessage.Text = "此代號不存在";
                txtCategory_Name.Text = "";
                txtCategory_Description.Text = "";
                txtCategory_Id.Focus();
            }
        }
        catch
        {

        }
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblErrorMessage.Text = "";
            DateTime dateValue;

            if (txtDate.Text.Trim() == "" || !DateTime.TryParseExact(txtDate.Text.Trim().ToUpper(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
            {
                lblErrorMessage.Text = "請輸入符合格式yyyy/MM/dd的日期";
                txtId.Text = "";
                txtDate.Focus();
            }
            else if(txtForm_Type_Id.ReadOnly == true)
            {

            }
            else
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(HR360connectionString))
                {
                    conn.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT [HR360_PR01_A].[ID], [HR360_PR01_A].[NAME], [HR360_PR01_A].[CODE_FORMAT] FROM [HR360_PR01_A] LEFT JOIN [HR360_PR03_A] ON [HR360_PR01_A].[ID] = [HR360_PR03_A].[FORM_TYPE_ID] WHERE [HR360_PR01_A].[FORM_TYPE] = N'PR03: 獎懲罰建立作業' AND [HR360_PR01_A].[ID]=@ID", conn);
                    cmdSelect.Parameters.AddWithValue("@ID", txtForm_Type_Id.Text.Trim().ToUpper());
                    SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                    da.Fill(dt);
                }


                if (dt.Rows.Count > 0)
                {
                    string code_format = dt.Rows[0][2].ToString();
                    //string id = "";
                    int year = 0;
                    //int month = 2;
                    int day = 0;
                    int seq = 0;
                    foreach (char c in code_format)
                    {
                        if (c == 'Y')
                        {
                            year += 1;
                        }
                        else if (c == 'D')
                        {
                            day += 1;
                        }
                        else if (c == '9')
                        {
                            seq += 1;
                        }
                    }
                    string seqNo = txtDate.Text.Substring(4 - year, year) + txtDate.Text.Substring(5, 2);
                    if (day != 0)
                    {
                        seqNo += txtDate.Text.Substring(8, 2);
                    }

                    //check for the highest ID with the same Code prior to 流水號
                    dt = new DataTable();
                    using (SqlConnection conn = new SqlConnection(HR360connectionString))
                    {
                        conn.Open();
                        SqlCommand cmdSelect = new SqlCommand("SELECT [HR360_PR03_A].[ID] FROM [HR360_PR03_A] LEFT JOIN [HR360_PR01_A] ON [HR360_PR03_A].[FORM_TYPE_ID] = [HR360_PR01_A].[ID] WHERE [HR360_PR01_A].[FORM_TYPE] = N'PR03: 獎懲罰建立作業' AND [HR360_PR03_A].[FORM_TYPE_ID]=@FORMTYPEID AND [HR360_PR03_A].[ID] LIKE @PRO3AID ORDER BY [HR360_PR03_A].[ID] DESC", conn);
                        cmdSelect.Parameters.AddWithValue("@FORMTYPEID", txtForm_Type_Id.Text.Trim().ToUpper());
                        cmdSelect.Parameters.AddWithValue("@PRO3AID", seqNo + "%");
                        SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                        da.Fill(dt);
                    }

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0] != null)
                        {
                            seqNo += (Convert.ToInt32(dt.Rows[0][0].ToString().Substring(dt.Rows[0][0].ToString().Count() - seq, seq)) + 1).ToString().PadLeft(seq, '0');
                        }
                    }
                    else
                    {
                        seqNo += "1".PadLeft(seq, '0');
                    }
                    txtId.Text = seqNo.Trim();
                }
                else
                {
                    lblErrorMessage.Text = "此單別代號不存在";
                    lblForm_Type_Name.Text = "";
                    txtForm_Type_Id.Focus();
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    //attachment-related methods
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            HttpPostedFile filename = Request.Files[0];
            if (uploadFile.PostedFile.FileName.Length > 0)
            {
                string directory = @"~/HR360/PR03_attachment/" + txtForm_Type_Id.Text.Trim().ToUpper() + @"/" + txtId.Text.Trim() + @"/";
                System.IO.Directory.CreateDirectory(Server.MapPath(directory));
                string filePath = Server.MapPath(directory + Path.GetFileName(filename.FileName));
                string fileNameOriginal = Path.GetFileNameWithoutExtension(filePath);
                string fileName = fileNameOriginal;
                string fileExt = Path.GetExtension(filePath);

                //writing upload file information into db
                using (SqlConnection conn = new SqlConnection(HR360connectionString))
                {
                    conn.Open();
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO [HR360_PR03_B] VALUES (GETDATE(),@CREATOR,GETDATE(),@MODIFIER,@FORM_TYPE_ID,@FORM_ID,@FILE_URL)", conn);
                    cmdInsert.Parameters.AddWithValue("@CREATOR", Session["user_id"]);
                    cmdInsert.Parameters.AddWithValue("@MODIFIER", Session["user_id"]);
                    cmdInsert.Parameters.AddWithValue("@FORM_TYPE_ID", txtForm_Type_Id.Text.Trim().ToUpper());
                    cmdInsert.Parameters.AddWithValue("@FORM_ID", txtId.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@FILE_URL", directory + fileName + fileExt);
                    cmdInsert.ExecuteNonQuery();
                }
                //loading file into filesystem, directory is ~/HR360/PR03_attachment/form_type/form_id/filename

                int i = 1;
                while (File.Exists(Server.MapPath(directory + fileName + fileExt)))
                {
                    fileName = fileNameOriginal + "(" + i.ToString() + ")";
                    i++;
                }
                uploadFile.PostedFile.SaveAs(Server.MapPath(directory + fileName + fileExt));

                if (fileExt == ".exe")
                {
                    lblErrorMessage.Text = "不可上傳執行檔";
                }
                else
                {
                    Label lbl = new Label();
                    lbl.Text = fileName + fileExt;

                    lbxAttachment.Items.Add(lbl.Text);
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void btnOpen_Click(object sender, EventArgs e)
    {
        try
        {
            if (lbxAttachment.SelectedItem != null)
            {
                string directory = @"~/HR360/PR03_attachment/" + txtForm_Type_Id.Text.Trim().ToUpper() + @"/" + txtId.Text.Trim() + @"/";
                Process proc = new Process();
                proc.StartInfo.FileName = Server.MapPath(directory + lbxAttachment.SelectedItem.Text);
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
            }
            else
            {
                lblErrorMessage.Text = "請選擇要開啟的檔案";
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (lbxAttachment.SelectedItem != null)
            {
                string directory = @"~/HR360/PR03_attachment/" + txtForm_Type_Id.Text.Trim().ToUpper() + @"/" + txtId.Text.Trim() + @"/";
                if (File.Exists(Server.MapPath(directory + lbxAttachment.SelectedItem.Text)))
                {
                    //remove record from database
                    using (SqlConnection conn = new SqlConnection(HR360connectionString))
                    {
                        conn.Open();
                        SqlCommand cmdDelete = new SqlCommand("DELETE FROM [HR360_PR03_B] WHERE [FORM_TYPE_ID]=@FORM_TYPE_ID AND [FORM_ID]=@FORM_ID AND [FILE_URL]=@FILE_URL", conn);
                        cmdDelete.Parameters.AddWithValue("@FORM_TYPE_ID", txtForm_Type_Id.Text.Trim().ToUpper());
                        cmdDelete.Parameters.AddWithValue("@FORM_ID", txtId.Text.Trim());
                        cmdDelete.Parameters.AddWithValue("@FILE_URL", directory + lbxAttachment.SelectedItem.Text);
                        cmdDelete.ExecuteNonQuery();
                    }
                    //removes file from filesystem
                    File.Delete(Server.MapPath(directory + lbxAttachment.SelectedItem.Text));
                    lbxAttachment.Items.Remove(lbxAttachment.SelectedItem);
                }
            }
            else
            {
                lblErrorMessage.Text = "請選擇要刪除的檔案";
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
}