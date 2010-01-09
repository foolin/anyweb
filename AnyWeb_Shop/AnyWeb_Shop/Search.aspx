<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" Title="产品搜索" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" Runat="Server">
<style type="text/css">
.search-list {
	line-height:1.5em;
	padding:5px;
}
.search-tips{
	font-size:14px;
	padding-left:20px;
	text-align:left;
}
.keywords{
	color:#F00;
	font-weight:bold;
}
table.goods-list
{
	width:100%;
	border-collapse:collapse;
	border:solid 1px #9ed96b;
	border:solid 1px #ccc;
}
table.goods-list th{
	line-height:25px;
	font-size:14px;
	padding:5px;
	border:dashed 1px #ccc;
	border-bottom:solid 1px #ccc;
}
table.goods-list td{
	border:dashed 1px #ccc;
	border-bottom:solid 1px #ccc;
	padding:5px;
	line-height:1.5em;
}

table.goods-list td ul li{
	padding:2px;
}
table.goods-list input{
	padding:3px;
	margin:3px;
	border:solid 1px #ccc;
}
.ctr
{
	line-height:0.5em;
	font-size:14px;
}
.ctr a
{
	text-decoration:none;
	margin:0px;
	display:block;
	width:80px;
	height:25px;
	line-height:25px;
	padding-left:5px;
	padding-right:5px;
	border:solid 1px #CCC;
	overflow:hidden;
}
.ctr a:hover{
	text-decoration:none;
	border:solid 1px #F00;
}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">	
    <div class="main">    	
    	<div class="gCol-sider">

        	<!-- 栏目 -->
        	<div class="category">
            	<div class="title">商品分类</div>
                <div class="content">
                
            		<h3>图像音像分类</h3>
                  	<ul>
                      <li><a href="">DVD</a></li>
                      <li><a href="">DVD</a></li>
                    </ul>
                    
                    <div class="clear"></div>
                </div>
                <!-- content end -->
            </div>
            <!-- category end -->
        
        </div>
        <!-- col-sider end -->

        <div class="gCol-main">
        
            <div class="box">
                <div class="title">
        	        <div class="search-tips">您搜索<span class="keywords"><asp:Literal ID="litKeywords" runat="server"></asp:Literal></span>，一共有<asp:Literal ID="litRecord" runat="server"></asp:Literal>条记录。</div>
                </div>
			<div class="search-list">
            	<table class="goods-list">
                	<tr>
                    	<th width="130">缩略图</th>
                        <th>商品信息</th>
                        <th width="20%">操作</th>
                    </tr>
                    
                    <asp:Repeater ID="repGoods" runat="server">
                        <ItemTemplate>
                                    
                	                <tr>
                    	                <td>
                                        <a href="Good.aspx?gid=<%#Eval("ID") %>"><img src="<%#(string)Eval( "image" )=="" ? "../images/wait.jpg":(string)Eval( "image" ) %>"
                                border="0" alt="<%#Eval("GoodsName")%>" /></a></td>
                                        <td>
                        	                <ul>
                            	                <li><a href="Good.aspx?gid=<%#Eval("ID") %>"><%#Eval("GoodsName")%></a></li>
                                                <li>市场价格：<s>￥ <%#Eval("MarketPrice")%>元</s></li>
                                                <li>基团网价格：<%#(bool)Eval("IsRecommend") ? "<s>￥ " + Eval("Price").ToString() + "元</s>" : "￥ " + Eval("Price").ToString() + "元"%></li>
                                                <%#(bool)Eval("IsRecommend") ? "<li>促销价格：￥ " + Eval("PromotionsPrice").ToString() + "元</li>" : ""%>
                                                <li>存货：<%#GetGoodCount((int)Eval("Status"))%></li>
                                            </ul>
                                        </td>
                                        <td>
                                            <div class="ctr">
                                            <a href="Good.aspx?gid=<%#Eval("ID") %>">查看详细信息</a><br />
                                            <a href="#">购买</a><br />
                                            <a href="#">添加到购物车</a><br />
                                            </div>
                                        </td>
                                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                
                </table>
                
                <div class="page">
                
                	<cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="10"></cc1:PageNaver>
                
                </div>
                
                <div class="search">
                    <form action="search.aspx" method="get">
                    <label>
                        搜索：</label>
                    <input name="keywords" type="text" onclick="if(this.value=='请输入关键词')this.value='';" value="<%=keywords %>" />
                    <input class="button" type="submit" value="搜索" />
                    <span class="hot-tags"><a href="AdvancedSearch.aspx">高级搜索</a></span>
                    </form>
                </div>
           </div>
           <!-- box end -->
           
           </div>
                
        </div>
        <!-- col-main -->
    	<div class="clear"></div>
    
    
    </div>
    <!-- main end -->
</asp:Content>

