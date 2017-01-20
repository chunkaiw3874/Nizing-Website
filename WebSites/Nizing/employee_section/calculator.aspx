<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="calculator.aspx.cs" Inherits="restricted_calculator" %>
<%@ Register TagPrefix="uc" TagName="ConductorCalculatorInput" Src="~/employee_section/user_control/ConductorCalculatorInput.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    工程計算機
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="calculator">
        <div>
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>
        </div>
<%--        <div id="OD">
            <div class="calc_title">
                多芯絞線外徑計算器
            </div>
            <table>
                <tr>
                    <td>單條線OD (mm)</td>
                    <td>條數</td>
                    <td>外徑 (mm)</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtOD1" runat="server" Width="100px" AutoPostBack="true" OnTextChanged="txtOD_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOD2" runat="server" Width="100px" AutoPostBack="true" OnTextChanged="txtOD_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblAns1" runat="server" Width="100px"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div id="copperConverter">
            <div class="calc_title">
                銅導體重量米數計算器
            </div>
            <table>
                <tr>
                    <td colspan="3">基本變數</td>
                </tr>
                <tr>
                    <td>單心導體OD (mm)</td>
                    <td>條數</td>
                    <td>銅公斤單價</td>                    
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCopperConverter_OD" runat="server" Width="100px" AutoPostBack="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCopperConverter_Number" runat="server" Width="100px" AutoPostBack="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCopperConverter_CopperPrice" runat="server" Width="100px" AutoPostBack="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>公斤</td>
                    <td></td>
                    <td>米</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCopperCoverter_Kg" runat="server" Width="100px" AutoPostBack="true" OnTextChanged="ConvertKgAndM"></asp:TextBox>
                    </td>
                    <td>&lt;=&gt;</td>
                    <td>
                        <asp:TextBox ID="txtCopperCoverter_M" runat="server" Width="100px" AutoPostBack="true" OnTextChanged="ConvertKgAndM"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>--%>
        <div id="stockCost">
            <div class="calc_title">
                Avg Cost of Goods on Hand - FIFO
                <asp:Button ID="btnAddCondCalc" runat="server" Text="Add User Control" OnClick="btnAddCondCalc_Click" />
            </div>
            <asp:Panel ID="Panel1" runat="server">
                <uc:ConductorCalculatorInput id="calc1" runat="server"></uc:ConductorCalculatorInput>
<%--                <asp:DropDownList ID="ddlRawMat" runat="server" DataSourceID="SqlDataSourceRawMat" OnDataBound="ddlRawMat_DataBound" OnSelectedIndexChanged="ddlRawMat_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" DataTextField="MB002" DataValueField="MB001">
                    <asp:ListItem>--Pick a Conductor--</asp:ListItem>
                </asp:DropDownList>
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
                <asp:Label ID="Label1" runat="server" Text="Amount of Goods On Hand"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Across number of PO"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="Average Cost of Good On Hand"></asp:Label>--%>
            </asp:Panel>
            <div>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </div>
            <div>
                <asp:GridView ID="grdConductorList" runat="server" CssClass="grdResult" AutoGenerateColumns="false" OnRowDeleting="grdConductorList_RowDeleting">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnCondDelete" runat="server" ImageUrl="~/employee_section/image/button/delete1.png" CommandName="DELETE" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="導體">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("ddlRawMat") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單價">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("txtCondCost") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單條導體線徑(mm)">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("txtCondOD") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="條數">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("txtCondStrandNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="長度(M)">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("txtCondLength") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="重量(Kg)">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("lblCondWeight") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="每米導體單價">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("lblCondCostPerMeter") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="芯線數">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("txtCondCoreNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="每米成本">
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("lblCondTotalCostPerMeter") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="總成本">
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("lblCondTotalCost") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

