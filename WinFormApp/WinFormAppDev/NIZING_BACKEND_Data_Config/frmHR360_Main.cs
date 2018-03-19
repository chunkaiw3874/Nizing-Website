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
    public partial class frmHR360_Main : Form
    {
        public string UserName { get; set; }
        private Boolean searchFormLoaded = false;
        private enum FunctionMode { ADD, EDIT, DELETE, SEARCH, HASRECORD, NORECORD };
        TabPage currentTabPage;
        private FunctionMode accountTabMode = FunctionMode.NORECORD;

        public frmHR360_Main()
        {
            InitializeComponent();
            accountTabMode = FunctionMode.NORECORD;
            currentTabPage = tbcAccountManagement.SelectedTab;
            LoadControlStatus(currentTabPage);
            txtAccountManagementMemo.Text = String.Empty;      
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
                    ckxAccountSuperUser.Enabled = true;
                    ckxAccountSuperUser.Checked = false;
                    txtAccountPassword.Enabled = true;
                    txtAccountPassword.Text = String.Empty;
                    txtAccountConfirmPassword.Enabled = true;
                    txtAccountConfirmPassword.Text = String.Empty;
                    txtAccountERPID.Enabled = true;
                    txtAccountERPID.Text = string.Empty;
                    btnAccountSearchERPID.Enabled = true;
                    txtAccountName.Enabled = true;
                    txtAccountName.Text = string.Empty;
                    txtAccountEmail.Enabled = true;
                    txtAccountEmail.Text = string.Empty;
                    txtAccountLineId.Enabled = true;
                    txtAccountLineId.Text = string.Empty;
                    txtAccountDisabledDate.Enabled = false;
                    txtAccountDisabledDate.Text = string.Empty;
                    ckxAccountDisable.Enabled = true;
                    ckxAccountDisable.Checked = false;
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
                    txtAccountERPID.Enabled = true;
                    btnAccountSearchERPID.Enabled = true;
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
                    txtAccountName.Enabled = false;
                    txtAccountEmail.Enabled = false;
                    txtAccountLineId.Enabled = false;
                    txtAccountDisabledDate.Enabled = false;
                    ckxAccountDisable.Enabled = false;
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
                    txtAccountName.Enabled = false;
                    txtAccountEmail.Enabled = false;
                    txtAccountLineId.Enabled = false;
                    txtAccountDisabledDate.Enabled = false;
                    ckxAccountDisable.Enabled = false;
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
    }
}
