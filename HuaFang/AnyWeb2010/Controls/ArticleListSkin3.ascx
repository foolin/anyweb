<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleListSkin3.ascx.cs"
    Inherits="Controls_ArticleListSkin3" %>
<div id="bannerBox" class="PicBlack_Roll">
    <div class="banner">
        <div id="slides" class="PicB_win">
            <div class="slides_container PicBReel cs-clear">
                <asp:Repeater ID="rep1" runat="server">
                    <ItemTemplate>
                        <div>
                            <a class="PicBlack_mod2" href="<%#Eval("fdArtiPath") %>">
                                <img src="<%#Eval("fdArtiPic") %>" class="nobor" />
                                <div class="PicBlack_tit PicBlack_tit2">
                                    <h2>
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 30, false )%></h2>
                                    <p>
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiDesc" ), 65, false )%></p>
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
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

