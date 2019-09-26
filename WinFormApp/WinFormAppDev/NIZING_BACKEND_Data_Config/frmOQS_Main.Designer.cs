using NIZING_BACKEND_Data_Config;
namespace NIZING_BACKEND_Data_Config
{
    partial class frmOQS_Main
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
            this.tbcManagement = new System.Windows.Forms.TabControl();
            this.tbpAccountManagement = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAccountAdd = new System.Windows.Forms.Button();
            this.btnAccountEdit = new System.Windows.Forms.Button();
            this.btnAccountDelete = new System.Windows.Forms.Button();
            this.btnAccountSearch = new System.Windows.Forms.Button();
            this.tlpAccountInputField = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccountId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.txtAccountConfirmPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccountPassword = new System.Windows.Forms.TextBox();
            this.cbxAccountVipLevel = new System.Windows.Forms.ComboBox();
            this.aCCOUNTVIPLEVELBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsOQS_LoginAccount = new NIZING_BACKEND_Data_Config.dsOQS_LoginAccount();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAccountConfirm = new System.Windows.Forms.Button();
            this.btnAccountCancel = new System.Windows.Forms.Button();
            this.lblAccountSubmitStatus = new System.Windows.Forms.Label();
            this.gvAccountSearch_Result = new System.Windows.Forms.DataGridView();
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
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.cbxFunctionList = new System.Windows.Forms.ComboBox();
            this.bgwProductSyncLoader = new System.ComponentModel.BackgroundWorker();
            this.aCCOUNT_VIPLEVELTableAdapter = new NIZING_BACKEND_Data_Config.dsOQS_LoginAccountTableAdapters.ACCOUNT_VIPLEVELTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbcManagement.SuspendLayout();
            this.tbpAccountManagement.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tlpAccountInputField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aCCOUNTVIPLEVELBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOQS_LoginAccount)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccountSearch_Result)).BeginInit();
            this.tbpProductManagement.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProductSearch_Result)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tbcManagement, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel6, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.061224F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96.93877F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1184, 862);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbcManagement
            // 
            this.tbcManagement.Controls.Add(this.tbpAccountManagement);
            this.tbcManagement.Controls.Add(this.tbpProductManagement);
            this.tbcManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcManagement.Location = new System.Drawing.Point(0, 26);
            this.tbcManagement.Margin = new System.Windows.Forms.Padding(0);
            this.tbcManagement.Name = "tbcManagement";
            this.tbcManagement.SelectedIndex = 0;
            this.tbcManagement.Size = new System.Drawing.Size(1184, 836);
            this.tbcManagement.TabIndex = 1;
            this.tbcManagement.SelectedIndexChanged += new System.EventHandler(this.tbcManagement_SelectedIndexChanged);
            // 
            // tbpAccountManagement
            // 
            this.tbpAccountManagement.Controls.Add(this.tableLayoutPanel2);
            this.tbpAccountManagement.Location = new System.Drawing.Point(4, 22);
            this.tbpAccountManagement.Name = "tbpAccountManagement";
            this.tbpAccountManagement.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAccountManagement.Size = new System.Drawing.Size(1176, 810);
            this.tbpAccountManagement.TabIndex = 0;
            this.tbpAccountManagement.Text = "帳號管理";
            this.tbpAccountManagement.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 460F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAccountSearch, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tlpAccountInputField, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.gvAccountSearch_Result, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1170, 804);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAccountAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnAccountEdit);
            this.flowLayoutPanel1.Controls.Add(this.btnAccountDelete);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(460, 56);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnAccountAdd
            // 
            this.btnAccountAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAccountAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAccountAdd.Name = "btnAccountAdd";
            this.btnAccountAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAccountAdd.TabIndex = 0;
            this.btnAccountAdd.Text = "新增";
            this.btnAccountAdd.UseVisualStyleBackColor = true;
            this.btnAccountAdd.Click += new System.EventHandler(this.btnAccountAdd_Click);
            // 
            // btnAccountEdit
            // 
            this.btnAccountEdit.Location = new System.Drawing.Point(84, 3);
            this.btnAccountEdit.Name = "btnAccountEdit";
            this.btnAccountEdit.Size = new System.Drawing.Size(75, 23);
            this.btnAccountEdit.TabIndex = 1;
            this.btnAccountEdit.Text = "修改";
            this.btnAccountEdit.UseVisualStyleBackColor = true;
            this.btnAccountEdit.Click += new System.EventHandler(this.btnAccountEdit_Click);
            // 
            // btnAccountDelete
            // 
            this.btnAccountDelete.Location = new System.Drawing.Point(165, 3);
            this.btnAccountDelete.Name = "btnAccountDelete";
            this.btnAccountDelete.Size = new System.Drawing.Size(75, 23);
            this.btnAccountDelete.TabIndex = 2;
            this.btnAccountDelete.Text = "刪除";
            this.btnAccountDelete.UseVisualStyleBackColor = true;
            this.btnAccountDelete.Click += new System.EventHandler(this.btnAccountDelete_Click);
            // 
            // btnAccountSearch
            // 
            this.btnAccountSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccountSearch.Location = new System.Drawing.Point(1091, 4);
            this.btnAccountSearch.Name = "btnAccountSearch";
            this.btnAccountSearch.Size = new System.Drawing.Size(75, 23);
            this.btnAccountSearch.TabIndex = 1;
            this.btnAccountSearch.Text = "查詢";
            this.btnAccountSearch.UseVisualStyleBackColor = true;
            this.btnAccountSearch.Click += new System.EventHandler(this.btnAccountSearch_Click);
            // 
            // tlpAccountInputField
            // 
            this.tlpAccountInputField.ColumnCount = 2;
            this.tlpAccountInputField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.04884F));
            this.tlpAccountInputField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.95116F));
            this.tlpAccountInputField.Controls.Add(this.label1, 0, 0);
            this.tlpAccountInputField.Controls.Add(this.txtAccountId, 1, 0);
            this.tlpAccountInputField.Controls.Add(this.label4, 0, 1);
            this.tlpAccountInputField.Controls.Add(this.lblAccountName, 1, 1);
            this.tlpAccountInputField.Controls.Add(this.txtAccountConfirmPassword, 1, 4);
            this.tlpAccountInputField.Controls.Add(this.label3, 0, 4);
            this.tlpAccountInputField.Controls.Add(this.txtAccountPassword, 1, 3);
            this.tlpAccountInputField.Controls.Add(this.cbxAccountVipLevel, 1, 2);
            this.tlpAccountInputField.Controls.Add(this.label2, 0, 3);
            this.tlpAccountInputField.Controls.Add(this.label5, 0, 2);
            this.tlpAccountInputField.Controls.Add(this.flowLayoutPanel2, 1, 5);
            this.tlpAccountInputField.Controls.Add(this.lblAccountSubmitStatus, 1, 6);
            this.tlpAccountInputField.Location = new System.Drawing.Point(1, 58);
            this.tlpAccountInputField.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAccountInputField.Name = "tlpAccountInputField";
            this.tlpAccountInputField.RowCount = 7;
            this.tlpAccountInputField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpAccountInputField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpAccountInputField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpAccountInputField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpAccountInputField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpAccountInputField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpAccountInputField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.77778F));
            this.tlpAccountInputField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpAccountInputField.Size = new System.Drawing.Size(460, 465);
            this.tlpAccountInputField.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "帳號:";
            // 
            // txtAccountId
            // 
            this.txtAccountId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountId.Location = new System.Drawing.Point(76, 14);
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.Size = new System.Drawing.Size(150, 22);
            this.txtAccountId.TabIndex = 4;
            this.txtAccountId.Leave += new System.EventHandler(this.txtAccountId_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "名稱";
            // 
            // lblAccountName
            // 
            this.lblAccountName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Location = new System.Drawing.Point(76, 70);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(0, 12);
            this.lblAccountName.TabIndex = 8;
            // 
            // txtAccountConfirmPassword
            // 
            this.txtAccountConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountConfirmPassword.Location = new System.Drawing.Point(76, 218);
            this.txtAccountConfirmPassword.Name = "txtAccountConfirmPassword";
            this.txtAccountConfirmPassword.Size = new System.Drawing.Size(150, 22);
            this.txtAccountConfirmPassword.TabIndex = 6;
            this.txtAccountConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "確認密碼:";
            // 
            // txtAccountPassword
            // 
            this.txtAccountPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountPassword.Location = new System.Drawing.Point(76, 167);
            this.txtAccountPassword.Name = "txtAccountPassword";
            this.txtAccountPassword.Size = new System.Drawing.Size(150, 22);
            this.txtAccountPassword.TabIndex = 5;
            this.txtAccountPassword.UseSystemPasswordChar = true;
            // 
            // cbxAccountVipLevel
            // 
            this.cbxAccountVipLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxAccountVipLevel.DataSource = this.aCCOUNTVIPLEVELBindingSource;
            this.cbxAccountVipLevel.DisplayMember = "LEVEL";
            this.cbxAccountVipLevel.FormattingEnabled = true;
            this.cbxAccountVipLevel.Location = new System.Drawing.Point(76, 117);
            this.cbxAccountVipLevel.Name = "cbxAccountVipLevel";
            this.cbxAccountVipLevel.Size = new System.Drawing.Size(150, 20);
            this.cbxAccountVipLevel.TabIndex = 10;
            this.cbxAccountVipLevel.ValueMember = "LEVEL";
            // 
            // aCCOUNTVIPLEVELBindingSource
            // 
            this.aCCOUNTVIPLEVELBindingSource.DataMember = "ACCOUNT_VIPLEVEL";
            this.aCCOUNTVIPLEVELBindingSource.DataSource = this.dsOQS_LoginAccount;
            // 
            // dsOQS_LoginAccount
            // 
            this.dsOQS_LoginAccount.DataSetName = "dsOQS_LoginAccount";
            this.dsOQS_LoginAccount.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密碼:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "VIP等級:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnAccountConfirm);
            this.flowLayoutPanel2.Controls.Add(this.btnAccountCancel);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(73, 255);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(387, 31);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // btnAccountConfirm
            // 
            this.btnAccountConfirm.Location = new System.Drawing.Point(0, 3);
            this.btnAccountConfirm.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnAccountConfirm.Name = "btnAccountConfirm";
            this.btnAccountConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnAccountConfirm.TabIndex = 3;
            this.btnAccountConfirm.Text = "確認";
            this.btnAccountConfirm.UseVisualStyleBackColor = true;
            this.btnAccountConfirm.Click += new System.EventHandler(this.btnAccountConfirm_Click);
            // 
            // btnAccountCancel
            // 
            this.btnAccountCancel.Location = new System.Drawing.Point(81, 3);
            this.btnAccountCancel.Name = "btnAccountCancel";
            this.btnAccountCancel.Size = new System.Drawing.Size(75, 23);
            this.btnAccountCancel.TabIndex = 4;
            this.btnAccountCancel.Text = "取消";
            this.btnAccountCancel.UseVisualStyleBackColor = true;
            this.btnAccountCancel.Click += new System.EventHandler(this.btnAccountCancel_Click);
            // 
            // lblAccountSubmitStatus
            // 
            this.lblAccountSubmitStatus.AutoSize = true;
            this.lblAccountSubmitStatus.Location = new System.Drawing.Point(76, 286);
            this.lblAccountSubmitStatus.Name = "lblAccountSubmitStatus";
            this.lblAccountSubmitStatus.Size = new System.Drawing.Size(0, 12);
            this.lblAccountSubmitStatus.TabIndex = 12;
            // 
            // gvAccountSearch_Result
            // 
            this.gvAccountSearch_Result.AllowUserToAddRows = false;
            this.gvAccountSearch_Result.AllowUserToDeleteRows = false;
            this.gvAccountSearch_Result.AllowUserToResizeRows = false;
            this.gvAccountSearch_Result.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvAccountSearch_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAccountSearch_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvAccountSearch_Result.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvAccountSearch_Result.Location = new System.Drawing.Point(462, 58);
            this.gvAccountSearch_Result.Margin = new System.Windows.Forms.Padding(0);
            this.gvAccountSearch_Result.MultiSelect = false;
            this.gvAccountSearch_Result.Name = "gvAccountSearch_Result";
            this.gvAccountSearch_Result.RowHeadersVisible = false;
            this.gvAccountSearch_Result.RowTemplate.Height = 24;
            this.gvAccountSearch_Result.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAccountSearch_Result.Size = new System.Drawing.Size(707, 745);
            this.gvAccountSearch_Result.TabIndex = 4;
            this.gvAccountSearch_Result.SelectionChanged += new System.EventHandler(this.gvAccountSearch_Result_SelectionChanged);
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
            this.btnProductSync.Click += new System.EventHandler(this.btnProductSync_Click);
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
            this.btnProductSearch.Click += new System.EventHandler(this.btnProductSearch_Click);
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
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.btnLogout);
            this.flowLayoutPanel6.Controls.Add(this.cbxFunctionList);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(1184, 26);
            this.flowLayoutPanel6.TabIndex = 2;
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
            this.cbxFunctionList.TabIndex = 7;
            this.cbxFunctionList.ValueMember = "ID";
            this.cbxFunctionList.SelectionChangeCommitted += new System.EventHandler(this.cbxFunctionList_SelectionChangeCommitted);
            // 
            // bgwProductSyncLoader
            // 
            this.bgwProductSyncLoader.WorkerReportsProgress = true;
            this.bgwProductSyncLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProductSyncLoader_DoWork);
            this.bgwProductSyncLoader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwProductSyncLoader_ProgressChanged);
            this.bgwProductSyncLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProductSyncLoader_RunWorkerCompleted);
            // 
            // aCCOUNT_VIPLEVELTableAdapter
            // 
            this.aCCOUNT_VIPLEVELTableAdapter.ClearBeforeFill = true;
            // 
            // frmOQS_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 862);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmOQS_Main";
            this.Text = "線上報價系統";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmOQS_Main_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tbcManagement.ResumeLayout(false);
            this.tbpAccountManagement.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tlpAccountInputField.ResumeLayout(false);
            this.tlpAccountInputField.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aCCOUNTVIPLEVELBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOQS_LoginAccount)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvAccountSearch_Result)).EndInit();
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
            this.flowLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tbpAccountManagement;
        private System.Windows.Forms.TabPage tbpProductManagement;
        private System.Windows.Forms.TabControl tbcManagement;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAccountAdd;
        private System.Windows.Forms.Button btnAccountEdit;
        private System.Windows.Forms.Button btnAccountDelete;
        private System.Windows.Forms.Button btnAccountConfirm;
        private System.Windows.Forms.Button btnAccountCancel;
        private System.Windows.Forms.Button btnAccountSearch;
        private System.Windows.Forms.TableLayoutPanel tlpAccountInputField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccountPassword;
        private System.Windows.Forms.TextBox txtAccountConfirmPassword;
        private System.Windows.Forms.TextBox txtAccountId;
        private System.Windows.Forms.DataGridView gvAccountSearch_Result;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxAccountVipLevel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblAccountSubmitStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnProductEdit;
        private System.Windows.Forms.Button btnProductSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button btnProductConfirm;
        private System.Windows.Forms.Button btnProductCancel;
        private System.Windows.Forms.Label lblProductSubmitStatus;
        private System.Windows.Forms.DataGridView gvProductSearch_Result;
        private System.Windows.Forms.Button btnProductSync;
        private System.ComponentModel.BackgroundWorker bgwProductSyncLoader;
        private System.Windows.Forms.ProgressBar pgbProductSyncProgress;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblProductSyncStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtProductPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox ckbProductDisplay;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProductBuffer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.TextBox txtProductDiscount;
        private System.Windows.Forms.Label label12;
        private dsOQS_LoginAccount dsOQS_LoginAccount1;
        private dsOQS_LoginAccount dsOQS_LoginAccount;
        private System.Windows.Forms.BindingSource aCCOUNTVIPLEVELBindingSource;
        private dsOQS_LoginAccountTableAdapters.ACCOUNT_VIPLEVELTableAdapter aCCOUNT_VIPLEVELTableAdapter;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ComboBox cbxFunctionList;
    }
}