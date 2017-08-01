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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tbcManagement = new System.Windows.Forms.TabControl();
            this.tbpQuestionCategory = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuestionCategoryCancel = new System.Windows.Forms.Button();
            this.btnQuestionCategorySave = new System.Windows.Forms.Button();
            this.gvQuestionCategory = new System.Windows.Forms.DataGridView();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.btnQuestionCategoryEdit = new System.Windows.Forms.Button();
            this.tbpProductManagement = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnProductEdit = new System.Windows.Forms.Button();
            this.btnProductSync = new System.Windows.Forms.Button();
            this.btnProductSearch = new System.Windows.Forms.Button();
            this.gvProductSearch_Result = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnProductConfirm = new System.Windows.Forms.Button();
            this.btnProductCancel = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProductPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ckbProductDisplay = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProductBuffer = new System.Windows.Forms.TextBox();
            this.lblProductSubmitStatus = new System.Windows.Forms.Label();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtProductDiscount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pgbProductSyncProgress = new System.Windows.Forms.ProgressBar();
            this.lblProductSyncStatus = new System.Windows.Forms.Label();
            this.hR360ASSESSMENTQUESTIONCATEGORYABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAPAQuestionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAPA_Question = new NIZING_BACKEND_Data_Config.dsAPA_Question();
            this.hR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter = new NIZING_BACKEND_Data_Config.dsAPA_QuestionTableAdapters.HR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbcManagement.SuspendLayout();
            this.tbpQuestionCategory.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuestionCategory)).BeginInit();
            this.tbpProductManagement.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProductSearch_Result)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hR360ASSESSMENTQUESTIONCATEGORYABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAPAQuestionBindingSource)).BeginInit();
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
            this.tbcManagement.Controls.Add(this.tbpProductManagement);
            this.tbcManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcManagement.Location = new System.Drawing.Point(0, 26);
            this.tbcManagement.Margin = new System.Windows.Forms.Padding(0);
            this.tbcManagement.Name = "tbcManagement";
            this.tbcManagement.SelectedIndex = 0;
            this.tbcManagement.Size = new System.Drawing.Size(1184, 836);
            this.tbcManagement.TabIndex = 1;
            // 
            // tbpQuestionCategory
            // 
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
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.gvQuestionCategory, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtTest, 0, 3);
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
            // flowLayoutPanel1
            // 
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
            this.btnQuestionCategoryCancel.Location = new System.Drawing.Point(1090, 3);
            this.btnQuestionCategoryCancel.Name = "btnQuestionCategoryCancel";
            this.btnQuestionCategoryCancel.Size = new System.Drawing.Size(75, 23);
            this.btnQuestionCategoryCancel.TabIndex = 0;
            this.btnQuestionCategoryCancel.Text = "取消";
            this.btnQuestionCategoryCancel.UseVisualStyleBackColor = true;
            // 
            // btnQuestionCategorySave
            // 
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
            this.gvQuestionCategory.AllowUserToDeleteRows = false;
            this.gvQuestionCategory.AllowUserToResizeRows = false;
            this.gvQuestionCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvQuestionCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvQuestionCategory.Location = new System.Drawing.Point(4, 34);
            this.gvQuestionCategory.MultiSelect = false;
            this.gvQuestionCategory.Name = "gvQuestionCategory";
            this.gvQuestionCategory.RowTemplate.Height = 24;
            this.gvQuestionCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvQuestionCategory.Size = new System.Drawing.Size(1162, 635);
            this.gvQuestionCategory.TabIndex = 1;
            this.gvQuestionCategory.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvQuestionCategory_CellValidating);
            this.gvQuestionCategory.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvQuestionCategory_CellValueChanged);
            this.gvQuestionCategory.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvQuestionCategory_RowEnter);
            this.gvQuestionCategory.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvQuestionCategory_RowLeave);
            this.gvQuestionCategory.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gvQuestionCategory_RowValidating);
            this.gvQuestionCategory.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.gvQuestionCategory_UserAddedRow);
            this.gvQuestionCategory.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gvQuestionCategory_UserDeletingRow);
            this.gvQuestionCategory.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gvQuestionCategory_KeyUp);
            // 
            // txtTest
            // 
            this.txtTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTest.Location = new System.Drawing.Point(4, 706);
            this.txtTest.Multiline = true;
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(1162, 94);
            this.txtTest.TabIndex = 2;
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
            // tbpProductManagement
            // 
            this.tbpProductManagement.Controls.Add(this.tableLayoutPanel3);
            this.tbpProductManagement.Location = new System.Drawing.Point(4, 22);
            this.tbpProductManagement.Name = "tbpProductManagement";
            this.tbpProductManagement.Padding = new System.Windows.Forms.Padding(3);
            this.tbpProductManagement.Size = new System.Drawing.Size(1176, 810);
            this.tbpProductManagement.TabIndex = 1;
            this.tbpProductManagement.Text = "產品管理";
            this.tbpProductManagement.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 460F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnProductSearch, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.gvProductSearch_Result, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1170, 804);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnProductEdit);
            this.flowLayoutPanel3.Controls.Add(this.btnProductSync);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(460, 56);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // btnProductEdit
            // 
            this.btnProductEdit.Location = new System.Drawing.Point(3, 3);
            this.btnProductEdit.Name = "btnProductEdit";
            this.btnProductEdit.Size = new System.Drawing.Size(75, 23);
            this.btnProductEdit.TabIndex = 1;
            this.btnProductEdit.Text = "修改";
            this.btnProductEdit.UseVisualStyleBackColor = true;
            // 
            // btnProductSync
            // 
            this.btnProductSync.Location = new System.Drawing.Point(84, 3);
            this.btnProductSync.Name = "btnProductSync";
            this.btnProductSync.Size = new System.Drawing.Size(75, 23);
            this.btnProductSync.TabIndex = 3;
            this.btnProductSync.Text = "同步";
            this.btnProductSync.UseVisualStyleBackColor = true;
            // 
            // btnProductSearch
            // 
            this.btnProductSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProductSearch.Location = new System.Drawing.Point(1091, 4);
            this.btnProductSearch.Name = "btnProductSearch";
            this.btnProductSearch.Size = new System.Drawing.Size(75, 23);
            this.btnProductSearch.TabIndex = 1;
            this.btnProductSearch.Text = "查詢";
            this.btnProductSearch.UseVisualStyleBackColor = true;
            // 
            // gvProductSearch_Result
            // 
            this.gvProductSearch_Result.AllowUserToAddRows = false;
            this.gvProductSearch_Result.AllowUserToDeleteRows = false;
            this.gvProductSearch_Result.AllowUserToResizeRows = false;
            this.gvProductSearch_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProductSearch_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvProductSearch_Result.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvProductSearch_Result.Location = new System.Drawing.Point(462, 58);
            this.gvProductSearch_Result.Margin = new System.Windows.Forms.Padding(0);
            this.gvProductSearch_Result.MultiSelect = false;
            this.gvProductSearch_Result.Name = "gvProductSearch_Result";
            this.gvProductSearch_Result.RowHeadersVisible = false;
            this.gvProductSearch_Result.RowTemplate.Height = 24;
            this.gvProductSearch_Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gvProductSearch_Result.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvProductSearch_Result.Size = new System.Drawing.Size(707, 745);
            this.gvProductSearch_Result.TabIndex = 4;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.pgbProductSyncProgress, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.lblProductSyncStatus, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(1, 58);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 465F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(460, 745);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtProductId, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label8, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel4, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.txtProductPrice, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.ckbProductDisplay, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.txtProductBuffer, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.lblProductSubmitStatus, 0, 7);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel5, 1, 3);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 8;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(460, 465);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "品號:";
            // 
            // txtProductId
            // 
            this.txtProductId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtProductId.Location = new System.Drawing.Point(79, 12);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(150, 22);
            this.txtProductId.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "品名:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(79, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 12);
            this.label8.TabIndex = 8;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.btnProductConfirm);
            this.flowLayoutPanel4.Controls.Add(this.btnProductCancel);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(76, 276);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(384, 27);
            this.flowLayoutPanel4.TabIndex = 11;
            // 
            // btnProductConfirm
            // 
            this.btnProductConfirm.Location = new System.Drawing.Point(0, 3);
            this.btnProductConfirm.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnProductConfirm.Name = "btnProductConfirm";
            this.btnProductConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnProductConfirm.TabIndex = 3;
            this.btnProductConfirm.Text = "確認";
            this.btnProductConfirm.UseVisualStyleBackColor = true;
            // 
            // btnProductCancel
            // 
            this.btnProductCancel.Location = new System.Drawing.Point(81, 3);
            this.btnProductCancel.Name = "btnProductCancel";
            this.btnProductCancel.Size = new System.Drawing.Size(75, 23);
            this.btnProductCancel.TabIndex = 4;
            this.btnProductCancel.Text = "取消";
            this.btnProductCancel.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "價格:";
            // 
            // txtProductPrice
            // 
            this.txtProductPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtProductPrice.Location = new System.Drawing.Point(79, 104);
            this.txtProductPrice.Name = "txtProductPrice";
            this.txtProductPrice.Size = new System.Drawing.Size(150, 22);
            this.txtProductPrice.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 155);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "折扣:";
            // 
            // ckbProductDisplay
            // 
            this.ckbProductDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckbProductDisplay.AutoSize = true;
            this.ckbProductDisplay.Location = new System.Drawing.Point(79, 199);
            this.ckbProductDisplay.Name = "ckbProductDisplay";
            this.ckbProductDisplay.Size = new System.Drawing.Size(96, 16);
            this.ckbProductDisplay.TabIndex = 17;
            this.ckbProductDisplay.Text = "為可訂購產品";
            this.ckbProductDisplay.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 247);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "庫存緩衝量:";
            // 
            // txtProductBuffer
            // 
            this.txtProductBuffer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtProductBuffer.Location = new System.Drawing.Point(79, 242);
            this.txtProductBuffer.Name = "txtProductBuffer";
            this.txtProductBuffer.Size = new System.Drawing.Size(150, 22);
            this.txtProductBuffer.TabIndex = 19;
            // 
            // lblProductSubmitStatus
            // 
            this.lblProductSubmitStatus.AutoSize = true;
            this.lblProductSubmitStatus.Location = new System.Drawing.Point(3, 303);
            this.lblProductSubmitStatus.Name = "lblProductSubmitStatus";
            this.lblProductSubmitStatus.Size = new System.Drawing.Size(0, 12);
            this.lblProductSubmitStatus.TabIndex = 12;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel5.Controls.Add(this.txtProductDiscount);
            this.flowLayoutPanel5.Controls.Add(this.label12);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(76, 147);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(384, 28);
            this.flowLayoutPanel5.TabIndex = 20;
            // 
            // txtProductDiscount
            // 
            this.txtProductDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtProductDiscount.Location = new System.Drawing.Point(3, 3);
            this.txtProductDiscount.Name = "txtProductDiscount";
            this.txtProductDiscount.Size = new System.Drawing.Size(150, 22);
            this.txtProductDiscount.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(159, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 12);
            this.label12.TabIndex = 16;
            this.label12.Text = "%";
            // 
            // pgbProductSyncProgress
            // 
            this.pgbProductSyncProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbProductSyncProgress.Location = new System.Drawing.Point(3, 719);
            this.pgbProductSyncProgress.Name = "pgbProductSyncProgress";
            this.pgbProductSyncProgress.Size = new System.Drawing.Size(454, 23);
            this.pgbProductSyncProgress.TabIndex = 4;
            // 
            // lblProductSyncStatus
            // 
            this.lblProductSyncStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProductSyncStatus.AutoSize = true;
            this.lblProductSyncStatus.ForeColor = System.Drawing.Color.Green;
            this.lblProductSyncStatus.Location = new System.Drawing.Point(3, 704);
            this.lblProductSyncStatus.Name = "lblProductSyncStatus";
            this.lblProductSyncStatus.Size = new System.Drawing.Size(0, 12);
            this.lblProductSyncStatus.TabIndex = 5;
            // 
            // hR360ASSESSMENTQUESTIONCATEGORYABindingSource
            // 
            this.hR360ASSESSMENTQUESTIONCATEGORYABindingSource.DataMember = "HR360_ASSESSMENTQUESTION_CATEGORY_A";
            this.hR360ASSESSMENTQUESTIONCATEGORYABindingSource.DataSource = this.dsAPAQuestionBindingSource;
            // 
            // dsAPAQuestionBindingSource
            // 
            this.dsAPAQuestionBindingSource.DataSource = this.dsAPA_Question;
            this.dsAPAQuestionBindingSource.Position = 0;
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
            this.tbpProductManagement.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProductSearch_Result)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hR360ASSESSMENTQUESTIONCATEGORYABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAPAQuestionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAPA_Question)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TabControl tbcManagement;
        private System.Windows.Forms.TabPage tbpQuestionCategory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage tbpProductManagement;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnProductEdit;
        private System.Windows.Forms.Button btnProductSync;
        private System.Windows.Forms.Button btnProductSearch;
        private System.Windows.Forms.DataGridView gvProductSearch_Result;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button btnProductConfirm;
        private System.Windows.Forms.Button btnProductCancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtProductPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox ckbProductDisplay;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProductBuffer;
        private System.Windows.Forms.Label lblProductSubmitStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.TextBox txtProductDiscount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ProgressBar pgbProductSyncProgress;
        private System.Windows.Forms.Label lblProductSyncStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnQuestionCategoryCancel;
        private System.Windows.Forms.Button btnQuestionCategorySave;
        private System.Windows.Forms.DataGridView gvQuestionCategory;
        private System.Windows.Forms.BindingSource dsAPAQuestionBindingSource;
        private dsAPA_Question dsAPA_Question;
        private System.Windows.Forms.BindingSource hR360ASSESSMENTQUESTIONCATEGORYABindingSource;
        private dsAPA_QuestionTableAdapters.HR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter hR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter;
        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.Button btnQuestionCategoryEdit;
    }
}