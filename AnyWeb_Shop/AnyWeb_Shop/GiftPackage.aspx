<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
CodeFile="GiftPackage.aspx.cs" Inherits="GiftPackage" Title="畅销大礼包页" %>
<%@ Register Src="~/Controls/CategoryLeft.ascx" TagName="CategoryLeft" TagPrefix="uc" %>
<%@ Register Src="~/Controls/GiftPackageDetails.ascx" TagName="GiftPackageDetails" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
  		<div class="col2MainSider">
      	    <uc:CategoryLeft ID="CategoryLeft1" runat="server" />
        </div>
        <div class="col2MainContent">
            <uc:GiftPackageDetails ID="GiftPackageDetails" runat="server" />
        </div>
        <div class="clear"></div>
</asp:Content>

