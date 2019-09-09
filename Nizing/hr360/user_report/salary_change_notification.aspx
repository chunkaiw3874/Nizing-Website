<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Child_user.master" AutoEventWireup="true" CodeFile="salary_change_notification.aspx.cs" Inherits="hr360_user_report_salary_change_notification" %>

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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="page_content" Runat="Server">
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
            <div style="margin-top:5px;margin-bottom:50px;">
                *前年年度考績與現行年度考績之任一年度考績如低於C等，將無法列入調薪名單
            </div>
            <div style="width:100%;margin-bottom:50px;">
                <div class="title">
                    <h2>II. 薪資異動</h2>
                </div>
                <div style="width:50%;">
                    <asp:GridView ID="grdStructure" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" CssClass="white-gridline" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="薪資項目">
                                <ItemTemplate>
                                    <asp:Label ID="lblMB002" runat="server" Text='<%#Eval("MB002") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="調整前金額">
                                <ItemTemplate>
                                    <asp:Label ID="lblMF003" runat="server" Text='<%#Eval("TD004") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="調整後金額">
                                <ItemTemplate>
                                    <asp:Label ID="lblTD005" runat="server" Text='<%#Eval("TD005") %>'></asp:Label>
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
                            <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/hr360/image/image/signature/abbie.png" />--%>
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
</asp:Content>

