<%@ Page Title="推荐列表" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Recomment.aspx.cs" Inherits="Recomment" %>

<%@ Register Src="~/Controls/RecommentCate.ascx" TagName="RecommentCate" TagPrefix="uc" %>
<%@ Register Src="~/Controls/RecommentGoods.ascx"TagName="RecommentGoods" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="col2MainSider">
        <uc:RecommentCate ID="RecommentCate" runat="server" />
    </div>
    <div class="col2MainContent">
        <uc:RecommentGoods id="RecommentGoods" runat="server" />
    </div>
    <div class="clear">
    </div>
</asp:Content>

