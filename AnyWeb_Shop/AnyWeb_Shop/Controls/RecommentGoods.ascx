﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecommentGoods.ascx.cs" Inherits="Controls_RecommentGoods" %>
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
                    <dd>
                        <s>市场价：￥<%#Eval("MarketPrice")%>元</s></dd>
                    <dd>
                        商城优惠价：￥<%#Eval("PromotionsPrice")%>元
                    </dd>
                </dl>
            </div>
            <!-- goods end -->
        </ItemTemplate>
    </asp:Repeater>
    <div class="clear">
    </div>
    <div class="page">
        <cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="18"></cc1:PageNaver>
    </div>
    <!-- page end -->
</div>