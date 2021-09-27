<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="thermocouple.aspx.cs" Inherits="thermocouple" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>補償導線、熱電偶-日進電線</title>
    <meta name="keywords" content="補償導線,熱電偶" />
    <meta name="description" content="各式補償導線線材，包含RTD、K-Type 補償導線、J-Type 補償導線、T-Type 補償導線、R-Type 補償導線、S-Type 補償導線、E-Type 補償導線、手持式熱電偶，為溫度測量及感應線材">

    <style type="text/css">
        .product-category .bg-wrapper {
            background-image: url('/images/product/thermocouple/background/thermocouple.jpg');
        }

/*        .display-block:nth-child(2n) {
            background-color: #ffffff;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-product-en.png"
                alt="補償導線系列 Thermocouple RTD K-Type T-Type J-Type E-Type R-Type S-Type" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper product-category">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    補償導線系列
                </div>
                <div class="subtitle">
                    Thermocouple Series
                </div>
            </div>
            <div class="container-fluid bg-wrapper">
                <div class="content container">
                    <div id="divProductList" runat="server" class="row row-cols-2 row-cols-md-3 row-cols-lg-4 product-list">
                    </div>
                </div>
            </div>
        </div>
        <div class="display-block">
            <div class="container">
                <div class="title">
                    何謂熱電偶
                </div>
                <div class="subtitle">
                    What is Thermocouple
                </div>
            </div>
            <div class="content container">
                <div class="row row-cols-1 row-cols-md-2">
                    <div>
                        把兩種不同材質之金屬導體以電器連接(焊接)，使其產生一密閉迴路，
                        在焊接點(即溫接點)加熱產生溫差，迴路中就會有電流流動，此現象稱為席貝克效應。
                        如果將另一端(基準接點或稱冷接點)的溫度保持恆溫(一般設定為0°C)，
                        則可依熱電動勢值(EMF)之大小換算出溫接點端的溫度。此兩種成對的金屬導體即稱為"熱電偶"。
                    </div>
                    <div>
                        <img src="/images/product/thermocouple/何謂熱電偶.jpg" />
                    </div>
                </div>
            </div>
        </div>
        <div class="display-block">
            <div class="container">
                <div class="title">
                    補償導線的種類
                </div>
                <div class="subtitle">
                    Thermocouple Categories
                </div>
            </div>
            <div class="content container">
                <a href="/images/product/thermocouple/補償導線的種類.jpg" target="_blank">
                    <img src="/images/product/thermocouple/補償導線的種類.jpg" />
                </a>
            </div>
        </div>
        <div class="display-block">
            <div class="container">
                <div class="title">
                    熱電動勢曲線圖
                </div>
                <div class="subtitle">
                    Thermal EMF Curve
                </div>
            </div>
            <div class="content container">
                <img src="/images/product/thermocouple/熱電偶的熱電動勢曲線圖-01.jpg" />
            </div>
        </div>
    </div>
</asp:Content>

