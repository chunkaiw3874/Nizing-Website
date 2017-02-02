<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="SD01.aspx.cs" Inherits="SD01" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="NetSale">
        <div>
            <h2>銷售淨額報表</h2>
        </div>
        <div>
            <div>
                <div>
                    <table id="parameterSelection">
                        <tr>                        
                            <td>
                                <div>
                                    <asp:RadioButton ID="rdoDDL" runat="server" Text="快速選單" GroupName="R2" Checked="true" AutoPostBack="true" OnCheckedChanged="R2_CheckedChanged" />
                                </div>
                            </td>
                            <td>
                                <div>
                                    <asp:RadioButton ID="rdoText" runat="server" Text="選擇日期(yyyyMMdd)" GroupName="R2" AutoPostBack="true" OnCheckedChanged="R2_CheckedChanged" />
                                </div>
                            </td>                            
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    <asp:RadioButton ID="rdoYear" runat="server" Text="年報表" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" />
                                   <asp:RadioButton ID="rdoMonth" runat="server" Text="月報表" Checked="true" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    <asp:DropDownList ID="ddlYear" runat="server">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlMonth" runat="server">
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
                            </td>
                            <td>
                                <div>
                                    開始查詢日期
                                    <asp:TextBox ID="txtStart" runat="server"></asp:TextBox>
                                    <br />
                                    結束查詢日期
                                    <asp:TextBox ID="txtEnd" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>                        
                    </table>
                </div>
            </div>
            <br />
            <div>
                <asp:DropDownList ID="ddlPersonnel" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="MV002" DataValueField="TG006">
                    <asp:ListItem Selected="True">全部人員</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NZConnectionString %>" SelectCommand="SELECT DISTINCT TG006, MV002
    FROM COPTG
	    LEFT JOIN CMSMV MV ON TG006 = MV001
    WHERE TG006 &lt;&gt; ''
    ORDER BY TG006"></asp:SqlDataSource>            
            </div>
            <br />
            <div>
                <asp:Button ID="btnReport" runat="server" Text="產生報表" OnClick="btnReport_Click" />
                <asp:Button ID="btnExport" runat="server" Text="匯出至Excel" OnClick="btnExport_Click" />
            </div>
            <br />
            <div id="search-result">                
                <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
                <br />
                <asp:Label ID="lblRange" runat="server"></asp:Label>
                <br />
                <div class="inline-top">
                    <asp:GridView ID="grdReport" runat="server" OnDataBound="grdReport_DataBound" OnRowCreated="grdReport_RowCreated" ShowFooter="True" CssClass="grdResultWithFooter" Caption="銷售淨額排名">
                    </asp:GridView>
                </div>
                <div class="inline-top">
                    <asp:Chart ID="Chart1" runat="server" Width="500px">
                        <Series>
                            <asp:Series Name="Series1" IsValueShownAsLabel="True"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
                <div class="inline-top">
                    <asp:GridView ID="grdReport2" runat="server" AutoGenerateColumns="false" OnDataBound="grdReport2_DataBound" OnRowCreated="grdReport2_RowCreated" ShowFooter="True" CssClass="grdResultWithFooter" Caption="銷退金額排名">
                        <Columns>
                            <asp:TemplateField HeaderText="排名">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("排名") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="業務名稱">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("業務名稱") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="業務代號">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("業務代號") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="退貨金額">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("退貨金額") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
<%--                            <asp:TemplateField HeaderText="退貨單數">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("退貨單數") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="退貨件數">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("退貨件數") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="inline-top">
                    <asp:Chart ID="Chart2" runat="server" Width="500px">
                        <Series>
                            <asp:Series Name="Series2" IsValueShownAsLabel="True"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea2"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
            </div>
        </div>
    </div>
<%--    <script type="text/javascript">
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

