using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class hr360_PR01 : System.Web.UI.Page
{
    //universal functions
    string connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

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
        ViewState["txtId"] = txtId.Text.ToUpper().Trim();
        ViewState["txtName"] = txtName.Text.Trim();
        ViewState["txtEn_Name"] = txtEn_Name.Text.Trim();
        ViewState["txtMemo"] = txtMemo.Text.Trim();
        ViewState["ddlForm_Type"] = ddlForm_Type.SelectedValue.ToString();
        ViewState["ddlCode_Method"] = ddlCode_Method.SelectedValue.ToString();
        ViewState["ddlCode_Year"] = ddlCode_Year.SelectedValue.ToString();
        ViewState["ddlCode_Number"] = ddlCode_Number.SelectedValue.ToString();
        ViewState["txtCode_Format"] = txtCode_Format.Text.Trim();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtId.Text = "";
            txtId.ReadOnly = true;
            txtId.CssClass = "read-only";
            txtName.Text = "";
            txtName.ReadOnly = true;
            txtName.CssClass = "read-only";
            txtEn_Name.Text = "";
            txtEn_Name.ReadOnly = true;
            txtEn_Name.CssClass = "read-only";
            txtMemo.Text = "";
            txtMemo.ReadOnly = true;
            txtMemo.CssClass = "read-only";
            ddlForm_Type.Enabled = false;
            ddlCode_Method.Enabled = false;
            ddlCode_Year.Enabled = false;
            ddlCode_Number.Enabled = false;
            Code_Format_Change(sender, e);
            lblErrorMessage.Text = "";

            Load_toplink(getPostBackControlName());
        }
        else
        {
            
        }
    }
    protected void toplink_add_Click(object sender, EventArgs e)
    {         
        txtId.Text = "";
        txtId.ReadOnly = false;
        txtId.CssClass = "required-field";
        txtName.Text = "";
        txtName.ReadOnly = false; ;
        txtName.CssClass = "required-field";
        txtEn_Name.Text = "";
        txtEn_Name.ReadOnly = false;
        txtEn_Name.CssClass = "required-field";
        txtMemo.Text = "";
        txtMemo.ReadOnly = false;
        txtMemo.CssClass = "";
        ddlForm_Type.Enabled = true;
        ddlCode_Method.Enabled = true;
        ddlCode_Year.Enabled = true;
        ddlCode_Number.Enabled = true;
        txtCode_Format.Text = "";
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
        string query = "SELECT [ID] 單別代號, [NAME] 單別名稱, [EN_NAME] 單別英文名稱, [CODE_METHOD] 單據編碼方式, [CODE_YEAR] 年碼數, [CODE_NUMBER] 流水號碼數, [FORM_TYPE] 單據性質, [MEMO] 單別備註, [CODE_FORMAT] 編碼格式, [CREATEDATE] 建立日期, [CREATOR] 建立者, [MODIFIEDDATE] 修改日期, [MODIFIER] 修改者 FROM [HR360_PR01_A]";
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
            using (SqlConnection conn = new SqlConnection(connectionString))
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
        catch
        {

        }
    }
    protected void grdResult_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblErrorMessage.Text = "";
        txtId.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[0].Text);
        txtId.ReadOnly = true;
        txtId.CssClass = "read-only";
        txtName.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[1].Text);
        txtName.ReadOnly = true;
        txtName.CssClass = "read-only";
        txtEn_Name.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[2].Text);
        txtEn_Name.ReadOnly = true;
        txtEn_Name.CssClass = "read-only";
        ddlCode_Method.SelectedValue = Server.HtmlDecode(grdResult.SelectedRow.Cells[3].Text);
        ddlCode_Method.Enabled = false;
        ddlCode_Year.SelectedValue = Server.HtmlDecode(grdResult.SelectedRow.Cells[4].Text);
        ddlCode_Year.Enabled = false;
        ddlCode_Number.SelectedValue = Server.HtmlDecode(grdResult.SelectedRow.Cells[5].Text);
        ddlCode_Number.Enabled = false;
        ddlForm_Type.SelectedValue = Server.HtmlDecode(grdResult.SelectedRow.Cells[6].Text);
        ddlForm_Type.Enabled = false;
        txtMemo.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[7].Text);
        
        txtMemo.ReadOnly = true;
        txtMemo.CssClass = "read-only";
        txtCode_Format.Text = grdResult.SelectedRow.Cells[8].Text;
    }
    //
    protected void toplink_edit_Click(object sender, EventArgs e)
    {
        if (txtId.Text.Trim() == "")
        {
            lblErrorMessage.Text = "需先輸入單別代號後才能進行修改，修改時不得更改單別代號";
            txtId.ReadOnly = false;
            txtId.CssClass = "required-field";
            txtId.Focus();
        }
        else
        {
            //needs to set condition where if this FORM ID has been used in other related DB, then the CODE_FORMAT cannot be changed
            lblErrorMessage.Text = "";
            txtId.ReadOnly = true;
            txtId.CssClass = "read-only";
            txtName.ReadOnly = false;
            txtName.CssClass = "required-field";
            txtEn_Name.ReadOnly = false;
            txtEn_Name.CssClass = "required-field";
            txtMemo.ReadOnly = false;
            txtMemo.CssClass = "";
            ddlForm_Type.Enabled = true;
            ddlCode_Method.Enabled = true;
            ddlCode_Year.Enabled = true;
            ddlCode_Number.Enabled = true;
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
        if (txtId.Text.Trim() == "")
        {
            lblErrorMessage.Text = "請輸入單別代號";
            txtId.ReadOnly = false;
            txtId.CssClass = "required-field";
            txtId.Focus();
        }
        else if (txtName.Text.Trim() == "")
        {
            lblErrorMessage.Text = "請輸入單別名稱";
            txtName.ReadOnly = false;
            txtName.CssClass = "required-field";
            txtName.Focus();
        }
        else if (txtEn_Name.Text.Trim() == "")
        {
            lblErrorMessage.Text = "請輸入單別英文名稱";
            txtEn_Name.ReadOnly = false;
            txtEn_Name.CssClass = "required-field";
            txtEn_Name.Focus();
        }        
        else
        {
            try
            {
                if (txtId.ReadOnly == false) //新增
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmdDuplicateSearch = new SqlCommand("SELECT [ID] FROM [HR360_PR01_A] WHERE [ID] = @ID", conn);
                        cmdDuplicateSearch.Parameters.AddWithValue("@ID", txtId.Text.ToUpper().Trim());
                        conn.Open();
                        SqlDataReader reader = cmdDuplicateSearch.ExecuteReader();

                        if (reader.HasRows)
                        {
                            lblErrorMessage.Text = "此單別代號已存在";
                            txtId.Focus();
                            reader.Close();
                        }
                        else
                        {
                            reader.Close();
                            SqlCommand cmd = new SqlCommand("INSERT INTO [HR360_PR01_A] VALUES (GETDATE(), @CREATOR, GETDATE(), @MODIFIER, @ID, @NAME, @EN_NAME, @MEMO, @FORM_TYPE, @CODE_METHOD, @CODE_YEAR, @CODE_NUMBER, @CODE_FORMAT)", conn);
                            cmd.Parameters.AddWithValue("@CREATOR", Session["user_id"]);
                            cmd.Parameters.AddWithValue("@MODIFIER", Session["user_id"]);
                            cmd.Parameters.AddWithValue("@ID", txtId.Text.ToUpper().Trim());
                            cmd.Parameters.AddWithValue("@NAME", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@EN_NAME", txtEn_Name.Text.Trim());
                            cmd.Parameters.AddWithValue("@MEMO", txtMemo.Text.Trim());
                            cmd.Parameters.AddWithValue("@FORM_TYPE", ddlForm_Type.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@CODE_METHOD", ddlCode_Method.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@CODE_YEAR", ddlCode_Year.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@CODE_NUMBER", ddlCode_Number.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@CODE_FORMAT", txtCode_Format.Text);
                            cmd.ExecuteNonQuery();
                            lblErrorMessage.Text = "";
                            //enable grdResult after click
                            grdResult.Enabled = true;

                            Load_toplink(getPostBackControlName());
                        }
                    }
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE [HR360_PR01_A] SET [MODIFIEDDATE]=GETDATE(), [MODIFIER] = @MODIFIER, [NAME]=@NAME, [EN_NAME]=@EN_NAME, [FORM_TYPE]=@FORM_TYPE, [CODE_METHOD]=@CODE_METHOD, [CODE_YEAR]=@CODE_YEAR, [CODE_NUMBER]=@CODE_NUMBER, [CODE_FORMAT]=@CODE_FORMAT, [MEMO]=@MEMO WHERE ID=@ID", conn);
                        cmd.Parameters.AddWithValue("@MODIFIER", Session["user_id"]);
                        cmd.Parameters.AddWithValue("@ID", txtId.Text.ToUpper().Trim());
                        cmd.Parameters.AddWithValue("@NAME", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@EN_NAME", txtEn_Name.Text.Trim());
                        cmd.Parameters.AddWithValue("@MEMO", txtMemo.Text.Trim());
                        cmd.Parameters.AddWithValue("@FORM_TYPE", ddlForm_Type.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@CODE_METHOD", ddlCode_Method.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@CODE_YEAR", ddlCode_Year.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@CODE_NUMBER", ddlCode_Number.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@CODE_FORMAT", txtCode_Format.Text);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        lblErrorMessage.Text = "";
                        //enable grdResult after click
                        grdResult.Enabled = true;
                        Load_toplink(getPostBackControlName());
                    }
                }
                txtId.ReadOnly = true;
                txtId.CssClass = "read-only";
                txtName.ReadOnly = true;
                txtName.CssClass = "read-only";
                txtEn_Name.ReadOnly = true;
                txtEn_Name.CssClass = "read-only";
                txtMemo.ReadOnly = true;
                txtMemo.CssClass = "read-only";
                ddlForm_Type.Enabled = false;
                ddlCode_Method.Enabled = false;
                ddlCode_Year.Enabled = false;
                ddlCode_Number.Enabled = false;
            }
            catch
            {

            }
        }
    }
    protected void toplink_cancel_Click(object sender, EventArgs e)
    {
        lblErrorMessage.Text = "";
        txtId.Text = ViewState["txtId"].ToString();
        txtId.ReadOnly = true;
        txtId.CssClass = "read-only";
        txtName.Text = ViewState["txtName"].ToString();
        txtName.ReadOnly = true;
        txtName.CssClass = "read-only";
        txtEn_Name.Text = ViewState["txtEn_Name"].ToString();
        txtEn_Name.ReadOnly = true;
        txtEn_Name.CssClass = "read-only";
        txtMemo.Text = ViewState["txtMemo"].ToString();
        txtMemo.ReadOnly = true;
        txtMemo.CssClass = "read-only";
        ddlForm_Type.SelectedValue = ViewState["ddlForm_Type"].ToString();
        ddlForm_Type.Enabled = false;
        ddlCode_Method.SelectedValue = ViewState["ddlCode_Method"].ToString();
        ddlCode_Method.Enabled = false;
        ddlCode_Year.SelectedValue = ViewState["ddlCode_Year"].ToString();
        ddlCode_Year.Enabled = false;
        ddlCode_Number.SelectedValue = ViewState["ddlCode_Number"].ToString();
        ddlCode_Number.Enabled = false;
        txtCode_Format.Text = ViewState["txtCode_Format"].ToString();

        //enable grdResult after click
        grdResult.Enabled = true;

        Load_toplink(getPostBackControlName());
    }
    protected void toplink_delete_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ID] FROM [HR360_PR01_A] WHERE [ID] = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", txtId.Text.ToUpper().Trim());
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    SqlCommand cmdDelete = new SqlCommand("DELETE FROM [HR360_PR01_A] WHERE [ID] = @ID", conn);
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
                    txtId.Text = "";
                    txtName.Text = "";
                    txtEn_Name.Text = "";
                    txtMemo.Text = "";
                    ddlForm_Type.SelectedIndex = 0;
                    ddlCode_Method.SelectedIndex = 0;
                    ddlCode_Year.SelectedIndex = 0;
                    ddlCode_Number.SelectedIndex = 0;

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
        txtId.ReadOnly = true;
        txtId.CssClass = "read-only";
        txtName.ReadOnly = true;
        txtName.CssClass = "read-only";
        txtEn_Name.ReadOnly = true;
        txtEn_Name.CssClass = "read-only";
        txtMemo.ReadOnly = true;
        txtMemo.CssClass = "read-only";
        ddlForm_Type.Enabled = false;
        ddlCode_Method.Enabled = false;
        ddlCode_Year.Enabled = false;
        ddlCode_Number.Enabled = false;
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
        txtId.Text = "";
        txtId.ReadOnly = false;
        txtId.CssClass = "required-field";
        txtId.Focus();
        txtName.Text = ViewState["txtName"].ToString();
        txtName.ReadOnly = true;
        txtName.CssClass = "read-only";
        txtEn_Name.Text = ViewState["txtEn_Name"].ToString();
        txtEn_Name.ReadOnly = true;
        txtEn_Name.CssClass = "read-only";
        txtMemo.Text = ViewState["txtMemo"].ToString();
        txtMemo.ReadOnly = true;
        txtMemo.CssClass = "read-only";
        ddlForm_Type.SelectedValue = ViewState["ddlForm_Type"].ToString();
        ddlForm_Type.Enabled = false;
        ddlCode_Method.SelectedValue = ViewState["ddlCode_Method"].ToString();
        ddlCode_Method.Enabled = false;
        ddlCode_Year.SelectedValue = ViewState["ddlCode_Year"].ToString();
        ddlCode_Year.Enabled = false;
        ddlCode_Number.SelectedValue = ViewState["ddlCode_Number"].ToString();
        ddlCode_Number.Enabled = false;
        txtCode_Format.Text = ViewState["txtCode_Format"].ToString();

        //disable grdResult while in edit mode
        grdResult.Enabled = false;

        Load_toplink(getPostBackControlName());
    }

    //page-specific functions

    protected void Code_Format_Change(object sender, EventArgs e)
    {
        string code_format = "";
        for (int i = 0; i < Convert.ToInt16(ddlCode_Year.SelectedValue.ToString()); i++)
        {
            code_format += "Y";
        }
        code_format += "MM";
        if (ddlCode_Method.SelectedValue.ToString() == "1: 日編")
        {
            code_format += "DD";
        }
        for (int i = 0; i < Convert.ToInt16(ddlCode_Number.SelectedValue.ToString()); i++)
        {
            code_format += "9";
        }
        txtCode_Format.Text = code_format;
    }
}