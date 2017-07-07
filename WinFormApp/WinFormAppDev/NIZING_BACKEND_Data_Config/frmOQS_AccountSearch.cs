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
    public delegate void searchForm_Close();
    public delegate void searchForm_Search(DataTable dt);
    public partial class frmOQS_AccountSearch : Form
    {
        public event searchForm_Close loadButtonEvent;
        public event searchForm_Search loadGridviewEvent;

        public frmOQS_AccountSearch()
        {
            InitializeComponent();
            this.ControlBox = false;
            cbxAccountSearch_AdminRight.SelectedIndex = 0;
        }

        private void btnAccountSearch_Cancel_Click(object sender, EventArgs e)
        {   
            if (loadButtonEvent != null)
            {
                loadButtonEvent();
            }
            this.Close();
        }

        private void btnAccountSearch_Search_Click(object sender, EventArgs e)
        {            
            DataTable dtLoginAccount = new DataTable();
            dsOQS_LoginAccountTableAdapters.LOGIN_ACCOUNTTableAdapter accountAdapter = new dsOQS_LoginAccountTableAdapters.LOGIN_ACCOUNTTableAdapter();
            dtLoginAccount = accountAdapter.GetData();
            string startAccountIdFilter = txtAccountSearch_StartingId.Text.Trim();
            string endAccountIdFilter = txtAccountSearch_EndingId.Text.Trim();
            string accountNameFilter = txtAccountSearch_Name.Text.Trim();
            string startingVipLevelFilter = cbxAccountSearch_StartingVipLevel.SelectedValue.ToString();
            string endingVipLevelFilter = cbxAccountSearch_EndingVipLevel.SelectedValue.ToString();
            string adminRightFilter = cbxAccountSearch_AdminRight.SelectedItem.ToString();
            DataTable dtLoginAccountFiltered = dtLoginAccount.AsEnumerable().CopyToDataTable();            
            if (!string.IsNullOrEmpty(startAccountIdFilter))
            {
                var rows = dtLoginAccountFiltered.AsEnumerable().Where(x => ((string)x["ID"]).CompareTo(startAccountIdFilter) >= 0);
                if (rows.Any())
                {
                    dtLoginAccountFiltered = rows.CopyToDataTable();
                }
                else
                {
                    dtLoginAccountFiltered.Clear();
                }
            }
            if (!string.IsNullOrEmpty(endAccountIdFilter))
            {
                var rows = dtLoginAccountFiltered.AsEnumerable().Where(x => ((string)x["ID"]).CompareTo(endAccountIdFilter) <= 0);
                if (rows.Any())
                {
                    dtLoginAccountFiltered = rows.CopyToDataTable();
                }
                else
                {
                    dtLoginAccountFiltered.Clear();
                }
            }
            if (!string.IsNullOrEmpty(accountNameFilter))
            {
                var rows = dtLoginAccountFiltered.AsEnumerable().Where(x => Convert.ToString(x["NAME"] == DBNull.Value ? "" : (string)x["NAME"]).CompareTo(accountNameFilter) >= 0);
                if (rows.Any())
                {
                    dtLoginAccountFiltered = rows.CopyToDataTable();
                }
                else
                {
                    dtLoginAccountFiltered.Clear();
                }
            }
            if (!string.IsNullOrEmpty(startingVipLevelFilter) && !string.IsNullOrWhiteSpace(startingVipLevelFilter))
            {
                var rows = dtLoginAccountFiltered.AsEnumerable().Where(x => Convert.ToString(x["VIPLEVEL"] == DBNull.Value ? "" : (string)x["VIPLEVEL"]).CompareTo(startingVipLevelFilter) >= 0);
                if (rows.Any())
                {
                    dtLoginAccountFiltered = rows.CopyToDataTable();
                }
                else
                {
                    dtLoginAccountFiltered.Clear();
                }
            }
            if (!string.IsNullOrEmpty(endingVipLevelFilter) && !string.IsNullOrWhiteSpace(endingVipLevelFilter))
            {
                var rows = dtLoginAccountFiltered.AsEnumerable().Where(x => Convert.ToString(x["VIPLEVEL"] == DBNull.Value ? "" : (string)x["VIPLEVEL"]).CompareTo(endingVipLevelFilter) <= 0);
                if (rows.Any())
                {
                    dtLoginAccountFiltered = rows.CopyToDataTable();
                }
                else
                {
                    dtLoginAccountFiltered.Clear();
                }
            }
            if (!string.IsNullOrEmpty(adminRightFilter))
            {
                var rows = dtLoginAccountFiltered.AsEnumerable().Where(x => ((string)x["ADMIN"]).CompareTo(adminRightFilter) == 0);
                if (rows.Any())
                {
                    dtLoginAccountFiltered = rows.CopyToDataTable();
                }
                else
                {
                    dtLoginAccountFiltered.Clear();
                }
            }

            if (loadGridviewEvent != null)
            {
                loadGridviewEvent(dtLoginAccountFiltered);
            } 

            if (loadButtonEvent != null)
            {
                loadButtonEvent();
            }

            this.Close();
        }

        private void frmAccountSearch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsLoginAccount.ACCOUNT_VIPLEVEL' table. You can move, or remove it, as needed.
            this.aCCOUNT_VIPLEVELTableAdapter.Fill(this.dsOQS_LoginAccount.ACCOUNT_VIPLEVEL);

            //insert empty row into datasource
            DataRow emptyVipRow = dsOQS_LoginAccount.ACCOUNT_VIPLEVEL.NewRow();
            emptyVipRow["LEVEL"] = "";
            dsOQS_LoginAccount.ACCOUNT_VIPLEVEL.Rows.InsertAt(emptyVipRow, 0);
            BindingSource bsStartingVipLevel = new BindingSource();
            bsStartingVipLevel.DataSource = dsOQS_LoginAccount.ACCOUNT_VIPLEVEL;
            cbxAccountSearch_StartingVipLevel.DataSource = bsStartingVipLevel;
            cbxAccountSearch_StartingVipLevel.DisplayMember = "LEVEL";
            cbxAccountSearch_StartingVipLevel.ValueMember = "LEVEL";
            BindingSource bsEndingVipLevel = new BindingSource();
            bsEndingVipLevel.DataSource = dsOQS_LoginAccount.ACCOUNT_VIPLEVEL;
            cbxAccountSearch_EndingVipLevel.DataSource = bsEndingVipLevel;
            cbxAccountSearch_EndingVipLevel.DisplayMember = "LEVEL";
            cbxAccountSearch_EndingVipLevel.ValueMember = "LEVEL";
        }
    }
}
