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
    public partial class frmAPA_Main : Form
    {
        #region Frame Universal Variable
        public string UserName { get; set; }
        private enum FunctionMode { ADD, EDIT, DELETE, SEARCH, HASRECORD, NORECORD }
        private enum TableRowStatus { DELETED, EDITED, NEW, UNCHANGED };
        int currentTabPage = 0;
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

        public frmAPA_Main()
        {
            InitializeComponent();
            #region 問題分類建立 Initialization
            foreach (DataGridViewColumn col in gvQuestionCategory.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }            
            dtQuestionCategorySource = adapterQuestionCategory.GetData();
            gvQuestionCategory.DataSource = dtQuestionCategorySource;            
            gvQuestionCategory.Columns["ID"].ReadOnly = true;
            questionCategoryTabMode = FunctionMode.HASRECORD;
            LoadControlStatus(questionCategoryTabMode);
            currentTabPage = tbcManagement.SelectedIndex;
            #endregion

            //gvQuestionCategory.Columns["NAME"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;  //change gv column to multiline
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
            if (questionCategoryTabMode == FunctionMode.ADD || questionCategoryTabMode == FunctionMode.EDIT || questionCategoryTabMode == FunctionMode.SEARCH)
            {
                tbcManagement.SelectedIndex = currentTabPage;
            }
            else
            {
                currentTabPage = tbcManagement.SelectedIndex;
            }
        }
        private void LoadControlStatus(FunctionMode mode)
        {
            if (tbcManagement.SelectedTab == tbpQuestionCategory)
            {
                if (mode == FunctionMode.HASRECORD)
                {
                    btnQuestionCategoryEdit.Enabled = true;
                    btnQuestionCategorySave.Enabled = false;
                    btnQuestionCategoryCancel.Enabled = false;
                    gvQuestionCategory.Enabled = false;
                    gvQuestionCategory.ForeColor = Color.Gray;
                }
                else if (mode == FunctionMode.EDIT)
                {
                    btnQuestionCategoryEdit.Enabled = false;
                    btnQuestionCategorySave.Enabled = true;
                    btnQuestionCategoryCancel.Enabled = true;
                    gvQuestionCategory.Enabled = true;
                    gvQuestionCategory.ForeColor = Color.Black;
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
        #endregion      

        #region 問題分類建立 Tab Method and Events
        private void gvQuestionCategory_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {            
            if (String.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
            {
                MessageBox.Show("cell cannot be empty");
                e.Cancel = true;
            }
            else if (e.ColumnIndex == 0)
            {
                int result;
                if (!int.TryParse(e.FormattedValue.ToString(), out result))
                {
                    MessageBox.Show("ID must be an integer");
                    e.Cancel = true;
                }
            }
            else if (e.ColumnIndex == 2)
            {
                decimal result;
                if (!decimal.TryParse(e.FormattedValue.ToString(), out result))
                {
                    MessageBox.Show("Weight must be a number");
                    e.Cancel = true;
                }
            }
        }
        private void gvQuestionCategory_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            foreach (DataGridViewCell c in gvQuestionCategory.Rows[e.RowIndex].Cells)
            {
                if (String.IsNullOrWhiteSpace(c.EditedFormattedValue.ToString()))
                {
                    MessageBox.Show("Row cannot contain empty cell");
                    e.Cancel = true;
                    break;
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
                            MessageBox.Show("Row cannot contain empty cell");
                            e.Handled = true;
                            break;
                        }
                    }
                    if (!e.Handled)
                    {
                        dtQuestionCategorySource.Rows.Add();
                        dtQuestionCategorySource.Rows[dtQuestionCategorySource.Rows.Count - 1][0] = (Convert.ToInt16(gvQuestionCategory.CurrentRow.Cells[0].EditedFormattedValue) + 1).ToString();
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
            LoadControlStatus(questionCategoryTabMode);
            this.Text = UserName;
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
                adapterQuestionCategory.UpdateQuery(UserName, dtSourceInterim.Rows[i]["NAME"].ToString().Trim(), dtSourceInterim.Rows[i]["WEIGHT"].ToString().Trim(), dtSourceInterim.Rows[i]["ID"].ToString().Trim());
            }
            tempRow = dtQuestionCategorySource.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted && (string)x["EDIT_STATUS"] == TableRowStatus.NEW.ToString()).OrderBy(y => y["ID"]);
            dtSourceInterim = new DataTable();
            dtSourceInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtQuestionCategorySource.Clone();
            for (int i = 0; i < dtSourceInterim.Rows.Count; i++)
            {
                adapterQuestionCategory.InsertQuery(UserName, dtSourceInterim.Rows[i]["ID"].ToString().Trim(), dtSourceInterim.Rows[i]["NAME"].ToString().Trim(), dtSourceInterim.Rows[i]["WEIGHT"].ToString().Trim());
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
                            MessageBox.Show("ID:" + dtSourceInterim.Rows[i]["ID"].ToString().Trim() + dtSourceInterim.Rows[i]["NAME"].ToString().Trim() + " 已連結至其他資料，不可刪除");
                            break;
                        default:
                            MessageBox.Show("資料刪除錯誤");
                            break;
                    }
                }
            }
            dtQuestionCategorySource = adapterQuestionCategory.GetData();
            gvQuestionCategory.DataSource = dtQuestionCategorySource;            
            tbcManagement.Enabled = true;
            questionCategoryTabMode = FunctionMode.HASRECORD;
            LoadControlStatus(questionCategoryTabMode);
        }
        private void btnQuestionCategoryCancel_Click(object sender, EventArgs e)
        {            
            dtQuestionCategorySource = adapterQuestionCategory.GetData();
            gvQuestionCategory.DataSource = dtQuestionCategorySource;
            questionCategoryTabMode = FunctionMode.HASRECORD;
            LoadControlStatus(questionCategoryTabMode);
        }
        #endregion

        #region 問題建立 Tab Method and Events

        #endregion


    }
}
