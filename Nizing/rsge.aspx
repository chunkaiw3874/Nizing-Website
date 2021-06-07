<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="rsge.aspx.cs" Inherits="ul1007" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <title>RSGE矽膠編織耐熱線-日進電線</title>
    <meta name="description" content="RSGE矽膠編織耐熱線，適用於各種家用電器、照明燈具、工業機器、電熱製品、原料熔爐等高溫場所之配線，通過UL VW-1垂直燃燒測試以及多項IEC測試，證實為低煙、無鹵、耐燃之產品。詳細的產品資訊，包括RSGE矽膠編織耐熱線的產品規格以及使用範圍值">

    <style type="text/css">
        .product-item #product-image-carousel.carousel .product-image.carousel-item img {
            display: block;
        }

        .product-item #product-image-carousel.carousel .carousel-control-prev .carousel-control-prev-icon,
        .product-item #product-image-carousel.carousel .carousel-control-next .carousel-control-next-icon,
        .product-item #product-image-carousel.carousel .carousel-indicators li {
            filter: invert(1);
        }
    </style>

    <script type="text/javascript">
        $(function () {
            dragScroll();
        });
    </script>
</asp:Content>
<asp:Content ID="banner" ContentPlaceHolderID="banner" runat="server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-product-en.png" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="server">
    <div class="display-block-wrapper product-item">
        <section class="display-block" itemscope itemtype="https://schema.org/Product">
            <article class="container">
                <h2 itemprop="name" class="title">RS-GE 矽膠編織耐熱線
                </h2>
                <h2 class="subtitle" itemprop="productID">RS-GE
                </h2>
                <div class="content row">
                    <div class="col-lg-7 pl-lg-0">
                        <div id="product-image-carousel" class="carousel slide" data-ride="carousel" data-interval="false">
                            <ol class="carousel-indicators">
                                <li data-target="#product-image-carousel" data-slide-to="0" class="active"></li>
                                <%--<li data-target="#product-image-carousel" data-slide-to="1"></li>
                                <li data-target="#product-image-carousel" data-slide-to="2"></li>--%>
                            </ol>
                            <div class="carousel-inner">
                                <figure class="carousel-item product-image active">
                                    <img itemprop="image" src="images/product_pic/silicone-fiberglass-wire/rsge-yellowgreen-1000x450.jpg"
                                        alt="矽膠編織線適用於各種家用電器、照明燈具、工業機器、電熱製品、原料熔爐等高溫場所之配線" />
                                </figure>
                                <%--<figure itemprop="image" class="carousel-item product-image">
                                    <img src="images/product_pic/silicone-fiberglass-wire/background/ul3512-blue-4032x2268.jpg" />
                                </figure>
                                <figure itemprop="image" class="carousel-item product-image">
                                    <img src="images/product_pic/silicone-fiberglass-wire/silicone-fiberglass-wire_menu-500x500-A.png" />
                                </figure>--%>
                            </div>
                            <a class="carousel-control-prev" href="#product-image-carousel" role="button" data-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="sr-only">Previous</span>
                            </a>
                            <a class="carousel-control-next" href="#product-image-carousel" role="button" data-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="sr-only">Next</span>
                            </a>
                        </div>
                        <div class="color-code-section">
                            <div>
                                Color:
                            </div>
                            <div class="color-code bg-white">
                            </div>
                            <div class="color-code bg-black">
                            </div>
                            <div class="color-code bg-red">
                            </div>
                            <div class="color-code bg-yellow">
                            </div>
                            <div class="color-code bg-blue">
                            </div>
                            <div class="color-code bg-green">
                            </div>
                            <div class="color-code bg-brown">
                            </div>
                            <div class="color-code bg-yellowgreen">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-5 pr-lg-0 d-flex flex-column justify-content-between product-text">
                        <div class="text-section application-field">
                            <div class="nizing-blue">
                                適用領域
                            </div>
                            RS-GE電線適用於各種家用電器、照明燈具、工業機器、電熱製品、原料熔爐等高溫場所之配線。
                        </div>
                        <div class="text-section simple-product-spec">
                            <div class="nizing-blue">
                                技術資料
                            </div>
                            <table>
                                <tr>
                                    <td>額定電壓:</td>
                                    <td>300/600V AC</td>
                                </tr>
                                <tr>
                                    <td>溫度範圍:</td>
                                    <td>-60~+200C</td>
                                </tr>
                                <tr>
                                    <td>外徑容差:</td>
                                    <td>±0.1~±1.5mm</td>
                                </tr>
                                <tr>
                                    <td>試驗電壓:</td>
                                    <td>1500/2000V</td>
                                </tr>
                            </table>
                        </div>
                        <div class="row text-section product-certification">
                            <div class="col-2">
                                <img src="images/certificate/iso9001/iso9001.jpg" class="w-100" />
                            </div>
                            <div class="col-2">
                                <img src="images/certificate/rohs/rohs.png" class="w-100" />
                            </div>
                            <div class="col-2">
                                <img src="images/certificate/reach/reach.jpg" class="w-100" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content full-product-spec">
                    <div class="table-wrapper table-responsive drag-scroll">
                        <table class="table table-striped table-striped-blue">
                            <tr>
                                <th colspan="3">導體<br />
                                    Conductor</th>
                                <th colspan="3">絕緣體
                    <br />
                                    Insulator</th>
                                <th rowspan="2">完成外徑<br />
                                    Overall Diameter<br />
                                    mm</th>
                                <th colspan="2">電氣特性<br />
                                    Electrical Characteristic</th>
                                <th>包裝<br />
                                    Packing</th>
                            </tr>
                            <tr>
                                <th>截面積<br />
                                    Section mm²/ (AWG)</th>
                                <th>導體結構<br />
                                    Composition
                    <br />
                                    NO. x mm</th>
                                <th>內徑<br />
                                    Inside Diameter mm</th>
                                <th>絕緣厚度<br />
                                    Insulation Thickness
                    <br />
                                    mm</th>
                                <th>矽膠外俓<br />
                                    Silicone
                    <br />
                                    Insulation<br />
                                    mm</th>
                                <th>玻璃纖維厚度<br />
                                    Fiberglass Thickness<br />
                                    mm</th>
                                <th>導體電阻<br />
                                    Maximum Resistance at 20°C ohm/km</th>
                                <th>電流容量<br />
                                    Current Capacity at 170°C-AMP</th>
                                <th>米/卷<br />
                                    Meters/ Coil</th>
                            </tr>
                            <tr>
                                <td>0.3(22AWG)</td>
                                <td>12x0.18</td>
                                <td>0.72</td>
                                <td>0.40</td>
                                <td>1.52 </td>
                                <td>0.16 </td>
                                <td>1.84</td>
                                <td>64.4</td>
                                <td>3.0</td>
                                <td>500</td>
                            </tr>
                            <tr>
                                <td>0.5(20AWG)</td>
                                <td>20x0.18</td>
                                <td>1.00</td>
                                <td>0.40</td>
                                <td>1.80 </td>
                                <td>0.16 </td>
                                <td>2.12</td>
                                <td>38.7</td>
                                <td>5.0</td>
                                <td>500</td>
                            </tr>
                            <tr>
                                <td>0.75(18AWG)</td>
                                <td>30x0.18</td>
                                <td>1.20</td>
                                <td>0.40</td>
                                <td>2.00 </td>
                                <td>0.16 </td>
                                <td>2.32</td>
                                <td>25.8</td>
                                <td>8.0</td>
                                <td>400</td>
                            </tr>
                            <tr>
                                <td>1(17AWG)</td>
                                <td>40x0.18</td>
                                <td>1.30</td>
                                <td>0.45</td>
                                <td>2.20 </td>
                                <td>0.16 </td>
                                <td>2.52</td>
                                <td>20.0</td>
                                <td>9.5</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>1.25(16AWG)</td>
                                <td>50x0.18</td>
                                <td>1.50</td>
                                <td>0.45</td>
                                <td>2.40 </td>
                                <td>0.16 </td>
                                <td>2.72</td>
                                <td>15.5</td>
                                <td>11.0</td>
                                <td>200</td>
                            </tr>
                            <tr>
                                <td>1.5(15AWG)</td>
                                <td>28x0.254</td>
                                <td>1.60</td>
                                <td>0.50</td>
                                <td>2.60 </td>
                                <td>0.16 </td>
                                <td>2.92</td>
                                <td>13.1</td>
                                <td>12.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>2(14AWG)</td>
                                <td>37x0.254</td>
                                <td>1.80</td>
                                <td>0.50</td>
                                <td>2.80 </td>
                                <td>0.16 </td>
                                <td>3.12</td>
                                <td>9.91</td>
                                <td>15.0</td>
                                <td>200</td>
                            </tr>
                            <tr>
                                <td>2.5(13AWG)</td>
                                <td>47x0.254</td>
                                <td>2.00</td>
                                <td>0.50</td>
                                <td>3.00 </td>
                                <td>0.16 </td>
                                <td>3.32</td>
                                <td>9.5</td>
                                <td>17.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>3(12AWG)</td>
                                <td>57x0.254</td>
                                <td>2.20</td>
                                <td>0.50</td>
                                <td>3.20</td>
                                <td>0.16</td>
                                <td>3.52</td>
                                <td>7.44</td>
                                <td>19.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>3.5(12AWG)</td>
                                <td>43x0.32</td>
                                <td>2.50</td>
                                <td>0.60</td>
                                <td>3.70</td>
                                <td>0.16</td>
                                <td>4.02</td>
                                <td>5.38</td>
                                <td>21.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>4(11AWG)</td>
                                <td>50x0.32</td>
                                <td>2.60</td>
                                <td>0.70</td>
                                <td>4.00 </td>
                                <td>0.16 </td>
                                <td>4.32</td>
                                <td>4.00</td>
                                <td>23.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>5.5(10AWG)</td>
                                <td>34x0.45</td>
                                <td>3.10</td>
                                <td>0.70</td>
                                <td>4.50 </td>
                                <td>0.16</td>
                                <td>4.82</td>
                                <td>3.5</td>
                                <td>28.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>6(10AWG)</td>
                                <td>37x0.45</td>
                                <td>3.30</td>
                                <td>0.80</td>
                                <td>4.90</td>
                                <td>0.16</td>
                                <td>5.22</td>
                                <td>3.01</td>
                                <td>29.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>8(8AWG)</td>
                                <td>50x0.45</td>
                                <td>3.70</td>
                                <td>0.80</td>
                                <td>5.30 </td>
                                <td>0.20 </td>
                                <td>5.70</td>
                                <td>2.45</td>
                                <td>35.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>10(7AWG)</td>
                                <td>63x0.45</td>
                                <td>4.20</td>
                                <td>0.90</td>
                                <td>6.00 </td>
                                <td>0.20 </td>
                                <td>6.40</td>
                                <td>2.05</td>
                                <td>44.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>12(6AWG)</td>
                                <td>74x0.45</td>
                                <td>4.50</td>
                                <td>1.10</td>
                                <td>6.70 </td>
                                <td>0.20 </td>
                                <td>7.10</td>
                                <td>1.65</td>
                                <td>75.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>14(6AWG)</td>
                                <td>85x0.45</td>
                                <td>5.20</td>
                                <td>1.10</td>
                                <td>7.40 </td>
                                <td>0.20 </td>
                                <td>7.80</td>
                                <td>1.39</td>
                                <td>88.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>16(5AWG)</td>
                                <td>100x0.45</td>
                                <td>5.20</td>
                                <td>1.20</td>
                                <td>7.60 </td>
                                <td>0.20 </td>
                                <td>8.00</td>
                                <td>1.12</td>
                                <td>95.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>22(4AWG)</td>
                                <td>135x0.45</td>
                                <td>7.00</td>
                                <td>1.35</td>
                                <td>9.70</td>
                                <td>0.50 </td>
                                <td>10.70</td>
                                <td>0.892</td>
                                <td>115.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>25(4AWG)</td>
                                <td>150x0.45</td>
                                <td>7.50</td>
                                <td>1.35</td>
                                <td>10.20</td>
                                <td>0.50 </td>
                                <td>11.20</td>
                                <td>0.85</td>
                                <td>124.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>35(2AWG)</td>
                                <td>230x0.45</td>
                                <td>8.90</td>
                                <td>1.35</td>
                                <td>11.60 </td>
                                <td>0.50 </td>
                                <td>12.60</td>
                                <td>0.561</td>
                                <td>153.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>38(2AWG)</td>
                                <td>235x0.45</td>
                                <td>9.20</td>
                                <td>1.35</td>
                                <td>11.90 </td>
                                <td>0.50 </td>
                                <td>12.90</td>
                                <td>0.525</td>
                                <td>162.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>50(1/0AWG)</td>
                                <td>7x43x0.45</td>
                                <td>10.70</td>
                                <td>1.80</td>
                                <td>14.30 </td>
                                <td>0.50 </td>
                                <td>15.30</td>
                                <td>0.411</td>
                                <td>192.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>60(2/0AWG)</td>
                                <td>19x20x0.45</td>
                                <td>11.60</td>
                                <td>1.80</td>
                                <td>15.20 </td>
                                <td>0.50 </td>
                                <td>16.20</td>
                                <td>0.329</td>
                                <td>217.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>80(3/0AWG)</td>
                                <td>19x27x0.45</td>
                                <td>13.50</td>
                                <td>1.80</td>
                                <td>17.10 </td>
                                <td>0.50 </td>
                                <td>18.10</td>
                                <td>0.243</td>
                                <td>257.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>100(4/0AWG)</td>
                                <td>19x34x0.45</td>
                                <td>15.20</td>
                                <td>2.20</td>
                                <td>19.60 </td>
                                <td>0.50 </td>
                                <td>20.60</td>
                                <td>0.193</td>
                                <td>298.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>125(4/0AWG)</td>
                                <td>19x42x0.45</td>
                                <td>15.80</td>
                                <td>2.60</td>
                                <td>21.00 </td>
                                <td>0.80 </td>
                                <td>22.60</td>
                                <td>0.156</td>
                                <td>347.0</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td colspan="10" class="text-left text-lg-center">最大平方數: 250mm² 耐熱電纜線</td>
                            </tr>
                        </table>
                    </div>
                </div>
            </article>
        </section>
    </div>
</asp:Content>

