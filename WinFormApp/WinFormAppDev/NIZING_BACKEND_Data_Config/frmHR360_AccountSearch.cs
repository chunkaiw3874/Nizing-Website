using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NIZING_BACKEND_Data_Config
{
    public partial class frmHR360_AccountSearch : Form
    {
        string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["OQS_Data_Config.Properties.Settings.NZ_ERP2ConnectionString"].ConnectionString;
        public event searchForm_Close loadButtonEvent;
        public event searchForm_Search loadGridviewEvent;

        public frmHR360_AccountSearch()
        {
            InitializeComponent();
        }

        private void btnAccountSearch_Cancel_Click(object sender, EventArgs e)
        {
            if (loadButtonEvent != null)
            {
                loadButtonEvent();
            }
            this.Close();
        }

        private void frmHR360_AccountSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnAccountSearch_Cancel_Click(sender, e);
        }
    }
}
