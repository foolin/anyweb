<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ColumnList_Temp.aspx.cs" Inherits="ColumnList_Temp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <aw:ColumnList ID="columnList" runat="server">
        <ItemTemplate>
            <a href="columnlist_temp.aspx?id=<%#Eval("fdColuID") %>"><%#Eval("fdColuName") %></a>
        </ItemTemplate>
    </aw:ColumnList>
</body>
</html>
