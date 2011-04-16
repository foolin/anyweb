<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/CommonContent.master"
    AutoEventWireup="true" CodeFile="TemplateAdd.aspx.cs" Inherits="Admin_Content_TemplateAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
    新建模板

    <script type="text/javascript">
        $(function() {
            $("#<%=txtContent.ClientID %>").height(document.documentElement.clientHeight - 140);
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
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <ul>
        <li>模板名称：
            <asp:TextBox ID="txtName" runat="server" Width="300" CssClass="text" MaxLength="100"></asp:TextBox>
            <sw:Validator ID="val1" ControlID="txtName" ValidateType="Required" ErrorMessage="请填写模板名称"
                runat="server">
            </sw:Validator>
        </li>
        <li>模板类型：
            <asp:DropDownList ID="drpType" runat="server">
                <asp:ListItem Value="4">首页模板</asp:ListItem>
                <asp:ListItem Value="1">栏目模板</asp:ListItem>
                <asp:ListItem Value="2">内容模板</asp:ListItem>
                <asp:ListItem Value="3">嵌套模板</asp:ListItem>
            </asp:DropDownList>
        </li>
        <li>模板内容：
            <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="98%"></asp:TextBox>
            <sw:Validator ID="Validator1" ControlID="txtContent" ValidateType="Required" ErrorMessage="请填写模板内容"
                runat="server">
            </sw:Validator>
        </li>
    </ul>
    <div class="mft">
        <button id="Saving" type="button" style="display: none;" disabled="disabled">
            正在保存</button>
        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="保存模板" OnClick="btnSave_Click" />
        <button type="button" onclick="window.close()">
            取消退出</button>
    </div>
</asp:Content>
