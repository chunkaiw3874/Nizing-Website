<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="company-capability.aspx.cs" Inherits="company_capability" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>日進電線-設備技術</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    設備技術
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <a href="company-intro.aspx">公司簡介</a> | <a href="company-culture.aspx">核心文化</a> | <a href="company-history.aspx">歷史紀錄</a> | <a href="company-capability.aspx" class="active">設備技術</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="company-capability">
        <div class="inner-content">
            <ajaxToolkit:TabContainer ID="capabilityDetail" runat="server" ActiveTabIndex="0" CssClass="CapabilityTab">
                <ajaxToolkit:TabPanel runat="server" HeaderText="製程能力" ID="TabPanel1">
                    <ContentTemplate>
                        <h4>單芯纜線</h4>
                        <p>線種包括電子線、機具用線、耐高溫線、耐高壓線、多層絕緣線、加熱線、...等</p>
                        <h4>多芯複合線纜</h4>
                        <p>線種包括防盜線、視聽用線、資料傳輸用線、醫療線、儀器用線、網路線、電話線、USB傳輸線、機器手臂用線、熱補償導線、各式UL線種、各式捲線、超軟線...等</p>
                        <h4>導體</h4>
                        <p>除一般裸銅、鍍錫、鍍鎳或鍍銀銅單線或絞線外，尚可提供銅包鋼、鍍銀銅包鋼、鍍鋅鋼線、鎘銅(鍍錫或鍍銀)、鎳烙合金、錫銅合金、銅鐵合金、銀線、金線、鍍金線...等各種特殊材料</p>
                        <h4>遮蔽層</h4>
                        <p>可提供各種型態之遮蔽設計，包括纏繞、編織鋁箔麥拉帶、麥拉帶、棉紙，e-PTFE...等</p>
                        <h4>絕緣及外被</h4>
                        <p>可供應用之材料廣泛，函括PVC、PP、PE、PU、HYTREL、TPEE、NYLON、PFA、FEP、ETFE、PVDF、TPE、TPR、TPV、TPO、SILICONE、XLPE、導電塑膠(PE，PVC)、低煙無鹵...等</p>
                        <h4>加強</h4>
                        <p>Kevlar, 尼龍線, 棉線, Nomex, Technora, 玻纖...</p>
                        <h4>客製化服務</h4>
                        <p>各類線種之客製化 OEM & ODM 服務，為您量身訂做符合您特殊需求之線材。</p>
                        <div class="img">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/company/company-capability1.jpg" />
                        </div>
                        <div class="img">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/company/company-capability2.jpg" />
                        </div>
                        <div class="img">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/company/company-capability3.jpg" />
                        </div>
                        <div class="img">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/images/company/company-capability4.jpg" />
                        </div>
                        <div class="img">
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/images/company/company-capability5.jpg" />
                        </div>
                        <div class="img">
                            <asp:Image ID="Image6" runat="server" ImageUrl="~/images/company/company-capability6.jpg" />
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" HeaderText="生產設備" ID="TabPanel2">
                    <ContentTemplate>
                        <div class="img">
                            <asp:Image ID="Image7" runat="server" ImageUrl="~/images/company/company-capability-machine1.jpg" />
                            動力放線架
                        </div>
                        <div class="img">
                            <asp:Image ID="Image8" runat="server" ImageUrl="~/images/company/company-capability-machine2.jpg" />
                            溫度控制箱
                        </div>
                        <div class="img" style="margin-right:0px;">
                            <asp:Image ID="Image9" runat="server" ImageUrl="~/images/company/company-capability-machine3.jpg" />
                            自動填料機
                        </div>
                        <div class="img">
                            <asp:Image ID="Image10" runat="server" ImageUrl="~/images/company/company-capability-machine4.jpg" />
                            押出機
                        </div>
                        <div class="img">
                            <asp:Image ID="Image11" runat="server" ImageUrl="~/images/company/company-capability-machine5.jpg" />
                            引取機
                        </div>
                        <div class="img" style="margin-right:0px;">
                            <asp:Image ID="Image12" runat="server" ImageUrl="~/images/company/company-capability-machine6.jpg" />
                            搖盤機
                        </div>
                        <div class="img">
                            <asp:Image ID="Image13" runat="server" ImageUrl="~/images/company/company-capability-machine7.jpg" />
                            編織機
                        </div>
                        <div class="img">
                            <asp:Image ID="Image14" runat="server" ImageUrl="~/images/company/company-capability-machine8.jpg" />
                            絞線機
                        </div>
                        <div class="img" style="margin-right:0px;">
                            <asp:Image ID="Image15" runat="server" ImageUrl="~/images/company/company-capability-machine9.jpg" />
                            數位噴字機
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" HeaderText="檢測儀器" ID="TabPanel3">
                    <ContentTemplate>
                        <div class="img">
                            <asp:Image ID="Image16" runat="server" ImageUrl="~/images/company/company-capability-test1.jpg" />
                            線材彎折試驗機
                        </div>
                        <div class="img">
                            <asp:Image ID="Image17" runat="server" ImageUrl="~/images/company/company-capability-test2.jpg" />
                            耐電壓絕緣測試機
                        </div>
                        <div class="img" style="margin-right:0px;">
                            <asp:Image ID="Image18" runat="server" ImageUrl="~/images/company/company-capability-test3.jpg" />
                            燃燒測試機
                        </div>
                        <div class="img">
                            <asp:Image ID="Image19" runat="server" ImageUrl="~/images/company/company-capability-test4.jpg" />
                            安規綜合測試機
                        </div>
                        <div class="img">
                            <asp:Image ID="Image20" runat="server" ImageUrl="~/images/company/company-capability-test5.jpg" />
                            萬用數位電表
                        </div>
                        <div class="img" style="margin-right:0px;">
                            <asp:Image ID="Image21" runat="server" ImageUrl="~/images/company/company-capability-test6.jpg" />
                            電器熱風烘箱
                        </div>
                        <div class="img">
                            <asp:Image ID="Image22" runat="server" ImageUrl="~/images/company/company-capability-test7.jpg" />
                            拉力測試機
                        </div>
                        <div class="img">
                            <asp:Image ID="Image23" runat="server" ImageUrl="~/images/company/company-capability-test8.jpg" />
                            穿透測試機
                        </div>
                        <div class="img" style="margin-right:0px;">
                            <asp:Image ID="Image24" runat="server" ImageUrl="~/images/company/company-capability-test9.jpg" />
                            雷射外徑測試儀
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>
    </div>
</asp:Content>

