<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Child.master" AutoEventWireup="true" CodeFile="BI01.aspx.cs" Inherits="hr360_BI01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="javascript_section" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_title" Runat="Server">
    <div id="page-title">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/hr360/image/icon/left_menu/BI01-1.png" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="top_menu" Runat="server">
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
            <div id="Login_Personnel_Setup">
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="MyTabStyle">
                    <ajaxToolkit:TabPanel runat="server" HeaderText="基本資料" ID="TabPanel1">
                        <ContentTemplate>            
                            <div id="message">
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" Text=" "></asp:Label>
                            </div>
                            <div class="content">
                                <table class="content-table">
                                    <tr>
                                        <td>
                                            使用者代號
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUserId" runat="server" MaxLength="20" placeholder="最大字元數量20" BorderColor="#a9caff" Font-Size="12"></asp:TextBox>
                                        </td>
                                        <td>
                                            超級使用者
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkSuperUser" runat="server" Checked="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            密碼
                                        </td>
                                        <td>
                                            <%--<asp:TextBox ID="txtPassword" runat="server" MaxLength="20" placeholder="最大字元數量20" BorderColor="#a9caff" Font-Size="12" TextMode="Password"></asp:TextBox>--%>
                                            <!--可看到密碼-->
                                            <asp:TextBox ID="txtPassword" runat="server" MaxLength="20" placeholder="最大字元數量20" BorderColor="#a9caff" Font-Size="12"></asp:TextBox>
                                        </td>
                                        <td>
                                            失效帳號
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkDisabled" runat="server" Checked="false" OnCheckedChanged="chkDisabled_CheckedChanged" AutoPostBack="true" BorderColor="#a9caff" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            確認密碼
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtReenterPassword" runat="server" MaxLength="20" placeholder="確認密碼" BorderColor="#a9caff" Font-Size="12" TextMode="Password"></asp:TextBox>
                                            <!--可看到密碼-->
                                            <%--<asp:TextBox ID="txtReenterPassword" runat="server" MaxLength="20" placeholder="確認密碼" BorderColor="#a9caff" Font-Size="12"></asp:TextBox>--%>
                                        </td>
                                        <td>
                                            失效日期
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDisabledDate" runat="server"  BorderColor="#a9caff" Font-Size="12"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            ERP員工代號
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtErpUserId" runat="server" MaxLength="255" placeholder="最大字元數量255" BorderColor="#a9caff" Font-Size="12"></asp:TextBox>
                                            <asp:Button ID="btnErpId_Search" runat="server" Text="..." PostBackUrl="#erp_id_search_window" OnClick="btnErpId_Search_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="margin:0px;padding:0px; color:red" colspan="5">
                                            *如果您沒有 "ERP員工代號" ，請於使用者名稱內填寫
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            使用者名稱
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" runat="server" BorderColor="#a9caff" Font-Size="12"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            EMAIL
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="255" Width="350" placeholder="最大字元數量255" BorderColor="#a9caff" Font-Size="12"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            LINE ID
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLineId" runat="server" MaxLength="255" Width="350" placeholder="最大字元數量255" BorderColor="#a9caff" Font-Size="12"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>                
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="資料瀏覽">
                        <ContentTemplate>
                            <div class="search-result">
                                <asp:GridView ID="grdResult" runat="server" CellPadding="10" ForeColor="#333333" OnSelectedIndexChanged="grdResult_SelectedIndexChanged" CellSpacing="2" OnRowDataBound="grdResult_RowDataBound" CssClass="grdResult">
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
                            <asp:DropDownList ID="ddlSearch_Item" runat="server" DataSourceID="HR360" DataTextField="COLUMN_NAME_CN" DataValueField="COLUMN_NAME" OnSelectedIndexChanged="ddlSearch_Item_SelectedIndexChanged"></asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="HR360" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT COLUMN_NAME, CASE COLUMN_NAME
					WHEN N'ID' THEN N'使用者代號'                             
                    WHEN N'ERP_ID' THEN N'ERP員工代號'
                    WHEN N'NAME' THEN N'使用者名稱'   
                    WHEN N'EMAIL' THEN N'電子郵件'
                    WHEN N'LINE_ID' THEN N'LINE ID'
                    WHEN N'NO_DELETE' THEN N'不可刪除(1/0)'
                    WHEN N'DISABLED' THEN N'失效(1/0)'
                    WHEN N'DISABLEDDATE' THEN N'失效日期'
					WHEN N'CREATEDATE' THEN N'建立日期'
                    WHEN N'CREATOR' THEN N'建立者'
					WHEN N'MODIFIEDDATE' THEN N'修改日期'
                    WHEN N'MODIFIER' THEN N'修改者'
					END AS COLUMN_NAME_CN
                    FROM INFORMATION_SCHEMA.COLUMNS
                    WHERE TABLE_NAME = N'HR360_BI01_A' AND COLUMN_NAME <> N'PASSWORD' AND (COLUMN_NAME=N'ID' OR COLUMN_NAME=N'ERP_ID' OR COLUMN_NAME=N'NAME' OR COLUMN_NAME=N'EMAIL' OR COLUMN_NAME=N'LINE_ID' OR COLUMN_NAME=N'NO_DELETE' OR COLUMN_NAME=N'DISABLED' OR COLUMN_NAME=N'DISABLEDDATE' OR COLUMN_NAME=N'CREATEDATE' OR COLUMN_NAME=N'CREATOR' OR COLUMN_NAME=N'MODIFIEDDATE' OR COLUMN_NAME=N'MODIFIER')"></asp:SqlDataSource>
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
                            <asp:TextBox ID="txtSearchCondition" runat="server" TextMode="MultiLine" Wrap="False" ReadOnly="true" ViewStateMode="Enabled"></asp:TextBox>                            
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
    <div id="erp_id_search_window" class="overlay">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>            
	            <div class="popup">
		            <h2>ERP ID</h2>
		            <a class="close" href="#">×</a>
		            <div class="content">
                        <div class="search-result">
                            <asp:GridView ID="grdErp_Id" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" OnSelectedIndexChanged="grdErp_Id_SelectedIndexChanged">
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
                <asp:PostBackTrigger ControlID="grdErp_Id" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>

