<%@ Page Title="推荐列表" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Recomment.aspx.cs" Inherits="Recomment" %>

<%@ Register Src="~/Controls/RecommentCate.ascx" TagName="Recomment" TagPrefix="cate" %>
<%@ Register Src="~/Controls/RecommentGoods.ascx"TagName="Recomment" TagPrefix="good" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" Runat="Server">
    <link href="/public/category.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="location">您的位置：<a href="Default.aspx">首页</a> → 推荐商品 </div>
    <div class="main">
        <div class="col-sider">
            <!-- 栏目 -->
            <!-- 栏目 -->
        	<cate:Recomment runat="server" />
            <!-- category end -->
        </div>
        <!-- col-sider end -->
        <div class="col-main">
            <good:Recomment runat="server" />
            <!-- container end -->
        </div>
        <!-- col-main -->
        <div class="clear">
        </div>
    </div>
    <!-- main end -->
</asp:Content>

