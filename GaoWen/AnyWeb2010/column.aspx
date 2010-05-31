<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="column.aspx.cs" Inherits="column" %>

<%@ Register Src="Control/innermenu.ascx" TagName="menu" TagPrefix="uc1" %>
<%@ Register Src="~/Control/columntip.ascx" TagName="tip" TagPrefix="uc1" %>
<%@ Register Src="~/Control/columnskin1.ascx" TagName="skin1" TagPrefix="uc1" %>
<%@ Register Src="~/Control/columnskin2.ascx" TagName="skin2" TagPrefix="uc1" %>
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
                                <li><a href="column.aspx?id=<%#Eval("fdColuID") %>" class="<%#(int)Eval("fdColuID")==bean.fdColuID?"serviceSelected":"" %>">
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
                    <%if (getSkin(bean) == 1)
                      { %>
                    <uc1:skin1 ID="skin1" runat="server" />
                    <%}
                      else
                      {%>
                    <uc1:skin2 ID="skin2" runat="server" />
                    <%} %>
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
                        <asp:Repeater ID="repRelation" runat="server">
                            <ItemTemplate>
                                <li><a href="<%#Eval("fdRelaLink") %>">
                                    <%#Eval("fdRelaTitle")%></a></li>
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
