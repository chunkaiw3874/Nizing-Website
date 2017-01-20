<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/application.master" AutoEventWireup="true" CodeFile="misc-app.aspx.cs" Inherits="misc_app" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Misc Application - Nizing Electric Wire & Cable</title>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="product-submenu">
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink12" runat="server" ImageUrl="~/en/images/service_pic/liquid_level_sensor-menu.jpg" alt="Liquid Level Sensor" NavigateUrl="liquid-level-sensor.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    Liquid Level Sensor<br />
                    Customized Product<br />
                    Liquid Level Detection
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-10°C~ +105°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Bare Copper, Stainless Steel</td>
                        </tr>
                        <tr>
                            <td>Braid:</td>
                            <td>Polyester</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>PVC</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>        
    </div>
</asp:Content>

