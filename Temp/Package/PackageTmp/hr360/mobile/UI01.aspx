<%@ Page Title="" Language="C#" MasterPageFile="~/hr360/mobile/master/greenMaster.master" AutoEventWireup="true" CodeFile="UI01.aspx.cs" Inherits="hr360_UI01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .view-icon {
            cursor: pointer;
        }
    </style>
    <script>
        function pageLoad(sender, args) {
            $('.view-icon').click(function () {
                var input = document.getElementById($(this).prev('input').attr('id'));
                if (input.type == 'password') {
                    input.type = 'text';
                    $(this).children('span').children('i').removeClass('fas fa-eye');
                    $(this).children('span').children('i').addClass('fas fa-eye-slash');
                }
                else {
                    input.type = 'password';
                    $(this).children('span').children('i').removeClass('fas fa-eye-slash');
                    $(this).children('span').children('i').addClass('fas fa-eye');
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
        <div class="mt-2 mb-2">
            <asp:Button ID="btnChangePassword" runat="server" CssClass="btn btn-info" Text="變更密碼"
                OnClick="btnChangePassword_Click" />
        </div>

        <asp:UpdatePanel ID="upChangePassword" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnChangePassword" />
                <asp:AsyncPostBackTrigger ControlID="btnChangePasswordSubmit" />
            </Triggers>
            <ContentTemplate>
                <%--<div runat="server" id="ChangePasswordForm">
                    <div class="input-group mb-1">
                        <div class="input-group-prepend">
                            <span class="input-group-text">舊密碼</span>
                        </div>
                        <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <div class="input-group-append view-icon">
                            <span class="input-group-text"><i class="fas fa-eye"></i></span>
                        </div>
                    </div>
                    <div class="input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text">新密碼</span>
                        </div>
                        <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <div class="input-group-append view-icon">
                            <span class="input-group-text"><i class="fas fa-eye"></i></span>
                        </div>
                    </div>
                </div>--%>
                <div class="modal fade" id="ChangePasswordForm" data-backdrop="static" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:Label ID="Label1" runat="server" Text="變更密碼"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            </div>
                            <div class="modal-body">
                                <div class="input-group mb-1">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">舊密碼</span>
                                    </div>
                                    <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                    <div class="input-group-append view-icon">
                                        <span class="input-group-text"><i class="fas fa-eye"></i></span>
                                    </div>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">新密碼</span>
                                    </div>
                                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password" MaxLength="20" placeholder="最長20字元，不接受特殊符號"></asp:TextBox>
                                    <div class="input-group-append view-icon">
                                        <span class="input-group-text"><i class="fas fa-eye"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnChangePasswordSubmit" runat="server" CssClass="btn btn-success w-100" Text="變更密碼"
                                    UseSubmitBehavior="false"
                                    data-dismiss="modal"                                    
                                    OnClick="btnChangePasswordSubmit_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
