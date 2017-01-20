<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="company-culture.aspx.cs" Inherits="company_culture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>日進電線-核心文化</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    核心文化
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <a href="company-intro.aspx">公司簡介</a> | <a href="company-culture.aspx" class="active">核心文化</a> | <a href="company-history.aspx">歷史紀錄</a> | <a href="company-capability.aspx">設備技術</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="company-culture">
        <div class="inner-content">
            <div class="content-row">
                <div class="text">
                    日進電線除了人的不懈努力外，更重要的歸功于各位先進的指導與愛護。貫徹整體顧客意識，珍惜每一次服務的機會。全體日進電線人員處世以&quot;誠&quot;、&quot;信&quot;為原則；&quot;誠&quot;乃是出自於內心的真誠，&quot;信&quot;則是言而有信、言出必行。&quot;積極、創新、追求卓越&quot;是日進電線的經營理念。我們深信，唯有堅定的企業信念、熱忱投入的工作態度、以及高效率和實事求是的負責精神，才能贏得客戶的支持與信賴。
                    <p>日進就是一個可以帶給大家幸福的地方。以日進為本，照顧大家。透過日進，大家互相協助，互相理解，同心協力幫助客戶解決問題。這就是我們的宗旨。</p>
                </div>
                <div class="img">
                    <div style="float:right;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/company/comany-culture3.jpg" />
                    </div>
                    <div>
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/company/comany-culture1.jpg" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

