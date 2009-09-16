<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Column.aspx.cs"
    Inherits="Column" Title="最新新闻" %>

<%@ Register Src="Controls/ColumnArticle.ascx" TagName="ColumnArticle" TagPrefix="uc4" %>

<%@ Register Src="Controls/HotList.ascx" TagName="HotList" TagPrefix="uc3" %>

<%@ Register Src="Controls/ImagesCtl.ascx" TagName="ImagesCtl" TagPrefix="uc2" %>

<%@ Register Src="Controls/Contact.ascx" TagName="Contact" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="location">您的位置： <a href="Index.aspx">首页</a> → <a href="Column.aspx">文章列表</a></div>
    <div class="main">
        <div class="container">
            <div class="column-sider">
                <!--栏目-->
                <uc3:HotList id="HotList1" runat="server"></uc3:HotList>
                <!--栏目-->
                <div class="boxA">
                    <uc1:Contact ID="Contact1" runat="server" />
                </div>
            </div>
            <div class="column-main">
                <!--栏目-->
                <div class="box">
                    <uc4:ColumnArticle id="ColumnArticle1" runat="server">
                    </uc4:ColumnArticle>    
                </div>
            </div>
            <!-- column-main end -->
        </div>
        <!--container end -->
    </div>
    <!-- main end -->
</asp:Content>
