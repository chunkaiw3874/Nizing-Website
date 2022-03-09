<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="hr360_mobile_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="icon" href="data:," />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous" />
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.bundle.min.js" integrity="sha384-1CmrxMRARb6aLqgBO7yyAxTOQE2AKb9GfXnEo760AUcUmFx3ibVJJAzGytlQcNXd" crossorigin="anonymous"></script>
    <script src="https://kit.fontawesome.com/32e9a84b4a.js" crossorigin="anonymous"></script>
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
            <h1>歡迎來到日進HR360系統</h1>
            <asp:Button ID="btnNizingWebsite" runat="server" Text="回到日進網站" CssClass="btn btn-primary btn-lg green"
                OnClick="btnNizingWebsite_Click" />
        </div>
        <div class="container">
            <div class="row form-group">
                <div class="col-sm-6 offset-sm-3">
                    <asp:TextBox ID="txtUsername" runat="server" placeholder="登入名稱" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-sm-6 offset-sm-3">
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="密碼" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-sm-6 offset-sm-3">
                    <asp:DropDownList ID="ddlCompany" runat="server" CssClass="custom-select"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6 offset-sm-3">
                    <asp:Button ID="btnLogin" runat="server" Text="登入" CssClass="btn btn-primary w-100" OnClick="btnLogin_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6 offset-sm-3">
                    <asp:Label ID="lblLoginMessage" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
