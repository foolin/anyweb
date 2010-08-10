<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="article.aspx.cs" Inherits="article" %>
<%@ Register Src="~/Control/columntip.ascx" TagName="tip" TagPrefix="uc1" %>
<%@ Register Src="~/Control/rightclpt.ascx" TagName="clpt" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function() {
            $.get("addclick.aspx?id=<%=bean.fdArtiID %>");
        });
    </script>
    <div class="main">
        <div class="lscon">
            <div class="lside column">
                <div class="crumb defColor">
                    <uc1:tip ID="tip1" runat="server" />
                </div>
                <div class="box678">
                    <div class="Lsbanner">
                        <%if (!string.IsNullOrEmpty(column.fdColuPicture))
                          {%>
                            <img src="<%=column.fdColuPicture %>" width="679" />
                        <%}
                          else if (column.fdColuParentID != 0 && !string.IsNullOrEmpty(column.Parent.fdColuPicture))
                          { %>
                            <img src="<%=column.Parent.fdColuPicture %>" width="679" />
                        <%} %>
                    </div>
                    <div class="conBg">
                        <div class="content">
                            <div class="fontSize">
                                [ 字体：<a href="javascript:void(0);" onclick="changeFontSize(this,'f14');">大</a><a
                                    href="javascript:void(0);" onclick="changeFontSize(this,'f13');">中</a><a href="javascript:void(0);"
                                        onclick="changeFontSize(this,'f12');" class="cur">小</a> ]
                                <a href="getpdf.aspx?id=<%=bean.fdArtiID %>" target="_blank"><img src="public/images/icon_fontsize.gif" /></a>
                            </div>
                            <div id="ConDetail" class="ConDetail">
                                <%=bean.fdArtiContent %>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="moreAbout">
                    <%if (bean.fdArtiID != 1128)
                      { %>
                        <a href="article.aspx?id=1128" class="btn19H"><b>想了解更多？请联系我们</b></a>
                    <%} %>
                    <div class="blank12px">
                    </div>
                    <div class="moreList">
                        <div class="blank5px">
                        </div>
                        <dl>
                            <dt>
                                <%if (column.fdColuParentID == 0)
                                  { %>
                                    <%=column.fdColuName%>
                                <%}
                                  else
                                  { %>
                                    <%=column.Parent.fdColuName%>
                                <%} %>
                            </dt>
                            <asp:Repeater ID="repColumn" runat="server">
                                <ItemTemplate>
                                    <dd>
                                        <a href="column.aspx?id=<%#Eval("fdColuID") %>"><%#Eval("fdColuName")%></a></dd>
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

