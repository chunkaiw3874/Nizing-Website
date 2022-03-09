<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="contact_us.aspx.cs" Inherits="contact_us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>日進電線-聯絡我們</title>
    <style>
        .banner .img {
            width: 100%;
        }

        .person-wrapper {
            padding: 1rem 0;
        }

        .person-frame {
            box-shadow: 10px 10px 10px 0 rgba(0, 0, 0, 0.5);
        }

            .person-frame img {
                width: 100%;
            }

        .person-text {
            padding-top: 15px;
            text-align: center;
        }

            .person-text .person-email {
                padding-top: 20px;
                word-wrap: break-word;
            }

        .address-section {
            padding-top: 0px !important;
        }

            .address-section .title {
                padding: 2rem 0;
                font-size: inherit;
            }

                .address-section .title .chinese {
                    font-size: 20px;
                }

            .address-section .map {
                max-width: 600px;
                margin-left: auto;
                margin-right: auto;
            }

            .address-section .content {
                font-size: 14px;
            }

        @media all and (max-width:768px) {
            .person-text .person-email {
                font-size: 14px;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    <div class="banner">
        <picture>
            <source srcset="/images/banner/banner-contact-en.webp" type="image/webp" />
            <img src="/images/banner/banner-contact-en.png" />
        </picture>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    國內業務代表
                </div>
                <div class="subtitle">
                    Domestic Sales Rep
                </div>
                <div class="block content">
                    <div class="row row-cols-2 row-cols-md-3">
                        <div class="col">
                            <div class="person-wrapper">
                                <div class="person-frame">
                                    <div class="d-flex justify-content-center">
                                        <picture>
                                            <source srcset="/images/contact/Chris Huang.webp" type="image/webp" />
                                            <img src="/images/contact/Chris Huang.png" />
                                        </picture>
                                    </div>
                                </div>
                                <div class="person-text">
                                    <div>
                                        Chris Huang
                                    </div>
                                    <div class="person-name chinese">
                                        黃憲騰
                                    </div>
                                    <div class="person-email">
                                        chris@nizing.com.tw
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="person-wrapper">
                                <div class="person-frame">
                                    <div class="d-flex justify-content-center">
                                        <picture>
                                            <source srcset="/images/contact/Kelven Chao.webp" type="image/webp" />
                                            <img src="/images/contact/Kelven Chao.png" />
                                        </picture>
                                    </div>
                                </div>
                                <div class="person-text">
                                    <div>
                                        Kelven Chao
                                    </div>
                                    <div class="person-name chinese">
                                        趙重鈞
                                    </div>
                                    <div class="person-email">
                                        kelven33033@nizing.com.tw
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="person-wrapper">
                                <div class="person-frame">
                                    <div class="d-flex justify-content-center">
                                        <picture>
                                            <source srcset="/images/contact/Aris Chen.webp" type="image/webp" />
                                            <img src="/images/contact/Aris Chen.png" />
                                        </picture>
                                    </div>
                                </div>
                                <div class="person-text">
                                    <div>
                                        Aris Chen
                                    </div>
                                    <div class="person-name chinese">
                                        陳淑倩
                                    </div>
                                    <div class="person-email">
                                        aris@nizing.com.tw
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="display-block">
            <div class="container">
                <div class="title">
                    國外業務代表
                </div>
                <div class="subtitle">
                    International Sales Rep
                </div>
                <div class="block content">
                    <div class="row row-cols-2 row-cols-md-3">
                        <div class="col">
                            <div class="person-wrapper">
                                <div class="person-frame">
                                    <div class="d-flex justify-content-center">
                                        <picture>
                                            <source srcset="/images/contact/Nick Wang.webp" type="image/webp" />
                                            <img src="/images/contact/Nick Wang.png" />
                                        </picture>
                                    </div>
                                </div>
                                <div class="person-text">
                                    <div>
                                        Nick Wang
                                    </div>
                                    <div class="person-name chinese">
                                        王群傑
                                    </div>
                                    <div class="person-email">
                                        nick.wang@nizing.com.tw
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--<div class="col">
                            <div class="person-wrapper">
                                <div class="person-frame">
                                    <div class="d-flex justify-content-center">
                                        <source srcset="/images/contact/Kevin Wang.webp" type="image/webp" />
                                        <img src="/images/contact/Kevin Wang.png" />
                                    </div>
                                </div>
                                <div class="person-text">
                                    <div>
                                        Kevin Wang
                                    </div>
                                    <div class="person-name chinese">
                                        王君凱
                                    </div>
                                    <div class="person-email">
                                        kevin@nizing.com.tw
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="display-block address-section">
            <div class="container-fluid p-0">
                <div>
                    <picture>
                        <source srcset="/images/contact/NIZING.webp" type="image/webp" />
                        <img src="/images/contact/NIZING.jpg" />
                    </picture>
                </div>
                <div class="text-center">
                    <div class="title">
                        <span class="chinese">日進電線股份有限公司</span><br />
                        Nizing Electric Wire & Cable Co., Ltd.
                    </div>
                    <div class="map">
                        <picture>
                            <source srcset="/images/contact/nizing map_2021.webp" type="image/webp" />
                            <img src="/images/contact/nizing map_2021.jpg" />
                        </picture>
                    </div>
                    <div class="content">
                        <span class="chinese">地址: 新北市三重區光復路二段87巷10-12號</span><br />
                        ADD: No.10-12, Ln.87, Sec.2, Guanfu Road, Sanchong Dist., New Taipei City, Taiwan 24158<br />
                        TEL: +886-2-2999-9181<br />
                        FAX: +886-2-2999-9771<br />
                        Office Hour: 08:00~18:00 UTC+8
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

