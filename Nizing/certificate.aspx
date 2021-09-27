<<<<<<< HEAD
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDCertificateMaster.master" AutoEventWireup="true" CodeFile="certificate.aspx.cs" Inherits="certificate" %>
=======
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/certificateMaster2021.master" AutoEventWireup="true" CodeFile="certificate.aspx.cs" Inherits="certificate" %>
>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>日進電線-安規認證</title>
    <style>
<<<<<<< HEAD
        .certificates .certificate-introduction .certificate-image img {
            width: 100%;
        }

        .certificates .certificate-introduction .certificate-text,
        .certificates .management-certificate-list .management-certificate .certificate-text,
        .certificates .green-certificate-list .green-certificate .certificate-text {
            text-align: center;
            font-size: 1.25rem;
            margin: 24px 0;
        }

            .certificates .certificate-introduction .certificate-text:last-child,
            .certificates .management-certificate-list .management-certificate .certificate-text:last-child,
            .certificates .green-certificate-list .green-certificate .certificate-text:last-child {
                margin-bottom: 0;
            }


        .certificates .management-certificate-list .certificate .certificate-wrapper,
        .certificates .green-certificate-list .certificate .certificate-wrapper {
            display: flex;
            justify-content: center;
            width: 100%;
        }

            .certificates .management-certificate-list .certificate .certificate-wrapper .certificate-frame,
            .certificates .green-certificate-list .certificate .certificate-wrapper .certificate-frame {
                box-shadow: 0 0 15px 8px rgba(0, 0, 0, 0.5);
                background-color: #ffffff;
                padding: 30px;
                height: 520px;
                margin: 0 auto;
                aspect-ratio: 100 / 158;
            }

                .certificates .management-certificate-list .certificate .certificate-wrapper .certificate-frame .certificate-image,
                .certificates .green-certificate-list .certificate .certificate-wrapper .certificate-frame .certificate-image {
                    display: flex;
                    justify-content: center;
                    width: 100%;
                }

                .certificates .management-certificate-list .certificate .certificate-wrapper .certificate-frame img,
                .certificates .green-certificate-list .certificate .certificate-wrapper .certificate-frame img {
                    max-width: 300px;
                    width: 100%;
                    object-fit: contain;
                }

                .certificates .management-certificate-list .certificate .certificate-wrapper .certificate-frame .certificate-title,
                .certificates .green-certificate-list .certificate .certificate-wrapper .certificate-frame .certificate-title,
                .certificates .management-certificate-list .certificate .certificate-wrapper .certificate-frame .certificate-date,
                .certificates .green-certificate-list .certificate .certificate-wrapper .certificate-frame .certificate-date {
                    text-align: center;
                }

                .certificates .management-certificate-list .certificate .certificate-wrapper .certificate-frame .certificate-title,
                .certificates .green-certificate-list .certificate .certificate-wrapper .certificate-frame .certificate-title {
                    font-size: 40px;
                    color: #606060;
                }

                .certificates .management-certificate-list .certificate .certificate-wrapper .certificate-frame .certificate-date,
                .certificates .green-certificate-list .certificate .certificate-wrapper .certificate-frame .certificate-date {
                    font-size: 26px;
                    margin-bottom: 24px;
                    color: #ff0000;
                }

        .certificates .certification-body-list .certification-body {
            margin-bottom: 24px;
            background-color: #ffffff;
            height: calc(100% - 24px);
        }

            .certificates .certification-body-list .certification-body:nth-last-child(1),
            .certificates .certification-body-list .certification-body:nth-last-child(2) {
                padding-bottom: 0;
            }

            .certificates .certification-body-list .certification-body .card {
                max-height: 360px;
            }

            .certificates .certification-body-list .certification-body .card-img {
                object-fit: contain;
                height: 260px;
            }


            .certificates .certification-body-list .certification-body .certificate-text {
                font-size: 26px;
                text-align: center;
                padding: 24px 0;
            }

        @media all and (max-width: 992px) {
            .certificates .certificate {
                margin-bottom: 24px;
            }

                .certificates .certificate:last-child {
                    margin-bottom: 0;
                }
        }

        @media all and (max-width: 768px) {
            .certificates .certification-body-list .certification-body .certificate-text {
                font-size: 20px;
            }

            .certificates .certification-body-list .certification-body .card-img {
                height: 200px;
            }
        }

        @media all and (max-width: 576px) {
            .certificates .certification-body-list .certification-body .certificate-text {
                font-size: 16px;
            }

            .certificates .certification-body-list .certification-body .card-img {
                height: 140px;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="banner" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <picture>
                <source srcset="/images/banner/banner-certificate-en.webp" type="image/webp" />
                <img src="/images/banner/banner-certificate-en.png" />
            </picture>
        </div>
    </div>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper certificates">
        <div class="display-block certificate-introduction">
            <div class="container-fluid">
                <div class="title">
                    管理品質認證
                </div>
                <div class="subtitle">
                    Managerment Quality Certification
                </div>
                <div class="content">
                    <div class="certificate-image">
                        <picture>
                            <source srcset="/images/certificate/certificate-1.webp" type="image/webp" />
                            <img src="/images/certificate/certificate-1.png" />
                        </picture>
                    </div>
                    <div class="certificate-text container">
                        我司每年度執行內部稽核審查所有作業流程，並由外部稽核單位執行外部稽核與查驗。
                    </div>
                    <div class="certificate-image">
                        <picture>
                            <source srcet="/images/certificate/certificate-2.webp" type="image/webp" />
                            <img src="/images/certificate/certificate-2.png" />
                        </picture>
                    </div>
                    <div class="certificate-text container">
                        搭配ERP&ERP II、KPI、OKR、MES工廠管理系統與大數據，做完善的流程控管。
                    </div>
                </div>
            </div>
        </div>

        <div class="display-block management-certificate-list">
            <div class="title">
                管理證書
            </div>
            <div class="subtitle">
                MANAGEMENT CERTIFICATES
            </div>
            <div class="container content">
                <div class="row row-cols-1">
                    <div class="col certificate management-certificate">
                        <div class="certificate-wrapper">
                            <a class="link" href="/pdf/certificate/iso9001/iso9001-2015.pdf" target="_blank">
                                <div class="certificate-frame">
                                    <div class="certificate-title">
                                        ISO9001:2015
                                    </div>
                                    <div class="certificate-date">
                                        Certified:2020/09/18
                                    </div>
                                    <div class="certificate-image">
                                        <picture>
                                            <source srcset="/images/certificate/iso9001/iso9001.webp" type="image/webp" />
                                            <img src="/images/certificate/iso9001/iso9001.png" />
                                        </picture>
=======
        .display-block:last-child .col {
            padding-bottom: 30px;
        }

            .display-block:last-child .col:nth-last-child(1),
            .display-block:last-child .col:nth-last-child(2) {
                padding-bottom: 0px;
            }

        .display-block:last-child .card-text {
            padding-bottom: 30px;
            font-size: 26px;
        }


        .certificate-wrapper {
            width: 480px;
        }

        .certificate-frame {
            box-shadow: 0 0 15px 8px rgba(0, 0, 0, 0.5);
            background-color: #ffffff;
            padding: 30px;
            height: 560px;
            margin-bottom: 30px;
        }

            .certificate-frame .img {
                width: 300px;
                object-fit:contain;
            }

        .certificate-title,
        .certificate-date {
            text-align: center;
        }

        .certificate-title {
            font-size: 50px;
            color: #606060;
        }

        .certificate-date {
            font-size: 30px;
            margin-bottom: 30px;
            color: #ff0000;
        }

        .card {
            height: 360px;
            padding: 30px 0;
        }

        .card-img {
            object-fit: contain;
            height: 260px;
            padding-bottom: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="container-fluid p-0">
        <div class="display-block">
            <div class="block header">
                <div class="block title h2">
                    管理品質認證
                </div>
                <div class="block subtitle h4">
                    Managerment Quality Certification
                </div>
            </div>
            <div class="block content">
                <div>
                    <img src="images/certificate/品質認證-圖檔1.png" class="img w-100" />
                </div>
                <div class="my-5 text-center h5">
                    我司每年度執行內部稽核審查所有作業流程，並由外部稽核單位執行外部稽核與查驗。
                </div>
                <div>
                    <img src="images/certificate/品質認證-圖檔2.png" class="img w-100" />
                </div>
                <div class="mt-5 text-center h5">
                    搭配ERP&ERP II、KPI、OKR、MES工廠管理系統與大數據，做完善的流程控管。
                </div>
            </div>
        </div>
        <div class="display-block">
            <div class="block header">
                <div class="block title h2">
                    管理證書
                </div>
                <div class="block subtitle h4">
                    MANAGEMENT CERTIFICATES
                </div>
            </div>
            <div class="container block content">
                <div class="row row-cols-1">
                    <div class="col">
                        <div class="d-flex justify-content-center">
                            <a class="link" href="iso9001.aspx">
                                <div class="certificate-wrapper">
                                    <div class="certificate-frame">
                                        <div class="certificate-title">
                                            ISO9001:2015
                                        </div>
                                        <div class="certificate-date">
                                            Certified:2020/09/18
                                        </div>
                                        <div class="d-flex justify-content-center">
                                            <img src="images/certificate/iso9001/ISO9001-2015.jpg" class="img" />
                                        </div>
                                    </div>
                                    <div class="certificate-text h5">
                                        最新版本ISO9001證書
>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
                                    </div>
                                </div>
                            </a>
                        </div>
<<<<<<< HEAD
                        <div class="certificate-text">
                            最新版本ISO9001證書
=======
                        <div class="d-flex justify-content-center">
>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
                        </div>
                    </div>
                </div>
            </div>
        </div>
<<<<<<< HEAD
        <div class="display-block green-certificate-list">
            <div class="title">
                歐盟綠色認證
            </div>
            <div class="subtitle">
                EUROPEAN UNION GREEN CERTIFICATION
            </div>
            <div class="container content">
                <div class="row row-cols-1 row-cols-lg-2">
                    <div class="col certificate green-certificate">
                        <div class="certificate-wrapper">
                            <a class="link" href="/pdf/certificate/rohs/rohs.pdf">
                                <div class="certificate-frame">
                                    <div class="certificate-title">
                                        ROHS 2.0
                                    </div>
                                    <div class="certificate-date">
                                        Certified:2021/05/10
                                    </div>
                                    <div class="certificate-image">
                                        <img src="/images/certificate/rohs/rohs.png" />
=======
        <div class="display-block">
            <div class="block header">
                <div class="block title h2">
                    歐盟綠色認證
                </div>
                <div class="block subtitle h4">
                    EUROPEAN UNION GREEN CERTIFICATION
                </div>
            </div>
            <div class="container block content">
                <div class="row row-cols-2">
                    <div class="col">
                        <div class="d-flex justify-content-center">
                            <a class="link" href="rohs.aspx">
                                <div class="certificate-wrapper">
                                    <div class="certificate-frame">
                                        <div class="certificate-title">
                                            ROHS 2.0
                                        </div>
                                        <div class="certificate-date">
                                            Certified:2021/05/10
                                        </div>
                                        <div class="d-flex justify-content-center">
                                            <img src="images/certificate/rohs/rohs.png" class="img" />
                                        </div>
                                    </div>
                                    <div class="certificate-text h5">
                                        我司產品經測試驗證10項ROHS驗證標準，取得最新ROHS2.0認證
>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
                                    </div>
                                </div>
                            </a>
                        </div>
<<<<<<< HEAD
                        <div class="certificate-text">
                            我司產品經測試驗證10項ROHS驗證標準，取得最新ROHS2.0認證
                        </div>
                    </div>
                    <div class="col certificate green-certificate">
                        <div class="certificate-wrapper">
                            <a class="link" href="/pdf/certificate/reach/reach.pdf">
                                <div class="certificate-frame">
                                    <div class="certificate-title">
                                        REACH
                                    </div>
                                    <div class="certificate-date">
                                        Certified:2020/07/30
                                    </div>
                                    <div class="certificate-image">
                                        <picture>
                                            <source srcset="/images/certificate/reach/reach.webp" type="image/webp" />
                                            <img src="/images/certificate/reach/reach.png" />
                                        </picture>
=======
                    </div>
                    <div class="col">
                        <div class="d-flex justify-content-center">
                            <a class="link" href="reach.aspx">
                                <div class="certificate-wrapper">
                                    <div class="certificate-frame">
                                        <div class="certificate-title">
                                            REACH
                                        </div>
                                        <div class="certificate-date">
                                            Certified:2020/07/30
                                        </div>
                                        <div class="d-flex justify-content-center">
                                            <img src="images/certificate/reach/reach.jpg" class="img" />
                                        </div>
                                    </div>
                                    <div class="certificate-text h5">
                                        高度關切物質測試211項並通過REACH認證
>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
                                    </div>
                                </div>
                            </a>
                        </div>
<<<<<<< HEAD
                        <div class="certificate-text">
                            高度關切物質測試211項並通過REACH認證
                        </div>
=======
>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
                    </div>
                </div>
            </div>
        </div>
<<<<<<< HEAD
        <div class="display-block certification-body-list">
            <div class="title">
                線材安規認證
            </div>
            <div class="subtitle">
                Product Certificate
            </div>
            <div class="container content">
                <div class="row row-cols-2 row-cols-lg-3">
                    <div class="col">
                        <div class="certification-body">
                            <a class="link">
                                <div class="card">
                                    <picture>
                                        <source srcset="/images/certificate/sgs/sgs.webp" type="image/webp" />
                                        <img src="/images/certificate/sgs/sgs.png" class="img card-img mx-auto" />
                                    </picture>
                                    <div class="card-body p-0">
                                        <div class="certificate-text">
                                            SGS 台灣檢驗科技
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col">
                        <div class="certification-body">
                            <a class="link">
                                <div class="card">
                                    <picture>
                                        <source srcset="/images/certificate/intertek/intertek.webp" type="image/webp" />
                                        <img src="/images/certificate/intertek/intertek.png" class="img card-img mx-auto" />
                                    </picture>
                                    <div class="card-body p-0">
                                        <div class="certificate-text">
                                            INTERTEK 全國公證檢驗
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col">
                        <div class="certification-body">
                            <a class="link" href="/zh/certificate/ul">
                                <div class="card">
                                    <picture>
                                        <source srcset="/images/certificate/ul/ul.webp" type="image/webp" />
                                        <img src="/images/certificate/ul/ul.png" class="img card-img mx-auto" />
                                    </picture>
                                    <div class="card-body p-0">
                                        <div class="certificate-text">
                                            美國UL檢測認證研究所
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col">
                        <div class="certification-body">
                            <a class="link" href="/zh/certificate/vde">
                                <div class="card">
                                    <picture>
                                        <source srcset="/images/certificate/vde/vde.webp" type="image/webp" />
                                        <img src="/images/certificate/vde/vde.png" class="img card-img mx-auto" />
                                    </picture>
                                    <div class="card-body p-0">
                                        <div class="certificate-text">
                                            德國VDE檢測認證研究所
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col">
                        <div class="certification-body">
                            <a class="link">
                                <div class="card">
                                    <picture>
                                        <source srcset="/images/certificate/ccc/ccc.webp" type="image/webp" />
                                        <img src="/images/certificate/ccc/ccc.png" class="img card-img mx-auto" />
                                    </picture>
                                    <div class="card-body p-0">
                                        <div class="certificate-text">
                                            中國國際強制性產品認證
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col">
                        <div class="certification-body">
                            <a class="link">
                                <div class="card">
                                    <picture>
                                        <source srcset="/images/certificate/pse/pse.webp" type="image/webp" />
                                        <img src="/images/certificate/pse/pse.png" class="img card-img mx-auto" />
                                    </picture>
                                    <div class="card-body p-0">
                                        <div class="certificate-text">
                                            日本PSE產品綠色認證
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
=======
        <div class="display-block">
            <div class="block header">
                <div class="block title h2">
                    線材安規認證
                </div>
                <div class="block subtitle h4">
                    Product Certificate
                </div>
            </div>
            <div class="container block content">
                <div class="row row-cols-2">
                    <div class="col">
                        <a class="link">
                            <div class="card">
                                <img src="images/certificate/sgs/sgs.png" class="img card-img mx-auto" />
                                <div class="card-body p-0">
                                    <div class="card-text text-center">
                                        SGS 台灣檢驗科技
                                    </div>
                                </div>
                            </div>
                        </a>
                    </div>
                    <div class="col">
                        <a class="link">
                            <div class="card">
                                <img src="images/certificate/intertek/intertek.png" class="img card-img mx-auto" />
                                <div class="card-body p-0">
                                    <div class="card-text text-center">
                                        INTERTEK 全國公證檢驗
                                    </div>
                                </div>
                            </div>
                        </a>
                    </div>
                    <div class="col">
                        <a class="link" href="ul.aspx">
                            <div class="card">
                                <img src="images/certificate/ul/ul.png" class="img card-img mx-auto" />
                                <div class="card-body p-0">
                                    <div class="card-text text-center">
                                        美國UL檢測認證研究所
                                    </div>
                                </div>
                            </div>
                        </a>
                    </div>
                    <div class="col">
                        <a class="link" href="vde.aspx">
                            <div class="card">
                                <img src="images/certificate/vde/vde.png" class="img card-img mx-auto" />
                                <div class="card-body p-0">
                                    <div class="card-text text-center">
                                        德國VDE檢測認證研究所
                                    </div>
                                </div>
                            </div>
                        </a>
                    </div>
                    <div class="col">
                        <a class="link">
                            <div class="card">
                                <img src="images/certificate/3c/ccc.png" class="img card-img mx-auto" />
                                <div class="card-body p-0">
                                    <div class="card-text text-center">
                                        中國國際強制性產品認證
                                    </div>
                                </div>
                            </div>
                        </a>
                    </div>
                    <div class="col">
                        <a class="link">
                            <div class="card">
                                <img src="images/certificate/pse/pse.png" class="img card-img mx-auto" />
                                <div class="card-body p-0">
                                    <div class="card-text text-center">
                                        日本PSE產品綠色認證
                                    </div>
                                </div>
                            </div>
                        </a>
>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
                    </div>
                </div>
            </div>
        </div>
    </div>
<<<<<<< HEAD
=======

>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
</asp:Content>
