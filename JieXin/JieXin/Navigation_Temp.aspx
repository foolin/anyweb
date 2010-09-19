<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Navigation_Temp.aspx.cs"
    Inherits="Navigation_Temp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <AW:NAVIGATION ID="navigation1" runat="server">
        <ItemTemplate>
            一级导航：<%#Eval("fdNaviTitle") %>
            <AW:NAVIGATION ID="navi2" runat="server" DataSource='<%#Eval("Children") %>'>
                <ItemTemplate>
                    二级导航：<a href="<%#Eval("fdNaviLink") %>"><%#Eval("fdNaviTitle") %></a>
                </ItemTemplate>
            </AW:NAVIGATION>
        </ItemTemplate>
    </AW:NAVIGATION>
</body>
</html>
