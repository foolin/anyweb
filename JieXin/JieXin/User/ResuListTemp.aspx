<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResuListTemp.aspx.cs" Inherits="User_ResuListTemp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <a href="/User/ResuInit.aspx">添加</a>
    <form id="form1" runat="server">
    <table>
    <tr>
        <th>简历名称</th>
        <th>操作</th>
    </tr>
    <asp:Repeater ID="rep" runat="server">
        <ItemTemplate>
        <tr>
            <td><%#Eval("fdResuName")%></td>
            <td><a href="/User/ResuEditTemp.aspx?id=<%#Eval("fdResuID") %>">修改</a><a href="/User/ResuDelTemp.aspx">删除</a></td>
        </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
    </form>
</body>
</html>
