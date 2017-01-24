using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hr360_PR10 : System.Web.UI.Page
{
    //universal functions
    string HR360connectionString = ConfigurationManager.ConnectionStrings["HR360ConnectionString"].ConnectionString;
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
        AddRowSelectToGridView(grdForm);

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
                            toplink_copy.Enabled = false;
                            toplink_copy.CssClass = "disabled";
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
                            toplink_copy.Enabled = false;
                            toplink_copy.CssClass = "disabled";
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
                            toplink_copy.Enabled = false;
                            toplink_copy.CssClass = "disabled";
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
                            toplink_copy.Enabled = false;
                            toplink_copy.CssClass = "disabled";
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
        ViewState["txtForm_Id"] = txtForm_Id.Text.Trim();
        ViewState["lblEmployee_Id"] = lblEmployee_Id.Text.Trim();
        ViewState["lblEmployee_Name"] = lblEmployee_Name.Text.Trim();
        ViewState["lblAssessor_Id"] = lblAssessor_Id.Text.Trim();
        ViewState["lblAssessor_Name"] = lblAssessor_Name.Text.Trim();
        ViewState["txtAssessor_Comment"] = txtAssessor_Comment.Text.Trim();
        ViewState["chkDisplay"] = chkDisplay.Checked;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtForm_Type_Id.Text = "";
            txtForm_Type_Id.ReadOnly = true;
            txtForm_Type_Id.CssClass = "read-only";
            btnForm_Type_Select.Enabled = false;
            lblForm_Type_Name.Text = "";
            txtForm_Id.Text = "";
            txtForm_Id.ReadOnly = true;
            txtForm_Id.CssClass = "read-only";
            btnForm_Id_Select.Enabled = false;
            lblEmployee_Id.Text = "";
            lblEmployee_Name.Text = "";
            lblAssessor_Id.Text = Session["user_id"].ToString();
            using (SqlConnection conn = new SqlConnection(HR360connectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT [ID], [NAME] FROM [HR360_BI01_A] WHERE [ID]=@ID", conn);
                cmdSelect.Parameters.AddWithValue("@ID", Session["user_id"]);
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lblAssessor_Name.Text = dt.Rows[0][1].ToString().Trim();
            }
            txtAssessor_Comment.Text = "";
            txtAssessor_Comment.ReadOnly = true;
            txtAssessor_Comment.CssClass = "read-only";
            chkDisplay.Enabled = false;
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
        txtForm_Id.Text = "";
        txtForm_Id.ReadOnly = false;
        txtForm_Id.CssClass = "required-field";
        btnForm_Id_Select.Enabled = true;
        lblEmployee_Id.Text = "";
        lblEmployee_Name.Text = "";
        lblAssessor_Id.Text = Session["user_id"].ToString();
        using (SqlConnection conn = new SqlConnection(HR360connectionString))
        {
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT [ID], [NAME] FROM [HR360_BI01_A] WHERE [ID]=@ID", conn);
            cmdSelect.Parameters.AddWithValue("@ID", Session["user_id"]);
            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblAssessor_Name.Text = dt.Rows[0][1].ToString().Trim();
        }
        txtAssessor_Comment.Text = "";
        txtAssessor_Comment.ReadOnly = false;
        txtAssessor_Comment.CssClass = "";
        chkDisplay.Enabled = true;
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
        string query = "SELECT [HR360_PR10_A].[FORM_TYPE_ID] 評核單別, [HR360_PR07_A].[FORM_TYPE_NAME] 評核單別名稱, [HR360_PR10_A].[FORM_ID] 評核單號, [HR360_PR07_A].[EMPLOYEE_ID] 員工代號, [HR360_PR07_A].[EMPLOYEE_NAME] 員工姓名, [HR360_PR10_A].[ASSESSOR_ID] 評核員代號, [HR360_PR10_A].[ASSESSOR_NAME] 評核員姓名, [HR360_PR10_A].[ASSESSOR_COMMENT] 評語, [HR360_PR10_A].[DISPLAY] 是否顯示, [HR360_PR10_A].[CREATEDATE] 建立日期, [HR360_PR10_A].[CREATOR] 建立者, [HR360_PR10_A].[MODIFIEDDATE] 修改日期, [HR360_PR10_A].[MODIFIER] 修改者 FROM [HR360_PR10_A] LEFT JOIN [HR360_PR07_A] ON [HR360_PR10_A].[HR360_FORM_TYPE_ID]=[HR360_PR07_A].[FORM_TYPE_ID] AND [HR360_PR10_A].[FORM_ID]=[HR360_PR07_A].[ID] ";
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
            query_condition += " ORDER BY [HR360_PR10_A].[FORM_TYPE_ID] ASC, [HR360_PR10_A].[FORM_ID] DESC";
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
        txtForm_Type_Id.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[0].Text.Trim());
        txtForm_Type_Id.ReadOnly = true;
        txtForm_Type_Id.CssClass = "read-only";
        btnForm_Type_Select.Enabled = false;
        lblForm_Type_Name.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[1].Text.Trim());
        txtForm_Id.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[2].Text.Trim());
        txtForm_Id.ReadOnly = true;
        txtForm_Id.CssClass = "read-only";
        btnForm_Id_Select.Enabled = false;
        lblEmployee_Id.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[3].Text.Trim());
        lblEmployee_Name.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[4].Text.Trim());
        lblAssessor_Id.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[5].Text.Trim().ToUpper());
        lblAssessor_Name.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[6].Text.Trim());
        txtAssessor_Comment.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[7].Text.Trim());
        txtAssessor_Comment.ReadOnly = true;
        txtAssessor_Comment.CssClass = "read-only";
        if ((grdResult.SelectedRow.Cells[8].Controls[0] as CheckBox).Checked == true)
        {
            chkDisplay.Checked = true;
        }
        else
        {
            chkDisplay.Checked = false;
        }    
    }
    //
    protected void toplink_edit_Click(object sender, EventArgs e)
    {
        if (lblAssessor_Id.Text == Session["user_id"].ToString())
        {
            lblErrorMessage.Text = "";
            txtForm_Type_Id.ReadOnly = true;
            txtForm_Type_Id.CssClass = "read-only";
            btnForm_Type_Select.Enabled = false;
            txtForm_Id.ReadOnly = true;
            txtForm_Id.CssClass = "read-only";
            btnForm_Id_Select.Enabled = false;
            txtAssessor_Comment.ReadOnly = false;
            txtAssessor_Comment.CssClass = "";
            chkDisplay.Enabled = true;
            //disable gridview while editing
            grdResult.Enabled = false;

            Load_toplink(getPostBackControlName());
        }
        else
        {
            lblErrorMessage.Text = "不可編輯非自己留的評語";
        }
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
        bool isMatchFormId = false;
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
        using (SqlConnection conn = new SqlConnection(HR360connectionString))
        {
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT [ID] FROM [HR360_PR07_A] WHERE [FORM_TYPE_ID]=@FORM_TYPE_ID AND [ID]=@ID", conn);
            cmdSelect.Parameters.AddWithValue("@FORM_TYPE_ID", txtForm_Type_Id.Text.Trim().ToUpper());
            cmdSelect.Parameters.AddWithValue("@ID", txtForm_Id.Text.Trim());
            SqlDataReader dr = cmdSelect.ExecuteReader();
            if (dr.HasRows)
            {
                isMatchFormId = true;
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
        else if (txtForm_Id.Text.Trim() == "" || !isMatchFormId)
        {
            lblErrorMessage.Text = "請選擇正確的單據代號";
            txtForm_Id.ReadOnly = false;
            txtForm_Id.CssClass = "required-field";
            txtForm_Id.Focus();
            btnForm_Id_Select.Enabled = true;
        }
        else
        {
            try
            {
                if (txtForm_Type_Id.ReadOnly == false && txtForm_Id.ReadOnly == false) //新增
                {
                    using (SqlConnection conn = new SqlConnection(HR360connectionString))
                    {
                        SqlCommand cmdDuplicateSearch = new SqlCommand("SELECT [FORM_ID] FROM [HR360_PR10_A] WHERE [FORM_ID] = @FORM_ID AND [FORM_TYPE_ID]=@FORMTYPEID AND [ASSESSOR_ID]=@ASSESSOR_ID ", conn);
                        cmdDuplicateSearch.Parameters.AddWithValue("@FORMTYPEID", txtForm_Type_Id.Text.Trim().ToUpper());
                        cmdDuplicateSearch.Parameters.AddWithValue("@FORM_ID", txtForm_Id.Text.ToUpper().Trim());
                        cmdDuplicateSearch.Parameters.AddWithValue("@ASSESSOR_ID", lblAssessor_Id.Text.Trim());
                        conn.Open();
                        SqlDataReader reader = cmdDuplicateSearch.ExecuteReader();
                        if (!reader.HasRows)
                        {
                            if (!reader.IsClosed)
                            {
                                reader.Close();
                            }
                            SqlCommand cmdInsert = new SqlCommand("INSERT INTO [HR360_PR10_A] VALUES(GETDATE(),@CREATOR,GETDATE(),@MODIFIER,@FORM_TYPE_ID,@FORM_ID,@ASSESSOR_ID,@ASSESSOR_NAME,@ASSESSOR_COMMENT,@DISPLAY)", conn);
                            cmdInsert.Parameters.AddWithValue("@CREATOR", Session["user_id"]);
                            cmdInsert.Parameters.AddWithValue("@MODIFIER", Session["user_id"]);
                            cmdInsert.Parameters.AddWithValue("@FORM_TYPE_ID", txtForm_Type_Id.Text.Trim().ToUpper());
                            cmdInsert.Parameters.AddWithValue("@FORM_ID", txtForm_Id.Text.Trim());
                            cmdInsert.Parameters.AddWithValue("@ASSESSOR_ID", lblAssessor_Id.Text.Trim().ToUpper());
                            cmdInsert.Parameters.AddWithValue("@ASSESSOR_NAME", lblAssessor_Name.Text.Trim());
                            cmdInsert.Parameters.AddWithValue("@ASSESSOR_COMMENT", Server.HtmlEncode(txtAssessor_Comment.Text.Trim()));
                            if (chkDisplay.Checked == true)
                            {
                                cmdInsert.Parameters.AddWithValue("@DISPLAY", 1);
                            }
                            else
                            {
                                cmdInsert.Parameters.AddWithValue("@DISPLAY", 0);
                            }
                            cmdInsert.ExecuteNonQuery();
                            lblErrorMessage.Text = "";
                        }
                        else
                        {
                            if (!reader.IsClosed)
                            {
                                reader.Close();
                            }
                            lblErrorMessage.Text = "此評核者已於此評核單下評語，如欲增加，請用查詢方式做修改";
                        }
                    }
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(HR360connectionString))
                    {
                        conn.Open();
                        SqlCommand cmdUpdate = new SqlCommand("UPDATE [HR360_PR10_A] SET [MODIFIEDDATE]=GETDATE(),[MODIFIER]=@MODIFIER,[ASSESSOR_NAME]=@ASSESSOR_NAME,[ASSESSOR_COMMENT]=@ASSESSOR_COMMENT,[DISPLAY]=@DISPLAY WHERE [FORM_TYPE_ID]=@FORM_TYPE_ID AND [FORM_ID]=@FORM_ID AND [ASSESSOR_ID]=@ASSESSOR_ID", conn);
                        cmdUpdate.Parameters.AddWithValue("@MODIFIER", Session["user_id"]);
                        cmdUpdate.Parameters.AddWithValue("@ASSESSOR_NAME", lblAssessor_Name.Text.Trim());
                        cmdUpdate.Parameters.AddWithValue("@ASSESSOR_COMMENT", txtAssessor_Comment.Text.Trim());
                        cmdUpdate.Parameters.AddWithValue("@FORM_TYPE_ID", txtForm_Type_Id.Text.Trim().ToUpper());
                        cmdUpdate.Parameters.AddWithValue("@FORM_ID", txtForm_Id.Text.Trim().ToUpper());
                        cmdUpdate.Parameters.AddWithValue("@ASSESSOR_ID", lblAssessor_Id.Text.Trim().ToUpper());
                        if (chkDisplay.Checked == true)
                        {
                            cmdUpdate.Parameters.AddWithValue("@DISPLAY", 1);
                        }
                        else
                        {
                            cmdUpdate.Parameters.AddWithValue("@DISPLAY", 0);
                        }
                        cmdUpdate.ExecuteNonQuery();
                    }
                    lblErrorMessage.Text = "";
                }
                
                //enable grdResult after click
                grdResult.Enabled = true;
                Load_toplink(getPostBackControlName());

                txtForm_Type_Id.ReadOnly = true;
                txtForm_Type_Id.CssClass = "read-only";
                btnForm_Type_Select.Enabled = false;
                txtForm_Id.ReadOnly = true;
                txtForm_Id.CssClass = "read-only";
                btnForm_Id_Select.Enabled = false;
                txtAssessor_Comment.ReadOnly = true;
                txtAssessor_Comment.CssClass = "read-only";
                chkDisplay.Enabled = false;
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
        txtForm_Id.Text = "";
        txtForm_Id.ReadOnly = true;
        txtForm_Id.CssClass = "read-only";
        btnForm_Id_Select.Enabled = false;
        lblEmployee_Id.Text = "";
        lblEmployee_Name.Text = "";
        lblAssessor_Id.Text = "";
        lblAssessor_Name.Text = "";
        txtAssessor_Comment.Text = "";
        txtAssessor_Comment.ReadOnly = true;
        txtAssessor_Comment.CssClass = "read-only";
        chkDisplay.Enabled = false;

        //enable grdResult after click
        grdResult.Enabled = true;

        Load_toplink(getPostBackControlName());
    }
    protected void toplink_delete_Click(object sender, EventArgs e)
    {
        try
        {
            if (lblAssessor_Id.Text == Session["user_id"].ToString())
            {
                using (SqlConnection conn = new SqlConnection(HR360connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT [FORM_ID] FROM [HR360_PR10_A] WHERE [FORM_ID] = @FORM_ID AND [FORM_TYPE_ID]=@FORM_TYPE_ID AND [ASSESSOR_ID]=@ASSESSOR_ID", conn);
                    cmd.Parameters.AddWithValue("@FORM_TYPE_ID", txtForm_Type_Id.Text.Trim().ToUpper());
                    cmd.Parameters.AddWithValue("@FORM_ID", txtForm_Id.Text.Trim().ToUpper());
                    cmd.Parameters.AddWithValue("@ASSESSOR_ID", lblAssessor_Id.Text.Trim());
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        }
                        SqlCommand cmdDelete = new SqlCommand("DELETE FROM [HR360_PR10_A] WHERE [FORM_ID] = @FORM_ID AND [FORM_TYPE_ID]=@FORM_TYPE_ID AND [ASSESSOR_ID]=@ASSESSOR_ID", conn);
                        cmdDelete.Parameters.AddWithValue("@FORM_TYPE_ID", txtForm_Type_Id.Text.Trim().ToUpper());
                        cmdDelete.Parameters.AddWithValue("@FORM_ID", txtForm_Id.Text.ToUpper().Trim());
                        cmdDelete.Parameters.AddWithValue("@ASSESSOR_ID", lblAssessor_Id.Text.Trim());
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
                        txtForm_Id.Text = "";
                        lblEmployee_Id.Text = "";
                        lblEmployee_Name.Text = "";
                        lblAssessor_Id.Text = "";
                        lblAssessor_Name.Text = "";
                        txtAssessor_Comment.Text = "";

                        Load_toplink(getPostBackControlName());
                    }
                    else
                    {
                        lblErrorMessage.Text = "此項目不存在";
                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        }
                    }
                }
            }
            else
            {
                lblErrorMessage.Text = "不可刪除非自己的評語";
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
        txtForm_Id.ReadOnly = true;
        txtForm_Id.CssClass = "read-only";
        btnForm_Id_Select.Enabled = false;
        txtAssessor_Comment.ReadOnly = true;
        txtAssessor_Comment.CssClass = "read-only";
        chkDisplay.Enabled = false;
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
        //toplink_add_Click(sender, e);
        lblErrorMessage.Text = "";
        txtForm_Type_Id.Text = "";
        txtForm_Type_Id.ReadOnly = false;
        txtForm_Type_Id.CssClass = "required-field";
        btnForm_Type_Select.Enabled = true;
        //disable grdResult while in edit mode
        grdResult.Enabled = false;

        Load_toplink(getPostBackControlName());
    }

    //page specific methods

    protected void txtForm_Type_Id_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblErrorMessage.Text = "";

            if (txtForm_Type_Id.Text.Trim() == "")
            {
                txtForm_Id.Text = "";
                lblForm_Type_Name.Text = "";
                txtForm_Type_Id.Focus();
            }
            else if (lblForm_Type_Name.Text.Trim() == "")
            {
                lblErrorMessage.Text = "請選擇正確的單別";
                txtForm_Type_Id.ReadOnly = false;
                txtForm_Type_Id.CssClass = "required-field";
                btnForm_Type_Select.Enabled = true;
            }
            else
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(HR360connectionString))
                {
                    conn.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT [HR360_PR01_A].[ID], [HR360_PR01_A].[NAME] FROM [HR360_PR01_A] WHERE [HR360_PR01_A].[FORM_TYPE] = N'PR07: 考績單建立作業' AND [HR360_PR01_A].[ID]=@ID", conn);
                    cmdSelect.Parameters.AddWithValue("@ID", txtForm_Type_Id.Text.Trim().ToUpper());
                    SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                    da.Fill(dt);
                }


                if (dt.Rows.Count > 0)
                {
                    txtForm_Type_Id.Text = dt.Rows[0][0].ToString().Trim().ToUpper();
                    lblForm_Type_Name.Text = dt.Rows[0][1].ToString().Trim();
                    txtForm_Id.Text = "";
                    lblEmployee_Name.Text = "";
                    lblEmployee_Id.Text = "";
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
    protected void btnForm_Type_Select_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(HR360connectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT [ID] 單別代號, [NAME] 單別名稱, [EN_NAME] 單別英文名稱 FROM [HR360_PR01_A] WHERE [FORM_TYPE] = N'PR07: 考績單建立作業'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                DataTable dt = new DataTable();
                da.Fill(dt);

                grdForm_Type.DataSource = dt;
                grdForm_Type.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void grdForm_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtForm_Type_Id.Text = Server.HtmlDecode(grdForm_Type.SelectedRow.Cells[0].Text);
        lblForm_Type_Name.Text = Server.HtmlDecode(grdForm_Type.SelectedRow.Cells[1].Text);
        txtForm_Id.Text = "";
        lblEmployee_Name.Text = "";
        lblEmployee_Id.Text = "";
        txtForm_Type_Id_TextChanged(sender, e);
    }
    protected void txtForm_Id_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblErrorMessage.Text = "";

            if (lblForm_Type_Name.Text.Trim() == "")
            {
                lblErrorMessage.Text = "請選擇單別";
                txtForm_Type_Id.ReadOnly = false;
                txtForm_Type_Id.CssClass = "required-field";
                btnForm_Type_Select.Enabled = true;
            }
            else
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(HR360connectionString))
                {
                    conn.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT [HR360_PR07_A].[FORM_TYPE_ID], [HR360_PR07_A].[FORM_TYPE_NAME], [HR360_PR07_A].[ID], [HR360_PR07_A].[EMPLOYEE_ID], [HR360_PR07_A].[EMPLOYEE_NAME] FROM [HR360_PR07_A] WHERE [HR360_PR07_A].[ID]=@ID AND [HR360_PR07_A].[FORM_TYPE_ID]=@FORM_TYPE_ID", conn);
                    cmdSelect.Parameters.AddWithValue("@ID", txtForm_Id.Text.Trim().ToUpper());
                    cmdSelect.Parameters.AddWithValue("@FORM_TYPE_ID", txtForm_Type_Id.Text.Trim().ToUpper());
                    SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                    da.Fill(dt);
                }


                if (dt.Rows.Count > 0)
                {
                    txtForm_Type_Id.Text = dt.Rows[0][0].ToString().Trim().ToUpper();
                    lblForm_Type_Name.Text = dt.Rows[0][1].ToString().Trim();
                    txtForm_Id.Text = dt.Rows[0][2].ToString().Trim();
                    lblEmployee_Id.Text = dt.Rows[0][3].ToString().Trim();
                    lblEmployee_Name.Text = dt.Rows[0][4].ToString().Trim();
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
    protected void btnForm_Id_Select_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(HR360connectionString))
            {                
                conn.Open();
                string condition = "";
                if (txtForm_Type_Id.Text.Trim() != "")
                {
                    condition = " WHERE [HR360_PR07_A].[FORM_TYPE_ID] = N'" + txtForm_Type_Id.Text.Trim().ToUpper() + "'";
                }
                SqlCommand cmdSelect = new SqlCommand("SELECT [FORM_TYPE_ID] 評核單別代號, [FORM_TYPE_NAME] 評核單別名稱, [ID] 評核單代號, [ASSESSMENT_YEAR] 評核年度,CONVERT(NVARCHAR(20), HR360_PR07_A.ASSESSMENT_START_DATE) + '~' + CONVERT(NVARCHAR(20), HR360_PR07_A.ASSESSMENT_END_DATE) [評核期間], [EMPLOYEE_ID] 員工代號, [EMPLOYEE_NAME] 員工姓名 FROM [HR360_PR07_A]" + condition, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                DataTable dt = new DataTable();
                da.Fill(dt);

                grdForm.DataSource = dt;
                grdForm.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void grdForm_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtForm_Type_Id.Text = Server.HtmlDecode(grdForm.SelectedRow.Cells[0].Text.Trim().ToUpper());
        lblForm_Type_Name.Text = Server.HtmlDecode(grdForm.SelectedRow.Cells[1].Text.Trim());
        txtForm_Id.Text = Server.HtmlDecode(grdForm.SelectedRow.Cells[2].Text.Trim());
        lblEmployee_Id.Text = Server.HtmlDecode(grdForm.SelectedRow.Cells[5].Text.Trim().ToUpper());
        lblEmployee_Name.Text = Server.HtmlDecode(grdForm.SelectedRow.Cells[6].Text.Trim());
        lblErrorMessage.Text = "";
    }
}