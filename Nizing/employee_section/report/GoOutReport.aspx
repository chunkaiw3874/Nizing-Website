<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="GoOutReport.aspx.cs" Inherits="employee_section_report_GoOutReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .scrollbox-500{
            height:auto;
            max-height:500px;
        }

        .table td, .table th{
            border:initial;
        }

        th {
            background-color: #29ABE2;
            color: #FFFFFF
        }

        td {
            background-color: #ffffff;
            color: #000000;
        }

        tr:nth-child(2n) td {
            background-color: #c3e8f4;
            color: #000000;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=txtSearchbox.ClientID%>').keyup(function () {
                var value = $(this).val().toLowerCase();
                $('#<%=gvGoOutData.ClientID%> tr.tbody').filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <h4>外出報表</h4>
    </div>
    <div class="input-group mb-2">
        <div class="input-group-prepend">
            <span class="input-group-text">查詢年月</span>
        </div>
        <asp:DropDownList ID="ddlParameterYear" runat="server" CssClass="custom-select">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlParameterMonth" runat="server" CssClass="custom-select">
        </asp:DropDownList>
        <div class="input-group-append">
            <asp:Button ID="btnSearchGoOutData" runat="server" Text="查詢" CssClass="btn btn-success"
                OnClick="btnSearchGoOutData_Click"/>
        </div>
    </div>
    <div class="input-group mb-2">
        <div class="input-group-prepend">
            <div class="input-group-text">
                <i class="fas fa-search"></i>
            </div>
        </div>
        <asp:TextBox ID="txtSearchbox" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:UpdatePanel ID="upDataview" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearchGoOutData" />
        </Triggers>
        <ContentTemplate>
            <div class="table-responsive scrollbox-500 mb-3">
                <asp:GridView ID="gvGoOutData" runat="server" AutoGenerateColumns="false" CssClass="table table-light table-hover"
                    EmptyDataText="無外出資料">
                    <RowStyle CssClass="tbody" />
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblFormId" runat="server" Text='<%#Eval("FormId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="使用者">
                            <ItemTemplate>
                                <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                                <asp:HiddenField ID="hdnUserId" runat="server" Value='<%#Eval("UserId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="公司別">
                            <ItemTemplate>
                                <asp:Label ID="lblUserCompany" runat="server" Text='<%#Eval("UserCompany") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblEstimatedStartTime" runat="server" Text='<%#Eval("EstimateStartTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblEstimateTimeUsed" runat="server" Text='<%#Eval("EstimateTimeUsed") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="出發時間">
                            <ItemTemplate>
                                <asp:Label ID="lblActualStartTime" runat="server" Text='<%#Eval("ActualStartTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="結束時間">
                            <ItemTemplate>
                                <asp:Label ID="lblActualEndTime" runat="server" Text='<%#Eval("ActualEndTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="使用時間">
                            <ItemTemplate>
                                <asp:Label ID="lblTimespan" runat="server" Text='<%#Eval("Timespan") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="目的地">
                            <ItemTemplate>
                                <asp:Label ID="lblDestination" runat="server" Text='<%#Eval("Destination") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="事由">
                            <ItemTemplate>
                                <asp:Label ID="lblMemo" runat="server" Text='<%#Eval("Memo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="分攤公司">
                            <ItemTemplate>
                                <asp:Label ID="lblForWhichCompany" runat="server" Text='<%#Eval("ForWhichCompany") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="狀態">
                            <ItemTemplate>
                                <asp:Label ID="lblFormStatus" runat="server" Text='<%#Eval("FormStatus") %>'></asp:Label>
                                <asp:HiddenField ID="hdnStatus" runat="server" Value='<%#Eval("Status") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

