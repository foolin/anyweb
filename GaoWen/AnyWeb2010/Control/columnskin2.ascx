<%@ Control Language="C#" AutoEventWireup="true" CodeFile="columnskin2.ascx.cs" Inherits="Control_columnskin2" %>
<div class="title">
    <img src="public/images/list_title.gif" width="132" height="28" /></div>
<div class="list">
    <asp:Repeater ID="repArticle" runat="server">
        <ItemTemplate>
            <dl>
                <dt><a href="article.aspx?id=<%#Eval("fdArtiID") %>">
                    <%#Eval("fdArtiTitle") %></a></dt>
                <dd>
                    <%#Studio.Web.WebAgent.GetLeft(Studio.Web.WebAgent.GetText((string)Eval("fdArtiContent")),18) %>
                </dd>
            </dl>
        </ItemTemplate>
    </asp:Repeater>
    <div class="clear">
    </div>
</div>
<div class="page">
    <sw:PageNaver ID="PN1" runat="server" StyleID="4" PageSize="9">
    </sw:PageNaver>
</div>
