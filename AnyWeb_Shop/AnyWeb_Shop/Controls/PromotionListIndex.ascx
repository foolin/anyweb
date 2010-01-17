<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PromotionListIndex.ascx.cs"
    Inherits="Controls_PromotionListIndex" %>
<!-- 促销专题开始 -->

<asp:Repeater ID="repList" runat="server">
    <ItemTemplate>
        <div class="topic-goods"  style="overflow:hidden; width:99%;">
            <div class="goods-pic">
                <a href="Good.aspx?gid=<%#Eval("ID") %>">
                    <img src="<%#(string)Eval( "image" )=="" ? "../images/wait.jpg":(string)Eval( "image" ) %>" width="90" height="90" alt="" border="0" />
                </a>
            </div>
            <div class="goods-intro">
                <div class="content">
                    <h5>
                        <a href="Good.aspx?gid=<%#Eval("ID") %>"><%#Studio.Web.WebAgent.GetLeft(Eval("GoodsName").ToString(),11)%></a></h5>
                    <%#Studio.Web.WebAgent.GetLeft(Studio.Web.WebAgent.stripHtml(Eval("Description").ToString()),70)%>
                </div>
                <div class="more">
                    <a href="Good.aspx?gid=<%#Eval("ID") %>">详细信息>></a></div>
            </div>
        </div>
        <div class="clear">
        </div>
    </ItemTemplate>
</asp:Repeater>
<!-- topic-goods end-->
        <div class="more">
            <br />
             <a href="Promotion.aspx">查看更多>></a></div>
<!-- 促销专题结束 -->
