<%@ Page Title="" Language="C#" MasterPageFile="~/master/indexMaster2021.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>高品質電線電纜製造-日進電線-國際安規認證通過</title>
    <meta name="keywords" content="電線,電纜,電線電纜,矽膠電線,鐵氟龍電線,照射電線,發熱電線,PVC電線,PE電線,PU電線,補償導線,耐高溫電線,耐高溫電纜,耐高壓電線,耐高壓電纜,UL電線,矽膠編織電線,軍規線,汽車花線" />
    <meta name="description" content="日進電線為國內一流電線及電纜製造商，專門製造特殊材質及用途電線及電纜，如耐高溫的矽膠電線、矽膠編織電線，抗酸鹼的聚合氟化線電線，抗UV的照射電線等，旗下電線電纜產品眾多，歡迎聯繫洽詢" />

    <script type="text/javascript">
        //for onmouseover image swap
        function SwapImage(e) {
            e = e || window.event;
            var link = e.target || e.srcElement;
            document.getElementById("ContentPlaceHolder1_imgNews").src = link.title;
            document.getElementById("ContentPlaceHolder1_imgNews").style.height = '180px';
            document.getElementById("ContentPlaceHolder1_imgNews").style.width = '215px';
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="main-content">
        <div class="product">
            <div class="title-no-border">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/title/title_product.jpg" />
            </div>
            <div class="main-page-menu-product">
                <div class="button">
                    <asp:HyperLink ID="HyperLink19" runat="server" ImageUrl="~/images/product/pro_01.jpg" NavigateUrl="~/pvc-series.aspx" Text="PVC電線" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink20" runat="server" ImageUrl="~/images/product/pro_02.jpg" NavigateUrl="~/silicone-fiberglass-series.aspx" Text="矽膠編織電線" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink21" runat="server" ImageUrl="~/images/product/pro_03.jpg" NavigateUrl="~/high-temperature-resistance-series.aspx" Text="耐溫電線" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink22" runat="server" ImageUrl="~/images/product/pro_04.jpg" NavigateUrl="~/silicone-series.aspx" Text="矽膠電線" />
                </div>
            </div>
            <div class="main-page-menu-product">
                <div class="button">
                    <asp:HyperLink ID="HyperLink23" runat="server" ImageUrl="~/images/product/pro_05.jpg" NavigateUrl="~/teflon-series.aspx" Text="鐵氟龍電線" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink24" runat="server" ImageUrl="~/images/product/pro_06.jpg" NavigateUrl="~/xlpe-series.aspx" Text="照射電線" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink25" runat="server" ImageUrl="~/images/product/pro_07.jpg" NavigateUrl="~/sleeve-and-tube-series.aspx" Text="套管" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink26" runat="server" ImageUrl="~/images/product/pro_08.jpg" NavigateUrl="~/thermocouple-series.aspx" Text="補償導線" />
                </div>
            </div>
            <div class="main-page-menu-product">
                <div class="button">
                    <asp:HyperLink ID="HyperLink27" runat="server" ImageUrl="~/images/product/pro_09.jpg" NavigateUrl="~/heating-wire-series.aspx" Text="發熱線" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink28" runat="server" ImageUrl="~/images/product/pro_10.jpg" NavigateUrl="~/special-cable.aspx" Text="特殊規格電線" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink29" runat="server" ImageUrl="~/images/product/pro_11.jpg" NavigateUrl="~/automotive-wire-series.aspx" Text="汽車花線" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink41" runat="server" ImageUrl="~/images/product/pro_12.jpg" NavigateUrl="~/military-grade-series.aspx" Text="軍規線" />
                </div>
            </div>
        </div>
        <div class="product">
            <div class="title-no-border">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/images/title/title_application.jpg" />
            </div>
            <div class="main-page-menu-product">
                <div class="button">
                    <asp:HyperLink ID="HyperLink30" runat="server" ImageUrl="~/images/service/s1.jpg" NavigateUrl="~/car.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink31" runat="server" ImageUrl="~/images/service/s2.jpg" NavigateUrl="~/cloud.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink32" runat="server" ImageUrl="~/images/service/s3.jpg" NavigateUrl="~/heating.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink33" runat="server" ImageUrl="~/images/service/s4.jpg" NavigateUrl="~/medical.aspx" />
                </div>
            </div>
            <div class="main-page-menu-product">
                <div class="button">
                    <asp:HyperLink ID="HyperLink34" runat="server" ImageUrl="~/images/service/s5.jpg" NavigateUrl="~/led.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink35" runat="server" ImageUrl="~/images/service/s6.jpg" NavigateUrl="~/temperature-control.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink36" runat="server" ImageUrl="~/images/service/s7.jpg" NavigateUrl="~/construction.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink37" runat="server" ImageUrl="~/images/service/s8.jpg" NavigateUrl="~/solar.aspx" />
                </div>
            </div>
            <div class="main-page-menu-product">
                <div class="button">
                    <asp:HyperLink ID="HyperLink38" runat="server" ImageUrl="~/images/service/s9.jpg" NavigateUrl="~/steel.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink40" runat="server" ImageUrl="~/images/service/s10.jpg" NavigateUrl="~/roboarm.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink39" runat="server" ImageUrl="~/images/service/misc-app.jpg" NavigateUrl="~/misc-app.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLinkSvcLast" runat="server" ImageUrl="~/images/button/customize_icon-215x123.jpg" NavigateUrl="~/customize_page.aspx" />
                </div>
            </div>
        </div>
        <div id="news-default">
            <div class="title-no-border">
                <asp:Image ID="titleNews" runat="server" ImageUrl="~/images/title/title_news.jpg" />
            </div>
            <div class="img">
                <%--<asp:Image ID="imgNews" runat="server" />--%>
            </div>
            <div class="default-content">
                <ul>
                    <%-- 最上面一排ID必須為url1，圖片才會變成預設顯示 --%>
                    <li>
                        <asp:HyperLink ID="url1" runat="server" onmouseover="SwapImage();" ToolTip="images/news/20180823中元普渡.jpg"> 2018.08.23 一年一度的中元普度，保佑日進生意興隆~ </asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="url5" runat="server" onmouseover="SwapImage();" ToolTip="images/news/20180420_moving_notice.jpg" NavigateUrl="https://www.facebook.com/NIZING.ELECTRIC/photos/pb.367173643345648.-2207520000.1524197134./1818663161530015/?type=3&theater" Target="_blank"> 2018.04.20 遷移啟事：本公司將於107/06/04(一)遷至新址，並照常出貨至06/01(五)，06/02(六)全廠加班搬遷，06/04(一)恢復正常營運，搬遷期間一切正常營運，屆時請依新址、電話及傳真聯絡，繼續給予支持指教！ </asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="url2" runat="server" onmouseover="SwapImage();" ToolTip="images/news/20170108_year_end_banquet.jpg"> 2018.03.28 4/4(三)~4/8(日)為清明連假，為配合貨運公司，4/3出貨將於4/9送達，請多加留意~ </asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="url6" runat="server" onmouseover="SwapImage();" ToolTip="images/news/20170108_year_end_banquet.jpg" NavigateUrl="https://www.facebook.com/pg/NIZING.ELECTRIC/photos/?tab=album&album_id=1328290773900592" Target="_blank"> 2017.01.08 日進尾牙圓滿落幕，恭喜各位大獎得主~ </asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="url3" runat="server" onmouseover="SwapImage();" ToolTip="images/news/20161117_inv_check_announce.jpg"> 2016.11.17 我司將於12/26~12/27進行年度盤點作業，最後出貨時間為12/23 17:00，並於12/28恢復正常作業。<br />我司將於2016/12/30(五)休假一日。 </asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="url4" runat="server" onmouseover="SwapImage();" ToolTip="images/news/20151130_InvCheckAnnounce.jpg"> 2015.11.30 我司將於12/25~12/27進行年度結帳相關作業，最後出貨時間為12/24 17:00，並於12/28恢復正常作業 </asp:HyperLink>
                    </li>
                    <li style="border: none; text-align: right;">
                        <asp:HyperLink ID="urlMore" runat="server" NavigateUrl="news.aspx">more news...</asp:HyperLink>
                    </li>
                </ul>
            </div>
        </div>
        <div id="link-default">
            <div class="title-no-border">
                <asp:Image ID="titleLink" runat="server" ImageUrl="~/images/title/title_links.jpg" />
            </div>
            <div class="default-content">
                <div class="button">
                    <asp:HyperLink ID="HyperLink16" runat="server" ImageUrl="~/images/button/stock_icon2.jpg" NavigateUrl="https://finance.sina.com.cn/futures/quotes/CAD.shtml" Target="_blank" BorderStyle="None" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink17" runat="server" ImageUrl="~/images/button/red_ul_icon2.jpg" NavigateUrl="http://taiwan.ul.com/" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink18" runat="server" ImageUrl="~/images/button/vde_icon2.jpg" NavigateUrl="http://www.vde.com/en/Pages/Homepage.aspx" Target="_blank" />
                </div>
            </div>
        </div>
        <div id="clientlogo-default">
            <div class="title-no-border">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/title/title_client.jpg" />
            </div>
            <div class="default-content">
                <div class="button">
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/images/logo/aidc.jpg" NavigateUrl="http://www.aidc.com.tw/tw/index.asp" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/images/logo/cpc.jpg" NavigateUrl="http://new.cpc.com.tw/Home/" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/images/logo/csc.jpg" NavigateUrl="http://www.csc.com.tw/" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/images/logo/delta.jpg" NavigateUrl="http://www.deltaww.com/default.aspx?hl=zh-TW" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="~/images/logo/fpc.jpg" NavigateUrl="http://www.fpc.com.tw/fpcw/" Target="_blank" />
                </div>
            </div>
            <div class="default-content">
                <div class="button">
                    <asp:HyperLink ID="HyperLink6" runat="server" ImageUrl="~/images/logo/huachuang.jpg" NavigateUrl="http://www.haitec.com.tw/tc/" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink7" runat="server" ImageUrl="~/images/logo/ITRI.jpg" NavigateUrl="https://www.itri.org.tw/" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink8" runat="server" ImageUrl="~/images/logo/nypc.jpg" NavigateUrl="http://www.npc.com.tw/index.htm" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink9" runat="server" ImageUrl="~/images/logo/osram.jpg" NavigateUrl="http://www.osram.tw/osram_tw/" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink10" runat="server" ImageUrl="~/images/logo/stsc.jpg" NavigateUrl="http://www.taiwansemi.com/zh-tw" Target="_blank" />
                </div>
            </div>
            <div class="default-content">
                <div class="button">
                    <asp:HyperLink ID="HyperLink11" runat="server" ImageUrl="~/images/logo/tatung.jpg" NavigateUrl="http://www.tatung.com.tw/b5/index.asp" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink12" runat="server" ImageUrl="~/images/logo/teco.jpg" NavigateUrl="http://www.teco.com.tw/" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink13" runat="server" ImageUrl="~/images/logo/ti.jpg" NavigateUrl="http://www.thermoway.com.tw/zh/home.php" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink14" runat="server" ImageUrl="~/images/logo/tsmc.jpg" NavigateUrl="http://www.tsmc.com.tw/chinese/default.htm" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink15" runat="server" ImageUrl="~/images/logo/walsin.jpg" NavigateUrl="http://www.walsin.com.tw/walsin/home.do" Target="_blank" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

