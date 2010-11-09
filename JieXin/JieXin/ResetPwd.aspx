<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ResetPwd.aspx.cs" Inherits="AnyWell_ResetPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="regpage">
        <div class="topic">
            <h2>
                重置密码</h2>
            <span class="gray">填写以下信息重新设置您的密码</span>
        </div>
        <div class="formTable">
            <form runat="server" id="form1" onsubmit="return checkForm()">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <th scope="row" width="80">
                        <span class="orange">*</span>请设置新密码
                    </th>
                    <td>
                        <asp:TextBox ID="txtPwd1" runat="server" TextMode="Password" CssClass="reginput" MaxLength="20"></asp:TextBox>
                    </td>
                    <td>
                        <span class="tipW" style="display:none" id="Error_Pwd1_1">密码不能为空！</span>
                        <span class="tipW" style="display:none" id="Error_Pwd1_2">密码设置至少6位，且区分大小写！</span>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        <span class="orange">*</span>重复输入密码
                    </th>
                    <td width="192">
                        <asp:TextBox ID="txtPwd2" runat="server" TextMode="Password" CssClass="reginput" MaxLength="20"></asp:TextBox>
                    </td>
                    <td>
                        <span class="tipW" style="display:none" id="Error_Pwd2_1">密码不能为空！</span>
                        <span class="tipW" style="display:none" id="Error_Pwd2_2">密码设置至少6位，且区分大小写！</span>
                        <span class="tipW" style="display:none" id="Error_Pwd2_3">两次输入密码不一致！</span>
                    </td>
                </tr>
                <tr>
                    <th scope="row" colspan="3" height="30">
                        &nbsp;
                    </th>
                </tr>
            </table>
            <div class="tc">
                <input type="submit" class="btn96_35" value="重置密码" />
            </div>
            </form>
        </div>
    </div>

    <script type="text/javascript">
        function checkForm() {
            var error = true;

            var Pwd1 = $.trim($("#<%=txtPwd1.ClientID %>").val());
            var Pwd2 = $.trim($("#<%=txtPwd2.ClientID %>").val());

            if (!Pwd1) {
                $("#Error_Pwd1_1").show();
                $("#Error_Pwd1_2").hide();
                error = false;
            } else if (Pwd1.length < 6) {
                $("#Error_Pwd1_1").hide();
                $("#Error_Pwd1_2").show();
                error = false;
            } else {
                $("#Error_Pwd1_1").hide();
                $("#Error_Pwd1_2").hide();
            }

            if (!Pwd2) {
                $("#Error_Pwd2_1").show();
                $("#Error_Pwd2_2").hide();
                $("#Error_Pwd2_3").hide();
                error = false;
            } else if (Pwd2.length < 6) {
                $("#Error_Pwd2_1").hide();
                $("#Error_Pwd2_2").show();
                $("#Error_Pwd2_3").hide();
                error = false;
            } else if (Pwd1 != Pwd2) {
                $("#Error_Pwd2_1").hide();
                $("#Error_Pwd2_2").hide();
                $("#Error_Pwd2_3").show();
                error = false;
            } else {
                $("#Error_Pwd2_1").hide();
                $("#Error_Pwd2_2").hide();
                $("#Error_Pwd2_3").hide();
            }
            
            return error;
        }
    </script>

</asp:Content>
