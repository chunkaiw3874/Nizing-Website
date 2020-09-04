<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="M01.aspx.cs" Inherits="nizing_intranet_M01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            var isPostBack = $('#<%=hdnIsPostBack.ClientID%>').val();
            if (isPostBack == '0') {
                $('#TargetSetter').hide();
            }
            else {
                if ($('#<%=hdnIsbtnShowTargetSetterTrue.ClientID%>').val() == '1') {
                    $('#TargetSetter').show();
                }
                else {
                    $('#TargetSetter').hide();
                }
            }
            $(document).on('click', '#btnShowTargetSetter', function () {
                $('#TargetSetter').toggle();
                if ($('#TargetSetter').is(":visible") == true) {
                    $('#TargetSetter').show();
                    $('#<%=hdnIsbtnShowTargetSetterTrue.ClientID%>').val('1');
                }
                else {
                    $('#TargetSetter').hide();
                    $('#<%=hdnIsbtnShowTargetSetterTrue.ClientID%>').val('0');
                }
            });
        })
    </script>
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
    <div id="M01" class="container">
        <div id="Admin" runat="server" visible="false" class="form-group">
            <div class="row">
                <div class="col-sm-12 form-group">
                    <span class="label label-info" id="btnShowTargetSetter" style="cursor: pointer; font-size: 20px; color: aqua;">設定生產目標</span>
                    <asp:HiddenField ID="hdnIsPostBack" runat="server" />
                    <asp:HiddenField ID="hdnIsbtnShowTargetSetterTrue" runat="server" />
                </div>
            </div>
            <div id="TargetSetter">
                <div class="input-group">
                    <asp:DropDownList ID="ddlTargetYear" runat="server" CssClass="custom-select"></asp:DropDownList>
                    <asp:DropDownList ID="ddlTargetProductionLine" runat="server" CssClass="custom-select"></asp:DropDownList>
                    <div class="input-group-append">
                        <asp:Button ID="btnTargetSubmit" runat="server" Text="搜尋" CssClass="btn btn-success" OnClick="btnTargetSubmit_Click" />
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:GridView ID="gvTargetSetter" runat="server" AutoGenerateColumns="false" CssClass="grdResult">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblTargetSetterProductionLine" runat="server" Text=""></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTargetSetterProductionYear" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="一月">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTargetSetterProductionTarget1" runat="server" Text='<%#string.IsNullOrWhiteSpace(Eval("1").ToString())?"":Eval("1") %>' MaxLength="10" Width="100"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="二月">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTargetSetterProductionTarget2" runat="server" Text='<%#string.IsNullOrWhiteSpace(Eval("2").ToString())?"":Eval("2") %>' MaxLength="10" Width="100"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="三月">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTargetSetterProductionTarget3" runat="server" Text='<%#string.IsNullOrWhiteSpace(Eval("3").ToString())?"":Eval("3") %>' MaxLength="10" Width="100"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="四月">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTargetSetterProductionTarget4" runat="server" Text='<%#string.IsNullOrWhiteSpace(Eval("4").ToString())?"":Eval("4") %>' MaxLength="10" Width="100"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="五月">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTargetSetterProductionTarget5" runat="server" Text='<%#string.IsNullOrWhiteSpace(Eval("5").ToString())?"":Eval("5") %>' MaxLength="10" Width="100"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="六月">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTargetSetterProductionTarget6" runat="server" Text='<%#string.IsNullOrWhiteSpace(Eval("6").ToString())?"":Eval("6") %>' MaxLength="10" Width="100"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="七月">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTargetSetterProductionTarget7" runat="server" Text='<%#string.IsNullOrWhiteSpace(Eval("7").ToString())?"":Eval("7") %>' MaxLength="10" Width="100"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="八月">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTargetSetterProductionTarget8" runat="server" Text='<%#string.IsNullOrWhiteSpace(Eval("8").ToString())?"":Eval("8") %>' MaxLength="10" Width="100"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="九月">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTargetSetterProductionTarget9" runat="server" Text='<%#string.IsNullOrWhiteSpace(Eval("9").ToString())?"":Eval("9") %>' MaxLength="10" Width="100"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="十月">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTargetSetterProductionTarget10" runat="server" Text='<%#string.IsNullOrWhiteSpace(Eval("10").ToString())?"":Eval("10") %>' MaxLength="10" Width="100"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="十一月">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTargetSetterProductionTarget11" runat="server" Text='<%#string.IsNullOrWhiteSpace(Eval("11").ToString())?"":Eval("11") %>' MaxLength="10" Width="100"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="十二月">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTargetSetterProductionTarget12" runat="server" Text='<%#string.IsNullOrWhiteSpace(Eval("12").ToString())?"":Eval("12") %>' MaxLength="10" Width="100"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <asp:Button ID="btnSaveTarget" runat="server" Text="儲存" CssClass="btn-success btn" Visible="false" OnClick="btnSaveTarget_Click" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <asp:Label ID="lblTargetSetterMessage" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-sm-12 h2">
                生產統計表
            </div>
        </div>
        <div class="form-group">
            <div class="input-group">
                <div class="input-group-prepend">
                    <asp:Label ID="Label2" runat="server" CssClass="input-group-text" Text="開始查詢年份"></asp:Label>
                </div>
                <asp:DropDownList ID="ddlStartYear" runat="server" CssClass="custom-select">
                </asp:DropDownList>
            </div>
            <div class="input-group">
                <div class="input-group-prepend">
                    <asp:Label ID="Label3" runat="server" CssClass="input-group-text" Text="結束查詢年份"></asp:Label>
                </div>
                <asp:DropDownList ID="ddlEndYear" runat="server" CssClass="custom-select">
                </asp:DropDownList>
            </div>
        </div>
        <div class="btn-group flex">
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="查詢" CssClass="btn btn-success" />
            <asp:Button ID="btnExport" runat="server" Text="匯出至Excel" OnClick="btnExport_Click" CssClass="btn btn-success" />
        </div>
        <div class="form-group row">
            <div class="col-sm-12">
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-12">
                <asp:Label ID="lblScope" runat="server"></asp:Label>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-12">
                <asp:GridView ID="grdProduction" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="grdResult col-xs-12" OnRowDataBound="grdProduction_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="型別">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("TYPE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="生產線別">
                            <ItemTemplate>
                                <asp:Label ID="lbl1" runat="server" Text='<%#Eval("ProductionLine") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="年度">
                            <ItemTemplate>
                                <asp:Label ID="lbl2" runat="server" Text='<%#Eval("YR") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="生產數量">
                            <ItemTemplate>
                                <asp:Label ID="lbl2" runat="server" Text='<%#Eval("ProductionAmount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="一月">
                            <ItemTemplate>
                                <asp:Label ID="lbl3" runat="server" Text='<%#Eval("01") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="二月">
                            <ItemTemplate>
                                <asp:Label ID="lbl4" runat="server" Text='<%#Eval("02") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="三月">
                            <ItemTemplate>
                                <asp:Label ID="lbl5" runat="server" Text='<%#Eval("03") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="四月">
                            <ItemTemplate>
                                <asp:Label ID="lbl6" runat="server" Text='<%#Eval("04") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="五月">
                            <ItemTemplate>
                                <asp:Label ID="lbl7" runat="server" Text='<%#Eval("05") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="六月">
                            <ItemTemplate>
                                <asp:Label ID="lbl8" runat="server" Text='<%#Eval("06") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="七月">
                            <ItemTemplate>
                                <asp:Label ID="lbl9" runat="server" Text='<%#Eval("07") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="八月">
                            <ItemTemplate>
                                <asp:Label ID="lbl10" runat="server" Text='<%#Eval("08") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="九月">
                            <ItemTemplate>
                                <asp:Label ID="lbl11" runat="server" Text='<%#Eval("09") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="十月">
                            <ItemTemplate>
                                <asp:Label ID="lbl12" runat="server" Text='<%#Eval("10") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="十一月">
                            <ItemTemplate>
                                <asp:Label ID="lbl13" runat="server" Text='<%#Eval("11") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="十二月">
                            <ItemTemplate>
                                <asp:Label ID="lbl14" runat="server" Text='<%#Eval("12") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="年度總產量">
                            <ItemTemplate>
                                <asp:Label ID="lbl15" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

