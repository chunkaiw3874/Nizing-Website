<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="application.aspx.cs" Inherits="application" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <title>應用產業-日進電線</title>
    <meta name="description" content="日進電線持續與最頂尖的新科技接軌，持續研發，滿足各種客製需求">

    <style type="text/css">
        .bg-wrapper {
            background-image: url('/images/application/background/bg-application.jpg');
        }

        .overlay-parent {
            min-height: 100%;
        }

        .opacity-100 {
            opacity: 1 !important;
        }

        .bg-skyblue .title {
            mix-blend-mode: normal !important;
        }
    </style>
</asp:Content>
<asp:Content ID="banner" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="images/banner/banner-application-en.png" alt="電線電纜應用產業 wire and cable application" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper application-category-list">
        <section class="display-block bg-wrapper">
            <div class="title">
                應用產業
            </div>
            <div class="subtitle">
                PRODUCT APPLICATION
            </div>
            <div class="container-fluid">
                <div class="container">
                    <div class="content row row-cols-2 row-cols-md-3 row-cols-lg-4 application-list">
                        <div class="col application-category-item">
                            <a href="car.aspx">
                                <figure class="overlay-parent shadow move">
                                    <img src="images/application/car/car.jpg"
                                        alt="車用配線 Automobile Wire and Cable" />
                                    <div class="overlay">
                                        <figcaption class="title dark-background text-glow">
                                            車用配線
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col application-category-item">
                            <a href="medical.aspx">
                                <figure class="overlay-parent shadow move">
                                    <img src="images/application/medical/medical.jpg"
                                        alt="醫療用線 Medical Wire and Cable" />
                                    <div class="overlay">
                                        <figcaption class="title light-background text-glow">
                                            醫療配線與耗材
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col application-category-item">
                            <a href="heating.aspx">
                                <figure class="overlay-parent shadow move">
                                    <div class="overlay bg-skyblue opacity-100">
                                        <figcaption class="title dark-background text-glow">
                                            加熱系統配線
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col application-category-item">
                            <a href="temperature-control.aspx">
                                <figure class="overlay-parent shadow move opacity-80">
                                    <div class="overlay bg-white opacity-100">
                                        <figcaption class="title light-background text-glow">
                                            溫控系統配線
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col application-category-item">
                            <a href="led.aspx">
                                <figure class="overlay-parent shadow move bg-white opacity-80">
                                    <div class="overlay bg-white opacity-100">
                                        <figcaption class="title light-background text-glow">
                                            LED燈具配線
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col application-category-item d-none d-lg-block">
                            <div class="application-category-item-wrapper bg-white opacity-0">
                            </div>
                        </div>
                        <div class="col application-category-item">
                            <a href="construction.aspx">
                                <figure class="overlay-parent shadow move opacity-80">
                                    <div class="overlay bg-white opacity-100">
                                        <figcaption class="title light-background text-glow">
                                            建築配線
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col application-category-item">
                            <a href="solar.aspx">
                                <figure class="overlay-parent shadow move">
                                    <img src="images/application/solar/solar.jpg"
                                        alt="太陽能配線 Solar Electricity Wire and Cable" />
                                    <div class="overlay">
                                        <figcaption class="title dark-background text-glow">
                                            太陽能配線
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col application-category-item d-none d-lg-block">
                            <div class="application-category-item-wrapper bg-white opacity-0">
                            </div>
                        </div>
                        <div class="col application-category-item">
                            <a href="steel.aspx">
                                <figure class="overlay-parent shadow move">
                                    <div class="overlay bg-skyblue opacity-100">
                                        <figcaption class="title dark-background text-glow">
                                            鋼鐵工業配線
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col application-category-item d-none d-lg-block">
                            <div class="application-category-item-wrapper bg-white opacity-0">
                            </div>
                        </div>
                        <div class="col application-category-item">
                            <a href="robotic.aspx">
                                <figure class="overlay-parent shadow move">
                                    <img src="images/application/robotic/robotic.jpg"
                                        alt="機械手臂配線 Robotics wire and cable" />
                                    <div class="overlay">
                                        <figcaption class="title dark-background text-glow">
                                            機械手臂配線
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col application-category-item">
                            <a href="semiconductor.aspx">
                                <figure class="overlay-parent shadow move">
                                    <div class="overlay bg-skyblue opacity-80">
                                        <figcaption class="title dark-background text-glow">
                                            半導體產業
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col application-category-item d-none d-lg-block">
                            <div class="application-category-item-wrapper bg-skyblue opacity-0">
                            </div>
                        </div>
                        <div class="col application-category-item">
                            <a href="cloud.aspx">
                                <figure class="overlay-parent shadow move">
                                    <div class="overlay bg-skyblue opacity-100">
                                        <figcaption class="title dark-background text-glow">
                                            雲端系統配線
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                        <div class="col application-category-item">
                            <a href="misc-app.aspx">
                                <figure class="overlay-parent shadow move opacity-80">
                                    <div class="overlay bg-skyblue opacity-100">
                                        <figcaption class="title dark-background text-glow">
                                            其他應用
                                        </figcaption>
                                    </div>
                                </figure>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

