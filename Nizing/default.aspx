<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>高品質電線電纜製造-日進電線-國際安規認證通過</title>
    <meta name="keywords" content="電線,電纜,電線電纜,矽膠電線,鐵氟龍電線,照射電線,發熱電線,PVC電線,PE電線,PU電線,補償導線,耐高溫電線,耐高溫電纜,耐高壓電線,耐高壓電纜,UL電線,矽膠編織電線,軍規線,汽車花線" />
    <meta name="description" content="日進電線為國內一流電線及電纜製造商，專門製造特殊材質及用途電線及電纜，如耐高溫的矽膠電線、矽膠編織電線，抗酸鹼的聚合氟化線電線，抗UV的照射電線等，旗下電線電纜產品眾多，歡迎聯繫洽詢" />
    <link rel="stylesheet" type="text/css" href="/Content/slick/slick.css" />
    <link href="/Content/slick/slick-theme.css" rel="stylesheet" />
    <script type="text/javascript" src="/Content/slick/slick.min.js"></script>
    <style style="text/css">
        /*首頁不顯示breadcrumb*/
        .breadcrumb {
            display: none;
        }

        .product-category-list.bg-wrapper {
            background-image: url('images/background/bg-product.png');
        }

        .display-block:first-child {
            padding-top: 24px !important;
            margin: 12px 0;
        }

        .display-block .list-group-item {
            background-color: inherit;
            border: none;
        }


        .news.bg-wrapper {
            background-image: url('images/background/bg-news.jpg');
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

            $('#promotionModal').modal('show');
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
  "image" : [ "http://www.nizing.com.tw/images/banner/banner-homepage-cn-1300x500.gif", "http://www.nizing.com.tw/images/product_pic/high-temperature-wire/high-temperature-wire_menu-500x500.png", "http://www.nizing.com.tw/images/product_pic/silicone-wire/silicone-wire_menu-500x500.png", "http://www.nizing.com.tw/images/product_pic/teflon-wire/teflon-wire_menu-500x500.png", "http://www.nizing.com.tw/images/product_pic/xlpe-wire/xlpe-wire_menu-500x500.png", "http://www.nizing.com.tw/images/product_pic/pvc-wire/pvc-wire_menu-500x500.png", "http://www.nizing.com.tw/images/product_pic/tube/tube_menu-500x500.png", "http://www.nizing.com.tw/images/product_pic/thermocouple/thermocouple_menu-500x500.png", "http://www.nizing.com.tw/images/product_pic/heating-wire/heating-wire_menu-500x500.png", "http://www.nizing.com.tw/images/product_pic/special-cable/special-cable_menu-500x500.png" ],
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
            <img src="images/banner/banner-homepage-cn-1300x500.gif" alt="日進電線電纜 Nizing Electric Wire and Cable" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="display-block-wrapper homepage">
            <section class="display-block product-category-list bg-wrapper">
                <div class="container">
                    <h2 class="title revealTrigger">
                        產品分類
                    </h2>
                    <h2 class="subtitle">
                        PRODUCT
                    </h2>
                    <div class="content row row-cols-2 row-cols-sm-2 row-cols-md-3 row-cols-lg-4">
                        <div class="col product-category-item reveal animate__animated">
                            <a href="silicone-fiberglass-series.aspx">
                                <figure class="overlay-parent shadow move">
                                    <img src="images/product_pic/silicone-fiberglass-wire/silicone-fiberglass-wire-menu.png"
                                        alt="矽膠編織電線 Silicone Fiberglass Wire" />
                                    <div class="overlay">
                                        <figcaption class="title">
                                            矽膠編織線系列
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col product-category-item reveal animate__animated">
                            <a href="high-temperature-resistance-series.aspx">
                                <figure class="overlay-parent shadow move">
                                    <img src="images/product_pic/high-temperature-wire/high-temperature-wire-menu.png"
                                        alt="高溫電線 High Temperature Wire" />
                                    <div class="overlay">
                                        <figcaption class="title">
                                            高溫線系列
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col product-category-item reveal animate__animated">
                            <a href="silicone-series.aspx">
                                <figure class="overlay-parent shadow move">
                                    <img src="images/product_pic/silicone-wire/silicone-wire_menu-500x500.png"
                                        alt="矽膠電線 Silicone Wire" />
                                    <div class="overlay">
                                        <figcaption class="title">
                                            矽膠線系列
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col product-category-item reveal animate__animated">
                            <a href="teflon-series.aspx">
                                <figure class="overlay-parent shadow move">
                                    <img src="images/product_pic/teflon-wire/teflon-wire-menu.png"
                                        alt="鐵氟龍電線 Teflon Wire" />
                                    <div class="overlay">
                                        <figcaption class="title">
                                            鐵氟龍線系列
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col product-category-item reveal animate__animated">
                            <a href="xlpe-series.aspx">
                                <figure class="overlay-parent shadow move">
                                    <img src="images/product_pic/xlpe-wire/xlpe-wire_menu-500x500.png"
                                        alt="交聯照射電線 cross linked wire xlpe" />
                                    <div class="overlay">
                                        <figcaption class="title">
                                            交聯照射線系列
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col product-category-item reveal animate__animated">
                            <a href="pvc-series.aspx">
                                <figure class="overlay-parent shadow move">
                                    <img src="images/product_pic/pvc-wire/pvc-wire_menu-500x500.png"
                                        alt="PVC電線 PVC" />
                                    <div class="overlay">
                                        <figcaption class="title">
                                            PVC線系列
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col product-category-item reveal animate__animated">
                            <a href="sleeve-and-tube-series.aspx">
                                <figure class="overlay-parent shadow move">
                                    <img src="images/product_pic/tube/tube_menu-500x500.png"
                                        alt="矽膠套管 玻纖套管 Silicone Fiberglass Tube" />
                                    <div class="overlay">
                                        <figcaption class="title">
                                            套管系列
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col product-category-item reveal animate__animated">
                            <a href="thermocouple-series.aspx">
                                <figure class="overlay-parent shadow move">
                                    <img src="images/product_pic/thermocouple/thermocouple_menu-500x500.png"
                                        alt="補償導線 Thermocouple K-Type J-Type T-Type R-Type S-Type E-Type" />
                                    <div class="overlay">
                                        <figcaption class="title">
                                            補償導線系列
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col product-category-item reveal animate__animated">
                            <a href="heating-wire-series.aspx">
                                <figure class="overlay-parent shadow move">
                                    <img src="images/product_pic/heating-wire/heating-wire_menu-500x500.png"
                                        alt="發熱線 Heating Wire" />
                                    <div class="overlay">
                                        <figcaption class="title">
                                            發熱線系列
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col product-category-item reveal animate__animated">
                            <a href="automotive-wire-series.aspx">
                                <figure class="overlay-parent shadow move">
                                    <img src="images/product_pic/xlpe-wire/xlpe-wire_menu-500x500.png"
                                        alt="汽車花線 automotive wire" />
                                    <div class="overlay">
                                        <figcaption class="title">
                                            汽車花線系列
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col product-category-item reveal animate__animated">
                            <a href="military-grade-series.aspx">
                                <figure class="overlay-parent shadow move">
                                    <img src="images/product_pic/military-grade-wire/military-grade-wire.png"
                                        alt="軍規線 Military Grade Wire and Cable" />
                                    <div class="overlay">
                                        <figcaption class="title">
                                            軍規線系列
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col product-category-item reveal animate__animated">
                            <a href="special-cable.aspx">
                                <figure class="overlay-parent shadow move">
                                    <img src="images/product_pic/special-cable/special-cable_menu-500x500.png"
                                        alt="特殊線 Custom Wire and Cable" />
                                    <div class="overlay">
                                        <figcaption class="title">
                                            特殊線系列
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                    </div>
                </div>
            </section>
            <section class="display-block news bg-wrapper">
                <div class="container">
                    <h2 class="title">
                        最新消息
                    </h2>
                    <h2 class="subtitle">
                        LATEST NEWS
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
                    <figure class="slider">
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
                            <a href="respiration-pipe-heating-wire.aspx">
                                <img src="images/promotion/醫療用 呼吸加熱管.jpg" />
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
