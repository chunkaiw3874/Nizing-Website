<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="car.aspx.cs" Inherits="car" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>車用元件-日進電線</title>
    <meta name="description" content="車用元件研發製造，日進電線持續與最頂尖的新科技接軌，歡迎各種客製需求">
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
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="jumbotron jumbotron-fluid">
        <div class="container">
            <div class="title">車用線材
            </div>
            <div class="subtitle">Automobile Appliance Wire</div>
        </div>
    </div>
    <div class="product-subclass sticky-top">
        <nav class="navbar product-subclass-nav">
            <ul class="nav nav-pills">
                <li class="nav-item">
                    <a class="nav-link" href="#automobile-appliance-wire">車用線</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#automobile-lighting-wire">車燈用線</a>
                </li>
            </ul>
        </nav>
    </div>
    <body data-spy="scroll" data-target=".product-subclass-nav" data-offset="56">
        <div id="automobile-appliance-wire" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row m-0">
                            <div class="col-md-7">
                                <img src="/images/service_pic/engine-power-cable-menu.jpg" class="img d-block m-auto" alt="馬達動力線 感溫線 複合線" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">車用線</div>
                                <p class="subtitle">Automobile Appliance Wire</p>
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
                                        <th>耐熱範圍
                                        </th>
                                        <th>結構
                                        </th>
                                    </tr>
                                    <tr class="navigation-row" data-href="engine-power-cable.aspx">
                                        <td>馬達動力線
                                        </td>
                                        <td>傳輸電流至引擎的主要傳輸電纜
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="temperature-sensor.aspx">
                                        <td>車用感溫線
                                        </td>
                                        <td>精確的測量車輛各處溫度
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="ul3512.aspx">
                                        <td>UL3512
                                        </td>
                                        <td>耐熱
                                        </td>
                                        <td>600V
                                        </td>
                                        <td>-60°C~+200°C
                                        </td>
                                        <td>導體: 鍍錫銅線<br />
                                            絕緣: 矽橡膠<br />
                                            外被: 玻璃纖維+矽樹脂
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="m27500.aspx">
                                        <td>M27500
                                        </td>
                                        <td>軍規、多芯
                                        </td>
                                        <td>...
                                        </td>
                                        <td>90°C~400°C
                                        </td>
                                        <td>導體: 鍍錫/鍍銀/鍍鎳銅線...<br />
                                            絕緣: PVC/Nylon/FEP/PTFE...<br />
                                            編織: 鍍錫/鍍銀/鍍鎳銅線...
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="m81822.aspx">
                                        <td>M81822
                                        </td>
                                        <td>軍規
                                        </td>
                                        <td>300V
                                        </td>
                                        <td>105°C~200°C
                                        </td>
                                        <td>導體: 鍍銀銅線<br />
                                            絕緣: PTFE/PVDF...
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

