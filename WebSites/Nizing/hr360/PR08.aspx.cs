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

public partial class hr360_PR08 : System.Web.UI.Page
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
        //AddRowSelectToGridView(grdResult);
        AddRowSelectToGridView(grdForm_List);
        AddRowSelectToGridView(grdForm_Type);
        AddRowSelectToGridView(grdAssessor);

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
                        toplink_edit.Enabled = true;
                        toplink_edit.CssClass = "";
                    }
                    else
                    {
                        toplink_edit.Enabled = false;
                        toplink_edit.CssClass = "disabled";
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
                    toplink_add.Enabled = false;
                    toplink_add.CssClass = "disabled";
                    //toplink_edit.Enabled = false;
                    //toplink_edit.CssClass = "disabled";
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
                        toplink_edit.Enabled = true;
                        toplink_edit.CssClass = "";
                    }
                    else
                    {
                        toplink_edit.Enabled = false;
                        toplink_edit.CssClass = "disabled";
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
                    toplink_add.Enabled = false;
                    toplink_add.CssClass = "disabled";
                    toplink_save.Enabled = false;
                    toplink_save.CssClass = "disabled";
                    toplink_cancel.Enabled = false;
                    toplink_cancel.CssClass = "disabled";
                    //whether there are still items in search result or not
                    if (grdForm_List.Rows.Count == 0)
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
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][9].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE")) //
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
                        toplink_edit.Enabled = true;
                        toplink_edit.CssClass = "";
                    }
                    else
                    {
                        toplink_edit.Enabled = false;
                        toplink_edit.CssClass = "disabled";
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
                    toplink_add.Enabled = false;
                    toplink_add.CssClass = "disabled";
                    toplink_save.Enabled = false;
                    toplink_save.CssClass = "disabled";
                    toplink_cancel.Enabled = false;
                    toplink_cancel.CssClass = "disabled";
                    //whether there are still items in search result or not
                    if (grdForm_List.Rows.Count == 0)
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
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][9].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE")) //
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
                        toplink_add.Enabled = false;
                        toplink_add.CssClass = "disabled";
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
                        toplink_edit.Enabled = true;
                        toplink_edit.CssClass = "";
                    }
                    else
                    {
                        toplink_edit.Enabled = false;
                        toplink_edit.CssClass = "disabled";
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
                    toplink_add.Enabled = false;
                    toplink_add.CssClass = "disabled";
                    toplink_save.Enabled = false;
                    toplink_save.CssClass = "disabled";
                    toplink_cancel.Enabled = false;
                    toplink_cancel.CssClass = "disabled";
                    //whether there are still items in search result or not
                    if (grdForm_List.Rows.Count == 0)
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
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][9].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE")) //
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
                        toplink_add.Enabled = false;
                        toplink_add.CssClass = "disabled";
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
                        toplink_edit.Enabled = true;
                        toplink_edit.CssClass = "";
                    }
                    else
                    {
                        toplink_edit.Enabled = false;
                        toplink_edit.CssClass = "disabled";
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
                    toplink_add.Enabled = false;
                    toplink_add.CssClass = "disabled";
                    toplink_save.Enabled = false;
                    toplink_save.CssClass = "disabled";
                    toplink_cancel.Enabled = false;
                    toplink_cancel.CssClass = "disabled";
                    //whether there are still items in search result or not
                    if (grdForm_List.Rows.Count == 0)
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
                        if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][9].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE")) //
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
                        toplink_add.Enabled = false;
                        toplink_add.CssClass = "disabled";
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

    void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["txtForm_Assessment_Year"] = txtForm_Assessment_Year.Text.Trim();
        ViewState["txtForm_Type_Id"] = txtForm_Type_Id.Text.ToUpper().Trim();
        ViewState["imgAvatar"] = imgAvatar.ImageUrl;
        ViewState["lblEmployee_Id"] = lblEmployee_Id.Text;
        ViewState["lblEmployee_Name"] = lblEmployee_Name.Text;
        ViewState["lblEmployee_Rank"] = lblEmployee_Rank.Text;
        ViewState["lblEmployee_Department"] = lblEmployee_Department.Text;
        ViewState["lblForm_Id"] = lblForm_Id.Text;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtForm_Assessment_Year.Text = "";
            txtForm_Type_Id.Text = "";
            try
            {
                string condition = fastSearchString(txtForm_Assessment_Year.Text.Trim(), txtForm_Type_Id.Text.Trim());

                using (SqlConnection conn = new SqlConnection(HR360connectionString))
                {
                    conn.Open();
                    SqlCommand cmdSelect = new SqlCommand("WITH A"
                                                        + " AS"
                                                        + " ("
                                                        + " SELECT DISTINCT HR360_PR07_A.FORM_TYPE_ID"
                                                        + " , HR360_PR07_A.FORM_TYPE_NAME"
                                                        + " , HR360_PR07_A.ID [FORM_ID]"
                                                        + " , HR360_PR07_A.ASSESSMENT_YEAR"
                                                        + " , CONVERT(NVARCHAR(20), HR360_PR07_A.ASSESSMENT_START_DATE) + '~' + CONVERT(NVARCHAR(20), HR360_PR07_A.ASSESSMENT_END_DATE) [FORM_ASSESSMENT_PERIOD]"
                                                        + " , HR360_PR07_A.EMPLOYEE_ID"
                                                        + " , HR360_PR07_A.EMPLOYEE_NAME"
                                                        + " , HR360_PR07_A.EMPLOYEE_RANK"
                                                        + " , HR360_PR07_A.EMPLOYEE_DEPARTMENT"
                                                        + " FROM HR360_PR07_A"
                                                        + " )"
                                                        + " SELECT A.FORM_TYPE_ID"
                                                        + " , A.FORM_TYPE_NAME"
                                                        + " , A.FORM_ID"
                                                        + " , A.ASSESSMENT_YEAR"
                                                        + " , A.FORM_ASSESSMENT_PERIOD"
                                                        + " , A.EMPLOYEE_ID"
                                                        + " , A.EMPLOYEE_NAME"
                                                        + " , A.EMPLOYEE_RANK"
                                                        + " , A.EMPLOYEE_DEPARTMENT"
                                                        + " , (SELECT COUNT(HR360_PR08_A.ASSESSOR_ID) "
                                                        + " 	FROM HR360_PR08_A "
                                                        + " 	WHERE HR360_PR08_A.FORM_TYPE_ID = A.FORM_TYPE_ID AND HR360_PR08_A.FORM_ID = A.FORM_ID"
                                                        + " 	) ASSESSOR_NO"
                                                        + " FROM A"
                                                        + " ORDER BY A.FORM_TYPE_ID, A.FORM_ID DESC", conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    grdForm_List.DataSource = dt;
                    grdForm_List.DataBind();
                    
                }
                if (grdForm_List.Rows.Count != 0)
                {
                    grdForm_List.SelectedIndex = 0;
                    grdForm_List_SelectedIndexChanged(sender, e);
                }
                else
                {
                    grdForm_List.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.ToString();
            }
            
            txtAssessor_Id.Text = "";
            txtAssessor_Id.ReadOnly = true;
            txtAssessor_Id.CssClass = "read-only";
            btnAssessor_Select.Enabled = false;
            lblAssessor_Name.Text = "";
            btnAssessor_Import.Enabled = false;
            grdAssessor_List.Enabled = false;
            grdAssessor.DataSource = null;
            grdAssessor.DataBind();
            grdAssessor.Enabled = false;
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
        lblEmployee_Name.Text = "";
        lblEmployee_Rank.Text = "";
        lblEmployee_Department.Text = "";
        lblErrorMessage.Text = "";

        //disable grdResult while in edit mode
        //grdResult.Enabled = false;
        grdForm_List.Enabled = false;

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
                if (ddlSearch_Item.SelectedItem.Value == "ASSESSMENT_YEAR")
                {
                    txtSearchCondition.Text = "A.[" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'%" + txtSearchContent.Text + "%'";
                }
                else
                {
                    txtSearchCondition.Text = "HR360_PR08_A.[" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'%" + txtSearchContent.Text + "%'";
                }
            }
            else if (rdoAnd.Checked == true)
            {
                if (ddlSearch_Item.SelectedItem.Value == "ASSESSMENT_YEAR")
                {
                    txtSearchCondition.Text += "\n" + rdoAnd.Text + " A.[" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'%" + txtSearchContent.Text + "%'";
                }
                else
                {
                    txtSearchCondition.Text += "\n" + rdoAnd.Text + " HR360_PR08_A.[" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'%" + txtSearchContent.Text + "%'";
                }
            }
            else if (rdoOr.Checked == true)
            {
                if (ddlSearch_Item.SelectedItem.Value == "ASSESSMENT_YEAR")
                {
                    txtSearchCondition.Text += "\n" + rdoOr.Text + " A.[" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'%" + txtSearchContent.Text + "%'";
                }
                else
                {
                    txtSearchCondition.Text += "\n" + rdoOr.Text + " HR360_PR08_A.[" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'%" + txtSearchContent.Text + "%'";
                }
            }

        }
        else
        {
            if (condition.Length == 0)
            {
                if (ddlSearch_Item.SelectedItem.Value == "ASSESSMENT_YEAR")
                {
                    txtSearchCondition.Text = "A.[" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'" + txtSearchContent.Text + "'";
                }
                else
                {
                    txtSearchCondition.Text = "HR360_PR08_A.[" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'" + txtSearchContent.Text + "'";
                }
            }
            else if (rdoAnd.Checked == true)
            {
                if (ddlSearch_Item.SelectedItem.Value == "ASSESSMENT_YEAR")
                {
                    txtSearchCondition.Text += "\n" + rdoAnd.Text + " A.[" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'" + txtSearchContent.Text + "'";
                }
                else
                {
                    txtSearchCondition.Text += "\n" + rdoAnd.Text + " HR360_PR08_A.[" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'" + txtSearchContent.Text + "'";
                }
            }
            else if (rdoOr.Checked == true)
            {
                if (ddlSearch_Item.SelectedItem.Value == "ASSESSMENT_YEAR")
                {
                    txtSearchCondition.Text += "\n" + rdoOr.Text + " A.[" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'" + txtSearchContent.Text + "'";
                }
                else
                {
                    txtSearchCondition.Text += "\n" + rdoOr.Text + " HR360_PR08_A.[" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'" + txtSearchContent.Text + "'";
                }
            }
        }
    }
    protected void btnSearch_ClearCondition_Click(object sender, EventArgs e)
    {
        txtSearchCondition.Text = "";
    }
    protected void btnSearch_Search_Click(object sender, EventArgs e)
    {
        string query_condition = "";
        if (txtSearchCondition.Text != "") //有搜尋條件
        {
            query_condition = " WHERE " + txtSearchCondition.Text.Replace("\n", " ").Trim();
        }
        else
        {

        }
        string query = "WITH A"
                    + " AS"
                    + " ("
                    + " SELECT DISTINCT HR360_PR07_A.FORM_TYPE_ID"
                    + " , HR360_PR07_A.FORM_TYPE_NAME"
                    + " , HR360_PR07_A.ID [FORM_ID]"
                    + " , HR360_PR07_A.ASSESSMENT_YEAR"
                    + " , CONVERT(NVARCHAR(20), HR360_PR07_A.ASSESSMENT_START_DATE) + '~' + CONVERT(NVARCHAR(20), HR360_PR07_A.ASSESSMENT_END_DATE) [FORM_ASSESSMENT_PERIOD]"
                    + " , HR360_PR07_A.EMPLOYEE_ID"
                    + " , HR360_PR07_A.EMPLOYEE_NAME"
                    + " , HR360_PR07_A.EMPLOYEE_RANK"
                    + " , HR360_PR07_A.EMPLOYEE_DEPARTMENT"
                    + " FROM HR360_PR07_A"
                    + " )"
                    + " SELECT A.FORM_TYPE_ID"
                    + " , A.FORM_TYPE_NAME"
                    + " , A.FORM_ID"
                    + " , A.ASSESSMENT_YEAR"
                    + " , A.FORM_ASSESSMENT_PERIOD"
                    + " , A.EMPLOYEE_ID"
                    + " , A.EMPLOYEE_NAME"
                    + " , A.EMPLOYEE_RANK"
                    + " , A.EMPLOYEE_DEPARTMENT"
                    + " , (SELECT COUNT(HR360_PR08_A.ASSESSOR_ID) "
                    + " 	FROM HR360_PR08_A "
                    + " 	WHERE HR360_PR08_A.FORM_TYPE_ID = A.FORM_TYPE_ID AND HR360_PR08_A.FORM_ID = A.FORM_ID"
                    + " 	) ASSESSOR_NO"
                    + " FROM A"
                    + " LEFT JOIN HR360_PR08_A ON A.FORM_TYPE_ID = HR360_PR08_A.FORM_TYPE_ID AND A.FORM_ID = HR360_PR08_A.FORM_ID"
                    + query_condition
                    + " GROUP BY A.FORM_TYPE_ID, A.FORM_TYPE_NAME, A.FORM_ID, A.ASSESSMENT_YEAR, A.FORM_ASSESSMENT_PERIOD,"
                    + " A.EMPLOYEE_ID, A.EMPLOYEE_NAME, A.EMPLOYEE_RANK, A.EMPLOYEE_DEPARTMENT"
                    + " ORDER BY A.[FORM_TYPE_ID], A.FORM_ID DESC";

        try
        {
            using (SqlConnection conn = new SqlConnection(HR360connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grdForm_List.DataSource = ds;
                grdForm_List.DataBind();
                if (grdForm_List.Rows.Count != 0)
                {
                    grdForm_List.SelectedIndex = 0;
                    grdForm_List_SelectedIndexChanged(sender, e);
                }
                else
                {
                    grdForm_List.SelectedIndex = -1;
                }
            }
            Load_toplink(getPostBackControlName());
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void toplink_edit_Click(object sender, EventArgs e)
    {
        bool no_edit = true;
        using (SqlConnection conn = new SqlConnection(HR360connectionString))
        {
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand(("SELECT [NO_EDIT] FROM [HR360_PR07_A] WHERE [FORM_TYPE_ID]=FORM_TYPE_ID AND [ID]=@ID"), conn);
            cmdSelect.Parameters.AddWithValue("@FORM_TYPE_ID", Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[0].FindControl("grdlblForm_Type_Id")).Text));
            cmdSelect.Parameters.AddWithValue("@ID", Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[2].FindControl("grdlblForm_Id")).Text));
            SqlDataReader dr = cmdSelect.ExecuteReader();
            while (dr.Read())
            {
                no_edit = dr.GetBoolean(0);
            }
            if (!dr.IsClosed)
            {
                dr.Close();
            }
        }
        if (!no_edit)
        {
            if (grdForm_List.SelectedIndex == -1)
            {
                lblErrorMessage.Text = "需先選擇單據後才能進行修改";
            }
            else
            {
                lblErrorMessage.Text = "";
                txtForm_Assessment_Year.ReadOnly = false;
                txtForm_Assessment_Year.CssClass = "";
                txtForm_Type_Id.ReadOnly = false;
                txtForm_Type_Id.CssClass = "";
                btnForm_Type_Select.Enabled = true;
                txtAssessor_Id.Text = "";
                txtAssessor_Id.ReadOnly = false;
                txtAssessor_Id.CssClass = "";
                btnAssessor_Select.Enabled = true;
                btnAssessor_Import.Enabled = true;
                grdAssessor_List.Enabled = true;
            }
            //disable gridview while editing
            //grdResult.Enabled = false;
            grdForm_List.Enabled = false;

            Load_toplink(getPostBackControlName());
        }
        else
        {
            lblErrorMessage.Text = "此表已被使用，不可修改";
        }
    }
    protected void toplink_print_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void toplink_first_record_Click(object sender, ImageClickEventArgs e)
    {
        if (grdForm_List.Rows.Count != 0)
        {
            grdForm_List.SelectedIndex = 0;
            grdForm_List_SelectedIndexChanged(sender, e);
        }
        else
        {
            grdForm_List.SelectedIndex = -1;
        }
    }
    protected void toplink_previous_Click(object sender, ImageClickEventArgs e)
    {
        if (grdForm_List.Rows.Count != 0)
        {
            if (grdForm_List.SelectedIndex > 0)
            {
                grdForm_List.SelectedIndex--;
                grdForm_List_SelectedIndexChanged(sender, e);
            }
        }
        else
        {
            grdForm_List.SelectedIndex = -1;
        }
    }
    protected void toplink_next_Click(object sender, ImageClickEventArgs e)
    {
        if (grdForm_List.Rows.Count != 0)
        {
            if (grdForm_List.SelectedIndex < grdForm_List.Rows.Count - 1)
            {
                grdForm_List.SelectedIndex++;
                grdForm_List_SelectedIndexChanged(sender, e);
            }
        }
        else
        {
            grdForm_List.SelectedIndex = -1;
        }
    }
    protected void toplink_last_record_Click(object sender, ImageClickEventArgs e)
    {
        if (grdForm_List.Rows.Count != 0)
        {
            grdForm_List.SelectedIndex = grdForm_List.Rows.Count - 1;
            grdForm_List_SelectedIndexChanged(sender, e);
        }
        else
        {
            grdForm_List.SelectedIndex = -1;
        }
    }
    protected void toplink_save_Click(object sender, EventArgs e)
    {
        bool no_edit = true;
        using (SqlConnection conn = new SqlConnection(HR360connectionString))
        {
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand(("SELECT [NO_EDIT] FROM [HR360_PR07_A] WHERE [FORM_TYPE_ID]=FORM_TYPE_ID AND [ID]=@ID"), conn);
            cmdSelect.Parameters.AddWithValue("@FORM_TYPE_ID", Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[0].FindControl("grdlblForm_Type_Id")).Text));
            cmdSelect.Parameters.AddWithValue("@ID", Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[2].FindControl("grdlblForm_Id")).Text));
            SqlDataReader dr = cmdSelect.ExecuteReader();
            while (dr.Read())
            {
                no_edit = dr.GetBoolean(0);
            }
            if (!dr.IsClosed)
            {
                dr.Close();
            }
        }
        if (!no_edit)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(HR360connectionString))
                {
                    conn.Open();
                    //delete all the previous entries of this form, and re-add the list currently in grdKpi_Item
                    SqlCommand cmdDelete = new SqlCommand("DELETE FROM [HR360_PR08_A] WHERE [FORM_TYPE_ID]=@FORM_TYPE_ID AND [FORM_ID]=@FORM_ID", conn);
                    cmdDelete.Parameters.AddWithValue("@FORM_TYPE_ID", Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[0].FindControl("grdlblForm_Type_Id")).Text));
                    cmdDelete.Parameters.AddWithValue("@FORM_ID", Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[2].FindControl("grdlblForm_Id")).Text));
                    cmdDelete.ExecuteNonQuery();

                    foreach (GridViewRow row in grdAssessor_List.Rows)
                    {
                        SqlCommand cmdInsert = new SqlCommand("INSERT INTO [HR360_PR08_A] VALUES (GETDATE(),@CREATOR,GETDATE(),@MODIFIER,@ORDER,@FORM_TYPE_ID,@FORM_ID,@ASSESSOR_ID,@ASSESSOR_NAME,@ASSESSOR_DEPARTMENT,@ASSESSOR_RANK)", conn);
                        cmdInsert.Parameters.AddWithValue("@CREATOR", Session["user_id"]);
                        cmdInsert.Parameters.AddWithValue("@MODIFIER", Session["user_id"]);
                        cmdInsert.Parameters.AddWithValue("@ORDER", ((Label)row.Cells[1].FindControl("grdlblOrder")).Text);
                        cmdInsert.Parameters.AddWithValue("@FORM_TYPE_ID", Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[0].FindControl("grdlblForm_Type_Id")).Text));
                        cmdInsert.Parameters.AddWithValue("@FORM_ID", Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[2].FindControl("grdlblForm_Id")).Text));
                        cmdInsert.Parameters.AddWithValue("@ASSESSOR_ID", ((Label)row.Cells[2].FindControl("grdlblAssessor_Id")).Text);
                        cmdInsert.Parameters.AddWithValue("@ASSESSOR_NAME", ((Label)row.Cells[3].FindControl("grdlblAssessor_Name")).Text);
                        cmdInsert.Parameters.AddWithValue("@ASSESSOR_DEPARTMENT", ((Label)row.Cells[4].FindControl("grdlblAssessor_Department")).Text);
                        cmdInsert.Parameters.AddWithValue("@ASSESSOR_RANK", ((Label)row.Cells[5].FindControl("grdlblAssessor_Rank")).Text);
                        cmdInsert.ExecuteNonQuery();
                    }

                    lblErrorMessage.Text = "";
                    //enable grdResult after click
                    //grdResult.Enabled = true;
                    grdForm_List.Enabled = true;

                    Load_toplink(getPostBackControlName());
                }
                txtForm_Assessment_Year.Text = "";
                txtForm_Assessment_Year.ReadOnly = true;
                txtForm_Assessment_Year.CssClass = "read-only";
                txtForm_Type_Id.Text = "";
                txtForm_Type_Id.ReadOnly = true;
                txtForm_Type_Id.CssClass = "read-only";
                btnForm_Type_Select.Enabled = false;
                txtAssessor_Id.Text = "";
                txtAssessor_Id.ReadOnly = true;
                txtAssessor_Id.CssClass = "read-only";
                btnAssessor_Select.Enabled = false;
                lblAssessor_Name.Text = "";
                btnAssessor_Import.Enabled = false;
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.ToString();
            }            
        }
        else
        {
            lblErrorMessage.Text = "此表已被使用，不可修改";
            Load_toplink(getPostBackControlName());
        }
    }
    protected void toplink_cancel_Click(object sender, EventArgs e)
    {
        lblErrorMessage.Text = "";
        txtForm_Assessment_Year.Text = "";
        txtForm_Assessment_Year.ReadOnly = false;
        txtForm_Assessment_Year.CssClass = "";
        txtForm_Type_Id.Text = "";
        txtForm_Type_Id.ReadOnly = false;
        txtForm_Type_Id.CssClass = "";
        btnForm_Type_Select.Enabled = true;
        txtAssessor_Id.Text = "";
        txtAssessor_Id.ReadOnly = true;
        txtAssessor_Id.CssClass = "read-only";
        btnAssessor_Select.Enabled = false;
        lblAssessor_Name.Text = "";
        btnAssessor_Import.Enabled = false;

        //enable grdResult after click
        //grdResult.Enabled = true;
        grdForm_List.Enabled = true;

        Load_toplink(getPostBackControlName());
    }
    protected void toplink_delete_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(HR360connectionString))
            {
                conn.Open();
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM [HR360_PR08_A] WHERE [FORM_TYPE_ID]=@FORM_TYPE_ID AND [FORM_ID]=@FORM_ID", conn);
                cmdDelete.Parameters.AddWithValue("@FORM_TYPE_ID", Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[0].FindControl("grdlblForm_Type_Id")).Text));
                cmdDelete.Parameters.AddWithValue("@FORM_ID", (((Label)grdForm_List.SelectedRow.Cells[2].FindControl("grdlblForm_Id")).Text));
                cmdDelete.ExecuteNonQuery();

                btnSearch_ClearCondition_Click(sender, e);
                toplink_refresh_Click(sender, (ImageClickEventArgs)e);

                lblErrorMessage.Text = "";

                txtForm_Assessment_Year.Text = "";
                txtForm_Type_Id.Text = "";
                txtAssessor_Id.Text = "";
                lblAssessor_Name.Text = "";

                Load_toplink(getPostBackControlName());
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
        txtForm_Assessment_Year.ReadOnly = true;
        txtForm_Assessment_Year.CssClass = "read-only";
        txtForm_Type_Id.ReadOnly = true;
        txtForm_Type_Id.CssClass = "read-only";
        btnForm_Type_Select.Enabled = false;
        txtAssessor_Id.ReadOnly = true;
        txtAssessor_Id.CssClass = "read-only";
        btnAssessor_Select.Enabled = false;
        btnAssessor_Import.Enabled = false;
    }
    protected void toplink_refresh_Click(object sender, ImageClickEventArgs e)
    {
        if (grdForm_List.Rows.Count != 0)
        {
            int i = grdForm_List.SelectedIndex;
            btnSearch_Search_Click(sender, e);
            grdForm_List.SelectedIndex = i;
        }
        else
        {
            grdForm_List.SelectedIndex = -1;
        }
    }
    protected void toplink_copy_Click(object sender, EventArgs e)
    {        
        ////toplink_add_Click(sender, e);
        //lblErrorMessage.Text = "";
        //txtForm_Type_Id.Text = "";
        //txtForm_Type_Id.ReadOnly = false;
        //txtForm_Type_Id.CssClass = "required-field";
        //btnForm_Type_Select.Enabled = true;

        //lblEmployee_Name.Text = ViewState["lblEmployee_Name"].ToString();
        //lblEmployee_Rank.Text = ViewState["lblEmployee_Rank"].ToString();
        //lblEmployee_Department.Text = ViewState["lblEmployee_Department"].ToString();
        ////disable grdResult while in edit mode
        ////grdResult.Enabled = false;
        //grdForm_List.Enabled = false;

        Load_toplink(getPostBackControlName());
    }

    //page specific methods
    protected void txtForm_Assessment_Year_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string condition = fastSearchString(txtForm_Assessment_Year.Text.Trim(), txtForm_Type_Id.Text.Trim());

            using (SqlConnection conn = new SqlConnection(HR360connectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("WITH A"
                                                        + " AS"
                                                        + " ("
                                                        + " SELECT DISTINCT HR360_PR07_A.FORM_TYPE_ID"
                                                        + " , HR360_PR07_A.FORM_TYPE_NAME"
                                                        + " , HR360_PR07_A.ID [FORM_ID]"
                                                        + " , HR360_PR07_A.ASSESSMENT_YEAR"
                                                        + " , CONVERT(NVARCHAR(20), HR360_PR07_A.ASSESSMENT_START_DATE) + '~' + CONVERT(NVARCHAR(20), HR360_PR07_A.ASSESSMENT_END_DATE) [FORM_ASSESSMENT_PERIOD]"
                                                        + " , HR360_PR07_A.EMPLOYEE_ID"
                                                        + " , HR360_PR07_A.EMPLOYEE_NAME"
                                                        + " , HR360_PR07_A.EMPLOYEE_RANK"
                                                        + " , HR360_PR07_A.EMPLOYEE_DEPARTMENT"
                                                        + " FROM HR360_PR07_A"
                                                        + " )"
                                                        + " SELECT A.FORM_TYPE_ID"
                                                        + " , A.FORM_TYPE_NAME"
                                                        + " , A.FORM_ID"
                                                        + " , A.ASSESSMENT_YEAR"
                                                        + " , A.FORM_ASSESSMENT_PERIOD"
                                                        + " , A.EMPLOYEE_ID"
                                                        + " , A.EMPLOYEE_NAME"
                                                        + " , A.EMPLOYEE_RANK"
                                                        + " , A.EMPLOYEE_DEPARTMENT"
                                                        + " , (SELECT COUNT(HR360_PR08_A.ASSESSOR_ID) "
                                                        + " 	FROM HR360_PR08_A "
                                                        + " 	WHERE HR360_PR08_A.FORM_TYPE_ID = A.FORM_TYPE_ID AND HR360_PR08_A.FORM_ID = A.FORM_ID"
                                                        + " 	) ASSESSOR_NO"
                                                        + " FROM A"
                                                        + condition
                                                        + " ORDER BY A.FORM_TYPE_ID, A.FORM_ID DESC", conn);

                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grdForm_List.DataSource = dt;
                grdForm_List.DataBind();
            }
            if (grdForm_List.Rows.Count != 0)
            {
                grdForm_List.SelectedIndex = 0;
                grdForm_List_SelectedIndexChanged(sender, e);
            }
            else
            {
                grdForm_List.SelectedIndex = -1;
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void txtForm_Type_Id_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string condition = fastSearchString(txtForm_Assessment_Year.Text.Trim(), txtForm_Type_Id.Text.Trim());

            using (SqlConnection conn = new SqlConnection(HR360connectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("WITH A"
                                                        + " AS"
                                                        + " ("
                                                        + " SELECT DISTINCT HR360_PR07_A.FORM_TYPE_ID"
                                                        + " , HR360_PR07_A.FORM_TYPE_NAME"
                                                        + " , HR360_PR07_A.ID [FORM_ID]"
                                                        + " , HR360_PR07_A.ASSESSMENT_YEAR"
                                                        + " , CONVERT(NVARCHAR(20), HR360_PR07_A.ASSESSMENT_START_DATE) + '~' + CONVERT(NVARCHAR(20), HR360_PR07_A.ASSESSMENT_END_DATE) [FORM_ASSESSMENT_PERIOD]"
                                                        + " , HR360_PR07_A.EMPLOYEE_ID"
                                                        + " , HR360_PR07_A.EMPLOYEE_NAME"
                                                        + " , HR360_PR07_A.EMPLOYEE_RANK"
                                                        + " , HR360_PR07_A.EMPLOYEE_DEPARTMENT"
                                                        + " FROM HR360_PR07_A"
                                                        + " )"
                                                        + " SELECT A.FORM_TYPE_ID"
                                                        + " , A.FORM_TYPE_NAME"
                                                        + " , A.FORM_ID"
                                                        + " , A.ASSESSMENT_YEAR"
                                                        + " , A.FORM_ASSESSMENT_PERIOD"
                                                        + " , A.EMPLOYEE_ID"
                                                        + " , A.EMPLOYEE_NAME"
                                                        + " , A.EMPLOYEE_RANK"
                                                        + " , A.EMPLOYEE_DEPARTMENT"
                                                        + " , (SELECT COUNT(HR360_PR08_A.ASSESSOR_ID) "
                                                        + " 	FROM HR360_PR08_A "
                                                        + " 	WHERE HR360_PR08_A.FORM_TYPE_ID = A.FORM_TYPE_ID AND HR360_PR08_A.FORM_ID = A.FORM_ID"
                                                        + " 	) ASSESSOR_NO"
                                                        + " FROM A"
                                                        + condition
                                                        + " ORDER BY A.FORM_TYPE_ID, A.FORM_ID DESC", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grdForm_List.DataSource = dt;
                grdForm_List.DataBind();
            }
            if (grdForm_List.Rows.Count != 0)
            {
                grdForm_List.SelectedIndex = 0;
                grdForm_List_SelectedIndexChanged(sender, e);
            }
            else
            {
                grdForm_List.SelectedIndex = -1;
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
                SqlCommand cmdSelect = new SqlCommand("SELECT [ID] 單別代號, [NAME] 單別名稱 FROM [HR360_PR01_A] WHERE [FORM_TYPE] = N'PR07: 考績單建立作業'", conn);
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
        txtForm_Type_Id_TextChanged(sender, e);
    }
    protected void grdForm_List_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<string[]> grdSourceAssessor_List = new List<string[]>();
            lblErrorMessage.Text = "";
            using (SqlConnection conn = new SqlConnection(HR360connectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT [ORDER],[ASSESSOR_ID], ASSESSOR_NAME, ASSESSOR_DEPARTMENT, ASSESSOR_RANK"
                                                    + " FROM HR360_PR08_A"
                                                    + " WHERE FORM_TYPE_ID=@FORM_TYPE_ID AND FORM_ID=@FORM_ID", conn);
                cmdSelect.Parameters.AddWithValue("@FORM_TYPE_ID", Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[0].FindControl("grdlblForm_Type_Id")).Text.Trim()));
                cmdSelect.Parameters.AddWithValue("@FORM_ID", Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[2].FindControl("grdlblForm_Id")).Text.Trim()));
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //grdAssessor_List.DataSource = dt;
                //grdAssessor_List.DataBind();

                foreach (DataRow row in dt.Rows)
                {
                    grdSourceAssessor_List.Add(new string[] { row[0].ToString(), row[1].ToString() });
                }
                //foreach (GridViewRow row in grdAssessor_List.Rows)
                //{
                //    grdSourceAssessor_List.Add(new string[] { ((Label)row.Cells[1].FindControl("grdlblOrder")).Text, ((Label)row.Cells[2].FindControl("grdlblAssessor_Id")).Text });
                //}
                grdSourceAssessor_List = grdSourceAssessor_List.OrderBy(x => x[0]).ToList();
                Load_Assessor_Gridview(grdSourceAssessor_List);
            }
            imgAvatar.ImageUrl = "~/hr360/image/employee_profile/" + Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[5].FindControl("grdlblEmployee_Id")).Text) + ".jpg";
            lblEmployee_Id.Text = Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[5].FindControl("grdlblEmployee_Id")).Text);
            lblEmployee_Name.Text = Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[6].FindControl("grdlblEmployee_Name")).Text);
            lblEmployee_Rank.Text = Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[7].FindControl("grdlblEmployee_Rank")).Text);
            lblEmployee_Department.Text = Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[8].FindControl("grdlblEmployee_Department")).Text);
            lblForm_Id.Text = Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[0].FindControl("grdlblForm_Type_Id")).Text) + "-" + Server.HtmlDecode(((Label)grdForm_List.SelectedRow.Cells[2].FindControl("grdlblForm_Id")).Text);
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void txtAssessor_Id_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblErrorMessage.Text = "";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT CMSMV.MV001 員工代號, CMSMV.MV002 員工名稱, CMSMJ.MJ003 職稱, CMSME.ME002 部門名稱, CMSMV.MV031 年資 FROM CMSMV	LEFT JOIN CMSME ON CMSMV.MV004 = CMSME.ME001 LEFT JOIN CMSMJ ON CMSMV.MV006 = CMSMJ.MJ001 WHERE CMSMV.MV022 = N'' AND MV001=@ID", conn);
                cmdSelect.Parameters.AddWithValue("@ID", txtAssessor_Id.Text.Trim().ToUpper());
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                txtAssessor_Id.Text = dt.Rows[0][0].ToString().Trim();
                lblAssessor_Name.Text = dt.Rows[0][1].ToString().Trim();
            }
            else
            {
                lblErrorMessage.Text = "此代號不存在";
                txtAssessor_Id.Text = "";
                txtAssessor_Id.Focus();
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void btnAssessor_Select_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT CMSMV.MV001 員工代號, CMSMV.MV002 員工名稱, CMSMJ.MJ003 職稱, CMSME.ME002 部門名稱 FROM CMSMV	LEFT JOIN CMSME ON CMSMV.MV004 = CMSME.ME001 LEFT JOIN CMSMJ ON CMSMV.MV006 = CMSMJ.MJ001 WHERE CMSMV.MV022 = N''", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                DataTable dt = new DataTable();
                da.Fill(dt);

                grdAssessor.DataSource = dt;
                grdAssessor.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void grdAssessor_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAssessor_Id.Text = Server.HtmlDecode(grdAssessor.SelectedRow.Cells[0].Text.Trim());
        lblAssessor_Name.Text = Server.HtmlDecode(grdAssessor.SelectedRow.Cells[1].Text.Trim());
        txtAssessor_Id_TextChanged(sender, e);
    }
    protected void btnAssessor_Import_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            bool duplicate = false;
            foreach (GridViewRow row in grdAssessor_List.Rows)
            {
                if (((Label)row.Cells[2].FindControl("grdlblAssessor_Id")).Text.Trim() == txtAssessor_Id.Text.Trim())
                {
                    duplicate = true;
                    break;
                }
            }

            if (!duplicate)
            {
                List<string[]> grdSourceAssessor_List = new List<string[]>();
                //Assessor[] grdSourceAssessor_List = new Assessor[999];

                //string[][] array = new string[][] { };
                if (grdAssessor_List.Rows.Count != 0)
                {
                    //add existing assessors to list
                    foreach (GridViewRow row in grdAssessor_List.Rows)
                    {
                        grdSourceAssessor_List.Add(new string[] { ((Label)row.Cells[1].FindControl("grdlblOrder")).Text, ((Label)row.Cells[2].FindControl("grdlblAssessor_Id")).Text });
                    }
                    grdSourceAssessor_List = grdSourceAssessor_List.OrderBy(x => x[0]).ToList();
                    
                    //go down the list finding an empty spot for the new entry
                    for (int i = 0; i < grdSourceAssessor_List.Count + 1; i++)
                    {
                        if (i == 0)
                        {
                            if (Convert.ToInt16(grdSourceAssessor_List[i][0].ToString()) != 1)
                            {
                                grdSourceAssessor_List.Add(new string[] { "1", txtAssessor_Id.Text.Trim() });
                                break;
                            }
                        }
                        else if(i < grdSourceAssessor_List.Count)
                        {
                            if (Convert.ToInt16(grdSourceAssessor_List[i][0]) - 1 != Convert.ToInt16(grdSourceAssessor_List[i - 1][0]))
                            {
                                grdSourceAssessor_List.Add(new string[] { (i + 1).ToString(), txtAssessor_Id.Text.Trim() });
                                break;
                            }
                        }
                        else
                        {
                            grdSourceAssessor_List.Add(new string[] { (i + 1).ToString(), txtAssessor_Id.Text.Trim() });
                            break;
                        }
                    }
                }
                else
                {
                    grdSourceAssessor_List.Add(new string[] { "1", txtAssessor_Id.Text.Trim() });
                }
                grdSourceAssessor_List = grdSourceAssessor_List.OrderBy(x => x[0]).ToList();
                Load_Assessor_Gridview(grdSourceAssessor_List);
            }
            else
            {
                lblErrorMessage.Text = "此員工已是評核者";
                txtAssessor_Id.Focus();
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void grdAssessor_List_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<string[]> grdSourceAssessor_List = new List<string[]>();
        if ((List<string[]>)ViewState["grdSourceAssessor_List"] != null)
        {
            grdSourceAssessor_List = (List<string[]>)ViewState["grdSourceAssessor_List"];
        }
        for (int i = 0; i < grdSourceAssessor_List.Count; i++)
        {
            bool match = false;
            if (((Label)grdAssessor_List.Rows[e.RowIndex].Cells[2].FindControl("grdlblAssessor_Id")).Text == grdSourceAssessor_List[i][1])
            {
                grdSourceAssessor_List.RemoveAt(i);
                match = true;
            }
            if (match)
            {
                break;
            }
        }
        Load_Assessor_Gridview(grdSourceAssessor_List);
    }

    //loads assessors for the selected form in grdForm_List
    protected void Load_Assessor_Gridview(List<string[]> list1)
    {
        DataTable dt = new DataTable();
        foreach (string[] str in list1)
        {
            string query = "SELECT " + str[0].ToString() + " [ORDER], CMSMV.MV001 [ASSESSOR_ID], CMSMV.MV002 [ASSESSOR_NAME], CMSMJ.MJ003 [ASSESSOR_RANK], CMSME.ME002 [ASSESSOR_DEPARTMENT] FROM CMSMV LEFT JOIN CMSME ON CMSMV.MV004 = CMSME.ME001 LEFT JOIN CMSMJ ON CMSMV.MV006 = CMSMJ.MJ001 WHERE CMSMV.MV001=N'" + str[1].ToString() + "' ORDER BY [ORDER]";
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                SqlCommand cmdSearch = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmdSearch);
                da.Fill(dt);
            }
        }
        grdAssessor_List.DataSource = dt;
        grdAssessor_List.DataBind();
        ViewState["grdSourceAssessor_List"] = list1;
    }

    //create fast search query condition based on txtForm_Assessment_Year, txtForm_Type_Id, and ddlForm_Distribution
    protected string fastSearchString(params string[] condition)
    {
        string conditions = "";
        if (condition[0].ToString().Trim() != "")
        {
            conditions += " WHERE A.ASSESSMENT_YEAR=N'" + condition[0].ToString().Trim() + "'";
        }
        if (condition[1].ToString().Trim() != "")
        {
            if (condition[0].ToString().Trim() == "")
            {
                conditions += " WHERE A.FORM_TYPE_ID=N'" + condition[1].ToString().Trim() + "'";
            }
            else
            {
                conditions += " AND A.FORM_TYPE_ID=N'" + condition[1].ToString().Trim() + "'";
            }
        }        
        return conditions;
    }

}