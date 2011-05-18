<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/InnerContent.master"
    AutoEventWireup="true" CodeFile="InfoEdit.aspx.cs" Inherits="Admin_Person_InfoEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
    个人资料

    <script type="text/javascript">
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
    <table>
        <tr>
            <th>
                用户帐号：
            </th>
            <td>
                <asp:Label ID="lblAccount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                用户昵称：
            </th>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="150" CssClass="text" MaxLength="50"></asp:TextBox>
                <sw:Validator ID="Validator4" ControlID="txtName" ValidateType="Required" ErrorMessage="请填写用户昵称"
                    runat="server">
                </sw:Validator>
            </td>
        </tr>
        <tr>
            <th>
                用户邮箱：
            </th>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="150" CssClass="text" MaxLength="100"></asp:TextBox>
                <sw:Validator ID="Validator1" ControlID="txtEmail" ValidateType="DataType" DataType="Email"
                    ErrorMessage="邮箱格式不正确" runat="server">
                </sw:Validator>
            </td>
        </tr>
        <tr>
            <th>
                QQ：
            </th>
            <td>
                <asp:TextBox ID="txtQQ" runat="server" Width="150" CssClass="text" MaxLength="15"></asp:TextBox>
                <sw:Validator ID="Validator6" ControlID="txtQQ" ValidateType="DataType" DataType="qq"
                    ErrorMessage="QQ格式不正确" runat="server">
                </sw:Validator>
            </td>
        </tr>
        <tr>
            <th>
                MSN：
            </th>
            <td>
                <asp:TextBox ID="txtMSN" runat="server" Width="150" CssClass="text" MaxLength="100"></asp:TextBox>
                <sw:Validator ID="Validator5" ControlID="txtMSN" ValidateType="DataType" DataType="Email"
                    ErrorMessage="MSN格式不正确" runat="server">
                </sw:Validator>
            </td>
        </tr>
    </table>
    <div class="mft">
        <button id="Saving" type="button" style="display: none;" disabled="disabled">
            正在保存</button>
        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="保存" OnClick="btnSave_Click" />
    </div>
</asp:Content>
