<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleListSkin4.ascx.cs"
    Inherits="Controls_ArticleListSkin4" %>
<div class="g_360 cs-fl">
    <asp:Repeater ID="rep1" runat="server">
        <ItemTemplate>
            <a href="<%#Eval("fdArtiPath") %>" class="cs-fl">
                <img class="nobor" width="180" height="280" src="<%#Eval("fdArtiPic") %>"></a>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="g_360 cs-fr">
    <ul class="list-disc">
        <asp:Repeater ID="rep2" runat="server">
            <ItemTemplate>
                <li><a href="<%#Eval("fdArtiPath") %>">
                    <%#Eval( "fdArtiTitle" )%></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="Index_piclist cs-clear">
        <asp:Repeater ID="rep3" runat="server">
            <ItemTemplate>
                <a href="<%#Eval("fdArtiPath") %>">
                    <img class="nobor" src="<%#Eval("fdArtiPic") %>" />
                    <strong>
                        <%#Eval( "fdArtiTitle" )%></strong> </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
