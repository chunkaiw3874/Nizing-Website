using System;
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
    public partial class frmAPA_Main : Form
    {
        List<GridviewChange> changesInData = new List<GridviewChange>();

        public frmAPA_Main()
        {
            InitializeComponent();
            txtTest.Text = "";
            foreach (DataGridViewColumn col in gvQuestionCategory.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            changesInData = new List<GridviewChange>();
        }

        //To keep track of Data edit in gridview, in order to replicate the steps for correct
        //data edit in database
        private enum GridviewAction { ADD, DELETE, EDIT };
        private class GridviewChange
        {
            private int _orderNumber;
            private GridviewAction _action;
            private int _rowNumber;

            public GridviewChange(int o, GridviewAction a, int r)
            {
                _orderNumber = o;
                _action = a;
                _rowNumber = r;
            }
            public int OrderNumber
            {
                get { return _orderNumber; }
            }
            public GridviewAction Action
            {
                get { return _action; }
            }
            public int RowNumber
            {
                get { return _rowNumber; }
            }
            public override string ToString()
            {
                return _orderNumber.ToString() + "." + _action.ToString() + " " + _rowNumber.ToString() + ";";
            }
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
        #endregion

        private void frmAPA_Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsAPA_Question.HR360_ASSESSMENTQUESTION_CATEGORY_A' table. You can move, or remove it, as needed.
            this.hR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter.Fill(this.dsAPA_Question.HR360_ASSESSMENTQUESTION_CATEGORY_A);
        }

        private void gvQuestionCategory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            changesInData.Add(new GridviewChange(changesInData.Count + 1, GridviewAction.EDIT, e.RowIndex));
            txtTest.Text += changesInData[changesInData.Count - 1].ToString() + '\n';
        }

        private void gvQuestionCategory_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            changesInData.Add(new GridviewChange(changesInData.Count + 1, GridviewAction.DELETE, e.Row.Index));
            txtTest.Text += changesInData[changesInData.Count - 1].ToString() + '\n';
        }

        private void gvQuestionCategory_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            changesInData.Add(new GridviewChange(changesInData.Count + 1, GridviewAction.ADD, e.Row.Index));
            txtTest.Text += changesInData[changesInData.Count - 1].ToString() + '\n';
        }

        private void btnQuestionCategorySave_Click(object sender, EventArgs e)
        {
            txtTest.Text = "";
        }

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

        private void gvQuestionCategory_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //txtTest.Text = "Leaving Row " + e.RowIndex.ToString() + "\r\n";

        }

        private void gvQuestionCategory_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
                
            //txtTest.Text += "Entering Row " + e.RowIndex.ToString() + "\r\n";
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
    }
}
