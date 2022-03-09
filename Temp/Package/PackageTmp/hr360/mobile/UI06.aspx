<%@ Page Title="" Language="C#" MasterPageFile="~/hr360/mobile/master/greenMaster.master" AutoEventWireup="true" CodeFile="UI06.aspx.cs" Inherits="hr360_UI06" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        @media print {
            body * {
                visibility: hidden;
                /*display:none;*/
            }

            .printarea * {
                visibility: visible;
                /*position:absolute; width:100%; top:0; padding:0; margin:-1px;*/
            }

            .printarea {
                position: absolute;
                top: 0;
                left: 0;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="input-group">
            <asp:DropDownList ID="ddlYear" runat="server" CssClass="custom-select"></asp:DropDownList>
            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="custom-select"></asp:DropDownList>
            <div class="input-group-append">
                <asp:Button ID="btnSubmit" runat="server"
                    CssClass="btn btn-success"
                    Text="查詢" OnClick="btnSubmit_Click" />
            </div>
        </div>
        <div>
            *此系統為薪資單查詢，非銀行入帳證明
        </div>
        <div style="margin-bottom: 10px">
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>
        </div>
        <div class="printarea">
            <div id="salary_slip" runat="server" visible="false" style="width: 1002px; display: flex; flex-direction: column;">
                <div style="height: 100px; margin-bottom: 5px; display: flex; flex-direction: row">
                    <div style="width: 300px; height: 100%; vertical-align: top;">
                        <div>
                            <asp:Image ID="imgCompanyLogo" runat="server" CssClass="img-fluid" Width="300px" />
                        </div>
                    </div>
                    <div style="width: 400px; height: 100%; text-align: center;">
                        <div style="font-size: 20px;"><b style="border-bottom: solid 1px #cccccc;">員工薪資單</b></div>
                        <span style="font-size:10px; color:black;">謝謝您這個月的辛苦及對公司的貢獻</span>
                    </div>
                    <div style="width: 300px; height: 100%; text-align: right;">
                        <div>
                            <asp:Label ID="lblYear" runat="server" Text=""></asp:Label>/<asp:Label ID="lblMonth" runat="server" Text=""></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblJob" runat="server" Text="" Visible="false"></asp:Label>
                        </div>
                        <div>
                            <span style="margin-right: 5px;">
                                <asp:Label ID="lblDept_Id" runat="server" Text=""></asp:Label></span>
                            <asp:Label ID="lblDept_Name" runat="server" Text=""></asp:Label>
                        </div>
                        <div>
                            <span style="margin-right: 5px;">
                                <asp:Label ID="lblEmp_Id" runat="server" Text=""></asp:Label></span>
                            <asp:Label ID="lblEmp_Name" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div style="border: solid 1px #cccccc; display: flex; flex-direction: row;">
                    <div style="width: 300px; display: flex; flex-direction: column; border-right: solid 1px #cccccc;">
                        <div style="display: flex; flex-direction: row; padding: 5px; border-bottom: solid 1px #cccccc;">
                            <div style="width: 50%; text-align: left;">
                                津貼
                            </div>
                            <div style="width: 50%; text-align: right;">
                                金額
                            </div>
                        </div>
                        <div style="display: flex; flex-direction: row; padding: 10px 5px 0px 5px;">
                            <div style="width: 50%; text-align: left;">
                                底(本)薪
                            </div>
                            <div style="width: 50%; text-align: right;">
                                <asp:Label ID="lblBaseSalary" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="display: flex; flex-direction: row; padding: 0px 5px 0px 5px;">
                            <div style="width: 50%; text-align: left;">
                                全勤獎金
                            </div>
                            <div style="width: 50%; text-align: right;">
                                <asp:Label ID="lblAttendanceBonus" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="display: flex; flex-direction: row; padding: 0px 5px 0px 5px;">
                            <div style="width: 50%; text-align: left;">
                                加班費
                            </div>
                            <div style="width: 50%; text-align: right;">
                                <asp:Label ID="lblOTSalary" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="display: flex; flex-direction: row; padding-bottom: 10px;">
                            <div style="width: 50%; text-align: left; padding: 0px 0px 0px 5px;">
                                <asp:Panel ID="pnlBonusName" runat="server"></asp:Panel>
                            </div>
                            <div style="width: 50%; text-align: right; padding: 0px 5px 0px 0px;">
                                <asp:Panel ID="pnlBonusAmount" runat="server"></asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div style="width: 400px; display: flex; flex-direction: column; border-right: solid 1px #cccccc;">
                        <div style="display: flex; flex-direction: row; padding: 5px; border-bottom: solid 1px #cccccc;">
                            <div style="width: 50%; text-align: left;">
                                扣款
                            </div>
                            <div style="width: 50%; text-align: right;">
                                金額
                            </div>
                        </div>
                        <div style="display: flex; flex-direction: row; padding: 10px 5px 0px 5px;">
                            <div style="width: 50%; text-align: left;">
                                請假扣款
                            </div>
                            <div style="width: 50%; text-align: right;">
                                <asp:Label ID="lblDayOffDeduction" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="display: flex; flex-direction: row; padding: 0px 5px 0px 5px;">
                            <div style="width: 50%; text-align: left;">
                                健保費
                            </div>
                            <div style="width: 50%; text-align: right;">
                                <asp:Label ID="lblHealthCareDeduction" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="display: flex; flex-direction: row; padding: 0px 5px 0px 5px;">
                            <div style="width: 50%; text-align: left;">
                                勞保費
                            </div>
                            <div style="width: 50%; text-align: right;">
                                <asp:Label ID="lblLaborRetirementDeduction" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="display: flex; flex-direction: row; padding: 0px 5px 0px 5px;">
                            <div style="width: 50%; text-align: left;">
                                員工提繳
                            </div>
                            <div style="width: 50%; text-align: right;">
                                <asp:Label ID="lblEmployeeMatch" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="display: flex; flex-direction: row; padding: 0px 5px 0px 5px;">
                            <div style="width: 50%; text-align: left;">
                                補充保費
                            </div>
                            <div style="width: 50%; text-align: right;">
                                <asp:Label ID="lblHealthCareDeductionAppend" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="display: flex; flex-direction: row; padding-bottom: 10px;">
                            <div style="width: 50%; text-align: left; padding: 0px 0px 0px 5px;">
                                <asp:Panel ID="pnlDeductionName" runat="server"></asp:Panel>
                            </div>
                            <div style="width: 50%; text-align: right; padding: 0px 5px 0px 0px;">
                                <asp:Panel ID="pnlDeductionAmount" runat="server"></asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div style="width: 300px; display: flex; flex-direction: column;">
                        <div style="padding: 5px; border-bottom: solid 1px #cccccc;">
                            <div style="width: 100%; text-align: center;">
                                出勤
                            </div>
                        </div>
                        <div style="display: flex; flex-direction: row; padding: 10px 5px 0px 5px;">
                            <div style="width: 50%; text-align: left;">
                                出勤天數
                            </div>
                            <div style="width: 50%; text-align: right;">
                                <asp:Label ID="lblAttendanceDay" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="display: flex; flex-direction: row; padding: 0px 5px 0px 5px;">
                            <div style="width: 50%; text-align: left;">
                                加班時數
                            </div>
                            <div style="width: 50%; text-align: right;">
                                <asp:Label ID="lblOTTime" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="display: flex; flex-direction: row; padding-bottom: 10px;">
                            <div style="width: 50%; text-align: left; padding: 0px 0px 0px 5px;">
                                <asp:Panel ID="pnlAttendanceName" runat="server"></asp:Panel>
                            </div>
                            <div style="width: 50%; text-align: right; padding: 0px 5px 0px 0px;">
                                <asp:Panel ID="pnlAttendanceTime" runat="server"></asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="display: flex; flex-direction: column; border: solid 1px #cccccc; border-top: 0px;">
                    <div style="display: flex; flex-direction: row; border-bottom: solid 1px #cccccc;">
                        <div style="width: 300px; display: flex; flex-direction: row; border-right: solid 1px #cccccc;">
                            <div style="width: 40%; text-align: center; border-right: solid 1px #cccccc; padding: 5px;">
                                公司提繳
                            </div>
                            <div style="width: 60%; text-align: right; padding: 5px;">
                                <asp:Label ID="lblCompanyMatch" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="width: 400px; display: flex; flex-direction: row; border-right: solid 1px #cccccc;">
                            <div style="width: 30%; text-align: center; border-right: solid 1px #cccccc; padding: 5px;">
                                津貼合計
                            </div>
                            <div style="width: 40%; text-align: right; border-right: solid 1px #cccccc; padding: 5px;">
                                <asp:Label ID="lblBonusTotal" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width: 30%; text-align: center; padding: 5px;">
                                課稅所得
                            </div>
                        </div>
                        <div style="width: 300px; display: flex; flex-direction: row;">
                            <div style="width: 40%; text-align: right; border-right: solid 1px #cccccc; padding: 5px;">
                                <asp:Label ID="lblTaxable" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width: 30%; text-align: center; border-right: solid 1px #cccccc; padding: 5px;">
                                應發金額
                            </div>
                            <div style="width: 30%; text-align: right; padding: 5px;">
                                <asp:Label ID="lblNominalSalary" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div style="display: flex; flex-direction: row; border-bottom: solid 1px #cccccc;">
                        <div style="width: 300px; display: flex; flex-direction: row; border-right: solid 1px #cccccc;">
                            <div style="width: 40%; text-align: center; border-right: solid 1px #cccccc; padding: 5px;">
                                員工累計
                            </div>
                            <div style="width: 60%; text-align: right; padding: 5px;">
                                <asp:Label ID="lblEmployeeMatchTotal" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="width: 400px; display: flex; flex-direction: row; border-right: solid 1px #cccccc;">
                            <div style="width: 30%; text-align: center; border-right: solid 1px #cccccc; padding: 5px;">
                                扣款合計
                            </div>
                            <div style="width: 40%; text-align: right; border-right: solid 1px #cccccc; padding: 5px;">
                                <asp:Label ID="lblDeductionTotal" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width: 30%; text-align: center; padding: 5px;">
                            </div>
                        </div>
                        <div style="width: 300px; display: flex; flex-direction: row;">
                            <div style="width: 40%; text-align: center; border-right: solid 1px #cccccc; padding: 5px;">
                            </div>
                            <div style="width: 30%; text-align: center; border-right: solid 1px #cccccc; padding: 5px;">
                                實發金額
                            </div>
                            <div style="width: 30%; text-align: right; padding: 5px;">
                                <asp:Label ID="lblRealSalary" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div style="display: flex; flex-direction: row;">
                        <div style="width: 300px; display: flex; flex-direction: row; border-right: solid 1px #cccccc;">
                            <div style="width: 40%; text-align: center; border-right: solid 1px #cccccc; padding: 5px;">
                                公司累計
                            </div>
                            <div style="width: 60%; text-align: right; padding: 5px;">
                                <asp:Label ID="lblCompanyMatchTotal" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="width: 698px; display: flex; flex-direction: row;">
                            <div style="width:143px;text-align: center; border-right: solid 1px #cccccc; padding: 5px;">
                                帳號
                            </div>
                            <div style="width:100%; text-align: center; padding: 5px;">
                                <asp:Label ID="lblAccount" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

