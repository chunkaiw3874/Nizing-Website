<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/application.master" AutoEventWireup="true" CodeFile="temperature-control.aspx.cs" Inherits="temperature_control" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Temperature Control System Component - Nizing Electric Wire & Cable</title>
    <meta name="description" content="Temperature Control System component research and development. Nizing Electric continues to connect with the latest technology. We welcome any type of customized needs.">	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="product-submenu">
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/en/images/service_pic/thermocouple-menu.jpg" alt="Thermocouple" NavigateUrl="thermocouple-series.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    Thermocouple<br />
                    Temperature Sensor
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Thermocouple Types:</td>
                        </tr>
                        <tr>
                            <td><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="k-type.aspx">K-Type</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="j-type.aspx">J-Type</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="t-type.aspx">T-Type</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="rs-type.aspx">R/S-Type</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="e-type.aspx">E-Type</asp:HyperLink></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>        
    </div>
</asp:Content>

