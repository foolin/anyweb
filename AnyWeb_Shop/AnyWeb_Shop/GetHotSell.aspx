<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetHotSell.aspx.cs" Inherits="GetHotSell" %>

<asp:repeater id="repHot" runat="server">
    <ItemTemplate>
        <li><a href="http://shop.thshcoop.com/Good.aspx?gid=<%#Eval("ID") %>" target="_blank">
            <img src="http://shop.thshcoop.com<%#(string)Eval( "image" )=="" ? "/images/wait.jpg":(string)Eval( "image" ) %>"
                width="120" height="90" alt="<%#Eval("GoodsName") %>" /></a> <a href="http://shop.thshcoop.com/Good.aspx?gid=<%#Eval("ID") %>"
                    target="_blank">
                    <%#Studio.Web.WebAgent.GetLeft((string)Eval("GoodsName"), 10, true)%></a>
        </li>
    </ItemTemplate>
</asp:repeater>
