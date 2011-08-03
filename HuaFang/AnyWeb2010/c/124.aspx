<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="124.aspx.cs" Inherits="c_124" %>

<%@ Register Src="~/Controls/TagList.ascx" TagName="TagList" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/FashionLeftSide.ascx" TagName="FashionLeftSide" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide1.ascx" TagName="LeftSide1" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide2.ascx" TagName="LeftSide2" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide3.ascx" TagName="LeftSide3" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/FashionArticleListSkin1.ascx" TagName="FashionArticleListSkin1" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/FashionArticleListSkin2.ascx" TagName="FashionArticleListSkin2" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="product cs-clear">
        <uc1:TagList runat="server" />
        <uc1:Search runat="server" />
    </div>
    <div class="cs-group">
        <div class="title-bar">
            <h2 class="cs-clear">
                <p class="title-ch cs-fl">
                    <span>热秀推荐</span></p>
            </h2>
        </div>
    </div>
    <div class="Hot_Show cs-clear">
        <asp:Repeater ID="repHot" runat="server">
            <ItemTemplate>
                <div class="HotShow-box <%#Container.ItemIndex==0?"HotShow-item":"" %>">
                    <a class="" href="<%#Eval("fdArtiPath") %>">
                        <img src="<%#Eval("fdArtiPic") %>" /></a>
                    <p class="HotShow-info">
                        <a class="HotShow-tit" href="<%#Eval("fdArtiPath") %>">
                            <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 10 )%></a><span><%#Eval("fdArtiCategoryName") %></span><span><%#Eval("Column.fdColuName") %></span>
                    </p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="cs-group">
        <div class="g_760">
            <uc1:FashionArticleListSkin1 ID="column1" runat="server" />
            <uc1:FashionArticleListSkin2 ID="column2" runat="server" />
            <uc1:FashionArticleListSkin1 ID="column3" runat="server" />
            <uc1:FashionArticleListSkin2 ID="column4" runat="server" />
        </div>
        <div class="g_192">
            <uc1:FashionLeftSide runat="server" />
            <uc1:LeftSide1 runat="server" />
            <uc1:LeftSide2 runat="server" />
            <uc1:LeftSide3 runat="server" />
        </div>
    </div>
</asp:Content>
