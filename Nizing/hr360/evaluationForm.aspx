<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Master.master" AutoEventWireup="true" CodeFile="evaluationForm.aspx.cs" Inherits="hr360_evaluationForm" %>

<%--<%@ MasterType VirtualPath="~/master/HR360_Master.master" %>--%>
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
    <script>
        $(function () {
            $('.autosize').autosize();
        });

        $(document).ready(function () {
            jQuery.validator.addMethod('decimal', function (value, element) {
                return this.optional(element) || /^\d{0,2}(?:\.\d)?$/.test(value);
            }, "小數點最多一位"); //validate decimal places (1)
            jQuery.validator.addMethod('sRequired', $.validator.methods.required, "此為必填欄位"); //custom message for validating required field
            jQuery.validator.addMethod('sNumber', $.validator.methods.number, "請輸入正確的數字格式"); //custom message for validating number-only input
            jQuery.validator.addMethod('sRange', $.validator.methods.range, $.validator.format("數值必須在{0}與{1}之間")); //custom message for validating range
            jQuery.validator.addClassRules('numbers-only', {
                sRequired: true,
                sNumber: true,
                sRange: [1, 10],
                decimal: true
            }); //intialize validation
            $('#form1').validate({
                errorClass: "error-class",
                validClass: "valid-class",
                submitHandler: function (form) {
                    form.submit();
                }
            });

            $(document).on('blur', '.add-number', function () {
                $('.final-score').html(sumUp().toFixed(2).toString());
                $('#<%=hfFinalScore.ClientID%>').val($('.final-score').html());
            });

            function sumUp() {
                var sum = 0;
                var i = 1;
                var weightSum = 0;

                $('.add-number').each(function () {
                    var score = $('.col' + i + '_5').val();
                    var weight = $('.col' + i + '_3').text();
                    weightSum += parseFloat(weight);
                    sum += (score * weight);
                    i++;
                });
                return sum / (weightSum);
            };
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
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
                    <br />
                    評核日期:
                <asp:Label ID="lblEvalDate" runat="server" Text="Date"></asp:Label>
                    <br />
                    評核類別:
                    <asp:Label ID="lblEvalType" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <div id="question">
            <div class="row">
                <div class="col-xs-12 subtitle border">
                    考核項目
                </div>
            </div>
            <div class="row">
                <div class="col-xs-1 border">
                    <span class="form-control text-center">#</span>
                </div>
                <div class="col-xs-2 border">
                    <span class="form-control text-center">分類</span>
                </div>
                <div class="col-xs-1 border">
                    <span class="form-control text-center">權重</span>
                </div>
                <div class="col-xs-6 border">
                    <span class="form-control text-center">問題</span>
                </div>
                <div class="col-xs-2 border">
                    <span class="form-control text-center">分數</span>
                </div>
                <%--                <div class="col-xs-1 border">
                    <span class="form-control text-center">加權分數</span>
                </div>--%>
<%--                <div class="col-xs-2 border">
                    <span class="form-control text-center">評語</span>
                </div>--%>
            </div>
            <div id="Load_Question" runat="server">
            </div>
            <div class="row">
                <div class="col-xs-12 subtitle border">
                    分數
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 border">
                    <div class="col-xs-10">
                    </div>
                    <div class="col-xs-2">
                        <asp:Label ID="lblFinalScore" runat="server" Text="" CssClass="final-score"></asp:Label>
                        /10
                        <asp:HiddenField ID="hfFinalScore" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 border">
                    * 評分範圍:  分數為1~10分，最多小數點後一位。<br />  
                    * 評分標準: 0:極差/完全沒有; 1~3:差/有很大的進步空間; 4~6:普通/有待加強; 7~9:良好/已經很好，但可再進步; 10:極好/非常好
                </div>
            </div>
        </div>
        <div id="record">
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
        </div>
        <div id="comment" runat="server">
            <!--非自評的話，需於code behind加上一個動態div for 評核者 comment-->
            <div class="row">
                <div class="col-xs-12 subtitle border">
                    自評評語
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 border">
                    <asp:TextBox ID="txtSelfComment" runat="server" placeholder="請寫下您今年度對公司的額外貢獻(旁人所不知的貢獻)" TextMode="MultiLine" CssClass="form-control no-resize autosize"></asp:TextBox>
                </div>
            </div>
        </div>
        <!--放置支援圖片-->
        <div id="image">
            <%--<div class="row">
                <div class="col-xs-8 border" style="border-right:none;">
                    <img src="image/assessment/2016_production_efficiency.jpg" style="max-width:100%;" />
                </div>
                <div class="col-xs-4 border" style="border-left:none;">
                    <img src="image/assessment/2016_scrap_amount.jpg" style="max-width:100%;" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 border">
                    <img src="image/assessment/2016_production_amount.jpg" style="max-width:100%" />
                </div>
            </div>            --%>
        </div>
        <div>
            <div class="row" style="margin-top: 5px;">
                <div class="col-xs-9">
                </div>
                <div class="col-xs-1">
                </div>
                <div class="col-xs-1">
                </div>
                <div class="col-xs-1">
                    <asp:Button ID="btnSubmit" runat="server" Text="送出" CssClass="btn btn-lg btn-success" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>        
        <div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

