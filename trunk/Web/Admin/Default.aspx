<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="后台首页" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    后台首页
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content">
        <div id="content">
            <asp:Label ID="LoginUserTips" runat="server" Text="Label" ForeColor="Green" Font-Size="14px" Height="25px"></asp:Label>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="navmenu">
        <dl>
        <dt>系统管理</dt>
	    <dd>
		<a href="/Admin/Layout/ArticleAdd.aspx">添加文档</a></dd>
            <dd>
                <a href="/Admin/Layout/LinkAdd.aspx">添加链接</a></dd>
            <dd>
                <a href="/Admin/Content/PhotoAdd.aspx">上传图片</a></dd>
            <dd>
                <a href="/Admin/Setting/LogList.aspx">操作日志</a></dd>
            <dd>
                <a href="Logout.aspx" target="_top">退出管理</a></dd>
        </dl>
    </div>
</asp:Content>
