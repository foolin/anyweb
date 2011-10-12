<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Navigation.ascx.cs" Inherits="Controls_Navigation" %>
<div class="nav">
    <div class="nav-con">
        <ul class="nav-list">
            <li class="nav-special"><a href="/Index.aspx">首页</a></li>
            <AW:Navigation runat="server">
                <ItemTemplate>
                    <li><a href="<%#Eval("fdNaviLink") %>">
                        <%#Eval("fdNaviTitle") %></a>
                        <div class="nav_menu">
                            <AW:Navigation runat="server" DataSource='<%#Eval("Children") %>'>
                                <ItemTemplate>
                                    <a href="<%#Eval("fdNaviLink") %>">
                                        <%#Eval("fdNaviTitle") %></a>
                                </ItemTemplate>
                            </AW:Navigation>
                        </div>
                    </li>
                </ItemTemplate>
            </AW:Navigation>
            <li class="nav-special"><a href="/building.aspx">专业资讯</a></li>
            <li class="nav-special"><a href="/building.aspx">人来人往</a></li>
        </ul>
    </div>
</div>

<script type="text/javascript">
    $(".nav-list li").hover(
		function() {
		    if ($(this).children(".nav_menu").children().length) {
		        $(this).children(".nav_menu").show();
		    }
		},
		function() {
		    if ($(this).children(".nav_menu").children().length) {
		        $(this).children(".nav_menu").hide();
		    }
		}
	);
</script>

