<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Library.aspx.cs" Inherits="Library" %>

<%@ Register Src="~/Controls/TagList.ascx" TagName="TagList" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="product cs-clear">
        <uc1:TagList runat="server" />
        <uc1:Search runat="server" />
    </div>
    <div class="cs-group product_main">
        <div class="title-bar">
            <h2 class="cs-clear">
                <p class="title-ch cs-fl">
                    <a href="/Index.aspx">首页</a>/<a href="/l/<%=library.fdLibrType %>.aspx"><%=typeName %></a>/<span><%=library.fdLibrName %></span></p>
                <p class="title-eng cs-fr">
                    CON<span>TENT</span></p>
            </h2>
        </div>
        <div class="g_360 cs-fl">
            <asp:Repeater ID="rep1" runat="server">
                <ItemTemplate>
                    <a href="<%#Eval("fdArtiPath") %>" class="nobor" target="_blank">
                        <img src="<%#Eval("fdArtiPic") %>" width="358" /></a>
                </ItemTemplate>
            </asp:Repeater>
            <div class="Star-post cs-clear">
                <asp:Repeater ID="rep2" runat="server">
                    <ItemTemplate>
                        <div class="Star-postL <%#Container.ItemIndex==0?"cs-fl":"cs-fr" %>">
                            <a href="<%#Eval("fdArtiPath") %>" title="<%#Eval("fdLibrEnName") %>" target="_blank">
                                <%#Studio.Web.WebAgent.GetLeft((string)Eval("fdLibrEnName"),25) %></a> <a href="<%#Eval("fdArtiPath") %>"
                                    title="<%#Eval("fdLibrName") %>" target="_blank">
                                    <%#Studio.Web.WebAgent.GetLeft((string)Eval("fdLibrName"),12) %></a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="g_580">
            <div class="title-sub title-sub2">
                <p class="cs-fl">
                    <%=library.fdLibrName %>
                    资讯</p>
                <a href="#" class="tit_more cs-fr">更多</a></div>
            <div class="OtherHot OtherHot-js">
                <asp:Repeater ID="rep3" runat="server">
                    <ItemTemplate>
                        <div class="OtherHot-item <%#Container.ItemIndex==0?"OtherHot-yes":"" %>">
                            <div class="OtherHot_list">
                                <span>
                                    <%#Eval("fdArtiCreateAt","{0:yyyy-MM-dd}") %>
                                    /</span><%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 36, false )%></div>
                            <div class="OtherHot_con cs-clear">
                                <a href="<%#Eval("fdArtiPath") %>" target="_blank" class="OtherHot_pic cs-fl">
                                    <img width="130" src="<%#Eval("fdArtiPic") %>"></a>
                                <div class="OtherHot_info cs-fr">
                                    <p>
                                        <%#Eval( "fdArtiCreateAt", "{0:yyyy.MM.dd}" )%></p>
                                    <a class="OtherHot_tit" href="<%#Eval("fdArtiPath") %>" target="_blank" title="<%#Eval( "fdArtiTitle" ) %>">
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 16, false )%></a>
                                    <p class="Article">
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiDesc" ), 230, false )%></p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div class="Star_name">
        <h1>
            <%=library.fdLibrEnName %></h1>
        <h1>
            <%=library.fdLibrName %></h1>
    </div>
    <div class="cs-group">
        <div class="g_360 cs-fl">
            <div class="title-sub title-sub2">
                <p class="cs-fl">
                    相关<%=typeShortName%></p>
            </div>
            <div class="Pic_360">
                <div class="Pic_list2 cs-clear">
                    <asp:Repeater ID="repRelated" runat="server">
                        <ItemTemplate>
                            <div class="Star_picitem">
                                <a href="/lc/<%#Eval("fdLibrID") %>.aspx">
                                    <img src="<%#Eval("fdLibrPic") %>" width="110" /></a> <a href="/lc/<%#Eval("fdLibrID") %>.aspx">
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdLibrEnName" ), 16 )%><br />
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdLibrName" ), 9 )%></a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="Star_article">
                <h2>
                    <strong>
                        <%=library.fdLibrName %>小档案</strong></h2>
                <%=library.fdLibrDesc %>
            </div>
        </div>
        <div class="g_580">
            <div class="title-sub title-sub2">
                <p class="cs-fl">
                    <%=library.fdLibrName %>的图片</p>
            </div>
            <div class="Featured Featured2">
                <div class="Featured-com2 cs-clear">
                    <asp:Repeater ID="repPic" runat="server">
                        <ItemTemplate>
                            <div class="Featured-item">
                                <a href="<%#Eval("fdArtiPath") %>" target="_blank">
                                    <img src="<%#Eval("fdArtiPic") %>" width="160" /></a></div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
