<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="environment-certificate.aspx.cs" Inherits="environment_certificate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Certification - Nizing Electric Wire & Cable</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    Environmental Certification
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="rohs.aspx">RoHS</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="reach.aspx">REACH</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="child-menu">
        <div class="inner-content">
            <div class="content-row">
                <div class="button">
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/en/images/button/rohs.jpg" NavigateUrl="rohs.aspx" ToolTip="RoHS認證"></asp:HyperLink>
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/en/images/button/reach.jpg" NavigateUrl="reach.aspx" ToolTip="REACH認證"></asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

