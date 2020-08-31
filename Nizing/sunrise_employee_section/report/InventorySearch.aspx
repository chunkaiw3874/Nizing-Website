<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/report/sunrise-master.master" CodeFile="InventorySearch.aspx.cs" Inherits="InventorySearch" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <style>
        #inventory #search-result .grdResult tr td:nth-child(n+3):nth-child(-n+5){
            text-align:left;
        }
        #Panel1{
            margin-bottom:20px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch">
        <div id="inventory">
            <div id="search-field">
                <h2>庫存查詢系統</h2>
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                <div>
                    <table id="search-table">
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkId" runat="server" Text="品號查詢" Checked="true" />
                            </td>
                            <td>開頭為
                            </td>
                            <td>
                                <asp:TextBox ID="txtId_Start" runat="server" Width="200"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkName" runat="server" Text="品名查詢" />
                            </td>
                            <td>開頭為
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtName_Start" runat="server" Width="200"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>包含有
                            </td>
                            <td>
                                <asp:TextBox ID="txtId_Middle" runat="server" Width="200"></asp:TextBox>
                            </td>
                            <td></td>
                            <td>包含有
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtName_Middle" runat="server" Width="200"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>結尾為
                            </td>
                            <td>
                                <asp:TextBox ID="txtId_End" runat="server" Width="200"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3"></td>
                            <td>
                                <asp:CheckBox ID="chkCategory" runat="server" Text="分類查詢" />
                            </td>
                            <td>會計分類
                            </td>
                            <td>
                                <asp:TextBox ID="txtCategory_Acct" runat="server"></asp:TextBox>
                                <asp:Button ID="btnCategory_Acct_Select" runat="server" Text="..." PostBackUrl="#acct_search_window" OnClick="btnCategory_Acct_Select_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:CheckBox ID="chkInvShowZero" runat="server" Text="顯示實際在庫量為0的項目" Checked="false" />
                            </td>
                            <td></td>
                            <%--                        <td>
                            原物半分類
                        </td>
                        <td>
                            <asp:TextBox ID="txtCategory_Raw" runat="server"></asp:TextBox>
                            <asp:Button ID="btnCategory_Raw_Select" runat="server" Text="..." PostBackUrl="#raw_search_window" OnClick="btnCategory_Raw_Select_Click" />
                        </td>  --%>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:CheckBox ID="chkSafetyShowZero" runat="server" Text="顯示預估安全存量為0的項目" Checked="true" />
                            </td>
                            <td></td>
                            <%--                        <td>
                            小成品分類
                        </td>
                        <td>
                            <asp:TextBox ID="txtCategory_Small" runat="server"></asp:TextBox>
                            <asp:Button ID="btnCategory_Small_Select" runat="server" Text="..." PostBackUrl="#small_search_window" OnClick="btnCategory_Small_Select_Click" />
                        </td>--%>
                            <td>
                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/employee_section/report/image/button/Search_Button.png" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                        <%--<tr>
                        <td colspan="4"></td>
                        <td>
                            大成品分類
                        </td>
                        <td>
                            <asp:TextBox ID="txtCategory_Large" runat="server"></asp:TextBox>
                            <asp:Button ID="btnCategory_Large_Select" runat="server" Text="..." PostBackUrl="#large_search_window" OnClick="btnCategory_Large_Select_Click" />
                        </td>
                    </tr>--%>
                    </table>
                </div>
            </div>

            <div id="search-result">
                <asp:GridView ID="grdResult" runat="server" AutoGenerateColumns="false" CssClass="grdResult"
                    OnPreRender="grdResult_PreRender">
                    <Columns>
                        <asp:TemplateField HeaderText="在庫量" HeaderStyle-Width="60">
                            <ItemTemplate>
                                <asp:Label ID="label" runat="server" Text='<%#Eval("AMOUNT_IN_INV") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="儲位" HeaderStyle-Width="70">
                            <ItemTemplate>
                                <asp:Label ID="label" runat="server" Text='<%#Eval("INV_LOCATION") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="品號" HeaderStyle-Width="160">
                            <ItemTemplate>
                                <asp:Label ID="label" runat="server" Text='<%#Eval("ITEM_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="品名" HeaderStyle-Width="200">
                            <ItemTemplate>
                                <asp:Label ID="label" runat="server" Text='<%#Eval("ITEM_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="規格" HeaderStyle-Width="100">
                            <ItemTemplate>
                                <asp:Label ID="label" runat="server" Text='<%#Eval("ITEM_SPEC") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位成本未稅">
                            <ItemTemplate>
                                <asp:Label ID="label" runat="server" Text='<%#Eval("INV_AVG_COST") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="最後進貨價格">
                            <ItemTemplate>
                                <asp:Label ID="label" runat="server" Text='<%#Eval("LAST_PURCHASE_PRICE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="幣別" HeaderStyle-Width="50">
                            <ItemTemplate>
                                <asp:Label ID="label" runat="server" Text="NTD"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位" HeaderStyle-Width="50">
                            <ItemTemplate>
                                <asp:Label ID="label" runat="server" Text='<%#Eval("UNIT") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="庫別" HeaderStyle-Width="70">
                            <ItemTemplate>
                                <asp:Label ID="label" runat="server" Text='<%#Eval("INV_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="庫別名稱" HeaderStyle-Width="70">
                            <ItemTemplate>
                                <asp:Label ID="label" runat="server" Text='<%#Eval("INV_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="安全庫存量" HeaderStyle-Width="70">
                            <ItemTemplate>
                                <asp:Label ID="label" runat="server" Text='<%#Eval("AMOUNT_SAFETY") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="原物半分類">
                        <ItemStyle Width="100" />
                        <ItemTemplate>
                            <asp:Label ID="label" runat="server" Text='<%#Eval("CATEGORY_RAW") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="小成品分類">
                        <ItemStyle Width="100" />
                        <ItemTemplate>
                            <asp:Label ID="label" runat="server" Text='<%#Eval("CATEGORY_SMALL") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="大成品分類">
                        <ItemStyle Width="100" />
                        <ItemTemplate>
                            <asp:Label ID="label" runat="server" Text='<%#Eval("CATEGORY_LARGE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="acct_search_window" class="overlay">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="popup">
                        <h2>會計分類</h2>
                        <a class="close" href="#">×</a>
                        <div class="content">
                            <div class="search-result">
                                <asp:GridView ID="grdAcct" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" OnSelectedIndexChanged="grdAcct_SelectedIndexChanged">
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
                    <asp:PostBackTrigger ControlID="grdAcct" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <%--    <div id="raw_search_window" class="overlay">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>            
	            <div class="popup">
		            <h2>原物料半分類</h2>
		            <a class="close" href="#">×</a>
		            <div class="content">
                        <div class="search-result">
                            <asp:GridView ID="grdRaw" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" OnSelectedIndexChanged="grdRaw_SelectedIndexChanged">
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
                <asp:PostBackTrigger ControlID="grdRaw" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="small_search_window" class="overlay">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>            
	            <div class="popup">
		            <h2>小成品分類</h2>
		            <a class="close" href="#">×</a>
		            <div class="content">
                        <div class="search-result">
                            <asp:GridView ID="grdSmall" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" OnSelectedIndexChanged="grdSmall_SelectedIndexChanged">
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
                <asp:PostBackTrigger ControlID="grdSmall" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="large_search_window" class="overlay">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>            
	            <div class="popup">
		            <h2>大成品分類</h2>
		            <a class="close" href="#">×</a>
		            <div class="content">
                        <div class="search-result">
                            <asp:GridView ID="grdLarge" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" OnSelectedIndexChanged="grdLarge_SelectedIndexChanged">
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
                <asp:PostBackTrigger ControlID="grdLarge" />
            </Triggers>
        </asp:UpdatePanel>
    </div>--%>
    </asp:Panel>
</asp:Content>
