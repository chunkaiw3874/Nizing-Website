<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="multi-furnace-temperature-control-dual-shielded-cable.aspx.cs" Inherits="application_multi_furnace_temperature_control_dual_shielded_cable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title><%if (RouteData.Values["language"].ToString() == "zh")
               {%>
                                                多爐溫控系統雙層屏蔽線-日進電線
                                                <%}
                                                    else
                                                    {%>
                                                 Multi Furnace Temperature Control Dual Shielded Cable - Nizing Electric Wire & Cable
                                            <%}%></title>
    <meta name="description" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "為工業機器量身訂做的溫控線，可運用在大型高溫爐的多爐溫控，高溫爐對於溫度控制相對嚴格，如有差池對產品質量會有很大影響，機器設備本身的溫度也會間接影響其機器壽命長度，所以數據精準的回饋相當的重要，此線材特別針對每對電熱偶進行單獨包覆隔離網，並在整體外層增加多重防雜訊隔離，雙層屏蔽的保護之下，可更加有效的阻止外部電磁雜訊的干擾並保持傳輸網絡信號數據的精準回饋。"
                                                <%}
        else
        {%>
                                                 "Designed specifically for industrial machines, this temperature control cable is extremely sensitive to temperature, making it ideal for monitoring large industrial furnaces, whose product quality depends largely on the micro-management of its temperature output. This cable provides individual insulation for each thermocouple pair, along with extra noise cancellation insulations over the entire cable, making it extremely resistant to noise, and allows precise data feedback in a timely manner."
                                            <%}%> />
    <meta property="og:type" content="article" />
    <meta property="og:title" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "多爐溫控系統雙層屏蔽線-日進電線"
                                                <%}
        else
        {%>
                                                 "Multi Furnace Temperature Control Dual Shielded Cable - Nizing Electric Wire & Cable"
                                            <%}%> />
    <meta property="og:description" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "為工業機器量身訂做的溫控線，可運用在大型高溫爐的多爐溫控，高溫爐對於溫度控制相對嚴格，如有差池對產品質量會有很大影響，機器設備本身的溫度也會間接影響其機器壽命長度，所以數據精準的回饋相當的重要，此線材特別針對每對電熱偶進行單獨包覆隔離網，並在整體外層增加多重防雜訊隔離，雙層屏蔽的保護之下，可更加有效的阻止外部電磁雜訊的干擾並保持傳輸網絡信號數據的精準回饋。"
                                                <%}
        else
        {%>
                                                 "Designed specifically for industrial machines, this temperature control cable is extremely sensitive to temperature, making it ideal for monitoring large industrial furnaces, whose product quality depends largely on the micro-management of its temperature output. This cable provides individual insulation for each thermocouple pair, along with extra noise cancellation insulations over the entire cable, making it extremely resistant to noise, and allows precise data feedback in a timely manner."
                                            <%}%> />
    <meta property="og:image" content="https://www.nizing.com.tw/images/application/products/multi-furnace-temperature-control-dual-shielded-cable/impression/multi-furnace-temperature-control-dual-shielded-cable-02-mobile.jpg" />
    <meta property="og:url" content="https://www.nizing.com.tw/<%=RouteData.Values["language"].ToString() %>/application/temperature-control-system/multi-furnace-temperature-control-dual-shielded-cable" />
    <meta property="og:site_name" content="Nizing Electric Wire and Cable" />
    <style type="text/css">
        .breadcrumb {
            display: none;
        }

        .content-wrapper {
            position: relative;
        }

        .row {
            margin: 0;
        }

        img {
            object-fit: cover;
        }

        .webp .bg-wrapper {
            background: url("/images/application/products/multi-furnace-temperature-control-dual-shielded-cable/impression/multi-furnace-temperature-control-dual-shielded-cable-bg.webp") no-repeat top / cover;
        }

        .no-webp .bg-wrapper {
            background: url("/images/application/products/multi-furnace-temperature-control-dual-shielded-cable/impression/multi-furnace-temperature-control-dual-shielded-cable-bg.jpg") no-repeat top / cover;
        }

        .bg-color {
            background-color: #000000 !important;
        }

        .text-section {
            margin: 80px 0 40px 0;
            font-weight: bold;
        }

            .text-section .text-title {
                color: #FFF000;
                line-height: 1.3;
                padding: 20px 0;
                width: 69%;
            }

        .zh .text-section .text-title {
            font-size: 54px;
        }

        .en .text-section .text-title {
            font-size: 34px;
        }

        .text-section .text-subtitle {
            display: block;
            padding: 0 1.5rem;
            color: #ffffff;
            background-color: #036eb7;
            width: 51%;
        }

        .zh .text-section .text-subtitle {
            font-size: 28px;
        }

        .en .text-section .text-subtitle {
            font-size: 22px;
        }

        .text-section .text-content {
            font-size: 20px;
            color: #ffffff;
            padding-bottom: 24px;
        }

        .zh .text-section .text-content {
            font-size: 20px;
        }

        .en .text-section .text-content {
            font-size: 20px;
        }

        .text-section .text-image {
            width: 70%;
            margin: 0 auto;
        }

        .text-shadow {
            text-shadow: 1px 1px 15px #000000, 2px 2px 30px #000000
        }

        @media all and (max-width:1199px) {
            .text-section {
                margin-top: 60px;
            }

                .text-section .text-title {
                    padding-top: 14px;
                    padding-bottom: 14px;
                }

            .zh .text-section .text-title {
                font-size: 42px;
            }

            .en .text-section .text-title {
                font-size: 28px;
            }

            .zh .text-section .text-subtitle {
                font-size: 22px;
            }

            .en .text-section .text-subtitle {
                font-size: 19px;
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
        }

        @media all and (max-width:991px) {
            .text-section {
                margin-top: 40px;
            }

            .zh .text-section .text-title {
                font-size: 36px;
            }

            .en .text-section .text-title {
                font-size: 20px;
            }

            .zh .text-section .text-subtitle {
                font-size: 18px;
            }

            .en .text-section .text-subtitle {
                font-size: 13px;
            }

            .zh .text-section .text-content {
                font-size: 16px;
            }

            .en .text-section .text-content {
                font-size: 12px;
            }
        }

        @media all and (max-width:767px) {
            .webp .bg-wrapper {
                background: none;
            }

            .no-webp .bg-wrapper {
                background: none;
            }

            .text-section {
                margin: -250px 0 0 0;
            }

                .text-section .text-title {
                    padding: 40px 0;
                    width: 90%;
                }

            .zh .text-section .text-title {
                font-size: 49px;
            }

            .en .text-section .text-title {
                font-size: 31px;
            }

            .text-section .text-subtitle {
                width: 70%;
            }

            .zh .text-section .text-subtitle {
                font-size: 24px;
            }

            .en .text-section .text-subtitle {
                font-size: 23px;
            }

            .zh .text-section .text-content {
                font-size: 16px;
            }

            .en .text-section .text-content {
                font-size: 16px;
            }

            .text-image {
                padding-bottom: 40px;
            }
        }

        @media all and (max-width:575px) {
            .text-section {
                margin-top: -180px;
            }

                .text-section .text-title {
                    padding: 20px 0;
                }

            .zh .text-section .text-title {
                font-size: 31px;
            }

            .en .text-section .text-title {
                font-size: 19px;
            }

            .zh .text-section .text-subtitle {
                font-size: 15px;
            }

            .en .text-section .text-subtitle {
                font-size: 13px;
            }

            .zh .text-section .text-content {
                font-size: 14px;
            }

            .en .text-section .text-content {
                font-size: 12px;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="container-fluid bg-wrapper bg-color <%=RouteData.Values["language"].ToString() %>">
        <div class="content-wrapper">
            <div class="d-md-none">
                <picture>
                    <source srcset="/images/application/products/multi-furnace-temperature-control-dual-shielded-cable/impression/multi-furnace-temperature-control-dual-shielded-cable-01-mobile.webp"
                        type="image/webp" />
                    <img src="/images/application/products/multi-furnace-temperature-control-dual-shielded-cable/impression/multi-furnace-temperature-control-dual-shielded-cable-01-mobile.jpg"
                        alt="多爐溫控系統雙層屏蔽線 Multi-Furnace Temperature Control Dual Shielded Cable" />
                </picture>
            </div>
            <div class="container-md">
                <div class="row">
                    <div class="col-md-8">
                        <div class="text-section">
                            <div class="text-subtitle">
                                <%if (RouteData.Values["language"].ToString() == "zh")
                                    {%>
                                                工業用大型高溫爐溫控線
                                                <%}
                                                    else
                                                    {%>
                                                 Industrial Furnace Temperature Control Cable
                                            <%}%>
                            </div>
                            <div class="text-title text-shadow">
                                <%if (RouteData.Values["language"].ToString() == "zh")
                                    {%>                                                
                                                    雙層屏蔽多爐溫控線<br />
                                                    掌控溫度的核心靈魂
                                                <%}
                                                    else
                                                    {%>
                                                 Dual Noise Cancellation Cable<br />
                                                 Heart Of Temperature Control
                                            <%}%>
                            </div>
                            <div class="text-content text-shadow">
                                <%if (RouteData.Values["language"].ToString() == "zh")
                                    {%>
                                                為工業機器量身訂做的溫控線，可運用在大型高溫爐的多爐溫控，高溫爐對於溫度控制相對嚴格，如有差池對產品質量會有很大影響，機器設備本身的溫度也會間接影響其機器壽命長度，所以數據精準的回饋相當的重要，此線材特別針對每對電熱偶進行單獨包覆隔離網，並在整體外層增加多重防雜訊隔離，雙層屏蔽的保護之下，可更加有效的阻止外部電磁雜訊的干擾並保持傳輸網絡信號數據的精準回饋。
                                                <%}
                                                    else
                                                    {%>
                                                Designed specifically for industrial machines, this temperature control cable is extremely sensitive to temperature, making it ideal for monitoring large industrial furnaces, whose product quality depends largely on the micro-management of its temperature output. This cable provides individual insulation for each thermocouple pair, along with extra noise cancellation insulations over the entire cable, making it extremely resistant to noise, and allows precise data feedback in a timely manner.
                                            <%}%>
                            </div>
                            <div class="d-none d-md-flex justify-content-center text-image">
                                <picture>
                                    <img src="/images/application/products/multi-furnace-temperature-control-dual-shielded-cable/impression/multi-furnace-temperature-control-dual-shielded-cable-02-<%=RouteData.Values["language"].ToString() %>.svg"
                                        alt="多爐溫控系統雙層屏蔽線結構 Multi-Furnace Temperature Control Dual Shielded Cable Structure" class="mx-auto" />
                                </picture>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 d-none d-md-flex align-items-end">
                        <picture>
                            <source srcset="/images/application/products/multi-furnace-temperature-control-dual-shielded-cable/impression/multi-furnace-temperature-control-dual-shielded-cable-01.webp"
                                type="image/webp" />
                            <img src="/images/application/products/multi-furnace-temperature-control-dual-shielded-cable/impression/multi-furnace-temperature-control-dual-shielded-cable-01.png"
                                alt="多爐溫控系統雙層屏蔽線 Multi-Furnace Temperature Control Dual Shielded Cable" />
                        </picture>
                    </div>
                </div>
            </div>

            <div class="d-block d-md-none">
                <picture>
                    <source srcset="/images/application/products/multi-furnace-temperature-control-dual-shielded-cable/impression/multi-furnace-temperature-control-dual-shielded-cable-02-mobile.webp"
                        type="image/webp" />
                    <img src="/images/application/products/multi-furnace-temperature-control-dual-shielded-cable/impression/multi-furnace-temperature-control-dual-shielded-cable-02-mobile.png"
                        alt="多爐溫控系統雙層屏蔽線 Multi-Furnace Temperature Control Dual Shielded Cable" />
                </picture>
            </div>
            <div class="container d-md-none">
                <div class="d-flex justify-content-center text-image">
                    <picture>
                        <img src="/images/application/products/multi-furnace-temperature-control-dual-shielded-cable/impression/multi-furnace-temperature-control-dual-shielded-cable-02-<%=RouteData.Values["language"].ToString() %>.svg"
                            alt="多爐溫控系統雙層屏蔽線結構 Multi-Furnace Temperature Control Dual Shielded Cable Structure" class="mx-auto" />
                    </picture>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

