<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/employee_section/report/image/button/dept/SD.png" /></li>
            </ul>
            <ul>
                <li>
                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/employee_section/report/image/button/dept/SD-1.png" PostBackUrl="~/revivify_employee_section/report/SD01.aspx" /></li>
                <li>
            </ul>
        </div>
    </div>
</asp:Content>
