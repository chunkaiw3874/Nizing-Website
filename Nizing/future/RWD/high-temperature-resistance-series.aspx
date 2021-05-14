<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="high-temperature-resistance-series.aspx.cs" Inherits="high_temperature_resistance_series" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>耐熱電線、高溫電線-日進電線</title>
    <meta name="keywords" content="耐熱電線、高溫電線" />
    <meta name="description" content="各式耐熱電線，常於特殊高溫場所及機台使用的TGGT-5256、TGGT-400、MG5107、CF-750及其他各類常規及訂製電線">
    <link href="/css/RWD-ProductCategory.css" rel="stylesheet" />

    <style>
        .jumbotron {
            background: url("https://www.wallpapertip.com/wmimgs/33-330407_electrical-wiring.jpg");
            background-size: cover;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function ($) {
            $('.product-category .navigation-row').click(function () {
                window.location = $(this).data('href');
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">    
    <div class="jumbotron jumbotron-fluid">
        <div class="container">
            <div class="title">高溫線</div>
            <div class="subtitle">High Temperature Resistance Wire</div>
        </div>
    </div>
    <div class="product-subclass sticky-top">
        <nav class="navbar product-subclass-nav">
            <ul class="nav nav-pills">
                <li class="nav-item">
                    <a class="nav-link" href="#high-temperature-resistance-wire">高溫線</a>
                </li>
            </ul>
        </nav>
    </div>
    <body data-spy="scroll" data-target=".product-subclass-nav" data-offset="56">
        <div id="high-temperature-resistance-wire" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row m-0">
                            <div class="col-md-7">
                                <img src="/images/product_pic/tggt400-menu.jpg" class="img d-block m-auto" alt="高溫編織線 high-temperature-resistance-wire tggt5256 tggt400 mg5107 cf750" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">高溫編織線</div>
                                <p class="subtitle">High Temperature Resistance Wire</p>
                            </div>
                        </div>
                    </div>
                    <div class="row row-m-0">
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <table class="table table-hover table-striped table-bordered">
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
                                    <tr class="navigation-row" data-href="tggt-5256.aspx">
                                        <td>TGGT-5256
                                        </td>
                                        <td>耐熱
                                        </td>
                                        <td>600V
                                        </td>
                                        <td>-60°C~+250°C
                                        </td>
                                        <td>導體: 鍍錫銅線<br />
                                            絕緣體: 高溫矽橡膠<br />
                                            編織: 雙層玻璃纖維+矽樹脂
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="tggt-400.aspx">
                                        <td>TGGT-400
                                        </td>
                                        <td>耐熱
                                        </td>
                                        <td>600V
                                        </td>
                                        <td>-80°C~+400°C
                                        </td>
                                        <td>導體: 鍍錫鎳合金銅線<br />
                                            絕緣體: 	三層玻璃纖維
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="mg-5107.aspx">
                                        <td>MG-5107
                                        </td>
                                        <td>耐熱
                                        </td>
                                        <td>600V
                                        </td>
                                        <td>-100°C~+450°C
                                        </td>
                                        <td>導體: 鍍鎳銅線<br />
                                            絕緣體: 	雲母帶<br />
                                            絕緣體" 四層玻璃纖維
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="cf-750.aspx">
                                        <td>CF-750
                                        </td>
                                        <td>耐熱
                                        </td>
                                        <td>600V
                                        </td>
                                        <td>-120°C~+750°C
                                        </td>
                                        <td>導體: 純鎳線<br />
                                            絕緣體: 陶瓷纖維<br />
                                            絕緣體: 二氧化矽纖維<br />
                                            絕緣體: 高溫矽樹脂
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </body>    
</asp:Content>

