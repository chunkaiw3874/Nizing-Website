<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PurchaseReport.aspx.cs" Inherits="PurchaseReport" MasterPageFile="~/masterPage/MasterPage.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <style>
        .btn-group.flex {
            display: flex;
        }

        .flex .btn {
            flex: 1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div>
            <h2>採購交期達成率報告</h2>
        </div>
        <div class="input-group mb-1">
            <div class="input-group-prepend">
                <asp:Label ID="Label1" runat="server" CssClass="input-group-text" Text="查詢開始"></asp:Label>
            </div>
            <asp:DropDownList ID="ddlBeginYear" runat="server" CssClass="custom-select">
                <asp:ListItem Selected="True" Value="0">請選擇起始年份</asp:ListItem>
                <%--            <asp:ListItem Value="2014">2014</asp:ListItem>
            <asp:ListItem Value="2015">2015</asp:ListItem>
            <asp:ListItem Value="2016">2016</asp:ListItem>
            <asp:ListItem Value="2017">2017</asp:ListItem>
            <asp:ListItem Value="2018">2018</asp:ListItem>
            <asp:ListItem Value="2019">2019</asp:ListItem>
            <asp:ListItem Value="2020">2020</asp:ListItem>--%>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlBeginMonth" runat="server" CssClass="custom-select">
                <asp:ListItem Selected="True" Value="0">請選擇起始月份</asp:ListItem>
                <asp:ListItem Value="0101">1</asp:ListItem>
                <asp:ListItem Value="0201">2</asp:ListItem>
                <asp:ListItem Value="0301">3</asp:ListItem>
                <asp:ListItem Value="0401">4</asp:ListItem>
                <asp:ListItem Value="0501">5</asp:ListItem>
                <asp:ListItem Value="0601">6</asp:ListItem>
                <asp:ListItem Value="0701">7</asp:ListItem>
                <asp:ListItem Value="0801">8</asp:ListItem>
                <asp:ListItem Value="0901">9</asp:ListItem>
                <asp:ListItem Value="1001">10</asp:ListItem>
                <asp:ListItem Value="1101">11</asp:ListItem>
                <asp:ListItem Value="1201">12</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="input-group mb-2">
            <div class="input-group-prepend">
                <span class="input-group-text">結束查詢</span>
            </div>
            <asp:DropDownList ID="ddlEndYear" runat="server" CssClass="custom-select">
                <asp:ListItem Selected="True" Value="0">請選擇結束年份</asp:ListItem>
                <%--            <asp:ListItem Value="2014">2014</asp:ListItem>
            <asp:ListItem Value="2015">2015</asp:ListItem>
            <asp:ListItem Value="2016">2016</asp:ListItem>
            <asp:ListItem Value="2017">2017</asp:ListItem>
            <asp:ListItem Value="2018">2018</asp:ListItem>
            <asp:ListItem Value="2019">2019</asp:ListItem>
            <asp:ListItem Value="2020">2020</asp:ListItem>--%>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlEndMonth" runat="server" CssClass="custom-select">
                <asp:ListItem Selected="True" Value="0">請選擇結束月份</asp:ListItem>
                <asp:ListItem Value="0131">1</asp:ListItem>
                <asp:ListItem Value="0229">2</asp:ListItem>
                <asp:ListItem Value="0331">3</asp:ListItem>
                <asp:ListItem Value="0430">4</asp:ListItem>
                <asp:ListItem Value="0531">5</asp:ListItem>
                <asp:ListItem Value="0630">6</asp:ListItem>
                <asp:ListItem Value="0731">7</asp:ListItem>
                <asp:ListItem Value="0831">8</asp:ListItem>
                <asp:ListItem Value="0930">9</asp:ListItem>
                <asp:ListItem Value="1031">10</asp:ListItem>
                <asp:ListItem Value="1130">11</asp:ListItem>
                <asp:ListItem Value="1231">12</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="btn-group flex">
            <asp:Button ID="btnReport" runat="server" Text="產生報表" CssClass="btn btn-success" OnClick="btnReport_Click" />
            <asp:Button ID="btnExport" runat="server" Text="匯出至Excel" CssClass="btn btn-warning" OnClick="btnExport_Click" Enabled="False" />
        </div>
        <asp:HiddenField ID="Begin" runat="server" Value="0" />
        <asp:HiddenField ID="End" runat="server" Value="0" />
        <br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblRange" runat="server" Text=""></asp:Label>
        <br />
        <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="grdResult">
            <Columns>
                <asp:BoundField DataField="採購單號" HeaderText="採購單號" ReadOnly="True" SortExpression="採購單號"></asp:BoundField>
                <asp:BoundField DataField="廠商代號" HeaderText="廠商代號" SortExpression="廠商代號"></asp:BoundField>
                <asp:BoundField DataField="廠商簡稱" HeaderText="廠商簡稱" SortExpression="廠商簡稱"></asp:BoundField>
                <asp:BoundField DataField="採購日期" HeaderText="採購日期" SortExpression="採購日期"></asp:BoundField>
                <asp:BoundField DataField="預交日" HeaderText="預交日" SortExpression="預交日"></asp:BoundField>
                <asp:BoundField DataField="品號" HeaderText="品號" SortExpression="品號"></asp:BoundField>
                <asp:BoundField DataField="品名" HeaderText="品名" SortExpression="品名"></asp:BoundField>
                <asp:BoundField DataField="規格" HeaderText="規格" SortExpression="規格" ReadOnly="True"></asp:BoundField>
                <asp:BoundField DataField="採購數量" HeaderText="採購數量" SortExpression="採購數量"></asp:BoundField>
                <asp:BoundField DataField="已交數量" HeaderText="已交數量" ReadOnly="True" SortExpression="已交數量"></asp:BoundField>
                <asp:BoundField DataField="未交數量" HeaderText="未交數量" ReadOnly="True" SortExpression="未交數量"></asp:BoundField>
                <asp:BoundField DataField="單位" HeaderText="單位" SortExpression="單位"></asp:BoundField>
                <asp:BoundField DataField="備註" HeaderText="備註" SortExpression="備註" ReadOnly="True"></asp:BoundField>
                <asp:BoundField DataField="進貨日" HeaderText="進貨日" ReadOnly="True" SortExpression="進貨日"></asp:BoundField>
                <asp:BoundField DataField="準時" HeaderText="準時" ReadOnly="True" SortExpression="準時"></asp:BoundField>
                <asp:BoundField DataField="遲交天數" HeaderText="遲交天數" ReadOnly="True" SortExpression="遲交天數" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NZConnectionString %>" SelectCommand="SELECT TD001+N'-'+TD002+N'-'+TD003 採購單號, TC004 廠商代號, MA002 廠商簡稱, TC024 採購日期, TD012 預交日, TD004 品號, TD005 品名
		, COALESCE(TD006, N'') 規格, TD008 採購數量, SUM(TH007) 已交數量, TD008-SUM(TH007) 未交數量, TD009 單位, COALESCE(TC009, N'') 備註, MIN(TG014) 進貨日
		, CASE 
			WHEN MIN(TG014)&lt;=TD012 THEN N'準時'
			WHEN MIN(TG014)&gt;TD012 THEN N'遲交'
                                                        WHEN GETDATE() &lt; TD012 AND MIN(TG014) IS NULL THEN N'未至交貨日'	                                                        ELSE '遲交'
			END AS 準時
                                    , CASE
                                               WHEN DATEDIFF(dd,CAST(TD012 AS DATE), CAST(MIN(TG014) AS DATE)) &lt; 0 THEN 0
ELSE DATEDIFF(dd,CAST(TD012 AS DATE), CAST(MIN(TG014) AS DATE))
END AS  遲交天數 		
FROM PURTD TD
	LEFT JOIN PURTC TC ON TD001 = TC001 AND TD002 = TC002
	LEFT JOIN PURMA MA ON TC004 = MA001
	LEFT JOIN PURTH TH ON TD001 = TH011 AND TD002 = TH012 AND TD003 = TH013
	LEFT JOIN PURTG TG ON TH001 = TG001 AND TH002 = TG002
WHERE ((TD012 BETWEEN @BEGIN AND @END AND TD016 != N'y' AND TG014 IS NULL)
		OR (TD012 BETWEEN @BEGIN AND @END AND TD016  = N'y' AND TG014 IS NOT NULL) 
		OR (TD012 BETWEEN @BEGIN AND @END AND TD016 = N'Y')
		OR (TD012 BETWEEN @BEGIN AND @END AND TD016 = N'N'))
GROUP BY TD001, TD002, TD003, TC004, MA002, TC024, TD012, TD004, TD005, TD006, TD008, TD009, TC009
ORDER BY TD002 ASC">
            <SelectParameters>
                <asp:ControlParameter ControlID="Begin" Name="BEGIN" PropertyName="Value" />
                <asp:ControlParameter ControlID="End" Name="END" PropertyName="Value" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
