<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="column.aspx.cs" Inherits="column" %>

<%@ Register Src="Control/innermenu.ascx" TagName="menu" TagPrefix="uc1" %>
<%@ Register Src="~/Control/columntip.ascx" TagName="tip" TagPrefix="uc1" %>
<%@ Register Src="~/Control/rightclpt.ascx" TagName="clpt" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="lscon">
            <div class="lside column">
                <div class="crumb defColor">
                    <uc1:tip ID="tip1" runat="server" />
                </div>
                <div class="box678">
                    <div class="Lsbanner">
                        <%if (!string.IsNullOrEmpty(bean.fdColuPicture))
                          {%>
                        <img src="<%=bean.fdColuPicture %>" width="679" />
                        <%}
                          else if (bean.fdColuParentID != 0 && !string.IsNullOrEmpty(bean.Parent.fdColuPicture))
                          { %>
                        <img src="<%=bean.Parent.fdColuPicture %>" width="679" />
                        <%} %>
                    </div>
                    <div class="conBg">
                        <div class="content">
                            <div class="articleList">
                                <div class="blank5px">
                                </div>
                                <ul>
                                    <asp:Repeater ID="repArticle" runat="server">
                                        <ItemTemplate>
                                            <li><a href="article.aspx?id=<%#Eval("fdArtiID") %>">
                                                <%#Studio.Web.WebAgent.GetLeft((String)Eval("fdArtiTitle"),30,true) %></a> </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
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
                    <a href="article.aspx?id=1128" class="btn19H"><b>想了解更多？请联系我们</b></a>
                    <div class="blank12px">
                    </div>
                   <%-- <div class="moreList">
                        <div class="blank5px">
                        </div>
                        <dl>
                            <dt>
                                <%if (bean.fdColuParentID == 0)
                                  { %>
                                <%=bean.fdColuName%>
                                <%}
                                  else
                                  { %>
                                <%=bean.Parent.fdColuName%>
                                <%} %>
                            </dt>
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
                    </div>--%>
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
                    <uc1:clpt ID="clpt1" runat="server" />
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
