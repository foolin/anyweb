<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="124.aspx.cs" Inherits="c_124" %>

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
        <div class="title-bar">
            <h2 class="cs-clear">
                <p class="title-ch cs-fl">
                    <span>热秀推荐</span></p>
            </h2>
        </div>
    </div>
    <div class="Hot_Show cs-clear">
        <asp:Repeater ID="repHot" runat="server">
            <ItemTemplate>
                <div class="HotShow-box <%#Container.ItemIndex==0?"HotShow-item":"" %>">
                    <a class="" href="<%#Eval("fdArtiPath") %>">
                        <img src="<%#Eval("fdArtiPic") %>" /></a>
                    <p class="HotShow-info">
                        <a class="HotShow-tit" href="<%#Eval("fdArtiPath") %>">
                            <%#Eval( "fdArtiTitle" )%></a><span><%#Eval("fdArtiCategoryName") %></span><span><%#Eval("Column.fdColuName") %></span>
                    </p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <!-- -->
    <!-- -->
    <div class="cs-group">
        <div class="g_760">
            <!-- -->
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch title-ch2 cs-fl">
                        <span class="title-size1">2011</span>/<span>秋冬</span></p>
                    <p class="title-ch cs-fr">
                        <a href="#">本季男装</a>/<a href="#">本季高级成衣</a>/<a href="#">本季高级定制</a>/<a>本季全部</a></p>
                </h2>
            </div>
            <!-- -->
            <!-- -->
            <div class="Showpic_list cs-section">
                <div class="g_230 cs-fl">
                    <a href="#">
                        <img src="img/demo4.jpg" height="355" width="228" /></a>
                    <h2 class="Showpic_tit">
                        <a href="#">Christopher Christopher Kane </a>
                    </h2>
                    <p class="Show_introbor">
                        奥斯卡颁奖礼是有趣的Valentino对比研究案例。Anne Hathaway所穿的红色华丽礼服是过去的代表，而现在是...</p>
                </div>
                <div class="g_495 cs-fr">
                    <!-- -->
                    <div class="Piclist_outline">
                        <div class="Pic_list cs-clear">
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash</a></div>
                            </div>
                        </div>
                    </div>
                    <!-- -->
                </div>
            </div>
            <!-- -->
            <!-- -->
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch title-ch2 cs-fl">
                        <span class="title-size1">2011</span>/<span>春夏</span></p>
                    <p class="title-ch cs-fr">
                        <a href="#">本季男装</a>/<a href="#">本季高级成衣</a>/<a href="#">本季高级定制</a>/<a>本季全部</a></p>
                </h2>
            </div>
            <!-- -->
            <!-- -->
            <div class="Showpic_list cs-section">
                <div class="g_230 cs-fr">
                    <a href="#">
                        <img src="img/demo4.jpg" height="355" width="228" /></a>
                    <h2 class="Showpic_tit">
                        <a href="#">Vera Wang Vera WangVera Wang 1242343543653</a></h2>
                    <p class="Show_introbor">
                        奥斯卡颁奖礼是有趣的Valentino对比研究案例。Anne Hathaway所穿的红色华丽礼服是过去的代表，而现在是...</p>
                </div>
                <div class="g_495 cs-fl">
                    <!-- -->
                    <div class="Piclist_outline">
                        <div class="Pic_list cs-clear">
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash</a></div>
                            </div>
                        </div>
                    </div>
                    <!-- -->
                </div>
            </div>
            <!-- -->
            <!-- -->
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch title-ch2 cs-fl">
                        <span class="title-size1">2010</span>/<span>春夏</span></p>
                    <p class="title-ch cs-fr">
                        <a href="#">本季男装</a>/<a href="#">本季高级成衣</a>/<a href="#">本季高级定制</a>/<a>本季全部</a></p>
                </h2>
            </div>
            <!-- -->
            <!-- -->
            <div class="Showpic_list cs-section">
                <div class="g_230 cs-fl">
                    <a href="#">
                        <img src="img/demo4.jpg" height="355" width="228" /></a>
                    <h2 class="Showpic_tit">
                        <a href="#">Vera Wang </a>
                    </h2>
                    <p class="Show_introbor">
                        奥斯卡颁奖礼是有趣的Valentino对比研究案例。Anne Hathaway所穿的红色华丽礼服是过去的代表，而现在是...</p>
                </div>
                <div class="g_495 cs-fr">
                    <!-- -->
                    <div class="Piclist_outline">
                        <div class="Pic_list cs-clear">
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash</a></div>
                            </div>
                        </div>
                    </div>
                    <!-- -->
                </div>
            </div>
            <!-- -->
            <!-- -->
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch title-ch2 cs-fl">
                        <span class="title-size1">2010</span>/<span>春夏</span></p>
                    <p class="title-ch cs-fr">
                        <a href="#">本季男装</a>/<a href="#">本季高级成衣</a>/<a href="#">本季高级定制</a>/<a>本季全部</a></p>
                </h2>
            </div>
            <!-- -->
            <!-- -->
            <div class="Showpic_list cs-section">
                <div class="g_230 cs-fr">
                    <a href="#">
                        <img src="img/demo4.jpg" height="355" width="228" /></a>
                    <h2 class="Showpic_tit">
                        <a href="#">Vera Wang </a>
                    </h2>
                    <p class="Show_introbor">
                        奥斯卡颁奖礼是有趣的Valentino对比研究案例。Anne Hathaway所穿的红色华丽礼服是过去的代表，而现在是...</p>
                </div>
                <div class="g_495 cs-fl">
                    <!-- -->
                    <div class="Piclist_outline">
                        <div class="Pic_list cs-clear">
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash</a></div>
                            </div>
                            <div class="Show_picitem Show_picitem2">
                                <a href="#">
                                    <img width="95" height="150" src="img/demo3.jpg"></a>
                                <div class="Show_intro Show_introbor">
                                    <a href="#">Anne Valérie Hash</a></div>
                            </div>
                        </div>
                    </div>
                    <!-- -->
                </div>
            </div>
            <!-- -->
            <!-- -->
        </div>
        <!-- -->
        <div class="g_192">
            <!-- -->
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>秀场追击</span></p>
                </h2>
            </div>
            <!-- -->
            <!-- -->
            <div class="ShowNav ShowNav_season">
                <h3>
                    <strong>季节</strong></h3>
                <div class="SeasonList cs-clear">
                    <a href="javascript:void(0);" class="SeaList-Up" id="btn2"></a><a href="javascript:void(0);"
                        class="SeaList-Down" id="btn1"></a>
                    <div class="SeasonList-con cs-fl" id="scrollDiv">
                        <ul class="SeaList-main">
                            <li><span><a href="#">秋冬2011</a></span><span><a href="#">春夏2011</a></span></li>
                            <li><span><a href="#" class="on">秋冬2010</a></span><span><a href="#">春夏2010</a></span></li>
                            <li><span><a href="#">秋冬2009</a></span><span><a href="#">春夏2009</a></span></li>
                            <li><span><a href="#">秋冬2008</a></span><span><a href="#">春夏2008</a></span></li>
                            <li><span><a href="#">秋冬2007</a></span><span><a href="#">春夏2007</a></span></li>
                            <li><span><a href="#">秋冬2006</a></span><span><a href="#">春夏2006</a></span></li>
                            <li><span><a href="#">秋冬2005</a></span><span><a href="#">春夏2005</a></span></li>
                            <li><span><a href="#">秋冬2004</a></span><span><a href="#">春夏2004</a></span></li>
                            <li><span><a href="#">秋冬2003</a></span><span><a href="#">春夏2003</a></span></li>
                            <li><span><a href="#">秋冬2002</a></span><span><a href="#">春夏2002</a></span></li>
                        </ul>
                    </div>
                </div>
                <a href="#" class="ShowNav-all">全部</a>
            </div>
            <!-- -->
            <!-- -->
            <div class="ShowNav">
                <h3>
                    <strong>产品类别</strong></h3>
                <div class="">
                    <p>
                        <span><a href="#">男装</a></span><span><a href="#" class="on">高级成衣</a></span><span><a
                            href="#">高级定制</a></span><span><a href="#" class="ShowNav-all">全部</a></span></p>
                </div>
            </div>
            <!-- -->
            <!-- -->
            <div class="ShowNav">
                <h3>
                    <strong>城市列表</strong></h3>
                <div class="">
                    <p>
                        <span><a href="#">巴黎</a></span><span><a href="#">米兰</a></span><span><a href="#" class="on">伦敦</a></span><span><a
                            href="#">纽约</a></span><span><a href="#" class="ShowNav-all">全部</a></span></p>
                </div>
            </div>
            <!-- -->
            <!-- -->
            <div class="ShowNav">
                <h3>
                    <strong>设计师/品牌</strong></h3>
                <div class="ShowNav-btn cs-clear">
                    <a class="btn-simple" href="#">搜索</a></div>
                <div class="ShowNav-search">
                    <input type="text" class="ipt-simple">
                    <div class="ShowNav-list" style="display: none">
                        <a href="#">Acne - Pre </a><a href="#">Amuse - Pre </a><a href="#">Burberry Prorsum
                            Cruise </a><a href="#">Celine - Pre </a><a href="#">Danjyo Hiyoji - Pre </a>
                        <a href="#">Acne - Pre </a><a href="#">Amuse - Pre </a><a href="#">Burberry Prorsum
                            Cruise </a><a href="#">Celine - Pre </a><a href="#">Depression - Pre </a><a href="#">
                                Diane von Furstenberg...</a> <a href="#">Erdem - Pre</a> <a href="#">Ermenegildo Zegna
                                </a><a href="#">Etro </a><a href="#">Giorgio Armani </a>
                    </div>
                </div>
            </div>
            <!-- -->
            <!-- -->
            <div class="Side_menu">
                <div class="common_menu">
                    <a href="#"><strong>行业招聘</strong></a>
                </div>
                <div class="common_menu cs-nobor">
                    <a href="#"><strong>行业人才</strong></a>
                </div>
            </div>
            <!-- -->
            <!-- -->
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>最新要闻</span></p>
                </h2>
            </div>
            <!-- -->
            <!-- -->
            <div class="Pho_Cap_Recom">
                <a href="#" class="PhoCap-a">
                    <img src="img/demo2.jpg" /></a>
                <h3>
                    <a href="#">DSQUARED2北京三里屯旗舰店盛大开幕</a></h3>
                <ul class="list-disc">
                    <li><a href="#">威廉王子大婚特辑</a></li>
                    <li><a href="#">70年代风格回潮明星示范撞色</a></li>
                    <li><a href="#">70年代风格回潮明星示范撞色</a></li>
                </ul>
            </div>
            <!-- -->
            <!-- -->
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>近期热点</span></p>
                </h2>
            </div>
            <!-- -->
            <!-- -->
            <div class="Pho_Cap_Recom">
                <a href="#" class="PhoCap-a">
                    <img src="img/demo3.jpg" /></a>
                <h3>
                    <a href="#">DSQUARED2北京三里屯旗舰店盛大开幕</a></h3>
                <ul class="list-disc">
                    <li><a href="#">威廉王子大婚特辑</a></li>
                    <li><a href="#">70年代风格回潮明星示范撞色</a></li>
                    <li><a href="#">70年代风格回潮明星示范撞色</a></li>
                </ul>
            </div>
            <!-- -->
            <!-- -->
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>特别推介</span></p>
                </h2>
            </div>
            <!-- -->
            <!-- -->
            <div class="Pho_Cap_Recom">
                <a href="#" class="PhoCap-a">
                    <img src="img/demo4.jpg" /></a>
                <h3>
                    <a href="#">DSQUARED2北京三里屯旗舰店盛大开幕</a></h3>
                <ul class="list-disc">
                    <li><a href="#">威廉王子大婚特辑</a></li>
                    <li><a href="#">70年代风格回潮明星示范撞色</a></li>
                    <li><a href="#">70年代风格回潮明星示范撞色</a></li>
                </ul>
            </div>
            <!-- -->
            <!-- -->
        </div>
        <!-- -->
    </div>
</asp:Content>
