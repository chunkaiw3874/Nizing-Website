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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAccountSearch_Search = new System.Windows.Forms.Button();
            this.btnAccountSearch_Cancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxAccountSearch_StartingVipLevel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxAccountSearch_AdminRight = new System.Windows.Forms.ComboBox();
            this.aCCOUNTVIPLEVELBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsLoginAccount = new NIZING_BACKEND_Data_Config.dsLoginAccount();
            this.aCCOUNT_VIPLEVELTableAdapter = new NIZING_BACKEND_Data_Config.dsLoginAccountTableAdapters.ACCOUNT_VIPLEVELTableAdapter();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxAccountSearch_EndingVipLevel = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aCCOUNTVIPLEVELBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLoginAccount)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbxAccountSearch_AdminRight, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbxAccountSearch_EndingVipLevel, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 362);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtAccountSearch_Name
            // 
            this.txtAccountSearch_Name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountSearch_Name.Location = new System.Drawing.Point(88, 115);
            this.txtAccountSearch_Name.Name = "txtAccountSearch_Name";
            this.txtAccountSearch_Name.Size = new System.Drawing.Size(150, 22);
            this.txtAccountSearch_Name.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 120);
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
            this.label1.Location = new System.Drawing.Point(91, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "帳號管理搜尋條件";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "起始帳號:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "結束帳號:";
            // 
            // txtAccountSearch_StartingId
            // 
            this.txtAccountSearch_StartingId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountSearch_StartingId.Location = new System.Drawing.Point(88, 43);
            this.txtAccountSearch_StartingId.Name = "txtAccountSearch_StartingId";
            this.txtAccountSearch_StartingId.Size = new System.Drawing.Size(150, 22);
            this.txtAccountSearch_StartingId.TabIndex = 4;
            // 
            // txtAccountSearch_EndingId
            // 
            this.txtAccountSearch_EndingId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountSearch_EndingId.Location = new System.Drawing.Point(88, 79);
            this.txtAccountSearch_EndingId.Name = "txtAccountSearch_EndingId";
            this.txtAccountSearch_EndingId.Size = new System.Drawing.Size(150, 22);
            this.txtAccountSearch_EndingId.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAccountSearch_Search);
            this.flowLayoutPanel1.Controls.Add(this.btnAccountSearch_Cancel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(85, 252);
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
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "VIP等級大於:";
            // 
            // cbxAccountSearch_StartingVipLevel
            // 
            this.cbxAccountSearch_StartingVipLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxAccountSearch_StartingVipLevel.FormattingEnabled = true;
            this.cbxAccountSearch_StartingVipLevel.Items.AddRange(new object[] {
            "\"select\""});
            this.cbxAccountSearch_StartingVipLevel.Location = new System.Drawing.Point(88, 152);
            this.cbxAccountSearch_StartingVipLevel.Name = "cbxAccountSearch_StartingVipLevel";
            this.cbxAccountSearch_StartingVipLevel.Size = new System.Drawing.Size(150, 20);
            this.cbxAccountSearch_StartingVipLevel.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "管理者權限:";
            // 
            // cbxAccountSearch_AdminRight
            // 
            this.cbxAccountSearch_AdminRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxAccountSearch_AdminRight.FormattingEnabled = true;
            this.cbxAccountSearch_AdminRight.Items.AddRange(new object[] {
            "",
            "0",
            "1"});
            this.cbxAccountSearch_AdminRight.Location = new System.Drawing.Point(88, 224);
            this.cbxAccountSearch_AdminRight.Name = "cbxAccountSearch_AdminRight";
            this.cbxAccountSearch_AdminRight.Size = new System.Drawing.Size(150, 20);
            this.cbxAccountSearch_AdminRight.TabIndex = 14;
            // 
            // aCCOUNTVIPLEVELBindingSource
            // 
            this.aCCOUNTVIPLEVELBindingSource.DataMember = "ACCOUNT_VIPLEVEL";
            this.aCCOUNTVIPLEVELBindingSource.DataSource = this.dsLoginAccount;
            // 
            // dsLoginAccount
            // 
            this.dsLoginAccount.DataSetName = "dsLoginAccount";
            this.dsLoginAccount.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aCCOUNT_VIPLEVELTableAdapter
            // 
            this.aCCOUNT_VIPLEVELTableAdapter.ClearBeforeFill = true;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "VIP等級小於:";
            // 
            // cbxAccountSearch_EndingVipLevel
            // 
            this.cbxAccountSearch_EndingVipLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxAccountSearch_EndingVipLevel.FormattingEnabled = true;
            this.cbxAccountSearch_EndingVipLevel.Items.AddRange(new object[] {
            "\"select\""});
            this.cbxAccountSearch_EndingVipLevel.Location = new System.Drawing.Point(88, 188);
            this.cbxAccountSearch_EndingVipLevel.Name = "cbxAccountSearch_EndingVipLevel";
            this.cbxAccountSearch_EndingVipLevel.Size = new System.Drawing.Size(150, 20);
            this.cbxAccountSearch_EndingVipLevel.TabIndex = 16;
            // 
            // frmAccountSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmAccountSearch";
            this.Text = "frmAccountSearch";
            this.Load += new System.EventHandler(this.frmAccountSearch_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aCCOUNTVIPLEVELBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLoginAccount)).EndInit();
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
        private dsLoginAccount dsLoginAccount;
        private System.Windows.Forms.BindingSource aCCOUNTVIPLEVELBindingSource;
        private NIZING_BACKEND_Data_Config.dsLoginAccountTableAdapters.ACCOUNT_VIPLEVELTableAdapter aCCOUNT_VIPLEVELTableAdapter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxAccountSearch_AdminRight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxAccountSearch_EndingVipLevel;
    }
}