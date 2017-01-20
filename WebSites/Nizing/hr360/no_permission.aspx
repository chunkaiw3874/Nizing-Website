<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Master.master" AutoEventWireup="true" CodeFile="no_permission.aspx.cs" Inherits="no_permission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        連線已逾時，請重新登入<br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">回登入頁</asp:LinkButton>
    </div>
</asp:Content>

