<<<<<<< HEAD
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDCompanyMaster.master" AutoEventWireup="true" CodeFile="company-culture.aspx.cs" Inherits="company_culture" %>
=======
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/companyMaster2021.master" AutoEventWireup="true" CodeFile="company-culture.aspx.cs" Inherits="company_culture" %>
>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>日進電線-核心文化</title>
    <style>
<<<<<<< HEAD
        .content .title {
            text-align: left;
            font-size: 24px;
        }

        .belief-list-item {
            padding-left: 16px;
            padding-right: 16px;
        }

            .belief-list-item .title {
                font-size: 24px;
                text-align: center;
            }

            .belief-list-item .content {
                text-align: center;
                margin-top: 0.5rem;
            }

        .circle {
            position: relative;
            display: block;
            margin: 2em 0;
            background-color: transparent;
            color: #222;
            border-radius: 50%;
            background-color: var(--nizing-red);
            text-align: center;
        }

            .circle:after {
                display: block;
                padding-bottom: 100%;
                width: 100%;
                height: 0;
                /*                border-radius: 50%;
                background-color: var(--nizing-red);*/
                content: "";
            }

        .circle__inner {
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            width: 100%;
            height: 100%;
        }

        .circle__wrapper {
            display: table;
            width: 100%;
            height: 100%;
        }

        .circle__content {
            display: flex;
            align-items: center;
            height: 100%;
            justify-content: space-between;
            padding: 1em;
            font-size: 1.5rem;
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
                        企業願景
                    </div>
                    <div>
                        成為全世界最先進，靈活開發產品電源供應元件之設計製造公司，經由研發與設計，提供客製化電線電纜與元組件滿足各種電源供應的需求與應用。
                    </div>
                    <ul>
                        <li>持續研發新型技術，導入新機台，新製程，與新原料
                        </li>
                        <li>E化製造工廠，並以大數據控制品質，達到優良的良率
                        </li>
                        <li>持續提升與精進公司經營管理流程，搭配IT系統開發與AI人工智慧提升服務質量
                        </li>
                    </ul>
                    <div class="title">
                        企業使命
                    </div>
                    <ul>
                        <li>由專業的研發與設計，提供客製化電線電纜與元組件，滿足各種電源供應的需求與應用，成為特殊線材市場領導者
                        </li>
                        <li>積極強化整體經營體質，持續獲利成長，追求永續發展
                        </li>
                        <li>實踐企業社會責任，持續提供給員工同業平均水準以上的薪資與福利，並優化改善工作環境
                        </li>
                        <li>生產力提升、顧客滿意，是我們成長的動力!!
                        </li>
                        <li>持續提供給員工同業平均水準以上的薪資與福利，並優化工作環境
                        </li>
                    </ul>
                    <div class="title">
                        經營理念
                    </div>
                    <div class="row row-cols-2 row-cols-md-4">
                        <div class="cols belief-list-item">
                            <div class="circle bg-red">
                                <div class="circle__inner">
                                    <div class="circle__wrapper">
                                        <div class="circle__content text-white">
                                            <span>負</span>
                                            <span>責</span>
                                            <span>誠</span>
                                            <span>信</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="title">
                                誠信負責迎得信賴
                            </div>
                            <div class="content">
                                堅守此做人處事信守不渝的基本態度與信念，我們對員工、客戶、供應商都以誠信為出發
                                    ，遵守道德法律規範，以此為基礎維持良好的夥伴關係及形成大家皆贏的局勢，並兼顧企業社會責任
                            </div>
                        </div>
                        <div class="cols belief-list-item">
                            <div class="circle bg-blue">
                                <div class="circle__inner">
                                    <div class="circle__wrapper">
                                        <div class="circle__content text-white">
                                            <span>研</span>
                                            <span>發</span>
                                            <span>創</span>
                                            <span>新</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="title">
                                創新超越自我
                            </div>
                            <div class="content">
                                技術基礎上力求精進，在企業的願景帶領下，持續提昇研發與製程能力，持續開發具生產高附加價值產品
                                ，不斷自我超越以期技術及客戶權益維持領先。
                            </div>
                        </div>
                        <div class="cols belief-list-item">
                            <div class="circle bg-green">
                                <div class="circle__inner">
                                    <div class="circle__wrapper">
                                        <div class="circle__content text-white">
                                            <span>專</span>
                                            <span>業</span>
                                            <span>用</span>
                                            <span>心</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="title">
                                品質至上的堅持
                            </div>
                            <div class="content">
                                專業知識與素養，堅守職場敬業的工作精神，達成客戶滿意度就是我們的堅持
                            </div>
                        </div>
                        <div class="cols belief-list-item">
                            <div class="circle bg-lightgray">
                                <div class="circle__inner">
                                    <div class="circle__wrapper">
                                        <div class="circle__content text-white">
                                            <span>團</span>
                                            <span>隊</span>
                                            <span>合</span>
                                            <span>作</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="title">
                                共同追求卓越
                            </div>
                            <div class="content">
                                營造樂於溝通的環境，以建立開放型管理模式，透過集思廣益的團隊合作廣納各方不同的聲音。
                                共識建立後，就團結合一、傾全力向既定共同目標積極穩健前進
                            </div>
=======
        .block.content .top {
            width: 1200px;
            box-shadow: 10px 10px 15px 5px #6f6f6f;
            margin-bottom: 50px;
        }

        .block.content .content:first-child {
            margin-bottom: 30px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="container-fluid p-0">
        <div class="display-block">
            <div class="block header">
                <div class="block title h2">
                    企業文化
                </div>
                <div class="block subtitle h4">
                    ENTERPRISE CULTURE
                </div>
            </div>
            <div class="block content">
                <div class="content d-flex justify-content-center">
                    <div class="flex-column justify-content-center">
                        <div class="top">
                            <img src="images/company/culture/christmas-1.png" class="img w-100" />
                        </div>
                        <div class="h5 d-flex justify-content-center">
                            <div>
                                ◆ 負責、誠信<br />
                                ◆ 專業、用心<br />
                                ◆ 研發、創新<br />
                                ◆ 團隊合作
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content">
                    <div class="row p-0 m-0">
                        <div class="col-4">
                            <img src="images/company/culture/christmas-2.png" class="img w-100" />
                        </div>
                        <div class="col-8 pr-0 d-flex flex-column justify-content-between">
                            <div class="row m-0">
                                <div class="col-10 pr-0 h5">
                                    <p>日進電線除了人的不懈努力外，更重要的歸功于各位先進的指導與愛護。貫徹整體顧客意識，珍惜每一次服務的機會。全體日進電線人員處世以&quot;誠&quot;、&quot;信&quot;為原則；&quot;誠&quot;乃是出自於內心的真誠，&quot;信&quot;則是言而有信、言出必行。&quot;積極、創新、追求卓越&quot;是日進電線的經營理念。</p>
                                    <p>我們深信，唯有堅定的企業信念、熱忱投入的工作態度、以及高效率和實事求是的負責精神，才能贏得客戶的支持與信賴。</p>
                                    <p>日進就是一個可以帶給大家幸福的地方。以日進為本，照顧大家。透過日進，大家互相協助，互相理解，同心協力幫助客戶解決問題。這就是我們的宗旨。</p>
                                </div>
                            </div>
                            <div class="row m-0">
                                <div class="offset-6 col-6 pr-0">
                                    <img src="images/company/culture/christmas-3.png" class="img w-100" />
                                </div>
                            </div>
>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

