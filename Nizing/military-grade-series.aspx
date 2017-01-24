<%@ Page Title="" Language="C#" MasterPageFile="~/master/product.master" AutoEventWireup="true" CodeFile="military-grade-series.aspx.cs" Inherits="military_grade_series" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>日進電線-軍規線系列</title>
    <meta name="description" content="各式軍規線材，MIL-C-24643/23-08軍規船用電纜、MIL-W-22759鐵氟龍軍規電子線等軍規線材">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="product-submenu">
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/images/product_pic/mil-c-24643-23-08-menu.jpg" alt="MIL-C-24643/23-08軍規低煙無毒電纜" NavigateUrl="~/mil-c-24643-23-08.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    MIL-C-24643/23-08<br />
                    軍規低煙無毒電纜<br />
                    船用電纜
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>300V AC</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>200°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>填充:</td>
                            <td>玻璃纖維</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>矽橡膠</td>
                        </tr>
                        <tr>
                            <td>隔離層:</td>
                            <td>鋁箔</td>
                        </tr>
                        <tr>
                            <td>外被:</td>
                            <td>矽橡膠、SUS304</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/images/product_pic/mil-w-22759-7-menu.jpg" alt="MIL-W-22575/7 軍規鐵氟龍電子線" NavigateUrl="~/mil-w-22759-7.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    MIL-W-22759/7<br />
                    軍規鐵氟龍電子線<br />
                    電子線
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>600V AC</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>200°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍銀銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>鐵氟龍TFE</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

