<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="military-spec-missile-control-cable.aspx.cs" Inherits="application_military_spec_missile_control_cable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title><%if (RouteData.Values["language"].ToString() == "zh")
               {%>
                                                飛彈控制軍規線-日進電線 2021
                                                <%}
                                                    else
                                                    {%>
                                                Military Spec Missile Control Cable - Nizing Electric Wire & Cable
                                            <%}%></title>
    <meta name="description" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "飛彈控制系統是一個綜合性很強的複雜系統，透過訊號傳遞所獲取的信息，引導飛彈攻擊目標的技術方法和手段，飛彈性能的優劣，命中目標的精確程度，均由此系統的好壞來決定，控制系統可視為飛彈之靈魂，需達到高精確度及可靠性，不得有任何的誤差及延遲，故導線的訊號回饋的即時性就非常的重要。此電線導體使用超高無氧、高純度、高導電導體，提供訊號傳遞及電力，並使用符合綠色能量 Silicone 作為絕緣外被，無毒無味、耐腐蝕化學品...等特性，可耐200°C耐壓750V。"
                                                <%}
        else
        {%>
                                                "Missile guidance system is a highly complex, multi-dimensional system. It utilizes data from split second signal transmittance to make accurate projection of the missile. The guidance system is the heart and soul of the launcher, and a reliable cable which allows timely network feedback is the backbone. 
                                                The Military Spec Missile Control Cable uses top notch conductor, which allows clean and fast signal and electricity transmission, along with non-toxic silicone insulation which makes it safe to use in most environment."
                                            <%}%> />
    <meta property="og:type" content="article" />
    <meta property="og:title" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "飛彈控制軍規線-日進電線 2021"
                                                <%}
        else
        {%>
                                                "Military Spec Missile Control Cable - Nizing Electric Wire & Cable"
                                            <%}%> />
    <meta property="og:description" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "飛彈控制系統是一個綜合性很強的複雜系統，透過訊號傳遞所獲取的信息，引導飛彈攻擊目標的技術方法和手段，飛彈性能的優劣，命中目標的精確程度，均由此系統的好壞來決定，控制系統可視為飛彈之靈魂，需達到高精確度及可靠性，不得有任何的誤差及延遲，故導線的訊號回饋的即時性就非常的重要。此電線導體使用超高無氧、高純度、高導電導體，提供訊號傳遞及電力，並使用符合綠色能量 Silicone 作為絕緣外被，無毒無味、耐腐蝕化學品...等特性，可耐200°C耐壓750V。"
                                                <%}
        else
        {%>
                                                "Missile guidance system is a highly complex, multi-dimensional system. It utilizes data from split second signal transmittance to make accurate projection of the missile. The guidance system is the heart and soul of the launcher, and a reliable cable which allows timely network feedback is the backbone. 
                                                The Military Spec Missile Control Cable uses top notch conductor, which allows clean and fast signal and electricity transmission, along with non-toxic silicone insulation which makes it safe to use in most environment."
                                            <%}%> />
    <meta property="og:image" content="https://www.nizing.com.tw/images/application/products/military-spec-missile-control-cable/impression/military-spec-missile-control-cable-mobile-01.jpg" />
    <meta property="og:url" content="https://www.nizing.com.tw/<%=RouteData.Values["language"].ToString() %>/application/temperature-control-system/military-spec-missile-control-cable" />
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
            background: url("/images/application/products/military-spec-missile-control-cable/impression/military-spec-missile-control-cable-bg.webp") no-repeat top / cover;
        }

        .no-webp .bg-wrapper {
            background: url("/images/application/products/military-spec-missile-control-cable/impression/military-spec-missile-control-cable-bg.jpg") no-repeat top / cover;
        }

        .bg-color-gradient {
            background-image: none;
        }

        .text-section {
            margin: 80px 0 20px 0;
            font-weight: bold;
        }

            .text-section .text-title {
                color: #122f51;
                line-height: 1;
                padding-bottom: 20px;
            }

        .zh .text-section .text-title {
            font-size: 76px;
        }

        .en .text-section .text-title {
            font-size: 54px;
        }

        .text-section .text-subtitle {
            display: flex;
            padding-bottom: 20px;
            color: red;
            align-items: baseline;
        }

        .zh .text-section .text-subtitle {
            font-size: 36px;
        }

        .en .text-section .text-subtitle {
            font-size: 30px;
        }

        .text-section .text-subtitle .subtitle-indent {
            background-color: red;
            aspect-ratio: 1/3;
            margin: auto 5px auto 0;
        }

        .zh .text-section .text-subtitle .subtitle-indent {
            height: 34px;
        }

        .en .text-section .text-subtitle .subtitle-indent {
            height: 27px;
        }

        .text-section .text-image-top {
            padding-bottom: 20px;
        }

        .text-section .text-content {
            color: #ffffff;
            padding-bottom: 24px;
        }

        .zh .text-section .text-content {
            font-size: 24px;
            text-align: justify;
        }

        .en .text-section .text-content {
            font-size: 23px;
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
            .text-section {
                margin-top: 60px;
            }

            .zh .text-section .text-title {
                font-size: 76px;
            }

            .en .text-section .text-title {
                font-size: 54px;
            }

            .zh .text-section .text-subtitle {
                font-size: 36px;
            }

            .en .text-section .text-subtitle {
                font-size: 30px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 34px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 27px;
            }

            .text-section .text-content {
                padding-bottom: 20px;
            }

            .zh .text-section .text-content {
                font-size: 24px;
            }

            .en .text-section .text-content {
                font-size: 22px;
            }
        }

        @media all and (max-width:1199px) {
            .zh .text-section .text-title {
                font-size: 62px;
            }

            .en .text-section .text-title {
                font-size: 45px;
            }

            .zh .text-section .text-subtitle {
                font-size: 30px;
            }

            .en .text-section .text-subtitle {
                font-size: 25px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 28px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 22px;
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
                font-size: 46px;
            }

            .en .text-section .text-title {
                font-size: 32px;
            }

            .zh .text-section .text-subtitle {
                font-size: 22px;
            }

            .en .text-section .text-subtitle {
                font-size: 18px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 20px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 16px;
            }

            .zh .text-section .text-content {
                font-size: 16px;
            }

            .en .text-section .text-content {
                font-size: 16px;
            }
        }

        @media all and (max-width:767px) {
            .webp .bg-wrapper.bg-color-gradient, .no-webp .bg-wrapper.bg-color-gradient {
                background-image: linear-gradient(#dbdcdc 66%, #3e4c56);
            }

            .webp .bg-wrapper, .no-webp .bg-wrapper {
                background: none;
            }

            .text-section {
                margin: -20px 0 0 0;
            }

            .zh .text-section .text-title {
                font-size: 52px;
            }

            .en .text-section .text-title {
                font-size: 38px;
            }

            .zh .text-section .text-subtitle {
                font-size: 24px;
            }

            .en .text-section .text-subtitle {
                font-size: 21px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 22px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 19px;
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

            .text-shadow {
                text-shadow: none;
            }
        }

        @media all and (max-width:575px) {
            .zh .text-section .text-title {
                font-size: 32px;
            }

            .en .text-section .text-title {
                font-size: 24px;
            }

            .zh .text-section .text-subtitle {
                font-size: 16px;
            }

            .en .text-section .text-subtitle {
                font-size: 16px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 14px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 14px;
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
                    <source srcset="/images/application/products/military-spec-missile-control-cable/impression/military-spec-missile-control-cable-mobile-01.webp"
                        type="image/webp" />
                    <img src="/images/application/products/military-spec-missile-control-cable/impression/military-spec-missile-control-cable-mobile-01.jpg"
                        alt="飛彈控制軍規線 Military Spec Missile Control Cable" />
                </picture>
            </div>
            <div class="container-md">
                <div class="row">
                    <div class="col-md-8">
                        <div class="text-section">
                            <div class="text-subtitle">
                                <div class="subtitle-indent"></div>
                                <%if (RouteData.Values["language"].ToString() == "zh")
                                    {%>
                                                飛彈控制軍規線
                                                <%}
                                                    else
                                                    {%>
                                                Military Spec Missile Control Cable
                                            <%}%>
                            </div>
                            <div class="text-title">
                                <%if (RouteData.Values["language"].ToString() == "zh")
                                    {%>
                                                精準零延遲 完美發射
                                                <%}
                                                    else
                                                    {%>
                                            Zero Delay、Perfect Timing
                                            <%}%>                                
                            </div>
                            <div class="text-image-top d-none d-md-block">
                                <picture>
                                    <source srcset="/images/application/products/military-spec-missile-control-cable/impression/military-spec-missile-control-cable-01.webp"
                                        type="image/webp" />
                                    <img src="/images/application/products/military-spec-missile-control-cable/impression/military-spec-missile-control-cable-01.jpg"
                                        alt="飛彈控制軍規線 Military Spec Missile Control Cable" />
                                </picture>
                            </div>
                            <div class="text-image-top d-md-none">
                                <picture>
                                    <source srcset="/images/application/products/military-spec-missile-control-cable/impression/military-spec-missile-control-cable-mobile-02.webp"
                                        type="image/webp" />
                                    <img src="/images/application/products/military-spec-missile-control-cable/impression/military-spec-missile-control-cable-mobile-02.jpg"
                                        alt="飛彈控制軍規線 Military Spec Missile Control Cable" />
                                </picture>
                            </div>
                            <div class="text-content text-shadow">
                                <%if (RouteData.Values["language"].ToString() == "zh")
                                    {%>
                                飛彈控制系統是一個綜合性很強的複雜系統，透過訊號傳遞所獲取的信息，引導飛彈攻擊目標的技術方法和手段，飛彈性能的優劣，命中目標的精確程度，均由此系統的好壞來決定，控制系統可視為飛彈之靈魂，需達到高精確度及可靠性，不得有任何的誤差及延遲，故導線的訊號回饋的即時性就非常的重要。<br />
                                此電線導體使用超高無氧、高純度、高導電導體，提供訊號傳遞及電力，並使用符合綠色能量 Silicone 作為絕緣外被，無毒無味、耐腐蝕化學品...等特性，可耐200<span class="special-char-font">°</span>C耐壓750V。
                                                <%}
                                                    else
                                                    {%>
                                                Missile guidance system is a highly complex, multi-dimensional system. It utilizes data from split second signal transmittance to make accurate projection of the missile. The guidance system is the heart and soul of the launcher, and a reliable cable which allows timely network feedback is the backbone. <br />
                                                The Military Spec Missile Control Cable uses top notch conductor, which allows clean and fast signal and electricity transmission, along with non-toxic silicone insulation which makes it safe to use in most environment.
                                            <%}%>
                            </div>
                            <div class="d-none d-md-flex justify-content-center text-image">
                                <picture>
                                    <img src="/images/application/products/military-spec-missile-control-cable/impression/military-spec-missile-control-cable-02-<%=RouteData.Values["language"].ToString() %>.svg"
                                        alt="飛彈控制軍規線結構 Military Spec Missile Control Cable Structure" class="mx-auto" />
                                </picture>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 d-none d-md-flex align-items-end">
                        <picture>
                            <source srcset="/images/application/products/military-spec-missile-control-cable/impression/military-spec-missile-control-cable-03.webp"
                                type="image/webp" />
                            <img src="/images/application/products/military-spec-missile-control-cable/impression/military-spec-missile-control-cable-03.png"
                                alt="飛彈控制軍規線 Military Spec Missile Control Cable" />
                        </picture>
                    </div>
                </div>
            </div>


            <div class="container d-md-none">
                <div class="d-flex justify-content-center text-image">
                    <picture>
                        <img src="/images/application/products/military-spec-missile-control-cable/impression/military-spec-missile-control-cable-02-<%=RouteData.Values["language"].ToString() %>.svg"
                            alt="飛彈控制軍規線結構 Military Spec Missile Control Cable Structure" class="mx-auto" />
                    </picture>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

