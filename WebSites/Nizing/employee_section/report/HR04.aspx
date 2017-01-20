<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="HR04.aspx.cs" Inherits="nizing_intranet_HR04" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="HR04">
        <div>
            <h2>員工年度平均底薪</h2>
        </div>
        <div>
            <asp:DropDownList ID="ddlYear" runat="server" Width="70"></asp:DropDownList>
        </div>
        <div>
            <asp:DropDownList ID="ddlType" runat="server" Width="70">
                <asp:ListItem Value="實領">實領</asp:ListItem>
                <asp:ListItem Value="底薪">底薪</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div style="margin-top: 10px; margin-bottom: 10px;">
            <asp:ImageButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ImageUrl="~/employee_section/report/image/button/Search_Button.png" />
        </div>
        <div>
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblScope" runat="server"></asp:Label>
        </div>
        <div id="search-result">
            <div class="inline-top">
                <asp:GridView ID="grdReport" runat="server" GridLines="None" AutoGenerateColumns="false" OnRowDataBound="grdReport_RowDataBound" OnDataBound="grdReport_DataBound" OnRowCreated="grdReport_RowCreated" ShowFooter="True" CssClass="grdResultWithFooter">
                    <Columns>
                        <asp:TemplateField HeaderText="員工代號">
                            <ItemTemplate>
                                <asp:Label ID="lbl1" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="員工姓名">
                            <ItemTemplate>
                                <asp:Label ID="lbl2" runat="server" Text='<%#Eval("NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                        <asp:TemplateField HeaderText="總額">
                            <ItemTemplate>
                                <asp:Label ID="lbl15" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="年度平均">
                            <ItemTemplate>
                                <asp:Label ID="lbl16" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

