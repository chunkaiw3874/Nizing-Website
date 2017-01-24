<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Child_user.master" AutoEventWireup="true" CodeFile="UI05.aspx.cs" Inherits="hr360_UI05" %>

<asp:Content ID="Content1" ContentPlaceHolderID="javascript_section" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_title" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="top_menu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="page_content" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-xs-9">
                2017年年終獎金計算方式:<br />
                年度平均底薪x考績等級之月份<br />
                <br />
                甲等: 3個月 x個人考績分數<br />
                乙等: 2.5個月 x個人考績分數<br />
                丙等: 視狀況而定<br />
                <br />
                年資未滿一年之計算方式:<br />
                年度平均底薪x 1個月 /12個月 x 到職月份<br />
            </div>
        </div>
        <br />
        <div id="divAssessmentList" runat="server">
            <div class="row">
                <div class="col-xs-9">
                    <h3>等待評核人員</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-9">
                    <table id="tbFirstAssessment" class="table table-bordered">
                        <thead>
                            <tr>
                                <th class="col-xs-3">自評</th>
                                <th class="col-xs-3">主管評</th>
                                <th class="col-xs-3">特評</th>
                            </tr>
                        </thead>
                        <tbody id="tbFirstAssessmentBody" runat="server">
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-9">
                    <h3>已評核人員(點選修改)</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-9">
                    <table id="tbAssessmentEdit" class="table table-bordered">
                        <thead>
                            <tr>
                                <th class="col-xs-3">自評</th>
                                <th class="col-xs-3">主管評</th>
                                <th class="col-xs-3">特評</th>
                            </tr>
                        </thead>
                        <tbody id="tbAssessmentEditBody" runat="server">
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div id="divAssessmentBonus" runat="server">
            <div class="row">
                <div class="col-xs-9">
                    <h3>評核獎金</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-1">
                    考績金額:
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="lblAssessmentBonus" runat="server" CssClass="form-control"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-1">
                    休假未修:
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="lblUnusedDayOffBonus" runat="server" CssClass="form-control" placeholder="金額"></asp:Label>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="lblUnusedDayOffMemo" runat="server" CssClass="form-control" placeholder="備註"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-1">
                    年度全勤:
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="lblAttendanceBonus" runat="server" CssClass="form-control" placeholder="金額"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-1">
                    其他加項:
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="lblOtherBonus" runat="server" CssClass="form-control" placeholder="金額"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-1">
                    其他減項:
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="lblOtherDeduction" runat="server" CssClass="form-control" placeholder="金額"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-1">
                    總金額:
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="lblFinalBonus" runat="server" Text="0" CssClass="form-control"></asp:Label>
                </div>
            </div>
        </div>
        <div id="divAdminViewList" runat="server" visible="false">
            <div class="row">
                <div class="col-xs-9">
                    <h3>個人考績評核總表</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2">
                    <asp:DropDownList ID="ddlViewYear" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-2">
                    <asp:DropDownList ID="ddlAdminViewList" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-1">
                    <asp:Button ID="btnSearch" runat="server" Text="查詢" CssClass="btn btn-success form-control" OnClick="btnSearch_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-9">
                    <h3>個人獎金資料輸入</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2">
                    <asp:DropDownList ID="ddlViewYear2" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-2">
                    <asp:DropDownList ID="ddlAdminViewList2" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-1">
                    <asp:Button ID="btnSearch2" runat="server" Text="查詢" CssClass="btn btn-success form-control" OnClick="btnSearch2_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

