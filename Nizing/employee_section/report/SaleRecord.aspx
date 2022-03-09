<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="SaleRecord.aspx.cs" Inherits="SaleRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <h2>商品銷售單價明細</h2>
    </div>
    <div>
        <div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="選擇起始查詢日期"></asp:Label>
                <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                <asp:ImageButton ID="imgBtnStartCalendar" runat="server" Height="25px" ImageUrl="~/employee_section/report/image/calendar-icon.png" Width="25px" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" BehaviorID="calendarStart" runat="server" Format="yyyyMMdd" PopupButtonID="imgBtnStartCalendar" PopupPosition="Right" TargetControlID="txtStartDate" OnClientHidden="onCalendarHidden" OnClientShown="onCalendarShown" />
            </div>
            <br />
            <div>
                <asp:Label ID="Label2" runat="server" Text="選擇查詢結束日期"></asp:Label>
                <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                <asp:ImageButton ID="imgBtnEndCalendar" runat="server" Height="25px" ImageUrl="~/employee_section/report/image/calendar-icon.png" Width="25px" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" BehaviorID="calendarEnd" runat="server" Format="yyyyMMdd" PopupButtonID="imgBtnEndCalendar" PopupPosition="Right" TargetControlID="txtEndDate" />
            </div>
            <br />
            <div>
                <asp:Label ID="Label3" runat="server" Text="品號"></asp:Label>
                <asp:TextBox ID="txtPrdNo" runat="server"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="客戶名稱"></asp:Label>
                <asp:TextBox ID="txtCustName" runat="server"></asp:TextBox>
            </div>
            <br />
            <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Button ID="btnReport" runat="server" Text="產生報表" OnClick="btnReport_Click" />
        </div>
        <br />
            <asp:Label ID="lblRange" runat="server"></asp:Label>
            <asp:GridView ID="grdReport" runat="server" CssClass="grdResult">
            </asp:GridView>
    </div>
    <script type="text/javascript">
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
    </script>
</asp:Content>

