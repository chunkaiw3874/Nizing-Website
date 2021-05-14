<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="military-grade-series.aspx.cs" Inherits="military_grade_series" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>軍規電線、軍規電纜-日進電線</title>
    <meta name="keywords" content="船用軍規電纜,軍規電子線" />
    <meta name="description" content="各式軍規線材，MIL-C-24643/23-08軍規船用電纜、MIL-W-22759鐵氟龍軍規電子線等軍規線材">
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
            <div class="title">軍規線</div>
            <div class="subtitle">Military Grade Cable</div>
        </div>
    </div>
    <div class="product-subclass sticky-top">
        <nav class="navbar product-subclass-nav">
            <ul class="nav nav-pills">
                <li class="nav-item">
                    <a class="nav-link" href="#military-grade-cable">軍規線</a>
                </li>
            </ul>
        </nav>
    </div>
    <body data-spy="scroll" data-target=".product-subclass-nav" data-offset="56">
        <div id="military-grade-cable" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row m-0">
                            <div class="col-md-7">
                                <img src="/images/product_pic/m24643-720x412.png" class="img d-block m-auto" alt="軍規線 military-grade-cable M16878 MIL-DTL-16878 M22759 MIL-DTL-22759 M24643 MIL-DTL-24643 M27500 MIL-DTL-27500 M81822 MIL-W-81822" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">軍規線</div>
                                <p class="subtitle">Military Grade Cable</p>
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
                                    <tr class="navigation-row" data-href="m16878.aspx">
                                        <td>M16878
                                        </td>
                                        <td>軍規
                                        </td>
                                        <td>250V~1000V
                                        </td>
                                        <td>105°C~260°C
                                        </td>
                                        <td>導體: 鍍錫/鍍銀/鍍鎳銅線...<br />
                                            絕緣: PVC/FEP/PTFE...
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="m22759.aspx">
                                        <td>M22759
                                        </td>
                                        <td>軍規
                                        </td>
                                        <td>600V~1000V
                                        </td>
                                        <td>150°C~260°C
                                        </td>
                                        <td>導體: 鍍錫/鍍銀/鍍鎳銅線...<br />
                                            絕緣: PTFE/PTFE帶...
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="m24643.aspx">
                                        <td>M24643
                                        </td>
                                        <td>軍規、多芯
                                        </td>
                                        <td>300V~5000V
                                        </td>
                                        <td>...
                                        </td>
                                        <td>...
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

