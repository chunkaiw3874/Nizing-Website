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

public partial class hr360_PR07 : System.Web.UI.Page
{
    //universal functions
    string HR360connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    //functions that do not need change, and needed on every page
    //protected DataTable getPagePermission(string pageName)
    //{
    //    try
    //    {
    //        DataRow[] dr = ((Session["permission"]) as DataTable).Select("MODULE_ID = '" + pageName + "'");
    //        DataTable dt = ((Session["permission"]) as DataTable).Clone();
    //        foreach (DataRow row in dr)
    //        {
    //            dt.ImportRow(row);
    //        }
    //        return dt;
    //    }
    //    catch
    //    {
    //        DataTable dtnothing = new DataTable();
    //        Response.Redirect("~/hr360/no_permission.aspx");
    //        return dtnothing;
    //    }
    //}
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        AddRowSelectToGridView(grdResult);
        AddRowSelectToGridView(grdForm_Type);
        AddRowSelectToGridView(grdEmployee);
        AddRowSelectToGridView(grdGroup);
        AddRowSelectToGridView(grdKpi);

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
        //DataTable dt = getPagePermission(System.IO.Path.GetFileName(Request.PhysicalPath).Remove(System.IO.Path.GetFileName(Request.PhysicalPath).Length - 5));

        try
        {
            //if (dt.Rows.Count != 0)
            //{
                if (eventName == null)
                {
                    //enable and disable toplink base on user permission
                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                    //{
                        toplink_add.Enabled = true;
                        toplink_add.CssClass = "";
                    //}
                    //else
                    //{
                    //    toplink_add.Enabled = false;
                    //    toplink_add.CssClass = "disabled";
                    //}
                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][8].ToString().ToUpper().Equals("TRUE"))
                    //{
                        toplink_search.Enabled = true;
                        toplink_search.CssClass = "";
                    //}
                    //else
                    //{
                    //    toplink_search.Enabled = false;
                    //    toplink_search.CssClass = "disabled";
                    //}
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
                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                    //{
                        toplink_add.Enabled = true;
                        toplink_add.CssClass = "";
                    //}
                    //else
                    //{
                    //    toplink_add.Enabled = false;
                    //    toplink_add.CssClass = "disabled";
                    //}
                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][8].ToString().ToUpper().Equals("TRUE"))
                    //{
                        toplink_search.Enabled = true;
                        toplink_search.CssClass = "";
                    //}
                    //else
                    //{
                    //    toplink_search.Enabled = false;
                    //    toplink_search.CssClass = "disabled";
                    //}
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
                        //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][9].ToString().ToUpper().Equals("TRUE"))
                        //{
                            toplink_edit.Enabled = true;
                            toplink_edit.CssClass = "";
                        //}
                        //else
                        //{
                        //    toplink_edit.Enabled = false;
                        //    toplink_edit.CssClass = "disabled";
                        //}
                        //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][10].ToString().ToUpper().Equals("TRUE"))
                        //{
                            toplink_print.Enabled = true;
                            toplink_print.CssClass = "";
                        //}
                        //else
                        //{
                        //    toplink_print.Enabled = false;
                        //    toplink_print.CssClass = "disabled";
                        //}
                        //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][11].ToString().ToUpper().Equals("TRUE"))
                        //{
                            toplink_delete.Enabled = true;
                            toplink_delete.CssClass = "";
                        //}
                        //else
                        //{
                        //    toplink_delete.Enabled = false;
                        //    toplink_delete.CssClass = "disabled";
                        //}
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
                        //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                        //{
                            toplink_copy.Enabled = true;
                            toplink_copy.CssClass = "";
                        //}
                        //else
                        //{
                        //    toplink_copy.Enabled = false;
                        //    toplink_copy.CssClass = "disabled";
                        //}
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
                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                    //{
                        toplink_add.Enabled = true;
                        toplink_add.CssClass = "";
                    //}
                    //else
                    //{
                    //    toplink_add.Enabled = false;
                    //    toplink_add.CssClass = "disabled";
                    //}
                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][8].ToString().ToUpper().Equals("TRUE"))
                    //{
                        toplink_search.Enabled = true;
                        toplink_search.CssClass = "";
                    //}
                    //else
                    //{
                    //    toplink_search.Enabled = false;
                    //    toplink_search.CssClass = "disabled";
                    //}
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
                        //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][9].ToString().ToUpper().Equals("TRUE"))
                        //{
                            toplink_edit.Enabled = true;
                            toplink_edit.CssClass = "";
                        //}
                        //else
                        //{
                        //    toplink_edit.Enabled = false;
                        //    toplink_edit.CssClass = "disabled";
                        //}
                        //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][10].ToString().ToUpper().Equals("TRUE"))
                        //{
                            toplink_print.Enabled = true;
                            toplink_print.CssClass = "";
                        //}
                        //else
                        //{
                        //    toplink_print.Enabled = false;
                        //    toplink_print.CssClass = "disabled";
                        //}
                        //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][11].ToString().ToUpper().Equals("TRUE"))
                        //{
                            toplink_delete.Enabled = true;
                            toplink_delete.CssClass = "";
                        //}
                        //else
                        //{
                        //    toplink_delete.Enabled = false;
                        //    toplink_delete.CssClass = "disabled";
                        //}
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
                        //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                        //{
                            toplink_copy.Enabled = true;
                            toplink_copy.CssClass = "";
                        //}
                        //else
                        //{
                        //    toplink_copy.Enabled = false;
                        //    toplink_copy.CssClass = "disabled";
                        //}
                    }
                }
                else if (eventName == "toplink_cancel")
                {
                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                    //{
                        toplink_add.Enabled = true;
                        toplink_add.CssClass = "";
                    //}
                    //else
                    //{
                    //    toplink_add.Enabled = false;
                    //    toplink_add.CssClass = "disabled";
                    //}
                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][8].ToString().ToUpper().Equals("TRUE"))
                    //{
                        toplink_search.Enabled = true;
                        toplink_search.CssClass = "";
                    //}
                    //else
                    //{
                    //    toplink_search.Enabled = false;
                    //    toplink_search.CssClass = "disabled";
                    //}
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
                        //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][9].ToString().ToUpper().Equals("TRUE"))
                        //{
                            toplink_edit.Enabled = true;
                            toplink_edit.CssClass = "";
                        //}
                        //else
                        //{
                        //    toplink_edit.Enabled = false;
                        //    toplink_edit.CssClass = "disabled";
                        //}
                        //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][10].ToString().ToUpper().Equals("TRUE"))
                        //{
                            toplink_print.Enabled = true;
                            toplink_print.CssClass = "";
                        //}
                        //else
                        //{
                        //    toplink_print.Enabled = false;
                        //    toplink_print.CssClass = "disabled";
                        //}
                        //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][11].ToString().ToUpper().Equals("TRUE"))
                        //{
                            toplink_delete.Enabled = true;
                            toplink_delete.CssClass = "";
                        //}
                        //else
                        //{
                        //    toplink_delete.Enabled = false;
                        //    toplink_delete.CssClass = "disabled";
                        //}
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
                        //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                        //{
                            toplink_copy.Enabled = true;
                            toplink_copy.CssClass = "";
                        //}
                        //else
                        //{
                        //    toplink_copy.Enabled = false;
                        //    toplink_copy.CssClass = "disabled";
                        //}
                    }
                }
                else if (eventName == "toplink_delete")
                {
                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                    //{
                        toplink_add.Enabled = true;
                        toplink_add.CssClass = "";
                    //}
                    //else
                    //{
                    //    toplink_add.Enabled = false;
                    //    toplink_add.CssClass = "disabled";
                    //}
                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][8].ToString().ToUpper().Equals("TRUE"))
                    //{
                        toplink_search.Enabled = true;
                        toplink_search.CssClass = "";
                    //}
                    //else
                    //{
                    //    toplink_search.Enabled = false;
                    //    toplink_search.CssClass = "disabled";
                    //}
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
                        //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][9].ToString().ToUpper().Equals("TRUE"))
                        //{
                            toplink_edit.Enabled = true;
                            toplink_edit.CssClass = "";
                        //}
                        //else
                        //{
                        //    toplink_edit.Enabled = false;
                        //    toplink_edit.CssClass = "disabled";
                        //}
                        //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][10].ToString().ToUpper().Equals("TRUE"))
                        //{
                            toplink_print.Enabled = true;
                            toplink_print.CssClass = "";
                        //}
                        //else
                        //{
                        //    toplink_print.Enabled = false;
                        //    toplink_print.CssClass = "disabled";
                        //}
                        //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][11].ToString().ToUpper().Equals("TRUE"))
                        //{
                            toplink_delete.Enabled = true;
                            toplink_delete.CssClass = "";
                        //}
                        //else
                        //{
                        //    toplink_delete.Enabled = false;
                        //    toplink_delete.CssClass = "disabled";
                        //}
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
                        //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
                        //{
                            toplink_copy.Enabled = true;
                            toplink_copy.CssClass = "";
                        //}
                        //else
                        //{
                        //    toplink_copy.Enabled = false;
                        //    toplink_copy.CssClass = "disabled";
                        //}
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
            //}
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
        ViewState["lblForm_Type_En_Name"] = lblForm_Type_En_Name.Text;
        ViewState["txtId"] = txtId.Text.ToUpper().Trim();
        ViewState["txtAssessment_Start_Date"] = txtAssessment_Start_Date.Text.Trim();
        ViewState["txtAssessment_End_Date"] = txtAssessment_End_Date.Text.Trim();
        ViewState["txtAssessment_Year"] = txtAssessment_Year.Text.Trim();
        ViewState["txtEmployee_Id"] = txtEmployee_Id.Text.Trim().ToUpper();
        ViewState["lblEmployee_Name"] = lblEmployee_Name.Text;
        ViewState["lblEmployee_Rank"] = lblEmployee_Rank.Text;
        ViewState["lblEmployee_Department"] = lblEmployee_Department.Text;
        ViewState["lblEmployee_Year_In_Service"] = lblEmployee_Year_In_Service.Text;
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
            lblForm_Type_En_Name.Text = "";
            txtId.Text = "";
            txtAssessment_Start_Date.Text = "";
            txtAssessment_Start_Date.ReadOnly = true;
            txtAssessment_Start_Date.CssClass = "read-only";
            txtAssessment_End_Date.Text = "";
            txtAssessment_End_Date.ReadOnly = true;
            txtAssessment_End_Date.CssClass = "read-only";
            txtAssessment_Year.Text = "";
            txtAssessment_Year.ReadOnly = true;
            txtAssessment_Year.CssClass = "read-only";
            txtEmployee_Id.Text = "";
            txtEmployee_Id.ReadOnly = true;
            txtEmployee_Id.CssClass = "read-only";
            btnEmployee_Select.Enabled = false;
            lblEmployee_Name.Text = "";
            lblEmployee_Rank.Text = "";
            lblEmployee_Year_In_Service.Text = "";
            txtKpi_Group_Id.Text = "";
            txtKpi_Group_Id.ReadOnly = true;
            txtKpi_Group_Id.CssClass = "read-only";
            btnKpi_Group_Select.Enabled = false;
            txtKpi_Item_Id.Text = "";
            txtKpi_Item_Id.ReadOnly = true;
            txtKpi_Item_Id.CssClass = "read-only";
            btnKpi_Item_Select.Enabled = false;
            btnKpi_Input_Selection.Enabled = false;
            grdKpi_Category.Enabled = false;
            grdKpi_Item.Enabled = false;
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
        lblForm_Type_En_Name.Text = "";
        txtId.Text = "";
        txtAssessment_Start_Date.Text = "";
        txtAssessment_Start_Date.ReadOnly = false;
        txtAssessment_Start_Date.CssClass = "required-field";
        txtAssessment_End_Date.Text = "";
        txtAssessment_End_Date.ReadOnly = false;
        txtAssessment_End_Date.CssClass = "required-field";
        txtAssessment_Year.Text = "";
        txtAssessment_Year.ReadOnly = false;
        txtAssessment_Year.CssClass = "required-field";
        txtEmployee_Id.Text = "";
        txtEmployee_Id.ReadOnly = false;
        txtEmployee_Id.CssClass = "required-field";
        btnEmployee_Select.Enabled = true;
        lblEmployee_Name.Text = "";
        lblEmployee_Rank.Text = "";
        lblEmployee_Department.Text = "";
        lblEmployee_Year_In_Service.Text = "";
        txtKpi_Group_Id.Text = "";
        txtKpi_Group_Id.ReadOnly = false;
        txtKpi_Group_Id.CssClass = "";
        btnKpi_Group_Select.Enabled = true;
        txtKpi_Item_Id.Text = "";
        txtKpi_Item_Id.ReadOnly = false;
        txtKpi_Item_Id.CssClass = "";
        btnKpi_Item_Select.Enabled = true;
        btnKpi_Input_Selection.Enabled = true;
        grdKpi_Category.Enabled = true;
        //grdKpi_Category.DataSource = null;
        //grdKpi_Category.DataBind();
        grdKpi_Item.Enabled = true;
        //grdKpi_Item.DataSource = null;
        //grdKpi_Item.DataBind();
        List<string[]> grdSourceKpi_Item = new List<string[]>();
        Load_KPI_Gridview(grdSourceKpi_Item);
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
        string query = "SELECT [FORM_TYPE_ID] 評核單別, [FORM_TYPE_NAME] 評核單別名稱, [FORM_TYPE_EN_NAME] 評核單別英文名稱, [ID] 評核單號, [ASSESSMENT_START_DATE] 評核開始日期, [ASSESSMENT_END_DATE] 評核結束日期, [ASSESSMENT_YEAR] 評核年度, [EMPLOYEE_ID] 員工代號, [EMPLOYEE_NAME] 員工姓名, [EMPLOYEE_RANK] 員工職稱, [EMPLOYEE_DEPARTMENT] 員工部門, [EMPLOYEE_YEAR_IN_SERVICE] 員工年資, [CREATEDATE] 建立日期, [CREATOR] 建立者, [MODIFIEDDATE] 修改日期, [MODIFIER] 修改者 FROM [HR360_PR07_A]";
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
            query_condition += " ORDER BY [HR360_PR07_A].[FORM_TYPE_ID] ASC, [HR360_PR07_A].[ID] DESC";
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
        lblForm_Type_En_Name.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[2].Text);
        txtId.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[3].Text);
        txtAssessment_Start_Date.Text = Convert.ToDateTime(Server.HtmlDecode(grdResult.SelectedRow.Cells[4].Text)).ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
        txtAssessment_Start_Date.ReadOnly = true;
        txtAssessment_Start_Date.CssClass = "read-only";
        txtAssessment_End_Date.Text = Convert.ToDateTime(Server.HtmlDecode(grdResult.SelectedRow.Cells[5].Text)).ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
        txtAssessment_End_Date.ReadOnly = true;
        txtAssessment_End_Date.CssClass = "read-only";
        txtAssessment_Year.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[6].Text);
        txtAssessment_Year.ReadOnly = true;
        txtAssessment_Year.CssClass = "read-only";
        txtEmployee_Id.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[7].Text);
        txtEmployee_Id.ReadOnly = true;
        txtEmployee_Id.CssClass = "read-only";
        btnEmployee_Select.Enabled = false;
        lblEmployee_Name.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[8].Text);
        lblEmployee_Rank.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[9].Text);
        lblEmployee_Department.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[10].Text);
        lblEmployee_Year_In_Service.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[11].Text);
        txtKpi_Group_Id.Text = "";
        txtKpi_Group_Id.ReadOnly = true;
        txtKpi_Group_Id.CssClass = "read-only";
        btnKpi_Group_Select.Enabled = false;
        lblKpi_Group_Name.Text = "";
        txtKpi_Item_Id.Text = "";
        txtKpi_Item_Id.ReadOnly = true;
        txtKpi_Item_Id.CssClass = "read-only";
        btnKpi_Item_Select.Enabled = false;
        lblKpi_Item_Name.Text = "";
        btnKpi_Input_Selection.Enabled = false;
        using (SqlConnection conn = new SqlConnection(HR360connectionString))
        {
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT [KPI_ITEM_ID], [MEMO] FROM [HR360_PR07_B] WHERE [FORM_TYPE_ID]=@FORMTYPEID AND [FORM_ID]=@ID", conn);
            cmdSelect.Parameters.AddWithValue("@FORMTYPEID", txtForm_Type_Id.Text.Trim().ToUpper());
            cmdSelect.Parameters.AddWithValue("@ID", txtId.Text.Trim());
            SqlDataReader dr = cmdSelect.ExecuteReader();
            //SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
            //DataTable dt = new DataTable();
            List<string[]> grdSourceKpi_Item = new List<string[]>();
            while (dr.Read())
            {
                grdSourceKpi_Item.Add(new string[]{dr.GetString(0), dr.GetString(1)});
            }
            if (!dr.IsClosed)
            {
                dr.Close();
            }
            Load_KPI_Gridview(grdSourceKpi_Item);
        }
        grdKpi_Category.Enabled = false;
        grdKpi_Item.Enabled = false;
    }
    //
    protected void toplink_edit_Click(object sender, EventArgs e)
    {
        bool no_edit = true;
        using (SqlConnection conn = new SqlConnection(HR360connectionString))
        {
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand(("SELECT [NO_EDIT] FROM [HR360_PR07_A] WHERE [FORM_TYPE_ID]=FORM_TYPE_ID AND [ID]=@ID"), conn);
            cmdSelect.Parameters.AddWithValue("@FORM_TYPE_ID", txtForm_Type_Id.Text.Trim().ToUpper());
            cmdSelect.Parameters.AddWithValue("@ID", txtId.Text);
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
                txtAssessment_Start_Date.ReadOnly = false;
                txtAssessment_Start_Date.CssClass = "required-field";
                txtAssessment_End_Date.ReadOnly = false;
                txtAssessment_End_Date.CssClass = "required-field";
                txtAssessment_Year.ReadOnly = false;
                txtAssessment_Year.CssClass = "required-field";
                txtEmployee_Id.ReadOnly = false;
                txtEmployee_Id.CssClass = "required-field";
                btnEmployee_Select.Enabled = true;
                txtKpi_Group_Id.Text = "";
                txtKpi_Group_Id.ReadOnly = false;
                txtKpi_Group_Id.CssClass = "";
                btnKpi_Group_Select.Enabled = true;
                txtKpi_Item_Id.Text = "";
                txtKpi_Item_Id.ReadOnly = false;
                txtKpi_Item_Id.CssClass = "";
                btnKpi_Item_Select.Enabled = true;
                btnKpi_Input_Selection.Enabled = true;
                grdKpi_Category.Enabled = true;
                grdKpi_Item.Enabled = true;
            }
            //disable gridview while editing
            grdResult.Enabled = false;

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
        DateTime dateValue_Start;
        DateTime dateValue_End;
        DateTime dateValue_Year;
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
        if (txtForm_Type_Id.Text.Trim() == "" || !isMatchFormType)
        {
            lblErrorMessage.Text = "請選擇正確的單別代號";
            txtForm_Type_Id.ReadOnly = false;
            txtForm_Type_Id.CssClass = "required-field";
            btnForm_Type_Select.Enabled = true;
        }
        else if (!DateTime.TryParseExact(txtAssessment_Start_Date.Text.Trim().ToUpper(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue_Start))
        {
            lblErrorMessage.Text = "評核期間不符合yyyy/MM/dd的格式";
            txtAssessment_Start_Date.ReadOnly = false;
            txtAssessment_Start_Date.CssClass = "required-field";
            txtAssessment_Start_Date.Focus();
        }
        else if (!DateTime.TryParseExact(txtAssessment_End_Date.Text.Trim().ToUpper(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue_End))
        {
            lblErrorMessage.Text = "評核期間不符合yyyy/MM/dd的格式";
            txtAssessment_End_Date.ReadOnly = false;
            txtAssessment_End_Date.CssClass = "required-field";
            txtAssessment_End_Date.Focus();
        }
        else if (dateValue_End.Date < dateValue_Start.Date)
        {
            lblErrorMessage.Text = "評核結束日期不可小於評核開始日期";
            txtAssessment_Start_Date.ReadOnly = false;
            txtAssessment_Start_Date.CssClass = "required-field";
            txtAssessment_End_Date.ReadOnly = false;
            txtAssessment_End_Date.CssClass = "required-field";
            txtAssessment_Start_Date.Focus();
        }
        else if (!DateTime.TryParseExact(txtAssessment_Year.Text.Trim().ToUpper(), "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue_Year))
        {
            lblErrorMessage.Text = "評核年度不符合yyyy的格式";
            txtAssessment_Year.ReadOnly = false;
            txtAssessment_Year.CssClass = "required-field";
            txtAssessment_Year.Focus();
        }
        else if (txtEmployee_Id.Text.Trim() == "" || !isMatchEmployeeId)
        {
            lblErrorMessage.Text = "請選擇正確的員工代號";
            txtEmployee_Id.ReadOnly = false;
            txtEmployee_Id.CssClass = "required-field";
            txtEmployee_Id.Focus();
            btnEmployee_Select.Enabled = true;
        }
        else
        {
            try
            {
                if (txtForm_Type_Id.ReadOnly == false) //新增
                {
                    using (SqlConnection conn = new SqlConnection(HR360connectionString))
                    {
                        SqlCommand cmdDuplicateSearch = new SqlCommand("SELECT [ID] FROM [HR360_PR07_A] WHERE [ID] = @ID AND [FORM_TYPE_ID]=@FORMTYPEID", conn);
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
                            SqlCommand cmdSelect = new SqlCommand("SELECT [HR360_PR01_A].[ID], [HR360_PR01_A].[NAME], [HR360_PR01_A].[CODE_FORMAT] FROM [HR360_PR01_A] LEFT JOIN [HR360_PR07_A] ON [HR360_PR01_A].[ID] = [HR360_PR07_A].[FORM_TYPE_ID] WHERE [HR360_PR01_A].[FORM_TYPE] = N'PR07: 考績單建立作業' AND [HR360_PR01_A].[ID]=@ID", conn);
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
                            string seqNo = DateTime.Now.Year.ToString().Substring(4 - year, year) + DateTime.Now.Month.ToString();
                            if (day != 0)
                            {
                                seqNo += DateTime.Now.Month.ToString();
                            }

                            //check for the highest ID with the same Code prior to 流水號
                            dt = new DataTable();

                            cmdSelect = new SqlCommand("SELECT [HR360_PR07_A].[ID] FROM [HR360_PR07_A] LEFT JOIN [HR360_PR01_A] ON [HR360_PR07_A].[FORM_TYPE_ID] = [HR360_PR01_A].[ID] WHERE [HR360_PR01_A].[FORM_TYPE] = N'PR07: 考績單建立作業' AND [HR360_PR07_A].[FORM_TYPE_ID]=@FORMTYPEID AND [HR360_PR07_A].[ID] LIKE @PRO7AID ORDER BY [HR360_PR07_A].[ID] DESC", conn);
                            cmdSelect.Parameters.AddWithValue("@FORMTYPEID", txtForm_Type_Id.Text.Trim().ToUpper());
                            cmdSelect.Parameters.AddWithValue("@PRO7AID", seqNo + "%");
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
                            SqlCommand cmdInsert = new SqlCommand("INSERT INTO [HR360_PR07_A] VALUES (GETDATE(), @CREATOR, GETDATE(), @MODIFIER, @FORM_TYPE_ID, @FORM_TYPE_NAME, @FORM_TYPE_EN_NAME, @ID, @ASSESSMENT_START_DATE, @ASSESSMENT_END_DATE, @ASSESSMENT_YEAR, @EMPLOYEE_ID, @EMPLOYEE_NAME, @EMPLOYEE_RANK, @EMPLOYEE_DEPARTMENT, @EMPLOYEE_YEAR_IN_SERVICE, 0)", conn);
                            cmdInsert.Parameters.AddWithValue("@CREATOR", Session["user_id"]);
                            cmdInsert.Parameters.AddWithValue("@MODIFIER", Session["user_id"]);
                            cmdInsert.Parameters.AddWithValue("@FORM_TYPE_ID", txtForm_Type_Id.Text.ToUpper().Trim());
                            cmdInsert.Parameters.AddWithValue("@FORM_TYPE_NAME", lblForm_Type_Name.Text);
                            cmdInsert.Parameters.AddWithValue("@FORM_TYPE_EN_NAME", lblForm_Type_En_Name.Text);
                            cmdInsert.Parameters.AddWithValue("@ID", txtId.Text.ToUpper().Trim());
                            cmdInsert.Parameters.AddWithValue("@ASSESSMENT_START_DATE", txtAssessment_Start_Date.Text.Trim());
                            cmdInsert.Parameters.AddWithValue("@ASSESSMENT_END_DATE", txtAssessment_End_Date.Text.Trim());
                            cmdInsert.Parameters.AddWithValue("@ASSESSMENT_YEAR", txtAssessment_Year.Text.Trim());
                            cmdInsert.Parameters.AddWithValue("@EMPLOYEE_ID", txtEmployee_Id.Text.ToUpper().Trim());
                            cmdInsert.Parameters.AddWithValue("@EMPLOYEE_NAME", lblEmployee_Name.Text);
                            cmdInsert.Parameters.AddWithValue("@EMPLOYEE_RANK", lblEmployee_Rank.Text);
                            cmdInsert.Parameters.AddWithValue("@EMPLOYEE_DEPARTMENT", lblEmployee_Department.Text);
                            cmdInsert.Parameters.AddWithValue("@EMPLOYEE_YEAR_IN_SERVICE", lblEmployee_Year_In_Service.Text);
                            cmdInsert.ExecuteNonQuery();
                            //save information to pr07_b
                            foreach (GridViewRow row in grdKpi_Item.Rows)
                            {
                                //find the kpi category information for the kpi item in that row
                                SqlCommand cmdSelect = new SqlCommand("SELECT [HR360_PR04_A].[ID], [HR360_PR04_A].[NAME], [HR360_PR04_A].[MEMO] FROM [HR360_PR05_A] LEFT JOIN [HR360_PR04_A] ON [HR360_PR05_A].[CATEGORY_ID] = [HR360_PR04_A].[ID] WHERE [HR360_PR05_A].[ID] = @ID", conn);
                                cmdSelect.Parameters.AddWithValue("@ID", ((Label)row.Cells[2].FindControl("lblKpi_Id")).Text);
                                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                cmdInsert = new SqlCommand("INSERT INTO [HR360_PR07_B] VALUES (GETDATE(), @CREATOR, GETDATE(), @MODIFIER, @FORM_TYPE_ID, @FORM_ID, @KPI_CATEGORY_ID, @KPI_CATEGORY_NAME, @KPI_CATEGORY_MEMO, @KPI_ITEM_ID, @KPI_ITEM_NAME, @MEMO)", conn);
                                cmdInsert.Parameters.AddWithValue("@CREATOR", Session["user_id"]);
                                cmdInsert.Parameters.AddWithValue("@MODIFIER", Session["user_id"]);
                                cmdInsert.Parameters.AddWithValue("@FORM_TYPE_ID", txtForm_Type_Id.Text.Trim().ToUpper());
                                cmdInsert.Parameters.AddWithValue("@FORM_ID", txtId.Text.Trim());
                                cmdInsert.Parameters.AddWithValue("@KPI_CATEGORY_ID", dt.Rows[0][0]);
                                cmdInsert.Parameters.AddWithValue("@KPI_CATEGORY_NAME", dt.Rows[0][1]);
                                cmdInsert.Parameters.AddWithValue("@KPI_CATEGORY_MEMO", dt.Rows[0][2]);
                                cmdInsert.Parameters.AddWithValue("@KPI_ITEM_ID", ((Label)row.Cells[2].FindControl("lblKpi_Id")).Text);
                                cmdInsert.Parameters.AddWithValue("@KPI_ITEM_NAME", ((Label)row.Cells[3].FindControl("lblKpi_Name")).Text);
                                cmdInsert.Parameters.AddWithValue("@MEMO", ((TextBox)row.Cells[4].FindControl("txtMemo")).Text.Trim());
                                cmdInsert.ExecuteNonQuery();
                            }
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
                        //delete all the previous entries of this form, and re-add the list currently in grdKpi_Item
                        SqlCommand cmdDelete = new SqlCommand("DELETE FROM [HR360_PR07_B] WHERE [FORM_TYPE_ID]=@FORM_TYPE_ID AND [FORM_ID]=@FORM_ID", conn);
                        cmdDelete.Parameters.AddWithValue("@FORM_TYPE_ID", txtForm_Type_Id.Text.Trim().ToUpper());
                        cmdDelete.Parameters.AddWithValue("@FORM_ID", txtId.Text.Trim().ToUpper());
                        cmdDelete.ExecuteNonQuery();

                        //re-add information to pr07_b
                        foreach (GridViewRow row in grdKpi_Item.Rows)
                        {
                            //find the kpi category information for the kpi item in that row
                            SqlCommand cmdSelect = new SqlCommand("SELECT [HR360_PR04_A].[ID], [HR360_PR04_A].[NAME], [HR360_PR04_A].[MEMO] FROM [HR360_PR05_A] LEFT JOIN [HR360_PR04_A] ON [HR360_PR05_A].[CATEGORY_ID] = [HR360_PR04_A].[ID] WHERE [HR360_PR05_A].[ID] = @ID", conn);
                            cmdSelect.Parameters.AddWithValue("@ID", ((Label)row.Cells[2].FindControl("lblKpi_Id")).Text);
                            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            SqlCommand cmdInsert = new SqlCommand("INSERT INTO [HR360_PR07_B] VALUES (GETDATE(), @CREATOR, GETDATE(), @MODIFIER, @FORM_TYPE_ID, @FORM_ID, @KPI_CATEGORY_ID, @KPI_CATEGORY_NAME, @KPI_CATEGORY_MEMO, @KPI_ITEM_ID, @KPI_ITEM_NAME, @MEMO)", conn);
                            cmdInsert.Parameters.AddWithValue("@CREATOR", Session["user_id"]);
                            cmdInsert.Parameters.AddWithValue("@MODIFIER", Session["user_id"]);
                            cmdInsert.Parameters.AddWithValue("@FORM_TYPE_ID", txtForm_Type_Id.Text.Trim().ToUpper());
                            cmdInsert.Parameters.AddWithValue("@FORM_ID", txtId.Text.Trim());
                            cmdInsert.Parameters.AddWithValue("@KPI_CATEGORY_ID", dt.Rows[0][0]);
                            cmdInsert.Parameters.AddWithValue("@KPI_CATEGORY_NAME", dt.Rows[0][1]);
                            cmdInsert.Parameters.AddWithValue("@KPI_CATEGORY_MEMO", dt.Rows[0][2]);
                            cmdInsert.Parameters.AddWithValue("@KPI_ITEM_ID", ((Label)row.Cells[2].FindControl("lblKpi_Id")).Text);
                            cmdInsert.Parameters.AddWithValue("@KPI_ITEM_NAME", ((Label)row.Cells[3].FindControl("lblKpi_Name")).Text);
                            cmdInsert.Parameters.AddWithValue("@MEMO", ((TextBox)row.Cells[4].FindControl("txtMemo")).Text.Trim());
                            cmdInsert.ExecuteNonQuery();
                        }
                        lblErrorMessage.Text = "";
                        //enable grdResult after click
                        grdResult.Enabled = true;
                        Load_toplink(getPostBackControlName());
                    }
                }
                txtForm_Type_Id.ReadOnly = true;
                txtForm_Type_Id.CssClass = "read-only";
                btnForm_Type_Select.Enabled = false;
                txtAssessment_Start_Date.ReadOnly = true;
                txtAssessment_Start_Date.CssClass = "read-only";
                txtAssessment_End_Date.ReadOnly = true;
                txtAssessment_End_Date.CssClass = "read-only";
                txtAssessment_Year.ReadOnly = true;
                txtAssessment_Year.CssClass = "read-only";
                txtEmployee_Id.ReadOnly = true;
                txtEmployee_Id.CssClass = "read-only";
                btnEmployee_Select.Enabled = false;
                txtKpi_Group_Id.Text = "";
                txtKpi_Group_Id.ReadOnly = true;
                txtKpi_Group_Id.CssClass = "read-only";
                btnKpi_Group_Select.Enabled = false;
                lblKpi_Group_Name.Text = "";
                txtKpi_Item_Id.Text = "";
                txtKpi_Item_Id.ReadOnly = true;
                txtKpi_Item_Id.CssClass = "read-only";
                btnKpi_Item_Select.Enabled = false;
                lblKpi_Item_Name.Text = "";
                grdKpi_Category.Enabled = false;
                grdKpi_Item.Enabled = false;
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
        lblForm_Type_En_Name.Text = "";
        txtId.Text = ViewState["txtId"].ToString();
        txtAssessment_Start_Date.Text = "";
        txtAssessment_Start_Date.ReadOnly = true;
        txtAssessment_Start_Date.CssClass = "read-only";
        txtAssessment_End_Date.Text = "";
        txtAssessment_End_Date.ReadOnly = true;
        txtAssessment_End_Date.CssClass = "read-only";
        txtAssessment_Year.Text = "";
        txtAssessment_Year.ReadOnly = true;
        txtAssessment_Year.CssClass = "read-only";
        txtEmployee_Id.Text = "";
        txtEmployee_Id.ReadOnly = true;
        txtEmployee_Id.CssClass = "read-only";
        btnEmployee_Select.Enabled = false;
        lblEmployee_Name.Text = "";
        lblEmployee_Rank.Text = "";
        lblEmployee_Department.Text = "";
        lblEmployee_Year_In_Service.Text = "";
        txtKpi_Group_Id.Text = "";
        txtKpi_Group_Id.ReadOnly = true;
        txtKpi_Group_Id.CssClass = "read-only";
        btnKpi_Group_Select.Enabled = false;
        lblKpi_Group_Name.Text = "";
        txtKpi_Item_Id.Text = "";
        txtKpi_Item_Id.ReadOnly = true;
        txtKpi_Item_Id.CssClass = "read-only";
        btnKpi_Item_Select.Enabled = false;
        lblKpi_Item_Name.Text = "";
        btnKpi_Input_Selection.Enabled = false;
        List<string[]> grdSourceKpi_Item = new List<string[]>();
        Load_KPI_Gridview(grdSourceKpi_Item);

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
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT [ID] FROM [HR360_PR07_A] WHERE [ID] = @ID AND [FORM_TYPE_ID]=@FORMTYPEID", conn);
                cmd.Parameters.AddWithValue("@FORMTYPEID", txtForm_Type_Id.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@ID", txtId.Text.ToUpper().Trim());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    SqlCommand cmdDelete = new SqlCommand("DELETE FROM [HR360_PR07_B] WHERE [FORM_ID] = @ID AND [FORM_TYPE_ID]=@FORMTYPEID", conn);
                    cmdDelete.Parameters.AddWithValue("@FORMTYPEID", txtForm_Type_Id.Text.Trim().ToUpper());
                    cmdDelete.Parameters.AddWithValue("@ID", txtId.Text.ToUpper().Trim());
                    cmdDelete.ExecuteNonQuery();

                    cmdDelete = new SqlCommand("DELETE FROM [HR360_PR07_A] WHERE [ID] = @ID AND [FORM_TYPE_ID]=@FORMTYPEID", conn);
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
                    lblForm_Type_En_Name.Text = "";
                    txtId.Text = "";
                    txtAssessment_Start_Date.Text = "";
                    txtAssessment_End_Date.Text = "";
                    txtAssessment_Year.Text = "";
                    txtEmployee_Id.Text = "";
                    lblEmployee_Name.Text = "";
                    lblEmployee_Rank.Text = "";
                    lblEmployee_Department.Text = "";
                    lblEmployee_Year_In_Service.Text = "";
                    txtKpi_Group_Id.Text = "";
                    lblKpi_Group_Name.Text = "";
                    txtKpi_Item_Id.Text = "";
                    lblKpi_Item_Name.Text = "";
                    grdGroup.DataSource = null;
                    grdGroup.DataBind();
                    grdKpi.DataSource = null;
                    grdKpi.DataBind();

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
        txtAssessment_Start_Date.ReadOnly = true;
        txtAssessment_Start_Date.CssClass = "read-only";
        txtAssessment_End_Date.ReadOnly = true;
        txtAssessment_End_Date.CssClass = "read-only";
        txtAssessment_Year.ReadOnly = true;
        txtAssessment_Year.CssClass = "read-only";
        txtEmployee_Id.ReadOnly = true;
        txtEmployee_Id.CssClass = "read-only";
        btnEmployee_Select.Enabled = false;
        txtKpi_Group_Id.ReadOnly = true;
        txtKpi_Group_Id.CssClass = "read-only";
        btnKpi_Group_Select.Enabled = false;
        txtKpi_Item_Id.ReadOnly = true;
        txtKpi_Item_Id.CssClass = "read-only";
        btnKpi_Item_Select.Enabled = false;
        btnKpi_Input_Selection.Enabled = false;
        grdKpi_Category.DataSource = null;
        grdKpi_Category.DataBind();
        grdKpi_Category.Enabled = false;
        grdKpi_Item.DataSource = null;
        grdKpi_Item.DataBind();
        grdKpi_Item.Enabled = false;
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
        txtId.Text = "";
        txtAssessment_Start_Date.Text = ViewState["txtAssessment_Start_Date"].ToString();
        txtAssessment_Start_Date.ReadOnly = true;
        txtAssessment_Start_Date.CssClass = "read-only";
        txtAssessment_End_Date.Text = ViewState["txtAssessment_End_Date"].ToString();
        txtAssessment_End_Date.ReadOnly = true;
        txtAssessment_End_Date.CssClass = "read-only";
        txtAssessment_Year.Text = ViewState["txtAssessment_Year"].ToString();
        txtAssessment_Year.ReadOnly = true;
        txtAssessment_Year.CssClass = "read-only";
        txtEmployee_Id.Text = ViewState["txtEmployee_Id"].ToString();
        txtEmployee_Id.ReadOnly = true;
        txtEmployee_Id.CssClass = "read-only";
        btnEmployee_Select.Enabled = false;
        lblEmployee_Name.Text = ViewState["lblEmployee_Name"].ToString();
        lblEmployee_Rank.Text = ViewState["lblEmployee_Rank"].ToString();
        lblEmployee_Department.Text = ViewState["lblEmployee_Department"].ToString();
        lblEmployee_Year_In_Service.Text = ViewState["lblEmployee_Year_In_Service"].ToString();
        List<string[]> grdSourceKpi_Item = (List<string[]>)ViewState["grdSourceKpi_Item"];
        Load_KPI_Gridview(grdSourceKpi_Item);
        //disable grdResult while in edit mode
        grdResult.Enabled = false;

        Load_toplink(getPostBackControlName());
    }

    //page specific methods
    protected void Load_KPI_Gridview(List<string[]> list1)
    {
        string query = "SELECT ROW_NUMBER() OVER(ORDER BY [HR360_PR05_A].[CATEGORY_ID], [HR360_PR05_A].[ID]) RN, [HR360_PR05_A].[ID] [ID], [HR360_PR05_A].[NAME] [NAME], [HR360_PR05_A].[CATEGORY_ID] [CATEGORY_ID], [HR360_PR04_A].[NAME] [CATEGORY_NAME], [HR360_PR04_A].[MEMO] [CATEGORY_MEMO] FROM [HR360_PR05_A] LEFT JOIN [HR360_PR04_A] ON [HR360_PR05_A].[CATEGORY_ID] = [HR360_PR04_A].[ID]";
        string condition = "";
        //load kpi item gridview
        //if list is empty
        if (list1 == null || list1.Count == 0)
        {
            condition = " WHERE [HR360_PR05_A].[ID] = N'-1'";
        }
        else
        {
            for (int i = 0; i < list1.Count; i++)
            {
                if (i == 0)
                {
                    if (list1.Count == 1)
                    {
                        condition = " WHERE [HR360_PR05_A].[ID]=N'" + list1[i][0].ToString() + "'";
                    }
                    else
                    {
                        condition = " WHERE [HR360_PR05_A].[ID]=N'" + list1[i][0].ToString() + "' OR ";
                    }
                }
                else if (i != list1.Count - 1)
                {
                    condition += " [HR360_PR05_A].[ID]=N'" + list1[i][0].ToString() + "' OR";
                }
                else
                {
                    condition += " [HR360_PR05_A].[ID]=N'" + list1[i][0].ToString() + "'";
                }
            }
        }
        using (SqlConnection conn = new SqlConnection(HR360connectionString))
        {
            conn.Open();
            SqlCommand cmdSearch = new SqlCommand(query + condition, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmdSearch);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grdKpi_Item.DataSource = dt;
            grdKpi_Item.DataBind();
            grdKpi_Category.DataSource = dt;
            grdKpi_Category.DataBind();
        }
        for (int i = 0; i < grdKpi_Item.Rows.Count; i++)
        {
            foreach (string[] str in list1)
            {
                if (str[0].ToString() == Server.HtmlDecode(((Label)grdKpi_Item.Rows[i].Cells[1].FindControl("lblKpi_Id")).Text))
                {
                    ((TextBox)grdKpi_Item.Rows[i].Cells[4].FindControl("txtMemo")).Text = Server.HtmlDecode(str[1].ToString());
                }
            }
        }
        ViewState["grdSourceKpi_Item"] = list1;
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
        lblForm_Type_En_Name.Text = Server.HtmlDecode(grdForm_Type.SelectedRow.Cells[2].Text);
        txtForm_Type_Id_TextChanged(sender, e);
    }
    protected void btnEmployee_Select_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT CMSMV.MV001 員工代號, CMSMV.MV002 員工名稱, CMSMJ.MJ003 職稱, CMSME.ME002 部門名稱, CMSMV.MV031 年資 FROM CMSMV	LEFT JOIN CMSME ON CMSMV.MV004 = CMSME.ME001 LEFT JOIN CMSMJ ON CMSMV.MV006 = CMSMJ.MJ001 WHERE CMSMV.MV022 = N''", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                DataTable dt = new DataTable();
                da.Fill(dt);

                grdEmployee.DataSource = dt;
                grdEmployee.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtEmployee_Id.Text = Server.HtmlDecode(grdEmployee.SelectedRow.Cells[0].Text);
        lblEmployee_Name.Text = Server.HtmlDecode(grdEmployee.SelectedRow.Cells[1].Text);
        lblEmployee_Rank.Text = Server.HtmlDecode(grdEmployee.SelectedRow.Cells[2].Text);
        lblEmployee_Department.Text = Server.HtmlDecode(grdEmployee.SelectedRow.Cells[3].Text);
        lblEmployee_Year_In_Service.Text = Server.HtmlDecode(grdEmployee.SelectedRow.Cells[4].Text);
        txtEmployee_Id_TextChanged(sender, e);
    }
    protected void txtForm_Type_Id_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblErrorMessage.Text = "";

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
                    SqlCommand cmdSelect = new SqlCommand("SELECT [HR360_PR01_A].[ID], [HR360_PR01_A].[NAME], [HR360_PR01_A].[CODE_FORMAT] FROM [HR360_PR01_A] WHERE [HR360_PR01_A].[FORM_TYPE] = N'PR07: 考績單建立作業' AND [HR360_PR01_A].[ID]=@ID", conn);
                    cmdSelect.Parameters.AddWithValue("@ID", txtForm_Type_Id.Text.Trim().ToUpper());
                    SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                    da.Fill(dt);
                }


                if (dt.Rows.Count > 0)
                {
                    txtForm_Type_Id.Text = txtForm_Type_Id.Text.Trim().ToUpper();
                    lblForm_Type_Name.Text = dt.Rows[0][1].ToString();
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
                    string seqNo = DateTime.Now.Year.ToString().Substring(4 - year, year) + DateTime.Now.Month.ToString();
                    if (day != 0)
                    {
                        seqNo += DateTime.Now.Day.ToString();
                    }

                    //check for the highest ID with the same Code prior to 流水號
                    dt = new DataTable();
                    using (SqlConnection conn = new SqlConnection(HR360connectionString))
                    {
                        conn.Open();
                        SqlCommand cmdSelect = new SqlCommand("SELECT [HR360_PR07_A].[ID] FROM [HR360_PR07_A] LEFT JOIN [HR360_PR01_A] ON [HR360_PR07_A].[FORM_TYPE_ID] = [HR360_PR01_A].[ID] WHERE [HR360_PR01_A].[FORM_TYPE] = N'PR07: 考績單建立作業' AND [HR360_PR07_A].[FORM_TYPE_ID]=@FORMTYPEID AND [HR360_PR07_A].[ID] LIKE @PRO7AID ORDER BY [HR360_PR07_A].[ID] DESC", conn);
                        cmdSelect.Parameters.AddWithValue("@FORMTYPEID", txtForm_Type_Id.Text.Trim().ToUpper());
                        cmdSelect.Parameters.AddWithValue("@PRO7AID", seqNo + "%");
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
                SqlCommand cmdSelect = new SqlCommand("SELECT CMSMV.MV001 員工代號, CMSMV.MV002 員工名稱, CMSMJ.MJ003 職稱, CMSME.ME002 部門名稱, CMSMV.MV031 年資 FROM CMSMV	LEFT JOIN CMSME ON CMSMV.MV004 = CMSME.ME001 LEFT JOIN CMSMJ ON CMSMV.MV006 = CMSMJ.MJ001 WHERE CMSMV.MV022 = N'' AND MV001=@ID", conn);
                cmdSelect.Parameters.AddWithValue("@ID", txtEmployee_Id.Text.Trim().ToUpper());
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                txtEmployee_Id.Text = txtEmployee_Id.Text.Trim().ToUpper();
                lblEmployee_Name.Text = dt.Rows[0][1].ToString();
                lblEmployee_Rank.Text = dt.Rows[0][2].ToString();
                lblEmployee_Department.Text = dt.Rows[0][3].ToString();
                lblEmployee_Year_In_Service.Text = dt.Rows[0][4].ToString();
            }
            else
            {
                lblErrorMessage.Text = "此代號不存在";
                lblEmployee_Name.Text = "";
                txtEmployee_Id.Focus();
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void txtAssessment_Start_Date_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblErrorMessage.Text = "";
            DateTime dateValue;

            if (txtAssessment_Start_Date.Text.Trim() == "" || !DateTime.TryParseExact(txtAssessment_Start_Date.Text.Trim().ToUpper(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
            {
                lblErrorMessage.Text = "請輸入符合格式yyyy/MM/dd的日期";
                txtAssessment_Start_Date.Focus();
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void txtAssessment_End_Date_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblErrorMessage.Text = "";
            DateTime dateValue;

            if (txtAssessment_End_Date.Text.Trim() == "" || !DateTime.TryParseExact(txtAssessment_End_Date.Text.Trim().ToUpper(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
            {
                lblErrorMessage.Text = "請輸入符合格式yyyy/MM/dd的日期";
                txtAssessment_End_Date.Focus();
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void txtAssessment_Year_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblErrorMessage.Text = "";
            DateTime dateValue;

            if (txtAssessment_Year.Text.Trim() == "" || !DateTime.TryParseExact(txtAssessment_Year.Text.Trim().ToUpper(), "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
            {
                lblErrorMessage.Text = "請輸入符合格式yyyy的日期";
                txtAssessment_Year.Focus();
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void btnKpi_Group_Select_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(HR360connectionString))
        {
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT DISTINCT [ID] KPI群組代號, [NAME] KPI群組名稱 FROM [HR360_PR06_A]", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grdGroup.DataSource = dt;
            grdGroup.DataBind();
        }
    }
    protected void grdGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtKpi_Group_Id.Text = Server.HtmlDecode(grdGroup.SelectedRow.Cells[0].Text);
        lblKpi_Group_Name.Text = Server.HtmlDecode(grdGroup.SelectedRow.Cells[1].Text);
        txtKpi_Group_Id_TextChanged(sender, e);
    }
    protected void txtKpi_Group_Id_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblErrorMessage.Text = "";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(HR360connectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT DISTINCT [ID] KPI群組代號, [NAME] KPI群組名稱 FROM [HR360_PR06_A] WHERE [ID]=@ID", conn);
                cmdSelect.Parameters.AddWithValue("@ID", txtKpi_Group_Id.Text.Trim().ToUpper());
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                txtKpi_Group_Id.Text = dt.Rows[0][0].ToString();
                lblKpi_Group_Name.Text = dt.Rows[0][1].ToString();
            }
            else
            {
                lblErrorMessage.Text = "此代號不存在";
                lblKpi_Group_Name.Text = "";
                txtKpi_Group_Id.Focus();
            }

        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void btnKpi_Item_Select_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(HR360connectionString))
        {
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT [ID] KPI代號, [NAME] KPI名稱, [MEMO] KPI備註 FROM HR360_PR05_A", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grdKpi.DataSource = dt;
            grdKpi.DataBind();
        }
    }
    protected void grdKpi_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtKpi_Item_Id.Text = Server.HtmlDecode(grdKpi.SelectedRow.Cells[0].Text);
        lblKpi_Item_Name.Text = Server.HtmlDecode(grdKpi.SelectedRow.Cells[1].Text.Replace("\n", "<br />"));
        txtKpi_Item_Id_TextChanged(sender, e);
    }
    protected void txtKpi_Item_Id_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblErrorMessage.Text = "";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(HR360connectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT [ID] KPI代號, [NAME] KPI名稱, [MEMO] KPI備註 FROM HR360_PR05_A WHERE [ID]=@ID", conn);
                cmdSelect.Parameters.AddWithValue("@ID", txtKpi_Item_Id.Text.Trim().ToUpper());
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                txtKpi_Item_Id.Text = Server.HtmlDecode(dt.Rows[0][0].ToString());
                lblKpi_Item_Name.Text = Server.HtmlDecode(dt.Rows[0][1].ToString().Replace("\n", "<br />"));
            }
            else
            {
                lblErrorMessage.Text = "此代號不存在";
                lblKpi_Item_Name.Text = "";
                txtKpi_Item_Id.Focus();
            }

        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void btnKpi_Input_Selection_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(HR360connectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT [HR360_PR05_A].[ID] FROM [HR360_PR06_A] LEFT JOIN [HR360_PR05_A] ON [HR360_PR06_A].[KPI_ID] = [HR360_PR05_A].[ID] WHERE [HR360_PR06_A].[ID] = @ID ORDER BY [HR360_PR05_A].[CATEGORY_ID], [HR360_PR05_A].[ID]", conn);
                cmdSelect.Parameters.AddWithValue("@ID", txtKpi_Group_Id.Text.Trim().ToUpper());
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                da.Fill(dt);
            }
            List<string[]> grdSourceKpi_Item = (List<string[]>)ViewState["grdSourceKpi_Item"];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    bool duplicate = false;
                    if (grdSourceKpi_Item != null)
                    {
                        foreach (string[] str in grdSourceKpi_Item)
                        {
                            if (row[0].ToString() == str[0].ToString())
                            {
                                duplicate = true;
                            }
                        }
                    }
                    if (!duplicate)
                    {
                        if (grdSourceKpi_Item == null)
                        {
                            grdSourceKpi_Item = new List<string[]>();
                        }
                        grdSourceKpi_Item.Add(new string[] { row[0].ToString(), "" });
                    }
                }
            }
            using (SqlConnection conn = new SqlConnection(HR360connectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT [HR360_PR05_A].[ID] FROM [HR360_PR05_A] WHERE [HR360_PR05_A].[ID] = @ID ORDER BY [HR360_PR05_A].[CATEGORY_ID], [HR360_PR05_A].[ID]", conn);
                cmdSelect.Parameters.AddWithValue("@ID", txtKpi_Item_Id.Text.Trim().ToUpper());
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                dt = new DataTable();
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    bool duplicate = false;
                    if (grdSourceKpi_Item != null)
                    {
                        foreach (string[] str in grdSourceKpi_Item)
                        {
                            if (row[0].ToString() == str[0].ToString())
                            {
                                duplicate = true;
                            }
                        }
                    }
                    if (!duplicate)
                    {
                        if (grdSourceKpi_Item == null)
                        {
                            grdSourceKpi_Item = new List<string[]>();
                        }
                        grdSourceKpi_Item.Add(new string[] { row[0].ToString(), "" });
                    }
                }
            }
            Load_KPI_Gridview(grdSourceKpi_Item);
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void grdKpi_Item_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdKpi_Item_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<string[]> grdSourceKpi_Item = (List<string[]>)ViewState["grdSourceKpi_Item"];
        for (int i=0; i<grdSourceKpi_Item.Count; i++)
        {
            bool match = false;
            if (((Label)grdKpi_Item.Rows[e.RowIndex].Cells[2].FindControl("lblKpi_Id")).Text == grdSourceKpi_Item[i][0])
            {
                grdSourceKpi_Item.RemoveAt(i);
                match = true;
            }
            if (match)
            {
                break;
            }
        }
        Load_KPI_Gridview(grdSourceKpi_Item);
    }
    protected void grdKpi_Category_RowCreated(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i < grdKpi_Category.Rows.Count; i++)
        {
            if (i > 0)
            {
                if (((Label)grdKpi_Category.Rows[i].Cells[0].FindControl("lblCategory_Id")).Text == ((Label)grdKpi_Category.Rows[i - 1].Cells[0].FindControl("lblCategory_Id")).Text)
                {
                    ((Label)grdKpi_Category.Rows[i].Cells[0].FindControl("lblCategory_Id")).Text = "";
                    ((Label)grdKpi_Category.Rows[i].Cells[1].FindControl("lblCategory_Name")).Text = "";
                    ((Label)grdKpi_Category.Rows[i].Cells[2].FindControl("lblCategory_Memo")).Text = "";
                }
            }
        }

        //for (int i = 0; i < grdKpi_Category.Rows.Count; i++)
        //{
        //    grdKpi_Category.Rows[i].Height = grdKpi_Item.Rows[i].Height;
        //}
    }
}