<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleList.ascx.cs" Inherits="Controls_ArticleList" %>
<div class="list">
    <asp:Repeater ID="repArticle" runat="server">
        <ItemTemplate>
            <dl>
                <dt><a href="Article.aspx?id=<%#Eval("ArtiID") %>" title="<%#Eval("ArtiTitle") %>">
                    <%#Studio.Web.WebAgent.GetLeft(Eval("ArtiTitle").ToString(),20) %></a></dt>
                <dd>
                    [<%#Eval("ArtiCreateAt","{0:yyyy-MM-dd}") %>]</dd>
            </dl>
        </ItemTemplate>
    </asp:Repeater>
</div>
