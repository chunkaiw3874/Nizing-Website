﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="submarine-communications-cable.aspx.cs" Inherits="application_submarine_communications_cable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title><%if (RouteData.Values["language"].ToString() == "zh")
               {%>
                                                水下不鏽鋼鎧裝海底網路通訊線-日進電線 <%=DateTime.Today.Year.ToString() %>
        <%}
            else
            {%>
                                                Submarine Connumications Cable - Nizing Electric Wire & Cable
                                            <%}%></title>
    <meta name="description" content=
        <%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "使用90A高硬度絕緣外被，先進的線材結構，可長時間浸泡於高密度及高深水壓的海水環境也不易腐蝕變質，堅固耐用且耐魚咬。不鏽鋼鎧裝及多重防雜訊隔離，可阻止外部的電磁干擾進入，保持傳輸網絡信號的穩定快速，品質優越，非常適合安裝於水底或其它嚴苛環境之網路通訊使用。"
                            <%}
        else
        {%>
                                                "Uses 90A high density insulation, with advance composition, this cable can withstand the massive pressure of the deep sea, and strong enough to endure the wear and tear of underwater creatures. The multiple layers of noise cancellation insulations can keep the signals stable, making it ideal for the extreme conditions of the sea."
                                            <%}%>/>
    <meta property="og:type" content="article" />
    <meta property="og:title" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "水下不鏽鋼鎧裝海底網路通訊線-日進電線 <%=DateTime.Now.Year.ToString() %>"
        <%}
        else
        {%>
                                                "Submarine Connumications Cable - Nizing Electric Wire & Cable"
                                            <%}%> />
    <meta property="og:description" content=
        <%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "使用90A高硬度絕緣外被，先進的線材結構，可長時間浸泡於高密度及高深水壓的海水環境也不易腐蝕變質，堅固耐用且耐魚咬。不鏽鋼鎧裝及多重防雜訊隔離，可阻止外部的電磁干擾進入，保持傳輸網絡信號的穩定快速，品質優越，非常適合安裝於水底或其它嚴苛環境之網路通訊使用。"
                            <%}
        else
        {%>
                                                "Uses 90A high density insulation, with advance composition, this cable can withstand the massive pressure of the deep sea, and strong enough to endure the wear and tear of underwater creatures. The multiple layers of noise cancellation insulations can keep the signals stable, making it ideal for the extreme conditions of the sea."
                                            <%}%>/> />
    <meta property="og:image" content="https://www.nizing.com.tw/images/application/products/submarine-communications-cable/impression/submarine-communications-cable-01-mobile.jpg" />
    <meta property="og:url" content="https://www.nizing.com.tw/<%=RouteData.Values["language"].ToString() %>/application/cloud-system/submarine-communications-cable" />
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
            background: url("/images/application/products/submarine-communications-cable/impression/submarine-communications-cable-bg.webp") no-repeat top right / contain;
        }

        .no-webp .bg-wrapper {
            background: url("/images/application/products/submarine-communications-cable/impression/submarine-communications-cable-bg.jpg") no-repeat top right / contain;
        }

        .bg-color {
            background-color: #012fb6 !important;
        }

        .bottom-image {
            position: absolute;
            top: 320px;
            right: 0;
            width: 40%;
        }

        .text-section {
            padding: 0 46px 0 150px;
            margin-top: 40px;
            margin-bottom: 150px;
            font-weight: bold;
        }

            .text-section .text-title {
                font-size: 44px;
                color: #FFF000;
                line-height: 1.3;
                padding: 20px 0;
            }


            .text-section .text-subtitle {
                display: flex;
                font-size: 28px;
                color: #ffffff;
                align-items: baseline;
                line-height: 1;
            }

                .text-section .text-subtitle .subtitle-indent {
                    background-color: #fff000;
                    aspect-ratio: 1/3;
                    height: 24px;
                    margin: auto 5px auto 0;
                }

            .text-section .text-content {
                font-size: 20px;
                color: #ffffff;
                padding-bottom: 24px;
            }

            .text-section .text-image {
                width: 70%;
                margin: 0 auto;
            }

        @media all and (max-width:1199px) {
            .text-section {
                padding-left: 46px;
                margin-top: 40px;
                margin-bottom: 40px;
            }

            .bottom-image {
                top: 280px;
                width: 45%;
            }

            .text-section .text-title {
                font-size: 42px;
                padding-bottom: 14px;
            }

            .text-section .text-subtitle {
                padding-bottom: 16px;
            }

            .zh .text-section .text-subtitle {
                font-size: 26px;
            }

            .en .text-section .text-subtitle {
                font-size: 23px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 22px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 20px;
            }

            .text-section .text-content {
                font-size: 16px;
                padding-bottom: 20px;
            }

            .text-section .text-image {
                width: 100%;
            }
        }

        @media all and (max-width:991px) {
            .bg-color-gradient {
                background-color: none;
            }

            .text-section {
                margin-top: 40px;
                margin-bottom: 100px;
            }

            .bottom-image {
                top: 250px;
                width: 50%;
            }

            .text-section .text-title {
                font-size: 30px;
            }

            .zh .text-section .text-subtitle {
                font-size: 20px;
            }

            .en .text-section .text-subtitle {
                font-size: 16px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 18px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 15px;
            }

            .text-section .text-content {
                font-size: 16px;
            }
        }

        @media all and (max-width:767px) {
            .bg-color-gradient {
                background-image: linear-gradient(#012fb6, #00246c);
            }

            .webp .bg-wrapper {
                background: none;
            }

            .no-webp .bg-wrapper {
                background: none;
            }

            .text-section {
                margin-top: 20px;
                padding: 0 20px;
                margin-bottom: 40px;
            }

                .text-section .text-title {
                    font-size: 56px;
                }

            .zh .text-section .text-subtitle {
                font-size: 26px;
            }

            .en .text-section .text-subtitle {
                font-size: 26px;
            }

            .zh .text-section .text-subtitle .subtitle-indent {
                height: 24px;
            }

            .en .text-section .text-subtitle .subtitle-indent {
                height: 24px;
            }

            .text-section .text-content {
                font-size: 16px;
            }
        }

        @media all and (max-width:575px) {
            .text-section .text-title {
                font-size: 36px;
            }

            .en .text-section .text-subtitle {
                font-size: 18px;
            }

                .en .text-section .text-subtitle .subtitle-indent {
                    height: 16px;
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
                    <source srcset="/images/application/products/submarine-communications-cable/impression/submarine-communications-cable-01-mobile.webp"
                        type="image/webp" />
                    <img src="/images/application/products/submarine-communications-cable/impression/submarine-communications-cable-01-mobile.jpg"
                        alt="水下不鏽鋼鎧裝海底網路通訊線 Submarine Communications Cable" />
                </picture>
            </div>
            <div class="row bg-color-gradient">
                <div class="col-md-6">
                    <div class="text-section">
                        <div class="text-subtitle">
                            <div class="subtitle-indent"></div>
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>
                                                水下不鏽鋼鎧裝網路線
                            <%}
                                else
                                {%>
                                                Submarine Connumications Cable
                                            <%}%>
                        </div>
                        <div class="text-title">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>
                                                90A高硬度 防水解<br />
                                                不鏽鋼鎧裝多重防護
                            <%}
                                else
                                {%>
                                                90A High Density<br />
                                                Noise-Cancellation
                                            <%}%>                            
                        </div>
                        <div class="text-content">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>
                                                使用90A高硬度絕緣外被，先進的線材結構，可長時間浸泡於高密度及高深水壓的海水環境也不易腐蝕變質，堅固耐用且耐魚咬。不鏽鋼鎧裝及多重防雜訊隔離，可阻止外部的電磁干擾進入，保持傳輸網絡信號的穩定快速，品質優越，非常適合安裝於水底或其它嚴苛環境之網路通訊使用。
                            <%}
                                else
                                {%>
                                                Uses 90A high density insulation, with advance composition, this cable can withstand the massive pressure of the deep sea, and strong enough to endure the wear and tear of underwater creatures. The multiple layers of noise cancellation insulations can keep the signals stable, making it ideal for the extreme conditions of the sea.
                                            <%}%>
                        </div>
                        <div class="d-flex justify-content-center text-image">
                            <picture>
                                <img src="/images/application/products/submarine-communications-cable/impression/submarine-communications-cable-03-<%=RouteData.Values["language"].ToString() %>.svg"
                                    alt="水下不鏽鋼鎧裝海底網路通訊線結構 Submarine Communications Cable Structure" class="mx-auto" />
                            </picture>
                        </div>
                    </div>
                </div>
            </div>
            <div class="d-none d-md-flex bottom-image">
                <picture>
                    <source srcset="/images/application/products/submarine-communications-cable/impression/submarine-communications-cable-02.webp"
                        type="image/webp" />
                    <img src="/images/application/products/submarine-communications-cable/impression/submarine-communications-cable-02.png"
                        alt="水下不鏽鋼鎧裝海底網路通訊線 Submarine Communications Cable" />
                </picture>
            </div>
        </div>
    </div>
</asp:Content>

