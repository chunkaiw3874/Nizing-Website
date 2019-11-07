namespace NIZING_BACKEND_Data_Config
{
    partial class frmQAS_Main
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
            this.tbpDeficientProductRecord = new System.Windows.Forms.TabPage();
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
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAccountConfirm = new System.Windows.Forms.Button();
            this.btnAccountCancel = new System.Windows.Forms.Button();
            this.lblAccountSubmitStatus = new System.Windows.Forms.Label();
            this.gvAccountSearch_Result = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.cbxFunctionList = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbcManagement.SuspendLayout();
            this.tbpDeficientProductRecord.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tlpAccountInputField.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccountSearch_Result)).BeginInit();
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
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tbcManagement
            // 
            this.tbcManagement.Controls.Add(this.tbpDeficientProductRecord);
            this.tbcManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcManagement.Location = new System.Drawing.Point(0, 26);
            this.tbcManagement.Margin = new System.Windows.Forms.Padding(0);
            this.tbcManagement.Name = "tbcManagement";
            this.tbcManagement.SelectedIndex = 0;
            this.tbcManagement.Size = new System.Drawing.Size(1184, 836);
            this.tbcManagement.TabIndex = 1;
            // 
            // tbpDeficientProductRecord
            // 
            this.tbpDeficientProductRecord.Controls.Add(this.tableLayoutPanel2);
            this.tbpDeficientProductRecord.Location = new System.Drawing.Point(4, 22);
            this.tbpDeficientProductRecord.Name = "tbpDeficientProductRecord";
            this.tbpDeficientProductRecord.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDeficientProductRecord.Size = new System.Drawing.Size(1176, 810);
            this.tbpDeficientProductRecord.TabIndex = 0;
            this.tbpDeficientProductRecord.Text = "異常單管理";
            this.tbpDeficientProductRecord.UseVisualStyleBackColor = true;
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
            // 
            // btnAccountSearch
            // 
            this.btnAccountSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccountSearch.Location = new System.Drawing.Point(1091, 4);
            this.btnAccountSearch.Name = "btnAccountSearch";
            this.btnAccountSearch.Size = new System.Drawing.Size(75, 22);
            this.btnAccountSearch.TabIndex = 1;
            this.btnAccountSearch.Text = "查詢";
            this.btnAccountSearch.UseVisualStyleBackColor = true;
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
            this.tlpAccountInputField.Size = new System.Drawing.Size(460, 374);
            this.tlpAccountInputField.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "帳號:";
            // 
            // txtAccountId
            // 
            this.txtAccountId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountId.Location = new System.Drawing.Point(76, 9);
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.Size = new System.Drawing.Size(150, 22);
            this.txtAccountId.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "名稱";
            // 
            // lblAccountName
            // 
            this.lblAccountName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Location = new System.Drawing.Point(76, 55);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(0, 12);
            this.lblAccountName.TabIndex = 8;
            // 
            // txtAccountConfirmPassword
            // 
            this.txtAccountConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountConfirmPassword.Location = new System.Drawing.Point(76, 173);
            this.txtAccountConfirmPassword.Name = "txtAccountConfirmPassword";
            this.txtAccountConfirmPassword.Size = new System.Drawing.Size(150, 22);
            this.txtAccountConfirmPassword.TabIndex = 6;
            this.txtAccountConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "確認密碼:";
            // 
            // txtAccountPassword
            // 
            this.txtAccountPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountPassword.Location = new System.Drawing.Point(76, 132);
            this.txtAccountPassword.Name = "txtAccountPassword";
            this.txtAccountPassword.Size = new System.Drawing.Size(150, 22);
            this.txtAccountPassword.TabIndex = 5;
            this.txtAccountPassword.UseSystemPasswordChar = true;
            // 
            // cbxAccountVipLevel
            // 
            this.cbxAccountVipLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxAccountVipLevel.DisplayMember = "LEVEL";
            this.cbxAccountVipLevel.FormattingEnabled = true;
            this.cbxAccountVipLevel.Location = new System.Drawing.Point(76, 92);
            this.cbxAccountVipLevel.Name = "cbxAccountVipLevel";
            this.cbxAccountVipLevel.Size = new System.Drawing.Size(150, 20);
            this.cbxAccountVipLevel.TabIndex = 10;
            this.cbxAccountVipLevel.ValueMember = "LEVEL";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密碼:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 96);
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
            this.flowLayoutPanel2.Location = new System.Drawing.Point(73, 205);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(387, 24);
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
            // 
            // btnAccountCancel
            // 
            this.btnAccountCancel.Location = new System.Drawing.Point(81, 3);
            this.btnAccountCancel.Name = "btnAccountCancel";
            this.btnAccountCancel.Size = new System.Drawing.Size(75, 23);
            this.btnAccountCancel.TabIndex = 4;
            this.btnAccountCancel.Text = "取消";
            this.btnAccountCancel.UseVisualStyleBackColor = true;
            // 
            // lblAccountSubmitStatus
            // 
            this.lblAccountSubmitStatus.AutoSize = true;
            this.lblAccountSubmitStatus.Location = new System.Drawing.Point(76, 229);
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
            // 
            // frmQC_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 862);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmQC_Main";
            this.Text = "品保系統";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tbcManagement.ResumeLayout(false);
            this.tbpDeficientProductRecord.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tlpAccountInputField.ResumeLayout(false);
            this.tlpAccountInputField.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvAccountSearch_Result)).EndInit();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tbcManagement;
        private System.Windows.Forms.TabPage tbpDeficientProductRecord;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAccountAdd;
        private System.Windows.Forms.Button btnAccountEdit;
        private System.Windows.Forms.Button btnAccountDelete;
        private System.Windows.Forms.Button btnAccountSearch;
        private System.Windows.Forms.TableLayoutPanel tlpAccountInputField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.TextBox txtAccountConfirmPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccountPassword;
        private System.Windows.Forms.ComboBox cbxAccountVipLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnAccountConfirm;
        private System.Windows.Forms.Button btnAccountCancel;
        private System.Windows.Forms.Label lblAccountSubmitStatus;
        private System.Windows.Forms.DataGridView gvAccountSearch_Result;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ComboBox cbxFunctionList;
    }
}