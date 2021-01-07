<%@ Page Title="" Language="C#" MasterPageFile="~/hr360/mobile/master/greenMaster.master" AutoEventWireup="true" CodeFile="OTForm.aspx.cs" Inherits="hr360_mobile_OTForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../Scripts/moment-with-locales.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/tempusdominus-bootstrap-4/5.0.0-alpha14/js/tempusdominus-bootstrap-4.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/tempusdominus-bootstrap-4/5.0.0-alpha14/css/tempusdominus-bootstrap-4.min.css" />

    <style>
        .card-header a {
            color: white;
        }

            .card-header a:hover {
                color: #e8e8e8;
            }

        textarea {
            resize: none;
        }
    </style>
    <script>
        function pageLoad(sender, args) {
            $('.datetimepicker-input').keydown(function (e) {
                return false;
            });

            $('#applicationDatetimePicker').datetimepicker({
                ignoreReadonly: true,
                locale: 'zh-tw',
                buttons: {
                    showToday: true
                },
                format: "YYYY/MM/DD HH:mm",
                stepping: 30,
                toolbarPlacement: 'top'
            });

            autosize($('.autosize'));
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <nav>
            <div class="nav nav-tabs" id="nav-tab" role="tablist">
                <a class="nav-link active" id="nav-application-tab" data-toggle="tab" href="#nav-application" role="tab" aria-controls="nav-home" aria-selected="true">申請</a>
                <a class="nav-link" id="nav-approval-tab" data-toggle="tab" href="#nav-approval" role="tab" aria-controls="nav-profile" aria-selected="false">簽核</a>
                <a class="nav-link" id="nav-search-tab" data-toggle="tab" href="#nav-search" role="tab" aria-controls="nav-contact" aria-selected="false">查詢</a>
            </div>
        </nav>
        <div class="tab-content" id="nav-tabContent">
            <asp:UpdatePanel ID="upApplicationTab" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAddOTApplication" />
                </Triggers>
                <ContentTemplate>
                    <div class="tab-pane fade show active" id="nav-application" role="tabpanel" aria-labelledby="nav-home-tab">
                        <div class="form-group" style="color: red">
                            *員工因工作需要加班時，經權責主管核准後方可加班<br />
                            *最遲於加班發生後3日內完成申請<br />
                            *加班申報時數最小計算單位為0.5小時<br />
                            *延長之工作時間，平日不可超過3小時(含)、假日不可超過8小時(含)、單月總計不可超過46小時(含)
                        </div>
                        <div>
                            <asp:Button ID="btnOTApplication" runat="server" CssClass="btn btn-primary" Text="申請加班"
                                OnClick="btnOTApplication_Click" />
                            <asp:Button ID="btnOTAppointment" runat="server" CssClass="btn btn-primary" Text="申請派工" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="tab-pane fade" id="nav-approval" role="tabpanel" aria-labelledby="nav-profile-tab">
                <div class="form-group">
                    <asp:TextBox ID="TextBox1" runat="server" Text="approval"></asp:TextBox>
                </div>
            </div>
            <div class="tab-pane fade" id="nav-search" role="tabpanel" aria-labelledby="nav-contact-tab">
                <div class="form-group">
                    <asp:TextBox ID="TextBox3" runat="server" Text="search"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="upApplicationForm" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnOTApplication" />
            <asp:AsyncPostBackTrigger ControlID="btnAddOTApplication" />
        </Triggers>
        <ContentTemplate>
            <div class="modal fade" id="ApplicationForm" data-backdrop="static" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <asp:Label ID="lblApplicationFormTitle" runat="server" Text=""></asp:Label>
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </div>
                        <div class="modal-body">
                            <div class="input-group mb-1" id="applicationDatetimePicker" data-target-input="nearest">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">加班開始時間</span>
                                </div>
                                <asp:TextBox ID="txtApplicationOTDate" runat="server"
                                    CssClass="form-control datetimepicker-input"
                                    data-target="#applicationDatetimePicker"></asp:TextBox>
                                <div class="input-group-append" data-target="#applicationDatetimePicker" data-toggle="datetimepicker">
                                    <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                                </div>
                            </div>
                            <div class="input-group mb-1">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">預計加班時數</span>
                                </div>
                                <asp:TextBox ID="txtApplicationOTTimespan" runat="server" CssClass="form-control"></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="input-group-text">小時</span>
                                </div>
                            </div>
                            <div class="input-group mb-1">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">派工人員</span>
                                </div>
                                <asp:DropDownList ID="ddlOTAssigner" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="input-group mb-1">
                                <div class="input-group-prepend">
                                    <span class="input-group-text"> 補償方式</span>
                                </div>
                                <asp:DropDownList ID="ddlCompensationMethod" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            
                            <div class="row">
                                <div class="col-12">
                                    加班內容:
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <asp:TextBox ID="txtOTReason" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnAddOTApplication" runat="server" CssClass="btn btn-success w-100" Text="送出"
                                UseSubmitBehavior="false"
                                data-dismiss="modal"
                                OnClick="btnAddOTApplication_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

