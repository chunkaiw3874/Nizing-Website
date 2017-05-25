<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SaleRecord.aspx.cs" Inherits="SaleRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="../Content/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap-datepicker.js"></script>
    <script src="../Scripts/locales/bootstrap-datepicker.zh-TW.min.js"></script>
    <%--<script src="../Scripts/bootstrap.js"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.datepicker').datepicker({
                language: 'zh-TW',
                format: 'yyyymmdd',
                autoclose: true,
                todayBtn: true,
                todayHighlight: true
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <span class="h2 col-xs-12">商品銷售單價明細</span>
    </div>
    <div>
        <div>
            <div class="row form-group">
                <div class="col-xs-3">
                    <%--<asp:Label ID="Label1" runat="server" Text="選擇起始查詢日期"></asp:Label>--%>
                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control datepicker" placeholder="起始查詢日期"></asp:TextBox>
                    <%--                <asp:ImageButton ID="imgBtnStartCalendar" runat="server" Height="25px" ImageUrl="~/nizing_intranet/image/calendar-icon.png" Width="25px" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" BehaviorID="calendarStart" runat="server" Format="yyyyMMdd" PopupButtonID="imgBtnStartCalendar" PopupPosition="Right" TargetControlID="txtStartDate" OnClientHidden="onCalendarHidden" OnClientShown="onCalendarShown" />--%>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-xs-3">
                    <%--<asp:Label ID="Label2" runat="server" Text="選擇查詢結束日期"></asp:Label>--%>
                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control datepicker" placeholder="結束查詢日期"></asp:TextBox>
                    <%--<asp:ImageButton ID="imgBtnEndCalendar" runat="server" Height="25px" ImageUrl="~/nizing_intranet/image/calendar-icon.png" Width="25px" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" BehaviorID="calendarEnd" runat="server" Format="yyyyMMdd" PopupButtonID="imgBtnEndCalendar" PopupPosition="Right" TargetControlID="txtEndDate" />--%>
                </div>
            </div>
            <div class="row form-group">
                <%--<div class="col-xs-1">
                <asp:Label ID="Label3" runat="server" Text="品號" CssClass="form-control"></asp:Label>
                    </div>--%>
                <div class="col-xs-3">
                    <asp:TextBox ID="txtPrdNo" runat="server" CssClass="form-control" placeholder="產品品號"></asp:TextBox>
                </div>
                <%--<div class="col-xs-1">
                <asp:Label ID="Label4" runat="server" Text="客戶名稱"></asp:Label>
                    </div>--%>
                <div class="col-xs-3">
                    <asp:TextBox ID="txtCustName" runat="server" CssClass="form-control" placeholder="客戶名稱"></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-xs-3">
                    <asp:CheckBox ID="ckbExactProdId" runat="server" Checked="false" Text="品號=" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
                </div>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-xs-2">
                <asp:Button ID="btnReport" runat="server" Text="產生報表" OnClick="btnReport_Click" CssClass="btn btn-success" />
            </div>
        </div>
        <br />
        <asp:Label ID="lblRange" runat="server"></asp:Label>
        <hr />
        <div class="row">
            <span class="col-xs-1">最低:</span>
            <asp:Label ID="lblMin" runat="server" CssClass="col-xs-1" Text=""></asp:Label>
        </div>
        <div class="row">
            <span class="col-xs-1">最高:</span>
            <asp:Label ID="lblMax" runat="server" CssClass="col-xs-1" Text=""></asp:Label>
        </div>
        <div class="row">
            <span class="col-xs-1">最常出現:</span>
            <asp:Label ID="lblMode" runat="server" CssClass="col-xs-1" Text=""></asp:Label>
        </div>
        <div class="row">
            <span class="col-xs-1">平均:</span>
            <asp:Label ID="lblAvg" runat="server" CssClass="col-xs-1" Text=""></asp:Label>
        </div>
        <hr />
        <div class="row">
            <div class="col-xs-12">
                <asp:GridView ID="grdReport" runat="server" CssClass="grdResult">
                </asp:GridView>
            </div>
        </div>
    </div>
    <%--<script type="text/javascript">
        function onCalendarShown() {
            var calStart = $find("calendarStart");
            var calEnd = $find("calendarEnd");

            calStart._switchMode("months", true);
            calEnd._switchMode("months", true);

            if (calStart._monthsBody) {
                for (var i = 0; i < calStart._monthsBody.rows.length; i++) {
                    var row = calStart._monthsBody.rows[i];
                    for (var j = 0; j < row.cells.length; j++) {
                        Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call);
                    }
                }
            }

            if (calEnd._monthsBody) {
                for (var i = 0; i < calEnd._monthsBody.rows.length; i++) {
                    var row = calEnd._monthsBody.rows[i];
                    for (var j = 0; j < row.cells.length; j++) {
                        Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call);
                    }
                }
            }
        }

        function onCalendarHidden() {
            var calStart = $find("calendarStart");
            var calEnd = $find("calendarEnd");

            if (calStart._monthsBody) {
                for (var i = 0; i < calStart._monthsBody.rows.length; i++) {
                    var row = calStart._monthsBody.rows[i];
                    for (var j = 0; j < row.cells.length; j++) {
                        Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call);
                    }
                }
            }

            if (calEnd._monthsBody) {
                for (var i = 0; i < calEnd._monthsBody.rows.length; i++) {
                    var row = calEnd._monthsBody.rows[i];
                    for (var j = 0; j < row.cells.length; j++) {
                        Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call);
                    }
                }
            }
        }

        function call(eventElement) {
            var target = eventElement.target;
            switch (target.mode) {
                case "month":
                    var cal = $find("calendarStart");
                    cal._visibleDate = target.date;
                    cal.set_selectedDate(target.date);
                    cal._switchMonth(target.date);
                    cal._blur.post(true);
                    cal.raiseDateSelectionChanged();
                    break;
            }
        }
    </script>--%>
</asp:Content>

