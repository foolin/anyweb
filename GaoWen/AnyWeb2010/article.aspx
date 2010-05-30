﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="article.aspx.cs" Inherits="article" %>

<%@ Register Src="Control/innermenu.ascx" TagName="menu" TagPrefix="uc1" %>
<%@ Register Src="~/Control/columntip.ascx" TagName="tip" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="public/js/fontZoom.js"></script>

    <div class="pageTopMain">
        <uc1:menu ID="menu1" runat="server" />
        <div class="pageFocus">
            <%if (!string.IsNullOrEmpty(column.fdColuPicture))
              {%>
            <a href="#">
                <img src="<%=column.fdColuPicture %>" alt="焦点图片" border="0" /></a>
            <%} %>
        </div>
        <!-- end pageTopMain -->
    </div>
    <div class="pageMidMain">
        <div class="pageColSiderA">
            <div class="service">
                <div class="serviceTitle">
                    <%if (column.fdColuParentID == 0)
                      { %>
                    <img src="public/images/<%=column.fdColuID %>.jpg" border="0" alt="" />
                    <%}
                      else
                      { %>
                    <img src="public/images/<%=column.Parent.fdColuID %>.jpg" border="0" alt="" />
                    <%} %>
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
                    <uc1:tip ID="tip1" runat="server" />
                </div>
                <div class="articleFontSize">
                    [字体：<a href="javascript:fontZoomMax()">大</a> <a href="javascript:fontZoomMid(12)">中</a>
                    <a href="javascript:fontZoomMin()">小</a>] &nbsp;[<a href="javascript:window.print()">打印</a>]
                    &nbsp;[<a href="javascript:window.close()">关闭</a>]
                </div>
                <div class="article">
                    <div class="title">
                        <%=bean.fdArtiTitle %>
                    </div>
                    <div class="content" id="art-content">
                        <%=bean.fdArtiContent %>
                        <div style="text-align: right">
                            <a href="#more">
                                <img src="public/images/more_contantUs.gif" border="0" width="150" height="24" alt="想了解更多吗？请联系我们" /></a>
                        </div>
                    </div>
                    <div class="preNextLink">
                        <%if (preArticle != null)
                          { %>
                        <span>上一篇：<a href="article.aspx?id=<%=preArticle.fdArtiID %>"><%=preArticle.fdArtiTitle%></a></span>
                        <%} %>
                        <%if (nextArticle != null)
                          { %>
                        <span>下一篇：<a href="article.aspx?id=<%=nextArticle.fdArtiID %>"><%=nextArticle.fdArtiTitle%></a></span>
                        <%} %>
                    </div>
                </div>
            </div>
        </div>
        <div class="pageColSiderB">
            <div class="colBox">
                <div class="colTitle">
                </div>
                <div class="colContent">
                    <div class="text">
                        <ul>
                            <asp:Repeater ID="repRelation" runat="server">
                                <ItemTemplate>
                                    <li><a href="<%#Eval("fdRelaLink") %>">
                                        <%#Eval("fdRelaTitle")%></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <div class="colButtomCorner">
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>