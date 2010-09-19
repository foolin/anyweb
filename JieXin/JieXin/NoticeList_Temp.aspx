<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoticeList_Temp.aspx.cs" Inherits="NoticeList_Temp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <AW:NOTICELIST ID="notice" runat="server" PagerID="page1">
        <ItemTemplate>
            <a href="<%#Eval("fdNotiPath") %>"><%#Eval("fdNotiTitle") %></a><br />
        </ItemTemplate>
    </AW:NOTICELIST>
    <aw:Pager ID="page1" runat="server" PageSize="1"></aw:Pager>
</body>
</html>
