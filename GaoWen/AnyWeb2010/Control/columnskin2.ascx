<%@ Control Language="C#" AutoEventWireup="true" CodeFile="columnskin2.ascx.cs" Inherits="Control_columnskin2" %>
<div class="title">
    <img src="public/images/list_title.gif" width="132" height="28" /></div>
<div class="list">
    <ul>
    <asp:Repeater ID="repArticle" runat="server">
        <ItemTemplate>
            <li> <a href="article.aspx?id=<%#Eval("fdArtiID") %>"><%#Eval("fdArtiTitle") %></a> (<%#Eval("fdArtiCreateAt","{0:yyyy-MM-dd}") %>) </li>
        </ItemTemplate>
    </asp:Repeater>
    </ul>
</div>
<div class="page">
    <sw:PageNaver ID="PN1" runat="server" StyleID="4" PageSize="12">
    </sw:PageNaver>
</div>

