<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" Title="无标题页" %>
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
table.goods-list{
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
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="location">您的位置：<a href="Index.aspx">首页</a> → 商品搜索 </div>
	
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
                                                <li><s>￥ <%#Eval("MarketPrice")%>元</s></s> ￥ <%#Eval("PromotionsPrice")%></li>
                                                <li>存货：<%#GetGoodCount((int)Eval("Status"))%></li>
                                            </ul>
                                        </td>
                                        <td>
                                            <a href="Good.aspx?gid=<%#Eval("ID") %>">查看详细信息</a><br />
                        	                <input type="button" name="buy" value="购买" />
                                            <input type="button" name="addToCart" value="添加到购物车" />
                                        </td>
                                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                
                </table>
                <div class="page">
                
                	<cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="10"></cc1:PageNaver>
                
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

