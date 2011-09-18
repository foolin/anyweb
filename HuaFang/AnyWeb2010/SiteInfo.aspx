<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SiteInfo.aspx.cs" Inherits="SiteInfo" %>

<%@ Register Src="~/Controls/TagList.ascx" TagName="TagList" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/SideMenu.ascx" TagName="SideMenu" TagPrefix="uc1" %>
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
                        <a href="/Index.aspx">首页</a>//<span><%=bean.fdSiInTitle%></span></p>
                    <p class="title-eng EngTit CONTENT cs-fr">
                        CON<span>TENT</span></p>
                </h2>
            </div>
            <div class="About-Art">
                <h1>
                    <%=bean.fdSiInTitle%></h1>
                <div class="">
                    <%=bean.fdSiInContent %>
                </div>
                <div class="About-nav">
                    <a href="/s/1.aspx">关于华纺</a>|<a href="/s/2.aspx">联系华纺</a>|<a href="/s/3.aspx">隐私保护</a>|<a
                        href="/s/4.aspx">加入华纺</a>
                </div>
            </div>
        </div>
        <div class="g_192">
            <uc1:SideMenu runat="server" />
        </div>
    </div>
</asp:Content>
