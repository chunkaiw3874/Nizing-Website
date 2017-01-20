<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Master.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="banner">
        <div style="width:100%;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~\hr360\image\banner\login_page_banner.png" />
        </div>
    </div>
    <div style="-webkit-box-sizing:border-box;-moz-box-sizing: border-box;box-sizing: border-box;min-width:1100px;max-width:100%;text-align:center;padding-left:875px;">
        <asp:ImageButton ID="ImageButton1" runat="server" Width="100px" ImageUrl="~\hr360\image\button\home_web.png" PostBackUrl="~\default.aspx" />
    </div>
    <div style="width:100%">
        <asp:Panel ID="Panel1" runat="server" DefaultButton="HR360Login$LoginButton">
            <div id="APR_Login_Box">
                <asp:Login ID="HR360Login" runat="server" LoginButtonText="登入" PasswordLabelText="密碼:" UserNameLabelText="使用者代號:" TitleText="" OnLoggingIn="HR360Login_LoggingIn" DisplayRememberMe="False" CssClass="login" LoginButtonType="Button">
                    <LabelStyle HorizontalAlign="Justify" />
                    <LayoutTemplate>
                        <table>
                            <tr>
                                <td style="text-align:left;">請登入帳號</td>
                            </tr>
                            <tr>                                    
                                <td>
                                    <asp:TextBox ID="UserName" runat="server" placeholder="輸入使用者代號" width="200"></asp:TextBox>                                        
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="請輸入使用者名稱" ToolTip="請輸入使用者名稱" ValidationGroup="HR360Login">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="height:10px;"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" placeholder="輸入密碼" width="200"></asp:TextBox>                                        
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="請輸入密碼" ToolTip="請輸入密碼" ValidationGroup="HR360Login">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-top:10px;">
                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" CssClass="login-button" Text="登入" ValidationGroup="HR360Login" />
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                </asp:Login>
                <br />
                <br />
                <asp:Label ID="lblErrorMessage" CssClass="error-message" runat="server" Text=""></asp:Label>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

