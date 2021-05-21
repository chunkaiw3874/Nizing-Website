<%@ Page Title="" Language="C#" MasterPageFile="~/master/indexMaster2021.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>高品質電線電纜製造-日進電線-國際安規認證通過</title>
    <meta name="keywords" content="電線,電纜,電線電纜,矽膠電線,鐵氟龍電線,照射電線,發熱電線,PVC電線,PE電線,PU電線,補償導線,耐高溫電線,耐高溫電纜,耐高壓電線,耐高壓電纜,UL電線,矽膠編織電線,軍規線,汽車花線" />
    <meta name="description" content="日進電線為國內一流電線及電纜製造商，專門製造特殊材質及用途電線及電纜，如耐高溫的矽膠電線、矽膠編織電線，抗酸鹼的聚合氟化線電線，抗UV的照射電線等，旗下電線電纜產品眾多，歡迎聯繫洽詢" />
    <style>
        .display-block {
            padding-bottom: 30px;
        }

            .display-block .block-header {
                padding: 30px 0;
            }

            .display-block:nth-child(2n+1) {
                background-color: #f1f1f1;
            }


        .product-category a{
            color:black;
            text-decoration:none;
        }

        .banner .img,
        .product-category .img {
            width: 100%;
            object-fit: contain;
        }

        .product-category .img {
            box-shadow: 15px 15px 15px 0 rgba(0, 0, 0, 0.5);
            transition: transform 0.3s ease;
            transform: translateX(0px);
        }

            .product-category .img:hover {
                transform: translateX(-5px) translateY(-5px);
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
            color: black;
            text-decoration: none;
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
                slidesToShow: 8,
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid p-0">
        <div class="banner">
            <img src="/images/banner/banner-homepage-cn-1800x500.gif" class="w-100 img" />
        </div>
        <div class="display-block">
            <div class="container product-category">
                <div class="block-header text-center">
                    <div class="block-title text-black-50 h1">產品資訊</div>
                    <div class="block-subtitle text-black-50 h3">PRODUCT</div>
                </div>
                <div class="block-content row row-cols-4">
                    <div class="col px-4 py-2">
                        <div>
                            <a href="/silicone-fiberglass-series.aspx">
                                <img src="/images/product_pic/silicone-fiberglass-wire/silicone-fiberglass-wire_menu-500x500.png" class="w-100 img card-img-top" />
                                <div class="card-body text-center h5 mt-2">
                                    矽膠編織線系列
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col px-4 py-2">
                        <div>
                            <a href="/high-temperature-resistance-series.aspx">
                                <img src="/images/product_pic/high-temperature-wire/high-temperature-wire_menu-500x500.png" class="w-100 img card-img-top" />
                                <div class="card-body text-center h5 mt-2">
                                    高溫線系列
                                </div>
                            </a>

                        </div>
                    </div>
                    <div class="col px-4 py-2">
                        <div>
                            <a href="/silicone-series.aspx">
                                <img src="/images/product_pic/silicone-wire/silicone-wire_menu-500x500.png" class="w-100 img card-img-top" />
                                <div class="card-body text-center h5 mt-2">
                                    矽膠線系列
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col px-4 py-2">
                        <div>
                            <a href="/teflon-series.aspx">
                                <img src="/images/product_pic/teflon-wire/teflon-wire_menu-500x500.png" class="w-100 img card-img-top" />
                                <div class="card-body text-center h5 mt-2">
                                    鐵氟龍線系列
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col px-4 py-2">
                        <div>
                            <a href="pvc-series.aspx">
                                <img src="/images/product_pic/pvc-wire/pvc-wire_menu-500x500.png" class="w-100 img card-img-top" />
                                <div class="card-body text-center h5 mt-2">
                                    PVC線系列
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col px-4 py-2">
                        <div>
                            <a href="/sleeve-and-tube-series.aspx">
                                <img src="/images/product_pic/tube/tube_menu-500x500.png" class="w-100 img card-img-top" />
                                <div class="card-body text-center h5 mt-2">
                                    套管系列
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col px-4 py-2">
                        <div>
                            <a href="/thermocouple-series.aspx">
                                <img src="/images/product_pic/thermocouple/thermocouple_menu-500x500.png" class="w-100 img card-img-top" />
                                <div class="card-body text-center h5 mt-2">
                                    補償導線系列
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col px-4 py-2">
                        <div>
                            <a href="/heating-wire-series.aspx">
                                <img src="/images/product_pic/heating-wire/heating-wire_menu-500x500.png" class="w-100 img card-img-top" />
                                <div class="card-body text-center h5 mt-2">
                                    發熱線系列
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col px-4 py-2">
                        <div>
                            <a href="/xlpe-series.aspx">
                                <img src="/images/product_pic/xlpe-wire/xlpe-wire_menu-500x500.png" class="w-100 img card-img-top" />
                                <div class="card-body text-center h5 mt-2">
                                    交聯照射線系列
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col px-4 py-2">
                        <div>
                            <a href="/special-cable.aspx">
                                <img src="/images/product_pic/special-cable/special-cable_menu-500x500.png" class="w-100 img card-img-top" />
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
                <div class="block-header text-center">
                    <div class="block-title text-black-50 h1">最新消息</div>
                    <div class="block-subtitle text-black-50 h3">NIZING NEWS</div>
                </div>
                <div class="block-content">
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
                <div class="block-header text-center">
                    <div class="block-title text-black-50 h1">合作企業</div>
                    <div class="block-subtitle text-black-50 h3">ASSOCIATES</div>
                </div>
                <div class="slider block-content">
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

    <!--Modal-->
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
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

