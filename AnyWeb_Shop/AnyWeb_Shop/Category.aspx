<%@ Page Title="商品分类" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Category.aspx.cs" Inherits="Web_Category" %>

<%@ Register Src="~/Controls/CategoryInner.ascx" TagName="CategoryInner" TagPrefix="cate" %>
<%@ Register Src="~/Controls/GoodsByCate.ascx"TagName="GoodsByCate" TagPrefix="cate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
    <link href="/public/category.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="main">
        <div class="col-sider">
            <!-- 栏目 -->
            <!-- 栏目 -->
        	<cate:CategoryInner runat="server" />
            <!-- category end -->
        </div>
        <!-- col-sider end -->
        <div class="col-main">
            <cate:GoodsByCate runat="server" />
            <!-- container end -->
        </div>
        <!-- col-main -->
        <div class="clear">
        </div>
    </div>
    <!-- main end -->
</asp:Content>
