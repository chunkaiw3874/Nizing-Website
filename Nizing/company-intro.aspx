<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDCompanyMaster.master" AutoEventWireup="true" CodeFile="company-intro.aspx.cs" Inherits="company_intro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>日進電線-公司簡介</title>
    <style>
        .content {
            margin-top: 30px;
            text-align:left;
        }

            .content:first-child {
                margin-top: 0px;
            }

            @media all and (min-width:992px){
                .content{
                    text-align:justify;
                }
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="images/banner/banner-company-en-1920x500.png" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    日進簡介
                </div>
                <div class="subtitle">
                    Brief Introduction
                </div>
                <div class="content d-flex justify-content-center">
                    <div class="row m-0">                        
                        <div class="col-lg-4 pl-lg-0 d-none d-lg-block">
                            <img src="images/company/intro/nizing front desk.jpg" class="img w-100" />
                        </div>
                        <div class="d-block d-lg-none">
                            <img src="images/company/intro/nizing office.jpg" class="w-100 pb-3"/>
                        </div>
                        <div class="col-12 p-0 col-lg-8 h5">
                            <p>
                                日進電線是世界知名的耐熱耐壓電線廠，自1983年起進行特殊線材的研發、設計、及製造有長達
                                數十年的經驗，目前為國內最大的高溫及高壓電線研發製造商。日進電線集團以台灣為研發總部
                                ，專門為新產品量身訂做貼合需求之電線電纜。自1996年拓展至中國大陸以來，陸續在東莞、上
                                海等地設立了生產中心、營銷中心、及營銷網路，現已成為台灣與中國耐熱耐壓專業電線行業的
                                領導者。日進在與客戶的不斷交流溝通中，以完善的先進科技研發、製造及技術支持體系，為廣
                                大用戶提供專業的電線電纜。作為電線電纜業的領航者，日進以其前瞻的眼光及布局，不斷致力
                                於多元化耐熱耐壓電線及相關產品的研發，並生產出日臻完善的產品。
                            </p>
                            <p>
                                日進電線所生產的產品不僅規格齊全，且性能優異。其主要產品，耐高溫、耐高壓電線及套管系
                                列，均具有優良的耐熱、耐壓、耐燃燒、及抗老化等特性，使用溫度從攝氏-60到+1100度，品質
                                符合國際標準，並通過了UL、CUL、CSA、VDE等國際權威認證。產品廣泛適用於家用電器、暖房
                                器具、空調機器、照明燈具、電子設備、電熱製品、電腦通訊、航太以及汽車業等高科技領域。
                            </p>
                            <p>
                                日進電線已成為同業當之無愧的專業製造廠商，專門為客戶量身訂做新產品，開發、設計與製造
                                特殊線材。其矽膠電線、鐵氟龍電線、矽膠編織電線、矽膠套管等系列，和持續創新的電線產
                                品不僅備受廣大用戶的讚譽，更引導著專業電線產業不斷邁進的步伐。未來的日進電線將致力於耐
                                高溫、耐高壓線材的創新與研發，為客戶提供競爭力的產品，並以優質、高效、專業的服務，使日
                                進成為世界知名的國際化公司。
                            </p>
                        </div>
                    </div>
                </div>
                <div class="content">
                    <div class="h5">
                        <img src="images/company/intro/nizing office.jpg" class="img d-none d-lg-block" style="width: 500px; object-fit: contain; float: right; padding: 2px 0 12px 15px;" />
                        <div>
                            <p>
                                Nizing Group is the leader of high temperature and high voltage wire manufacturers.
                                We have been design, develop, and product custom wire and cable since 1983. Since then, 
                                Nizing has become a world renowned supplier for high temperature and high voltage wire
                                and cable. Our core ability is customizing and producing unique wire and cable products 
                                according to each customer's request. Nizing started in Taiwan, and expanded to China in 
                                1996, setup manufacture plants and marketing centers in Shanghai and Gongguan, and sales 
                                channels all over mainland China. We provide customers with the best solutions and dedicated
                                to making high quality high-end wire and cable.                                
                            </p>
                            <p>
                                Nizing have a wide range of products with great performance. Our greatest strength is our ability
                                to customize new product for each customer. We have been certified with global authorities such
                                as UL, CUL, CSA, PSE, VDE, CCC, among others. Our products are widely used in home appliances, 
                                air conditioners, computers, electronic equipments, communication equipments, aviations, automobiles,
                                and other industrial machines, with temperature range from -60 to 1100 Celsius.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

