<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="special-cable.aspx.cs" Inherits="special_cable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>客製線、冷媒線-日進電線</title>
    <meta name="keywords" content="客製電線,冷媒線" />
    <meta name="description" content="各式客製特殊線材，有一般冷凍壓縮馬達使用的UL5048冷媒線、及其他各類客製電線">
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
            <div class="title">特殊線</div>
            <div class="subtitle">Special Cable</div>
        </div>
    </div>
    <div class="product-subclass sticky-top">
        <nav class="navbar product-subclass-nav">
            <ul class="nav nav-pills">
                <li class="nav-item">
                    <a class="nav-link" href="#anti-refrigrant-wire">發熱線</a>
                </li>
            </ul>
        </nav>
    </div>
    <body data-spy="scroll" data-target=".product-subclass-nav" data-offset="56">
        <div id="anti-refridgrant-wire" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row m-0">
                            <div class="col-md-7">
                                <%--<img src="https://dummyimage.com/2.35:1x1080" class="img img-fluid img-thumbnail" />--%>
                                <img src="/images/product_pic/ul5048-menu.jpg" class="img d-block m-auto" alt="冷媒線 Anti-Refrigerant-Wire UL5048" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">冷媒線</div>
                                <p class="subtitle">Anti-Refrigerant Wire</p>
                                <%--<p>發熱線</p>--%>
                            </div>
                        </div>
                    </div>
                    <div class="row row-m-0">
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <table class="table table-hover table-striped table-bordered">
                                    <tr class="">
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
                                    <tr class="navigation-row" data-href="ul5048.aspx">
                                        <td>UL5048
                                        </td>
                                        <td>耐冷
                                        </td>
                                        <td>600V AC
                                        </td>
                                        <td>-40°C~+105°C
                                        </td>
                                        <td>導體: 鍍錫銅線<br />
                                            隔離: PETP纖維<br />
                                            絕緣: PETP纖維
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

