<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Article.aspx.cs" Inherits="AnyWell_Article" %>

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
                        <aw:ArticleList ColumnID="-1" runat="server" TopCount="13" Order="fdArtiClick DESC,fdArtiID DESC">
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
                <aw:Column runat="server" ItemType="Parent" FromArticle="true">
                    <ItemTemplate>
                        > <a href="/c/<%#Eval("fdColuID") %>.aspx">
                            <%#Eval( "fdColuName" )%></a></ItemTemplate>
                </aw:Column>
                <aw:Column runat="server" FromArticle="true">
                    <ItemTemplate>
                        > <a href="/c/<%#Eval("fdColuID") %>.aspx">
                            <%#Eval( "fdColuName" )%></a></ItemTemplate>
                </aw:Column>
                <aw:Article ID="Article1" runat="server">
                    <ItemTemplate>
                        > <span class="green">
                            <%#Eval("fdArtiTitle") %></span>
                    </ItemTemplate>
                </aw:Article>
            </div>
            <div class="innerPad detail">
                <div class="blank20px">
                </div>
                <aw:Article runat="server">
                    <ItemTemplate>
                        <div class="comhead">
                            <h1 class="fbold tc">
                                <%#Eval("fdArtiTitle") %></h1>
                        </div>
                        <div class="flowhidden" style="padding: 0px 20px;">
                            <div class="lh24 tc lgray">
                                <%#Eval("fdArtiCreateAt","{0:yyyy-MM-dd HH:mm}") %></div>
                            <div class=" txtCon">
                                <%#Eval("fdArtiContent") %>
                            </div>
                        </div>
                    </ItemTemplate>
                </aw:Article>
                <div class="blank30px">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
