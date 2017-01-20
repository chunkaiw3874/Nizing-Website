<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/child.master" AutoEventWireup="true" CodeFile="alloy.aspx.cs" Inherits="alloy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Alloy - Nizing Electric Wire & Cable</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    Alloy
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="copper.aspx">Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="agcu.aspx">Silver-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="sncu.aspx">Tin-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="nicu.aspx">Nickel-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="ag.aspx">Silver</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="ccs.aspx">Copper Plated Steel</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="child-menu">
        <div class="inner-content">
            <div class="content-row">
                <div class="button">
                    <asp:HyperLink ID="HyperLink7" runat="server" ImageUrl="~/en/images/button/copper.jpg" NavigateUrl="copper.aspx"></asp:HyperLink>
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink8" runat="server" ImageUrl="~/en/images/button/agcu.jpg" NavigateUrl="agcu.aspx"></asp:HyperLink>
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink9" runat="server" ImageUrl="~/en/images/button/sncu.jpg" NavigateUrl="sncu.aspx"></asp:HyperLink>
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink10" runat="server" ImageUrl="~/en/images/button/nicu.jpg" NavigateUrl="nicu.aspx"></asp:HyperLink>
                </div>
            </div>
            <div class="content-row">                
                <div class="button">
                    <asp:HyperLink ID="HyperLink11" runat="server" ImageUrl="~/en/images/button/ag.jpg" NavigateUrl="ag.aspx"></asp:HyperLink>
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink12" runat="server" ImageUrl="~/en/images/button/ccs.jpg" NavigateUrl="ccs.aspx"></asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

