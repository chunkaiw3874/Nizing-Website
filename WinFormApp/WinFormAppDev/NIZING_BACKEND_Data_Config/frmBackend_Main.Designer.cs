namespace NIZING_BACKEND_Data_Config
{
    partial class frmBackend_Main
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
            this.btnLogout = new System.Windows.Forms.Button();
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
            this.txtAccountConfirmPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccountPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flpAccountId = new System.Windows.Forms.FlowLayoutPanel();
            this.txtAccountId = new System.Windows.Forms.TextBox();
            this.ckxFullAdminRights = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbAdminRights = new System.Windows.Forms.CheckedListBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAccountConfirm = new System.Windows.Forms.Button();
            this.btnAccountCancel = new System.Windows.Forms.Button();
            this.lblAccountSubmitStatus = new System.Windows.Forms.Label();
            this.gvAccountSearch_Result = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbcManagement.SuspendLayout();
            this.tbpAccountManagement.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tlpAccountInputField.SuspendLayout();
            this.flpAccountId.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccountSearch_Result)).BeginInit();
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
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(800, 600);
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
            this.tbcManagement.Controls.Add(this.tbpAccountManagement);
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
            this.tlpAccountInputField.Controls.Add(this.txtAccountConfirmPassword, 1, 2);
            this.tlpAccountInputField.Controls.Add(this.label3, 0, 2);
            this.tlpAccountInputField.Controls.Add(this.txtAccountPassword, 1, 1);
            this.tlpAccountInputField.Controls.Add(this.label2, 0, 1);
            this.tlpAccountInputField.Controls.Add(this.flpAccountId, 1, 0);
            this.tlpAccountInputField.Controls.Add(this.groupBox1, 1, 3);
            this.tlpAccountInputField.Controls.Add(this.flowLayoutPanel2, 1, 4);
            this.tlpAccountInputField.Controls.Add(this.lblAccountSubmitStatus, 1, 5);
            this.tlpAccountInputField.Location = new System.Drawing.Point(1, 58);
            this.tlpAccountInputField.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAccountInputField.Name = "tlpAccountInputField";
            this.tlpAccountInputField.RowCount = 6;
            this.tlpAccountInputField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tlpAccountInputField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tlpAccountInputField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tlpAccountInputField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpAccountInputField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpAccountInputField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tlpAccountInputField.Size = new System.Drawing.Size(460, 465);
            this.tlpAccountInputField.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "帳號:";
            // 
            // txtAccountConfirmPassword
            // 
            this.txtAccountConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountConfirmPassword.Location = new System.Drawing.Point(76, 106);
            this.txtAccountConfirmPassword.Name = "txtAccountConfirmPassword";
            this.txtAccountConfirmPassword.Size = new System.Drawing.Size(150, 22);
            this.txtAccountConfirmPassword.TabIndex = 6;
            this.txtAccountConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "確認密碼:";
            // 
            // txtAccountPassword
            // 
            this.txtAccountPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountPassword.Location = new System.Drawing.Point(76, 59);
            this.txtAccountPassword.Name = "txtAccountPassword";
            this.txtAccountPassword.Size = new System.Drawing.Size(150, 22);
            this.txtAccountPassword.TabIndex = 5;
            this.txtAccountPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密碼:";
            // 
            // flpAccountId
            // 
            this.flpAccountId.Controls.Add(this.txtAccountId);
            this.flpAccountId.Controls.Add(this.ckxFullAdminRights);
            this.flpAccountId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAccountId.Location = new System.Drawing.Point(73, 0);
            this.flpAccountId.Margin = new System.Windows.Forms.Padding(0);
            this.flpAccountId.Name = "flpAccountId";
            this.flpAccountId.Size = new System.Drawing.Size(387, 47);
            this.flpAccountId.TabIndex = 12;
            // 
            // txtAccountId
            // 
            this.txtAccountId.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtAccountId.Location = new System.Drawing.Point(3, 3);
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.Size = new System.Drawing.Size(150, 22);
            this.txtAccountId.TabIndex = 4;
            // 
            // ckxFullAdminRights
            // 
            this.ckxFullAdminRights.AutoSize = true;
            this.ckxFullAdminRights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckxFullAdminRights.Location = new System.Drawing.Point(159, 3);
            this.ckxFullAdminRights.Name = "ckxFullAdminRights";
            this.ckxFullAdminRights.Size = new System.Drawing.Size(72, 22);
            this.ckxFullAdminRights.TabIndex = 5;
            this.ckxFullAdminRights.Text = "權限全開";
            this.ckxFullAdminRights.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clbAdminRights);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(73, 141);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 152);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "開啟權限";
            // 
            // clbAdminRights
            // 
            this.clbAdminRights.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbAdminRights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbAdminRights.FormattingEnabled = true;
            this.clbAdminRights.Location = new System.Drawing.Point(3, 18);
            this.clbAdminRights.Margin = new System.Windows.Forms.Padding(0);
            this.clbAdminRights.MultiColumn = true;
            this.clbAdminRights.Name = "clbAdminRights";
            this.clbAdminRights.Size = new System.Drawing.Size(378, 131);
            this.clbAdminRights.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnAccountConfirm);
            this.flowLayoutPanel2.Controls.Add(this.btnAccountCancel);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(73, 293);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(387, 30);
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
            this.lblAccountSubmitStatus.Location = new System.Drawing.Point(76, 323);
            this.lblAccountSubmitStatus.Name = "lblAccountSubmitStatus";
            this.lblAccountSubmitStatus.Size = new System.Drawing.Size(33, 12);
            this.lblAccountSubmitStatus.TabIndex = 14;
            this.lblAccountSubmitStatus.Text = "label4";
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
            // 
            // frmBackend_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 862);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmBackend_Main";
            this.Text = "後台管理系統";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tbcManagement.ResumeLayout(false);
            this.tbpAccountManagement.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tlpAccountInputField.ResumeLayout(false);
            this.tlpAccountInputField.PerformLayout();
            this.flpAccountId.ResumeLayout(false);
            this.flpAccountId.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvAccountSearch_Result)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TabControl tbcManagement;
        private System.Windows.Forms.TabPage tbpAccountManagement;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAccountAdd;
        private System.Windows.Forms.Button btnAccountEdit;
        private System.Windows.Forms.Button btnAccountDelete;
        private System.Windows.Forms.Button btnAccountSearch;
        private System.Windows.Forms.TableLayoutPanel tlpAccountInputField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountConfirmPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccountPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpAccountId;
        private System.Windows.Forms.TextBox txtAccountId;
        private System.Windows.Forms.CheckBox ckxFullAdminRights;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clbAdminRights;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnAccountConfirm;
        private System.Windows.Forms.Button btnAccountCancel;
        private System.Windows.Forms.Label lblAccountSubmitStatus;
        private System.Windows.Forms.DataGridView gvAccountSearch_Result;
    }
}