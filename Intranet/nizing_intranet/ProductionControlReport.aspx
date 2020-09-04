<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ProductionControlReport.aspx.cs" Inherits="ProductionControlReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .btn-group.flex {
            display: flex;
        }

        .flex .btn {
            flex: 1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <h2>交期達成率報告</h2>
            </div>
        </div>
        <div class="input-group mb-1">
            <div class="input-group-prepend">
                <label class="input-group-text">開始查詢</label>
            </div>
            <asp:DropDownList ID="ddlBeginYear" runat="server" CssClass="custom-select">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlBeginMonth" runat="server" CssClass="custom-select">
                <asp:ListItem Value="1226">01</asp:ListItem>
                <asp:ListItem Value="0126">02</asp:ListItem>
                <asp:ListItem Value="0226">03</asp:ListItem>
                <asp:ListItem Value="0326">04</asp:ListItem>
                <asp:ListItem Value="0426">05</asp:ListItem>
                <asp:ListItem Value="0526">06</asp:ListItem>
                <asp:ListItem Value="0626">07</asp:ListItem>
                <asp:ListItem Value="0726">08</asp:ListItem>
                <asp:ListItem Value="0826">09</asp:ListItem>
                <asp:ListItem Value="0926">10</asp:ListItem>
                <asp:ListItem Value="1026">11</asp:ListItem>
                <asp:ListItem Value="1126">12</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="input-group mb-2">
            <div class="input-group-prepend">
                <label class="input-group-text">結束查詢</label>
            </div>
            <asp:DropDownList ID="ddlEndYear" runat="server" CssClass="custom-select">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlEndMonth" runat="server" CssClass="custom-select">
                <asp:ListItem Value="0125">01</asp:ListItem>
                <asp:ListItem Value="0225">02</asp:ListItem>
                <asp:ListItem Value="0325">03</asp:ListItem>
                <asp:ListItem Value="0425">04</asp:ListItem>
                <asp:ListItem Value="0525">05</asp:ListItem>
                <asp:ListItem Value="0625">06</asp:ListItem>
                <asp:ListItem Value="0725">07</asp:ListItem>
                <asp:ListItem Value="0825">08</asp:ListItem>
                <asp:ListItem Value="0925">09</asp:ListItem>
                <asp:ListItem Value="1025">10</asp:ListItem>
                <asp:ListItem Value="1125">11</asp:ListItem>
                <asp:ListItem Value="1225">12</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="btn-group flex">
            <asp:Button ID="btnReport" runat="server" Text="產生報表" OnClick="btnReport_Click" CssClass="btn btn-success" />
            <asp:Button ID="btnExport" runat="server" Text="匯出至Excel" OnClick="btnExport_Click" Enabled="False" CssClass="btn btn-success" />
        </div>
        <br />
        <asp:HiddenField ID="Begin" runat="server" Value="0" />
        <asp:HiddenField ID="End" runat="server" Value="0" />
        <br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblRange" runat="server" Text=""></asp:Label>
        <br />
        <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="grdResult">
            <Columns>
                <asp:BoundField DataField="客戶簡稱" HeaderText="客戶簡稱" SortExpression="客戶簡稱"></asp:BoundField>
                <asp:BoundField DataField="業務員" HeaderText="業務員" SortExpression="業務員"></asp:BoundField>
                <asp:BoundField DataField="訂單號碼" HeaderText="訂單號碼" SortExpression="訂單號碼" ReadOnly="True"></asp:BoundField>
                <asp:BoundField DataField="銷貨編號" HeaderText="銷貨編號" SortExpression="銷貨編號" ReadOnly="True"></asp:BoundField>
                <asp:BoundField DataField="品號" HeaderText="品號" SortExpression="品號"></asp:BoundField>
                <asp:BoundField DataField="品名" HeaderText="品名" SortExpression="品名"></asp:BoundField>
                <asp:BoundField DataField="規格" HeaderText="規格" SortExpression="規格"></asp:BoundField>
                <asp:BoundField DataField="總數量" HeaderText="總數量" SortExpression="總數量"></asp:BoundField>
                <asp:BoundField DataField="單位" HeaderText="單位" SortExpression="單位"></asp:BoundField>
                <asp:BoundField DataField="備註" HeaderText="備註" SortExpression="備註" ReadOnly="True"></asp:BoundField>
                <asp:BoundField DataField="預定交期" HeaderText="預定交期" SortExpression="預定交期"></asp:BoundField>
                <asp:BoundField DataField="交貨日期" HeaderText="交貨日期" SortExpression="交貨日期" ReadOnly="True"></asp:BoundField>
                <asp:BoundField DataField="準時" HeaderText="準時" SortExpression="準時" ReadOnly="True"></asp:BoundField>
                <asp:BoundField DataField="遲交天數" HeaderText="遲交天數" ReadOnly="True" SortExpression="遲交天數" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NZConnectionString %>" SelectCommand="SELECT MA002 客戶簡稱, MV002 業務員, TD001+'-'+TD002+'-'+TD003 訂單號碼, TH001+'-'+TH002 銷貨編號, TD004 品號, TD005 品名, TD006 規格, TD008 總數量
	, TD010 單位, COALESCE(TC015, N'') 備註, TD013 預定交期, COALESCE(TG003, N'') 交貨日期
	, CASE
		WHEN TG003 &lt;= TD013 THEN N'準時'
		ELSE N'遲交'
		END AS 準時
	, CASE 
		WHEN DATEDIFF(DD, CONVERT(DATE, TD013), CONVERT(DATE, TG003))&lt;0 THEN 0
		ELSE DATEDIFF(DD, CONVERT(DATE, TD013), CONVERT(DATE, TG003))
		END AS 遲交天數
FROM COPTD
	LEFT JOIN COPTC ON TD001 = TC001 AND TD002 = TC002
	LEFT JOIN COPMA ON TC004 = MA001
	LEFT JOIN CMSMV ON TC006 = MV001
	LEFT JOIN COPTH ON TD001 = TH014 AND TD002 = TH015 AND TD003 = TH016
	LEFT JOIN COPTG ON TH001 = TG001 AND TH002 = TG002
WHERE TG003 BETWEEN @BEGIN AND @END	
ORDER BY MA002 ASC">
            <SelectParameters>
                <asp:ControlParameter ControlID="Begin" Name="BEGIN" PropertyName="Value" />
                <asp:ControlParameter ControlID="End" Name="END" PropertyName="Value" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>

