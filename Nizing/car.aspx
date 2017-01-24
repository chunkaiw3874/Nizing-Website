<%@ Page Title="" Language="C#" MasterPageFile="~/master/application.master" AutoEventWireup="true" CodeFile="car.aspx.cs" Inherits="car" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>車用元件-日進電線</title>
    <meta name="description" content="車用元件研發製造，日進電線持續與最頂尖的新科技接軌，歡迎各種客製需求">	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="product-submenu">
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/images/service_pic/engine-power-cable-menu.jpg" alt="馬達動力線" NavigateUrl="~/engine-power-cable.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    馬達動力線<br />
                    訂製線<br />
                    輸電用線
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>用途:</td>
                            <td>傳輸電流至引擎的主要傳輸電纜，為車輛必備元件。</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/images/service_pic/temp-sensor-menu.jpg" alt="車用感溫線" NavigateUrl="~/temperature-sensor.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    車用感溫線<br />
                    訂製線<br />
                    溫度感應
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>用途:</td>
                            <td>精確的測量車輛各處溫度，為行車安全重要元件之一。</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/images/product_pic/ul3512-menu.jpg" alt="UL3512矽膠編織線" NavigateUrl="~/ul3512.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL3512<br />
                    矽膠編織線<br />
                    電熱馬達、高溫家用電器配線
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-60°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣:</td>
                            <td>矽橡膠</td>
                        </tr>
                        <tr>
                            <td>外被編織:</td>
                            <td>玻璃纖維+矽樹脂</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/images/service_pic/tef-sili-multi-core-cable-menu.jpg" alt="鐵氟龍矽膠多芯複合線" NavigateUrl="~/tef-sili-multi-core-cable.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    鐵氟龍矽膠多芯複合線<br />
                    訂製線<br />
                    車用線
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>300V</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-60°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>芯線:</td>
                            <td>PTFE</td>
                        </tr>
                        <tr>
                            <td>絕緣:</td>
                            <td>矽橡膠</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="~/images/service_pic/ultra-flexible-sili-fiber-wire-menu.jpg" alt="超軟矽膠編織線" NavigateUrl="~/ultra-flexible-sili-fiber-wire.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    超軟矽膠編織線<br />
                    訂製線<br />
                    電熱馬達、高溫家用電器配線
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-60°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣:</td>
                            <td>矽橡膠</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink6" runat="server" ImageUrl="~/images/service_pic/double-shield-tef-sili-cable-menu.jpg" alt="雙隔離矽膠鐵氟龍多芯線" NavigateUrl="~/double-shield-tef-sili-cable.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    雙隔離矽膠鐵氟龍多芯線<br />
                    訂製線<br />
                    頂級車種LED燈用配線
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>300V</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-60°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>芯線:</td>
                            <td>UL1332鐵氟龍線</td>
                        </tr>
                        <tr>
                            <td>隔離:</td>
                            <td>鋁箔/編織銅網</td>
                        </tr>
                        <tr>
                            <td>絕緣:</td>
                            <td>矽橡膠</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

