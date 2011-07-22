<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleListSkin1.ascx.cs"
    Inherits="Controls_ArticleListSkin1" %>
<div class="g_360 cs-fl">
    <asp:Repeater ID="rep1" runat="server">
        <ItemTemplate>
            <a href="<%#Eval("fdArtiPath") %>" class="PicBlack_mod">
                <img src="<%#Eval("fdArtiPic") %>" />
                <div class="PicBlack_tit">
                    <h2>
                        <%#Eval( "fdArtiTitle" )%></h2>
                    <p>
                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiDesc" ), 40, false )%></p>
                    <span class="Pic_point"></span>
                </div>
            </a>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="g_360 cs-fr">
    <div class="Hotnews_minor Hotnews_minor2">
        <asp:Repeater ID="rep2" runat="server">
            <ItemTemplate>
                <%#Container.ItemIndex == 0 || Container.ItemIndex == 3 ? string.Format( "<div class=\"Minor-item Minor-item2 cs-clear\"><a class=\"Minor-pic\" href=\"{0}\"><img class=\"nobor\" src=\"{1}\"></a><div class=\"Minor-intro\"><h2 class=\"Minor-tit Minor-tit2\"><a href=\"{0}\">{2}</a></h2><p>{3}</p><div class=\"cs-clear\">", Eval( "fdArtiPath" ), Eval( "fdArtiPic" ), Eval( "fdArtiTitle" ), Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiDesc" ), 24, false ) ) : ""%>
                <%#Container.ItemIndex != 0 && Container.ItemIndex != 3 ? string.Format( "<a href=\"{0}\" class=\"Index_picarticle {3}\"><img class=\"nobor\" src=\"{1}\" /><span>{2}</span></a>", Eval( "fdArtiPath" ), Eval( "fdArtiPic" ), Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 10, false ), Container.ItemIndex == 1 || Container.ItemIndex == 4 ? "cs-fl" : "cs-fr" ) : ""%>
                <%#Container.ItemIndex == 2 || Container.ItemIndex == 5 || Container.ItemIndex == articleCount - 1 ? "</div></div></div>" : ""%>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
