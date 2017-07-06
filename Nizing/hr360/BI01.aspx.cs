using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hr360_BI01 : System.Web.UI.Page
{
    //universal functions
    string connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string nzconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    private enum currentFunctionMode { ADD, EDIT, NONE };
    //    //save view-state
    //void Page_PreRender(object sender, EventArgs e)
    //{
    //    //ViewState["txtUserId"] = txtUserId.Text.ToUpper().Trim();
    //    //ViewState["txtPassword"] = txtPassword.Text.Trim();
    //    //ViewState["txtEmail"] = txtEmail.Text.ToUpper().Trim();
    //    //ViewState["txtLineId"] = txtLineId.Text.ToUpper().Trim();
    //    //ViewState["chkDisabled"] = chkDisabled.Checked;
    //    //ViewState["txtDisabledDate"] = txtDisabledDate.Text.Trim();
    //    //ViewState["txtErpUserId"] = txtErpUserId.Text.Trim();
    //    //ViewState["txtName"] = txtName.Text.Trim();
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ViewState["Mode"] = currentFunctionMode.NONE;
            txtUserId.ReadOnly = true;
            txtUserId.CssClass = "read-only";
            txtPassword.ReadOnly = true;
            txtPassword.CssClass = "read-only";
            txtReenterPassword.ReadOnly = true;
            txtReenterPassword.CssClass = "read-only";
            txtEmail.Text = "";
            txtEmail.ReadOnly = true;
            txtEmail.CssClass = "read-only";
            txtLineId.Text = "";
            txtLineId.ReadOnly = true;
            txtLineId.CssClass = "read-only";
            txtUserId.Text = "";
            txtPassword.Text = "";
            txtReenterPassword.Text = "";
            chkSuperUser.Enabled = false;
            chkDisabled.Enabled = false;
            txtDisabledDate.ReadOnly = true;
            txtDisabledDate.CssClass = "read-only";
            txtErpUserId.ReadOnly = true;
            txtErpUserId.CssClass = "read-only";
            btnErpId_Search.Enabled = false;
            txtName.ReadOnly = true;
            txtName.CssClass = "read-only";
            lblErrorMessage.Text = "";

            Load_toplink(getPostBackControlName());
        }
        else
        {
        }
    }
    protected void toplink_add_Click(object sender, EventArgs e)
    {
        ViewState["Mode"] = currentFunctionMode.ADD;
        txtUserId.ReadOnly = false;
        txtUserId.CssClass = "required-field";
        txtPassword.ReadOnly = false;
        txtPassword.CssClass = "required-field";
        txtReenterPassword.ReadOnly = false;
        txtReenterPassword.CssClass = "required-field";
        txtEmail.Text = "";
        txtEmail.ReadOnly = false;
        txtEmail.CssClass = "";
        txtLineId.Text = "";
        txtLineId.ReadOnly = false;
        txtLineId.CssClass = "";
        txtUserId.Text = "";
        txtPassword.Text = "";
        txtReenterPassword.Text = "";
        chkSuperUser.Enabled = true;
        chkDisabled.Enabled = true;
        btnErpId_Search.Enabled = true;
        txtErpUserId.Text = "";
        txtName.Text = "";
        txtName.ReadOnly = false;
        txtName.CssClass = "required-field";
        lblErrorMessage.Text = "";

        //disable grdResult
        grdResult.Enabled = false;

        Load_toplink(getPostBackControlName());
    }
        //search-related functions
    protected void toplink_search_Click(object sender, EventArgs e)
    {
        
    }
    protected void ddlSearch_Item_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSearch_Item.SelectedValue == "CREATEDATE" || ddlSearch_Item.SelectedValue == "MODIFIEDDATE" || ddlSearch_Item.SelectedValue == "DISABLEDDATE")
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
        string query = "SELECT [ERP_ID] N'ERP員工代號', [NAME] N'姓名', [ID] N'使用者代號', [PASSWORD] N'密碼', [EMAIL] N'EMAIL', [LINE_ID] N'LINE ID', [DISABLED] N'帳號失效', [DISABLEDDATE] N'失效日期', [SUPER_USER] N'超級使用者', [CREATEDATE] N'建立日期', [CREATOR] N'建立者', [MODIFIEDDATE] N'修改日期', [MODIFIER] N'修改者' FROM [HR360_BI01_A]";
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
        txtUserId.ReadOnly = true;
        txtUserId.CssClass = "read-only";
        txtPassword.ReadOnly = true;
        txtPassword.CssClass = "read-only";
        txtReenterPassword.ReadOnly = true;
        txtReenterPassword.CssClass = "read-only";
        txtEmail.ReadOnly = true;
        txtEmail.CssClass = "read-only";
        txtLineId.ReadOnly = true;
        txtLineId.CssClass = "read-only";
        chkSuperUser.Enabled = false;
        chkDisabled.Enabled = false;
        btnErpId_Search.Enabled = false;
        txtName.ReadOnly = true;
        txtName.CssClass = "read-only";
        txtErpUserId.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[0].Text);
        txtName.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[1].Text);
        txtUserId.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[2].Text);
        txtPassword.Text = ((masterPage_HR360_Child)this.Master).Decrypt(Server.HtmlDecode(grdResult.SelectedRow.Cells[3].Text));
        txtEmail.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[4].Text);
        txtLineId.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[5].Text);        
        if ((grdResult.SelectedRow.Cells[6].Controls[0] as CheckBox).Checked == true)
        {
            chkDisabled.Checked = true;
        }
        else
        {
            chkDisabled.Checked = false;
        }        
        txtDisabledDate.Text = Server.HtmlDecode(grdResult.SelectedRow.Cells[7].Text);
        if ((grdResult.SelectedRow.Cells[8].Controls[0] as CheckBox).Checked == true)
        {
            chkSuperUser.Checked = true;
        }
        else
        {
            chkSuperUser.Checked = false;
        } 
        
    }
        //
    protected void toplink_edit_Click(object sender, EventArgs e)
    {
        ViewState["Mode"] = currentFunctionMode.EDIT;
        if (txtUserId.Text.Trim() == "")
        {
            lblErrorMessage.Text = "需先輸入使用者代號後才能進行修改，修改時不得更改使用者代號";
            txtUserId.ReadOnly = false;
            txtUserId.CssClass = "required-field";
            txtUserId.Focus();
        }
        else
        {            
            txtUserId.ReadOnly = true;
            txtUserId.CssClass = "read-only";
            txtPassword.ReadOnly = false;
            txtPassword.CssClass = "required-field";
            txtPassword.Focus();
            txtReenterPassword.ReadOnly = false;
            txtReenterPassword.CssClass = "required-field";
            txtEmail.ReadOnly = false;
            txtEmail.CssClass = "";
            txtLineId.ReadOnly = false;
            txtLineId.CssClass = "";
            chkSuperUser.Enabled = true;
            chkDisabled.Enabled = true;
            btnErpId_Search.Enabled = true;
            if (txtName.Text.Trim() == "")
            {
                txtName.ReadOnly = false;
                txtName.CssClass = "required-field";
            }
            else
            {
                txtName.ReadOnly = true;
                txtName.CssClass = "read-only";
            }
            lblErrorMessage.Text = "";

            //disable gridview while editing
            grdResult.Enabled = false;

            Load_toplink(getPostBackControlName());
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
        try
        {
            //if (txtUserId.ReadOnly == false) //判斷是要新增還是修改資料，新增資料txtUserId唯讀屬性為false
            if((currentFunctionMode)ViewState["Mode"] == currentFunctionMode.ADD)
            {
                if (txtUserId.Text.Trim() == "") //沒有輸入要使用的User ID
                {
                    lblErrorMessage.Text = "使用者代號為必填欄位";
                    txtUserId.ReadOnly = false;
                    txtUserId.CssClass = "required-field";
                    txtUserId.Focus();
                }
                else if (txtPassword.Text.Trim() == "") //沒有密碼
                {
                    lblErrorMessage.Text = "密碼為必填欄位";
                    txtPassword.ReadOnly = false;                    
                    txtPassword.CssClass = "required-field";
                    txtReenterPassword.ReadOnly = false;
                    txtReenterPassword.CssClass = "required-field";
                    txtPassword.Focus();
                }
                else if (txtPassword.Text.Trim() != txtReenterPassword.Text.Trim()) //密碼與確認密碼不相符
                {
                    lblErrorMessage.Text = "密碼與確認密碼不相符";
                    txtPassword.ReadOnly = false;
                    txtPassword.CssClass = "required-field";
                    txtReenterPassword.ReadOnly = false;
                    txtReenterPassword.CssClass = "required-field";
                    txtPassword.Focus();
                }
                else if (txtName.Text.Trim() == "") //沒有使用者名稱
                {
                    lblErrorMessage.Text = "使用者名稱為必填欄位，請輸入名稱，或選擇ERP員工代號";
                    btnErpId_Search.Enabled = true;
                    txtName.ReadOnly = false;
                    txtName.CssClass = "required-field";
                    txtName.Focus();
                }
                else if (string.IsNullOrWhiteSpace(txtEmail.Text) == false && ValidateEmail(txtEmail.Text) == false)
                {
                    lblErrorMessage.Text = "請輸入有效的Email地址";
                    txtEmail.ReadOnly = false;
                    txtEmail.CssClass = "";
                    txtEmail.Focus();
                }
                else
                {
                    //新增資料的QUERY
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmdDuplicateSearch = new SqlCommand("SELECT * FROM [HR360_BI01_A] WHERE ID=@USERID", conn);
                        cmdDuplicateSearch.Parameters.AddWithValue("@USERID", txtUserId.Text.ToUpper().Trim());
                        SqlDataReader reader = cmdDuplicateSearch.ExecuteReader();

                        if (reader.HasRows) //有讀到資料表示使用者已存在
                        {
                            lblErrorMessage.Text = "此使用者代號已經存在，請選擇另一個代號";
                            reader.Close();
                            txtUserId.ReadOnly = false;
                            txtUserId.CssClass = "required-field";
                            txtUserId.Focus();
                            txtPassword.ReadOnly = false;
                            txtPassword.CssClass = "required-field";
                            txtReenterPassword.ReadOnly = false;
                            txtReenterPassword.CssClass = "required-field";
                            txtEmail.ReadOnly = false;
                            txtEmail.CssClass = "";
                            txtLineId.ReadOnly = false;
                            txtLineId.CssClass = "";
                            chkSuperUser.Enabled = true;
                            chkDisabled.Enabled = true;
                            btnErpId_Search.Enabled = true;
                            if (txtName.Text.Trim() == "")
                            {
                                txtName.ReadOnly = false;
                                txtName.CssClass = "required-field";
                            }
                            else
                            {
                                txtName.ReadOnly = true;
                                txtName.CssClass = "read-only";
                            }
                        }
                        else
                        {
                            reader.Close();
                            SqlCommand cmd = new SqlCommand("INSERT INTO [HR360_BI01_A] VALUES (GETDATE(),@CREATOR,GETDATE(),@MODIFIER,@USERID,@ERPID,@NAME,@PASSWORD,@EMAIL,@LINEID,N'0',@DISABLED,@DISABLEDDATE,@SUPERUSER)", conn);
                            cmd.Parameters.AddWithValue("@CREATOR", Session["user_id"]);
                            cmd.Parameters.AddWithValue("@MODIFIER", Session["user_id"]);
                            cmd.Parameters.AddWithValue("@USERID", txtUserId.Text.ToUpper().Trim());
                            cmd.Parameters.AddWithValue("@ERPID", txtErpUserId.Text.Trim());
                            cmd.Parameters.AddWithValue("@NAME", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@PASSWORD", ((masterPage_HR360_Child)this.Master).Encrypt(txtPassword.Text.Trim()));
                            cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text.ToUpper().Trim());
                            cmd.Parameters.AddWithValue("@LINEID", txtLineId.Text.Trim());
                            if (chkDisabled.Checked == true)
                            {
                                cmd.Parameters.AddWithValue("@DISABLED", 1);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@DISABLED", 0);
                            }
                            if (chkSuperUser.Checked == true)
                            {
                                cmd.Parameters.AddWithValue("@SUPERUSER", 1);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@SUPERUSER", 0);
                            }
                            cmd.Parameters.AddWithValue("@DISABLEDDATE", txtDisabledDate.Text.Trim());
                            cmd.ExecuteNonQuery();
                            lblErrorMessage.Text = "";
                            txtUserId.ReadOnly = true;
                            txtUserId.CssClass = "read-only";
                            txtPassword.ReadOnly = true;
                            txtPassword.CssClass = "read-only";
                            txtReenterPassword.ReadOnly = true;
                            txtReenterPassword.CssClass = "read-only";
                            txtEmail.ReadOnly = true;
                            txtEmail.CssClass = "read-only";
                            txtLineId.ReadOnly = true;
                            txtLineId.CssClass = "read-only";
                            chkSuperUser.Enabled = false;
                            chkDisabled.Enabled = false;
                            btnErpId_Search.Enabled = false;
                            txtName.ReadOnly = true;
                            txtName.CssClass = "read-only";
                            //enable grdResult after click
                            grdResult.Enabled = true;
                            Load_toplink(getPostBackControlName());
                        }
                    }
                }
            }
            else //如果不是新增資料，就是修改資料(txtUserId為唯讀)
            {
                if (txtUserId.Text.Trim() == "") //沒有輸入要使用的User ID
                {
                    lblErrorMessage.Text = "使用者代號為必填欄位";
                    txtUserId.ReadOnly = false;
                    txtUserId.CssClass = "required-field";
                    txtUserId.Focus();
                }
                //else if (txtPassword.Text.Trim() == "") //沒有密碼
                //{
                //    lblErrorMessage.Text = "密碼為必填欄位";
                //    txtUserId.ReadOnly = true;
                //    txtUserId.CssClass = "read-only";
                //    txtPassword.ReadOnly = false;
                //    txtPassword.CssClass = "required-field";
                //    txtReenterPassword.ReadOnly = false;
                //    txtReenterPassword.CssClass = "required-field";
                //    txtPassword.Focus();
                //}
                else if (txtPassword.Text.Trim() != txtReenterPassword.Text.Trim()) //密碼與確認密碼不相符
                {
                    lblErrorMessage.Text = "密碼與確認密碼不相符";
                    txtUserId.ReadOnly = true;
                    txtUserId.CssClass = "read-only";
                    txtPassword.ReadOnly = false;
                    txtPassword.CssClass = "required-field";
                    txtReenterPassword.ReadOnly = false;
                    txtReenterPassword.CssClass = "required-field";
                    txtPassword.Focus();
                }
                else if (txtName.Text.Trim() == "") //沒有使用者名稱
                {
                    lblErrorMessage.Text = "使用者名稱為必填欄位，請輸入名稱，或選擇ERP員工代號";
                    btnErpId_Search.Enabled = true;
                    txtName.ReadOnly = false;
                    txtName.CssClass = "required-field";
                    txtName.Focus();
                }
                else if (string.IsNullOrWhiteSpace(txtEmail.Text) == false && ValidateEmail(txtEmail.Text) == false)
                {
                    lblErrorMessage.Text = "請輸入有效的Email地址";
                    txtEmail.ReadOnly = false;
                    txtEmail.CssClass = "";
                    txtEmail.Focus();
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "";
                        if (String.IsNullOrEmpty(txtPassword.Text.Trim()))
                        {
                            query = "UPDATE [HR360_BI01_A] SET [MODIFIEDDATE]=GETDATE(),[MODIFIER]=@MODIFIER,[ERP_ID]=@ERPID,[NAME]=@NAME,[EMAIL]=@EMAIL,[LINE_ID]=@LINEID,[DISABLED]=@DISABLED,[DISABLEDDATE]=@DISABLEDDATE, [SUPER_USER]=@SUPERUSER WHERE ID=@USERID";
                        }
                        else
                        {
                            query = "UPDATE [HR360_BI01_A] SET [MODIFIEDDATE]=GETDATE(),[MODIFIER]=@MODIFIER,[ERP_ID]=@ERPID,[NAME]=@NAME,[PASSWORD]=@PASSWORD,[EMAIL]=@EMAIL,[LINE_ID]=@LINEID,[DISABLED]=@DISABLED,[DISABLEDDATE]=@DISABLEDDATE, [SUPER_USER]=@SUPERUSER WHERE ID=@USERID";
                        }
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MODIFIER", Session["user_id"]);
                        cmd.Parameters.AddWithValue("@USERID", txtUserId.Text.ToUpper().Trim());
                        cmd.Parameters.AddWithValue("@ERPID", txtErpUserId.Text.Trim());
                        cmd.Parameters.AddWithValue("@NAME", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@PASSWORD", ((masterPage_HR360_Child)this.Master).Encrypt(txtPassword.Text.Trim()));
                        cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text.ToUpper().Trim());
                        cmd.Parameters.AddWithValue("@LINEID", txtLineId.Text.Trim());
                        if (chkDisabled.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@DISABLED", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@DISABLED", 0);
                        }
                        cmd.Parameters.AddWithValue("@DISABLEDDATE", txtDisabledDate.Text.Trim());
                        if (chkSuperUser.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@SUPERUSER", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@SUPERUSER", 0);
                        }
                        cmd.ExecuteNonQuery();
                        lblErrorMessage.Text = "";
                    }
                    txtUserId.ReadOnly = true;
                    txtUserId.CssClass = "read-only";
                    txtPassword.ReadOnly = true;
                    txtPassword.CssClass = "read-only";
                    txtReenterPassword.ReadOnly = true;
                    txtReenterPassword.CssClass = "read-only";
                    txtEmail.ReadOnly = true;
                    txtEmail.CssClass = "read-only";
                    txtLineId.ReadOnly = true;
                    txtLineId.CssClass = "read-only";
                    chkSuperUser.Enabled = false;
                    chkDisabled.Enabled = false;
                    btnErpId_Search.Enabled = false;
                    txtName.ReadOnly = true;
                    txtName.CssClass = "read-only";
                    //enable grdResult after click
                    grdResult.Enabled = true;
                    Load_toplink(getPostBackControlName());
                }
            }
            ViewState["Mode"] = currentFunctionMode.NONE;
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void toplink_cancel_Click(object sender, EventArgs e)
    {
        lblErrorMessage.Text = "";
        //txtUserId.Text = ViewState["txtUserId"].ToString();
        //txtPassword.Text = ViewState["txtPassword"].ToString();
        //txtEmail.Text = ViewState["txtEmail"].ToString();
        //txtLineId.Text = ViewState["txtLineId"].ToString();
        //chkDisabled.Checked = (bool)ViewState["chkDisabled"];
        //txtDisabledDate.Text = ViewState["txtDisabledDate"].ToString();
        //txtErpUserId.Text = ViewState["txtErpUserId"].ToString();
        //txtName.Text = ViewState["txtName"].ToString();
        txtUserId.Text = "";
        txtPassword.Text = "";
        txtReenterPassword.Text = "";
        txtEmail.Text = "";
        txtLineId.Text = "";
        txtDisabledDate.Text = "";
        txtErpUserId.Text = "";
        txtName.Text = "";
        txtUserId.ReadOnly = true;
        txtUserId.CssClass = "read-only";
        txtPassword.ReadOnly = true;
        txtPassword.CssClass = "read-only";
        txtReenterPassword.ReadOnly = true;
        txtReenterPassword.CssClass = "read-only";
        txtEmail.ReadOnly = true;
        txtEmail.CssClass = "read-only";
        txtLineId.ReadOnly = true;
        txtLineId.CssClass = "read-only";
        chkSuperUser.Enabled = false;
        chkDisabled.Enabled = false;
        btnErpId_Search.Enabled = false;
        txtName.ReadOnly = true;
        txtName.CssClass = "read-only";

        ViewState["Mode"] = currentFunctionMode.NONE;
        //enable grdResult after click
        grdResult.Enabled = true;
        Load_toplink(getPostBackControlName());
    }
    protected void toplink_delete_Click(object sender, EventArgs e)
    {
        try
        {
            //檢查USER是否存在
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ID], [NO_DELETE] FROM [HR360_BI01_A] WHERE [ID] = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", txtUserId.Text.ToUpper().Trim());
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows) //要刪除的使用者代號存在於DB中
                {
                    while (reader.Read())
                    {
                        if (reader.GetBoolean(1) == true) //不得刪除[NO_DELETE]為1的資料
                        {
                            lblErrorMessage.Text = "此帳號不得刪除";
                        }
                        else if (reader.GetString(0) == (string)Session["user_id"]) //不得刪除現在使用者的資料
                        {
                            lblErrorMessage.Text = "不得刪除現在使用中的帳號資料";
                        }
                        else
                        {
                            if (txtUserId.Text.Trim() == "")
                            {
                                lblErrorMessage.Text = "請指定要刪除的使用者代號";
                            }
                            else
                            {
                                if (!reader.IsClosed)
                                {
                                    reader.Close();
                                }
                                SqlCommand cmd1 = new SqlCommand("DELETE FROM [HR360_BI01_A] WHERE [ID] = @ID", conn);
                                cmd1.Parameters.AddWithValue("@ID", txtUserId.Text.ToUpper().Trim());
                                cmd1.ExecuteNonQuery();
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
                                txtUserId.Text = "";
                                txtPassword.Text = "";
                                txtReenterPassword.Text = "";
                                txtEmail.Text = "";
                                txtLineId.Text = "";
                                chkSuperUser.Enabled = false;
                                chkDisabled.Checked = false;
                                txtDisabledDate.Text = "";
                                txtErpUserId.Text = "";
                                txtName.Text = "";
                                reader = cmd.ExecuteReader();
                                Load_toplink(getPostBackControlName());
                            }
                        }
                    }
                }
                else
                {
                    lblErrorMessage.Text = "此使用者代號不存在";
                    txtUserId.Text = "";
                    txtPassword.Text = "";
                    txtReenterPassword.Text = "";
                }
                reader.Close();
            }
            txtUserId.ReadOnly = true;
            txtUserId.CssClass = "read-only";
            txtPassword.ReadOnly = true;
            txtPassword.CssClass = "read-only";
            txtReenterPassword.ReadOnly = true;
            txtReenterPassword.CssClass = "read-only";
            txtEmail.ReadOnly = true;
            txtEmail.CssClass = "read-only";
            txtLineId.ReadOnly = true;
            txtLineId.CssClass = "read-only";
            chkSuperUser.Enabled = false;
            chkDisabled.Enabled = false;
            btnErpId_Search.Enabled = false;
            txtName.ReadOnly = true;
            txtName.CssClass = "read-only";
        }
        catch (SqlException ex)
        {
            switch (ex.Number)
            {
                case 547:
                    lblErrorMessage.Text = "此項目已連結至其他資料，不可刪除";
                    break;
                default:
                    lblErrorMessage.Text = "資料刪除錯誤";
                    break;
            }
        }
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
        txtUserId.ReadOnly = false;
        txtUserId.Text = "";
        txtUserId.CssClass = "required-field";
        txtUserId.Focus();
        txtPassword.Text = "";
        txtPassword.ReadOnly = false;
        txtPassword.CssClass = "required-field";
        txtReenterPassword.Text = "";
        txtReenterPassword.ReadOnly = false;
        txtReenterPassword.CssClass = "required-field";
        txtEmail.Text = ViewState["txtEmail"].ToString();
        txtEmail.ReadOnly = true;
        txtEmail.CssClass = "read-only";
        txtLineId.Text = ViewState["txtLineId"].ToString();
        txtLineId.ReadOnly = true;
        txtLineId.CssClass = "read-only";
        chkSuperUser.Checked = false;
        chkSuperUser.Enabled = false;
        chkDisabled.Checked = false;
        chkDisabled.Enabled = false;
        txtDisabledDate.Text = "";
        txtErpUserId.Text = ViewState["txtErpUserId"].ToString();
        btnErpId_Search.Enabled = false;
        txtName.Text = ViewState["txtName"].ToString();
        txtName.ReadOnly = true;
        txtName.CssClass = "read-only";
        lblErrorMessage.Text = "";

        //disable grdResult while in edit mode
        grdResult.Enabled = false;

        Load_toplink(getPostBackControlName());
    }
    //
    //page-specific functions
    private bool ValidateEmail(string email)
    {
        bool validate = false;
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        if (match.Success)
        {
            validate = true;
        }
        else
        {
            validate = false;
        }
        return validate;
    }
    protected void chkDisabled_CheckedChanged(object sender, EventArgs e)
    {
        if (chkDisabled.Checked == true)
        {
            txtDisabledDate.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }
        else
        {
            txtDisabledDate.Text = "";
        }
    }
    protected void grdResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (grdResult.Rows.Count != 0)
        {
            e.Row.Cells[3].Width = new Unit("200px");
        }
    }
    protected void btnErpId_Search_Click(object sender, EventArgs e)
    {
        grdErp_Id.SelectedIndex = -1;
        grdErp_Id.DataSource = null;
        grdErp_Id.DataBind();
        using (SqlConnection conn = new SqlConnection(nzconnectionString))
        {
            SqlCommand cmdSearch = new SqlCommand("SELECT '' 員工代號, '清除選項' 員工名稱 UNION SELECT [MV001], [MV002] FROM [CMSMV] WHERE [MV022] = N''", conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmdSearch);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdErp_Id.DataSource = ds;
            grdErp_Id.DataBind();
        }
    }
    protected void grdErp_Id_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtErpUserId.Text = Server.HtmlDecode(grdErp_Id.SelectedRow.Cells[0].Text);
        
        if (Server.HtmlDecode(grdErp_Id.SelectedRow.Cells[1].Text) == "清除選項")
        {
            txtName.Text = Server.HtmlDecode(grdErp_Id.SelectedRow.Cells[1].Text).Replace("清除選項", "");
        }
        else
        {
            txtName.Text = Server.HtmlDecode(grdErp_Id.SelectedRow.Cells[1].Text);
        }

        if (txtName.Text.Trim() == "")
        {
            txtName.ReadOnly = false;
            txtName.CssClass = "required-field";
        }
        else
        {
            txtName.ReadOnly = true;
            txtName.CssClass = "read-only";
        }
    }

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
        AddRowSelectToGridView(grdErp_Id);

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
}