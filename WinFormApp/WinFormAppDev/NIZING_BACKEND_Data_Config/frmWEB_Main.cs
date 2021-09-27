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
using System.IO;

namespace NIZING_BACKEND_Data_Config
{
    public partial class frmWEB_Main : Form
    {
        #region Frame Universal Variable

        string WEBConnectionString = ConfigurationManager.ConnectionStrings["WEBConnectionString"].ConnectionString;
        string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

        public string UserName { get; set; }
        public DataTable dtAuthorizedFunctionTable { get; set; }
        public string CurrentForm { get; set; }
        private readonly frmLogin _frmLogin;
        TabPage currentTabPage;

        private enum FunctionMode { ADD, EDIT, DELETE, SEARCH, HASRECORD, NORECORD }
        #endregion

        #region 公司公告 Universal Variable
        private FunctionMode newsTabMode;
        string newsAttachmentFilePath = @"\\192.168.10.222\Web\Nizing\attachment\news\";

        #endregion

        #region 產品設定 Universal Variable
        private FunctionMode productTabMode;
        string productAttachmentFilePath = @"\\192.168.10.222\Web\Nizing\images\product_pic\";
        #endregion

        public frmWEB_Main(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
            newsTabMode = FunctionMode.NORECORD;
            productTabMode = FunctionMode.NORECORD;
            currentTabPage = tbcManagement.SelectedTab;
            LoadControlStatus(currentTabPage);
        }
        private void frmWEB_Shown(object sender, EventArgs e)
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

        private void LoadControlStatus(TabPage tab)
        {
            if (tab == tbpNewsManagement)
            {
                if (newsTabMode == FunctionMode.ADD)
                {
                    btnNewsAdd.Enabled = false;
                    btnNewsEdit.Enabled = false;
                    btnNewsDelete.Enabled = false;
                    btnNewsSearch.Enabled = false;
                    btnNewsConfirm.Enabled = true;
                    btnNewsCancel.Enabled = true;
                    dtpNewsDate.Enabled = true;
                    dtpNewsDate.Value = DateTime.Today;
                    ckxNewsVisible.Enabled = true;
                    txtNewsTitle.Enabled = true;
                    txtNewsTitle.Text = string.Empty;
                    txtNewsContent.Enabled = true;
                    txtNewsContent.Text = string.Empty;
                    txtNewsLink.Enabled = true;
                    txtNewsLink.Text = string.Empty;
                    btnNewsAddAttachment.Enabled = true;
                    btnNewsRemoveAttachment.Enabled = true;
                    lbtnNewsAttachmentSelection.Enabled = true;
                    clbNewsAttachmentList.Enabled = true;
                    clbNewsAttachmentList.Items.Clear();
                    gvNewsSearchResult.Enabled = false;
                    btnLogout.Enabled = false;
                    cbxFunctionList.Enabled = false;
                }
                else if (newsTabMode == FunctionMode.EDIT)
                {
                    btnNewsAdd.Enabled = false;
                    btnNewsEdit.Enabled = false;
                    btnNewsDelete.Enabled = false;
                    btnNewsSearch.Enabled = false;
                    btnNewsConfirm.Enabled = true;
                    btnNewsCancel.Enabled = true;
                    dtpNewsDate.Enabled = true;
                    ckxNewsVisible.Enabled = true;
                    txtNewsTitle.Enabled = true;
                    txtNewsContent.Enabled = true;
                    txtNewsLink.Enabled = true;
                    btnNewsAddAttachment.Enabled = true;
                    btnNewsRemoveAttachment.Enabled = true;
                    lbtnNewsAttachmentSelection.Enabled = true;
                    clbNewsAttachmentList.Enabled = true;
                    gvNewsSearchResult.Enabled = false;
                    btnLogout.Enabled = false;
                    cbxFunctionList.Enabled = false;
                }
                else if (newsTabMode == FunctionMode.DELETE)
                {

                }
                else if (newsTabMode == FunctionMode.SEARCH)
                {

                }
                else if (newsTabMode == FunctionMode.HASRECORD)
                {
                    btnNewsAdd.Enabled = true;
                    btnNewsEdit.Enabled = true;
                    btnNewsDelete.Enabled = true;
                    btnNewsSearch.Enabled = true;
                    btnNewsConfirm.Enabled = false;
                    btnNewsCancel.Enabled = false;
                    dtpNewsDate.Enabled = false;
                    ckxNewsVisible.Enabled = false;
                    txtNewsTitle.Enabled = false;
                    txtNewsContent.Enabled = false;
                    txtNewsLink.Enabled = false;
                    btnNewsAddAttachment.Enabled = false;
                    btnNewsRemoveAttachment.Enabled = false;
                    lbtnNewsAttachmentSelection.Enabled = false;
                    clbNewsAttachmentList.Enabled = false;
                    gvNewsSearchResult.Enabled = true;
                    btnLogout.Enabled = true;
                    cbxFunctionList.Enabled = true;
                }
                else if (newsTabMode == FunctionMode.NORECORD)
                {
                    btnNewsAdd.Enabled = true;
                    btnNewsEdit.Enabled = false;
                    btnNewsDelete.Enabled = false;
                    btnNewsSearch.Enabled = true;
                    btnNewsConfirm.Enabled = false;
                    btnNewsCancel.Enabled = false;
                    dtpNewsDate.Enabled = false;
                    ckxNewsVisible.Enabled = false;
                    txtNewsTitle.Enabled = false;
                    txtNewsContent.Enabled = false;
                    txtNewsLink.Enabled = false;
                    btnNewsAddAttachment.Enabled = false;
                    btnNewsRemoveAttachment.Enabled = false;
                    lbtnNewsAttachmentSelection.Enabled = false;
                    clbNewsAttachmentList.Enabled = false;
                    gvNewsSearchResult.Enabled = true;
                    btnLogout.Enabled = true;
                    cbxFunctionList.Enabled = true;
                }
            }
        }

        private List<string> CheckConfirmError(FunctionMode mode)
        {
            List<string> errorList = new List<string>();
            if (tbcManagement.SelectedTab == tbpNewsManagement)
            {
                if (mode == FunctionMode.ADD)
                {
                    if (String.IsNullOrWhiteSpace(txtNewsTitle.Text.Trim()))
                    {
                        errorList.Add("主旨不可為空白");
                    }

                    if (String.IsNullOrWhiteSpace(txtNewsContent.Text.Trim()))
                    {
                        errorList.Add("內容不可為空白");
                    }
                }
                else if (mode == FunctionMode.EDIT)
                {
                    if (String.IsNullOrWhiteSpace(txtNewsTitle.Text.Trim()))
                    {
                        errorList.Add("主旨不可為空白");
                    }

                    if (String.IsNullOrWhiteSpace(txtNewsContent.Text.Trim()))
                    {
                        errorList.Add("內容不可為空白");
                    }
                }
                else if (mode == FunctionMode.HASRECORD)
                {

                }
                else if (mode == FunctionMode.DELETE)
                {
                    if (clbNewsAttachmentList.Items.Count > 1) //ignore "Thumbs.db" file that gets created by system
                    {
                        errorList.Add("請先刪除所有附件，再刪除新聞");
                    }
                }
            }
            return errorList;
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

        private void displayGridviewSearchResultInControls(DataGridView gv)
        {
            if (gv.Name == "gvNewsSearchResult")
            {
                dtpNewsDate.Value = Convert.ToDateTime(gv.SelectedRows[0].Cells["newsDate"].Value);
                lblNewsId.Text = gv.SelectedRows[0].Cells["newsId"].Value.ToString();
                ckxNewsVisible.Checked = (bool)gv.SelectedRows[0].Cells["visible"].Value;
                txtNewsTitle.Text = gv.SelectedRows[0].Cells["newsTitle"].Value.ToString();
                txtNewsContent.Text = gv.SelectedRows[0].Cells["newsContent"].Value.ToString();
                txtNewsLink.Text = gv.SelectedRows[0].Cells["newsLink"].Value.ToString();
                clbNewsAttachmentList.Items.Clear();
                string attachmentFilePath = newsAttachmentFilePath + lblNewsId.Text + @"\";
                if (Directory.Exists(attachmentFilePath))
                {
                    foreach (string fName in Directory.GetFiles(attachmentFilePath))
                    {
                        if (Path.GetFileName(fName) != "Thumbs.db")
                        {
                            clbNewsAttachmentList.Items.Add(Path.GetFileName(fName));
                        }
                    }
                }
                else
                {
                    clbNewsAttachmentList.Items.Clear();
                }
            }
        }
        #endregion

        #region 新聞管理 Methods and Events
        private void lbtnNewsAttachmentSelection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lbtnNewsAttachmentSelection.Text == "全選")
            {
                for (int i = 0; i < clbNewsAttachmentList.Items.Count; i++)
                {
                    clbNewsAttachmentList.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < clbNewsAttachmentList.Items.Count; i++)
                {
                    clbNewsAttachmentList.SetItemChecked(i, false);
                }
            }
        }

        private void clbNewsAttachmentList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                if (clbNewsAttachmentList.CheckedItems.Count == clbNewsAttachmentList.Items.Count - 1)
                {
                    lbtnNewsAttachmentSelection.Text = "反選";
                }
            }
            else
            {
                lbtnNewsAttachmentSelection.Text = "全選";
            }
        }
        #endregion

        private void btnNewsAddAttachment_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(lblNewsId.Text))
            {
                using (OpenFileDialog ofg = new OpenFileDialog())
                {
                    ofg.Filter = "All files (*.*)|*.*|Image Files (*.gif;*.jpg;*.png)|*.gif;*.jpg;*.png|PDF Files (*.pdf)|*.pdf";
                    ofg.FilterIndex = 1;
                    ofg.Multiselect = true;
                    if (ofg.ShowDialog() == DialogResult.OK)
                    {
                        string destination = newsAttachmentFilePath + lblNewsId.Text + @"\";
                        if (!Directory.Exists(destination))
                        {
                            Directory.CreateDirectory(destination);
                        }
                        foreach (string srcFileName in ofg.FileNames)
                        {
                            string fName = Path.GetFileName(srcFileName);
                            File.Copy(srcFileName, destination + fName, true);
                            if (!clbNewsAttachmentList.Items.Contains(fName))
                            {
                                clbNewsAttachmentList.Items.Add(fName);
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("尚未取得新聞ID", "錯誤");
            }
        }

        private void btnNewsRemoveAttachment_Click(object sender, EventArgs e)
        {
            for (int i = clbNewsAttachmentList.Items.Count; i > 0; i--)
            {
                if (clbNewsAttachmentList.CheckedItems.Contains(clbNewsAttachmentList.Items[i - 1]))
                {
                    string fullFileName = newsAttachmentFilePath + lblNewsId.Text + @"\" + clbNewsAttachmentList.Items[i - 1].ToString();
                    if (File.Exists(fullFileName))
                    {
                        File.Delete(fullFileName);
                    }
                    clbNewsAttachmentList.Items.RemoveAt(i - 1);
                }
            }
        }

        private void btnNewsSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(WEBConnectionString))
            {
                conn.Open();
                string query = "SELECT [newsId],[newsDate],[newsTitle],[newsContent],[newsLink],[visible]"
                            + " FROM News"
                            + " ORDER BY [newsId] desc";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            gvNewsSearchResult.DataSource = dt;
            if (isGridViewEmpty(gvNewsSearchResult))
            {
                newsTabMode = FunctionMode.NORECORD;
                LoadControlStatus(currentTabPage);
            }
            else
            {
                newsTabMode = FunctionMode.HASRECORD;
                LoadControlStatus(currentTabPage);
            }
        }

        private void gvNewsSearchResult_SelectionChanged(object sender, EventArgs e)
        {
            if (gvNewsSearchResult.SelectedRows.Count > 0)
            {
                displayGridviewSearchResultInControls(gvNewsSearchResult);
            }
        }

        private void btnNewsAdd_Click(object sender, EventArgs e)
        {
            newsTabMode = FunctionMode.ADD;
            lblNewsId.Text = GetNewsId().ToString();
            LoadControlStatus(currentTabPage);
            txtNewsTitle.Focus();
        }

        protected string GetNewsId()
        {
            string newID;

            using (SqlConnection conn = new SqlConnection(WEBConnectionString))
            {
                conn.Open();
                string query = "select coalesce(MAX(convert(decimal, newsId))+1,@date+'001')" +
                    " from News" +
                    " where newsId like @date+'%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@date", dtpNewsDate.Value.ToString("yyyyMMdd"));
                newID = cmd.ExecuteScalar().ToString();
            }

            return newID;
        }

        private void btnNewsEdit_Click(object sender, EventArgs e)
        {
            newsTabMode = FunctionMode.EDIT;
            LoadControlStatus(currentTabPage);
            txtNewsTitle.Focus();
        }

        private void btnNewsDelete_Click(object sender, EventArgs e)
        {
            newsTabMode = FunctionMode.DELETE;
            List<string> errorList = CheckConfirmError(newsTabMode);

            if (errorList.Count == 0)
            {
                var confirmResult = MessageBox.Show("確定要刪除公告" + lblNewsId.Text.Trim() + "的資料嗎?", "刪除確認", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    //delete selected item
                    using (SqlConnection conn = new SqlConnection(WEBConnectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM News"
                                    + " WHERE [newsId]=@ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", lblNewsId.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                    gvNewsSearchResult.DataSource = null;

                    txtNewsMemo.Text += DateTime.Now.ToString() + ":資料已刪除" + Environment.NewLine;
                    btnNewsSearch_Click(sender, e);

                }
            }
            else
            {
                txtNewsMemo.Text += DateTime.Now.ToString() + ":ERROR" + Environment.NewLine;
                foreach (string s in errorList)
                {
                    txtNewsMemo.Text += s + Environment.NewLine;
                }
            }
        }

        private void btnNewsConfirm_Click(object sender, EventArgs e)
        {
            List<string> errorList = CheckConfirmError(newsTabMode);

            if (errorList.Count == 0)
            {
                if (newsTabMode == FunctionMode.ADD)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(WEBConnectionString))
                        {
                            conn.Open();
                            string query = "INSERT INTO News (createTime,creator,modifyTime,modifier,newsId,newsDate,newsTitle,newsContent,newsLink,visible)"
                                        + " VALUES(getdate(),@creator,getdate(),@creator,@id,@date,@title,@content,@link,@visible)";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@creator", UserName);
                            cmd.Parameters.AddWithValue("@id", lblNewsId.Text);
                            cmd.Parameters.AddWithValue("@date", dtpNewsDate.Value.ToString("yyyyMMdd"));
                            cmd.Parameters.AddWithValue("@title", txtNewsTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@content", txtNewsContent.Text.Trim());
                            cmd.Parameters.AddWithValue("@link", txtNewsLink.Text.Trim());
                            cmd.Parameters.AddWithValue("@visible", ckxNewsVisible.Checked);
                            cmd.ExecuteNonQuery();
                        }
                        txtNewsMemo.Text += DateTime.Now.ToString() + ":資料新增完成" + Environment.NewLine;
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627)
                        {
                            lblNewsId.Text = GetNewsId().ToString();
                            btnNewsConfirm_Click(sender, e);
                        }
                        else
                        {
                            txtNewsMemo.Text += DateTime.Now.ToString() + ":Error 新增出現錯誤" + Environment.NewLine;
                        }
                    }

                }
                else if (newsTabMode == FunctionMode.EDIT)
                {
                    using (SqlConnection conn = new SqlConnection(WEBConnectionString))
                    {
                        conn.Open();
                        string query = "UPDATE News"
                                    + " SET modifyTime=GETDATE()"
                                    + " ,modifier=@editor" +
                                    " ,newsDate=@date" +
                                    " ,newsTitle=@title"
                                    + " ,newsContent=@content" +
                                    " ,newsLink=@link"
                                    + " ,visible=@visible"
                                    + " WHERE [newsId]=@id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@editor", UserName);
                        cmd.Parameters.AddWithValue("@id", lblNewsId.Text);
                        cmd.Parameters.AddWithValue("@date", dtpNewsDate.Value.ToString("yyyyMMdd"));
                        cmd.Parameters.AddWithValue("@title", txtNewsTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@content", txtNewsContent.Text.Trim());
                        cmd.Parameters.AddWithValue("@link", txtNewsLink.Text.Trim());
                        cmd.Parameters.AddWithValue("@visible", ckxNewsVisible.Checked);
                        cmd.ExecuteNonQuery();
                    }
                    txtNewsMemo.Text += DateTime.Now.ToString() + ":資料更新完成" + Environment.NewLine;
                }
                //if (isGridViewEmpty(gvNewsSearchResult))
                //{
                //    newsTabMode = FunctionMode.NORECORD;
                //    LoadControlStatus(tbpNewsManagement);
                //}
                //else
                //{
                //    newsTabMode = FunctionMode.HASRECORD;
                //    LoadControlStatus(tbpNewsManagement);
                //}
            }
            else
            {
                txtNewsMemo.Text += DateTime.Now.ToString() + ":ERROR" + Environment.NewLine;
                foreach (string s in errorList)
                {
                    txtNewsMemo.Text += s + Environment.NewLine;
                }
            }
            btnNewsSearch_Click(sender, e);
            //if (isGridViewEmpty(gvNewsSearchResult))
            //{
            //    newsTabMode = FunctionMode.NORECORD;
            //    LoadControlStatus(tbpNewsManagement);
            //}
            //else
            //{
            //    newsTabMode = FunctionMode.HASRECORD;
            //    LoadControlStatus(tbpNewsManagement);
            //}

        }

        private void btnNewsCancel_Click(object sender, EventArgs e)
        {
            if (isGridViewEmpty(gvNewsSearchResult))
            {
                newsTabMode = FunctionMode.NORECORD;
                LoadControlStatus(tbpNewsManagement);
            }
            else
            {
                newsTabMode = FunctionMode.HASRECORD;
                LoadControlStatus(tbpNewsManagement);
            }
        }

        private void dtpNewsDate_ValueChanged(object sender, EventArgs e)
        {
            lblNewsId.Text = GetNewsId();
        }
    }
}
