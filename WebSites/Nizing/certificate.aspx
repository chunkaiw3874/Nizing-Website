<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="certificate.aspx.cs" Inherits="certificate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>日進電線-安規認證</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    安規認證
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="spec-certificate.aspx">安規認證</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="quality-certificate.aspx">品質認證</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="environment-certificate.aspx">綠色認證</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="child-menu">
        <div class="inner-content">
            <div class="content-row">
                <div class="button">
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/images/button/spec-certificate.jpg" NavigateUrl="spec-certificate.aspx"></asp:HyperLink>
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="~/images/button/quality-certificate.jpg" NavigateUrl="quality-certificate.aspx"></asp:HyperLink>
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink6" runat="server" ImageUrl="~/images/button/environment-certificate.jpg" NavigateUrl="environment-certificate.aspx"></asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

