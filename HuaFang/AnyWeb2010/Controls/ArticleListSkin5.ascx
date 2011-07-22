<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleListSkin5.ascx.cs"
    Inherits="Controls_ArticleListSkin5" %>
<div class="g_360 cs-fl">
    <asp:Repeater ID="rep1" runat="server">
        <ItemTemplate>
            <div class="Column5_item Column5_itemL cs-clear">
                <a href="<%#Eval("fdArtiPath") %>" class="Column5_pic">
                    <img src="<%#Eval("fdArtiPic") %>" /></a>
                <div class="Column5_tit">
                    <h2>
                        <a href="<%#Eval("fdArtiPath") %>">
                            <%#Eval( "fdArtiTitle" )%></a>
                    </h2>
                    <p>
                        <%#Studio.Web.WebAgent.GetLeft((string)Eval("fdArtiDesc"),75,false) %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="g_360 cs-fr">
    <asp:Repeater ID="rep2" runat="server">
        <ItemTemplate>
            <div class="Column5_item Column5_itemL cs-clear">
                <a href="<%#Eval("fdArtiPath") %>" class="Column5_pic">
                    <img src="<%#Eval("fdArtiPic") %>" /></a>
                <div class="Column5_tit">
                    <h2>
                        <a href="<%#Eval("fdArtiPath") %>"><%#Eval( "fdArtiTitle" )%></a>
                    </h2>
                    <p>
                        <%#Studio.Web.WebAgent.GetLeft((string)Eval("fdArtiDesc"),75,false) %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
