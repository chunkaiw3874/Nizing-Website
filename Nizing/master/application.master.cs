using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class master_application : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void SideMenu_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
    {
        TreeNodeCollection ts = null;

        if (e.Node.Parent == null)
        {
            ts = ((TreeView)sender).Nodes;
        }
        else
        {
            ts = e.Node.Parent.ChildNodes;
        }

        foreach (TreeNode node in ts)
        {
            if (node != e.Node)
            {
                node.Collapse();
            }
        }
    }
    protected void SideMenu_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
    {
        TreeNodeCollection ts = null;

        if (e.Node.Parent == null)
        {
            ts = ((TreeView)sender).Nodes;
        }
        else
        {
            ts = e.Node.Parent.ChildNodes;
        }

        foreach (TreeNode node in ts)
        {
            node.CollapseAll();
        }
    }
}
