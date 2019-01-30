using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.Net;

namespace NIZING_BACKEND_Data_Config
{
    public partial class frmHR360_Main : Form
    {
        string NZConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
        string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
        public string UserName { get; set; }
        private Boolean searchFormLoaded = false;
        private enum FunctionMode { ADD, EDIT, DELETE, SEARCH, HASRECORD, NORECORD };
        TabPage currentTabPage;
        private FunctionMode accountTabMode = FunctionMode.NORECORD;
        private FunctionMode tabModeTempStorage;

        #region 公司公告 Universal Variable
        private FunctionMode companyAccouncementTabMode = FunctionMode.NORECORD;
        #endregion

        public frmHR360_Main()
        {
            InitializeComponent();
            accountTabMode = FunctionMode.NORECORD;
            currentTabPage = tbcAccountManagement.SelectedTab;
            LoadControlStatus(currentTabPage);
            txtAccountManagementMemo.Text = String.Empty;

            #region 公司公告 Init
            companyAccouncementTabMode = FunctionMode.NORECORD;
            txtCompanyAnnouncementMemo.Text = String.Empty;
            #endregion
        }

        #region Frame Method and Button Behavior
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var frm = new frmLogin();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
            this.Hide();
        }

        private List<string> CheckConfirmError(FunctionMode mode)
        {
            List<string> errorList = new List<string>();
            if (tbcAccountManagement.SelectedTab == tbpAccountManagement)
            {
                if (mode == FunctionMode.ADD)
                {
                    if (String.IsNullOrWhiteSpace(txtAccountId.Text))
                    {
                        errorList.Add("未輸入帳號");
                    }
                    if (String.IsNullOrWhiteSpace(txtAccountPassword.Text))
                    {
                        errorList.Add("未輸入密碼");
                    }
                    if (String.IsNullOrWhiteSpace(txtAccountConfirmPassword.Text))
                    {
                        errorList.Add("請確認密碼");
                    }
                    if (txtAccountPassword.Text != txtAccountConfirmPassword.Text)
                    {
                        errorList.Add("密碼與確認密碼不符");
                    }
                }
                else if (mode == FunctionMode.EDIT)
                {
                    if (!String.IsNullOrWhiteSpace(txtAccountPassword.Text))
                    {
                        if (txtAccountPassword.Text != txtAccountConfirmPassword.Text)
                        {
                            errorList.Add("密碼與確認密碼不符");
                        }
                    }
                }
            }
            else if (tbcAccountManagement.SelectedTab == tbpCompanyAnnouncement)
            {
                if (mode == FunctionMode.ADD)
                {
                    if (!String.IsNullOrWhiteSpace(txtCompanyAnnouncementBody.Text.Trim()))
                    {
                        errorList.Add("內容不可為空白");
                    }
                }
                else if (mode == FunctionMode.EDIT)
                {
                    if (!String.IsNullOrWhiteSpace(txtCompanyAnnouncementBody.Text.Trim()))
                    {
                        errorList.Add("內容不可為空白");
                    }
                }
                else if (mode == FunctionMode.DELETE)
                {

                }
            }
            return errorList;
        }

        private void LoadControlStatus(TabPage tab)
        {
            if (tab == tbpAccountManagement)
            {
                if (accountTabMode == FunctionMode.ADD)
                {
                    btnAccountAdd.Enabled = false;
                    btnAccountEdit.Enabled = false;
                    btnAccountDelete.Enabled = false;
                    btnAccountSearch.Enabled = false;
                    btnAccountConfirm.Enabled = true;
                    btnAccountCancel.Enabled = true;
                    txtAccountId.Enabled = true;
                    txtAccountId.Text = String.Empty;
                    ckxAccountSuperUser.Enabled = true;
                    ckxAccountSuperUser.Checked = false;
                    txtAccountPassword.Enabled = true;
                    txtAccountPassword.Text = String.Empty;
                    txtAccountConfirmPassword.Enabled = true;
                    txtAccountConfirmPassword.Text = String.Empty;
                    txtAccountERPID.Enabled = false;
                    if (string.IsNullOrWhiteSpace(txtAccountERPID.Text))
                    {                        
                        txtAccountName.Enabled = true;
                        txtAccountName.Text = string.Empty;
                    }
                    else
                    {
                        txtAccountName.Enabled = false;
                    }
                    btnAccountSearchERPID.Enabled = true;
                    btnAccountClearERPID.Enabled = true;
                    txtAccountEmail.Enabled = true;
                    txtAccountEmail.Text = string.Empty;
                    txtAccountLineId.Enabled = true;
                    txtAccountLineId.Text = string.Empty;
                    txtAccountDisabledDate.Enabled = false;
                    txtAccountDisabledDate.Text = string.Empty;
                    ckxAccountDisable.Enabled = true;
                    ckxAccountDisable.Checked = false;
                    btnAvatarImageFilePathSearch.Enabled = true;
                    gvAccountSearch_Result.Enabled = false;
                    btnLogout.Enabled = false;
                }
                else if (accountTabMode == FunctionMode.EDIT)
                {
                    btnAccountAdd.Enabled = false;
                    btnAccountEdit.Enabled = false;
                    btnAccountDelete.Enabled = false;
                    btnAccountSearch.Enabled = false;
                    btnAccountConfirm.Enabled = true;
                    btnAccountCancel.Enabled = true;
                    txtAccountId.Enabled = false;
                    ckxAccountSuperUser.Enabled = true;
                    txtAccountPassword.Enabled = true;
                    txtAccountPassword.Text = String.Empty;
                    txtAccountConfirmPassword.Enabled = true;
                    txtAccountConfirmPassword.Text = String.Empty;
                    txtAccountERPID.Enabled = false;
                    btnAccountSearchERPID.Enabled = true;
                    btnAccountClearERPID.Enabled = true;
                    if (string.IsNullOrWhiteSpace(txtAccountERPID.Text))
                    {
                        txtAccountName.Enabled = true;
                    }
                    else
                    {
                        txtAccountName.Enabled = false;
                    }                    
                    txtAccountEmail.Enabled = true;
                    txtAccountLineId.Enabled = true;
                    txtAccountDisabledDate.Enabled = false;
                    ckxAccountDisable.Enabled = true;
                    btnAvatarImageFilePathSearch.Enabled = true;
                    gvAccountSearch_Result.Enabled = false;
                    btnLogout.Enabled = false;
                }
                else if (accountTabMode == FunctionMode.DELETE)
                {

                }
                else if (accountTabMode == FunctionMode.SEARCH)
                {
                    btnAccountAdd.Enabled = false;
                    btnAccountEdit.Enabled = false;
                    btnAccountDelete.Enabled = false;
                    btnAccountSearch.Enabled = false;
                    btnAccountConfirm.Enabled = false;
                    btnAccountCancel.Enabled = false;
                    txtAccountId.Enabled = false;
                    ckxAccountSuperUser.Enabled = false;
                    txtAccountPassword.Enabled = false;
                    txtAccountConfirmPassword.Enabled = false;
                    txtAccountERPID.Enabled = false;
                    btnAccountSearchERPID.Enabled = false;
                    btnAccountClearERPID.Enabled = false;
                    txtAccountName.Enabled = false;
                    txtAccountEmail.Enabled = false;
                    txtAccountLineId.Enabled = false;
                    txtAccountDisabledDate.Enabled = false;
                    ckxAccountDisable.Enabled = false;
                    btnAvatarImageFilePathSearch.Enabled = false;
                    gvAccountSearch_Result.Enabled = false;
                    btnLogout.Enabled = false;
                }
                else if (accountTabMode == FunctionMode.HASRECORD)
                {
                    btnAccountAdd.Enabled = true;
                    btnAccountEdit.Enabled = true;
                    btnAccountDelete.Enabled = true;
                    btnAccountSearch.Enabled = true;
                    btnAccountConfirm.Enabled = false;
                    btnAccountCancel.Enabled = false;
                    txtAccountId.Enabled = false;
                    ckxAccountSuperUser.Enabled = false;
                    txtAccountPassword.Enabled = false;
                    txtAccountPassword.Text = String.Empty;
                    txtAccountConfirmPassword.Enabled = false;
                    txtAccountConfirmPassword.Text = String.Empty;
                    txtAccountERPID.Enabled = false;
                    btnAccountSearchERPID.Enabled = false;
                    btnAccountClearERPID.Enabled = false;
                    txtAccountName.Enabled = false;
                    txtAccountEmail.Enabled = false;
                    txtAccountLineId.Enabled = false;
                    txtAccountDisabledDate.Enabled = false;
                    ckxAccountDisable.Enabled = false;
                    btnAvatarImageFilePathSearch.Enabled = false;
                    gvAccountSearch_Result.Enabled = true;
                    btnLogout.Enabled = true;
                }
                else if (accountTabMode == FunctionMode.NORECORD)
                {
                    btnAccountAdd.Enabled = true;
                    btnAccountEdit.Enabled = false;
                    btnAccountDelete.Enabled = false;
                    btnAccountSearch.Enabled = true;
                    btnAccountConfirm.Enabled = false;
                    btnAccountCancel.Enabled = false;
                    txtAccountId.Enabled = false;
                    txtAccountId.Text = string.Empty;
                    ckxAccountSuperUser.Enabled = false;
                    ckxAccountSuperUser.Checked = false;
                    txtAccountPassword.Enabled = false;
                    txtAccountPassword.Text = String.Empty;
                    txtAccountConfirmPassword.Enabled = false;
                    txtAccountConfirmPassword.Text = String.Empty;
                    txtAccountERPID.Enabled = false;
                    txtAccountERPID.Text = string.Empty;
                    btnAccountSearchERPID.Enabled = false;
                    btnAccountClearERPID.Enabled = false;
                    txtAccountName.Enabled = false;
                    txtAccountName.Text = string.Empty;
                    txtAccountEmail.Enabled = false;
                    txtAccountEmail.Text = string.Empty;
                    txtAccountLineId.Enabled = false;
                    txtAccountLineId.Text = string.Empty;
                    txtAccountDisabledDate.Enabled = false;
                    txtAccountDisabledDate.Text = string.Empty;
                    ckxAccountDisable.Enabled = false;
                    ckxAccountDisable.Checked = false;
                    btnAvatarImageFilePathSearch.Enabled = false;
                    gvAccountSearch_Result.Enabled = false;
                    gvAccountSearch_Result.DataSource = null;
                    btnLogout.Enabled = true;
                }
            }
            else if (tbcAccountManagement.SelectedTab == tbpCompanyAnnouncement)
            {
                //control display for each function mode
                if (companyAccouncementTabMode == FunctionMode.ADD)
                {
                    btnCompanyAnnouncementAdd.Enabled = false;
                    btnCompanyAnnouncementEdit.Enabled = false;
                    btnCompanyAnnouncementDelete.Enabled = false;
                    btnCompanyAnnouncementSearch.Enabled = false;
                    btnCompanyAnnoucementConfirm.Enabled = true;
                    btnCompanyAnnouncementCancel.Enabled = true;
                    txtCompanyAnnouncementBody.Text = String.Empty;
                    txtCompanyAnnouncementBody.Enabled = true;
                    gvCompanyAnnouncementSearch_Result.Enabled = false;
                }
                else if (companyAccouncementTabMode == FunctionMode.EDIT)
                {
                    btnCompanyAnnouncementAdd.Enabled = false;
                    btnCompanyAnnouncementEdit.Enabled = false;
                    btnCompanyAnnouncementDelete.Enabled = false;
                    btnCompanyAnnouncementSearch.Enabled = false;
                    btnCompanyAnnoucementConfirm.Enabled = true;
                    btnCompanyAnnouncementCancel.Enabled = true;
                    txtCompanyAnnouncementBody.Enabled = true;
                    gvCompanyAnnouncementSearch_Result.Enabled = false;
                }
                else if (companyAccouncementTabMode == FunctionMode.DELETE)
                {

                }
                else if (companyAccouncementTabMode == FunctionMode.SEARCH)
                {
                    btnCompanyAnnouncementAdd.Enabled = false;
                    btnCompanyAnnouncementEdit.Enabled = false;
                    btnCompanyAnnouncementDelete.Enabled = false;
                    btnCompanyAnnouncementSearch.Enabled = false;
                    btnCompanyAnnoucementConfirm.Enabled = false;
                    btnCompanyAnnouncementCancel.Enabled = false;
                    txtCompanyAnnouncementBody.Enabled = false;
                    gvCompanyAnnouncementSearch_Result.Enabled = false;
                }
                else if (companyAccouncementTabMode == FunctionMode.HASRECORD)
                {
                    btnCompanyAnnouncementAdd.Enabled = true;
                    btnCompanyAnnouncementEdit.Enabled = true;
                    btnCompanyAnnouncementDelete.Enabled = true;
                    btnCompanyAnnouncementSearch.Enabled = true;
                    btnCompanyAnnoucementConfirm.Enabled = false;
                    btnCompanyAnnouncementCancel.Enabled = false;
                    txtCompanyAnnouncementBody.Enabled = false;
                    gvCompanyAnnouncementSearch_Result.Enabled = true;
                }
                else if (companyAccouncementTabMode == FunctionMode.NORECORD)
                {
                    btnCompanyAnnouncementAdd.Enabled = true;
                    btnCompanyAnnouncementEdit.Enabled = false;
                    btnCompanyAnnouncementDelete.Enabled = true;
                    btnCompanyAnnouncementSearch.Enabled = true;
                    btnCompanyAnnoucementConfirm.Enabled = false;
                    btnCompanyAnnouncementCancel.Enabled = false;
                    txtCompanyAnnouncementBody.Enabled = false;
                    gvCompanyAnnouncementSearch_Result.Enabled = false;
                }
            }
        }

        private bool isGridViewEmpty(DataGridView gv)
        {
            bool isEmpty = true;
            if (gv.Rows.Count > 0)
            {
                isEmpty = false;
            }
            else
            {
                isEmpty = true;
            }
            return isEmpty;
        }

        private void tbcManagement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (accountTabMode == FunctionMode.ADD || accountTabMode == FunctionMode.EDIT || accountTabMode == FunctionMode.SEARCH
                ||companyAccouncementTabMode == FunctionMode.ADD || companyAccouncementTabMode==FunctionMode.EDIT || companyAccouncementTabMode==FunctionMode.SEARCH
                )
            {
                tbcAccountManagement.SelectedTab = currentTabPage;
            }
            else
            {
                currentTabPage = tbcAccountManagement.SelectedTab;
                LoadControlStatus(currentTabPage);
            }
        }

        private void displayGridviewSearch_ResultInControls(DataGridView gv)
        {
            if (gv.Name == "gvAccountSearch_Result")
            {
                //txtAccountId.Text = gvAccountSearch_Result.SelectedRows[0].Cells["LOGIN_ID"].Value.ToString();
                //for (int i = 1; i < gvAccountSearch_Result.Columns.Count; i++)
                //{
                //    if (gvAccountSearch_Result.SelectedRows[0].Cells[i].Value.ToString() == "0")
                //    {
                //        clbAdminRights.SetItemCheckState(i - 1, CheckState.Unchecked);
                //    }
                //    else
                //    {
                //        clbAdminRights.SetItemCheckState(i - 1, CheckState.Checked);
                //    }
                //}
            }
            else if (gv.Name == "gvCompanyAnnouncementSearch_Result")
            {

            }
        }
        #endregion        

        #region Account Method and Events

        private void btnAccountAdd_Click(object sender, EventArgs e)
        {
            accountTabMode = FunctionMode.ADD;
            LoadControlStatus(currentTabPage);
        }

        private void btnAccountEdit_Click(object sender, EventArgs e)
        {
            accountTabMode = FunctionMode.EDIT;
            LoadControlStatus(currentTabPage);
        }

        private void btnAccountDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("確定要刪除" + txtAccountId.Text.Trim() + "的資料嗎?", "刪除確認", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();   
                    string query = "SELECT [ID], [NO_DELETE] FROM [HR360_BI01_A] WHERE [ID] = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", txtAccountId.Text.ToUpper().Trim());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                if (dt.Rows[0]["NO_DELETE"].ToString() == "1")
                {
                    MessageBox.Show("不可刪除此帳號", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM [HR360_BI01_A] WHERE [ID] = @ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", txtAccountId.Text.ToUpper().Trim());
                        cmd.ExecuteNonQuery();
                    }
                    gvAccountSearch_Result.DataSource = null;
                    txtAccountManagementMemo.Text += DateTime.Now.ToString() + ":" + txtAccountId.Text.Trim() +"資料已刪除" + Environment.NewLine;

                    searchFormLoaded = false;
                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM [HR360_BI01_A] WHERE [ID] = @ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", txtAccountId.Text.ToUpper().Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void btnAccountSearch_Click(object sender, EventArgs e)
        {
            accountTabMode = FunctionMode.SEARCH;
            LoadControlStatus(currentTabPage);

            var frm = new frmHR360_AccountSearch();
            frm.Location = new Point(this.Location.X + (this.Width / 2), this.Location.Y + (this.Height / 4));
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { frm.Hide(); };
            frm.loadButtonEvent += new searchForm_Close(accountSearchForm_loadButton);
            frm.loadGridviewEvent += new searchForm_Search(accountSearchForm_loadGridview);
            frm.Show();
        }

        private void btnAccountSearchERPID_Click(object sender, EventArgs e)
        {
            tabModeTempStorage = accountTabMode;
            accountTabMode = FunctionMode.SEARCH;
            LoadControlStatus(currentTabPage);

            var frm = new frmHR360_AccountSearchERPID();
            frm.Location = new Point(this.Location.X + (this.Width / 2), this.Location.Y + (this.Height / 4));
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { frm.Hide(); };
            frm.loadButtonEvent += new searchForm_Close(accountSearchFormERPID_loadButton);
            frm.loadSelectionEvent += new searchForm_Select(accountSearchERPIDForm_loadSelection);
            frm.Show();
        }

        private void btnAccountClearERPID_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAccountERPID.Text))
            {
                txtAccountERPID.Text = string.Empty;
                txtAccountName.Text = string.Empty;
            }
            LoadControlStatus(currentTabPage);
        }

        private void ckxAccountDisable_CheckedChanged(object sender, EventArgs e)
        {
            if (ckxAccountDisable.Checked == true)
            {
                txtAccountDisabledDate.Text = DateTime.Today.Year.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day;
            }
            else
            {
                txtAccountDisabledDate.Clear();
            }
        }

        private void btnAvatarImageFilePathSearch_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "D:\\Nizing Website CC\\Nizing\\hr360\\image\\employee_profile";
                ofd.RestoreDirectory = true;
                ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtAvatarImageFilePath.Text = ofd.FileName;
                }
            }            
        }

        private void btnAccountConfirm_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtAvatarImageFilePath.Text))
            {
                //AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
                //WindowsIdentity identity = new WindowsIdentity("nizing\\mis", "@WSX3edc&UJM8ik,@WSX");
                //WindowsImpersonationContext context = identity.Impersonate();
                ////using(new Impersonator)
                //System.IO.File.Copy(txtAvatarImageFilePath.Text, "\\192.168.10.222\\Web\\Nizing\\hr360\\image\\avatar.jpg", true);
                //context.Undo();
                //txtAccountManagementMemo.Text = "file saved";
                //WebClient client = new WebClient();
                //client.Credentials = CredentialCache.DefaultNetworkCredentials;
                //client.UploadFile("file:////192.168.10.222//Web//Nizing//hr360//image//avatar.jpg", "POST", txtAvatarImageFilePath.Text);
                //client.Dispose();


            }
        }

        private void btnAccountCancel_Click(object sender, EventArgs e)
        {
            if (isGridViewEmpty(gvAccountSearch_Result))
            {
                accountTabMode = FunctionMode.NORECORD;
                LoadControlStatus(currentTabPage);
            }
            else
            {
                accountTabMode = FunctionMode.HASRECORD;
                LoadControlStatus(currentTabPage);
            }
        }

        #endregion


        #region method for search form
        void accountSearchForm_loadButton()
        {
            if (isGridViewEmpty(gvAccountSearch_Result))
            {
                accountTabMode = FunctionMode.NORECORD;
                LoadControlStatus(currentTabPage);
            }
            else
            {
                accountTabMode = FunctionMode.HASRECORD;
                LoadControlStatus(currentTabPage);
            }
        }
        void accountSearchForm_loadGridview(DataTable dt)
        {
            searchFormLoaded = false;
            gvAccountSearch_Result.DataSource = dt;
            searchFormLoaded = true;
            if (!isGridViewEmpty(gvAccountSearch_Result))
            {
                gvAccountSearch_Result.Rows[0].Selected = true;
                displayGridviewSearch_ResultInControls(gvAccountSearch_Result);
            }
            else
            {
                txtAccountId.Text = "";
                txtAccountPassword.Text = "";
                txtAccountConfirmPassword.Text = "";
            }
            foreach (DataGridViewColumn col in gvAccountSearch_Result.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }
        void accountSearchFormERPID_loadButton()
        {
            accountTabMode = tabModeTempStorage;
            if (accountTabMode == FunctionMode.ADD)
            {
                LoadControlStatus(currentTabPage);
            }
            else if (accountTabMode == FunctionMode.EDIT)
            {
                LoadControlStatus(currentTabPage);
            }            
        }
        void accountSearchERPIDForm_loadSelection(DataRow[] dr)
        {
            accountSearchFormERPID_loadButton();
            txtAccountERPID.Text = dr[0][0].ToString().Trim();
            txtAccountName.Text = dr[0][1].ToString().Trim();
            txtAccountName.Enabled = false;
        }
        #endregion




    }
}
