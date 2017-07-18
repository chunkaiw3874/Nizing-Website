﻿using System;
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
    public partial class frmOQS_Main : Form
    {
        private Boolean searchFormLoaded = false;        

        public frmOQS_Main()
        {
            InitializeComponent();
            #region 帳號管理
            btnAccountAdd.Enabled = true;
            btnAccountEdit.Enabled = false;
            btnAccountDelete.Enabled = false;
            btnAccountConfirm.Enabled = false;
            btnAccountCancel.Enabled = false;
            btnAccountSearch.Enabled = true;
            gvAccountSearch_Result.Enabled = true;
            tlpAccountInputField.Enabled = false;
            txtAccountId.Text = "";
            lblAccountName.Text = "";
            txtAccountPassword.Text = "";
            txtAccountConfirmPassword.Text = "";
            #endregion
            #region 產品管理
            btnProductEdit.Enabled = false;
            btnProductSearch.Enabled = true;
            btnProductSync.Enabled = true;
            btnProductConfirm.Enabled = false;
            btnProductCancel.Enabled = false;
            
            #endregion
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var frm = new frmLogin();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsOQS_LoginAccount.ACCOUNT_VIPLEVEL' table. You can move, or remove it, as needed.
            this.aCCOUNT_VIPLEVELTableAdapter.Fill(this.dsOQS_LoginAccount.ACCOUNT_VIPLEVEL);

        }
        #region 帳號管理
        #region button behavior
        private void btnAccountAdd_Click(object sender, EventArgs e)
        {
            btnAccountAdd.Enabled = false;
            btnAccountEdit.Enabled = false;
            btnAccountDelete.Enabled = false;
            btnAccountConfirm.Enabled = true;
            btnAccountCancel.Enabled = true;
            btnAccountSearch.Enabled = false;
            gvAccountSearch_Result.Enabled = false;
            tlpAccountInputField.Enabled = true;
            txtAccountId.Enabled = true;
            txtAccountId.Text = "";
            lblAccountName.Text = "";
            txtAccountPassword.Text = "";
            txtAccountConfirmPassword.Text = "";
        }

        private void btnAccountEdit_Click(object sender, EventArgs e)
        {
            btnAccountAdd.Enabled = false;
            btnAccountEdit.Enabled = false;
            btnAccountDelete.Enabled = false;
            btnAccountConfirm.Enabled = true;
            btnAccountCancel.Enabled = true;
            btnAccountSearch.Enabled = false;
            gvAccountSearch_Result.Enabled = false;
            tlpAccountInputField.Enabled = true;
            txtAccountId.Enabled = false;
        }

        private void btnAccountDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("確定要刪除" + txtAccountId.Text.Trim() + "的資料嗎?", "刪除確認", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                dsOQS_LoginAccountTableAdapters.LOGIN_ACCOUNTTableAdapter adapter = new dsOQS_LoginAccountTableAdapters.LOGIN_ACCOUNTTableAdapter();
                adapter.DeleteQuery(txtAccountId.Text.Trim());
                lblAccountSubmitStatus.Text = "帳號刪除完成";
                lblAccountSubmitStatus.ForeColor = Color.Green;

                btnAccountAdd.Enabled = true;
                searchFormLoaded = false;
                gvAccountSearch_Result.DataSource = adapter.GetData();
                searchFormLoaded = true;
                if (gvAccountSearch_Result.Rows.Count > 0)  //刪除後，搜尋結果裡還有資料可供編輯或刪除
                {
                    btnAccountEdit.Enabled = true;
                    btnAccountDelete.Enabled = true;
                    gvAccountSearch_Result.Rows[0].Selected = true;
                    displaygvAccountSearch_ResultInControls();
                }
                else
                {
                    btnAccountEdit.Enabled = false;
                    btnAccountDelete.Enabled = false;
                }
                btnAccountConfirm.Enabled = false;
                btnAccountCancel.Enabled = false;
                btnAccountSearch.Enabled = true;
                gvAccountSearch_Result.Enabled = true;
                tlpAccountInputField.Enabled = false;
            }            
        }

        private void btnAccountConfirm_Click(object sender, EventArgs e)    //需要確認準備被確認的資料是用來新增或編輯的
        {            
            Boolean confirm = true;
            lblAccountSubmitStatus.Text = "";
            lblAccountSubmitStatus.ForeColor = Color.Red;
            if (txtAccountId.Text.Trim() == "")
            {
                confirm = false;
                lblAccountSubmitStatus.Text += "未輸入帳號\n";
            }
            if (txtAccountPassword.Text.Trim() == "")
            {
                confirm = false;
                lblAccountSubmitStatus.Text += "未輸入密碼\n";
            }
            if (txtAccountConfirmPassword.Text.Trim() == "")
            {
                confirm = false;
                lblAccountSubmitStatus.Text += "請確認密碼\n";
            }
            if (txtAccountConfirmPassword.Text != txtAccountPassword.Text)
            {
                confirm = false;
                lblAccountSubmitStatus.Text += "密碼與確認密碼不符\n";
            }

            if (confirm == true)
            {
                //確認OK後針對資料所做的處理
                dsOQS_LoginAccountTableAdapters.LOGIN_ACCOUNTTableAdapter adapter = new dsOQS_LoginAccountTableAdapters.LOGIN_ACCOUNTTableAdapter();    //load account table through an adapter                

                if (txtAccountId.Enabled == true) //新增的confirm
                {
                    adapter.InsertQuery(txtAccountId.Text.Trim(), txtAccountPassword.Text, cbxAccountVipLevel.SelectedValue.ToString());
                    lblAccountSubmitStatus.Text = "新增帳號完成";
                    lblAccountSubmitStatus.ForeColor = Color.Green;
                }
                else
                {
                    adapter.UpdateQuery(txtAccountPassword.Text, cbxAccountVipLevel.SelectedValue.ToString(), txtAccountId.Text.Trim());
                    lblAccountSubmitStatus.Text = "編輯帳號完成";
                    lblAccountSubmitStatus.ForeColor = Color.Green;
                }

                //確認OK後針對控制項所做的處理
                btnAccountAdd.Enabled = true;
                btnAccountEdit.Enabled = true;
                btnAccountDelete.Enabled = true;
                btnAccountConfirm.Enabled = false;
                btnAccountCancel.Enabled = false;
                btnAccountSearch.Enabled = true;
                gvAccountSearch_Result.Enabled = true;
                tlpAccountInputField.Enabled = false;
            }
        }

        private void btnAccountCancel_Click(object sender, EventArgs e)
        {
            btnAccountAdd.Enabled = true;
            btnAccountEdit.Enabled = false;
            btnAccountDelete.Enabled = false;
            btnAccountConfirm.Enabled = false;
            btnAccountCancel.Enabled = false;
            btnAccountSearch.Enabled = true;
            gvAccountSearch_Result.Enabled = true;
            tlpAccountInputField.Enabled = false;
            txtAccountId.Text = "";
            lblAccountName.Text = "";
            txtAccountPassword.Text = "";
            txtAccountConfirmPassword.Text = "";
        }        
        
        private void btnAccountSearch_Click(object sender, EventArgs e)
        {
            btnAccountAdd.Enabled = false;
            btnAccountEdit.Enabled = false;
            btnAccountDelete.Enabled = false;
            btnAccountConfirm.Enabled = false;
            btnAccountCancel.Enabled = false;
            btnAccountSearch.Enabled = false;
            gvAccountSearch_Result.Enabled = false;
            tlpAccountInputField.Enabled = false;

            var frm = new frmOQS_AccountSearch();
            frm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { frm.Hide(); };
            frm.loadButtonEvent += new searchForm_Close(accountSearchForm_loadButton);
            frm.loadGridviewEvent += new searchForm_Search(accountSearchForm_loadGridview);
            frm.Show();
        }

        #endregion

        #region method for other forms
        void accountSearchForm_loadButton()
        {
            btnAccountAdd.Enabled = true;
            if (gvAccountSearch_Result.Rows.Count > 0)
            {
                btnAccountEdit.Enabled = true;
                btnAccountDelete.Enabled = true;
            }
            else
            {
                btnAccountEdit.Enabled = false;
                btnAccountDelete.Enabled = false;
            }
            btnAccountConfirm.Enabled = false;
            btnAccountCancel.Enabled = false;
            btnAccountSearch.Enabled = true;
            gvAccountSearch_Result.Enabled = true;
            tlpAccountInputField.Enabled = false;
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
                lblAccountName.Text = "";
                cbxAccountVipLevel.SelectedIndex = 0;
                txtAccountPassword.Text = "";
                txtAccountConfirmPassword.Text = "";
            }
            foreach (DataGridViewColumn col in gvAccountSearch_Result.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }
        #endregion
        private void gvAccountSearch_Result_SelectionChanged(object sender, EventArgs e)
        {
            if (searchFormLoaded)
            {
                displaygvAccountSearch_ResultInControls();
            }
        }

        private void displaygvAccountSearch_ResultInControls()
        {
            if (gvAccountSearch_Result.Rows.Count > 0)
            {
                txtAccountId.Text = (string)gvAccountSearch_Result.SelectedRows[0].Cells[0].Value;
                if (gvAccountSearch_Result.SelectedRows[0].Cells[1].Value == DBNull.Value)
                {
                    lblAccountName.Text = string.Empty;
                }
                else
                {
                    lblAccountName.Text = (string)gvAccountSearch_Result.SelectedRows[0].Cells[1].Value;
                }
                txtAccountPassword.Text = (string)gvAccountSearch_Result.SelectedRows[0].Cells[2].Value;
                txtAccountConfirmPassword.Text = (string)gvAccountSearch_Result.SelectedRows[0].Cells[2].Value;
                if (gvAccountSearch_Result.SelectedRows[0].Cells[3].Value == DBNull.Value)
                {
                    cbxAccountVipLevel.SelectedIndex = 0;
                }
                else
                {
                    cbxAccountVipLevel.SelectedIndex = Convert.ToInt16(gvAccountSearch_Result.SelectedRows[0].Cells[3].Value);
                }
            }
        }

        //When AccountId textbox is out of focus, program searches for client name that fits the ID from ERP client list
        private void txtAccountId_Leave(object sender, EventArgs e)
        {
            dsOQS_LoginAccountTableAdapters.COPMATableAdapter adapter = new dsOQS_LoginAccountTableAdapters.COPMATableAdapter();
            DataTable dt = adapter.GetData();

            if (string.IsNullOrEmpty(txtAccountId.Text.Trim()))
            {
                lblAccountName.Text = "";
            }
            else
            {
                var row = dt.AsEnumerable().FirstOrDefault(x => ((string)x["ID"]).Trim().CompareTo(txtAccountId.Text.Trim()) == 0) ?? null;
                if (row == null)
                {
                    lblAccountName.Text = "";
                }
                else
                {
                    lblAccountName.Text = row[1].ToString();
                }
            }
        }

        #endregion        

        #region 產品管理
        private enum postSyncAction { ADD, DELETE, MODIFY, NONE };
        /// <summary>
        /// Sync OQS database with Products from ERP database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProductSync_Click(object sender, EventArgs e)
        {            
            var confirmResult = MessageBox.Show("與鼎新ERP同步產品資料嗎?", "同步資料", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this.Enabled = false;
                pgbProductSyncProgress.Maximum = 100;
                pgbProductSyncProgress.Step = 1;
                pgbProductSyncProgress.Value = 0;                
                bgwProductSyncLoader.RunWorkerAsync();
            }
        }
        private void btnProductSearch_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 背景執行緒
        private void bgwProductSyncLoader_DoWork(object sender, DoWorkEventArgs e)
        {

            dsOQS_ProductInfoTableAdapters.INVMBTableAdapter erpAdapter = new dsOQS_ProductInfoTableAdapters.INVMBTableAdapter();
            dsOQS_ProductInfoTableAdapters.PRODUCT_INFOTableAdapter oqsAdapter = new dsOQS_ProductInfoTableAdapters.PRODUCT_INFOTableAdapter();

            DataTable dtOqs = oqsAdapter.GetData();
            DataTable dtErp = erpAdapter.GetData();
            dtErp.Columns.Add("ACTION");
            dtOqs.Columns.Add("ACTION");

            //開始對所有的資料行進行POSTSYNCACTION的MARKING
            this.Invoke(new MethodInvoker(delegate
            {
                lblProductSyncStatus.Text = "資料比對中...";
            }));             
            if (dtErp != null)
            {
                //開始進行ERP跟OQS table的資料比對
                for (int i = 0; i < dtErp.Rows.Count; i++)
                {
                    //iterate through OQS的資料行，尋找跟這筆ERP的資料相符的資料
                    for (int j = 0; j < dtOqs.Rows.Count; j++)
                    {
                        if (String.IsNullOrWhiteSpace(dtOqs.Rows[j]["ACTION"].ToString().Trim()))    //先檢查此行是否已經配對成功過
                        {
                            if (dtErp.Rows[i]["ID"].ToString().Trim() == dtOqs.Rows[j]["ID"].ToString().Trim()) //找到matching ID
                            {
                                if (dtErp.Rows[i]["NAME"].ToString().Trim() == dtOqs.Rows[j]["NAME"].ToString().Trim()) //同ID且品名一樣
                                {
                                    dtErp.Rows[i]["ACTION"] = postSyncAction.NONE;
                                    dtOqs.Rows[j]["ACTION"] = postSyncAction.NONE;  //備註無動作
                                }
                                else  //同ID但品名不同
                                {
                                    dtErp.Rows[i]["ACTION"] = postSyncAction.MODIFY;
                                    dtOqs.Rows[j]["ACTION"] = postSyncAction.MODIFY;    //備註需更新品名
                                }
                                break;
                            }
                        }
                    }
                    //結束iterate through OQS的資料行尋找相符資料
                    if (String.IsNullOrWhiteSpace(dtErp.Rows[i]["ACTION"].ToString().Trim()))   //這筆ERP的資料未於OQS找到相符的資料行，需新增至OQS
                    {
                        dtErp.Rows[i]["ACTION"] = postSyncAction.ADD;
                    }                    
                }
                //兩個table的資料比對結束
                //iterate through OQS table again, and mark all the unmarked data with DELETE                
                for (int i = 0; i < dtOqs.Rows.Count; i++)
                {
                    if (String.IsNullOrWhiteSpace(dtOqs.Rows[i]["ACTION"].ToString().Trim()))
                    {
                        dtOqs.Rows[i]["ACTION"] = postSyncAction.DELETE;
                    }
                    bgwProductSyncLoader.ReportProgress((int)(100 * (i + 1) / (dtOqs.Rows.Count)));
                }
                //結束iteration
                this.Invoke(new MethodInvoker(delegate
                {
                    lblProductSyncStatus.Text = "資料比對結束";
                })); 
            }            
            //結束MARKING

            //開始更新OQS資料庫(MODIFY > DELETE > ADD)
            DataTable dtErpInterim = new DataTable();
            DataTable dtOqsInterim = new DataTable();
            this.Invoke(new MethodInvoker(delegate
            {
                lblProductSyncStatus.Text = "同步資料庫...";
            })); 
                //MODIFY
            this.Invoke(new MethodInvoker(delegate
            {
                lblProductSyncStatus.Text = "更新已有資料...";
            })); 
            var tempRow = dtErp.AsEnumerable().Where(x => (string)x["ACTION"] == postSyncAction.MODIFY.ToString()).OrderBy(y => y["ID"]);
            dtErpInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtErp.Clone();
            tempRow = dtOqs.AsEnumerable().Where(x => (string)x["ACTION"] == postSyncAction.MODIFY.ToString()).OrderBy(y => y["ID"]);
            dtOqsInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtOqs.Clone();
            if (dtErpInterim.Rows.Count > 0 || dtOqsInterim.Rows.Count > 0)
            {
                for (int i = 0; i < dtOqsInterim.Rows.Count; i++)
                {
                    for (int j = 0; j < dtErpInterim.Rows.Count; j++)
                    {
                        if (dtOqsInterim.Rows[i]["ID"].ToString().Trim() == dtErpInterim.Rows[j]["ID"].ToString().Trim())
                        {
                            oqsAdapter.UpdateQuery(dtErpInterim.Rows[j]["NAME"].ToString().Trim(), dtErpInterim.Rows[j]["ID"].ToString().Trim());
                            break;
                        }
                    }
                    bgwProductSyncLoader.ReportProgress((int)(100 * (i + 1) / dtOqsInterim.Rows.Count));
                }
            }
                //END MODIFY
                //DELETE
            this.Invoke(new MethodInvoker(delegate
            {
                lblProductSyncStatus.Text = "刪除舊資料...";
            })); 
            tempRow = dtOqs.AsEnumerable().Where(x => (string)x["ACTION"] == postSyncAction.DELETE.ToString()).OrderBy(y => y["ID"]);
            dtOqsInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtOqs.Clone();
            if (dtOqsInterim.Rows.Count > 0)
            {
                for (int i = 0; i < dtOqsInterim.Rows.Count; i++)
                {
                    oqsAdapter.DeleteQuery(dtOqsInterim.Rows[i]["ID"].ToString().Trim());
                    bgwProductSyncLoader.ReportProgress((int)(100 * (i + 1) / dtOqsInterim.Rows.Count));
                }
            }
                //END DELETE
                //ADD
            this.Invoke(new MethodInvoker(delegate
            {
                lblProductSyncStatus.Text = "新增新資料...";
            })); 
            tempRow = dtErp.AsEnumerable().Where(x => (string)x["ACTION"] == postSyncAction.ADD.ToString()).OrderBy(y => y["ID"]);
            dtErpInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtErp.Clone();
            if (dtErpInterim.Rows.Count > 0)
            {
                for (int i = 0; i < dtErpInterim.Rows.Count; i++)
                {
                    oqsAdapter.InsertQuery(dtErpInterim.Rows[i]["ID"].ToString().Trim(), dtErpInterim.Rows[i]["NAME"].ToString().Trim(), null, null, null, null);
                    bgwProductSyncLoader.ReportProgress((int)(100 * (i + 1) / dtErpInterim.Rows.Count));
                }
            }
                //END ADD

            this.Invoke(new MethodInvoker(delegate
            {
                lblProductSyncStatus.Text = "資料庫同步完成";
            }));             
            //結束更新OQS資料庫

            //Display data in gridview (not necessary)
            this.Invoke(new MethodInvoker(delegate
            {
                gvProductSearch_Result.DataSource = dtOqs;
            }));            
        }
        #endregion

        private void bgwProductSyncLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {            
            this.pgbProductSyncProgress.SetProgressNoAnimation(e.ProgressPercentage);
        }

        private void bgwProductSyncLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Enabled = true;
        }
    }

    public static class ExtensionMethods
    {
        /// <summary>
        /// Sets the progress bar value, without using 'Windows Aero' animation.
        /// This is to work around a known WinForms issue where the progress bar 
        /// is slow to update. 
        /// </summary>
        public static void SetProgressNoAnimation(this ProgressBar pb, int value)
        {
            // To get around the progressive animation, we need to move the 
            // progress bar backwards.
            if (value == pb.Maximum)
            {
                // Special case as value can't be set greater than Maximum.
                pb.Maximum = value + 1;     // Temporarily Increase Maximum
                pb.Value = value + 1;       // Move past
                pb.Maximum = value;         // Reset maximum
            }
            else
            {
                pb.Value = value + 1;       // Move past
            }
            pb.Value = value;               // Move to correct value
        }
    }
}
