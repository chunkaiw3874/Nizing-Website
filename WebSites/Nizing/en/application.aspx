<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/application.master" AutoEventWireup="true" CodeFile="application.aspx.cs" Inherits="application" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Applied Industry - Nizing Electric Wire & Cable</title>
    <meta name="description" content="Nizing Electric Wire & Cable continues to connect with the latest technology. We welcome any type of customized needs.">	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="product-menu">
        <div class="content-row">
            <div class="button">
                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/en/images/service/s1.jpg" NavigateUrl="car.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/en/images/service/s2.jpg" NavigateUrl="cloud.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/en/images/service/s3.jpg" NavigateUrl="heating.aspx"></asp:HyperLink> 
            </div>
        </div>
        <div class="content-row">
            <div class="button">
                <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/en/images/service/s4.jpg" NavigateUrl="medical.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="~/en/images/service/s5.jpg" NavigateUrl="led.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink6" runat="server" ImageUrl="~/en/images/service/s6.jpg" NavigateUrl="temperature-control.aspx"></asp:HyperLink> 
            </div>
        </div>
        <div class="content-row">
            <div class="button">
                <asp:HyperLink ID="HyperLink7" runat="server" ImageUrl="~/en/images/service/s7.jpg" NavigateUrl="construction.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink8" runat="server" ImageUrl="~/en/images/service/s8.jpg" NavigateUrl="solar.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink9" runat="server" ImageUrl="~/en/images/service/s9.jpg" NavigateUrl="steel.aspx"></asp:HyperLink> 
            </div>
        </div>
        <div class="content-row">
            <div class="button">
                <asp:HyperLink ID="HyperLink40" runat="server" ImageUrl="~/en/images/service/s10.jpg" NavigateUrl="roboarm.aspx" />
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink10" runat="server" ImageUrl="~/en/images/service/misc-app.jpg" NavigateUrl="misc-app.aspx"></asp:HyperLink> 
            </div>
        </div>        
    </div>
</asp:Content>

