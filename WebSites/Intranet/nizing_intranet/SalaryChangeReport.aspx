<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SalaryChangeReport.aspx.cs" Inherits="SalaryChangeReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>薪資異動查詢系統</h2>
    <div style="vertical-align:middle;">
        <asp:Label ID="Label3" runat="server" Text="查詢人員:"></asp:Label>
        <asp:DropDownList ID="ddlPersonnel" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="MV002" DataValueField="MV001">
            <asp:ListItem Value="all">全部人員</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NZConnectionString %>" SelectCommand="SELECT MV001, MV002
FROM CMSMV
WHERE MV022 LIKE N''">
        </asp:SqlDataSource>
        <div>
            <asp:Label ID="Label1" runat="server" Text="選擇起始查詢日期"></asp:Label>
            <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
            <asp:ImageButton ID="imgBtnStartCalendar" runat="server" Height="25px" ImageUrl="~/nizing_intranet/image/calendar-icon.png" Width="25px" />
            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyyMMdd" PopupButtonID="imgBtnStartCalendar" PopupPosition="Right" TargetControlID="txtStartDate" />
        </div>
        <br />
        <div>
            <asp:Label ID="Label2" runat="server" Text="選擇查詢結束日期"></asp:Label>
            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
            <asp:ImageButton ID="imgBtnEndCalendar" runat="server" Height="25px" ImageUrl="~/nizing_intranet/image/calendar-icon.png" Width="25px" />
            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyyMMdd" PopupButtonID="imgBtnEndCalendar" PopupPosition="Right" TargetControlID="txtEndDate" />
        </div>
    </div>
    <br />
    <div>
        <asp:Label ID="lblDateError" runat="server" CssClass="error-message" Text=""></asp:Label>
        <br />
        <asp:Button ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" />
        <asp:Button ID="btnExport" runat="server" Text="匯出Excel" OnClick="btnExport_Click" />
        <br />
        <asp:Label ID="lblRange" runat="server" Text=""></asp:Label>
    </div>
    <div style="width:100%;">
        <asp:GridView ID="grdReport" runat="server" CssClass="grdResult">
        </asp:GridView>   
    </div>
</asp:Content>

