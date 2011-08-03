<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Column.aspx.cs" Inherits="Asp_Column" %>

<%@ Register Src="~/Controls/TagList.ascx" TagName="TagList" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/SideMenu.ascx" TagName="SideMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide1.ascx" TagName="LeftSide1" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide2.ascx" TagName="LeftSide2" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LeftSide3.ascx" TagName="LeftSide3" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="product cs-clear">
        <uc1:TagList runat="server" />
        <uc1:Search runat="server" />
    </div>
    <div class="cs-group">
        <div class="g_760">
            <div class="title-bar">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <AW:Position runat="server" SplitText="//">
                        </AW:Position>
                    </p>
                    <p class="title-eng cs-fr">
                        HOT<span>NEWS</span></p>
                </h2>
            </div>
            <div class="cs-section Column_sec1">
                <div class="g_360 cs-fl">
                    <asp:Repeater ID="rep1" runat="server">
                        <ItemTemplate>
                            <a href="<%#Eval("fdArtiPath") %>" class="PicBlack_mod">
                                <img src="<%#Eval("fdArtiPic") %>" />
                                <div class="PicBlack_tit">
                                    <h2>
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 28, false )%></h2>
                                    <p>
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiDesc" ), 30, false )%>
                                    </p>
                                    <span class="Pic_point"></span>
                                </div>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="g_360 cs-fr">
                    <div class="Hotnews_minor Hotnews_minor2">
                        <asp:Repeater ID="rep2" runat="server">
                            <ItemTemplate>
                                <div class="Minor-item Minor-item2 cs-clear">
                                    <a class="Minor-pic" href="<%#Eval("fdArtiPath") %>">
                                        <img class="nobor" src="<%#Eval("fdArtiPic") %>"></a>
                                    <div class="Minor-intro">
                                        <h2 class="Minor-tit">
                                            <a href="<%#Eval("fdArtiPath") %>">
                                                <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 10, false )%></a></h2>
                                        <p>
                                            <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiDesc" ), 120, false )%></p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="title-bar" id="divMore1" runat="server">
                <h2 class="cs-clear">
                    <p class="title-ch cs-fl">
                        <span>更多资讯</span></p>
                    <p class="title-eng cs-fr">
                        OTHER<span>NEWS</span></p>
                </h2>
            </div>
            <div class="OtherHot" id="divMore2" runat="server">
                <div class="List_order List_order2 cs-clear">
                    <p class="List_order_tit cs-fl">
                        1-5项</p>
                    <div class="Pagination cs-fr">
                        <AW:Pager ID="PN1" runat="server" StyleID="6" PageSize="15">
                        </AW:Pager>
                    </div>
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
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 30, false )%></a>
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
                <asp:Repeater ID="rep4" runat="server">
                    <ItemTemplate>
                        <div class="OtherHot-item">
                            <div class="OtherHot_con cs-clear">
                                <a href="<%#Eval("fdArtiPath") %>" class="OtherHot_pic cs-fl">
                                    <img width="130" src="<%#Eval("fdArtiPic") %>"></a>
                                <div class="OtherHot_info2 cs-fr">
                                    <p>
                                        <%#Eval("fdArtiCreateAt","{0:yyyy-MM-dd}") %></p>
                                    <a class="OtherHot_tit" href="<%#Eval("fdArtiPath") %>">
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 30, false )%></a>
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
                <asp:Repeater ID="rep5" runat="server">
                    <ItemTemplate>
                        <div class="OtherHot-item">
                            <div class="OtherHot_con cs-clear">
                                <a href="<%#Eval("fdArtiPath") %>" class="OtherHot_pic cs-fl">
                                    <img width="130" src="<%#Eval("fdArtiPic") %>"></a>
                                <div class="OtherHot_info2 cs-fr">
                                    <p>
                                        <%#Eval("fdArtiCreateAt","{0:yyyy-MM-dd}") %></p>
                                    <a class="OtherHot_tit" href="<%#Eval("fdArtiPath") %>">
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 30, false )%></a>
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
                        <AW:Pager ID="PN2" runat="server" StyleID="6" PageSize="15">
                        </AW:Pager>
                    </div>
                </div>
            </div>
        </div>
        <div class="g_192">
            <uc1:SideMenu ID="SideMenu1" runat="server" />
            <uc1:LeftSide1 ID="LeftSide1" runat="server" />
            <uc1:LeftSide2 ID="LeftSide2" runat="server" />
            <uc1:LeftSide3 ID="LeftSide3" runat="server" />
        </div>
    </div>
</asp:Content>
