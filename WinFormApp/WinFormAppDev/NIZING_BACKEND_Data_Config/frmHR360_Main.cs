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
using System.Security.Cryptography;
using System.IO;
using System.Web;
using System.Collections.Specialized;

namespace NIZING_BACKEND_Data_Config
{
    public partial class frmHR360_Main : Form
    {
        string NZConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
        string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
        public string UserName { get; set; }
        public DataTable dtAuthorizedFunctionTable { get; set; }
        public string CurrentForm { get; set; }
        private readonly frmLogin _frmLogin;
        private Boolean searchFormLoaded = false;
        private enum FunctionMode { ADD, EDIT, DELETE, SEARCH, HASRECORD, NORECORD };
        TabPage currentTabPage;
        private FunctionMode accountTabMode = FunctionMode.NORECORD;
        private FunctionMode tabModeTempStorage;

        #region 帳號管理 Universal Variable
        string avatarFilePath = @"\\192.168.10.222\Web\Nizing\hr360\image\employee_profile\";
        #endregion

        #region 公司公告 Universal Variable
        private FunctionMode companyAccouncementTabMode = FunctionMode.NORECORD;
        #endregion

        public frmHR360_Main(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
            accountTabMode = FunctionMode.NORECORD;
            currentTabPage = tbcManagement.SelectedTab;
            LoadControlStatus(currentTabPage);
            txtAccountManagementMemo.Text = String.Empty;

            #region 公司公告 Init
            companyAccouncementTabMode = FunctionMode.NORECORD;
            txtCompanyAnnouncementMemo.Text = String.Empty;
            flpCompanyAnnouncementID.Margin = new Padding(0, (flpCompanyAnnouncementID.Height - lblCompanyAnnouncementID.Height - 10) / 2, 0, 0);
            #endregion
        }

        public frmHR360_Main()
        {
            InitializeComponent();
            accountTabMode = FunctionMode.NORECORD;
            currentTabPage = tbcManagement.SelectedTab;
            LoadControlStatus(currentTabPage);
            txtAccountManagementMemo.Text = String.Empty;

            #region 公司公告 Init
            companyAccouncementTabMode = FunctionMode.NORECORD;
            txtCompanyAnnouncementMemo.Text = String.Empty;
            flpCompanyAnnouncementID.Margin = new Padding(0, (flpCompanyAnnouncementID.Height - lblCompanyAnnouncementID.Height - 10) / 2, 0, 0);
            #endregion
        }

        private void frmHR360_Main_Shown(object sender, EventArgs e)
        {
            _frmLogin.LoadCbxFunctionList(this);
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
        private void cbxFunctionList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _frmLogin.ChangeForm(cbxFunctionList.SelectedValue.ToString());
        }

        private List<string> CheckConfirmError(FunctionMode mode)
        {
            List<string> errorList = new List<string>();
            if (tbcManagement.SelectedTab == tbpAccountManagement)
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
                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                    {
                        conn.Open();
                        string query = "SELECT [ID]"
                                    +" FROM HR360_BI01_A"
                                    +" WHERE [ID]=@ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", txtAccountId.Text.Trim());
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            errorList.Add("此帳號已被使用，請選擇其他帳號");
                        }
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
            else if (tbcManagement.SelectedTab == tbpCompanyAnnouncement)
            {
                if (mode == FunctionMode.ADD)
                {
                    if (String.IsNullOrWhiteSpace(txtCompanyAnnouncementBody.Text.Trim()))
                    {
                        errorList.Add("內容不可為空白");
                    }
                }
                else if (mode == FunctionMode.EDIT)
                {
                    if (String.IsNullOrWhiteSpace(txtCompanyAnnouncementBody.Text.Trim()))
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
                    btnAccountAvatarImageFilePathSearch.Enabled = true;
                    btnAccountClearAvatarPath.Enabled = true;                    
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
                    btnAccountAvatarImageFilePathSearch.Enabled = true;
                    btnAccountClearAvatarPath.Enabled = true;
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
                    btnAccountAvatarImageFilePathSearch.Enabled = false; //false
                    btnAccountClearAvatarPath.Enabled = false;
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
                    btnAccountAvatarImageFilePathSearch.Enabled = false; //false
                    btnAccountClearAvatarPath.Enabled = false;
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
                    btnAccountAvatarImageFilePathSearch.Enabled = false; //false
                    btnAccountClearAvatarPath.Enabled = false;
                    gvAccountSearch_Result.Enabled = false;
                    gvAccountSearch_Result.DataSource = null;
                    btnLogout.Enabled = true;
                }
            }
            else if (tbcManagement.SelectedTab == tbpCompanyAnnouncement)
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
                    ckxCompanyAnnouncementVisible.Enabled = true;
                    ckxCompanyAnnouncementVisible.Checked = true;
                    ckxCompanyAnnouncementOnTop.Enabled = true;
                    ckxCompanyAnnouncementOnTop.Checked = false;
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
                    ckxCompanyAnnouncementVisible.Enabled = true;
                    ckxCompanyAnnouncementOnTop.Enabled = true;
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
                    ckxCompanyAnnouncementVisible.Enabled = false;
                    ckxCompanyAnnouncementOnTop.Enabled = false;
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
                    ckxCompanyAnnouncementVisible.Enabled = false;
                    ckxCompanyAnnouncementOnTop.Enabled = false;
                    txtCompanyAnnouncementBody.Enabled = false;
                    gvCompanyAnnouncementSearch_Result.Enabled = true;
                }
                else if (companyAccouncementTabMode == FunctionMode.NORECORD)
                {
                    btnCompanyAnnouncementAdd.Enabled = true;
                    btnCompanyAnnouncementEdit.Enabled = false;
                    btnCompanyAnnouncementDelete.Enabled = false;
                    btnCompanyAnnouncementSearch.Enabled = true;
                    btnCompanyAnnoucementConfirm.Enabled = false;
                    btnCompanyAnnouncementCancel.Enabled = false;
                    ckxCompanyAnnouncementVisible.Enabled = false;
                    ckxCompanyAnnouncementOnTop.Enabled = false;
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
                tbcManagement.SelectedTab = currentTabPage;
            }
            else
            {
                currentTabPage = tbcManagement.SelectedTab;
                LoadControlStatus(currentTabPage);
            }
        }

        private void displayGridviewSearch_ResultInControls(DataGridView gv)
        {
            if (gv.Name == "gvAccountSearch_Result")
            {
                txtAccountId.Text = gvAccountSearch_Result.SelectedRows[0].Cells["ID"].Value.ToString();
                if ((bool)gvAccountSearch_Result.SelectedRows[0].Cells["SUPER_USER"].Value == true)
                {
                    ckxAccountSuperUser.Checked = true;
                }
                else
                {
                    ckxAccountSuperUser.Checked = false;
                }
                txtAccountERPID.Text = gvAccountSearch_Result.SelectedRows[0].Cells["ERP_ID"].Value.ToString();
                txtAccountName.Text = gvAccountSearch_Result.SelectedRows[0].Cells["NAME"].Value.ToString();
                txtAccountEmail.Text = gvAccountSearch_Result.SelectedRows[0].Cells["EMAIL"].Value.ToString();
                txtAccountLineId.Text = gvAccountSearch_Result.SelectedRows[0].Cells["LINE_ID"].Value.ToString();
                if ((bool)gvAccountSearch_Result.SelectedRows[0].Cells["DISABLED"].Value == true)
                {
                    ckxAccountDisable.Checked = true;
                }
                else
                {
                    ckxAccountDisable.Checked = false;
                }
                txtAccountDisabledDate.Text = gvAccountSearch_Result.SelectedRows[0].Cells["DISABLEDDATE"].Value.ToString();
                //load image for selection change
                if (File.Exists(avatarFilePath + txtAccountId.Text.Trim() + ".jpg"))
                {
                    LoadAvatarFile(avatarFilePath + txtAccountId.Text.Trim() + @".jpg");
                }
                else
                {
                    ClearPicAccountAvatar();
                }

            }
            else if (gv.Name == "gvCompanyAnnouncementSearch_Result")
            {
                lblCompanyAnnouncementID.Text = gv.SelectedRows[0].Cells["ID"].Value.ToString();
                ckxCompanyAnnouncementVisible.Checked = (bool)gv.SelectedRows[0].Cells["VISIBLE"].Value;
                ckxCompanyAnnouncementOnTop.Checked = (bool)gv.SelectedRows[0].Cells["ON_TOP"].Value;
                txtCompanyAnnouncementBody.Text = gv.SelectedRows[0].Cells["BODY"].Value.ToString();
            }

        }

        public string Encrypt(string clearText)
        {
            string EncryptionKey = "IMTHEBOSS999";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "IMTHEBOSS999";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        #endregion        

        #region Account Method and Events

        private void btnAccountAdd_Click(object sender, EventArgs e)
        {
            accountTabMode = FunctionMode.ADD;
            ClearContent();
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
                    cmd.Parameters.AddWithValue("@ID", txtAccountId.Text.Trim());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                if (dt.Rows.Count > 0)
                {
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
                            cmd.Parameters.AddWithValue("@ID", txtAccountId.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                        txtAccountManagementMemo.Text += DateTime.Now.ToString() + ":" + txtAccountId.Text.Trim() + "資料已刪除" + Environment.NewLine;
                        searchFormLoaded = false;
                        gvAccountSearch_Result.DataSource = null;
                        searchFormLoaded = true;
                        btnAccountSearch_Click(sender, e);
                    }
                }
            }
        }

        private void btnAccountSearch_Click(object sender, EventArgs e)
        {
            ClearContent();
            accountTabMode = FunctionMode.SEARCH;
            LoadControlStatus(currentTabPage);
            string condition = "";
            if (!ckxAccountShowDisabled.Checked)
            {
                condition = " AND [DISABLED]='0'";
            }
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT [ID],[ERP_ID],[NAME],[EMAIL],[LINE_ID],[DISABLED],[DISABLEDDATE],[SUPER_USER],[PASSWORD]"
                            + " FROM HR360_BI01_A"
                            + " WHERE [ID]<>'ADMIN'"
                            + condition
                            + " ORDER BY [ID]";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                searchFormLoaded = false;
                gvAccountSearch_Result.DataSource = dt;
                searchFormLoaded = true;
                
            }
            if (gvAccountSearch_Result.Rows.Count > 0)
            {
                accountTabMode = FunctionMode.HASRECORD;
            }
            else
            {
                accountTabMode = FunctionMode.NORECORD;
            }
            LoadControlStatus(currentTabPage);
            
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
                txtAccountERPID.Clear();
                txtAccountName.Clear();
            }
            LoadControlStatus(currentTabPage);
        }

        private void ckxAccountDisable_CheckedChanged(object sender, EventArgs e)
        {
            if (ckxAccountDisable.Checked == true)
            {
                txtAccountDisabledDate.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            }
            else
            {
                txtAccountDisabledDate.Clear();
            }
        }

        private void btnAccountAvatarImageFilePathSearch_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = @"C:\";
                ofd.RestoreDirectory = true;
                ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    LoadAvatarFile(ofd.FileName);                    
                }
                
            }            
        }

        private void LoadAvatarFile(string fileName)
        {
            txtAccountAvatarImageFilePath.Text = fileName;
            picAccountAvatar.LoadAsync(txtAccountAvatarImageFilePath.Text.Trim());
        }

        private void btnAccountClearAvatarPath_Click(object sender, EventArgs e)
        {
            txtAccountAvatarImageFilePath.Clear();
            ClearPicAccountAvatar();
        }

        private void btnAccountConfirm_Click(object sender, EventArgs e)
        {
            List<string> errorMsg = new List<string>();
            if (accountTabMode == FunctionMode.ADD)
            {
                //新增模式下執行確認的動作
                errorMsg = CheckConfirmError(FunctionMode.ADD);
                if (errorMsg.Count == 0)
                {
                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                    {
                        conn.Open();
                        string query = "INSERT INTO HR360_BI01_A"
                                    + " VALUES (GETDATE(),@CREATOR,GETDATE(),@MODIFIER,@ID,@ERP_ID,@NAME,@PASSWORD,@EMAIL,@LINE_ID,@NO_DELETE,@DISABLED,@DISABLEDDATE,@SUPER_USER)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@CREATOR", UserName);
                        cmd.Parameters.AddWithValue("@MODIFIER", UserName);
                        cmd.Parameters.AddWithValue("@ID", txtAccountId.Text.Trim());
                        cmd.Parameters.AddWithValue("@ERP_ID", txtAccountERPID.Text.Trim());
                        cmd.Parameters.AddWithValue("@NAME", txtAccountName.Text.Trim());
                        cmd.Parameters.AddWithValue("@PASSWORD", Encrypt(txtAccountPassword.Text.Trim()));
                        cmd.Parameters.AddWithValue("@EMAIL", txtAccountEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@LINE_ID", txtAccountLineId.Text.Trim());
                        cmd.Parameters.AddWithValue("@NO_DELETE", "0");
                        cmd.Parameters.AddWithValue("@DISABLED", Convert.ToInt32(ckxAccountDisable.Checked).ToString());
                        cmd.Parameters.AddWithValue("@DISABLEDDATE", txtAccountDisabledDate.Text.Trim());
                        cmd.Parameters.AddWithValue("@SUPER_USER", Convert.ToInt32(ckxAccountSuperUser.Checked).ToString());
                        cmd.ExecuteNonQuery();
                    }
                    
                    if (!string.IsNullOrEmpty(txtAccountAvatarImageFilePath.Text))
                    {
                        if (SaveAvatarFile())
                        {
                            txtAccountManagementMemo.Text += DateTime.Now.ToString() + ":新增使用者" + txtAccountId.Text.Trim() + "完成" + Environment.NewLine;
                            txtAccountManagementMemo.Text += "檔案名稱:" + lblAccountAvatarFileName.Text + "已存檔" + Environment.NewLine;
                        }
                        else
                        {
                            txtAccountManagementMemo.Text += DateTime.Now.ToString() + ":新增使用者" + txtAccountId.Text.Trim() + "完成" + Environment.NewLine;
                            txtAccountManagementMemo.Text += "檔案名稱:" + lblAccountAvatarFileName.Text + "未存檔" + Environment.NewLine;
                        }
                    }
                    else
                    {
                        txtAccountManagementMemo.Text += DateTime.Now.ToString() + ":新增使用者" + txtAccountId.Text.Trim() + "完成" + Environment.NewLine;
                    }
                    btnAccountSearch_Click(sender, e);
                }
                else
                {
                    txtAccountManagementMemo.Text += DateTime.Now.ToString() + ":";
                    foreach (string s in errorMsg)
                    {
                        txtAccountManagementMemo.Text += s + Environment.NewLine;
                    }
                }
            }
            else if (accountTabMode == FunctionMode.EDIT)
            {
                //編輯模式下執行確認的動作
                errorMsg = CheckConfirmError(FunctionMode.EDIT);
                if (errorMsg.Count == 0)
                {
                    string passwordChange = "";

                    if (!string.IsNullOrWhiteSpace(txtAccountPassword.Text))
                    {
                        passwordChange = " ,PASSWORD=@PASSWORD";
                    }
                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                    {
                        conn.Open();
                        string query = "UPDATE HR360_BI01_A"
                                    + " SET MODIFIEDDATE=GETDATE()"
                                    + " ,MODIFIER=@MODIFIER"
                                    + " ,SUPER_USER=@SUPER_USER"
                                    + " ,DISABLED=@DISABLED"
                                    + " ,DISABLEDDATE=@DISABLEDDATE"
                                    + " ,EMAIL=@EMAIL"
                                    + " ,LINE_ID=@LINE_ID"
                                    + passwordChange
                                    + " WHERE [ID]=@ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", txtAccountId.Text.Trim());
                        cmd.Parameters.AddWithValue("@MODIFIER", UserName);
                        cmd.Parameters.AddWithValue("@PASSWORD", Encrypt(txtAccountPassword.Text.Trim()));
                        cmd.Parameters.AddWithValue("@EMAIL", txtAccountEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@LINE_ID", txtAccountLineId.Text.Trim());
                        cmd.Parameters.AddWithValue("@DISABLED", Convert.ToInt32(ckxAccountDisable.Checked).ToString());
                        cmd.Parameters.AddWithValue("@DISABLEDDATE", txtAccountDisabledDate.Text.Trim());
                        cmd.Parameters.AddWithValue("@SUPER_USER", Convert.ToInt32(ckxAccountSuperUser.Checked).ToString());
                        cmd.ExecuteNonQuery();
                    }
                    

                    if (!string.IsNullOrEmpty(txtAccountAvatarImageFilePath.Text))
                    {
                        if (SaveAvatarFile())
                        {
                            txtAccountManagementMemo.Text += DateTime.Now.ToString() + ":編輯使用者" + txtAccountId.Text.Trim() + "完成" + Environment.NewLine;
                            txtAccountManagementMemo.Text += "檔案名稱:" + lblAccountAvatarFileName.Text + "已存檔" + Environment.NewLine;
                        }
                        else
                        {
                            txtAccountManagementMemo.Text += DateTime.Now.ToString() + ":編輯使用者" + txtAccountId.Text.Trim() + "完成" + Environment.NewLine;
                            txtAccountManagementMemo.Text += "檔案名稱:" + lblAccountAvatarFileName.Text + "未存檔" + Environment.NewLine;
                        }                        
                    }
                    else
                    {
                        txtAccountManagementMemo.Text += DateTime.Now.ToString() + ":編輯使用者" + txtAccountId.Text.Trim() + "完成" + Environment.NewLine;
                    }
                    btnAccountSearch_Click(sender, e);
                }
                else
                {
                    txtAccountManagementMemo.Text += DateTime.Now.ToString() + ":";
                    foreach (string s in errorMsg)
                    {
                        txtAccountManagementMemo.Text += s + Environment.NewLine;
                    }
                }
            }

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

        private void gvAccountSearch_Result_SelectionChanged(object sender, EventArgs e)
        {
            if (searchFormLoaded)
            {
                displayGridviewSearch_ResultInControls(gvAccountSearch_Result);
            }
        }

        private void ClearContent()
        {
            txtAccountId.Text = "";
            ckxAccountSuperUser.Checked = false;
            txtAccountPassword.Text = "";
            txtAccountConfirmPassword.Text = "";
            txtAccountERPID.Text = "";
            txtAccountName.Text = "";
            txtAccountEmail.Text = "";
            txtAccountLineId.Text = "";
            txtAccountDisabledDate.Text = "";
            ckxAccountDisable.Checked = false;
            txtAccountAvatarImageFilePath.Text = "";
            ClearPicAccountAvatar();
        }

        private bool SaveAvatarFile()
        {
            //Using webclient to upload file  (Works, but no prompt for overwrite or other controls)
            WebClient myWebClient = new WebClient();
            string originalFileName = txtAccountAvatarImageFilePath.Text.Trim();
            string destinationFileName = avatarFilePath + txtAccountId.Text.Trim();

            if (File.Exists(destinationFileName + Path.GetExtension(txtAccountAvatarImageFilePath.Text.Trim())))
            {
                var confirmFileName = MessageBox.Show(@"檔案已存在，請問要覆蓋嗎? (OK:覆蓋/Cancel:取消)", "檔案名稱重複", MessageBoxButtons.OKCancel);
                if (confirmFileName == DialogResult.OK)
                {
                    destinationFileName += Path.GetExtension(txtAccountAvatarImageFilePath.Text.Trim());
                    myWebClient.UploadFile(destinationFileName, originalFileName);
                    return true;
                }
                else
                {
                    return false;
                }
                //else if (confirmFileName == DialogResult.No)
                //{
                //    int i = 0;
                //    string temp;
                //    temp = destinationFileName;
                //    while (File.Exists(destinationFileName + Path.GetExtension(txtAccountAvatarImageFilePath.Text.Trim())))
                //    {
                //        i += 1;
                //        destinationFileName = temp + "-" + i.ToString();
                //    }
                //    destinationFileName += Path.GetExtension(txtAccountAvatarImageFilePath.Text.Trim());
                //    myWebClient.UploadFile(destinationFileName, originalFileName);
                //    txtAccountManagementMemo.Text += "檔案名稱:" + Path.GetFileName(destinationFileName) + "已存檔" + Environment.NewLine;
                //}
            }
            else
            {
                destinationFileName += Path.GetExtension(txtAccountAvatarImageFilePath.Text.Trim());
                myWebClient.UploadFile(destinationFileName, originalFileName);
                return true;
            }

        }

        private void picAccountAvatar_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {            
            if (picAccountAvatar.Image == null)
            {
                lblAccountAvatarFileName.Text = string.Empty;
            }
            else
            {
                lblAccountAvatarFileName.Text = Path.GetFileName((string)picAccountAvatar.ImageLocation);
            }
        }

        private void ClearPicAccountAvatar()
        {
            picAccountAvatar.Image = null;
            lblAccountAvatarFileName.Text = string.Empty;
        }

        #endregion


        #region method for search form
        //void accountSearchForm_loadButton()
        //{
        //    if (isGridViewEmpty(gvAccountSearch_Result))
        //    {
        //        accountTabMode = FunctionMode.NORECORD;
        //        LoadControlStatus(currentTabPage);
        //    }
        //    else
        //    {
        //        accountTabMode = FunctionMode.HASRECORD;
        //        LoadControlStatus(currentTabPage);
        //    }
        //}
        //void accountSearchForm_loadGridview(DataTable dt)
        //{
        //    searchFormLoaded = false;
        //    gvAccountSearch_Result.DataSource = dt;
        //    searchFormLoaded = true;
        //    if (!isGridViewEmpty(gvAccountSearch_Result))
        //    {
        //        gvAccountSearch_Result.Rows[0].Selected = true;
        //        displayGridviewSearch_ResultInControls(gvAccountSearch_Result);
        //    }
        //    else
        //    {
        //        txtAccountId.Text = "";
        //        txtAccountPassword.Text = "";
        //        txtAccountConfirmPassword.Text = "";
        //    }
        //    foreach (DataGridViewColumn col in gvAccountSearch_Result.Columns)
        //    {
        //        col.SortMode = DataGridViewColumnSortMode.Automatic;
        //    }
        //}
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


        #region Company Announcement Methods and Events

        private void btnCompanyAnnouncementAdd_Click(object sender, EventArgs e)
        {
            companyAccouncementTabMode = FunctionMode.ADD;
            lblCompanyAnnouncementID.Text = GetNewCompanyAnnouncementID().ToString();
            LoadControlStatus(currentTabPage);
            txtCompanyAnnouncementBody.Focus();
        }

        private void btnCompanyAnnouncementEdit_Click(object sender, EventArgs e)
        {
            companyAccouncementTabMode = FunctionMode.EDIT;
            LoadControlStatus(currentTabPage);
            txtCompanyAnnouncementBody.Focus();
        }

        private void btnCompanyAnnouncementDelete_Click(object sender, EventArgs e)
        {
            companyAccouncementTabMode = FunctionMode.DELETE;
            List<string> errorList = CheckConfirmError(companyAccouncementTabMode);

            if (errorList.Count == 0)
            {
                var confirmResult = MessageBox.Show("確定要刪除公告" + lblCompanyAnnouncementID.Text.Trim() + "的資料嗎?", "刪除確認", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    //delete selected item
                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM HR360_COMPANYANNOUNCEMENT"
                                    + " WHERE [ID]=@ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", lblCompanyAnnouncementID.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                    gvCompanyAnnouncementSearch_Result.DataSource = null;
                    txtCompanyAnnouncementMemo.Text += DateTime.Now.ToString() + ":資料已刪除" + Environment.NewLine;
                    btnCompanyAnnouncementSearch_Click(sender, e);

                }
            }
            else
            {
                txtCompanyAnnouncementMemo.Text += DateTime.Now.ToString() + ":ERROR" + Environment.NewLine;
                foreach (string s in errorList)
                {
                    txtCompanyAnnouncementMemo.Text += s + Environment.NewLine;
                }
            } 
        }

        private void btnCompanyAnnouncementSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT [ID],[BODY],[VISIBLE],[ON_TOP]"
                            + " FROM HR360_COMPANYANNOUNCEMENT"
                            + " ORDER BY [ID]";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            gvCompanyAnnouncementSearch_Result.DataSource = dt;
            if (isGridViewEmpty(gvCompanyAnnouncementSearch_Result))
            {
                companyAccouncementTabMode = FunctionMode.NORECORD;
                LoadControlStatus(currentTabPage);
            }
            else
            {
                companyAccouncementTabMode = FunctionMode.HASRECORD;
                LoadControlStatus(currentTabPage);
            }
        }

        private void btnCompanyAnnoucementConfirm_Click(object sender, EventArgs e)
        {
            List<string> errorList = CheckConfirmError(companyAccouncementTabMode);

            if (errorList.Count == 0)
            {
                if (companyAccouncementTabMode == FunctionMode.ADD)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                        {
                            conn.Open();
                            string query = "INSERT INTO HR360_COMPANYANNOUNCEMENT ([ID],CREATE_TIME,CREATOR,LAST_EDIT_TIME,LAST_EDITOR,[BODY],VISIBLE,ON_TOP)"
                                        + " VALUES(@ID,GETDATE(),@CREATOR,GETDATE(),@EDITOR,@BODY,@VISIBLE,@ONTOP)";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ID", lblCompanyAnnouncementID.Text);
                            cmd.Parameters.AddWithValue("@CREATOR", UserName);
                            cmd.Parameters.AddWithValue("@EDITOR", UserName);
                            cmd.Parameters.AddWithValue("@BODY", txtCompanyAnnouncementBody.Text.Trim());
                            cmd.Parameters.AddWithValue("@VISIBLE", ckxCompanyAnnouncementVisible.Checked);
                            cmd.Parameters.AddWithValue("@ONTOP", ckxCompanyAnnouncementOnTop.Checked);
                            cmd.ExecuteNonQuery();
                        }
                        txtCompanyAnnouncementMemo.Text += DateTime.Now.ToString() + ":資料新增完成" + Environment.NewLine;
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627)
                        {
                            lblCompanyAnnouncementID.Text = GetNewCompanyAnnouncementID().ToString();
                            btnCompanyAnnoucementConfirm_Click(sender, e);
                        }
                        else
                        {
                            txtCompanyAnnouncementMemo.Text += DateTime.Now.ToString() + ":Error 新增出現錯誤" + Environment.NewLine;
                        }
                    }
                    
                }
                else if (companyAccouncementTabMode == FunctionMode.EDIT)
                {
                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                    {
                        conn.Open();
                        string query = "UPDATE HR360_COMPANYANNOUNCEMENT"
                                    + " SET LAST_EDIT_TIME=GETDATE()"
                                    + " ,LAST_EDITOR=@EDITOR"
                                    + " ,BODY=@BODY"
                                    + " ,VISIBLE=@VISIBLE"
                                    + " ,ON_TOP=@ONTOP"
                                    + " WHERE [ID]=@ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", lblCompanyAnnouncementID.Text);
                        cmd.Parameters.AddWithValue("@EDITOR", UserName);
                        cmd.Parameters.AddWithValue("@BODY", txtCompanyAnnouncementBody.Text.Trim());
                        cmd.Parameters.AddWithValue("@VISIBLE", ckxCompanyAnnouncementVisible.Checked);
                        cmd.Parameters.AddWithValue("@ONTOP", ckxCompanyAnnouncementOnTop.Checked);
                        cmd.ExecuteNonQuery();
                    }
                    txtCompanyAnnouncementMemo.Text += DateTime.Now.ToString() + ":資料更新完成" + Environment.NewLine;
                }
                if (isGridViewEmpty(gvCompanyAnnouncementSearch_Result))
                {
                    companyAccouncementTabMode = FunctionMode.NORECORD;
                    LoadControlStatus(tbpCompanyAnnouncement);
                }
                else
                {
                    companyAccouncementTabMode = FunctionMode.HASRECORD;
                    LoadControlStatus(tbpCompanyAnnouncement);
                }
            }
            else
            {
                txtCompanyAnnouncementMemo.Text += DateTime.Now.ToString() + ":ERROR" + Environment.NewLine;
                foreach (string s in errorList)
                {
                    txtCompanyAnnouncementMemo.Text += s + Environment.NewLine;
                }
            }
            btnCompanyAnnouncementSearch_Click(sender, e);
            if (isGridViewEmpty(gvCompanyAnnouncementSearch_Result))
            {
                companyAccouncementTabMode = FunctionMode.NORECORD;
                LoadControlStatus(tbpCompanyAnnouncement);
            }
            else
            {
                companyAccouncementTabMode = FunctionMode.HASRECORD;
                LoadControlStatus(tbpCompanyAnnouncement);
            }
        }

        private void btnCompanyAnnouncementCancel_Click(object sender, EventArgs e)
        {
            if (isGridViewEmpty(gvCompanyAnnouncementSearch_Result))
            {
                companyAccouncementTabMode = FunctionMode.NORECORD;
                LoadControlStatus(tbpCompanyAnnouncement);
            }
            else
            {
                companyAccouncementTabMode = FunctionMode.HASRECORD;
                LoadControlStatus(tbpCompanyAnnouncement);
            }
        }

        private void gvCompanyAnnouncementSearch_Result_SelectionChanged(object sender, EventArgs e)
        {
            if (gvCompanyAnnouncementSearch_Result.SelectedRows.Count > 0)
            {
                displayGridviewSearch_ResultInControls(gvCompanyAnnouncementSearch_Result);
            }
        }

        protected int GetNewCompanyAnnouncementID()
        {
            int newID;

            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "select MAX([ID]) + 1 [newID]"
                            + " FROM HR360_COMPANYANNOUNCEMENT";
                SqlCommand cmd = new SqlCommand(query, conn);
                newID = Convert.ToInt16(cmd.ExecuteScalar());
            }

            return newID;
        }
        
        #endregion

    }
}
