﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecommentGoods.ascx.cs"
    Inherits="Controls_RecommentGoods" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<div class="mainContainer">
    <div class="title">
        <asp:Literal ID="litTitle" runat="server"></asp:Literal></div>
    <div class="content">
        <div class="goodsListEx">
            <asp:Repeater ID="repGoods" runat="server">
                <ItemTemplate>
                    <div class="goodsListItem">
                        <dl>
                            <dd>
                                <a href="Good.aspx?gid=<%#Eval("ID") %>" target="_blank">
                                    <img src="<%#(string)Eval( "image" )=="" ? "../images/wait.jpg":(string)Eval( "image" ) %>"
                                        class="img" border="0" alt="<%#Eval("GoodsName")%>" /></a></dd>
                            <dt><a href="Good.aspx?gid=<%#Eval("ID") %>" target="_blank">
                                <%#Studio.Web.WebAgent.GetLeft((string)Eval("GoodsName"),16)%></a></dt>
                            <%#(double)Eval("MarketPrice") == 0 ? "<dd>&nbsp;</dd>" : "<dd>市场价：<s>￥" + Eval("MarketPrice") + "元</s></dd>"%>
                            <%# 
                                (bool)Eval("IsPromotions") ? ((double)Eval("Price") == 0 ? "<dd>促销价格：￥" + Eval("PromotionsPrice") + "元</dd><dd>&nbsp;</dd>" : "<dd>基团网价格：<s>￥" + Eval("Price") + "元</s></dd>" + "<dd>促销价格：￥" + Eval("PromotionsPrice") + "元</dd>") : ((double)Eval("Price") == 0 ? "" : "<dd>基团网价格：￥" + Eval("Price") + "元</dd><dd>&nbsp;</dd>")
                            %>
                        </dl>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div class="page">
        <cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="18">
        </cc1:PageNaver>
    </div>
</div>
