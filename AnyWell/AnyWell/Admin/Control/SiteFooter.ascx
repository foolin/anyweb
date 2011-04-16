<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SiteFooter.ascx.cs" Inherits="Admin_Control_SiteFooter" %>
<div class="guaid">
    <div>
        <ul>
            <li id="Article"><a href="SiteArticleList.aspx?id=<%=CurrentSite.fdSiteID %>">文档</a></li>
            <li id="Column"><a href="SiteMain.aspx?id=<%=CurrentSite.fdSiteID %>">栏目</a></li>
            <li id="Search"><a href="SiteArticleSearch.aspx?id=<%=CurrentSite.fdSiteID %>">搜索</a></li>
            <li id="Recycle"><a href="SiteArticleRecycleList.aspx?id=<%=CurrentSite.fdSiteID %>">回收站</a></li>
            <li id="Template"><a href="TemplateList.aspx?id=<%=CurrentSite.fdSiteID %>">模板</a></li>
        </ul>
    </div>
</div>
