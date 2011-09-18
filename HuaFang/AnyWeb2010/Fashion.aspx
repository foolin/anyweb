<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Fashion.aspx.cs" Inherits="Fashion" %>

<%@ Register Src="~/Controls/TagList.ascx" TagName="TagList" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/FashionLeftSide.ascx" TagName="FashionLeftSide" TagPrefix="uc1" %>
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
                        <a href="/Index.aspx">首页</a>//<span>秀场直击</span></p>
                    <div class="Pagination cs-fr">
                        <AW:Pager ID="PN1" runat="server" StyleID="7" PageSize="24">
                        </AW:Pager>
                    </div>
                </h2>
            </div>
            <div class="Piclist_outline">
                <div class="Pic_list cs-clear">
                    <asp:Repeater ID="rep" runat="server">
                        <ItemTemplate>
                            <div class="Show_picitem">
                                <a href="<%#Eval("fdArtiPath") %>" target="_blank">
                                    <img width="95" height="150" src="<%#Eval("fdArtiPic") %>"></a>
                                <div class="Show_intro Show_introbor">
                                    <strong><a href="<%#Eval("fdArtiPath") %>" target="_blank">
                                        <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 15, false )%></a></strong></div>
                                <div class="Show_intro">
                                    <p>
                                        <%#Eval("Column.fdColuName") %></p>
                                    <p>
                                        <%#Eval( "fdArtiCategoryName" )%>
                                    </p>
                                    <p>
                                        <%#Eval( "fdArtiCityName" )%></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="title-bar title-bar_bottom">
                <h2 class="cs-clear">
                    <div class="Pagination cs-fr">
                        <AW:Pager ID="PN2" runat="server" StyleID="7" PageSize="24">
                        </AW:Pager>
                    </div>
                </h2>
            </div>
        </div>
        <div class="g_192">
            <uc1:FashionLeftSide runat="server" />
            <uc1:LeftSide1 runat="server" />
            <uc1:LeftSide2 runat="server" />
            <uc1:LeftSide3 runat="server" />
        </div>
    </div>
</asp:Content>
