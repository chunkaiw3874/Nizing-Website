<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/HR360_Child.master" AutoEventWireup="true" CodeFile="PR03.aspx.cs" Inherits="hr360_PR03" %>

<asp:Content ID="Content1" ContentPlaceHolderID="javascript_section" Runat="Server">
    <script type="text/javascript">
        function chooseFile()
        {
            $("#<%= uploadFile.ClientID%>").click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_title" Runat="Server">
    <div id="page-title">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/hr360/image/icon/left_menu/PR03-1.png" />
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
            <asp:ImageButton ID="toplink_refresh" runat="server" ImageUrl="~/hr360/image/icon/top_menu/refresh-1.png" PostBackUrl="PR03.aspx" OnClick="toplink_refresh_Click" onmouseover="this.src='image/icon/top_menu/refresh-2.png'" onmouseout="this.src='image/icon/top_menu/refresh-1.png'" />
            <asp:ImageButton ID="toplink_copy" runat="server" ImageUrl="~/hr360/image/icon/top_menu/copy-1.png" OnClick="toplink_copy_Click" onmouseover="this.src='image/icon/top_menu/copy-2.png'" onmouseout="this.src='image/icon/top_menu/copy-1.png'" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="page_content" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <div id="PR03">
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="MyTabStyle">
                    <ajaxToolkit:TabPanel runat="server" HeaderText="基本資料" ID="TabPanel1">
                        <ContentTemplate>
                            <div id="message">
                                <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="error-message"></asp:Label>
                            </div>
                            <div class="content">
                                <table class="content-table">
                                    <tr>
                                        <td>獎懲單別</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtForm_Type_Id" runat="server" AutoPostBack="true" OnTextChanged="txtForm_Type_Id_TextChanged"></asp:TextBox>
                                            <asp:Button ID="btnForm_Type_Select" runat="server" Text="..." PostBackUrl="#search_window_form_type" OnClick="btnForm_Type_Select_Click" /> <%--只會出現PR01_A中FORM_TYPE為PR03: 獎懲單建立作業的選項--%>
                                            <asp:Label ID="lblForm_Type_Name" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>獎懲單號</td>
                                        <td colspan="3"><asp:TextBox ID="txtId" runat="server" ReadOnly="true" CssClass="read-only"></asp:TextBox></td> <%--選擇了獎懲單別後自動產生，格式從PR01_A中的CODE_FORMAT抓取--%>
                                    </tr>
                                    <tr>
                                        <td>獎懲日期</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtDate" runat="server" AutoPostBack="true" OnTextChanged="txtDate_TextChanged"></asp:TextBox>
                                            <%--<asp:ImageButton ID="btnDate_Select" runat="server" Height="25px" ImageUrl="~/hr360/image/icon/calendar-icon.png" Width="25px" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" BehaviorID="calendarDate" runat="server" Format="yyyy/MM/dd" PopupButtonID="btnDate_Select" PopupPosition="Right" TargetControlID="txtDate" OnClientHidden="onCalendarHidden" OnClientShown="onCalendarShown" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>員工代號</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtEmployee_Id" runat="server" MaxLength="20" AutoPostBack="true" OnTextChanged="txtEmployee_Id_TextChanged"></asp:TextBox>
                                            <asp:Button ID="btnEmployee_Select" runat="server" Text="..." PostBackUrl="#search_window_employee_id" OnClick="btnEmployee_Select_Click" /> <%--只顯示打單當日在職員工--%>
                                            <asp:Label ID="lblEmployee_Name" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>獎懲項目代號</td>
                                        <td>
                                            <asp:TextBox ID="txtCategory_Id" runat="server" AutoPostBack="true" OnTextChanged="txtCategory_Id_TextChanged"></asp:TextBox>
                                            <asp:Button ID="btnCategory_Select" runat="server" Text="..." PostBackUrl="#search_window_category_id" OnClick="btnCategory_Select_Click" />
                                        </td>
                                        <td>輕重等級</td>
                                        <td>
                                            <asp:DropDownList ID="ddlSeverity" runat="server">
                                                <asp:ListItem>1: 輕微</asp:ListItem>
                                                <asp:ListItem>2: 偏中等</asp:ListItem>
                                                <asp:ListItem>3: 中等</asp:ListItem>
                                                <asp:ListItem>4: 偏重大</asp:ListItem>
                                                <asp:ListItem>5: 重大</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>獎懲項目名稱</td>
                                        <td><asp:TextBox ID="txtCategory_Name" runat="server" Width="400px" ReadOnly="true" CssClass="read-only"></asp:TextBox></td>
                                        <td>獎懲金額</td>
                                        <td><asp:TextBox ID="txtAmount" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>獎懲項目說明</td>
                                        <td><asp:TextBox ID="txtCategory_Description" runat="server" Width="400px" ReadOnly="true" CssClass="read-only"></asp:TextBox></td>
                                        <td>結清方式</td>
                                        <td>
                                            <asp:DropDownList ID="ddlClear_Method" runat="server">
                                                <asp:ListItem>1: 當月結清</asp:ListItem>
                                                <asp:ListItem>2: 次月結清</asp:ListItem>
                                                <asp:ListItem>3: 年底結清</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>細項說明</td>
                                        <td colspan="3"><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="800" Height="200" Wrap="true"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            附件
                                        </td>
                                        <td colspan="3">
                                            檔案於按下上傳或刪除後即完成相關步驟<br />
                                            <asp:ListBox ID="lbxAttachment" runat="server" Width="400px" Height="100px"></asp:ListBox>
                                            <div class="upload">
                                                <input id="uploadFile" name="uploadFile" type="file" runat="server"/>
                                            </div>
                                            <div id="uploadTrigger" onclick="chooseFile();" style="display:inline-block;cursor:pointer;">
                                                <asp:Image ID="imgBrowse" runat="server" ImageUrl="~/hr360/image/icon/expand.png" />
                                            </div>
                                            <asp:Button ID="btnUpload" runat="server" Text="上傳" OnClick="btnUpload_Click"/>    
                                            <asp:Button ID="btnOpen" runat="server" Text="開啟" OnClick="btnOpen_Click" />
                                            <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClick="btnDelete_Click" />
                                        </td>
                                    </tr>
                                </table>
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
        <Triggers>
            <asp:PostBackTrigger ControlID="TabContainer1$TabPanel1$btnUpload" />
        </Triggers>
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
					        WHEN N'CREATEDATE' THEN N'建立日期'
                            WHEN N'CREATOR' THEN N'建立者'
					        WHEN N'MODIFIEDDATE' THEN N'修改日期'
					        WHEN N'MODIFIER' THEN N'修改者'
					        WHEN N'FORM_TYPE_ID' THEN N'獎懲單別代號'
					        WHEN N'ID' THEN N'獎懲單代號'
                            WHEN N'DATE' THEN N'獎懲日期'
                            WHEN N'EMPLOYEE_ID' THEN N'員工代號'
                            WHEN N'CATEGORY_ID' THEN N'獎懲項目代號'
                            WHEN N'SEVERITY' THEN N'輕重等級'
                            WHEN N'AMOUNT' THEN N'獎懲金額'
                            WHEN N'CLEAR_METHOD' THEN N'結清方式'
                            WHEN N'DESCRIPTION' THEN N'細項說明'
					        END AS COLUMN_NAME_CN
                            FROM INFORMATION_SCHEMA.COLUMNS
                            WHERE TABLE_NAME = N'PR03_A' AND (COLUMN_NAME=N'CREATEDATE' OR COLUMN_NAME=N'CREATOR' OR COLUMN_NAME=N'MODIFIEDDATE' OR COLUMN_NAME=N'MODIFIER' OR COLUMN_NAME=N'FORM_TYPE_ID' OR COLUMN_NAME=N'ID' OR COLUMN_NAME=N'DATE' OR COLUMN_NAME=N'EMPLOYEE_ID' OR COLUMN_NAME=N'CATEGORY_ID' OR COLUMN_NAME=N'SEVERITY' OR COLUMN_NAME=N'AMOUNT' OR COLUMN_NAME=N'CLEAR_METHOD' OR COLUMN_NAME=N'DESCRIPTION')"></asp:SqlDataSource>
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
    <div id="search_window_category_id" class="overlay">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>            
	            <div class="popup">
		            <h2>獎懲項目</h2>
		            <a class="close" href="#">×</a>
		            <div class="content">
                        <div class="search-result">
                            <asp:GridView ID="grdCategory" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" OnSelectedIndexChanged="grdCategory_SelectedIndexChanged" CssClass="grdResult">
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
                <asp:PostBackTrigger ControlID="grdCategory" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
<asp:Content ID="PrintArea" ContentPlaceHolderID="PrintArea" runat="server">
</asp:Content>