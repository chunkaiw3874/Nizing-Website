<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="pvc-series.aspx.cs" Inherits="pvc_series" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>PVC電線、控制線、家用電器配線-日進電線</title>
    <meta name="keywords" content="PVC電線,PVC電纜,PVC IV 粗芯控制線,KIV細芯控制線,家用電器配線" />
    <meta name="description" content="各式PVC線材，有一般家用的UL1007、UL1015、電腦傳輸訊號用的UL2464、UL2517、建築用的IV控制線、機械設備使用的KIV控制線、及其他各類常規及訂製線材">
    <link href="/css/RWD-ProductCategory.css" rel="stylesheet" />

    <style>
        .jumbotron {
            background: url("https://www.wallpapertip.com/wmimgs/33-330407_electrical-wiring.jpg");
            background-size: cover;
        }
    </style>
    <script>
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
            <div class="title">PVC線</div>
            <div class="subtitle">PVC Wire</div>
        </div>
    </div>
    <div class="product-subclass sticky-top">
        <nav class="navbar product-subclass-nav">
            <ul class="nav nav-pills">
                <li class="nav-item">
                    <a class="nav-link" href="#pvc-wire">PVC線</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#internet-cable">網路線</a>
                </li>
            </ul>
        </nav>
    </div>
    <body data-spy="scroll" data-target=".product-subclass-nav" data-offset="56">
        <div id="pvc-wire" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row m-0">
                            <div class="col-md-7">
                                <img src="/images/product_pic/iv_wire-menu.jpg" class="img d-block m-auto" alt="pvc線 pvc-wire ul1007 ul1015 iv-wire kiv-wire" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">PVC線</div>
                                <p class="subtitle">PVC Wire</p>
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
                                    <tr class="navigation-row" data-href="ul1007.aspx">
                                        <td>UL1007
                                        </td>
                                        <td>
                                        </td>
                                        <td>300V
                                        </td>
                                        <td>-10°C~+80°C
                                        </td>
                                        <td>導體: 鍍錫銅線<br />
                                            絕緣體: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="ul1015.aspx">
                                        <td>UL1015
                                        </td>
                                        <td>
                                        </td>
                                        <td>600V
                                        </td>
                                        <td>-10°C~+105°C
                                        </td>
                                        <td>導體: 鍍錫銅線<br />
                                            絕緣體: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="iv-wire.aspx">
                                        <td>IV
                                        </td>
                                        <td>建築用、粗芯
                                        </td>
                                        <td>600V
                                        </td>
                                        <td>-10°C~+60°C
                                        </td>
                                        <td>導體: 鍍錫銅線<br />
                                            絕緣體: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="kiv-wire.aspx">
                                        <td>KIV
                                        </td>
                                        <td>機器用、細芯
                                        </td>
                                        <td>600V
                                        </td>
                                        <td>-10°C~+60°C
                                        </td>
                                        <td>導體: 鍍錫銅線<br />
                                            絕緣體: PVC
                                        </td>
                                    </tr>                                    
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="multi-core-teflon-wire" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row row-m-0">
                            <div class="col-md-7">
                                <img src="/images/product_pic/ul2464-menu.jpg" class="img d-block m-auto" alt="網路線 internet-cable ul2464 ul2517" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">網路線</div>
                                <p class="subtitle">Internet Cable</p>
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
                                    <tr class="navigation-row" data-href="ul2464.aspx">
                                        <td>UL2464
                                        </td>
                                        <td>訊號線
                                        </td>
                                        <td>300V AC
                                        </td>
                                        <td>-20°C~+80°C
                                        </td>
                                        <td>導體: 鍍錫銅線<br />
                                            隔離: 單隔:鋁箔 / 雙隔:鋁箔+編織銅網<br />
                                            絕緣體: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="ul2464.aspx">
                                        <td>UL2517
                                        </td>
                                        <td>訊號線
                                        </td>
                                        <td>300V AC
                                        </td>
                                        <td>-20°C~+105°C
                                        </td>
                                        <td>導體: 鍍錫銅線<br />
                                            隔離: 單隔:鋁箔 / 雙隔:鋁箔+編織銅網<br />
                                            絕緣體: PVC
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

