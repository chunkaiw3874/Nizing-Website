<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDCompanyMaster.master" AutoEventWireup="true" CodeFile="company-culture.aspx.cs" Inherits="company_culture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>日進電線-核心文化</title>
    <style>
        .content {
            margin-top: 48px;
        }

            .content .title {
                text-align: left;
                font-size: 24px;
                font-weight: bold;
                border-bottom: solid 1px #000000;
                padding-bottom: 20px;
            }

            .content .body {
                padding-top: 20px;
                font-weight: bold;
            }

                .content .body.philosophy-list {
                    padding-left: 8px;
                    padding-right: 8px;
                }

        .philosophy-list-item {
            padding-left: 16px;
            padding-right: 16px;
        }

            .philosophy-list-item .title {
                font-size: 24px;
                text-align: center;
                border: none;
                padding: 10px 0;
            }

            .philosophy-list-item:nth-child(1) .title {
                color: #172987;
            }

            .philosophy-list-item:nth-child(2) .title {
                color: #006834;
            }

            .philosophy-list-item:nth-child(3) .title {
                color: #E73828;
            }

            .philosophy-list-item:nth-child(4) .title {
                color: #F39700;
            }

            .philosophy-list-item .content {
                text-align: left;
                margin-top: 0.5rem;
            }

        .mission .red {
            color: #C30D22;
        }

        @media all and (max-width:1199px) {
        }

        @media all and (max-width:991px) {
            .philosophy-list-item .title {
                font-size: 18px;
            }
        }

        @media all and (max-width:767px) {
            .philosophy-list-item .title {
                font-size: 26px;
            }
        }

        @media all and (max-width:575px) {
            .philosophy-list-item .title {
                font-size: 20px;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <picture>
                <source srcset="/images/banner/banner-company-en.webp" type="image/webp" />
                <img src="/images/banner/banner-company-en.png" />
            </picture>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    企業核心價值與經營理念
                </div>
                <div class="subtitle">
                    ENTERPRISE CULTURE
                </div>
                <div class="content">
                    <div class="title">
                        經營理念 Philosophy
                    </div>
                    <div class="row row-cols-2 row-cols-md-4 body philosophy-list">
                        <div class="cols philosophy-list-item">
                            <picture>
                                <source srcset="/images/company/culture/company-culture-01.webp" type="image/webp" />
                                <img src="/images/company/culture/company-culture-01.png" />
                            </picture>
                            <div class="title">
                                誠信負責迎得信賴
                            </div>
                            <div class="content">
                                堅守此做人處事信守不渝的基本態度與信念，我們對員工、客戶、供應商都以誠信為出發
                                    ，遵守道德法律規範，以此為基礎維持良好的夥伴關係及形成大家皆贏的局勢，並兼顧企業社會責任
                            </div>
                        </div>
                        <div class="cols philosophy-list-item">
                            <picture>
                                <source srcset="/images/company/culture/company-culture-02.webp" type="image/webp" />
                                <img src="/images/company/culture/company-culture-02.png" />
                            </picture>
                            <div class="title">
                                創新超越自我
                            </div>
                            <div class="content">
                                技術基礎上力求精進，在企業的願景帶領下，持續提昇研發與製程能力，持續開發具生產高附加價值產品
                                ，不斷自我超越以期技術及客戶權益維持領先。
                            </div>
                        </div>
                        <div class="cols philosophy-list-item">
                            <picture>
                                <source srcset="/images/company/culture/company-culture-03.webp" type="image/webp" />
                                <img src="/images/company/culture/company-culture-03.png" />
                            </picture>
                            <div class="title">
                                品質至上的堅持
                            </div>
                            <div class="content">
                                專業知識與素養，堅守職場敬業的工作精神，達成客戶滿意度就是我們的堅持
                            </div>
                        </div>
                        <div class="cols philosophy-list-item">
                            <picture>
                                <source srcset="/images/company/culture/company-culture-04.webp" type="image/webp" />
                                <img src="/images/company/culture/company-culture-04.png" />
                            </picture>
                            <div class="title">
                                共同追求卓越
                            </div>
                            <div class="content">
                                營造樂於溝通的環境，以建立開放型管理模式，透過集思廣益的團隊合作廣納各方不同的聲音。
                                共識建立後，就團結合一、傾全力向既定共同目標積極穩健前進
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content">
                    <div class="title">
                        企業願景 Vision
                    </div>
                    <div class="body">
                        成為全球最專業、多元開發設計之電線電纜公司，垂直整合客製化線材方案的提供者。
                    </div>
                </div>
                <div class="content">
                    <div class="title">
                        企業使命 Mission
                    </div>
                    <div class="body mission">
                        <ul>
                            <li>專業的設計實力，提供「客製化」電線電纜與元組件，成為<span class="red">特殊線材領域之技術領導者</span>。
                            </li>
                            <li>一條龍的製程，完整多樣化的全產品線，卓越的整合服務，給予<span class="red">客戶最完整的線材垂直整合服務者</span>。
                            </li>
                            <li>遵守道德/法律規範，實踐企業社會責任；建立開放型管理模式，持續創造獲利成長，讓<span class="red">客戶與員工安心的企業</span>。
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="content">
                    <div class="title">
                        核心價值觀 Core Value
                    </div>
                    <div class="body">
                        <picture>
                            <source srcset="/images/company/culture/company-culture-05.webp" type="image/webp" />
                            <img src="/images/company/culture/company-culture-05.png"
                                class="w-50 d-block mx-auto" />
                        </picture>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

