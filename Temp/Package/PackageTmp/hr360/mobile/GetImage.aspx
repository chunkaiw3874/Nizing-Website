<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<% 
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    using (SqlConnection conn = new SqlConnection(ERP2connectionString))
    {
        conn.Open();
        string query = "SELECT [DATA] FROM HR360_FILE_STORAGE";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.CommandType = CommandType.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        Response.BinaryWrite((byte[])dr["DATA"]);
    }
 
%>
<!DOCTYPE html>

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
