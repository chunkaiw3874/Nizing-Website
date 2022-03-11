<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="military-spec-high-frequency-transmission-control-cable.aspx.cs" Inherits="application_military_spec_high_frequency_transmission_control_cable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title><%if (RouteData.Values["language"].ToString() == "zh")
               {%>
                                                軍規高頻傳輸控制複合電纜-日進電線 2021
                                                <%}
                                                    else
                                                    {%>
                                                Military Spec High Frequency Transmission Control Cable - Nizing Electric Wire & Cable
                                            <%}%></title>
    <meta name="description" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "飛彈發射器需接收飛彈下鏈資料，目標分類與辨識、追蹤與接戰，必須不受雜訊的干擾及即時的訊息回饋，才能精準有效的達成發彈發射的所有動作，此線材外層增加多重防雜訊隔離，有效的阻止外部電磁雜訊的干擾並保持傳輸網絡信號數據的完整傳遞，可運用在單臂及雙臂飛彈發射器中的傾斜式環形彈艙、垂直圓柱型彈艙、垂直輸送帶彈艙或其它各種型態不同的發彈發射器，結合飛彈控制系統即為完整的飛彈防禦系統。"
                                                <%}
        else
        {%>
                                                "Missile launcher needs to complete complex tasks such as target recognition, tracking, and contact, in order make accurate calculation for a successful missile launch, which requires fast and clean signal transmission. The Military Spec High Frequency Transmission Control Cable added multiple layers of anti-interference layers to ensure the data is being transferred clean and unaltered."
                                            <%}%> />
    <meta property="og:type" content="article" />
    <meta property="og:title" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "軍規高頻傳輸控制複合電纜-日進電線 2021"
                                                <%}
        else
        {%>
                                                "Military Spec High Frequency Transmission Control Cable - Nizing Electric Wire & Cable"
                                            <%}%> />
    <meta property="og:description" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "飛彈發射器需接收飛彈下鏈資料，目標分類與辨識、追蹤與接戰，必須不受雜訊的干擾及即時的訊息回饋，才能精準有效的達成發彈發射的所有動作，此線材外層增加多重防雜訊隔離，有效的阻止外部電磁雜訊的干擾並保持傳輸網絡信號數據的完整傳遞，可運用在單臂及雙臂飛彈發射器中的傾斜式環形彈艙、垂直圓柱型彈艙、垂直輸送帶彈艙或其它各種型態不同的發彈發射器，結合飛彈控制系統即為完整的飛彈防禦系統。"
                                                <%}
        else
        {%>
                                                "Missile launcher needs to complete complex tasks such as target recognition, tracking, and contact, in order make accurate calculation for a successful missile launch, which requires fast and clean signal transmission. The Military Spec High Frequency Transmission Control Cable added multiple layers of anti-interference layers to ensure the data is being transferred clean and unaltered."
                                            <%}%> />
    <meta property="og:image" content="https://www.nizing.com.tw/images/application/products/military-spec-high-frequency-transmission-control-cable/impression/high-frequency-transmission-control-cable-01-m.jpg" />
    <meta property="og:url" content="https://www.nizing.com.tw/<%=RouteData.Values["language"].ToString() %>/application/temperature-control-system/military-spec-high-frequency-transmission-control-cable" />
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
            background: url("/images/application/products/military-spec-high-frequency-transmission-control-cable/impression/high-frequency-transmission-control-cable-bg.webp") no-repeat top / cover;
        }

        .no-webp .bg-wrapper {
            background: url("/images/application/products/military-spec-high-frequency-transmission-control-cable/impression/high-frequency-transmission-control-cable-bg.jpg") no-repeat top / cover;
        }

        .bg-color-gradient {
            background-image: none;
        }

        .image-section img {
            width: 76%;
        }

        .text-section {
            margin: 60px 0 20px 0;
            font-weight: bold;
        }

            .text-section .text-title {
                color: #036eb7;
                line-height: 1.1;
                padding-bottom: 12px;
            }

        .zh .text-section .text-title {
            font-size: 52px;
        }

        .en .text-section .text-title {
            font-size: 56px;
        }

        .text-section .text-subtitle {
            display: flex;
            padding-bottom: 12px;
            color: #c30d23;
            align-items: baseline;
        }

        .zh .text-section .text-subtitle {
            font-size: 34px;
        }

        .en .text-section .text-subtitle {
            font-size: 22px;
        }

        .text-section .text-subtitle .subtitle-indent {
            background-color: #c30d23;
            aspect-ratio: 1/3;
            margin: auto 5px auto 0;
        }

        .zh .text-section .text-subtitle .subtitle-indent {
            height: 30px;
        }

        .en .text-section .text-subtitle .subtitle-indent {
            height: 0px;
        }

        .text-section .text-content {
            color: #415576;
        }

        .zh .text-section .text-content {
            font-size: 24px;
            text-align: justify;
        }

        .en .text-section .text-content {
            font-size: 24px;
        }

        .text-section .text-image {
            width: 70%;
        }

        .text-section .text-content-link {
            display: flex;
            justify-content: right;
        }

            .text-section .text-content-link a {
                padding: 5px 20px;
                border-radius: 20px;
                font-size: 14px;
            }

        @media all and (max-width:1423px) {
            .text-section {
                margin-top: 40px;
            }

            .zh .text-section .text-title {
                font-size: 52px;
            }

            .en .text-section .text-title {
                font-size: 75px;
            }

            .zh .text-section .text-subtitle {
                font-size: 33px;
            }

            .en .text-section .text-subtitle {
                font-size: 25px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 30px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 0;
            }

            .zh .text-section .text-content {
                font-size: 22px;
            }

            .en .text-section .text-content {
                font-size: 22px;
            }
        }

        @media all and (max-width:1199px) {
            .text-section {
                margin-top: 40px;
            }

            .zh .text-section .text-title {
                font-size: 51px;
            }

            .en .text-section .text-title {
                font-size: 73px;
            }

            .zh .text-section .text-subtitle {
                font-size: 33px;
            }

            .en .text-section .text-subtitle {
                font-size: 24px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 30px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 0;
            }

            .zh .text-section .text-content {
                font-size: 20px;
            }

            .en .text-section .text-content {
                font-size: 20px;
            }
        }

        @media all and (max-width:991px) {
            .text-section {
                margin-top: 40px;
            }

            .zh .text-section .text-title {
                font-size: 37px;
            }

            .en .text-section .text-title {
                font-size: 53px;
            }

            .zh .text-section .text-subtitle {
                font-size: 24px;
            }

            .en .text-section .text-subtitle {
                font-size: 17px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 21px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 0;
            }

            .zh .text-section .text-content {
                font-size: 18px;
            }

            .en .text-section .text-content {
                font-size: 16px;
            }

            .image-section img {
                width: 100%;
            }
        }

        @media all and (max-width:767px) {
            .webp .bg-wrapper.bg-color-gradient, .no-webp .bg-wrapper.bg-color-gradient {
                background-image: linear-gradient(#445145 63%, #303b36, #1c2528);
            }

            .webp .bg-wrapper, .no-webp .bg-wrapper {
                background: none;
            }

            .text-section {
                margin: 0;
            }

                .text-section .text-title {
                    color: #f7b52c;
                }

            .zh .text-section .text-title {
                font-size: 48px;
            }

            .en .text-section .text-title {
                font-size: 69px;
            }

            .text-section .text-subtitle {
                color: #ffffff;
            }

            .zh .text-section .text-subtitle {
                font-size: 31px;
            }

            .en .text-section .text-subtitle {
                font-size: 17px;
            }

            .text-section .text-subtitle .subtitle-indent {
                background-color: #ffffff;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 26px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 0;
            }

            .text-section .text-content {
                color: #ffffff;
            }

            .zh .text-section .text-content {
                font-size: 18px;
            }

            .en .text-section .text-content {
                font-size: 20px;
            }

            .text-section .text-image {
                padding: 40px 0;
                margin: auto;
            }

            .text-section .text-content-link {
                justify-content: center;
            }

            .bottom-image {
                margin-top: -60px;
            }
        }

        @media all and (max-width:575px) {
            .zh .text-section .text-title {
                font-size: 31px;
            }

            .en .text-section .text-title {
                font-size: 45px;
            }

            .zh .text-section .text-subtitle {
                font-size: 20px;
            }

            .en .text-section .text-subtitle {
                font-size: 22px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 17px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 0;
            }

            .zh .text-section .text-content {
                font-size: 16px;
            }

            .en .text-section .text-content {
                font-size: 18px;
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
                    <source srcset="/images/application/products/military-spec-high-frequency-transmission-control-cable/impression/high-frequency-transmission-control-cable-01-m.webp"
                        type="image/webp" />
                    <img src="/images/application/products/military-spec-high-frequency-transmission-control-cable/impression/high-frequency-transmission-control-cable-01-m.jpg"
                        alt="軍規高頻傳輸控制複合電纜 Military Spec High Frequency Transmission Control Cable" />
                </picture>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-md-4 d-none d-md-flex align-items-end image-section">
                        <picture>
                            <source srcset="/images/application/products/military-spec-high-frequency-transmission-control-cable/impression/high-frequency-transmission-control-cable-01.webp"
                                type="image/webp" />
                            <img src="/images/application/products/military-spec-high-frequency-transmission-control-cable/impression/high-frequency-transmission-control-cable-01.png"
                                alt="軍規高頻傳輸控制複合電纜 Military Spec High Frequency Transmission Control Cable" />
                        </picture>
                    </div>
                    <div class="col-md-7 col-xl-6">
                        <div class="text-section">
                            <div class="text-subtitle">
                                <div class="subtitle-indent"></div>
                                <%if (RouteData.Values["language"].ToString() == "zh")
                                    {%>
                                                MIL 飛彈發射器
                                                <%}
                                                    else
                                                    {%>
                                                Military Spec High Frequency Transmission Control Cable
                                            <%}%>
                            </div>
                            <div class="text-title">
                                <%if (RouteData.Values["language"].ToString() == "zh")
                                    {%>
                                                一發入魂 完美發射<br />
                                                高頻傳輸控制複合電纜
                                                <%}
                                                    else
                                                    {%>
                                            Zero Delay、Perfect Timing
                                            <%}%>                                
                            </div>
                            <div class="text-content">
                                <%if (RouteData.Values["language"].ToString() == "zh")
                                    {%>
                                                飛彈發射器需接收飛彈下鏈資料，目標分類與辨識、追蹤與接戰，必須不受雜訊的干擾及即時的訊息回饋，才能精準有效的達成發彈發射的所有動作，此線材外層增加多重防雜訊隔離，有效的阻止外部電磁雜訊的干擾並保持傳輸網絡信號數據的完整傳遞，可運用在單臂及雙臂飛彈發射器中的傾斜式環形彈艙、垂直圓柱型彈艙、垂直輸送帶彈艙或其它各種型態不同的發彈發射器，結合飛彈控制系統即為完整的飛彈防禦系統。
                                                <%}
                                                    else
                                                    {%>
                                                Missile launcher needs to complete complex tasks such as target recognition, tracking, and contact, in order make accurate calculation for a successful missile launch, which requires fast and clean signal transmission. The Military Spec High Frequency Transmission Control Cable added multiple layers of anti-interference layers to ensure the data is being transferred clean and unaltered.
                                            <%}%>
                            </div>
                            <div class="text-image">
                                <picture>
                                    <img src="/images/application/products/military-spec-high-frequency-transmission-control-cable/impression/high-frequency-transmission-control-cable-03-<%=RouteData.Values["language"].ToString() %>.svg"
                                        alt="軍規高頻傳輸控制複合電纜結構 Military Spec High Frequency Transmission Control Cable Structure" class="mx-auto" />
                                </picture>
                            </div>
                            <div class="text-content-link">
                                <a href="/<%=RouteData.Values["language"].ToString() %>/product/military-grade-wire" class="btn-primary">
                                    <%if (RouteData.Values["language"].ToString() == "zh")
                                        {%>
                                                
                                    ▶▶▶更多軍規線產品
                                                <%}
                                    else
                                    {%>
                                                
                                    ▶▶▶More Military Grade Wire
                                            <%}%>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>            
            <div class="d-md-none bottom-image">
                <picture>
                    <source srcset="/images/application/products/military-spec-high-frequency-transmission-control-cable/impression/high-frequency-transmission-control-cable-04-m.webp"
                        type="image/webp" />
                    <img src="/images/application/products/military-spec-high-frequency-transmission-control-cable/impression/high-frequency-transmission-control-cable-04-m.png" />
                </picture>
            </div>
        </div>
    </div>
</asp:Content>

