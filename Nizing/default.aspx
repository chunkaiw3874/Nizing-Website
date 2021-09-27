<<<<<<< HEAD
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<%@ OutputCache Duration="600" VaryByParam="None" %>
=======
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/indexMaster2021.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>高品質電線電纜製造-日進電線-國際安規認證通過</title>
    <meta name="keywords" content="電線,電纜,電線電纜,矽膠電線,鐵氟龍電線,照射電線,發熱電線,PVC電線,PE電線,PU電線,補償導線,耐高溫電線,耐高溫電纜,耐高壓電線,耐高壓電纜,UL電線,矽膠編織電線,軍規線,汽車花線" />
    <meta name="description" content="日進電線為國內一流電線及電纜製造商，專門製造特殊材質及用途電線及電纜，如耐高溫的矽膠電線、矽膠編織電線，抗酸鹼的聚合氟化線電線，抗UV的照射電線等，旗下電線電纜產品眾多，歡迎聯繫洽詢" />
<<<<<<< HEAD
    <link rel="stylesheet" type="text/css" href="/Content/slick/slick.css" />
    <link href="/Content/slick/slick-theme.css" rel="stylesheet" />
    <script type="text/javascript" src="/Content/slick/slick.min.js"></script>
    <style style="text/css">
        .overlay-parent {
            min-height: 100%;
            margin: 0px;
        }

        /*首頁不顯示breadcrumb*/
        .breadcrumb {
            display: none;
        }

        .display-block {
            margin-bottom: 8px;
        }



        .webp .product-category-list.bg-wrapper {
            background-image: url('/images/background/bg-product.webp');
        }

        .no-webp .product-category-list.bg-wrapper {
            background-image: url('/images/background/bg-product.png');
        }

        .display-block:first-child {
            padding-top: 24px !important;
        }

        .display-block .list-group-item {
            background-color: inherit;
            border: none;
        }


        .webp .news.bg-wrapper {
            background-image: url('/images/background/bg-news.webp');
        }

        .no-webp .news.bg-wrapper {
            background-image: url('/images/background/bg-news.jpg');
        }

        .news .title,
        .news .subtitle {
            color: white;
        }

        .news .card {
            border-bottom: solid 1px #ffffff;
            border-radius: 0;
            color: white !important;
        }

        .news .overlay {
            padding-top: 0px;
        }

        .news .card-img {
            width: 300px;
            border-radius: 0;
        }

        .news .content .news-date {
            display: flex;
            justify-content: flex-end;
        }

        .associate-partner {
            margin: -8px 0;
        }

            .associate-partner img {
                width: 50px;
            }

        /*modal*/
        #newsModal img {
            max-height: 500px;
            width: 100%;
            padding-bottom: 20px;
        }

        #promotionModal .modal-dialog {
            max-width: 750px !important;
        }

        #promotionModal .close {
            position: absolute;
            top: 5px;
            right: 5px;
            color: white;
        }

        /*slick slide css*/
        /*vertical center*/
        .associate-partner .slick-initialized .slick-track {
            display: flex;
            align-items: center;
        }

        .slick-prev:before,
        .slick-next:before {
            color: #585858;
        }

        @media all and (min-width: 768px) {
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
                autoplaySpeed: 0,
                speed: 5000,
                centerMode: false,
                cssEase: 'linear',
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

            });

            //$('#promotionModal').modal('show');
        });

        $(window).resize(function () {
            $('.associate-partner .slider').not('.slick-initialized').slick('resize');
        });

        $(window).on('orientationchange', function () {
            $('.associate-partner .slider').not('.slick-initialized').slick('resize');
        });
    </script>

    <!-- 由 Google 結構化資料標記協助工具產生的 JSON-LD 標記。 -->
    <script type="application/ld+json">
{
  "@context" : "http://schema.org",
  "@type" : "Product",
  "name" : "Wire and Cable",
  "image" : [ "http://www.nizing.com.tw/images/banner/banner-homepage-cn-1300x500.gif", "http://www.nizing.com.tw/images/product/high-temperature-wire/high-temperature-wire_menu-500x500.png", "http://www.nizing.com.tw/images/product/silicone-wire/silicone-wire_menu-500x500.png", "http://www.nizing.com.tw/images/product/teflon-wire/teflon-wire_menu-500x500.png", "http://www.nizing.com.tw/images/product/xlpe-wire/xlpe-wire_menu-500x500.png", "http://www.nizing.com.tw/images/product/pvc-wire/pvc-wire_menu-500x500.png", "http://www.nizing.com.tw/images/product/tube/tube_menu-500x500.png", "http://www.nizing.com.tw/images/product/thermocouple/thermocouple_menu-500x500.png", "http://www.nizing.com.tw/images/product/heating-wire/heating-wire_menu-500x500.png", "http://www.nizing.com.tw/images/product/composite-cable/special-cable_menu-500x500.png" ],
  "url" : "http://www.nizing.com.tw/default.aspx",
  "brand" : {
    "@type" : "Brand",
    "name" : "NIZING"
  },
        "aggregateRating":{
        "@type": "AggregateRating",
        "ratingValue": "(Number from 0 to 5)",
        "reviewCount": "500"
        }
}
    </script>


    <%--/*scrollmagic*/--%>
    <%--/*permanent reveal on scroll*/--%>
    <style type="text/css">
        .reveal {
            opacity: 0;
            /*-webkit-transform: rotate(40deg) scale(0.5);
            -moz-transform: rotate(40deg) scale(0.5);
            -ms-transform: rotate(40deg) scale(0.5);
            -o-transform: rotate(40deg) scale(0.5);
            transform: rotate(40deg) scale(0.5);
            -webkit-transition: all 0.8s ease-in-out;
            -moz-transition: all 0.8s ease-in-out;
            -ms-transition: all 0.8s ease-in-out;
            -o-transition: all 0.8s ease-in-out;
            transition: all 0.8s ease-in-out;*/
        }

            .reveal.animate__bounce {
                opacity: 1;
                /*-webkit-transform: none;
                -moz-transform: none;
                -ms-transform: none;
                -o-transform: none;
                transform: none;*/
            }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {

            var controller = new ScrollMagic.Controller();

            new ScrollMagic.Scene({
                triggerElement: ".reveal",
                triggerHook: 0.9, // show, when scrolled 10% into view
                offset: -50, // move trigger
                reverse: false // only do once
                //duration: "80%", // hide 10% before exiting view (80% + 10% from bottom)
            })
                .setClassToggle(".reveal", "animate__bounce") // add class toggle
                .addTo(controller);
        })
=======
    <style>
        .display-block:first-child {
            padding-top: 48px !important;
        }

        .banner .img {
            width: 100%;
            object-fit: contain;
        }

        .product-category .img {
            width: 100%;
        }

        .product-category .shadow {
            box-shadow: 15px 15px 15px 0 rgba(0, 0, 0, 0.5) !important;
        }

        .news-display-image .img {
            width: 100%;
            height: 100%;
            max-height: 500px !important;
            object-fit: cover;
        }

        .news-list {
            max-height: 500px !important;
        }

        .news .block-content .news-list .img {
            height: 100%;
            max-height: 160px !important;
            object-fit: cover;
        }

        .news .news-list-item {
            margin-bottom: 10px;
        }

            .news .news-list-item:last-child {
                margin-bottom: 0px;
            }

        .news .img {
            box-shadow: 10px 10px 10px 0 rgba(0, 0, 0, 0.5);
        }

        .associates img {
            width: 100px;
        }
        /*slick slide vertical center*/
        .slick-initialized .slick-track {
            display: flex;
            align-items: center;
        }

        /*test style*/
        /*上拉式資訊 on hover*/
        .pull-up-slide .img {
            display: block;
        }

        .pull-up-slide:hover .info {
            height: 100%;
            background-color: #00fff7;
            opacity: 0.8;
            color: black;
        }

        .info {
            mix-blend-mode: luminosity;
            position: absolute;
            padding: 50px 35px;
            bottom: 0;
            left: 0;
            right: 0;
            height: 0;
            overflow: hidden;
            transition: all .5s ease;
        }

            .info .title {
                text-align: center;
                padding: 10px;
                font-size: 20px;
                border-bottom: solid 1px #ffffff;
            }

            .info .text {
                padding-top: 10px;
                font-size: 14px;
                text-align: left;
            }
    </style>
    <script type="text/javascript">
        //for onmouseover image swap
        function SwapImage(e) {
            e = e || window.event;
            var link = e.target || e.srcElement;
            document.getElementById("body_NewsDisplayImage").src = link.src;
        }

        $(document).ready(function () {
            $('.associates .slider').slick({
                mobileFirst: true,
                arrows: false,
                slidesToShow: 7,
                slidesToScroll: 1,
                autoplay: true,
                autoplaySpeed: 1000,
                centerMode: true
            })
        });

        $(window).resize(function () {
            $('.associates .slider').not('.slick-initialized').slick('resize');
        });

        $(window).on('orientationchange', function () {
            $('.associates .slider').not('.slick-initialized').slick('resize');
        });
>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
    </script>

    <style>
    </style>
</asp:Content>
<<<<<<< HEAD
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-homepage-cn-1300x500.gif" alt="日進電線電纜 Nizing Electric Wire and Cable" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="display-block-wrapper homepage">
            <section class="display-block hottest-item-list">
                <div class="container">
                    <h2 class="title">熱門精品區
                    </h2>
                    <h2 class="subtitle">HOTTEST BOUTIQUE SECTION
                    </h2>
                    <div class="content row row-cols-2 row-cols-md-3">
                        <div class="col">
                            <div class="hottest-item">
                                <a href="/zh/product/heating-wire/MEDICAL-RESPIRATION-PIPE-HEATING-WIRE">
                                    <div class="image-section">
                                        <picture>
                                            <source srcset="/images/product/hot-item/medical-repiration-tube.webp" type="image/webp">
                                            <img src="/images/product/hot-item/medical-repiration-tube.jpg"
                                                alt="醫療用呼吸加熱管 Medical Respiration Tube">
                                        </picture>
                                    </div>
                                </a>
                                <div class="text-section">
                                    <div class="title text-left">醫療用呼吸加熱管</div>
                                    <div class="subtitle text-left">HFNC高含氧人工呼吸器耗材</div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="hottest-item">
                                <a href="">
                                    <div class="image-section">
                                        <picture>
                                            <source srcset="/images/product/hot-item/inflammable-signal-cable.webp" type="image/webp">
                                            <img src="/images/product/hot-item/inflammable-signal-cable.jpg"
                                                alt="防火耐燃訊號線 Inflammable Signal Cable">
                                        </picture>
                                    </div>
                                </a>
                                <div class="text-section">
                                    <div class="title text-left">防火耐燃訊號線</div>
                                    <div class="subtitle text-left">iPhone-Type C快速充電線</div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="hottest-item">
                                <a href="">
                                    <div class="image-section">
                                        <picture>
                                            <source srcset="/images/product/hot-item/high-density-deep-sea-cable.webp" type="image/webp">
                                            <img src="/images/product/hot-item/high-density-deep-sea-cable.jpg"
                                                alt="水下不鏽鋼鎧裝海底網路通訊線 High Density Deep Sea Cable">
                                        </picture>
                                    </div>
                                </a>
                                <div class="text-section">
                                    <div class="title text-left">高硬度防鼠咬CAT5E/CAT6A</div>
                                    <div class="subtitle text-left">水下不鏽鋼鎧裝海底網路通訊線</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section class="display-block newest-item-list">
                <div class="container">
                    <h2 class="title">最新產品
                    </h2>
                    <h2 class="subtitle">Newest Product
                    </h2>
                    <div class="content row row-cols-2 row-cols-md-4">
                        <div class="col">
                            <div class="newest-item">
                                <a href="">
                                    <div class="image-section">
                                        <picture>
                                            <source srcset="/images/product/new-item/fighter-jet-temperature-control-cable.webp" type="image/webp">
                                            <img src="/images/product/new-item/fighter-jet-temperature-control-cable.jpg"
                                                alt="戰鬥機溫控線 Fighter Jet Temperature Control Cable">
                                        </picture>
                                    </div>
                                </a>
                                <div class="text-section">
                                    <div class="title text-left">戰鬥機溫控線</div>
                                    <div class="subtitle text-left">日本軍規配線</div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="newest-item">
                                <a href="">
                                    <div class="image-section">
                                        <picture>
                                            <source srcset="https://via.placeholder.com/350x250?text=&nbsp" type="image/webp">
                                            <img src="https://via.placeholder.com/350x250?text=&nbsp"
                                                alt="高鐵/捷運光纖電纜 Optic Fiber Cable for High Speed Rail and Massive Transit System">
                                        </picture>
                                    </div>
                                </a>
                                <div class="text-section">
                                    <div class="title text-left">高鐵/捷運光纖電纜</div>
                                    <div class="subtitle text-left">通訊配線</div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="newest-item">
                                <a href="">
                                    <div class="image-section">
                                        <picture>
                                            <source srcset="https://via.placeholder.com/350x250?text=&nbsp" type="image/webp">
                                            <img src="https://via.placeholder.com/350x250?text=&nbsp"
                                                alt="飛彈控制軍規線 Missile Control Cable">
                                        </picture>
                                    </div>
                                </a>
                                <div class="text-section">
                                    <div class="title text-left">飛彈控制軍規線</div>
                                    <div class="subtitle text-left">軍規船用電纜</div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="newest-item">
                                <a href="">
                                    <div class="image-section">
                                        <picture>
                                            <source srcset="https://via.placeholder.com/350x250?text=&nbsp" type="image/webp">
                                            <img src="https://via.placeholder.com/350x250?text=&nbsp"
                                                alt="CR認證潛艦電纜 CR Certified Submarine Cable">
                                        </picture>
                                    </div>
                                </a>
                                <div class="text-section">
                                    <div class="title text-left">潛艦國造-CR認證</div>
                                    <div class="subtitle text-left">軍規船舶複合電纜</div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="newest-item">
                                <a href="">
                                    <div class="image-section">
                                        <picture>
                                            <source srcset="https://via.placeholder.com/350x250?text=&nbsp" type="image/webp">
                                            <img src="https://via.placeholder.com/350x250?text=&nbsp"
                                                alt="飛彈發射器 Missle Launcher Control Cable">
                                        </picture>
                                    </div>
                                </a>
                                <div class="text-section">
                                    <div class="title text-left">MIL 飛彈發射器</div>
                                    <div class="subtitle text-left">軍規高頻傳輸控制複合電纜</div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="newest-item">
                                <a href="/zh/application/automobile/motor-temperature-sensor-cable-tesla-taycan">
                                    <div class="image-section">
                                        <picture>
                                            <source srcset="/images/product/new-item/cable-electric-car.webp" type="image/webp">
                                            <img src="/images/product/new-item/cable-electric-car.jpg"
                                                alt="IATF-16949 馬達溫度感知線 Motor Temperature Sensor Cable">
                                        </picture>
                                    </div>
                                </a>
                                <div class="text-section">
                                    <div class="title text-left">電動車用-Tesla/Porsche Taycan</div>
                                    <div class="subtitle text-left">IATF-16949 馬達溫度感知線</div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="newest-item">
                                <a href="/zh/application/automobile/motor-power-cable">
                                    <div class="image-section">
                                        <picture>
                                            <source srcset="/images/product/new-item/cable-electric-motorcycle.webp" type="image/webp">
                                            <img src="/images/product/new-item/cable-electric-motorcycle.jpg"
                                                alt="電源供應器 電動馬達動力線 Power Cable Motor Cable">
                                        </picture>
                                    </div>
                                </a>
                                <div class="text-section">
                                    <div class="title text-left">電動機車-GOGORO</div>
                                    <div class="subtitle text-left">電源供應器 & 電動馬達動力線</div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="newest-item">
                                <a href="">
                                    <div class="image-section">
                                        <picture>
                                            <source srcset="/images/product/new-item/industrial-furnace.webp" type="image/webp">
                                            <img src="/images/product/new-item/industrial-furnace.jpg"
                                                alt="多爐溫控系統雙層屏蔽線 Temper Control Signal Shielding Cable">
                                        </picture>
                                    </div>
                                </a>
                                <div class="text-section">
                                    <div class="title text-left">大型高溫爐</div>
                                    <div class="subtitle text-left">多爐溫控系統雙層屏蔽線</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section class="display-block product-category-list bg-wrapper">
                <div class="container">
                    <h2 class="title revealTrigger">產品分類
                    </h2>
                    <h2 class="subtitle">PRODUCT
                    </h2>
                    <div id="divProductItemList" runat="server" class="content row row-cols-2 row-cols-sm-2 row-cols-md-3 row-cols-lg-4">
                        <div class="col reveal animate__animated">
                            <figure class="product-category-item move">
                                <a href="/zh/product/silicone-fiberglass-wire">
                                    <div class="image-section">
                                        <picture>
                                            <source srcset="/images/home/inflammable/big-menu.webp" type="image/webp">
                                            <img src="/images/home/inflammable/big-menu.png"
                                                alt="防火耐燃線 Anti-Flammatory Wire and Cable">
                                        </picture>
                                    </div>
                                </a>
                                <div class="text-section">
                                    <figcaption class="title my-auto">防火耐燃系列
                                    </figcaption>
                                </div>
                            </figure>
                        </div>
                    </div>
                </div>
            </section>
            <section class="display-block news bg-wrapper">
                <div class="container">
                    <h2 class="title">最新消息
                    </h2>
                    <h2 class="subtitle">LATEST NEWS
                    </h2>
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
            </section>
            <section class="display-block">
                <div class="associate-partner">
                    <figure class="slider m-0">
                        <img src="/images/logo/aidc-logo.svg" class="mx-auto" />
                        <img src="/images/logo/corning-logo.svg" class="mx-auto" />
                        <img src="/images/logo/cpc-logo.svg" class="mx-auto" />
                        <img src="/images/logo/csc-logo.svg" class="mx-auto" />
                        <img src="/images/logo/delta-logo.svg" class="mx-auto" />
                        <img src="/images/logo/fpg-logo.svg" class="mx-auto" />
                        <img src="/images/logo/itri-logo.svg" class="mx-auto" />
                        <img src="/images/logo/nypg-logo.svg" class="mx-auto" />
                        <img src="/images/logo/osram-logo.svg" class="mx-auto" />
                        <img src="/images/logo/tatung-logo.svg" class="mx-auto" />
                        <img src="/images/logo/tsmc-logo.svg" class="mx-auto" />
                    </figure>
                </div>
            </section>
        </div>
    </div>

=======
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid p-0">
        <div class="banner">
            <img src="images/banner/banner-homepage-cn-1300x600.gif" class="w-100 img" />
        </div>
        <div>
            <div class="display-block">
                <div class="container product-category">
                    <div class="block header">
                        <div class="block title h1">產品資訊</div>
                        <div class="block subtitle h3">PRODUCT</div>
                    </div>
                    <div class="block content row row-cols-4">
                        <%--Pull up slide test block --%>
                        <%--<div class="col px-4 py-2">
                            <div class="" style="position: absolute;">
                                <a class="link" href="silicone-fiberglass-series.aspx">
                                    <div class="shadow pull-up-slide">
                                        <img src="images/product_pic/silicone-fiberglass-wire/silicone-fiberglass-wire_menu-500x500.png" class="w-100 img card-img-top" />
                                        <div class="info">
                                            <div class="title">
                                                矽膠編織線系列
                                            </div>
                                            <div class="text">
                                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent neque quam, volutpat ac massa non, convallis fermentum mauris. Ut consectetur nulla quis blandit placerat
                                            </div>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col px-4 py-2">
                            <div class="" style="position: absolute;">
                                <a class="link" href="silicone-fiberglass-series.aspx">
                                    <div class="shadow pull-up-slide">
                                        <img src="images/product_pic/high-temperature-wire/high-temperature-wire_menu-500x500.png" class="w-100 img card-img-top" />
                                        <div class="info">
                                            <div class="title">
                                                高溫線系列
                                            </div>
                                            <div class="text">
                                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent neque quam, volutpat ac massa non, convallis fermentum mauris. Ut consectetur nulla quis blandit placerat
                                            </div>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </div>--%>
                        <div class="col px-4 py-2">
                            <div class="move">
                                <a class="link" href="silicone-fiberglass-series.aspx">
                                    <div class="shadow">
                                        <img src="images/product_pic/silicone-fiberglass-wire/silicone-fiberglass-wire_menu-500x500.png" class="w-100 img card-img-top" />
                                    </div>
                                    <div class="card-body text-center h5 mt-2">
                                        矽膠編織線系列
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col px-4 py-2">
                            <div class="move">
                                <a class="link" href="high-temperature-resistance-series.aspx">
                                    <div class="shadow">
                                        <img src="images/product_pic/high-temperature-wire/high-temperature-wire_menu-500x500.png" class="w-100 img card-img-top" />
                                    </div>
                                    <div class="card-body text-center h5 mt-2">
                                        高溫線系列
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col px-4 py-2">
                            <div class="move">
                                <a class="link" href="silicone-series.aspx">
                                    <div class="shadow">
                                        <img src="images/product_pic/silicone-wire/silicone-wire_menu-500x500.png" class="w-100 img card-img-top" />
                                    </div>
                                    <div class="card-body text-center h5 mt-2">
                                        矽膠線系列
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col px-4 py-2">
                            <div class="move">
                                <a class="link" href="teflon-series.aspx">
                                    <div class="shadow">
                                        <img src="images/product_pic/teflon-wire/teflon-wire_menu-500x500.png" class="w-100 img card-img-top" />
                                    </div>
                                    <div class="card-body text-center h5 mt-2">
                                        鐵氟龍線系列
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col px-4 py-2">
                            <div class="move">
                                <a class="link" href="pvc-series.aspx">
                                    <div class="shadow">
                                        <img src="images/product_pic/pvc-wire/pvc-wire_menu-500x500.png" class="w-100 img card-img-top" />
                                    </div>
                                    <div class="card-body text-center h5 mt-2">
                                        PVC線系列
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col px-4 py-2">
                            <div class="move">
                                <a class="link" href="sleeve-and-tube-series.aspx">
                                    <div class="shadow">
                                        <img src="images/product_pic/tube/tube_menu-500x500.png" class="w-100 img card-img-top" />
                                    </div>
                                    <div class="card-body text-center h5 mt-2">
                                        套管系列
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col px-4 py-2">
                            <div class="move">
                                <a class="link" href="thermocouple-series.aspx">
                                    <div class="shadow">
                                        <img src="images/product_pic/thermocouple/thermocouple_menu-500x500.png" class="w-100 img card-img-top" />
                                    </div>
                                    <div class="card-body text-center h5 mt-2">
                                        補償導線系列
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col px-4 py-2">
                            <div class="move">
                                <a class="link" href="heating-wire-series.aspx">
                                    <div class="shadow">
                                        <img src="images/product_pic/heating-wire/heating-wire_menu-500x500.png" class="w-100 img card-img-top" />
                                    </div>
                                    <div class="card-body text-center h5 mt-2">
                                        發熱線系列
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col px-4 py-2">
                            <div class="move">
                                <a class="link" href="xlpe-series.aspx">
                                    <div class="shadow">
                                        <img src="images/product_pic/xlpe-wire/xlpe-wire_menu-500x500.png" class="w-100 img card-img-top" />
                                    </div>
                                    <div class="card-body text-center h5 mt-2">
                                        交聯照射線系列
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col px-4 py-2">
                            <div class="move">
                                <a class="link" href="special-cable.aspx">
                                    <div class="shadow">
                                        <img src="images/product_pic/special-cable/special-cable_menu-500x500.png" class="w-100 img card-img-top" />
                                    </div>
                                    <div class="card-body text-center h5 mt-2">
                                        特殊線系列
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="display-block">
                <div class="container news">
                    <div class="block header">
                        <div class="block title h1">最新消息</div>
                        <div class="block subtitle h3">NIZING NEWS</div>
                    </div>
                    <div class="block content">
                        <div class="row row-cols-2">
                            <div class="col news-display-image">
                                <img id="NewsDisplayImage" runat="server" class="img" />
                            </div>
                            <asp:UpdatePanel ID="upNews" runat="server">
                                <Triggers>
                                </Triggers>
                                <ContentTemplate>
                                    <div class="col h-100">
                                        <div id="newsContent" runat="server" class="news-list h-100 d-flex flex-column justify-content-between">
                                            <!--dynamic news content-->
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <div class="display-block">
                <div class="associates">
                    <div class="block header">
                        <div class="block title h1">合作企業</div>
                        <div class="block subtitle h3">ASSOCIATES</div>
                    </div>
                    <div class="slider block content">
                        <div class="">
                            <img src="images/logo/aidc-logo.svg" />
                        </div>
                        <div class="">
                            <img src="images/logo/corning-logo.svg" />
                        </div>
                        <div class="">
                            <img src="images/logo/cpc-logo.svg" />
                        </div>
                        <div class="">
                            <img src="images/logo/csc-logo.svg" />
                        </div>
                        <div class="">
                            <img src="images/logo/delta-logo.svg" />
                        </div>
                        <div class="">
                            <img src="images/logo/fpg-logo.svg" />
                        </div>
                        <div class="">
                            <img src="images/logo/itri-logo.svg" />
                        </div>
                        <div class="">
                            <img src="images/logo/nypg-logo.svg" />
                        </div>
                        <div class="">
                            <img src="images/logo/osram-logo.svg" />
                        </div>
                        <div class="">
                            <img src="images/logo/tatung-logo.svg" />
                        </div>
                        <div class="">
                            <img src="images/logo/tsmc-logo.svg" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Modal-->
>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
    <asp:UpdatePanel ID="upNewsModal" runat="server">
        <Triggers>
        </Triggers>
        <ContentTemplate>
<<<<<<< HEAD
            <div class="modal fade" id="newsModal" tabindex="-1" aria-labelledby="newsContent" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <asp:Label ID="newsModalTitle" runat="server" CssClass="modal-title h5" Text="Label"></asp:Label>
=======
            <div class="modal fade" id="newsModal" tabindex="-1" data-backdrop="static" aria-labelledby="newsContent" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <asp:Label ID="newsModalTitle" runat="server" CssClass="modal-title h5" Text=""></asp:Label>
>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
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
<<<<<<< HEAD
                        <%--<div class="modal-footer">
                        </div>--%>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="upPromotionModal" runat="server">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <div class="modal fade" id="promotionModal" tabindex="-1" aria-labelledby="promotionContent" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <a href="/zh/product/heating-wire/MEDICAL-RESPIRATION-PIPE-HEATING-WIRE">
                                <img src="/images/promotion/醫療用 呼吸加熱管.jpg" />
                            </a>
                        </div>
=======
>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
