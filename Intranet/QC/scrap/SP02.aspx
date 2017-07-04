<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/Scrap_Master.master" AutoEventWireup="true" CodeFile="SP02.aspx.cs" Inherits="QC_scrap_SP02" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    廢線資料輸入
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" Runat="Server">
    <div id="page-menu">
        <asp:ImageButton ID="toplink_add" runat="server" ImageUrl="~/image/top_menu/add-1.png" OnClick="toplink_add_Click" onmouseover="this.src='/image/top_menu/add-2.png'" onmouseout="this.src='/image/top_menu/add-1.png'" />
        <asp:ImageButton ID="toplink_search" runat="server" ImageUrl="~/image/top_menu/search-1.png" PostBackUrl="#search_window" OnClick="toplink_search_Click" onmouseover="this.src='/image/top_menu/search-2.png'" onmouseout="this.src='/image/top_menu/search-1.png'" />
        <asp:ImageButton ID="toplink_edit" runat="server" ImageUrl="~/image/top_menu/edit-1.png" OnClick="toplink_edit_Click" onmouseover="this.src='/image/top_menu/edit-2.png'" onmouseout="this.src='/image/top_menu/edit-1.png'" />
        <asp:ImageButton ID="toplink_save" runat="server" ImageUrl="~/image/top_menu/save-1.png" OnClick="toplink_save_Click" onmouseover="this.src='/image/top_menu/save-2.png'" onmouseout="this.src='/image/top_menu/save-1.png'" />
        <asp:ImageButton ID="toplink_cancel" runat="server" ImageUrl="~/image/top_menu/cancel-1.png" OnClick="toplink_cancel_Click" onmouseover="this.src='/image/top_menu/cancel-2.png'" onmouseout="this.src='/image/top_menu/cancel-1.png'" />
        <asp:ImageButton ID="toplink_delete" runat="server" ImageUrl="~/image/top_menu/delete-1.png" OnClick="toplink_delete_Click" OnClientClick ="return confirm('確定要刪除嗎?');" onmouseover="this.src='/image/top_menu/delete-2.png'" onmouseout="this.src='/image/top_menu/delete-1.png'" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <div id="SP02">
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="MyTabStyle">
                    <ajaxToolkit:TabPanel runat="server" HeaderText="基本資料" ID="TabPanel1">
                        <ContentTemplate>
                            <div id="message">
                                <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="error-message"></asp:Label>
                            </div>
                            <div class="content">
                                <table class="content-table">
                                    <tr>
                                        <td>
                                            <div>
                                                <asp:Label ID="Label1" runat="server" Text="回收日期"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:TextBox ID="txtRecycle_Date" runat="server" MaxLength="8" placeholder="格式範例:20150304"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div>
                                                <asp:Label ID="Label2" runat="server" Text="報廢部門"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="DeptDataSource" DataTextField="ME002" DataValueField="ME001" AppendDataBoundItems="true">
                                                    <asp:ListItem Value="MISC">其它</asp:ListItem>
                                                    <asp:ListItem Value="SAMPLE">樣品</asp:ListItem>
                                                    <asp:ListItem Value="B-D">編織銅網部</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource runat="server" ID="DeptDataSource" ConnectionString='<%$ ConnectionStrings:NZConnectionString %>' 
                                                    SelectCommand="SELECT ME001, ME002
                                                                FROM CMSME
                                                                ORDER BY ME001 DESC">
                                                </asp:SqlDataSource>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div>
                                                <asp:Label ID="Label3" runat="server" Text="品項"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:DropDownList ID="ddlType" runat="server" DataSourceID="ScrapTypeDataSource" DataTextField="NAME" DataValueField="ID">
                                                </asp:DropDownList>
                                                <asp:SqlDataSource runat="server" ID="ScrapTypeDataSource" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' 
                                                        SelectCommand="SELECT ID, NAME
                                                                    FROM SCRAP_SP01_A
                                                                    ORDER BY ID">
                                                </asp:SqlDataSource>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div>
                                                <asp:Label ID="Label4" runat="server" Text="回收數量"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:TextBox ID="txtAmount" runat="server" OnTextChanged="txtAmount_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <div>
                                                <asp:Label ID="Label5" runat="server" Text="單位"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:Label ID="lblUnit" runat="server" Text="KG"></asp:Label>
                                            </div>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <div>
                                                <asp:Label ID="Label6" runat="server" Text="單價"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:TextBox ID="txtPrice" runat="server" OnTextChanged="txtPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <div>
                                                <asp:Label ID="Label7" runat="server" Text="總金額"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:Label ID="lblNet" runat="server"></asp:Label>
                                            </div>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <div>
                                                <asp:Label ID="Label8" runat="server" Text="備註"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:TextBox ID="txtMemo" runat="server" Width="400px" MaxLength="255" placeholder="MAX 255字元"></asp:TextBox>
                                            </div>
                                        </td>                                        
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel runat="server" HeaderText="資料瀏覽" ID="TabPanel2">
                        <ContentTemplate>
                            <div class="search-result">
                                <asp:GridView ID="grdResult" runat="server" CssClass="grdResult" CellPadding="10" ForeColor="#333333" OnSelectedIndexChanged="grdResult_SelectedIndexChanged" CellSpacing="2" AutoGenerateColumns="false" HeaderStyle-Wrap="false" RowStyle-Wrap="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="回收日期">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl0" runat="server" Text='<%#Eval("RECYCLE_DATE") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="報廢部門代號">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl1" runat="server" Text='<%#Eval("DEPARTMENT_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="報廢部門名稱">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl2" runat="server" Text='<%#Eval("DEPARTMENT_NAME") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="品項代號">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl3" runat="server" Text='<%#Eval("TYPE_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="品項名稱">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl4" runat="server" Text='<%#Eval("TYPE_NAME") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="回收數量">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl5" runat="server" Text='<%#Eval("AMOUNT") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="單位">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl6" runat="server" Text='<%#Eval("UNIT") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="單價">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl7" runat="server" Text='<%#Eval("PRICE") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="備註">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl8" runat="server" Text='<%#Eval("MEMO") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="建立日期">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl9" runat="server" Text='<%#Eval("CREATEDATE") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="建立人員">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl10" runat="server" Text='<%#Eval("CREATOR") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="修改日期">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl11" runat="server" Text='<%#Eval("MODIFIEDDATE") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="修改人員">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl12" runat="server" Text='<%#Eval("MODIFIER") %>'></asp:Label>
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
					        WHEN N'RECYCLE_DATE' THEN N'回收日期'
					        WHEN N'DEPARTMENT_ID' THEN N'報廢部門代號'
					        WHEN N'DEPARTMENT_NAME' THEN N'報廢部門名稱'
					        WHEN N'TYPE_ID' THEN N'品項代號'
					        WHEN N'TYPE_NAME' THEN N'品項名稱'
					        WHEN N'AMOUNT' THEN N'回收數量'
					        WHEN N'PRICE' THEN N'單價'
					        WHEN N'MEMO' THEN N'備註'
					        END AS COLUMN_NAME_CN
                            FROM INFORMATION_SCHEMA.COLUMNS
                            WHERE TABLE_NAME = N'SCRAP_SP02_A' AND (COLUMN_NAME=N'CREATEDATE' 
                                OR COLUMN_NAME=N'CREATOR'
                                OR COLUMN_NAME=N'MODIFIEDDATE' 
                                OR COLUMN_NAME=N'MODIFIER' 
                                OR COLUMN_NAME=N'RECYCLE_DATE' 
                                OR COLUMN_NAME=N'DEPARTMENT_ID'
                                OR COLUMN_NAME=N'DEPARTMENT_NAME'
                                OR COLUMN_NAME=N'TYPE_ID'
                                OR COLUMN_NAME=N'TYPE_NAME'
                                OR COLUMN_NAME=N'AMOUNT'
                                OR COLUMN_NAME=N'PRICE'
                                OR COLUMN_NAME=N'MEMO')"></asp:SqlDataSource>
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PrintArea" Runat="Server">
</asp:Content>

