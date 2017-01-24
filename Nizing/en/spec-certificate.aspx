﻿<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/child.master" AutoEventWireup="true" CodeFile="spec-certificate.aspx.cs" Inherits="spec_certificate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Certification - Nizing Electric Wire & Cable</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    Spec Certification
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="ul.aspx">UL</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="pse.aspx">PSE</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="vde.aspx">VDE</asp:HyperLink> 
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="child-menu">
        <div class="inner-content">
            <div class="content-row">
                <div class="button">
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/en/images/button/ul.jpg" NavigateUrl="ul.aspx"></asp:HyperLink>
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="~/en/images/button/pse.jpg" NavigateUrl="pse.aspx"></asp:HyperLink>
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink6" runat="server" ImageUrl="~/en/images/button/vde.jpg" NavigateUrl="vde.aspx"></asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
