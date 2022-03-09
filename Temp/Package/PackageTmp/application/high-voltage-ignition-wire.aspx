<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="high-voltage-ignition-wire.aspx.cs" Inherits="application_high_voltage_ignition_wire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title><%if (RouteData.Values["language"].ToString() == "zh")
               {%>
                                                高壓點火線-日進電線 2021
                                                <%}
                                                    else
                                                    {%>
                                                High Voltage Ignition Wire - Nizing Electric Wire & Cable
                                            <%}%></title>
    <meta name="description" content=
                            <%if (RouteData.Values["language"].ToString() == "zh")
        {%>                     
                                    "高強度防磁氣高壓點火線可有效降低電阻，能產生強大的火花和點火，改善發動機響應和功率，讓引擎發揮更強的性能，燃燒率提升瞬間點火電力。此線使用防磁三芯電線加上雙層絕緣包覆，增加耐用度並防止電流穿刺，電阻穩定，導電性能相當優越，碳導體點火時，不會產生電磁波以及電磁脈衝影響車內的電子儀器。中層使用玻璃纖維編織纏繞，不燃，抗腐，隔熱，抗拉強度高，電絕緣性好，防止高溫斷裂並提供強度防止膨脹及維持柔韌性。"
                                                <%}
        else
        {%>
                                    "High Voltage Ignition Wire lowers electric resistance, increase the effectiveness of ignition, allowing for greater engine performance. This wire uses three core wires with two insulation jackets , designed to prevent current spike, stablize resistance, and smooth out the current flow, in order to minimize the effect of magnetic wave on the electronic componetns of the vehicle."
                                            <%}%> />
    <meta property="og:type" content="article" />
    <meta property="og:title" content=
        <%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "高壓點火線-日進電線 2021"
                                                <%}
        else
        {%>
                                                "High Voltage Ignition Wire - Nizing Electric Wire & Cable"
                                            <%}%> />
    <meta property="og:description" content=
                            <%if (RouteData.Values["language"].ToString() == "zh")
        {%>                     
                                    "高強度防磁氣高壓點火線可有效降低電阻，能產生強大的火花和點火，改善發動機響應和功率，讓引擎發揮更強的性能，燃燒率提升瞬間點火電力。此線使用防磁三芯電線加上雙層絕緣包覆，增加耐用度並防止電流穿刺，電阻穩定，導電性能相當優越，碳導體點火時，不會產生電磁波以及電磁脈衝影響車內的電子儀器。中層使用玻璃纖維編織纏繞，不燃，抗腐，隔熱，抗拉強度高，電絕緣性好，防止高溫斷裂並提供強度防止膨脹及維持柔韌性。"
                                                <%}
        else
        {%>
                                    "High Voltage Ignition Wire lowers electric resistance, increase the effectiveness of ignition, allowing for greater engine performance. This wire uses three core wires with two insulation jackets , designed to prevent current spike, stablize resistance, and smooth out the current flow, in order to minimize the effect of magnetic wave on the electronic componetns of the vehicle."
                                            <%}%> />
    <meta property="og:image" content="https://www.nizing.com.tw/images/application/products/high-voltage-ignition-wire/impression/high-voltage-ignition-wire-mobile-1.jpg" />
    <meta property="og:url" content="https://www.nizing.com.tw/<%=RouteData.Values["language"].ToString() %>/application/automobile/high-voltage-ignition-wire" />
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
            background: url("/images/application/products/high-voltage-ignition-wire/impression/high-voltage-ignition-wire-1-bg.webp") no-repeat top right / cover;
        }

        .no-webp .bg-wrapper {
            background: url("/images/application/products/high-voltage-ignition-wire/impression/high-voltage-ignition-wire-1-bg.jpg") no-repeat top right / cover;
        }

        .bg-color {
            background-color: #121417 !important;
        }

        .bottom-image {
            position: absolute;
            top: 320px;
            right: 0;
            width: 40%;
        }

        .text-section {
            padding: 0 46px 0 120px;
            margin-top: 40px;
            margin-bottom: 150px;
            font-weight: bold;
        }

            .text-section .text-title {
                color: #FFF000;
                line-height: 1.4;
                padding: 20px 0;
                width: 90%;
            }

        .zh .text-section .text-title {
            font-size: 60px;
        }

        .en .text-section .text-title {
            font-size: 47px;
        }

        .text-section .text-subtitle {
            display: flex;
            color: #ffffff;
            align-items: baseline;
            line-height: 1;
        }

            .text-section .text-subtitle .subtitle-indent {
                background-color: #fc002a;
                width: 10px;
                margin: auto 5px auto 0;
            }

        .zh .text-section .text-subtitle {
            font-size: 26px;
        }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 24px;
            }

        .en .text-section .text-subtitle {
            font-size: 26px;
        }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 24px;
            }

        .text-section .text-content {
            color: #ffffff;
            padding-bottom: 24px;
        }

        .zh .text-section .text-content {
            font-size: 20px;
            text-align: justify;
        }

        .en .text-section .text-content {
            font-size: 20px;
        }

        .text-section .text-image {
            width: 70%;
            margin: 0 auto;
        }

        .text-shadow {
            text-shadow: 5px 5px 10px #000000;
        }

        @media all and (max-width:1423px) {
            .zh .text-section .text-title {
                font-size: 47px;
            }

            .en .text-section .text-title {
                font-size: 37px;
            }

            .zh .text-section .text-subtitle {
                font-size: 23px;
            }

                .zh .text-section .text-subtitle .subtitle-indent {
                    height: 21px;
                }

            .en .text-section .text-subtitle {
                font-size: 21px;
            }

                .en .text-section .text-subtitle .subtitle-indent {
                    height: 19px;
                }

            .text-section .text-content {
                padding-bottom: 20px;
            }

            .zh .text-section .text-content {
                font-size: 18px;
            }

            .en .text-section .text-content {
                font-size: 18px;
            }

            .text-section .text-image {
                width: 80%;
                margin: 0 auto;
            }
        }

        @media all and (max-width:1199px) {
            .text-section {
                margin-top: 40px;
                margin-bottom: 40px;
            }

            .bottom-image {
                top: 280px;
                width: 55%;
            }

            .zh .text-section .text-title {
                font-size: 36px;
            }

            .en .text-section .text-title {
                font-size: 28px;
            }

            .zh .text-section .text-subtitle {
                font-size: 22px;
            }

                .zh .text-section .text-subtitle .subtitle-indent {
                    height: 20px;
                }

            .en .text-section .text-subtitle {
                font-size: 18px;
            }

                .en .text-section .text-subtitle .subtitle-indent {
                    height: 16px;
                }

            .text-section .text-content {
                padding-bottom: 20px;
            }

            .zh .text-section .text-content {
                font-size: 16px;
            }

            .en .text-section .text-content {
                font-size: 18px;
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
                margin-top: 40px;
                margin-bottom: 100px;
                padding-left: 80px;
            }

            .bottom-image {
                top: 270px;
                width: 65%;
            }

            .zh .text-section .text-title {
                font-size: 28px;
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
                font-size: 16px;
            }

                .en .text-section .text-subtitle .subtitle-indent {
                    height: 14px;
                }

            .zh .text-section .text-content {
                font-size: 16px;
            }

            .en .text-section .text-content {
                font-size: 15px;
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
                padding: 0 20px;
                margin-bottom: -100px;
            }

                .text-section .text-title {
                    padding: 18px 0;
                }

            .zh .text-section .text-title {
                font-size: 56px;
            }

            .en .text-section .text-title {
                font-size: 46px;
            }

            .zh .text-section .text-subtitle {
                font-size: 26px;
            }

                .zh .text-section .text-subtitle .subtitle-indent {
                    height: 24px;
                }

            .en .text-section .text-subtitle {
                font-size: 26px;
            }

                .en .text-section .text-subtitle .subtitle-indent {
                    height: 24px;
                }

            .zh .text-section .text-content {
                font-size: 20px;
            }

            .en .text-section .text-content {
                font-size: 20px;
            }
        }

        @media all and (max-width:575px) {
            .text-section .text-title {
                padding: 14px 0;
            }

            .zh .text-section .text-title {
                font-size: 32px;
            }

            .en .text-section .text-title {
                font-size: 29px;
            }

            .zh .text-section .text-subtitle {
                font-size: 20px;
            }

                .zh .text-section .text-subtitle .subtitle-indent {
                    height: 18px;
                }

            .en .text-section .text-subtitle {
                font-size: 18px;
            }

                .en .text-section .text-subtitle .subtitle-indent {
                    height: 16px;
                }

            .zh .text-section .text-content {
                font-size: 16px;
            }

            .en .text-section .text-content {
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
                    <source srcset="/images/application/products/high-voltage-ignition-wire/impression/high-voltage-ignition-wire-mobile-1.webp"
                        type="image/webp" />
                    <img src="/images/application/products/high-voltage-ignition-wire/impression/high-voltage-ignition-wire-mobile-1.jpg"
                        alt="高壓點火線 High Voltage Ignition Wire" />
                </picture>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="text-section">
                        <div class="text-subtitle text-shadow">
                            <div class="subtitle-indent"></div>
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>                                                
                                                汽車高壓點火線圈
                                                <%}
                                                    else
                                                    {%>
                                               High Voltage Ignition Wire
                                            <%}%>
                        </div>
                        <div class="text-title text-shadow">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>                     
                                    雙層絕緣防磁三芯<br />
                                    強大火花瞬間點火
                                                <%}
                                                    else
                                                    {%>
                                               Duo Layer Protection<br />
                                                Tri Core Production
                                            <%}%>
                        </div>
                        <div class="text-content text-shadow">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>                     
                                    高強度防磁氣高壓點火線可有效降低電阻，能產生強大的火花和點火，改善發動機響應和功率，讓引擎發揮更強的性能，燃燒率提升瞬間點火電力。此線使用防磁三芯電線加上雙層絕緣包覆，增加耐用度並防止電流穿刺，電阻穩定，導電性能相當優越，碳導體點火時，不會產生電磁波以及電磁脈衝影響車內的電子儀器。中層使用玻璃纖維編織纏繞，不燃，抗腐，隔熱，抗拉強度高，電絕緣性好，防止高溫斷裂並提供強度防止膨脹及維持柔韌性。
                                                <%}
                                                    else
                                                    {%>
                                    High Voltage Ignition Wire lowers electric resistance, increase the effectiveness of ignition, allowing for greater engine performance. This wire uses three core wires with two insulation jackets , designed to prevent current spike, stablize resistance, and smooth out the current flow, in order to minimize the effect of magnetic wave on the electronic componetns of the vehicle.
                                            <%}%>
                        </div>
                        <div class="d-flex justify-content-center text-image">
                            <picture>
                                <img src="/images/application/products/high-voltage-ignition-wire/impression/high-voltage-ignition-wire-3-structure-<%=RouteData.Values["language"].ToString() %>.svg"
                                    alt="高壓點火線 High Voltage Ignition Wire" class="mx-auto" />
                            </picture>
                        </div>
                    </div>
                </div>
            </div>
            <div class="d-none d-md-flex bottom-image">
                <picture>
                    <source srcset="/images/application/products/high-voltage-ignition-wire/impression/high-voltage-ignition-wire-2.webp"
                        type="image/webp" />
                    <img src="/images/application/products/high-voltage-ignition-wire/impression/high-voltage-ignition-wire-2.png"
                        alt="高壓點火線 High Voltage Ignition Wire" />
                </picture>
            </div>
            <div class="d-md-none">
                <picture>
                    <source srcset="/images/application/products/high-voltage-ignition-wire/impression/high-voltage-ignition-wire-mobile-2.webp"
                        type="image/webp" />
                    <img src="/images/application/products/high-voltage-ignition-wire/impression/high-voltage-ignition-wire-mobile-2.jpg"
                        alt="" />
                </picture>
            </div>
        </div>
    </div>
</asp:Content>

