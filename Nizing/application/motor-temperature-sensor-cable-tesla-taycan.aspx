<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="motor-temperature-sensor-cable-tesla-taycan.aspx.cs" Inherits="application_motor_temperature_sensor_cable_tesla_taycan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title><%if (RouteData.Values["language"].ToString() == "zh")
               {%>
                                                IATF-16949 馬達溫度感知線-日進電線 2021
                                                <%}
                                                    else
                                                    {%>
                                                 IATF-16949 Motor Temperature Sensor Cable - Nizing Electric Wire & Cable
                                            <%}%></title>
    <meta name="description" content="電動車內部馬達溫度感知線，為行車安全不可或缺的元件" />
    <meta property="og:type" content="article" />
    <meta property="og:title" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "IATF-16949 馬達溫度感知線-日進電線 2021"
                                                <%}
        else
        {%>
                                                 "IATF-16949 Motor Temperature Sensor Cable - Nizing Electric Wire & Cable"
                                            <%}%> />
    <meta property="og:description" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "汽車馬達內感溫線須具備卓越耐腐蝕性及極強的耐絕緣性，此款產品使用可耐高低溫性的PFA鐵氟龍材質，具備其耐腐蝕及耐絕緣性二項特色外，並搭配多重防雜訊隔離使其數值回饋更加精準，優秀的品質是多家知名車廠指定使用之線材。"
                                                <%}
        else
        {%>
                                                 "The temperature sensor cable inside an automobile motor must have excellent corrosion and electric resistance. This cable uses PFA Teflon insulation, which is known for its wide temperature range, extreme chemical resistance, and high voltage protection, in combination with noise insulation, making the feedbacks much more accurate."
                                            <%}%> />
    <meta property="og:image" content="https://www.nizing.com.tw/images/application/products/motor-temperature-sensor-cable-tesla-taycan/impression/motor-temperature-sensor-cable-tesla-taycan-02.jpg" />
    <meta property="og:url" content="https://www.nizing.com.tw/<%=RouteData.Values["language"].ToString() %>/application/automobile/motor-temperature-sensor-cable" />
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

        .bg-black {
            background-color: #080403 !important;
        }

        .text-blue {
            color: #2ca6e0;
        }

        .text-section .top {
            padding-top: 1.5rem;
            padding-bottom: 1rem;
        }

        .zh .text-section .top {
            font-size: 24px;
        }

        .en .text-section .top {
            font-size: 20px;
        }

        .text-section {
            padding-right: 48px;
            font-weight: bold;
        }

            .text-section .middle {
                padding-bottom: 1rem;
            }

        .zh .text-section .middle {
            font-size: 32px;
        }

        .en .text-section .middle {
            font-size: 28px;
        }

        .text-section .middle p {
            margin: 0;
        }

        .text-section .bottom {
            padding-bottom: 1rem;
        }

        .zh .text-section .bottom {
            font-size: 18px;
        }

        .en .text-section .bottom {
            font-size: 18px;
        }

        .img-small {
            width: 70%;
        }

        @media all and (max-width:1199px) {
            .zh .text-section .top {
                font-size: 20px;
            }

            .en .text-section .top {
                font-size: 16px;
            }

            .zh .text-section .middle {
                font-size: 28px;
            }

            .en .text-section .middle {
                font-size: 22px;
            }

            .zh .text-section .bottom {
                font-size: 16px;
            }

            .en .text-section .bottom {
                font-size: 16px;
            }
        }

        @media all and (max-width:991px) {
            .zh .text-section .top {
                font-size: 18px;
            }

            .en .text-section .top {
                font-size: 14px;
            }

            .zh .text-section .middle {
                font-size: 20px;
            }

            .en .text-section .middle {
                font-size: 16px;
            }

            .zh .text-section .bottom {
                font-size: 16px;
            }

            .en .text-section .bottom {
                font-size: 14px;
            }
        }

        @media all and (max-width:767px) {
            .text-section {
                padding-right: 15px;
            }

            .zh .text-section .top {
                font-size: 18px;
            }

            .en .text-section .top {
                font-size: 14px;
            }

            .zh .text-section .middle {
                font-size: 22px;
            }

            .en .text-section .middle {
                font-size: 18px;
            }

            .zh .text-section .bottom {
                font-size: 16px;
            }

            .en .text-section .bottom {
                font-size: 14px;
            }

            .img-small {
                width: 100%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="container-fluid">
        <div class="row bg-black m-0 pb-3 <%=RouteData.Values["language"].ToString() %>">
            <div class="col-md-6">
                <picture>
                    <source srcset="/images/application/products/motor-temperature-sensor-cable-tesla-taycan/impression/motor-temperature-sensor-cable-tesla-taycan-01.webp"
                        type="image/webp" />
                    <img src="/images/application/products/motor-temperature-sensor-cable-tesla-taycan/impression/motor-temperature-sensor-cable-tesla-taycan-01.jpg"
                        alt="Taycan Electric Car" />
                </picture>
            </div>
            <div class="col-md-6">
                <div class="container text-section">
                    <div class="top text-blue">
                        <%if (RouteData.Values["language"].ToString() == "zh")
                            {%>
                                                IATF-16949 馬達溫度感知線
                                                <%}
                                                    else
                                                    {%>
                                                 IATF-16949 Motor Temperature Sensor Cable
                                            <%}%>
                    </div>
                    <div class="middle text-white">
                        <p>                            
                        <%if (RouteData.Values["language"].ToString() == "zh")
                            {%>
                                                ”卓越耐腐蝕性、極強的耐絕緣性
                                                <%}
                                                    else
                                                    {%>
                                                 "Anti-Corrosion, Voltage Resistant
                                            <%}%>
                        </p>
                        <p>
                        <%if (RouteData.Values["language"].ToString() == "zh")
                            {%>
                                                多重防雜訊隔離，數據更加精準 ”
                                                <%}
                                                    else
                                                    {%>
                                                 Noise Insulation, Accurate Feedback"
                                            <%}%>
                            
                        </p>
                    </div>
                    <div class="bottom text-white">
                        <%if (RouteData.Values["language"].ToString() == "zh")
                            {%>
                                                汽車馬達內感溫線須具備卓越耐腐蝕性及極強的耐絕緣性，此款產品使用可耐高低溫性的PFA鐵氟龍材質，具備其耐腐蝕及耐絕緣性二項特色外，並搭配多重防雜訊隔離使其數值回饋更加精準，優秀的品質是多家知名車廠指定使用之線材。
                                                <%}
                                                    else
                                                    {%>
                                                 The temperature sensor cable inside an automobile motor must have excellent corrosion and electric resistance. This cable uses PFA Teflon insulation, which is known for its wide temperature range, extreme chemical resistance, and high voltage protection, in combination with noise insulation, making the feedbacks much more accurate.
                                            <%}%>
                    </div>

                </div>
                <div>
                    <picture>
                        <source srcset="/images/application/products/motor-temperature-sensor-cable-tesla-taycan/impression/motor-temperature-sensor-cable-tesla-taycan-02.webp"
                            type="image/webp" />
                        <img src="/images/application/products/motor-temperature-sensor-cable-tesla-taycan/impression/motor-temperature-sensor-cable-tesla-taycan-02.jpg"
                            alt="Tesla and Taycan  Motor Temperature Sensor Wire" />
                    </picture>
                </div>
                <div class="d-flex justify-content-center">
                    <picture>
                        <img src="/images/application/products/motor-temperature-sensor-cable-tesla-taycan/impression/motor-temperature-sensor-cable-tesla-taycan-03-<%=RouteData.Values["language"].ToString() %>.svg"
                            alt="Tesla and Taycan  Motor Temperature Sensor Wire Structure" class="img-small" />
                    </picture>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

