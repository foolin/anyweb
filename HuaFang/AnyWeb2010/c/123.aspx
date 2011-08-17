<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="123.aspx.cs" Inherits="c_123" %>

<%@ Register Src="~/Controls/TagList.ascx" TagName="TagList" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/SideMenu.ascx" TagName="SideMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide1.ascx" TagName="LeftSide1" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide2.ascx" TagName="LeftSide2" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide3.ascx" TagName="LeftSide3" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ArticleListSkin1.ascx" TagName="ArticleListSkin1" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ArticleListSkin4.ascx" TagName="ArticleListSkin4" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ArticleListSkin5.ascx" TagName="ArticleListSkin5" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ArticleListSkin6.ascx" TagName="ArticleListSkin6" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="product cs-clear">
        <uc1:TagList ID="TagList1" runat="server" />
        <uc1:Search ID="Search1" runat="server" />
    </div>
    <div class="cs-group">
        <div class="g_760">
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>品牌新闻</span></p>
                    <p class="title-eng EngTit NEWS cs-fr">
                        NEW<span>S</span></p>
                </h2>
            </div>
            <div class="cs-section Column_sec1">
                <uc1:ArticleListSkin1 runat="server" columnID="130" />
            </div>
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>大师花边</span></p>
                    <p class="title-eng EngTit DESIGNERGOSSIP cs-fr">
                        DESIGNER<span>GOSSIP</span></p>
                </h2>
            </div>
            <div class="cs-section Index_sec2">
                <uc1:ArticleListSkin6 runat="server" columnID="132" />
            </div>
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>广告大片</span></p>
                    <p class="title-eng EngTit CAMPAIGN cs-fr">
                        CAMP<span>AIGN</span></p>
                </h2>
            </div>
            <div class="cs-section Index_sec4">
                <uc1:ArticleListSkin4 runat="server" columnID="133" />
            </div>
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>造型画册</span></p>
                    <p class="title-eng EngTit LOOKBOOK cs-fr">
                        LOOK<span>BOOK</span></p>
                </h2>
            </div>
            <div class="cs-section Column_sec5">
                <uc1:ArticleListSkin5 runat="server" columnID="154" />
            </div>
        </div>
        <div class="g_192">
            <uc1:SideMenu ID="SideMenu1" runat="server" />
            <uc1:LeftSide1 ID="LeftSide1" runat="server" />
            <uc1:LeftSide2 ID="LeftSide2" runat="server" />
            <uc1:LeftSide3 ID="LeftSide3" runat="server" />
        </div>
    </div>
</asp:Content>
