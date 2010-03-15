﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GoodsByCate.ascx.cs" Inherits="Controls_GoodsByCate" %>
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
                            <img src="<%#(string)Eval( "image" )=="" ? "../images/wait.jpg":(string)Eval( "image" ) %>"
                                border="0" alt="<%#Eval("GoodsName")%>" /></a></dd>
                    <dd>
                        <a href="Good.aspx?gid=<%#Eval("ID") %>"><%#Eval("GoodsName")%></a></dd>
                    <%#(double)Eval("MarketPrice") == 0 ? "<dd>&nbsp;</dd>" : "<dd>市场价：<s>￥" + Eval("MarketPrice") + "元</s></dd>"%>
                    <%# 
                        (bool)Eval("IsPromotions") ? ((double)Eval("Price") == 0 ? "<dd>促销价格：￥" + Eval("PromotionsPrice") + "元</dd><dd>&nbsp;</dd>" : "<dd>基团网价格：<s>￥" + Eval("Price") + "元</s></dd>" + "<dd>促销价格：￥" + Eval("PromotionsPrice") + "元</dd>") : ((double)Eval("Price") == 0 ? "" : "<dd>基团网价格：￥" + Eval("Price") + "元</dd><dd>&nbsp;</dd>")
                    %>
                </dl>
            </div>

        </ItemTemplate>
    </asp:Repeater>
    <div class="clear">
    </div>
    <div class="page">
        <cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="18"></cc1:PageNaver>
    </div>
    <!-- page end -->
</div>
