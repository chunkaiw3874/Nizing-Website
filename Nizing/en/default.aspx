<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/index.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Nizing Electric Wire & Cable</title>
</asp:Content>
<asp:Content ID="Java" ContentPlaceHolderID="JavaScriptCode" runat="server">
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main-content">
        <div class="product">
            <div class="title-no-border">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/en/images/title/title_product.jpg" />
            </div>
            <div class="main-page-menu-product">
                <div class="button">
                    <asp:HyperLink ID="HyperLink19" runat="server" ImageUrl="~/en/images/product/pro_01.jpg" NavigateUrl="pvc-series.aspx" alt="PVC Series" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink20" runat="server" ImageUrl="~/en/images/product/pro_02.jpg" NavigateUrl="silicone-fiberglass-series.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink21" runat="server" ImageUrl="~/en/images/product/pro_03.jpg" NavigateUrl="high-temperature-resistance-series.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink22" runat="server" ImageUrl="~/en/images/product/pro_04.jpg" NavigateUrl="silicone-series.aspx" />
                </div>
            </div>
            <div class="main-page-menu-product">
                <div class="button">                                
                    <asp:HyperLink ID="HyperLink23" runat="server" ImageUrl="~/en/images/product/pro_05.jpg" NavigateUrl="teflon-series.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink24" runat="server" ImageUrl="~/en/images/product/pro_06.jpg" NavigateUrl="xlpe-series.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink25" runat="server" ImageUrl="~/en/images/product/pro_07.jpg" NavigateUrl="sleeve-and-tube-series.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink26" runat="server" ImageUrl="~/en/images/product/pro_08.jpg" NavigateUrl="thermocouple-series.aspx" />
                </div>
            </div>
            <div class="main-page-menu-product">                                
                <div class="button">
                    <asp:HyperLink ID="HyperLink27" runat="server" ImageUrl="~/en/images/product/pro_09.jpg" NavigateUrl="heating-wire-series.aspx" />
                </div>
                <div class="button">                                
                    <asp:HyperLink ID="HyperLink28" runat="server" ImageUrl="~/en/images/product/pro_10.jpg" NavigateUrl="special-cable.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink29" runat="server" ImageUrl="~/en/images/product/pro_11.jpg" NavigateUrl="automotive-wire-series.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink41" runat="server" ImageUrl="~/en/images/product/pro_12.jpg" NavigateUrl="military-grade-series.aspx" />
                </div>
            </div>
        </div>
        <div class="product">
            <div class="title-no-border">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/en/images/title/title_application.jpg" />
            </div>
            <div class="main-page-menu-product">
                <div class="button">
                    <asp:HyperLink ID="HyperLink30" runat="server" ImageUrl="~/en/images/service/s1.jpg" NavigateUrl="car.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink31" runat="server" ImageUrl="~/en/images/service/s2.jpg" NavigateUrl="cloud.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink32" runat="server" ImageUrl="~/en/images/service/s3.jpg" NavigateUrl="heating.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink33" runat="server" ImageUrl="~/en/images/service/s4.jpg" NavigateUrl="medical.aspx" />
                </div>
            </div>
            <div class="main-page-menu-product">
                <div class="button">
                    <asp:HyperLink ID="HyperLink34" runat="server" ImageUrl="~/en/images/service/s5.jpg" NavigateUrl="led.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink35" runat="server" ImageUrl="~/en/images/service/s6.jpg" NavigateUrl="temperature-control.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink36" runat="server" ImageUrl="~/en/images/service/s7.jpg" NavigateUrl="construction.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink37" runat="server" ImageUrl="~/en/images/service/s8.jpg" NavigateUrl="solar.aspx" />
                </div>
            </div>
            <div class="main-page-menu-product">
                <div class="button">
                    <asp:HyperLink ID="HyperLink38" runat="server" ImageUrl="~/en/images/service/s9.jpg" NavigateUrl="steel.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink40" runat="server" ImageUrl="~/en/images/service/s10.jpg" NavigateUrl="roboarm.aspx" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink39" runat="server" ImageUrl="~/en/images/service/misc-app.jpg" NavigateUrl="misc-app.aspx" />  
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLinkSvcLast" runat="server" ImageUrl="~/en/images/button/customize_icon-215x123.jpg" NavigateUrl="customize_page.aspx" />
                </div>
            </div>
        </div>
        <div id="news-default">
            <div class="title-no-border">
                <asp:Image ID="titleNews" runat="server" ImageUrl="~/en/images/title/title_news.jpg" />
            </div>
            <div class="img">
                <asp:Image ID="imgNews" runat="server" />
            </div>
            <div class="default-content">
                <ul>
                    <%-- 最上面一排ID必須為url1，圖片才會變成預設顯示 --%>      
                    <li>
                        <asp:HyperLink ID="HyperLink42" runat="server" onmouseover="SwapImage();" ToolTip="images/news/20170108_year_end_banquet.jpg"> 2018.03.28 In accordance with the delivery company, no delivery will be made during the long weekend between 4/4~4/8, goods sent out on 4/3 will arrive no earlier than 4/9.</asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="url1" runat="server" onmouseover="SwapImage();" ToolTip="images/news/20170108_year_end_banquet.jpg" NavigateUrl="https://www.facebook.com/pg/NIZING.ELECTRIC/photos/?tab=album&album_id=1328290773900592" Target="_blank"> 2017.01.08 Great fun at Nizing's Year-End Banquet, congratulations to all the prize winners! </asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="url3" runat="server" onmouseover="SwapImage();" ToolTip="images/news/20161117_inv_check_announce.jpg">2016.11.17 We will be conducting End-Of-Year Inventory Check between 12/26 and 12/27, no goods will be distributed during those date. Operation will be back to normal on 12/28.<br /> Office is closed on 12/30. </asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="url4" runat="server" onmouseover="SwapImage();" ToolTip="images/news/20151130_InvCheckAnnounce.jpg"> 2015.11.30 We will be conducting End-Of-Year Inventory Check between 12/25 and 12/27, no goods will be distributed during those date. Operation will be back to normal on 12/28. </asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="url5" runat="server" onmouseover="SwapImage();" ToolTip="images/news/20150827中元普渡.jpg"> 2015.08.27 Spirit Festival~ May the spirits watch over us~ </asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="url2" runat="server" onmouseover="SwapImage();" ToolTip="images/news/20150513_optical_fiber_extrusion.jpg" NavigateUrl="https://www.facebook.com/367173643345648/videos/vb.367173643345648/902348333161507/?type=2&theater" Target="_blank"> 2015.05.13 Optical Fiber 100 strand extrusion! </asp:HyperLink>
                    </li>
                    <li style="border:none; text-align:right;">
                        <asp:HyperLink ID="urlMore" runat="server" NavigateUrl="news.aspx">more news...</asp:HyperLink>
                    </li>
                </ul>
            </div>
        </div>
        <div id="link-default">
            <div class="title-no-border">
                <asp:Image ID="titleLink" runat="server" ImageUrl="~/en/images/title/title_links.jpg" />
            </div>
            <div class="default-content">
                <div class="button">
                    <asp:HyperLink ID="HyperLink16" runat="server" ImageUrl="~/en/images/button/stock_icon2.jpg" NavigateUrl="http://www.lme.com/metals/non-ferrous/copper/" Target="_blank" BorderStyle="None" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink17" runat="server" ImageUrl="~/en/images/button/red_ul_icon2.jpg" NavigateUrl="http://ul.com/" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink18" runat="server" ImageUrl="~/en/images/button/vde_icon2.jpg" NavigateUrl="http://www.vde.com/en/Pages/Homepage.aspx" Target="_blank" />
                </div>
            </div>
        </div>
        <div id="clientlogo-default">
            <div class="title-no-border">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/en/images/title/title_client.jpg" />
            </div>
            <div class="default-content">
                <div class="button">
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/en/images/logo/aidc.jpg" NavigateUrl="http://www.aidc.com.tw/tw/index.asp" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/en/images/logo/cpc.jpg" NavigateUrl="http://new.cpc.com.tw/Home/" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/en/images/logo/csc.jpg" NavigateUrl="http://www.csc.com.tw/" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/en/images/logo/delta.jpg" NavigateUrl="http://www.deltaww.com/default.aspx?hl=zh-TW" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="~/en/images/logo/fpc.jpg" NavigateUrl="http://www.fpc.com.tw/fpcw/" Target="_blank" />
                </div>
            </div>
            <div class="default-content">
                <div class="button">
                    <asp:HyperLink ID="HyperLink6" runat="server" ImageUrl="~/en/images/logo/huachuang.jpg" NavigateUrl="http://www.haitec.com.tw/tc/" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink7" runat="server" ImageUrl="~/en/images/logo/ITRI.jpg" NavigateUrl="https://www.itri.org.tw/" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink8" runat="server" ImageUrl="~/en/images/logo/nypc.jpg" NavigateUrl="http://www.npc.com.tw/index.htm" Target="_blank" />                    
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink9" runat="server" ImageUrl="~/en/images/logo/osram.jpg" NavigateUrl="http://www.osram.tw/osram_tw/" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink10" runat="server" ImageUrl="~/en/images/logo/stsc.jpg" NavigateUrl="http://www.taiwansemi.com/zh-tw" Target="_blank" />
                </div>
            </div>
            <div class="default-content">
                <div class="button">
                    <asp:HyperLink ID="HyperLink11" runat="server" ImageUrl="~/en/images/logo/tatung.jpg" NavigateUrl="http://www.tatung.com.tw/b5/index.asp" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink12" runat="server" ImageUrl="~/en/images/logo/teco.jpg" NavigateUrl="http://www.teco.com.tw/" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink13" runat="server" ImageUrl="~/en/images/logo/ti.jpg" NavigateUrl="http://www.thermoway.com.tw/zh/home.php" Target="_blank" />         
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink14" runat="server" ImageUrl="~/en/images/logo/tsmc.jpg" NavigateUrl="http://www.tsmc.com.tw/chinese/default.htm" Target="_blank" />
                </div>
                <div class="button">
                    <asp:HyperLink ID="HyperLink15" runat="server" ImageUrl="~/en/images/logo/walsin.jpg" NavigateUrl="http://www.walsin.com.tw/walsin/home.do" Target="_blank" />
                </div>
            </div>
        </div>
    </div>    
</asp:Content>

