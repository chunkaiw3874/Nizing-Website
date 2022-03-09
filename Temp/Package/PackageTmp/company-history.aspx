<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDCompanyMaster.master" AutoEventWireup="true" CodeFile="company-history.aspx.cs" Inherits="company_history" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <title>日進電線-歷史紀錄</title>
    <link rel="stylesheet" href="/css/timeline/style-albe-timeline.css" />
    <script src="/Scripts/timeline/jquery-albe-timeline.min.js"></script>
    <style type="text/css">
        .company-timeline section#timeline:before {
            z-index: 0;
        }

        .company-timeline section#timeline div[class*="group"], section#timeline article div.panel div.badge {
            box-shadow: none;
        }

        section#timeline:before {
            background-color: #1da3d9;
        }

        section#timeline div[class*="group"] {
            background-color: #1da3d9;
            border: solid 1px #1da3d9;
        }

        .company-timeline section#timeline article .panel .badge {
            white-space: normal;
            color: white;
            font-size: 6px;
            border: solid 1px #1da3d9;
        }

            .company-timeline section#timeline article .panel .badge:hover {
                cursor: default;
            }

        section#timeline article div.panel .panel-body {
            padding: 0;
            background-color: #cccccc;
        }

        .company-timeline section#timeline article div.panel-body:after {
            top: 10px;
            background-color: #1da3d9;
        }


        .company-timeline section#timeline article .panel .panel-body .panel-title {
            background-color: #1da3d9;
            color: #ffffff;
            text-align: center;
            font-size: 24px;
        }

        .company-timeline section#timeline article .panel .panel-body .panel-text {
            padding: 1rem;
        }

        @media all and (max-width: 768px) {
            .company-timeline section#timeline > article > div.panel {
                width: 42%;
            }

            .company-timeline section#timeline article .panel .panel-body .panel-title {
                font-size: 20px;
            }

            .company-timeline section#timeline article .panel .panel-body .panel-text {
                text-align: justify;
            }
        }
    </style>

    <script type="text/javascript">
        var data = [
            {
                time: "1983-01-01",
                body: [{
                    tag: "div",
                    content: "於台灣台北成立日進電線股份有限公司",
                    attr: {
                        cssClass: "panel-title"
                    }
                }]
            },
            {
                time: "1996-01-01",
                body: [{
                    tag: "div",
                    content: "於中國東莞成立大陸日進",
                    attr: {
                        cssClass: "panel-title"
                    }
                }]
            },
            {
                time: "1999-01-01",
                body: [{
                    tag: "div",
                    content: "成立東莞分公司",
                    attr: {
                        cssClass: "panel-title"
                    }
                }]
            },
            {
                time: "2001-01-01",
                body: [{
                    tag: "div",
                    content: "成立上海東華分公司",
                    attr: {
                        cssClass: "panel-title"
                    }
                }]
            },
            {
                time: "2002-01-01",
                body: [
                    {
                        tag: "div",
                        content: "擴張生產基地",
                        attr: {
                            cssClass: "panel-title"
                        }
                    },
                    {
                        tag: "div",
                        content: "併購生產基地周圍土地進行擴廠，產能增加為兩倍",
                        attr: {
                            cssClass: "panel-text"
                        }
                    }
                ]
            },
            {
                time: "2004-01-01",
                body: [{
                    tag: "div",
                    content: "於浙江、湛江、中山等區設立分公司",
                    attr: {
                        cssClass: "panel-title"
                    }
                }]
            },
            {
                time: "2006-01-01",
                body: [{
                    tag: "div",
                    content: "併購成立東莞鉅生電線有限公司",
                    attr: {
                        cssClass: "panel-title"
                    }
                }]
            },
            {
                time: "2008-01-01",
                body: [{
                    tag: "div",
                    content: "成立福建漳州日進電子",
                    attr: {
                        cssClass: "panel-title"
                    }
                }]
            },
            {
                time: "2009-01-01",
                body: [
                    {
                        tag: "div",
                        content: "成立福建漳州日進電子配線廠",
                        attr: {
                            cssClass: "panel-title"
                        }
                    }
                ]
            },
            {
                time: "2009-07-01",
                body: [
                    {
                        tag: "div",
                        content: "導入金屬編織鎧裝與鐵氟龍產線設備與技術",
                        attr: {
                            cssClass: "panel-title"
                        }
                    },
                    {
                        tag: "div",
                        content: "為提供最優良品質產品及提升客製能力而設置金屬編織鎧裝及鐵氟龍產線",
                        attr: {
                            cssClass: "panel-text"
                        }
                    }
                ]
            },
            {
                time: "2010-05-01",
                body: [
                    {
                        tag: "div",
                        content: "設立絞線部門",
                        attr: {
                            cssClass: "panel-title"
                        }
                    },
                    {
                        tag: "div",
                        content: "引進絞線設備與技術，提升複合線材製造及客製化能力",
                        attr: {
                            cssClass: "panel-text"
                        },
                    },
                    {
                        tag: "div",
                        content: "跨足溫控產業",
                        attr: {
                            cssClass: "panel-title"
                        }
                    },
                    {
                        tag: "div",
                        content: "以高品質的補償導線成功進入溫控市場",
                        attr: {
                            cssClass: "panel-text"
                        },
                    }
                ]
            },
            {
                time: "2011-01-01",
                body: [
                    {
                        tag: "div",
                        content: "跨足電動車、醫療產業",
                        attr: {
                            cssClass: "panel-title"
                        }
                    },
                    {
                        tag: "div",
                        content: "成功進入對於安規及材料要求最為嚴苛的兩大產業",
                        attr: {
                            cssClass: "panel-text"
                        },
                    }
                ]
            },
            {
                time: "2012-01-01",
                body: [
                    {
                        tag: "div",
                        content: "跨足太陽能、LED產業",
                        attr: {
                            cssClass: "panel-title"
                        }
                    },
                    {
                        tag: "div",
                        content: "成功進入產業供應鏈，為業界大廠之合格廠商",
                        attr: {
                            cssClass: "panel-text"
                        },
                    }
                ]
            },
            {
                time: "2013-05-01",
                body: [
                    {
                        tag: "div",
                        content: "成功整合導入ERP系統",
                        attr: {
                            cssClass: "panel-title"
                        }
                    },
                    {
                        tag: "div",
                        content: "使用ERP系統，更精確記錄生產資料",
                        attr: {
                            cssClass: "panel-text"
                        },
                    },
                    {
                        tag: "div",
                        content: "跨足3D列印、機械手臂產業",
                        attr: {
                            cssClass: "panel-title"
                        }
                    },
                    {
                        tag: "div",
                        content: "製作3D列印耗材及機械手臂相關元件",
                        attr: {
                            cssClass: "panel-text"
                        },
                    }
                ]
            },
            {
                time: "2014-10-01",
                body: [
                    {
                        tag: "div",
                        content: "獲得ISO9001認證",
                        attr: {
                            cssClass: "panel-title"
                        }
                    },
                    {
                        tag: "div",
                        content: "經法國Association Francaise de Normalisation認證成為ISO9001廠商",
                        attr: {
                            cssClass: "panel-text"
                        },
                    },
                    {
                        tag: "div",
                        content: "成功整合全系列複合線",
                        attr: {
                            cssClass: "panel-title"
                        }
                    }
                    , {
                        tag: "div",
                        content: "垂直整合所有外被、絕緣、隔離、芯線製程，所有線材及複合製程皆可自製",
                        attr: {
                            cssClass: "panel-text"
                        }
                    }]
            },
            {
                time: "2015-01-01",
                body: [
                    {
                        tag: "div",
                        content: "導入電腦化設計系統",
                        attr: {
                            cssClass: "panel-title"
                        }
                    }
                    , {
                        tag: "div",
                        content: "使用最先進的程式及技術進行最精確的研發設計",
                        attr: {
                            cssClass: "panel-text"
                        }
                    }]
            }
        ];

        $(document).ready(function () {
            $('.company-timeline').albeTimeline(data,
                {
                    language: 'en-US',
                    sortDesc: true,
                    showMenu: false
                });
        })
    </script>
</asp:Content>
<asp:Content ID="banner" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <picture>
                <source srcset="/images/banner/banner-company-en.webp" type="image/webp" />
                <img src="/images/banner/banner-company-en.png" />
            </picture>
        </div>
    </div>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper company-history">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    歷史歷程
                </div>
                <div class="subtitle">
                    Nizing History
                </div>
                <div class="content company-timeline">
                </div>
            </div>
        </div>
    </div>
</asp:Content>

