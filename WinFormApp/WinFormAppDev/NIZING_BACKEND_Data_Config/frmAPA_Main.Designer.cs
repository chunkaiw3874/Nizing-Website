namespace NIZING_BACKEND_Data_Config
{
    partial class frmAPA_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tbcManagement = new System.Windows.Forms.TabControl();
            this.tbpQuestionCategory = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuestionCategorySave = new System.Windows.Forms.Button();
            this.gvQuestionCategory = new System.Windows.Forms.DataGridView();
            this.btnQuestionCategoryEdit = new System.Windows.Forms.Button();
            this.tbpQuestion = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuestionCancel = new System.Windows.Forms.Button();
            this.btnQuestionSave = new System.Windows.Forms.Button();
            this.gvQuestion = new System.Windows.Forms.DataGridView();
            this.txtQuestionTest = new System.Windows.Forms.TextBox();
            this.btnQuestionEdit = new System.Windows.Forms.Button();
            this.dsAPA_Question = new NIZING_BACKEND_Data_Config.dsAPA_Question();
            this.hR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter = new NIZING_BACKEND_Data_Config.dsAPA_QuestionTableAdapters.HR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter();
            this.btnQuestionCategoryCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbcManagement.SuspendLayout();
            this.tbpQuestionCategory.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuestionCategory)).BeginInit();
            this.tbpQuestion.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAPA_Question)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnLogout, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbcManagement, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.061224F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96.93877F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1184, 862);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.CausesValidation = false;
            this.btnLogout.Location = new System.Drawing.Point(1084, 0);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 26);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "登出";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // tbcManagement
            // 
            this.tbcManagement.Controls.Add(this.tbpQuestionCategory);
            this.tbcManagement.Controls.Add(this.tbpQuestion);
            this.tbcManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcManagement.Location = new System.Drawing.Point(0, 26);
            this.tbcManagement.Margin = new System.Windows.Forms.Padding(0);
            this.tbcManagement.Name = "tbcManagement";
            this.tbcManagement.SelectedIndex = 0;
            this.tbcManagement.Size = new System.Drawing.Size(1184, 836);
            this.tbcManagement.TabIndex = 1;
            this.tbcManagement.SelectedIndexChanged += new System.EventHandler(this.tbcManagement_SelectedIndexChanged);
            // 
            // tbpQuestionCategory
            // 
            this.tbpQuestionCategory.CausesValidation = false;
            this.tbpQuestionCategory.Controls.Add(this.tableLayoutPanel2);
            this.tbpQuestionCategory.Location = new System.Drawing.Point(4, 22);
            this.tbpQuestionCategory.Name = "tbpQuestionCategory";
            this.tbpQuestionCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tbpQuestionCategory.Size = new System.Drawing.Size(1176, 810);
            this.tbpQuestionCategory.TabIndex = 0;
            this.tbpQuestionCategory.Text = "問題分類建立";
            this.tbpQuestionCategory.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CausesValidation = false;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.gvQuestionCategory, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnQuestionCategoryEdit, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1170, 804);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.CausesValidation = false;
            this.flowLayoutPanel1.Controls.Add(this.btnQuestionCategoryCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnQuestionCategorySave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 774);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1168, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnQuestionCategorySave
            // 
            this.btnQuestionCategorySave.Enabled = false;
            this.btnQuestionCategorySave.Location = new System.Drawing.Point(1009, 3);
            this.btnQuestionCategorySave.Name = "btnQuestionCategorySave";
            this.btnQuestionCategorySave.Size = new System.Drawing.Size(75, 23);
            this.btnQuestionCategorySave.TabIndex = 1;
            this.btnQuestionCategorySave.Text = "儲存";
            this.btnQuestionCategorySave.UseVisualStyleBackColor = true;
            this.btnQuestionCategorySave.Click += new System.EventHandler(this.btnQuestionCategorySave_Click);
            // 
            // gvQuestionCategory
            // 
            this.gvQuestionCategory.AllowUserToAddRows = false;
            this.gvQuestionCategory.AllowUserToResizeRows = false;
            this.gvQuestionCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvQuestionCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvQuestionCategory.Location = new System.Drawing.Point(4, 34);
            this.gvQuestionCategory.MultiSelect = false;
            this.gvQuestionCategory.Name = "gvQuestionCategory";
            this.gvQuestionCategory.RowTemplate.Height = 24;
            this.gvQuestionCategory.Size = new System.Drawing.Size(1162, 736);
            this.gvQuestionCategory.TabIndex = 1;
            this.gvQuestionCategory.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvQuestionCategory_CellValidating);
            this.gvQuestionCategory.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvQuestionCategory_DataBindingComplete);
            this.gvQuestionCategory.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gvQuestionCategory_RowValidating);
            this.gvQuestionCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvQuestionCategory_KeyDown);
            // 
            // btnQuestionCategoryEdit
            // 
            this.btnQuestionCategoryEdit.Location = new System.Drawing.Point(4, 4);
            this.btnQuestionCategoryEdit.Name = "btnQuestionCategoryEdit";
            this.btnQuestionCategoryEdit.Size = new System.Drawing.Size(75, 23);
            this.btnQuestionCategoryEdit.TabIndex = 3;
            this.btnQuestionCategoryEdit.Text = "編輯";
            this.btnQuestionCategoryEdit.UseVisualStyleBackColor = true;
            this.btnQuestionCategoryEdit.Click += new System.EventHandler(this.btnQuestionCategoryEdit_Click);
            // 
            // tbpQuestion
            // 
            this.tbpQuestion.Controls.Add(this.tableLayoutPanel3);
            this.tbpQuestion.Location = new System.Drawing.Point(4, 22);
            this.tbpQuestion.Name = "tbpQuestion";
            this.tbpQuestion.Padding = new System.Windows.Forms.Padding(3);
            this.tbpQuestion.Size = new System.Drawing.Size(1176, 810);
            this.tbpQuestion.TabIndex = 1;
            this.tbpQuestion.Text = "問題建立";
            this.tbpQuestion.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.gvQuestion, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtQuestionTest, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.btnQuestionEdit, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1170, 804);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnQuestionCancel);
            this.flowLayoutPanel2.Controls.Add(this.btnQuestionSave);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1, 673);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1168, 29);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btnQuestionCancel
            // 
            this.btnQuestionCancel.Enabled = false;
            this.btnQuestionCancel.Location = new System.Drawing.Point(1090, 3);
            this.btnQuestionCancel.Name = "btnQuestionCancel";
            this.btnQuestionCancel.Size = new System.Drawing.Size(75, 23);
            this.btnQuestionCancel.TabIndex = 0;
            this.btnQuestionCancel.Text = "取消";
            this.btnQuestionCancel.UseVisualStyleBackColor = true;
            // 
            // btnQuestionSave
            // 
            this.btnQuestionSave.Enabled = false;
            this.btnQuestionSave.Location = new System.Drawing.Point(1009, 3);
            this.btnQuestionSave.Name = "btnQuestionSave";
            this.btnQuestionSave.Size = new System.Drawing.Size(75, 23);
            this.btnQuestionSave.TabIndex = 1;
            this.btnQuestionSave.Text = "儲存";
            this.btnQuestionSave.UseVisualStyleBackColor = true;
            // 
            // gvQuestion
            // 
            this.gvQuestion.AllowUserToAddRows = false;
            this.gvQuestion.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvQuestion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gvQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvQuestion.Location = new System.Drawing.Point(4, 34);
            this.gvQuestion.MultiSelect = false;
            this.gvQuestion.Name = "gvQuestion";
            this.gvQuestion.RowTemplate.Height = 24;
            this.gvQuestion.Size = new System.Drawing.Size(1162, 635);
            this.gvQuestion.TabIndex = 1;
            this.gvQuestion.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvQuestion_DataBindingComplete);
            // 
            // txtQuestionTest
            // 
            this.txtQuestionTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuestionTest.Location = new System.Drawing.Point(4, 706);
            this.txtQuestionTest.Multiline = true;
            this.txtQuestionTest.Name = "txtQuestionTest";
            this.txtQuestionTest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuestionTest.Size = new System.Drawing.Size(1162, 94);
            this.txtQuestionTest.TabIndex = 2;
            // 
            // btnQuestionEdit
            // 
            this.btnQuestionEdit.Location = new System.Drawing.Point(4, 4);
            this.btnQuestionEdit.Name = "btnQuestionEdit";
            this.btnQuestionEdit.Size = new System.Drawing.Size(75, 23);
            this.btnQuestionEdit.TabIndex = 3;
            this.btnQuestionEdit.Text = "編輯";
            this.btnQuestionEdit.UseVisualStyleBackColor = true;
            this.btnQuestionEdit.Click += new System.EventHandler(this.btnQuestionEdit_Click);
            // 
            // dsAPA_Question
            // 
            this.dsAPA_Question.DataSetName = "dsAPA_Question";
            this.dsAPA_Question.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter
            // 
            this.hR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter.ClearBeforeFill = true;
            // 
            // btnQuestionCategoryCancel
            // 
            this.btnQuestionCategoryCancel.CausesValidation = false;
            this.btnQuestionCategoryCancel.Enabled = false;
            this.btnQuestionCategoryCancel.Location = new System.Drawing.Point(1090, 3);
            this.btnQuestionCategoryCancel.Name = "btnQuestionCategoryCancel";
            this.btnQuestionCategoryCancel.Size = new System.Drawing.Size(75, 23);
            this.btnQuestionCategoryCancel.TabIndex = 0;
            this.btnQuestionCategoryCancel.Text = "取消";
            this.btnQuestionCategoryCancel.UseVisualStyleBackColor = true;
            this.btnQuestionCategoryCancel.Click += new System.EventHandler(this.btnQuestionCategoryCancel_Click);
            // 
            // frmAPA_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 862);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmAPA_Main";
            this.Text = "frmAPA_Main";
            this.Load += new System.EventHandler(this.frmAPA_Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tbcManagement.ResumeLayout(false);
            this.tbpQuestionCategory.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvQuestionCategory)).EndInit();
            this.tbpQuestion.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAPA_Question)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TabControl tbcManagement;
        private System.Windows.Forms.TabPage tbpQuestionCategory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage tbpQuestion;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnQuestionCategorySave;
        private System.Windows.Forms.DataGridView gvQuestionCategory;
        private dsAPA_Question dsAPA_Question;
        private dsAPA_QuestionTableAdapters.HR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter hR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter;
        private System.Windows.Forms.Button btnQuestionCategoryEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnQuestionCancel;
        private System.Windows.Forms.Button btnQuestionSave;
        private System.Windows.Forms.DataGridView gvQuestion;
        private System.Windows.Forms.TextBox txtQuestionTest;
        private System.Windows.Forms.Button btnQuestionEdit;
        private System.Windows.Forms.Button btnQuestionCategoryCancel;
    }
}