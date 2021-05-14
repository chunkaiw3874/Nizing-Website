<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="company-intro.aspx.cs" Inherits="company_intro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>日進電線-公司簡介</title>
    <style>
        .downloadLink{
            color:#0094ff;
        }
        .downloadLink:hover{
            color:#00ffff;
            text-decoration:underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    公司簡介
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <a href="company-intro.aspx" class="active">公司簡介</a> | <a href="company-culture.aspx">核心文化</a> | <a href="company-history.aspx">歷史紀錄</a> | <a href="company-capability.aspx">設備技術</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="company-intro">
        <div class="inner-content">
            <div class="content-row">
                <div class="text">
                    日進電線股份有限公司創立於1983年，耐熱電線電纜起步，目前日進電線已是台灣電線電纜及特殊線材產業領導廠商，同時成功跨足綠能光電、成為國際化企業。 <br />
        	        <p>日進電線所生產的矽膠線、補償導線、PVC線、不銹鋼線材，廣泛運用於電力傳輸、電信網路、交通運輸、工業生產等基礎建設。旗下核心事業中，電線電纜事業包含矽膠耐熱電線、補償導線、PVC照射線等電線電纜。電力電纜與通信線纜產品線完整，深耕台灣電力和電信需求。<br /></p>
	                <p>日進電線自2003年開始研發LED、溫度控制、醫療、雲端及太陽能光電等產業，藉由研發及先進材料產業的經驗及成果，作為佈局新興科技領域的基礎。 <br /></p>
                    <p>日進電線擁有完整的產品系列，通過數種國際安規認可產品。以最熱忱的服務態度，不斷精進品質，開發新產品，和客戶共同發展、共同成長。由于您持續的支持與愛護，以前瞻性的佈局策略追求企業創新成長，進行自主技術之研究，依據市場及客戶需求開發新產品與新業務。日進電線秉持一貫對品質的嚴謹要求，以及快速整合的服務，成為客戶的最佳伙伴，在兩岸經濟發展的重要里程中，扮演關鍵的參與和推動角色，未來日進電線將在卓越製造技術與多樣化客戶基礎下持續深耕，同時積極掌握產業新興發展機會，創造企業發展的新里程。</p>
                </div>
                <div class="img">
                    <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/images/company/company-intro4.jpg" />--%>
                    <video controls="controls" width="300">
                        <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/images/company/company-intro4.jpg" />--%>
                        <source src="video/nizing-intro.mp4" type="video/mp4" />
                        Your browser does not support the video tag
                    </video>
                    <a href="pdf/日進電線公司簡介(中).pptx" class="downloadLink" style="font-size:16px">下載公司簡介</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

