<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="LibraryList.aspx.cs" Inherits="LibraryList" %>

<%@ Register Src="~/Controls/TagList.ascx" TagName="TagList" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="product cs-clear">
        <uc1:TagList runat="server" />
        <uc1:Search runat="server" />
    </div>
    <div class="StarList">
        <div class="title-bar">
            <h2 class="cs-clear">
                <p class="title-ch cs-fl">
                    <a href="/Index.aspx">首页</a>//<span><%=typeName %></span></p>
                <p class="title-eng EngTit FILELIST cs-fr">
                    FILE<span>LIST</span></p>
            </h2>
        </div>
        <div class="Page_btm cs-clear">
            <div class="PageSet cs-fr">
                <a href="/l/<%=type %>.aspx" <%=cate==0?"class=\"on\"":"" %>>A</a> <a href="/l/<%=type %>.aspx?c=1"
                    <%=cate==1?"class=\"on\"":"" %>>B</a> <a href="/l/<%=type %>.aspx?c=2" <%=cate==2?"class=\"on\"":"" %>>
                        C</a> <a href="/l/<%=type %>.aspx?c=3" <%=cate==3?"class=\"on\"":"" %>>D</a>
                <a href="/l/<%=type %>.aspx?c=4" <%=cate==4?"class=\"on\"":"" %>>E</a> <a href="/l/<%=type %>.aspx?c=5"
                    <%=cate==5?"class=\"on\"":"" %>>F</a> <a href="/l/<%=type %>.aspx?c=6" <%=cate==6?"class=\"on\"":"" %>>
                        G</a> <a href="/l/<%=type %>.aspx?c=7" <%=cate==7?"class=\"on\"":"" %>>H</a>
                <a href="/l/<%=type %>.aspx?c=8" <%=cate==8?"class=\"on\"":"" %>>I</a> <a href="/l/<%=type %>.aspx?c=9"
                    <%=cate==9?"class=\"on\"":"" %>>J</a> <a href="/l/<%=type %>.aspx?c=10" <%=cate==10?"class=\"on\"":"" %>>
                        K</a> <a href="/l/<%=type %>.aspx?c=11" <%=cate==11?"class=\"on\"":"" %>>L</a>
                <a href="/l/<%=type %>.aspx?c=12" <%=cate==12?"class=\"on\"":"" %>>M</a> <a href="/l/<%=type %>.aspx?c=13"
                    <%=cate==13?"class=\"on\"":"" %>>N</a> <a href="/l/<%=type %>.aspx?c=14" <%=cate==14?"class=\"on\"":"" %>>
                        O</a> <a href="/l/<%=type %>.aspx?c=15" <%=cate==15?"class=\"on\"":"" %>>P</a>
                <a href="/l/<%=type %>.aspx?c=16" <%=cate==16?"class=\"on\"":"" %>>Q</a> <a href="/l/<%=type %>.aspx?c=17"
                    <%=cate==17?"class=\"on\"":"" %>>R</a> <a href="/l/<%=type %>.aspx?c=18" <%=cate==18?"class=\"on\"":"" %>>
                        S</a> <a href="/l/<%=type %>.aspx?c=19" <%=cate==19?"class=\"on\"":"" %>>T</a>
                <a href="/l/<%=type %>.aspx?c=20" <%=cate==20?"class=\"on\"":"" %>>U</a> <a href="/l/<%=type %>.aspx?c=21"
                    <%=cate==21?"class=\"on\"":"" %>>V</a> <a href="/l/<%=type %>.aspx?c=22" <%=cate==22?"class=\"on\"":"" %>>
                        W</a> <a href="/l/<%=type %>.aspx?c=23" <%=cate==23?"class=\"on\"":"" %>>X</a>
                <a href="/l/<%=type %>.aspx?c=24" <%=cate==24?"class=\"on\"":"" %>>Y</a> <a href="/l/<%=type %>.aspx?c=25"
                    <%=cate==25?"class=\"on\"":"" %>>Z</a> <a href="/l/<%=type %>.aspx?c=26" class="PageSet-ch <%=cate==26?"on":"" %>">
                        其他</a> <span class="Pagination_sort">/</span> <span class="Pagination_sort">排序：</span>
                <a href="?c=<%=cate %>" class="<%=sort==0?"on":"" %>">字母</a> <a href="?c=<%=cate %>&s=1"
                    class="<%=sort==1?"on":"" %>">拼音</a>
            </div>
        </div>
        <div class="List_order List_order2 List_order4 cs-clear">
            <p class="List_order_tit List_order_tit2 cs-fl">
                <%=cateName%></p>
            <div class="Pagination cs-fr">
                <AW:Pager ID="PN1" runat="server" StyleID="7" PageSize="28">
                </AW:Pager>
            </div>
        </div>
        <div class="Pic_list cs-clear">
            <asp:Repeater ID="rep" runat="server">
                <ItemTemplate>
                    <div class="Star_picitem">
                        <a href="/lc/<%#Eval("fdLibrID") %>.aspx">
                            <img src="<%#Eval("fdLibrPic") %>" width="110" /></a> <strong><a href="/lc/<%#Eval("fdLibrID") %>.aspx">
                                <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdLibrEnName" ), 17 )%><br />
                                <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdLibrName" ), 9 )%></a></strong>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="PageTurning cs-clear">
            <div class="Pagination cs-fr">
                <AW:Pager ID="PN2" runat="server" StyleID="7" PageSize="28">
                </AW:Pager>
            </div>
        </div>
    </div>
</asp:Content>
