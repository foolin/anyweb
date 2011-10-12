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
                    <a href="/Index.aspx">首页</a>
                    <%if( library.fdLibrType == 2 )
                      { %>
                    /<a href="/l/<%=library.fdLibrType %>.aspx"><%=typeName %></a>
                    <%} %>
                    /<span><%=library.fdLibrName %>(<%=library.fdLibrEnName %>)</span></p>
                <p class="title-eng EngTit CONTENT cs-fr">
                    CON<span>TENT</span></p>
            </h2>
        </div>
        <div class="g_360 cs-fl">
            <img src="<%=library.fdLibrPic %>" width="358" />
            <div class="Star-post cs-clear">
                <%if( preLibrary != null )
                  {%>
                <div class="Star-postL cs-fl">
                    <a href="/lc/<%=preLibrary.fdLibrID %>.aspx" title="<%=preLibrary.fdLibrEnName %>">
                        <%=Studio.Web.WebAgent.GetLeft( preLibrary.fdLibrEnName, 25 )%></a> <a href="/lc/<%=preLibrary.fdLibrID %>.aspx"
                            title="<%=preLibrary.fdLibrName %>">
                            <%=Studio.Web.WebAgent.GetLeft( preLibrary.fdLibrName, 12 )%></a>
                </div>
                <%} %>
                <%if( nextLibrary != null )
                  {%>
                <div class="Star-postR cs-fr">
                    <a href="/lc/<%=nextLibrary.fdLibrID %>.aspx" title="<%=nextLibrary.fdLibrEnName %>">
                        <%=Studio.Web.WebAgent.GetLeft( nextLibrary.fdLibrEnName, 25 )%></a> <a href="/lc/<%=nextLibrary.fdLibrID %>.aspx"
                            title="<%=nextLibrary.fdLibrName %>">
                            <%=Studio.Web.WebAgent.GetLeft( nextLibrary.fdLibrName, 12 )%></a>
                </div>
                <%} %>
            </div>
        </div>
        <div class="g_580">
            <div class="title-sub title-sub2">
                <p class="cs-fl">
                    <%=library.fdLibrName %>(<%=library.fdLibrEnName %>) 资讯</p>
            </div>
            <div class="OtherHot OtherHot-js">
                <asp:Repeater ID="rep" runat="server">
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
                                    <img src="<%#Eval("fdLibrPic") %>" width="110" /></a> <strong><a href="/lc/<%#Eval("fdLibrID") %>.aspx">
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdLibrEnName" ), 16 )%><br />
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdLibrName" ), 9 )%></a></strong>
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
                    <%=library.fdLibrName %>(<%=library.fdLibrEnName %>)的图片</p>
            </div>
            <div class="Featured Featured2">
                <div class="Featured-com2 cs-clear">
                    <asp:Repeater ID="repPic" runat="server">
                        <ItemTemplate>
                            <div class="Featured-item">
                                <a href="<%#Eval("fdArtiPath") %>" target="_blank" title="<%#Eval("fdArtiTitle") %>">
                                    <img src="<%#Eval("fdArtiPic") %>" width="160" /></a></div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
