<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Notice.aspx.cs" Inherits="AnyWell_Notice" %>

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
                <a href="/Index.aspx">首页</a> > <span class="green">公告列表</span></div>
            <div class="innerPad">
                <div class="blank20px">
                </div>
                <div class="comhead">
                    公告列表</div>
                <div class="flowhidden" style="padding: 0px 20px;">
                    <div class="blank15px">
                    </div>
                    <ul class="comList gray">
                        <aw:NoticeList runat="server" PagerID="PN1">
                            <ItemTemplate>
                                <li><span class="date">
                                    <%#Eval("fdNotiCreateAt","{0:yyyy-MM-dd HH:mm}") %></span><a href="/n/<%#Eval("fdNotiID") %>.aspx"><%#Studio.Web.WebAgent.GetLeft((string)Eval("fdNotiTitle"),43,true) %></a></li>
                            </ItemTemplate>
                        </aw:NoticeList>
                    </ul>
                </div>
                <div class="pageStyle tr">
                    <aw:Pager ID="PN1" runat="server" StyleID="5" PageSize="20"></aw:Pager>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
