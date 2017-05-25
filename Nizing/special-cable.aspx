<%@ Page Title="" Language="C#" MasterPageFile="~/master/product.master" AutoEventWireup="true" CodeFile="special-cable.aspx.cs" Inherits="special_cable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>客製線、冷媒線-日進電線</title>
    <meta name="keywords" content="客製電線,冷媒線" />
    <meta name="description" content="各式客製特殊線材，有一般冷凍壓縮馬達使用的UL5048冷媒線、及其他各類客製電線">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="product-submenu">
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/images/product_pic/ul5048-menu.jpg" Text="UL5048冷媒線" NavigateUrl="~/ul5048.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL5048冷媒線<br />
                    冷媒線<br />
                    冷凍壓縮機馬達
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-40°C~+105°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣:</td>
                            <td>PETP纖維</td>
                        </tr>
                        <tr>
                            <td>隔離層:</td>
                            <td>PETP帶</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

