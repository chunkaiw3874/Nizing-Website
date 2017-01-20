<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/Scrap_Master.master" AutoEventWireup="true" CodeFile="SP_R01.aspx.cs" Inherits="QC_scrap_SP_R01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    <h2>廢線月平均量</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="查詢起始年份"></asp:Label>
            <asp:DropDownList ID="ddlStartYear" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="查詢結束年份"></asp:Label>
            <asp:DropDownList ID="ddlEndYear" runat="server"></asp:DropDownList>
        </div>
        <div style="margin-top:10px;">
            <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="DeptDataSource" DataTextField="ME002" DataValueField="ME001" AppendDataBoundItems="true">
                <asp:ListItem Value="all" Selected="True">全部部門</asp:ListItem>
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
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="查詢" OnClick="btnSubmit_Click" />
        </div>
        <div>
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>
        </div>
    </div>
    <div>
        <div>
            <asp:Label ID="lblScope" runat="server"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="grdResult" runat="server" CssClass="grdResult" AutoGenerateColumns="false" OnRowDataBound="grdResult_RowDataBound" HeaderStyle-Wrap="false" RowStyle-Wrap="false">
                <Columns>
                    <asp:TemplateField HeaderText="年份">
                        <ItemTemplate>
                            <asp:Label ID="lbl0" runat="server" Text='<%#Eval("YR") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="部門">
                        <ItemTemplate>
                            <asp:Label ID="lbl1" runat="server" Text='<%#Eval("DEPT_NAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="項目">
                        <ItemTemplate>
                            <asp:Label ID="lbl2" runat="server" Text='<%#Eval("TYPE_NAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="一月">
                        <ItemTemplate>
                            <asp:Label ID="lbl3" runat="server" Text='<%#Eval("1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="二月">
                        <ItemTemplate>
                            <asp:Label ID="lbl4" runat="server" Text='<%#Eval("2") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="三月">
                        <ItemTemplate>
                            <asp:Label ID="lbl5" runat="server" Text='<%#Eval("3") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="四月">
                        <ItemTemplate>
                            <asp:Label ID="lbl6" runat="server" Text='<%#Eval("4") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="五月">
                        <ItemTemplate>
                            <asp:Label ID="lbl7" runat="server" Text='<%#Eval("5") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="六月">
                        <ItemTemplate>
                            <asp:Label ID="lbl8" runat="server" Text='<%#Eval("6") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="七月">
                        <ItemTemplate>
                            <asp:Label ID="lbl9" runat="server" Text='<%#Eval("7") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="八月">
                        <ItemTemplate>
                            <asp:Label ID="lbl10" runat="server" Text='<%#Eval("8") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="九月">
                        <ItemTemplate>
                            <asp:Label ID="lbl11" runat="server" Text='<%#Eval("9") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="年度總報廢量">
                        <ItemTemplate>
                            <asp:Label ID="lbl15" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="月平均報廢量">
                        <ItemTemplate>
                            <asp:Label ID="lbl16" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PrintArea" Runat="Server">
</asp:Content>

