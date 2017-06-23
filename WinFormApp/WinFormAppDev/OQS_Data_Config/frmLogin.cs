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
            dsLoginAccountTableAdapters.LOGIN_ACCOUNTTableAdapter accountAdapter = new dsLoginAccountTableAdapters.LOGIN_ACCOUNTTableAdapter();
            dtLoginAccount = accountAdapter.GetData();

            DataRow[] drVerifyLogin = dtLoginAccount.Select("ID='" + txtUserName.Text.Trim().ToUpper() + "' AND ADMIN='1'");

            if (drVerifyLogin.Length == 0)
            {
                lblLoginStatus.Text = "使用者不存在";
            }
            else if (drVerifyLogin[0]["PASSWORD"].ToString() != txtPassword.Text)
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
}
