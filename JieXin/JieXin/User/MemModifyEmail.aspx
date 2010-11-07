<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MemModifyEmail.aspx.cs" Inherits="User_MemModifyEmail" %>

<%@ Register Src="~/Control/UserSidebar.ascx" TagName="UserSidebar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="resumePage">
        <uc1:usersidebar runat="server" />
        <div class="content column">
            <div class="tit gray">
                <a href="/Index.aspx">首页</a> > <a href="/User/Index.aspx">个人会员</a> > <span class="green">
                    邮箱管理</span></div>
            <div class="MemCon">
                <div class="blank12px">
                </div>
                <div class="Res670">
                    <form runat="server" id="form1" onsubmit="return checkForm()">
                    <div class="blank8px">
                    </div>
                    <div class="modifypwd lh24">
                        <strong class="brown">修改邮箱</strong> (<span class="brown">*</span>为必填项)<span
                            class="blank12px"></span>
                        <table width="250" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th scope="row">
                                    &nbsp;旧邮箱
                                </th>
                                <td>
                                    <%=this.LoginUser.fdUserEmail %>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    <span class="brown">*</span>新邮箱
                                </th>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="reginput"
                                        MaxLength="100"></asp:TextBox>
                                </td>
                                <td>
                                    <span class="tipW" style="display: none" id="Error_Email_1">邮箱地址不能为空！</span> <span
                                        class="tipW" style="display: none" id="Error_Email_2">邮箱地址格式不正确！</span>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="blank12px">
                    </div>
                    <div class="lh24">
                        <input type="submit" class="btn94_28" value="保 存" />
                    </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function checkForm() {
            var error = true;
            var email = $("#<%=txtEmail.ClientID %>").val();
            var mailValid = /^\w+([-+.]\w+)*@\w+([-.]\\w+)*\.\w+([-.]\w+)*$/;
            if (!email) {
                $("#Error_Email_1").show();
                $("#Error_Email_2").hide();
                error = false;
            } else if (!mailValid.test(email)) {
                $("#Error_Email_1").hide();
                $("#Error_Email_2").show();
                error = false;
            } else {
                $("#Error_Email_1").hide();
                $("#Error_Email_2").hide();
            }
            return error;
        }
    </script>

    <script type="text/javascript">
        setUserSidebar("YXGL");
    </script>

</asp:Content>
