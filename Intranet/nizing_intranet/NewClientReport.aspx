<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="NewClientReport.aspx.cs" Inherits="NewClientReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="NewClientReport">
        <div>
            <h2>新客戶成交報表</h2>
        </div>
        <div>
            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:Label ID="Label1" runat="server" Text="選擇起始查詢日期"></asp:Label>
                <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                <asp:ImageButton ID="imgBtnStartCalendar" runat="server" Height="25px" ImageUrl="~/nizing_intranet/image/calendar-icon.png" Width="25px" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyyMMdd" PopupButtonID="imgBtnStartCalendar" PopupPosition="Right" TargetControlID="txtStartDate" />
                <br />
                <asp:Label ID="Label2" runat="server" Text="選擇查詢結束日期"></asp:Label>
                <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                <asp:ImageButton ID="imgBtnEndCalendar" runat="server" Height="25px" ImageUrl="~/nizing_intranet/image/calendar-icon.png" Width="25px" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyyMMdd" PopupButtonID="imgBtnEndCalendar" PopupPosition="Right" TargetControlID="txtEndDate" />
            </div>
            <br />
            <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
            <br />
            <asp:Button ID="btnReport" runat="server" Text="產生報表" OnClick="btnReport_Click" />
            <asp:Button ID="btnExport" runat="server" Text="匯出Excel" OnClick="btnExport_Click" />
        </div>
        <br />
        <div id="search-result">
            <asp:Label ID="lblRange" runat="server"></asp:Label>
            <br />
            <div style="width:500px;">
                <asp:GridView ID="grdSum" runat="server" CssClass="grdResult">
                </asp:GridView>
                <br />
                <asp:GridView ID="grdDetail" runat="server" CssClass="grdResult">
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

