<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="company.aspx.cs" Inherits="company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>日進電線</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    日進電線
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <a href="company-intro.aspx">公司簡介</a> | <a href="company-culture.aspx">核心文化</a> | <a href="company-history.aspx">歷史紀錄</a> | <a href="company-capability.aspx">設備技術</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="child-menu">
        <div class="inner-content">
            <div class="content-row">
                <div class="button">
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/images/button/company-intro.jpg" NavigateUrl="~/company-intro.aspx"></asp:HyperLink>
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/images/button/company-culture.jpg" NavigateUrl="~/company-culture.aspx"></asp:HyperLink>
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/images/button/company-history.jpg" NavigateUrl="~/company-history.aspx"></asp:HyperLink>
                </div>
                <div class="button" style="margin:0px;">
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/images/button/company-capability.jpg" NavigateUrl="~/company-capability.aspx"></asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

