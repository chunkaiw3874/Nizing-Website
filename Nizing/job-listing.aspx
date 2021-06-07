<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="job-listing.aspx.cs" Inherits="job_listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #qjobDiv {
            width: 100% !important;
            max-height: 1000px !important;
            min-height: 600px !important;
            margin-top: 56px !important;
        }

        iframe {
            height: 100%;
        }

        form#form1 .body{
            padding: 0;
            height: 0;
        }
        /*#qjobDiv img {
                display: none;
            }*/
    </style>

    <script type="text/javascript" src="//static.104.com.tw/104i/js/plugin/stickers/qjob.js"></script>
    <script>
        //$(function () {
        //    console.log('script begins');

        //    var j104Widget = function (oo) {
        //        if (oo) {
        //            for (p in oo) {
        //                this.s[p] = oo[p];
        //            };
        //        };
        //    };

        //    j104Widget.prototype.s = {
        //        "qjobsrc": '//www.104.com.tw/jb/104i/joblist/qjob?pgsz=15',
        //        "logo": '//static.104.com.tw/104i/images/qjob/logo.gif',
        //        "qjobWidth": 400,
        //        "qjobHeight": 200,
        //        "hideList": ""
        //    };

        //    j104Widget.prototype.output = function () {
        //        var s = this.s;
        //        tmp = decodeURIComponent(s.qjobsrc).split('?');

        //        str = '<div id="qjobDiv" style="width:' + this.s.qjobWidth + 'px; height:' + this.s.qjobHeight + 'px; padding: 8px 0 8px 8px !important;">';
        //        str += '<iframe id="qjobiframe" name="qjobiframe" width="100%" height="100%" frameborder="0" src=""></iframe>';
        //        str += '<img src="' + this.s.logo + '" style="margin-top: 10px;float: right;" /></div>';

        //        str += '<div id="postdataDiv" style="display:none;">';
        //        str += '<form id="postForm" action="' + s.qjobsrc + '" method="get" target="qjobiframe">';
        //        if (tmp.length > 1) {
        //            tmp2 = tmp[1].split('&');
        //            for (var i = tmp2.length - 1; i >= 0; i--) {
        //                paramArray = tmp2[i].split('=');
        //                str += '<input type="text" name="' + paramArray[0] + '" value="' + paramArray[1] + '" />';
        //            };

        //        }
        //        str += '<input type="text" name="hideList" value="' + s.hideList + '" />';
        //        str += '</form>';
        //        str += '</div>';
        //        document.write(str);
        //        postdata();
        //    }




        b = new j104Widget({
            "logo": "",
            "qjobsrc": "//www.104.com.tw/jb/104i/joblist/qjob?c=4870426b565c3e2240323c1d1d1d1d5f2443a363189j56&order=8,0",
            "qjobWidth": "600",
            "qjobHeight": "612",
            "hideList": ""
        }); b.output();
        //});



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
</asp:Content>

