<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="CostAnalysis.aspx.cs" Inherits="neo_employee_section_report_CostAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row form-group" style="border">
            <div class="col-sm-6">
                <div class="input-group">
                <asp:TextBox ID="txtPrdId" runat="server" placeholder="產品品號" CssClass="form-control"></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button ID="btnSearch" runat="server" Text="搜尋" CssClass="btn btn-success" OnClick="btnSearch_Click" />
                    </span>
                </div>
            </div>
            <div class="col-sm-6">
                <asp:Label ID="lblProductName" runat="server" Text="" Font-Size="Large" Font-Bold="true"></asp:Label>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-sm-3">
                <asp:GridView ID="gvBOMList" runat="server" AutoGenerateColumns="false" GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="製令單號">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbBOMID" runat="server" Text='<%#Eval("製令單號") %>' OnClick="lbBOMID_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm-3">
                <asp:Label ID="lblProductionAmount" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-sm-3">
                <asp:Label ID="lblAvgCost" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-sm-12">
                <asp:GridView ID="gvMaterialList" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="grdResultWithFooter" OnDataBound="gvMaterialList_DataBound" OnRowCreated="gvMaterialList_RowCreated">                    
                    <Columns>
                        <asp:TemplateField HeaderText="品號">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("材料品號") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                    
                        <asp:TemplateField HeaderText="品名">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("材料品名") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="數量">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("數量") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="採購平均單價">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("成本") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="小記">
                            <ItemTemplate>
                                <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("小記") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

