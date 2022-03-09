<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/child.master" AutoEventWireup="true" CodeFile="vde.aspx.cs" Inherits="vde" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Certification - Nizing Electric Wire & Cable</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    VDE
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="ul.aspx">UL</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="pse.aspx">PSE</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="vde.aspx" CssClass="active">VDE</asp:HyperLink> 
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="certificate-document">
        <div class="inner-content">
            <div class="content-row">
                <h4>Single-Core</h4>
                <div class="icon">
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/en/images/certificate/cert_vdesingle_en1-small.jpg" NavigateUrl="~/en/images/certificate/cert_vdesingle_en1.jpg" Target="_blank"></asp:HyperLink>
                </div>
                <div class="icon">
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/en/images/certificate/cert_vdesingle_en2-small.jpg" NavigateUrl="~/en/images/certificate/cert_vdesingle_en2.jpg" Target="_blank"></asp:HyperLink>
                </div>
                <div class="icon">
                    <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="~/en/images/certificate/cert_vdesingle_en3-small.jpg" NavigateUrl="~/en/images/certificate/cert_vdesingle_en3.jpg" Target="_blank"></asp:HyperLink>
                </div>
                <div class="icon">
                    <asp:HyperLink ID="HyperLink6" runat="server" ImageUrl="~/en/images/certificate/cert_vdesingle_en4-small.jpg" NavigateUrl="~/en/images/certificate/cert_vdesingle_en4.jpg" Target="_blank"></asp:HyperLink>
                </div>
                <div class="icon">
                    <asp:HyperLink ID="HyperLink7" runat="server" ImageUrl="~/en/images/certificate/cert_vdesingle_en5-small.jpg" NavigateUrl="~/en/images/certificate/cert_vdesingle_en5.jpg" Target="_blank"></asp:HyperLink>
                </div>
            </div>
            <div class="content-row">
                <h4>Multi-Core</h4>
                <div class="icon">
                    <asp:HyperLink ID="HyperLink8" runat="server" ImageUrl="~/en/images/certificate/cert_vdemulti_en1-small.jpg" NavigateUrl="~/en/images/certificate/cert_vdemulti_en1.jpg" Target="_blank"></asp:HyperLink>
                </div>
                <div class="icon">
                    <asp:HyperLink ID="HyperLink9" runat="server" ImageUrl="~/en/images/certificate/cert_vdemulti_en2-small.jpg" NavigateUrl="~/en/images/certificate/cert_vdemulti_en2.jpg" Target="_blank"></asp:HyperLink>
                </div>
                <div class="icon">
                    <asp:HyperLink ID="HyperLink10" runat="server" ImageUrl="~/en/images/certificate/cert_vdemulti_en3-small.jpg" NavigateUrl="~/en/images/certificate/cert_vdemulti_en3.jpg" Target="_blank"></asp:HyperLink>
                </div>
                <div class="icon" style="margin:0px;">
                    <asp:HyperLink ID="HyperLink13" runat="server" ImageUrl="~/en/images/certificate/cert_vdemulti_en4-small.jpg" NavigateUrl="~/en/images/certificate/cert_vdemulti_en4.jpg" Target="_blank"></asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

