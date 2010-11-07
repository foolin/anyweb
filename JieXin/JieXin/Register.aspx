<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="regpage">
        <div class="topic">
            <h2>
                填写您的注册信息</h2>
            <span class="gray">填写以下信息成为杰信个人会员</span>
        </div>
        <div class="formTable">
            <form runat="server" id="form1" onsubmit="return checkRegister()">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <th scope="row" width="75">
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
                    <th scope="row">
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
                        <span class="orange">*</span>密 码
                    </th>
                    <td>
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="reginput" MaxLength="20"></asp:TextBox>
                    </td>
                    <td>
                        <span class="tipW" style="display:none" id="Error_Password1_1">密码不能为空！</span>
                        <span class="tipW" style="display:none" id="Error_Password1_2">密码设置至少6位，且区分大小写！</span>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        <span class="orange">*</span>重复密码
                    </th>
                    <td>
                        <asp:TextBox ID="txtPassword2" TextMode="Password" runat="server" CssClass="reginput" MaxLength="20"></asp:TextBox>
                    </td>
                    <td>
                        <span class="tipW" style="display:none" id="Error_Password2_1">密码不能为空！</span>
                        <span class="tipW" style="display:none" id="Error_Password2_2">密码设置至少6位，且区分大小写！</span>
                        <span class="tipW" style="display:none" id="Error_Password2_3">两次输入密码不一致！</span>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        &nbsp;
                    </th>
                    <td>
                        <input type="checkbox" id="agreen" class="cexbox" runat="server" checked="checked" /><label for="<%=agreen.ClientID %>">我已阅读</label><a href="javascript:void(0)" onclick='$("#service").toggle();'>《服务声明》</a>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <th scope="row" colspan="3" height="30">
                        &nbsp;
                    </th>
                </tr>
            </table>
            <textarea id="service" cols="77" rows="20" readonly="readonly" style="display:none"><%=AnyWell.Configs.GeneralConfigs.GetConfig().RegAgreement%></textarea>
            <div class="tc">
                <input type="submit" class="btn96_35" value="开始注册" />
            </div>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkRegister() {
            var error = true;
            var mailValid = /^\w+([-+.]\w+)*@\w+([-.]\\w+)*\.\w+([-.]\w+)*$/;
            var mail = $.trim($("#<%=txtEmail.ClientID %>").val());
            var name = $.trim($("#<%=txtName.ClientID %>").val());
            var password = $.trim($("#<%=txtPassword.ClientID %>").val());
            var password2 = $.trim($("#<%=txtPassword2.ClientID %>").val());
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

            if (!password) {
                $("#Error_Password1_1").show();
                $("#Error_Password1_2").hide();
                error = false;
            } else if (password.length < 6) {
                $("#Error_Password1_1").hide();
                $("#Error_Password1_2").show();
                error = false;
            } else {
                $("#Error_Password1_1").hide();
                $("#Error_Password1_2").hide();
            }

            if (!password2) {
                $("#Error_Password2_1").show();
                $("#Error_Password2_2").hide();
                $("#Error_Password2_3").hide();
                error = false;
            } else if (password2.length < 6) {
                $("#Error_Password2_1").hide();
                $("#Error_Password2_2").show();
                $("#Error_Password2_3").hide();
                error = false;
            } else if (password != password2) {
                $("#Error_Password2_1").hide();
                $("#Error_Password2_2").hide();
                $("#Error_Password2_3").show();
                error = false;
            } else {
                $("#Error_Password2_1").hide();
                $("#Error_Password2_2").hide();
            }
            
            if (error && !$("#<%=agreen.ClientID %>").attr("checked")) {
                alert("需要先同意《服务声明》才能继续注册！")
                error = false;
            }
            return error;
        }
    </script>
</asp:Content>
