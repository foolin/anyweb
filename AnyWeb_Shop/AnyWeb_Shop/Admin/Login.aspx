<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>基团网后台管理</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta http-equiv="Content-Type" content="text/html;charset=gb2312" />
    <style type="text/css">
    <!--
    /***********************************/
    /**    登录页面CSS                 **/
    /***********************************/
    body{
	    margin:0 auto;
	    font-size:12px;
    }
    .loginBody{
	    background:#FFF;
    }
    .loginWrap{
	    margin:0px auto;
	    background:url(../images/login_bg.jpg) repeat-x;
	    width:1024px;
	    height:768px;
    }
    .loginDiv{
	    margin:0px auto;
	    margin-top:230px;
	    width:343px;
	    height:319px;
	    background:url(../images/loginform_bg.gif) no-repeat;
    }

    .loginDiv .loginTitle{
	    height:30px;
	    line-height:35px;
	    text-indent:2.5em;
	    font-size:14px;
	    font-weight:bold;
	    color:#FFF;
    }

    .loginForm{
	    margin-left:18px;
	    margin-top:18px;
	    width:300px;
	    height:165px;
    }
    a{
	    color:#666;
    }
    a:hover{
	    color:#F00;
    }
    -->
    </style>
</head>
<body class="loginBody">
    <div class="loginWrap">
        <form runat="server" id="form1" onsubmit="javascript:return checkForm()">
        <div class="loginDiv">
            <div class="loginTitle">
                商城系统管理登录</div>
            <table class="loginForm">
                <tr>
                    <td width="25%" align="right">
                        用户名：
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" MaxLength="20" CssClass="text" Style="width: 150px;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        密 码：
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" MaxLength="20" TextMode="Password" CssClass="text password"
                            Style="width: 150px;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        验证码：
                    </td>
                    <td>
                        <input type="text" id="txtVal" name="val" maxlength="4" style="width: 60px;" class="text"
                            style="width: 50px;" /><asp:Image ID="imgVal" runat="server" /><a href="javascript:refreshCode()">看不清？</a>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td>
                        <input type="hidden" name="valcode" value="<%=valcode%>" />
                        <asp:Button ID="Button1" OnClick="submit_Click" runat="server" Text="登 录" CssClass="button">
                        </asp:Button>
                    </td>
                </tr>
            </table>
        </div>
        </form>
    </div>

    <script type="text/javascript" language="javascript">
        function refreshCode() {
            var num = parseInt(Math.random() * 9999 + 1).toString();
            var img = document.getElementById("<%=imgVal.ClientID%>");
            if (num.length < 4) num = "0" + num;
            document.forms[0].valcode.value = num;
            img.src = "/admin/imageval.aspx?id=" + num;
        }
        function checkForm() {
            if (form1.txtUserName.value == "") {
                alert("请输入帐号!");
                form1.txtUserName.focus();
                return false;
            }
            if (form1.txtPassword.value == "") {
                alert("请输入密码!");
                form1.txtPassword.focus();
                return false;
            }
            if (form1.txtVal.value == "") {
                alert("请输入验证码!");
                form1.txtVal.focus();
                return false;
            }
            return true;
        }
        
    </script>

</body>
</body>
</html>
