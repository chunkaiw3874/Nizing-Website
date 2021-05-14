<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="heating-wire-series.aspx.cs" Inherits="heating_wire_series" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>發熱線、醫療器材配線-日進電線</title>
    <meta name="keywords" content="發熱線,醫療呼吸管" />
    <meta name="description" content="各式發熱線材，包含醫療呼吸管使用的UL3589、UL3323，以及為表層加溫的PHC並聯式電熱帶、及其他各類常規及訂製線材">
    <link href="/css/RWD-ProductCategory.css" rel="stylesheet" />

    <style>
        .jumbotron{
            background: url("https://www.wallpapertip.com/wmimgs/33-330407_electrical-wiring.jpg");
            background-size:cover;
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
            <div class="title">發熱線</div>
            <div class="subtitle">Heating Wire</div>
        </div>
    </div>
    <div class="product-subclass sticky-top">
        <nav class="navbar product-subclass-nav">
            <ul class="nav nav-pills">
                <li class="nav-item">
                    <a class="nav-link" href="#heating-wire">發熱線</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#phc">並聯式發熱帶</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#medical-heating-wire">醫療用發熱線</a>
                </li>
            </ul>
        </nav>
    </div>
    <body data-spy="scroll" data-target=".product-subclass-nav" data-offset="56">
        <div id="heating-wire" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row m-0">
                            <div class="col-md-7">
                                <%--<img src="https://dummyimage.com/2.35:1x1080" class="img img-fluid img-thumbnail" />--%>
                                <img src="/images/product_pic/ul3589-3.jpg" class="img d-block m-auto" alt="ul3589 ul3323 發熱線" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">單芯發熱線</div>
                                <p class="subtitle">Heating Wire</p>
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
                                        <th>電阻值
                                        </th>
                                        <th>額定電壓
                                        </th>
                                        <th>溫度範圍
                                        </th>
                                        <th>結構
                                        </th>
                                    </tr>
                                    <tr class="navigation-row" data-href="ul3589.aspx">
                                        <td>UL3323
                                        </td>
                                        <td>發熱
                                        </td>
                                        <td>0.5~5000 Ohm
                                        </td>
                                        <td>300V
                                        </td>
                                        <td>-60°C~+200°C
                                        </td>
                                        <td>導體: 合金纏繞線/玻璃纖維<br />
                                            絕緣體: 矽橡膠
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="ul3589.aspx">
                                        <td>UL3589
                                        </td>
                                        <td>發熱
                                        </td>
                                        <td>0.5~5000 Ohm
                                        </td>
                                        <td>600V
                                        </td>
                                        <td>-60°C~+200°C
                                        </td>
                                        <td>導體: 合金纏繞線/玻璃纖維<br />
                                            絕緣體: 矽橡膠
                                        </td>
                                    </tr>
                                </table>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="phc" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row row-m-0">
                            <div class="col-md-7">
                                <%--<img src="https://dummyimage.com/2.35:1x1080" class="img img-fluid img-thumbnail" />--%>
                                <img src="/images/product_pic/phc-3.jpg" class="img d-block m-auto" alt="parallel heating cable 並聯式電熱帶" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">並聯式電熱帶</div>
                                <p class="subtitle">PHC</p>
                                <%--<p>並聯式電熱帶</p>--%>
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
                                    <tr class="navigation-row" data-href="phc.aspx">
                                        <td>PHC
                                        </td>
                                        <td>發熱、並聯
                                        </td>
                                        <td>110V/230V
                                        </td>
                                        <td>-60°C~+200°C
                                        </td>
                                        <td>導體: 合金纏繞線、鍍錫銅線<br />
                                            絕緣體: 矽橡膠<br />
                                            外被: 矽橡膠
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="medical-heating-wire" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row row-m-0 ">
                            <div class="col-md-7">
                                <img src="/images/service_pic/medical-respiration-pipe-heating-wire-3.jpg" class="img d-block m-auto" alt="醫療用加熱管 heating pipe" />
                            </div>
                            <div class="col-md-5">
                                <div class="card-body">
                                    <div class="title">醫療用加熱管</div>
                                    <p class="subtitle">Respiration Heating Pipe</p>
                                </div>
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
                                        <th>導體電阻
                                        </th>
                                        <th>溫度範圍
                                        </th>
                                        <th>結構
                                        </th>
                                    </tr>
                                    <tr class="navigation-row" data-href="respiration-pipe-heating-wire.aspx">
                                        <td>醫療用呼吸加熱管
                                        </td>
                                        <td>加熱、醫療
                                        </td>
                                        <td>3 Ohm/M
                                        </td>
                                        <td>80°C
                                        </td>
                                        <td>絕緣體: 醫療級聚丙烯<br />
                                            填充: 聚脂纖維
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

