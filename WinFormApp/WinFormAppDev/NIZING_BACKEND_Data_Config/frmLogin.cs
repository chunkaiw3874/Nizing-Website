using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NIZING_BACKEND_Data_Config
{    
    public partial class frmLogin : Form
    {
        string NZConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
        string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
        public string UserName { get; set; }
        public DataTable dtAuthorizedFunctionTable { get; set; }
        public string CurrentForm { get; set; }



        //QUICK ACCESS TO USERNAME AND PW，REMOVE AFTER DEBUG PHASE!
        private void fastLogin(object sender, EventArgs e)
        {
            //txtUserName.Text = "0080";
            //txtPassword.Text = "387485";
            //cbxFunctionList.SelectedIndex = 3;
        }

        #region public methods
        public void LoadCbxFunctionList(Form frm)
        {
            //dtAuthorizedFunctionTable = GetAuthorizedFunctionList();
            if (dtAuthorizedFunctionTable != null)
            {
                ComboBox cbxFunctionList = (ComboBox)frm.Controls.Find("cbxFunctionList", true)[0];   
                cbxFunctionList.DataSource = dtAuthorizedFunctionTable;
                cbxFunctionList.DisplayMember = "NAME";
                cbxFunctionList.ValueMember = "ID";
                cbxFunctionList.SelectedValue = CurrentForm;
            }
        }

        public void ChangeForm(Form sourceForm, string newForm)
        {
            CurrentForm = newForm;
            switch (newForm)
            {
                case "ADMIN":
                    var frmBackend = new frmBackend_Main(this);
                    frmBackend.Location = this.Location;
                    frmBackend.StartPosition = FormStartPosition.Manual;
                    frmBackend.FormClosing += delegate { Application.Exit(); };
                    frmBackend.UserName = this.UserName;
                    frmBackend.CurrentForm = this.CurrentForm;
                    frmBackend.dtAuthorizedFunctionTable = this.dtAuthorizedFunctionTable;
                    frmBackend.Show();
                    sourceForm.Hide();
                    break;
                case "APA":
                    var frmAPA = new frmAPA_Main(this);
                    frmAPA.Location = this.Location;
                    frmAPA.StartPosition = FormStartPosition.Manual;
                    frmAPA.FormClosing += delegate { Application.Exit(); };
                    frmAPA.UserName = this.UserName;
                    frmAPA.CurrentForm = this.CurrentForm;
                    frmAPA.dtAuthorizedFunctionTable = this.dtAuthorizedFunctionTable;
                    frmAPA.Show();
                    sourceForm.Hide();
                    break;
                case "DPR":
                    var frmDPR = new frmDPR_Main(this);
                    frmDPR.Location = this.Location;
                    frmDPR.StartPosition = FormStartPosition.Manual;
                    frmDPR.FormClosing += delegate { Application.Exit(); };
                    frmDPR.UserName = this.UserName;
                    frmDPR.Show();
                    sourceForm.Hide();
                    break;
                case "HR360":
                    var frmHR360 = new frmHR360_Main(this);
                    frmHR360.Location = this.Location;
                    frmHR360.StartPosition = FormStartPosition.Manual;
                    frmHR360.FormClosing += delegate { Application.Exit(); };
                    frmHR360.UserName = this.UserName;
                    frmHR360.Show();
                    sourceForm.Hide();
                    break;
                case "WEB":
                    var frmWEB = new frmWEB_Main(this);
                    frmWEB.Location = this.Location;
                    frmWEB.StartPosition = FormStartPosition.Manual;
                    frmWEB.FormClosing += delegate { Application.Exit(); };
                    frmWEB.UserName = this.UserName;
                    frmWEB.Show();
                    sourceForm.Hide();
                    break;
                default:
                    break;
            }
        }
        #endregion

        public frmLogin()
        {
            InitializeComponent();
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                lblVersion.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            else
            {
                if (System.Reflection.Assembly.GetExecutingAssembly() != null)
                {
                    lblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                }
            }
            //string version = System.Windows.Forms.Application.ProductVersion;
            //Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            //DateTime buildDate = new DateTime(2000, 1, 1)
            //            .AddDays(version.Build).AddSeconds(version.Revision * 2);
            //this.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(3);
            //lblVersion.Text = version.Major + "." + version.Minor + "." + version.Build + Environment.NewLine + buildDate.ToString();
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

            if (dtVerifyLogin.Rows.Count == 0 || dtVerifyLogin.Rows[0]["PASSWORD"].ToString() != txtPassword.Text)
            {
                lblLoginStatus.Text = "使用者/密碼錯誤";
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
                    UserName = txtUserName.Text.Trim();
                    dtAuthorizedFunctionTable = GetAuthorizedFunctionList();
                    CurrentForm = cbxFunctionList.SelectedValue.ToString();
                    ChangeForm(this, CurrentForm);
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

        private DataTable GetAuthorizedFunctionList()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT AUTH.ACCESS_FUNCTION_ID 'ID'"
                            + " ,FUNC.NAME 'NAME'"
                            + " FROM BACKEND_LOGIN_AUTHORIZATION AUTH"
                            + " LEFT JOIN BACKEND_FUNCTION_LIST FUNC ON AUTH.ACCESS_FUNCTION_ID=FUNC.ID"
                            + " WHERE AUTH.ID=@ID"
                            + " AND AUTH.ACTIVE='1'"
                            + " ORDER BY AUTH.ACCESS_FUNCTION_ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", UserName);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }
    }
}
