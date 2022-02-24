<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="dual-insulation-high-voltage-silicone-wire.aspx.cs" Inherits="application_dual_insulation_high_voltage_silicone_wire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title><%if (RouteData.Values["language"].ToString() == "zh")
               {%>
                                                雙層絕緣高壓測試線-日進電線
                                                <%}
                                                    else
                                                    {%>
                                                Dual Insulation High Voltage Silicone Wire - Nizing Electric Wire & Cable
                                            <%}%></title>
    <meta name="description" content=
                            <%if (RouteData.Values["language"].ToString() == "zh")
        {%>                     
                                    "電子產品在上市前都需要通過一系列嚴格的測試來確保品質和安全性，測試產品大多為電腦週邊設備、家電產品、通信產品 電熱管...等。在這些安全測試項目裡頭，耐壓測試是最常見的也是被所有電氣安全標準所要求必須執行的測試項目之一，藉由耐壓測試儀對產品施加瞬態高壓來驗證及測試其產品的絕緣能力是否合格，而產品無法通過測驗，讓產品即具有極大的風險會對使用者有觸電造成傷害或死亡的可能。加強雙層絕緣的高壓測試線可承受更強大的高壓電流，線材更耐電暈性和耐電弧性、更安全、耐寒耐熱、具有更長的壽命，材質較柔軟，耐蝕、抗氧化、性能強，可大大延長線纜的使用壽命，優質的導體導電性能良好。"
                                                <%}
        else
        {%>
                                    "Prior to the launch of any electrical devices, they are required to pass a series of tests to ensure their quality and safety.  Within these tests, voltage resistance test is one of the most common requirement for nearly all the devices.  The voltage resistance test is used to determine if the device can be safely used in situations where a spike of voltage may pass through.  The dual insulation high voltage silicone wire is designed to withstand extremely high voltage, with materials that is resistant to not just electrical properties, but also physical properties such as bending, and chemical properties like corrosion, giving the product greater performance and longer lifespan."
                                            <%}%> />
    <meta property="og:type" content="article" />
    <meta property="og:title" content=
        <%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "雙層絕緣高壓測試線-日進電線"
                                                <%}
        else
        {%>
                                                "Dual Insulation High Voltage Silicone Wire - Nizing Electric Wire & Cable"
                                            <%}%> />
    <meta property="og:description" content=
                            <%if (RouteData.Values["language"].ToString() == "zh")
        {%>                     
                                    "電子產品在上市前都需要通過一系列嚴格的測試來確保品質和安全性，測試產品大多為電腦週邊設備、家電產品、通信產品 電熱管...等。在這些安全測試項目裡頭，耐壓測試是最常見的也是被所有電氣安全標準所要求必須執行的測試項目之一，藉由耐壓測試儀對產品施加瞬態高壓來驗證及測試其產品的絕緣能力是否合格，而產品無法通過測驗，讓產品即具有極大的風險會對使用者有觸電造成傷害或死亡的可能。加強雙層絕緣的高壓測試線可承受更強大的高壓電流，線材更耐電暈性和耐電弧性、更安全、耐寒耐熱、具有更長的壽命，材質較柔軟，耐蝕、抗氧化、性能強，可大大延長線纜的使用壽命，優質的導體導電性能良好。"
                                                <%}
        else
        {%>
                                    "Prior to the launch of any electrical devices, they are required to pass a series of tests to ensure their quality and safety.  Within these tests, voltage resistance test is one of the most common requirement for nearly all the devices.  The voltage resistance test is used to determine if the device can be safely used in situations where a spike of voltage may pass through.  The dual insulation high voltage silicone wire is designed to withstand extremely high voltage, with materials that is resistant to not just electrical properties, but also physical properties such as bending, and chemical properties like corrosion, giving the product greater performance and longer lifespan."
                                            <%}%> />
    <meta property="og:image" content="https://www.nizing.com.tw/images/application/products/dual-insulation-high-voltage-silicone-wire/impression/dual-insulation-high-voltage-silicone-wire-01-mobile.jpg" />
    <meta property="og:url" content="https://www.nizing.com.tw/<%=RouteData.Values["language"].ToString() %>/application/misc-app/dual-insulation-high-voltage-silicone-wire" />
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
            background-color: #ffffff !important;
        }

        .text-section {
            margin-top: 20px;
            margin-bottom: 20px;
            font-weight: bold;
        }

            .text-section .text-title {
                color: #c30d23;
                line-height: 1;
                padding: 15px 0;
                width: 100%;
            }

        .zh .text-section .text-title {
            font-size: 63px;
        }

        .en .text-section .text-title {
            font-size: 56px;
        }

        .text-section .text-subtitle {
            display: flex;
            color: #171c61;
            align-items: baseline;
            width: 76%;
        }

        .zh .text-section .text-subtitle {
            font-size: 29px;
        }

        .en .text-section .text-subtitle {
            font-size: 23px;
        }

        .text-section .text-subtitle .subtitle-indent {
            background-color: #171c61;
            aspect-ratio: 1/3;
            margin: auto 5px auto 0;
        }

        .zh .text-section .text-subtitle .subtitle-indent {
            height: 26px;
        }

        .en .text-section .text-subtitle .subtitle-indent {
            height: 22px;
        }

        .text-section .text-content {
            color: #2d3e56;
            padding-bottom: 24px;
        }

        .zh .text-section .text-content {
            font-size: 22px;
            text-align: justify;
        }

        .en .text-section .text-content {
            font-size: 18px;
        }

        .text-section .text-image {
            width: 65%;
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
                border-radius: 5px;
                font-size: 14px;
            }

        .image-vertical-center {
            margin: auto 0;
        }

        @media all and (max-width:1423px) {
            .zh .text-section .text-title {
                font-size: 63px;
            }

            .en .text-section .text-title {
                font-size: 56px;
            }

            .zh .text-section .text-subtitle {
                font-size: 29px;
            }

            .en .text-section .text-subtitle {
                font-size: 23px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 26px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 22px;
            }

            .zh .text-section .text-content {
                font-size: 22px;
            }

            .en .text-section .text-content {
                font-size: 18px;
            }
        }

        @media all and (max-width:1199px) {
            .content-wrapper {
                padding: 0 15px;
            }

            .zh .text-section .text-title {
                font-size: 51px;
            }

            .en .text-section .text-title {
                font-size: 46px;
            }

            .zh .text-section .text-subtitle {
                font-size: 23px;
            }

            .en .text-section .text-subtitle {
                font-size: 18px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 20px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 15px;
            }

            .text-section .text-content {
                padding-bottom: 20px;
            }

            .zh .text-section .text-content {
                font-size: 18px;
            }

            .en .text-section .text-content {
                font-size: 15px;
            }

            .text-section .text-image {
                width: 80%;
            }
        }

        @media all and (max-width:991px) {
            .zh .text-section .text-title {
                font-size: 38px;
            }

            .en .text-section .text-title {
                font-size: 34px;
            }

            .zh .text-section .text-subtitle {
                font-size: 17px;
            }

            .en .text-section .text-subtitle {
                font-size: 13px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 16px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 12px;
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
                font-size: 55px;
            }            

            .en .text-section .text-title {
                font-size: 49px;
            }

            .text-section .text-subtitle {
                width: 90%;
            }

            .zh .text-section .text-subtitle {
                font-size: 30px;
            }

            .en .text-section .text-subtitle {
                font-size: 24px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 25px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 18px;
            }

            .zh .text-section .text-content {
                font-size: 23px;
            }

            .en .text-section .text-content {
                font-size: 18px;
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
                font-size: 35px;
            }

            .en .text-section .text-title {
                font-size: 30px;
            }

            .zh .text-section .text-subtitle {
                font-size: 18px;
            }

            .en .text-section .text-subtitle {
                font-size: 15px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 17px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 13px;
            }

            .zh .text-section .text-content {
                font-size: 15px;
            }

            .en .text-section .text-content {
                font-size: 15px;
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
                    <source srcset="/images/application/products/dual-insulation-high-voltage-silicone-wire/impression/dual-insulation-high-voltage-silicone-wire-01-mobile.webp"
                        type="image/webp" />
                    <img src="/images/application/products/dual-insulation-high-voltage-silicone-wire/impression/dual-insulation-high-voltage-silicone-wire-01-mobile.jpg"
                        alt="雙層絕緣高壓測試線 Dual Insulation High Voltage Silicone Wire" />
                </picture>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="text-section">
                        <div class="text-subtitle">
                                <div class="subtitle-indent"></div>
                                <%if (RouteData.Values["language"].ToString() == "zh")
                                    {%>
                                                安全把關最佳守門員-耐壓測試儀
                                                <%}
                                                    else
                                                    {%>
                                                The Safety Guardian - Voltage Test Kit
                                            <%}%>
                            </div>
                        <div class="text-title">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>                     
                                    雙層絕緣高壓測試線
                                                <%}
                                                    else
                                                    {%>
                                    Dual Insulation High Voltage Silicone Wire
                                            <%}%>
                        </div>
                        <div class="text-content">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>                     
                                    電子產品在上市前都需要通過一系列嚴格的測試來確保品質和安全性，測試產品大多為電腦週邊設備、家電產品、通信產品 電熱管...等。在這些安全測試項目裡頭，耐壓測試是最常見的也是被所有電氣安全標準所要求必須執行的測試項目之一，藉由耐壓測試儀對產品施加瞬態高壓來驗證及測試其產品的絕緣能力是否合格，而產品無法通過測驗，讓產品即具有極大的風險會對使用者有觸電造成傷害或死亡的可能。<br />
                            加強雙層絕緣的高壓測試線可承受更強大的高壓電流，線材更耐電暈性和耐電弧性、更安全、耐寒耐熱、具有更長的壽命，材質較柔軟，耐蝕、抗氧化、性能強，可大大延長線纜的使用壽命，優質的導體導電性能良好。
                                                <%}
                                                    else
                                                    {%>
                                    Prior to the launch of any electrical devices, they are required to pass a series of tests to ensure their quality and safety.  Within these tests, voltage resistance test is one of the most common requirement for nearly all the devices.  The voltage resistance test is used to determine if the device can be safely used in situations where a spike of voltage may pass through.<br />
                            The dual insulation high voltage silicone wire is designed to withstand extremely high voltage, with materials that is resistant to not just electrical properties, but also physical properties such as bending, and chemical properties like corrosion, giving the product greater performance and longer lifespan.
                                            <%}%>
                        </div>
                        <div class="d-flex justify-content-left text-image">
                            <picture>
                                <img src="/images/application/products/dual-insulation-high-voltage-silicone-wire/impression/dual-insulation-high-voltage-silicone-wire-structure-02-<%=RouteData.Values["language"].ToString() %>.svg"
                                    alt="雙層絕緣高壓測試線 Dual Insulation High Voltage Silicone Wire" class="mx-auto" />
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
                            </div>
                    </div>
                </div>
                <div class="d-none d-md-flex col-md-6 image-vertical-center">
                    <picture>
                        <source srcset="/images/application/products/dual-insulation-high-voltage-silicone-wire/impression/dual-insulation-high-voltage-silicone-wire-01.webp"
                            type="image/webp" />
                        <img src="/images/application/products/dual-insulation-high-voltage-silicone-wire/impression/dual-insulation-high-voltage-silicone-wire-01.jpg"
                            alt="雙層絕緣高壓測試線 Dual Insulation High Voltage Silicone Wire" />
                    </picture>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

