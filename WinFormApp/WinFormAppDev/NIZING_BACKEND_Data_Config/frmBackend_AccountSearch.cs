using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NIZING_BACKEND_Data_Config
{
    //public delegate void searchForm_Close();
    //public delegate void searchForm_Search(DataTable dt);

    public partial class frmBackend_AccountSearch : Form
    {
        public event searchForm_Close loadButtonEvent;
        public event searchForm_Search loadGridviewEvent;

        public frmBackend_AccountSearch()
        {
            InitializeComponent();
        }
    }
}
