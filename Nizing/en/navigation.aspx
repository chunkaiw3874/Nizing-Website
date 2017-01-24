<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/child.master" AutoEventWireup="true" CodeFile="navigation.aspx.cs" Inherits="navigation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Navigation - Nizing Electric Wire & Cable</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    Navigation
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="navigation">
        <div class="inner-content">
            <div class="content-row">
                <div class="content-column">
                    <div class="header">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="company.aspx">Nizing</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="company-intro.aspx">Introduction</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="company-culture.aspx.cs">Culture</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="company-history.aspx">History</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="company-capability.aspx">Capability</asp:HyperLink>
                    </div>
                </div>
                <div class="content-column">
                    <div class="header">
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="product.aspx">Product</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="pvc-series.aspx">PVC</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="silicone-fiberglass-series.aspx">Silicone Fiberglass</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="high-temperature-resistance-series.aspx">High Temperature</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="silicone-series.aspx">Silicone</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="teflon-series.aspx">Teflon</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="xlpe-series.aspx">XLPE</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="sleeve-and-tube-series.aspx">Sleeve and Tube</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="thermocouple-series.aspx">Thermocouple</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="heating-wire-series.aspx">Heating Wire</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="automotive-wire-series.aspx">Automobile Wire</asp:HyperLink>
                    </div>
                    <div class="sub">
                        <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="automotive-wire-standard-jaso.aspx">JASO</asp:HyperLink>
                    </div>
                    <div class="sub">
                        <asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="automotive-wire-standard-sae.aspx">SAE</asp:HyperLink>
                    </div>
                    <div class="sub">
                        <asp:HyperLink ID="HyperLink19" runat="server" NavigateUrl="automotive-wire-standard-iso.aspx">ISO</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink20" runat="server" NavigateUrl="special-cable.aspx">Customized Cable</asp:HyperLink>
                    </div>
                </div>
                <div class="content-column">
                    <div class="header">
                        <asp:HyperLink ID="HyperLink21" runat="server" NavigateUrl="application.aspx">Application</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink23" runat="server" NavigateUrl="car.aspx">Car</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink24" runat="server" NavigateUrl="cloud.aspx">Cloud System</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink26" runat="server" NavigateUrl="heating.aspx">Heating System</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink27" runat="server" NavigateUrl="medical.aspx">Medical</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink28" runat="server" NavigateUrl="led.aspx">LED</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink29" runat="server" NavigateUrl="temperature-control.aspx">Temperature Control</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink30" runat="server" NavigateUrl="construction.aspx">Construction</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink31" runat="server" NavigateUrl="solar.aspx">Solar Power</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink32" runat="server" NavigateUrl="steel.aspx">Steel Industry</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink33" runat="server" NavigateUrl="misc-app.aspx">Misc</asp:HyperLink>
                    </div>
                </div>
                <div class="content-column">
                    <div class="header">
                        <asp:HyperLink ID="HyperLink22" runat="server" NavigateUrl="material.aspx">Material</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink34" runat="server" NavigateUrl="plastic.aspx">Plastic</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink35" runat="server" NavigateUrl="silicone.aspx">Silicone</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink36" runat="server" NavigateUrl="teflon.aspx">Teflon</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink37" runat="server" NavigateUrl="twinning.aspx">Twinning Material</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink38" runat="server" NavigateUrl="conductor.aspx">Conductor</asp:HyperLink>
                    </div>
                </div>
                <div class="content-column">
                    <div class="header">
                        <asp:HyperLink ID="HyperLink39" runat="server" NavigateUrl="alloy.aspx">Alloy</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink40" runat="server" NavigateUrl="copper.aspx">Copper</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink41" runat="server" NavigateUrl="agcu.aspx">Silver-Copper</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink42" runat="server" NavigateUrl="sncu.aspx">Tin-Copper</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink43" runat="server" NavigateUrl="nicu.aspx">Nickel-Copper</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink44" runat="server" NavigateUrl="ag.aspx">Silver</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink45" runat="server" NavigateUrl="ccs.aspx">Copper-Clad-Steel</asp:HyperLink>
                    </div>
                </div>
                <div class="content-column">
                    <div class="header">
                        <asp:HyperLink ID="HyperLink46" runat="server" NavigateUrl="certificate.aspx">Certification</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink47" runat="server" NavigateUrl="spec-certificate.aspx">Spec Certificaiton</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink48" runat="server" NavigateUrl="quality-certificate.aspx">Quality Certification</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink49" runat="server" NavigateUrl="environment-certificate.aspx">Environment Certification</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

