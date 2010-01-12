<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Promotion.aspx.cs" Inherits="Promotion" %>

<%@ Register Src="~/Controls/PromotionCate.ascx" TagName="Promotion" TagPrefix="cate" %>
<%@ Register Src="~/Controls/PromotionGoods.ascx"TagName="Promotion" TagPrefix="good" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" Runat="Server">
    <link href="/public/category.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">

    <div class="location">您的位置：<a href="Default.aspx">首页</a> → 促销商品 </div>

    <div class="main">
        <div class="col-sider">
            <!-- 栏目 -->
            <!-- 栏目 -->
        	<cate:Promotion runat="server" />
            <!-- category end -->
        </div>
        <!-- col-sider end -->
        <div class="col-main">
            <good:Promotion runat="server" />
            <!-- container end -->
        </div>
        <!-- col-main -->
        <div class="clear">
        </div>
    </div>
    <!-- main end -->
</asp:Content>