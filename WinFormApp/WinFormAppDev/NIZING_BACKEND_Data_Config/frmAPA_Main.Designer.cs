﻿namespace NIZING_BACKEND_Data_Config
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tbcManagement = new System.Windows.Forms.TabControl();
            this.tbpQuestionCategory = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtQuestionCategoryTabMemo = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuestionCategoryCancel = new System.Windows.Forms.Button();
            this.btnQuestionCategorySave = new System.Windows.Forms.Button();
            this.gvQuestionCategory = new System.Windows.Forms.DataGridView();
            this.btnQuestionCategoryEdit = new System.Windows.Forms.Button();
            this.tbpQuestion = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuestionCancel = new System.Windows.Forms.Button();
            this.btnQuestionSave = new System.Windows.Forms.Button();
            this.gvQuestion = new System.Windows.Forms.DataGridView();
            this.ctxmsQuestion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmQuestionAssignment = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQuestionEdit = new System.Windows.Forms.Button();
            this.txtQuestionTabMemo = new System.Windows.Forms.RichTextBox();
            this.tbpQuestionAssignment = new System.Windows.Forms.TabPage();
            this.tbpPersonnelAssignment = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPersonnelAssignmentCancel = new System.Windows.Forms.Button();
            this.btnPersonnelAssignmentSave = new System.Windows.Forms.Button();
            this.gvPersonnelAssignment = new System.Windows.Forms.DataGridView();
            this.txtPersonnelAssignmentTabMemo = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbxPersonnelAssignmentYear = new System.Windows.Forms.ComboBox();
            this.btnPersonnelAssignmentEdit = new System.Windows.Forms.Button();
            this.dsAPA_Question = new NIZING_BACKEND_Data_Config.dsAPA_Question();
            this.hR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter = new NIZING_BACKEND_Data_Config.dsAPA_QuestionTableAdapters.HR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtQuestionAssignmentTabMemo = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuestionAssignmentCancel = new System.Windows.Forms.Button();
            this.btnQuestionAssignmentSave = new System.Windows.Forms.Button();
            this.lblQuestionAssignmentQuestionCategory = new System.Windows.Forms.Label();
            this.txtQuestionAssignmentQuestionBody = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lvQuestionAssignmentDept = new System.Windows.Forms.ListView();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbxQuestionAssignmentDept = new System.Windows.Forms.ComboBox();
            this.btnQuestionAssignmentAddDept = new System.Windows.Forms.Button();
            this.btnQuestionAssignmentRemoveDept = new System.Windows.Forms.Button();
            this.lvQuestionAssignmentEmp = new System.Windows.Forms.ListView();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbxQuestionAssignmentEmp = new System.Windows.Forms.ComboBox();
            this.btnQuestionAssignmentAddEmp = new System.Windows.Forms.Button();
            this.btnQuestionAssignmentRemoveEmp = new System.Windows.Forms.Button();
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
            this.ctxmsQuestion.SuspendLayout();
            this.tbpQuestionAssignment.SuspendLayout();
            this.tbpPersonnelAssignment.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPersonnelAssignment)).BeginInit();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsAPA_Question)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
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
            this.tbcManagement.Controls.Add(this.tbpQuestionAssignment);
            this.tbcManagement.Controls.Add(this.tbpPersonnelAssignment);
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
            this.tableLayoutPanel2.Controls.Add(this.txtQuestionCategoryTabMemo, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.gvQuestionCategory, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnQuestionCategoryEdit, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1170, 804);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtQuestionCategoryTabMemo
            // 
            this.txtQuestionCategoryTabMemo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuestionCategoryTabMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuestionCategoryTabMemo.Location = new System.Drawing.Point(4, 706);
            this.txtQuestionCategoryTabMemo.Multiline = true;
            this.txtQuestionCategoryTabMemo.Name = "txtQuestionCategoryTabMemo";
            this.txtQuestionCategoryTabMemo.ReadOnly = true;
            this.txtQuestionCategoryTabMemo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuestionCategoryTabMemo.Size = new System.Drawing.Size(1162, 94);
            this.txtQuestionCategoryTabMemo.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.CausesValidation = false;
            this.flowLayoutPanel1.Controls.Add(this.btnQuestionCategoryCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnQuestionCategorySave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 673);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1168, 29);
            this.flowLayoutPanel1.TabIndex = 0;
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
            this.gvQuestionCategory.Size = new System.Drawing.Size(1162, 635);
            this.gvQuestionCategory.TabIndex = 1;
            this.gvQuestionCategory.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvQuestionCategory_CellValidating);
            this.gvQuestionCategory.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gv_DataBindingComplete);
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
            this.tableLayoutPanel3.Controls.Add(this.btnQuestionEdit, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtQuestionTabMemo, 0, 3);
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
            this.flowLayoutPanel2.CausesValidation = false;
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
            this.btnQuestionCancel.CausesValidation = false;
            this.btnQuestionCancel.Enabled = false;
            this.btnQuestionCancel.Location = new System.Drawing.Point(1090, 3);
            this.btnQuestionCancel.Name = "btnQuestionCancel";
            this.btnQuestionCancel.Size = new System.Drawing.Size(75, 23);
            this.btnQuestionCancel.TabIndex = 0;
            this.btnQuestionCancel.Text = "取消";
            this.btnQuestionCancel.UseVisualStyleBackColor = true;
            this.btnQuestionCancel.Click += new System.EventHandler(this.btnQuestionCancel_Click);
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
            this.btnQuestionSave.Click += new System.EventHandler(this.btnQuestionSave_Click);
            // 
            // gvQuestion
            // 
            this.gvQuestion.AllowUserToAddRows = false;
            this.gvQuestion.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvQuestion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvQuestion.ContextMenuStrip = this.ctxmsQuestion;
            this.gvQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvQuestion.Location = new System.Drawing.Point(4, 34);
            this.gvQuestion.MultiSelect = false;
            this.gvQuestion.Name = "gvQuestion";
            this.gvQuestion.RowTemplate.Height = 24;
            this.gvQuestion.Size = new System.Drawing.Size(1162, 635);
            this.gvQuestion.TabIndex = 1;
            this.gvQuestion.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvQuestion_CellValidating);
            this.gvQuestion.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gv_DataBindingComplete);
            this.gvQuestion.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gvQuestion_RowValidating);
            this.gvQuestion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvQuestion_KeyDown);
            this.gvQuestion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvQuestion_MouseDown);
            // 
            // ctxmsQuestion
            // 
            this.ctxmsQuestion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmQuestionAssignment});
            this.ctxmsQuestion.Name = "ctxmsQuestion";
            this.ctxmsQuestion.Size = new System.Drawing.Size(125, 26);
            // 
            // tsmQuestionAssignment
            // 
            this.tsmQuestionAssignment.Name = "tsmQuestionAssignment";
            this.tsmQuestionAssignment.Size = new System.Drawing.Size(124, 22);
            this.tsmQuestionAssignment.Text = "問題分配";
            this.tsmQuestionAssignment.Click += new System.EventHandler(this.tsmQuestionAssignment_Click);
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
            // txtQuestionTabMemo
            // 
            this.txtQuestionTabMemo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuestionTabMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuestionTabMemo.Location = new System.Drawing.Point(4, 706);
            this.txtQuestionTabMemo.Name = "txtQuestionTabMemo";
            this.txtQuestionTabMemo.ReadOnly = true;
            this.txtQuestionTabMemo.Size = new System.Drawing.Size(1162, 94);
            this.txtQuestionTabMemo.TabIndex = 4;
            this.txtQuestionTabMemo.Text = "";
            // 
            // tbpQuestionAssignment
            // 
            this.tbpQuestionAssignment.Controls.Add(this.tableLayoutPanel5);
            this.tbpQuestionAssignment.Location = new System.Drawing.Point(4, 22);
            this.tbpQuestionAssignment.Name = "tbpQuestionAssignment";
            this.tbpQuestionAssignment.Padding = new System.Windows.Forms.Padding(3);
            this.tbpQuestionAssignment.Size = new System.Drawing.Size(1176, 810);
            this.tbpQuestionAssignment.TabIndex = 3;
            this.tbpQuestionAssignment.Text = "問題分配";
            this.tbpQuestionAssignment.UseVisualStyleBackColor = true;
            // 
            // tbpPersonnelAssignment
            // 
            this.tbpPersonnelAssignment.Controls.Add(this.tableLayoutPanel4);
            this.tbpPersonnelAssignment.Location = new System.Drawing.Point(4, 22);
            this.tbpPersonnelAssignment.Name = "tbpPersonnelAssignment";
            this.tbpPersonnelAssignment.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPersonnelAssignment.Size = new System.Drawing.Size(1176, 810);
            this.tbpPersonnelAssignment.TabIndex = 2;
            this.tbpPersonnelAssignment.Text = "評核人員分配";
            this.tbpPersonnelAssignment.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel3, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.gvPersonnelAssignment, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtPersonnelAssignmentTabMemo, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel4, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1170, 804);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.CausesValidation = false;
            this.flowLayoutPanel3.Controls.Add(this.btnPersonnelAssignmentCancel);
            this.flowLayoutPanel3.Controls.Add(this.btnPersonnelAssignmentSave);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(1, 673);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1168, 29);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // btnPersonnelAssignmentCancel
            // 
            this.btnPersonnelAssignmentCancel.CausesValidation = false;
            this.btnPersonnelAssignmentCancel.Enabled = false;
            this.btnPersonnelAssignmentCancel.Location = new System.Drawing.Point(1090, 3);
            this.btnPersonnelAssignmentCancel.Name = "btnPersonnelAssignmentCancel";
            this.btnPersonnelAssignmentCancel.Size = new System.Drawing.Size(75, 23);
            this.btnPersonnelAssignmentCancel.TabIndex = 0;
            this.btnPersonnelAssignmentCancel.Text = "取消";
            this.btnPersonnelAssignmentCancel.UseVisualStyleBackColor = true;
            this.btnPersonnelAssignmentCancel.Click += new System.EventHandler(this.btnPersonnelAssignmentCancel_Click);
            // 
            // btnPersonnelAssignmentSave
            // 
            this.btnPersonnelAssignmentSave.Enabled = false;
            this.btnPersonnelAssignmentSave.Location = new System.Drawing.Point(1009, 3);
            this.btnPersonnelAssignmentSave.Name = "btnPersonnelAssignmentSave";
            this.btnPersonnelAssignmentSave.Size = new System.Drawing.Size(75, 23);
            this.btnPersonnelAssignmentSave.TabIndex = 1;
            this.btnPersonnelAssignmentSave.Text = "儲存";
            this.btnPersonnelAssignmentSave.UseVisualStyleBackColor = true;
            this.btnPersonnelAssignmentSave.Click += new System.EventHandler(this.btnPersonnelAssignmentSave_Click);
            // 
            // gvPersonnelAssignment
            // 
            this.gvPersonnelAssignment.AllowUserToAddRows = false;
            this.gvPersonnelAssignment.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvPersonnelAssignment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvPersonnelAssignment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPersonnelAssignment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvPersonnelAssignment.Location = new System.Drawing.Point(4, 34);
            this.gvPersonnelAssignment.MultiSelect = false;
            this.gvPersonnelAssignment.Name = "gvPersonnelAssignment";
            this.gvPersonnelAssignment.RowTemplate.Height = 24;
            this.gvPersonnelAssignment.Size = new System.Drawing.Size(1162, 635);
            this.gvPersonnelAssignment.TabIndex = 1;
            this.gvPersonnelAssignment.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gv_DataBindingComplete);
            // 
            // txtPersonnelAssignmentTabMemo
            // 
            this.txtPersonnelAssignmentTabMemo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPersonnelAssignmentTabMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPersonnelAssignmentTabMemo.Location = new System.Drawing.Point(4, 706);
            this.txtPersonnelAssignmentTabMemo.Multiline = true;
            this.txtPersonnelAssignmentTabMemo.Name = "txtPersonnelAssignmentTabMemo";
            this.txtPersonnelAssignmentTabMemo.ReadOnly = true;
            this.txtPersonnelAssignmentTabMemo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPersonnelAssignmentTabMemo.Size = new System.Drawing.Size(1162, 94);
            this.txtPersonnelAssignmentTabMemo.TabIndex = 2;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel4.Controls.Add(this.cbxPersonnelAssignmentYear);
            this.flowLayoutPanel4.Controls.Add(this.btnPersonnelAssignmentEdit);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(1168, 29);
            this.flowLayoutPanel4.TabIndex = 3;
            // 
            // cbxPersonnelAssignmentYear
            // 
            this.cbxPersonnelAssignmentYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPersonnelAssignmentYear.FormattingEnabled = true;
            this.cbxPersonnelAssignmentYear.Location = new System.Drawing.Point(3, 3);
            this.cbxPersonnelAssignmentYear.Name = "cbxPersonnelAssignmentYear";
            this.cbxPersonnelAssignmentYear.Size = new System.Drawing.Size(121, 20);
            this.cbxPersonnelAssignmentYear.TabIndex = 0;
            this.cbxPersonnelAssignmentYear.SelectedIndexChanged += new System.EventHandler(this.cbxPersonnelAssignmentYear_SelectedIndexChanged);
            // 
            // btnPersonnelAssignmentEdit
            // 
            this.btnPersonnelAssignmentEdit.Location = new System.Drawing.Point(130, 3);
            this.btnPersonnelAssignmentEdit.Name = "btnPersonnelAssignmentEdit";
            this.btnPersonnelAssignmentEdit.Size = new System.Drawing.Size(75, 23);
            this.btnPersonnelAssignmentEdit.TabIndex = 3;
            this.btnPersonnelAssignmentEdit.Text = "編輯";
            this.btnPersonnelAssignmentEdit.UseVisualStyleBackColor = true;
            this.btnPersonnelAssignmentEdit.Click += new System.EventHandler(this.btnPersonnelAssignmentEdit_Click);
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
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.txtQuestionAssignmentTabMemo, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel5, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.lblQuestionAssignmentQuestionCategory, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtQuestionAssignmentQuestionBody, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1170, 804);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // txtQuestionAssignmentTabMemo
            // 
            this.txtQuestionAssignmentTabMemo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuestionAssignmentTabMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuestionAssignmentTabMemo.Location = new System.Drawing.Point(4, 705);
            this.txtQuestionAssignmentTabMemo.Name = "txtQuestionAssignmentTabMemo";
            this.txtQuestionAssignmentTabMemo.ReadOnly = true;
            this.txtQuestionAssignmentTabMemo.Size = new System.Drawing.Size(1162, 95);
            this.txtQuestionAssignmentTabMemo.TabIndex = 0;
            this.txtQuestionAssignmentTabMemo.Text = "";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.btnQuestionAssignmentCancel);
            this.flowLayoutPanel5.Controls.Add(this.btnQuestionAssignmentSave);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(1, 672);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(1168, 29);
            this.flowLayoutPanel5.TabIndex = 1;
            // 
            // btnQuestionAssignmentCancel
            // 
            this.btnQuestionAssignmentCancel.Location = new System.Drawing.Point(1090, 3);
            this.btnQuestionAssignmentCancel.Name = "btnQuestionAssignmentCancel";
            this.btnQuestionAssignmentCancel.Size = new System.Drawing.Size(75, 23);
            this.btnQuestionAssignmentCancel.TabIndex = 0;
            this.btnQuestionAssignmentCancel.Text = "button1";
            this.btnQuestionAssignmentCancel.UseVisualStyleBackColor = true;
            // 
            // btnQuestionAssignmentSave
            // 
            this.btnQuestionAssignmentSave.Location = new System.Drawing.Point(1009, 3);
            this.btnQuestionAssignmentSave.Name = "btnQuestionAssignmentSave";
            this.btnQuestionAssignmentSave.Size = new System.Drawing.Size(75, 23);
            this.btnQuestionAssignmentSave.TabIndex = 1;
            this.btnQuestionAssignmentSave.Text = "button2";
            this.btnQuestionAssignmentSave.UseVisualStyleBackColor = true;
            // 
            // lblQuestionAssignmentQuestionCategory
            // 
            this.lblQuestionAssignmentQuestionCategory.AutoSize = true;
            this.lblQuestionAssignmentQuestionCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuestionAssignmentQuestionCategory.Font = new System.Drawing.Font("PMingLiU", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQuestionAssignmentQuestionCategory.Location = new System.Drawing.Point(4, 1);
            this.lblQuestionAssignmentQuestionCategory.Name = "lblQuestionAssignmentQuestionCategory";
            this.lblQuestionAssignmentQuestionCategory.Size = new System.Drawing.Size(1162, 26);
            this.lblQuestionAssignmentQuestionCategory.TabIndex = 2;
            this.lblQuestionAssignmentQuestionCategory.Text = "label1";
            // 
            // txtQuestionAssignmentQuestionBody
            // 
            this.txtQuestionAssignmentQuestionBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuestionAssignmentQuestionBody.Location = new System.Drawing.Point(4, 31);
            this.txtQuestionAssignmentQuestionBody.Multiline = true;
            this.txtQuestionAssignmentQuestionBody.Name = "txtQuestionAssignmentQuestionBody";
            this.txtQuestionAssignmentQuestionBody.ReadOnly = true;
            this.txtQuestionAssignmentQuestionBody.Size = new System.Drawing.Size(1162, 379);
            this.txtQuestionAssignmentQuestionBody.TabIndex = 3;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel6.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.lvQuestionAssignmentDept, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.flowLayoutPanel6, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.lvQuestionAssignmentEmp, 2, 1);
            this.tableLayoutPanel6.Controls.Add(this.flowLayoutPanel7, 3, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(1, 414);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1168, 257);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 16F);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(378, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "適用部門";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 16F);
            this.label3.Location = new System.Drawing.Point(587, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(378, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "適用員工";
            // 
            // lvQuestionAssignmentDept
            // 
            this.lvQuestionAssignmentDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvQuestionAssignmentDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvQuestionAssignmentDept.Location = new System.Drawing.Point(3, 25);
            this.lvQuestionAssignmentDept.Name = "lvQuestionAssignmentDept";
            this.lvQuestionAssignmentDept.Size = new System.Drawing.Size(378, 229);
            this.lvQuestionAssignmentDept.TabIndex = 2;
            this.lvQuestionAssignmentDept.UseCompatibleStateImageBehavior = false;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.cbxQuestionAssignmentDept);
            this.flowLayoutPanel6.Controls.Add(this.btnQuestionAssignmentAddDept);
            this.flowLayoutPanel6.Controls.Add(this.btnQuestionAssignmentRemoveDept);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(384, 22);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(200, 235);
            this.flowLayoutPanel6.TabIndex = 3;
            // 
            // cbxQuestionAssignmentDept
            // 
            this.cbxQuestionAssignmentDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQuestionAssignmentDept.FormattingEnabled = true;
            this.cbxQuestionAssignmentDept.Location = new System.Drawing.Point(3, 3);
            this.cbxQuestionAssignmentDept.Name = "cbxQuestionAssignmentDept";
            this.cbxQuestionAssignmentDept.Size = new System.Drawing.Size(121, 20);
            this.cbxQuestionAssignmentDept.TabIndex = 0;
            // 
            // btnQuestionAssignmentAddDept
            // 
            this.btnQuestionAssignmentAddDept.Font = new System.Drawing.Font("PMingLiU", 20F);
            this.btnQuestionAssignmentAddDept.Location = new System.Drawing.Point(3, 29);
            this.btnQuestionAssignmentAddDept.Name = "btnQuestionAssignmentAddDept";
            this.btnQuestionAssignmentAddDept.Size = new System.Drawing.Size(40, 40);
            this.btnQuestionAssignmentAddDept.TabIndex = 1;
            this.btnQuestionAssignmentAddDept.Text = "+";
            this.btnQuestionAssignmentAddDept.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuestionAssignmentAddDept.UseVisualStyleBackColor = true;
            // 
            // btnQuestionAssignmentRemoveDept
            // 
            this.btnQuestionAssignmentRemoveDept.Font = new System.Drawing.Font("PMingLiU", 20F);
            this.btnQuestionAssignmentRemoveDept.Location = new System.Drawing.Point(3, 75);
            this.btnQuestionAssignmentRemoveDept.Name = "btnQuestionAssignmentRemoveDept";
            this.btnQuestionAssignmentRemoveDept.Size = new System.Drawing.Size(40, 40);
            this.btnQuestionAssignmentRemoveDept.TabIndex = 2;
            this.btnQuestionAssignmentRemoveDept.Text = "-";
            this.btnQuestionAssignmentRemoveDept.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuestionAssignmentRemoveDept.UseVisualStyleBackColor = true;
            // 
            // lvQuestionAssignmentEmp
            // 
            this.lvQuestionAssignmentEmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvQuestionAssignmentEmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvQuestionAssignmentEmp.Location = new System.Drawing.Point(587, 25);
            this.lvQuestionAssignmentEmp.Name = "lvQuestionAssignmentEmp";
            this.lvQuestionAssignmentEmp.Size = new System.Drawing.Size(378, 229);
            this.lvQuestionAssignmentEmp.TabIndex = 4;
            this.lvQuestionAssignmentEmp.UseCompatibleStateImageBehavior = false;
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Controls.Add(this.cbxQuestionAssignmentEmp);
            this.flowLayoutPanel7.Controls.Add(this.btnQuestionAssignmentAddEmp);
            this.flowLayoutPanel7.Controls.Add(this.btnQuestionAssignmentRemoveEmp);
            this.flowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel7.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel7.Location = new System.Drawing.Point(968, 22);
            this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(200, 235);
            this.flowLayoutPanel7.TabIndex = 5;
            // 
            // cbxQuestionAssignmentEmp
            // 
            this.cbxQuestionAssignmentEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQuestionAssignmentEmp.FormattingEnabled = true;
            this.cbxQuestionAssignmentEmp.Location = new System.Drawing.Point(3, 3);
            this.cbxQuestionAssignmentEmp.Name = "cbxQuestionAssignmentEmp";
            this.cbxQuestionAssignmentEmp.Size = new System.Drawing.Size(121, 20);
            this.cbxQuestionAssignmentEmp.TabIndex = 0;
            // 
            // btnQuestionAssignmentAddEmp
            // 
            this.btnQuestionAssignmentAddEmp.Font = new System.Drawing.Font("PMingLiU", 20F);
            this.btnQuestionAssignmentAddEmp.Location = new System.Drawing.Point(3, 29);
            this.btnQuestionAssignmentAddEmp.Name = "btnQuestionAssignmentAddEmp";
            this.btnQuestionAssignmentAddEmp.Size = new System.Drawing.Size(40, 40);
            this.btnQuestionAssignmentAddEmp.TabIndex = 3;
            this.btnQuestionAssignmentAddEmp.Text = "+";
            this.btnQuestionAssignmentAddEmp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuestionAssignmentAddEmp.UseVisualStyleBackColor = true;
            // 
            // btnQuestionAssignmentRemoveEmp
            // 
            this.btnQuestionAssignmentRemoveEmp.Font = new System.Drawing.Font("PMingLiU", 20F);
            this.btnQuestionAssignmentRemoveEmp.Location = new System.Drawing.Point(3, 75);
            this.btnQuestionAssignmentRemoveEmp.Name = "btnQuestionAssignmentRemoveEmp";
            this.btnQuestionAssignmentRemoveEmp.Size = new System.Drawing.Size(40, 40);
            this.btnQuestionAssignmentRemoveEmp.TabIndex = 4;
            this.btnQuestionAssignmentRemoveEmp.Text = "-";
            this.btnQuestionAssignmentRemoveEmp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuestionAssignmentRemoveEmp.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvQuestionCategory)).EndInit();
            this.tbpQuestion.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvQuestion)).EndInit();
            this.ctxmsQuestion.ResumeLayout(false);
            this.tbpQuestionAssignment.ResumeLayout(false);
            this.tbpPersonnelAssignment.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvPersonnelAssignment)).EndInit();
            this.flowLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsAPA_Question)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel7.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnQuestionEdit;
        private System.Windows.Forms.Button btnQuestionCategoryCancel;
        private System.Windows.Forms.TabPage tbpPersonnelAssignment;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnPersonnelAssignmentCancel;
        private System.Windows.Forms.Button btnPersonnelAssignmentSave;
        private System.Windows.Forms.DataGridView gvPersonnelAssignment;
        private System.Windows.Forms.Button btnPersonnelAssignmentEdit;
        private System.Windows.Forms.TextBox txtQuestionCategoryTabMemo;
        private System.Windows.Forms.TextBox txtPersonnelAssignmentTabMemo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.ComboBox cbxPersonnelAssignmentYear;
        private System.Windows.Forms.TabPage tbpQuestionAssignment;
        private System.Windows.Forms.ContextMenuStrip ctxmsQuestion;
        private System.Windows.Forms.ToolStripMenuItem tsmQuestionAssignment;
        private System.Windows.Forms.RichTextBox txtQuestionTabMemo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.RichTextBox txtQuestionAssignmentTabMemo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Button btnQuestionAssignmentCancel;
        private System.Windows.Forms.Button btnQuestionAssignmentSave;
        private System.Windows.Forms.Label lblQuestionAssignmentQuestionCategory;
        private System.Windows.Forms.TextBox txtQuestionAssignmentQuestionBody;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvQuestionAssignmentDept;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.ComboBox cbxQuestionAssignmentDept;
        private System.Windows.Forms.Button btnQuestionAssignmentAddDept;
        private System.Windows.Forms.Button btnQuestionAssignmentRemoveDept;
        private System.Windows.Forms.ListView lvQuestionAssignmentEmp;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.ComboBox cbxQuestionAssignmentEmp;
        private System.Windows.Forms.Button btnQuestionAssignmentAddEmp;
        private System.Windows.Forms.Button btnQuestionAssignmentRemoveEmp;
    }
}