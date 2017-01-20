<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="navigation.aspx.cs" Inherits="navigation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>日進電線-網站導覽</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    網站導覽
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="navigation">
        <div class="inner-content">
            <div class="content-row">
                <div class="content-column">
                    <div class="header">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/company.aspx">日進電線</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/company-intro.aspx">公司簡介</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/company-culture.aspx.cs">核心文化</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink4" runat="server">歷史紀錄</asp:HyperLink>                        
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink5" runat="server">設備技術</asp:HyperLink>
                    </div>
                </div>
                <div class="content-column">
                    <div class="header">
                        <asp:HyperLink ID="HyperLink6" runat="server">產品資訊</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink7" runat="server">PVC</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink8" runat="server">矽膠編織耐熱線</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink9" runat="server">高溫線</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink10" runat="server">矽膠耐熱線系列</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink11" runat="server">鐵氟龍線</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink12" runat="server">交連照射線</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink13" runat="server">套管</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink14" runat="server">補償導線</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink15" runat="server">發熱線</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink16" runat="server">汽車花線</asp:HyperLink>
                    </div>
                    <div class="sub">
                        <asp:HyperLink ID="HyperLink17" runat="server">日規</asp:HyperLink>
                    </div>
                    <div class="sub">
                        <asp:HyperLink ID="HyperLink18" runat="server">美規</asp:HyperLink>
                    </div>
                    <div class="sub">
                        <asp:HyperLink ID="HyperLink19" runat="server">歐規</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink20" runat="server">特殊訂製線材</asp:HyperLink>
                    </div>
                </div>
                <div class="content-column">
                    <div class="header">
                        <asp:HyperLink ID="HyperLink21" runat="server">應用產業</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink23" runat="server">車用元件</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink24" runat="server">雲端系統</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink25" runat="server">機器手臂</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink26" runat="server">加熱系統</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink27" runat="server">醫療科技</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink28" runat="server">LED</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink29" runat="server">溫控系統</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink30" runat="server">建築材料</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink31" runat="server">太陽能</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink32" runat="server">鋼鐵工業</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink33" runat="server">其他應用</asp:HyperLink>
                    </div>
                </div>
                <div class="content-column">
                    <div class="header">
                        <asp:HyperLink ID="HyperLink22" runat="server">材料特性</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink34" runat="server">塑料特性</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink35" runat="server">矽膠特性</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink36" runat="server">鐵氟龍特性</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink37" runat="server">纏繞編織材料特性</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink38" runat="server">導體特性</asp:HyperLink>
                    </div>
                </div>
                <div class="content-column">
                    <div class="header">
                        <asp:HyperLink ID="HyperLink39" runat="server">合金導體</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink40" runat="server">純銅類</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink41" runat="server">銀銅合金類</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink42" runat="server">錫銅合金類</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink43" runat="server">鎳銅合金類</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink44" runat="server">純銀及銀合金</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink45" runat="server">銅包鋼類</asp:HyperLink>
                    </div>
                </div>
                <div class="content-column">
                    <div class="header">
                        <asp:HyperLink ID="HyperLink46" runat="server">安規認證</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink47" runat="server">規格認證</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink48" runat="server">管理認證</asp:HyperLink>
                    </div>
                    <div class="parent">
                        <asp:HyperLink ID="HyperLink49" runat="server">綠色認證</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

