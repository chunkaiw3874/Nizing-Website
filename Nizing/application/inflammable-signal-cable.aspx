<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="inflammable-signal-cable.aspx.cs" Inherits="application_inflammable_signal_cable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>防火耐燃訊號線-日進電線 2021</title>
    <meta name="description" content="AM2F特殊編織環保線材，有效阻絕火焰直接燃燒，將防火與耐燃能力推向消防等級，符合綠色能量之宗旨，無毒、無味、無汙染、耐腐蝕化學品...等特性，以環保及居家安全為首要指標。編織線材高柔韌性、耐彎折、不易斷且好收藏，此材質應用廣泛，也可應用汽車排氣管、潛艇引擎、發電機等各式線材上，適合各式場合或極端工作環境。" />
    <meta property="og:type" content="article" />
    <meta property="og:title" content="防火耐燃訊號線-日進電線 2021" />
    <meta property="og:description" content="AM2F特殊編織環保線材，有效阻絕火焰直接燃燒，將防火與耐燃能力推向消防等級，符合綠色能量之宗旨，無毒、無味、無汙染、耐腐蝕化學品...等特性，以環保及居家安全為首要指標。編織線材高柔韌性、耐彎折、不易斷且好收藏，此材質應用廣泛，也可應用汽車排氣管、潛艇引擎、發電機等各式線材上，適合各式場合或極端工作環境。" />
    <meta property="og:image" content="https://www.nizing.com.tw/images/application/products/inflammable-signal-cable/impression/inflammable-signal-cable-01-horizontal.png" />
    <meta property="og:url" content="https://www.nizing.com.tw/zh/application/cloud-system/inflammable-signal-cable" />
    <meta property="og:site_name" content="Nizing Electric Wire and Cable" />
    <style type="text/css">
        body {
            color: #595757;
            font-size: 20px;
        }

        p {
            margin: 0;
        }

        .breadcrumb {
            display: none;
        }

        img {
            object-fit: cover;
        }

        .bg-wrapper {
            background-color: #DADBDB;
        }

        .section {
            padding-bottom: 16px;
        }

        .slogan-section {
            display: flex;
            flex-direction: column;
            align-self: center;
        }

        .small-text {
            font-size: 20px;
            line-height: 2;
        }

        .large-text {
            font-size: 72px;
            line-height: 1.4;
        }

        .slogan {
            display: flex;
        }

            .slogan p:first-child {
                padding-right: 46px;
            }

        .image-section {
            padding-bottom: 8px;
        }

        .text-section {
            padding-bottom: 8px;
        }

        .text-blue {
            color: #036EB6;
        }

        .text-green {
            color: #0DAB67;
        }

        .text-red {
            color: #FF5050;
        }

        .bg-gray {
            background-color: #B3B3B4;
        }

        .horizontal-image-divider img {
            margin-left: auto;
        }

        @media all and (max-width:1199px) {
            body {
                font-size: 16px;
            }

            .small-text {
                font-size: 16px;
                line-height: 2;
            }

            .large-text {
                font-size: 60px;
                line-height: 1.4;
            }

            .slogan p:first-child {
                padding-right: 38px;
            }
        }

        @media all and (max-width:991px) {
            .small-text {
                font-size: 14px;
                line-height: 2;
            }

            .large-text {
                font-size: 40px;
                line-height: 1.4;
            }

            .slogan p:first-child {
                padding-right: 24px;
            }
        }

        @media all and (max-width:767px) {
            .small-text {
                font-size: 14px;
                line-height: 2;
            }

            .large-text {
                font-size: 32px;
                line-height: 1.4;
            }

            .slogan p:first-child {
                padding-right: 20px;
            }
        }

        @media all and (max-width:575px) {
            .section.top {
                margin-bottom: 0;
            }

            .small-text {
                font-size: 14px;
                line-height: 2;
            }

            .large-text {
                font-size: 32px;
                line-height: 1.4;
            }

            .slogan p:first-child {
                padding-right: 20px;
            }
        }

        /*video css*/
        .video-wrapper {
            position: relative;
        }

            .video-wrapper > video {
                width: 100%;
                vertical-align: middle;
            }

                .video-wrapper > video.has-media-controls-hidden::-webkit-media-controls {
                    display: none;
                }

        .video-overlay-play-button {
            box-sizing: border-box;
            width: 100%;
            height: 100%;
            padding: 10px calc(50% - 50px);
            position: absolute;
            top: 0;
            left: 0;
            display: block;
            opacity: 0.95;
            cursor: pointer;
            background-image: linear-gradient(transparent, #000);
            transition: opacity 150ms;
        }

            .video-overlay-play-button:hover {
                opacity: 1;
            }

            .video-overlay-play-button.is-hidden {
                display: none;
            }

        .youtube-wrapper {
            position: relative;
            padding-bottom: 56.25%;
            /* 16:9 */
            padding-top: 25px;
            height: 0;
        }

        .youtube-wrapper iframe {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
        }
    </style>

    <script>
        $(document).ready(function () {
            var videoPlayButton,
                videoWrapper = document.getElementsByClassName('video-wrapper')[0],
                video = document.getElementsByTagName('video')[0],
                videoMethods = {
                    renderVideoPlayButton: function () {
                        if (videoWrapper.contains(video)) {
                            this.formatVideoPlayButton()
                            video.classList.add('has-media-controls-hidden')
                            videoPlayButton = document.getElementsByClassName('video-overlay-play-button')[0]
                            videoPlayButton.addEventListener('click', this.hideVideoPlayButton)
                        }
                    },
                    formatVideoPlayButton: function () {
                        videoWrapper.insertAdjacentHTML('beforeend', '\
                            <svg class= "video-overlay-play-button" viewBox="0 0 200 200" alt = "Play video">\
                            <circle cx="100" cy="100" r="90" fill="none" stroke-width="15" stroke="#fff" />\
                            <polygon points="70, 55 70, 145 145, 100" fill="#fff" />\
                            </svg >\
                        ')
                    },
                    hideVideoPlayButton: function () {
                        video.play()
                        videoPlayButton.classList.add('is-hidden')
                        video.classList.remove('has-media-controls-hidden')
                        video.setAttribute('controls', 'controls')
                    }
                }
            videoMethods.renderVideoPlayButton()
        })

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="container-fluid">
        <div class="bg-wrapper">
            <div class="container">
                <div class="section top">
                    <div class="row">
                        <div class="d-none d-sm-block col-sm-3 col-md-2">
                            <picture>
                                <source srcset="/images/application/products/inflammable-signal-cable/impression/inflammable-signal-cable-01.webp" type="image/webp" />
                                <img src="/images/application/products/inflammable-signal-cable/impression/inflammable-signal-cable-01.webp"
                                    alt="防火耐燃訊號線" />
                            </picture>
                        </div>
                        <div class="slogan-section col-sm-9 col-md-10">
                            <p class="small-text">iPhone / Type C 快速充電線</p>
                            <p class="large-text"><span class="text-blue">消防級</span>AM2F<span class="text-green">環保</span>線材</p>
                            <div class="slogan large-text">
                                <p class="text-red">防火耐燃</p>
                                <p>安全再升級</p>
                            </div>
                            <p>
                                AM2F特殊編織環保線材，有效阻絕火焰直接燃燒，將防火與耐
燃能力推向消防等級，符合綠色能量之宗旨，無毒、無味、無汙
染、耐腐蝕化學品...等特性，以環保及居家安全為首要指標。編
織線材高柔韌性、耐彎折、不易斷且好收藏，此材質應用廣泛，
也可應用汽車排氣管、潛艇引擎、發電機等各式線材上，適合各
式場合或極端工作環境。
                            </p>
                        </div>
                    </div>
                </div>
            </div>

            <div class="d-block d-sm-none horizontal-image-divider">
                <picture>
                    <source srcset="/images/application/products/inflammable-signal-cable/impression/inflammable-signal-cable-01-horizontal.webp" type="image/webp" />
                    <img src="/images/application/products/inflammable-signal-cable/impression/inflammable-signal-cable-01-horizontal.png"
                        alt="防火耐燃訊號線" />
                </picture>
            </div>
            <div class="container">
                <div class="section">
                    <div class="image-section">
                        <picture>
                            <source srcset="/images/application/products/inflammable-signal-cable/impression/inflammable-signal-cable-02.webp" type="image/webp" />
                            <img src="/images/application/products/inflammable-signal-cable/impression/inflammable-signal-cable-02.png"
                                alt="防火耐燃訊號線耐燃特性" />
                        </picture>
                    </div>
                    <div class="text-section">
                        使用AM2F特殊編織環保線材，溫度範圍為0∼1000度，耐高溫、耐化學腐蝕，不產生有毒氣體，可應用在各式線材上及適合運用在極端工作環境。
                    </div>
                    <div class="image-section">
                        <picture>
                            <source srcset="/images/application/products/inflammable-signal-cable/impression/inflammable-signal-cable-03.webp" type="image/webp" />
                            <img src="/images/application/products/inflammable-signal-cable/impression/inflammable-signal-cable-03.png"
                                alt="防火耐燃訊號線耐燃測試實驗" />
                        </picture>
                    </div>
                    <div class="text-section">
                        防火耐燃測試中，它牌電線經燃燒，著火後會往左右二邊延燒並不斷冒出黑煙產生出惡臭的有毒氣體，日進電線的消防級AM2F環保線材燃燒後，著火部份火源穩定且不會往左右延燒，也不會產生有毒黑煙。
                    </div>
                    <div class="image-section row">
                        <div class="col-6">
                            <picture>
                                <source srcset="/images/application/products/inflammable-signal-cable/impression/inflammable-signal-cable-04.webp" type="image/webp" />
                                <img src="/images/application/products/inflammable-signal-cable/impression/inflammable-signal-cable-04.png"
                                    alt="日進防火耐燃訊號線耐燃實驗完成後依然正常" />
                            </picture>
                            <div class="text-center text-blue" style="font-size: 20px;">
                                日進牌電線燒後外觀
                            </div>
                            <div class="px-1">
                                電線外觀完整，些許焦黑但無破損，且可正常充電。
                            </div>
                        </div>
                        <div class="col-6">
                            <picture>
                                <source srcset="/images/application/products/inflammable-signal-cable/impression/inflammable-signal-cable-05.webp" type="image/webp" />
                                <img src="/images/application/products/inflammable-signal-cable/impression/inflammable-signal-cable-05.png"
                                    alt="它牌訊號線耐燃測試實驗後無法繼續使用" />
                            </picture>
                            <div class="text-center text-blue" style="font-size: 20px;">
                                它牌電線燒後外觀
                            </div>
                            <div class="px-1">
                                電線外觀己融化變形，導體部份斷裂外露，己無法正常充電。
                            </div>
                        </div>
                    </div>
                    <div class="text-section">
                        <div class="bg-gray text-center text-red" style="font-size: 24px;">
                            防火耐燃測試完整影片
                        </div>
                    </div>
                    <div class="image-section youtube-wrapper">
                        <iframe width="560" height="315" src="https://www.youtube.com/embed/FZJH8dnI9Wo"
                            title="YouTube video player"
                            frameborder="0"
                            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
                            allowfullscreen></iframe>
                        <%--                        <div class="video-wrapper">
                            <video width="100" poster="/images/application/products/inflammable-signal-cable/impression/inflammable-signal-cable-02.webp">
                                <source src="/images/application/products/inflammable-signal-cable/impression/inflammable-signal-cable-flammability-test-20210922.ogg"
                                    type="video/ogg" />
                            </video>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>

