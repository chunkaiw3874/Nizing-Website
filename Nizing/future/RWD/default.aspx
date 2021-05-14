<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>高品質電線電纜製造-日進電線-國際安規認證通過</title>
    <meta name="keywords" content="電線,電纜,電線電纜,矽膠電線,鐵氟龍電線,照射電線,發熱電線,PVC電線,PE電線,PU電線,補償導線,耐高溫電線,耐高溫電纜,耐高壓電線,耐高壓電纜,UL電線,矽膠編織電線,軍規線,汽車花線" />
    <meta name="description" content="日進電線為國內一流電線及電纜製造商，專門製造特殊材質及用途電線及電纜，如耐高溫的矽膠電線、矽膠編織電線，抗酸鹼的聚合氟化線電線，抗UV的照射電線等，旗下電線電纜產品眾多，歡迎聯繫洽詢" />
    <style style="text/css">
        .company-image {
            margin-bottom: -6px;
        }

        .main-block {
            background-color: #ffffff;
            padding: 24px 0px;
        }

            .main-block .container .title {
                text-align: center;
            }

            .main-block .container .subtitle {
                text-align: center;
            }

            .main-block .content {
                margin-top: 24px;
            }

            .main-block:nth-child(2n) {
                background-color: #f1f1f1;
            }

            .main-block .list-group-item {
                background-color: inherit;
                border: none;
            }

        .emphasis-menu {
            background-color: #f1f1f1;
            padding: 0px;
        }

            .emphasis-menu .card-body {
                text-align: center;
            }

                .emphasis-menu .card-body span {
                    font-size: 1rem;
                }

                .emphasis-menu .card-body .img-thumbnail {
                    filter: invert(0.4) sepia(0) saturate(1) hue-rotate(0deg) brightness(0.5);
                    background-color: inherit;
                    border: none;
                    width: 75px;
                }

        .tilted {
            transform: rotate(-135deg);
        }


        /*.image-stack .img {
            width: 100%;
            display: block;
        }*/

        .image-stack::after {
            content: ' ';
            display: table;
            clear: both;
        }

        .image-stack .stack-top {
            float: right;
            width: 57%;
            position: relative;
            margin-top: 23%;
            z-index: 1;
        }

        .image-stack .stack-bottom {
            float: left;
            margin-right: -100%;
            width: 66%;
        }

        @supports (display: grid) {
            .image-stack {
                display: grid;
                grid-template-columns: repeat(12, 1fr);
                position: relative;
            }

                .image-stack .stack-top {
                    grid-column: 1/span 8;
                    grid-row: 1;
                    padding-top: 20%;
                }

            image-stack .stack-bottom {
                grid-column: 4/-1;
                grid-row: 1;
            }
        }

        .more-button {
            /*background-color: inherit;*/
            /*border:solid 1px #585858;*/
            /*mix-blend-mode: lighten;*/
            /*filter:invert(1);*/
            /*color:inherit;*/
        }

        .emphasis-menu .card-body .card-text .title {
            font-size: large;
            font-weight: bold;
        }

        .emphasis-menu .card-body .card-text .subtitle {
            font-weight: bold;
            font-size: small;
            color: gray;
        }

        .emphasis-menu .card-body .card-text {
            font-size: 0.8rem;
            font-weight: normal;
        }

            .emphasis-menu .card-body .card-text .btn {
                /*background-color: inherit;*/
            }

        .emphasis-menu .card-link {
            color: inherit;
        }

        .product-menu .img {
            width: 400px;
        }

        .product-menu .img-thumbnail:hover {
            border-color: #585858;
        }

        .news .card {
            border-bottom: solid 1px #585858;
        }

        .news .card-body {
            padding-top: 0px;
        }

        .news .card-img {
            width: 200px;
        }

        .associate-partner {
            background-color: #f1f1f1;
            padding: 20px 10px;
        }

            .associate-partner img {
                width: 50px;
            }
        /*slick slide vertical center*/
        .slick-initialized .slick-track {
            display: flex;
            align-items: center;
        }

        @media all and (min-width: 768px) {
            .emphasis-menu .card {
                border: none;
                padding: 0px;
            }

            .emphasis-menu .col {
                /*border-right: solid 1px #d7d7d7;*/
            }

                .emphasis-menu .col:last-child {
                    border-right: none;
                }

            .emphasis-menu .card-link {
                padding: 10px 0px;
            }

                .emphasis-menu .card-link:hover {
                    background-color: #e0fffe;
                }

            .news .card-img {
                width: 100%;
            }
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            $('.associate-partner .slider').slick({
                mobileFirst: true,
                arrows: false,
                slidesToShow: 4,
                slidesToScroll: 1,
                autoplay: true,
                autoplaySpeed: 500,
                centerMode: true,
                responsive: [
                    {
                        breakpoint: 576,
                        settings: {
                            slidesToShow: 4,
                            sllidesToScroll: 1
                        }
                    },
                    {
                        breakpoint: 768,
                        settings: {
                            slidesToShow: 6,
                            sllidesToScroll: 1
                        }
                    },
                    {
                        breakpoint: 992,
                        settings: {
                            slidesToShow: 8,
                            sllidesToScroll: 1
                        }
                    }
                ]

            })
        });

        $(window).resize(function () {
            $('.associate-partner .slider').not('.slick-initialized').slick('resize');
        });

        $(window).on('orientationchange', function () {
            $('.associate-partner .slider').not('.slick-initialized').slick('resize');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="company-image">
            <video preload="auto" muted autoplay loop playsinline>
                <source src="/video/nizing-intro.mp4" />
            </video>
        </div>
        <div class="emphasis-menu">
            <%--<div class="slider">
                <nav class="card">
                    <a class="card-link" href="silicone-fiberglass-series.aspx">
                        <div class="card-body d-sm-block">
                            <img src="images/menu/braided-wire-menu-white.svg" class="img img-thumbnail tilted" />
                            <p class="card-text">矽膠編織線</p>
                        </div>
                    </a>
                </nav>
                <nav class="card h-100">
                    <a class="card-link" href="high-temperature-resistance-series.aspx">
                        <div class="card-body">
                            <img src="images/menu/high-temperature-wire-menu-white.svg" class="img img-thumbnail tilted" />
                            <p class="card-text">高溫線</p>
                        </div>
                    </a>
                </nav>
                <nav class="card h-100">
                    <a class="card-link" href="silicone-series.aspx">
                        <div class="card-body">
                            <img src="images/menu/silicone-wire-menu-white.svg" class="img img-thumbnail tilted" />
                            <p class="card-text">矽膠線</p>
                        </div>
                    </a>
                </nav>
                <nav class="card h-100">
                    <a class="card-link" href="teflon-series.aspx">
                        <div class="card-body">
                            <img src="images/menu/teflon-wire-menu-white.svg" class="img img-thumbnail tilted" />
                            <p class="card-text">鐵氟龍線</p>
                        </div>
                    </a>
                </nav>
                <nav class="card h-100">
                    <a class="card-link" href="xlpe-series.aspx">
                        <div class="card-body">
                            <img src="images/menu/xlpe-wire-menu-white.svg" class="img img-thumbnail tilted" />
                            <p class="card-text">XLPE</p>
                        </div>
                    </a>
                </nav>
                <nav class="card h-100">
                    <a class="card-link" href="pvc-series.aspx">
                        <div class="card-body">
                            <img src="images/menu/pvc-wire-menu-white.svg" class="img img-thumbnail tilted" />
                            <p class="card-text">PVC</p>
                        </div>
                    </a>
                </nav>
                <nav class="card h-100">
                    <a class="card-link" href="sleeve-and-tube-series.aspx">
                        <div class="card-body">
                            <img src="images/menu/tube-menu-white.svg" class="img img-thumbnail" />
                            <p class="card-text">套管</p>
                        </div>
                    </a>
                </nav>
                <nav class="card h-100">
                    <a class="card-link" href="thermocouple-series.aspx">
                        <div class="card-body">
                            <img src="images/menu/thermocouple-wire-menu-white.svg" class="img img-thumbnail tilted" />
                            <p class="card-text">補償導線</p>
                        </div>
                    </a>
                </nav>
                <nav class="card h-100">
                    <a class="card-link" href="heating-wire-series.aspx">
                        <div class="card-body">
                            <img src="images/menu/heating-wire-menu-white.svg" class="img img-thumbnail" />
                            <p class="card-text">發熱線</p>
                        </div>
                    </a>
                </nav>
            </div>--%>
            <div class="container">
                <div class="row-m-0 row row-cols-1 row-cols-sm-2 row-cols-md-4 row-cols-lg-6 w-100">
                    <div class="col-px-0 col align-self-center d-none d-sm-block">
                        <div class="card">
                            <div class="card-body">
                                <div class="card-text text-md-left">
                                    <div class="title">暢銷分類</div>
                                    <div class="subtitle">Best Sellers</div>
                                    <div>
                                        <a class="btn btn-dark text-light mt-2 more-button" href="product.aspx">+ More</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-px-0 col d-none d-sm-block">
                        <nav class="card">
                            <a class="card-link" href="silicone-fiberglass-series.aspx">
                                <div class="card-body d-sm-block">
                                    <img src="images/menu/braided-wire-menu-white.svg" class="img img-thumbnail tilted" />
                                    <p class="card-text">矽膠編織線</p>
                                </div>
                            </a>
                        </nav>
                    </div>
                    <div class="col-px-0 col d-none d-sm-block">
                        <nav class="card h-100">
                            <a class="card-link" href="high-temperature-resistance-series.aspx">
                                <div class="card-body">
                                    <img src="images/menu/high-temperature-wire-menu-white.svg" class="img img-thumbnail tilted" />
                                    <p class="card-text">高溫線</p>
                                </div>
                            </a>
                        </nav>
                    </div>
                    <div class="col-px-0 col d-none d-sm-block">
                        <nav class="card h-100">
                            <a class="card-link" href="silicone-series.aspx">
                                <div class="card-body">
                                    <img src="images/menu/silicone-wire-menu-white.svg" class="img img-thumbnail tilted" />
                                    <p class="card-text">矽膠線</p>
                                </div>
                            </a>
                        </nav>
                    </div>
                    <div class="col-px-0 col d-none d-lg-block">
                        <nav class="card h-100">
                            <a class="card-link" href="teflon-series.aspx">
                                <div class="card-body">
                                    <img src="images/menu/teflon-wire-menu-white.svg" class="img img-thumbnail tilted" />
                                    <p class="card-text">鐵氟龍線</p>
                                </div>
                            </a>
                        </nav>
                    </div>
                    <div class="col-px-0 col d-none d-lg-block">
                        <nav class="card h-100">
                            <a class="card-link" href="xlpe-series.aspx">
                                <div class="card-body">
                                    <img src="images/menu/xlpe-wire-menu-white.svg" class="img img-thumbnail tilted" />
                                    <p class="card-text">XLPE</p>
                                </div>
                            </a>
                        </nav>
                    </div>
                    <div class="col-px-0 col d-none d-xl-block">
                        <nav class="card h-100">
                            <a class="card-link" href="pvc-series.aspx">
                                <div class="card-body">
                                    <img src="images/menu/pvc-wire-menu-white.svg" class="img img-thumbnail tilted" />
                                    <p class="card-text">PVC</p>
                                </div>
                            </a>
                        </nav>
                    </div>
                    <div class="col-px-0 col d-none d-xl-block">
                        <nav class="card h-100">
                            <a class="card-link" href="sleeve-and-tube-series.aspx">
                                <div class="card-body">
                                    <img src="images/menu/tube-menu-white.svg" class="img img-thumbnail" />
                                    <p class="card-text">套管</p>
                                </div>
                            </a>
                        </nav>
                    </div>
                    <div class="col-px-0 col d-none d-xl-block">
                        <nav class="card h-100">
                            <a class="card-link" href="thermocouple-series.aspx">
                                <div class="card-body">
                                    <img src="images/menu/thermocouple-wire-menu-white.svg" class="img img-thumbnail tilted" />
                                    <p class="card-text">補償導線</p>
                                </div>
                            </a>
                        </nav>
                    </div>
                    <div class="col-px-0 col d-none d-xl-block">
                        <nav class="card h-100">
                            <a class="card-link" href="heating-wire-series.aspx">
                                <div class="card-body">
                                    <img src="images/menu/heating-wire-menu-white.svg" class="img img-thumbnail" />
                                    <p class="card-text">發熱線</p>
                                </div>
                            </a>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
        <div class="main-block product-menu">
            <div class="container">
                <div class="title">
                    <span class="h1">產品分類</span>
                </div>
                <div class="subtitle">Product Category</div>
                <div class="content row row-cols-1 row-cols-sm-1 row-cols-md-2 row-cols-lg-3">
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="silicone-fiberglass-series.aspx">
                                <img class="img img-thumbnail" src="/images/product/pro_02.jpg" />
                                <%--<div class="title">
                                    矽膠編織線
                                </div>
                                <div class="subtitle">
                                    Silicone Fiberglass Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="high-temperature-resistance-series.aspx">
                                <img class="img img-thumbnail" src="/images/product/pro_03.jpg" />
                                <%--<div class="title">
                                    高溫線
                                </div>
                                <div class="subtitle">
                                    High Temperature Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="silicone-series.aspx">
                                <img class="img img-thumbnail" src="/images/product/pro_04.jpg" />
                                <%--<div class="title">
                                    矽膠線
                                </div>
                                <div class="subtitle">
                                    Silicone Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="teflon-series.aspx">
                                <img class="img img-thumbnail" src="/images/product/pro_05.jpg" />
                                <%--<div class="title">
                                    鐵氟龍線
                                </div>
                                <div class="subtitle">
                                    Teflon Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="xlpe-series.aspx">
                                <img class="img img-thumbnail" src="/images/product/pro_06.jpg" />
                                <%--<div class="title">
                                    XLPE線
                                </div>
                                <div class="subtitle">
                                    XLPE Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="pvc-series.aspx">
                                <img class="img img-thumbnail" src="/images/product/pro_01.jpg" />
                                <%--<div class="title">
                                    PVC線
                                </div>
                                <div class="subtitle">
                                    PVC Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="sleeve-and-tube-series.aspx">
                                <img class="img img-thumbnail" src="/images/product/pro_07.jpg" />
                                <%--<div class="title">
                                    套管
                                </div>
                                <div class="subtitle">
                                    Tube and Sleeve
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="thermocouple-series.aspx">
                                <img class="img img-thumbnail" src="/images/product/pro_08.jpg" />
                                <%--<div class="title">
                                    補償導線
                                </div>
                                <div class="subtitle">
                                    Thermocouple
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="heating-wire-series.aspx">
                                <img class="img img-thumbnail" src="/images/product/pro_09.jpg" />
                                <%--<div class="title">
                                    發熱線
                                </div>
                                <div class="subtitle">
                                    Heating Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="special-cable.aspx">
                                <img class="img img-thumbnail" src="/images/product/pro_10.jpg" />
                                <%--<div class="title">
                                    發熱線
                                </div>
                                <div class="subtitle">
                                    Heating Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="automotive-wire-series.aspx">
                                <img class="img img-thumbnail" src="/images/product/pro_11.jpg" />
                                <%--<div class="title">
                                    發熱線
                                </div>
                                <div class="subtitle">
                                    Heating Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="military-grade-series.aspx">
                                <img class="img img-thumbnail" src="/images/product/pro_12.jpg" />
                                <%--<div class="title">
                                    發熱線
                                </div>
                                <div class="subtitle">
                                    Heating Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="main-block">
            <div class="container">
                <div class="title">
                    <span class="h1">客製化線材</span>
                </div>
                <div class="subtitle">
                    Customized Cable
                </div>
                <div class="content">
                    <div class="row">
                        <div class="col-md-6 d-none d-md-block image-stack">
                            <div class="stack-top">
                                <img src="images/customize-02.jpg" width="150" class="img img-thumbnail" />
                            </div>
                            <div class="stack-bottom">
                                <img src="images/customize-01.jpg" width="400" class="img img-thumbnail" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <p>專注於您的需求，為您客製專屬的線材，無論您所需要的是規格分析，亦或是材質解析，日進皆可給您最專業的服務</p>
                            <a class="btn btn-dark text-light mt-2 more-button" href="customize_page.aspx">+ More</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="main-block product-menu">
            <div class="container">
                <div class="title">
                    <span class="h1">應用產業</span>
                </div>
                <div class="subtitle">Applied Fields</div>
                <div class="content row row-cols-1 row-cols-sm-1 row-cols-md-2 row-cols-lg-3">
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="car.aspx">
                                <img class="img img-thumbnail" src="/images/service/s1.jpg" />
                                <%--<div class="title">
                                    矽膠編織線
                                </div>
                                <div class="subtitle">
                                    Silicone Fiberglass Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="cloud.aspx">
                                <img class="img img-thumbnail" src="/images/service/s2.jpg" />
                                <%--<div class="title">
                                    高溫線
                                </div>
                                <div class="subtitle">
                                    High Temperature Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="heating.aspx">
                                <img class="img img-thumbnail" src="/images/service/s3.jpg" />
                                <%--<div class="title">
                                    矽膠線
                                </div>
                                <div class="subtitle">
                                    Silicone Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="medical.aspx">
                                <img class="img img-thumbnail" src="/images/service/s4.jpg" />
                                <%--<div class="title">
                                    鐵氟龍線
                                </div>
                                <div class="subtitle">
                                    Teflon Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="led.aspx">
                                <img class="img img-thumbnail" src="/images/service/s5.jpg" />
                                <%--<div class="title">
                                    XLPE線
                                </div>
                                <div class="subtitle">
                                    XLPE Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="temperature-control.aspx">
                                <img class="img img-thumbnail" src="/images/service/s6.jpg" />
                                <%--<div class="title">
                                    PVC線
                                </div>
                                <div class="subtitle">
                                    PVC Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="construction.aspx">
                                <img class="img img-thumbnail" src="/images/service/s7.jpg" />
                                <%--<div class="title">
                                    套管
                                </div>
                                <div class="subtitle">
                                    Tube and Sleeve
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="solar.aspx">
                                <img class="img img-thumbnail" src="/images/service/s8.jpg" />
                                <%--<div class="title">
                                    補償導線
                                </div>
                                <div class="subtitle">
                                    Thermocouple
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="steel.aspx">
                                <img class="img img-thumbnail" src="/images/service/s9.jpg" />
                                <%--<div class="title">
                                    發熱線
                                </div>
                                <div class="subtitle">
                                    Heating Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="roboarm.aspx">
                                <img class="img img-thumbnail" src="/images/service/s10.jpg" />
                                <%--<div class="title">
                                    發熱線
                                </div>
                                <div class="subtitle">
                                    Heating Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                    <div class="col p-1 text-center">
                        <div class="content-wrapper">
                            <a href="misc-app.aspx">
                                <img class="img img-thumbnail" src="/images/service/misc-app.jpg" />
                                <%--<div class="title">
                                    發熱線
                                </div>
                                <div class="subtitle">
                                    Heating Wire
                                </div>--%>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--<div class="main-block">

        </div>--%>
        <div class="main-block news">
            <div class="container">
                <div class="title">
                    <span class="h1">日進動向</span>
                </div>
                <div class="subtitle">
                    Nizing News
                </div>
                <asp:UpdatePanel ID="upNews" runat="server">
                    <Triggers>
                    </Triggers>
                    <ContentTemplate>
                        <div id="newsContent" runat="server" class="content">
                            <!--dynamic news content-->
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div>
                    <a class="btn btn-dark text-light mt-2 more-button" href="news.aspx">+ More
                    </a>
                </div>
            </div>
        </div>
        <%--<div class="main-block">
            <div class="container">
                <div class="title">
                    聯繫我們
                </div>
                <div class="subtitle">
                    Contact Us
                </div>
                <div class="content">
                    <div class="row row-cols-1 row-cols-md-2">
                        <div class="col">
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item">
                                    <a class="card-link"
                                        href="https://www.google.com/maps/place/%E6%97%A5%E9%80%B2%E9%9B%BB%E7%B7%9A%E8%82%A1%E4%BB%BD%E6%9C%89%E9%99%90%E5%85%AC%E5%8F%B8/@25.0587124,121.4718232,17z/data=!4m12!1m6!3m5!1s0x3442a7e768a1d123:0x1b3b1220987a8188!2z5pel6YCy6Zu757ea6IKh5Lu95pyJ6ZmQ5YWs5Y-4!8m2!3d25.0587076!4d121.4740119!3m4!1s0x3442a7e768a1d123:0x1b3b1220987a8188!8m2!3d25.0587076!4d121.4740119">地址: 新北市三重區光復路二段87巷10-12號</a>
                                </li>
                                <li class="list-group-item">
                                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3614.2819554612033!2d121.47185441457191!3d25.058430943466583!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3442a8edf0d7f197%3A0xe1699fcd3243f5be!2zMjQx5paw5YyX5biC5LiJ6YeN5Y2A5YWJ5b6p6Lev5LqM5q61ODflt7cxMC0xMuiZnw!5e0!3m2!1szh-TW!2stw!4v1528095172293" width="400" height="300" frameborder="0" style="border:0"></iframe>
                                </li>
                                <li class="list-group-item">
                                    <a class="card-link"
                                        href="tel:+886229999181">電話: 02-2999-9181
                                    </a>
                                </li>
                                <li class="list-group-item">
                                    <a class="card-link">傳真: 02-2999-9771</a>
                                </li>
                                <li class="list-group-item" style="font-size: xx-large">
                                    <a class="card-link img"
                                        href="https://www.facebook.com/NIZING.ELECTRIC/">
                                        <i class="fab fa-facebook-square"></i>
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <div class="col message-board">
                            <div class="title">
                                留言給我們
                            </div>
                            <div class="form-group">
                                <label for="txtInquiryName">姓名</label>
                                <asp:TextBox ID="txtInquiryName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtInquiryEmail">Email</label>
                                <asp:TextBox ID="txtInquiryEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtInquirySubject">主旨</label>
                                <asp:TextBox ID="txtInquirySubject" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtInquiryContent">內容</label>
                                <asp:TextBox ID="txtInquiryContent" runat="server" Height="200"
                                    CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnSumbitInquiry" runat="server" Text="送出" CssClass="btn btn-dark" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>
        <div class="associate-partner">
            <div class="">
                <%--                <div class="title text-center text-black-50 mb-4">
                    企業客戶
                </div>--%>
                <div class="slider">
                    <div class="">
                        <img src="/images/logo/aidc-logo.svg" />
                    </div>
                    <div class="">
                        <img src="/images/logo/corning-logo.svg" />
                    </div>
                    <div class="">
                        <img src="/images/logo/cpc-logo.svg" />
                    </div>
                    <div class="">
                        <img src="/images/logo/csc-logo.svg" />
                    </div>
                    <div class="">
                        <img src="/images/logo/delta-logo.svg" />
                    </div>
                    <div class="">
                        <img src="/images/logo/fpg-logo.svg" />
                    </div>
                    <div class="">
                        <img src="/images/logo/itri-logo.svg" />
                    </div>
                    <div class="">
                        <img src="/images/logo/nypg-logo.svg" />
                    </div>
                    <div class="">
                        <img src="/images/logo/osram-logo.svg" />
                    </div>
                    <div class="">
                        <img src="/images/logo/tatung-logo.svg" />
                    </div>
                    <div class="">
                        <img src="/images/logo/tsmc-logo.svg" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:UpdatePanel ID="upNewsModal" runat="server">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <div class="modal fade" id="newsModal" tabindex="-1" data-backdrop="static" aria-labelledby="newsContent" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <asp:Label ID="newsModalTitle" runat="server" CssClass="modal-title h5" Text="Label"></asp:Label>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div id="newsModalBody" runat="server" class="modal-body">
                            <asp:Label ID="newsModalContent" runat="server" Text="Label"></asp:Label>
                            <a id="newsModalLink" runat="server" class="text-info" target="_blank"></a>
                            <div class="text-right text-muted">
                                <asp:Label ID="newsModalDate" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div id="newsModalImageSection" runat="server">
                            </div>
                        </div>
                        <%--<div class="modal-footer">
                        </div>--%>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
