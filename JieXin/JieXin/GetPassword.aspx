<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GetPassword.aspx.cs" Inherits="AnyWell_GetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="regpage">
        <div class="topic">
            <h2>
                找回密码</h2>
            <span class="gray">填写以下信息找回您的密码</span>
        </div>
        <div class="formTable">
            <form runat="server" id="form1" onsubmit="return checkForm()">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <th scope="row" width="75">
                        <span class="orange">*</span>用 户 名
                    </th>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="reginput" MaxLength="20"></asp:TextBox>
                    </td>
                    <td>
                        <span class="tipW" style="display:none" id="Error_Name">用户名不能为空！</span>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        <span class="orange">*</span>Email
                    </th>
                    <td width="192">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="reginput" MaxLength="100"></asp:TextBox>
                    </td>
                    <td>
                        <span class="tipW" style="display:none" id="Error_Email">邮箱不能为空！</span>
                        <span class="tipW" style="display:none" id="Error_Email2">邮箱格式不正确！</span>
                    </td>
                </tr>
                <tr>
                    <th scope="row" colspan="3" height="30">
                        &nbsp;
                    </th>
                </tr>
            </table>
            <div class="tc">
                <input type="submit" class="btn96_35" value="找回密码" />
            </div>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkForm() {
            var error = true;
            var mailValid = /^\w+([-+.]\w+)*@\w+([-.]\\w+)*\.\w+([-.]\w+)*$/;
            var mail = $.trim($("#<%=txtEmail.ClientID %>").val());
            var name = $.trim($("#<%=txtName.ClientID %>").val());
            
            if (!mail) {
                $("#Error_Email").show();
                $("#Error_Email2").hide();
            } else if (!mailValid.test(mail)) {
                $("#Error_Email").hide();
                $("#Error_Email2").show();
                error = false;
            } else {
                $("#Error_Email").hide();
                $("#Error_Email2").hide();
            }

            if (!name) {
                $("#Error_Name").show();
                error = false;
            } else {
                $("#Error_Name").hide();
            }
            
            return error;
        }
    </script>
</asp:Content>

