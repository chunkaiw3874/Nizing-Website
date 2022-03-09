<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="motor-power-cable.aspx.cs" Inherits="application_motor_power_cable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title><%if (RouteData.Values["language"].ToString() == "zh")
               {%>
                                                電動機車電源供應器 電動馬達動力線-日進電線 2021
                                                <%}
                                                    else
                                                    {%>
                                                 Motor Power Cable - Nizing Electric Wire & Cable
                                            <%}%></title>
    <meta name="description" content=                        
                            <%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "使用超軟導體讓有限空間內佈線更加自由輕巧，具有『超高無氧』、『高純度』及『高導電』等特點，可耐-40~200°C，也適合在極端溫度環境下使用。 為符合綠色能量之宗旨，使用 Silicone 作為絕緣外被，是公認最具環保材質，無毒無味、無汙染、耐腐蝕化學品...等，沒有汙染，絕對環保 。"
                                                <%}
        else
        {%>
                                                 "Uses ultra flexible conductor, allowing more freedom in wiring design. With high purity, great conductivity, and -40~200°C temperature range, the Motor Power Cable can withstand extreme conditions, coupling with its silicone insulation, the most environmental friendly material, it is the ideal representation of both green & technology."
                                            <%}%>         />
    <meta property="og:type" content="article" />
    <meta property="og:title" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "電動機車電源供應器 電動馬達動力線-日進電線 2021"
                                                <%}
        else
        {%>
                                                 "Motor Power Cable - Nizing Electric Wire & Cable"
                                            <%}%> />
    <meta property="og:description" content=                        
                            <%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "使用超軟導體讓有限空間內佈線更加自由輕巧，具有『超高無氧』、『高純度』及『高導電』等特點，可耐-40~200°C，也適合在極端溫度環境下使用。 為符合綠色能量之宗旨，使用 Silicone 作為絕緣外被，是公認最具環保材質，無毒無味、無汙染、耐腐蝕化學品...等，沒有汙染，絕對環保 。"
                                                <%}
        else
        {%>
                                                 "Uses ultra flexible conductor, allowing more freedom in wiring design. With high purity, great conductivity, and -40~200°C temperature range, the Motor Power Cable can withstand extreme conditions, coupling with its silicone insulation, the most environmental friendly material, it is the ideal representation of both green & technology."
                                            <%}%> />
    <meta property="og:image" content="https://www.nizing.com.tw/images/application/products/motor-power-cable/impression/motor-power-cable-2.jpg" />
    <meta property="og:url" content="https://www.nizing.com.tw/<%=RouteData.Values["language"].ToString()%>/application/automobile/motor-power-cable" />
    <meta property="og:site_name" content="Nizing Electric Wire and Cable" />
    <style type="text/css">
        .breadcrumb {
            display: none;
        }

        .col-md-6 {
            padding: 0;
        }

        img {
            object-fit: cover;
        }

        .bg-color {
            background-color: #90AAB1 !important;
        }

        .text-green {
            color: #E0F7AD;
        }

        .text-section .top {
            padding-top: 1.5rem;
            padding-bottom: 0.6rem;
        }

        .zh .text-section .top {
            font-size: 20px;
        }

        .en .text-section .top {
            font-size: 20px;
        }

        .text-section {
            padding-right: 48px;
            font-weight: bold;
        }

            .text-section .middle {
                padding-bottom: 0.6rem;
                letter-spacing: 5px;
            }

        .zh .text-section .middle {
            font-size: 50px;
        }

        .en .text-section .middle {
            font-size: 54px;
        }

        .text-section .middle p {
            margin: 0;
        }

        .zh .text-section .middle p:first-child {
            font-size: 47px;
        }

        .en .text-section .middle p:first-child {
            font-size: 47px;
        }

        .text-section .bottom {
            padding-bottom: 1rem;
        }

        .zh .text-section .bottom {
            font-size: 18px;
        }

        .img-small {
            width: 90%;
        }

        .special-char-font {
            font-family: Arial;
        }

        @media all and (max-width:1199px) {
            .zh .text-section .top {
                font-size: 18px;
            }

            .en .text-section .top {
                font-size: 18px;
            }

            .zh .text-section .middle {
                font-size: 40px;
            }

            .en .text-section .middle {
                font-size: 42px;
            }

            .zh .text-section .middle p:first-child {
                font-size: 38px;
            }

            .en .text-section .middle p:first-child {
                font-size: 36px;
            }

            .zh .text-section .bottom {
                font-size: 16px;
            }

            .en .text-section .bottom {
                font-size: 16px;
            }
        }

        @media all and (max-width:991px) {
            .zh .text-section .middle {
                font-size: 34px;
            }

            .en .text-section .middle {
                font-size: 23px;
            }

            .zh .text-section .middle p:first-child {
                font-size: 32px;
            }

            .en .text-section .middle p:first-child {
                font-size: 28px;
            }
        }

        @media all and (max-width:767px) {
            .text-section {
                padding-right: 15px;
            }

            .mobile-text-wrapper {
                margin: auto;
                width: fit-content;
            }

            .zh .text-section .middle {
                font-size: 30px;
            }

            .en .text-section .middle {
                font-size: 30px;
            }

            .zh .text-section .middle p:first-child {
                font-size: 28px;
            }

            .en .text-section .middle p:first-child {
                font-size: 27px;
            }

            .text-section .bottom {
                margin: auto;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="container-fluid">
        <div class="row bg-color m-0 pb-3 <%=RouteData.Values["language"].ToString() %>">
            <div class="col-md-6">
                <picture>
                    <source srcset="/images/application/products/motor-power-cable/impression/motor-power-cable-1-mobile.webp" media="(max-width:767px)" type="image/webp" />
                    <source srcset="/images/application/products/motor-power-cable/impression/motor-power-cable-1.webp" type="image/webp" />
                    <source srcset="/images/application/products/motor-power-cable/impression/motor-power-cable-1-mobile.jpg" media="(max-width:767px)" />
                    <img src="/images/application/products/motor-power-cable/impression/motor-power-cable-1.jpg"
                        alt="Gogoro Electric Motorcycle" />
                </picture>
            </div>
            <div class="col-md-6">
                <div class="container text-section">
                    <div class="mobile-text-wrapper">
                        <div class="top text-green">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>
                                                電源供應器 & 電動馬達動力線
                                                <%}
                                                    else
                                                    {%>
                                                 Motor Power Cable
                                            <%}%>
                        </div>
                        <div class="middle text-white">
                            <p>                                
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>
                                                超軟導體  恣意佈線
                                                <%}
                                                    else
                                                    {%>
                                                 Flexibility Freedom
                                            <%}%>
                            </p>
                            <p>
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>
                                                綠能環保線在啟動
                                                <%}
                                                    else
                                                    {%>
                                                 Green Cable Now
                                            <%}%>                                
                            </p>
                        </div>
                    </div>
                    <div class="bottom text-white">                        
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>
                                                使用超軟導體讓有限空間內佈線更加自由輕巧，具有『超高無氧』、『高純度』及『高導電』等特點，可耐-40~200<span class="special-char-font">°</span>C，也適合在極端溫度環境下使用。 為符合綠色能量之宗旨，使用 Silicone 作為絕緣外被，是公認最具環保材質，無毒無味、無汙染、耐腐蝕化學品...等，沒有汙染，絕對環保 。
                                                <%}
                                                    else
                                                    {%>
                                                 Uses ultra flexible conductor, allowing more freedom in wiring design. With high purity, great conductivity, and -40~200<span class="special-char-font">°</span>C temperature range, the Motor Power Cable can withstand extreme conditions, coupling with its silicone insulation, the most environmental friendly material, it is the ideal representation of both green & technology.
                                            <%}%>                              
                    </div>
                </div>
                <div>
                    <picture>
                        <source srtset="/images/application/products/motor-power-cable/impression/motor-power-cable-2.webp" type="image/webp" />
                        <img src="/images/application/products/motor-power-cable/impression/motor-power-cable-2.jpg"
                            alt="電動馬達動力線 Electric Motorcycle Power Cable" />
                    </picture>
                </div>
                <div class="d-flex justify-content-center">
                    <picture>
                        <img src="/images/application/products/motor-power-cable/impression/motor-power-cable-3-<%=RouteData.Values["language"].ToString() %>.svg"
                            alt="電動馬達動力線 Electric Motorcycle Power Cable Structure" class="img-small" />
                    </picture>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

