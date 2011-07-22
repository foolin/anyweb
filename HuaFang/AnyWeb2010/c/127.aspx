<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="127.aspx.cs" Inherits="c_127" %>

<%@ Register Src="~/Controls/TagList.ascx" TagName="TagList" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/SideMenu.ascx" TagName="SideMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide1.ascx" TagName="LeftSide1" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide2.ascx" TagName="LeftSide2" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide3.ascx" TagName="LeftSide3" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ArticleListSkin1.ascx" TagName="ArticleListSkin1" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ArticleListSkin2.ascx" TagName="ArticleListSkin2" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ArticleListSkin3.ascx" TagName="ArticleListSkin3" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ArticleListSkin4.ascx" TagName="ArticleListSkin4" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ArticleListSkin5.ascx" TagName="ArticleListSkin5" TagPrefix="uc1" %>
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
                        <span>服装配饰</span></p>
                    <p class="title-eng cs-fr">
                        ENGLISH<span>NAME</span></p>
                </h2>
            </div>
            <div class="cs-section Column_sec1">
                <uc1:ArticleListSkin1 runat="server" columnID="150" />
            </div>
            <div class="cs-section Index_sec2">
                <div class="g_360 cs-fl">
                    <div class="title-bar">
                        <h2 class="cs-clear">
                            <p class="title-ch cs-fl">
                                <span>时尚活动</span></p>
                            <p class="title-eng cs-fr">
                                EVENT<span>S</span></p>
                        </h2>
                    </div>
                    <uc1:ArticleListSkin2 runat="server" columnID="151" />
                </div>
                <div class="g_360 cs-fr">
                    <div class="title-bar">
                        <h2 class="cs-clear">
                            <p class="title-ch cs-fl">
                                <span>美妆美容</span></p>
                            <p class="title-eng cs-fr">
                                BEAU<span>TY</span></p>
                        </h2>
                    </div>
                    <uc1:ArticleListSkin3 runat="server" columnID="149" />
                </div>
            </div>
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>品味人生</span></p>
                    <p class="title-eng cs-fr">
                        GOOD<span>TASTE</span></p>
                </h2>
            </div>
            <div class="cs-section Index_sec4">
                <uc1:ArticleListSkin4 runat="server" columnID="152" />
            </div>
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>旅行生活</span></p>
                    <p class="title-eng cs-fr">
                        TRA<span>VEL</span></p>
                </h2>
            </div>
            <div class="cs-section Column_sec5">
                <uc1:ArticleListSkin5 runat="server" columnID="153" />
            </div>
        </div>
        <div class="g_192">
            <uc1:SideMenu runat="server" />
            <uc1:LeftSide1 runat="server" />
            <uc1:LeftSide2 runat="server" />
            <uc1:LeftSide3 runat="server" />
        </div>
    </div>
</asp:Content>
