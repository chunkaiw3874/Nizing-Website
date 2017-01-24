<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="M01.aspx.cs" Inherits="nizing_intranet_M01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="M01">
        <div>
            <h2>生產統計表</h2>
        </div>
<%--        <div>
            <asp:RadioButton ID="rdoYear" runat="server" Text="年報表" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" />
            <asp:RadioButton ID="rdoMonth" runat="server" Text="月報表" Checked="true" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" />
        </div>--%>
        <div>
            開始查詢年份
            <asp:DropDownList ID="ddlStartYear" runat="server">
            </asp:DropDownList>
        </div>
        <div>
            結束查詢年份
            <asp:DropDownList ID="ddlEndYear" runat="server">
            </asp:DropDownList>
        </div>
        <div style="margin-top:10px; margin-bottom:10px;">
            <asp:ImageButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ImageUrl="~/nizing_intranet/image/button/Search_Button.png" />
            <asp:Button ID="btnExport" runat="server" Text="匯出至Excel" OnClick="btnExport_Click" />
        </div>
        <div>
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblScope" runat="server"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="grdProduction" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="grdResult" OnRowDataBound="grdProduction_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="生產線別">
                        <ItemTemplate>
                            <asp:Label ID="lbl1" runat="server" Text='<%#Eval("ProductionLine") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="年度">
                        <ItemTemplate>
                            <asp:Label ID="lbl2" runat="server" Text='<%#Eval("YR") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="生產數量">
                        <ItemTemplate>
                            <asp:Label ID="lbl2" runat="server" Text='<%#Eval("ProductionAmount") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="一月">
                            <ItemTemplate>
                                <asp:Label ID="lbl3" runat="server" Text='<%#Eval("01") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="二月">
                            <ItemTemplate>
                                <asp:Label ID="lbl4" runat="server" Text='<%#Eval("02") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="三月">
                            <ItemTemplate>
                                <asp:Label ID="lbl5" runat="server" Text='<%#Eval("03") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="四月">
                            <ItemTemplate>
                                <asp:Label ID="lbl6" runat="server" Text='<%#Eval("04") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="五月">
                            <ItemTemplate>
                                <asp:Label ID="lbl7" runat="server" Text='<%#Eval("05") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="六月">
                            <ItemTemplate>
                                <asp:Label ID="lbl8" runat="server" Text='<%#Eval("06") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="七月">
                            <ItemTemplate>
                                <asp:Label ID="lbl9" runat="server" Text='<%#Eval("07") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="八月">
                            <ItemTemplate>
                                <asp:Label ID="lbl10" runat="server" Text='<%#Eval("08") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="九月">
                            <ItemTemplate>
                                <asp:Label ID="lbl11" runat="server" Text='<%#Eval("09") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="十月">
                            <ItemTemplate>
                                <asp:Label ID="lbl12" runat="server" Text='<%#Eval("10") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="十一月">
                            <ItemTemplate>
                                <asp:Label ID="lbl13" runat="server" Text='<%#Eval("11") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="十二月">
                            <ItemTemplate>
                                <asp:Label ID="lbl14" runat="server" Text='<%#Eval("12") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="年度總產量">
                            <ItemTemplate>
                                <asp:Label ID="lbl15" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

