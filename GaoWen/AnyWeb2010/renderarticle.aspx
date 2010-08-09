<%@ Page Language="C#" AutoEventWireup="true" CodeFile="renderarticle.aspx.cs" Inherits="renderarticle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="width:810px;">
    <img src="public/images/pdflog.jpg" alt="" />
    <div style="width:800px;">
    <asp:Repeater ID="rep" runat="server">
        <ItemTemplate>
            <%#Eval("fdArtiContent") %>
        </ItemTemplate>
    </asp:Repeater>
    </div>
    </div>
</body>
</html>
