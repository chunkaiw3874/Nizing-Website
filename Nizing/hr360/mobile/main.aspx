<%@ Page Title="" Language="C#" MasterPageFile="~/hr360/mobile/master/greenMaster.master" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="hr360_mobile_main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        //detects when user reaches the end
        window.addEventListener("scroll", function () {
            var wrap = document.getElementById('news_list');
            var contentHeight = wrap.offsetHeight;
            var yOffset = window.pageYOffset;
            var y = yOffset + window.innerHeight;
            var x = 0;
            if (y >= contentHeight) {
                x += 1
                //load new content
                wrap.innerHTML = wrap.innerHTML + "<div>this is added line " + x.toString() + "</div>";

            }
        })
        $(function () {
            $('.autosize').autosize();
        });
        //$('.infinite-scroll').jscroll({
        //    autoTrigger: false
        //});
        function ShowNews() {
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
        }
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

