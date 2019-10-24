<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="src/css/style.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            alert('text text');
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
    </div>
    </form>
</body>
</html>
