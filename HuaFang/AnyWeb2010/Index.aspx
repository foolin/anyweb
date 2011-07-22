<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="Index" %>

<%@ Register Src="~/Controls/TagList.ascx" TagName="TagList" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/SideMenu.ascx" TagName="SideMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide1.ascx" TagName="LeftSide1" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide2.ascx" TagName="LeftSide2" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide3.ascx" TagName="LeftSide3" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="BannerAD">
        <div class="BannerPic">
            <ul id="slider2">
                <asp:Repeater ID="repFlash" runat="server">
                    <ItemTemplate>
                        <li><a class="BannerSlide" href="<%#Eval("fdFlasUrl") %>">
                            <img class="nobor" src="<%#Eval("fdFlasPicture") %>" />
                            <div class="BannerSlide_tit">
                                <h2>
                                    <%#Eval( "fdFlasName" )%></h2>
                                <p>
                                    <%#Eval( "fdFlashDesc" )%>
                                </p>
                            </div>
                        </a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>

            <script type="text/javascript">
                $(function() {

                    $('#slider2').anythingSlider({
                        resizeContents: false,
                        autoPlay: true,
                        delay: 2000,
                        startText: "自动播放",
                        stopText: "停止播放",
                        navigationFormatter: function(index, panel) { // Format navigation labels with text
                            return [<%=flashName %>][index - 1];
                        }
                    });

                });
            </script>

        </div>
    </div>
    <div class="product cs-clear">
        <uc1:TagList runat="server" />
        <uc1:Search runat="server" />
    </div>
    <div class="cs-group">
        <div class="g_760">
            <div class="cs-section Index_sec1">
                <div class="g_360 cs-fl">
                    <div class="title-bar">
                        <h2 class="cs-clear">
                            <p class="title-ch cs-fl">
                                <span>品牌动态</span></p>
                            <p class="title-eng cs-fr">
                                BRAND<span>NEWS</span></p>
                        </h2>
                    </div>
                    <AW:ArticleList runat="server" TopCount="1" GetChild="true" ColumnID="123">
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
                    </AW:ArticleList>
                </div>
                <div class="g_360 cs-fr">
                    <div class="title-bar">
                        <h2 class="cs-clear">
                            <p class="title-ch cs-fl">
                                <span>明星名媛</span></p>
                            <p class="title-eng cs-fr">
                                FASHION<span>NEWS</span></p>
                        </h2>
                    </div>
                    <div class="Hotnews_minor Hotnews_minor2">
                        <asp:Repeater ID="repCelebs" runat="server">
                            <ItemTemplate>
                                <%#Container.ItemIndex == 0 || Container.ItemIndex == 3 ? string.Format( "<div class=\"Minor-item Minor-item2 cs-clear\"><a class=\"Minor-pic\" href=\"{0}\"><img class=\"nobor\" src=\"{1}\"></a><div class=\"Minor-intro\"><h2 class=\"Minor-tit Minor-tit2\"><a href=\"{0}\">{2}</a></h2><p>{3}</p><div class=\"cs-clear\">", Eval( "fdArtiPath" ), Eval( "fdArtiPic" ), Eval( "fdArtiTitle" ), Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiDesc" ), 24, false ) ) : ""%>
                                <%#Container.ItemIndex != 0 && Container.ItemIndex != 3 ? string.Format( "<a href=\"{0}\" class=\"Index_picarticle {3}\"><img class=\"nobor\" src=\"{1}\" /><span>{2}</span></a>", Eval( "fdArtiPath" ), Eval( "fdArtiPic" ), Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 10, false ), Container.ItemIndex == 1 || Container.ItemIndex == 4 ? "cs-fl" : "cs-fr" ) : ""%>
                                <%#Container.ItemIndex == 2 || Container.ItemIndex == 5 || Container.ItemIndex == celebsCount - 1 ? "</div></div></div>" : ""%>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="cs-section Index_sec2">
                <div class="g_360 cs-fl">
                    <div class="title-bar">
                        <h2 class="cs-clear">
                            <p class="title-ch cs-fl">
                                <span>潮流街拍</span></p>
                            <p class="title-eng cs-fr">
                                STREET<span>STYLE</span></p>
                        </h2>
                    </div>
                    <div class="Hotnews_minor Hotnews_minor2">
                        <asp:Repeater ID="repStreet" runat="server">
                            <ItemTemplate>
                                <%#Container.ItemIndex == 0 || Container.ItemIndex == 3 ? string.Format( "<div class=\"Minor-item Minor-item2 cs-clear\"><a class=\"Minor-pic\" href=\"{0}\"><img class=\"nobor\" src=\"{1}\"></a><div class=\"Minor-intro\"><h2 class=\"Minor-tit Minor-tit2\"><a href=\"{0}\">{2}</a></h2><p>{3}</p><div class=\"cs-clear\">", Eval( "fdArtiPath" ), Eval( "fdArtiPic" ), Eval( "fdArtiTitle" ), Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiDesc" ), 24, false ) ) : ""%>
                                <%#Container.ItemIndex != 0 && Container.ItemIndex != 3 ? string.Format( "<a href=\"{0}\" class=\"Index_picarticle {3}\"><img class=\"nobor\" src=\"{1}\" /><span>{2}</span></a>", Eval( "fdArtiPath" ), Eval( "fdArtiPic" ), Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 10, false ), Container.ItemIndex == 1 || Container.ItemIndex == 4 ? "cs-fl" : "cs-fr" ) : ""%>
                                <%#Container.ItemIndex == 2 || Container.ItemIndex == 5 || Container.ItemIndex == celebsCount - 1 ? "</div></div></div>" : ""%>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="title-bar title-bar2">
                        <h2 class="cs-clear">
                            <p class="title-ch cs-fl">
                                <span>更多情报</span></p>
                        </h2>
                    </div>
                    <ul class="list-disc list-disc-fl cs-clear">
                        <asp:Repeater ID="repStreetMore" runat="server">
                            <ItemTemplate>
                                <li><a href="<%# Eval( "fdArtiPath" )%>">
                                    <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 23, false )%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="g_360 cs-fr">
                    <div class="title-bar">
                        <h2 class="cs-clear">
                            <p class="title-ch cs-fl">
                                <span>流行趋势</span></p>
                            <p class="title-eng cs-fr">
                                FASHION<span>TRENDS</span></p>
                        </h2>
                    </div>
                    <div class="PicBlack_Roll">
                        <div class="PicB_win">
                            <div class="PicBReel cs-clear">
                                <asp:Repeater ID="repFashion" runat="server">
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
                        <ul class="PicBlack_tab cs-clear">
                            <asp:Repeater ID="repFashionButton" runat="server">
                                <ItemTemplate>
                                    <li <%#Container.ItemIndex==0?"class=\"active\"":"" %> href="" rel="<%#Container.ItemIndex+1 %>">
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>秀场直击</span></p>
                    <p class="title-eng cs-fr">
                        FASHION<span>SHOW</span></p>
                </h2>
            </div>
            <div class="cs-section Index_sec3">
                <div class="g_360 Hotnews_main cs-fl">
                    <asp:Repeater ID="repFashionShow" runat="server">
                        <ItemTemplate>
                            <a href="<%#Eval("fdArtiPath") %>">
                                <img width="350" height="544" src="<%#Eval("fdArtiPic") %>"></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="g_360 cs-fr">
                    <div class="Index_piclist cs-clear">
                        <asp:Repeater ID="repFashionShowMore" runat="server">
                            <ItemTemplate>
                                <a href="<%#Eval("fdArtiPath") %>">
                                    <img class="nobor" src="<%#Eval("fdArtiPic") %>" />
                                    <span>
                                        <%#Eval( "fdArtiTitle" )%></span> </a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="Fashion_search">
                        <p>
                            <span>季&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;节：</span><a href="#" class="on">2011春夏</a><a
                                href="#">2011秋冬</a><a href="#">2010春夏</a><a href="#">2010秋冬</a><a href="#" class="special">全部</a></p>
                        <p>
                            <span>服装类型：</span><a href="#">男装</a><a href="#" class="on">高级成衣</a><a href="#">高级定制</a><a
                                href="#" class="special">全部</a></p>
                        <p>
                            <span>设&nbsp;计&nbsp;师&nbsp;：</span><input type="password" class="ipt-simple" /></p>
                        <p class="cs-clear Fashion_s_btn">
                            <button class="btn-simple btn-simple2">
                                搜索</button></p>
                    </div>
                </div>
            </div>
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>时尚生活</span></p>
                    <p class="title-eng cs-fr">
                        FASHION<span>LIFE</span></p>
                </h2>
            </div>
            <div class="cs-section Index_sec4">
                <div class="g_360 cs-fl">
                    <asp:Repeater ID="repFashionLife1" runat="server">
                        <ItemTemplate>
                            <a href="<%#Eval("fdArtiPath") %>" class="cs-fl">
                                <img class="nobor" width="180" height="280" src="<%#Eval("fdArtiPic") %>"></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="g_360 cs-fr">
                    <ul class="list-disc">
                        <asp:Repeater ID="repFashionLife2" runat="server">
                            <ItemTemplate>
                                <li><a href="<%#Eval("fdArtiPath") %>">
                                    <%#Eval( "fdArtiTitle" )%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="Index_piclist cs-clear">
                        <asp:Repeater ID="repFashionLife3" runat="server">
                            <ItemTemplate>
                                <a href="<%#Eval("fdArtiPath") %>">
                                    <img class="nobor" src="<%#Eval("fdArtiPic") %>" />
                                    <span>
                                        <%#Eval( "fdArtiTitle" )%></span> </a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
        <div class="g_192">
            <uc1:SideMenu runat="server" />
            <uc1:LeftSide1 runat="server" />
            <uc1:LeftSide2 runat="server" />
            <uc1:LeftSide3 runat="server" />
        </div>
    </div>
    <div class="cs-group cs-clear">
        <div class="title-bar">
            <h2 class="cs-clear">
                <p class="title-ch cs-fl">
                    <span>高清大片</span></p>
                <p class="title-eng cs-fr">
                    EDITOR<span>IAL</span></p>
            </h2>
        </div>
        <div class="Editorial">
            <div class="Pic_GoRound_mod">
                <div class="Pic_GoRound cs-clear">
                    <ul id="mycarousel" class="jcarousel-skin-tango">
                        <asp:Repeater ID="repEditorial" runat="server">
                            <ItemTemplate>
                                <li><a href="<%#Eval("fdArtiPath") %>">
                                    <img src="<%#Eval("fdArtiPic") %>" /></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
