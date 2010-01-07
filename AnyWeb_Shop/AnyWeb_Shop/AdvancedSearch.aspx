<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdvancedSearch.aspx.cs" Inherits="AdvancedSearch" Title="高级搜索" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" Runat="Server">
<style type="text/css">
<!--
.advanced-search {
	padding:5px;
	padding-left:20px;
	font-size:14px;
}
.advanced-search p{
	margin:5px;
}
.advanced-search p .left{
	width:150px;
	display:inline-block;
	text-align:right;
}
.advanced-search p .right{
	padding-left:5px;
}
.advanced-search input{
	padding:3px;
}
-->
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
            	<div class="title">高级搜索</div>
                <div class="advanced-search">
                    <form action="Search.aspx" method="post">
                        <p>
                        	<span class="left">关键词：</span>
                            <span class="right"><input name="keywords" type="text" onclick="if(this.value=='请输入关键词')this.value='';" value="请输入关键词" /> 多关键词用空格分开</span>
                        </p>
                        <p>
                        	<span class="left">分类：</span>
                            <span class="right">
                                <select name="category"> 
                                    <option value="0" selected="selected">全部</option> 
                                    <asp:Repeater ID="repCate" runat="server">
                                        <ItemTemplate>
                                            <option value="<%#Eval("ID") %>"><%#Eval("Name")%></option> 
                                        </ItemTemplate>
                                    </asp:Repeater>
							    </select>
							</span>
                        </p>
                        <p>
                        	<span class="left">价格：</span>
                            <span class="right"><input name="price" type="text" value="" style="width:50px;" /> 请输入价格（单位：元）</span>
                        </p>
                   		<p>
                        	<span class="left"></span>
                        	<span class="right"><input type="submit" value="高级搜索"  /></span>
                        </p>
                    </form>
                </div>
            </div>
            <!-- box end -->
            
            
        </div>
        <div class="clear"></div>
        <!-- gCol-main -->

    
    </div>
    <!-- main end -->
</asp:Content>

