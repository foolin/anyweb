<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleList.ascx.cs" Inherits="Controls_ArticleList" %>
<div class="box-title">
    <span class="titletxt">--== <asp:Literal ID="litTitle" runat="server"></asp:Literal> ==--</span><span class="more"><a href="Column.aspx?id=<%=ColumnID %>">更多>></a></span></div>
<div class="box-content">
    <table>
        <asp:Repeater ID="repArticle" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <a href="Article.aspx?id=<%#Eval("ArtiID") %>" title="<%#Eval("ArtiTitle") %>"><%#Studio.Web.WebAgent.GetLeft(Eval("ArtiTitle").ToString(),20) %></a></td>
                    <td class="time">
                        <%#Eval("ArtiCreateAt","{0:yyyy-MM-dd}") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</div>
