<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Child_user.master" AutoEventWireup="true" CodeFile="evaluationBonusView.aspx.cs" Inherits="hr360_evaluationBonusView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="javascript_section" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="top_menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="page_content" Runat="Server">
     <div class="container">
         <div class="row">
             <div class="col-xs-9">
                 <h3>我的年終獎金</h3>
             </div>             
         </div>
         <div class="row">
             <div class="col-xs-9">
                 <table class="table table-bordered">
                     <thead>
                         <tr>
                             <th class="col-xs-3">項目</th>
                             <th class="col-xs-3">金額</th>
                             <th class="col-xs-3">備註</th>
                         </tr>
                     </thead>
                     <tbody>                         
                         <tr>
                             <td>
                                 年度考績
                             </td>
                             <td>
                                 <asp:Label ID="lblAssessmentBonus" runat="server" Text=""></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblAssessmentMemo" runat="server" Text=""></asp:Label>
                             </td>
                         </tr>                         
                         <tr>
                             <td>
                                 特休未休
                             </td>
                             <td>
                                 <asp:Label ID="lblUnusedDayOffBonus" runat="server" Text=""></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblUnusedDayOffMemo" runat="server" Text=""></asp:Label>
                             </td>
                         </tr>                         
                         <tr>
                             <td>
                                 年度全勤
                             </td>
                             <td>
                                 <asp:Label ID="lblAttendanceBonus" runat="server" Text=""></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblAttendanceMemo" runat="server" Text=""></asp:Label>
                             </td>
                         </tr>                         
                         <tr>
                             <td>
                                 年度獎懲
                             </td>
                             <td>
                                 <asp:Label ID="lblRnPBonus" runat="server" Text=""></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblRnPMemo" runat="server" Text=""></asp:Label>
                             </td>
                         </tr>                         
                         <tr>
                             <td>
                                 其他項目
                             </td>
                             <td>
                                 <asp:Label ID="lblOtherBonus" runat="server" Text=""></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblOtherBonusMemo" runat="server" Text=""></asp:Label>
                             </td>
                         </tr>                         
                         <%--<tr>
                             <td>
                                 其他減項
                             </td>
                             <td>
                                 <asp:Label ID="lblOtherDeduction" runat="server" Text=""></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblOtherDeductionMemo" runat="server" Text=""></asp:Label>
                             </td>
                         </tr>                         
 --%>                        <tr>
                             <td>
                                 總金額
                             </td>
                             <td>
                                 <asp:Label ID="lblFinalBonus" runat="server" Text=""></asp:Label>
                             </td>
                             <td>
                             </td>
                         </tr>
                     </tbody>
                 </table>
             </div>
         </div>
         <div class="row">
             <div class="col-xs-9">
                 <asp:Image ID="imgBonusAttachment" runat="server" />
             </div>
         </div>
     </div>
</asp:Content>

