using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using nizingBackendUserControlLib;

namespace NIZING_BACKEND_Data_Config
{
    public partial class frmDPR_Main : Form
    {
        #region Frame Universal Variable

        string NZConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
        string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

        public string UserName { get; set; }
        public DataTable dtAuthorizedFunctionTable { get; set; }
        public string CurrentForm { get; set; }
        private readonly frmLogin _frmLogin;

        private enum FunctionMode { ADD, EDIT, DELETE, SEARCH, STATIC, DISABLED }
        #endregion

        #region 異常單登入 DeficientRecord Universal Variable
        

        #endregion

        public frmDPR_Main(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
            DataTable dtDeptList = new DataTable();
            dtDeptList = GetDeptList();
            ((ListBox)clbDeficientRecordResponsibleDept).DataSource = dtDeptList;
            ((ListBox)clbDeficientRecordResponsibleDept).ValueMember = "deptId";
            ((ListBox)clbDeficientRecordResponsibleDept).DisplayMember = "deptName";
        }
        private void frmDPR_Shown(object sender, EventArgs e)
        {
            _frmLogin.LoadCbxFunctionList(this);
     }

        #region Frame Methods and Events
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
            _frmLogin.ChangeForm(this, cbxFunctionList.SelectedValue.ToString());
        }
        #endregion

        #region 異常單登入 Methods and Events
        private DataTable GetDeptList()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(NZConnectionString))
            {
                conn.Open();
                string query = "select ME001 'deptId'" +
                    " , ME002 'deptName'" +
                    " from CMSME" +
                    " where ME001 <> 'A-PSD'" +
                    " and ME001<>'A-ACC'" +
                    " and ME001<>'A-ADM'" +
                    " and ME001<>'A-HR'" +
                    " and ME001<>'A-IT'" +
                    " and ME001<>'A-MD'" +
                    " and ME001<>'B-M'" +
                    " order by ME001";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }


        private void clbDeficientRecordResponsibleDept_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            txtDeficientRecordMemo.Text += ((DataRowView)clbDeficientRecordResponsibleDept.Items[e.Index])["deptId"].ToString().Trim() + " is " + e.NewValue + "-" + clbDeficientRecordResponsibleDept.CheckedItems.Count + " items are checked" + Environment.NewLine;
            if(e.NewValue == CheckState.Checked)
            {
                AddDeptResponsible(e);
            }
            else
            {
                RemoveDeptResponsible(e);
            }            
            txtDeficientRecordMemo.Text += "責任部門清單現在有" + flpResponsibleDeptPercent.Controls.Count + "個部門" + Environment.NewLine;

        }

        private void AddDeptResponsible(ItemCheckEventArgs e)
        {
            LabelTextSet lts = new LabelTextSet();
            lts.Name = "ltsDeficientRecordResponsibleDept_" + ((DataRowView)clbDeficientRecordResponsibleDept.Items[e.Index])["deptId"].ToString().Trim();
            lts.Title = ((DataRowView)clbDeficientRecordResponsibleDept.Items[e.Index])["deptName"].ToString().Trim();
            flpResponsibleDeptPercent.Controls.Add(lts);
        }

        private void RemoveDeptResponsible(ItemCheckEventArgs e)
        {
            foreach(Control c in flpResponsibleDeptPercent.Controls)
            {
                if (c.Name.Contains(((DataRowView)clbDeficientRecordResponsibleDept.Items[e.Index])["deptId"].ToString().Trim()))
                {
                    flpResponsibleDeptPercent.Controls.Remove(c);
                    c.Dispose();
                    break;
                }
            }
        }
        #endregion
    }
}
