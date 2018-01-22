<%@ Page Title="" Language="C#" MasterPageFile="~/hr360/mobile/master/greenMaster.master" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="hr360_mobile_main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        //load news table from codebehind (converted to json)
        var newsTable = <%=jsonAnnouncementData%>;
        var newsLoaded = 0;
        //load json to textbox
        $(document).ready(function () {
            //var obj = JSON.parse(newsTable);
            //ToJavaScriptDate(newsTable.CREATE_TIME);           
            LoadNews(2);
        });
        function LoadNews(numbersToLoad){
            for(var i=newsLoaded;i<newsLoaded+numbersToLoad;i++){
                var createDate = new Date(parseInt(newsTable[i]['CREATE_TIME'].replace('/Date(', '')));
                var modifyDate = new Date(parseInt(newsTable[i]['LAST_EDIT_TIME'].replace('/Date(', '')));
                var divRow = document.createElement('div');
                divRow.className = 'row';
                var divHeading = document.createElement('div');
                divHeading.className = 'col-sm-2';                
                var heading = document.createElement('span');
                heading.innerText = newsTable[i]['CREATE_TIME'].substring(0,10);
                var divBody = document.createElement('div');
                divBody.className = 'col-sm-9';
                var txtBody = document.createElement('textarea');
                txtBody.readOnly=true;
                txtBody.className = 'form-group no-resize autosize';
                txtBody.style="border-width:0px;width:100%;";
                txtBody.innerHTML = newsTable[i]['BODY'].replace(/(?:\r\n|\r|\n)/g, '\n');
                var editNote = document.createElement('span');
                editNote.style = 'color:Gray;font-size:6pt;font-style:italic;';
                editNote.innerText = '最後編輯: ' + newsTable[i]['EDITOR_NAME'] + ' ' + newsTable[i]['LAST_EDIT_TIME'];
                divHeading.appendChild(heading);
                divBody.appendChild(txtBody);
                divBody.appendChild(editNote);
                divRow.appendChild(divHeading);
                divRow.appendChild(divBody);
                $('[id$=news_list]').append('<hr/>').append(divRow);                
            }
            newsLoaded+=numbersToLoad;
        }
        //detects when user reaches the end
        window.addEventListener("scroll", function () {
            var wrap = document.getElementById('news_list');
            var contentHeight = wrap.offsetHeight;
            var yOffset = window.pageYOffset;
            var y = yOffset + window.innerHeight;
            if (y >= contentHeight) {
                //load new content
                LoadNews(1);

            }
        })
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
<%--        <div>
            <asp:TextBox ID="txtTest" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>--%>
    </div>
</asp:Content>

