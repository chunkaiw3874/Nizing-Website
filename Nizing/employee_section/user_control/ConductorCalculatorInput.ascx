<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConductorCalculatorInput.ascx.cs" Inherits="employee_section_user_control_ConductorCalculatorInput" %>

<style type="text/css">
    .frame{
        margin-bottom:10px;
        padding:5px;
        border:solid 1px #cccccc;
    }
    table tr th{
        padding:4px;
        background-color:#29ABE2;
        color:#FFFFFF;
        border:solid 1px #ffffff;
    }
    table tr td{
        padding:4px;
        background-color:#c3e8f4;
        color:#000000;    
        text-align:center;
        border:solid 1px #ffffff;
    }
    .error-message{
        color:red;
    }
</style>

<div class="frame">
    <asp:Label ID="lblCondErrorMessage" runat="server" CssClass="error-message"></asp:Label>
    <table>
        <tr>
            <th>導體</th>
            <th>單價</th>
            <th>單條導體線徑(mm)</th>
            <th>條數</th>
            <th>長度(M)</th>
            <th>重量(Kg)</th>
            <th>每米導體單價</th>
            <th>芯線數</th>
            <th>每米成本</th>
            <th>總成本</th>
        </tr>
        <tr>
            <td>
            <asp:DropDownList ID="ddlRawMat" runat="server" DataSourceID="SqlDataSourceRawMat" OnSelectedIndexChanged="ddlRawMat_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" DataTextField="MB002" DataValueField="MB001">
                <asp:ListItem Value="00">--選擇導體--</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="txtCondCost" runat="server" Width="70px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtCondOD" runat="server" Width="50px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtCondStrandNumber" runat="server" Width="50px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtCondLength" runat="server" Width="50px"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblCondWeight" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCondCostPerMeter" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCondCoreNumber" runat="server" Width="50px"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblCondTotalCostPerMeter" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCondTotalCost" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Button ID="btnCondCalculate" runat="server" Text="計算成本" OnClick="btnCondCalculate_Click" />
</div>
<asp:SqlDataSource ID="SqlDataSourceRawMat" runat="server" ConnectionString='<%$ ConnectionStrings:NZConnectionString %>' SelectCommand=
            "SELECT LTRIM(RTRIM(INVMB.MB001)) MB001, LTRIM(RTRIM(INVMB.MB002)) MB002
            FROM INVMB
            WHERE INVMB.MB005=N'05'
            AND (
            INVMB.MB006=N'5-HW'
            OR INVMB.MB006=N'51-ALL'
            OR INVMB.MB006=N'51-T'
            OR INVMB.MB006=N'51-TC'
            OR INVMB.MB006=N'51-Z'
            )
            ORDER BY INVMB.MB006, INVMB.MB001">
</asp:SqlDataSource>