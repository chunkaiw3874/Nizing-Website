<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="WorkDuration.aspx.cs" Inherits="WorkDuration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="WorkDuration">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <h2>人事年資一覽表</h2>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="年資結算日期"></asp:Label>
            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
            <asp:ImageButton ID="imgBtnEndCalendar" runat="server" Height="25px" ImageUrl="~/nizing_intranet/image/calendar-icon.png" Width="25px" />
            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" BehaviorID="calendarEnd" runat="server" Format="yyyyMMdd" PopupButtonID="imgBtnEndCalendar" PopupPosition="Right" TargetControlID="txtEndDate" />
            <br />
            <asp:CheckBox ID="chkDisplay" runat="server" Text="顯示已離職員工" Checked="false" />
            <br />
            <br />
            <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Button ID="btnReport" runat="server" Text="產生報表" OnClick="btnReport_Click" />
            <asp:Button ID="btnExport" runat="server" Text="匯出Excel" OnClick="btnExport_Click" />
        </div>
        <br />
        <div>
            <asp:Label ID="lblScope" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblEmpCount" runat="server" Text=""></asp:Label>
            <br />
            <asp:GridView ID="grdReport" runat="server" CssClass="grdResult">
            </asp:GridView>
        </div>
    </div>
</asp:Content>

