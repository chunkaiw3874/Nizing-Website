namespace NIZING_BACKEND_Data_Config
{
    partial class frmWEB_Main
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbcManagement = new System.Windows.Forms.TabControl();
            this.tbpNewsManagement = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNewsConfirm = new System.Windows.Forms.Button();
            this.btnNewsCancel = new System.Windows.Forms.Button();
            this.txtNewsMemo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNewsContent = new System.Windows.Forms.TextBox();
            this.flpNewsId = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNewsId = new System.Windows.Forms.Label();
            this.ckxNewsVisible = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNewsAddAttachment = new System.Windows.Forms.Button();
            this.btnNewsRemoveAttachment = new System.Windows.Forms.Button();
            this.lbtnNewsAttachmentSelection = new System.Windows.Forms.LinkLabel();
            this.clbNewsAttachmentList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewsTitle = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNewsAdd = new System.Windows.Forms.Button();
            this.btnNewsEdit = new System.Windows.Forms.Button();
            this.btnNewsDelete = new System.Windows.Forms.Button();
            this.gvNewsSearchResult = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNewsSearch = new System.Windows.Forms.Button();
            this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.cbxFunctionList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNewsDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewsLink = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbcManagement.SuspendLayout();
            this.tbpNewsManagement.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel8.SuspendLayout();
            this.flpNewsId.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvNewsSearchResult)).BeginInit();
            this.flowLayoutPanel9.SuspendLayout();
            this.flowLayoutPanel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tbcManagement, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel11, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.061224F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96.93877F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1184, 862);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tbcManagement
            // 
            this.tbcManagement.Controls.Add(this.tbpNewsManagement);
            this.tbcManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcManagement.Location = new System.Drawing.Point(0, 26);
            this.tbcManagement.Margin = new System.Windows.Forms.Padding(0);
            this.tbcManagement.Name = "tbcManagement";
            this.tbcManagement.SelectedIndex = 0;
            this.tbcManagement.Size = new System.Drawing.Size(1184, 836);
            this.tbcManagement.TabIndex = 1;
            // 
            // tbpNewsManagement
            // 
            this.tbpNewsManagement.Controls.Add(this.tableLayoutPanel2);
            this.tbpNewsManagement.Location = new System.Drawing.Point(4, 22);
            this.tbpNewsManagement.Name = "tbpNewsManagement";
            this.tbpNewsManagement.Padding = new System.Windows.Forms.Padding(3);
            this.tbpNewsManagement.Size = new System.Drawing.Size(1176, 810);
            this.tbpNewsManagement.TabIndex = 0;
            this.tbpNewsManagement.Text = "網站新聞管理";
            this.tbpNewsManagement.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.gvNewsSearchResult, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel9, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1170, 804);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.04884F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.95116F));
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel8, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.txtNewsMemo, 1, 7);
            this.tableLayoutPanel4.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.txtNewsContent, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.flpNewsId, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label14, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.txtNewsTitle, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.dtpNewsDate, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.txtNewsLink, 1, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1, 58);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 8;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(600, 745);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(73, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "ID:";
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.Controls.Add(this.btnNewsConfirm);
            this.flowLayoutPanel8.Controls.Add(this.btnNewsCancel);
            this.flowLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel8.Location = new System.Drawing.Point(96, 595);
            this.flowLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(504, 30);
            this.flowLayoutPanel8.TabIndex = 6;
            // 
            // btnNewsConfirm
            // 
            this.btnNewsConfirm.Location = new System.Drawing.Point(0, 3);
            this.btnNewsConfirm.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnNewsConfirm.Name = "btnNewsConfirm";
            this.btnNewsConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnNewsConfirm.TabIndex = 0;
            this.btnNewsConfirm.Text = "確認";
            this.btnNewsConfirm.UseVisualStyleBackColor = true;
            this.btnNewsConfirm.Click += new System.EventHandler(this.btnNewsConfirm_Click);
            // 
            // btnNewsCancel
            // 
            this.btnNewsCancel.Location = new System.Drawing.Point(81, 3);
            this.btnNewsCancel.Name = "btnNewsCancel";
            this.btnNewsCancel.Size = new System.Drawing.Size(75, 23);
            this.btnNewsCancel.TabIndex = 1;
            this.btnNewsCancel.Text = "取消";
            this.btnNewsCancel.UseVisualStyleBackColor = true;
            this.btnNewsCancel.Click += new System.EventHandler(this.btnNewsCancel_Click);
            // 
            // txtNewsMemo
            // 
            this.txtNewsMemo.BackColor = System.Drawing.Color.White;
            this.txtNewsMemo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewsMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNewsMemo.Location = new System.Drawing.Point(96, 625);
            this.txtNewsMemo.Margin = new System.Windows.Forms.Padding(0);
            this.txtNewsMemo.Multiline = true;
            this.txtNewsMemo.Name = "txtNewsMemo";
            this.txtNewsMemo.ReadOnly = true;
            this.txtNewsMemo.Size = new System.Drawing.Size(504, 120);
            this.txtNewsMemo.TabIndex = 7;
            this.txtNewsMemo.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Right;
            this.label13.Location = new System.Drawing.Point(61, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 327);
            this.label13.TabIndex = 5;
            this.label13.Text = "內容:";
            // 
            // txtNewsContent
            // 
            this.txtNewsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNewsContent.Location = new System.Drawing.Point(99, 93);
            this.txtNewsContent.Multiline = true;
            this.txtNewsContent.Name = "txtNewsContent";
            this.txtNewsContent.Size = new System.Drawing.Size(498, 321);
            this.txtNewsContent.TabIndex = 3;
            // 
            // flpNewsId
            // 
            this.flpNewsId.Controls.Add(this.lblNewsId);
            this.flpNewsId.Controls.Add(this.ckxNewsVisible);
            this.flpNewsId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpNewsId.Location = new System.Drawing.Point(96, 30);
            this.flpNewsId.Margin = new System.Windows.Forms.Padding(0);
            this.flpNewsId.Name = "flpNewsId";
            this.flpNewsId.Size = new System.Drawing.Size(504, 30);
            this.flpNewsId.TabIndex = 1;
            // 
            // lblNewsId
            // 
            this.lblNewsId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNewsId.AutoSize = true;
            this.lblNewsId.Location = new System.Drawing.Point(3, 5);
            this.lblNewsId.Name = "lblNewsId";
            this.lblNewsId.Size = new System.Drawing.Size(0, 12);
            this.lblNewsId.TabIndex = 0;
            // 
            // ckxNewsVisible
            // 
            this.ckxNewsVisible.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckxNewsVisible.AutoSize = true;
            this.ckxNewsVisible.Checked = true;
            this.ckxNewsVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckxNewsVisible.Location = new System.Drawing.Point(9, 3);
            this.ckxNewsVisible.Name = "ckxNewsVisible";
            this.ckxNewsVisible.Size = new System.Drawing.Size(72, 16);
            this.ckxNewsVisible.TabIndex = 1;
            this.ckxNewsVisible.Text = "是否顯示";
            this.ckxNewsVisible.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(61, 447);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 12);
            this.label14.TabIndex = 6;
            this.label14.Text = "附件:";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.clbNewsAttachmentList, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(96, 447);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(504, 148);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.btnNewsAddAttachment, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnNewsRemoveAttachment, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.lbtnNewsAttachmentSelection, 2, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(504, 30);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // btnNewsAddAttachment
            // 
            this.btnNewsAddAttachment.Location = new System.Drawing.Point(3, 3);
            this.btnNewsAddAttachment.Name = "btnNewsAddAttachment";
            this.btnNewsAddAttachment.Size = new System.Drawing.Size(75, 23);
            this.btnNewsAddAttachment.TabIndex = 0;
            this.btnNewsAddAttachment.Text = "新增附件";
            this.btnNewsAddAttachment.UseVisualStyleBackColor = true;
            this.btnNewsAddAttachment.Click += new System.EventHandler(this.btnNewsAddAttachment_Click);
            // 
            // btnNewsRemoveAttachment
            // 
            this.btnNewsRemoveAttachment.Location = new System.Drawing.Point(84, 3);
            this.btnNewsRemoveAttachment.Name = "btnNewsRemoveAttachment";
            this.btnNewsRemoveAttachment.Size = new System.Drawing.Size(75, 23);
            this.btnNewsRemoveAttachment.TabIndex = 1;
            this.btnNewsRemoveAttachment.Text = "移除附件";
            this.btnNewsRemoveAttachment.UseVisualStyleBackColor = true;
            this.btnNewsRemoveAttachment.Click += new System.EventHandler(this.btnNewsRemoveAttachment_Click);
            // 
            // lbtnNewsAttachmentSelection
            // 
            this.lbtnNewsAttachmentSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbtnNewsAttachmentSelection.AutoSize = true;
            this.lbtnNewsAttachmentSelection.Location = new System.Drawing.Point(472, 18);
            this.lbtnNewsAttachmentSelection.Name = "lbtnNewsAttachmentSelection";
            this.lbtnNewsAttachmentSelection.Size = new System.Drawing.Size(29, 12);
            this.lbtnNewsAttachmentSelection.TabIndex = 2;
            this.lbtnNewsAttachmentSelection.TabStop = true;
            this.lbtnNewsAttachmentSelection.Text = "全選";
            this.lbtnNewsAttachmentSelection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtnNewsAttachmentSelection_LinkClicked);
            // 
            // clbNewsAttachmentList
            // 
            this.clbNewsAttachmentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbNewsAttachmentList.FormattingEnabled = true;
            this.clbNewsAttachmentList.Location = new System.Drawing.Point(3, 33);
            this.clbNewsAttachmentList.Name = "clbNewsAttachmentList";
            this.clbNewsAttachmentList.Size = new System.Drawing.Size(498, 112);
            this.clbNewsAttachmentList.TabIndex = 1;
            this.clbNewsAttachmentList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbNewsAttachmentList_ItemCheck);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "主旨:";
            // 
            // txtNewsTitle
            // 
            this.txtNewsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewsTitle.Location = new System.Drawing.Point(99, 64);
            this.txtNewsTitle.Name = "txtNewsTitle";
            this.txtNewsTitle.Size = new System.Drawing.Size(498, 22);
            this.txtNewsTitle.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNewsAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnNewsEdit);
            this.flowLayoutPanel1.Controls.Add(this.btnNewsDelete);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(600, 56);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnNewsAdd
            // 
            this.btnNewsAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnNewsAdd.Location = new System.Drawing.Point(3, 3);
            this.btnNewsAdd.Name = "btnNewsAdd";
            this.btnNewsAdd.Size = new System.Drawing.Size(75, 23);
            this.btnNewsAdd.TabIndex = 0;
            this.btnNewsAdd.Text = "新增";
            this.btnNewsAdd.UseVisualStyleBackColor = true;
            this.btnNewsAdd.Click += new System.EventHandler(this.btnNewsAdd_Click);
            // 
            // btnNewsEdit
            // 
            this.btnNewsEdit.Location = new System.Drawing.Point(84, 3);
            this.btnNewsEdit.Name = "btnNewsEdit";
            this.btnNewsEdit.Size = new System.Drawing.Size(75, 23);
            this.btnNewsEdit.TabIndex = 1;
            this.btnNewsEdit.Text = "修改";
            this.btnNewsEdit.UseVisualStyleBackColor = true;
            this.btnNewsEdit.Click += new System.EventHandler(this.btnNewsEdit_Click);
            // 
            // btnNewsDelete
            // 
            this.btnNewsDelete.Location = new System.Drawing.Point(165, 3);
            this.btnNewsDelete.Name = "btnNewsDelete";
            this.btnNewsDelete.Size = new System.Drawing.Size(75, 23);
            this.btnNewsDelete.TabIndex = 2;
            this.btnNewsDelete.Text = "刪除";
            this.btnNewsDelete.UseVisualStyleBackColor = true;
            this.btnNewsDelete.Click += new System.EventHandler(this.btnNewsDelete_Click);
            // 
            // gvNewsSearchResult
            // 
            this.gvNewsSearchResult.AllowUserToAddRows = false;
            this.gvNewsSearchResult.AllowUserToDeleteRows = false;
            this.gvNewsSearchResult.AllowUserToResizeColumns = false;
            this.gvNewsSearchResult.AllowUserToResizeRows = false;
            this.gvNewsSearchResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvNewsSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvNewsSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvNewsSearchResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvNewsSearchResult.Location = new System.Drawing.Point(602, 58);
            this.gvNewsSearchResult.Margin = new System.Windows.Forms.Padding(0);
            this.gvNewsSearchResult.MultiSelect = false;
            this.gvNewsSearchResult.Name = "gvNewsSearchResult";
            this.gvNewsSearchResult.RowHeadersVisible = false;
            this.gvNewsSearchResult.RowTemplate.Height = 24;
            this.gvNewsSearchResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvNewsSearchResult.Size = new System.Drawing.Size(567, 745);
            this.gvNewsSearchResult.TabIndex = 2;
            this.gvNewsSearchResult.SelectionChanged += new System.EventHandler(this.gvNewsSearchResult_SelectionChanged);
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.Controls.Add(this.btnNewsSearch);
            this.flowLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel9.Location = new System.Drawing.Point(602, 1);
            this.flowLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel9.Size = new System.Drawing.Size(567, 56);
            this.flowLayoutPanel9.TabIndex = 3;
            // 
            // btnNewsSearch
            // 
            this.btnNewsSearch.Location = new System.Drawing.Point(489, 3);
            this.btnNewsSearch.Name = "btnNewsSearch";
            this.btnNewsSearch.Size = new System.Drawing.Size(75, 23);
            this.btnNewsSearch.TabIndex = 4;
            this.btnNewsSearch.Text = "查詢";
            this.btnNewsSearch.UseVisualStyleBackColor = true;
            this.btnNewsSearch.Click += new System.EventHandler(this.btnNewsSearch_Click);
            // 
            // flowLayoutPanel11
            // 
            this.flowLayoutPanel11.Controls.Add(this.btnLogout);
            this.flowLayoutPanel11.Controls.Add(this.cbxFunctionList);
            this.flowLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel11.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel11.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel11.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel11.Name = "flowLayoutPanel11";
            this.flowLayoutPanel11.Size = new System.Drawing.Size(1184, 26);
            this.flowLayoutPanel11.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(1084, 0);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 26);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "登出";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // cbxFunctionList
            // 
            this.cbxFunctionList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxFunctionList.DisplayMember = "NAME";
            this.cbxFunctionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFunctionList.FormattingEnabled = true;
            this.cbxFunctionList.Location = new System.Drawing.Point(855, 3);
            this.cbxFunctionList.Name = "cbxFunctionList";
            this.cbxFunctionList.Size = new System.Drawing.Size(226, 20);
            this.cbxFunctionList.TabIndex = 6;
            this.cbxFunctionList.ValueMember = "ID";
            this.cbxFunctionList.SelectionChangeCommitted += new System.EventHandler(this.cbxFunctionList_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "新聞日期:";
            // 
            // dtpNewsDate
            // 
            this.dtpNewsDate.Location = new System.Drawing.Point(99, 3);
            this.dtpNewsDate.Name = "dtpNewsDate";
            this.dtpNewsDate.Size = new System.Drawing.Size(200, 22);
            this.dtpNewsDate.TabIndex = 0;
            this.dtpNewsDate.ValueChanged += new System.EventHandler(this.dtpNewsDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 426);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "網址連結:";
            // 
            // txtNewsLink
            // 
            this.txtNewsLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewsLink.Location = new System.Drawing.Point(99, 421);
            this.txtNewsLink.Name = "txtNewsLink";
            this.txtNewsLink.Size = new System.Drawing.Size(498, 22);
            this.txtNewsLink.TabIndex = 4;
            // 
            // frmWEB_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 862);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmWEB_Main";
            this.Text = "frmWEB_Main";
            this.Shown += new System.EventHandler(this.frmWEB_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tbcManagement.ResumeLayout(false);
            this.tbpNewsManagement.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.flowLayoutPanel8.ResumeLayout(false);
            this.flpNewsId.ResumeLayout(false);
            this.flpNewsId.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvNewsSearchResult)).EndInit();
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel11.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tbcManagement;
        private System.Windows.Forms.TabPage tbpNewsManagement;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnNewsAdd;
        private System.Windows.Forms.Button btnNewsEdit;
        private System.Windows.Forms.Button btnNewsDelete;
        private System.Windows.Forms.DataGridView gvNewsSearchResult;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.Button btnNewsSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel11;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ComboBox cbxFunctionList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.Button btnNewsConfirm;
        private System.Windows.Forms.Button btnNewsCancel;
        private System.Windows.Forms.TextBox txtNewsMemo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNewsContent;
        private System.Windows.Forms.FlowLayoutPanel flpNewsId;
        private System.Windows.Forms.Label lblNewsId;
        private System.Windows.Forms.CheckBox ckxNewsVisible;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnNewsAddAttachment;
        private System.Windows.Forms.Button btnNewsRemoveAttachment;
        private System.Windows.Forms.LinkLabel lbtnNewsAttachmentSelection;
        private System.Windows.Forms.CheckedListBox clbNewsAttachmentList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewsTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNewsDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewsLink;
    }
}