<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="fighter-jet-temperature-sensor-cable.aspx.cs" Inherits="application_fighter_jet_temperature_sensor_cable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title><%if (RouteData.Values["language"].ToString() == "zh")
               {%>
                                                戰鬥機溫控線-日進電線 2021
                                                <%}
                                                    else
                                                    {%>
                                                Fighter Jet Temperature Control Cable - Nizing Electric Wire & Cable
                                            <%}%></title>
    <meta name="description" content=
        <%if (RouteData.Values["language"].ToString() == "zh")
        {%>                                                
                                "戰鬥機的設計結構繁複精密，在任一環節都不允許任何出錯的可能，在電線上的選擇更不能馬虎，戰鬥機內感溫線須具備抗高溫及卓越耐腐蝕性及極強的耐絕緣性，此款產品使用可耐高低溫性的PFA鐵氟龍材質，具有最優秀可連續使用溫度260°C，且具耐腐蝕及耐絕緣性二項特色，並在內層搭配多重防雜訊隔離使其數值回饋更加精準，提高可靠性及安全性。"
                                                <%}
        else
        {%>
                                "A war machine like the fighter jet has highly complex design to ensure its reliability in the most volatile situation, and the components it exhibits must be up to the challenge. The cables it relies on to transfer accurate and precise data swiftly between components is of utmost importance. The Fighter Jet Temperature Control Cable possesses PFA jacket for superior anti-corrosion and insulation properties to ensure safety, as well as anti-interference shielding to guarantee data integrity, making it the best cable for the job."
                                            <%}%>         />
    <meta property="og:type" content="article" />
    <meta property="og:title" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "戰鬥機溫控線-日進電線 2021"
                                                <%}
        else
        {%>
                                                "Fighter Jet Temperature Control Cable - Nizing Electric Wire & Cable"
                                            <%}%> />
    <meta property="og:description" content=
        <%if (RouteData.Values["language"].ToString() == "zh")
        {%>                                                
                                "戰鬥機的設計結構繁複精密，在任一環節都不允許任何出錯的可能，在電線上的選擇更不能馬虎，戰鬥機內感溫線須具備抗高溫及卓越耐腐蝕性及極強的耐絕緣性，此款產品使用可耐高低溫性的PFA鐵氟龍材質，具有最優秀可連續使用溫度260°C，且具耐腐蝕及耐絕緣性二項特色，並在內層搭配多重防雜訊隔離使其數值回饋更加精準，提高可靠性及安全性。"
                                                <%}
        else
        {%>
                                "A war machine like the fighter jet has highly complex design to ensure its reliability in the most volatile situation, and the components it exhibits must be up to the challenge. The cables it relies on to transfer accurate and precise data swiftly between components is of utmost importance. The Fighter Jet Temperature Control Cable possesses PFA jacket for superior anti-corrosion and insulation properties to ensure safety, as well as anti-interference shielding to guarantee data integrity, making it the best cable for the job."
                                            <%}%> />
    <meta property="og:image" content="https://www.nizing.com.tw/images/application/products/fighter-jet-temperature-sensor-cable/impression/fighter-jet-temperature-sensor-cable-01.png" />
    <meta property="og:url" content="https://www.nizing.com.tw/<%=RouteData.Values["language"].ToString() %>/application/misc-app/fighter-jet-temperature-sensor-cable" />
    <meta property="og:site_name" content="Nizing Electric Wire and Cable" />
    <style type="text/css">
        .breadcrumb {
            display: none;
        }

        .content-wrapper {
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
            background: url("/images/application/products/fighter-jet-temperature-sensor-cable/impression/fighter-jet-temperature-sensor-cable-bg.webp") no-repeat right / contain;
        }

        .no-webp .bg-wrapper {
            background: url("/images/application/products/fighter-jet-temperature-sensor-cable/impression/fighter-jet-temperature-sensor-cable-bg.jpg") no-repeat right / contain;
        }

        .bg-color {
            background-color: #5B6C88 !important;
        }

        .text-blue {
            color: #C0FBFF;
        }

        .text-section {
            padding: 0 36px 0 150px;
            margin-top: -260px;
        }

        .zh .text-section {
            text-align: justify;
        }

        .text-section > div {
            padding-bottom: 1rem;
        }

        .zh .text-section .top {
            font-size: 24px;
        }

        .en .text-section .top {
            font-size: 23px;
        }

        .zh .text-section .middle {
            font-size: 48px;
        }

        .en .text-section .middle {
            font-size: 34px;
        }

        .text-section .middle p {
            margin: 0;
        }

            .text-section .middle p:nth-child(2) {
                margin-left: 12px;
            }

        .zh .text-section .bottom {
            font-size: 20px;
        }

        .en .text-section .bottom {
            font-size: 19px;
        }

        @media all and (max-width:1199px) {
            .content-wrapper {
                max-height: none;
            }

            .text-section {
                padding-left: 36px;
                margin-top: -150px;
            }

            .zh .text-section .top {
                font-size: 20px;
            }

            .en .text-section .top {
                font-size: 24px;
            }

            .zh .text-section .middle {
                font-size: 40px;
            }

            .en .text-section .middle {
                font-size: 36px;
            }
        }

        @media all and (max-width:991px) {
            .text-section {
                margin-top: -120px;
            }

            .zh .text-section .top {
                font-size: 18px;
            }

            .en .text-section .top {
                font-size: 17px;
            }

            .zh .text-section .middle {
                font-size: 36px;
            }

            .en .text-section .middle {
                font-size: 26px;
            }

            .zh .text-section .bottom {
                font-size: 16px;
            }

            .en .text-section .bottom {
                font-size: 16px;
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
                margin-top: 0px;
            }

                .text-section .top {
                    font-size: 22px;
                }

                .text-section .middle {
                    font-size: 32px;
                }

                .text-section .bottom {
                    font-size: 16px;
                }
        }

        @media all and (max-width:575px) {
            .zh .text-section .top {
                font-size: 20px;
            }

            .en .text-section .top {
                font-size: 17px;
            }

            .zh .text-section .middle {
                font-size: 28px;
            }

            .en .text-section .middle {
                font-size: 25px;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="container-fluid bg-wrapper bg-color <%=RouteData.Values["language"].ToString() %>">
        <div class="content-wrapper">
            <div class="row">
                <div class="col-md-6"></div>
                <div class="col-md-6 d-flex justify-content-end">
                    <picture>
                        <source srcset="/images/application/products/fighter-jet-temperature-sensor-cable/impression/fighter-jet-temperature-sensor-cable-01.webp"
                            type="image/webp" />
                        <img src="/images/application/products/fighter-jet-temperature-sensor-cable/impression/fighter-jet-temperature-sensor-cable-01.png"
                            alt="戰鬥機溫控線  Fighter Jet Temperature Sensor Cable" />
                    </picture>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="text-section">
                        <div class="top text-blue">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>                                                
                                戰鬥機溫控線 日本軍規配線
                                                <%}
                                                    else
                                                    {%>
                                                Fighter Jet Temperature Control Cable
                                            <%}%>
                        </div>
                        <div class="middle text-white d-flex">
                            <p>
                                <%if (RouteData.Values["language"].ToString() == "zh")
                                    {%>                                                
                                精準回饋
                                                <%}
                                                    else
                                                    {%>
                                                PRECISION
                                            <%}%>
                            </p>
                            <p>
                                <%if (RouteData.Values["language"].ToString() == "zh")
                                    {%>                                                
                                攻守兼備
                                                <%}
                                                    else
                                                    {%>
                                                ACCURACY
                                            <%}%>
                            </p>
                        </div>
                        <div class="bottom text-white">
                                <%if (RouteData.Values["language"].ToString() == "zh")
                                    {%>                                                
                                戰鬥機的設計結構繁複精密，在任一環節都不允許任何出錯的可能，在電線上的選擇更不能馬虎，戰鬥機內感溫線須具備抗高溫及卓越耐腐蝕性及極強的耐絕緣性，此款產品使用可耐高低溫性的PFA鐵氟龍材質，具有最優秀可連續使用溫度260°C，且具耐腐蝕及耐絕緣性二項特色，並在內層搭配多重防雜訊隔離使其數值回饋更加精準，提高可靠性及安全性。
                                                <%}
                                                    else
                                                    {%>
                                A war machine like the fighter jet has highly complex design to ensure its reliability in the most volatile situation, and the components it exhibits must be up to the challenge. The cables it relies on to transfer accurate and precise data swiftly between components is of utmost importance. The Fighter Jet Temperature Control Cable possesses PFA jacket for superior anti-corrosion and insulation properties to ensure safety, as well as anti-interference shielding to guarantee data integrity, making it the best cable for the job.
                                            <%}%>                            
                        </div>
                        <div class="d-flex justify-content-center limit-width-500">
                            <picture>
                                <img src="/images/application/products/fighter-jet-temperature-sensor-cable/impression/fighter-jet-temperature-sensor-cable-02-<%=RouteData.Values["language"].ToString() %>.svg"
                                    alt="戰鬥機溫控線  Fighter Jet Temperature Sensor Cable Structure" class="mx-auto" />
                            </picture>
                        </div>
                    </div>
                </div>
            </div>
            <div class="d-md-none" style="margin-top: -100px">
                <picture>
                    <source srcset="/images/application/products/fighter-jet-temperature-sensor-cable/impression/fighter-jet-temperature-sensor-cable-03.webp"
                        type="image/webp" />
                    <img src="/images/application/products/fighter-jet-temperature-sensor-cable/impression/fighter-jet-temperature-sensor-cable-03.png"
                        alt="戰鬥機溫控線  Fighter Jet Temperature Sensor Cable" />
                </picture>
            </div>
        </div>
    </div>
</asp:Content>

