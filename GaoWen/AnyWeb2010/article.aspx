<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="article.aspx.cs" Inherits="article" %>

<%@ Register Src="Control/innermenu.ascx" TagName="menu" TagPrefix="uc1" %>
<%@ Register Src="~/Control/columntip.ascx" TagName="tip" TagPrefix="uc1" %>
<%@ Register Src="~/Control/rightclpt.ascx" TagName="clpt" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="public/js/fontZoom.js"></script>
    <script type="text/javascript">
        $(document).ready(function() {
        $.get("addclick.aspx?id=<%=bean.fdArtiID %>"); 
        });
    </script>

    <div class="pageTopMain">
        <uc1:menu ID="menu1" runat="server" />
        <div class="pageFocus">
            <%if (!string.IsNullOrEmpty(column.fdColuPicture))
              {%>
                <img src="<%=column.fdColuPicture %>" alt="高闻顾问" border="0" />
            <%} %>
        </div>
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
                                <li class="<%#(int)Eval("fdColuID")==column.fdColuID?"on":"" %>"><a href="column.aspx?id=<%#Eval("fdColuID") %>">
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
                    <a href="javascript:fontZoomMin()">小</a>] &nbsp;<a href="getpdf.aspx?id=<%=bean.fdArtiID %>" target="_blank"><img alt="PDF" src="Public/images/pdf.jpg" style=" border:0; padding-top:2px;" /></a>
                </div>
                <div class="article">
                    <div class="title">
                        <%=bean.fdArtiTitle %>
                    </div>
                    <div class="content" id="art-content">
                        <%=bean.fdArtiContent %>
                        <%if (bean.fdArtiID != 1065)
                          { %>
                        <div style="text-align: right">
                            <a href="article.aspx?id=1065">
                                <img src="public/images/more_contantUs.gif" border="0" width="150" height="24" alt="想了解更多吗？请联系我们" /></a>
                        </div>
                        <%} %>
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
                <uc1:clpt ID="clpt1" runat="server" />
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
