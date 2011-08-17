<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Navigation.ascx.cs" Inherits="Controls_Navigation" %>
<div class="nav">
    <div class="nav-con">
        <ul class="nav-list cs-clear">
            <li class="nav-special" onmouseover="navTab(0)"><a href="/Index.aspx">首页</a></li>
            <AW:Navigation runat="server">
                <ItemTemplate>
                    <li onmouseover="navTab(<%#Eval("fdNaviID") %>)"><a href="<%#Eval("fdNaviLink") %>">
                        <%#Eval("fdNaviTitle") %></a></li>
                </ItemTemplate>
            </AW:Navigation>
            <li class="nav-special" onmouseover="navTab(100001)"><a href="#">专业资讯</a></li>
            <li class="nav-special" onmouseover="navTab(100002)"><a href="#">人才市场</a></li>
        </ul>
    </div>
</div>
<div class="subNav" id="subNav">
    <AW:Navigation runat="server">
        <ItemTemplate>
            <div id="navC_navT_<%#Eval("fdNaviID") %>">
                <AW:Navigation runat="server" DataSource='<%#Eval("Children") %>'>
                    <ItemTemplate>
                        <%#Container.ItemIndex > 0 ? "/" : ""%>
                        <a href="<%#Eval("fdNaviLink") %>">
                            <%#Eval("fdNaviTitle") %></a>
                    </ItemTemplate>
                </AW:Navigation>
            </div>
        </ItemTemplate>
    </AW:Navigation>
    <div id="navC_navT_100001">
        <a href="#">专业资讯</a>/<a href="#">专业资讯</a></div>
    <div id="navC_navT_100002">
        <a href="#">人才市场</a>/<a href="#">人才市场</a>/<a href="#">人才市场</a>/<a href="#">行业人才</a>/<a
            href="#">行业人才</a></div>
</div>
