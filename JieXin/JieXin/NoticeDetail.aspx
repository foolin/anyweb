<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="NoticeDetail.aspx.cs" Inherits="NoticeDetail" %>

<%@ Register Src="Control/Sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="comPage">
        <div class="ls">
            <div class="lsBox">
                <uc1:Sidebar runat="server" />
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
                <a href="/Index.aspx">首页</a> > <a href="/Notice.aspx">公告</a> > <span class="green">
                    <aw:Notice ID="Notice1" runat="server">
                        <ItemTemplate>
                            <%#Eval("fdNotiTitle") %></ItemTemplate>
                    </aw:Notice>
                </span>
            </div>
            <div class="innerPad detail">
                <div class="blank20px">
                </div>
                <aw:Notice runat="server">
                    <ItemTemplate>
                        <div class="comhead">
                            <h1 class="fbold tc">
                                <%#Eval("fdNotiTitle") %></h1>
                        </div>
                        <div class="flowhidden" style="padding: 0px 20px;">
                            <div class="lh24 tc lgray">
                                <%#Eval("fdNotiCreateAt","{0:yyyy-MM-dd HH:mm}") %></div>
                            <div class=" txtCon">
                                <%#Eval("fdNotiContent") %>
                            </div>
                        </div>
                    </ItemTemplate>
                </aw:Notice>
                <div class="blank30px">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
