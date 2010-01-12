<%@ Page Title="产品信息" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Good.aspx.cs" Inherits="Good" %>
<%@ Register Src="~/Controls/CategoryInner.ascx" TagName="CategoryInner" TagPrefix="cate" %>
<%@ Register Src="~/Controls/ProductInfo.ascx" TagName="GoodDetail" TagPrefix="good" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
    <link href="/public/goods_details.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">

    <div class="location">您的位置：<a href="Default.aspx">首页</a> → 商品信息 </div>

    <div class="main">
        <div class="col-sider">
            <cate:CategoryInner runat="server" />
        </div>
        <!-- col-sider end -->
        <div class="col-main">
            <div class="box">
                <good:GoodDetail runat="server" />
            </div>
            <!-- container end -->
        </div>
        <!-- col-main -->
        <div class="clear">
        </div>
    </div>
    <!-- main end -->
</asp:Content>
