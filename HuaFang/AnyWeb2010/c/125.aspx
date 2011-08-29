<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="125.aspx.cs" Inherits="c_125" %>

<%@ Register Src="~/Controls/TagList.ascx" TagName="TagList" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/SideMenu.ascx" TagName="SideMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide1.ascx" TagName="LeftSide1" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ArticleListSkin1.ascx" TagName="ArticleListSkin1" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ArticleListSkin4.ascx" TagName="ArticleListSkin4" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ArticleListSkin5.ascx" TagName="ArticleListSkin5" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ArticleListSkin6.ascx" TagName="ArticleListSkin6" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="product cs-clear">
        <uc1:TagList ID="TagList1" runat="server" />
        <uc1:Search ID="Search1" runat="server" />
    </div>
    <div class="cs-group">
        <div class="g_760">
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>星级影踪</span></p>
                    <p class="title-eng EngTit CELEBSGALLERY cs-fr">
                        CELEBS<span>GALLERY</span></p>
                </h2>
            </div>
            <div class="cs-section Column_sec1">
                <uc1:ArticleListSkin1 runat="server" columnID="143" />
            </div>
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>星级八卦</span></p>
                    <p class="title-eng EngTit CELEBSGOSSIP cs-fr">
                        CELEBS<span>GOSSIP</span></p>
                </h2>
            </div>
            <div class="cs-section Index_sec2">
                <uc1:ArticleListSkin6 runat="server" columnID="141" />
            </div>
        </div>
        <div class="g_192">
            <uc1:SideMenu runat="server" />
            <uc1:LeftSide1 runat="server" />
        </div>
    </div>
</asp:Content>

