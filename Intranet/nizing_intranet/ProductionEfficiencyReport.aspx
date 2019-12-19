<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ProductionEfficiencyReport.aspx.cs" Inherits="ProductionEfficiencyReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <div>
            <h2>生產效率報表</h2>
        </div>
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <%--<asp:RadioButton ID="rdoYear" runat="server" Text="年報表" GroupName="R1" />
            <asp:RadioButton ID="rdoMonth" runat="server" Text="月報表" Checked="true" GroupName="R1" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="選擇起始查詢日期"></asp:Label>
            <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
            <asp:ImageButton ID="imgBtnStartCalendar" runat="server" Height="25px" ImageUrl="~/nizing_intranet/image/calendar-icon.png" Width="25px" />
            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyyMMdd" PopupButtonID="imgBtnStartCalendar" PopupPosition="Right" TargetControlID="txtStartDate" />
            <br />
            <asp:Label ID="Label2" runat="server" Text="選擇查詢結束日期"></asp:Label>
            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
            <asp:ImageButton ID="imgBtnEndCalendar" runat="server" Height="25px" ImageUrl="~/nizing_intranet/image/calendar-icon.png" Width="25px" />
            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyyMMdd" PopupButtonID="imgBtnEndCalendar" PopupPosition="Right" TargetControlID="txtEndDate" />--%>
            <div>
                <asp:RadioButton ID="rdoYear" runat="server" Text="年報表" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" />
                <asp:RadioButton ID="rdoMonth" runat="server" Text="月報表" Checked="true" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" />
            </div>
            <br />
            <div>
                <div>
                    開始查詢時間
                    <asp:DropDownList ID="ddlStartYear" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlStartMonth" runat="server">
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>            
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div>
                    結束查詢時間
                    <asp:DropDownList ID="ddlEndYear" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlEndMonth" runat="server">
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>            
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>            
            <br />
            <asp:DropDownList ID="ddlDept" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="MD002" DataValueField="MD001">                
                <asp:ListItem Value="all">全部部門</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NZConnectionString %>" SelectCommand="SELECT [MD001], [MD002] FROM [CMSMD]"></asp:SqlDataSource>
            <br />
            <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
            <br />
            <asp:Button ID="btnReport" runat="server" Text="產生報表" OnClick="btnReport_Click" />
            <asp:Button ID="btnExport" runat="server" Text="匯出Excel" OnClick="btnExport_Click" />
        </div>
        <br />
        <div>
            <ul>
                <li style="color:red;">*當月生產情況未至當月15日前不一定出現，如需了解當月生產數量，請使用"每月產量排名表"報表</li>
                <li style="color:red;">*依現行系統制度，跨部門支援時，時數仍會算在人員隸屬的部門上，請各組長自行記錄組員跨部門支援時數，並於每月KPI表中自行調整計算正確的生產效能</li>
            </ul>
        </div>
        <br />
        <div>
            <asp:Label ID="lblRange" runat="server"></asp:Label>
            <br />
            <asp:GridView ID="grdReport" runat="server" CssClass="grdResult">
            </asp:GridView>
        </div>
<%--        <div>
            <ul>
                <li>使用說明:</li>
                <li>月報表如結束日期非月底，則當月效能會無法計算</li>
                <li>年報表以所選擇日期的年份為查詢條件(2010/05/31~2014/06/30的年報表查詢結果為2010/01/01~2014/12/31)</li>
                <li>年報表中本年份的產能及效能計算計算至已過完的月份(ex.2015/7/20做2014/03/21~2015/07/20年報表查詢，2015年出來的數字是至2015/06/30)</li>
            </ul>
        </div>--%>
    </div>
</asp:Content>

