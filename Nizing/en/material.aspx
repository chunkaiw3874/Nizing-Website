<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/child.master" AutoEventWireup="true" CodeFile="material.aspx.cs" Inherits="material" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Material - Nizing Electric Wire & Cable</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    Material
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="plastic.aspx">Plastic</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="silicone.aspx">Silicone</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="teflon.aspx">Teflon</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="twinning.aspx">Twinning Material</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="conductor.aspx">Conductor</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="child-menu">
        <div class="inner-content">
            <div class="content-row">
                <div class="button">
                    <asp:HyperLink ID="HyperLink6" runat="server" ImageUrl="~/en/images/button/plastic.jpg" NavigateUrl="plastic.aspx"></asp:HyperLink>
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink7" runat="server" ImageUrl="~/en/images/button/silicone.jpg" NavigateUrl="silicone.aspx"></asp:HyperLink>
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink8" runat="server" ImageUrl="~/en/images/button/teflon.jpg" NavigateUrl="teflon.aspx"></asp:HyperLink>
                </div>
                <div class="button" style="margin-right:0px;">
                    <asp:HyperLink ID="HyperLink9" runat="server" ImageUrl="~/en/images/button/twinning.jpg" NavigateUrl="twinning.aspx"></asp:HyperLink>
                </div>
            </div>
            <div class="content-row">
                <div class="button">
                    <asp:HyperLink ID="HyperLink10" runat="server" ImageUrl="~/en/images/button/conductor.jpg" NavigateUrl="conductor.aspx"></asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

