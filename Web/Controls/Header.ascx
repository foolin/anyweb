<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Controls_Header" %>
<div class="header">
    <div class="loveFav">
        <a href="#" onclick="return HomePage.call(this);">设为首页</a> &nbsp;|&nbsp; 
        <a href="#" onclick="return Love();">添加收藏</a> &nbsp;|&nbsp; 
        <a href="/Contact.aspx"> 联系我们</a>
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
<!-- header end -->
<div class="nav">
    <ul>
        <li><a href="index.aspx">首页</a></li>
        <li><a href="Company.aspx">企业介绍</a></li>
        <li><a href="Column.aspx?id=1">最新新闻</a></li>
        <li><a href="Column.aspx?id=2">社务动态</a></li>
        <li><a href="Column.aspx?id=3">政策法规</a></li>
        <li><a href="GoodsSell.aspx">商品销售</a></li>
        <li><a href="LkdMarket.aspx">龙口东市场</a></li>
        <li><a href="HR.aspx">人力资源</a></li>
        <li><a href="Contact.aspx">联系我们</a></li>
        <li style="float:right; padding-right:5px;font-size:12px; font-weight:normal; width:210px; height:35px;overflow:hidden;"><span id="time">加载中...</span></li>
    </ul>
</div>
<script type="text/javascript" language="javascript">
<!--
//时间,每秒刷新
function $(o){ return typeof(o)=="string" ? document.getElementById(o) : o;}
setInterval("$('time').innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());",1000);
-->
</script>
<!-- nav end -->
<div class="hr">
</div>


