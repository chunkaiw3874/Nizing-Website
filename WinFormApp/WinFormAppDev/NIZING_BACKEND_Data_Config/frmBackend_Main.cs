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
        private Boolean searchFormLoaded = false; 
        private enum FunctionMode { ADD, EDIT, DELETE, SEARCH, HASRECORD, NORECORD };
        private FunctionMode fmode = FunctionMode.NORECORD;
        public frmBackend_Main()
        {
            InitializeComponent();
            flpAccountId.Margin = new Padding(0, (flpAccountId.Height - (txtAccountId.Height + 3)) / 2, 0, 0);
            dsBackendLoginAccountTableAdapters.BACKEND_FUNCTION_LISTTableAdapter adapter = new dsBackendLoginAccountTableAdapters.BACKEND_FUNCTION_LISTTableAdapter();
            DataTable dtFunctionList = adapter.GetData();
            ((ListBox)this.clbAdminRights).DataSource = dtFunctionList;
            ((ListBox)this.clbAdminRights).DisplayMember = "NAME";
            ((ListBox)this.clbAdminRights).ValueMember = "ID";
            fmode = FunctionMode.NORECORD;
            LoadAccountManagementControlStatus(fmode);
            lblAccountSubmitStatus.Text = String.Empty;
        }

        private void btnAccountConfirm_Click(object sender, EventArgs e)
        {
            dsBackendLoginAccountTableAdapters.BACKEND_LOGIN_ACCOUNTTableAdapter accountAdapter = new dsBackendLoginAccountTableAdapters.BACKEND_LOGIN_ACCOUNTTableAdapter();
            dsBackendLoginAccountTableAdapters.BACKEND_FUNCTION_LISTTableAdapter functionListAdapter = new dsBackendLoginAccountTableAdapters.BACKEND_FUNCTION_LISTTableAdapter();            
            List<string> errorList = CheckConfirmError(fmode);           

            lblAccountSubmitStatus.Text = "";
            if (errorList.Count == 0)
            {
                DataTable dtFunctionList = functionListAdapter.GetData();
                List<string> authorizationList = GetSelectedItem(clbAdminRights);
                string accountId = txtAccountId.Text.ToUpper().Trim();
                string password = txtAccountPassword.Text;
                if (fmode == FunctionMode.ADD)
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
                    lblAccountSubmitStatus.Text = "資料新增完成";
                    lblAccountSubmitStatus.ForeColor = Color.Green;
                }
                else if (fmode == FunctionMode.EDIT)
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
                    lblAccountSubmitStatus.Text = "資料更新完成";
                    lblAccountSubmitStatus.ForeColor = Color.Green;
                }
            }
            else
            {
                foreach (string s in errorList)
                {
                    lblAccountSubmitStatus.Text += s + "\n";
                    lblAccountSubmitStatus.ForeColor = Color.Red;
                }
            }

            if (gvAccountSearch_Result.Rows.Count > 0)
            {
                fmode = FunctionMode.HASRECORD;
                LoadAccountManagementControlStatus(fmode);
            }
            else
            {
                fmode = FunctionMode.NORECORD;
                LoadAccountManagementControlStatus(fmode);
            }
        }

        private List<string> GetSelectedItem(CheckedListBox clb)
        {
            List<string> checkedList = new List<string>();
            foreach (DataRowView row in clbAdminRights.CheckedItems)
            {
                checkedList.Add(row["ID"].ToString());
            }
            return checkedList;
        }

        private void btnAccountAdd_Click(object sender, EventArgs e)
        {
            fmode = FunctionMode.ADD;
            LoadAccountManagementControlStatus(fmode);
        }

        private List<string> CheckConfirmError(FunctionMode mode)
        {
            List<string> errorList = new List<string>();
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
            return errorList;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var frm = new frmLogin();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
            this.Hide();
        }

        private void LoadAccountManagementControlStatus(FunctionMode mode)
        {
            if (mode == FunctionMode.ADD)
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
            else if (mode == FunctionMode.EDIT)
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
            else if (mode == FunctionMode.DELETE)
            {
                
            }
            else if (mode == FunctionMode.SEARCH)
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
            else if (mode == FunctionMode.HASRECORD)
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
            else
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

        private void btnAccountDelete_Click(object sender, EventArgs e)
        {
            fmode = FunctionMode.DELETE;
            List<string> errorList = CheckConfirmError(fmode);           
            
            lblAccountSubmitStatus.Text = "";
            if (errorList.Count == 0)
            {
                var confirmResult = MessageBox.Show("確定要刪除" + txtAccountId.Text.Trim() + "的資料嗎?", "刪除確認", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    dsBackendLoginAccountTableAdapters.BACKEND_LOGIN_ACCOUNTTableAdapter adapter = new dsBackendLoginAccountTableAdapters.BACKEND_LOGIN_ACCOUNTTableAdapter();
                    adapter.DeleteAuthRecordQuery(txtAccountId.Text);
                    adapter.DeleteLoginRecordQuery(txtAccountId.Text);
                    gvAccountSearch_Result.DataSource = null;
                    lblAccountSubmitStatus.Text = "資料已刪除";
                    lblAccountSubmitStatus.ForeColor = Color.Green;
                }
            }
            else
            {
                foreach (string s in errorList)
                {
                    lblAccountSubmitStatus.Text += s + "\n";
                    lblAccountSubmitStatus.ForeColor = Color.Red;
                }
            }

            if (gvAccountSearch_Result.Rows.Count > 0)
            {
                fmode = FunctionMode.HASRECORD;
                LoadAccountManagementControlStatus(fmode);
            }
            else
            {
                fmode = FunctionMode.NORECORD;
                LoadAccountManagementControlStatus(fmode);
            }
            
        }

        private void btnAccountSearch_Click(object sender, EventArgs e)
        {
            fmode = FunctionMode.SEARCH;
            LoadAccountManagementControlStatus(fmode);

            var frm = new frmBackend_AccountSearch();
            frm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { frm.Hide(); };
            frm.loadButtonEvent += new searchForm_Close(accountSearchForm_loadButton);
            frm.loadGridviewEvent += new searchForm_Search(accountSearchForm_loadGridview);
            frm.Show();
        }

        #region method for search form
        void accountSearchForm_loadButton()
        {
            if (gvAccountSearch_Result.Rows.Count > 0)
            {
                fmode = FunctionMode.HASRECORD;
                LoadAccountManagementControlStatus(fmode);
            }
            else
            {
                fmode = FunctionMode.NORECORD;
                LoadAccountManagementControlStatus(fmode);
            }
        }
        void accountSearchForm_loadGridview(DataTable dt)
        {
            searchFormLoaded = false;
            gvAccountSearch_Result.DataSource = dt;
            searchFormLoaded = true;
            if (gvAccountSearch_Result.Rows.Count > 0)
            {
                gvAccountSearch_Result.Rows[0].Selected = true;
                displaygvAccountSearch_ResultInControls();
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

        private void displaygvAccountSearch_ResultInControls()
        {

        }
    }
}
