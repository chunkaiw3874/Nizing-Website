<%@ Page Title="" Language="C#" MasterPageFile="~/hr360/mobile/master/greenMaster.master" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="hr360_mobile_main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        //load news table from codebehind (converted to json)
        var newsTable = <%=jsonAnnouncementData%>;

        //load json to textbox
        $(document).ready(function () {
            //var obj = JSON.parse(newsTable);
            //ToJavaScriptDate(newsTable.CREATE_TIME);
            for(var i=0;i<newsTable.length;i++){
                var createDate = new Date(parseInt(newsTable[i]['CREATE_TIME'].replace('/Date(', '')));
                var modifyDate = new Date(parseInt(newsTable[i]['LAST_EDIT_TIME'].replace('/Date(', '')));
                var textarea = document.createElement("textarea")
                textarea.readOnly=true;
                textarea.attributes["class"] = "form-group no-resize autosize";
                textarea.style="border-width:0px;width:100%;color:Gray;";
                textarea.innerHTML = newsTable[i]['BODY'].replace(/(?:\r\n|\r|\n)/g, '<br>');
                $('[id$=news_list]').append(textarea);
                //$('[id$=news_list]').append('<hr/>')
                //.append('<div class="row">')
                //    .append('<div class="col-sm-2">')
                //        .append('<span class="form-ctonrol">')
                //            .append(createDate.getFullYear()+'-'+createDate.getMonth()+'-'+createDate.getDay())
                //        .append('</span>')
                //    .append('</div>')
                //    .append('<div class="col-sm-9">')
                //        .append('<textarea readonly="readonly" class="form-group no-resize autosize" style="border-width:0px;width:100%;">')
                //            .append(newsTable[i]['BODY'].replace(/(?:\r\n|\r|\n)/g, '<br />'))
                //        .append('</textarea>')
                //    .append('</div>')
                //    .append('<div>')
                //        .append('<span style="color:Gray;font-size:6pt;font-style:italic;">')
                //            .append('最後編輯: ' + newsTable[i]['EDITOR_NAME'] + ' ' + modifyDate)
                //        .append('</span>')
                //    .append('</div>')
                //.append('</div>')
            }
            //$('[id$=txtTest]').val('123');
        });
        //function ToJavaScriptDate(value) {
        //    var pattern = /Date\(([^)]+)\)/;
        //    var results = pattern.exec(value);
        //    var dt = new Date(parseFloat(results[1]));
        //    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
        //}
        //detects when user reaches the end
        //window.addEventListener("scroll", function () {
        //    var wrap = document.getElementById('news_list');
        //    var contentHeight = wrap.offsetHeight;
        //    var yOffset = window.pageYOffset;
        //    var y = yOffset + window.innerHeight;
        //    var x = 0;
        //    if (y >= contentHeight) {
        //        x += 1
        //        //load new content
        //        wrap.innerHTML = wrap.innerHTML + "<div>this is added line " + x.toString() + "</div>";

        //    }
        //})
        $(function () {
            $('.autosize').autosize();
        });
        //$('.infinite-scroll').jscroll({
        //    autoTrigger: false
        //});
<%--        function ShowNews() {
            $.ajax({
                type: "POST",
                url: "main.aspx/GetNews",
                data: '{dt: ' + <%=this.dtAnnouncementData%> + ', row: ' + <%=this.lastNewsRow%> + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function () {
                    alert('failed');
                }
            });
        }
        function OnSuccess() {
            alert('success');
        }--%>
        //function ShowCurrentTime() {
        //    $.ajax({
        //        type: "POST",
        //        url: "main.aspx/GetCurrentTime",
        //        data: '{name: "Kevin" }',
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: OnSuccess,
        //        failure: function (response) {
        //            alert(response.d);
        //        }
        //    });
        //}
        //function OnSuccess(response) {
        //    alert(response.d);
        //}
    </script>
    <style>
        .form-control {
            border: none;
        }

        .no-resize {
            resize: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="panel-group" id="accordion">
            <div class="panel-info">
                <div class="panel-heading" data-toggle="collapse" data-parent="#accordion" data-target="#dayoff_remain">
                    <h4 class="panel-title">剩餘假期
                    </h4>
                </div>
                <div id="dayoff_remain" class="panel-collapse collapse in">
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-3">特休</div>
                            <div class="col-sm-3">上半季特休剩餘</div>
                            <div class="col-sm-3">下半季特休剩餘</div>
                            <div class="col-sm-3">kakakalalalalalala</div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3">補休</div>
                            <div class="col-sm-3">剩餘時數</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <input id="btnGetTime" type="button" value="Show More News"
    onclick = "ShowNews()" />
        <div>
            <h2>最新公告</h2>
        </div>
        <div id="news_list" class="infinite-scroll" runat="server">
        </div>
        <div>
            <asp:TextBox ID="txtTest" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
</asp:Content>

