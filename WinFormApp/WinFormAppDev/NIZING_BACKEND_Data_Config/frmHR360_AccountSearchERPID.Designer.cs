namespace NIZING_BACKEND_Data_Config
{
    partial class frmHR360_AccountSearchERPID
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
            this.gvERPIDList = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvERPIDList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gvERPIDList, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 362);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gvERPIDList
            // 
            this.gvERPIDList.AllowUserToAddRows = false;
            this.gvERPIDList.AllowUserToDeleteRows = false;
            this.gvERPIDList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvERPIDList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvERPIDList.Location = new System.Drawing.Point(0, 0);
            this.gvERPIDList.Margin = new System.Windows.Forms.Padding(0);
            this.gvERPIDList.MultiSelect = false;
            this.gvERPIDList.Name = "gvERPIDList";
            this.gvERPIDList.ReadOnly = true;
            this.gvERPIDList.RowTemplate.Height = 24;
            this.gvERPIDList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvERPIDList.Size = new System.Drawing.Size(284, 362);
            this.gvERPIDList.TabIndex = 0;
            this.gvERPIDList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvERPIDList_CellDoubleClick);
            // 
            // frmHR360_AccountSearchERPID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmHR360_AccountSearchERPID";
            this.Text = "ERP使用者代號查詢";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHR360_AccountSearchERPID_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvERPIDList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView gvERPIDList;

    }
}