<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDMaterialMaster.master" AutoEventWireup="true" CodeFile="thermoplastic-elastomer.aspx.cs" Inherits="thermoplastic_elastomer" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <title>熱可塑性彈性體特性-日進電線 <%=DateTime.Now.Year.ToString() %></title>
    <meta name="keywords" content="電線,外被,熱可塑性彈性體,Wire,Insulation Material,TPE" />

    <style type="text/css">
        .content .content-title {
            font-size: 1.3rem;
            margin-bottom: 10px;
        }

            .content .content-title .square-blue {
                display: inline-block;
                width: 1rem;
                height: 1rem;
                background-color: skyblue;
            }

        .content .content-body {
            padding-left: 22px;
            margin-bottom: 10px;
        }

        .zh .content .content-body {
            text-align: justify;
        }

        @media all and (max-width:767px) {
            .display-block .content {
                padding-bottom: 0;
            }

            .content .content-title {
                font-size: 16px;
            }

            .content .content-body {
                font-size: 14px;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="banner" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <picture>
                <source srcset="/images/material/thermoplastic-elastomer/banner-tpe.webp"
                    type="image/webp" />
                <img src="/images/material/thermoplastic-elastomer/banner-tpe.jpg"
                    alt="熱可塑性彈性體 Thermoplastic Elastomer TPE" />
            </picture>
        </div>
    </div>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper material-item <%=RouteData.Values["language"].ToString() %>">
        <div class="container">
            <div class="display-block">
                <div class="title">
                    熱可塑性彈性體(TPE)
                </div>
                <div class="subtitle">
                    Thermoplastic Elastomer
                </div>
                <div class="content">
                    <div class="content-title">
                        <div class="square-blue"></div>
                        熱可塑性彈性體(TPE)是什麼?
                    </div>
                    <div class="content-body">
                        Thermoplastic Elastomer 簡稱 TPE ，係指在常溫下具有加硫橡膠性質，在高溫下又可以塑性變形，可用塑膠成型設備來加工成型的高分子材料，有時候也常被稱為TPR 。
                    </div>
                    <div class="content-title">
                        <div class="square-blue"></div>
                        熱熱塑性彈性體(TPE)有哪些優勢？
                    </div>
                    <div class="content-body">
                        1. 可用一般的熱塑性塑料成型機加工，不需要特殊的加工設備。<br />
                        2. 生產效率大幅提高，可直接用橡膠注塑機硫化。<br />
                        3. 易於回收利用，降低成本，生產過程中產生的廢料可直接再利用。<br />
                        4. 熱塑性彈性體大多不需要硫化或硫化時間很短，可以有效節約能源。<br />
                        5. 由於TPE兼具橡膠和塑料的優點，為橡膠工業開闢了更廣領域。<br />
                        6. 可用於幫助塑膠材料的增強，增韌改質。
                    </div>
                    <div class="content-title">
                        <div class="square-blue"></div>
                        TPE與熱固性彈性體的差異
                    </div>
                    <div class="content-body">
                        TPE 熱可塑性彈性體：<br />
                        優點：具熱可塑性、加工成本低、 次料可完全回收 、環保訴求佳。<br />
                        缺點：耐溶劑性不佳、壓縮變形率高、通常不耐高溫 ( 120°C以上 )<br />
                        <br />
                        Rubber 熱固性彈性體：<br />
                        優點：耐溶劑性佳、優秀的永久壓縮歪、耐高溫特性佳、重複耐疲勞度優。<br />
                        缺點：加工時間長、 次料無法回收 、生產氣味不佳、環保疑慮高。
                    </div>
                    <div class="content-title">
                        <div class="square-blue"></div>
                        常見的熱塑性彈性體(TPE)可分為哪些種類？
                    </div>
                    <div class="content-body">
                        ◆ TPU（熱可塑性聚氨基甲酸酯彈性體）<br />
                        ◆ TPO（熱可塑聚烯烴彈性體）<br />
                        ◆ TPV（熱可塑聚烯烴動態加硫彈性體）<br />
                        ◆ TPS / TPR （熱可塑苯乙烯系彈性體）<br />
                        ◆ TPEE（熱可塑聚醚酯彈性體）<br />
                        ◆ TPA（聚醯胺系彈性體）
                    </div>
                    <div class="table-responsive">
                        <img src="/images/material/thermoplastic-elastomer/spec/tpe sheet-01.svg" />
                    </div>
                    <div class="content-title pt-3">
                        <div class="square-blue"></div>
                        UL規格_無鹵防火規格TPE
                    </div>
                    <div class="content-body">
                        UL規格無鹵阻燃熱塑性彈性體(TPE)，通過UL防火安全檢測，滿足最嚴格的難燃以及燃燒熄滅試驗的複合式高性能TPE。與一般的TPE 規格主要差異在於UL規格系列含有阻燃添加劑，使其具有優秀的耐燃特性。全系列規格無氯、無多溴聯苯醚、低煙無鹵特性，符合有害物質Rohs 指令並提供良好的阻燃效果。
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

