<%@ Page Title="关于我们" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AboutUs.aspx.cs" Inherits="Web_AboutUs" %>

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
                关于我们
            </div>
            <div class="content word">
                <%=ShopInfo.AboutUs %>
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
</asp:Content>
