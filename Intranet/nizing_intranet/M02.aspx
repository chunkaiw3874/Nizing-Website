<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="M02.aspx.cs" Inherits="nizing_intranet_M02" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Content/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="../Content/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap-datepicker.js"></script>
    <script src="../Scripts/locales/bootstrap-datepicker.zh-TW.min.js"></script>
    <%--<script src="../Scripts/bootstrap.js"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.datepicker').datepicker({
                language: 'zh-TW',
                format: 'yyyymmdd',
                autoclose: true,
                todayBtn: true,
                todayHighlight: true
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <h2>人員生產入庫明細表</h2>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-xs-3">
                    <asp:RadioButton ID="rdoDDL" runat="server" Text="快速選單" GroupName="R2" Checked="true" AutoPostBack="true" OnCheckedChanged="R2_CheckedChanged" CssClass="radio-inline" />
                </div>
                <div class="col-xs-3">
                    <asp:RadioButton ID="rdoText" runat="server" Text="選擇日期(yyyyMMdd)" GroupName="R2" AutoPostBack="true" OnCheckedChanged="R2_CheckedChanged" CssClass="radio-inline" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-1">
                    <asp:RadioButton ID="rdoYear" runat="server" Text="年報表" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" CssClass="radio-inline" />
                </div>
                <div class="col-xs-1">
                    <asp:RadioButton ID="rdoMonth" runat="server" Text="月報表" Checked="true" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" CssClass="radio-inline" />
                </div>
            </div>
            <div class="row form-group">
                <div class="col-xs-2">
                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-xs-1">
                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control">
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
                <label class="control-label col-xs-2">開始查詢日期</label>
                <div class="col-xs-3">
                    <asp:TextBox ID="txtStart" runat="server" CssClass="form-control datepicker" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <label class="control-label col-xs-2 col-xs-offset-3">結束查詢日期</label>
                <div class="col-xs-3">
                    <asp:TextBox ID="txtEnd" runat="server" CssClass="form-control datepicker" Enabled="false"></asp:TextBox>
                </div>
            </div>
        <br />
            <div class="row">
                <div class="col-xs-3">
                    <asp:DropDownList ID="ddlPersonnel" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="MV002" DataValueField="TF200" CssClass="form-control">
                        <asp:ListItem Selected="True">全部人員</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NZConnectionString %>" SelectCommand="SELECT DISTINCT TF.TF200, TF.TF200+' '+MV.MV002 MV002
                    FROM MOCTF TF
	                    LEFT JOIN CMSMV MV ON TF.TF200 = MV.MV001
                    WHERE TF.TF200 &lt;&gt; ''
                    ORDER BY TF.TF200"></asp:SqlDataSource>
                </div>
            </div>
        </div>
        <div>
            <asp:Button ID="btnReport" runat="server" Text="產生報表" OnClick="btnReport_Click" CssClass="btn btn-success" />
            <%--<asp:Button ID="btnExport" runat="server" Text="匯出至Excel" OnClick="btnExport_Click" CssClass="btn btn-success" />--%>
        </div>
        <div id="search-result">
            <div class="row">
                <div class="col-xs-12">
                    <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:Label ID="lblRange" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:GridView ID="grdReport" runat="server" 
                        AutoGenerateColumns="false" CssClass="grdResult" OnRowCommand="grdReport_RowCommand"
                        ShowFooter="true" OnDataBound="grdReport_DataBound" OnRowCreated="grdReport_RowCreated" >
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:LinkButton ID="lb1" runat="server" Text="生產線別" CommandName="Sort" CommandArgument="生產線別" ForeColor="White"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("生產線別") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="lb2" runat="server" Text="生產人員" CommandName="Sort" CommandArgument="生產人員" ForeColor="White"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("生產人員") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:LinkButton ID="lb3" runat="server" Text="單據日期" CommandName="Sort" CommandArgument="單據日期" ForeColor="White"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("單據日期") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="lb4" runat="server" Text="品號" CommandName="Sort" CommandArgument="品號" ForeColor="White"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("品號") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="品名">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("品名") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="規格" HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("規格") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="入庫數量">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("入庫數量") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="單位">
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("單位") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="lb11" runat="server" Text="庫別" CommandName="Sort" CommandArgument="庫別" ForeColor="White"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("庫別") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="庫別名稱" HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%#Eval("庫別名稱") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="lb13" runat="server" Text="製令單號" CommandName="Sort" CommandArgument="製令單號" ForeColor="White"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label13" runat="server" Text='<%#Eval("製令單號") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

