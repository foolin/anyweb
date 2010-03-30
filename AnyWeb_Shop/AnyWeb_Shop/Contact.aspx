<%@ Page Title="联系我们" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Contact.aspx.cs" Inherits="Contact" %>

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
                联系我们
            </div>
            <div class="content word">
                <%=ShopInfo.InterosculateUs %>
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
</asp:Content>
