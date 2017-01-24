<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Child.master" AutoEventWireup="true" CodeFile="PR07.aspx.cs" Inherits="hr360_PR07" %>

<asp:Content ID="Content1" ContentPlaceHolderID="javascript_section" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_title" Runat="Server">
    <div id="page-title">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/hr360/image/icon/left_menu/PR07-1.png" />
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
            <asp:ImageButton ID="toplink_refresh" runat="server" ImageUrl="~/hr360/image/icon/top_menu/refresh-1.png" PostBackUrl="PR07.aspx" OnClick="toplink_refresh_Click" onmouseover="this.src='image/icon/top_menu/refresh-2.png'" onmouseout="this.src='image/icon/top_menu/refresh-1.png'" />
            <asp:ImageButton ID="toplink_copy" runat="server" ImageUrl="~/hr360/image/icon/top_menu/copy-1.png" OnClick="toplink_copy_Click" onmouseover="this.src='image/icon/top_menu/copy-2.png'" onmouseout="this.src='image/icon/top_menu/copy-1.png'" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="page_content" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <div id="PR07">
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="MyTabStyle">
                    <ajaxToolkit:TabPanel runat="server" HeaderText="基本資料" ID="TabPanel1">
                        <ContentTemplate>
                            <div id="message">
                                <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="error-message"></asp:Label>
                            </div>
                            <div class="content">
                                <div class="title">
                                    <div style="position:relative; top:30px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/hr360/image/image/HR360.png" />
                                    </div>
                                    <div class="text">
                                        <asp:Label ID="lblForm_Type_Name" runat="server"></asp:Label>
                                    </div>
                                    <div class="text">
                                        <asp:Label ID="lblForm_Type_En_Name" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <table class="content-table">
                                    <tr>
                                        <td>評核單別</td>
                                        <td>
                                            <asp:TextBox ID="txtForm_Type_Id" runat="server" AutoPostBack="true" OnTextChanged="txtForm_Type_Id_TextChanged"></asp:TextBox>
                                            <asp:Button ID="btnForm_Type_Select" runat="server" Text="..." PostBackUrl="#search_window_form_type" OnClick="btnForm_Type_Select_Click" /> <%--只會出現PR01_A中FORM_TYPE為PR07: 考績單建立作業的選項--%>
                                        </td>
                                        <td>評核年度</td>
                                        <td><asp:TextBox ID="txtAssessment_Year" MaxLength="4" runat="server" Width="60px" OnTextChanged="txtAssessment_Year_TextChanged"></asp:TextBox> 年</td>
                                    </tr>
                                    <tr>
                                        <td>評核單號</td>
                                        <td><asp:TextBox ID="txtId" runat="server" ReadOnly="true" CssClass="read-only"></asp:TextBox></td> <%--選擇了獎懲單別後自動產生，格式從PR01_A中的CODE_FORMAT抓取--%>
                                        <td>員工代號</td>
                                        <td>
                                            <asp:TextBox ID="txtEmployee_Id" runat="server" MaxLength="20" AutoPostBack="true" OnTextChanged="txtEmployee_Id_TextChanged"></asp:TextBox>
                                            <asp:Button ID="btnEmployee_Select" runat="server" Text="..." PostBackUrl="#search_window_employee_id" OnClick="btnEmployee_Select_Click" /> <%--只顯示打單當日在職員工--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>評核日期</td>
                                        <td>
                                            <asp:TextBox ID="txtAssessment_Start_Date" runat="server" AutoPostBack="true" OnTextChanged="txtAssessment_Start_Date_TextChanged"></asp:TextBox>
                                             至 
                                            <asp:TextBox ID="txtAssessment_End_Date" runat="server" AutoPostBack="true" OnTextChanged="txtAssessment_End_Date_TextChanged"></asp:TextBox>
                                        </td>                                        
                                        <td>員工姓名</td>
                                        <td>
                                            <asp:Label ID="lblEmployee_Name" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>職稱</td>
                                        <td>
                                            <asp:Label ID="lblEmployee_Rank" runat="server"></asp:Label><span style="margin-right:20px;"></span>
                                            <asp:Label ID="lblEmployee_Department" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>年資</td>
                                        <td>
                                            <asp:Label ID="lblEmployee_Year_In_Service" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div style="margin-left:494px; margin-bottom:20px; margin-top:10px; margin-right:15px;">
                                    <span style="color:#f0a142">請選擇KPI群組，將所有屬於該群組之KPI項目一次帶入</span>
                                    <br />
                                    KPI群組代號
                                    <asp:TextBox ID="txtKpi_Group_Id" runat="server" AutoPostBack="true" OnTextChanged="txtKpi_Group_Id_TextChanged"></asp:TextBox>
                                    <asp:Button ID="btnKpi_Group_Select" runat="server" Text="..." PostBackUrl="#search_window_group_id" OnClick="btnKpi_Group_Select_Click" />
                                    <asp:Label ID="lblKpi_Group_Name" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    KPI項目代號
                                    <asp:TextBox ID="txtKpi_Item_Id" runat="server" AutoPostBack="true" OnTextChanged="txtKpi_Item_Id_TextChanged"></asp:TextBox>
                                    <asp:Button ID="btnKpi_Item_Select" runat="server" Text="..." PostBackUrl="#search_window_kpi_id" OnClick="btnKpi_Item_Select_Click" />
                                    <asp:ImageButton ID="btnKpi_Input_Selection" runat="server" OnClick="btnKpi_Input_Selection_Click" ImageUrl="~/hr360/image/icon/expand.png" />
                                    <div style="margin-top:20px;">
                                        <asp:Label ID="lblKpi_Item_Name" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div>
                                    評核項目瀏覽 Performance Category Preview
                                    <span style="margin-left:246px; color:#3880b0;">
                                    KPI建立作業 Key Performance Indicator
                                    </span>
                                </div>
                                <div>
                                    <div class="gridview">
                                        <asp:GridView ID="grdKpi_Category" runat="server" CssClass="grdKPI_List" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnRowCreated="grdKpi_Category_RowCreated">
                                            <Columns>
                                                <asp:TemplateField HeaderText="考績項目代號">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCategory_Id" runat="server" Text='<%#Eval("CATEGORY_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="考績項目名稱">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCategory_Name" runat="server" Text='<%#Eval("CATEGORY_NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="考績項目備註">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCategory_Memo" runat="server" Text='<%#Eval("CATEGORY_MEMO") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                            <EditRowStyle BackColor="#999999"></EditRowStyle>
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                            <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" CssClass="rowstyle"></RowStyle>
                                            <SelectedRowStyle BackColor="#FF9933" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                            <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                                            <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                                            <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                                        </asp:GridView>
                                    </div>
                                    <div class="gridview">
                                        <asp:GridView ID="grdKpi_Item" runat="server" CssClass="grdKPI_List" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnRowCreated="grdKpi_Item_RowCreated" OnRowDeleting="grdKpi_Item_RowDeleting">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/hr360/image/icon/collapse.png" CommandName="Delete" Height="20px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="序號">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRow_Number" runat="server" Text='<%#Eval("RN") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="KPI代號">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblKpi_Id" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="KPI名稱">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblKpi_Name" runat="server" Text='<%#Eval("NAME").ToString().Replace("\n","<br />") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="KPI備註">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtMemo" runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                            <EditRowStyle BackColor="#999999"></EditRowStyle>
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                            <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" CssClass="rowstyle"></RowStyle>
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
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="資料瀏覽">
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
                    </ajaxToolkit:TabPanel>
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
                            <asp:SqlDataSource runat="server" ID="HR360" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT COLUMN_NAME, CASE COLUMN_NAME
					        WHEN N'CREATEDATE' THEN N'建立日期'
                            WHEN N'CREATOR' THEN N'建立者'
					        WHEN N'MODIFIEDDATE' THEN N'修改日期'
					        WHEN N'MODIFIER' THEN N'修改者'
					        WHEN N'FORM_TYPE_ID' THEN N'評核單別代號'
					        WHEN N'ID' THEN N'評核單代號'
                            WHEN N'ASSESSMENT_YEAR' THEN N'評核年度'
                            WHEN N'EMPLOYEE_ID' THEN N'員工代號'
                            WHEN N'EMPLOYEE_NAME' THEN N'員工姓名'
					        END AS COLUMN_NAME_CN
                            FROM INFORMATION_SCHEMA.COLUMNS
                            WHERE TABLE_NAME = N'HR360_PR07_A' AND (COLUMN_NAME=N'CREATEDATE' OR COLUMN_NAME=N'CREATOR' OR COLUMN_NAME=N'MODIFIEDDATE' OR COLUMN_NAME=N'MODIFIER' OR COLUMN_NAME=N'FORM_TYPE_ID' OR COLUMN_NAME=N'ID' OR COLUMN_NAME=N'ASSESSMENT_YEAR' OR COLUMN_NAME=N'EMPLOYEE_ID' OR COLUMN_NAME=N'EMPLOYEE_NAME')"></asp:SqlDataSource>
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
		            <h2>員工選項</h2>
		            <a class="close" href="#">×</a>
		            <div class="content">
                        <div class="search-result">
                            <asp:GridView ID="grdEmployee" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" OnSelectedIndexChanged="grdEmployee_SelectedIndexChanged" CssClass="grdResult">
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
                <asp:PostBackTrigger ControlID="grdEmployee" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="search_window_group_id" class="overlay">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>            
	            <div class="popup">
		            <h2>群組代號</h2>
		            <a class="close" href="#">×</a>
		            <div class="content">
                        <div class="search-result">
                            <asp:GridView ID="grdGroup" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" OnSelectedIndexChanged="grdGroup_SelectedIndexChanged" CssClass="grdResult">
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
                <asp:PostBackTrigger ControlID="grdGroup" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="search_window_kpi_id" class="overlay">
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>            
	            <div class="popup">
		            <h2>KPI代號</h2>
		            <a class="close" href="#">×</a>
		            <div class="content">
                        <div class="search-result">
                            <asp:GridView ID="grdKpi" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" OnSelectedIndexChanged="grdKpi_SelectedIndexChanged" CssClass="grdResult">
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
                <asp:PostBackTrigger ControlID="grdKpi" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
