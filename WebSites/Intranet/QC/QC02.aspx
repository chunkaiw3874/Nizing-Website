<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="QC02.aspx.cs" Inherits="QC_QC02" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .one-third{
            vertical-align:top;
            display:inline-block;
            width:33%;
            min-width:330px;
            margin-top:10px;
            /*border:solid 1px #cccccc;*/
            overflow:visible;
        }
        .one-fourth img{
            max-width:100%;
            min-width:330px;
            max-height:100%;
        }
        #grdReport1Div{
            overflow:scroll;
            overflow-x:auto;
            overflow-y:auto;
            max-width:100%;
        }
        #grdReport1Div table tr td {
            white-space:nowrap;
        }
        .grdResult{
            height:100%;
        }
    
        @media print{
            .printarea{
                width:500mm;
                height:297mm;
                position:absolute;
                top:0;
                left:0;
                font-size:14px;

            }
            #search-result{
                width:100%;
                height:100%;
            }            
            #grdReport1Div{
                overflow:hidden;
                overflow-x:hidden;
                overflow-y:hidden;
                /*page-break-after:always;*/
            }
            #grdReport1Div table{
                max-width:100%;
            }
            /*#grdReport1Div table tr th{                
                font-size:12px;
            }
            #grdReport1Div table tr td{                
                font-size:12px;
            }*/
            #grdReport1Div table tr td:nth-child(5){
                max-width:300px;
                white-space:nowrap;
                overflow:hidden;
                text-overflow:ellipsis;
            }
            #summary{
                position:relative;
                top:0;
                page-break-before:auto;
                page-break-after:auto;
                page-break-inside:avoid;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="QC02">
        <div>
            <h2>退貨原因查詢</h2>
        </div>
        <div>
            <asp:RadioButton ID="rdoYear" runat="server" Text="年報表" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" />
            <asp:RadioButton ID="rdoMonth" runat="server" Text="月報表" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" />
        </div>
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
        <div style="margin-top:10px; margin-bottom:10px;">
            <asp:ImageButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ImageUrl="~/nizing_intranet/image/button/Search_Button.png" />
        </div>
        <div>
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>
        </div>
<%--        <div class="printarea">
            <div>
                <h2><asp:Label ID="lblScope" runat="server"></asp:Label></h2>
            </div>
            <div id="search-result">
                <div id="grdReport1Div">                
                    <asp:GridView ID="grdReport1" runat="server" AutoGenerateColumns="false" CaptionAlign="Left" CssClass="grdResult" HeaderStyle-Wrap="false" >
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("RN") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="單據日期">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("TI034") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="客戶簡稱">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("MA002") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="業務名稱">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("MV002") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="品名">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("TJ005") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="銷退數量">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("TJ007") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="單位">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("TJ008") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="檢驗者">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("PIC_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="退貨原因">
                                <ItemTemplate>
                                    <asp:Label ID="lblCause" runat="server" Text='<%#Eval("CAUSE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="責任歸屬">
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("RESPONSIBLE").ToString().Replace(Environment.NewLine, "<br />") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="處理方式">
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("HANDLE").ToString().Replace(Environment.NewLine, "<br />") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="退貨說明">
                                <ItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%#Eval("DESCRIPTION") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="幣別">
                                <ItemTemplate>
                                    <asp:Label ID="Label13" runat="server" Text='<%#Eval("TI008") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="單價">
                                <ItemTemplate>
                                    <asp:Label ID="Label14" runat="server" Text='<%#Eval("TJ011") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="台幣未稅總金額">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("TJ033") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="良品金額">
                                <ItemTemplate>
                                    <asp:Label ID="lblGood" runat="server" Text='<%#Eval("AMOUNT_GOOD") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="重工金額">
                                <ItemTemplate>
                                    <asp:Label ID="lblRedo" runat="server" Text='<%#Eval("AMOUNT_REDO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="報廢金額">
                                <ItemTemplate>
                                    <asp:Label ID="lblScrap" runat="server" Text='<%#Eval("AMOUNT_SCRAP") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="其他金額">
                                <ItemTemplate>
                                    <asp:Label ID="lblOther" runat="server" Text='<%#Eval("AMOUNT_OTHER") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="損失金額">
                                <ItemTemplate>
                                    <asp:Label ID="Label20" runat="server" Text='<%#Eval("AMOUNT_LOSS").ToString().Replace(Environment.NewLine, "<br />") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="簽核確認">
                                <ItemTemplate>
                                    <asp:Label ID="Label21" runat="server" Text='<%#Eval("SIGNOFF") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="summary">
                    <div style="display:none;">
                        <table>
                            <tr>
                                <td>
                                    <div>
                                        品質異常
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="lblCauseTotal1" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        客戶訂錯
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="lblCauseTotal2" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        出錯貨
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="lblCauseTotal3" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        訂單錯誤
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="lblCauseTotal4" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        換貨
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="lblCauseTotal5" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        其他
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="lblCauseTotal6" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        總數
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="lblCauseGrandTotal" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="one-third">
                        <asp:Chart ID="chartReturn" runat="server" Width="330" Height="330">
                            <Series>
                                <asp:Series Name="Series1" ChartType="Pie" LegendText="#VALY 件 / #VALX / #PERCENT"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </div>
                    <div class="one-third">
                        <div style="margin-left:5em;">
                            良品金額:
                            <asp:Label ID="lblGoodTotal" runat="server"></asp:Label>
                        </div>
                        <div style="margin-left:5em;">
                            重工金額:
                            <asp:Label ID="lblRedoTotal" runat="server"></asp:Label>
                        </div>
                        <div style="margin-left:5em;">
                            報廢金額:
                            <asp:Label ID="lblScrapTotal" runat="server"></asp:Label>
                        </div>
                        <div style="border-bottom:double 1px #cccccc;margin-left:5em;">
                            其他金額:
                            <asp:Label ID="lblOtherTotal" runat="server"></asp:Label>
                        </div>
                        <div style="margin-left:3em;">
                            已配置總金額:
                            <asp:Label ID="lblAllocatedTotal" runat="server"></asp:Label>
                        </div>
                        <div style="margin-left:9.5em">
                            <asp:Label ID="lblTotalMatch" runat="server"></asp:Label>
                        </div>
                        <div style="border-bottom:double 1px #cccccc;margin-left:6em;">
                            總金額:
                            <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                        </div>
                        <div>
                            非品質異常退貨金額:
                            <asp:Label ID="lblReturnGoodTotal" runat="server"></asp:Label>
                        </div>
                        <div style="margin-left:1em;">
                            品質異常退貨金額:
                            <asp:Label ID="lblReturnBadTotal" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="one-third">
                        <asp:Chart ID="chartReturnAmount" runat="server" Width="330" Height="330">
                            <Series>
                                <asp:Series Name="Series1" ChartType="Pie" LegendText="#VALY / #VALX / #PERCENT"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </div>
                </div>
            </div>
        </div>--%>
    </div>
</asp:Content>

