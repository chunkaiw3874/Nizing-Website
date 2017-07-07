using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OQS_Data_Config
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// disable window's move
        /// </summary>
        /// <param name="message"></param>

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dtLoginAccount = new DataTable();
            dsBackendLoginAccountTableAdapters.BACKEND_LOGIN_ACCOUNTTableAdapter accountAdapter = new dsBackendLoginAccountTableAdapters.BACKEND_LOGIN_ACCOUNTTableAdapter();
            //dsLoginAccountTableAdapters.LOGIN_ACCOUNTTableAdapter accountAdapter = new dsLoginAccountTableAdapters.LOGIN_ACCOUNTTableAdapter();
            dtLoginAccount = accountAdapter.GetData();

            var tempRow = dtLoginAccount.Select("LOGIN_ID='" + txtUserName.Text.Trim().ToUpper() + "'");
            DataTable dtVerifyLogin = tempRow.Any()? tempRow.CopyToDataTable() : dtLoginAccount.Clone();

            if (dtVerifyLogin.Rows.Count == 0)
            {
                lblLoginStatus.Text = "使用者不存在";
            }
            else
            {
                tempRow=dtVerifyLogin.Select("AUTH_ID='" + cbxFunctionList.SelectedValue + "'");
                dtVerifyLogin = tempRow.Any() ? tempRow.CopyToDataTable() : dtVerifyLogin.Clone();
                if (dtVerifyLogin.Rows.Count == 0)
                {
                    lblLoginStatus.Text = "使用者無權限使用此模組";
                }
                else if (dtVerifyLogin.Rows[0]["PASSWORD"].ToString() != txtPassword.Text)
                {
                    lblLoginStatus.Text = "密碼錯誤";
                }
                else
                {
                    var frm = new frmMain();
                    frm.Location = this.Location;
                    frm.StartPosition = FormStartPosition.Manual;
                    frm.FormClosing += delegate { Application.Exit(); };
                    frm.Show();
                    this.Hide();
                }
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsBackendLoginAccount.BACKEND_FUNCTION_LIST' table. You can move, or remove it, as needed.
            this.bACKEND_FUNCTION_LISTTableAdapter.Fill(this.dsBackendLoginAccount.BACKEND_FUNCTION_LIST);

        }
    }
}
