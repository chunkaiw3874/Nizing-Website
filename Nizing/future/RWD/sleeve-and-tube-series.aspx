<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="sleeve-and-tube-series.aspx.cs" Inherits="sleeve_and_tube_series" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>套管、絕緣-日進電線</title>
    <meta name="keywords" content="矽膠套管,玻璃纖維套管,鐵氟龍套管,絕緣保護" />
    <meta name="description" content="各式套管、包含UL HST、UL FRS、UL SRG、各式鐵氟龍套管、矽膠套管、玻璃纖維套管，提供最適當的絕緣保護">
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
            <div class="title">套管</div>
            <div class="subtitle">Tube and Sleeve</div>
        </div>
    </div>
    <div class="product-subclass sticky-top">
        <nav class="navbar product-subclass-nav">
            <ul class="nav nav-pills">
                <li class="nav-item">
                    <a class="nav-link" href="#fiberglass-tube">玻璃纖維套管</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#silicone-tube">矽膠套管</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#multi-layer-tube">多層絕緣套管</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#teflon-tube">鐵氟龍套管</a>
                </li>
            </ul>
        </nav>
    </div>
    <body data-spy="scroll" data-target=".product-subclass-nav" data-offset="56">
        <div id="fiberglass-tube" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row m-0">
                            <div class="col-md-7">
                                <img src="/images/product_pic/ulsrg-menu.jpg" class="img d-block m-auto" alt="玻璃纖維套管 Fiberglass-Tube UL-SSG-SRG" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">玻璃纖維套管</div>
                                <p class="subtitle">Fiberglass Tube</p>
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
                                    <tr class="navigation-row" data-href="ulsrg.aspx">
                                        <td>UL SSG/SRG
                                        </td>
                                        <td>耐熱、阻燃自熄 ULVW-1
                                        </td>
                                        <td>1.5KV~2.5KV
                                        </td>
                                        <td>-40°C~+200°C
                                        </td>
                                        <td>玻璃纖維
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="silicone-tube" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row row-m-0">
                            <div class="col-md-7">
                                <img src="/images/product_pic/silicone_tube-menu.jpg" class="img d-block m-auto" alt="矽膠套管 silicone-tube" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">矽膠套管</div>
                                <p class="subtitle">Silicone Tube</p>
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
                                    <tr class="navigation-row" data-href="silicone-tube.aspx">
                                        <td>Silicone Tube
                                        </td>
                                        <td>耐熱、阻燃自熄 ULVW-1
                                        </td>
                                        <td>4KV
                                        </td>
                                        <td>-60°C~+200°C
                                        </td>
                                        <td>矽橡膠
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="multi-layer-tube" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row row-m-0">
                            <div class="col-md-7">
                                <img src="/images/product_pic/ulhst-menu.jpg" class="img d-block m-auto" alt="多層絕緣套管 UL-HST UL-FRS" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">多層絕緣套管</div>
                                <p class="subtitle">Multi-Layer Tube</p>
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
                                    <tr class="navigation-row" data-href="ulhst.aspx">
                                        <td>UL HST
                                        </td>
                                        <td>雙層絕緣、阻燃自熄 ULVW-1
                                        </td>
                                        <td>600V~8KV AC
                                        </td>
                                        <td>-60°C~+200°C
                                        </td>
                                        <td>內: 矽橡膠<br />
                                            外: 玻璃纖維
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="ulfrs.aspx">
                                        <td>UL FRS
                                        </td>
                                        <td>雙層絕緣、阻燃自熄 ULVW-1
                                        </td>
                                        <td>4KV
                                        </td>
                                        <td>-30°C~+200°C
                                        </td>
                                        <td>內: 玻璃纖維<br />
                                            外: 矽橡膠
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="teflon-tube" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row row-m-0">
                            <div class="col-md-7">
                                <img src="/images/product_pic/pfa_fep_tube-menu.jpg" class="img d-block m-auto" alt="鐵氟龍套管 Teflon-Tube PFA-FEP-Tube PTFE-Tube" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">鐵氟龍套管</div>
                                <p class="subtitle">Teflon Tube</p>
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
                                    <tr class="navigation-row" data-href="pfa-fep-tube.aspx">
                                        <td>FEP Tube
                                        </td>
                                        <td>耐熱
                                        </td>
                                        <td>24KV~74KV
                                        </td>
                                        <td>-100°C~+200°C
                                        </td>
                                        <td>FEP
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="pfa-fep-tube.aspx">
                                        <td>PFA Tube
                                        </td>
                                        <td>耐熱
                                        </td>
                                        <td>24KV~74KV
                                        </td>
                                        <td>-100°C~+260°C
                                        </td>
                                        <td>PFA
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="ptfe-tube.aspx">
                                        <td>PTFE Tube
                                        </td>
                                        <td>耐熱
                                        </td>
                                        <td>24KV
                                        </td>
                                        <td>-100°C~+280°C
                                        </td>
                                        <td>FEP
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

