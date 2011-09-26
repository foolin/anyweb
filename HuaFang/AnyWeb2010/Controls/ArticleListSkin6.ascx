<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleListSkin6.ascx.cs"
    Inherits="Controls_ArticleListSkin6" %>
<div class="g_360 cs-fl">
    <div class="Hotnews_minor Hotnews_minor2">
        <asp:Repeater ID="rep1" runat="server">
            <ItemTemplate>
                <%#Container.ItemIndex == 0 || Container.ItemIndex == 3 ? string.Format( "<div class=\"Minor-item Minor-item2 cs-clear\"><a class=\"Minor-pic\" href=\"{0}\"><img class=\"nobor\" src=\"{1}\"></a><div class=\"Minor-intro\"><h2 class=\"Minor-tit Minor-tit2\"><a href=\"{0}\">{2}</a></h2><p>{3}</p><div class=\"cs-clear\">", Eval( "fdArtiPath" ), Eval( "fdArtiPic" ), Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 11, false ), Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiDesc" ), 24, false ) ) : ""%>
                <%#Container.ItemIndex != 0 && Container.ItemIndex != 3 ? string.Format( "<a href=\"{0}\" class=\"Index_picarticle {3}\"><img class=\"nobor\" src=\"{1}\" /><strong>{2}</strong></a>", Eval( "fdArtiPath" ), Eval( "fdArtiPic" ), Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 10, false ), Container.ItemIndex == 1 || Container.ItemIndex == 4 ? "cs-fl" : "cs-fr" ) : ""%>
                <%#Container.ItemIndex == 2 || Container.ItemIndex == 5 || Container.ItemIndex == articleCount - 1 ? "</div></div></div>" : ""%>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <a href="/c/<%=columnID %>.aspx" class="More-mod More-item">more</a>
    <div class="title-bar title-bar2">
        <h2 class="cs-clear">
            <p class="title-ch cs-fl">
                <span>更多情报</span></p>
        </h2>
    </div>
    <ul class="list-disc list-disc-fl cs-clear">
        <asp:Repeater ID="rep2" runat="server">
            <ItemTemplate>
                <li><a href="<%# Eval( "fdArtiPath" )%>" title="<%#Eval( "fdArtiTitle" ) %>">
                    <%#Eval( "fdArtiTitle" )%></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
<div class="g_360 cs-fr">
    <div id="bannerBox" class="PicBlack_Roll">
        <div class="banner">
            <div id="slides" class="PicB_win">
                <div class="slides_container PicBReel cs-clear">
                    <asp:Repeater ID="rep3" runat="server">
                        <ItemTemplate>
                            <a class="PicBlack_mod2" href="#">
                                <img src="<%#Eval("fdArtiPic") %>" class="nobor" />
                                <div class="PicBlack_tit PicBlack_tit2">
                                    <h2>
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 30, false )%></h2>
                                    <p>
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiDesc" ), 65, false )%></p>
                                </div>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
        $(function () {
            $('#slides').slides({
                preload: true,
                preloadImage: 'img/loading.gif',
                play: 3000,
                pause: 2500,
                hoverPause: true,
                animationStart: function () {
                    $('.caption').animate({
                        bottom: -35
                    }, 100);
                },
                animationComplete: function (current) {
                    $('.caption').animate({
                        bottom: 0
                    }, 200);
                    if (window.console && console.log) {
                        // example return of current slide number
                        console.log(current);
                    };
                }
            });
        });
</script>

