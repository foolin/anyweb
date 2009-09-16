<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ColumnArticle.ascx.cs"
    Inherits="Controls_ColumnArticle" %>
    <%@ Register TagPrefix="cc1" Namespace="Studio.Web" Assembly="Studio" %>
<div class="box-title">
    <span class="titletxt">--==
        <asp:Literal ID="litTitle" runat="server"></asp:Literal>
        ==--</span></div>
<div class="box-content">
    <table>
        <asp:Repeater ID="repArticle" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <a href="article.aspx?id=<%#Eval("ArtiID") %>" title="<%#Eval("ArtiTitle") %>"><%#Studio.Web.WebAgent.GetLeft(Eval("ArtiTitle").ToString(),20) %></a></td>
                    <td style="width:120px; color:Gray;">
                        <%#Eval("ArtiCreateAt","{0:yyyy-MM-dd HH:mm}") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="pagebar">
        <cc1:PageNaver ID="PN1" runat="server" StyleID="1"></cc1:PageNaver>
    </div>
</div>
