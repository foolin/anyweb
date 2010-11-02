<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SiteInfo.aspx.cs" Inherits="AnyWell_SiteInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="comPage">
        <div class="ls">
            <div class="lsBox">
                <div class="listSideTop">
                    相关导航</div>
                <div class="bg gray">
                    <div class="blank20px">
                    </div>
                    <ul class="menuBar" id="sidebar">
                        <aw:SiteInfoList runat="server">
                            <ItemTemplate>
                                <li><a href="/s/<%#Eval("fdSiInID") %>.aspx">
                                    <%#Eval( "fdSiInTitle" )%></a> </li>
                            </ItemTemplate>
                        </aw:SiteInfoList>
                    </ul>
                    <div class="blank5px">
                    </div>
                </div>
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
                <aw:SiteInfo runat="server">
                    <ItemTemplate>
                        > <span class="green">
                            <%#Eval( "fdSiInTitle" )%></span>
                    </ItemTemplate>
                </aw:SiteInfo>
            </div>
            <div class="innerPad detail">
                <div class="blank20px">
                </div>
                <aw:SiteInfo runat="server">
                    <ItemTemplate>
                        <div class="comhead">
                            <h1 class="fbold tc">
                                <%#Eval( "fdSiInTitle" )%></h1>
                        </div>
                        <div class="flowhidden" style="padding: 0px 20px;">
                            <div class="lh24 tc lgray">
                                </div>
                            <div class=" txtCon">
                                <%#Eval( "fdSiInContent" )%>
                            </div>
                        </div>
                    </ItemTemplate>
                </aw:SiteInfo>
                <div class="blank30px">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
