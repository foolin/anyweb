<%@ Control Language="C#" AutoEventWireup="true" CodeFile="33.ascx.cs" Inherits="Contorls_Exhibitor_List_33" %>
<marquee width="100%" height="140" id="c2" onmouseout="this.start()" onmouseover="this.stop()"
    direction="up" scrollamount="1" scrolldelay="40">
    <asp:Repeater ID="rep" runat="server">
    <ItemTemplate>
        <a href="/195/index.html?id=<%#Eval("fdExhiID") %>"><%#Eval("fdExhiName") %></a><br />
    </ItemTemplate>
    </asp:Repeater>
</marquee>
