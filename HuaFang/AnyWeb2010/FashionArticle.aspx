<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FashionArticle.aspx.cs" Inherits="FashionArticle" %>

<%@ Register Src="~/Controls/TagList.ascx" TagName="TagList" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/FashionLeftSide.ascx" TagName="FashionLeftSide" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide1.ascx" TagName="LeftSide1" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide2.ascx" TagName="LeftSide2" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide3.ascx" TagName="LeftSide3" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function MM_CheckFlashVersion(reqVerStr, msg) {
            with (navigator) {
                var isIE = (appVersion.indexOf("MSIE") != -1 && userAgent.indexOf("Opera") == -1);
                var isWin = (appVersion.toLowerCase().indexOf("win") != -1);
                if (!isIE || !isWin) {
                    var flashVer = -1;
                    if (plugins && plugins.length > 0) {
                        var desc = plugins["Shockwave Flash"] ? plugins["Shockwave Flash"].description : "";
                        desc = plugins["Shockwave Flash 2.0"] ? plugins["Shockwave Flash 2.0"].description : desc;
                        if (desc == "") flashVer = -1;
                        else {
                            var descArr = desc.split(" ");
                            var tempArrMajor = descArr[2].split(".");
                            var verMajor = tempArrMajor[0];
                            var tempArrMinor = (descArr[3] != "") ? descArr[3].split("r") : descArr[4].split("r");
                            var verMinor = (tempArrMinor[1] > 0) ? tempArrMinor[1] : 0;
                            flashVer = parseFloat(verMajor + "." + verMinor);
                        }
                    }
                    // WebTV has Flash Player 4 or lower -- too low for video
                    else if (userAgent.toLowerCase().indexOf("webtv") != -1) flashVer = 4.0;

                    var verArr = reqVerStr.split(",");
                    var reqVer = parseFloat(verArr[0] + "." + verArr[2]);

                    if (flashVer < reqVer) {
                        if (confirm(msg))
                            window.location = "http://www.macromedia.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash";
                    }
                }
            }
        }
    </script>

    <div class="product cs-clear">
        <uc1:TagList ID="TagList1" runat="server" />
        <uc1:Search ID="Search1" runat="server" />
    </div>
    <div class="cs-group">
        <div class="g_760">
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch title-ch3 cs-fl">
                        <AW:Position runat="server" SplitText="//" HasLink="true">
                        </AW:Position>
                        //<span><%=bean.fdArtiTitle %></span>
                    </p>
                </h2>
            </div>
            <div>
                <h1 class="Article_tit">
                    <%=bean.fdArtiTitle %></h1>
                <p class="keywords">
                    <%=bean.Column.fdColuName %>
                    <%=bean.fdArtiCategoryName%>
                    <%=bean.fdArtiCityName %>
                    <%=bean.fdArtiCreateAt.ToString("yyyy/MM/dd") %></p>
                <p class="keywords">
                    来源：<%=bean.fdArtiFrom %>
                    作者：<%=bean.fdArtiAuthor%></p>
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
            </div>
            <div class="ShowTime cs-clear">
                <div class="ShowTime_pic ShowTime_pic2">
                    <%if( bean.CatWalkList.Count == 0 && bean.CloseUpList.Count == 0 && bean.BackStageList.Count == 0 && bean.FrontRowList.Count == 0 && string.IsNullOrEmpty( bean.fdArtiFlashPath ) )
                      {%>
                    <div class="Show_filmstrip">
                        <img src="<%=bean.fdArtiPic %>" width="398" />
                    </div>
                    <%}
                      else
                      { %>
                    <div class="Loading">
                    </div>
                    <div class="Show_filmstrip" style="display: none">
                        <a href="" class="ShowTime_link" target="_blank" id="imageShow">
                            <img src="" width="398" /></a> <a href="javascript:pre();" class="Filmstrip_L">
                            </a><a href="javascript:next()" class="Filmstrip_R"></a><a id="imageLink" href=""
                                class="Filmstrip_Loupe" target="_blank"></a>
                    </div>
                    <div class="Article_picpage ">
                        <div class="Pic_Page Pic_PageL cs-clear">
                            <a href="javascript:pre();">&lt;上一页</a>
                        </div>
                        <div class="Pic_Page Pic_PageR cs-clear">
                            <a href="javascript:next();">下一页&gt;</a>
                        </div>
                        <div class="Pagination cs-clear">
                            <span id="imageCount"></span><span class="Pagination-nopa">第<input type="text" class="ipt-simple"
                                id="imagePage">页</span>
                            <button class="btn-simple btn-simple2" onclick="goPic();">
                                GO</button>
                        </div>
                    </div>
                    <%} %>
                </div>
            </div>
            <style>
                .PhoGal_mod{border:#b5b5b6 solid 5px;padding:6px;margin:10px 0 20px;width:;}
            </style>
            <div class="Pho_Gallery">
                <div class="Pho_Gallery_tab">
                    <div class="PhoG_Tabtit">
                        <%if( !string.IsNullOrEmpty( bean.fdArtiContent.Trim() ) )
                          { %>
                        <p name="p1">
                            现场报道</p>
                        <%} %>
                        <%if( bean.CatWalkList.Count > 0 )
                          {%>
                        <p name="p2">
                            T台风云</p>
                        <%} %>
                        <%if( bean.CloseUpList.Count > 0 )
                          {%>
                        <p name="p2">
                            细节鉴赏</p>
                        <%} %>
                        <%if( bean.BackStageList.Count > 0 )
                          {%>
                        <p name="p2">
                            幕后花絮</p>
                        <%} %>
                        <%if( bean.FrontRowList.Count > 0 )
                          {%>
                        <p name="p2">
                            前排观景</p>
                        <%} %>
                        <%if( !string.IsNullOrEmpty( bean.fdArtiFlashPath ) )
                          {%>
                        <p name="p1">
                            视频直击</p>
                        <%} %>
                    </div>
                    <div class="cs-clear" id="divFolding">
                        <a href="javascript:void(0);" class="btn-simple btn-simple1 Unfold" style="">图片展开</a>
                        <a href="javascript:void(0);" class="btn-simple btn-simple1 Packup" style="display: none">
                            图片收起</a>
                    </div>
                    <div class="PhoGal_mod">
                        <%if( !string.IsNullOrEmpty( bean.fdArtiContent.Trim() ) )
                          { %>
                        <div class="PhoGal_list PhoGal_list2 cs-clear">
                            <div class="PhoGal_list_article">
                                <div class="Article_content">
                                    <%=bean.fdArtiContent%>
                                </div>
                            </div>
                        </div>
                        <%} %>
                        <%if( bean.CatWalkList.Count > 0 )
                          {%>
                        <div class="PhoGal_list PhoGal_list2 cs-clear">
                            <asp:Repeater ID="repCatWalk" runat="server">
                                <ItemTemplate>
                                    <a href="javascript:setPic(<%#Container.ItemIndex %>)">
                                        <img src="<%#Eval("fdArPiPath") %>" /></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <%} %>
                        <%if( bean.CloseUpList.Count > 0 )
                          {%>
                        <div class="PhoGal_list PhoGal_list2 cs-clear">
                            <asp:Repeater ID="repCloseUp" runat="server">
                                <ItemTemplate>
                                    <a href="javascript:setPic(<%#Container.ItemIndex %>)">
                                        <img src="<%#Eval("fdArPiPath") %>" /></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <%} %>
                        <%if( bean.BackStageList.Count > 0 )
                          {%>
                        <div class="PhoGal_list PhoGal_list2 cs-clear">
                            <asp:Repeater ID="repBackStage" runat="server">
                                <ItemTemplate>
                                    <a href="javascript:setPic(<%#Container.ItemIndex %>)">
                                        <img src="<%#Eval("fdArPiPath") %>" /></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <%} %>
                        <%if( bean.FrontRowList.Count > 0 )
                          {%>
                        <div class="PhoGal_list PhoGal_list2 cs-clear">
                            <asp:Repeater ID="repFrontRow" runat="server">
                                <ItemTemplate>
                                    <a href="javascript:setPic(<%#Container.ItemIndex %>)">
                                        <img src="<%#Eval("fdArPiPath") %>" /></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <%} %>
                        <%if( !string.IsNullOrEmpty( bean.fdArtiFlashPath ) )
                          {%>
                        <div class="PhoGal_list PhoGal_list2 MvGal_list cs-clear">
                            <div class="FLVPlayer_mod">
                                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0"
                                    width="660" height="440" id="FLVPlayer">
                                    <param name="movie" value="/img/FLVPlayer_Progressive.swf" />
                                    <param name="salign" value="lt" />
                                    <param name="quality" value="high" />
                                    <param name="scale" value="noscale" />
                                    <param name="FlashVars" value="&MM_ComponentVersion=1&skinName=/img/Halo_Skin_3&streamName=<%=bean.fdArtiFlashPath %>&autoPlay=false&autoRewind=false" />
                                    <embed src="/img/FLVPlayer_Progressive.swf" flashvars="&MM_ComponentVersion=1&skinName=/img/Halo_Skin_3&streamName=<%=bean.fdArtiFlashPath %>&autoPlay=false&autoRewind=false"
                                        quality="high" scale="noscale" width="660" height="440" name="FLVPlayer" salign="LT"
                                        type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
                                </object>
                            </div>
                            <div class="PhoGal_list_article">
                                <div class="Article_content">
                                    <%=bean.fdArtiFlashDesc.Replace( "\r\n", "<br />" )%>
                                </div>
                            </div>
                        </div>
                        <%} %>
                    </div>
                </div>
            </div>
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch title-ch2 cs-fl">
                        <span class="title-size1">
                            <%=bean.fdArtiTitle %></span><span>其他相关秀场</span></p>
                </h2>
            </div>
            <div class="Piclist_outline">
                <div class="Pic_list cs-clear">
                    <asp:Repeater ID="repMore" runat="server">
                        <ItemTemplate>
                            <div class="Show_picitem Show_picitem2">
                                <a href="<%#Eval("fdArtiPath") %>">
                                    <img width="95" height="150" src="<%#Eval("fdArtiPic") %>"></a>
                                <div class="Show_intro Show_introbor">
                                    <strong><a href="<%#Eval("fdArtiPath") %>">
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 15, false )%></a></strong></div>
                                <div class="Show_intro">
                                    <p>
                                        <%#Eval( "Column.fdColuName" )%></p>
                                    <p>
                                        <%#Eval( "fdArtiCategoryName" )%>
                                    </p>
                                    <p>
                                        <%#Eval( "fdArtiCityName" )%>
                                    </p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch title-ch2 cs-fl">
                        <span class="title-size1">
                            <%=bean.Column.fdColuName %></span><span>其他相关秀场</span></p>
                </h2>
            </div>
            <div class="Piclist_outline">
                <div class="Pic_list cs-clear">
                    <asp:Repeater ID="repColumn" runat="server">
                        <ItemTemplate>
                            <div class="Show_picitem Show_picitem2">
                                <a href="<%#Eval("fdArtiPath") %>">
                                    <img width="95" height="150" src="<%#Eval("fdArtiPic") %>"></a>
                                <div class="Show_intro Show_introbor">
                                    <strong><a href="<%#Eval("fdArtiPath") %>">
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 15, false )%></a></strong></div>
                                <div class="Show_intro">
                                    <p>
                                        <%#Eval( "Column.fdColuName" )%></p>
                                    <p>
                                        <%#Eval( "fdArtiCategoryName" )%>
                                    </p>
                                    <p>
                                        <%#Eval( "fdArtiCityName" )%>
                                    </p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch title-ch2 cs-fl">
                        <span class="title-size1">
                            <%=bean.fdArtiCityName %></span><span>其他相关秀场</span></p>
                </h2>
            </div>
            <div class="Piclist_outline">
                <div class="Pic_list cs-clear">
                    <asp:Repeater ID="repCity" runat="server">
                        <ItemTemplate>
                            <div class="Show_picitem Show_picitem2">
                                <a href="<%#Eval("fdArtiPath") %>">
                                    <img width="95" height="150" src="<%#Eval("fdArtiPic") %>"></a>
                                <div class="Show_intro Show_introbor">
                                    <strong><a href="<%#Eval("fdArtiPath") %>">
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 15, false )%></a></strong></div>
                                <div class="Show_intro">
                                    <p>
                                        <%#Eval( "Column.fdColuName" )%></p>
                                    <p>
                                        <%#Eval( "fdArtiCategoryName" )%>
                                    </p>
                                    <p>
                                        <%#Eval( "fdArtiCityName" )%>
                                    </p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="g_192">
            <uc1:FashionLeftSide runat="server" />
            <uc1:LeftSide1 runat="server" />
            <uc1:LeftSide2 runat="server" />
            <uc1:LeftSide3 runat="server" />
        </div>
    </div>

    <script type="text/javascript">
        var current = 0;
        var tabIndex = 0;
        var tabTitle = ".Pho_Gallery_tab .PhoG_Tabtit p";
        var tabContent = ".Pho_Gallery_tab .PhoGal_mod .PhoGal_list";
        function setPic(index) {
            if (index >= 0) {
                current = index;
            }
            var image = $(tabContent).eq(tabIndex).find("a").eq(current).find("img");
            $(tabContent).eq(tabIndex).find("a").removeClass("Pho_on");
            $(tabContent).eq(tabIndex).find("a").eq(current).addClass("Pho_on");
            $("#imageShow").attr("href", $(image).attr("src").replace("S_", ""));
            $("#imageLink").attr("href", $(image).attr("src").replace("S_", ""));
            $("#imageShow img").attr("src", $(image).attr("src"));
            $("#imagePage").val(current + 1);
            $("#imageShow img").load(function() {
                var Height = $("#imageShow img").height() + 2;
                $(".Filmstrip_L").height(Height);
                $(".Filmstrip_R").height(Height);
                $(".Filmstrip_Loupe").height(Height);
            });
        }
        function pre() {
            if (current == 0) {
                alert("已经是第一张图片！");
                return;
            }
            current -= 1;
            setPic(current);
        }
        function next() {
            var count = $(tabContent).eq(tabIndex).find("a").length;
            if (current == count - 1) {
                alert("已经是最后一张图片！");
                return;
            }
            current += 1;
            setPic(current);
        }
        function goPic() {
            var pageIndex = $("#imagePage").val();
            if (pageIndex.search(/^[0-9]+$/) == -1) {
                alert("页码格式错误，只能输入数字类型！");
                return;
            }
            var count = $(tabContent).eq(tabIndex).find("a").length;
            if (pageIndex < 1) pageIndex = 1;
            if (pageIndex > count) pageIndex = count;
            setPic(pageIndex - 1);

        }
        $(function() {
            if ($(tabTitle).length > 0) {
                $(".Loading").hide();
                $(".Show_filmstrip").show();
                $(tabTitle + ":first").addClass("on");
                $(tabContent).not(":first").hide();
                if ($(tabTitle + ":first").attr("name") == "p1") {
                    $("#divFolding").css("visibility", "hidden");
                    $(".Pho_Gallery_tab .PhoGal_mod").addClass("PhoGal_Report");
                }

                if ($(tabTitle + "[name='p2']").length > 0) {
                    tabIndex = $(tabTitle).index($(tabTitle + "[name='p2']:first"));
                    var count = $(tabContent).eq(tabIndex).find("a").length;
                    $("#imageCount").html("共" + count + "页");
                    $("#imagePage").val(1);
                    setPic();
                }

                if ($(tabTitle).length > 1) {
                    $(tabTitle).bind("click", function() {
                        $(this).siblings("p").removeClass("on").end().addClass("on");
                        var index = $(tabTitle).index($(this));
                        $(tabContent).eq(index).siblings(tabContent).hide().end().fadeIn(0);
                        if ($(this).attr("name") == "p1") {
                            $("#divFolding").css("visibility", "hidden");
                            $(".Pho_Gallery_tab .PhoGal_mod").addClass("PhoGal_Report");
                        } else {
                            tabIndex = index;
                            $("#divFolding").css("visibility", "visible");
                            $(".Pho_Gallery_tab .PhoGal_mod").removeClass("PhoGal_Report");
                            var count = $(tabContent).eq(tabIndex).find("a").length;
                            $("#imageCount").html("共" + count + "页");
                            $("#imagePage").val(1);
                            setPic();
                        }
                    });
                }
            }
        });
    </script>

</asp:Content>
