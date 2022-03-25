<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="news" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title><%if (RouteData.Values["language"].ToString() == "zh")
               {%>
                                                日進電線-最新消息 <%=DateTime.Now.Year.ToString() %>
        <%}
            else
            {%>
                                                Latest News - Nizing Electric Wire & Cable <%=DateTime.Now.Year.ToString() %>
        <%}%>
    </title>
    <style type="text/css">
        #news ul {
            list-style-type: none;
        }

            #news ul li {
                padding: 5px 0;
                border-bottom: solid 1px #cccccc;
            }

                    #news ul li a div:first-child {
                        min-width: 90px;
                    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div id="news" class="container">
        <ul id="newslist" runat="server">
        </ul>
    </div>
</asp:Content>

