using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            //cbxFunctionList.SelectedIndex = 1;
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
                case "OQS":
                    var frmOQS = new frmOQS_Main(this);
                    frmOQS.Location = this.Location;
                    frmOQS.StartPosition = FormStartPosition.Manual;
                    frmOQS.FormClosing += delegate { Application.Exit(); };
                    frmOQS.UserName = this.UserName;
                    frmOQS.Show();
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
                default:
                    break;
            }
        }
        #endregion

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
                    UserName = txtUserName.Text.Trim();
                    dtAuthorizedFunctionTable = GetAuthorizedFunctionList();
                    CurrentForm = cbxFunctionList.SelectedValue.ToString();
                    ChangeForm(this, CurrentForm);
                    //switch (CurrentForm)
                    //{
                    //    case "ADMIN":                            
                    //        var frmBackend = new frmBackend_Main(this);
                    //        frmBackend.Location = this.Location;
                    //        frmBackend.StartPosition = FormStartPosition.Manual;
                    //        frmBackend.FormClosing += delegate { Application.Exit(); };
                    //        frmBackend.UserName = this.UserName;
                    //        frmBackend.CurrentForm = this.CurrentForm;
                    //        frmBackend.dtAuthorizedFunctionTable = this.dtAuthorizedFunctionTable;
                    //        frmBackend.Show();
                    //        this.Hide();
                    //        break;
                    //    case "APA":
                    //        var frmAPA = new frmAPA_Main(this);
                    //        frmAPA.Location = this.Location;
                    //        frmAPA.StartPosition = FormStartPosition.Manual;
                    //        frmAPA.FormClosing += delegate { Application.Exit(); };
                    //        frmAPA.UserName = this.UserName;
                    //        frmAPA.CurrentForm = this.CurrentForm;
                    //        frmAPA.dtAuthorizedFunctionTable = this.dtAuthorizedFunctionTable;
                    //        frmAPA.Show();
                    //        this.Hide();
                    //        break;
                    //    case "OQS":
                    //        var frmOQS = new frmOQS_Main(this);
                    //        frmOQS.Location = this.Location;
                    //        frmOQS.StartPosition = FormStartPosition.Manual;
                    //        frmOQS.FormClosing += delegate { Application.Exit(); };
                    //        frmOQS.UserName = this.UserName;
                    //        frmOQS.Show();
                    //        this.Hide();
                    //        break;
                    //    case "HR360":
                    //        var frmHR360 = new frmHR360_Main(this);
                    //        frmHR360.Location = this.Location;
                    //        frmHR360.StartPosition = FormStartPosition.Manual;
                    //        frmHR360.FormClosing += delegate { Application.Exit(); };
                    //        frmHR360.UserName = this.UserName;
                    //        frmHR360.Show();
                    //        this.Hide();
                    //        break;
                    //    default:
                    //        break;
                    //}
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
