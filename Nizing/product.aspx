<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="product" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <title>日進產品線-日進電線</title>
    <meta name="description" content="各式電線電纜，經過UL、VDE、CCC、PSE等國際認證，品質優良，外銷內需皆可滿足">

    <style type="text/css">
        .webp .product-category-list.bg-wrapper {
            background-image: url('/images/background/bg-product.webp');
        }
        .no-webp .product-category-list.bg-wrapper {
            background-image: url('/images/background/bg-product.png');
        }
    </style>
</asp:Content>
<asp:Content ID="banner" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <picture>
                <source srcset="/images/banner/banner-product-en.webp" type="image/webp" />
            <img src="/images/banner/banner-product-en.png" />
            </picture>
        </div>
    </div>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper">
        <section class="display-block product-category-list bg-wrapper">
            <div class="container">
                <h2 class="title revealTrigger">產品分類
                </h2>
                <h2 class="subtitle">PRODUCT
                </h2>
                <div id="divItemList" runat="server" class="content row row-cols-2 row-cols-sm-2 row-cols-md-3 row-cols-lg-4">
                    <%--<div class="col reveal animate__animated">
                        <figure class="product-category-item move">
                            <a href="/zh/military-grade-wire">
                                <div class="image-section">
                                    <img src="/images/product/military-grade-wire/military-grade-wire.png"
                                        alt="軍規線 Military Grade Wire and Cable" />
                                </div>
                            </a>
                            <div class="text-section">
                                <figcaption class="title">軍規線系列
                                </figcaption>
                            </div>
                        </figure>
                    </div>
                    <div class="col reveal animate__animated">
                        <figure class="product-category-item move">
                            <a href="/zh/silicone-fiberglass-wire">
                                <div class="image-section">
                                    <img src="https://via.placeholder.com/350x250?text=&nbsp" />
                                </div>
                            </a>
                            <div class="text-section">
                                <figcaption class="title my-auto">防火耐燃系列
                                </figcaption>
                            </div>
                        </figure>
                    </div>
                    <div class="col reveal animate__animated">
                        <figure class="product-category-item move">
                            <a href="/zh/silicone-fiberglass-wire">
                                <div class="image-section">
                                    <img src="/images/product/silicone-fiberglass-wire/silicone-fiberglass-wire-menu.png"
                                        alt="矽膠編織電線 Silicone Fiberglass Wire" />
                                </div>
                            </a>
                            <div class="text-section">
                                <figcaption class="title">矽膠編織線系列
                                </figcaption>
                            </div>
                        </figure>
                    </div>
                    <div class="col reveal animate__animated">
                        <figure class="product-category-item move">
                            <a href="/zh/high-temperature-wire">
                                <div class="image-section">
                                    <img src="/images/product/high-temperature-wire/high-temperature-wire-menu.png"
                                        alt="高溫電線 High Temperature Resistance Wire" />
                                </div>
                            </a>
                            <div class="text-section">
                                <figcaption class="title">高溫線系列
                                </figcaption>
                            </div>
                        </figure>
                    </div>
                    <div class="col reveal animate__animated">
                        <figure class="product-category-item move">
                            <a href="/zh/silicone-wire">
                                <div class="image-section">
                                    <img src="/images/product/silicone-wire/silicone-wire_menu-500x500.png"
                                        alt="矽膠電線 Silicone Wire" />
                                </div>
                            </a>
                            <div class="text-section">
                                <figcaption class="title">矽膠線系列
                                </figcaption>
                            </div>
                        </figure>
                    </div>
                    <div class="col reveal animate__animated">
                        <figure class="product-category-item move">
                            <a href="/zh/teflon-wire">
                                <div class="image-section">
                                    <img src="/images/product/teflon-wire/teflon-wire-menu.png"
                                        alt="鐵氟龍電線 Teflon Wire" />
                                </div>
                            </a>
                            <div class="text-section">
                                <figcaption class="title">鐵氟龍線系列
                                </figcaption>
                            </div>
                        </figure>
                    </div>
                    <div class="col reveal animate__animated">
                        <figure class="product-category-item move">
                            <a href="/zh/xlpe-wire">
                                <div class="image-section">
                                    <img src="/images/product/xlpe-wire/xlpe-wire_menu-500x500.png"
                                        alt="交聯照射電線 cross linked wire xlpe" />
                                </div>
                            </a>
                            <div class="text-section">
                                <figcaption class="title">交聯照射線系列
                                </figcaption>
                            </div>
                        </figure>
                    </div>
                    <div class="col reveal animate__animated">
                        <figure class="product-category-item move">
                            <a href="/zh/pvc-wire">
                                <div class="image-section">
                                    <img src="/images/product/pvc-wire/pvc-wire_menu-500x500.png"
                                        alt="PVC電線 PVC" />
                                </div>
                            </a>
                            <div class="text-section">
                                <figcaption class="title">PVC線系列
                                </figcaption>
                            </div>
                        </figure>
                    </div>
                    <div class="col reveal animate__animated">
                        <figure class="product-category-item move">
                            <a href="/zh/tube">
                                <div class="image-section">
                                    <img src="/images/product/tube/tube_menu-500x500.png"
                                        alt="矽膠套管 玻纖套管 Silicone Fiberglass Tube" />
                                </div>
                            </a>
                            <div class="text-section">
                                <figcaption class="title">套管系列
                                </figcaption>
                            </div>
                        </figure>
                    </div>
                    <div class="col reveal animate__animated">
                        <figure class="product-category-item move">
                            <a href="/zh/thermocouple">
                                <div class="image-section">
                                    <img src="/images/product/thermocouple/thermocouple_menu-500x500.png"
                                        alt="補償導線 Thermocouple K-Type J-Type T-Type R-Type S-Type E-Type" />
                                </div>
                            </a>
                            <div class="text-section">
                                <figcaption class="title">補償導線系列
                                </figcaption>
                            </div>
                        </figure>
                    </div>
                    <div class="col reveal animate__animated">
                        <figure class="product-category-item move">
                            <a href="/zh/heating-wire">
                                <div class="image-section">
                                    <img src="/images/product/heating-wire/heating-wire_menu-500x500.png"
                                        alt="發熱線 Heating Wire" />
                                </div>
                            </a>
                            <div class="text-section">
                                <figcaption class="title">發熱線系列
                                </figcaption>
                            </div>
                        </figure>
                    </div>
                    <div class="col reveal animate__animated">
                        <figure class="product-category-item move">
                            <a href="/zh/automobile-wire">
                                <div class="image-section">
                                    <img src="/images/product/xlpe-wire/xlpe-wire_menu-500x500.png"
                                        alt="汽車花線 automotive wire" />
                                </div>
                            </a>
                            <div class="text-section">
                                <figcaption class="title">汽車花線系列
                                </figcaption>
                            </div>
                        </figure>
                    </div>
                    <div class="col reveal animate__animated">
                        <figure class="product-category-item move">
                            <a href="/zh/composite-cable">
                                <div class="image-section">
                                    <img src="/images/product/composite-cable/composite-cable_menu.png"
                                        alt="複合線 Composite Cable" />
                                </div>
                            </a>
                            <div class="text-section">
                                <figcaption class="title">複合線系列
                                </figcaption>
                            </div>
                        </figure>
                    </div>
                </div>--%>
            </div>
        </section>
    </div>
</asp:Content>

