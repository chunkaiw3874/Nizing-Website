using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class masterPage_HR360_Child : System.Web.UI.MasterPage
{
    string NZConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string userId = (string)Session["user_id"];
            bool validation = (bool)(Session["validated"]);
        }
        catch
        {
            Server.Transfer("~/hr360/no_permission.aspx"); //session expires and value stored in session value disappears
        }
        if (!IsPostBack)
        {

        }
    }
    protected void PopulateSideMenu()
    {
        TreeView1.NodeStyle.CssClass = "node";
        TreeView1.RootNodeStyle.CssClass = "root";
        TreeView1.LeafNodeStyle.CssClass = "leaf";
        DataTable dtleftmenu = new DataTable();
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            //string query = "";
            SqlCommand sqlSearch = new SqlCommand("SELECT [HR360_BI03_A].[ID] CATEGORY_ID, [HR360_BI03_A].[IMAGE_URL] CATEGORY_IMGURL, [HR360_BI03_B].[ID] MODULE_ID, [HR360_BI03_B].[IMAGE_URL] MODULE_IMGURL, [HR360_BI03_B].[URL] MODULE_URL"
                                                    + " FROM [HR360_BI03_B]"
                                                    + " LEFT JOIN [HR360_BI03_A] ON [HR360_BI03_B].[CATEGORY_ID] = [HR360_BI03_A].[ID]"
                                                    + " ORDER BY [HR360_BI03_A].[SEQ_NO]", conn);
            SqlDataAdapter da = new SqlDataAdapter(sqlSearch);            
            da.Fill(dtleftmenu);
        }

        if (dtleftmenu.Rows.Count != 0)
        {
            for (int i = 0; i < dtleftmenu.Rows.Count; i++)
            {
                TreeNode node = new TreeNode();
                TreeNode childnode = new TreeNode();
                if (i == 0)
                {
                    node.Value = dtleftmenu.Rows[i][0].ToString();
                    node.ImageUrl = dtleftmenu.Rows[i][1].ToString();
                    node.SelectAction = TreeNodeSelectAction.Expand;
                    TreeView1.Nodes.Add(node);
                    childnode.Value = dtleftmenu.Rows[i][2].ToString();
                    childnode.ImageUrl = dtleftmenu.Rows[i][3].ToString();
                    //if ((Session["permission"] as DataTable).Rows.Count != 0 &&
                    //    ((Session["permission"] as DataTable).Rows[0][5].ToString().ToUpper().Equals("TRUE")
                    //    || ((Session["permission"] as DataTable).Select("MODULE_ID = '"+dtleftmenu.Rows[i][2].ToString()+"'"))[0][6].ToString().ToUpper().Equals("TRUE")))
                    //{
                        childnode.NavigateUrl = dtleftmenu.Rows[i][4].ToString();
                    //}
                    //else
                    //{
                    //    childnode.NavigateUrl = "javascript:alert('無此權限')";
                    //}
                        
                    node.ChildNodes.Add(childnode);
                }
                else
                {
                    if (dtleftmenu.Rows[i][0].ToString() == dtleftmenu.Rows[i - 1][0].ToString())
                    {
                        node = TreeView1.FindNode(dtleftmenu.Rows[i][0].ToString());
                        childnode.Value = dtleftmenu.Rows[i][2].ToString();
                        childnode.ImageUrl = dtleftmenu.Rows[i][3].ToString();
                        //if ((Session["permission"] as DataTable).Rows.Count != 0 &&
                        //   ((Session["permission"] as DataTable).Rows[0][5].ToString().ToUpper().Equals("TRUE")
                        //|| ((Session["permission"] as DataTable).Select("MODULE_ID = '" + dtleftmenu.Rows[i][2].ToString() + "'"))[0][6].ToString().ToUpper().Equals("TRUE")))
                        //{
                            childnode.NavigateUrl = dtleftmenu.Rows[i][4].ToString();
                        //}
                        //else
                        //{
                        //    childnode.NavigateUrl = "javascript:alert('無此權限');";
                        //}
                        node.ChildNodes.Add(childnode);
                    }
                    else
                    {
                        node.Value = dtleftmenu.Rows[i][0].ToString();
                        node.ImageUrl = dtleftmenu.Rows[i][1].ToString();
                        node.SelectAction = TreeNodeSelectAction.Expand;
                        TreeView1.Nodes.Add(node);
                        childnode.Value = dtleftmenu.Rows[i][2].ToString();
                        childnode.ImageUrl = dtleftmenu.Rows[i][3].ToString();
                        try
                        {
                            //if ((Session["permission"] as DataTable).Rows.Count != 0 &&
                            //   ((Session["permission"] as DataTable).Rows[0][5].ToString().ToUpper().Equals("TRUE")
                            //|| ((Session["permission"] as DataTable).Select("MODULE_ID = '" + dtleftmenu.Rows[i][2].ToString() + "'"))[0][6].ToString().ToUpper().Equals("TRUE")))
                            //{
                                childnode.NavigateUrl = dtleftmenu.Rows[i][4].ToString();
                            //}
                            //else
                            //{
                            //    childnode.NavigateUrl = "javascript:alert('無此權限');";

                            //}
                        }
                        catch
                        {

                        }
                        node.ChildNodes.Add(childnode);
                    }
                }
            }
        }
        //add boss section
        if (Session["user_id"].ToString().ToUpper() == "CHRISSY" || Session["user_id"].ToString().ToUpper() == "KELVEN"
            || Session["user_id"].ToString().ToUpper() == "0006" || Session["user_id"].ToString().ToUpper() == "0007")
        {
            TreeNode node = new TreeNode();
            TreeNode childnode = new TreeNode();
            node.Value = "AS00";
            node.ImageUrl = "~/hr360/image/icon/left_menu/AS00-1.png";
            node.SelectAction = TreeNodeSelectAction.Expand;
            TreeView1.Nodes.Add(node);
            childnode.Value = "AS01";
            childnode.ImageUrl = "~/hr360/image/icon/left_menu/BI01-1.png";
            childnode.NavigateUrl = "~/no_permission.aspx";
            node.ChildNodes.Add(childnode);
        }
    }
    //calling encrypting method from parent master
    public string Encrypt(string clearText)
    {
        return ((masterPage_HR360_Master)this.Master).Encrypt(clearText);
    }
    public string Decrypt(string cipherText)
    {
        return ((masterPage_HR360_Master)this.Master).Decrypt(cipherText);
    }
    protected string GetUserName(string strIn)
    {
        string name = "";
        using (SqlConnection conn = new SqlConnection(NZConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT CMSMV.MV002 FROM CMSMV WHERE CMSMV.MV001 = N'" + strIn + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = reader.GetString(0);
                }
            }
            else
            {
                name = "此使用者不存在";
            }
        }
        return name;
    }
    protected void btnLogout_Click(object sender, ImageClickEventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/hr360/login.aspx");
    }
    protected void btnHome_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/hr360/main.aspx");
    }    
    protected void btnAdminPage_Click(object sender, ImageClickEventArgs e)
    {
        if (((DataTable)Session["permission"]).Rows[0]["SUPER_USER"].ToString().Trim() == "1")
        {
            Response.Redirect("~/hr360/admin_main.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('無此權限');", true);
        }
    }
    protected void TreeView1_Load(object sender, EventArgs e)
    {
        if (Session["TreeViewState"] == null)
        {
            PopulateSideMenu();
            // Record the TreeView's current expand/collapse state.
            List<string> list = new List<string>(16);
            SaveTreeViewState(TreeView1.Nodes, list);
            Session["TreeViewState"] = list;
        }
        else
        {
            TreeView1.Nodes.Clear();
            PopulateSideMenu();
            // Apply the recorded expand/collapse state to the TreeView.
            List<string> list = (List<string>)Session["TreeViewState"];
            RestoreTreeViewState(TreeView1.Nodes, list);
        }
    }
    //The save state func...
    private void SaveTreeViewState(TreeNodeCollection nodes, List<string> list)
    {
        // Recursivley record all expanded nodes in the List.
        foreach (TreeNode node in nodes)
        {
            if (node.ChildNodes != null && node.ChildNodes.Count != 0)
            {
                if (node.Expanded.HasValue && node.Expanded == true && !String.IsNullOrEmpty(node.Value.ToString()))
                {
                    list.Add(node.Value.ToString());
                }
                SaveTreeViewState(node.ChildNodes, list);
            }
        }
    }
    //The restore state func...
    private void RestoreTreeViewState(TreeNodeCollection nodes, List<string> list)
    {
        foreach (TreeNode node in nodes)
        {
            // Restore the state of one node.
            if (list.Contains(node.Value.ToString()))
            {
                if (node.ChildNodes != null && node.ChildNodes.Count != 0)
                {
                    node.Expand();
                    //node.Expanded = true;
                }
            }
            else
            {
                if (node.ChildNodes != null && node.ChildNodes.Count != 0)
                {
                    node.Collapse();
                    //node.Expanded = false;
                }
            }
            // If the node has child nodes, restore their state, too.
            if (node.ChildNodes != null && node.ChildNodes.Count != 0)
            {
                RestoreTreeViewState(node.ChildNodes, list);
            }            
        }
    }

    protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
    {        
        e.Node.Expand();
        e.Node.Selected = true;
        for (int i = 0; i < TreeView1.Nodes.Count; i++)
        {
            if(TreeView1.Nodes[i].Selected == false)
            {   
                TreeNode node = TreeView1.Nodes[i];
                node.ImageUrl = ReplaceAt(node.ImageUrl.ToString(), node.ImageUrl.ToString().Length - 5, '1');
            }
            else
            {
                TreeNode node = TreeView1.Nodes[i];
                node.ImageUrl = ReplaceAt(node.ImageUrl.ToString(), node.ImageUrl.ToString().Length - 5, '2');
            }
        }
    }
    protected void TreeView1_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
    {
        e.Node.Collapse();
        e.Node.ImageUrl = e.Node.ImageUrl.Replace('2', '1');
    }
    protected void TreeView1_Unload(object sender, EventArgs e)
    {
        List<string> list = new List<string>(16);
        SaveTreeViewState(TreeView1.Nodes, list);
        Session["TreeViewState"] = list;
    }

    //for string replacement at specific index
    public static string ReplaceAt(string input, int index, char newChar)
    {
        if (input == null)
        {
            throw new ArgumentNullException("input");
        }
        char[] chars = input.ToCharArray();
        chars[index] = newChar;
        return new string(chars);
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {

    }
    protected void btnReport_Click(object sender, ImageClickEventArgs e)
    {

    }
}
