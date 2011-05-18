<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/InnerContent.master"
    AutoEventWireup="true" CodeFile="PasswordEdit.aspx.cs" Inherits="Admin_Person_PasswordEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
    修改密码

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

        function checkPassword() {
            return $("#<%=txtPassword.ClientID %>").val() == $("#<%=txtPassword2.ClientID %>").val();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <table>
        <tr>
            <th>
                原密码：
            </th>
            <td>
                <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" Width="150" CssClass="text"
                    MaxLength="16"></asp:TextBox>
                <sw:Validator ID="val1" ControlID="txtOldPassword" ValidateType="Required" ErrorMessage="请填写原密码"
                    runat="server">
                </sw:Validator>
            </td>
        </tr>
        <tr>
            <th>
                新密码：
            </th>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150" CssClass="text"
                    MaxLength="16"></asp:TextBox>
                <sw:Validator ID="Validator2" ControlID="txtPassword" ValidateType="Required" ErrorMessage="请填写原密码"
                    runat="server">
                </sw:Validator>
                <sw:Validator ID="Validator3" ControlID="txtPassword" ValidateType="MinLength" ErrorMessage="密码长度必须大于6位"
                    ErrorText="密码长度必须大于6位" MinLength="6" runat="server">
                </sw:Validator>
            </td>
        </tr>
        <tr>
            <th>
                确认密码：
            </th>
            <td>
                <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password" Width="150" CssClass="text"
                    MaxLength="16"></asp:TextBox>
                <sw:Validator ID="Validator1" ControlID="txtPassword2" Expression="checkPassword();" ValidateType="Custom" CheckBlur="true" ErrorText="确认密码和新密码不一样" ErrorMessage="确认密码和新密码不一样" runat="server"></sw:Validator>
            </td>
        </tr>
    </table>
    <div class="mft">
        <button id="Saving" type="button" style="display: none;" disabled="disabled">
            正在保存</button>
        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="保存密码" OnClick="btnSave_Click" />
    </div>
</asp:Content>
