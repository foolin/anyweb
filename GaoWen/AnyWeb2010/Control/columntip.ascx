<%@ Control Language="C#" AutoEventWireup="true" CodeFile="columntip.ascx.cs" Inherits="Control_columntip" %>
<a href="index.aspx">首页</a>
<asp:Repeater ID="repTip" runat="server">
    <ItemTemplate>
        - <a href="column.aspx?id=<%#Eval("fdColuID") %>"><%#Eval("fdColuName") %></a>
    </ItemTemplate>
</asp:Repeater>