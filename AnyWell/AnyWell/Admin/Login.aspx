<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Shop_Admin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>AnyWell Studio管理系统</title>
    <link href="class/style.css" rel="stylesheet" type="text/css" />
    <!--[if lte IE 6]>
	<link href="class/forIE6.css" rel="stylesheet" type="text/css" />
	<![endif]-->
    <script language="javascript" type="text/javascript" src="js/jquery.js"></script>
    <script language="javascript" type="text/javascript" src="js/validator1.2.js"></script>
</head>
<body>
    <form runat="server" id="form1">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="155" style="background:url(images/top02.gif) repeat;text-align:center;">
                <img src="images/top03.gif" />
            </td>
        </tr>
    </table>
    <table width="562" border="0" align="center" cellpadding="0" cellspacing="0" class="right-table03">
        <tr>
            <td width="221">
                <table width="95%" border="0" cellpadding="0" cellspacing="0" class="login-text01">
                    <tr>
                        <td>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="login-text01">
                                <tr>
                                    <td align="center">
                                        <img src="images/ico13.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="40" align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <img src="images/line01.gif" width="5" height="292" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="31%" height="35" class="login-text02">
                            帐 号：<br />
                        </td>
                        <td width="69%">
                            <asp:TextBox ID="txtUserName" runat="server" MaxLength="20" Width="150"></asp:TextBox>
                            <sw:Validator ID="valName" ControlID="txtUserName" ValidateType="Required" ErrorMessage="请输入帐号！" runat="server"></sw:Validator>
                        </td>
                    </tr>
                    <tr>
                        <td height="35" class="login-text02">
                            密 码：<br />
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" MaxLength="20" TextMode="Password" Width="150"></asp:TextBox>
                            <sw:Validator ID="valPwd" ControlID="txtPassword" ValidateType="Required" ErrorMessage="请输入密码！" runat="server"></sw:Validator>
                        </td>
                    </tr>
                    <tr>
                        <td height="35" class="login-text02">
                            验证码：<br />
                        </td>
                        <td>
                            <asp:TextBox ID="txtCode" runat="server" MaxLength="5" Width="40"></asp:TextBox>
                            <img align="absbottom" id="checkCode" src="" alt="验证码" style="width:60px;height:24px;" /> <a onclick="refreshCode();" class="login-text02" style="cursor:pointer">看不清？</a>
                            <sw:Validator ID="Validator1" ControlID="txtCode" ValidateType="Required" ErrorMessage="请输入验证码！" runat="server"></sw:Validator>
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="submit" OnClick="submit_Click" runat="server" Text="登 陆" CssClass="right-button01"></asp:Button>
                            <input type="reset" class="right-button01" value="重 置" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                Copyright© 2010-<%=DateTime.Now.Year %> Anywell Studio, All rights reserved.
            </td>
        </tr>
    </table>
    </form>
    <script type="text/javascript">
        function refreshCode() {
            $("#checkCode").attr("src", "CheckCode.aspx?rd=" + Math.random());
        }
        $(document).ready(function() {
            refreshCode();
        });
    </script>
</body>
</html>
