<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Controls_Header" %>
<div class="header">
    <div class="loveFav">
        <a href="#" onclick="return HomePage.call(this);">设为首页</a> &nbsp;|&nbsp; <a href="#"
            onclick="return Love();">添加收藏</a> &nbsp;|&nbsp; <a href="javascript:open('about-us');">
                联系我们</a>
    </div>
    <!-- loveFav end -->
    <div class="top-flash">

        <script language="javascript" type="text/javascript">
		    <!--
			    writeflashhtml("_swf=/images/top.swf", "_width=780", "_height=120" ,"_wmode=transparent");
			-->
        </script>

    </div>
    <!-- top-flash end -->
</div>
<div class="nav">
    <ul>
        <li><a href="index.aspx">首页</a></li>
        <li><a href="list.html">企业介绍</a></li>
        <li><a href="Column.aspx?id=1">最新新闻</a></li>
        <li><a href="Column.aspx?id=2">社务动态</a></li>
        <li><a href="Column.aspx?id=3">政策法规</a></li>
        <li><a href="list.html">商品销售</a></li>
        <li><a href="list.html">龙口东市场</a></li>
        <li><a href="list.html">人力资源</a></li>
        <li><a href="list.html">联系我们</a></li>
    </ul>
</div>
<!-- nav end -->
<div class="hr">
</div>
<!-- header end -->
