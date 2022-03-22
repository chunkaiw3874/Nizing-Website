<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="ul.aspx.cs" Inherits="ul" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>
        <%if (RouteData.Values["language"].ToString() == "zh")
            {%>
                UL認證 - 日進電線 <%= DateTime.Now.Year.ToString() %>
        <%}
            else
            {%>
                UL Certificate-Nizing Electric Wire & Cable <%=DateTime.Now.Year.ToString() %>
        <%}%>
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="container">
        <div id="certImg" runat="server" class="row row-cols-2 row-cols-md-4"></div>
    </div>
</asp:Content>

