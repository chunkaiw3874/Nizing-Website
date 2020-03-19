<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Child_user.master" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="javascript_section" Runat="Server">
    <script src="../Scripts/text.area.auto.adjust.js"></script>
    <style>
        .no-resize {
            resize: none;
        }
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
    <script type="text/javascript">
        $(function () {
            $('.autosize').autosize();
        });

    </script>
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
            <asp:UpdatePanel ID="upCompanyAnnouncement" runat="server">
                <ContentTemplate>
                    <div id="announcement_section">
                        <div id="announcement_pagination_control" style="margin-top:10px;">
                            <table style="width:100%;">
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="lbFirst" runat="server" style="text-decoration:none;"
                                            OnClick="lbFirst_Click">首頁</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lbPrevious" runat="server" style="text-decoration:none;"
                                            OnClick="lbPrevious_Click">前一頁</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:DataList ID="rptPaging" runat="server"
                                            OnItemCommand="rptPaging_ItemCommand" 
                                            OnItemDataBound="rptPaging_ItemDataBound" 
                                            RepeatDirection="Horizontal">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbPaging" runat="server" 
                                                    CommandArgument='<%# Eval("PageIndex") %>' 
                                                    CommandName="newPage"
                                                    Text='<%# Eval("PageText") %>' ></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lbNext" runat="server" style="text-decoration:none;"
                                            OnClick="lbNext_Click">下一頁</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lbLast" runat="server" style="text-decoration:none;"
                                            OnClick="lbLast_Click">末頁</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPage" runat="server" Text="[placeholder]"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="announcement_body">
                            <asp:Repeater ID="rptCompanyAnnouncement" runat="server" >
                                    <HeaderTemplate>
                                        <table id="tbCompanyAnnouncement" style="width:100%;border-collapse:collapse;">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td style="border-bottom:dotted 1px gray;text-wrap:normal;word-wrap:break-word;">
                                                <%--<object data="image/image/new.svg" width="50" height="50"></object>--%>
                                                <div id="newIcon" runat="server" style="display:inline-block">
                                                    <svg version="1.1" id="layer1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px"
	                                                 width="50px" height="50px" viewBox="103.254 18.52 106.941 107.02"
	                                                 enable-background="new 103.254 18.52 106.941 107.02" xml:space="preserve">
                                                        <path fill="#FF0000" d="M137.453,86.375V70.087c0-2.989-0.803-4.87-2.865-6.709c-1.848-1.649-4.33-2.486-7.375-2.486
	                                                    c-1.533,0-7.396-0.063-7.455-0.065h-6.823v25.546h3.682V64.509h3.111c0.362,0.004,5.951,0.065,7.485,0.065
	                                                    c2.144,0,3.754,0.507,4.924,1.551c1.13,1.008,1.635,1.819,1.635,3.962v16.288H137.453L137.453,86.375z M162.548,64.319
	                                                    c-1.095-1.44-2.485-2.608-4.122-3.467c-1.668-0.884-3.569-1.332-5.654-1.332c-1.983,0-3.782,0.383-5.346,1.138
	                                                    c-1.565,0.74-2.923,1.769-4.029,3.051c-1.085,1.244-1.937,2.724-2.531,4.4c-0.577,1.629-0.869,3.379-0.869,5.201
	                                                    c0,1.952,0.274,3.768,0.812,5.393c0.547,1.68,1.396,3.167,2.522,4.422c1.12,1.248,2.506,2.23,4.122,2.92
	                                                    c1.605,0.682,3.441,1.027,5.458,1.027c1.382,0,2.744-0.195,4.048-0.582l0.012-0.004c1.339-0.407,2.547-1.003,3.592-1.771
	                                                    c1.089-0.788,2.018-1.762,2.76-2.894c0.783-1.169,1.33-2.487,1.629-3.918l-3.463-0.721c-0.205,0.984-0.578,1.887-1.107,2.677
	                                                    l-0.011,0.017c-0.508,0.773-1.143,1.439-1.886,1.978l-0.01,0.007c-0.723,0.531-1.572,0.948-2.528,1.24
	                                                    c-0.975,0.289-1.995,0.435-3.034,0.435c-1.538,0-2.909-0.251-4.073-0.745c-1.151-0.491-2.091-1.154-2.875-2.029
	                                                    c-0.795-0.885-1.398-1.947-1.794-3.162c-0.131-0.397-0.243-0.812-0.333-1.24h1.173v0.02h20.084l0.183-1.563
	                                                    c0.225-1.93,0.096-3.821-0.381-5.615C164.421,67.39,163.632,65.749,162.548,64.319L162.548,64.319z M148.546,72.843v-0.02h-5.003
	                                                    c0.044-1.251,0.26-2.412,0.657-3.532c0.445-1.254,1.072-2.35,1.869-3.264c0.789-0.915,1.755-1.646,2.873-2.173l0.016-0.008
	                                                    c1.097-0.531,2.344-0.789,3.813-0.789c1.522,0,2.83,0.3,4.004,0.923c1.184,0.621,2.178,1.455,2.956,2.477
	                                                    c0.8,1.057,1.386,2.281,1.745,3.647c0.234,0.884,0.357,1.8,0.369,2.739H148.546L148.546,72.843z M180.321,86.429l2.968-13.512
	                                                    l3.002,13.512h8.246l6.344-25.108l-3.569-0.902l-5.642,22.328h-2.504l-4.402-19.116h-2.973l-4.353,19.116h-2.622l-5.563-22.322
	                                                    l-3.572,0.89l6.258,25.114H180.321z M118.921,34.183c-10.103,10.104-15.667,23.534-15.667,37.816
	                                                    c0,14.288,5.564,27.722,15.667,37.826c10.383,10.392,23.998,15.713,37.713,15.714c10.914,0.002,21.889-3.366,31.363-10.227
	                                                    l1.186-0.855l17.959,6.021l-0.963-3.364c-0.514-1.793-0.998-12.441-0.998-14.001h-3.683c0,1.021,0.218,9.058,0.563,11.78
	                                                    l-13.501-4.527l-2.72,1.965c-19.91,14.416-46.958,12.268-64.316-5.107c-9.408-9.409-14.589-21.918-14.589-35.224
	                                                    c0-13.299,5.181-25.805,14.589-35.213c9.405-9.406,21.904-14.585,35.194-14.585c13.299,0,25.805,5.18,35.215,14.586
	                                                    c14.248,14.248,18.483,35.513,10.791,54.176l3.404,1.402c8.26-20.042,3.71-42.88-11.592-58.182
	                                                    C184.431,24.082,171,18.52,156.719,18.52C142.446,18.52,129.022,24.082,118.921,34.183L118.921,34.183z"/>
                                                    </svg>
                                                </div>
                                                <span><%#Eval("CREATE_TIME") %></span><br /><br />
                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="no-resize autosize" Width="100%" BorderStyle="None" ReadOnly="true" TextMode="MultiLine" Text='<%#Eval("BODY") %>' ></asp:TextBox><br /><br />
                                                <asp:HiddenField ID="hdnLastEdit" runat="server" Value='<%#Eval("LAST_EDIT_TIME") %>' />
                                                <asp:HiddenField ID="hdnAnnouncementId" runat="server" Value='<%#Eval("ID") %>' />
                                                <%--<span style="white-space:pre"><%#Eval("BODY") %></span><br /><br />--%>
                                                <%--<span style="font-size:6px; font-style:italic; color:gray">最後編輯: <%#Eval("LAST_EDITOR") %> <%#Eval("LAST_EDIT_TIME") %></span>--%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>   
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>         
                            </asp:Repeater>
                        </div>
                        
                    </div>             
                           
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--<div class="announcement">
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
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/hr360/image/image/2016.jpg" Target="_blank"><asp:Image ID="Image3" runat="server" ImageUrl="~/hr360/image/image/2016.jpg" Width="200px" /></asp:HyperLink>
            </div>--%>
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
                    <asp:Label ID="lblDayOffMemo" runat="server" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                </div>
                <%--Uncomment for new way--%>
                <div>
                    <asp:Label ID="lblSecondPartDayOff" runat="server" Text="Label"></asp:Label>
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

