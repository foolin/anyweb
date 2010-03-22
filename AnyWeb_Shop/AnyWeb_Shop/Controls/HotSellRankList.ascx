<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HotSellRankList.ascx.cs" Inherits="Controls_HotSellRankList" %>

<!-- 畅销排行开始 -->
<asp:Repeater ID="repList" runat="server">
    <ItemTemplate>
        <div class="topic-goods"  style="overflow:hidden; width:99%;">
            <div class="goods-pic">
                <a href="Good.aspx?gid=<%#Eval("GoodsID") %>">
                    <img src="<%#(string)Eval( "OfGoods.image" )=="" ? "../images/wait.jpg":(string)Eval( "OfGoods.image" ) %>" width="90" height="90" alt="" border="0" />
                </a>
            </div>
            <div class="goods-intro">
                <div class="content">
                    <h5>
                        <%#Studio.Web.WebAgent.GetLeft(Eval("OfGoods.GoodsName").ToString(), 11)%></h5>
                    <%#Studio.Web.WebAgent.GetLeft(Studio.Web.WebAgent.stripHtml(Eval("OfGoods.Description").ToString()), 70)%>
                </div>
                <div class="more">
                    <a href="Good.aspx?gid=<%#Eval("GoodsID") %>">详细信息>></a></div>
            </div>
        </div>
        <div class="clear">
        </div>
    </ItemTemplate>
</asp:Repeater>
<!-- 畅销排行结束 -->
