<%@ Page Title="" Language="C#" MasterPageFile="~/master/product.master" AutoEventWireup="true" CodeFile="teflon-series.aspx.cs" Inherits="teflon_series" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" runat="Server">
    <title>鐵氟龍線、醫療器材配線-日進電線</title>
    <meta name="keywords" content="鐵氟龍線,醫療器材配線" />
    <meta name="description" content="各式鐵氟龍電線，為抗腐蝕及其它化學特性的首選，包含PTFE材質的UL1199、UL10344、UL10393、FEP材質的UL1330、UL1331、UL1332、UL1887、UL1901、VDE8219、VDE8220、VDE REG-NR8295、PFA材質的UL1709、UL1710、UL1726、UL1727、UL10362、ETFE材質的UL10109、醫療專用的鐵氟龍矽膠醫療器材配線、傳輸訊號的RG178B/U、RG179、RG316高頻同軸線及其他各類常規及訂製線材">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.bundle.min.js" integrity="sha384-1CmrxMRARb6aLqgBO7yyAxTOQE2AKb9GfXnEo760AUcUmFx3ibVJJAzGytlQcNXd" crossorigin="anonymous"></script>
    <script src="https://kit.fontawesome.com/32e9a84b4a.js" crossorigin="anonymous"></script>
    <style>
        .navigation-row {
            cursor: pointer;
        }

        .scrollable-300 {
            max-height: 300px;
            overflow: auto;
        }
    </style>
    <script>
        $(document).ready(function ($) {
            $('.navigation-row').click(function () {
                window.location = $(this).data('href');
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="mb-2 d-block">
            <div class="row">
                <h5>鐵氟龍線
                </h5>
            </div>
            <div class="row mb-1">
                <img src="images/product_pic/teflon-wire-black-menu.jpg" class="img-fluid" alt="鐵氟龍線" />
            </div>
            <div class="scrollable-300 row">
                <table class="table table-hover table-sm">
                    <tr>
                        <th>代號
                        </th>
                        <th>特性
                        </th>
                        <th>額定電壓
                        </th>
                        <th>溫度範圍
                        </th>
                        <th>結構
                        </th>
                    </tr>
                    <tr class="navigation-row" data-href="ul1199.aspx">
                        <td>UL1199
                        </td>
                        <td>耐熱、耐酸鹼
                        </td>
                        <td>600V
                        </td>
                        <td>-100°C~+200°C
                        </td>
                        <td>導體: 鍍錫/鍍銀/鍍鎳銅線<br />
                            絕緣體: PTFE
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1330.aspx">
                        <td>UL1330
                        </td>
                        <td>耐熱、耐酸鹼
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>導體: 鍍錫/鍍銀銅線<br />
                            絕緣體: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1331.aspx">
                        <td>UL1331
                        </td>
                        <td>耐熱、耐酸鹼
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫/鍍銀銅線<br />
                            絕緣體: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1332.aspx">
                        <td>UL1332
                        </td>
                        <td>耐熱、耐酸鹼
                        </td>
                        <td>300V
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>導體: 鍍錫/鍍銀銅線<br />
                            絕緣體: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1709.aspx">
                        <td>UL1709
                        </td>
                        <td>耐熱、耐酸鹼
                        </td>
                        <td>300V
                        </td>
                        <td>-100°C~+200°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: PFA
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1710.aspx">
                        <td>UL1710
                        </td>
                        <td>耐熱、耐酸鹼
                        </td>
                        <td>600V
                        </td>
                        <td>-100°C~+200°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: PFA
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1726.aspx">
                        <td>UL1726
                        </td>
                        <td>耐熱、耐酸鹼
                        </td>
                        <td>300V
                        </td>
                        <td>-80°C~+250°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: PFA
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1727.aspx">
                        <td>UL1727
                        </td>
                        <td>耐熱、耐酸鹼
                        </td>
                        <td>600V
                        </td>
                        <td>-80°C~+250°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: PFA
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1813.aspx">
                        <td>UL1813
                        </td>
                        <td>耐熱、耐酸鹼、高壓
                        </td>
                        <td>3000V
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>導體: 鍍錫/鍍銀銅線<br />
                            絕緣體: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1887.aspx">
                        <td>UL1887
                        </td>
                        <td>耐熱、耐酸鹼
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫/鍍銀/鍍鎳銅線<br />
                            絕緣體: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1901.aspx">
                        <td>UL1901
                        </td>
                        <td>耐熱、耐酸鹼
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul10109.aspx">
                        <td>UL10109
                        </td>
                        <td>耐熱、耐酸鹼
                        </td>
                        <td>300V
                        </td>
                        <td>-40°C~+150°C
                        </td>
                        <td>導體: 鍍錫/鍍銀銅線<br />
                            絕緣體: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul10344.aspx">
                        <td>UL10344
                        </td>
                        <td>耐熱、耐酸鹼
                        </td>
                        <td>600V
                        </td>
                        <td>-100°C~+250°C
                        </td>
                        <td>導體: 鍍錫/鍍銀/鍍鎳銅線<br />
                            絕緣體: PTFE
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul10362.aspx">
                        <td>UL10362
                        </td>
                        <td>耐熱、耐酸鹼
                        </td>
                        <td>600V
                        </td>
                        <td>-80°C~+250°C
                        </td>
                        <td>導體: 鍍錫/鍍銀銅線<br />
                            絕緣體: PFA
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul10393.aspx">
                        <td>UL10393
                        </td>
                        <td>耐熱、耐酸鹼
                        </td>
                        <td>600V
                        </td>
                        <td>-100°C~+250°C
                        </td>
                        <td>導體: 鍍錫/鍍銀/鍍鎳銅線<br />
                            絕緣體: PTFE
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul11331.aspx">
                        <td>UL11331
                        </td>
                        <td>耐熱、耐酸鹼
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>導體: 鍍錫/鍍銀銅線<br />
                            絕緣體: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul11817.aspx">
                        <td>UL11817
                        </td>
                        <td>耐熱、耐酸鹼、高壓
                        </td>
                        <td>3000V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫/鍍銀銅線<br />
                            絕緣體: FEP
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="mb-2 d-block">
            <div class="row">
                <h5>鐵氟龍多芯線
                </h5>
            </div>
            <div class="row mb-1">
                <img src="images/product_pic/teflon-multicore-wire-white-menu.jpg" class="img-fluid"
                    width="220"
                    alt="鐵氟龍多芯線" />
            </div>
            <div class="scrollable-300 row">
                <table class="table table-hover table-sm">
                    <tr>
                        <th>代號
                        </th>
                        <th>特性
                        </th>
                        <th>額定電壓
                        </th>
                        <th>溫度範圍
                        </th>
                        <th>結構
                        </th>
                    </tr>
                    <tr class="navigation-row" data-href="ul2748.aspx">
                        <td>UL2748
                        </td>
                        <td>耐熱、耐酸鹼、多芯
                        </td>
                        <td>600V AC
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫/鍍銀銅線<br />
                            絕緣體: FEP<br />
                            外被: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul2750.aspx">
                        <td>UL2750
                        </td>
                        <td>耐熱、耐酸鹼、多芯
                        </td>
                        <td>600V AC
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>導體: 鍍錫/鍍銀銅線<br />
                            絕緣體: FEP<br />
                            外被: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul2894.aspx">
                        <td>UL2894
                        </td>
                        <td>耐熱、耐酸鹼、多芯
                        </td>
                        <td>300V AC
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫/鍍銀銅線<br />
                            絕緣體: FEP<br />
                            外被: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul2895.aspx">
                        <td>UL2895
                        </td>
                        <td>耐熱、耐酸鹼、多芯
                        </td>
                        <td>300V AC
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>導體: 鍍錫/鍍銀銅線<br />
                            絕緣體: FEP<br />
                            外被: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="teflon-silicone-medical-wire.aspx">
                        <td>Medical Wire
                        </td>
                        <td>耐熱、多芯、多層絕緣
                        </td>
                        <td>600V AC
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>導體: 鍍錫/鍍銀銅線<br />
                            絕緣體: FEP<br />
                            外被: 矽橡膠
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="mb-2 d-block">
            <div class="row">
                <h5>多層絕緣鐵氟龍線
                </h5>
            </div>
            <div class="row mb-1">
                <img src="images/product_pic/teflon-multi-layer-wire-white-menu.jpg" class="img-fluid"
                    width="220"
                    alt="多層絕緣鐵氟龍線" />
            </div>
            <div class="scrollable-300 row">
                <table class="table table-hover table-sm">
                    <tr>
                        <th>代號
                        </th>
                        <th>特性
                        </th>
                        <th>額定電壓
                        </th>
                        <th>溫度範圍
                        </th>
                        <th>結構
                        </th>
                    </tr>
                    <tr class="navigation-row" data-href="vde-reg-nr8295.aspx">
                        <td>VDE REG-NR8295
                        </td>
                        <td>耐熱、耐酸鹼、多層絕緣
                        </td>
                        <td>300V AC/500V DC
                        </td>
                        <td>-100°C~+180°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: FEP
                        </td>
                    </tr>
                </table>
            </div>
        </div><div class="mb-2 d-block">
            <div class="row">
                <h5>鐵氟龍同軸線
                </h5>
            </div>
            <div class="row mb-1">
                <img src="images/product_pic/teflon-coaxial-cable-clear-menu.jpg" class="img-fluid"
                    alt="鐵氟龍同軸線" />
            </div>
            <div class="scrollable-300 row">
                <table class="table table-hover table-sm">
                    <tr>
                        <th>代號
                        </th>
                        <th>特性
                        </th>
                        <th>額定電壓
                        </th>
                        <th>溫度範圍
                        </th>
                        <th>結構
                        </th>
                    </tr>
                    <tr class="navigation-row" data-href="rg178bu-rg179-rg316.aspx">
                        <td>RG178B/U RG179 RG316
                        </td>
                        <td>同軸
                        </td>
                        <td>30V
                        </td>
                        <td>-70°C~+200°C
                        </td>
                        <td>導體: 鍍銀銅絲/鍍銀銅包鋼<br />
                            絕緣體: FEP
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <%--<div id="product-submenu">
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/images/product_pic/ul1199-menu.jpg" Text="UL1199 PTFE鐵氟龍線" NavigateUrl="~/ul1199.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1199<br />
                    PTFE鐵氟龍線<br />
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
                            <td>-100°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫/鍍銀/鍍鎳銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>PTFE</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/images/product_pic/ul1330-menu.jpg" Text="UL1330 FEP鐵氟龍線" NavigateUrl="~/ul1330.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1330<br />
                    FEP鐵氟龍線<br />
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
                            <td>鍍錫/鍍銀銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>FEP</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/images/product_pic/ul1331-menu.jpg" Text="UL1331 FEP鐵氟龍線" NavigateUrl="~/ul1331.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1331<br />
                    FEP鐵氟龍線<br />
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
                            <td>-60°C~ +150°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫/鍍銀銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>FEP</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/images/product_pic/ul1332-menu.jpg" Text="UL1332 FEP鐵氟龍線" NavigateUrl="~/ul1332.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1332<br />
                    FEP鐵氟龍線<br />
                    電熱馬達、高溫家用電器配線
               
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
                            <td>導體:</td>
                            <td>鍍錫/鍍銀銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>FEP</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="~/images/product_pic/ul1709-menu.jpg" Text="UL1709 PFA鐵氟龍線" NavigateUrl="~/ul1709.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1709<br />
                    PFA鐵氟龍線<br />
                    電熱馬達、高溫家用電器配線
               
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>300V</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-100°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>PFA</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink6" runat="server" ImageUrl="~/images/product_pic/ul1710-menu.jpg" Text="UL1710 PFA鐵氟龍線" NavigateUrl="~/ul1710.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1710<br />
                    PFA鐵氟龍線<br />
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
                            <td>-100°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>PFA</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink7" runat="server" ImageUrl="~/images/product_pic/ul1726-menu.jpg" Text="UL1726 PFA鐵氟龍線" NavigateUrl="~/ul1726.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1726<br />
                    PFA鐵氟龍線<br />
                    電熱馬達、高溫家用電器配線
               
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>300V</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-80°C~ +250°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>PFA</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink8" runat="server" ImageUrl="~/images/product_pic/ul1727-menu.jpg" Text="UL1727 PFA鐵氟龍線" NavigateUrl="~/ul1727.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1727<br />
                    PFA鐵氟龍線<br />
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
                            <td>-80°C~ +250°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>PFA</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink9" runat="server" ImageUrl="~/images/product_pic/ul1887-menu.jpg" Text="UL1887 FEP鐵氟龍線" NavigateUrl="~/ul1887.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1887<br />
                    FEP鐵氟龍線<br />
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
                            <td>-60°C~ +150°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫/鍍銀/鍍鎳銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>FEP</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink10" runat="server" ImageUrl="~/images/product_pic/ul1901-menu.jpg" Text="UL1901 FEP鐵氟龍線" NavigateUrl="~/ul1901.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1901<br />
                    FEP鐵氟龍線<br />
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
                            <td>絕緣體:</td>
                            <td>FEP</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink11" runat="server" ImageUrl="~/images/product_pic/ul10109-menu.jpg" Text="UL10109 ETFE鐵氟龍線" NavigateUrl="~/ul10109.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL10109<br />
                    ETFE鐵氟龍線<br />
                    電熱馬達、高溫家用電器配線
               
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>300V</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-40°C~ +150°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫/鍍銀銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>ETFE</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink12" runat="server" ImageUrl="~/images/product_pic/ul10344-menu.jpg" Text="UL10344 PTFE鐵氟龍線" NavigateUrl="~/ul10344.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL10344<br />
                    PTFE鐵氟龍線<br />
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
                            <td>-100°C~ +250°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫/鍍銀/鍍鎳銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>PTFE</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink13" runat="server" ImageUrl="~/images/product_pic/ul10362-menu.jpg" Text="UL10362 PFA鐵氟龍線" NavigateUrl="~/ul10362.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL10362<br />
                    PFA鐵氟龍線<br />
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
                            <td>-80°C~ +250°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫/鍍銀銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>PFA</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink14" runat="server" ImageUrl="~/images/product_pic/ul10393-menu.jpg" Text="UL10393 PTFE鐵氟龍線" NavigateUrl="~/ul10393.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL10393<br />
                    PTFE鐵氟龍線<br />
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
                            <td>-100°C~ +250°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫/鍍銀/鍍鎳銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>PTFE</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink15" runat="server" ImageUrl="~/images/product_pic/vde8219-menu.jpg" Text="VDE8219 FEP鐵氟龍線" NavigateUrl="~/vde-8219.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    VDE8219<br />
                    FEP鐵氟龍線<br />
                    電熱馬達、高溫家用電器配線
               
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>300V/ 500V AC</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-80°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫/鍍銀銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>FEP</td>
                        </tr>
                        <tr>
                            <td>外被:</td>
                            <td>FEP鐵氟龍</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink16" runat="server" ImageUrl="~/images/product_pic/vde8220-menu.jpg" Text="VDE8220 FEP鐵氟龍線" NavigateUrl="~/vde-8220.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    VDE8220<br />
                    FEP鐵氟龍線<br />
                    電熱馬達、高溫家用電器配線
               
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>450V AC/750V DC</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-80°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫/鍍銀銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>FEP</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink17" runat="server" ImageUrl="~/images/product_pic/vde_reg-nr8295-menu.jpg" Text="VDE REG-NR8295 雙絕緣鐵氟龍線" NavigateUrl="~/vde-reg-nr8295.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    VDE REG-NR8295<br />
                    雙絕緣鐵氟龍線<br />
                    電熱馬達、高溫家用電器配線
               
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>300V AC/500V DC</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-100°C~ +180°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>FEP</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink18" runat="server" ImageUrl="~/images/product_pic/teflon_silicone_medical_wire-menu.jpg" Text="鐵氟龍矽膠醫療器材配線" NavigateUrl="~/teflon-silicone-medical-wire.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    Medical Wire<br />
                    鐵氟龍矽膠醫療線<br />
                    醫療器材配線
               
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
                            <td>絕緣體:</td>
                            <td>FEP</td>
                        </tr>
                        <tr>
                            <td>外被:</td>
                            <td>矽橡膠</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink19" runat="server" ImageUrl="~/images/product_pic/rg178-menu.jpg" Text="RG178B/U RG179 RG316 高頻同軸線" NavigateUrl="~/rg178bu-rg179-rg316.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    RG178B/U RG179 RG316<br />
                    高頻同軸線<br />
                    視訊傳輸用線
               
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>30V</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-70°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍銀銅絲/鍍銀銅包鋼</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>FEP</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>

