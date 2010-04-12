<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HotSellRankList.ascx.cs" Inherits="Controls_HotSellRankList" %>
<div class="box" style="margin-left: 2px;">
    <div class="title">
        <div class="txt">
            畅销商品排行</div>
        <div class="ico">
            <img src="Images/box1_title_rbg.gif" width="66" height="33" /></div>
    </div>
    <div class="content">
        <asp:Repeater ID="repList" runat="server">
            <ItemTemplate>
                <div class="indexTopic">
                    <div class="topicImage">
                        <a href="Good.aspx?gid=<%#Eval("ID") %>">
                            <img src="<%#(string)Eval( "image" )=="" ? "../images/wait.jpg":(string)Eval( "image" ) %>"
                                alt="<%#Eval("GoodsName") %>" border="0" />
                        </a>
                    </div>
                    <div class="topicDesc">
                        <h4>
                            <a href="Good.aspx?gid=<%#Eval("ID") %>">
                                <%#Studio.Web.WebAgent.GetLeft(Eval("GoodsName").ToString(),11)%></a></h4>
                        <%#Studio.Web.WebAgent.GetLeft(Studio.Web.WebAgent.stripHtml(Eval("Description").ToString()), 55)%>
                        <br />
                        <a href="Good.aspx?gid=<%#Eval("ID") %>" class="more">详细信息</a>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>