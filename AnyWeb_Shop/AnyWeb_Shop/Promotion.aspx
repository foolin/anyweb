<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Promotion.aspx.cs" Inherits="Promotion" %>

<%@ Register Src="~/Controls/PromotionCate.ascx" TagName="PromotionCate" TagPrefix="uc" %>
<%@ Register Src="~/Controls/PromotionGoods.ascx"TagName="PromotionGoods" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="col2MainSider">
        <uc:PromotionCate ID="PromotionCate" runat="server" />
    </div>
    <div class="col2MainContent">
        <uc:PromotionGoods id="PromotionGoods" runat="server" />
    </div>
    <div class="clear">
    </div>
</asp:Content>
