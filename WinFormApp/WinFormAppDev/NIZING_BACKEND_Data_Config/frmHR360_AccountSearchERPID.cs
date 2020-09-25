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
        string SunrizeConnectionString = ConfigurationManager.ConnectionStrings["SunrizeConnectionString"].ConnectionString;
        string defaultConnectionString;
        public event searchForm_Close loadButtonEvent;
        public event searchForm_Select loadSelectionEvent;
        private bool selectionMade { get; set; }
        DataSet ds = new DataSet();

        public frmHR360_AccountSearchERPID(string company)
        {
            InitializeComponent();
            if (company == "日進電線")
            {
                defaultConnectionString = NZConnectionString;
            }
            else
            {
                defaultConnectionString = SunrizeConnectionString;
            }
            using (SqlConnection conn = new SqlConnection(defaultConnectionString))
            {
                conn.Open();
                string query = "SELECT LTRIM(RTRIM(MV.MV001)) '員工代號', LTRIM(RTRIM(MV.MV002)) '員工姓名'"
                            + " FROM CMSMV MV"
                            + " WHERE MV.MV001 NOT LIKE 'PT%'"
                            + " AND LTRIM(RTRIM(MV.MV022)) = ''"
                            + " AND MV.MV001 <> '0000'"
                            + " AND MV.MV001 <> '0098'"
                            + " ORDER BY MV.MV001";                            
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);                
                da.Fill(ds, "ERPIDList");
                gvERPIDList.DataSource = ds.Tables["ERPIDList"];                
            }
        }

        private void btnAccountSearchERPID_Cancel_Click(object sender, EventArgs e)
        {
            if (loadButtonEvent != null)
            {
                loadButtonEvent();
            }
            selectionMade = false;
        }

        private void frmHR360_AccountSearchERPID_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (loadButtonEvent != null)
            {
                loadButtonEvent();
            }
        }

        private void gvERPIDList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (loadSelectionEvent != null)
            {
                loadSelectionEvent(ds.Tables["ERPIDList"].Select("員工代號 = '" + gvERPIDList.SelectedRows[0].Cells["員工代號"].Value+"'"));
            }
            selectionMade = true;
            this.Close();
        }
    }
}
