<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Index.aspx.cs"
    Inherits="Index" Title="广州市天河沙河供销社合作网" %>

<%@ Register Src="Controls/Contact.ascx" TagName="Contact" TagPrefix="uc1" %>
<%@ Register Src="Controls/LinkList.ascx" TagName="LinkList" TagPrefix="uc1" %>
<%@ Register Src="Controls/ArticleList.ascx" TagName="ArticleList" TagPrefix="uc1" %>
<%@ Register Src="Controls/Notice.ascx" TagName="Notice" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="js/ScrollPic.js"></script>

    <script type="text/javascript" src="js/focus.js"></script>

    <script type="text/javascript" src="js/weather.js"></script>

    <div class="banner">
        <img src="images/banner.jpg" width="962" height="185" />
    </div>
    <div class="blank6px">
    </div>
    <div class="HomeColOne">
        <div class="tit_NewsInfor">
        </div>
        <div class="con_NewsInfor">
            <div class="ls">
                <div class="wheather" id="wheather">
                    正在加载天气预报。。。
                </div>
                <uc1:Notice ID="Notice1" runat="server" />
                <div class="blank5px">
                </div>
                <uc1:Contact ID="Contact1" runat="server" />
            </div>
            <div class="rs">
                <div class="Comnews">
                    <div class="tit">
                        <h2>
                            社务动态</h2>
                        <span class="more"><a href="Column.aspx?id=2">更多>></a></span>
                    </div>
                    <div class="con">
                        <div class="focus" id="focus">
                            <div class="focusBg">
                                <div class="dImg">
                                    <div class="dImg_1" id="focus_list">
                                        <asp:Repeater ID="repFlash1" runat="server">
                                            <ItemTemplate>
                                                <a href="<%#Eval("PhotUrl") %>" target="_blank">
                                                    <img src="<%#Eval("PhotPath") %>" width="247" height="176" alt="<%#Eval("PhotName") %>"
                                                        title="<%#Eval("PhotName") %>" /></a>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                                <div class="dbtn" id="focus_btn">
                                    <asp:Repeater ID="repFlash2" runat="server">
                                        <ItemTemplate>
                                            <a href="javascript:void(0);" class="<%#Container.ItemIndex==0?"cur":"" %>" ref="<%#Container.ItemIndex%>">
                                            </a>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <div class="foTit">
                                <asp:Repeater ID="repFlash3" runat="server">
                                    <ItemTemplate>
                                        <p class="<%#Container.ItemIndex==0?"block":"" %>">
                                            <a href="<%#Eval("PhotUrl") %>" target="_blank">
                                                <%#Studio.Web.WebAgent.GetLeft((string)Eval("PhotName"),20,true) %></a></p>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="rsList">
                            <uc1:ArticleList ID="Article1" ColumnID="2" runat="server" />
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div class="blank5px">
                </div>
                <div class="lastestNews">
                    <div class="tit">
                        <h2>
                            最新新闻</h2>
                        <span class="more"><a href="Column.aspx?id=1">更多>></a></span>
                    </div>
                    <div class="con">
                        <uc1:ArticleList ID="ArticleList1" ColumnID="1" runat="server" />
                    </div>
                </div>
                <div class="policy">
                    <div class="tit">
                        <h2>
                            政策法规</h2>
                        <span class="more"><a href="Column.aspx?id=3">更多>></a></span>
                    </div>
                    <div class="con">
                        <uc1:ArticleList ID="ArticleList2" ColumnID="3" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="blank6px">
    </div>
    <div class="HomeColTwo">
        <div class="bgBanner">
        </div>
        <div class="bgBox">
            <div class="box192">
                <div class="severCenter">
                    <div class="subtit subtitBg">
                        <h3>
                            社区服务中心</h3>
                    </div>
                    <div class="con">
                        <img src="images/img_service.jpg" width="184" height="397" /></div>
                </div>
                <div class="blank6px">
                </div>
                <uc1:LinkList ID="LinkList1" runat="server"></uc1:LinkList>
            </div>
            <div class="box437">
                <div class="basket">
                    <div class="gTit">
                        <div class="TitBg">
                            <div class="mark icon_1">
                                网上菜篮子平台</div>
                            <span class="subMark"><a href="/LkdMarket.aspx">由此进入>></a></span>
                        </div>
                    </div>
                    <div class="con conBg">
                        <div class="brief">
                            &nbsp;&nbsp;&nbsp;&nbsp;龙口东农贸市场位于龙口东路133号，占地面积1700平方米，二○○四年九月，在市、区政府和上级领导的大力支持下，投入资金二百万元，完成了升级改造工作。场内各项设施基本配套齐全，配备食品检验室。为更好的方便市民购买肉菜的需要，龙口东农贸市场正式构建起"网上菜篮子"平台，通过在此平台，市民可以足不出户就能买到新鲜肉菜。市民通过龙口东农贸市场"网上菜篮子"平台所订购的肉菜均由本市场所属档口提供，确保是新鲜菜，放心肉。
                        </div>
                        <div class="picArea">
                            <ul id="Scroll">
                                <asp:Repeater ID="repCLZ" runat="server">
                                    <ItemTemplate>
                                        <li><a href="<%#Eval("PhotUrl") %>" target="_blank">
                                            <img src="<%#Eval("PhotPath") %>" width="133" height="92" alt="<%#Eval("PhotName") %>"
                                                title="<%#Eval("PhotName") %>" /></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="blank8px">
                </div>
                <div class="sourComp">
                    <div class="gTit">
                        <div class="TitBg">
                            <div class="mark icon_2">
                                杰信人力资源公司</div>
                            <span class="subMark"><a href="/Column.aspx?id=4">由此进入>></a></span>
                        </div>
                    </div>
                    <div class="con conBg">
                        <div class="brief">
                            &nbsp;&nbsp;&nbsp;&nbsp;我社在经营传统业务的同时紧跟市场发展潮流，抓紧机遇，进行二次创业。杰信公司便是我社二次创业的产物，我社在原有的资源基础上进行整合及有效利用，创办杰信公司开拓人力资源领域方向的相关业务。杰信公司的业务包括：人事代理、人才招聘、企业咨询、培训、劳务派遣、代理劳动关系手续办理（劳动年审、社会保险办理等）等相关业务。
                        </div>
                        <div class="corpCom">
                            <h4>
                                知名合作企业</h4>
                            <div class="left" id="scrollWrap" style="height: 150px; width: 401px; overflow: hidden;">
                                <div style="float: left;" id="scrollMsg">
                                    <ul>
                                        <asp:Repeater ID="repZMQY" runat="server">
                                            <ItemTemplate>
                                                <li><a href="<%#Eval("PhotUrl") %>" target="_blank">
                                                    <img src="<%#Eval("PhotPath") %>" width="104" height="34" alt="<%#Eval("PhotName") %>"
                                                        title="<%#Eval("PhotName") %>" /></a> <a href="<%#Eval("PhotUrl") %>" target="_blank">
                                                            <%#Studio.Web.WebAgent.GetLeft((string)Eval("PhotName"),10,true) %></a>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="box303">
                <div class="proSale">
                    <div class="gTit">
                        <div class="TitBg">
                            <div class="mark icon_1">
                                商品销售</div>
                            <span class="subMark"><a href="http://shop.thshcoop.com" target="_blank">更多>></a></span>
                        </div>
                    </div>
                    <div class="con proSaleBg">
                        <div class="brief">
                            &nbsp;&nbsp;&nbsp;&nbsp;商品经营是我社又一传统主营业务，我社在门店经营和网络经营的新结合点上，为各企业、团体、组织提供机团采购服务。面对消费者，我社提供物廉价美的商品。时代变迁，为大众提供优质服务是我社始终坚持的经营理念。
                        </div>
                        <ul id="product">
                        </ul>

                        <script type="text/javascript">
                            $(document).ready(function() {
                                $.ajax({
                                    type: "GET",
                                    url: "GetProducts.aspx",
                                    success: function(data) {
                                        $("#product").html(data);
                                    },
                                    error: function() {
                                        $("#product").html("数据正在维护中。。。");
                                    }
                                });
                            });
                        </script>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="blank6px">
    </div>
    <div class="HomeColThree">
        <h2>
            荣誉奖状</h2>
        <div class="conBox">
            <ul id="Scroll_1">
                <asp:Repeater ID="repRYJZ" runat="server">
                    <ItemTemplate>
                        <li><a href="<%#Eval("PhotUrl") %>" target="_blank">
                            <img src="<%#Eval("PhotPath") %>" width="178" height="106" alt="<%#Eval("PhotName") %>"
                                title="<%#Eval("PhotName") %>" /></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>

    <script type="text/javascript"> 
	<!--
        try {
            var isStoped = false;
            var oScroll = document.getElementById("scrollWrap");
            with (oScroll) {
                noWrap = true;
            }

            oScroll.onmouseover = new Function('isStoped = true');
            oScroll.onmouseout = new Function('isStoped = false');

            var preTop = 0;
            var curTop = 0;
            var stopTime = 5;
            var oScrollMsg = document.getElementById("scrollMsg");

            oScroll.appendChild(oScrollMsg.cloneNode(true));
            init_srolltext();
        } catch (e) { }

        function init_srolltext() {
            oScroll.scrollTop = 0;
            setInterval('scrollUp()', 10);
        }

        function scrollUp() {
            if (isStoped) return;
            curTop += 1;
            if (curTop == 76) {
                stopTime += 1;
                curTop -= 1;
                if (stopTime == 180) {
                    curTop = 0;
                    stopTime = 0;
                }
            } else {
                preTop = oScroll.scrollTop;
                oScroll.scrollTop += 1;
                if (preTop == oScroll.scrollTop) {
                    oScroll.scrollTop = 0;
                    oScroll.scrollTop += 1;
                }
            }
        } 
	//--> 
    </script>

    <script type="text/javascript">
    <!--
        var scrollPic_01 = new ScrollPic();
        scrollPic_01.scrollContId = "Scroll"; //内容容器ID
        scrollPic_01.arrLeftId = ""; //左箭头ID
        scrollPic_01.arrRightId = ""; //右箭头ID

        scrollPic_01.frameWidth = 415; //显示框宽度
        scrollPic_01.pageWidth = 138; //翻页宽度

        scrollPic_01.speed = 10; //移动速度(单位毫秒，越小越快)
        scrollPic_01.space = 10; //每次移动像素(单位px，越大越快)
        scrollPic_01.autoPlay = true; //自动播放
        scrollPic_01.autoPlayTime = 5; //自动播放间隔时间(秒)

        var scrollid = document.getElementById("Scroll_1");
        var imglen = scrollid.getElementsByTagName("img").length;
        if (imglen > 2) {
            scrollPic_01.initialize(); //初始化
        }
        else
        { }
    //-->
    </script>

    <script type="text/javascript">
    <!--
        var scrollPic_02 = new ScrollPic();
        scrollPic_02.scrollContId = "Scroll_1"; //内容容器ID
        scrollPic_02.arrLeftId = ""; //左箭头ID
        scrollPic_02.arrRightId = ""; //右箭头ID

        scrollPic_02.frameWidth = 962; //显示框宽度
        scrollPic_02.pageWidth = 192; //翻页宽度

        scrollPic_02.speed = 10; //移动速度(单位毫秒，越小越快)
        scrollPic_02.space = 10; //每次移动像素(单位px，越大越快)
        scrollPic_02.autoPlay = true; //自动播放
        scrollPic_02.autoPlayTime = 5; //自动播放间隔时间(秒)

        var scrollid = document.getElementById("Scroll_1");
        var imglen = scrollid.getElementsByTagName("img").length;
        if (imglen > 3) {
            scrollPic_02.initialize(); //初始化
        }
        else
        { }
    //-->
    </script>

    <script type="text/javascript">
        $(document).ready(function() {
            selMenu("SY");
            focusChange();
        });
        $.ajax({
            url: "GetWeather.aspx",
            data: "id=59287",
            cache: false,
            success: function(result) {
                if (result) {
                    eval(result);
                } else {
                    $("#wheather").html("数据正在维护中。。。");
                }
            },
            error: function() {
                $("#wheather").html("数据正在维护中。。。");
            }
        });
    </script>

</asp:Content>
