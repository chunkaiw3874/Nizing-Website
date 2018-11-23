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


namespace NIZING_BACKEND_Data_Config
{    
    public partial class frmLogin : Form
    {
        public string UserName { get; private set; }

        //QUICK ACCESS TO USERNAME AND PW，REMOVE AFTER DEBUG PHASE!
        private void fastLogin(object sender, EventArgs e)
        {
            txtUserName.Text = "admin";
            txtPassword.Text = "nizing";
            cbxFunctionList.SelectedIndex = 2;
        }

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
            dtLoginAccount = accountAdapter.GetData();

            var tempRow = dtLoginAccount.Select("LOGIN_ID='" + txtUserName.Text.Trim().ToUpper() + "'");
            DataTable dtVerifyLogin = tempRow.Any()? tempRow.CopyToDataTable() : dtLoginAccount.Clone();

            if (dtVerifyLogin.Rows.Count == 0)
            {
                lblLoginStatus.Text = "使用者不存在";
            }
            else if (dtVerifyLogin.Rows[0]["PASSWORD"].ToString() != txtPassword.Text)
            {
                lblLoginStatus.Text = "密碼錯誤";
            }
            else
            {
                tempRow = dtVerifyLogin.Select("AUTH_ID='" + cbxFunctionList.SelectedValue + "' AND ACTIVE='1'");
                dtVerifyLogin = tempRow.Any() ? tempRow.CopyToDataTable() : dtVerifyLogin.Clone();
                if (dtVerifyLogin.Rows.Count == 0)
                {
                    lblLoginStatus.Text = "使用者無權限使用此模組";
                }
                else
                {
                    UserName = txtUserName.Text.Trim().ToUpper();
                    switch (cbxFunctionList.SelectedValue.ToString())
                    {
                        case "ADMIN":                            
                            var frmBackend = new frmBackend_Main();
                            frmBackend.Location = this.Location;
                            frmBackend.StartPosition = FormStartPosition.Manual;
                            frmBackend.FormClosing += delegate { Application.Exit(); };
                            frmBackend.UserName = this.UserName;
                            frmBackend.Show();
                            this.Hide();
                            break;
                        case "APA":
                            var frmAPA = new frmAPA_Main();
                            frmAPA.Location = this.Location;
                            frmAPA.StartPosition = FormStartPosition.Manual;
                            frmAPA.FormClosing += delegate { Application.Exit(); };
                            frmAPA.UserName = this.UserName;
                            frmAPA.Show();
                            this.Hide();
                            break;
                        case "OQS":
                            var frmOQS = new frmOQS_Main();
                            frmOQS.Location = this.Location;
                            frmOQS.StartPosition = FormStartPosition.Manual;
                            frmOQS.FormClosing += delegate { Application.Exit(); };
                            frmOQS.UserName = this.UserName;
                            frmOQS.Show();
                            this.Hide();
                            break;
                        case "HR360":
                            var frmHR360 = new frmHR360_Main();
                            frmHR360.Location = this.Location;
                            frmHR360.StartPosition = FormStartPosition.Manual;
                            frmHR360.FormClosing += delegate { Application.Exit(); };
                            frmHR360.UserName = this.UserName;
                            frmHR360.Show();
                            this.Hide();
                            break;
                        default:
                            break;
                    }
                }
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsBackendLoginAccount.BACKEND_FUNCTION_LIST' table. You can move, or remove it, as needed.
            this.bACKEND_FUNCTION_LISTTableAdapter.Fill(this.dsBackendLoginAccount.BACKEND_FUNCTION_LIST);

        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.Clear();
        }


    }
}
