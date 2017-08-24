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
    public partial class frmAPA_Main : Form
    {
        #region Frame Universal Variable
        string NZConnectionString = ConfigurationManager.ConnectionStrings["OQS_Data_Config.Properties.Settings.NZConnectionString"].ConnectionString;
        string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["OQS_Data_Config.Properties.Settings.NZ_ERP2ConnectionString"].ConnectionString;
        public string UserName { get; set; }
        private enum FunctionMode { ADD, EDIT, DELETE, SEARCH, HASRECORD, NORECORD }
        private enum TableRowStatus { DELETED, EDITED, NEW, UNCHANGED };
        TabPage currentTabPage;
        bool isCancel = false;  //Check if an event is triggered after Cancel button is hit;
        #endregion

        #region 問題分類建立 Universal Variable
        private FunctionMode questionCategoryTabMode = FunctionMode.HASRECORD;
        dsAPA_QuestionTableAdapters.HR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter adapterQuestionCategory = new dsAPA_QuestionTableAdapters.HR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter();        
        DataTable dtQuestionCategorySource = new DataTable();
        #endregion

        #region 問題建立 Universal Variable
        private FunctionMode questionTabMode = FunctionMode.HASRECORD;
        dsAPA_QuestionTableAdapters.HR360_ASSESSMENTQUESTION_QUESTION_ATableAdapter adapterQuestion = new dsAPA_QuestionTableAdapters.HR360_ASSESSMENTQUESTION_QUESTION_ATableAdapter();
        DataTable dtQuestionSource = new DataTable();
        #endregion

        #region 評核人員分配 Universal Variable
        private FunctionMode personnelAssignmentTabMode = FunctionMode.HASRECORD;
        DataTable dtPersonnelAssignmentSource = new DataTable();        
        #endregion

        public frmAPA_Main()
        {
            InitializeComponent();
            currentTabPage = tbcManagement.SelectedTab;

            #region 問題分類建立 Initialization           
            dtQuestionCategorySource = adapterQuestionCategory.GetData();
            gvQuestionCategory.DataSource = dtQuestionCategorySource;
            LoadGridViewStyle(gvQuestionCategory);
            questionCategoryTabMode = FunctionMode.HASRECORD;
            LoadControlStatus(currentTabPage);
            #endregion
            #region 問題建立 Initializaiton
            dtQuestionSource = adapterQuestion.GetData();
            gvQuestion.DataSource = dtQuestionSource;
            LoadGridViewStyle(gvQuestion);
            questionTabMode = FunctionMode.HASRECORD;
            LoadControlStatus(currentTabPage);
            #endregion
            #region 評核人員分配 Initialization
            for (int i = DateTime.Now.Year; i >= 2016; i--)
            {
                cbxPersonnelAssignmentYear.Items.Add(i.ToString());
            }
            cbxPersonnelAssignmentYear.SelectedIndex = 0;
            LoadgvPersonnelAssignment();
            LoadGridViewStyle(gvPersonnelAssignment);
            personnelAssignmentTabMode = FunctionMode.HASRECORD;
            LoadControlStatus(currentTabPage);
            #endregion
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
        private void frmAPA_Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsAPA_Question.HR360_ASSESSMENTQUESTION_CATEGORY_A' table. You can move, or remove it, as needed.
            this.hR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter.Fill(this.dsAPA_Question.HR360_ASSESSMENTQUESTION_CATEGORY_A);
        }
        private void tbcManagement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (questionCategoryTabMode == FunctionMode.ADD || questionCategoryTabMode == FunctionMode.EDIT || questionCategoryTabMode == FunctionMode.SEARCH
                || questionTabMode == FunctionMode.ADD || questionTabMode == FunctionMode.EDIT || questionTabMode == FunctionMode.SEARCH
                || personnelAssignmentTabMode == FunctionMode.ADD || personnelAssignmentTabMode == FunctionMode.EDIT || personnelAssignmentTabMode == FunctionMode.SEARCH
                )
            {
                tbcManagement.SelectedTab = currentTabPage;
            }
            else
            {
                currentTabPage = tbcManagement.SelectedTab;
                LoadControlStatus(currentTabPage);
            }
        }
        private void LoadControlStatus(TabPage tab)
        {
            if (tab == tbpQuestionCategory)
            {
                if (questionCategoryTabMode == FunctionMode.HASRECORD)
                {
                    btnQuestionCategoryEdit.Enabled = true;
                    btnQuestionCategorySave.Enabled = false;
                    btnQuestionCategoryCancel.Enabled = false;
                    gvQuestionCategory.ReadOnly = true;
                    gvQuestionCategory.ForeColor = Color.Gray;
                }
                else if (questionCategoryTabMode == FunctionMode.EDIT)
                {
                    btnQuestionCategoryEdit.Enabled = false;
                    btnQuestionCategorySave.Enabled = true;
                    btnQuestionCategoryCancel.Enabled = true;
                    gvQuestionCategory.ReadOnly = false;
                    gvQuestionCategory.ForeColor = Color.Black;
                    LoadGridViewStyle(gvQuestionCategory);
                }
            }
            else if (tab == tbpQuestion)
            {
                if (questionTabMode == FunctionMode.HASRECORD)
                {
                    btnQuestionEdit.Enabled = true;
                    btnQuestionSave.Enabled = false;
                    btnQuestionCancel.Enabled = false;
                    gvQuestion.ReadOnly = true;
                    gvQuestion.ForeColor = Color.Gray;
                }
                else if (questionTabMode == FunctionMode.EDIT)
                {
                    btnQuestionEdit.Enabled = false;
                    btnQuestionSave.Enabled = true;
                    btnQuestionCancel.Enabled = true;
                    gvQuestion.ReadOnly = false;
                    gvQuestion.ForeColor = Color.Black;
                    LoadGridViewStyle(gvQuestion);
                }
            }
            else if (tab == tbpPersonnelAssignment)
            {
                if (personnelAssignmentTabMode == FunctionMode.HASRECORD)
                {                    
                    btnPersonnelAssignmentEdit.Enabled = true;
                    btnPersonnelAssignmentSave.Enabled = false;
                    btnPersonnelAssignmentCancel.Enabled = false;
                    cbxPersonnelAssignmentYear.Enabled = true;
                    gvPersonnelAssignment.ReadOnly = true;
                    gvPersonnelAssignment.ForeColor = Color.Gray;
                }
                else if (personnelAssignmentTabMode == FunctionMode.EDIT)
                {
                    btnPersonnelAssignmentEdit.Enabled = false;
                    btnPersonnelAssignmentSave.Enabled = true;
                    btnPersonnelAssignmentCancel.Enabled = true;
                    cbxPersonnelAssignmentYear.Enabled = false;
                    gvPersonnelAssignment.ReadOnly = false;
                    gvPersonnelAssignment.ForeColor = Color.Black;
                    LoadGridViewStyle(gvPersonnelAssignment);
                }
            }
        }
        private void CompareTables(DataTable dtOriginal, DataTable dtChanged)
        {
            if (!dtOriginal.Columns.Contains("EDIT_STATUS"))
            {
                dtOriginal.Columns.Add("EDIT_STATUS");
            }
            if (!dtChanged.Columns.Contains("EDIT_STATUS"))
            {
                dtChanged.Columns.Add("EDIT_STATUS");
            }

            for (int i = 0; i < dtChanged.Rows.Count; i++)
            {
                if (dtChanged.Rows[i].RowState != DataRowState.Deleted)
                {
                    for (int y = 0; y < dtOriginal.Rows.Count; y++)
                    {
                        if (dtOriginal.Rows[y][0].ToString() == dtChanged.Rows[i][0].ToString())  //找到兩個dt中UID相同的row，執行對比
                        {
                            for (int z = 1; z < dtOriginal.Columns.Count - 1; z++)
                            {
                                if (dtOriginal.Rows[y][z].ToString().Trim() != dtChanged.Rows[i][z].ToString().Trim())    //有cell值不相同，表示此row有被edit過
                                {
                                    dtOriginal.Rows[y]["EDIT_STATUS"] = TableRowStatus.EDITED;
                                    dtChanged.Rows[i]["EDIT_STATUS"] = TableRowStatus.EDITED;
                                    break;
                                }
                            }
                            if (String.IsNullOrWhiteSpace(dtChanged.Rows[i]["EDIT_STATUS"].ToString()))
                            {
                                dtOriginal.Rows[y]["EDIT_STATUS"] = TableRowStatus.UNCHANGED;
                                dtChanged.Rows[i]["EDIT_STATUS"] = TableRowStatus.UNCHANGED;
                            }
                            break;
                        }
                    }
                    if (String.IsNullOrWhiteSpace(dtChanged.Rows[i]["EDIT_STATUS"].ToString()))
                    {
                        dtChanged.Rows[i]["EDIT_STATUS"] = TableRowStatus.NEW;
                    }
                }
            }
            for (int i = 0; i < dtOriginal.Rows.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(dtOriginal.Rows[i]["EDIT_STATUS"].ToString()))
                {
                    dtOriginal.Rows[i][dtOriginal.Columns.Count - 1] = TableRowStatus.DELETED;
                }
            }

        }
        private void LoadGridViewStyle(DataGridView gv)
        {
            switch (gv.Name)
            {
                case "gvQuestionCategory":
                    gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["ID"].ReadOnly = true;
                    gv.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["權重"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    break;
                case "gvQuestion":
                    gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["ID"].ReadOnly = true;
                    gv.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["問題"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;  //change gv column to multiline
                    gv.Columns["問題"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    gv.Columns["分類"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["使用中"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["全體共用"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DataTable dtTemp = adapterQuestionCategory.GetData();
                    dtTemp.Columns.Add("ID_NAME");
                    foreach (DataRow rows in dtTemp.Rows)
                    {
                        rows["ID_NAME"] = rows["ID"].ToString() + " " + rows["名稱"].ToString();
                    }
                    foreach (DataGridViewRow row in gv.Rows)
                    {                        
                        DataGridViewCheckBoxCell ckbIN_USECell = new DataGridViewCheckBoxCell()
                        {
                            TrueValue = "1",
                            FalseValue = "0"                            
                        };
                        ckbIN_USECell.Style.NullValue = false;
                        row.Cells["使用中"] = ckbIN_USECell;
                        DataGridViewCheckBoxCell ckbUSE_BY_ALLCell = new DataGridViewCheckBoxCell()
                        {
                            TrueValue = "1",
                            FalseValue = "0"
                        };
                        ckbUSE_BY_ALLCell.Style.NullValue = false;
                        row.Cells["全體共用"] = ckbUSE_BY_ALLCell;
                        DataGridViewComboBoxCell cbxCATEGORY_IDCell = new DataGridViewComboBoxCell();
                        cbxCATEGORY_IDCell.FlatStyle = FlatStyle.Flat;
                        cbxCATEGORY_IDCell.DataSource = dtTemp;
                        cbxCATEGORY_IDCell.ValueMember = "ID";
                        cbxCATEGORY_IDCell.DisplayMember = "ID_NAME";
                        row.Cells["分類"] = cbxCATEGORY_IDCell;
                    }
                    break;
                case "gvPersonnelAssignment":
                    gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["年份"].ReadOnly = true;
                    gv.Columns["年份"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["受評者"].ReadOnly = true;
                    DataTable dtAssessorList = new DataTable();
                    using (SqlConnection conn = new SqlConnection(NZConnectionString))
                    {
                        conn.Open();
                        string query = "SELECT LTRIM(RTRIM(MV.MV001))+' '+LTRIM(RTRIM(MV.MV002)) 'NAME',LTRIM(RTRIM(MV.MV001)) 'ID'"
                                    + " FROM CMSMV MV"
                                    + " WHERE "
                                    + " (MV.MV022=''"
                                    + " OR MV.MV022 > @YEAR+'1232')"
                                    + " AND MV.MV021 < @YEAR+'1232'"
                                    + " AND MV.MV001 NOT LIKE 'PT%'"
                                    + " AND MV.MV001<>'0000'"
                                    + " AND MV.MV001<>'0098'"
                                    + " ORDER BY MV.MV001";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@YEAR", cbxPersonnelAssignmentYear.Text);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtAssessorList);
                    }
                    foreach (DataGridViewRow row in gv.Rows)
                    {
                        DataGridViewComboBoxCell cbxAssessorCell = new DataGridViewComboBoxCell();
                        cbxAssessorCell.MaxDropDownItems = 5;
                        cbxAssessorCell.DataSource = dtAssessorList;
                        cbxAssessorCell.DisplayMember = "NAME";
                        cbxAssessorCell.ValueMember = "NAME";
                        row.Cells["評核者"] = cbxAssessorCell;
                    }
                    break;
            }
        }
        private string GetErrorMessage(int errorCode)
        {
            string message = "";
            switch (errorCode)
            {
                case 101:
                    message = "儲存格不得空白";
                    break;
                case 102:
                    message = "儲存格值型態錯誤";
                    break;
                case 201:
                    message = "尚有空白儲存格，請將資料完整填寫";
                    break;
                case 401:
                    message = "資料刪除錯誤";
                    break;
                default:
                    message = "未知錯誤";
                    break;
            }
            return message;
        }        
        private void ShowError(int errorCode)
        {
            MessageBox.Show(GetErrorMessage(errorCode));
        }
        private void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }
        private void gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LoadGridViewStyle((DataGridView)sender);
        }
        #endregion      

        #region 問題分類建立 Tab Method and Events
        private void gvQuestionCategory_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!isCancel)
            {
                if (String.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    ShowError(101);
                    e.Cancel = true;
                }
                else if (e.ColumnIndex == 0)
                {
                    int result;
                    if (!int.TryParse(e.FormattedValue.ToString(), out result))
                    {
                        ShowError(102);
                        e.Cancel = true;
                    }
                }
                else if (e.ColumnIndex == 2)
                {
                    decimal result;
                    if (!decimal.TryParse(e.FormattedValue.ToString(), out result))
                    {
                        ShowError(102);
                        e.Cancel = true;
                    }
                }
            }
        }
        private void gvQuestionCategory_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!isCancel)
            {
                foreach (DataGridViewCell c in gvQuestionCategory.Rows[e.RowIndex].Cells)
                {
                    if (String.IsNullOrWhiteSpace(c.EditedFormattedValue.ToString()))
                    {
                        ShowError(201);
                        e.Cancel = true;
                        break;
                    }
                }
            }
        }
        private void gvQuestionCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                
                if (gvQuestionCategory.CurrentRow.Index == gvQuestionCategory.Rows.Count - 1)
                {
                    foreach (DataGridViewCell c in gvQuestionCategory.CurrentRow.Cells)
                    {
                        if (String.IsNullOrWhiteSpace(c.EditedFormattedValue.ToString()))
                        {
                            ShowError(201);
                            e.Handled = true;
                            break;
                        }
                    }
                    if (!e.Handled)
                    {
                        DataRow newRow = dtQuestionCategorySource.NewRow();
                        newRow["ID"] = (Convert.ToInt16(gvQuestionCategory.CurrentRow.Cells[0].EditedFormattedValue) + 1).ToString("D2");
                        dtQuestionCategorySource.Rows.Add(newRow);
                        gvQuestionCategory.DataSource = dtQuestionCategorySource;
                        if (gvQuestionCategory.Rows.Count > 1 && gvQuestionCategory.Enabled == true)
                        {
                            gvQuestionCategory.CurrentCell = gvQuestionCategory.Rows[gvQuestionCategory.CurrentRow.Index + 1].Cells[0];
                        }
                    }
                }
            }
        }
        private void btnQuestionCategoryEdit_Click(object sender, EventArgs e)
        {
            questionCategoryTabMode = FunctionMode.EDIT;
            LoadControlStatus(currentTabPage);
            if (gvQuestionCategory.Rows.Count > 0)
            {
                gvQuestionCategory.CurrentCell = gvQuestionCategory.Rows[0].Cells[0];
            }
        }
        private void btnQuestionCategorySave_Click(object sender, EventArgs e)
        {
            DataTable dtOriginalTable = adapterQuestionCategory.GetData();
            tbcManagement.Enabled = false;
            gvQuestionCategory.DataSource = null;
            CompareTables(dtOriginalTable, dtQuestionCategorySource);
            var tempRow = dtQuestionCategorySource.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted && (string)x["EDIT_STATUS"] == TableRowStatus.EDITED.ToString()).OrderBy(y => y["ID"]);
            DataTable dtSourceInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtQuestionCategorySource.Clone();
            for (int i = 0; i < dtSourceInterim.Rows.Count; i++)
            {
                adapterQuestionCategory.UpdateQuery(UserName, dtSourceInterim.Rows[i]["名稱"].ToString().Trim(), dtSourceInterim.Rows[i]["權重"].ToString().Trim(), dtSourceInterim.Rows[i]["ID"].ToString().Trim());
            }
            tempRow = dtQuestionCategorySource.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted && (string)x["EDIT_STATUS"] == TableRowStatus.NEW.ToString()).OrderBy(y => y["ID"]);
            dtSourceInterim = new DataTable();
            dtSourceInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtQuestionCategorySource.Clone();
            for (int i = 0; i < dtSourceInterim.Rows.Count; i++)
            {
                adapterQuestionCategory.InsertQuery(UserName, dtSourceInterim.Rows[i]["ID"].ToString().Trim(), dtSourceInterim.Rows[i]["名稱"].ToString().Trim(), dtSourceInterim.Rows[i]["權重"].ToString().Trim());
            }
            tempRow = dtOriginalTable.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted && (string)x["EDIT_STATUS"] == TableRowStatus.DELETED.ToString()).OrderBy(y => y["ID"]);
            dtSourceInterim = new DataTable();
            dtSourceInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtOriginalTable.Clone();
            for (int i = 0; i < dtSourceInterim.Rows.Count; i++)
            {
                try
                {
                    adapterQuestionCategory.DeleteQuery(dtSourceInterim.Rows[i]["ID"].ToString().Trim());
                }
                catch (SqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 547:
                            ShowError("ID:" + dtSourceInterim.Rows[i]["ID"].ToString().Trim() + dtSourceInterim.Rows[i]["名稱"].ToString().Trim() + " 已連結至其他資料，不可刪除");
                            break;
                        default:
                            ShowError(401);
                            break;
                    }
                }
            }
            dtQuestionCategorySource = adapterQuestionCategory.GetData();
            gvQuestionCategory.DataSource = dtQuestionCategorySource;            
            tbcManagement.Enabled = true;
            questionCategoryTabMode = FunctionMode.HASRECORD;
            LoadControlStatus(currentTabPage);
            txtQuestionCategoryTabMemo.Text += DateTime.Now.ToString() + " 資料更新完成" + Environment.NewLine;
        }
        private void btnQuestionCategoryCancel_Click(object sender, EventArgs e)
        {
            isCancel = true;
            if (gvQuestionCategory.Rows[gvQuestionCategory.Rows.Count - 1].IsNewRow)
            {
                gvQuestionCategory.Rows.RemoveAt(gvQuestionCategory.Rows.Count - 1);
            }
            dtQuestionCategorySource = adapterQuestionCategory.GetData();
            gvQuestionCategory.DataSource = dtQuestionCategorySource;
            questionCategoryTabMode = FunctionMode.HASRECORD;
            LoadControlStatus(currentTabPage);
            isCancel = false;
            txtQuestionCategoryTabMemo.Text += DateTime.Now.ToString() + " 資料更新取消" + Environment.NewLine;
        }
        #endregion

        #region 問題建立 Tab Method and Events
        private void gvQuestion_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!isCancel)
            {
                if (String.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    ShowError(101);
                    e.Cancel = true;
                }
                else if (e.ColumnIndex == 0)
                {
                    int result;
                    if (!int.TryParse(e.FormattedValue.ToString(), out result))
                    {
                        ShowError(102);
                        e.Cancel = true;
                    }
                }
            }
        }
        private void gvQuestion_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!isCancel)
            {
                foreach (DataGridViewCell c in gvQuestion.Rows[e.RowIndex].Cells)
                {
                    if (String.IsNullOrWhiteSpace(c.EditedFormattedValue.ToString()))
                    {
                        ShowError(201);
                        e.Cancel = true;
                        break;
                    }
                }
            }
        }
        private void btnQuestionEdit_Click(object sender, EventArgs e)
        {
            questionTabMode = FunctionMode.EDIT;
            LoadControlStatus(currentTabPage);
            if (gvQuestion.Rows.Count > 0)
            {
                gvQuestionCategory.CurrentCell = gvQuestionCategory.Rows[0].Cells[0];
            }
        }
        private void btnQuestionCancel_Click(object sender, EventArgs e)
        {
            isCancel = true;
            if (gvQuestion.Rows[gvQuestionCategory.Rows.Count - 1].IsNewRow)
            {
                gvQuestion.Rows.RemoveAt(gvQuestionCategory.Rows.Count - 1);
            }
            dtQuestionSource = adapterQuestion.GetData();
            gvQuestion.DataSource = dtQuestionSource;
            questionTabMode = FunctionMode.HASRECORD;
            LoadControlStatus(currentTabPage);
            txtQuestionTabMemo.Text += DateTime.Now.ToString() + " 資料更新取消" + Environment.NewLine;
            isCancel = false;
        }       

        private void gvQuestion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {

                if (gvQuestion.CurrentRow.Index == gvQuestion.Rows.Count - 1)
                {
                    foreach (DataGridViewCell c in gvQuestion.CurrentRow.Cells)
                    {
                        if (String.IsNullOrWhiteSpace(c.EditedFormattedValue.ToString()))
                        {
                            ShowError(201);
                            e.Handled = true;
                            break;
                        }
                    }
                    if (!e.Handled)
                    {
                        DataRow newRow = dtQuestionSource.NewRow();
                        newRow["ID"] = (Convert.ToInt16(gvQuestion.CurrentRow.Cells[0].EditedFormattedValue) + 1).ToString();
                        dtQuestionSource.Rows.Add(newRow);
                        gvQuestion.DataSource = dtQuestionSource;
                        if (gvQuestion.Rows.Count > 1 && gvQuestion.Enabled == true)
                        {
                            gvQuestion.CurrentCell = gvQuestion.Rows[gvQuestion.CurrentRow.Index + 1].Cells[0];
                        }
                    }
                }
            }
        }
        private void btnQuestionSave_Click(object sender, EventArgs e)
        {
            DataTable dtOriginalTable = adapterQuestion.GetData();
            tbcManagement.Enabled = false;
            gvQuestion.DataSource = null;
            CompareTables(dtOriginalTable, dtQuestionSource);
            var tempRow = dtQuestionSource.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted && (string)x["EDIT_STATUS"] == TableRowStatus.EDITED.ToString()).OrderBy(y => y["ID"]);
            DataTable dtSourceInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtQuestionSource.Clone();
            for (int i = 0; i < dtSourceInterim.Rows.Count; i++)
            {
                adapterQuestion.UpdateQuery(UserName, dtSourceInterim.Rows[i]["問題"].ToString().Trim(), dtSourceInterim.Rows[i]["分類"].ToString(), dtSourceInterim.Rows[i]["使用中"].ToString(), dtSourceInterim.Rows[i]["全體共用"].ToString(), Convert.ToInt16(dtSourceInterim.Rows[i]["ID"].ToString()));
            }
            tempRow = dtQuestionSource.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted && (string)x["EDIT_STATUS"] == TableRowStatus.NEW.ToString()).OrderBy(y => y["ID"]);
            dtSourceInterim = new DataTable();
            dtSourceInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtQuestionSource.Clone();
            for (int i = 0; i < dtSourceInterim.Rows.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(dtSourceInterim.Rows[i]["使用中"].ToString()))
                {
                    dtSourceInterim.Rows[i]["使用中"] = "0";
                }
                if (String.IsNullOrWhiteSpace(dtSourceInterim.Rows[i]["全體共用"].ToString()))
                {
                    dtSourceInterim.Rows[i]["全體共用"] = "0";
                }
                adapterQuestion.InsertQuery(UserName, Convert.ToInt16(dtSourceInterim.Rows[i]["ID"].ToString()), dtSourceInterim.Rows[i]["問題"].ToString().Trim(), dtSourceInterim.Rows[i]["分類"].ToString(), dtSourceInterim.Rows[i]["使用中"].ToString(), dtSourceInterim.Rows[i]["全體共用"].ToString());
            }
            tempRow = dtOriginalTable.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted && (string)x["EDIT_STATUS"] == TableRowStatus.DELETED.ToString()).OrderBy(y => y["ID"]);
            dtSourceInterim = new DataTable();
            dtSourceInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtOriginalTable.Clone();
            for (int i = 0; i < dtSourceInterim.Rows.Count; i++)
            {
                try
                {
                    adapterQuestion.DeleteQuery(Convert.ToInt16(dtSourceInterim.Rows[i]["ID"].ToString()));
                }
                catch (SqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 547:
                            ShowError("ID:" + dtSourceInterim.Rows[i]["ID"].ToString().Trim() + dtSourceInterim.Rows[i]["NAME"].ToString().Trim() + " 已連結至其他資料，不可刪除");
                            break;
                        default:
                            ShowError(401);
                            break;
                    }
                }
            }
            dtQuestionSource = adapterQuestion.GetData();
            gvQuestion.DataSource = dtQuestionSource;
            tbcManagement.Enabled = true;
            questionTabMode = FunctionMode.HASRECORD;
            txtQuestionTabMemo.Text += DateTime.Now.ToString() + " 資料更新完成" + Environment.NewLine;
            LoadControlStatus(currentTabPage);
        }
        #endregion

        #region 評核人員分配 Tab Metho and Events
        /*這邊有個重點，自評的分配與調整將會自動於背景進行，以ERP中在職者為依據進行新增以及編輯(使已離職者INACTIVE)*/
        private void LoadgvPersonnelAssignment()
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = ";WITH"
                            + " ASSIGNMENT"
                            + " AS"
                            + " (SELECT *"
                            + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
                            + " WHERE [YEAR]=@YEAR"
                            + " )"
                            + " SELECT COALESCE(ASSIGN.[YEAR],@YEAR) '年份'"
                            + " ,LTRIM(RTRIM(MV.MV001)) + ' ' + LTRIM(RTRIM(MV.MV002)) '受評者'"
                            + " ,COALESCE(LTRIM(RTRIM(ASSIGN.ASSESSOR_ID)) + ' ' + LTRIM(RTRIM(MVASSESSOR.MV002)),'') '評核者'"
                            + " ,COALESCE([TYPE].NAME,'') '評核類型名稱'"
                            + " FROM NZ.dbo.CMSMV MV"
                            + " LEFT JOIN ASSIGNMENT ASSIGN ON MV.MV001=ASSIGN.ASSESSED_ID"
                            + " LEFT JOIN NZ.dbo.CMSMV MVASSESSOR ON ASSIGN.ASSESSOR_ID=MVASSESSOR.MV001"
                            + " LEFT JOIN HR360_ASSESSMENTPERSONNEL_TYPE_A [TYPE] ON ASSIGN.ASSESS_TYPE=[TYPE].ID"
                            + " WHERE "
                            + " (MV.MV022=''"
                            + " OR MV.MV022 > @YEAR+'1232')"
                            + " AND MV.MV021 < @YEAR+'1232'"
                            + " AND MV.MV001 NOT LIKE 'PT%'"
                            + " AND MV.MV001<>'0000'"
                            + " AND MV.MV001<>'0006'"
                            + " AND MV.MV001<>'0007'"
                            + " AND MV.MV001<>'0098'"
                            + " ORDER BY MV.MV001";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@YEAR", cbxPersonnelAssignmentYear.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dtPersonnelAssignmentSource = new DataTable();
                da.Fill(dtPersonnelAssignmentSource);
            }
            gvPersonnelAssignment.DataSource = dtPersonnelAssignmentSource;
        }

        private void cbxPersonnelAssignmentYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadgvPersonnelAssignment();
        }        

        private void btnPersonnelAssignmentEdit_Click(object sender, EventArgs e)
        {
            personnelAssignmentTabMode = FunctionMode.EDIT;
            LoadControlStatus(currentTabPage);
            if (gvPersonnelAssignment.Rows.Count > 0)
            {
                gvQuestionCategory.CurrentCell = gvQuestionCategory.Rows[0].Cells[0];
            }
        }       
        #endregion
    }
}
