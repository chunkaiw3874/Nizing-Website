using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class index : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] segments = Request.Url.Segments;
        string s = segments[segments.Length - 2];

        if(s == "en/")
        {
            string st = "";
            for(int i = 0; i < segments.Length; i++)
            {
                if(i != segments.Length-2)
                {
                    st = st + segments[i];
                }
            }
            linkEnglish.NavigateUrl = Request.Url.AbsoluteUri;
            linkChinese.NavigateUrl = Request.Url.Scheme + "://" + Request.Url.Authority + st;
        }
        else
        {
            string st = "";
            for (int i = 0; i < segments.Length;i++)
            {                
                if(i != segments.Length - 1)
                {
                    st = st + segments[i];
                }
                else
                {
                    st = st + "en\\" + segments[i];
                }
            }
            linkChinese.NavigateUrl = Request.Url.AbsoluteUri;
            linkEnglish.NavigateUrl = Request.Url.Scheme + "://" + Request.Url.Authority + st;
        }

        if(System.IO.Path.GetFileName(Request.PhysicalPath) == "default.aspx")
        {
            directory.Visible = false;
        }
        else
        {
            directory.Visible = true;
        }
    }

    //protected void SideMenu_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
    //{
    //    TreeNodeCollection ts = null;

    //    if (e.Node.Parent == null)
    //    {
    //        ts = ((TreeView)sender).Nodes;
    //    }
    //    else
    //    {
    //        ts = e.Node.Parent.ChildNodes;
    //    }

    //    foreach (TreeNode node in ts)
    //    {
    //        if (node != e.Node)
    //        {
    //            node.Collapse();
    //        }
    //    }
    //}
}
