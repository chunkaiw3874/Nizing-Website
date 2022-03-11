<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="associates.aspx.cs" Inherits="associates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>
        合作夥伴-日進電線 <%=DateTime.Now.Year.ToString() %>
    </title>
    <style type="text/css">
        .content {
            display: flex;
            justify-content: center;
            flex-direction: column;
            font-weight: bolder;
        }

            .content .associate-type {
                margin-bottom: 50px;
            }

                .content .associate-type .title-wrapper {
                    width: 330px;
                    border-bottom: 3px solid #000000;
                    margin: auto;
                }

                .content .associate-type .title {
                    font-size: 36px;
                    padding-bottom: 5px;
                }

                .content .associate-type .subtitle {
                    font-size: 20px;
                    padding-bottom: 5px;
                }

            .content .logo-wrapper {
                display: flex;
                justify-content: center;
            }

                .content .logo-wrapper .logo {
                    width: auto;
                    padding: 20px 40px;
                    text-align: center;
                }

                    .content .logo-wrapper .logo .logo-img {
                        width: 100px;
                        margin: auto;
                    }

        @media all and (max-width:767px) {
            .content .logo-wrapper {
                display: flex;
                justify-content: start;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <picture>
                <source srcset="/images/associates/banner-associates.webp" type="image/webp" />
                <img src="/images/associates/banner-associates.png" />
            </picture>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block">
        <div class="container">
            <div class="content">
                <div class="associate-type">
                    <div class="title-wrapper">
                        <div class="title">
                            汽車、運輸及倉儲業
                        </div>
                        <div class="subtitle">
                            Car & Transportation & Storage
                        </div>
                    </div>
                    <div class="logo-wrapper row row-cols-2 row-cols-md-4">
                        <div class="logo col">
                            <img src="/images/associates/logo/01-gogoro.svg" class="logo-img" />
                            <div class="logo-text">
                                gogoro
                            </div>
                        </div>
                        <div class="logo col">
                            <img src="/images/associates/logo/01-CSBC.svg" class="logo-img" />
                            <div class="logo-text">
                                台灣國際造船
                            </div>
                        </div>
                    </div>
                </div>
                <div class="associate-type">
                    <div class="title-wrapper">
                        <div class="title">
                            營建工程業
                        </div>
                        <div class="subtitle">
                            Construction
                        </div>
                    </div>
                    <div class="logo-wrapper row row-cols-2 row-cols-md-4">
                        <div class="logo">
                            <img src="/images/associates/logo/02-agc.svg" class="logo-img" />
                            <div class="logo-text">
                                艾杰旭
                            </div>
                        </div>
                        <div class="logo">
                            <img src="/images/associates/logo/02-CSC.svg" class="logo-img" />
                            <div class="logo-text">
                                中國鋼鐵公司
                            </div>
                        </div>
                        <div class="logo">
                            <img src="/images/associates/logo/02-dragonsteel.svg" class="logo-img" />
                            <div class="logo-text">
                                中龍鋼鐵
                            </div>
                        </div>
                        <div class="logo">
                            <img src="/images/associates/logo/02-NANYA.svg" class="logo-img" />
                            <div class="logo-text">
                                南亞塑膠工業
                            </div>
                        </div>
                        <div class="logo">
                            <img src="/images/associates/logo/02-osram.svg" class="logo-img" />
                            <div class="logo-text">
                                歐司朗
                            </div>
                        </div>
                        <div class="logo">
                            <img src="/images/associates/logo/02-shihlin-electric.svg" class="logo-img" />
                            <div class="logo-text">
                                士林電機
                            </div>
                        </div>
                        <div class="logo">
                            <img src="/images/associates/logo/02-taiwan-glass.svg" class="logo-img" />
                            <div class="logo-text">
                                台玻集團
                            </div>
                        </div>
                        <div class="logo">
                            <img src="/images/associates/logo/02-taiwan-textile.svg" class="logo-img" />
                            <div class="logo-text">
                                財團法人紡織產業綜合研究所(紡織所)
                            </div>
                        </div>
                    </div>
                </div>
                <div class="associate-type">
                    <div class="title-wrapper">
                        <div class="title">
                            電力及燃氣供應業
                        </div>
                        <div class="subtitle">
                            Gas and Electricity
                        </div>
                    </div>
                    <div class="logo-wrapper row row-cols-2 row-cols-md-4">
                        <div class="logo col">
                            <img src="/images/associates/logo/03-CCP.svg" class="logo-img" />
                            <div class="logo-text">
                                長春集團
                            </div>
                        </div>
                        <div class="logo col">
                            <img src="/images/associates/logo/03-CPC.svg" class="logo-img" />
                            <div class="logo-text">
                                台灣中油
                            </div>
                        </div>
                        <div class="logo col">
                            <img src="/images/associates/logo/03-formosa-plastics-group.svg" class="logo-img" />
                            <div class="logo-text">
                                台塑企業
                            </div>
                        </div>
                    </div>
                </div>
                <div class="associate-type">
                    <div class="title-wrapper">
                        <div class="title">
                            科技製造業
                        </div>
                        <div class="subtitle">
                            High Tech Manufacturing
                        </div>
                    </div>
                    <div class="logo-wrapper row row-cols-2 row-cols-md-4">
                        <div class="logo col">
                            <img src="/images/associates/logo/04-corning.svg" class="logo-img" />
                            <div class="logo-text">
                                康寧公司
                            </div>
                        </div>
                        <div class="logo col">
                            <img src="/images/associates/logo/04-delta.svg" class="logo-img" />
                            <div class="logo-text">
                                台達電子
                            </div>
                        </div>
                        <div class="logo col">
                            <img src="/images/associates/logo/04-ITRI.svg" class="logo-img" />
                            <div class="logo-text">
                                工業技術研究院
                            </div>
                        </div>
                        <div class="logo col">
                            <img src="/images/associates/logo/04-TSMC.svg" class="logo-img" />
                            <div class="logo-text">
                                台積電
                            </div>
                        </div>
                    </div>
                </div>
                <div class="associate-type">
                    <div class="title-wrapper">
                        <div class="title">
                            公共行政及國防
                        </div>
                        <div class="subtitle">
                            Public Administration and National Defence
                        </div>
                    </div>
                    <div class="logo-wrapper row row-cols-2 row-cols-md-4">
                        <div class="logo col">
                            <img src="/images/associates/logo/05-AIDC.svg" class="logo-img" />
                            <div class="logo-text">
                                漢翔航空工業
                            </div>
                        </div>
                        <div class="logo col">
                            <img src="/images/associates/logo/05-NCSIST.svg" class="logo-img" />
                            <div class="logo-text">
                                國家中山科學研究院(中科院)
                            </div>
                        </div>
                        <div class="logo col">
                            <img src="/images/associates/logo/05-NSRRC.svg" class="logo-img" />
                            <div class="logo-text">
                                國家同步輻射研究中心
                            </div>
                        </div>
                    </div>
                </div>
                <div class="associate-type">
                    <div class="title-wrapper">
                        <div class="title">
                            醫療保健業
                        </div>
                        <div class="subtitle">
                            Pharmaceutical
                        </div>
                    </div>
                    <div class="logo-wrapper row row-cols-2 row-cols-md-4">
                        <div class="logo col">
                            <img src="/images/associates/logo/06-DCMED.svg" class="logo-img" />
                            <div class="logo-text">
                                大中醫療器材
                            </div>
                        </div>
                        <div class="logo col">
                            <img src="/images/associates/logo/06-EGMED.svg" class="logo-img" />
                            <div class="logo-text">
                                醫技實業
                            </div>
                        </div>
                        <div class="logo col">
                            <img src="/images/associates/logo/06-GGM.svg" class="logo-img" />
                            <div class="logo-text">
                                鉅邦醫材
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

