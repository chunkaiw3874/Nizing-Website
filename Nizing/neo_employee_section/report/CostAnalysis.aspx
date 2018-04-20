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
                        <asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn btn-success" />
                    </span>
                </div>
            </div>
            <div class="col-sm-6">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-sm-3">
                製令單號
            </div>
            <div class="col-sm-3">
            <table id="tbBomList" class="table" runat="server">
                <tr>
                    <td>1</td>
                </tr>
                <tr>
                    <td>1</td>
                </tr>
                <tr>
                    <td>1</td>
                </tr>
            </table>
                </div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                abc
            </div>
        </div>
    </div>

</asp:Content>

