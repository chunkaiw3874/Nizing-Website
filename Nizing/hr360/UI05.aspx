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
                <%--<h3>公告</h3>--%>
                <img src="image/banner/公告.png" height="30" />
            </div>
        </div>
        <!--2018.02.08 per Chrissy, 隱藏公告-->
        <div class="row" hidden="hidden">   
            <div class="col-xs-9" style="border: solid 1px #006837; border-radius: 5px; margin-top: 5px;">
                <div style="margin-bottom: 10px;">
                    2017年年終獎金參考計算方式:評核時間為2016/01/01~2016/12/31之綜合表現<br />
                    <br />
                    1.年資滿一年:<br />
                    年度平均底薪x考績等級之月份<br />
                    <br />
                    甲等: 3個月 x個人考績分數<br />
                    乙等: 2.5個月 x個人考績分數<br />
                    丙等: 視狀況而定<br />
                    <br />
                    2.年資未滿一年:<br />
                    甲、乙等: 年度平均底薪x 1個月 /12個月 x 到職月份<br />                    
                    丙等: 視狀況而定<br />
                </div>
                <div>
                    <img src="image/assessment/考核公告1.jpg" />
                </div>
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
        <div id="divPlaceholder" class="row" runat="server">
            *查詢功能將會於評分結束後重新開啟
        </div>       
        <div id="divAssessmentLookup" runat="server">
            <div class="row">
                <div class="col-xs-9" style="margin-bottom: 10px; margin-top: 10px;">
                    <%--<h3>我的年度考績表</h3>--%>
                    <img src="image/banner/我的年度考績表.png" height="30" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2">
                    <asp:DropDownList ID="ddlAssessmentYear" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-1">
                    <asp:Button ID="btnAssessmentSearch" runat="server" Text="查詢" CssClass="btn btn-success form-control" OnClick="btnAssessmentSearch_Click" />
                </div>
            </div>
        </div>
        <div id="divBonusLookup" runat="server">
            <div class="row">
                <div class="col-xs-9" style="margin-bottom: 10px; margin-top: 10px;">
                    <%--<h3>我的年終獎金</h3>--%>
                    <img src="image/banner/我的年終獎金.png" height="30" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2">
                    <asp:DropDownList ID="ddlBonusYear" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-1">
                    <asp:Button ID="btnBonusSearch" runat="server" Text="查詢" CssClass="btn btn-success form-control" OnClick="btnBonusSearch_Click" />
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

