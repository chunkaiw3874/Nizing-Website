<%@ Page Title="" Language="C#" MasterPageFile="~/hr360/mobile/master/greenMaster.master" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="hr360_mobile_main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        //load news table from codebehind (converted to json)
        var newsTable = <%=jsonAnnouncementData%>;
        var newsLoaded = 0;
        //var imgBlob=Convert.toBase64String(<%=blob%>);
        //load json to textbox
        $(document).ready(function () {
            var wrap = document.getElementById('<%=news_list.ClientID%>');
            var offsetHeight = document.getElementById('<%=day_off_window.ClientID%>').offsetHeight;
            var contentHeight = wrap.offsetHeight;
            var win = $(window.top).height()-offsetHeight;
            do{
                LoadNews(1);   
                contentHeight=wrap.offsetHeight;
            }while(contentHeight<win);
            autosize($('textarea'));
            
            //var image = document.createElement('image');
            //image.src='data:image/jpeg;base64,'+Base64.encode(blob);
            //$('[id$=news_list]').append(image);
        });
        function LoadNews(numbersToLoad){
            for(var i=newsLoaded;i<newsLoaded+numbersToLoad;i++){
                if(i<newsTable.length){
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
                    txtBody.className = 'form-group no-resize';
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
            }
            newsLoaded+=numbersToLoad;
            $('textarea').each(function(index,textArea){
                autosize(textArea);
            })
        }
        //detects when user reaches the end
        window.addEventListener("scroll", function (){
            var wrap = document.getElementById('<%=news_list.ClientID%>');
            var contentHeight = wrap.offsetHeight;
            var yOffset = window.pageYOffset;
            var y = yOffset + window.innerHeight;
            if (y >= contentHeight) {
                //load new content
                LoadNews(1);
            }
        });
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
        <div class="row">
            <div class="col-sm-12">
                <h5>
                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>，您好，<asp:HyperLink ID="hlSalaryNotification" runat="server" NavigateUrl="~/hr360/user_report/salary_change_notification.aspx">您有調薪通知!</asp:HyperLink>
                </h5>
                
            </div>
        </div>
    </div>
    <div id="day_off_window" runat="server" class="container">
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
                            <div class="col-sm-3">
                                <asp:Label ID="lblFirstPartDayOff" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblSecondPartDayOff" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblDayOffMemo" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3">補休</div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblMakeupDayOff" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div></div>
    </div>
    <div class="container">
        <div>
            <h2>公告</h2>
        </div>
        <div id="news_list" class="infinite-scroll" runat="server">
        </div>
    </div>
    <div>
        <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/hr360/mobile/GetImage.aspx" />--%>
    </div>
</asp:Content>

