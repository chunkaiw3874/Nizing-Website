<%@ Page Language="C#" AutoEventWireup="true" CodeFile="oqs.aspx.cs" Inherits="testApplication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="JavaScript">

var nAgt = navigator.userAgent;
if (getIEVersion()==-1) {
alert("請於 Internet Explorer(IE)瀏覽器使用");

}

function getIEVersion()
{
  var rv = -1;
  if (navigator.appName == 'Microsoft Internet Explorer')
  {
    var ua = navigator.userAgent;
    var re  = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");
    if (re.exec(ua) != null)
      rv = parseFloat( RegExp.$1 );
  }
  else if (navigator.appName == 'Netscape')
  {
    var ua = navigator.userAgent;
    var re  = new RegExp("Trident/.*rv:([0-9]{1,}[\.0-9]{0,})");  //for IE 11
    if (re.exec(ua) != null)
      rv = parseFloat( RegExp.$1 );
  }
  return rv;
}

  </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/application/OQS/NizingElectric.pfx">Download Certificate</asp:HyperLink>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <div>
            <iframe id="iframe1" runat="server" src="../application/OQS/WpfHost.xbap" height="700" width="700"></iframe>
        </div>
    </form>
</body>
</html>
