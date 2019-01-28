<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Master.master" AutoEventWireup="true" CodeFile="evaluationFormView.aspx.cs" Inherits="hr360_evaluationFormView" %>

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

        .text-color-green {
            color: green;
        }
        .test-area{
            visibility:hidden;
        }
        .rnp-textbox{
            border:none;
            resize:none;
            background-color:white;
            width:100%;
        }
        @media print {
            body *{
                visibility: hidden;
            }
            /*.printarea * {
                visibility: visible;
                overflow:visible;
            }*/
            .print-area *{
                visibility:visible;
                font-size:1px;
            }
            .print-area {
                
            }
        }
    </style>
    <script>
        $(function () {
            $('.autosize').autosize();
        });
        //$(function () {
        //    var div = $('#display-area').clone();
        //    $('#print-area').html(div);
        //})
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="display-area" class="container print-area">
        <div id="info">
            <div class="row" style="border-bottom: solid 1px #337ab7;">
                <div class="col-xs-2">
                    員工編號:
                <asp:Label ID="lblEmpID" runat="server" Text="ID"></asp:Label>
                    <br />
                    員工姓名:
                <asp:Label ID="lblEmpName" runat="server" Text="Name"></asp:Label>
                    <br />
                    職務名稱:
                <asp:Label ID="lblEmpJob" runat="server" Text="Job"></asp:Label>
                    <br />
                    工作年資:
                <asp:Label ID="lblEmpWorkYear" runat="server" Text="年資"></asp:Label>
                </div>
                <div class="col-xs-8 title">
                    年度考核表<br />
                    Annual Key Performance Indicator
                </div>
                <div class="col-xs-2">
                    評核年度:
                <asp:Label ID="lblEvalYear" runat="server" Text="Year"></asp:Label>
                </div>
            </div>
        </div>
        <div id="question">
            <div class="row">
                <div class="col-xs-12 subtitle border">
                    考核項目
                </div>
            </div>
            <div class="row" id="divQuestionTitleRow" runat="server">
            </div>
            <div id="divQuestionBodyRow" runat="server">
            </div>
        </div>
        <div class="row" id="finalScoreRow" runat="server">
        </div>        
        <div class="row">
            <div class="col-xs-12 border">
                * 評分範圍:  分數為1~10分，最多小數點後一位。<br />  
                * 評分標準: 0:極差/完全沒有; 1~3:差/有很大的進步空間; 4~6:普通/有待加強; 7~9:良好/已經很好，但可再進步; 10:極好/非常好
            </div>
        </div>
        <div id="attendanceRecord" runat="server">
            <div class="row">
                <div class="col-xs-12 subtitle border">
                    年度考勤紀錄
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border" style="text-align:center;">
                    假別
                </div>
                <div class="col-xs-2 border" style="text-align:center;">
                    時數
                </div>
                <div class="col-xs-2 border" style="text-align:center;">
                    未修完時數
                </div>
                <div class="col-xs-2 border" style="text-align:center;">
                    加扣基底
                </div>
                <div class="col-xs-2 border" style="text-align:center;">
                    單位
                </div>
                <div class="col-xs-2 border" style="text-align:center;">
                    小計
                </div>
            </div>
            <%--Records added programmatically here --%>            
        </div>
        <div id="attendanceRecordCalculation">
            <div class="row" style="border-top: solid 1px #337ab7;">
                <div class="col-xs-2 border" style="text-align:center;">
                    缺勤時數小計
                </div>
                <div class="col-xs-2 border" style="text-align:center;">
                    <asp:Label ID="lblDayOffSum" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-4 border"></div>
                <div class="col-xs-2 border" style="text-align:right">合計:</div>
                <div class="col-xs-2 border" style="text-align:right">
                    <asp:Label ID="lblDayOffValueSum" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-8 border"></div>
                <div class="col-xs-2 border" style="text-align:right">實際出勤時數:</div>
                <div class="col-xs-2 border" style="text-align:right">
                    <asp:Label ID="lblActualAttendance" runat="server" Text="&nbsp"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-8 border"></div>
                <div class="col-xs-2 border" style="text-align:right">應出勤時數:</div>
                <div class="col-xs-2 border" style="text-align:right">
                    <asp:Label ID="lblExpectedAttendance" runat="server" Text="&nbsp"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-8 border"></div>
                <div class="col-xs-2 border" style="text-align:right">出勤分數:</div>
                <div class="col-xs-2 border" style="text-align:right">
                    <asp:Label ID="lblAttendanceScore" runat="server" Text="&nbsp"></asp:Label>
                </div>
            </div>
        </div>
        <div id="RnPRecord" runat="server">
            <div class="row">
                <div class="col-xs-12 subtitle border">
                    年度獎懲紀錄
                </div>
            </div>
            <div class="row">
                <div class="col-xs-1 border" style="text-align:center;">
                    項次
                </div>
                <div class="col-xs-1 border" style="text-align:center;">
                    事件分類
                </div>
                <div class="col-xs-3 border" style="text-align:center;">
                    事件內容
                </div>
                <div class="col-xs-5 border" style="text-align:center;">
                    獎懲內容
                </div>
                <div class="col-xs-1 border" style="text-align:center;">
                    核單狀態
                </div>
                <div class="col-xs-1 border" style="text-align:center;">
                    備註
                </div>
            </div>
            <%--Records added programmatically here --%> 
        </div>
        <div id="RnPCalculation">
            <div class="row">
                <div class="col-xs-8 border" style="text-align:right;">
                    小計:
                </div>
                <div class="col-xs-1 border" style="text-align:center">
                    <asp:Label ID="lblFinalRnPScore" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-xs-3 border"></div>
            </div>
        </div>
        <%--<div id="attendanceRecord">
            <div class="row">
                <div class="col-xs-6 subtitle border">
                    年度考勤紀錄
                </div>
                <div class="col-xs-6 subtitle border">
                    年度獎懲紀錄
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName1" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff1" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit1" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    嘉獎
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblRnP1" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    次
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName2" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff2" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit2" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    小功
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblRnP2" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    次
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName3" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff3" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit3" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    大功
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblRnP3" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    次
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName4" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff4" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit4" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    申誡
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblRnP4" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    次
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName5" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff5" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit5" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    小過
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblRnP5" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    次
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName6" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff6" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit6" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    大過
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblRnP6" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    次
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName7" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff7" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit7" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName8" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff8" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit8" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName9" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff9" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit9" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName10" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff10" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit10" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName11" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff11" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit11" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName12" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff12" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit12" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName13" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff13" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit13" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName14" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff14" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit14" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName15" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff15" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit15" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName16" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff16" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit16" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName17" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff17" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit17" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName18" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff18" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit18" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName19" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff19" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit19" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName20" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff20" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit20" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffName21" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOff21" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnit21" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row" style="border-top: solid 1px #337ab7;">
                <div class="col-xs-2 border">
                    缺勤時數小計
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffSum" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    時
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    年度出勤率
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblOnJobPercent" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    %
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 border">
                    未使用特/補休時數
                </div>
                <div class="col-xs-2 border">
                    <asp:Label ID="lblDayOffUnused" runat="server" Text="&nbsp"></asp:Label>
                </div>
                <div class="col-xs-2 border">
                    時
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
                <div class="col-xs-2 border">
                    <br />
                </div>
            </div>
        </div>--%>
        <div id="comment" runat="server">
            <!--非自評的話，需於code behind加上一個動態div for 評核者 comment-->
            <div class="row">
                <div class="col-xs-12 subtitle border">
                    自評評語
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 border">
                    <asp:TextBox ID="txtSelfComment" runat="server" TextMode="MultiLine" ReadOnly="true" CssClass="form-control no-resize autosize"></asp:TextBox>
                </div>
            </div>
        </div>
        <div id="div0067_comment" runat="server">
            <div class="row">
                <div class="col-xs-12 subtitle border">
                    吉田康森評語
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 border">
                    <div>
                        <asp:TextBox ID="txt0067Comment" TextMode="MultiLine" CssClass="form-control no-resize autosize" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div style="float:right;">
                        <asp:Button ID="btnSave0067Comment" runat="server" Text="儲存評語" CssClass="btn btn-success" OnClick="btnSaveComment_Click" Visible="false"/>
                    </div>
                </div>
            </div>
        </div>
        <div id="div0007_comment" runat="server">
            <div class="row">
                <div class="col-xs-12 subtitle border">
                    Chrissy評語
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 border">
                    <div>
                        <asp:TextBox ID="txt0007Comment" TextMode="MultiLine" CssClass="form-control no-resize autosize" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div style="float:right;">
                        <asp:Button ID="btnSave0007Comment" runat="server" Text="儲存評語" CssClass="btn btn-success" OnClick="btnSaveComment_Click" Visible="false"/>
                    </div>
                </div>
            </div>
        </div>
        <div id="div0006_comment" runat="server">
            <div class="row">
                <div class="col-xs-12 subtitle border">
                    Kelven評語
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 border">
                    <div>
                        <asp:TextBox ID="txt0006Comment" TextMode="MultiLine" CssClass="form-control no-resize autosize" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div style="float:right;">
                        <asp:Button ID="btnSave0006Comment" runat="server" Text="儲存評語" CssClass="btn btn-success" OnClick="btnSaveComment_Click"  Visible="false"/>
                    </div>
                </div>
            </div>
        </div>
        <!--放置支援圖片-->
        <div id="image">
            <%--<div class="row">
                <div class="col-xs-8 border" style="border-right:none;">
                    <img src="image/assessment/2016/2016_production_efficiency.jpg" style="max-width:100%;" />
                </div>
                <div class="col-xs-4 border" style="border-left:none;">
                    <img src="image/assessment/2016/2016_scrap_amount.jpg" style="max-width:100%;" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 border">
                    <img src="image/assessment/2016/2016_production_amount.jpg" style="max-width:100%" />
                </div>
            </div> --%>
        </div>
    </div>
</asp:Content>

