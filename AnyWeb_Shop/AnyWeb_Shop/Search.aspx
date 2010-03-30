<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="Search" Title="产品搜索" %>

<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/CategoryLeft.ascx" TagName="CategoryLeft" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="col2MainSider">
        <uc:CategoryLeft ID="CategoryLeft" runat="server" />
    </div>
    <div class="col2MainContent">
        <div class="mainContainer">
            <div class="title">
                您搜索<span class="keywords"><asp:Literal ID="litKeywords" runat="server"></asp:Literal></span>，一共有<asp:Literal
                    ID="litRecord" runat="server"></asp:Literal>条记录。</div>
            <div class="content">
                <div class="goodsListEx">
                    <asp:Repeater ID="repGoods" runat="server">
                        <Itemtemplate>
                            <div class="goodsListItem">
                                <dl>
                                    <dd>
                                        <a href="Good.aspx?gid=<%#Eval("ID") %>">
                                            <img src="<%#(string)Eval( "image" )=="" ? "../images/wait.jpg":(string)Eval( "image" ) %>"
                                                class="img" border="0" alt="<%#Eval("GoodsName")%>" /></a></dd>
                                    <dt><a href="Good.aspx?gid=<%#Eval("ID") %>">
                                        <%#Studio.Web.WebAgent.GetLeft((string)Eval("GoodsName"),16)%></a></dt>
                                    <%#(double)Eval("MarketPrice") == 0 ? "<dd>&nbsp;</dd>" : "<dd>市场价：<s>￥" + Eval("MarketPrice") + "元</s></dd>"%>
                                    <%# 
                                (bool)Eval("IsPromotions") ? ((double)Eval("Price") == 0 ? "<dd>促销价格：￥" + Eval("PromotionsPrice") + "元</dd><dd>&nbsp;</dd>" : "<dd>基团网价格：<s>￥" + Eval("Price") + "元</s></dd>" + "<dd>促销价格：￥" + Eval("PromotionsPrice") + "元</dd>") : ((double)Eval("Price") == 0 ? "" : "<dd>基团网价格：￥" + Eval("Price") + "元</dd><dd>&nbsp;</dd>")
                                    %>
                                </dl>
                            </div>
                        </Itemtemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="page">
                <cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="18">
                </cc1:PageNaver>
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
</asp:Content>
