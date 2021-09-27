using NIZING_BACKEND_Data_Config;
namespace NIZING_BACKEND_Data_Config
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbpnlLogin = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblLoginStatus = new System.Windows.Forms.Label();
            this.cbxFunctionList = new System.Windows.Forms.ComboBox();
            this.bACKENDFUNCTIONLISTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBackendLoginAccount = new NIZING_BACKEND_Data_Config.dsBackendLoginAccount();
            this.label3 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.dsBackendLoginAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bACKEND_FUNCTION_LISTTableAdapter = new NIZING_BACKEND_Data_Config.dsBackendLoginAccountTableAdapters.BACKEND_FUNCTION_LISTTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbpnlLogin.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bACKENDFUNCTIONLISTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBackendLoginAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBackendLoginAccountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tbpnlLogin, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblVersion, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 562);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbpnlLogin
            // 
            this.tbpnlLogin.ColumnCount = 3;
            this.tbpnlLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31F));
            this.tbpnlLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbpnlLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tbpnlLogin.Controls.Add(this.label1, 0, 1);
            this.tbpnlLogin.Controls.Add(this.label2, 0, 2);
            this.tbpnlLogin.Controls.Add(this.txtUserName, 1, 1);
            this.tbpnlLogin.Controls.Add(this.txtPassword, 1, 2);
            this.tbpnlLogin.Controls.Add(this.flowLayoutPanel1, 1, 4);
            this.tbpnlLogin.Controls.Add(this.cbxFunctionList, 1, 3);
            this.tbpnlLogin.Controls.Add(this.label3, 1, 0);
            this.tbpnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbpnlLogin.Location = new System.Drawing.Point(159, 115);
            this.tbpnlLogin.Name = "tbpnlLogin";
            this.tbpnlLogin.RowCount = 5;
            this.tbpnlLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbpnlLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tbpnlLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tbpnlLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tbpnlLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tbpnlLogin.Size = new System.Drawing.Size(464, 331);
            this.tbpnlLogin.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "帳號:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密碼:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUserName.Location = new System.Drawing.Point(146, 79);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(226, 22);
            this.txtUserName.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPassword.Location = new System.Drawing.Point(146, 128);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(226, 22);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnLogin);
            this.flowLayoutPanel1.Controls.Add(this.lblLoginStatus);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(143, 213);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(232, 118);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.Location = new System.Drawing.Point(3, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(226, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "登入";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoginStatus.AutoSize = true;
            this.lblLoginStatus.ForeColor = System.Drawing.Color.Red;
            this.lblLoginStatus.Location = new System.Drawing.Point(3, 29);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(226, 12);
            this.lblLoginStatus.TabIndex = 1;
            // 
            // cbxFunctionList
            // 
            this.cbxFunctionList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxFunctionList.DataSource = this.bACKENDFUNCTIONLISTBindingSource;
            this.cbxFunctionList.DisplayMember = "NAME";
            this.cbxFunctionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFunctionList.FormattingEnabled = true;
            this.cbxFunctionList.Location = new System.Drawing.Point(146, 167);
            this.cbxFunctionList.Name = "cbxFunctionList";
            this.cbxFunctionList.Size = new System.Drawing.Size(226, 20);
            this.cbxFunctionList.TabIndex = 4;
            this.cbxFunctionList.ValueMember = "ID";
            // 
            // bACKENDFUNCTIONLISTBindingSource
            // 
            this.bACKENDFUNCTIONLISTBindingSource.DataMember = "BACKEND_FUNCTION_LIST";
            this.bACKENDFUNCTIONLISTBindingSource.DataSource = this.dsBackendLoginAccount;
            // 
            // dsBackendLoginAccount
            // 
            this.dsBackendLoginAccount.DataSetName = "dsBackendLoginAccount";
            this.dsBackendLoginAccount.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(146, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "日進終端系統設定";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.fastLogin);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(781, 550);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(0, 12);
            this.lblVersion.TabIndex = 1;
            // 
            // dsBackendLoginAccountBindingSource
            // 
            this.dsBackendLoginAccountBindingSource.DataSource = this.dsBackendLoginAccount;
            this.dsBackendLoginAccountBindingSource.Position = 0;
            // 
            // bACKEND_FUNCTION_LISTTableAdapter
            // 
            this.bACKEND_FUNCTION_LISTTableAdapter.ClearBeforeFill = true;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmLogin";
            this.Text = "登入";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tbpnlLogin.ResumeLayout(false);
            this.tbpnlLogin.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bACKENDFUNCTIONLISTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBackendLoginAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBackendLoginAccountBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tbpnlLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLoginStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cbxFunctionList;
        private dsBackendLoginAccount dsBackendLoginAccount;
        private System.Windows.Forms.BindingSource dsBackendLoginAccountBindingSource;
        private System.Windows.Forms.BindingSource bACKENDFUNCTIONLISTBindingSource;
        private NIZING_BACKEND_Data_Config.dsBackendLoginAccountTableAdapters.BACKEND_FUNCTION_LISTTableAdapter bACKEND_FUNCTION_LISTTableAdapter;
        private System.Windows.Forms.Label lblVersion;

    }
}

