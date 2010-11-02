<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Column.aspx.cs" Inherits="AnyWell_Column" %>

<%@ Register Src="Control/Sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="comPage">
        <div class="ls">
            <div class="lsBox">
                <uc1:Sidebar ID="Sidebar1" runat="server" />
            </div>
            <div class="blank10px">
            </div>
            <div class="listCon">
                <div class="dTit">
                    热门文章</div>
                <div class="dCon gray">
                    <div class="blank12px">
                    </div>
                    <ul>
                        <aw:ArticleList ID="ArticleList1" ColumnID="-1" runat="server" TopCount="13" Order="fdArtiClick DESC,fdArtiID DESC">
                            <ItemTemplate>
                                <li>• <a href="/a/<%#Eval("fdArtiID") %>.aspx" title="<%#Eval("fdArtiTitle") %>">
                                    <%#Eval("fdArtiTitle") %></a></li>
                            </ItemTemplate>
                        </aw:ArticleList>
                    </ul>
                </div>
            </div>
        </div>
        <div class="content">
            <div class="tit gray">
                <a href="/Index.aspx">首页</a>
                <aw:Column runat="server" ItemType="Parent">
                    <ItemTemplate>
                        > <a href="/c/<%#Eval("fdColuID") %>.aspx">
                            <%#Eval( "fdColuName" )%></a></ItemTemplate>
                </aw:Column>
                <span class="green">
                    <aw:Column runat="server" ItemType="Current">
                        <ItemTemplate>
                            >
                            <%#Eval("fdColuName") %></ItemTemplate>
                    </aw:Column>
                </span>
            </div>
            <div class="innerPad">
                <div class="blank20px">
                </div>
                <div class="comhead">
                    文章列表</div>
                <div class="flowhidden" style="padding: 0px 20px;">
                    <div class="blank15px">
                    </div>
                    <ul class="comList gray">
                        <aw:ArticleList runat="server" PagerID="PN1" GetChild="true">
                            <ItemTemplate>
                                <li><span class="date">
                                    <%#Eval("fdArtiCreateAt","{0:yyyy-MM-dd HH:mm}") %></span><a href="/a/<%#Eval("fdArtiID") %>.aspx"><%#Studio.Web.WebAgent.GetLeft((string)Eval("fdArtiTitle"),43,true) %></a></li>
                            </ItemTemplate>
                        </aw:ArticleList>
                    </ul>
                </div>
                <div class="pageStyle tr">
                    <aw:Pager ID="PN1" runat="server" StyleID="5" PageSize="20">
                    </aw:Pager>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
