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
            nudDeficientRecordDeficientAmount.Maximum = decimal.MaxValue;
            lblDeficientRecordInputDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
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
            //txtDeficientRecordSysMsg.Text += ((DataRowView)clbDeficientRecordResponsibleDept.Items[e.Index])["deptId"].ToString().Trim() + " is " + e.NewValue + "-" + clbDeficientRecordResponsibleDept.CheckedItems.Count + " items are checked" + Environment.NewLine;
            if(e.NewValue == CheckState.Checked)
            {
                AddDeptResponsible(e);
            }
            else
            {
                RemoveDeptResponsible(e);
            }            
            //txtDeficientRecordSysMsg.Text += "責任部門清單現在有" + flpResponsibleDeptPercent.Controls.Count + "個部門" + Environment.NewLine;

        }

        private void AddDeptResponsible(ItemCheckEventArgs e)
        {
            LabelTextSet lts = new LabelTextSet();
            lts.Name = "ltsDeficientRecordResponsibleDept_" + ((DataRowView)clbDeficientRecordResponsibleDept.Items[e.Index])["deptId"].ToString().Trim();
            lts.Title = ((DataRowView)clbDeficientRecordResponsibleDept.Items[e.Index])["deptName"].ToString().Trim();
            flpDeficientRecordResponsibleDeptPercent.Controls.Add(lts);
        }

        private void RemoveDeptResponsible(ItemCheckEventArgs e)
        {
            foreach(Control c in flpDeficientRecordResponsibleDeptPercent.Controls)
            {
                if (c.Name.Contains(((DataRowView)clbDeficientRecordResponsibleDept.Items[e.Index])["deptId"].ToString().Trim()))
                {
                    flpDeficientRecordResponsibleDeptPercent.Controls.Remove(c);
                    c.Dispose();
                    break;
                }
            }
        }

        private void clbDeficientRecordResponsiblePersonnel_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                AddPersonnelResponsible(e);
            }
            else
            {
                RemovePersonnelResponsible(e);
            }
        }

        private void AddPersonnelResponsible(ItemCheckEventArgs e)
        {
            LabelTextSet lts = new LabelTextSet();
            lts.Name = "ltsDeficientRecordResponsiblePersonnel_" + ((DataRowView)clbDeficientRecordResponsiblePersonnel.Items[e.Index])["personnelId"].ToString().Trim();
            lts.Title = ((DataRowView)clbDeficientRecordResponsiblePersonnel.Items[e.Index])["personnelName"].ToString().Trim();
            flpDeficientRecordResponsiblePersonnelMemo.Controls.Add(lts);
        }

        private void RemovePersonnelResponsible(ItemCheckEventArgs e)
        {
            foreach (Control c in flpDeficientRecordResponsiblePersonnelMemo.Controls)
            {
                if (c.Name.Contains(((DataRowView)clbDeficientRecordResponsiblePersonnel.Items[e.Index])["personnelId"].ToString().Trim()))
                {
                    flpDeficientRecordResponsiblePersonnelMemo.Controls.Remove(c);
                    c.Dispose();
                    break;
                }
            }
        }

        private string GetCustomerName(string s)
        {
            using (SqlConnection conn = new SqlConnection(NZConnectionString))
            {
                conn.Open();
                string query = "select MA003" +
                    " from COPMA" +
                    " where MA001=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", s);
                return cmd.ExecuteScalar() == null ? null : cmd.ExecuteScalar().ToString().Trim();
            }
        }

        private void txtDeficientRecordCustomerId_Leave(object sender, EventArgs e)
        {
            if (!cbxDeficientRecordCustomerNameManualInput.Checked && !string.IsNullOrWhiteSpace(txtDeficientRecordCustomerId.Text.Trim()))
            {
                var name = "";

                name = GetCustomerName(txtDeficientRecordCustomerId.Text.Trim());
                if (string.IsNullOrEmpty(name))
                {
                    txtDeficientRecordCustomerName.Text = "";
                    txtDeficientRecordCustomerId.Focus();
                    MessageBox.Show("未找到相符資料，請重新輸入客戶ID");
                }
                else
                {
                    txtDeficientRecordCustomerName.Text = name;
                }
            }
        }

        private void cbxDeficientRecordCustomerNameManualInput_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDeficientRecordCustomerNameManualInput.Checked)
            {
                txtDeficientRecordCustomerId.Text = "ZZ9999";
                txtDeficientRecordCustomerId.ReadOnly = true;
                txtDeficientRecordCustomerName.Text = "";
                txtDeficientRecordCustomerName.ReadOnly = false;
                txtDeficientRecordCustomerName.Focus();
            }
            else
            {
                txtDeficientRecordCustomerId.Text = "";
                txtDeficientRecordCustomerId.ReadOnly = false;
                txtDeficientRecordCustomerName.Text = "";
                txtDeficientRecordCustomerName.ReadOnly = true;
                txtDeficientRecordCustomerId.Focus();
            }

        }

        private void txtDeficientRecordProductId_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDeficientRecordProductId.Text.Trim()))
            {
                DataTable dtProductInfo = new DataTable();
                DateTime date = dtpDeficientRecordOccurDate.Value;
                decimal unitCost;

                unitCost = GetProductUnitCost(txtDeficientRecordProductId.Text.Trim(), date, 3);
                txtDeficientRecordProductUnitCost.Text = unitCost.ToString();

                dtProductInfo = GetProductInfo(txtDeficientRecordProductId.Text.Trim());
                if (dtProductInfo.Rows.Count == 0) 
                {
                    lblDeficientRecordProductName.Text = "";
                    ddlDeficientRecordProductUnit.Items.Clear();

                    txtDeficientRecordProductUnitCost.Text = "";
                    cbxDeficientRecordProductCostManualInput.Enabled = false;

                    txtDeficientRecordProductId.Focus();
                    MessageBox.Show("未找到相符資料，請重新輸入產品品號");
                }
                else
                {
                    lblDeficientRecordProductName.Text = dtProductInfo.Rows[0]["productName"].ToString();
                    
                    ddlDeficientRecordProductUnit.Items.Clear();
                    ddlDeficientRecordProductUnit.Items.Add(dtProductInfo.Rows[0]["productUnit"].ToString());
                    ddlDeficientRecordProductUnit.Items.Add("件");
                    ddlDeficientRecordProductUnit.SelectedIndex = 0;

                    cbxDeficientRecordProductCostManualInput.Enabled = true;
                }
            }
            else
            {
                txtDeficientRecordProductUnitCost.Text = "";
                cbxDeficientRecordProductCostManualInput.Enabled = false;
            }
        }

        private DataTable GetProductInfo(string s)
        {
            using (SqlConnection conn = new SqlConnection(NZConnectionString))
            {
                conn.Open();
                string query = "select MB.MB002 'productName'" +
                    " ,MB.MB004 'productUnit'" +
                    " from INVMB MB" +
                    " where MB.MB001=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", s);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        private decimal GetProductUnitCost(string s, DateTime d, int interval = 0)
        {
            int monthDiff = 0;
            decimal r;

            do
            {                
                using (SqlConnection conn = new SqlConnection(NZConnectionString))
                {
                    conn.Open();
                    string query = "select convert(decimal(20,4), coalesce(LB.LB010, 0)) 'unitCost'" +
                        " from INVLB LB" +
                        " where LB.LB001=@id" +
                        " and LB.LB002=@yearMonth";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", s);
                    cmd.Parameters.AddWithValue("@yearMonth", d.AddMonths(-1 * monthDiff).ToString("yyyyMM"));
                    r = cmd.ExecuteScalar() == null ? 0 : decimal.Parse(cmd.ExecuteScalar().ToString());
                }
                monthDiff++;
            }
            while (r <= 0 && monthDiff <= interval);

            return r;
        }

        private void cbxDeficientRecordProductCostManualInput_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDeficientRecordCustomerNameManualInput.Checked)
            {
                txtDeficientRecordProductUnitCost.ReadOnly = false;
            }
            else
            {
                txtDeficientRecordProductUnitCost.ReadOnly = true;
            }
        }
        #endregion
    }
}
