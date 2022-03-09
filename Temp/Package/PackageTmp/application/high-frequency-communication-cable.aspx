<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="high-frequency-communication-cable.aspx.cs" Inherits="application_high_frequency_communication_cable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title><%if (RouteData.Values["language"].ToString() == "zh")
               {%>
                                                高頻無線通訊電纜-日進電線 2021
                                                <%}
                                                    else
                                                    {%>
                                                High Frequency Communication Cable - Nizing Electric Wire & Cable
                                            <%}%></title>
    <meta name="description" content="全新的數位汽車結合了無線網路及數位媒體以提供用戶嶄新的開車服務及體驗，功能包括＂Apple Carplay、GPS全球定位、Wi-Fi 無線網路、Bluetooth 藍芽傳輸、Autopilot自動輔助駕駛...等，讓汽車更智慧、更安全的方式行車，讓用戶輕鬆取得路線指引、打電話、發送和接收訊息，盡享喜愛的音樂，一切都可在汽車內建顯示器上進行操作，此一連串便利的設備服務，皆需背後功能強大的電纜一線連結才能運行。此線材具有高頻、耐高溫、耐潮濕、耐腐蝕、屏蔽佳、衰減率小和抗電子干擾、優越的溫度穩定性...等特點，具備優良的電氣性能使傳輸訊號更為穩定快速，使用無毒無味、無汙染的環保素材 Silicone 作為絕緣外被。" />
    <meta property="og:type" content="article" />
    <meta property="og:title" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "高頻無線通訊電纜-日進電線 2021"
                                                <%}
        else
        {%>
                                                "High Frequency Communication Cable - Nizing Electric Wire & Cable"
                                            <%}%> />
    <meta property="og:description" content="全新的數位汽車結合了無線網路及數位媒體以提供用戶嶄新的開車服務及體驗，功能包括＂Apple Carplay、GPS全球定位、Wi-Fi 無線網路、Bluetooth 藍芽傳輸、Autopilot自動輔助駕駛...等，讓汽車更智慧、更安全的方式行車，讓用戶輕鬆取得路線指引、打電話、發送和接收訊息，盡享喜愛的音樂，一切都可在汽車內建顯示器上進行操作，此一連串便利的設備服務，皆需背後功能強大的電纜一線連結才能運行。此線材具有高頻、耐高溫、耐潮濕、耐腐蝕、屏蔽佳、衰減率小和抗電子干擾、優越的溫度穩定性...等特點，具備優良的電氣性能使傳輸訊號更為穩定快速，使用無毒無味、無汙染的環保素材 Silicone 作為絕緣外被。" />
    <meta property="og:image" content="https://www.nizing.com.tw/images/application/products/high-frequency-communication-cable/impression/high-frequency-communication-cable-01-mobile.jpg" />
    <meta property="og:url" content="https://www.nizing.com.tw/<%=RouteData.Values["language"].ToString() %>/application/automobile/high-frequency-communication-cable" />
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

        .col-md-6 {
            padding: 0;
        }

        img {
            object-fit: cover;
        }

        .webp .bg-wrapper {
            background: url("/images/application/products/high-frequency-communication-cable/impression/high-frequency-communication-cable-bg.webp") no-repeat top / cover;
        }

        .no-webp .bg-wrapper {
            background: url("/images/application/products/high-frequency-communication-cable/impression/high-frequency-communication-cable-bg.jpg") no-repeat top / cover;
        }

        .bg-color {
            background-color: #030d26 !important;
        }

        .bottom-image {
            position: absolute;
            top: 420px;
            right: 0;
            width: 46%;
        }

        .text-section {
            padding: 40px 46px 120px 150px;
            font-weight: bold;
            background-color: #000f2160;
        }

        .zh .text-section {
            text-align: justify;
        }

        .text-section .text-title {
            color: #FFF000;
            padding: 20px 0;
        }

        .zh .text-section .text-title {
            font-size: 50px;
        }

        .en .text-section .text-title {
            font-size: 33px;
        }

        .text-section .text-subtitle {
            display: inline;
            color: #ffffff;
            background-color: #036eb7;
            padding: 5px 10px;
        }

        .zh .text-section .text-subtitle {
            font-size: 28px;
        }

        .zh .text-section .text-subtitle {
            font-size: 28px;
        }

        .text-section .text-content {
            color: #ffffff;
            padding-bottom: 24px;
        }

        .zh .text-section .text-content {
            font-size: 22px;
        }

        .en .text-section .text-content {
            font-size: 20px;
        }

        .text-section .text-image {
            width: 70%;
            margin: 0 auto;
        }

        @media all and (max-width:1423px) {
            .text-section {
                padding-left: 120px;
                padding-bottom: 40px;
            }

            .bottom-image {
                top: 420px;
                width: 48%;
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
                font-size: 16px;
            }

            .zh .text-section .text-content {
                font-size: 20px;
            }

            .en .text-section .text-content {
                font-size: 16px;
            }
        }

        @media all and (max-width:1199px) {
            .text-section {
                padding-bottom: 40px;
                padding-left: 80px;
            }

            .bottom-image {
                top: 330px;
                width: 48%;
            }

            .zh .text-section .text-title {
                font-size: 36px;
            }

            .en .text-section .text-title {
                font-size: 24px;
            }

            .zh .text-section .text-subtitle {
                font-size: 20px;
            }

            .en .text-section .text-subtitle {
                font-size: 16px;
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

            .text-section .text-image {
                width: 100%;
            }
        }

        @media all and (max-width:991px) {
            .webp .bg-wrapper {
                background-size: contain;
            }

            .no-webp .bg-wrapper {
                background-size: contain;
            }

            .text-section {
                padding-left: 40px;
            }

            .bottom-image {
                top: 270px;
                width: 45%;
            }

            .zh .text-section .text-title {
                font-size: 28px;
            }

            .en .text-section .text-title {
                font-size: 28px;
            }

            .zh .text-section .text-subtitle {
                font-size: 16px;
            }

            .en .text-section .text-subtitle {
                font-size: 16px;
            }

            .zh .text-section .text-content {
                font-size: 14px;
            }

            .en .text-section .text-content {
                font-size: 14px;
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
                margin-top: 20px;
                padding: 0 40px;
            }

            .zh .text-section .text-title {
                font-size: 46px;
            }

            .zh .text-section .text-subtitle {
                font-size: 24px;
            }

            .zh .text-section .text-content {
                font-size: 16px;
            }
        }

        @media all and (max-width:575px) {
            .zh .text-section .text-subtitle {
                font-size: 16px;
            }

            .en .text-section .text-subtitle {
                font-size: 13px;
            }

            .text-section .text-title {
                padding: 14px 0;
            }

            .zh .text-section .text-title {
                font-size: 26px;
            }

            .en .text-section .text-title {
                font-size: 17px;
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
                    <source srcset="/images/application/products/high-frequency-communication-cable/impression/high-frequency-communication-cable-01-mobile.webp"
                        type="image/webp" />
                    <img src="/images/application/products/high-frequency-communication-cable/impression/high-frequency-communication-cable-01-mobile.jpg"
                        alt="高頻無線通訊電纜 High Frequency Communication Cable" />
                </picture>
            </div>
            <div class="row">
                <div class="col-md-7 col-lg-6">
                    <div class="text-section">
                        <div class="text-subtitle">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>                                                
                                          車用-高頻無線通訊電纜
                                                <%}
                                                    else
                                                    {%>
                                            High Frequency Communication Cable
                                            <%}%>
                        </div>
                        <div class="text-title">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>                                                
                                          一線掌控數位汽車服務
                                                <%}
                                                    else
                                                    {%>
                                            FULL CONTROL OF YOUR CAR
                                            <%}%>                            
                        </div>
                        <div class="text-content text-shadow">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>                                                
                                          
                            全新的數位汽車結合了無線網路及數位媒體以提供用戶嶄新的開車服務及體驗，功能包括Apple Carplay、GPS全球定位、Wi-Fi 無線網路、Bluetooth 藍芽傳輸、Autopilot自動輔助駕駛...等，讓汽車更智慧、更安全的方式行車，讓用戶輕鬆取得路線指引、打電話、發送和接收訊息，盡享喜愛的音樂，一切都可在汽車內建顯示器上進行操作，此一連串便利的設備服務，皆需背後功能強大的電纜一線連結才能運行。
                            <br />
                            <br />
                            此線材具有高頻、耐高溫、耐潮濕、耐腐蝕、屏蔽佳、衰減率小和抗電子干擾、優越的溫度穩定性...等特點，具備優良的電氣性能使傳輸訊號更為穩定快速，使用無毒無味、無汙染的環保素材 Silicone 作為絕緣外被。
                                                <%}
                                                    else
                                                    {%>
                                            With improvement of technology, a car is no longer just a mode of transportation, but a combination of practical functions and entertainment system, including Apple Carplay, GPS, WiFi, Bluetooth, Autopilot... etc, which allows the driver to get instructions, receive calls, or enjoy their favorite tunes with ease, make driving safer, more enjoyable, and more convenient than ever before. All these convenience and functionality require a well designed cable to ensure all these intricate devices run smoothly.
                            <br />
                            <br />
                            High Frequency Communication Cable has high frequency, high temperature resistance, high humidity endurance, high chemical resistance, great signal shielding, low attenuation, and many other properties making it the top cable choice for your vehicular enjoyment.
                                            <%}%>        
                        </div>
                        <div class="d-flex justify-content-center text-image">
                            <picture>
                                <img src="/images/application/products/high-frequency-communication-cable/impression/high-frequency-communication-cable-02-structure-<%=RouteData.Values["language"].ToString() %>.svg"
                                    alt="高頻無線通訊電纜結構 High Frequency Communication Cable Structure" class="mx-auto" />
                            </picture>
                        </div>
                    </div>
                </div>
            </div>
            <div class="d-none d-md-flex bottom-image">
                <picture>
                    <source srcset="/images/application/products/high-frequency-communication-cable/impression/high-frequency-communication-cable-01.webp"
                        type="image/webp" />
                    <img src="/images/application/products/high-frequency-communication-cable/impression/high-frequency-communication-cable-01.png"
                        alt="高頻無線通訊電纜 High Frequency Communication Cable" />
                </picture>
            </div>
            <div class="d-md-none">
                <picture>
                    <source srcset="/images/application/products/high-frequency-communication-cable/impression/high-frequency-communication-cable-mobile-2.webp"
                        type="image/webp" />
                    <img src="/images/application/products/high-frequency-communication-cable/impression/high-frequency-communication-cable-mobile-2.jpg"
                        alt="" />
                </picture>
            </div>
        </div>
    </div>
</asp:Content>

