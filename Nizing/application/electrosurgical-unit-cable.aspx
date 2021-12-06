<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="electrosurgical-unit-cable.aspx.cs" Inherits="application_electrosurgical_unit_cable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>
        <%if (RouteData.Values["language"].ToString() == "zh")
            {%>
                                                醫療級止血線-日進電線 2021
                                                <%}
                                                    else
                                                    {%>
                                                Electrosurgical Unit Cable - Nizing Electric Wire & Cable
                                            <%}%>
        </title>
    <meta name="description" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "電刀是利用電能產生熱，加熱至100°C則可使細胞破裂，達到切割目的，當溫度來至200°C時則可以快速且大面積的止血，選用擁有極為優越溫度高穩定性的「醫療級止血線」，可在-40°C~200°C溫度內安全穩定的提供電能。"
                                                <%}
        else
        {%>
                                                "Electrosurgical Unit uses electricity to generate heat. It is capable of splitting cells when it reaches 100°C, and stops bleeding in large area swiftly at 200°C. Our Electrosurgical Unit Cable provides electricity between -40°C~200°C with safety and stability."
                                            <%}%> />
    <meta property="og:type" content="article" />
    <meta property="og:title" content=
        <%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "醫療級止血線-日進電線 2021"
                                                <%}
        else
        {%>
                                                "Electrosurgical Unit Cable - Nizing Electric Wire & Cable"
                                            <%}%> />
    <meta property="og:description" content=<%if (RouteData.Values["language"].ToString() == "zh")
        {%>
                                                "電刀是利用電能產生熱，加熱至100°C則可使細胞破裂，達到切割目的，當溫度來至200°C時則可以快速且大面積的止血，選用擁有極為優越溫度高穩定性的「醫療級止血線」，可在-40°C~200°C溫度內安全穩定的提供電能。"
                                                <%}
        else
        {%>
                                                "Electrosurgical Unit uses electricity to generate heat. It is capable of splitting cells when it reaches 100°C, and stops bleeding in large area swiftly at 200°C. Our Electrosurgical Unit Cable provides electricity between -40°C~200°C with safety and stability."
                                            <%}%> />
    <meta property="og:image" content="https://www.nizing.com.tw/images/application/products/electrosurgical-unit-cable/impression/electrosurgical-unit-cable-01-mobile.png" />
    <meta property="og:url" content="https://www.nizing.com.tw/<%=RouteData.Values["language"].ToString() %>/application/misc-app/electrosurgical-unit-cable" />
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
            background: url("/images/application/products/electrosurgical-unit-cable/impression/electrosurgical-unit-cable-bg.webp") no-repeat top right / contain;
        }

        .no-webp .bg-wrapper {
            background: url("/images/application/products/electrosurgical-unit-cable/impression/electrosurgical-unit-cable-bg.jpg") no-repeat top right / contain;
        }

        .bg-color {
            background-color: #88b0c9 !important;
        }

        .bottom-image {
            position: absolute;
            top: 320px;
            right: 0;
            width: 50%;
            justify-content: right;
        }

        .bottom-image-2 {
            position: absolute;
            top: 460px;
            right: 0;
            width: 50%;
        }

        .text-section {
            padding: 0 46px 0 150px;
            margin-top: 40px;
            margin-bottom: 150px;
            font-weight: bold;
        }

            .text-section .text-title {
                color: #B7467E;
                padding-bottom: 18px;
            }

        .zh .text-section .text-title {
            font-size: 56px;
        }

        .en .text-section .text-title {
            font-size: 30px;
        }


        .text-section .text-subtitle {
            color: #1951A3;
            padding-bottom: 16px;
        }

        .zh .text-section .text-subtitle {
            font-size: 28px;
        }

        .en .text-section .text-subtitle {
            font-size: 20px;
        }

        .text-section .text-content {
            color: #304068;
            padding-bottom: 24px;
        }

        .zh .text-section .text-content {
            font-size: 16px;
        }

        .en .text-section .text-content {
            font-size: 16px;
        }

        .text-section .text-image {
        }

        @media all and (max-width:1199px) {
            .text-section {
                margin-top: 40px;
                margin-bottom: 40px;
                padding-left: 46px;
            }

            .bottom-image {
                top: 280px;
            }

            .text-section .text-title {
                padding-bottom: 14px;
            }

            .zh .text-section .text-title {
                font-size: 56px;
            }

            .en .text-section .text-title {
                font-size: 30px;
            }

            .text-section .text-subtitle {
                padding-bottom: 16px;
            }

            .zh .text-section .text-subtitle {
                font-size: 26px;
            }

            .en .text-section .text-subtitle {
                font-size: 22px;
            }

            .text-section .text-content {
                font-size: 16px;
                padding-bottom: 20px;
            }
        }

        @media all and (max-width:991px) {
            .text-section {
                margin-top: 40px;
                margin-bottom: 100px;
            }

            .bottom-image {
                top: 210px;
            }

            .zh .text-section .text-title {
                font-size: 40px;
            }

            .en .text-section .text-title {
                font-size: 22px;
            }

            .zh .text-section .text-subtitle {
                font-size: 20px;
            }

            .en .text-section .text-subtitle {
                font-size: 18px;
            }

            .text-section .text-content {
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
                margin-top: 20px;
                padding: 0 20px;
                margin-bottom: 40px;
            }

            .zh .text-section .text-title {
                font-size: 70px;
            }

            .en .text-section .text-title {
                font-size: 40px;
            }

            .zh .text-section .text-subtitle {
                font-size: 26px;
            }

            .en .text-section .text-subtitle {
                font-size: 26px;
            }

            .text-section .text-content {
                font-size: 16px;
            }
        }

        @media all and (max-width:575px) {
            .zh .text-section .text-title {
                font-size: 48px;
            }

            .en .text-section .text-title {
                font-size: 26px;
            }

            .en .text-section .text-subtitle {
                font-size: 20px;
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
                    <source srcset="/images/application/products/electrosurgical-unit-cable/impression/electrosurgical-unit-cable-01-mobile.webp"
                        type="image/webp" />
                    <img src="/images/application/products/electrosurgical-unit-cable/impression/electrosurgical-unit-cable-01-mobile.jpg"
                        alt="醫療級止血線 Electrosurgical Unit Cable" />
                </picture>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="text-section">
                        <div class="text-title">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>
                                                醫療級止血線材
                                                <%}
                                                    else
                                                    {%>
                                                Electrosurgical Unit Cable
                                            <%}%>
                        </div>
                        <div class="text-subtitle">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>
                                                值得信賴的優越穩定性
                                                <%}
                                                    else
                                                    {%>
                                                Stability, Trustworthy
                                            <%}%>
                        </div>
                        <div class="text-content">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>
                                                電刀是利用電能產生熱，加熱至100°C則可使細胞破裂，達到切割目的，當溫度來至200°C時則可以快速且大面積的止血，選用擁有極為優越溫度高穩定性的「醫療級止血線」，可在-40°C~200°C溫度內安全穩定的提供電能。
                                                <%}
                                                    else
                                                    {%>
                                                Electrosurgical Unit uses electricity to generate heat. It is capable of splitting cells when it reaches 100°C, and stops bleeding in large area swiftly at 200°C. Our Electrosurgical Unit Cable provides electricity between -40°C~200°C with safety and stability.
                                            <%}%>
                        </div>
                        <div class="text-subtitle">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>
                                                安全可靠 守護面面俱到
                                                <%}
                                                    else
                                                    {%>
                                                Safety, Reliability
                                            <%}%>
                        </div>
                        <div class="text-content">
                            <%if (RouteData.Values["language"].ToString() == "zh")
                                {%>
                                                醫療用電線面對的環境較為嚴苛複雜，此線材有耐拉、柔軟、耐撓曲、耐電壓、耐彎折、抗干擾性能強等特性，並可承受多次重複性擦拭及消毒不會產生變質，通過生物相容性測試，人體在接觸到材料後不會引起發炎反應、免疫反應、毒性反應、血栓形成反應等危害，是最安全有保障的醫療儀器的首選線材。
                                                <%}
                                                    else
                                                    {%>
                                                Medical Cable is often used in complex situations, it requires the  cable to be consist of many advantageous characteristics such as high flexibility, high voltage resistance, high signal interference resistance, high chemical resistance, non-toxic, and less allergy prone to humans. The Electrosurgical Unit Cable is produced with these characteristics in mind, and thus highly recommended for your medical equipments.
                                            <%}%>
                        </div>
                        <div class="d-md-none d-lg-flex justify-content-center text-image">
                            <picture>
                                <img src="/images/application/products/electrosurgical-unit-cable/impression/electrosurgical-unit-cable-02-<%=RouteData.Values["language"].ToString() %>.svg"
                                    alt="醫療級止血線結構 Electrosurgical Unit Cable Structure" class="mx-auto" />
                            </picture>
                        </div>
                    </div>
                </div>
            </div>
            <div class="d-none d-md-flex bottom-image">
                <picture>
                    <source srcset="/images/application/products/electrosurgical-unit-cable/impression/electrosurgical-unit-cable-01.webp"
                        type="image/webp" />
                    <img src="/images/application/products/electrosurgical-unit-cable/impression/electrosurgical-unit-cable-01.png"
                        alt="醫療級止血線 Electrosurgical Unit Cable" />
                </picture>
            </div>
            <div class="d-none d-md-flex d-lg-none bottom-image-2">
                <picture>
                    <img src="/images/application/products/electrosurgical-unit-cable/impression/electrosurgical-unit-cable-02-<%=RouteData.Values["language"].ToString() %>.svg"
                        alt="醫療級止血線結構 Electrosurgical Unit Cable Structure" class="mx-auto" />
                </picture>
            </div>
        </div>
    </div>
</asp:Content>

