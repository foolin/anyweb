<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PromotionIndex.ascx.cs"
    Inherits="Controls_PromotionIndex" %>
<div class="box2">
    <div class="title">
        <div class="txt">
            促销商品</div>
        <div class="more">
            <a href="Promotion.aspx">更多>></a></div>
    </div>
    <div class="content">
        <div class="clear">
        </div>
        <asp:Repeater ID="repRecomment" runat="server" OnItemDataBound="repCategory_ItemDataBound">
            <ItemTemplate>
                <asp:Repeater ID="repGood" runat="server">
                    <ItemTemplate>
                        <div class="indexGoods">
                            <div class="indexItem">
                                <div class="pic">
                                    <a href="Good.aspx?gid=<%#Eval("ID") %>">
                                        <img src="<%#(string)Eval( "image" )=="" ? "../images/wait.jpg":(string)Eval( "image" ) %>"
                                            border="0" alt="<%#Eval("GoodsName")%>" /></a>
                                </div>
                                <div class="name">
                                    <a href="Good.aspx?gid=<%#Eval("ID") %>">
                                        <%#Studio.Web.WebAgent.GetLeft((string)Eval("GoodsName"),8)%></a>
                                </div>
                            </div>
                    </ItemTemplate>
                </asp:Repeater>
                <ul class="items">
                    <asp:Repeater ID="repList" runat="server">
                        <ItemTemplate>
                            <li><a href="Good.aspx?gid=<%#Eval("ID") %>" title="<%#Eval("GoodsName")%>">
                                <%#Studio.Web.WebAgent.GetLeft((string)Eval("GoodsName"),8)%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="clear">
        </div>
    </div>
</div>
