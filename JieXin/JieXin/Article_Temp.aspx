<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Article_Temp.aspx.cs" Inherits="Article_Temp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文章</title>
</head>
<body>
    <aw:Article ID="article" runat="server" ArticleID="4" IDName="id" ErrorMsg="文章不存在！" ErrorPage="/index.aspx">
        <ItemTemplate>
            标题:<%#Eval("fdArtiTitle") %>
        </ItemTemplate>
    </aw:Article>
    <aw:Article ID="pre" runat="server" IDName="id" ItemType="Previous">
        <ItemTemplate>
            上一篇：<a href="article_temp.aspx?id=<%#Eval("fdArtiID") %>"><%#Eval("fdArtiTitle") %></a>
        </ItemTemplate>
    </aw:Article>
    <aw:Article ID="Article1" runat="server" IDName="id" ItemType="Next">
        <ItemTemplate>
            上一篇：<a href="article_temp.aspx?id=<%#Eval("fdArtiID") %>"><%#Eval("fdArtiTitle") %></a>
        </ItemTemplate>
    </aw:Article>
</body>
</html>
