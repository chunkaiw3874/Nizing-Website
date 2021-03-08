<%@ Page Title="" Language="C#" MasterPageFile="~/master/product.master" AutoEventWireup="true" CodeFile="silicone-series.aspx.cs" Inherits="silicone_series" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" runat="Server">
    <title>矽膠電線、醫療器材配線-日進電線</title>
    <meta name="keywords" content="矽膠電線,矽膠高壓線,醫療器材配線,矽膠多芯線,矽膠絕緣線" />
    <meta name="description" content="各式矽膠電線，包含家電及需耐溫的機台常用的UL3123、UL3132、UL3135、UL3136、VDE H05S-K、VDE H05SS-F、VDE FG4G4、PSE3323矽膠耐熱電線、耐高壓的UL3239矽膠高壓電線、醫療業界使用的VDE REG-NR:103874醫療線、及其他各類常規及訂製電線">

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
                <h5>矽膠耐熱線
                </h5>
            </div>
            <div class="row mb-1">
                <img src="images/product_pic/silicone-wire-green-menu.jpg" class="img-fluid" alt="矽膠耐熱線" />
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
                    <tr class="navigation-row" data-href="ul3136.aspx">
                        <td>UL3123
                        </td>
                        <td>耐熱
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3132.aspx">
                        <td>UL3132
                        </td>
                        <td>耐熱
                        </td>
                        <td>300V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3133.aspx">
                        <td>UL3133
                        </td>
                        <td>耐熱
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3134.aspx">
                        <td>UL3134
                        </td>
                        <td>耐熱
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3135.aspx">
                        <td>UL3135
                        </td>
                        <td>耐熱
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3136.aspx">
                        <td>UL3136
                        </td>
                        <td>耐熱
                        </td>
                        <td>300V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3138.aspx">
                        <td>UL3138
                        </td>
                        <td>耐熱
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3139.aspx">
                        <td>UL3139
                        </td>
                        <td>耐熱
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3213.aspx">
                        <td>UL3213
                        </td>
                        <td>耐熱
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3239.aspx">
                        <td>UL3239
                        </td>
                        <td>耐熱、高壓
                        </td>
                        <td>3KV~60KV DC
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3529.aspx">
                        <td>UL3529
                        </td>
                        <td>耐熱
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3530.aspx">
                        <td>UL3530
                        </td>
                        <td>耐熱
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3572.aspx">
                        <td>UL3572
                        </td>
                        <td>高壓、耐熱
                        </td>
                        <td>1000V
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3580.aspx">
                        <td>UL3580
                        </td>
                        <td>耐熱
                        </td>
                        <td>高壓、1000V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3641.aspx">
                        <td>UL3641
                        </td>
                        <td>耐熱、高壓
                        </td>
                        <td>3300V
                        </td>
                        <td>-60°C~+180°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3642.aspx">
                        <td>UL3642
                        </td>
                        <td>耐熱、高壓
                        </td>
                        <td>6900V
                        </td>
                        <td>-60°C~+180°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3643.aspx">
                        <td>UL3643
                        </td>
                        <td>耐熱、高壓
                        </td>
                        <td>13800V
                        </td>
                        <td>-60°C~+180°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3644.aspx">
                        <td>UL3644
                        </td>
                        <td>高壓、耐熱
                        </td>
                        <td>1000V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3662.aspx">
                        <td>UL3662
                        </td>
                        <td>耐熱、高壓
                        </td>
                        <td>4200V
                        </td>
                        <td>-60°C~+180°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3663.aspx">
                        <td>UL3663
                        </td>
                        <td>耐熱、高壓
                        </td>
                        <td>7200V
                        </td>
                        <td>-60°C~+180°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3664.aspx">
                        <td>UL3664
                        </td>
                        <td>耐熱、高壓
                        </td>
                        <td>15000V
                        </td>
                        <td>-60°C~+180°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3754.aspx">
                        <td>UL3754
                        </td>
                        <td>耐熱
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3755.aspx">
                        <td>UL3755
                        </td>
                        <td>耐熱
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul3976.aspx">
                        <td>UL3976
                        </td>
                        <td>耐熱
                        </td>
                        <td>30V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="vde-h05s-k.aspx">
                        <td>VDE H05S-K
                        </td>
                        <td>耐熱
                        </td>
                        <td>450V/750V
                        </td>
                        <td>-60°C~+180°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="mb-2 d-block">
            <div class="row">
                <h5>矽膠多芯線
                </h5>
            </div>
            <div class="row mb-1">
                <img src="images/product_pic/silicone-multicore-wire-black-menu.jpg" class="img-fluid" alt="矽膠多芯線" />
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
                    <tr class="navigation-row" data-href="ul4330.aspx">
                        <td>UL4330
                        </td>
                        <td>耐熱、多芯
                        </td>
                        <td>300V AC
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul4476.aspx">
                        <td>UL4476
                        </td>
                        <td>高壓、耐熱、多芯
                        </td>
                        <td>1000V AC
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="vde-h05ss-f.aspx">
                        <td>VDE H05SS-F
                        </td>
                        <td>高壓、耐熱、多芯
                        </td>
                        <td>450V AC/750V DC
                        </td>
                        <td>-60°C~+180°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="mb-2 d-block">
            <div class="row">
                <h5>多層絕緣矽膠線
                </h5>
            </div>
            <div class="row mb-1">
                <img src="images/product_pic/multi-layer-silicone-wire-menu.jpg" class="img-fluid" alt="多層絕緣矽膠線" />
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
                    <tr class="navigation-row" data-href="ul3232.aspx">
                        <td>UL3232
                        </td>
                        <td>雙層絕緣
                        </td>
                        <td>300V AC
                        </td>
                        <td>-60°C~+105°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠<br />
                            絕緣體: 尼龍
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="vde-fg4g4.aspx">
                        <td>VDE FG4G4
                        </td>
                        <td>耐熱、雙層絕緣
                        </td>
                        <td>300V AC/500V DC
                        </td>
                        <td>-60°C~+180°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠<br />
                            絕緣體: 矽橡膠
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="mb-2 d-block">
            <div class="row">
                <h5>並排矽膠線
                </h5>
            </div>
            <div class="row mb-1">
                <img src="images/product_pic/parallel-silicone-wire-menu.jpg" class="img-fluid" alt="並排矽膠線" />
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
                    <tr class="navigation-row" data-href="vde-reg-nr103874.aspx">
                        <td>VDE REGNR103874
                        </td>
                        <td>耐熱、並排
                        </td>
                        <td>300V AC
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>導體: 鍍錫銅線<br />
                            絕緣體: 矽橡膠
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
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/images/product_pic/ul3123-menu.jpg" Text="UL3123矽膠耐熱電線" NavigateUrl="~/ul3123.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL3123<br />
                    矽膠耐熱電線<br />
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
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>矽橡膠</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/images/product_pic/ul3132-menu.jpg" Text="UL3132矽膠耐熱電線" NavigateUrl="~/ul3132.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL3132<br />
                    矽膠耐熱電線<br />
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
                            <td>-60°C~ +150°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>矽橡膠</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/images/product_pic/ul3135-menu.jpg" Text="UL3135矽膠耐熱電線" NavigateUrl="~/ul3135.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL3135<br />
                    矽膠耐熱電線<br />
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
                            <td>矽橡膠</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/images/product_pic/ul3136-menu.jpg" Text="UL3136矽膠耐熱電線" NavigateUrl="~/ul3136.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL3136<br />
                    矽膠耐熱電線<br />
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
                            <td>-60°C~ +150°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>矽橡膠</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="~/images/product_pic/ul3239-menu.jpg" Text="UL3239矽膠耐熱高壓線" NavigateUrl="~/ul3239.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL3239<br />
                    矽膠耐熱高壓線<br />
                    電熱馬達、高溫家用電器配線
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>3KV~60KV DC</td>
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
                            <td>矽橡膠</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink11" runat="server" ImageUrl="~/images/product_pic/ul4330-menu.jpg" Text="UL4330矽膠多芯線" NavigateUrl="~/ul4330.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL4330<br />
                    矽膠多芯線<br />
                    電熱馬達、高溫家用電器配線
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>300V AC</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-60°C~ +150°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>矽橡膠</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink12" runat="server" ImageUrl="~/images/product_pic/ul4476-menu.jpg" Text="UL4476矽膠高壓多芯線" NavigateUrl="~/ul4476.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL4476<br />
                    矽膠高壓多芯線<br />
                    電熱馬達、高溫家用電器配線
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>1KV AC</td>
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
                            <td>矽橡膠</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink6" runat="server" ImageUrl="~/images/product_pic/vde_h05s-k-menu.jpg" Text="VDE H05S-K矽膠耐熱電線" NavigateUrl="~/vde-h05s-k.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    VDE H05S-K<br />
                    矽膠耐熱電線<br />
                    電熱馬達、高溫家用電器配線
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>450V/750V</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-60°C~ +180°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>矽橡膠</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink7" runat="server" ImageUrl="~/images/product_pic/vde_reg-nr103874-menu.jpg" Text="VDE REG-NR:103874醫療矽膠並排線" NavigateUrl="~/vde-reg-nr103874.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    VDE REG-NR:103874<br />
                    醫療矽膠並排線<br />
                    醫療器材配線
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
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>矽橡膠</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink8" runat="server" ImageUrl="~/images/product_pic/vde_h05ss-f-menu.jpg" Text="VDE H05SS-F矽膠多芯線" NavigateUrl="~/vde-h05ss-f.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    VDE H05SS-F<br />
                    矽膠多芯線<br />
                    電熱馬達、高溫家用電器配線
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>450V AC/ 750V DC</td>
                        </tr>
                        <tr>
                            <td>溫度範圍:</td>
                            <td>-60°C~ +180°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>矽橡膠</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink9" runat="server" ImageUrl="~/images/product_pic/vde_fg4g4-menu.jpg" Text="VDE FG4G4矽膠雙層絕緣線" NavigateUrl="~/vde-fg4g4.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    VDE FG4G4<br />
                    矽膠雙層絕緣線<br />
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
                            <td>-60°C~ +180°C</td>
                        </tr>
                        <tr>
                            <td>導體:</td>
                            <td>鍍錫銅線</td>
                        </tr>
                        <tr>
                            <td>絕緣體:</td>
                            <td>矽橡膠</td>
                        </tr>
                        <tr>
                            <td>外被:</td>
                            <td>矽橡膠</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink10" runat="server" ImageUrl="~/images/product_pic/pse3323-menu.jpg" Text="PSE3323矽膠耐熱電線" NavigateUrl="~/pse-3323.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    PSE 3323<br />
                    矽膠耐熱電線<br />
                    電熱馬達、高溫家用電器配線
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>額定電壓:</td>
                            <td>300V/600V</td>
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
                            <td>矽橡膠</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>

