<%@ Page Title="商品分类" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Category.aspx.cs" Inherits="Web_Category" %>

<%@ Register Src="~/Controls/CategoryLeft.ascx" TagName="CategoryLeft" TagPrefix="uc" %>
<%@ Register Src="~/Controls/GoodsByCate.ascx" TagName="GoodsByCate" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="col2MainSider">
        <uc:CategoryLeft ID="CategoryLeft" runat="server" />
    </div>
    <div class="col2MainContent">
        <uc:GoodsByCate id="GoodsByCate" runat="server" />
    </div>
    <div class="clear">
    </div>
    <script type="text/javascript">
        SetTitleCss(2);
    </script>
</asp:Content>
