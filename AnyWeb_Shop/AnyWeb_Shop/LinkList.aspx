<%@ Page Title="友情链接" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LinkList.aspx.cs" Inherits="Web_LinkList" %>
<%@ Register Src="~/Controls/CategoryInner.ascx" TagName="CategoryInner" TagPrefix="cate" %>
<%@ Register Src="~/Controls/LinkList.ascx" TagName="LinkList" TagPrefix="link" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" Runat="Server">
    <link href="/public/category.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="main">
        <div class="col-sider">
            <!-- 栏目 -->
            <!-- 栏目 -->
        	<cate:CategoryInner ID="CategoryInner1" runat="server" />
            <!-- category end -->
        </div>
        <!-- col-sider end -->
        <div class="col-main">
            <link:LinkList runat="server" />
            <!-- container end -->
        </div>
        <!-- col-main -->
        <div class="clear">
        </div>
    </div>
    <!-- main end -->
</asp:Content>

