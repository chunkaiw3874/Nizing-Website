<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="hr360_mobile_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="../../Scripts/jquery-2.1.4.min.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/bootstrap-datepicker.min.js"></script>
    <link href="../../css/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            font-family: 'Adobe Fan Heiti Std';
        }

        .jumbotron {
            background-image: url(image/login_jumbotron_line_friends.png);
            background-repeat: no-repeat;
            height: 308px;
        }

            .jumbotron h1 {
                color: #ffffff;
            }

        .green {
            background-color: #01C82D;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" defaultfocus="txtUsername" defaultbutton="btnLogin">
        <div class="jumbotron green">
            <div class="container">
                <h1>歡迎來到日進HR360系統</h1>
                <asp:Button ID="Button2" runat="server" Text="回到日進網站" CssClass="btn btn-primary btn-lg green" />
            </div>
        </div>
        <div class="container">
            <div class="row form-group">
                <div class="col-sm-5"></div>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtUsername" runat="server" placeholder="登入名稱" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-sm-5"></div>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="密碼" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-5"></div>
                <div class="col-sm-3">
                    <asp:Button ID="btnLogin" runat="server" Text="登入" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-5"></div>
                <div class="col-sm-3">
                    <asp:Label ID="lblLoginMessage" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
