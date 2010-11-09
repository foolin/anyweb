<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Navigation.ascx.cs" Inherits="Control_Navigation" %>
<ul id="nav" class="ulNav white">
    <aw:Navigation ID="Navigation1" runat="server">
        <ItemTemplate>
            <li <%#Container.ItemIndex==0?"class=\"nobg\"":"" %>><a href="<%#Eval("fdNaviLink") %>" class="pa"><b>
                <%#Eval("fdNaviTitle") %></b></a>
                <%#( ( System.Collections.Generic.List<AnyWell.AW_DL.AW_Navigation_bean> ) Eval( "Children" ) ).Count > 0 ? "<span class=\"subMenu\">" : ""%>
                <aw:Navigation ID="Navigation2" runat="server" DataSource='<%#Eval("Children") %>'>
                    <ItemTemplate>
                        <a href="<%#Eval("fdNaviLink") %>">
                            <%#Eval("fdNaviTitle") %></a>
                    </ItemTemplate>
                </aw:Navigation>
                <%#( ( System.Collections.Generic.List<AnyWell.AW_DL.AW_Navigation_bean> ) Eval( "Children" ) ).Count > 0 ? "</span>" : ""%>
            </li>
        </ItemTemplate>
    </aw:Navigation>
</ul>
