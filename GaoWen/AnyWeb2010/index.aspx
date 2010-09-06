<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register Src="Control/menu.ascx" TagName="menu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="public/class/default_index.css" />
    <link rel="stylesheet" type="text/css" href="public/class/style_index.css" />

    <script type="text/javascript" src="public/js/jquery-1.2.5.js"></script>

    <script type="text/javascript" src="public/js/jquery.cookie.js"></script>

    <script type="text/javascript" src="public/js/chrome.js"></script>

    <script src="public/js/swfobject_modified.js" type="text/javascript"></script>

    <script type="text/javascript" src="public/js/common.js"></script>

    <title></title>
</head>
<body>
    <div id="loading" style="width: 100%; text-align: center; display: none;">
        <img src="public/images/Loading.jpg" alt="載入中，請稍候。。。" title="載入中，請稍候。。。" />
    </div>
    <div id="content" class="wrap_Home">
        <div class="topArea relate navIndex">
            <div class="topLs">
                <a href="/" class="logo" title="高闻顾问">高闻顾问</a>
            </div>
            <div class="topRs">
                <div class="blank5px">
                </div>
                <div class="search">
                    <div class="searInputBg">
                        <input type="text" id="keyword" name="keyword" /><a href="javascript:search();" class="btnSear"></a>
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
                        <img id="image<%#Container.ItemIndex+1 %>" src="<%#Eval("fdFlasPicture") %>" width="1004"
                            height="710" border="0" usemap="#Map<%#Container.ItemIndex+1 %>" />
                        <map name="Map<%#Container.ItemIndex+1 %>" id="Map<%#Container.ItemIndex+1 %>">
                            <area shape="rect" coords="4,156,1003,470" href="<%#Eval("fdFlasUrl") %>" />
                        </map>
                    </ItemTemplate>
                </asp:Repeater>
                <script type="text/javascript">
                    if (!$.cookie("gaowen")) {
                        $("#loading").show();
                        $("#content").hide();
                        $("body").css("background-color", "#270037");
                    }
                    var count = 0;
                    $("#focus").find("img").load(function() {
                        if (!$.cookie("gaowen")) {
                            count++;
                            if(count==<%=flashList.Count %>){
                                $("#content").show();
                                $("#loading").hide();
                                $("body").css("background-color", "#E5D9E9");

                                var cookieName = "gaowen";
                                var date = new Date();
                                date.setTime(date.getTime() + (1 * 24 * 60 * 60 * 1000));
                                $.cookie(cookieName, "1", { path: '/', expires: date });
                            }
                        }
                    });
                </script>
            </div>
            <div id="TurnNum" class="TurnNum">
                <asp:Repeater ID="repFlashNum" runat="server">
                    <ItemTemplate>
                        <a href="javascript:void(0);" alt="<%#Container.ItemIndex+1 %>" class="<%#Container.ItemIndex==0?"cur":"" %>">
                            <%#Container.ItemIndex+1 %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

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
                    _h = setTimeout("auto()", 10000);
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
                                <li><a href="article.aspx?id=<%#Eval("fdArtiID") %>">
                                    <%#Studio.Web.WebAgent.GetLeft((string)Eval("fdArtiTitle"),10)%></a> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="financialStatements left">
                    <ul class="list black  relate">
                        <li><a href="/pdf/TeamBuilding.pdf" target="_blank">人物檢查&團隊訓練</a></li>
                    </ul>
                </div>
                <div class="EHC right">
                    <ul class="list black  relate">
                        <li><a href="/pdf/EHC.pdf" target="_blank">企業健康度檢查</a></li>
                    </ul>
                </div>
            </div>
            <div class="footHomePos">
                <a href="/index.aspx">回到首頁</a><a href="/disclaimer-chs.aspx">免責聲明</a> <a href="/privacy-policy-chs.aspx">
                    私隱政策</a> <a href="/terms-conditions-chs.aspx">條款及條件</a> <a href="/copyright-notice-chs.aspx">
                        版權公示</a> © 2010 高聞顧問有限公司. 版权所有
            </div>
        </div>
    </div>
</body>
</html>
