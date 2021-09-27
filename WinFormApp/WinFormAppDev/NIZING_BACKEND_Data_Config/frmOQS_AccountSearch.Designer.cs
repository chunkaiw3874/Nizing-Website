using NIZING_BACKEND_Data_Config;
namespace NIZING_BACKEND_Data_Config
{
    partial class frmOQS_AccountSearch
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
            this.txtAccountSearch_Name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccountSearch_StartingId = new System.Windows.Forms.TextBox();
            this.txtAccountSearch_EndingId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxAccountSearch_StartingVipLevel = new System.Windows.Forms.ComboBox();
            this.aCCOUNTVIPLEVELBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsOQS_LoginAccount = new NIZING_BACKEND_Data_Config.dsOQS_LoginAccount();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAccountSearch_Search = new System.Windows.Forms.Button();
            this.btnAccountSearch_Cancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxAccountSearch_EndingVipLevel = new System.Windows.Forms.ComboBox();
            this.aCCOUNT_VIPLEVELTableAdapter = new NIZING_BACKEND_Data_Config.dsOQS_LoginAccountTableAdapters.ACCOUNT_VIPLEVELTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aCCOUNTVIPLEVELBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOQS_LoginAccount)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.txtAccountSearch_Name, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtAccountSearch_StartingId, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAccountSearch_EndingId, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbxAccountSearch_StartingVipLevel, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbxAccountSearch_EndingVipLevel, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 362);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtAccountSearch_Name
            // 
            this.txtAccountSearch_Name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountSearch_Name.Location = new System.Drawing.Point(88, 129);
            this.txtAccountSearch_Name.Name = "txtAccountSearch_Name";
            this.txtAccountSearch_Name.Size = new System.Drawing.Size(150, 22);
            this.txtAccountSearch_Name.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "帳號名稱:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(91, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "帳號管理搜尋條件";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "起始帳號:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "結束帳號:";
            // 
            // txtAccountSearch_StartingId
            // 
            this.txtAccountSearch_StartingId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountSearch_StartingId.Location = new System.Drawing.Point(88, 49);
            this.txtAccountSearch_StartingId.Name = "txtAccountSearch_StartingId";
            this.txtAccountSearch_StartingId.Size = new System.Drawing.Size(150, 22);
            this.txtAccountSearch_StartingId.TabIndex = 4;
            // 
            // txtAccountSearch_EndingId
            // 
            this.txtAccountSearch_EndingId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountSearch_EndingId.Location = new System.Drawing.Point(88, 89);
            this.txtAccountSearch_EndingId.Name = "txtAccountSearch_EndingId";
            this.txtAccountSearch_EndingId.Size = new System.Drawing.Size(150, 22);
            this.txtAccountSearch_EndingId.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "VIP等級大於:";
            // 
            // cbxAccountSearch_StartingVipLevel
            // 
            this.cbxAccountSearch_StartingVipLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxAccountSearch_StartingVipLevel.DataSource = this.aCCOUNTVIPLEVELBindingSource;
            this.cbxAccountSearch_StartingVipLevel.DisplayMember = "LEVEL";
            this.cbxAccountSearch_StartingVipLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAccountSearch_StartingVipLevel.FormattingEnabled = true;
            this.cbxAccountSearch_StartingVipLevel.Location = new System.Drawing.Point(88, 170);
            this.cbxAccountSearch_StartingVipLevel.Name = "cbxAccountSearch_StartingVipLevel";
            this.cbxAccountSearch_StartingVipLevel.Size = new System.Drawing.Size(150, 20);
            this.cbxAccountSearch_StartingVipLevel.TabIndex = 12;
            this.cbxAccountSearch_StartingVipLevel.ValueMember = "LEVEL";
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAccountSearch_Search);
            this.flowLayoutPanel1.Controls.Add(this.btnAccountSearch_Cancel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(85, 240);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(199, 100);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // btnAccountSearch_Search
            // 
            this.btnAccountSearch_Search.Location = new System.Drawing.Point(3, 3);
            this.btnAccountSearch_Search.Name = "btnAccountSearch_Search";
            this.btnAccountSearch_Search.Size = new System.Drawing.Size(75, 23);
            this.btnAccountSearch_Search.TabIndex = 6;
            this.btnAccountSearch_Search.Text = "查詢";
            this.btnAccountSearch_Search.UseVisualStyleBackColor = true;
            this.btnAccountSearch_Search.Click += new System.EventHandler(this.btnAccountSearch_Search_Click);
            // 
            // btnAccountSearch_Cancel
            // 
            this.btnAccountSearch_Cancel.Location = new System.Drawing.Point(84, 3);
            this.btnAccountSearch_Cancel.Name = "btnAccountSearch_Cancel";
            this.btnAccountSearch_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btnAccountSearch_Cancel.TabIndex = 7;
            this.btnAccountSearch_Cancel.Text = "取消";
            this.btnAccountSearch_Cancel.UseVisualStyleBackColor = true;
            this.btnAccountSearch_Cancel.Click += new System.EventHandler(this.btnAccountSearch_Cancel_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "VIP等級小於:";
            // 
            // cbxAccountSearch_EndingVipLevel
            // 
            this.cbxAccountSearch_EndingVipLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxAccountSearch_EndingVipLevel.DataSource = this.aCCOUNTVIPLEVELBindingSource;
            this.cbxAccountSearch_EndingVipLevel.DisplayMember = "LEVEL";
            this.cbxAccountSearch_EndingVipLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAccountSearch_EndingVipLevel.FormattingEnabled = true;
            this.cbxAccountSearch_EndingVipLevel.Location = new System.Drawing.Point(88, 210);
            this.cbxAccountSearch_EndingVipLevel.Name = "cbxAccountSearch_EndingVipLevel";
            this.cbxAccountSearch_EndingVipLevel.Size = new System.Drawing.Size(150, 20);
            this.cbxAccountSearch_EndingVipLevel.TabIndex = 16;
            this.cbxAccountSearch_EndingVipLevel.ValueMember = "LEVEL";
            // 
            // aCCOUNT_VIPLEVELTableAdapter
            // 
            this.aCCOUNT_VIPLEVELTableAdapter.ClearBeforeFill = true;
            // 
            // frmOQS_AccountSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmOQS_AccountSearch";
            this.ShowIcon = false;
            this.Text = "帳號搜尋";
            this.Load += new System.EventHandler(this.frmAccountSearch_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aCCOUNTVIPLEVELBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOQS_LoginAccount)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccountSearch_StartingId;
        private System.Windows.Forms.TextBox txtAccountSearch_EndingId;
        private System.Windows.Forms.Button btnAccountSearch_Search;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAccountSearch_Cancel;
        private System.Windows.Forms.TextBox txtAccountSearch_Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxAccountSearch_StartingVipLevel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxAccountSearch_EndingVipLevel;
        private dsOQS_LoginAccount dsOQS_LoginAccount;
        private System.Windows.Forms.BindingSource aCCOUNTVIPLEVELBindingSource;
        private dsOQS_LoginAccountTableAdapters.ACCOUNT_VIPLEVELTableAdapter aCCOUNT_VIPLEVELTableAdapter;
    }
}