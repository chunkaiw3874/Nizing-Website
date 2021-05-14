<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="automotive-wire-series.aspx.cs" Inherits="automotive_wire_series" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>汽車花線-日進電線</title>
    <meta name="keywords" content="日規汽車花線,美規汽車花線,歐規汽車花線" />
    <meta name="description" content="各種規格，符合規範的日規汽車花線、美規汽車花線、及歐規汽車花線">
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
            <div class="title">汽車花線</div>
            <div class="subtitle">Automotive Wire</div>
        </div>
    </div>
    <div class="product-subclass sticky-top">
        <nav class="navbar product-subclass-nav">
            <ul class="nav nav-pills">
                <li class="nav-item">
                    <a class="nav-link" href="#jaso-standard-automotive-wire">日規汽車花線</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#sae-standard-automotive-wire">美規汽車花線</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#iso-standard-automotive-wire">歐規汽車花線</a>
                </li>
            </ul>
        </nav>
    </div>
    <body data-spy="scroll" data-target=".product-subclass-nav" data-offset="56">
        <div id="jaso-standard-automotive-wire" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row m-0">
                            <div class="col-md-7">
                                <%--<div class="row m-0 image-container">
                                    <div class="col-8 p-0 mr-1">
                                        <img src="/images/product_pic/av-menu.jpg" class="img w-100" alt="日規汽車花線 JASO-Standard-Automotive-Wire av avs avss avssh aex avx aessx cavs cavus chfus hfss civus ivssh asssh sh-sx sh-sh le-ss le-sx le-sh" />
                                    </div>
                                    <div class="col-3 p-0 d-flex flex-column align-items-end">
                                        <img src="/images/product_pic/av-menu.jpg" class="img w-100" alt="日規汽車花線 JASO-Standard-Automotive-Wire av avs avss avssh aex avx aessx cavs cavus chfus hfss civus ivssh asssh sh-sx sh-sh le-ss le-sx le-sh" />
                                        <img src="/images/product_pic/av-menu.jpg" class="img w-100 mt-auto" alt="日規汽車花線 JASO-Standard-Automotive-Wire av avs avss avssh aex avx aessx cavs cavus chfus hfss civus ivssh asssh sh-sx sh-sh le-ss le-sx le-sh" />
                                    </div>
                                </div>--%>
                                <img src="/images/product_pic/av-menu.jpg" class="img" alt="日規汽車花線 JASO-Standard-Automotive-Wire av avs avss avssh aex avx aessx cavs cavus chfus hfss civus ivssh asssh sh-sx sh-sh le-ss le-sx le-sh" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">日規汽車花線</div>
                                <p class="subtitle">JASO Standard Automotive Wire</p>
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
                                        <th>溫度範圍
                                        </th>
                                        <th>結構
                                        </th>
                                    </tr>
                                    <tr class="navigation-row" data-href="av.aspx">
                                        <td>AV
                                        </td>
                                        <td>日規
                                        </td>
                                        <td>80°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="avs.aspx">
                                        <td>AVS
                                        </td>
                                        <td>日規、薄
                                        </td>
                                        <td>80°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="avss.aspx">
                                        <td>AVSS
                                        </td>
                                        <td>日規、極薄
                                        </td>
                                        <td>80°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="avssh.aspx">
                                        <td>AVSSH
                                        </td>
                                        <td>日規、耐熱、超薄
                                        </td>
                                        <td>100°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="aex.aspx">
                                        <td>AEX
                                        </td>
                                        <td>日規、耐熱
                                        </td>
                                        <td>120°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="avx.aspx">
                                        <td>AVX
                                        </td>
                                        <td>日規、照射
                                        </td>
                                        <td>100°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: XLPVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="aessx.aspx">
                                        <td>AESSX
                                        </td>
                                        <td>日規、耐熱、照射、極薄
                                        </td>
                                        <td>120°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: XLPE
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="cavs.aspx">
                                        <td>CAVS
                                        </td>
                                        <td>日規、薄
                                        </td>
                                        <td>80°C
                                        </td>
                                        <td>導體: 壓縮銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="cavus.aspx">
                                        <td>CAVUS
                                        </td>
                                        <td>日規、超薄
                                        </td>
                                        <td>80°C
                                        </td>
                                        <td>導體: 壓縮銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="chfus.aspx">
                                        <td>CHFUS
                                        </td>
                                        <td>日規、無鹵、極薄
                                        </td>
                                        <td>85°C
                                        </td>
                                        <td>導體: 壓縮銅線<br />
                                            絕緣: TPE
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="hfss.aspx">
                                        <td>HFSS
                                        </td>
                                        <td>日規、無鹵、極薄
                                        </td>
                                        <td>85°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: TPE
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="civus.aspx">
                                        <td>CIVUS
                                        </td>
                                        <td>日規、耐熱、超薄
                                        </td>
                                        <td>105°C
                                        </td>
                                        <td>導體: 壓縮銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="ivssh.aspx">
                                        <td>IVSSH
                                        </td>
                                        <td>日規、極薄、耐熱
                                        </td>
                                        <td>100°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="av.aspx">
                                        <td>AV
                                        </td>
                                        <td>日規
                                        </td>
                                        <td>80°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="asssh-shsx-shsh.aspx">
                                        <td>ASSSH
                                        </td>
                                        <td>日規
                                        </td>
                                        <td>90°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC<br />
                                            編織: 鍍錫銅線<br />
                                            外被: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="asssh-shsx-shsh.aspx">
                                        <td>ASSSH
                                        </td>
                                        <td>日規、多芯
                                        </td>
                                        <td>90°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC<br />
                                            編織: 鍍錫銅線<br />
                                            外被: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="asssh-shsx-shsh.aspx">
                                        <td>SH-SX
                                        </td>
                                        <td>日規、耐熱、多芯
                                        </td>
                                        <td>125°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PE<br />
                                            編織: 鍍錫銅線<br />
                                            外被: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="asssh-shsx-shsh.aspx">
                                        <td>SH-SH
                                        </td>
                                        <td>日規、耐熱、多芯
                                        </td>
                                        <td>100°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC<br />
                                            編織: 鍍錫銅線<br />
                                            外被: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="less-lesx-lesh.aspx">
                                        <td>LE-SS
                                        </td>
                                        <td>日規、多芯
                                        </td>
                                        <td>90°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC<br />
                                            包帶: 金屬箔<br />
                                            外被: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="less-lesx-lesh.aspx">
                                        <td>LE-SX
                                        </td>
                                        <td>日規、耐熱、多芯
                                        </td>
                                        <td>125°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PE<br />
                                            包帶: 金屬箔<br />
                                            外被: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="less-lesx-lesh.aspx">
                                        <td>LE-SH
                                        </td>
                                        <td>日規、耐熱、多芯
                                        </td>
                                        <td>100°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC<br />
                                            包帶: 金屬箔<br />
                                            外被: PVC
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="sae-standard-automotive-wire" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row m-0">
                            <div class="col-md-7">
                                <img src="/images/product_pic/gxl-menu.jpg" class="img d-block m-auto" alt="美規汽車花線 SAE-Standard-Automotive-Wire gpt twp hdt gxl sxl txl" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">美規汽車花線</div>
                                <p class="subtitle">SAE Standard Automotive Wire</p>
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
                                        <th>溫度範圍
                                        </th>
                                        <th>結構
                                        </th>
                                    </tr>
                                    <tr class="navigation-row" data-href="gpt.aspx">
                                        <td>GPT
                                        </td>
                                        <td>美規
                                        </td>
                                        <td>-40°C~+85°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="twp.aspx">
                                        <td>TWP
                                        </td>
                                        <td>美規、薄
                                        </td>
                                        <td>-40°C~+85°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="hdt.aspx">
                                        <td>HDT
                                        </td>
                                        <td>美規、厚
                                        </td>
                                        <td>-40°C~+85°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="gxl.aspx">
                                        <td>GXL
                                        </td>
                                        <td>美規、耐熱、照射
                                        </td>
                                        <td>-40°C~125°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: XLPE
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="sxl.aspx">
                                        <td>SXL
                                        </td>
                                        <td>美規、耐熱、照射、厚
                                        </td>
                                        <td>-40°C~125°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: XLPE
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="txl.aspx">
                                        <td>TXL
                                        </td>
                                        <td>美規、耐熱、照射、薄
                                        </td>
                                        <td>-40°C~125°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: XLPE
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>  
        <div id="iso-standard-automotive-wire" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row m-0">
                            <div class="col-md-7">
                                <img src="/images/product_pic/flr13ya-menu.jpg" class="img d-block m-auto" alt="歐規汽車花線 ISO-Standard-Automotive-Wire flry-a flry-b flrynx flryy flryw-a flryw-b fly flyw flyy-single flyy-multi fl2x-a fl2x-b flr2x-a flr2x-b flr13y-a" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">歐規汽車花線</div>
                                <p class="subtitle">ISO Standard Automotive Wire</p>
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
                                        <th>溫度範圍
                                        </th>
                                        <th>結構
                                        </th>
                                    </tr>
                                    <tr class="navigation-row" data-href="flrya.aspx">
                                        <td>FLRY-A
                                        </td>
                                        <td>歐規、薄
                                        </td>
                                        <td>-40°C~+105°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="flryb.aspx">
                                        <td>FLRY-B
                                        </td>
                                        <td>歐規、薄
                                        </td>
                                        <td>-40°C~+105°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="flrynx.aspx">
                                        <td>FLRYnx
                                        </td>
                                        <td>歐規、薄、多芯、無外被
                                        </td>
                                        <td>-40°C~+105°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="flryy.aspx">
                                        <td>FLRYY
                                        </td>
                                        <td>歐規、薄、多芯
                                        </td>
                                        <td>-40°C~+105°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC<br />
                                            外被: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="flrywa.aspx">
                                        <td>FLRYW-A
                                        </td>
                                        <td>歐規、耐熱、薄
                                        </td>
                                        <td>-40°C~+125°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="flrywb.aspx">
                                        <td>FLRYW-B
                                        </td>
                                        <td>歐規、耐熱
                                        </td>
                                        <td>-40°C~125°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="fly.aspx">
                                        <td>FLY
                                        </td>
                                        <td>歐規、厚
                                        </td>
                                        <td>-40°C~+105°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="flyw.aspx">
                                        <td>FLYW
                                        </td>
                                        <td>歐規、厚、耐熱
                                        </td>
                                        <td>-40°C~+125°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="flyy-single.aspx">
                                        <td>FLYY-Single
                                        </td>
                                        <td>歐規、厚、雙層絕緣
                                        </td>
                                        <td>-40°C~+105°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC<br />
                                            外被: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="flyy-multi.aspx">
                                        <td>FLYY-Multi
                                        </td>
                                        <td>歐規、耐熱、厚、雙層絕緣、多芯
                                        </td>
                                        <td>-40°C~+125°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: PVC<br />
                                            外被: PVC
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="fl2xa.aspx">
                                        <td>FL2X-A
                                        </td>
                                        <td>歐規、耐熱、厚、照射
                                        </td>
                                        <td>-40°C~+125°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: XLPE
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="fl2xb.aspx">
                                        <td>FL2X-B
                                        </td>
                                        <td>歐規、耐熱、厚、照射
                                        </td>
                                        <td>-40°C~+125°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: XLPE
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="flr2xa.aspx">
                                        <td>FLR2X-A
                                        </td>
                                        <td>歐規、薄、耐熱、照射
                                        </td>
                                        <td>-40°C~+125°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: XLPE
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="flr2xb.aspx">
                                        <td>FLR2X-B
                                        </td>
                                        <td>歐規、薄、耐熱、照射
                                        </td>
                                        <td>-40°C~+125°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: XLPE
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="flr13ya.aspx">
                                        <td>ASSSH
                                        </td>
                                        <td>歐規、薄、耐熱
                                        </td>
                                        <td>-40°C~+150°C
                                        </td>
                                        <td>導體: 軟絞銅線<br />
                                            絕緣: TPE-E
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

