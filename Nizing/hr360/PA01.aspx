<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Child.master" AutoEventWireup="true" CodeFile="PA01.aspx.cs" Inherits="hr360_PA01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="javascript_section" Runat="Server">
    <style type="text/css">
        .content{
            width:100%;
        }
        .title{
            width:100%;
            margin-bottom:10px;
            color:#5e9cff;
        }
        .cell-with-padding tr td{
            padding-top:5px;
            padding-bottom:5px;
        }
        .white-gridline{
            width:100%;
        }
        .white-gridline tr th{
            border:solid 1px #ffffff;
            padding:5px;
        }
        .white-gridline tr td{
            border:solid 1px #ffffff;
            text-align:center;
            padding:5px;
        }
        .image-container{
            width:100%;
            text-align:center;
            vertical-align:middle;
        }
        .image-container img{
            max-height:100%;
            max-width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="top_menu" Runat="Server">
    <div id="top-menu">
        <div class="first">
            <asp:ImageButton ID="toplink_add" runat="server" ImageUrl="~/hr360/image/icon/top_menu/add-1.png" OnClick="toplink_add_Click" onmouseover="this.src='image/icon/top_menu/add-2.png'" onmouseout="this.src='image/icon/top_menu/add-1.png'" />
            <asp:ImageButton ID="toplink_search" runat="server" ImageUrl="~/hr360/image/icon/top_menu/search-1.png" PostBackUrl="#search_window" OnClick="toplink_search_Click" onmouseover="this.src='image/icon/top_menu/search-2.png'" onmouseout="this.src='image/icon/top_menu/search-1.png'" />
            <asp:ImageButton ID="toplink_edit" runat="server" ImageUrl="~/hr360/image/icon/top_menu/edit-1.png" OnClick="toplink_edit_Click" onmouseover="this.src='image/icon/top_menu/edit-2.png'" onmouseout="this.src='image/icon/top_menu/edit-1.png'" />
            <asp:ImageButton ID="toplink_print" runat="server" ImageUrl="~/hr360/image/icon/top_menu/print-1.png" OnClientClick="javascript:window.print();" OnClick="toplink_print_Click" onmouseover="this.src='image/icon/top_menu/print-2.png'" onmouseout="this.src='image/icon/top_menu/print-1.png'" />
        </div>
        <div class="second">
            <asp:ImageButton ID="toplink_first_record" runat="server" ImageUrl="~/hr360/image/icon/top_menu/first_record-1.png" OnClick="toplink_first_record_Click" onmouseover="this.src='image/icon/top_menu/first_record-2.png'" onmouseout="this.src='image/icon/top_menu/first_record-1.png'" />
            <asp:ImageButton ID="toplink_previous" runat="server" ImageUrl="~/hr360/image/icon/top_menu/previous-1.png" OnClick="toplink_previous_Click" onmouseover="this.src='image/icon/top_menu/previous-2.png'" onmouseout="this.src='image/icon/top_menu/previous-1.png'" />
            <asp:ImageButton ID="toplink_next" runat="server" ImageUrl="~/hr360/image/icon/top_menu/next-1.png" OnClick="toplink_next_Click" onmouseover="this.src='image/icon/top_menu/next-2.png'" onmouseout="this.src='image/icon/top_menu/next-1.png'" />
            <asp:ImageButton ID="toplink_last_record" runat="server" ImageUrl="~/hr360/image/icon/top_menu/last_record-1.png" OnClick="toplink_last_record_Click" onmouseover="this.src='image/icon/top_menu/last_record-2.png'" onmouseout="this.src='image/icon/top_menu/last_record-1.png'" />
        </div>
        <div class ="third">
            <asp:ImageButton ID="toplink_save" runat="server" ImageUrl="~/hr360/image/icon/top_menu/save-1.png" OnClick="toplink_save_Click" onmouseover="this.src='image/icon/top_menu/save-2.png'" onmouseout="this.src='image/icon/top_menu/save-1.png'" />
            <asp:ImageButton ID="toplink_cancel" runat="server" ImageUrl="~/hr360/image/icon/top_menu/cancel-1.png" OnClick="toplink_cancel_Click" onmouseover="this.src='image/icon/top_menu/cancel-2.png'" onmouseout="this.src='image/icon/top_menu/cancel-1.png'" />
            <asp:ImageButton ID="toplink_delete" runat="server" ImageUrl="~/hr360/image/icon/top_menu/delete-1.png" OnClick="toplink_delete_Click" OnClientClick ="return confirm('確定要刪除嗎?');" onmouseover="this.src='image/icon/top_menu/delete-2.png'" onmouseout="this.src='image/icon/top_menu/delete-1.png'" />
            <asp:ImageButton ID="toplink_refresh" runat="server" ImageUrl="~/hr360/image/icon/top_menu/refresh-1.png" PostBackUrl="BI01.aspx" OnClick="toplink_refresh_Click" onmouseover="this.src='image/icon/top_menu/refresh-2.png'" onmouseout="this.src='image/icon/top_menu/refresh-1.png'" />
            <asp:ImageButton ID="toplink_copy" runat="server" ImageUrl="~/hr360/image/icon/top_menu/copy-1.png" OnClick="toplink_copy_Click" onmouseover="this.src='image/icon/top_menu/copy-2.png'" onmouseout="this.src='image/icon/top_menu/copy-1.png'" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="page_content" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <div id="PA01">
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="MyTabStyle">
                    <ajaxToolkit:TabPanel runat="server" HeaderText="薪資結構" ID="TabPanel1">
                        <ContentTemplate>            
                            <div class="content" id="firstTab" runat="server" style="width:985px;">
                                <div style="width:100%;margin-bottom:10px;border-bottom:solid 2px #5e9cff;">
                                    <div style="width:100%;text-align:center;">
                                        <h2>薪資調整通知單</h2>
                                    </div>
                                    <div style="width:31%;display:inline-block;margin-left:2%;">
                                        異動年月: 
                                        <asp:Label ID="lblY" runat="server"></asp:Label>
                                        /
                                        <asp:Label ID="lblM" runat="server"></asp:Label>
                                    </div>
                                    <div style="width:34%;display:inline-block;text-align:center;">
                                        Notification of Salary Modification
                                    </div>
                                </div>
                                <div style="width:98%;padding:2%;">
                                    <div style="width:100%;border-bottom:solid 1px #5e9cff;">
                                        <div class="title">
                                            <h2>I. 基本資料</h2>
                                        </div>
                                        <div style="width:100%;">
                                            <div style="width:49%;display:inline-block;vertical-align:top;">
                                                <table class="cell-with-padding">
                                                    <tr>
                                                        <td style="font-weight:bold;">
                                                            員工姓名:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblMF001" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblMV002" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight:bold;">
                                                            年齡:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAge" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight:bold;">
                                                            職務名稱:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblMJ003" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight:bold;">
                                                            部門別:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblME002" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight:bold;">
                                                            去年年度:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLastYear" runat="server"></asp:Label>
                                                        </td>
                                                        <td style="font-weight:bold;">
                                                            去年考績:
                                                        </td>
                                                        <td>
                                                            <%--<asp:Label ID="lblGrade" runat="server"></asp:Label>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div style="width:50%;display:inline-block;padding-bottom:5px;vertical-align:top;">
                                                <table class="cell-with-padding">
                                                    <tr>
                                                        <td style="font-weight:bold;">
                                                            到職日期:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblMV021" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight:bold;">
                                                            年資:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblMV031" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight:bold;">
                                                            職等:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblMV005" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="margin-top:5px;margin-bottom:10px;">
                                        *前年年度考績與現行年度考績之任一年度考績如低於C等，將無法列入調薪名單
                                    </div>
                                    <div style="width:100%">
                                        <div class="title">
                                            <h2>II. 薪資結構</h2>
                                        </div>
                                        <div style="width:50%;">
                                            <asp:GridView ID="grdStructure" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" CssClass="white-gridline" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="薪資項目">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMB002" runat="server" Text='<%#Eval("MB002") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="金額">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMF003" runat="server" Text='<%#Eval("MF003") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="最後異動備註">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblComment" runat="server" Text='<%#Eval("COMMENT") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <AlternatingRowStyle BackColor="#5e9cff" ForeColor="#000000"></AlternatingRowStyle>
                                                <EditRowStyle BackColor="#999999"></EditRowStyle>
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                                                <HeaderStyle BackColor="#5e9cff" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                                <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                                                <RowStyle BackColor="#ffffff" ForeColor="#000000"></RowStyle>
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                                <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                                                <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                                                <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                                                <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div style="width:100%">
                                        <div class="title">
                                            <h2>III. 簽核系統</h2>
                                        </div>
                                        <div style="border:solid 1px #5e9cff;width:100%;height:40px;">
                                            <div style="height:100%;">
                                            <div style="display:inline-block;border-right:solid 1px #5e9cff;width:24%;height:100%;vertical-align:top;">
                                                <div class="image-container">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/hr360/image/image/signature/doris-2.png" />
                                                </div>
                                            </div>
                                            <div style="display:inline-block;border-right:solid 1px #5e9cff;width:24%;height:100%;vertical-align:top;">
                                                <div class="image-container">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/hr360/image/image/signature/chrissy.png" />
                                                </div>
                                            </div>
                                            <div style="display:inline-block;border-right:solid 1px #5e9cff;width:24%;height:100%;vertical-align:top;">
                                                <div class="image-container">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/hr360/image/image/signature/kelven.png" />
                                                </div>
                                            </div>
                                            <div style="display:inline-block;width:24%;height:100%;vertical-align:top;">
                                                <div class="image-container">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/hr360/image/image/signature/president.png" />
                                                </div>
                                            </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>                
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="歷史異動">
                        <ContentTemplate>
                            <div class="search-result">
                                <asp:GridView ID="grdResult" runat="server" CellPadding="10" ForeColor="#333333" OnSelectedIndexChanged="grdResult_SelectedIndexChanged" CellSpacing="2" CssClass="grdResult" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="員工代號">
                                            <ItemTemplate>
                                                <asp:Label ID="lblParentEmpId" runat="server" Text='<%#Eval("TD001") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="員工姓名">
                                            <ItemTemplate>
                                                <asp:Label ID="lblParentEmpName" runat="server" Text='<%#Eval("MV002") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="異動年份">
                                            <ItemTemplate>
                                                <asp:Label ID="lblParentAdjYr" runat="server" Text='<%#Eval("Y") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="異動月份">
                                            <ItemTemplate>
                                                <asp:Label ID="lblParentAdjMn" runat="server" Text='<%#Eval("M") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                    <EditRowStyle BackColor="#999999"></EditRowStyle>
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                    <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                                    <SelectedRowStyle BackColor="#FF9933" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                    <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                                    <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                                    <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                                </asp:GridView>
                            </div>
                            <div class="search-result">
                                <asp:GridView ID="grdResultChild" runat="server" CellPadding="10" ForeColor="#333333" CellSpacing="2" CssClass="grdResult" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="異動項目">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChildAdjItem" runat="server" Text='<%#Eval("TD007") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="調整前金額">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChildAdjBefore" runat="server" Text='<%#Eval("TD004") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="調整後金額">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChildAdjAfter" runat="server" Text='<%#Eval("TD005") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="調整說明">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChildAdjReason" runat="server" Text='<%#Eval("TD006") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                    <EditRowStyle BackColor="#999999"></EditRowStyle>
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                    <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                                    <SelectedRowStyle BackColor="#FF9933" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                    <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                                    <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                                    <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>                
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="search_window" class="overlay">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
	            <div class="popup" style="width:210px;">
		            <h2>查詢</h2>
		            <a class="close" href="#">×</a>
		            <div class="content">
    			        <div class="search-condition">
                            <div style="display:inline-block;margin-right:20px;vertical-align:top;">
                                選擇員工<br />
                                <asp:DropDownList ID="ddlEmployeeId" runat="server" DataSourceID="SourceEmployeeId" DataTextField="MV002" DataValueField="MV001"></asp:DropDownList>                                
                                <asp:SqlDataSource runat="server" ID="SourceEmployeeId" ConnectionString='<%$ ConnectionStrings:NZConnectionString %>' SelectCommand="SELECT MV001, MV002
FROM CMSMV
WHERE MV022=N''"></asp:SqlDataSource>
                            </div>
                            <div style="display:inline-block;vertical-align:top;">
                                選擇異動日期<br />
                                起<asp:DropDownList ID="ddlStartYear" runat="server"></asp:DropDownList>
                                <asp:DropDownList ID="ddlStartMonth" runat="server">
                                    <asp:ListItem>01</asp:ListItem>
                                    <asp:ListItem>02</asp:ListItem>
                                    <asp:ListItem>03</asp:ListItem>
                                    <asp:ListItem>04</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>06</asp:ListItem>
                                    <asp:ListItem>07</asp:ListItem>
                                    <asp:ListItem>08</asp:ListItem>
                                    <asp:ListItem>09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList><br />
                                迄<asp:DropDownList ID="ddlEndYear" runat="server"></asp:DropDownList>
                                <asp:DropDownList ID="ddlEndMonth" runat="server">
                                    <asp:ListItem>01</asp:ListItem>
                                    <asp:ListItem>02</asp:ListItem>
                                    <asp:ListItem>03</asp:ListItem>
                                    <asp:ListItem>04</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>06</asp:ListItem>
                                    <asp:ListItem>07</asp:ListItem>
                                    <asp:ListItem>08</asp:ListItem>
                                    <asp:ListItem>09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                            </div>
    			        </div>
                        <div style="width:100%;text-align:right;margin-top:20px;">
                            <asp:Button ID="btnSearch_Search" runat="server" Text="查詢" OnClick="btnSearch_Search_Click" />
                        </div>
	    	        </div>
	            </div>            
            </ContentTemplate>            
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSearch_Search" />
            </Triggers>
        </asp:UpdatePanel>
    </div>    
</asp:Content>

