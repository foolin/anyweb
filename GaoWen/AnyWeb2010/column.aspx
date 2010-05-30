<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="column.aspx.cs" Inherits="column" %>

<%@ Register Src="Control/innermenu.ascx" TagName="menu" TagPrefix="uc1" %>
<%@ Register Src="~/Control/columntip.ascx" TagName="tip" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pageTopMain">
        <uc1:menu ID="menu1" runat="server" />
        <div class="pageFocus">
            <%if (!string.IsNullOrEmpty(bean.fdColuPicture))
              {%>
            <a href="#">
                <img src="<%=bean.fdColuPicture %>" alt="焦点图片" border="0" /></a>
            <%} %>
        </div>
        <!-- end pageTopMain -->
    </div>
    <div class="pageMidMain">
        <div class="pageColSiderA">
            <div class="service">
                <div class="serviceTitle">
                    <%if (bean.fdColuParentID == 0)
                      { %>
                    <img src="public/images/<%=bean.fdColuID %>.jpg" border="0" alt="" />
                    <%}
                      else
                      { %>
                    <img src="public/images/<%=bean.Parent.fdColuID %>.jpg" border="0" alt="" />
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
                <div class="article">
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
