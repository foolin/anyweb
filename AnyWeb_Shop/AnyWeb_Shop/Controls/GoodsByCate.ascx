<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GoodsByCate.ascx.cs" Inherits="Controls_GoodsByCate" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<div class="box">
    <div class="title">
        <asp:Literal ID="litTitle" runat="server"></asp:Literal></div>
    <asp:Repeater ID="repGoods" runat="server">
        <ItemTemplate>
            <div class="goods">
                <dl>
                    <dd>
                        <a href="Good.aspx?gid=<%#Eval("ID") %>">
                            <img src="<%#Eval("Image") %>"
                                border="0" /></a></dd>
                    <dd>
                        <a href="Good.aspx?gid=<%#Eval("ID") %>"><%#Eval("GoodsName")%></a></dd>
                    <dd>
                        <s>市场价：￥<%#Eval("MarketPrice")%>元</s></dd>
                    <dd>
                        促销价：￥<%#Eval("PromotionsPrice")%>元
                    </dd>
                </dl>
            </div>
            <!-- goods end -->
        </ItemTemplate>
    </asp:Repeater>
    <div class="clear">
    </div>
    <div class="page">
        <cc1:PageNaver ID="PN1" runat="server"></cc1:PageNaver>
        <%--<a href="#1">上一页</a> <a href="#1">1</a> <a href="#1">2</a> 3 <a href="#1">4</a>
        <a href="#1">5</a> <a href="#1">下一页</a>
        <input type="text" name="page" value="" />--%>
    </div>
    <!-- page end -->
</div>
