<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PictureArticle.aspx.cs" Inherits="PictureArticle" %>

<%@ Register Src="~/Controls/TagList.ascx" TagName="TagList" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/RightSide1.ascx" TagName="RightSide1" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/RightSide2.ascx" TagName="RightSide2" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="product cs-clear">
        <uc1:TagList runat="server" />
        <uc1:Search runat="server" />
    </div>
    <div class="cs-group">
        <div class="">
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <AW:Position ID="Position2" runat="server" SplitText="//" HasLink="true">
                        </AW:Position>
                        //<span><%=bean.fdArtiTitle %></span></p>
                    <p class="title-eng cs-fr">
                        CON<span>TENT</span></p>
                </h2>
            </div>
            <div class="cs-section">
                <div class="g_690 cs-fl">
                    <div class="Article_main">
                        <div class="Article_head cs-clear">
                            <p class="cs-fl">
                                发表时间：<span><%=bean.fdArtiCreateAt.ToString("yyyy年M月d日") %></span></p>
                            <p>
                                来源：<span><%=bean.fdArtiFrom %></span> 作者：<span><%=bean.fdArtiAuthor %></span></p>
                            <p class="keywords">
                                <span>关键字：</span>
                                <asp:Repeater ID="repTag1" runat="server">
                                    <ItemTemplate>
                                        <span><a href="/t/<%#Eval("fdTagID") %>.aspx">
                                            <%#Eval( "fdTagName" )%></a></span>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </p>
                        </div>
                        <div class="Article_hd">
                            <h1 class="Article_tit">
                                <%=bean.fdArtiTitle %>
                            </h1>
                        </div>
                        <div class="Article_content">
                            <%if( bean.PictureList.Count == 0 )
                              { %>
                            <img src="<%=bean.fdArtiPic %>" width="460" height="716" />
                            <%}
                              else
                              { %>
                            <div class="Loading">
                            </div>
                            <div class="Show_filmstrip" style="display: none">
                                <a class="ShowTime_link" href="" id="imageShow" target="_blank">
                                    <img src=""></a> <a class="Filmstrip_L" href="javascript:pre();"></a><a class="Filmstrip_R"
                                        href="javascript:next();"></a><a id="imageLink" class="Filmstrip_Loupe" href="" target="_blank">
                                        </a>
                            </div>
                            <div class="ArticlePic_con cs-clear">
                                <div class="ArticlePic_all" id="imageContent">
                                    <%if( bean.fdArtiPicDesc == 1 )
                                      { %>
                                    <%=bean.fdArtiDesc.Replace( "\r\n", "<br />" )%>
                                    <%} %>
                                </div>
                            </div>
                            <%} %>
                        </div>
                        <%if( bean.PictureList.Count > 0 )
                          { %>
                        <style>
                            .PhoGal_con
                            {
                                width: <%=bean.PictureList.Count*106+20%>px;
                            }
                        </style>
                        <div class="Pho_Gallery">
                            <div class="Pho_Gal_hd cs-clear">
                                <a style="display: block;" class="btn-simple btn-simple1 Unfold" href="javascript:void(0);">
                                    展开图片列表</a> <a style="display: none;" class="btn-simple btn-simple1 Packup" href="javascript:void(0);">
                                        收起图片列表</a>
                            </div>
                            <div class="PhoGal_mod PhoGal_mod_2">
                                <div class="PhoGal_list cs-clear">
                                    <div class="PhoGal_con cs-clear">
                                        <asp:Repeater ID="repPicList" runat="server">
                                            <ItemTemplate>
                                                <a href="javascript:setPic(<%#Container.ItemIndex %>)"><span class="vertical-m">
                                                    <img src="<%#Eval("fdArPiPath") %>" /><span style="display: none"><%#(( string ) Eval( "fdArPiDesc" )).Replace( "\r\n", "<br />" )%></span>
                                                </span></a>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                                <a href="javascript:pre();" class="PhoGal-prev"></a><a href="javascript:next();"
                                    class="PhoGal-next"></a>
                            </div>
                        </div>
                        <%} %>
                        <div>
                            <%=bean.fdArtiContent %>
                        </div>
                        <div class="cs-clear weibo">
                            <p>
                                <a class="Article_collect" href="javascript:addFavorites();">收藏分享</a></p>

                            <script type="text/javascript">
                                var _t = encodeURI(document.title);
                                var _url = encodeURIComponent(document.location);
                                document.write("<p><a alt=\"转播到腾讯微博\" href=\"http://v.t.qq.com/share/share.php?url=" + _url + "&title=" + _t + "\" target=\"_blank\"><img border=\"0\" align=\"absmiddle\" alt=\"转播到腾讯微博\" src=\"/img/weibo_qq24.png\"></a></p>");
                                document.write("<p><a alt=\"转播到新浪微博\" href=\"http://service.weibo.com/share/share.php?url=" + _url + "&title=" + _t + "\" target=\"_blank\"><img border=\"0\" align=\"absmiddle\" alt=\"转播到新浪微博\" src=\"/img/weibo_sina24.gif\"></a></p>");
                            </script>

                        </div>
                        <p class="keywords">
                            关键字：
                            <asp:Repeater ID="repTag2" runat="server">
                                <ItemTemplate>
                                    <a href="/t/<%#Eval("fdTagID") %>.aspx">
                                        <%#Eval( "fdTagName" )%></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </p>
                        <div class="Article_nav">
                            <%if( preArticle != null )
                              { %>
                            <p>
                                <a href="<%=preArticle.fdArtiPath %>">上一篇：<%=preArticle.fdArtiTitle%></a></p>
                            <%} %>
                            <%if( nextArticle != null )
                              { %>
                            <p>
                                <a href="<%=nextArticle.fdArtiPath %>">下一篇：<%=nextArticle.fdArtiTitle%></a></p>
                            <%} %>
                        </div>
                    </div>
                    <div class="title-bar">
                        <h2 class="cs-clear">
                            <p class="title-ch cs-fl">
                                <span>关注更多</span></p>
                            <p class="title-eng cs-fr">
                                OTHER<span>HOT</span></p>
                        </h2>
                    </div>
                    <div class="OtherHot OtherHot-js">
                        <asp:Repeater ID="repOther" runat="server">
                            <ItemTemplate>
                                <div class="OtherHot-item <%#Container.ItemIndex==0?"OtherHot-yes":"" %>">
                                    <div class="OtherHot_list">
                                        <span>
                                            <%#Eval("fdArtiCreateAt","{0:yyyy-MM-dd}") %>
                                            /</span><%#Studio.Web.WebAgent.GetLeft((string)Eval("fdArtiTitle"),48,false) %></div>
                                    <div class="OtherHot_con cs-clear">
                                        <a href="<%#Eval("fdArtiPath") %>" class="OtherHot_pic cs-fl">
                                            <img width="130" src="<%#Eval("fdArtiPic") %>"></a>
                                        <div class="OtherHot_info5 cs-fr">
                                            <p>
                                                <%#Eval( "fdArtiCreateAt", "{0:yyyy.MM.dd}" )%></p>
                                            <a class="OtherHot_tit" href="<%#Eval("fdArtiPath") %>" title="<%#Eval("fdArtiTitle") %>">
                                                <%#Studio.Web.WebAgent.GetLeft((string)Eval("fdArtiTitle"),20,false) %></a>
                                            <p class="Article">
                                                <%#Studio.Web.WebAgent.GetLeft((string)Eval("fdArtiDesc"),300,false) %></p>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <%--<div class="title-sub">
                        相关刊物</div>
                    <div class="Perio_List Perio_List3">
                        <div class="Pic_GoRound_mod">
                            <div class="Pic_GoRound cs-clear">
                                <div class=" jcarousel-skin-tango">
                                    <div class="jcarousel-container jcarousel-container-horizontal" style="position: relative;
                                        display: block;">
                                        <div class="jcarousel-clip jcarousel-clip-horizontal" style="position: relative;">
                                            <ul class="jcarousel-list jcarousel-list-horizontal" id="mycarousel" style="overflow: hidden;
                                                position: relative; top: 0px; margin: 0px; padding: 0px; left: 0px; width: 1180px;">
                                                <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-1 jcarousel-item-1-horizontal"
                                                    style="float: left; list-style: none outside none;" jcarouselindex="1"><a class="Index_picarticle cs-fl"
                                                        href="#">
                                                        <img src="img/demo1.jpg"><span>angel 天使妆容之术1</span></a></li>
                                                <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-2 jcarousel-item-2-horizontal"
                                                    style="float: left; list-style: none outside none;" jcarouselindex="2"><a class="Index_picarticle cs-fl"
                                                        href="#">
                                                        <img src="img/demo2.jpg"><span>angel 天使妆容之术2</span></a></li>
                                                <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-3 jcarousel-item-3-horizontal"
                                                    style="float: left; list-style: none outside none;" jcarouselindex="3"><a class="Index_picarticle cs-fl"
                                                        href="#">
                                                        <img src="img/demo3.jpg"><span>angel 天使妆容之术3</span></a></li>
                                                <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-4 jcarousel-item-4-horizontal"
                                                    style="float: left; list-style: none outside none;" jcarouselindex="4"><a class="Index_picarticle cs-fl"
                                                        href="#">
                                                        <img src="img/demo4.jpg"><span>angel 天使妆容之术4</span></a></li>
                                                <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-5 jcarousel-item-5-horizontal"
                                                    style="float: left; list-style: none outside none;" jcarouselindex="5"><a class="Index_picarticle cs-fl"
                                                        href="#">
                                                        <img src="img/demo5.jpg"><span>angel 天使妆容之5</span></a></li>
                                                <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-6 jcarousel-item-6-horizontal"
                                                    style="float: left; list-style: none outside none;" jcarouselindex="6"><a class="Index_picarticle cs-fl"
                                                        href="#">
                                                        <img src="img/demo1.jpg"><span>angel 天使妆容之术6</span></a></li>
                                                <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-7 jcarousel-item-7-horizontal"
                                                    style="float: left; list-style: none outside none;" jcarouselindex="7"><a class="Index_picarticle cs-fl"
                                                        href="#">
                                                        <img src="img/demo2.jpg"><span>angel 天使妆容之术7</span></a></li>
                                                <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-8 jcarousel-item-8-horizontal"
                                                    style="float: left; list-style: none outside none;" jcarouselindex="8"><a class="Index_picarticle cs-fl"
                                                        href="#">
                                                        <img src="img/demo3.jpg"><span>angel 天使妆容之术8</span></a></li>
                                                <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-9 jcarousel-item-9-horizontal"
                                                    style="float: left; list-style: none outside none;" jcarouselindex="9"><a class="Index_picarticle cs-fl"
                                                        href="#">
                                                        <img src="img/demo4.jpg"><span>angel 天使妆容之术9</span></a></li>
                                                <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-10 jcarousel-item-10-horizontal"
                                                    style="float: left; list-style: none outside none;" jcarouselindex="10"><a class="Index_picarticle cs-fl"
                                                        href="#">
                                                        <img src="img/demo5.jpg"><span>angel 天使妆容之术0</span></a></li>
                                            </ul>
                                        </div>
                                        <div class="jcarousel-prev jcarousel-prev-horizontal" style="display: block;" disabled="false">
                                        </div>
                                        <div class="jcarousel-next jcarousel-next-horizontal" style="display: block;" disabled="false">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                </div>
                <div class="g_240 Article_side cs-fr">
                    <uc1:RightSide1 runat="server" />
                    <uc1:RightSide2 runat="server" />
                    <%if( otherPicList.Count > 0 )
                      { %>
                    <div class="Default-item">
                        <div class="title-bar title-bar2">
                            <h2 class="cs-clear">
                                <p class="title-ch cs-fl">
                                    <span>图文情报</span></p>
                            </h2>
                        </div>
                        <asp:Repeater ID="rep3" runat="server">
                            <ItemTemplate>
                                <div class="">
                                    <a href="<%#Eval("fdArtiPath") %>">
                                        <img src="<%#Eval("fdArtiPic") %>" width="190" height="295" /></a>
                                    <ul class="list-disc">
                                        <li><a href="<%#Eval("fdArtiPath") %>">
                                            <%#Eval("fdArtiTitle") %></a></li>
                                    </ul>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <%} %>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var current = 0;
        var tabContent = ".PhoGal_mod .PhoGal_list";
        function setPic(index) {
            if (index >= 0) {
                current = index;
            }
            var image = $(tabContent).find("a").eq(current).find("img");
            $(tabContent).find("a").removeClass("Pho_on");
            $(tabContent).find("a").eq(current).addClass("Pho_on");
            $("#imageShow").attr("href", $(image).attr("src").replace("S_", ""));
            $("#imageLink").attr("href", $(image).attr("src").replace("S_", ""));
            $("#imageShow img").attr("src", $(image).attr("src"));
            $("#imagePage").val(current + 1);
            if(<%=bean.fdArtiPicDesc %>==0){
                $("#imageContent").html($(tabContent).find("a").eq(current).find("span>span").html());
            }
            $("#imageShow img").load(function(){
                var Width=$("#imageShow img").width();
                $(".Show_filmstrip").width(Width+10);
                var Height=$("#imageShow img").height() + 2;
	            $(".Filmstrip_L").height(Height);
	            $(".Filmstrip_R").height(Height);
	            $(".Filmstrip_Loupe").height(Height).width(Width-64).css("margin-left",0-(Width-64)/2);
            });
        }
        function first() {
            setPic(0);
        }
        function last() {
            var count = $(tabContent).find("a").length;
            setPic(count - 1);
        }
        function pre() {
            if (current == 0) {
                alert("已经是第一张图片！");
                return;
            }
            setPic(current - 1);
        }
        function next() {
            var count = $(tabContent).find("a").length;
            if (current == count - 1) {
                alert("已经是最后一张图片！");
                return;
            }
            setPic(current + 1);
        }
        function goPic() {
            var pageIndex = $("#imagePage").val();
            if (pageIndex.search(/^[0-9]+$/) == -1) {
                alert("页码格式错误，只能输入数字类型！");
                return;
            }
            var count = $(tabContent).find("a").length;
            if (pageIndex < 1) pageIndex = 1;
            if (pageIndex > count) pageIndex = count;
            setPic(pageIndex - 1);
        }
        $(function() {
            if ($(tabContent).length > 0) {
                setPic(0);
                $(".Loading").hide();
                $(".Show_filmstrip").show();
            }
        });
    </script>

</asp:Content>
