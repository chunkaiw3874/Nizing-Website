<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="heating-wire-series.aspx.cs" Inherits="heating_wire_series" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <title>發熱線、醫療器材配線-日進電線</title>
    <meta name="keywords" content="發熱線,並聯式發熱帶,醫療呼吸管" />
    <meta name="description" content="各式發熱線材，包含醫療呼吸管使用的UL3589，以及為表層加溫的PHC並聯式電熱帶、及其他各類常規及訂製線材">

    <style type="text/css">
        .product-category .product-list-item img {
            width: 100%;
            /*max-height: 240px;*/
            object-fit: contain;
        }



        @media all and (max-width: 576px) {
            
        }
    </style>
</asp:Content>
<asp:Content ID="banner" ContentPlaceHolderID="banner" runat="server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-product-en.png"
                alt="發熱線 並聯式發熱帶 醫療呼吸管 Heating Wire Heat Parallel Heating Cable Medical Heating Pipe" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper product-category">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    發熱線系列
                </div>
                <div class="subtitle">
                    Heating Wire Series
                </div>
            </div>
            <div class="container-fluid">
                <div class="content container">
                    <div class="row row-cols-2 row-cols-md-3 row-cols-lg-4 product-list">
                        <div class="col product-list-item">
                            <a href="ul3589.aspx">
                                <div class="card">
                                    <div class="hot-item d-none">
                                        <img src="images/product_pic/hot-icon.png" />
                                    </div>
                                    <%--<img src="images/product_pic/heating-wire/heating-wire.png" class="w-100" />--%>
                                    <div class="card-body">
                                        <div class="card-title">
                                            <span>UL3589/UL3323</span>
                                        </div>
                                        <div class="card-text-wrapper">
                                            <div class="card-text">
                                                <div>電阻: 0~5000Ω</div>
                                                <div>耐溫: -60~200C</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="col product-list-item">
                            <a href="phc.aspx">
                                <div class="card">
                                    <div class="hot-item d-none">
                                        <img src="images/product_pic/hot-icon.png" />
                                    </div>
                                    <%--<img src="images/product_pic/heating-wire/parallel-heating-cable.jpg" class="w-100" />--%>
                                    <div class="card-body">
                                        <div class="card-title">
                                            <span>PHC</span>
                                        </div>
                                        <div class="card-text-wrapper">
                                            <div class="card-text">
                                                <div>耐溫: -60~200C</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="col product-list-item">
                            <a href="respiration-pipe-heating-wire.aspx">
                                <div class="card">
                                    <div class="hot-item">
                                        <img src="images/product_pic/hot-icon.png" />
                                    </div>
                                    <%--<img src="images/product_pic/heating-wire/respiratory-pipe-heating-wire.png" class="w-100" />--%>
                                    <div class="card-body">
                                        <div class="card-title">
                                            <span>醫療呼吸管加熱線</span>
                                        </div>
                                        <div class="card-text-wrapper">
                                            <div class="card-text">
                                                <div>電阻: 3Ω/M</div>
                                                <div>耐溫: 80C</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

