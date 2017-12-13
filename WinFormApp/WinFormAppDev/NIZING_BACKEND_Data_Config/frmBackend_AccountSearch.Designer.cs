namespace NIZING_BACKEND_Data_Config
{
    partial class frmBackend_AccountSearch
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAccountSearch_Search = new System.Windows.Forms.Button();
            this.btnAccountSearch_Cancel = new System.Windows.Forms.Button();
            this.txtAccountSearch_EndingId = new System.Windows.Forms.TextBox();
            this.txtAccountSearch_StartingId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbAdminRights = new System.Windows.Forms.CheckedListBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAccountSearch_Search);
            this.flowLayoutPanel1.Controls.Add(this.btnAccountSearch_Cancel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(85, 325);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(199, 37);
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
            // txtAccountSearch_EndingId
            // 
            this.txtAccountSearch_EndingId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountSearch_EndingId.Location = new System.Drawing.Point(88, 79);
            this.txtAccountSearch_EndingId.Name = "txtAccountSearch_EndingId";
            this.txtAccountSearch_EndingId.Size = new System.Drawing.Size(150, 22);
            this.txtAccountSearch_EndingId.TabIndex = 5;
            // 
            // txtAccountSearch_StartingId
            // 
            this.txtAccountSearch_StartingId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAccountSearch_StartingId.Location = new System.Drawing.Point(88, 43);
            this.txtAccountSearch_StartingId.Name = "txtAccountSearch_StartingId";
            this.txtAccountSearch_StartingId.Size = new System.Drawing.Size(150, 22);
            this.txtAccountSearch_StartingId.TabIndex = 4;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtAccountSearch_StartingId, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAccountSearch_EndingId, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 362);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clbAdminRights);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(88, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 211);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "權限查詢";
            // 
            // clbAdminRights
            // 
            this.clbAdminRights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbAdminRights.FormattingEnabled = true;
            this.clbAdminRights.Location = new System.Drawing.Point(3, 18);
            this.clbAdminRights.Name = "clbAdminRights";
            this.clbAdminRights.Size = new System.Drawing.Size(187, 190);
            this.clbAdminRights.TabIndex = 0;
            // 
            // frmBackend_AccountSearch
            // 
            this.AcceptButton = this.btnAccountSearch_Search;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmBackend_AccountSearch";
            this.Text = "帳號搜尋";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBackend_AccountSearch_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAccountSearch_Search;
        private System.Windows.Forms.Button btnAccountSearch_Cancel;
        private System.Windows.Forms.TextBox txtAccountSearch_EndingId;
        private System.Windows.Forms.TextBox txtAccountSearch_StartingId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clbAdminRights;

    }
}