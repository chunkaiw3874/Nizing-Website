<%@ Page Title="" Language="C#" MasterPageFile="~/master/application.master" AutoEventWireup="true" CodeFile="application.aspx.cs" Inherits="application" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>應用產業-日進電線</title>
    <meta name="description" content="日進電線持續與最頂尖的新科技接軌，持續研發，滿足各種客製需求">	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="product-menu">
        <div class="content-row">
            <div class="button">
                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/images/service/s1.jpg" NavigateUrl="~/car.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/images/service/s2.jpg" NavigateUrl="~/cloud.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/images/service/s3.jpg" NavigateUrl="~/heating.aspx"></asp:HyperLink> 
            </div>
        </div>
        <div class="content-row">
            <div class="button">
                <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/images/service/s4.jpg" NavigateUrl="~/medical.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="~/images/service/s5.jpg" NavigateUrl="~/led.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink6" runat="server" ImageUrl="~/images/service/s6.jpg" NavigateUrl="~/temperature-control.aspx"></asp:HyperLink> 
            </div>
        </div>
        <div class="content-row">
            <div class="button">
                <asp:HyperLink ID="HyperLink7" runat="server" ImageUrl="~/images/service/s7.jpg" NavigateUrl="~/construction.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink8" runat="server" ImageUrl="~/images/service/s8.jpg" NavigateUrl="~/solar.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink9" runat="server" ImageUrl="~/images/service/s9.jpg" NavigateUrl="~/steel.aspx"></asp:HyperLink> 
            </div>
        </div>
        <div class="content-row">
            <div class="button">
                <asp:HyperLink ID="HyperLink40" runat="server" ImageUrl="~/images/service/s10.jpg" NavigateUrl="~/roboarm.aspx" />
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink10" runat="server" ImageUrl="~/images/service/misc-app.jpg" NavigateUrl="~/misc-app.aspx"></asp:HyperLink> 
            </div>
        </div>        
    </div>
</asp:Content>

