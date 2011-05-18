<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/InnerContent.master"
    AutoEventWireup="true" CodeFile="UserEdit.aspx.cs" Inherits="Admin_User_UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
    修改用户

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

        function checkPasswordLength() {
            var str = $("#<%=txtPassword.ClientID %>").val();
            if (str.length == 0)
                return true;
            else if (str.length >= 6)
                return true;
            else
                return false;
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
                用户密码：
            </th>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150" CssClass="text"
                    MaxLength="16"></asp:TextBox>
                <sw:Validator ID="Validator7" ControlID="txtPassword" Expression="checkPasswordLength();"
                    ValidateType="Custom" CheckBlur="true" ErrorMessage="密码长度必须大于6位" ErrorText="密码长度必须大于6位"
                    runat="server">
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
                <sw:Validator ID="Validator8" ControlID="txtPassword2" Expression="checkPassword();"
                    ValidateType="Custom" CheckBlur="true" ErrorText="确认密码和新密码不一样" ErrorMessage="确认密码和新密码不一样"
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
        <tr>
            <th>
                其它：
            </th>
            <td>
                <asp:CheckBox ID="chkLocked" runat="server" Text="锁定" CssClass="checkbox" />
            </td>
        </tr>
    </table>
    <div class="mft">
        <button id="Saving" type="button" style="display: none;" disabled="disabled">
            正在保存</button>
        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="保存" OnClick="btnSave_Click" />
        <button type="button" onclick="history.back();">
            返回</button>
    </div>
</asp:Content>
