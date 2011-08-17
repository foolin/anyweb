<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PictureArticle.aspx.cs" Inherits="PictureArticle" %>

<%@ Register Src="~/Controls/TagList.ascx" TagName="TagList" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/SideMenu.ascx" TagName="SideMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide1.ascx" TagName="LeftSide1" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide2.ascx" TagName="LeftSide2" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide3.ascx" TagName="LeftSide3" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="product cs-clear">
        <uc1:TagList runat="server" />
        <uc1:Search runat="server" />
    </div>
    <div class="cs-group">
        <div class="g_760">
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <AW:Position ID="Position1" runat="server" SplitText="//" HasLink="true">
                        </AW:Position>
                        //<span><%=bean.fdArtiTitle %></span></p>
                    <p class="title-eng cs-fr">
                        CON<span>TENT</span></p>
                </h2>
            </div>
            <div class="cs-section">
                <div class="g_470 cs-fl">
                    <div class="Article_main">
                        <div class="Article_head cs-clear">
                            <p>
                                发表时间：<span><%=bean.fdArtiCreateAt.ToString("yyyy年M月d日") %></span></p>
                            <p>
                                来源：<span><%=bean.fdArtiFrom %></span> 作者：<span><%=bean.fdArtiAuthor %></span></p>
                        </div>
                        <p class="keywords">
                            <span>关键字：</span>
                            <asp:Repeater ID="repTag1" runat="server">
                                <ItemTemplate>
                                    <span><a href="/t/<%#Eval("fdTagID") %>.aspx">
                                        <%#Eval( "fdTagName" )%></a></span>
                                </ItemTemplate>
                            </asp:Repeater>
                        </p>
                        <h1 class="Article_tit">
                            <%=bean.fdArtiTitle %></h1>
                        <div class="Article_content">
                            <%if( bean.PictureList.Count == 0 )
                              { %>
                            <img src="<%=bean.fdArtiPic %>" width="460" height="716" />
                            <p>
                                <%=bean.fdArtiDesc.Replace( "\r\n", "<br />" )%>
                            </p>
                            <%}
                              else
                              { %>
                            <div class="Show_filmstrip">
                                <a class="ShowTime_link" href="" id="imageShow" target="_blank">
                                    <img src=""></a> <a class="Filmstrip_L" href="javascript:pre();"></a><a class="Filmstrip_R"
                                        href="javascript:next();"></a><a id="imageLink" class="Filmstrip_Loupe" href="" target="_blank">
                                        </a>
                            </div>
                            <div class="Article_picpage">
                                <div class="Pic_Page Pic_PageL cs-clear">
                                    <a href="javascript:first();">&lt;&lt;首页</a> <a href="javascript:pre();">&lt;上一页</a>
                                </div>
                                <div class="Pic_Page Pic_PageR cs-clear">
                                    <a href="javascript:next();">下一页&gt;</a> <a href="javascript:last();">尾页&gt;&gt;</a>
                                </div>
                                <div class="Pagination cs-clear">
                                    <span id="imageCount">共<%=bean.PictureList.Count %>页</span><span class="Pagination-nopa">第<input
                                        type="text" class="ipt-simple" id="imagePage">页</span>
                                    <button class="btn-simple btn-simple2" onclick="goPic();">
                                        GO</button>
                                </div>
                            </div>
                            <p id="imageContent">
                                <%=bean.fdArtiDesc.Replace( "\r\n", "<br />" )%>
                            </p>
                            <%} %>
                        </div>
                        <%if( bean.PictureList.Count > 0 )
                          { %>
                        <div class="Pho_Gallery">
                            <div class="cs-clear">
                                <a href="javascript:void(0);" class="btn-simple btn-simple1 Unfold" style="">图片展开</a>
                                <a href="javascript:void(0);" class="btn-simple btn-simple1 Packup" style="display: none">
                                    图片收起</a>
                            </div>
                            <div class="PhoGal_mod">
                                <div class="PhoGal_list cs-clear">
                                    <asp:Repeater ID="repPicList" runat="server">
                                        <ItemTemplate>
                                            <a href="javascript:setPic(<%#Container.ItemIndex %>)">
                                                <img src="<%#Eval("fdArPiPath") %>" /><span style="display: none"><%#(( string ) Eval( "fdArPiDesc" )).Replace( "\r\n", "<br />" )%></span></a>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                        <%} %>
                        <a href="javascript:addFavorites();" class="Article_collect">收藏分享</a>
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
                                            /</span><%#Studio.Web.WebAgent.GetLeft((string)Eval("fdArtiTitle"),28,false) %></div>
                                    <div class="OtherHot_con cs-clear">
                                        <a href="<%#Eval("fdArtiPath") %>" class="OtherHot_pic cs-fl">
                                            <img width="130" src="<%#Eval("fdArtiPic") %>"></a>
                                        <div class="OtherHot_info4 cs-fr">
                                            <p>
                                                <%#Eval( "fdArtiCreateAt", "{0:yyyy.MM.dd}" )%></p>
                                            <a class="OtherHot_tit" href="<%#Eval("fdArtiPath") %>" title="<%#Eval("fdArtiTitle") %>">
                                                <%#Studio.Web.WebAgent.GetLeft((string)Eval("fdArtiTitle"),25,false) %></a>
                                            <p class="Article">
                                                <%#Studio.Web.WebAgent.GetLeft((string)Eval("fdArtiDesc"),70,false) %></p>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <%--<div class="title-sub">
                        相关刊物</div>
                    <div class="Perio_List">
                        <div class="Pic_GoRound_mod">
                            <div class="Pic_GoRound cs-clear">
                                <ul id="mycarousel" class="jcarousel-skin-tango">
                                    <li><a href="#" class="Index_picarticle cs-fl">
                                        <img src="img/demo1.jpg" /><span>angel 天使妆容之术</span></a></li>
                                    <li><a href="#" class="Index_picarticle cs-fl">
                                        <img src="img/demo2.jpg" /><span>angel 天使妆容之术</span></a></li>
                                    <li><a href="#" class="Index_picarticle cs-fl">
                                        <img src="img/demo3.jpg" /><span>angel 天使妆容之术</span></a></li>
                                    <li><a href="#" class="Index_picarticle cs-fl">
                                        <img src="img/demo4.jpg" /><span>angel 天使妆容之术</span></a></li>
                                    <li><a href="#" class="Index_picarticle cs-fl">
                                        <img src="img/demo5.jpg" /><span>angel 天使妆容之术</span></a></li>
                                    <li><a href="#" class="Index_picarticle cs-fl">
                                        <img src="img/demo1.jpg" /><span>angel 天使妆容之术</span></a></li>
                                    <li><a href="#" class="Index_picarticle cs-fl">
                                        <img src="img/demo2.jpg" /><span>angel 天使妆容之术</span></a></li>
                                    <li><a href="#" class="Index_picarticle cs-fl">
                                        <img src="img/demo3.jpg" /><span>angel 天使妆容之术</span></a></li>
                                    <li><a href="#" class="Index_picarticle cs-fl">
                                        <img src="img/demo4.jpg" /><span>angel 天使妆容之术</span></a></li>
                                    <li><a href="#" class="Index_picarticle cs-fl">
                                        <img src="img/demo5.jpg" /><span>angel 天使妆容之术</span></a></li>
                                </ul>
                            </div>
                        </div>
                    </div>--%>
                </div>
                <div class="g_240 Article_side cs-fr">
                    <div class="Default-item">
                        <div class="title-bar title-bar2">
                            <h2 class="cs-clear">
                                <p class="title-ch cs-fl">
                                    <span>更多<%=bean.Column.fdColuName %></span></p>
                            </h2>
                        </div>
                        <div class="Pho_Cap_Recom">
                            <asp:Repeater ID="rep11" runat="server">
                                <ItemTemplate>
                                    <a href="<%#Eval("fdArtiPath") %>" class="PhoCap-a">
                                        <img src="<%#Eval("fdArtiPic") %>" /></a>
                                    <h3>
                                        <a href="<%#Eval("fdArtiPath") %>">
                                            <%#Eval("fdArtiTitle") %></a></h3>
                                </ItemTemplate>
                            </asp:Repeater>
                            <ul class="list-disc">
                                <asp:Repeater ID="rep12" runat="server">
                                    <ItemTemplate>
                                        <li><a href="<%#Eval("fdArtiPath") %>">
                                            <%#Eval("fdArtiTitle") %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <%if( bean.Column.fdColuParentID > 0 )
                      { %>
                    <div class="Default-item">
                        <div class="title-bar title-bar2">
                            <h2 class="cs-clear">
                                <p class="title-ch cs-fl">
                                    <span>更多<%=bean.Column.Parent.fdColuName %></span></p>
                            </h2>
                        </div>
                        <div class="Pho_Cap_Recom">
                            <asp:Repeater ID="rep21" runat="server">
                                <ItemTemplate>
                                    <a href="<%#Eval("fdArtiPath") %>" class="PhoCap-a">
                                        <img src="<%#Eval("fdArtiPic") %>" /></a>
                                    <h3>
                                        <a href="<%#Eval("fdArtiPath") %>">
                                            <%#Eval("fdArtiTitle") %></a></h3>
                                </ItemTemplate>
                            </asp:Repeater>
                            <ul class="list-disc">
                                <asp:Repeater ID="rep22" runat="server">
                                    <ItemTemplate>
                                        <li><a href="<%#Eval("fdArtiPath") %>">
                                            <%#Eval("fdArtiTitle") %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <%} %>
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
        <div class="g_192">
            <uc1:SideMenu runat="server" />
            <uc1:LeftSide1 runat="server" />
            <uc1:LeftSide2 runat="server" />
            <uc1:LeftSide3 runat="server" />
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
//            $(document).scrollTop($("#imageShow").offset().top);
            if(<%=bean.fdArtiPicDesc %>==0){
                $("#imageContent").html($(tabContent).find("a").eq(current).find("span").html());
            }
            $("#imageShow img").load(function(){
                $(".Show_filmstrip").width($("#imageShow img").width()+10);
                $(".Filmstrip_L").css("top",($("#imageShow img").height()-63)/2);
                $(".Filmstrip_R").css("top",($("#imageShow img").height()-63)/2);
                $(".Filmstrip_Loupe").css("top",($("#imageShow img").height()-29)/2);
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
            }
        });
    </script>

</asp:Content>
