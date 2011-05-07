<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/List.master" AutoEventWireup="true"
    CodeFile="SingleArticle.aspx.cs" Inherits="Admin_Content_SingleArticle" %>

<%@ Register Src="../Control/ColumnInfo.ascx" TagName="ColumnInfo" TagPrefix="uc1" %>
<%@ Register Src="../Control/SingleArticleFooter.ascx" TagName="SingleArticleFooter"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script type="text/javascript">
        $(function() {
            $("#<%=txtContent.ClientID %>_txt").height(document.documentElement.clientHeight - 188);
        });
        
        function disableButton() {
            $("#<%=btnSave.ClientID %>").hide();
            $("#Saving").show();
            return true;
        }

        function enableButton() {
            $("#<%=btnSave.ClientID %>").show();
            $("#Saving").hide();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <iframe style="width: 0px; height: 0px; display: none;" id="ifrSelf" name="ifrSelf">
    </iframe>
    <form id="form1" runat="server" target="ifrSelf">
    <ul>
        <li>文档标题：
            <asp:TextBox ID="txtTitle" runat="server" Width="300" CssClass="text" MaxLength="255"></asp:TextBox>
            <sw:Validator ID="val1" ControlID="txtTitle" ValidateType="Required" ErrorMessage="请填写文档标题"
                runat="server">
            </sw:Validator>
        </li>
        <li>所属栏目：<asp:Label ID="lblColumn" runat="server"></asp:Label></li>
        <li>
            <sw:TinyMce ID="txtContent" runat="server" />
        </li>
        <li>其他设置：
            <asp:CheckBox ID="chkEnableComment" runat="server" CssClass="checkbox" Text="允许评论"
                Checked="true" />
        </li>
    </ul>
    <div class="mft">
        <button id="Saving" type="button" style="display: none;" disabled="disabled">
            正在保存</button>
        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="保存文档" OnClick="btnSave_Click" />
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphOpr" runat="Server">
    <uc1:ColumnInfo runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" runat="Server">
    <uc1:SingleArticleFooter runat="server" />

    <script type="text/javascript">
        selectFooter("Article");
    </script>

</asp:Content>
