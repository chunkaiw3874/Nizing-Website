<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="QC01.aspx.cs" Inherits="nizing_intranet_QC01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .caption{

            text-align:left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="QC01">
        <div>
            <h2>退貨原因查詢</h2>
        </div>
        <div>
            <asp:RadioButton ID="rdoYear" runat="server" Text="年報表" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" />
            <asp:RadioButton ID="rdoMonth" runat="server" Text="月報表" Checked="true" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" />
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
        <div>
            <asp:Label ID="lblScope" runat="server"></asp:Label>
        </div>
        <div id="search-result">
            <div class="inline-top">
                <asp:GridView ID="grdReport2" runat="server" GridLines="None" AutoGenerateColumns="false" OnDataBound="grdReport2_DataBound" OnRowCreated="grdReport2_RowCreated" ShowFooter="True" CssClass="grdResultWithFooter" Caption='<div class="caption"><h2>銷退金額排名</h2></div>'>
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
<%--                        <asp:TemplateField HeaderText="退貨單數">
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
            <div style="overflow:scroll; max-width:100%;">                
                <asp:GridView ID="grdReport1" runat="server" AutoGenerateColumns="false" Caption='<div class="caption"><h2>銷退原因</h2></div>' CaptionAlign="Left" CssClass="grdResult" HeaderStyle-Wrap="false" RowStyle-Wrap="false">
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("RN") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="銷退單號">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單據日期">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("TI034") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
<%--                        <asp:TemplateField HeaderText="客戶代號">
                            <ItemTemplate>
                                <asp:Label ID="Label" runat="server" Text='<%#Eval("TI004") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="客戶簡稱">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("MA002") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="業務名稱">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("MV002") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
<%--                        <asp:TemplateField HeaderText="品號">
                            <ItemTemplate>
                                <asp:Label ID="Label" runat="server" Text='<%#Eval("TJ004") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="品名">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("TJ005") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="銷退數量">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("TJ007") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("TJ008") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="檢驗者">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlPIC" runat="server" DataSourceID="RICSource" DataTextField="MV002" DataValueField="MV001"></asp:DropDownList>
                                <asp:SqlDataSource runat="server" ID="RICSource" ConnectionString='<%$ ConnectionStrings:NZConnectionString %>' SelectCommand="SELECT LTRIM(RTRIM(CMSMV.MV001)) MV001, CMSMV.MV002, CMSMV.MV004, CMSMV.MV006
                                    FROM CMSMV
                                    WHERE CMSMV.MV004=N'B-QC' AND LTRIM(RTRIM(CMSMV.MV022)) = N''"></asp:SqlDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="退貨原因">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlCause" runat="server">
                                    <asp:ListItem>品質異常</asp:ListItem>
                                    <asp:ListItem>規格錯誤</asp:ListItem>
                                    <asp:ListItem>客戶訂錯</asp:ListItem>
                                    <asp:ListItem>出錯貨</asp:ListItem>
                                    <asp:ListItem>訂單錯誤</asp:ListItem>
                                    <asp:ListItem>換貨</asp:ListItem>
                                    <asp:ListItem>其他</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="責任歸屬">
                            <ItemTemplate>
                                <asp:TextBox ID="txtResponsible" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="處理方式">
                            <ItemTemplate>
                                <asp:TextBox ID="txtHandle" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="退貨說明">
                            <ItemTemplate>
                                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="幣別">
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("TI008") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單價">
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("TJ011") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="台幣未稅總金額">
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("TJ033") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="良品金額">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAmount_Good" runat="server" Width="6em"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="重工金額">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAmount_Redo" runat="server" Width="6em"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="報廢金額">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAmount_Scrap" runat="server" Width="6em"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="其他金額">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAmount_Other" runat="server" Width="6em"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="損失金額">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAmount_Loss" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="簽核確認">
                            <ItemTemplate>
                                <asp:TextBox ID="txtSignOff" runat="server" Width="6em"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div style="width:100%;text-align:right;">
                <asp:Button ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>

