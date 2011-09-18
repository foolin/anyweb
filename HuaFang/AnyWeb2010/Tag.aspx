<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Tag.aspx.cs" Inherits="Tag" %>

<%@ Register Src="~/Controls/TagList.ascx" TagName="TagList" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/SideMenu.ascx" TagName="SideMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide1.ascx" TagName="LeftSide1" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide2.ascx" TagName="LeftSide2" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide3.ascx" TagName="LeftSide3" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="product cs-clear">
        <uc1:TagList ID="TagList1" runat="server" />
        <uc1:Search ID="Search1" runat="server" />
    </div>
    <div class="cs-group">
        <div class="g_760">
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <a href="/index.aspx">首页</a>//<span><%=tag.fdTagName %></span>
                    </p>
                    <p class="title-eng cs-fr">
                        SEAR<span>CH</span></p>
                </h2>
            </div>
            <div class="OtherHot" id="divSearch" runat="server">
                <div class="List_order List_order2 cs-clear">
                    <p class="List_order_tit cs-fl">
                        1-5项</p>
                    <div class="Pagination cs-fr">
                        <AW:Pager ID="PN1" runat="server" StyleID="7" PageSize="15">
                        </AW:Pager>
                    </div>
                </div>
                <asp:Repeater ID="rep1" runat="server">
                    <ItemTemplate>
                        <div class="OtherHot-item">
                            <div class="OtherHot_con cs-clear">
                                <a href="<%#Eval("fdArtiPath") %>" class="OtherHot_pic cs-fl">
                                    <img width="130" src="<%#Eval("fdArtiPic") %>"></a>
                                <div class="OtherHot_info2 cs-fr">
                                    <p>
                                        <%#Eval("fdArtiCreateAt","{0:yyyy-MM-dd}") %></p>
                                    <a class="OtherHot_tit" href="<%#Eval("fdArtiPath") %>">
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 120, false )%></a>
                                    <p class="Article">
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiDesc" ), 120, false )%></p>
                                    <div class="More cs-clear">
                                        <a class="cs-fr" href="<%#Eval("fdArtiPath") %>">查看全文</a></div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="List_order List_order2 List_order3" id="div1" runat="server">
                    <p class="List_order_tit">
                        6-10项</p>
                </div>
                <asp:Repeater ID="rep2" runat="server">
                    <ItemTemplate>
                        <div class="OtherHot-item">
                            <div class="OtherHot_con cs-clear">
                                <a href="<%#Eval("fdArtiPath") %>" class="OtherHot_pic cs-fl">
                                    <img width="130" src="<%#Eval("fdArtiPic") %>"></a>
                                <div class="OtherHot_info2 cs-fr">
                                    <p>
                                        <%#Eval("fdArtiCreateAt","{0:yyyy-MM-dd}") %></p>
                                    <a class="OtherHot_tit" href="<%#Eval("fdArtiPath") %>">
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 120, false )%></a>
                                    <p class="Article">
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiDesc" ), 120, false )%></p>
                                    <div class="More cs-clear">
                                        <a class="cs-fr" href="<%#Eval("fdArtiPath") %>">查看全文</a></div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="List_order List_order2 List_order3" id="div2" runat="server">
                    <p class="List_order_tit">
                        11-15项</p>
                </div>
                <asp:Repeater ID="rep3" runat="server">
                    <ItemTemplate>
                        <div class="OtherHot-item">
                            <div class="OtherHot_con cs-clear">
                                <a href="<%#Eval("fdArtiPath") %>" class="OtherHot_pic cs-fl">
                                    <img width="130" src="<%#Eval("fdArtiPic") %>"></a>
                                <div class="OtherHot_info2 cs-fr">
                                    <p>
                                        <%#Eval("fdArtiCreateAt","{0:yyyy-MM-dd}") %></p>
                                    <a class="OtherHot_tit" href="<%#Eval("fdArtiPath") %>">
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 120, false )%></a>
                                    <p class="Article">
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiDesc" ), 120, false )%></p>
                                    <div class="More cs-clear">
                                        <a class="cs-fr" href="<%#Eval("fdArtiPath") %>">查看全文</a></div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="OtherHot-pag">
                    <div class="Pagination cs-fr">
                        <AW:Pager ID="PN2" runat="server" StyleID="7" PageSize="15">
                        </AW:Pager>
                    </div>
                </div>
            </div>
            <div id="divNull" runat="server" visible="false">
                找不到符合条件的资讯！</div>
        </div>
        <div class="g_192">
            <uc1:SideMenu ID="SideMenu1" runat="server" />
            <uc1:LeftSide1 ID="LeftSide1" runat="server" />
            <uc1:LeftSide2 ID="LeftSide2" runat="server" />
            <uc1:LeftSide3 ID="LeftSide3" runat="server" />
        </div>
    </div>
</asp:Content>
