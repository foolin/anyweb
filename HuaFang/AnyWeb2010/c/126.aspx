<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="126.aspx.cs" Inherits="c_126" %>

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
        <uc1:TagList runat="server" />
        <uc1:Search runat="server" />
    </div>
    <div class="cs-group">
        <div class="g_760">
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>潮人搭配</span></p>
                    <p class="title-eng cs-fr">
                        STREET<span>PHOTOS</span></p>
                </h2>
            </div>
            <div class="cs-section Column_sec1">
                <uc1:ArticleListSkin1 runat="server" columnID="148" />
            </div>
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>花边新闻</span></p>
                    <p class="title-eng cs-fr">
                        GOSS<span>IP</span></p>
                </h2>
            </div>
            <div class="cs-section Index_sec2">
                <uc1:ArticleListSkin6 runat="server" columnID="147" />
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
