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
    public partial class frmBackend_AccountSearch : Form
    {
        string erp2ConnectionString = ConfigurationManager.ConnectionStrings["OQS_Data_Config.Properties.Settings.NZ_ERP2ConnectionString"].ConnectionString;
        public event searchForm_Close loadButtonEvent;
        public event searchForm_Search loadGridviewEvent;

        public frmBackend_AccountSearch()
        {
            InitializeComponent();
            dsBackendLoginAccountTableAdapters.BACKEND_FUNCTION_LISTTableAdapter adapter = new dsBackendLoginAccountTableAdapters.BACKEND_FUNCTION_LISTTableAdapter();
            DataTable dtFunctionList = adapter.GetData();
            ((ListBox)this.clbAdminRights).DataSource = dtFunctionList;
            ((ListBox)this.clbAdminRights).DisplayMember = "NAME";
            ((ListBox)this.clbAdminRights).ValueMember = "ID";
        }

        private void btnAccountSearch_Search_Click(object sender, EventArgs e)
        {
            DataTable dtSearchResult = new DataTable();
            using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
            {
                conn.Open();
                string query = "DECLARE @cols NVARCHAR(MAX)"
                        + " SELECT @cols = ISNULL(@cols+',','')+'['+ID+']'"
                        + " FROM BACKEND_FUNCTION_LIST"
                        + " ORDER BY [ID]"
                        + " DECLARE @query NVARCHAR(MAX)"
                        + " SET @query = N'SELECT [LOGIN_ID],[LOGIN_PASSWORD],' + @cols + ' FROM"
                        + " ("
                        + " SELECT"
                        + " [FUNC].[ID] [AUTH_ID],"
                        + " [LOGIN].[ID] [LOGIN_ID],"
                        + " [LOGIN].[PASSWORD] [LOGIN_PASSWORD],"
                        + " CONVERT(INT,[AUTH].[ACTIVE]) [ACTIVE]"
                        + " FROM BACKEND_LOGIN_ACCOUNT [LOGIN]"
                        + " LEFT JOIN BACKEND_LOGIN_AUTHORIZATION [AUTH] ON [LOGIN].[ID]=[AUTH].ID"
                        + " LEFT JOIN BACKEND_FUNCTION_LIST [FUNC] ON [AUTH].ACCESS_FUNCTION_ID=[FUNC].[ID]"
                        + " ) P"
                        + " PIVOT"
                        + " ("
                        + " SUM([ACTIVE])"
                        + " FOR [AUTH_ID] IN"
                        + " (' + @cols + ')"
                        + " ) AS PVT"
                        + " ORDER BY [LOGIN_ID]"
                        + " '"
                        + " EXEC (@query)";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtSearchResult);
            }
            if (dtSearchResult.Rows.Count > 0)
            {
                string startAccountIdFilter = txtAccountSearch_StartingId.Text.ToUpper().Trim();
                string endAccountIdFilter = txtAccountSearch_EndingId.Text.ToUpper().Trim();
                List<string> adminRightsFilter = new List<string>();
                foreach (DataRowView row in clbAdminRights.CheckedItems)
                {
                    adminRightsFilter.Add(row["ID"].ToString());
                }
                if (!String.IsNullOrWhiteSpace(startAccountIdFilter))
                {
                    var rows = dtSearchResult.AsEnumerable().Where(x => ((string)x["LOGIN_ID"]).CompareTo(startAccountIdFilter) >= 0);
                    if (rows.Any())
                    {
                        dtSearchResult = rows.CopyToDataTable();
                    }
                    else
                    {
                        dtSearchResult.Clear();
                    }
                }
                if (!String.IsNullOrWhiteSpace(endAccountIdFilter))
                {
                    var rows = dtSearchResult.AsEnumerable().Where(x => ((string)x["LOGIN_ID"]).CompareTo(endAccountIdFilter) <= 0);
                    if (rows.Any())
                    {
                        dtSearchResult = rows.CopyToDataTable();
                    }
                    else
                    {
                        dtSearchResult.Clear();
                    }
                }

                if (adminRightsFilter.Count > 0)
                {                    
                    foreach (string s in adminRightsFilter)
                    {
                        var rows = dtSearchResult.AsEnumerable().Where(x => ((int)x[s]).CompareTo(1) == 0);
                        if (rows.Any())
                        {
                            dtSearchResult = rows.CopyToDataTable();
                        }
                        else
                        {
                            dtSearchResult.Clear();
                        }
                    }
                }
            }
            if (loadGridviewEvent != null)
            {
                loadGridviewEvent(dtSearchResult);
            }

            if (loadButtonEvent != null)
            {
                loadButtonEvent();
            }

            this.Close();
        }

        private void btnAccountSearch_Cancel_Click(object sender, EventArgs e)
        {
            if (loadButtonEvent != null)
            {
                loadButtonEvent();
            }
            this.Close();
        }

        private void frmBackend_AccountSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnAccountSearch_Cancel_Click(sender, e);
        }
    }
}
