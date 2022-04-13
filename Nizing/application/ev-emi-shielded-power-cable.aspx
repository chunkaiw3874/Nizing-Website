<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="ev-emi-shielded-power-cable.aspx.cs" Inherits="application_ev_emi_shielded_power_cable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>
        <%if (RouteData.Values["language"].ToString() == "zh")
            {%>
                                                EV高溫高壓隔離型電纜-日進電線 <%=DateTime.Now.Year.ToString() %>
        <%}
            else
            {%>
                                                Electric Vehicle EMI Shielded Power Cable - Nizing Electric Wire & Cable <%=DateTime.Now.Year.ToString() %>
        <%}%>
    </title>
        <meta name="description" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "電動汽車的發展已經成為汽車產業發展的趨勢及業界的共識。成就一輛電動汽車的，必然是它的三電系統，一套優秀的三電系統需要有高集成度、高安全性、高效率，要對極端氣候環境有良好的適應能力，同時還要有良好的動力表現，其水平的高低決定著一輛電動汽車的基本性能，且大功率電動汽車對更高電壓的應用需求大幅成長。為滿足電動車的【三電的配置】 設計與需求，[電源/電池系統]、[電驅系統] 及 [電控系統]共稱電動車「三電」系統，為決定電動車性能關鍵要素。日進電線提供可應用的電纜應用方案 ( UL3512 / UL3641 / UL3644 / UL4476 )，以矽橡膠SILICONE RUBBER作為EV高溫高壓隔離型電纜。"
                                                <%}
        else
        {%>
                                                "Electric vehicle is gradually replacing the traditional petro fueled vehicles, taking up a significant portion of the automobile market. The success of the electric vehicle is attributed to its excellent performance, stability, and versatility, which can only be achieved with the most reliable cable and wire. Nizing Electric Wire and Cable provides the best solution for electric vehicles with UL3512 / UL3641 / UL3644 / UL4476, which use silicone rubber as insulation material, and allows customization of inner insulations for wider range of applications."
                                            <%}%> />
    <meta property="og:type" content="article" />
        <meta property="og:title" content=
        <%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "EV高溫高壓隔離型電纜-日進電線 <%=DateTime.Now.Year.ToString() %>"
                                                <%}
        else
        {%>
                                                "Electric Vehicle EMI Shielded Power Cable - Nizing Electric Wire & Cable <%=DateTime.Now.Year.ToString() %>"
                                            <%}%> />
        <meta property="og:description" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "電動汽車的發展已經成為汽車產業發展的趨勢及業界的共識。成就一輛電動汽車的，必然是它的三電系統，一套優秀的三電系統需要有高集成度、高安全性、高效率，要對極端氣候環境有良好的適應能力，同時還要有良好的動力表現，其水平的高低決定著一輛電動汽車的基本性能，且大功率電動汽車對更高電壓的應用需求大幅成長。為滿足電動車的【三電的配置】 設計與需求，[電源/電池系統]、[電驅系統] 及 [電控系統]共稱電動車「三電」系統，為決定電動車性能關鍵要素。日進電線提供可應用的電纜應用方案 ( UL3512 / UL3641 / UL3644 / UL4476 )，以矽橡膠SILICONE RUBBER作為EV高溫高壓隔離型電纜。"
                                                <%}
        else
        {%>
                                                "Electric vehicle is gradually replacing the traditional petro fueled vehicles, taking up a significant portion of the automobile market. The success of the electric vehicle is attributed to its excellent performance, stability, and versatility, which can only be achieved with the most reliable cable and wire. Nizing Electric Wire and Cable provides the best solution for electric vehicles with UL3512 / UL3641 / UL3644 / UL4476, which use silicone rubber as insulation material, and allows customization of inner insulations for wider range of applications."
                                            <%}%> />
    <meta property="og:image" content="https://www.nizing.com.tw/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-01-en.jpg" />
    <meta property="og:url" content="https://www.nizing.com.tw/<%=RouteData.Values["language"].ToString() %>/application/automobile/ev-emi-shielded-power-cable" />
    <meta property="og:site_name" content="Nizing Electric Wire and Cable" />
    <style type="text/css">
        .color-bright-orange {
            color: #f15a24 !important;
        }

        .color-peach {
            color: #d4145a !important;
        }

        .color-red {
            color: #c1272d !important;
        }

        .breadcrumb {
            display: none;
        }

        .content-wrapper {
            position: relative;
        }

        img {
            object-fit: cover;
        }

        .bg-color {
            background-color: #ffffff !important;
        }

        .text-section {
            font-weight: 600;
            margin-bottom: 20px;
        }

            .text-section .text-title {
                color: #0071bc;
                padding-bottom: 20px;
            }

        .zh .text-section .text-title {
            font-size: 20px;
        }

        .en .text-section .text-title {
            font-size: 30px;
        }

        .text-section .text-content {
            padding-bottom: 20px;
        }

        .zh .text-section .text-content {
            font-size: 16px;
        }

        .en .text-section .text-content {
            font-size: 16px;
        }

        .text-section .text-subcontent {
            background-color: #e6e6e6;
            text-align: center;
            margin-bottom: 20px;
            padding: 5px;
        }

        .zh .text-section .text-subcontent {
            font-size: 14px;
            line-height: 26px;
        }

        .en .text-section .text-subcontent {
        }

        .text-section .text-image {
            padding-bottom: 20px;
        }

        @media all and (min-width:576px) {
            .text-section {
                margin-bottom: 20px;
            }

                .text-section .text-title {
                    padding-bottom: 20px;
                }

            .zh .text-section .text-title {
                font-size: 22px;
            }

            .en .text-section .text-title {
                font-size: 30px;
            }

            .text-section .text-content {
                padding-bottom: 20px;
            }

            .zh .text-section .text-content {
                font-size: 18px;
            }

            .en .text-section .text-content {
                font-size: 16px;
            }

            .text-section .text-subcontent {
                margin-bottom: 20px;
            }

            .zh .text-section .text-subcontent {
                font-size: 16px;
                line-height: 28px;
            }

            .en .text-section .text-subcontent {
            }

            .text-section .text-image {
                padding-bottom: 20px;
            }
        }

        @media all and (min-width:768px) {
            .text-section {
                margin-bottom: 20px;
            }

                .text-section .text-title {
                    padding-bottom: 20px;
                }

            .zh .text-section .text-title {
                font-size: 22px;
            }

            .en .text-section .text-title {
                font-size: 30px;
            }

            .text-section .text-content {
                padding-bottom: 20px;
            }

            .zh .text-section .text-content {
                font-size: 18px;
            }

            .en .text-section .text-content {
                font-size: 16px;
            }

            .text-section .text-subcontent {
                margin-bottom: 20px;
            }

            .zh .text-section .text-subcontent {
                font-size: 16px;
                line-height: 28px;
            }

            .en .text-section .text-subcontent {
            }

            .text-section .text-image {
                padding-bottom: 20px;
            }
        }

        @media all and (min-width:992px) {
            .text-section {
                margin-bottom: 20px;
            }

                .text-section .text-title {
                    padding-bottom: 20px;
                }

            .zh .text-section .text-title {
                font-size: 28px;
            }

            .en .text-section .text-title {
                font-size: 30px;
            }

            .text-section .text-content {
                padding-bottom: 20px;
            }

            .zh .text-section .text-content {
                font-size: 22px;
            }

            .en .text-section .text-content {
                font-size: 16px;
            }

            .text-section .text-subcontent {
                margin-bottom: 20px;
            }

            .zh .text-section .text-subcontent {
                font-size: 20px;
                line-height: 32px;
            }

            .en .text-section .text-subcontent {
            }

            .text-section .text-image {
                padding-bottom: 20px;
            }
        }

        @media all and (min-width:1200px) {
            .text-section {
                margin-bottom: 20px;
            }

                .text-section .text-title {
                    padding-bottom: 20px;
                }

            .zh .text-section .text-title {
                font-size: 32px;
            }

            .en .text-section .text-title {
                font-size: 30px;
            }

            .text-section .text-content {
                padding-bottom: 20px;
            }

            .zh .text-section .text-content {
                font-size: 26px;
            }

            .en .text-section .text-content {
                font-size: 16px;
            }

            .text-section .text-subcontent {
                margin-bottom: 20px;
            }

            .zh .text-section .text-subcontent {
                font-size: 24px;
                line-height: 36px;
            }

            .en .text-section .text-subcontent {
            }

            .text-section .text-image {
                padding-bottom: 20px;
            }
        }

        @media all and (min-width:1424px) {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="container-fluid bg-color <%=RouteData.Values["language"].ToString() %>">
        <div class="content-wrapper">
            <div class="text-section">
                <div class="text-image container-fluid container-lg">
                    <picture>
                        <source srcset="/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-01-<%=RouteData.Values["language"].ToString() %>.webp"
                            type="image/webp" />
                        <img src="/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-01-<%=RouteData.Values["language"].ToString() %>.jpg"
                            alt="EV高溫高壓隔離型電纜 Electric Vehicle EMI Shielded Power Cable" />
                    </picture>
                </div>
                <div class="container">
                    <div class="text-content">
                        <%if (RouteData.Values["language"].ToString() == "zh")
                            {%>
                                            電動汽車的發展已經成為汽車產業發展的趨勢及業界的共識。成就一輛電動汽車的，必然是它的三電系統，一套優秀的三電系統需要有高集成度、高安全性、高效率，要對極端氣候環境有良好的適應能力，同時還要有良好的動力表現，其水平的高低決定著一輛電動汽車的基本性能，且大功率電動汽車對更高電壓的應用需求大幅成長。<br />
                        <br />
                        為滿足電動車的<span class="color-bright-orange">【三電的配置】</span> 設計與需求，<span class="color-peach">[電源/電池系統]、[電驅系統] 及 [電控系統]</span>共稱電動車「三電」系統，為決定電動車性能關鍵要素。<br />
                        日進電線提供可應用的電纜應用方案 ( UL3512 / UL3641 / UL3644 / UL4476 )，以矽橡膠SILICONE RUBBER作為EV高溫高壓隔離型電纜。
                                            <%}
                                                else
                                                {%>
                        Electric vehicle is gradually replacing the traditional petro fueled vehicles, taking up a significant portion of the automobile market. The success of the electric vehicle is attributed to its excellent performance, stability, and versatility, which can only be achieved with the most reliable cable and wire.<br />
                        <br />
                        Nizing Electric Wire and Cable provides the best solution for electric vehicles with UL3512 / UL3641 / UL3644 / UL4476, which use silicone rubber as insulation material, and allows customization of inner insulations for wider range of applications.
                        <%}%>
                    </div>
                    <div class="text-image">
                        <a href="/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-02.jpg"
                            target="_blank">
                            <picture>
                                <source srcset="/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-02.webp"
                                    type="image/webp" />
                                <img src="/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-02.jpg"
                                    alt="EV高溫高壓隔離型電纜結構 Electric Vehicle EMI Shielded Power Cable Structure" />
                            </picture>
                        </a>
                    </div>
                    <div class="text-title">
                        <%if (RouteData.Values["language"].ToString() == "zh")
                            {%>
                                            ◆QC/T1037-2016針對電纜要點如下:
                                            <%}
                                                else
                                                {%>
                        ◆QC/T1037-2016 Cable Restriction:
                        <%}%>
                    </div>
                    <div class="text-content">
                        <%if (RouteData.Values["language"].ToString() == "zh")
                            {%>
                                                1、絕緣檢查電壓AC 900V/DC 1500V，測試電壓為10KV。<br />
                        2、電線外層限用<span class="color-bright-orange">鮮豔橙色</span> ORANGE。<br />
                        3、耐磨要求規定最小往復次數1000-1500次。<br />
                        4、耐化學試劑浸漬時間為10秒,蝕性強的如汽油、柴油單次浸漬後熱老化240H，弱腐蝕性液體如冷液、玻璃水則分4次浸漬,熱老化3000H，然後進行卷繞和絕緣測試。<br />
                        5、阻燃要求，延燃燒試驗熄時求小於30秒。
                                                <%}
                                                    else
                                                    {%>
                        1. Inspection voltage for AC 900V/DC 1500V is 10KV<br />
                        2. Only use <span class="color-bright-orange">bright orange</span> on the outer layer of the wire.<br />
                        3. Abrasion resistance requires the minimum number of reciprocating movements to be specified as 1000-1500 times.<br />
                        4. The impregnation time of chemical resistant reagent is changed to 10 seconds. Corrosive gases such as gasoline and diesel will undergo 240H thermal aging after soaking for one hour. Immerse weakly corrosive liquids (such as coolant and glass water) 4 times and heat aging 3000H, then perform winding and insulation test.<br />
                        5. The self-extinguishing time of the extended combustion test should be less than 30 seconds.
                        <%}%>
                    </div>
                    <div class="text-subcontent">
                        <%if (RouteData.Values["language"].ToString() == "zh")
                            {%>
                                                參考標準QC/T1037-2016《道路車輛用高壓電》:<br />
                        額定電壓AC 1000V/DC 1500V以上之道路輛用高壓電纜要求、試驗方法與檢驗規定。<br />
                        (額定電壓AC 1000V/DC 1500V以下歸類於GB/T1838.1-2015 電動汽車的電壓別-B級)<br />
                        <%}
                            else
                            {%>
                        Reference Standard QC/T1037-2016:<br />
                        Nominal Voltage AC 1000V/DC 1500V and above high voltage cable requirement, test methods, and inspection rules.<br />
                        (Nominal Voltage that is lower than AC 1000V/DC 1500V belongs to GT/T1838.1-2015)
                        <%}%>
                    </div>
                    <div class="text-title">
                        <%if (RouteData.Values["language"].ToString() == "zh")
                            {%>
                                                ◆道路車輛用高壓電纜（QC/T1037-2016 標準）簡介：
                                                <%}
                                                    else
                                                    {%>
                        ◆High Voltage Cables for Road Vehicles (QC/T1037-2016) introduction:
                        <%}%>
                    </div>
                    <div class="text-content">
                        <%if (RouteData.Values["language"].ToString() == "zh")
                            {%>
                                                電動汽車高壓線是用於連接充電口與電池、電池內部、電池與發動機及其他元器件以及電池儲能設備等領域，作為電力傳輸的載體。由於車內應用環境惡劣，電動汽車高壓線有著非常高的性能要求。
                                                <%}
                                                    else
                                                    {%>
                        Electric vehicle high voltage cable is used in recharge port, battery, ignition, and other components, as carrier of electric current. Due to the harsh and volatile application environment of vehicles, electric vehicle high voltage cable is expected to have great performance.
                        <%}%>
                    </div>
                    <div class="text-title">
                        <%if (RouteData.Values["language"].ToString() == "zh")
                            {%>
                                                ◆運用在新能源電動車內電纜配置：
                                                <%}
                                                    else
                                                    {%>

                        <%}%>
                    </div>
                    <div class="text-image">
                        <a href="/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-03-<%=RouteData.Values["language"].ToString() %>.jpg"
                            target="_blank">
                            <picture>
                                <source srcset="/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-03-<%=RouteData.Values["language"].ToString() %>.webp"
                                    type="image/webp" />
                                <img src="/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-03-<%=RouteData.Values["language"].ToString() %>.jpg"
                                    alt="EV車內電纜配置 Electric Vehicle Cable Usage" />
                            </picture>
                        </a>
                    </div>
                    <div class="text-title color-red">
                        <%if (RouteData.Values["language"].ToString() == "zh")
                            {%>
                                                ◆新能源電動車相關電纜詳細規格：
                                                <%}
                                                    else
                                                    {%>

                        <%}%>
                    </div>
                    <div class="text-link">
                        <a href="/<%=RouteData.Values["language"].ToString() %>/product/silicone-wire/ul3512">
                            <picture>
                                <source srcset="/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-btn-3512-<%=RouteData.Values["language"].ToString() %>.webp"
                                    type="image/webp" />
                                <img src="/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-btn-3512-<%=RouteData.Values["language"].ToString() %>.jpg"
                                    alt="EV高溫高壓隔離型電纜結構 Electric Vehicle EMI Shielded Power Cable" />
                            </picture>
                        </a>
                    </div>
                    <div class="text-link">
                        <a href="/<%=RouteData.Values["language"].ToString() %>/product/silicone-wire/ul3641">
                            <picture>
                                <source srcset="/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-btn-3641-<%=RouteData.Values["language"].ToString() %>.webp"
                                    type="image/webp" />
                                <img src="/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-btn-3641-<%=RouteData.Values["language"].ToString() %>.jpg"
                                    alt="EV高溫高壓隔離型電纜結構 Electric Vehicle EMI Shielded Power Cable" />
                            </picture>
                        </a>
                    </div>
                    <div class="text-link">
                        <a href="/<%=RouteData.Values["language"].ToString() %>/product/silicone-wire/ul3644">
                            <picture>
                                <source srcset="/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-btn-3644-<%=RouteData.Values["language"].ToString() %>.webp"
                                    type="image/webp" />
                                <img src="/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-btn-3644-<%=RouteData.Values["language"].ToString() %>.jpg"
                                    alt="EV高溫高壓隔離型電纜結構 Electric Vehicle EMI Shielded Power Cable" />
                            </picture>
                        </a>
                    </div>
                    <div class="text-link">
                        <a href="/<%=RouteData.Values["language"].ToString() %>/product/silicone-wire/ul4476">
                            <picture>
                                <source srcset="/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-btn-4476-<%=RouteData.Values["language"].ToString() %>.webp"
                                    type="image/webp" />
                                <img src="/images/application/products/ev-emi-shielded-power-cable/impression/ev-emi-shielded-power-cable-btn-4476-<%=RouteData.Values["language"].ToString() %>.jpg"
                                    alt="EV高溫高壓隔離型電纜結構 Electric Vehicle EMI Shielded Power Cable" />
                            </picture>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

