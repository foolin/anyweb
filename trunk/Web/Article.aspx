<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Article.aspx.cs"
    Inherits="Article" Title="文章" %>

<%@ Register Src="Controls/ArticleContent.ascx" TagName="ArticleContent" TagPrefix="uc3" %>

<%@ Register Src="Controls/HotList.ascx" TagName="HotList" TagPrefix="uc2" %>

<%@ Register Src="Controls/Contact.ascx" TagName="Contact" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="location">您的位置： <a href="Index.aspx">首页</a> → <a href="Column.aspx">文章</a> → 正文</div>
    <div class="main">
        <div class="container">
            <div class="column-sider">
                <!--栏目-->
                <uc2:HotList ID="HotList1" runat="server" />
                <!--栏目-->
                <div class="boxA">
                    <uc1:Contact ID="Contact1" runat="server" />
                </div>
            </div>
            <div class="column-main">
                <uc3:ArticleContent id="ArticleContent1" runat="server">
                </uc3:ArticleContent></div>
            <!-- column-main end -->
        </div>
        <!--container end -->
    </div>
    <!-- main end -->
</asp:Content>
