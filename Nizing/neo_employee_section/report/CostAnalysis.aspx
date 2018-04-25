<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="CostAnalysis.aspx.cs" Inherits="neo_employee_section_report_CostAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row form-group" style="border">
            <div class="col-sm-6">
                <div class="input-group">
                <%--<asp:Label ID="Label1" runat="server" Text="產品品號"></asp:Label>--%>
                <asp:TextBox ID="txtPrdId" runat="server" placeholder="產品品號" CssClass="form-control"></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button ID="btnSearch" runat="server" Text="搜尋" CssClass="btn btn-success" OnClick="btnSearch_Click" />
                    </span>
                </div>
            </div>
            <div class="col-sm-6">
                <asp:Label ID="lblProductName" runat="server" Text="品名"></asp:Label>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-sm-3">
                <asp:GridView ID="gvBOMList" runat="server" AutoGenerateColumns="false" GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="製令單號">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("製令單號") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--<table id="tbBomList" class="table" runat="server">
                    <tr>
                        <td>1</td>
                    </tr>
                    <tr>
                        <td>1</td>
                    </tr>
                    <tr>
                        <td>1</td>
                    </tr>
                </table>--%>
            </div>
            <div class="col-sm-3">
                預計產量:<asp:Label ID="lblProductionAmount" runat="server" Text="幾台"></asp:Label>
            </div>
        </div>
        <div class="row form-group">
            
        </div>
    </div>

</asp:Content>

