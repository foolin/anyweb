<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Notice_Temp.aspx.cs" Inherits="Notice_Temp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <AW:NOTICE ID="notice" runat="server">
        <ItemTemplate>
            标题:<%#Eval("fdNotiTitle") %>
        </ItemTemplate>
    </AW:NOTICE>
    <AW:NOTICE ID="pre" runat="server" ItemType="Previous">
        <ItemTemplate>
            上一篇：<a href="<%#Eval("fdNotiPath") %>"><%#Eval("fdNotiTitle")%></a>
        </ItemTemplate>
    </AW:NOTICE>
    <AW:NOTICE ID="next" runat="server" ItemType="Next">
        <ItemTemplate>
            下一篇：<a href="<%#Eval("fdNotiPath") %>"><%#Eval("fdNotiTitle")%></a>
        </ItemTemplate>
    </AW:NOTICE>
</body>
</html>
