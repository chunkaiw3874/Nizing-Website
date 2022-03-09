<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="military-spec-signal-control-cable.aspx.cs" Inherits="application_military_spec_signal_control_cable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title><%if (RouteData.Values["language"].ToString() == "zh")
               {%>
                                                軍規訊號控制線-日進電線
                                                <%}
                                                    else
                                                    {%>
                                                Military Spec Signal Control Cable - Nizing Electric Wire & Cable
                                            <%}%></title>
    <meta name="description" content=
                            <%if (RouteData.Values["language"].ToString() == "zh")
        {%>                     
                                    "無人機應用領域由商業到軍事等各項領域越發廣泛。無人機具有高機動性、多用途、大酬載、長滯空等特性，須具備高水準的穩定性、靈活度及高效能效能，電線的選擇需耐高溫、防燙、耐油、耐腐蝕、耐磨、抗老化、低阻抗、線材柔軟且輕量化...等優點，能完全符合無人機的需求，提供航太飛航更久的續航力，快速且有效的執行每項任務，並使無人機處於危險和極端惡劣的天氣條件下能穩定正常的運作。"
                                                <%}
        else
        {%>
                                    "Real life application for drones is ever expanding. Drones possess the characteristics of high mobility, multi-purpose, heavy loading, and long air time, which requires stability, agility, and performance of the highest standard aria-invalid its components. The ideal cable for such an intricate machine needs to withstand high temperature, oil and chemical resistant, anti-aging, and highly flexible, in order to bring out the full capability of the drone."
                                            <%}%> />
    <meta property="og:type" content="article" />
    <meta property="og:title" content=
        <%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "軍規訊號控制線-日進電線"
                                                <%}
        else
        {%>
                                                "Military Spec Signal Control Cable - Nizing Electric Wire & Cable"
                                            <%}%> />
    <meta property="og:description" content=
                            <%if (RouteData.Values["language"].ToString() == "zh")
        {%>                     
                                    "無人機應用領域由商業到軍事等各項領域越發廣泛。無人機具有高機動性、多用途、大酬載、長滯空等特性，須具備高水準的穩定性、靈活度及高效能效能，電線的選擇需耐高溫、防燙、耐油、耐腐蝕、耐磨、抗老化、低阻抗、線材柔軟且輕量化...等優點，能完全符合無人機的需求，提供航太飛航更久的續航力，快速且有效的執行每項任務，並使無人機處於危險和極端惡劣的天氣條件下能穩定正常的運作。"
                                                <%}
        else
        {%>
                                    "Real life application for drones is ever expanding. Drones possess the characteristics of high mobility, multi-purpose, heavy loading, and long air time, which requires stability, agility, and performance of the highest standard aria-invalid its components. The ideal cable for such an intricate machine needs to withstand high temperature, oil and chemical resistant, anti-aging, and highly flexible, in order to bring out the full capability of the drone."
                                            <%}%> />
    <meta property="og:image" content="https://www.nizing.com.tw/images/application/products/military-spec-signal-control-cable/impression/military-spec-signal-control-cable-01-mobile.jpg" />
    <meta property="og:url" content="https://www.nizing.com.tw/<%=RouteData.Values["language"].ToString() %>/application/misc-app/military-spec-signal-control-cable" />
    <meta property="og:site_name" content="Nizing Electric Wire and Cable" />
    <style type="text/css">
        .breadcrumb {
            display: none;
        }

        .content-wrapper {
            position: relative;
            padding: 20px 0;
        }

        .row {
            margin: 0;
        }

        .col-md-6 {
            padding: 0;
        }

        img {
            object-fit: cover;
        }

        .bg-color {
            background-color: #f7f7f7 !important;
        }

        .text-section {
            margin-top: 20px;
            margin-bottom: 20px;
            font-weight: bold;
        }

            .text-section .text-title {
                color: #2d3e56;
                line-height: 1.1;
                padding: 20px 0;
                width: 90%;
            }

        .zh .text-section .text-title {
            font-size: 60px;
        }

        .en .text-section .text-title {
            font-size: 44px;
        }

        .text-section .text-content {
            color: #2d3e56;
            padding-bottom: 24px;
        }

        .zh .text-section .text-content {
            font-size: 23px;
            text-align: justify;
        }

        .en .text-section .text-content {
            font-size: 20px;
        }

        .text-section .text-image {
            width: 80%;
        }

        .text-shadow {
            text-shadow: 5px 5px 10px #000000;
        }

        .text-section .text-content-link {
            display: flex;
            justify-content: right;
            padding-top: 24px;
        }

            .text-section .text-content-link a {
                padding: 5px 20px;
                border-radius: 20px;
                font-size: 14px;
            }

                .text-section .text-content-link a:first-child {
                    margin-right: 5px;
                }

        .image-vertical-center {
            margin: auto 0;
        }

        @media all and (max-width:1423px) {
            .zh .text-section .text-title {
                font-size: 60px;
            }

            .en .text-section .text-title {
                font-size: 44px;
            }

            .zh .text-section .text-content {
                font-size: 23px;
            }

            .en .text-section .text-content {
                font-size: 20px;
            }
        }

        @media all and (max-width:1199px) {
            .content-wrapper {
                padding: 0 15px;
            }

            .zh .text-section .text-title {
                font-size: 49px;
            }

            .en .text-section .text-title {
                font-size: 38px;
            }

            .text-section .text-content {
                padding-bottom: 20px;
            }

            .zh .text-section .text-content {
                font-size: 19px;
            }

            .en .text-section .text-content {
                font-size: 17px;
            }

            .text-section .text-image {
                width: 80%;
            }
        }

        @media all and (max-width:991px) {
            .zh .text-section .text-title {
                font-size: 37px;
            }

            .en .text-section .text-title {
                font-size: 27px;
            }

            .zh .text-section .text-content {
                font-size: 14px;
            }

            .en .text-section .text-content {
                font-size: 12px;
            }

            .text-section .text-content-link a {
                font-size: 12px;
            }
        }

        @media all and (max-width:767px) {
            .content-wrapper {
                padding: 0;
            }

            .text-section {
                padding: 0 30px;
            }

                .text-section .text-title {
                    width: 100%;
                }

            .zh .text-section .text-title {
                font-size: 71px;
            }

            .en .text-section .text-title {
                font-size: 48px;
            }

            .zh .text-section .text-content {
                font-size: 27px;
            }

            .en .text-section .text-content {
                font-size: 20px;
            }

            .text-section .text-content-link {
                display: flex;
                flex-direction: column;
                width: fit-content;
                margin: auto;
            }

                .text-section .text-content-link a {
                    display: block;
                    font-size: 16px;
                    width: 100%;
                }

                    .text-section .text-content-link a:first-child {
                        margin-bottom: 10px;
                    }
        }

        @media all and (max-width:575px) {
            .zh .text-section .text-title {
                font-size: 45px;
            }

            .en .text-section .text-title {
                font-size: 30px;
            }

            .zh .text-section .text-content {
                font-size: 18px;
            }

            .en .text-section .text-content {
                font-size: 16px;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="container-fluid bg-wrapper bg-color <%=RouteData.Values["language"].ToString() %>">
        <div class="content-wrapper container-md">
            <div class="d-md-none">
                <picture>
                    <source srcset="/images/application/products/military-spec-signal-control-cable/impression/military-spec-signal-control-cable-01-mobile.webp"
                        type="image/webp" />
                    <img src="/images/application/products/military-spec-signal-control-cable/impression/military-spec-signal-control-cable-01-mobile.jpg"
                        alt="軍規訊號控制線 Military Spec Signal Control Cable" />
                </picture>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="text-section">
                        <div class="text-title">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>                     
                                    <span style="color:#e73828">無人機載具系統</span><br />
                                    <span style="color:#0d5a84">軍規訊號控制線</span>
                                                <%}
                                                    else
                                                    {%>
                                    <span style="color:#e73828">Drone Carrier System</span><br />
                                    <span style="color:#0d5a84">Signal Control Cable</span>
                                            <%}%>
                        </div>
                        <div class="text-content">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>                     
                                    無人機應用領域由商業到軍事等各項領域越發廣泛。無人機具有高機動性、多用途、大酬載、長滯空等特性，須具備高水準的穩定性、靈活度及高效能效能，電線的選擇需耐高溫、防燙、耐油、耐腐蝕、耐磨、抗老化、低阻抗、線材柔軟且輕量化...等優點，能完全符合無人機的需求，提供航太飛航更久的續航力，快速且有效的執行每項任務，並使無人機處於危險和極端惡劣的天氣條件下能穩定正常的運作。
                                                <%}
                                                    else
                                                    {%>
                                    Real life application for drones is ever expanding. Drones possess the characteristics of high mobility, multi-purpose, heavy loading, and long air time, which requires stability, agility, and performance of the highest standard aria-invalid its components. The ideal cable for such an intricate machine needs to withstand high temperature, oil and chemical resistant, anti-aging, and highly flexible, in order to bring out the full capability of the drone.
                                            <%}%>
                        </div>
                        <div class="d-flex justify-content-left text-image">
                            <picture>
                                <img src="/images/application/products/military-spec-signal-control-cable/impression/military-spec-signal-control-cable-structure-02-<%=RouteData.Values["language"].ToString() %>.svg"
                                    alt="軍規訊號控制線 Military Spec Signal Control Cable" class="mx-auto" />
                            </picture>
                        </div>
                        <div class="text-content-link">
                                <a href="/<%=RouteData.Values["language"].ToString() %>/product/silicone-wire" class="btn btn-info">
                                    <%if (RouteData.Values["language"].ToString() == "zh")
                                        {%>
                                                
                                    ▹▹▹ 更多矽膠線產品
                                                <%}
                                                    else
                                                    {%>
                                                
                                    ▹▹▹ More Silicone Wire
                                            <%}%>
                                </a>
                                <a href="/<%=RouteData.Values["language"].ToString() %>/product/military-grade-wire" class="btn btn-primary">
                                    <%if (RouteData.Values["language"].ToString() == "zh")
                                        {%>
                                                
                                    ▹▹▹ 更多軍規線產品
                                                <%}
                                                    else
                                                    {%>
                                                
                                    ▹▹▹ More Military Wire
                                            <%}%>
                                </a>
                            </div>
                    </div>
                </div>
                <div class="d-none d-md-flex col-md-6 image-vertical-center">
                    <picture>
                        <source srcset="/images/application/products/military-spec-signal-control-cable/impression/military-spec-signal-control-cable-01.webp"
                            type="image/webp" />
                        <img src="/images/application/products/military-spec-signal-control-cable/impression/military-spec-signal-control-cable-01.jpg"
                            alt="軍規訊號控制線 Military Spec Signal Control Cable" />
                    </picture>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

