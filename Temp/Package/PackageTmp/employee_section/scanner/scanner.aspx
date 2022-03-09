<%@ Page Language="C#" AutoEventWireup="true" CodeFile="scanner.aspx.cs" Inherits="employee_section_scanner_scanner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;" />
<%--    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.bundle.min.js" integrity="sha384-1CmrxMRARb6aLqgBO7yyAxTOQE2AKb9GfXnEo760AUcUmFx3ibVJJAzGytlQcNXd" crossorigin="anonymous"></script>--%>
    <script src="https://rawgit.com/sitepoint-editors/jsqrcode/master/src/qr_packed.js"></script>
    <style>
        html {
            height: 100%;
        }

        body {
            font-family: sans-serif;
            padding: 0 10px;
            height: 100%;
            background: black;
            margin: 0;
        }

        h1 {
            color: white;
            margin: 0;
            padding: 15px;
        }

        #container {
            text-align: center;
            margin: 0;
        }

        #qr-canvas {
            margin: auto;
            width: calc(100% - 20px);
            max-width: 400px;
        }

        #btn-scan-qr {
            cursor: pointer;
        }

            #btn-scan-qr img {
                height: 10em;
                padding: 15px;
                margin: 15px;
                background: white;
            }

        #qr-result {
            font-size: 1.2em;
            margin: 20px auto;
            padding: 20px;
            max-width: 700px;
            background-color: white;
        }
    </style>
            
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <h1>QR Code Scanner</h1>

            <a id="btn-scan-qr">
                <img src="https://dab1nmslvvntp.cloudfront.net/wp-content/uploads/2017/07/1499401426qr_icon.svg" />
                <a />

                <canvas hidden="" id="qr-canvas"></canvas>

                <div id="qr-result" hidden="">
                    <b>Data:</b> <span id="outputData"></span>
                </div>
        </div>
        <script src="src/qrCodeReader.js"></script>

    </form>
</body>
</html>
