<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="terms-conditions-chs.aspx.cs" Inherits="terms_conditions_chs" %>

<%@ Register Src="~/Control/footer.ascx" TagName="footer" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="lscon">
            <div class="lside column">
                <div class="crumb defColor">
                    <a href="index.aspx">首页</a> - 条款及条件
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
                                <a href="getpdf.aspx?id=TKJTJ" target="_blank">
                                    <img src="public/images/icon_fontsize.gif" /></a>
                            </div>
                            <div id="ConDetail" class="ConDetail">
                                <asp:Literal ID="lit" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="moreAbout">
                    <a href="article.aspx?id=1128" class="btn19H"><b>想了解更多？请联系我们</b></a>
                    <div class="blank12px">
                    </div>
                    <div class="moreList">
                        <div class="blank5px">
                        </div>
                        <uc1:footer ID="Footer1" runat="server" />
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
                    <div class="related">
                        <ul>
                        </ul>
                    </div>
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
