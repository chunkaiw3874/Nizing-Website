<%@ Page Title="" Language="C#" MasterPageFile="~/master/application.master" AutoEventWireup="true" CodeFile="construction.aspx.cs" Inherits="construction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>建築配線-日進電線</title>
    <meta name="description" content="建築配線研發製造，日進電線持續與最頂尖的新科技接軌，歡迎各種客製需求">	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="product-submenu">
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/images/product_pic/iv_wire-menu.jpg" alt="IV粗芯控制線" NavigateUrl="~/iv-wire.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    IV<br />
                    粗芯控制線<br />
                    建築用線
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-10°C~60°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>PVC</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>        
    </div>
</asp:Content>

