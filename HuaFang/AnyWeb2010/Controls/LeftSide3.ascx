<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftSide3.ascx.cs" Inherits="Controls_LeftSide3" %>
<div class="title-bar">
    <h2 class="cs-clear">
        <p class="title-ch cs-fl">
            <span>特别推介</span></p>
    </h2>
</div>
<div class="Pho_Cap_Recom">
    <asp:Repeater ID="repRecomment1" runat="server">
        <ItemTemplate>
            <a href="<%#Eval("fdArtiPath") %>" class="PhoCap-a">
                <img src="<%#Eval("fdArtiPic") %>" /></a>
            <h3>
                <a href="<%#Eval("fdArtiPath") %>">
                    <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 15, false )%></a></h3>
        </ItemTemplate>
    </asp:Repeater>
    <ul class="list-disc">
        <asp:Repeater ID="repRecomment2" runat="server">
            <ItemTemplate>
                <li><a href="<%#Eval("fdArtiPath") %>">
                    <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 20, false )%></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
