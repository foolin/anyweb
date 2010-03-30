<%@ Page Title="产品信息" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Good.aspx.cs" Inherits="Good" %>

<%@ Register Src="~/Controls/CategoryLeft.ascx" TagName="CategoryLeft" TagPrefix="uc" %>
<%@ Register Src="~/Controls/GoodDetail.ascx" TagName="GoodDetail" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="col2MainSider">
        <uc:CategoryLeft ID="CategoryLeft" runat="server" />
    </div>
    <div class="col2MainContent">
        <uc:GoodDetail ID="GoodDetail" runat="server" />
    </div>
    <div class="clear">
    </div>
</asp:Content>
