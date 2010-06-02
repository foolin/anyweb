<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="search.aspx.cs" Inherits="search" %>

<%@ Register Src="Control/innermenu.ascx" TagName="menu" TagPrefix="uc1" %>
<%@ Register Src="~/Control/columnskin2.ascx" TagName="skin2" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pageTopMain">
        <uc1:menu ID="menu1" runat="server" />
        <div class="pageFocus">
            <img src="public/images/page_banner.jpg" alt="焦点图片" border="0" />
        </div>
    </div>
    <div class="pageMidMain">
        <div class="pageColSiderA">
            <div class="service">
                <div class="serviceTitle">
                    <img src="public/images/contact.jpg" border="0" alt="" />
                </div>
                <div class="serviceNav">
                    <ul>
                        <asp:Repeater ID="repColumn" runat="server">
                            <ItemTemplate>
                                <li><a href="column.aspx?id=<%#Eval("fdColuID") %>">
                                    <%#Eval("fdColuName")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
        <div class="pageColMain">
            <div class="pageColMainContent">
                <div class="navigation">
                    <a href="index.aspx">首页</a>→ 搜索
                </div>
                <div class="article">
                    <div class="innersearch">
                        <form action="search.aspx" id="searchForm" method="post">
                        <input type="text" name="keyword" id="keyword" class="searchInput" value="<%=Request.Form["keyword"] %>" />
                        <input type="submit" value="搜索" class="searchBtn" />
                        </form>
                    </div>
                    <div class="list">
                        <ul>
                            <asp:Repeater ID="repArticle" runat="server">
                                <ItemTemplate>
                                    <li><a href="article.aspx?id=<%#Eval("fdArtiID") %>">
                                        <%#Eval("fdArtiTitle") %></a> (<%#Eval("fdArtiCreateAt","{0:yyyy-MM-dd}") %>)
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <asp:Literal ID="litNull" runat="server"></asp:Literal>
                    </div>
                    <div class="page">
                        <sw:PageNaver ID="PN1" runat="server" StyleID="4" PageSize="9">
                        </sw:PageNaver>
                    </div>
                </div>
            </div>
        </div>
        <div class="pageColSiderB">
            <div class="colBox">
                <div class="titleClpt">
                </div>
                <div class="colContent">
                    <div style="text-align: center">
                        <img src="public/images/clpt.jpg" border="0" width="146" height="90" />
                    </div>
                    <ul>
                        <asp:Repeater ID="repHot" runat="server">
                            <ItemTemplate>
                                <li><a href="article.aspx?id=<%#Eval("fdArtiID") %>">
                                    <%#Eval("fdArtiTitle")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="colButtomCorner">
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
