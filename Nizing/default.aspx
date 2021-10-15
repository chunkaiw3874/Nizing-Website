<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<%@ OutputCache Duration="600" VaryByParam="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>高品質電線電纜製造-日進電線-國際安規認證通過</title>
    <meta name="keywords" content="電線,電纜,電線電纜,矽膠電線,鐵氟龍電線,照射電線,發熱電線,PVC電線,PE電線,PU電線,補償導線,耐高溫電線,耐高溫電纜,耐高壓電線,耐高壓電纜,UL電線,矽膠編織電線,軍規線,汽車花線" />
    <meta name="description" content="日進電線為國內一流電線及電纜製造商，專門製造特殊材質及用途電線及電纜，如耐高溫的矽膠電線、矽膠編織電線，抗酸鹼的聚合氟化線電線，抗UV的照射電線等，旗下電線電纜產品眾多，歡迎聯繫洽詢" />
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

        .banner .banner-text {
            color: white;
            font-size: 36px;
            text-shadow: 1px 1px 3px black,3px 3px 9px black;
        }

            .banner .banner-text p {
                margin: 0;
            }

            .banner .banner-text .top-left {
                position: absolute;
                top: 70px;
                left: 60px;
            }

                .banner .banner-text .top-left p {
                    line-height: 1.1;
                }

                    .banner .banner-text .top-left p:nth-child(2) {
                        padding-left: 20px;
                    }

            .banner .banner-text .bottom-right {
                position: absolute;
                bottom: 100px;
                right: 200px;
            }

                .banner .banner-text .bottom-right p {
                    line-height: 2;
                }

                    .banner .banner-text .bottom-right p:not(:first-child) {
                        line-height: 0.5;
                    }

                .banner .banner-text .bottom-right .small-text {
                    transform: scale(0.4);
                    -webkit-transform-origin-x: 0;
                }

        @media all and (max-width:1399px) {
            .banner .banner-text {
                color: white;
                font-size: 30px;
            }

                .banner .banner-text .bottom-right .small-text {
                    transform: scale(0.4);
                    -webkit-transform-origin-x: 0;
                }
        }

        @media all and (max-width:1199px) {
            .banner .banner-text {
                color: white;
                font-size: 26px;
            }

                .banner .banner-text .bottom-right .small-text {
                    transform: scale(0.4);
                    -webkit-transform-origin-x: 0;
                }

                .banner .banner-text .bottom-right {
                    /*margin-right: -350px;*/
                bottom: 100px;
                right: 200px;
                }
        }

        @media all and (max-width:991px) {
            .banner .banner-text {
                color: white;
                font-size: 20px;
            }

                .banner .banner-text .bottom-right .small-text {
                    transform: scale(0.4);
                    -webkit-transform-origin-x: 0;
                }

                .banner .banner-text .bottom-right {
                bottom: 50px;
                right: 150px;
                }
        }

        @media all and (max-width:767px) {
            .banner .banner-text {
                color: white;
                font-size: 16px;
            }

                .banner .banner-text .bottom-right .small-text {
                    transform: scale(0.4);
                    -webkit-transform-origin-x: 0;
                }

                .banner .banner-text .bottom-right {
                bottom: 50px;
                right: 20px;
                }
        }

        @media all and (max-width:575px) {
            .banner .banner-text .top-left {
                position: absolute;
                top: 30px;
                left: 20px;
            }

            .banner .banner-text {
                color: white;
                font-size: 14px;
            }

                .banner .banner-text .bottom-right .small-text {
                    transform: scale(0.3);
                    -webkit-transform-origin-x: 0;
                }

                .banner .banner-text .bottom-right {
                    bottom: 20px;
                    right:20px;
                }
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
  "image" : [ "http://www.nizing.com.tw/images/banner/banner-home.jpg"],
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
    </script>

    <style>
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    <div class="container-fluid">
        <div class="banner">
            <picture>
                <source srcset="/images/banner/banner-home-mobile.webp" media="(max-width:767px)" type="image/webp" />
                <source srcset="/images/banner/banner-home.webp" type="image/webp" />
                <source srcset="/images/banner/banner-home-mobile.jpg" media="(max-width:767px)" />
                <img src="/images/banner/banner-home.jpg" alt="日進電線電纜 Nizing Electric Wire and Cable" />
            </picture>
            <div class="banner-text">
                <div class="top-left">
                    <p>
                        為您客製品質優異、耐熱、耐電壓、
                    </p>
                    <p>
                        抗老化，安全時尚的電線電纜供應商
                    </p>
                </div>
                <div class="bottom-right">
                    <p>專業電線電纜製造商</p>
<%--                    <p class="small-text">GB/T 19001-2015; ISO: 9001-2015 Certified No. 00610 Q20229RIM</p>
                    <p class="small-text">UL / CSA / VDE / PSE / CCC / CE / RoHs, REACH, MIT Certified</p>--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="display-block-wrapper homepage">
            <section class="display-block hottest-item-list">
                <div class="container">
                    <h2 class="title">熱門電線精品區
                    </h2>
                    <h2 class="subtitle">HOTTEST WIRE AND CABLE
                    </h2>
                    <div class="content row row-cols-2 row-cols-md-3">
                        <div class="col">
                            <div class="hottest-item">
                                <a href="/zh/product/heating-wire/medical-respiration-pipe-heating-wire">
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
                                <a href="/zh/application/cloud-system/inflammable-signal-cable">
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
                                    <div class="subtitle text-left">iPhone-Type C 快速充電線</div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="hottest-item">
                                <a href="/zh/application/cloud-system/deep-sea-stainless-steel-armored-internet-cable">
                                    <div class="image-section">
                                        <picture>
                                            <source srcset="/images/application/products/deep-sea-stainless-steel-armored-internet-cable/menu/deep-sea-stainless-steel-armored-internet-cable.webp" type="image/webp">
                                            <img src="/images/application/products/deep-sea-stainless-steel-armored-internet-cable/menu/deep-sea-stainless-steel-armored-internet-cable.jpg"
                                                alt="水下不鏽鋼鎧裝海底網路通訊線 Deep Sea Stainless Steel Armored Internet Cable">
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
                    <h2 class="subtitle">Latest Product
                    </h2>
                    <div class="content row row-cols-2 row-cols-md-4">
                        <div class="col">
                            <div class="newest-item">
                                <a href="/zh/application/misc-app/fighter-jet-temperature-sensor-cable">
                                    <div class="image-section">
                                        <picture>
                                            <source srcset="/images/application/products/fighter-jet-temperature-sensor-cable/menu/fighter-jet-temperature-sensor-cable.webp" type="image/webp">
                                            <img src="/images/application/products/fighter-jet-temperature-sensor-cable/menu/fighter-jet-temperature-sensor-cable.jpg"
                                                alt="戰鬥機溫控電纜 Fighter Jet Temperature Control Cable">
                                        </picture>
                                    </div>
                                </a>
                                <div class="text-section">
                                    <div class="title text-left">戰鬥機溫控電纜</div>
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
                                <a href="/zh/application/medical/electrosurgical-unit-cable">
                                    <div class="image-section">
                                        <picture>
                                            <source srcset="/images/application/products/electrosurgical-unit-cable/menu/electrosurgical-unit-cable.webp" type="image/webp">
                                            <img src="/images/application/products/electrosurgical-unit-cable/menu/electrosurgical-unit-cable.png"
                                                alt="醫療級止血線 Electrosurgical Unit Cable">
                                        </picture>
                                    </div>
                                </a>
                                <div class="text-section">
                                    <div class="title text-left">手術用電燒刀</div>
                                    <div class="subtitle text-left">醫療級止血線</div>
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
                                            <source srcset="/images/application/products/motor-temperature-sensor-cable-tesla-taycan/menu/motor-temperature-sensor-cable-tesla-taycan.webp" type="image/webp">
                                            <img src="/images/application/products/motor-temperature-sensor-cable-tesla-taycan/menu/motor-temperature-sensor-cable-tesla-taycan.jpg"
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
                                            <source srcset="/images/application/products/motor-power-cable/menu/motor-power-cable.webp" type="image/webp">
                                            <img src="/images/application/products/motor-power-cable/menu/motor-power-cable.jpg"
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
                                                alt="多爐溫控系統雙層屏蔽電纜 Temper Control Signal Shielding Cable">
                                        </picture>
                                    </div>
                                </a>
                                <div class="text-section">
                                    <div class="title text-left">大型高溫爐</div>
                                    <div class="subtitle text-left">多爐溫控系統雙層屏蔽線</div>
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
                    </div>
                </div>
            </section>
            <section class="display-block product-category-list bg-wrapper">
                <div class="container">
                    <h2 class="title revealTrigger">電線產品分類
                    </h2>
                    <h2 class="subtitle">WIRE CATEGORY
                    </h2>
                    <div id="divProductItemList" runat="server" class="content row row-cols-2 row-cols-sm-2 row-cols-md-3 row-cols-lg-4">
                        <div class="col reveal animate__animated">
                            <figure class="product-category-item move">
                                <a href="/zh/product/silicone-fiberglass-wire">
                                    <div class="image-section">
                                        <picture>
                                            <source srcset="/images/home/inflammable/big-menu.webp" type="image/webp">
                                            <img src="/images/home/inflammable/big-menu.png"
                                                alt="防火耐燃電線 Anti-Flammatory Wire and Cable">
                                        </picture>
                                    </div>
                                </a>
                                <div class="text-section">
                                    <figcaption class="title my-auto">防火耐燃電線系列
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

    <asp:UpdatePanel ID="upNewsModal" runat="server">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <div class="modal fade" id="newsModal" tabindex="-1" aria-labelledby="newsContent" aria-hidden="true">
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
                            <a href="/zh/product/heating-wire/medical-respiration-pipe-heating-wire">
                                <img src="/images/promotion/醫療用 呼吸加熱管.jpg" />
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
