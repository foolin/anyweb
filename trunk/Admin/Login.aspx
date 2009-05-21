<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>用户登录</title>
    <style type="text/css">
        body{
	        background:#3a84b5;
        }

        /*登录窗口*/
        #login {
	        margin:0px auto;
	        margin-top:200px;
	        background:url(images/login_bg.gif) no-repeat;
	        width:310px;
	        height:282px;
	        font-size: 14px;
        }

        /*登录表单*/
        #loginForm{
	        color:#3E8AD0;
        }

        /*登录顶部标题*/
        #loginTitle{
	        padding-top:5px;
	        text-align:center;
	            color:#3C88DD;
	            font-weight:bold;
            }

		/*表单输入框*/
		#loginForm table{
			margin:5px auto;
			margin-top:15px;
			
		}

		#loginForm .inputTxt{
			width:130px;
			border:0px;
			height:20px;
			background:#D9E8F9;
			border-bottom:solid 2px #09C;
		}

		#loginForm .onInput{
			padding-bottom:0px;
			width:130px;
			border:0px;
			height:20px;
			background:#FFF;
			border-bottom:solid 1px #09C;
		}

		/*登录按钮*/
		.btnForm {
			padding-top:10px;
			text-align:center;
		}
		.btnForm input{
			padding:5px;
		}
    </style>
</head>
<body>
    <form id="form1" runat="server" onsubmit="javascript:return checkForm()">
        <div id="login">
            <div id="loginForm">
                <div id="loginTitle">
                    Anyweb后台管理系统V0.1</div>
                <table>
                    <tr>
                       <td>用户名：</td>
                       <td>
                       		<asp:TextBox class="inputTxt" onmouseover="this.className='onInput'" onmouseout="this.className='inputTxt'"
                            runat="server" ID="txtName"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>密&nbsp;&nbsp;码：</td>
                        <td>
                        	<asp:TextBox class="inputTxt" onmouseover="this.className='onInput'" onmouseout="this.className='inputTxt'"
                            runat="server" ID="txtPass" TextMode="Password"></asp:TextBox></dd>
                        </td>
                    </tr>
                    <tr>
                        <td>验证码：</td>
                        <td>
                        	<asp:TextBox class="inputTxt" onmouseover="this.className='onInput'" onmouseout="this.className='inputTxt'"
                            runat="server" ID="txtCode"></asp:TextBox>
                        	<a href="#" onclick="refreshCode()" title="看不清？">
                            <asp:Image ID="imgVal" runat="server"></asp:Image></a>
                        </td>
                    </tr>
                    <tr>
                     <td colspan="2"  class="btnForm">
                        <input type="hidden" name="valcode" value="<%=valcode%>" />
                        <asp:Button ID="submit" OnClick="submit_Click" runat="server" Text="登录" CssClass="button">
                        </asp:Button>
                        <input type="reset" value="重置" />
                    </td>
                  </tr>
                  
                </table>
            </div>
        </div>
    </form>

    <script language="jscript" type="text/jscript">
        function checkForm()
        {
            if( form1.txtName.value == "")
            {
                alert("请输入帐号!");
                form1.txtName.focus();
                return false;
            }
            if( form1.txtPass.value == "")
            {
                alert("请输入密码!");
                form1.txtPass.focus();
                return false;
            }
            if( form1.txtCode.value == "")
            {
                alert("请输入验证码!");
                form1.txtCode.focus();
                return false;
            }
            return true;
        }
        
        function refreshCode()
        {
            var num = parseInt(Math.random()*9999+1).toString();
            var img = document.getElementById("<%=imgVal.ClientID%>");
            if( num.length < 4) num = "0" + num;
            document.forms[0].valcode.value = num;
            img.src = "/imageval.aspx?id=" + num;
        }	
    </script>

</body>
</html>
