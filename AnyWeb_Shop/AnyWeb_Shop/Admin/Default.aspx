<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="供销社－商城后台管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
<li>欢迎使用商城后台管理系统！</li>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
<style>
    .total{line-height:30px;padding-left:20px;}
</style>
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2 >商城销售信息温馨提示：</h2>
            </div>
        </div>
        <asp:Panel ID="pn2" runat="server">
         <div class="mbd">
            <div class="inner">
               您还未开通商城系统，<asp:Button ID="btnOpen" runat="server" Text="点击开通" OnClick="btnOpen_Click" />。
            </div>
        </div>
        </asp:Panel>
        <asp:Panel ID="pn1" runat="server">
         <div class="mbd">
            <div class="inner">
                <div class="total">商城总浏览数： <%=ShopInfo.ClickCount%>次;</div>
                <div class="total">用户统计：共<%=ShopInfo.UserCount%>个用户，今日增长<asp:Literal ID="litUser" runat="server"></asp:Literal>个新用户</div>
                <div class="total">评论统计：共<%= ShopInfo.CommentCount%>条评论，今日增长<asp:Literal ID="litComment" runat="server"></asp:Literal>条新评论。</div>
                <div class="total">留言统计：共<%=ShopInfo.MessageCount%>条留言，今日增长<asp:Literal ID="litLeave" runat="server"></asp:Literal>条新留言。</div>
                <div class="total">订单统计：共<%=ShopInfo.OrderCount%>条订单，未处理订单<asp:Literal ID="litorder1" runat="server"></asp:Literal>条，已发货订单<asp:Literal ID="litOrder2" runat="server"></asp:Literal>条，取消发货订单<asp:Literal ID="litOrder3" runat="server"></asp:Literal>条，今日增长<asp:Literal ID="litOrder" runat="server"></asp:Literal>条新订单。</div>
            </div>
        </div>
        </asp:Panel>
    </div>
    
</asp:Content>
