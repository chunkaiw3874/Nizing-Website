<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Master.master" AutoEventWireup="true" CodeFile="evaluationBonus.aspx.cs" Inherits="hr360_evaluationBonus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/text.area.auto.adjust.js"></script>
    <style>
        body {
            margin-top: 10px;
            margin-bottom: 10px;
        }

        .title {
            font-weight: bold;
            font-size: 1.5em;
            text-align: center;
        }

        .subtitle {
            font-weight: bold;
            text-align: center;
            background-color: #337ab7;
            color: #ffffff;
        }

        .border {
            border: solid 1px #337ab7;
            border-top: 0px;
        }

        .row {
            display: -webkit-box;
            display: -webkit-flex;
            display: -ms-flexbox;
            display: flex;
            flex-wrap: wrap;
        }

        .form-control {
            border: none;
        }

        .no-resize {
            resize: none;
        }

        .error-class {
            color: #FF0000; /* red */
        }

        .valid-class {
            /*color:#00CC00;*/ /* green */
        }

        .final-score {
            font-weight: bold;
            color: green;
            font-size: 2em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div id="info" style="margin-bottom: 10px;">
            <div class="row">
                <div class="col-xs-1">
                    員工編號:
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="lblEmpID" runat="server" Text="ID"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-1">
                    員工姓名:
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="lblEmpName" runat="server" Text="NAME"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-1">
                    評核年度:
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="lblEvalYear" runat="server" Text="YEAR"></asp:Label>
                </div>
            </div>
        </div>
        <div id="content">
            <div class="row">
                <div class="col-xs-3 border" style="border-top: solid 1px #337ab7;">
                    考績金額:
                </div>
                <div class="col-xs-3 border" style="border-top: solid 1px #337ab7;">
                    <asp:TextBox ID="txtAssessmentBonus" runat="server" CssClass="form-control" placeholder="金額"></asp:TextBox>
                </div>
                <div class="col-xs-3 border" style="border-top: solid 1px #337ab7;">
                    <asp:TextBox ID="txtAssessmentMemo" runat="server" CssClass="form-control" placeholder="備註"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 border">
                    休假未修:
                </div>
                <div class="col-xs-3 border">
                    <asp:TextBox ID="txtUnusedDayOffBonus" runat="server" CssClass="form-control" placeholder="金額"></asp:TextBox>
                </div>
                <div class="col-xs-3 border">
                    <asp:TextBox ID="txtUnusedDayOffMemo" runat="server" CssClass="form-control" placeholder="備註"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 border">
                    年度全勤:
                </div>
                <div class="col-xs-3 border">
                    <asp:TextBox ID="txtAttendanceBonus" runat="server" CssClass="form-control" placeholder="金額"></asp:TextBox>
                </div>
                <div class="col-xs-3 border">
                    <asp:TextBox ID="txtAttendanceMemo" runat="server" CssClass="form-control" placeholder="備註"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 border">
                    年度獎懲::
                </div>
                <div class="col-xs-3 border">
                    <asp:TextBox ID="txtRnPBonus" runat="server" CssClass="form-control" placeholder="金額"></asp:TextBox>
                </div>
                <div class="col-xs-3 border">
                    <asp:TextBox ID="txtRnPMemo" runat="server" CssClass="form-control" placeholder="備註"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 border">
                    其他加項:
                </div>
                <div class="col-xs-3 border">
                    <asp:TextBox ID="txtOtherBonus" runat="server" CssClass="form-control" placeholder="金額"></asp:TextBox>
                </div>
                <div class="col-xs-3 border">
                    <asp:TextBox ID="txtOtherBonusMemo" runat="server" CssClass="form-control" placeholder="備註"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 border">
                    其他減項:
                </div>
                <div class="col-xs-3 border">
                    <asp:TextBox ID="txtOtherDeduction" runat="server" CssClass="form-control" placeholder="金額"></asp:TextBox>
                </div>
                <div class="col-xs-3 border">
                    <asp:TextBox ID="txtOtherDeductionMemo" runat="server" CssClass="form-control" placeholder="備註"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 border">
                    總金額:
                </div>
                <div class="col-xs-3 border">
                    <asp:Label ID="lblFinalBonus" runat="server" Text="0" CssClass="form-control"></asp:Label>
                </div>
                <div class="col-xs-3 border">
                    &nbsp;
                </div>
            </div>
        </div>
        <div>
            <%--<div class="row">
                <div class="col-xs-12">
                    <asp:Label ID="lblError" runat="server" Text="" CssClass="error-message"></asp:Label>
                </div>
            </div>--%>
            <div class="row" style="margin-top: 10px;">
                <div class="col-xs-3"></div>
                <div class="col-xs-3">
                    <asp:Button ID="btnCalculate" runat="server" Text="計算總金額" CssClass="btn btn-lg btn-success" OnClick="btnCalculate_Click" />
                </div>
                <div class="col-xs-3">
                    <asp:Button ID="btnSubmit" runat="server" Text="送出" CssClass="btn btn-lg btn-success" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

