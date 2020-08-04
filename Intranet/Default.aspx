<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/portal-master.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Portal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        a img{
            width:146px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <a href="nizing-default.aspx"><img src="image/NEW.png" /></a>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <a href="sunrise-default.aspx"><img src="image/SUNRISE.png" /></a>
        </div>
    </div>
</asp:Content>

