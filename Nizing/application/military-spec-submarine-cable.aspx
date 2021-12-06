<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="military-spec-submarine-cable.aspx.cs" Inherits="application_military_spec_submarine_cable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title><%if (RouteData.Values["language"].ToString() == "zh")
               {%>
                                                軍規潛艦電纜-日進電線 2021
                                                <%}
                                                    else
                                                    {%>
                                                Military Spec Submarine Cable - Nizing Electric Wire & Cable
                                            <%}%></title>
    <meta name="description" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "潛艦航行於海面下，靠匿踪、隱密對敵發起猝然攻擊。潛艦通信精密且複雜，主要通信手段有無線電通信、水下通信、衛星通信及藍綠雷射通信等方式，也會採取使用漂浮天線、拖曳天線或衛星通信等來保持其「隱匿」和「安全」的必要條件來傳輸電報、語音、數據、圖像資料....等資訊。此線材使用不鏽鋼鎧裝及多重防雜訊隔離，擁有可強力阻止外部電磁干擾的能力，保持傳輸信號的穩定快速、品質優越、抗腐蝕，非常適合於水底或其它嚴苛環境之網路通訊使用。"
                                                <%}
        else
        {%>
                                                "Being the stealthy assassin of the sea, submarine communications are extremely intricate and delicate. Its main communication methods include wireless, underwater, satellite, and laser, sometimes comebined with antennas of various types, to ensure the secrecy and security of its communications. Military Spec Submarine Cable, with its multiple layers of jackets of different materials to minimize both signal interference and physical mutilation, making it the best choice for underwater communication or communications in other harsh environments. "
                                            <%}%> />
    <meta property="og:type" content="article" />
    <meta property="og:title" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "軍規潛艦電纜-日進電線 2021"
                                                <%}
        else
        {%>
                                                "Military Spec Submarine Cable - Nizing Electric Wire & Cable"
                                            <%}%> />
    <meta property="og:description" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "潛艦航行於海面下，靠匿踪、隱密對敵發起猝然攻擊。潛艦通信精密且複雜，主要通信手段有無線電通信、水下通信、衛星通信及藍綠雷射通信等方式，也會採取使用漂浮天線、拖曳天線或衛星通信等來保持其「隱匿」和「安全」的必要條件來傳輸電報、語音、數據、圖像資料....等資訊。此線材使用不鏽鋼鎧裝及多重防雜訊隔離，擁有可強力阻止外部電磁干擾的能力，保持傳輸信號的穩定快速、品質優越、抗腐蝕，非常適合於水底或其它嚴苛環境之網路通訊使用。"
                                                <%}
        else
        {%>
                                                "Being the stealthy assassin of the sea, submarine communications are extremely intricate and delicate. Its main communication methods include wireless, underwater, satellite, and laser, sometimes comebined with antennas of various types, to ensure the secrecy and security of its communications. Military Spec Submarine Cable, with its multiple layers of jackets of different materials to minimize both signal interference and physical mutilation, making it the best choice for underwater communication or communications in other harsh environments. "
                                            <%}%> />
    <meta property="og:image" content="https://www.nizing.com.tw/images/application/products/military-spec-submarine-cable/impression/military-spec-submarine-cable-01-mobile.jpg" />
    <meta property="og:url" content="https://www.nizing.com.tw/<%=RouteData.Values["language"].ToString()%>/application/misc-app/military-spec-submarine-cable" />
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

        .w-80 {
            width: 80%;
        }

        .webp .bg-wrapper {
            background: url("/images/application/products/military-spec-submarine-cable/impression/military-spec-submarine-cable-01-bg.webp") no-repeat top / cover;
        }

        .no-webp .bg-wrapper {
            background: url("/images/application/products/military-spec-submarine-cable/impression/military-spec-submarine-cable-01-bg.jpg") no-repeat top / cover;
        }

        .bg-color-gradient {
            background-image: none;
        }

        .text-section {
            padding: 40px 50px;
            font-weight: bold;
            background-color: #04082850;
        }

        .zh .text-section {
            text-align: justify;
        }

        .text-section .text-title {
            color: #83d9ff;
            line-height: 1.1;
            padding-bottom: 20px;
        }

        .zh .text-section .text-title {
            font-size: 50px;
        }

            .zh .text-section .text-title:nth-child(2) {
                letter-spacing: 1.751px;
            }

        .en .text-section .text-title {
            font-size: 38px;
        }

        .text-section .text-subtitle {
            display: flex;
            padding-bottom: 20px;
            color: #b5eda9;
            align-items: baseline;
        }

            .text-section .text-subtitle .subtitle-indent {
                background-color: #b5eda9;
                width: 10px;
                margin: auto 5px auto 0;
            }

        .zh .text-section .text-subtitle {
            font-size: 36px;
        }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 34px;
            }

        .en .text-section .text-subtitle {
            font-size: 22px;
        }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 20px;
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

        .text-shadow {
            text-shadow: 1px 1px 15px #000000, 2px 2px 30px #000000;
        }

        .special-char-font {
            font-family: Arial;
        }

        @media all and (max-width:1423px) {
        }

        @media all and (max-width:1199px) {
            .zh .text-section .text-title {
                font-size: 39px;
            }

                .zh .text-section .text-title:nth-child(2) {
                    letter-spacing: 1.6px;
                }

            .en .text-section .text-title {
                font-size: 30px;
            }

            .zh .text-section .text-subtitle {
                font-size: 30px;
            }

                .zh .text-section .text-subtitle .subtitle-indent {
                    height: 28px;
                }

            .en .text-section .text-subtitle {
                font-size: 18px;
            }

                .en .text-section .text-subtitle .subtitle-indent {
                    height: 16px;
                }

            .zh .text-section .text-content {
                font-size: 20px;
            }

            .en .text-section .text-content {
                font-size: 16px;
            }
        }

        @media all and (max-width:991px) {
            .zh .text-section .text-title {
                font-size: 29px;
            }

                .zh .text-section .text-title:nth-child(2) {
                    letter-spacing: 1.05px;
                }

            .en .text-section .text-title {
                font-size: 20px;
            }

            .zh .text-section .text-subtitle {
                font-size: 20px;
            }

                .zh .text-section .text-subtitle .subtitle-indent {
                    height: 18px;
                }

            .en .text-section .text-subtitle {
                font-size: 14px;
            }

                .en .text-section .text-subtitle .subtitle-indent {
                    height: 12px;
                }

            .zh .text-section .text-content {
                font-size: 16px;
            }

            .en .text-section .text-content {
                font-size: 14px;
            }

            .text-section .text-image {
                width: 80%;
            }
        }

        @media all and (max-width:767px) {
            .bg-wrapper.bg-color-gradient {
                background-image: linear-gradient(#172b85, #172b85 60%, #000036);
            }

            .text-section {
                background: none;
                padding: 40px 20px;
            }

            .zh .text-section .text-title {
                font-size: 46px;
            }

                .zh .text-section .text-title:nth-child(2) {
                    letter-spacing: 1.6px;
                }

            .en .text-section .text-title {
                font-size: 34px;
            }

            .zh .text-section .text-subtitle {
                font-size: 30px;
            }

                .zh .text-section .text-subtitle .subtitle-indent {
                    height: 28px;
                }

            .en .text-section .text-subtitle {
                font-size: 20px;
            }

                .en .text-section .text-subtitle .subtitle-indent {
                    height: 18px;
                }

            .zh .text-section .text-content {
                font-size: 18px;
            }

            .en .text-section .text-content {
                font-size: 16px;
            }

            .text-image {
                padding-bottom: 40px;
            }

            .text-shadow {
                text-shadow: none;
            }
        }

        @media all and (max-width:575px) {
            .text-section {
                padding: 40px 0;
            }

            .zh .text-section .text-title {
                font-size: 30px;
            }

                .zh .text-section .text-title:nth-child(2) {
                    letter-spacing: 1.2px;
                }

            .en .text-section .text-title {
                font-size: 22px;
            }

            .zh .text-section .text-subtitle {
                font-size: 20px;
            }

                .zh .text-section .text-subtitle .subtitle-indent {
                    height: 18px;
                }

            .en .text-section .text-subtitle {
                font-size: 14px;
            }

                .en .text-section .text-subtitle .subtitle-indent {
                    height: 12px;
                }

            .zh .text-section .text-content {
                font-size: 16px;
            }

            .en .text-section .text-content {
                font-size: 14px;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="container-fluid bg-wrapper bg-color-gradient <%=RouteData.Values["language"].ToString() %>">
        <div class="content-wrapper">
            <div class="d-md-none">
                <picture>
                    <source srcset="/images/application/products/military-spec-submarine-cable/impression/military-spec-submarine-cable-01-mobile.webp"
                        type="image/webp" />
                    <img src="/images/application/products/military-spec-submarine-cable/impression/military-spec-submarine-cable-01-mobile.jpg"
                        alt="軍規潛艦電纜 Military Spec Submarine Cable" />
                </picture>
            </div>
            <div class="container-lg container-fluid-md">
                <div class="row">
                    <div class="col-md-7">
                        <div class="text-section">
                            <div class="text-subtitle">
                                <div class="subtitle-indent"></div>                                
                                <%if (RouteData.Values["language"].ToString() == "zh")
                                    {%>
                                                潛艦國造-CR認證
                                                <%}
                                                    else
                                                    {%>
                                                Submarine-CR Certified
                                            <%}%>
                            </div>
                            <div class="d-flex flex-column w-80">
                                <div class="text-title pb-0">                                
                                    <%if (RouteData.Values["language"].ToString() == "zh")
                                        {%>                                                
                                                    水下藏匿 情報傳送
                                                    <%}
                                                        else
                                                        {%>
                                                    Stealthy Transmission
                                                <%}%>
                                </div>
                                <div class="text-title">
                                    <%if (RouteData.Values["language"].ToString() == "zh")
                                        {%>                                                
                                                    軍規船舶複合電纜
                                                    <%}
                                                        else
                                                        {%>
                                                    Shipboard Cable
                                                <%}%>
                                </div>
                            </div>
                            <div class="text-content">
                                <%if (RouteData.Values["language"].ToString() == "zh")
                                    {%>
                                                潛艦航行於海面下，靠匿踪、隱密對敵發起猝然攻擊。潛艦通信精密且複雜，主要通信手段有無線電通信、水下通信、衛星通信及藍綠雷射通信等方式，也會採取使用漂浮天線、拖曳天線或衛星通信等來保持其「隱匿」和「安全」的必要條件來傳輸電報、語音、數據、圖像資料....等資訊。<br />
                                                此線材使用不鏽鋼鎧裝及多重防雜訊隔離，擁有可強力阻止外部電磁干擾的能力，保持傳輸信號的穩定快速、品質優越、抗腐蝕，非常適合於水底或其它嚴苛環境之網路通訊使用。
                                                <%}
                                                    else
                                                    {%>
                                                Being the stealthy assassin of the sea, submarine communications are extremely intricate and delicate. Its main communication methods include wireless, underwater, satellite, and laser, sometimes comebined with antennas of various types, to ensure the secrecy and security of its communications.<br />
                                                Military Spec Submarine Cable, with its multiple layers of jackets of different materials to minimize both signal interference and physical mutilation, making it the best choice for underwater communication or communications in other harsh environments.
                                            <%}%>                                
                            </div>
                            <div class="d-none d-md-flex justify-content-center text-image">
                                <picture>
                                    <img src="/images/application/products/military-spec-submarine-cable/impression/military-spec-submarine-cable-03-<%=RouteData.Values["language"].ToString() %>.svg"
                                        alt="軍規潛艦電纜結構 Military Spec Submarine Cable Structure" class="mx-auto" />
                                </picture>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-5 d-none d-md-flex align-items-end">
                        <picture>
                            <source srcset="/images/application/products/military-spec-submarine-cable/impression/military-spec-submarine-cable-02.webp"
                                type="image/webp" />
                            <img src="/images/application/products/military-spec-submarine-cable/impression/military-spec-submarine-cable-02.png"
                                alt="軍規潛艦電纜 Military Spec Submarine Cable" />
                        </picture>
                    </div>
                </div>
            </div>
            <div class="container d-md-none">
                <div class="d-flex justify-content-center text-image">
                    <picture>
                        <img src="/images/application/products/military-spec-submarine-cable/impression/military-spec-submarine-cable-03-<%=RouteData.Values["language"].ToString() %>.svg"
                            alt="軍規潛艦電纜結構 Military Spec Submarine Cable Structure" class="mx-auto" />
                    </picture>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

