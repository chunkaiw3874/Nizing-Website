<%@ Page Title="" Language="C#" MasterPageFile="~/master/application.master" AutoEventWireup="true" CodeFile="solar.aspx.cs" Inherits="solar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>太陽能元件-日進電線</title>
    <meta name="description" content="太陽能元件研發製造，日進電線持續與最頂尖的新科技接軌，歡迎各種客製需求">	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="product-submenu">
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/images/service_pic/xlpe-menu.jpg" alt="XLPE交連照射線" NavigateUrl="~/xlpe-series.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    XLPE<br />
                    交連照射線系列<br />
                    照射線
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>300~3KV</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-40°C~150°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>XLPE</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>        
    </div>
</asp:Content>

