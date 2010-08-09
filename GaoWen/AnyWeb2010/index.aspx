<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<%@ Register src="Control/menu.ascx" tagname="menu" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="public/class/default_index.css" />
    <link rel="stylesheet" type="text/css" href="public/class/style_index.css" />
    <script type="text/javascript" src="public/js/jquery-1.2.5.js"></script>
    <script type="text/javascript" src="public/js/chrome.js"></script>
    <script src="public/js/swfobject_modified.js" type="text/javascript"></script>
    <script type="text/javascript" src="public/js/common.js"></script>
    <title></title>
</head>
<body>
    <div id="flash">
        <object id="FlashID" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="400"
            height="200">
            <param name="movie" value="public/images/welcome.swf" />
            <param name="quality" value="high" />
            <param name="wmode" value="opaque" />
            <param name="swfversion" value="6.0.65.0" />
            <param name="expressinstall" value="public/js/expressInstall.swf" />
            <object type="application/x-shockwave-flash" data="public/images/welcome.swf" width="400"
                height="200">
                <param name="quality" value="high" />
                <param name="wmode" value="opaque" />
                <param name="swfversion" value="6.0.65.0" />
                <param name="expressinstall" value="public/js/expressInstall.swf" />
                <div>
                    <h4>
                        此页面上的内容需要较新版本的 Adobe Flash Player。</h4>
                    <p>
                        <a href="http://www.adobe.com/go/getflashplayer">
                            <img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif"
                                alt="获取 Adobe Flash Player" width="112" height="33" /></a></p>
                </div>
            </object>
        </object>
    </div>
    <div id="content" class="wrap_Home" style="display: none">
        <div class="topArea relate navIndex">
            <div class="topLs">
                <a href="/" class="logo" title="高闻顾问">高闻顾问</a>
            </div>
            <div class="topRs">
                <div class="blank5px">
                </div>
                <div class="search">
                    <div class="searInputBg">
                        <form action="search.aspx" id="search" method="post">
                        <input type="text" id="keyword" name="keyword" /><a href="javascript:search();" class="btnSear"></a>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <uc1:menu ID="menu1" runat="server" />
        <div class="blank10px">
        </div>
        <div class="homeFocus">
            <div id="focus" class="focus">
                <asp:Repeater ID="repFlash" runat="server">
                    <ItemTemplate>
                        <img id="image<%#Container.ItemIndex+1 %>" src="<%#Eval("fdFlasPicture") %>" width="1004" height="710" border="0" usemap="#Map<%#Container.ItemIndex+1 %>" />
                        <map name="Map<%#Container.ItemIndex+1 %>" id="Map<%#Container.ItemIndex+1 %>">
                            <area shape="rect" coords="4,156,1003,470" href="<%#Eval("fdFlasUrl") %>" />
                        </map>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div id="TurnNum" class="TurnNum">
                <asp:Repeater ID="repFlashNum" runat="server">
                    <ItemTemplate>
                        <a href="javascript:void(0);" alt="<%#Container.ItemIndex+1 %>" class="<%#Container.ItemIndex==0?"cur":"" %>"><%#Container.ItemIndex+1 %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <script type="text/javascript">
                var time = 0;
                if(<%=flashList.Count %>==0){
                    $("#content").show();
                    $("#flash").hide();
                }
                var interval = window.setInterval(checkStatus, 1000);
                <asp:Repeater ID="repJs1" runat="server">
                    <ItemTemplate>
                        var image<%#Container.ItemIndex+1 %>;
                        $("#image<%#Container.ItemIndex+1 %>").load(function() {
                            image<%#Container.ItemIndex+1 %> = true;
                            checkStatus();
                        });
                    </ItemTemplate>
                </asp:Repeater>
                function checkStatus() {
                    if ((true<asp:Repeater ID="repJs2" runat="server">
                        <ItemTemplate>
                            <%# "&&image"+(Container.ItemIndex+1) %>
                        </ItemTemplate>
                    </asp:Repeater>)||time>=10){
                        $("#content").show();
                        $("#flash").hide();
                        window.clearInterval(interval);
                    }
                    time++;
                }
                
                
            </script>
            <script type="text/javascript">
                var _c = _h = 0;
                $(document).ready(function() {
                    $('#TurnNum > a').click(function() {
                        var i = $(this).attr('alt') - 1;
                        _c = i;
                        clearTimeout(_h);
                        change(i);
                    })
                    $("#Map").hover(function() { clearTimeout(_h) }, function() { play() });
                    play();
                })
                function play() {
                    _h = setTimeout("auto()", 5000);
                }
                function change(i) {
                    $('#TurnNum > a').removeClass().eq(i).addClass('cur').blur();
                    $("#focus img").fadeOut('slow').eq(i).animate({
                        opacity: 'show'
                    }, 2000);
                    play();

                }
                function auto() {
                    _c = _c >= <%=flashList.Count-1 %> ? 0 : _c + 1;
                    change(_c);
                }
            </script>
            <div class="homeColumns">
                <div class="hotArcticle gap6px left">
                    <ul class="list black relate">
                        <asp:Repeater ID="repHot" runat="server">
                        <ItemTemplate>
                            <li>
                            <a href="article.aspx?id=<%#Eval("fdArtiID") %>">
                                <%#Studio.Web.WebAgent.GetLeft((string)Eval("fdArtiTitle"),10)%></a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    </ul>
                </div>
                <div class="financialStatements left">
                    <ul class="list black  relate">
                        <li><a href="/article.aspx?id=1081">如何看流动比率？</a></li>
                    </ul>
                </div>
                <div class="EHC right">
                    <ul class="list black  relate">
                        <li><a href="/article.aspx?id=1091">重新了解贵司的账目</a></li>
                    </ul>
                </div>
            </div>
            <div class="footHomePos">
                <a href="http://gaowenconsultancy.com/disclaimer-chs.html">免责声明</a> <a href="http://gaowenconsultancy.com/privacy-policy-chs.html">私隐政策</a> <a href="http://gaowenconsultancy.com/terms-conditions-chs.html">条款及条件</a> <a href="http://gaowenconsultancy.com/copyright-notice-chs.html">版权告示</a>
                © 2010 高闻顾问有限公司. 版权所有
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var flash = document.getElementById("flash");
        flash.style.position = "absolute";
        flash.style.top = (document.documentElement.clientHeight - flash.offsetHeight) / 2 + "px";
        flash.style.left = (document.documentElement.clientWidth - flash.offsetWidth) / 2 + "px";
        window.onload = function() {
        }
        swfobject.registerObject("FlashID");
    </script>

</body>
</html>
