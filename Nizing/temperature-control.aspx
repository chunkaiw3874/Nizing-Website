<%@ Page Title="" Language="C#" MasterPageFile="~/master/application.master" AutoEventWireup="true" CodeFile="temperature-control.aspx.cs" Inherits="temperature_control" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>溫控系統元件-日進電線</title>
    <meta name="description" content="溫控系統元件研發製造，日進電線持續與最頂尖的新科技接軌，歡迎各種客製需求">	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="product-submenu">
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/images/service_pic/thermocouple-menu.jpg" alt="Thermocouple補償導線" NavigateUrl="~/thermocoupole-series.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    補償導線<br />
                    溫感配線<br />
                    溫度感測
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>各式補償導線規格:</td>
                        </tr>
                        <tr>
                            <td><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/k-type.aspx">K-Type</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/j-type.aspx">J-Type</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/t-type.aspx">T-Type</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/rs-type.aspx">R/S-Type</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/e-type.aspx">E-Type</asp:HyperLink></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>        
    </div>
</asp:Content>

