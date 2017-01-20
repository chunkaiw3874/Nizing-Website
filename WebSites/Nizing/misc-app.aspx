<%@ Page Title="" Language="C#" MasterPageFile="~/master/application.master" AutoEventWireup="true" CodeFile="misc-app.aspx.cs" Inherits="misc_app" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>其他應用-日進電線</title>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="product-submenu">
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink12" runat="server" ImageUrl="~/images/service_pic/liquid_level_sensor-menu.jpg" alt="液位感應線" NavigateUrl="~/liquid-level-sensor.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    液位感應線<br />
                    訂製線<br />
                    液位測量用線
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-10°C~ +105°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>純銅線/不鏽鋼線</td>
                        </tr>
                        <tr>
                            <td>編織:</td>
                            <td>聚合纖維</td>
                        </tr>
                        <tr>
                            <td>絕緣:</td>
                            <td>PVC</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>        
    </div>
</asp:Content>

