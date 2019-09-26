using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NIZING_BACKEND_Data_Config
{
    public partial class frmBackend_Main : Form
    {
        public string UserName { get; set; }
        public DataTable dtAuthorizedFunctionTable { get; set; }
        public string CurrentForm { get; set; }
        private readonly frmLogin _frmLogin;
        private Boolean searchFormLoaded = false; 
        private enum FunctionMode { ADD, EDIT, DELETE, SEARCH, HASRECORD, NORECORD };
        TabPage currentTabPage;

        #region 帳號管理 Universal Variable
        private FunctionMode accountTabMode = FunctionMode.NORECORD;
        #endregion


        public frmBackend_Main(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
            currentTabPage = tbcManagement.SelectedTab;
            LoadControlStatus(currentTabPage);
            #region 帳號管理 Init
            flpAccountId.Margin = new Padding(0, (flpAccountId.Height - (txtAccountId.Height + 3)) / 2, 0, 0);
            dsBackendLoginAccountTableAdapters.BACKEND_FUNCTION_LISTTableAdapter adapter = new dsBackendLoginAccountTableAdapters.BACKEND_FUNCTION_LISTTableAdapter();
            DataTable dtFunctionList = adapter.GetData();
            ((ListBox)this.clbAdminRights).DataSource = dtFunctionList;
            ((ListBox)this.clbAdminRights).DisplayMember = "NAME";
            ((ListBox)this.clbAdminRights).ValueMember = "ID";
            accountTabMode = FunctionMode.NORECORD;
            txtAccountManagementMemo.Text = String.Empty;
            #endregion
        }

        public frmBackend_Main()
        {
            InitializeComponent();
            currentTabPage = tbcManagement.SelectedTab;
            LoadControlStatus(currentTabPage);
            #region 帳號管理 Init
            flpAccountId.Margin = new Padding(0, (flpAccountId.Height - (txtAccountId.Height + 3)) / 2, 0, 0);
            dsBackendLoginAccountTableAdapters.BACKEND_FUNCTION_LISTTableAdapter adapter = new dsBackendLoginAccountTableAdapters.BACKEND_FUNCTION_LISTTableAdapter();
            DataTable dtFunctionList = adapter.GetData();
            ((ListBox)this.clbAdminRights).DataSource = dtFunctionList;
            ((ListBox)this.clbAdminRights).DisplayMember = "NAME";
            ((ListBox)this.clbAdminRights).ValueMember = "ID";
            accountTabMode = FunctionMode.NORECORD;
            txtAccountManagementMemo.Text = String.Empty;
            #endregion

        }

        private void frmBackend_Main_Shown(object sender, EventArgs e)
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

        private List<string> GetSelectedItem(CheckedListBox clb)
        {
            List<string> checkedList = new List<string>();
            foreach (DataRowView row in clb.CheckedItems)
            {
                checkedList.Add(row["ID"].ToString());
            }
            return checkedList;
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
                else if (mode == FunctionMode.DELETE)
                {
                    if (String.IsNullOrWhiteSpace(txtAccountId.Text))
                    {
                        errorList.Add("未選擇刪除帳號");
                    }
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
                    ckxFullAdminRights.Enabled = true;
                    ckxFullAdminRights.Checked = false;
                    txtAccountPassword.Enabled = true;
                    txtAccountPassword.Text = String.Empty;
                    txtAccountConfirmPassword.Enabled = true;
                    txtAccountConfirmPassword.Text = String.Empty;
                    clbAdminRights.Enabled = true;
                    for (int i = 0; i < clbAdminRights.Items.Count; i++)
                    {
                        clbAdminRights.SetItemChecked(i, false);
                    }
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
                    txtAccountId.Enabled = true;
                    ckxFullAdminRights.Enabled = true;
                    txtAccountPassword.Enabled = true;
                    txtAccountPassword.Text = String.Empty;
                    txtAccountConfirmPassword.Enabled = true;
                    txtAccountConfirmPassword.Text = String.Empty;
                    clbAdminRights.Enabled = true;
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
                    ckxFullAdminRights.Enabled = false;
                    txtAccountPassword.Enabled = false;
                    txtAccountConfirmPassword.Enabled = false;
                    clbAdminRights.Enabled = false;
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
                    ckxFullAdminRights.Enabled = false;
                    txtAccountPassword.Enabled = false;
                    txtAccountConfirmPassword.Enabled = false;
                    txtAccountConfirmPassword.Text = String.Empty;
                    clbAdminRights.Enabled = false;
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
                    txtAccountId.Text = String.Empty;
                    ckxFullAdminRights.Enabled = false;
                    ckxFullAdminRights.Checked = false;
                    txtAccountPassword.Enabled = false;
                    txtAccountPassword.Text = String.Empty;
                    txtAccountConfirmPassword.Enabled = false;
                    txtAccountConfirmPassword.Text = String.Empty;
                    clbAdminRights.Enabled = false;
                    for (int i = 0; i < clbAdminRights.Items.Count; i++)
                    {
                        clbAdminRights.SetItemChecked(i, false);
                    }
                    gvAccountSearch_Result.Enabled = false;
                    gvAccountSearch_Result.DataSource = null;
                    btnLogout.Enabled = true;
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
            if (accountTabMode == FunctionMode.ADD || accountTabMode == FunctionMode.EDIT || accountTabMode == FunctionMode.SEARCH)
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
                txtAccountId.Text = gvAccountSearch_Result.SelectedRows[0].Cells["LOGIN_ID"].Value.ToString();
                for (int i = 1; i < gvAccountSearch_Result.Columns.Count; i++)
                {
                    if (gvAccountSearch_Result.SelectedRows[0].Cells[i].Value.ToString() == "0")
                    {
                        clbAdminRights.SetItemCheckState(i - 1, CheckState.Unchecked);
                    }
                    else
                    {
                        clbAdminRights.SetItemCheckState(i - 1, CheckState.Checked);
                    }
                }
            }
        }
        #endregion

        #region Account Method and Events
        private void btnAccountConfirm_Click(object sender, EventArgs e)
        {
            dsBackendLoginAccountTableAdapters.BACKEND_LOGIN_ACCOUNTTableAdapter accountAdapter = new dsBackendLoginAccountTableAdapters.BACKEND_LOGIN_ACCOUNTTableAdapter();
            dsBackendLoginAccountTableAdapters.BACKEND_FUNCTION_LISTTableAdapter functionListAdapter = new dsBackendLoginAccountTableAdapters.BACKEND_FUNCTION_LISTTableAdapter();            
            List<string> errorList = CheckConfirmError(accountTabMode);

            txtAccountManagementMemo.Text = "";
            if (errorList.Count == 0)
            {
                DataTable dtFunctionList = functionListAdapter.GetData();
                List<string> authorizationList = GetSelectedItem(clbAdminRights);
                string accountId = txtAccountId.Text.ToUpper().Trim();
                string password = txtAccountPassword.Text;
                if (accountTabMode == FunctionMode.ADD)
                {
                    accountAdapter.InsertLoginRecordQuery(accountId, password);
                    for (int i = 0; i < dtFunctionList.Rows.Count; i++)
                    {
                        accountAdapter.InsertAuthRecordQuery(accountId, dtFunctionList.Rows[i]["ID"].ToString(), "0");
                    }
                    foreach (string authorizationId in authorizationList)
                    {
                        accountAdapter.UpdateAuthRecordQuery("1", accountId, authorizationId);
                    }
                    txtAccountManagementMemo.Text += DateTime.Now.ToString() + ":資料新增完成" + Environment.NewLine;
                }
                else if (accountTabMode == FunctionMode.EDIT)
                {
                    for (int i = 0; i < dtFunctionList.Rows.Count; i++)
                    {
                        accountAdapter.UpdateAuthRecordQuery("0", accountId, dtFunctionList.Rows[i]["ID"].ToString());
                    }
                    foreach (string authorizationId in authorizationList)
                    {
                        accountAdapter.UpdateAuthRecordQuery("1", accountId, authorizationId);
                    }
                    if (!String.IsNullOrWhiteSpace(password))
                    {
                        accountAdapter.UpdateLoginRecordQuery(password, accountId);
                    }
                    txtAccountManagementMemo.Text += DateTime.Now.ToString() + ":資料更新完成" + Environment.NewLine;
                }
            }
            else
            {
                txtAccountManagementMemo.Text += DateTime.Now.ToString() + ":ERROR" + Environment.NewLine;
                foreach (string s in errorList)
                {
                    txtAccountManagementMemo.Text += s + Environment.NewLine;
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

        private void btnAccountAdd_Click(object sender, EventArgs e)
        {
            accountTabMode = FunctionMode.ADD;
            LoadControlStatus(currentTabPage);
        }

        private void btnAccountDelete_Click(object sender, EventArgs e)
        {
            accountTabMode = FunctionMode.DELETE;
            List<string> errorList = CheckConfirmError(accountTabMode);           
            
            if (errorList.Count == 0)
            {
                var confirmResult = MessageBox.Show("確定要刪除" + txtAccountId.Text.Trim() + "的資料嗎?", "刪除確認", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    dsBackendLoginAccountTableAdapters.BACKEND_LOGIN_ACCOUNTTableAdapter adapter = new dsBackendLoginAccountTableAdapters.BACKEND_LOGIN_ACCOUNTTableAdapter();
                    adapter.DeleteAuthRecordQuery(txtAccountId.Text);
                    adapter.DeleteLoginRecordQuery(txtAccountId.Text);
                    gvAccountSearch_Result.DataSource = null;
                    txtAccountManagementMemo.Text += DateTime.Now.ToString() + ":資料已刪除" + Environment.NewLine;

                    searchFormLoaded = false;
                    gvAccountSearch_Result.DataSource = adapter.GetData();
                    searchFormLoaded = true;
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
            }
            else
            {
                txtAccountManagementMemo.Text += DateTime.Now.ToString() + ":ERROR" + Environment.NewLine;
                foreach (string s in errorList)
                {
                    txtAccountManagementMemo.Text += s + Environment.NewLine;
                }
            }            
        }
        private void gvAccountSearch_Result_SelectionChanged(object sender, EventArgs e)
        {
            if (searchFormLoaded)
            {
                displayGridviewSearch_ResultInControls(gvAccountSearch_Result);
            }
        }
        private void btnAccountSearch_Click(object sender, EventArgs e)
        {
            accountTabMode = FunctionMode.SEARCH;
            LoadControlStatus(currentTabPage);

            var frm = new frmBackend_AccountSearch();
            frm.Location = new Point(this.Location.X + (this.Width / 2), this.Location.Y + (this.Height / 4));
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { frm.Hide(); };
            frm.loadButtonEvent += new searchForm_Close(accountSearchForm_loadButton);
            frm.loadGridviewEvent += new searchForm_Search(accountSearchForm_loadGridview);
            frm.Show();
        }
        private void ckxFullAdminRights_CheckedChanged(object sender, EventArgs e)
        {
            if (ckxFullAdminRights.Checked)
            {
                for (int i = 0; i < clbAdminRights.Items.Count; i++)
                {
                    clbAdminRights.SetItemCheckState(i, CheckState.Checked);
                }
            }
        }

        private void clbAdminRights_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
            {
                ckxFullAdminRights.Checked = false;
            }
        }

        private void btnAccountEdit_Click(object sender, EventArgs e)
        {
            accountTabMode = FunctionMode.EDIT;
            LoadControlStatus(currentTabPage);
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
        #endregion


    }
}
