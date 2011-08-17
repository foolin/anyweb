<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FashionArticleListSkin2.ascx.cs"
    Inherits="Controls_FashionArticleListSkin2" %>
<%if( column != null )
  { %>
<div class="title-bar">
    <h2 class="cs-clear">
        <p class="title-ch title-ch2 cs-fl">
            <span class="title-size1">
                <%=splitName[ 1 ]%></span>/<span><%=splitName[ 0 ]%></span></p>
        <p class="title-ch cs-fr">
            <a href="/Fashion.aspx?col=<%=column.fdColuID %>&cate=1">本季男装</a>/<a href="/Fashion.aspx?col=<%=column.fdColuID %>&cate=2">本季高级成衣</a>/<a
                href="/Fashion.aspx?col=<%=column.fdColuID %>&cate=3">本季高级定制</a>/<a href="/Fashion.aspx?col=<%=column.fdColuID %>">本季全部</a></p>
    </h2>
</div>
<div class="Showpic_list cs-section">
    <div class="g_230 cs-fr">
        <asp:Repeater ID="rep2" runat="server">
            <ItemTemplate>
                <a href="<%#Eval("fdArtiPath") %>">
                    <img src="<%#Eval("fdArtiPic") %>" height="355" width="228" /></a>
                <h2 class="Showpic_tit">
                    <a href="<%#Eval("fdArtiPath") %>">
                        <%#Eval("fdArtiTitle") %></a>
                </h2>
                <p class="Show_introbor">
                    <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiDesc" ), 52, false )%></p>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="g_495 cs-fl">
        <div class="Piclist_outline">
            <div class="Pic_list cs-clear">
                <asp:Repeater ID="rep1" runat="server">
                    <ItemTemplate>
                        <div class="Show_picitem Show_picitem2">
                            <a href="<%#Eval("fdArtiPath") %>">
                                <img width="95" height="150" src="<%#Eval("fdArtiPic") %>"></a>
                            <div class="Show_intro Show_introbor">
                                <strong><a href="<%#Eval("fdArtiPath") %>">
                                    <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 20, false )%></a></strong></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</div>
<%} %>