<%@ Page Title="" Language="C#" MasterPageFile="~/hr360/mobile/master/greenMaster.master" AutoEventWireup="true" CodeFile="UI01.aspx.cs" Inherits="hr360_UI01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                <div>
                    <asp:Label ID="lblEmployee_Id" runat="server"></asp:Label>
                    <asp:Label ID="lblEmployee_Name" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblEmployee_Department" runat="server"></asp:Label>
                    <asp:Label ID="lblEmployee_Rank" runat="server"></asp:Label>
                </div>
                <asp:Image ID="imgAvatar" runat="server" CssClass="img-fluid img-thumbnail w-25" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div>
                    <span class="text-info">到職日期:</span>
                    <asp:Label ID="lblStartDate" runat="server"></asp:Label>
                </div>
                <div class="border-bottom">
                    <span class="text-info">手機:</span>
                    <asp:Label ID="lblCell" runat="server"></asp:Label>
                </div>
                <div class="border-bottom">
                    <span class="text-info">電話:</span>
                    <asp:Label ID="lblTel" runat="server"></asp:Label>
                </div>
                <div class="border-bottom">
                    <span class="text-info">戶籍地址:</span>
                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                </div>
                <div class="border-bottom">
                    <span class="text-info">通訊地址:</span>
                    <asp:Label ID="lblResidentialAddress" runat="server"></asp:Label>
                </div>
                <div class="border-bottom">
                    <span class="text-info">E-Mail:</span>
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-md-6">
                <div class="border-bottom">
                    <span class="text-info">生日:</span>
                    <asp:Label ID="lblBirthDate" runat="server"></asp:Label>
                </div>
                <div class="border-bottom">
                    <span class="text-info">星座:</span>
                    <asp:Label ID="lblHoroscope" runat="server"></asp:Label>
                </div>
                <div class="border-bottom">
                    <span class="text-info">Line ID:</span>
                    <asp:Label ID="lblLine" runat="server"></asp:Label>
                </div>
                <div class="border-bottom">
                    <span class="text-info">銀行薪轉代號:</span>
                    <asp:Label ID="lblBankId" runat="server"></asp:Label>
                </div>
                <div class="border-bottom">
                    <span class="text-info">銀行薪轉帳號:</span>
                    <asp:Label ID="lblBankAccount" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="mt-2">
            <asp:Button ID="btnChangePassword" runat="server" CssClass="btn btn-info" Text="變更密碼"
                OnClick="btnChangePassword_Click"/>
        </div>
    </div>
</asp:Content>
