<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Column_Temp.aspx.cs" Inherits="Column_Temp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <aw:Column ID="column" runat="server" IDName="id" ErrorMsg="栏目不存在！" ErrorPage="/index.aspx">
        <ItemTemplate>
            <%#Eval("fdColuName")%>
        </ItemTemplate>
    </aw:Column>
    父级栏目：
    <aw:Column ID="column1" runat="server" IDName="id" ErrorMsg="栏目不存在！" ErrorPage="/index.aspx" ItemType="Parent">
        <ItemTemplate>
            <%#Eval("fdColuName")%>
        </ItemTemplate>
    </aw:Column>
    前一栏目：
    <aw:Column ID="column2" runat="server" IDName="id" ItemType="Previous">
        <ItemTemplate>
            <a href="column_temp.aspx?id=<%#Eval("fdColuID") %>"><%#Eval("fdColuName")%></a>
        </ItemTemplate>
    </aw:Column>
    后一栏目：
    <aw:Column ID="column3" runat="server" IDName="id" ItemType="Next">
        <ItemTemplate>
            <a href="column_temp.aspx?id=<%#Eval("fdColuID") %>"><%#Eval("fdColuName")%></a>
        </ItemTemplate>
    </aw:Column>
</body>
</html>
