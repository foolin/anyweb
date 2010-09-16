<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArticleList_temp.aspx.cs" Inherits="ArticleList_temp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <aw:ArticleList ID="article" runat="server" IDName="id" GetChild="true" PagerID="page1" Order="fdArtiID ASC">
        <ItemTemplate>
            <%#Eval("fdArtiTitle") %><br />
        </ItemTemplate>
    </aw:ArticleList>
    <aw:Pager ID="page1" runat="server" PageSize="1"></aw:Pager>
</body>
</html>
