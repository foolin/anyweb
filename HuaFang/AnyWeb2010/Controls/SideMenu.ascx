<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideMenu.ascx.cs" Inherits="Controls_SideMenu" %>
<div class="title-bar">
    <h2 class="cs-clear">
        <p class="title-ch cs-fl">
            <span>时尚资讯</span></p>
    </h2>
</div>
<div class="Side_menu">
    <asp:Repeater ID="repSideMenu" runat="server">
        <ItemTemplate>
            <div class="plain_menu <%#Container.ItemIndex==navigationCount-1?"cs-nobor":"" %>">
                <h3>
                    <strong><a href="<%#Eval("fdNaviLink") %>">
                        <%#Eval("fdNaviTitle") %></a></strong></h3>
                <p class="cs-clear">
                    <asp:Repeater runat="server" DataSource='<%#Eval("Children") %>'>
                        <ItemTemplate>
                            <span><a href="<%#Eval("fdNaviLink") %>">
                                <%#Eval("fdNaviTitle") %></a></span>
                        </ItemTemplate>
                    </asp:Repeater>
                </p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="title-bar">
    <h2 class="cs-clear">
        <p class="title-ch cs-fl">
            <span>行业招聘</span></p>
    </h2>
</div>
<div class="Side_menu">
    <div class="common_menu">
        <a href="#"><strong>行业招聘</strong></a>
    </div>
    <div class="common_menu cs-nobor">
        <a href="#"><strong>行业人才</strong></a>
    </div>
</div>
