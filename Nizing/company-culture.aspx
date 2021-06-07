<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDCompanyMaster.master" AutoEventWireup="true" CodeFile="company-culture.aspx.cs" Inherits="company_culture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>日進電線-核心文化</title>
    <style>
        .display-block .content .top img {
            width: 100%;
            box-shadow: 5px 5px 15px 5px #6f6f6f;
            margin-bottom: 2rem;
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
                    企業核心價值與經營理念
                </div>
                <div class="subtitle">
                    ENTERPRISE CULTURE
                </div>
                <div class="content">
                    <div class="flex-column justify-content-center">
                        <div class="top">
                            <img src="images/company/culture/christmas-1.png" />
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
                        <div class="col-md-4 pl-md-0 d-none d-md-block">
                            <img src="images/company/culture/christmas-2.png" class="img w-100" />
                        </div>
                        <div class="col-12 p-0 col-md-8 pl-md-2 d-flex flex-md-column justify-content-md-between">
                            <div class="row m-0">
                                <div class="p-0 col-md-12">
                                    <p>日進電線除了人的不懈努力外，更重要的歸功于各位先進的指導與愛護。貫徹整體顧客意識，珍惜每一次服務的機會。全體日進電線人員處世以&quot;誠&quot;、&quot;信&quot;為原則；&quot;誠&quot;乃是出自於內心的真誠，&quot;信&quot;則是言而有信、言出必行。&quot;積極、創新、追求卓越&quot;是日進電線的經營理念。</p>
                                    <p>我們深信，唯有堅定的企業信念、熱忱投入的工作態度、以及高效率和實事求是的負責精神，才能贏得客戶的支持與信賴。</p>
                                    <p>日進就是一個可以帶給大家幸福的地方。以日進為本，照顧大家。透過日進，大家互相協助，互相理解，同心協力幫助客戶解決問題。這就是我們的宗旨。</p>
                                </div>
                            </div>
                            <div class="row m-0 d-none d-md-block">
                                <div class="offset-md-6 col-md-6 pr-0">
                                    <img src="images/company/culture/christmas-3.png" class="img w-100" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

