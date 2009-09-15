<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HotList.ascx.cs" Inherits="Controls_HotList" %>
<div class="boxA">
    <div class="box-title">
        <span class="titletxt">--== 热门文章 ==--</span></div>
    <div class="box-content">
        <ul>
            <asp:Repeater ID="repHot" runat="server">
                <ItemTemplate>
                    <li><a href="article.aspx?id=<%#Eval("ArtiID") %>" title="<%#Eval("ArtiTitle") %>"><%#Studio.Web.WebAgent.GetLeft(Eval("ArtiTitle").ToString(),20) %></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
