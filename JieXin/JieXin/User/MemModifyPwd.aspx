<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MemModifyPwd.aspx.cs" Inherits="User_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="resumePage">
    	<div class="sidebar" style="height:1300px;">
        	<div class="bg column gray">
            	<ul>
                	<li><a href="index.aspx">简历管理</a></li>
                    <li><a href="MemAddInfo.aspx">基本信息管理</a></li>
                    <li><a href="#">形象照片管理</a></li>
                    <li class="cur"><a href="MemModifyPwd.aspx">密码管理</a></li>
                    <li><a href="#">邮箱管理</a></li>
                </ul>
            </div>
        </div>
        <div class="content column">
        	<div class="tit gray"><a href="#">首页</a> > <a href="#">个人会员</a> > <span class="green">会员管理</span></div>
            <div class="MemCon">
            	<div class="blank12px"></div>
                <div class="Res670">
                    <form runat="server" id="form1" onsubmit="return checkRegister()">
                    <div class="blank8px"></div>
                    <div class="modifypwd lh24">
                    	<strong class="brown">修改密码</strong> (<span class="brown">*</span>为必填项，新密码格式：只能是6-20位的英文字母或数字,以下划线或字母开头！或者2-10位汉字)<span class="blank12px"></span>
						<table width="250" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <th scope="row"><span class="brown">*</span>旧 密 码</th>
                            <td>
                                <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password" CssClass="reginput" MaxLength="50"></asp:TextBox>
                            </td>
                            <td>
                                <span class="tipW" style="display:none" id="Error_OldPwd">旧密码不能为空！</span>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">
                                <span class="brown">*</span>新 密 码
                            </th>
                            <td>
                                <asp:TextBox ID="txtNewPwd1" TextMode="Password" runat="server" CssClass="reginput" MaxLength="50"></asp:TextBox>
                            </td>
                            <td>
                                <span class="tipW" style="display:none" id="Error_NewPwd1_1">密码不能为空！</span>
                                <span class="tipW" style="display:none" id="Error_NewPwd1_2">密码设置至少6位，且区分大小写！</span>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">
                                <span class="brown">*</span>重复密码
                            </th>
                            <td>
                                <asp:TextBox ID="txtNewPwd2" TextMode="Password" runat="server" CssClass="reginput" MaxLength="50"></asp:TextBox>
                            </td>
                            <td>
                                <span class="tipW" style="display:none" id="Error_NewPwd2_1">密码不能为空！</span>
                                <span class="tipW" style="display:none" id="Error_NewPwd2_2">密码设置至少6位，且区分大小写！</span>
                                <span class="tipW" style="display:none" id="Error_NewPwd2_3">两次输入密码不一致！</span>
                            </td>
                          </tr>
                        </table>
                    </div>
                    <div class="blank12px"></div>
                    <div class="lh24">
                    	<input type="submit" class="btn94_28" value="保 存" />
                    </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function checkRegister() {
            var error = true;
            var oldPwd = $.trim($("#<%=txtOldPwd.ClientID %>").val());
            var newPwd1 = $.trim($("#<%=txtNewPwd1.ClientID %>").val());
            var newPwd2 = $.trim($("#<%=txtNewPwd2.ClientID %>").val());

            if (!oldPwd) {
                $("#Error_OldPwd").show();
                error = false;
            } else {
                $("#Error_OldPwd").hide();
            }

            if (!newPwd1) {
                $("#Error_NewPwd1_1").show();
                $("#Error_NewPwd1_2").hide();
                error = false;
            } else if (newPwd1.length < 6) {
                $("#Error_NewPwd1_1").hide();
                $("#Error_NewPwd1_2").show();
                error = false;
            } else {
                $("#Error_NewPwd1_1").hide();
                $("#Error_NewPwd1_2").hide();
            }

            if (!newPwd2) {
                $("#Error_NewPwd2_1").show();
                $("#Error_NewPwd2_2").hide();
                $("#Error_NewPwd2_3").hide();
                error = false;
            } else if (newPwd2.length < 6) {
                $("#Error_NewPwd2_1").hide();
                $("#Error_NewPwd2_2").show();
                $("#Error_NewPwd2_3").hide();
                error = false;
            } else if (newPwd1 != newPwd2) {
                $("#Error_NewPwd2_1").hide();
                $("#Error_NewPwd2_2").hide();
                $("#Error_NewPwd2_3").show();
                error = false;
            } else {
                $("#Error_NewPwd2_1").hide();
                $("#Error_NewPwd2_2").hide();
                $("#Error_NewPwd2_3").hide();
            }
            
            return error;
        }
    </script>
</asp:Content>

