<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="search.aspx.cs" Inherits="search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="lscon">
            <div class="lside column">
                <div class="crumb defColor">
                    <a href="index.aspx">首页</a> - 搜索
                </div>
                <div class="box678">
                    <div class="Lsbanner">
                        <img src="public/images/page_banner.jpg" width="679" />
                    </div>
                    <div class="conBg">
                        <div class="content">
                            <div class="articleList">
                                <div class="blank5px">
                                </div>
                                <ul>
                                    <asp:Repeater ID="repArticle" runat="server">
                                        <ItemTemplate>
                                            <li><a href="article.aspx?id=<%#Eval("fdArtiID") %>" target="_blank">
                                                <%#Eval("fdArtiTitle") %></a> </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <asp:Literal ID="litNull" runat="server"></asp:Literal>
                                </ul>
                                <div class="page">
                                    <sw:PageNaver ID="PN1" runat="server" StyleID="4" PageSize="9">
                                    </sw:PageNaver>
                                </div>
                                <div class="blank5px">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="moreAbout">
                    <a href="article.aspx?id=1065" class="btn19H"><b>想了解更多？请联系我们</b></a>
                    <div class="blank12px">
                    </div>
                    <div class="moreList">
                        <div class="blank5px">
                        </div>
                        <dl>
                            <dt>高闻顾问 </dt>
                            <asp:Repeater ID="repColumn" runat="server">
                                <ItemTemplate>
                                    <dd>
                                        <a href="column.aspx?id=<%#Eval("fdColuID") %>">
                                            <%#Eval("fdColuName")%></a></dd>
                                </ItemTemplate>
                            </asp:Repeater>
                        </dl>
                        <div class="blank5px">
                        </div>
                    </div>
                </div>
            </div>
            <div class="rside column">
                <div class="topBg">
                </div>
                <div class="box276">
                    <div class="Rsbanner">
                        <img src="public/images/img_related.jpg" width="276" height="145" />
                    </div>
                    <div class="arrow">
                        <img src="public/images/icon_arrow.gif" /></div>
                </div>
            </div>
        </div>
        <div class="mainBtm">
            <div class="lsBtm">
            </div>
            <div class="rsBtm">
            </div>
        </div>
    </div>
</asp:Content>
