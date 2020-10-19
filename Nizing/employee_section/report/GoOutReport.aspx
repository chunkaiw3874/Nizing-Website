<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="GoOutReport.aspx.cs" Inherits="employee_section_report_GoOutReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <h4>外出報表</h4>
    </div>
    <div class="input-group">
        <div class="input-group-prepend">
            <div class="input-group-text">
                <i class="fas fa-search"></i>
            </div>
        </div>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
</asp:Content>

