<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>高品質電線電纜製造-日進電線-國際安規認證通過</title>
    <meta name="keywords" content="電線,電纜,電線電纜,矽膠電線,鐵氟龍電線,照射電線,發熱電線,PVC電線,PE電線,PU電線,補償導線,耐高溫電線,耐高溫電纜,耐高壓電線,耐高壓電纜,UL電線,矽膠編織電線,軍規線,汽車花線" />
    <meta name="description" content="日進電線為國內一流電線及電纜製造商，專門製造特殊材質及用途電線及電纜，如耐高溫的矽膠電線、矽膠編織電線，抗酸鹼的聚合氟化線電線，抗UV的照射電線等，旗下電線電纜產品眾多，歡迎聯繫洽詢" />

    <style>
        video {
            width: 100%;
        }

        a {
            color: inherit;
        }

            a:hover {
                color: inherit;
                text-decoration: none;
            }

        textarea {
            resize: none;
        }

        .title {
            font-size: medium;
            font-weight: bold;
        }


        .subtitle {
            font-weight: bold;
            font-size: small;
            color: gray;
        }

        .jumbotron {
            padding: 0;
            margin: 0;
        }

        .row-m-0 {
            margin: 0px;
        }

        .col-px-0 {
            padding-left: 0px;
            padding-right: 0px;
        }

        .company-image {
            margin-bottom: -6px;
        }

        .main-block {
            background-color: #ffffff;
            padding: 48px 0px;
        }

            .main-block .container .title {
                text-align: center;
            }

            .main-block .container .subtitle {
                text-align: center;
            }

            .main-block .content {
                margin-top: 48px;
            }

            .main-block:nth-child(2n) {
                background-color: #000000;
                color: #ffffff;
            }

            .main-block .list-group-item {
                background-color: inherit;
                border: none;
            }

        .emphasis-menu {
            background-color: #f1f1f1;
            padding: 0px;
        }

            .emphasis-menu .card {
                border: none;
                background-color: inherit;
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

        /*.emphasis-menu .card-body .card-text .title {
                    font-size: large;
                    font-weight: bold;
                }

                .emphasis-menu .card-body .card-text .subtitle {
                    font-weight: bold;
                    font-size: small;
                    color: gray;
                }*/

        .emphasis-menu .card-body .card-text {
            font-size: 0.8rem;
            font-weight: normal;
        }

            .emphasis-menu .card-body .card-text .btn {
                background-color: inherit;
            }

        .emphasis-menu .card-link {
            color: inherit;
        }

        .product-menu .content-wrapper {
            padding: 20px 0;
            margin: 10px;
            border: solid 1px #1a1a1a;
            border-radius: 10px;
        }

        .product-menu .img {
            filter: invert(0.4) sepia(0) saturate(1) hue-rotate(0deg) brightness(0.5);
            background-color: inherit;
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
    <div class="container-fluid">
        <div class="company-image">
            <video preload="auto" muted autoplay loop playsinline>
                <source src="/video/nizing-intro.mp4" />
            </video>
        </div>
        <div class="emphasis-menu">
            <div class="container">
                <div class="row-m-0 row row-cols-1 row-cols-sm-2 row-cols-md-4 row-cols-lg-6 w-100">
                    <div class="col-px-0 col align-self-center">
                        <div class="card">
                            <div class="card-body">
                                <div class="card-text text-md-left">
                                    <div class="title">暢銷分類</div>
                                    <div class="subtitle">Best Sellers</div>
                                    <div>
                                        <a class="btn btn-dark text-dark mt-2" href="product.aspx">+ More</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-px-0 col">
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
                    <div class="col-px-0 col d-none d-lg-block d-xl-block">
                        <nav class="card h-100">
                            <a class="card-link" href="teflon-series.aspx">
                                <div class="card-body">
                                    <img src="images/menu/teflon-wire-menu-white.svg" class="img img-thumbnail tilted" />
                                    <p class="card-text">鐵氟龍線</p>
                                </div>
                            </a>
                        </nav>
                    </div>
                    <div class="col-px-0 col d-none d-lg-block d-xl-block">
                        <nav class="card h-100">
                            <a class="card-link" href="xlpe-series.aspx">
                                <div class="card-body">
                                    <img src="images/menu/xlpe-wire-menu-white.svg" class="img img-thumbnail tilted" />
                                    <p class="card-text">XLPE</p>
                                </div>
                            </a>
                        </nav>
                    </div>
                    <%--<div class="col-px-0 col d-none d-lg-block d-xl-block">
                        <nav class="card h-100">
                            <a class="card-link" href="pvc-series.aspx">
                                <div class="card-body">
                                    <img src="images/menu/pvc-wire-menu-white.svg" class="img img-thumbnail tilted" />
                                    <p class="card-text">PVC</p>
                                </div>
                            </a>
                        </nav>
                    </div>
                    <div class="col-px-0 col d-none d-lg-block d-xl-block">
                        <nav class="card h-100">
                            <a class="card-link" href="sleeve-and-tube-series.aspx">
                                <div class="card-body">
                                    <img src="images/menu/tube-menu-white.svg" class="img img-thumbnail" />
                                    <p class="card-text">套管</p>
                                </div>
                            </a>
                        </nav>
                    </div>
                    <div class="col-px-0 col d-none d-lg-block d-xl-block">
                        <nav class="card h-100">
                            <a class="card-link" href="thermocouple-series.aspx">
                                <div class="card-body">
                                    <img src="images/menu/thermocouple-wire-menu-white.svg" class="img img-thumbnail tilted" />
                                    <p class="card-text">補償導線</p>
                                </div>
                            </a>
                        </nav>
                    </div>
                    <div class="col-px-0 col d-none d-lg-block d-xl-block">
                        <nav class="card h-100">
                            <a class="card-link" href="heating-wire-series.aspx">
                                <div class="card-body">
                                    <img src="images/menu/heating-wire-menu-white.svg" class="img img-thumbnail" />
                                    <p class="card-text">發熱線</p>
                                </div>
                            </a>
                        </nav>
                    </div>--%>
                </div>
            </div>
        </div>
        <div class="main-block product-menu">
            <div class="container">
                <div class="title">
                    <span class="h1">產品分類</span>
                </div>
                <div class="subtitle">Product Category</div>
                <div class="content row row-cols-1 row-cols-sm-2 row-cols-md-3">
                    <div class="col text-center">
                        <div class="content-wrapper">
                            <a href="silicone-fiberglass-series.aspx">
                                <img class="img" src="/images/menu/braided-wire-menu-white.svg" />
                                <div class="title">
                                    矽膠編織線
                                </div>
                                <div class="subtitle">
                                    Silicone Fiberglass Wire
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col text-center">
                        <div class="content-wrapper">
                            <a href="high-temperature-resistance-series.aspx">
                                <img class="img" src="/images/menu/high-temperature-wire-menu-white.svg" />
                                <div class="title">
                                    高溫線
                                </div>
                                <div class="subtitle">
                                    High Temperature Wire
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col text-center">
                        <div class="content-wrapper">
                            <a href="silicone-series.aspx">
                                <img class="img" src="/images/menu/silicone-wire-menu-white.svg" />
                                <div class="title">
                                    矽膠線
                                </div>
                                <div class="subtitle">
                                    Silicone Wire
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col text-center">
                        <div class="content-wrapper">
                            <a href="teflon-series.aspx">
                                <img class="img" src="/images/menu/teflon-wire-menu-white.svg" />
                                <div class="title">
                                    鐵氟龍線
                                </div>
                                <div class="subtitle">
                                    Teflon Wire
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col text-center">
                        <div class="content-wrapper">
                            <a href="xlpe-series.aspx">
                                <img class="img" src="/images/menu/xlpe-wire-menu-white.svg" />
                                <div class="title">
                                    XLPE線
                                </div>
                                <div class="subtitle">
                                    XLPE Wire
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col text-center">
                        <div class="content-wrapper">
                            <a href="pvc-series.aspx">
                                <img class="img" src="/images/menu/pvc-wire-menu-white.svg" />
                                <div class="title">
                                    PVC線
                                </div>
                                <div class="subtitle">
                                    PVC Wire
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col text-center">
                        <div class="content-wrapper">
                            <a href="sleeve-and-tube-series.aspx">
                                <img class="img" src="/images/menu/tube-menu-white.svg" />
                                <div class="title">
                                    套管
                                </div>
                                <div class="subtitle">
                                    Tube and Sleeve
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col text-center">
                        <div class="content-wrapper">
                            <a href="thermocouple-series.aspx">
                                <img class="img" src="/images/menu/thermocouple-wire-menu-white.svg" />
                                <div class="title">
                                    補償導線
                                </div>
                                <div class="subtitle">
                                    Thermocouple
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col text-center">
                        <div class="content-wrapper">
                            <a href="heating-wire-series.aspx">
                                <img class="img" src="/images/menu/heating-wire-menu-white.svg" />
                                <div class="title">
                                    發熱線
                                </div>
                                <div class="subtitle">
                                    Heating Wire
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--<div class="main-block company-info">
            <div class="container">
                <div class="title">
                    <span class="h1">日進傳承</span>
                </div>
                <div class="subtitle">
                    Nizing Ideology
                </div>
                <div class="content">
                    <p>
                        日進電線股份有限公司創立於1983年，耐熱電線電纜起步，目前日進電線已是台灣電線電纜及特殊線材產業領導廠商，同時成功跨足綠能光電、成為國際化企業。
日進電線所生產的矽膠線、補償導線、PVC線、不銹鋼線材，廣泛運用於電力傳輸、電信網路、交通運輸、工業生產等基礎建設。旗下核心事業中，電線電纜事業包含矽膠耐熱電線、補償導線、PVC照射線等電線電纜。電力電纜與通信線纜產品線完整，深耕台灣電力和電信需求。
                        <br />
                        日進電線自2003年開始研發LED、溫度控制、醫療、雲端及太陽能光電等產業，藉由研發及先進材料產業的經驗及成果，作為佈局新興科技領域的基礎。
                        <br />
                        日進電線擁有完整的產品系列，通過數種國際安規認可產品。以最熱忱的服務態度，不斷精進品質，開發新產品，和客戶共同發展、共同成長。由于您持續的支持與愛護，以前瞻性的佈局策略追求企業創新成長，進行自主技術之研究，依據市場及客戶需求開發新產品與新業務。日進電線秉持一貫對品質的嚴謹要求，以及快速整合的服務，成為客戶的最佳伙伴，在兩岸經濟發展的重要里程中，扮演關鍵的參與和推動角色，未來日進電線將在卓越製造技術與多樣化客戶基礎下持續深耕，同時積極掌握產業新興發展機會，創造企業發展的新里程。
                        <br />
                        日進電線除了人的不懈努力外，更重要的歸功于各位先進的指導與愛護。貫徹整體顧客意識，珍惜每一次服務的機會。全體日進電線人員處世以"誠"、"信"為原則；"誠"乃是出自於內心的真誠，"信"則是言而有信、言出必行。"積極、創新、追求卓越"是日進電線的經營理念。我們深信，唯有堅定的企業信念、熱忱投入的工作態度、以及高效率和實事求是的負責精神，才能贏得客戶的支持與信賴。
日進就是一個可以帶給大家幸福的地方。以日進為本，照顧大家。透過日進，大家互相協助，互相理解，同心協力幫助客戶解決問題。這就是我們的宗旨。
                    </p>
                </div>
            </div>
        </div>--%>
        <div class="main-block">
            <div class="container">
                <div class="title">
                    客製化線材
                </div>
                <div class="subtitle">
                    Customized Cable
                </div>
                <div class="content">
                    <div class="row">
                        <div class="col-md-10">
                            <p>專注於您的需求，為您客製專屬的線材，無論您所需要的是規格分析，亦或是材質解析，日進皆可給您最專業的服務</p>
                            <a class="btn btn-light text-dark mt-2" href="customize_page.aspx">+ More</a>
                        </div>
                        <div class="col-md-2 d-none d-md-block">                            
                            <img src="images/customize-02.jpg" width="100" class="img img-thumbnail d-block ml-5 mb-1" />
                            <img src="images/customize-01.jpg" width="100" class="img img-thumbnail d-block" />
                        </div>
                    </div>
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
</asp:Content>
