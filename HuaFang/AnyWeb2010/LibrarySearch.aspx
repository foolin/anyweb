<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LibrarySearch.aspx.cs" Inherits="LibrarySearch" %>

<%@ Register Src="~/Controls/TagList.ascx" TagName="TagList" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Search.ascx" TagName="Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="product cs-clear">
        <uc1:TagList ID="TagList1" runat="server" />
        <uc1:Search ID="Search1" runat="server" />
    </div>
    <div class="StarList">
        <div class="title-bar">
            <h2 class="cs-clear">
                <p class="title-ch cs-fl">
                    <a href="/Index.aspx">首页</a>//<span><%=typeName %>搜索</span></p>
                <p class="title-eng cs-fr">
                    FILE<span>LIST</span></p>
            </h2>
        </div>
        <div class="List_order List_order2 List_order4 cs-clear">
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
                            <img src="<%#Eval("fdLibrPic") %>" width="110" /></a> <a href="/lc/<%#Eval("fdLibrID") %>.aspx"><%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdLibrEnName" ), 17 )%><br />
                                <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdLibrName" ), 9 )%></a>
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

