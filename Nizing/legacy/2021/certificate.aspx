<%@ Page Title="" Language="C#" MasterPageFile="~/master/certificateMaster2021.master" AutoEventWireup="true" CodeFile="certificate.aspx.cs" Inherits="certificate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>日進電線-安規認證</title>
    <style>
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
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="d-flex justify-content-center">
                        </div>
                    </div>
                </div>
            </div>
        </div>
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
                                    </div>
                                </div>
                            </a>
                        </div>
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
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
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
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
