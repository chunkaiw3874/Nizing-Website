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
    public partial class frmHR360_AccountSearchERPID : Form
    {
        string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
        string NZConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
        public event searchForm_Close loadButtonEvent;
        public event searchForm_Select loadSelectionEvent;

        public frmHR360_AccountSearchERPID()
        {
            InitializeComponent();
            
        }

        private void btnAccountSearchERPID_Cancel_Click(object sender, EventArgs e)
        {
            if (loadButtonEvent != null)
            {
                loadButtonEvent();
            }
            this.Close();
        }

        private void frmHR360_AccountSearchERPID_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnAccountSearchERPID_Cancel_Click(sender, e);
        }
    }
}
