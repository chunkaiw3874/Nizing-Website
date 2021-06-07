<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="product" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <title>日進產品線-日進電線</title>
    <meta name="description" content="各式電線電纜，經過UL、VDE、CCC、PSE等國際認證，品質優良，外銷內需皆可滿足">
    <style type="text/css">
        /*hover effects*/
        /*.enlarge {
            overflow: hidden;
        }

            .enlarge img {
                transition: transform 0.5s ease-in;
            }

            .enlarge:hover img {
                transform: scale(1.2);
            }

        .overlay-parent {
            position: relative;
        }

            .overlay-parent .overlay {
                position: absolute;
                top: 0;
                bottom: 0;
                left: 0;
                right: 0;
                background-color: aqua;
                opacity: 0;
                transition: 0.5s ease-in;
                display: flex;
                align-items: center;
                justify-content: center;
            }

                .overlay-parent .overlay .overlay-content {
                    font-size: 32px;
                    color: white;
                }

                .overlay-parent .overlay:hover {
                    opacity: 0.5;
                }*/
    </style>
</asp:Content>
<asp:Content ID="banner" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="images/banner/banner-product-en.png" class="w-100" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper">
        <section class="display-block product-category-list">
            <div class="container">
                <h2 class="title">
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
                                <figcaption class="overlay">
                                    <div class="title">
                                        鐵氟龍線系列
                                    </div>
                                </figcaption>
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
    </div>
</asp:Content>

