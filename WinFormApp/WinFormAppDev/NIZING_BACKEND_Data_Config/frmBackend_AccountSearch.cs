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
            dsBackendLoginAccountTableAdapters.BACKEND_FUNCTION_LISTTableAdapter adapter = new dsBackendLoginAccountTableAdapters.BACKEND_FUNCTION_LISTTableAdapter();
            DataTable dtFunctionList = adapter.GetData();
            //((ListBox)this.clbAdminRights).DataSource = dtFunctionList;
            //((ListBox)this.clbAdminRights).DisplayMember = "NAME";
            //((ListBox)this.clbAdminRights).ValueMember = "ID";
        }

        private void btnAccountSearch_Search_Click(object sender, EventArgs e)
        {
            DataTable dtSearchResult = new DataTable();
            dsBackendLoginAccountTableAdapters.BACKEND_LOGIN_ACCOUNTTableAdapter adapter = new dsBackendLoginAccountTableAdapters.BACKEND_LOGIN_ACCOUNTTableAdapter();
            dtSearchResult = adapter.GetData();
            var active = dtSearchResult.AsEnumerable().Where(x => ((string)x["ACTIVE"]).CompareTo("1") == 0);
            if (active.Any())
            {
                dtSearchResult = active.CopyToDataTable();
            }
            else
            {
                dtSearchResult.Clear();
            }
            if (dtSearchResult.Rows.Count > 0)
            {
                string startAccountIdFilter = txtAccountSearch_StartingId.Text.ToUpper().Trim();
                string endAccountIdFilter = txtAccountSearch_EndingId.Text.ToUpper().Trim();
                //List<string> adminRightsFilter = new List<string>();
                //foreach (DataRowView row in clbAdminRights.CheckedItems)
                //{
                //    adminRightsFilter.Add(row["ID"].ToString());
                //}
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
                    var rows = dtSearchResult.AsEnumerable().Where(x => ((string)x["LOGIN_ID"]).CompareTo(startAccountIdFilter) <= 0);
                    if (rows.Any())
                    {
                        dtSearchResult = rows.CopyToDataTable();
                    }
                    else
                    {
                        dtSearchResult.Clear();
                    }
                }

                //if (adminRightsFilter.Count > 0)
                //{
                //    string condition = "";
                //    int i = 0;
                //    foreach (string s in adminRightsFilter)
                //    {
                //        if (i == 0)
                //        {
                //            condition += "[AUTH_ID]='" + s + "'";
                //        }
                //        else
                //        {
                //            condition += " AND [AUTH_ID]='" + s + "'";
                //        }
                //        i++;
                //    }
                //    DataRow[] result = dtSearchResult.Select(condition);
                    
                //    foreach (DataRow row in result)
                //    {
                //        dtSearchResult.ImportRow(row);
                //    }
                //    //var rows = dtSearchResult.AsEnumerable().Where(x => ((string)x["AUTH_ID"]).CompareTo(s) == 0);
                //    //if (rows.Any())
                //    //{
                //    //    dtSearchResult = rows.CopyToDataTable();
                //    //}
                //    //else
                //    //{
                //    //    dtSearchResult.Clear();
                //    //}
                //}
            }
            if (loadGridviewEvent != null)
            {
                loadGridviewEvent(dtSearchResult);
            }

            if (loadButtonEvent != null)
            {
                loadButtonEvent();
            }
        }

        private void btnAccountSearch_Cancel_Click(object sender, EventArgs e)
        {
            if (loadButtonEvent != null)
            {
                loadButtonEvent();
            }
            this.Close();
        }
    }
}
