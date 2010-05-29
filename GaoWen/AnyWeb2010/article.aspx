<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="article.aspx.cs" Inherits="article" %>

<%@ Register Src="Control/innermenu.ascx" TagName="menu" TagPrefix="uc1" %>
<%@ Register Src="~/Control/columntip.ascx" TagName="tip" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                    [字体：<a href="#">大</a> <a href="#">中</a> <a href="#">小</a> ]
                </div>
                <div class="article">
                    <div class="title">
                        <%=bean.fdArtiTitle %>
                    </div>
                    <div class="content">
                        <%=bean.fdArtiContent %>
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
                                    <li><a href="<%#Eval("fdRelaLink") %>"><%#Eval("fdRelaTitle")%></a></li>
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
