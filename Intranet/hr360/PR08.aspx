<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/HR360_Child.master" AutoEventWireup="true" CodeFile="PR08.aspx.cs" Inherits="hr360_PR08" %>

<asp:Content ID="Content1" ContentPlaceHolderID="javascript_section" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_title" Runat="Server">
    <div id="page-title">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/hr360/image/icon/left_menu/PR08-1.png" />
    </div>
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
            <asp:ImageButton ID="toplink_refresh" runat="server" ImageUrl="~/hr360/image/icon/top_menu/refresh-1.png" PostBackUrl="PR08.aspx" OnClick="toplink_refresh_Click" onmouseover="this.src='image/icon/top_menu/refresh-2.png'" onmouseout="this.src='image/icon/top_menu/refresh-1.png'" />
            <asp:ImageButton ID="toplink_copy" runat="server" ImageUrl="~/hr360/image/icon/top_menu/copy-1.png" OnClick="toplink_copy_Click" onmouseover="this.src='image/icon/top_menu/copy-2.png'" onmouseout="this.src='image/icon/top_menu/copy-1.png'" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="page_content" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <div id="PR08">
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="MyTabStyle">
                    <ajaxToolkit:TabPanel runat="server" HeaderText="基本資料" ID="TabPanel1">
                        <ContentTemplate>
                            <div id="message">
                                <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="error-message"></asp:Label>
                            </div>
                            <div class="content">
                                <table class="content-table">
                                    <tr>
                                        <td colspan="6" class="title">
                                            STEP1:選擇評核資料
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>評核年度</td>
                                        <td>
                                            <asp:TextBox ID="txtForm_Assessment_Year" runat="server" MaxLength="4" Width="60" AutoPostBack="true" OnTextChanged="txtForm_Assessment_Year_TextChanged"></asp:TextBox> 年
                                        </td>
                                        <td>單別代號</td>
                                        <td>
                                            <asp:TextBox ID="txtForm_Type_Id" runat="server" AutoPostBack="true" OnTextChanged="txtForm_Type_Id_TextChanged"></asp:TextBox>
                                            <asp:Button ID="btnForm_Type_Select" runat="server" Text="..." PostBackUrl="#search_window_form_type" OnClick="btnForm_Type_Select_Click" />
                                        </td>
                                        <td></td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                <div>
                                    <div class="gridview">
                                        <asp:GridView ID="grdForm_List" runat="server" CssClass="grdForm_List" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnSelectedIndexChanged="grdForm_List_SelectedIndexChanged">
                                            <Columns>
                                                <asp:TemplateField HeaderText="單別代號">
                                                    <ItemTemplate>
                                                        <asp:Label ID="grdlblForm_Type_Id" runat="server" Text='<%#Eval("FORM_TYPE_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="單別名稱">
                                                    <ItemTemplate>
                                                        <asp:Label ID="grdlblForm_Type_Name" runat="server" Text='<%#Eval("FORM_TYPE_NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="評核單號">
                                                    <ItemTemplate>
                                                        <asp:Label ID="grdlblForm_Id" runat="server" Text='<%#Eval("FORM_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="評核年度">
                                                    <ItemTemplate>
                                                        <asp:Label ID="grdlblAssessment_Year" runat="server" Text='<%#Eval("ASSESSMENT_YEAR") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="評核期間">
                                                    <ItemTemplate>
                                                        <asp:Label ID="grdlblForm_Assessment_Period" runat="server" Text='<%#Eval("FORM_ASSESSMENT_PERIOD") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="員工代號">
                                                    <ItemTemplate>
                                                        <asp:Label ID="grdlblEmployee_Id" runat="server" Text='<%#Eval("EMPLOYEE_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="員工姓名">
                                                    <ItemTemplate>
                                                        <asp:Label ID="grdlblEmployee_Name" runat="server" Text='<%#Eval("EMPLOYEE_NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="員工部門">
                                                    <ItemTemplate>
                                                        <asp:Label ID="grdlblEmployee_Department" runat="server" Text='<%#Eval("EMPLOYEE_DEPARTMENT") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="員工職稱">
                                                    <ItemTemplate>
                                                        <asp:Label ID="grdlblEmployee_Rank" runat="server" Text='<%#Eval("EMPLOYEE_RANK") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="評核總人數">
                                                    <ItemTemplate>
                                                        <asp:Label ID="grdlblAssessor_No" runat="server" Text='<%#Eval("ASSESSOR_NO") %>'></asp:Label>
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
                                </div>
                                <table class="content-table">
                                    <tr>
                                        <td class="title">
                                            STEP2:分配評核員
                                        </td>
                                    </tr>
                                </table>
                                <div class="gridview2">
                                    <table class="wrapper">
                                        <tr>
                                            <td style="width:30%; vertical-align:bottom;">
                                                受稽核人員
                                            </td>
                                            <td style="width:5%"></td>
                                            <td style="width:10%; vertical-align:bottom;">
                                                稽核人員分配
                                            </td>
                                            <td style="width:55%;vertical-align:bottom;">
                                                <asp:TextBox ID="txtAssessor_Id" runat="server" AutoPostBack="true" OnTextChanged="txtAssessor_Id_TextChanged"></asp:TextBox>
                                                <asp:Button ID="btnAssessor_Select" runat="server" Text="..." PostBackUrl="#search_window_employee_id" OnClick="btnAssessor_Select_Click" />
                                                <asp:Label ID="lblAssessor_Name" runat="server"></asp:Label>
                                                <asp:ImageButton ID="btnAssessor_Import" ImageUrl="~/hr360/image/icon/expand.png" runat="server" OnClick="btnAssessor_Import_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="border:solid 1px #3880b0;height:240px;">
                                                    <div class="image">
                                                        <asp:Image ID="imgAvatar" runat="server" />
                                                    </div>
                                                    <div style="text-align:center;">
                                                        <asp:Label ID="lblEmployee_Id" runat="server"></asp:Label>
                                                        <asp:Label ID="lblEmployee_Name" runat="server"></asp:Label>
                                                    </div>
                                                    <div style="text-align:center;">   
                                                        <asp:Label ID="lblEmployee_Department" runat="server"></asp:Label>
                                                        <asp:Label ID="lblEmployee_Rank" runat="server"></asp:Label>
                                                    </div>
                                                    <div style="text-align:center;">
                                                        <asp:Label ID="lblForm_Id" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                            <td></td>
                                            <td colspan="2">
                                                <div style="border:solid 1px #3880b0;height:240px;">
                                                    <asp:GridView ID="grdAssessor_List" runat="server" CssClass="grdForm_List" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnRowDeleting="grdAssessor_List_RowDeleting">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/hr360/image/icon/collapse.png" CommandName="Delete" Height="20px" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="稽核順序">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="grdlblOrder" runat="server" Text='<%#Eval("ORDER") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="評核員代號">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="grdlblAssessor_Id" runat="server" Text='<%#Eval("ASSESSOR_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="評核員姓名">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="grdlblAssessor_Name" runat="server" Text='<%#Eval("ASSESSOR_NAME") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="部門別">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="grdlblAssessor_Department" runat="server" Text='<%#Eval("ASSESSOR_DEPARTMENT") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="職稱">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="grdlblAssessor_Rank" runat="server" Text='<%#Eval("ASSESSOR_RANK") %>'></asp:Label>
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
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
<%--                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="資料瀏覽">
                        <ContentTemplate>
                            <div class="search-result">
                                <asp:GridView ID="grdResult" runat="server" CellPadding="10" ForeColor="#333333" OnSelectedIndexChanged="grdResult_SelectedIndexChanged" CellSpacing="2" CssClass="grdResult">
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
                    </ajaxToolkit:TabPanel>--%>
                </ajaxToolkit:TabContainer>                
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="search_window" class="overlay">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>            
	            <div class="popup">
		            <h2>查詢</h2>
		            <a class="close" href="#">×</a>
		            <div class="content">
        			    <div class="search-condition">
                            <asp:DropDownList ID="ddlSearch_Item" runat="server" DataSourceID="HR360" DataTextField="COLUMN_NAME_CN" DataValueField="COLUMN_NAME"></asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="HR360" ConnectionString='<%$ ConnectionStrings:HR360ConnectionString %>' SelectCommand="SELECT COLUMN_NAME, CASE COLUMN_NAME
					        WHEN N'FORM_TYPE_ID' THEN N'評核單別代號'
					        WHEN N'FORM_ID' THEN N'評核單代號'
                            WHEN N'ASSESSMENT_YEAR' THEN N'評核年度'
                            WHEN N'ASSESSOR_ID' THEN N'評核員代號'
                            WHEN N'ASSESSOR_NAME' THEN N'評核員姓名'
					        END AS COLUMN_NAME_CN
                            FROM INFORMATION_SCHEMA.COLUMNS
                            WHERE (TABLE_NAME = N'HR360_PR08_A' AND (COLUMN_NAME=N'FORM_TYPE_ID' OR COLUMN_NAME=N'FORM_ID' OR COLUMN_NAME=N'ASSESSMENT_YEAR' OR COLUMN_NAME=N'ASSESSOR_ID' OR COLUMN_NAME=N'ASSESSOR_NAME'))
                                OR (TABLE_NAME = N'HR360_PR07_A' AND (COLUMN_NAME=N'ASSESSMENT_YEAR'))"></asp:SqlDataSource>
                            <asp:DropDownList ID="ddlOperative" runat="server">
                                <asp:ListItem Selected="True">=</asp:ListItem>
                                <asp:ListItem>&gt;=</asp:ListItem>
                                <asp:ListItem>&lt;=</asp:ListItem>
                                <asp:ListItem>&gt;</asp:ListItem>
                                <asp:ListItem>&lt;</asp:ListItem>
                                <asp:ListItem>&lt;&gt;</asp:ListItem>
                                <asp:ListItem>LIKE</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txtSearchContent" runat="server"></asp:TextBox>
                            <br />
                            <br />
                            <asp:RadioButton ID="rdoAnd" runat="server" Text="AND" GroupName="Search_Condition_AndOr" Checked="true" />
                            <asp:RadioButton ID="rdoOr" runat="server" Text="OR" GroupName="Search_Condition_AndOr" />
                            <br />
                            <br />
                            <asp:Button ID="btnSearch_AddCondition" runat="server" Text="加入" OnClick="btnSearch_AddCondition_Click" CssClass="search-condition-button" />
                            <asp:Button ID="btnSearch_ClearCondition" runat="server" Text="清除" OnClick="btnSearch_ClearCondition_Click" CssClass="search-condition-button" />
        			    </div>
                        <div class="search-condition-window">
                            <asp:TextBox ID="txtSearchCondition" runat="server" TextMode="MultiLine" Wrap="False" ReadOnly="true"></asp:TextBox>
                            <asp:Button ID="btnSearch_Search" runat="server" Text="查詢" OnClick="btnSearch_Search_Click" />
                        </div>
	    	        </div>
	            </div>            
            </ContentTemplate>            
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlSearch_Item" EventName="SelectedIndexChanged" />
                <asp:PostBackTrigger ControlID="btnSearch_Search" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="search_window_form_type" class="overlay">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>            
	            <div class="popup">
		            <h2>單別選項</h2>
		            <a class="close" href="#">×</a>
		            <div class="content">
                        <div class="search-result">
                            <asp:GridView ID="grdForm_Type" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" OnSelectedIndexChanged="grdForm_Type_SelectedIndexChanged" CssClass="grdResult">
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
	    	        </div>
	            </div>            
            </ContentTemplate>            
            <Triggers>
                <asp:PostBackTrigger ControlID="grdForm_Type" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="search_window_employee_id" class="overlay">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>            
	            <div class="popup">
		            <h2>評核員選項</h2>
		            <a class="close" href="#">×</a>
		            <div class="content">
                        <div class="search-result">
                            <asp:GridView ID="grdAssessor" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" OnSelectedIndexChanged="grdAssessor_SelectedIndexChanged" CssClass="grdResult">
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
	    	        </div>
	            </div>            
            </ContentTemplate>            
            <Triggers>
                <asp:PostBackTrigger ControlID="grdAssessor" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PrintArea" Runat="Server">
</asp:Content>
