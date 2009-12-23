<%@ Page Title="基团网" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="Index" %>
<%@ Register Src="~/Controls/CategoryLeft.ascx" TagName="CategoryLeft" TagPrefix="cate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="col-left">
            <!-- 栏目 -->
            <cate:CategoryLeft runat="server" />
            <!-- category end -->
            <!-- 栏目 -->
            <div class="category">
                <div class="title">
                    商品分类</div>
                <div class="content">
                    <h3>
                        图像音像分类</h3>
                    <div class="line">
                        <span><a href="">DVD</a></span> <span><a href="">影视</a></span> <span><a href="">音乐</a></span>
                        <span><a href="">音乐</a></span> <span><a href="">音乐</a></span> <span><a href="">音s乐</a></span>
                        <span><a href="">音s乐</a></span> <span><a href="">音s乐</a></span> <span><a href="">DVD</a></span>
                        <span><a href="">影视</a></span> <span><a href="">音乐</a></span> <span><a href="">音乐</a></span>
                        <span><a href="">音乐</a></span> <span><a href="">音s乐</a></span> <span><a href="">音s乐</a></span>
                        <span><a href="">音s乐</a></span>
                        <div class="clear">
                        </div>
                    </div>
                    <h3>
                        图像音像分类</h3>
                    <div class="line">
                        <span><a href="">DVD</a></span> <span><a href="">影视</a></span> <span><a href="">音乐</a></span>
                        <span><a href="">音乐</a></span> <span><a href="">音乐</a></span> <span><a href="">音s乐</a></span>
                        <span><a href="">音s乐</a></span> <span><a href="">音s乐</a></span> <span><a href="">DVD</a></span>
                        <span><a href="">影视</a></span> <span><a href="">音乐</a></span> <span><a href="">音乐</a></span>
                        <span><a href="">音乐</a></span> <span><a href="">音s乐</a></span> <span><a href="">音s乐</a></span>
                        <span><a href="">音s乐</a></span>
                        <div class="clear">
                        </div>
                    </div>
                    <h3>
                        图像音像分类</h3>
                    <div class="line">
                        <span><a href="">DVD</a></span> <span><a href="">影视</a></span> <span><a href="">音乐</a></span>
                        <span><a href="">音乐</a></span> <span><a href="">音乐</a></span> <span><a href="">音s乐</a></span>
                        <span><a href="">音s乐</a></span> <span><a href="">音s乐</a></span> <span><a href="">DVD</a></span>
                        <span><a href="">影视</a></span> <span><a href="">音乐</a></span> <span><a href="">音乐</a></span>
                        <span><a href="">音乐</a></span> <span><a href="">音s乐</a></span> <span><a href="">音s乐</a></span>
                        <span><a href="">音s乐</a></span>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <!-- content end -->
            </div>
            <!-- category end -->
        </div>
        <!-- col-left -->
        <div class="col-main">
            <div class="container-images">
                <div class="slide-container" id="slide-container">
                    <table id="slide-images" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <a href="saaa">
                                    <img src="pictures/slide01.jpg" /></a>
                            </td>
                            <td>
                                <a href="saaa">
                                    <img src="http://images.amazon.cn/w/wjf_091102_email_80.jpg?15" /></a>
                            </td>
                            <td>
                                <a href="saaa">
                                    <img src="http://images.amazon.cn/h/hl_091202_bea470_water.jpg??15" /></a>
                            </td>
                            <td>
                                <a href="saaa">
                                    <img src="http://images.amazon.cn/w/wj_091204_homecare_470-200_quilt2.jpg??15" /></a>
                            </td>
                            <td>
                                <a href="saaa">
                                    <img src="http://images.amazon.cn/l/lll_091203_dn470_basics.jpg?15" /></a>
                            </td>
                        </tr>
                    </table>
                    <ul class="num" id="idNum">
                    </ul>
                </div>
                <!-- slide-container end -->
            </div>
            <!-- container-images end -->

            <script>
///////////////////////////////////////////////////////////
var forEach = function(array, callback, thisObject){
	if(array.forEach){
		array.forEach(callback, thisObject);
	}else{
		for (var i = 0, len = array.length; i < len; i++) { callback.call(thisObject, array[i], i, array); }
	}
}

var st = new SlideTrans("slide-container", "slide-images", 5, { Vertical: false });

var nums = [];
//插入数字
for(var i = 0, n = st._count - 1; i <= n;){
	(nums[i] = $("idNum").appendChild(document.createElement("li"))).innerHTML = ++i;
}

forEach(nums, function(o, i){
	o.onmouseover = function(){ o.className = "on"; st.Auto = false; st.Run(i); }
	o.onmouseout = function(){ o.className = ""; st.Auto = true; st.Run(); }
})

//设置按钮样式
st.onStart = function(){
	forEach(nums, function(o, i){ o.className = st.Index == i ? "on" : ""; })
}

st.Run();
            </script>

            <div class="container">
                <div class="goods-container">
                    <div class="title">
                        热荐商品</div>
                    <div class="goods">
                        <!-- Index Item -->
                        <div class="index-item">
                            <div class="pic">
                                <a href="#test">
                                    <img src="pictures/04.jpg" border="0" alt="0" /></a>
                            </div>
                            <div class="name">
                                <a href="#test">社科图书</a>
                            </div>
                        </div>
                        <ul class="items">
                            <li><a href="#test">社科图书</a></li>
                            <li><a href="#test">社科图书</a></li>
                            <li><a href="#test">社科图书</a></li>
                            <li><a href="#test">社科图书</a></li>
                        </ul>
                    </div>
                    <!-- goods end-->
                    <div class="goods">
                        <!-- Index Item -->
                        <div class="index-item">
                            <div class="pic">
                                <a href="#test">
                                    <img src="pictures/04.jpg" border="0" alt="0" /></a>
                            </div>
                            <div class="name">
                                <a href="#test">社科图书</a>
                            </div>
                        </div>
                        <ul class="items">
                            <li><a href="#test">社科图书</a></li>
                            <li><a href="#test">社科图书</a></li>
                            <li><a href="#test">社科图书</a></li>
                            <li><a href="#test">社科图书</a></li>
                        </ul>
                    </div>
                    <!-- goods end-->
                    <div class="goods">
                        <!-- Index Item -->
                        <div class="index-item">
                            <div class="pic">
                                <a href="#test">
                                    <img src="pictures/04.jpg" border="0" alt="0" /></a>
                            </div>
                            <div class="name">
                                <a href="#test">社科图书</a>
                            </div>
                        </div>
                        <ul class="items">
                            <li><a href="#test">社科图书</a></li>
                            <li><a href="#test">社科图书</a></li>
                            <li><a href="#test">社科图书</a></li>
                            <li><a href="#test">社科图书</a></li>
                        </ul>
                    </div>
                    <!-- goods end-->
                    <div class="clear">
                    </div>
                </div>
                <!-- goods-container end -->
                <div class="goods-container">
                    <div class="title">
                        热荐商品</div>
                    <div class="goods">
                        <!-- Index Item -->
                        <div class="index-item">
                            <div class="pic">
                                <a href="#test">
                                    <img src="pictures/04.jpg" border="0" alt="0" /></a>
                            </div>
                            <div class="name">
                                <a href="#test">社科图书</a>
                            </div>
                        </div>
                        <ul class="items">
                            <li><a href="#test">社科图书</a></li>
                            <li><a href="#test">社科图书</a></li>
                            <li><a href="#test">社科图书</a></li>
                            <li><a href="#test">社科图书</a></li>
                        </ul>
                    </div>
                    <!-- goods end-->
                    <div class="goods">
                        <!-- Index Item -->
                        <div class="index-item">
                            <div class="pic">
                                <a href="#test">
                                    <img src="pictures/04.jpg" border="0" alt="0" /></a>
                            </div>
                            <div class="name">
                                <a href="#test">社科图书</a>
                            </div>
                        </div>
                        <ul class="items">
                            <li><a href="#test">魔笔小良彩笔系统39元起</a></li>
                            <li><a href="#test">魔笔小良彩笔系统39元起</a></li>
                            <li><a href="#test">社科图书</a></li>
                            <li><a href="#test">社科图书</a></li>
                        </ul>
                    </div>
                    <!-- goods end-->
                    <div class="goods">
                        <!-- Index Item -->
                        <div class="index-item">
                            <div class="pic">
                                <a href="#test">
                                    <img src="pictures/04.jpg" border="0" alt="0" /></a>
                            </div>
                            <div class="name">
                                <a href="#test">社科图书</a>
                            </div>
                        </div>
                        <ul class="items">
                            <li><a href="#test">魔笔小良彩笔系统39元起</a></li>
                            <li><a href="#test">魔笔小良彩笔系统39元起</a></li>
                            <li><a href="#test">社科图书</a></li>
                            <li><a href="#test">社科图书</a></li>
                        </ul>
                    </div>
                    <!-- goods end-->
                    <div class="clear">
                    </div>
                </div>
                <!-- goods-container end -->
            </div>
            <!-- container end -->
        </div>
        <!-- col-main -->
        <div class="col-right">
            <div class="topic-box">
                <!-- 促销专题开始 -->
                <div class="title">
                    促销专题</div>
                <div class="topic-goods">
                    <div class="goods-pic">
                        <a href="#links">
                            <img src="pictures/01.jpg" width="90" height="90" alt="" border="0" />
                        </a>
                    </div>
                    <div class="goods-intro">
                        <div class="content">
                            <h5>
                                奥特蓝星专卖店上线5折起</h5>
                            奥特蓝星是一家拥有70多年历史的老牌音频产品制造商，是美国市场上最负盛名的音响品牌之一，现卓越亚马逊奥特蓝星专卖店开业全场疯狂抢购5折起!
                        </div>
                        <div class="more">
                            <a href="#details.aspx">查看更多>></a></div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <!-- topic-goods end-->
                <div class="topic-goods">
                    <div class="goods-pic">
                        <a href="#links">
                            <img src="pictures/02.jpg" width="90" height="90" alt="" border="0" />
                        </a>
                    </div>
                    <div class="goods-intro">
                        <div class="content">
                            <h5>
                                奥特蓝星专卖店上线5折起</h5>
                            奥特蓝星是一家拥有70多年历史的老牌音频产品制造商，是美国市场上最负盛名的音响品牌之一，现卓越亚马逊奥特蓝星专卖店开业全场疯狂抢购5折起!
                        </div>
                        <div class="more">
                            <a href="#details.aspx">查看更多>> </a>
                        </div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <!-- topic-goods end-->
                <!-- 促销专题结束 -->
                <div style="height: 10px;">
                    <!-- 分割 -->
                </div>
                <div class="title">
                    最畅销影视作品</div>
                <div class="hot-goods">
                    <div class="goods-pic">
                        <a href="#links">
                            <img src="pictures/01.jpg" width="90" height="90" alt="" border="0" />
                        </a>
                    </div>
                    <div class="goods-list">
                        <ol>
                            <li><a href="#hotgoods.aspx?id=3">风声(DVD 简装版) </a></li>
                            <li><a href="#hotgoods.aspx?id=3">变形金刚2(2DVD9金版) </a></li>
                            <li><a href="#hotgoods.aspx?id=3">易经的奥秘(8DVD+书)(百家讲坛) </a></li>
                        </ol>
                        <div class="more">
                            <a href="#more">更多排行榜</a></div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <!-- hot-goods end -->
                <div class="title">
                    最畅销影视作品</div>
                <div class="hot-goods">
                    <div class="goods-pic">
                        <a href="#links">
                            <img src="pictures/01.jpg" width="90" height="90" alt="" border="0" />
                        </a>
                    </div>
                    <div class="goods-list">
                        <ol>
                            <li><a href="#hotgoods.aspx?id=3">风声(DVD 简装版) </a></li>
                            <li><a href="#hotgoods.aspx?id=3">变形金刚2(2DVD9金版) </a></li>
                            <li><a href="#hotgoods.aspx?id=3">易经的奥秘(8DVD+书)(百家讲坛) </a></li>
                        </ol>
                        <div class="more">
                            <a href="#more">更多排行榜</a></div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <!-- hot-goods end -->
                <div class="title">
                    最畅销影视作品</div>
                <div class="hot-goods">
                    <div class="goods-pic">
                        <a href="#links">
                            <img src="pictures/01.jpg" width="90" height="90" alt="" border="0" />
                        </a>
                    </div>
                    <div class="goods-list">
                        <ol>
                            <li><a href="#hotgoods.aspx?id=3">风声(DVD 简装版) </a></li>
                            <li><a href="#hotgoods.aspx?id=3">变形金刚2(2DVD9金版) </a></li>
                            <li><a href="#hotgoods.aspx?id=3">易经的奥秘(8DVD+书)(百家讲坛) </a></li>
                        </ol>
                        <div class="more">
                            <a href="#more">更多排行榜</a></div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <!-- hot-goods end -->
            </div>
            <!-- topic-box end -->
        </div>
        <!-- col-right -->
        <div class="clear">
        </div>
    </div>
    <!-- main end -->
    <div class="ad-banner">
        专题及节日销售活动
    </div>
    <!-- ad-banner end -->
</asp:Content>
