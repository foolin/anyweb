<%@ Control Language="C#" AutoEventWireup="true" CodeFile="39.ascx.cs" Inherits="Contorls_Exhibitor_List_39" %>
<marquee width="100%" height="140" scrolldelay="40" scrollamount="1" direction="up"
    onmouseover="this.stop()" onmouseout="this.start()" id="c2">
    <asp:Repeater ID="rep" runat="server">
    <ItemTemplate>
        <a href="/247/index.html?id=<%#Eval("fdExhiID") %>"><%#Eval("fdExhiName") %></a><br />
    </ItemTemplate>
    </asp:Repeater>
</marquee>
<div class="blank15px">
</div>
<div class="tc">
    <a href="/247/index.html" class="btn_Blue"><i>Search</i></a>
</div>
