<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Child_user.master" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="javascript_section" Runat="Server">
    <style>
        .horizontal-wrapper{
            display:inline-block;
            vertical-align:top;
        }
        .title{
            height:40px;
            background-color:#00c400;
            margin-bottom:10px;
        }
        .title img{
            height:20px;
            margin-top:10px;
            margin-left:10px;
        }
        .side-note{
            margin-bottom:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_title" Runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="top_menu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="page_content" Runat="Server">
    <div id="Main_Page">
        <div class="horizontal-wrapper" style="width:69%;margin-right:5%;">
            <div class="title">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/hr360/image/banner/news.png" />
            </div>
            <div class="announcement">
                2016.11.15 <br />
                公告:<br />
                105/12/25(日)行憲紀念日適逢週日，我司將於12/30(五)補假一日。
            </div>
            <div class="announcement">
                2016.04.28 <br />
                公告:<br />
                <br />
                自2016/01/01起，我司每月業績目標為: $18,500,000<br />
                <br />
                團體達成獎金由原先的<br /> 
                $500/ $500/ $1500 更改為  <br />
                $700/ $700/ $2100<br />
                <br />
                生效日期:  2016/06/01<br />
                <br />
                --管理部
            </div>
            <div class="announcement">
                2016.04.27 51<br />
                勞動節獎金於4/28號發放，錯過的人請至人事部門領取

            </div>
            <div class="announcement">
                2016.02.26<br />於 2016/01/01 起，我司改為周周休，故今年不調薪
            </div>
            <div>
                <%--<asp:Image ID="Image3" runat="server" ImageUrl="~/hr360/image/image/2016.jpg" />--%>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/hr360/image/image/2016.jpg" Target="_blank"><asp:Image ID="Image3" runat="server" ImageUrl="~/hr360/image/image/2016.jpg" Width="200px" /></asp:HyperLink>
            </div>
        </div>

        <div class="horizontal-wrapper" style="width:25%;">
            <div class="title">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/hr360/image/banner/reminder.png" />
            </div>
            <div class="side-note">
                <asp:Label ID="lblName" runat="server"></asp:Label>
                您尚有:
            </div>
            <div class="side-note">
                特休
                <div>
                    <asp:Label ID="lblFirstPartDayOff" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblSecondPartDayOff" runat="server" Text="Label"></asp:Label>小時
                </div>
            </div>
            <div class="side-note">
                補休
                <div>
                    <asp:Label ID="lblMakeupDayOff" runat="server"></asp:Label>小時
                </div>                
            </div>
            <div id="salaryAdjNotification" runat="server" visible="false">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/hr360/user_report/salary_change_notification.aspx">您有調薪通知!</asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>

