using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hr360_BI02 : System.Web.UI.Page
{
    ////universal functions
    //string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    ////save view-state
    //void Page_PreRender(object sender, EventArgs e)
    //{
    //    ViewState["txtUser_Id"] = txtUser_Id.Text;
    //    ViewState["txtName"] = txtName.Text;
    //    ViewState["chkSuper_User"] = chkSuper_User.Checked;
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
    //    if (!IsPostBack)
    //    {
    //        txtUser_Id.Text = "";
    //        txtUser_Id.ReadOnly = true;
    //        txtUser_Id.CssClass = "read-only";
    //        btnUser_Id_Search.Enabled = false;
    //        txtName.Text = "";
    //        txtName.ReadOnly = true;
    //        txtName.CssClass = "read-only";
    //        chkSuper_User.Checked = false;
    //        chkSuper_User.Enabled = false;

    //        grdModule_Permission.Enabled = false;
    //        lblErrorMessage.Text = "";

    //        Load_toplink(getPostBackControlName());
    //    }
    //    else
    //    {
    //    }
    }
    //protected void toplink_add_Click(object sender, ImageClickEventArgs e)
    //{
    //    lblErrorMessage.Text = "";
    //    txtUser_Id.Text = "";
    //    txtUser_Id.CssClass = "required-field";
    //    btnUser_Id_Search.Enabled = true;
    //    txtName.Text = "";
    //    txtName.CssClass = "required-field";
    //    chkSuper_User.Checked = false;
    //    chkSuper_User.Enabled = true;
    //    grdModule_Permission.Enabled = true;

    //    //disable grdResult while in edit mode
    //    grdResult.Enabled = false;

    //    Load_toplink(getPostBackControlName());
    //}
    ////search-related functions
    //protected void toplink_search_Click(object sender, ImageClickEventArgs e)
    //{

    //}
    //protected void ddlSearch_Item_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlSearch_Item.SelectedValue == "CREATEDATE" || ddlSearch_Item.SelectedValue == "MODIFIEDDATE")
    //    {
    //        txtSearchContent.Attributes.Add("placeholder", "日期格式為 YYYY-MM-DD");
    //    }
    //    else
    //    {
    //        txtSearchContent.Attributes.Add("placeholder", "大小寫為不同字元");
    //    }
    //}
    //protected void btnSearch_AddCondition_Click(object sender, EventArgs e)
    //{
    //    string[] condition = txtSearchCondition.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    //    if (ddlOperative.SelectedItem.Value == "LIKE")
    //    {
    //        if (condition.Length == 0)
    //        {
    //            txtSearchCondition.Text = "[" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'%" + txtSearchContent.Text + "%'";
    //        }
    //        else if (rdoAnd.Checked == true)
    //        {
    //            txtSearchCondition.Text += "\n" + rdoAnd.Text + " [" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'%" + txtSearchContent.Text + "%'";
    //        }
    //        else if (rdoOr.Checked == true)
    //        {
    //            txtSearchCondition.Text += "\n" + rdoOr.Text + " [" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'%" + txtSearchContent.Text + "%'";
    //        }

    //    }
    //    else
    //    {
    //        if (condition.Length == 0)
    //        {
    //            txtSearchCondition.Text = "[" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'" + txtSearchContent.Text + "'";
    //        }
    //        else if (rdoAnd.Checked == true)
    //        {
    //            txtSearchCondition.Text += "\n" + rdoAnd.Text + " [" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'" + txtSearchContent.Text + "'";
    //        }
    //        else if (rdoOr.Checked == true)
    //        {
    //            txtSearchCondition.Text += "\n" + rdoOr.Text + " [" + ddlSearch_Item.SelectedItem.Value + "] " + ddlOperative.SelectedItem.Text + " N'" + txtSearchContent.Text + "'";
    //        }
    //    }
    //}
    //protected void btnSearch_ClearCondition_Click(object sender, EventArgs e)
    //{
    //    txtSearchCondition.Text = "";
    //}
    //protected void btnSearch_Search_Click(object sender, EventArgs e)
    //{
    //    string query = "WITH [LAST_MODIFIED]"
    //                    + " AS"
    //                    + " ("
    //                    + " SELECT [USER_ID],[HR360_BI02_A].[CREATEDATE], [HR360_BI02_A].[CREATOR], [HR360_BI02_A].[MODIFIEDDATE], [HR360_BI02_A].[MODIFIER]"
    //                    + " ,ROW_NUMBER() OVER(PARTITION BY [HR360_BI02_A].[USER_ID] ORDER BY [HR360_BI02_A].[MODIFIEDDATE] DESC) RN"
    //                    + " FROM [HR360_BI02_A]"
    //                    + " )"
    //                    + " SELECT DISTINCT [HR360_BI02_A].[USER_ID] 使用者代號, [HR360_BI01_A].[NAME] 使用者名稱, [HR360_BI01_A].[SUPER_USER] 超級使用者"
    //                    + " ,[LAST_MODIFIED].[CREATEDATE] 建立日期, [LAST_MODIFIED].[CREATOR] 建立者, [LAST_MODIFIED].[MODIFIEDDATE] 修改日期"
    //                    + " ,[LAST_MODIFIED].[MODIFIER] 修改者"
    //                    + " FROM [HR360_BI02_A]"
    //                    + " LEFT JOIN [HR360_BI01_A] ON [HR360_BI02_A].[USER_ID] = [HR360_BI01_A].[ID]"
    //                    + " LEFT JOIN [LAST_MODIFIED] ON [HR360_BI02_A].[USER_ID] = [LAST_MODIFIED].[USER_ID] AND [LAST_MODIFIED].[RN] = 1";
    //    string query_condition = "";
    //    try
    //    {
    //        if (txtSearchCondition.Text != "") //有搜尋條件
    //        {
    //            query_condition = " WHERE [HR360_BI02_A]." + txtSearchCondition.Text.Replace("\n", " ").Trim();
    //        }
    //        else
    //        {

    //        }
    //        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
    //        {
    //            conn.Open();
    //            SqlCommand cmd = new SqlCommand(query + query_condition, conn);
    //            SqlDataAdapter da = new SqlDataAdapter(cmd);
    //            DataSet ds = new DataSet();
    //            da.Fill(ds);
    //            grdResult.DataSource = ds;
    //            grdResult.DataBind();
    //            if (grdResult.Rows.Count != 0)
    //            {
    //                grdResult.SelectedIndex = 0;
    //                grdResult_SelectedIndexChanged(sender, e);
    //            }
    //        }
    //        Load_toplink(getPostBackControlName());
    //    }
    //    catch
    //    {

    //    }

    //}
    //protected void grdResult_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    lblErrorMessage.Text = "";
    //    txtUser_Id.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[0].Text);
    //    txtUser_Id.ReadOnly = true;
    //    txtUser_Id.CssClass = "read-only";
    //    btnUser_Id_Search.Enabled = false;
    //    txtName.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[1].Text);
    //    txtName.ReadOnly = true;
    //    txtName.CssClass = "read-only";
    //    if ((grdResult.SelectedRow.Cells[2].Controls[0] as CheckBox).Checked == true)
    //    {
    //        chkSuper_User.Checked = true;
    //    }
    //    else
    //    {
    //        chkSuper_User.Checked = false;
    //    }
    //    grdModule_Permission.DataBind();
    //    grdModule_Permission.Enabled = false;
    //}
    ////
    //protected void toplink_edit_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (txtUser_Id.Text.Trim() == "")
    //    {
    //        lblErrorMessage.Text = "需先輸入使用者代號後才能進行修改，修改時不得更改使用者代號";
    //        btnUser_Id_Search.Enabled = true;
    //        txtUser_Id.CssClass = "required-field";
    //        txtUser_Id.Focus();
    //    }
    //    else
    //    {
    //        lblErrorMessage.Text = "";
    //        btnUser_Id_Search.Enabled = false;
    //        txtUser_Id.ReadOnly = true;
    //        txtUser_Id.CssClass = "read-only";
    //        txtName.ReadOnly = true;
    //        txtName.CssClass = "read-only";
    //        chkSuper_User.Enabled = true;
    //        grdModule_Permission.Enabled = true;
    //    }
    //    //disable gridview while editing
    //    grdResult.Enabled = false;
    //    Load_toplink(getPostBackControlName());
    //}
    //protected void toplink_print_Click(object sender, ImageClickEventArgs e)
    //{

    //}
    //protected void toplink_first_record_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (grdResult.Rows.Count != 0)
    //    {
    //        grdResult.SelectedIndex = 0;
    //        grdResult_SelectedIndexChanged(sender, e);
    //    }
    //}
    //protected void toplink_previous_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (grdResult.Rows.Count != 0)
    //    {
    //        if (grdResult.SelectedIndex > 0)
    //        {
    //            grdResult.SelectedIndex--;
    //            grdResult_SelectedIndexChanged(sender, e);
    //        }
    //    }
    //}
    //protected void toplink_next_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (grdResult.Rows.Count != 0)
    //    {
    //        if (grdResult.SelectedIndex < grdResult.Rows.Count - 1)
    //        {
    //            grdResult.SelectedIndex++;
    //            grdResult_SelectedIndexChanged(sender, e);
    //        }
    //    }
    //}
    //protected void toplink_last_record_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (grdResult.Rows.Count != 0)
    //    {
    //        grdResult.SelectedIndex = grdResult.Rows.Count - 1;
    //        grdResult_SelectedIndexChanged(sender, e);
    //    }
    //}
    //protected void toplink_save_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (txtUser_Id.Text.Trim() == "")
    //    {
    //        lblErrorMessage.Text = "請選擇使用者";
    //        btnUser_Id_Search.Enabled = true;
    //        txtUser_Id.ReadOnly = true;
    //        txtUser_Id.CssClass = "required-field";
    //        btnUser_Id_Search.Focus();
    //    }
    //    else if (txtName.Text.Trim() == "")
    //    {
    //        lblErrorMessage.Text = "請選擇使用者";
    //        btnUser_Id_Search.Enabled = true;
    //        txtName.ReadOnly = true;
    //        txtName.CssClass = "required-field";
    //        btnUser_Id_Search.Focus();
    //    }
    //    else
    //    {
    //        try
    //        {
    //            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
    //            {
    //                conn.Open();
    //                //reads all modules assigned to this user
    //                SqlCommand cmdUserModuleSearch = new SqlCommand("SELECT [USER_ID], [MODULE_ID] FROM [HR360_BI02_A] WHERE [USER_ID]=@USER_ID", conn);
    //                cmdUserModuleSearch.Parameters.AddWithValue("@USER_ID", txtUser_Id.Text);
    //                SqlDataAdapter da = new SqlDataAdapter(cmdUserModuleSearch);
    //                DataTable dt = new DataTable();
    //                da.Fill(dt);
    //                //if table has no row, then nothing is yet assigned to the user, so all data in permission gridview should be INSERT
    //                if (dt.Rows.Count == 0)
    //                {
    //                    //check permission grid row by row for data to be saved to db
    //                    foreach (GridViewRow row in grdModule_Permission.Rows)
    //                    {
    //                        SqlCommand cmdAddItem = new SqlCommand("INSERT INTO [HR360_BI02_A] VALUES(GETDATE(),@CREATOR,GETDATE(),@MODIFIER,@USER_ID,@MODULE_ID,@EXECUTE,@ADD,@SEARCH,@EDIT,@OUTPUT,@DELETE)", conn);
    //                        cmdAddItem.Parameters.AddWithValue("@CREATOR", Session["user_id"]);
    //                        cmdAddItem.Parameters.AddWithValue("@MODIFIER", Session["user_id"]);
    //                        cmdAddItem.Parameters.AddWithValue("@USER_ID", txtUser_Id.Text);
    //                        cmdAddItem.Parameters.AddWithValue("@MODULE_ID", (row.Cells[0].FindControl("lblModule_Id") as Label).Text);
    //                        if ((row.Cells[3].FindControl("chkExecute") as CheckBox).Checked == true)
    //                        {
    //                            cmdAddItem.Parameters.AddWithValue("@EXECUTE", 1);
    //                        }
    //                        else
    //                        {
    //                            cmdAddItem.Parameters.AddWithValue("@EXECUTE", 0);
    //                        }
    //                        if ((row.Cells[4].FindControl("chkAdd") as CheckBox).Checked == true)
    //                        {
    //                            cmdAddItem.Parameters.AddWithValue("@ADD", 1);
    //                        }
    //                        else
    //                        {
    //                            cmdAddItem.Parameters.AddWithValue("@ADD", 0);
    //                        }
    //                        if ((row.Cells[5].FindControl("chkSearch") as CheckBox).Checked == true)
    //                        {
    //                            cmdAddItem.Parameters.AddWithValue("@SEARCH", 1);
    //                        }
    //                        else
    //                        {
    //                            cmdAddItem.Parameters.AddWithValue("@SEARCH", 0);
    //                        }
    //                        if ((row.Cells[6].FindControl("chkEdit") as CheckBox).Checked == true)
    //                        {
    //                            cmdAddItem.Parameters.AddWithValue("@EDIT", 1);
    //                        }
    //                        else
    //                        {
    //                            cmdAddItem.Parameters.AddWithValue("@EDIT", 0);
    //                        }
    //                        if ((row.Cells[7].FindControl("chkOutput") as CheckBox).Checked == true)
    //                        {
    //                            cmdAddItem.Parameters.AddWithValue("@OUTPUT", 1);
    //                        }
    //                        else
    //                        {
    //                            cmdAddItem.Parameters.AddWithValue("@OUTPUT", 0);
    //                        }
    //                        if ((row.Cells[8].FindControl("chkDelete") as CheckBox).Checked == true)
    //                        {
    //                            cmdAddItem.Parameters.AddWithValue("@DELETE", 1);
    //                        }
    //                        else
    //                        {
    //                            cmdAddItem.Parameters.AddWithValue("@DELETE", 0);
    //                        }
    //                        cmdAddItem.ExecuteNonQuery();
    //                        SqlCommand cmdUpdateItem = new SqlCommand("UPDATE [HR360_BI01_A] SET [HR360_BI01_A].[SUPER_USER]=@SUPER_USER WHERE [HR360_BI01_A].[ID]=@ID", conn);
    //                        cmdUpdateItem.Parameters.AddWithValue("@ID", txtUser_Id.Text);
    //                        if (chkSuper_User.Checked == true)
    //                        {
    //                            cmdUpdateItem.Parameters.AddWithValue("@SUPER_USER", 1);
    //                        }
    //                        else
    //                        {
    //                            cmdUpdateItem.Parameters.AddWithValue("@SUPER_USER", 0);
    //                        }
    //                        cmdUpdateItem.ExecuteNonQuery();
    //                    }
    //                    lblErrorMessage.Text = "";
    //                    //enable grdResult after click
    //                    grdResult.Enabled = true;
    //                    Load_toplink(getPostBackControlName());
    //                }
    //                else //there are rows in dt, need to determine whether it's add or edit by checking module_id
    //                {
    //                    foreach (GridViewRow row in grdModule_Permission.Rows)
    //                    {
    //                        bool match = false;
    //                        //for every permission gridview row, need to check the entire dt for matching module_id
    //                        for (int i = 0; i < dt.Rows.Count; i++)
    //                        {
    //                            if (dt.Rows[i][1].ToString() == (row.Cells[0].FindControl("lblModule_Id") as Label).Text)
    //                            {
    //                                match = true;
    //                            }
    //                        }
    //                        if (match == false)
    //                        {
    //                            //no match, so this row of data is new, INSERT
    //                            SqlCommand cmdAddItem = new SqlCommand("INSERT INTO [HR360_BI02_A] VALUES(GETDATE(),@CREATOR,GETDATE(),@MODIFIER,@USER_ID,@MODULE_ID,@EXECUTE,@ADD,@SEARCH,@EDIT,@OUTPUT,@DELETE)", conn);
    //                            cmdAddItem.Parameters.AddWithValue("@CREATOR", Session["user_id"]);
    //                            cmdAddItem.Parameters.AddWithValue("@MODIFIER", Session["user_id"]);
    //                            cmdAddItem.Parameters.AddWithValue("@USER_ID", txtUser_Id.Text);
    //                            cmdAddItem.Parameters.AddWithValue("@MODULE_ID", (row.Cells[0].FindControl("lblModule_Id") as Label).Text);
    //                            if ((row.Cells[3].FindControl("chkExecute") as CheckBox).Checked == true)
    //                            {
    //                                cmdAddItem.Parameters.AddWithValue("@EXECUTE", 1);
    //                            }
    //                            else
    //                            {
    //                                cmdAddItem.Parameters.AddWithValue("@EXECUTE", 0);
    //                            }
    //                            if ((row.Cells[4].FindControl("chkAdd") as CheckBox).Checked == true)
    //                            {
    //                                cmdAddItem.Parameters.AddWithValue("@ADD", 1);
    //                            }
    //                            else
    //                            {
    //                                cmdAddItem.Parameters.AddWithValue("@ADD", 0);
    //                            }
    //                            if ((row.Cells[5].FindControl("chkSearch") as CheckBox).Checked == true)
    //                            {
    //                                cmdAddItem.Parameters.AddWithValue("@SEARCH", 1);
    //                            }
    //                            else
    //                            {
    //                                cmdAddItem.Parameters.AddWithValue("@SEARCH", 0);
    //                            }
    //                            if ((row.Cells[6].FindControl("chkEdit") as CheckBox).Checked == true)
    //                            {
    //                                cmdAddItem.Parameters.AddWithValue("@EDIT", 1);
    //                            }
    //                            else
    //                            {
    //                                cmdAddItem.Parameters.AddWithValue("@EDIT", 0);
    //                            }
    //                            if ((row.Cells[7].FindControl("chkOutput") as CheckBox).Checked == true)
    //                            {
    //                                cmdAddItem.Parameters.AddWithValue("@OUTPUT", 1);
    //                            }
    //                            else
    //                            {
    //                                cmdAddItem.Parameters.AddWithValue("@OUTPUT", 0);
    //                            }
    //                            if ((row.Cells[8].FindControl("chkDelete") as CheckBox).Checked == true)
    //                            {
    //                                cmdAddItem.Parameters.AddWithValue("@DELETE", 1);
    //                            }
    //                            else
    //                            {
    //                                cmdAddItem.Parameters.AddWithValue("@DELETE", 0);
    //                            } 
    //                            cmdAddItem.ExecuteNonQuery();
    //                            SqlCommand cmdUpdateItem = new SqlCommand("UPDATE [HR360_BI01_A] SET [HR360_BI01_A].[SUPER_USER]=@SUPER_USER WHERE [HR360_BI01_A].[ID]=@ID", conn);
    //                            cmdUpdateItem.Parameters.AddWithValue("@ID", txtUser_Id.Text);
    //                            if (chkSuper_User.Checked == true)
    //                            {
    //                                cmdUpdateItem.Parameters.AddWithValue("@SUPER_USER", 1);
    //                            }
    //                            else
    //                            {
    //                                cmdUpdateItem.Parameters.AddWithValue("@SUPER_USER", 0);
    //                            }
    //                            cmdUpdateItem.ExecuteNonQuery();
    //                        }
    //                        else
    //                        {
    //                            //have match, this row of data exists, UPDATE
    //                            SqlCommand cmdUpdateItem = new SqlCommand("UPDATE [HR360_BI02_A] SET [HR360_BI02_A].[MODIFIEDDATE]=GETDATE(), [HR360_BI02_A].[MODIFIER]=@MODIFIER, [HR360_BI02_A].[EXECUTE]=@EXECUTE, [HR360_BI02_A].[ADD]=@ADD, [HR360_BI02_A].[SEARCH]=@SEARCH, [HR360_BI02_A].[EDIT]=@EDIT, [HR360_BI02_A].[OUTPUT]=@OUTPUT, [HR360_BI02_A].[DELETE]=@DELETE WHERE [HR360_BI02_A].[USER_ID]=@USER_ID AND [HR360_BI02_A].[MODULE_ID]=@MODULE_ID", conn);
    //                            cmdUpdateItem.Parameters.AddWithValue("@MODIFIER", Session["user_id"]);
    //                            cmdUpdateItem.Parameters.AddWithValue("@USER_ID", txtUser_Id.Text);
    //                            cmdUpdateItem.Parameters.AddWithValue("@MODULE_ID", (row.Cells[0].FindControl("lblModule_Id") as Label).Text);
    //                            if ((row.Cells[3].FindControl("chkExecute") as CheckBox).Checked == true)
    //                            {
    //                                cmdUpdateItem.Parameters.AddWithValue("@EXECUTE", 1);
    //                            }
    //                            else
    //                            {
    //                                cmdUpdateItem.Parameters.AddWithValue("@EXECUTE", 0);
    //                            }
    //                            if ((row.Cells[4].FindControl("chkAdd") as CheckBox).Checked == true)
    //                            {
    //                                cmdUpdateItem.Parameters.AddWithValue("@ADD", 1);
    //                            }
    //                            else
    //                            {
    //                                cmdUpdateItem.Parameters.AddWithValue("@ADD", 0);
    //                            }
    //                            if ((row.Cells[5].FindControl("chkSearch") as CheckBox).Checked == true)
    //                            {
    //                                cmdUpdateItem.Parameters.AddWithValue("@SEARCH", 1);
    //                            }
    //                            else
    //                            {
    //                                cmdUpdateItem.Parameters.AddWithValue("@SEARCH", 0);
    //                            }
    //                            if ((row.Cells[6].FindControl("chkEdit") as CheckBox).Checked == true)
    //                            {
    //                                cmdUpdateItem.Parameters.AddWithValue("@EDIT", 1);
    //                            }
    //                            else
    //                            {
    //                                cmdUpdateItem.Parameters.AddWithValue("@EDIT", 0);
    //                            }
    //                            if ((row.Cells[7].FindControl("chkOutput") as CheckBox).Checked == true)
    //                            {
    //                                cmdUpdateItem.Parameters.AddWithValue("@OUTPUT", 1);
    //                            }
    //                            else
    //                            {
    //                                cmdUpdateItem.Parameters.AddWithValue("@OUTPUT", 0);
    //                            }
    //                            if ((row.Cells[8].FindControl("chkDelete") as CheckBox).Checked == true)
    //                            {
    //                                cmdUpdateItem.Parameters.AddWithValue("@DELETE", 1);
    //                            }
    //                            else
    //                            {
    //                                cmdUpdateItem.Parameters.AddWithValue("@DELETE", 0);
    //                            } 
    //                            cmdUpdateItem.ExecuteNonQuery();
    //                            cmdUpdateItem = new SqlCommand("UPDATE [HR360_BI01_A] SET [HR360_BI01_A].[SUPER_USER]=@SUPER_USER WHERE [HR360_BI01_A].[ID]=@ID", conn);
    //                            cmdUpdateItem.Parameters.AddWithValue("@ID", txtUser_Id.Text);
    //                            if (chkSuper_User.Checked == true)
    //                            {
    //                                cmdUpdateItem.Parameters.AddWithValue("@SUPER_USER", 1);
    //                            }
    //                            else
    //                            {
    //                                cmdUpdateItem.Parameters.AddWithValue("@SUPER_USER", 0);
    //                            }
    //                            cmdUpdateItem.ExecuteNonQuery();
    //                        }
    //                    }
    //                    lblErrorMessage.Text = "";
    //                    //enable grdResult after click
    //                    grdResult.Enabled = true;
    //                    Load_toplink(getPostBackControlName());
    //                }                    
    //            }
    //            btnUser_Id_Search.Enabled = false;
    //            txtUser_Id.ReadOnly = true;
    //            txtUser_Id.CssClass = "read-only";
    //            txtName.ReadOnly = true;
    //            txtName.CssClass = "read-only";
    //            chkSuper_User.Enabled = false;
    //            grdModule_Permission.Enabled = false;
    //        }
    //        catch
    //        {

    //        }
    //    }
    //}
    //protected void toplink_cancel_Click(object sender, ImageClickEventArgs e)
    //{
    //    lblErrorMessage.Text = "";
    //    btnUser_Id_Search.Enabled = false;
    //    txtUser_Id.Text = ViewState["txtUser_Id"].ToString();
    //    txtUser_Id.ReadOnly = true;
    //    txtUser_Id.CssClass = "read-only";
    //    txtName.Text = ViewState["txtName"].ToString();
    //    txtName.ReadOnly = true;
    //    txtName.CssClass = "read-only";
    //    chkSuper_User.Checked = (bool)ViewState["chkSuper_User"];
    //    chkSuper_User.Enabled = false;
    //    grdModule_Permission.Enabled = false;
    //    grdModule_Permission.DataBind();

    //    //enable grdResult after click
    //    grdResult.Enabled = true;
    //    Load_toplink(getPostBackControlName());
    //}
    //protected void toplink_delete_Click(object sender, ImageClickEventArgs e)
    //{
    //    try
    //    {
    //        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
    //        {
    //            SqlCommand cmdSearch = new SqlCommand("SELECT [USER_ID] FROM [HR360_BI02_A] WHERE [USER_ID] = @USER_ID", conn);
    //            cmdSearch.Parameters.AddWithValue("@USER_ID", txtUser_Id.Text.ToUpper().Trim());
    //            conn.Open();
    //            SqlDataReader reader = cmdSearch.ExecuteReader();

    //            if (reader.HasRows)
    //            {
    //                if (!reader.IsClosed)
    //                {
    //                    reader.Close();
    //                }
    //                //clear any assigned functions to the user
    //                SqlCommand cmdDelete = new SqlCommand("DELETE FROM [HR360_BI02_A] WHERE [USER_ID] = @USER_ID", conn);
    //                cmdDelete.Parameters.AddWithValue("@USER_ID", txtUser_Id.Text.ToUpper().Trim());
    //                cmdDelete.ExecuteNonQuery();
    //                //take out the super_user privilege in BI01_A database
    //                SqlCommand cmdUpdate = new SqlCommand("UPDATE [HR360_BI01_A] SET [SUPER_USER]=@SUPER_USER WHERE [ID]=@ID", conn);
    //                cmdUpdate.Parameters.AddWithValue("@ID", txtUser_Id.Text);
    //                cmdUpdate.Parameters.AddWithValue("@SUPER_USER", 0);
    //                cmdUpdate.ExecuteNonQuery();
    //                //select first item (if exist) on grdResult after successful delete
    //                if (grdResult.Rows.Count != 0)
    //                {
    //                    grdResult.SelectedIndex = 0;
    //                }
    //                else
    //                {
    //                    grdResult.SelectedIndex = -1;
    //                }
    //                toplink_refresh_Click(sender, (ImageClickEventArgs)e);
    //                lblErrorMessage.Text = "";
    //                txtUser_Id.Text = "";
    //                txtName.Text = "";
    //                chkSuper_User.Checked = false;
    //                grdModule_Permission.DataBind();
    //                Load_toplink(getPostBackControlName());
    //            }
    //            else
    //            {
    //                lblErrorMessage.Text = "此使用者未被賦予任何權限";
    //                if (!reader.IsClosed)
    //                {
    //                    reader.Close();
    //                }
    //            }
    //        }
    //    }
    //    catch (SqlException ex)
    //    {
    //        switch (ex.Number)
    //        {
    //            case 547:
    //                lblErrorMessage.Text = "此項目已連結至其他資料，不可刪除";
    //                break;
    //            default:
    //                lblErrorMessage.Text = "資料刪除錯誤";
    //                break;
    //        }
    //    }
    //    btnUser_Id_Search.Enabled = false;
    //    txtUser_Id.ReadOnly = true;
    //    txtUser_Id.CssClass = "read-only";
    //    txtName.ReadOnly = true;
    //    txtName.CssClass = "read-only";
    //    chkSuper_User.Enabled = false;
    //    grdModule_Permission.Enabled = false;
    //}
    //protected void toplink_refresh_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (grdResult.Rows.Count != 0)
    //    {
    //        int i = grdResult.SelectedIndex;
    //        btnSearch_Search_Click(sender, e);
    //        grdResult.SelectedIndex = i;
    //    }
    //}
    //protected void toplink_copy_Click(object sender, ImageClickEventArgs e)
    //{
    //    toplink_add_Click(sender, e);
    //    lblErrorMessage.Text = "";
    //    txtUser_Id.Text = ViewState["txtUser_Id"].ToString();
    //    txtName.Text = ViewState["txtName"].ToString();
    //    txtName.ReadOnly = true;
    //    txtName.CssClass = "read-only";
    //    chkSuper_User.Checked = (bool)ViewState["chkSuper_User"];
    //    chkSuper_User.Enabled = false;
    //    grdModule_Permission.DataBind();
    //    grdModule_Permission.Enabled = false;
    //    //txtUser_Id.Text = "";
    //    txtUser_Id.ReadOnly = true;
    //    txtUser_Id.CssClass = "required-field";
    //    txtUser_Id.Focus();

    //    //disable grdResult while in edit mode
    //    grdResult.Enabled = false;

    //    Load_toplink(getPostBackControlName());
    //}
    //protected void btnUser_Id_Search_Click(object sender, EventArgs e)
    //{
    //    grdUser_Id.SelectedIndex = -1;
    //    grdUser_Id.DataSource = null;
    //    grdUser_Id.DataBind();
    //    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
    //    {
    //        SqlCommand cmdSearch = new SqlCommand("SELECT [ID] 使用者代號, [NAME] 使用者名稱, [SUPER_USER] 超級使用者"
    //                                                + " FROM [HR360_BI01_A]"
    //                                                + " WHERE NOT EXISTS (SELECT [USER_ID] FROM [HR360_BI02_A] WHERE [HR360_BI02_A].[USER_ID] = [HR360_BI01_A].[ID])", conn);
    //        conn.Open();
    //        SqlDataAdapter da = new SqlDataAdapter(cmdSearch);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        grdUser_Id.DataSource = ds;
    //        grdUser_Id.DataBind();
    //    }
    //}
    //protected void grdUser_Id_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    txtUser_Id.Text = Server.HtmlDecode(grdUser_Id.SelectedRow.Cells[0].Text);
    //    txtName.Text = Server.HtmlDecode(grdUser_Id.SelectedRow.Cells[1].Text);
    //    if ((grdUser_Id.SelectedRow.Cells[2].Controls[0] as CheckBox).Checked == true)
    //    {
    //        chkSuper_User.Checked = true;
    //    }
    //    else
    //    {
    //        chkSuper_User.Checked = false;
    //    }
    //    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
    //    {
    //        SqlCommand cmdSearch = new SqlCommand("WITH [USER_PERMISSION]([MODULE_ID], [MODULE_NAME], [MODULE_CATEGORY], [EXECUTE], [ADD], [SEARCH], [EDIT], [OUTPUT], [DELETE])"
    //                                        + " AS"
    //                                        + " ("
    //                                        + " SELECT [HR360_BI03_B].[ID], [HR360_BI03_B].[NAME], [HR360_BI03_A].[NAME], [HR360_BI02_A].[EXECUTE], [HR360_BI02_A].[ADD], [HR360_BI02_A].[SEARCH], [HR360_BI02_A].[EDIT], [HR360_BI02_A].[OUTPUT], [HR360_BI02_A].[DELETE]"
    //                                        + " FROM [HR360_BI03_B]"
    //                                        + " LEFT JOIN [HR360_BI03_A] ON [HR360_BI03_B].[CATEGORY_ID] = [HR360_BI03_A].[ID]"
    //                                        + " LEFT JOIN [HR360_BI02_A] ON [HR360_BI03_B].[ID] = [HR360_BI02_A].[MODULE_ID]"
    //                                        + " WHERE [HR360_BI02_A].[USER_ID] = @USER_ID"
    //                                        + " )"
    //                                        + " SELECT [HR360_BI03_B].[ID] 程式代號, [HR360_BI03_B].[NAME] 程式名稱, [HR360_BI03_A].[NAME] 程式類別, [USER_PERMISSION].[EXECUTE] 執行, [USER_PERMISSION].[ADD] 新增, [USER_PERMISSION].[SEARCH] 查詢, [USER_PERMISSION].[EDIT] 修改, [USER_PERMISSION].[OUTPUT] 輸出, [USER_PERMISSION].[DELETE] 刪除"
    //                                        + " FROM [HR360_BI03_B]"
    //                                        + " LEFT JOIN [HR360_BI03_A] ON [HR360_BI03_B].[CATEGORY_ID] = [HR360_BI03_A].[ID]"
    //                                        + " LEFT JOIN [USER_PERMISSION] ON [HR360_BI03_B].[ID] = [USER_PERMISSION].[MODULE_ID]"
    //                                        + " ORDER BY [HR360_BI03_B].[ID]", conn);
    //        cmdSearch.Parameters.AddWithValue("@USER_ID", txtUser_Id.Text);
    //        conn.Open();
    //        SqlDataAdapter da = new SqlDataAdapter(cmdSearch);
    //        DataTable dt = new DataTable();
    //        da.Fill(dt);

    //        //goes through every row in grdModule_Permission
    //        foreach (GridViewRow row in grdModule_Permission.Rows)
    //        {
    //            //goes through every row in dt to look for matching module_id
    //            for (int i = 0; i < dt.Rows.Count; i++)
    //            {
    //                //finds matching module id
    //                if (dt.Rows[i][0].ToString() == row.Cells[0].ToString())
    //                {
    //                    //goes through the 6 function columns to see which one is checked
    //                    for (int j = 3; j < 9; j++)
    //                    {
    //                        //setting checkboxes in grdModule_Permission
    //                        if ((bool)dt.Rows[i][j])
    //                        {
    //                            ((CheckBox)row.Cells[j].Controls[0]).Checked = true;
    //                        }
    //                        else
    //                        {
    //                            ((CheckBox)row.Cells[j].Controls[0]).Checked = false;
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
        
    //}

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
    //protected override void Render(System.Web.UI.HtmlTextWriter writer)
    //{

    //    AddRowSelectToGridView(grdResult);
    //    AddRowSelectToGridView(grdUser_Id);

    //    base.Render(writer);

    //}
    //private void AddRowSelectToGridView(GridView gv)
    //{
    //    foreach (GridViewRow row in gv.Rows)
    //    {

    //        row.Attributes["onmouseover"] = "this.style.cursor='hand';";

    //        row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

    //        row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gv, "Select$" + row.RowIndex.ToString(), true));

    //    }
    //}
    //private void Load_toplink(string eventName)
    //{
    //    //DataTable dt = getPagePermission(System.IO.Path.GetFileName(Request.PhysicalPath).Remove(System.IO.Path.GetFileName(Request.PhysicalPath).Length - 5));

    //    try
    //    {
    //        //if (dt.Rows.Count != 0)
    //        //{
    //            if (eventName == null)
    //            {
    //                //enable and disable toplink base on user permission
    //                //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
    //                //{
    //                    toplink_add.Enabled = true;
    //                    toplink_add.CssClass = "";
    //                //}
    //                //else
    //                //{
    //                //    toplink_add.Enabled = false;
    //                //    toplink_add.CssClass = "disabled";
    //                //}
    //                //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][8].ToString().ToUpper().Equals("TRUE"))
    //                //{
    //                    toplink_search.Enabled = true;
    //                    toplink_search.CssClass = "";
    //                //}
    //                //else
    //                //{
    //                //    toplink_search.Enabled = false;
    //                //    toplink_search.CssClass = "disabled";
    //                //}
    //                toplink_edit.Enabled = false;
    //                toplink_edit.CssClass = "disabled";
    //                toplink_delete.Enabled = false;
    //                toplink_delete.CssClass = "disabled";
    //                toplink_print.Enabled = false;
    //                toplink_print.CssClass = "disabled";
    //                toplink_first_record.Enabled = false;
    //                toplink_first_record.CssClass = "disabled";
    //                toplink_previous.Enabled = false;
    //                toplink_previous.CssClass = "disabled";
    //                toplink_next.Enabled = false;
    //                toplink_next.CssClass = "disabled";
    //                toplink_last_record.Enabled = false;
    //                toplink_last_record.CssClass = "disabled";
    //                toplink_save.Enabled = false;
    //                toplink_save.CssClass = "disabled";
    //                toplink_cancel.Enabled = false;
    //                toplink_cancel.CssClass = "disabled";
    //                toplink_refresh.Enabled = false;
    //                toplink_refresh.CssClass = "disabled";
    //                toplink_copy.Enabled = false;
    //                toplink_copy.CssClass = "disabled";

    //            }
    //            else if (eventName == "toplink_add")
    //            {
    //                toplink_add.Enabled = false;
    //                toplink_add.CssClass = "disabled";
    //                toplink_search.Enabled = false;
    //                toplink_search.CssClass = "disabled";
    //                toplink_edit.Enabled = false;
    //                toplink_edit.CssClass = "disabled";
    //                toplink_delete.Enabled = false;
    //                toplink_delete.CssClass = "disabled";
    //                toplink_print.Enabled = false;
    //                toplink_print.CssClass = "disabled";
    //                toplink_first_record.Enabled = false;
    //                toplink_first_record.CssClass = "disabled";
    //                toplink_previous.Enabled = false;
    //                toplink_previous.CssClass = "disabled";
    //                toplink_next.Enabled = false;
    //                toplink_next.CssClass = "disabled";
    //                toplink_last_record.Enabled = false;
    //                toplink_last_record.CssClass = "disabled";
    //                toplink_save.Enabled = true;
    //                toplink_save.CssClass = "";
    //                toplink_cancel.Enabled = true;
    //                toplink_cancel.CssClass = "";
    //                toplink_refresh.Enabled = false;
    //                toplink_refresh.CssClass = "disabled";
    //                toplink_copy.Enabled = false;
    //                toplink_copy.CssClass = "disabled";
    //            }
    //            else if (eventName == "btnSearch_Search")
    //            {
    //                //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
    //                //{
    //                    toplink_add.Enabled = true;
    //                    toplink_add.CssClass = "";
    //                //}
    //                //else
    //                //{
    //                //    toplink_add.Enabled = false;
    //                //    toplink_add.CssClass = "disabled";
    //                //}
    //                //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][8].ToString().ToUpper().Equals("TRUE"))
    //                //{
    //                    toplink_search.Enabled = true;
    //                    toplink_search.CssClass = "";
    //                //}
    //                //else
    //                //{
    //                //    toplink_search.Enabled = false;
    //                //    toplink_search.CssClass = "disabled";
    //                //}
    //                toplink_save.Enabled = false;
    //                toplink_save.CssClass = "disabled";
    //                toplink_cancel.Enabled = false;
    //                toplink_cancel.CssClass = "disabled";
    //                //whether there are still items in search result or not
    //                if (grdResult.Rows.Count == 0)
    //                {
    //                    toplink_edit.Enabled = false;
    //                    toplink_edit.CssClass = "disabled";
    //                    toplink_print.Enabled = false;
    //                    toplink_print.CssClass = "disabled";
    //                    toplink_delete.Enabled = false;
    //                    toplink_delete.CssClass = "disabled";
    //                    toplink_first_record.Enabled = false;
    //                    toplink_first_record.CssClass = "disabled";
    //                    toplink_previous.Enabled = false;
    //                    toplink_previous.CssClass = "disabled";
    //                    toplink_next.Enabled = false;
    //                    toplink_next.CssClass = "disabled";
    //                    toplink_last_record.Enabled = false;
    //                    toplink_last_record.CssClass = "disabled";
    //                    toplink_refresh.Enabled = false;
    //                    toplink_refresh.CssClass = "disabled";
    //                    toplink_copy.Enabled = false;
    //                    toplink_copy.CssClass = "disabled";
    //                }
    //                else
    //                {
    //                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][9].ToString().ToUpper().Equals("TRUE"))
    //                    //{
    //                        toplink_edit.Enabled = true;
    //                        toplink_edit.CssClass = "";
    //                    //}
    //                    //else
    //                    //{
    //                    //    toplink_edit.Enabled = false;
    //                    //    toplink_edit.CssClass = "disabled";
    //                    //}
    //                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][10].ToString().ToUpper().Equals("TRUE"))
    //                    //{
    //                        toplink_print.Enabled = true;
    //                        toplink_print.CssClass = "";
    //                    //}
    //                    //else
    //                    //{
    //                    //    toplink_print.Enabled = false;
    //                    //    toplink_print.CssClass = "disabled";
    //                    //}
    //                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][11].ToString().ToUpper().Equals("TRUE"))
    //                    //{
    //                        toplink_delete.Enabled = true;
    //                        toplink_delete.CssClass = "";
    //                    //}
    //                    //else
    //                    //{
    //                    //    toplink_delete.Enabled = false;
    //                    //    toplink_delete.CssClass = "disabled";
    //                    //}
    //                    toplink_first_record.Enabled = true;
    //                    toplink_first_record.CssClass = "";
    //                    toplink_previous.Enabled = true;
    //                    toplink_previous.CssClass = "";
    //                    toplink_next.Enabled = true;
    //                    toplink_next.CssClass = "";
    //                    toplink_last_record.Enabled = true;
    //                    toplink_last_record.CssClass = "";
    //                    toplink_refresh.Enabled = true;
    //                    toplink_refresh.CssClass = "";
    //                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
    //                    //{
    //                        toplink_copy.Enabled = true;
    //                        toplink_copy.CssClass = "";
    //                    //}
    //                    //else
    //                    //{
    //                    //    toplink_copy.Enabled = false;
    //                    //    toplink_copy.CssClass = "disabled";
    //                    //}
    //                }
    //            }
    //            else if (eventName == "toplink_edit")
    //            {
    //                toplink_add.Enabled = false;
    //                toplink_add.CssClass = "disabled";
    //                toplink_search.Enabled = false;
    //                toplink_search.CssClass = "disabled";
    //                toplink_edit.Enabled = false;
    //                toplink_edit.CssClass = "disabled";
    //                toplink_delete.Enabled = false;
    //                toplink_delete.CssClass = "disabled";
    //                toplink_print.Enabled = false;
    //                toplink_print.CssClass = "disabled";
    //                toplink_first_record.Enabled = false;
    //                toplink_first_record.CssClass = "disabled";
    //                toplink_previous.Enabled = false;
    //                toplink_previous.CssClass = "disabled";
    //                toplink_next.Enabled = false;
    //                toplink_next.CssClass = "disabled";
    //                toplink_last_record.Enabled = false;
    //                toplink_last_record.CssClass = "disabled";
    //                toplink_save.Enabled = true;
    //                toplink_save.CssClass = "";
    //                toplink_cancel.Enabled = true;
    //                toplink_cancel.CssClass = "";
    //                toplink_refresh.Enabled = false;
    //                toplink_refresh.CssClass = "disabled";
    //                toplink_copy.Enabled = false;
    //                toplink_copy.CssClass = "disabled";
    //            }
    //            else if (eventName == "toplink_save")
    //            {
    //                //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
    //                //{
    //                    toplink_add.Enabled = true;
    //                    toplink_add.CssClass = "";
    //                //}
    //                //else
    //                //{
    //                //    toplink_add.Enabled = false;
    //                //    toplink_add.CssClass = "disabled";
    //                //}
    //                //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][8].ToString().ToUpper().Equals("TRUE"))
    //                //{
    //                //    toplink_search.Enabled = true;
    //                //    toplink_search.CssClass = "";
    //                //}
    //                //else
    //                //{
    //                    toplink_search.Enabled = false;
    //                    toplink_search.CssClass = "disabled";
    //                //}
    //                toplink_save.Enabled = false;
    //                toplink_save.CssClass = "disabled";
    //                toplink_cancel.Enabled = false;
    //                toplink_cancel.CssClass = "disabled";
    //                //whether there are still items in search result or not
    //                if (grdResult.Rows.Count == 0)
    //                {
    //                    toplink_edit.Enabled = false;
    //                    toplink_edit.CssClass = "disabled";
    //                    toplink_print.Enabled = false;
    //                    toplink_print.CssClass = "disabled";
    //                    toplink_delete.Enabled = false;
    //                    toplink_delete.CssClass = "disabled";
    //                    toplink_first_record.Enabled = false;
    //                    toplink_first_record.CssClass = "disabled";
    //                    toplink_previous.Enabled = false;
    //                    toplink_previous.CssClass = "disabled";
    //                    toplink_next.Enabled = false;
    //                    toplink_next.CssClass = "disabled";
    //                    toplink_last_record.Enabled = false;
    //                    toplink_last_record.CssClass = "disabled";
    //                    toplink_refresh.Enabled = false;
    //                    toplink_refresh.CssClass = "disabled";
    //                    toplink_copy.Enabled = false;
    //                    toplink_copy.CssClass = "disabled";
    //                }
    //                else
    //                {
    //                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][9].ToString().ToUpper().Equals("TRUE"))
    //                    //{
    //                        toplink_edit.Enabled = true;
    //                        toplink_edit.CssClass = "";
    //                    //}
    //                    //else
    //                    //{
    //                    //    toplink_edit.Enabled = false;
    //                    //    toplink_edit.CssClass = "disabled";
    //                    //}
    //                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][10].ToString().ToUpper().Equals("TRUE"))
    //                    //{
    //                        toplink_print.Enabled = true;
    //                        toplink_print.CssClass = "";
    //                    //}
    //                    //else
    //                    //{
    //                    //    toplink_print.Enabled = false;
    //                    //    toplink_print.CssClass = "disabled";
    //                    //}
    //                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][11].ToString().ToUpper().Equals("TRUE"))
    //                    //{
    //                        toplink_delete.Enabled = true;
    //                        toplink_delete.CssClass = "";
    //                    //}
    //                    //else
    //                    //{
    //                    //    toplink_delete.Enabled = false;
    //                    //    toplink_delete.CssClass = "disabled";
    //                    //}
    //                    toplink_first_record.Enabled = true;
    //                    toplink_first_record.CssClass = "";
    //                    toplink_previous.Enabled = true;
    //                    toplink_previous.CssClass = "";
    //                    toplink_next.Enabled = true;
    //                    toplink_next.CssClass = "";
    //                    toplink_last_record.Enabled = true;
    //                    toplink_last_record.CssClass = "";
    //                    toplink_refresh.Enabled = true;
    //                    toplink_refresh.CssClass = "";
    //                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
    //                    //{
    //                        toplink_copy.Enabled = true;
    //                        toplink_copy.CssClass = "";
    //                    //}
    //                    //else
    //                    //{
    //                    //    toplink_copy.Enabled = false;
    //                    //    toplink_copy.CssClass = "disabled";
    //                    //}
    //                }
    //            }
    //            else if (eventName == "toplink_cancel")
    //            {
    //                //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
    //                //{
    //                    toplink_add.Enabled = true;
    //                    toplink_add.CssClass = "";
    //                //}
    //                //else
    //                //{
    //                //    toplink_add.Enabled = false;
    //                //    toplink_add.CssClass = "disabled";
    //                //}
    //                //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][8].ToString().ToUpper().Equals("TRUE"))
    //                //{
    //                    toplink_search.Enabled = true;
    //                    toplink_search.CssClass = "";
    //                //}
    //                //else
    //                //{
    //                //    toplink_search.Enabled = false;
    //                //    toplink_search.CssClass = "disabled";
    //                //}
    //                toplink_save.Enabled = false;
    //                toplink_save.CssClass = "disabled";
    //                toplink_cancel.Enabled = false;
    //                toplink_cancel.CssClass = "disabled";
    //                //whether there are still items in search result or not
    //                if (grdResult.Rows.Count == 0)
    //                {
    //                    toplink_edit.Enabled = false;
    //                    toplink_edit.CssClass = "disabled";
    //                    toplink_print.Enabled = false;
    //                    toplink_print.CssClass = "disabled";
    //                    toplink_delete.Enabled = false;
    //                    toplink_delete.CssClass = "disabled";
    //                    toplink_first_record.Enabled = false;
    //                    toplink_first_record.CssClass = "disabled";
    //                    toplink_previous.Enabled = false;
    //                    toplink_previous.CssClass = "disabled";
    //                    toplink_next.Enabled = false;
    //                    toplink_next.CssClass = "disabled";
    //                    toplink_last_record.Enabled = false;
    //                    toplink_last_record.CssClass = "disabled";
    //                    toplink_refresh.Enabled = false;
    //                    toplink_refresh.CssClass = "disabled";
    //                    toplink_copy.Enabled = false;
    //                    toplink_copy.CssClass = "disabled";
    //                }
    //                else
    //                {
    //                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][9].ToString().ToUpper().Equals("TRUE"))
    //                    //{
    //                        toplink_edit.Enabled = true;
    //                        toplink_edit.CssClass = "";
    //                    //}
    //                    //else
    //                    //{
    //                    //    toplink_edit.Enabled = false;
    //                    //    toplink_edit.CssClass = "disabled";
    //                    //}
    //                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][10].ToString().ToUpper().Equals("TRUE"))
    //                    //{
    //                        toplink_print.Enabled = true;
    //                        toplink_print.CssClass = "";
    //                    //}
    //                    //else
    //                    //{
    //                    //    toplink_print.Enabled = false;
    //                    //    toplink_print.CssClass = "disabled";
    //                    //}
    //                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][11].ToString().ToUpper().Equals("TRUE"))
    //                    //{
    //                        toplink_delete.Enabled = true;
    //                        toplink_delete.CssClass = "";
    //                    //}
    //                    //else
    //                    //{
    //                    //    toplink_delete.Enabled = false;
    //                    //    toplink_delete.CssClass = "disabled";
    //                    //}
    //                    toplink_first_record.Enabled = true;
    //                    toplink_first_record.CssClass = "";
    //                    toplink_previous.Enabled = true;
    //                    toplink_previous.CssClass = "";
    //                    toplink_next.Enabled = true;
    //                    toplink_next.CssClass = "";
    //                    toplink_last_record.Enabled = true;
    //                    toplink_last_record.CssClass = "";
    //                    toplink_refresh.Enabled = true;
    //                    toplink_refresh.CssClass = "";
    //                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
    //                    //{
    //                        toplink_copy.Enabled = true;
    //                        toplink_copy.CssClass = "";
    //                    //}
    //                    //else
    //                    //{
    //                    //    toplink_copy.Enabled = false;
    //                    //    toplink_copy.CssClass = "disabled";
    //                    //}
    //                }
    //            }
    //            else if (eventName == "toplink_delete")
    //            {
    //                //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
    //                //{
    //                    toplink_add.Enabled = true;
    //                    toplink_add.CssClass = "";
    //                //}
    //                //else
    //                //{
    //                //    toplink_add.Enabled = false;
    //                //    toplink_add.CssClass = "disabled";
    //                //}
    //                //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][8].ToString().ToUpper().Equals("TRUE"))
    //                //{
    //                    toplink_search.Enabled = true;
    //                    toplink_search.CssClass = "";
    //                //}
    //                //else
    //                //{
    //                //    toplink_search.Enabled = false;
    //                //    toplink_search.CssClass = "disabled";
    //                //}
    //                toplink_save.Enabled = false;
    //                toplink_save.CssClass = "disabled";
    //                toplink_cancel.Enabled = false;
    //                toplink_cancel.CssClass = "disabled";
    //                //whether there are still items in search result or not
    //                if (grdResult.Rows.Count == 0)
    //                {
    //                    toplink_edit.Enabled = false;
    //                    toplink_edit.CssClass = "disabled";
    //                    toplink_print.Enabled = false;
    //                    toplink_print.CssClass = "disabled";
    //                    toplink_delete.Enabled = false;
    //                    toplink_delete.CssClass = "disabled";
    //                    toplink_first_record.Enabled = false;
    //                    toplink_first_record.CssClass = "disabled";
    //                    toplink_previous.Enabled = false;
    //                    toplink_previous.CssClass = "disabled";
    //                    toplink_next.Enabled = false;
    //                    toplink_next.CssClass = "disabled";
    //                    toplink_last_record.Enabled = false;
    //                    toplink_last_record.CssClass = "disabled";
    //                    toplink_refresh.Enabled = false;
    //                    toplink_refresh.CssClass = "disabled";
    //                    toplink_copy.Enabled = false;
    //                    toplink_copy.CssClass = "disabled";
    //                }
    //                else
    //                {
    //                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][9].ToString().ToUpper().Equals("TRUE"))
    //                    //{
    //                    //    toplink_edit.Enabled = true;
    //                        toplink_edit.CssClass = "";
    //                    //}
    //                    //else
    //                    //{
    //                    //    toplink_edit.Enabled = false;
    //                    //    toplink_edit.CssClass = "disabled";
    //                    //}
    //                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][10].ToString().ToUpper().Equals("TRUE"))
    //                    //{
    //                        toplink_print.Enabled = true;
    //                        toplink_print.CssClass = "";
    //                    //}
    //                    //else
    //                    //{
    //                    //    toplink_print.Enabled = false;
    //                    //    toplink_print.CssClass = "disabled";
    //                    //}
    //                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][11].ToString().ToUpper().Equals("TRUE"))
    //                    //{
    //                        toplink_delete.Enabled = true;
    //                        toplink_delete.CssClass = "";
    //                    //}
    //                    //else
    //                    //{
    //                    //    toplink_delete.Enabled = false;
    //                    //    toplink_delete.CssClass = "disabled";
    //                    //}
    //                    toplink_first_record.Enabled = true;
    //                    toplink_first_record.CssClass = "";
    //                    toplink_previous.Enabled = true;
    //                    toplink_previous.CssClass = "";
    //                    toplink_next.Enabled = true;
    //                    toplink_next.CssClass = "";
    //                    toplink_last_record.Enabled = true;
    //                    toplink_last_record.CssClass = "";
    //                    toplink_refresh.Enabled = true;
    //                    toplink_refresh.CssClass = "";
    //                    //if (dt.Rows[0][5].ToString().ToUpper().Equals("TRUE") || dt.Rows[0][7].ToString().ToUpper().Equals("TRUE"))
    //                    //{
    //                        toplink_copy.Enabled = true;
    //                        toplink_copy.CssClass = "";
    //                    //}
    //                    //else
    //                    //{
    //                    //    toplink_copy.Enabled = false;
    //                    //    toplink_copy.CssClass = "disabled";
    //                    //}
    //                }
    //            }
    //            else if (eventName == "toplink_copy")
    //            {
    //                toplink_add.Enabled = false;
    //                toplink_add.CssClass = "disabled";
    //                toplink_search.Enabled = false;
    //                toplink_search.CssClass = "disabled";
    //                toplink_edit.Enabled = false;
    //                toplink_edit.CssClass = "disabled";
    //                toplink_delete.Enabled = false;
    //                toplink_delete.CssClass = "disabled";
    //                toplink_print.Enabled = false;
    //                toplink_print.CssClass = "disabled";
    //                toplink_first_record.Enabled = false;
    //                toplink_first_record.CssClass = "disabled";
    //                toplink_previous.Enabled = false;
    //                toplink_previous.CssClass = "disabled";
    //                toplink_next.Enabled = false;
    //                toplink_next.CssClass = "disabled";
    //                toplink_last_record.Enabled = false;
    //                toplink_last_record.CssClass = "disabled";
    //                toplink_save.Enabled = true;
    //                toplink_save.CssClass = "";
    //                toplink_cancel.Enabled = true;
    //                toplink_cancel.CssClass = "";
    //                toplink_refresh.Enabled = false;
    //                toplink_refresh.CssClass = "disabled";
    //                toplink_copy.Enabled = false;
    //                toplink_copy.CssClass = "disabled";
    //            }
    //        //}
    //    }
    //    catch
    //    {

    //    }
    //}
    //private string getPostBackControlName()
    //{
    //    Control control = null;
    //    //first we will check the "__EVENTTARGET" because if post back made by       the controls
    //    //which used "_doPostBack" function also available in Request.Form collection.
    //    string ctrlname = Page.Request.Params["__EVENTTARGET"];
    //    if (ctrlname != null && ctrlname != String.Empty)
    //    {
    //        control = Page.FindControl(ctrlname);
    //    }
    //    // if __EVENTTARGET is null, the control is a button type and we need to
    //    // iterate over the form collection to find it
    //    else
    //    {
    //        string ctrlStr = String.Empty;
    //        Control c = null;
    //        foreach (string ctl in Page.Request.Form)
    //        {
    //            //handle ImageButton they having an additional "quasi-property" in their Id which identifies
    //            //mouse x and y coordinates
    //            if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
    //            {
    //                ctrlStr = ctl.Substring(0, ctl.Length - 2);
    //                c = Page.FindControl(ctrlStr);
    //            }
    //            else
    //            {
    //                c = Page.FindControl(ctl);
    //            }
    //            if (c is System.Web.UI.WebControls.Button ||
    //                     c is System.Web.UI.WebControls.ImageButton)
    //            {
    //                control = c;
    //                break;
    //            }
    //        }
    //    }
    //    if (control == null)
    //    {
    //        return null;
    //    }
    //    else
    //    {
    //        return control.ID;
    //    }

    //}
}