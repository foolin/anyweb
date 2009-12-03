<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>天河供销社网络商城后台管理</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta http-equiv="Content-Type" content="text/html;charset=gb2312" />
    <link href="/Public/login.css" rel="stylesheet" type="text/css" />
    <!--[if lte IE 6]>
	<link href="Public/forIE6.css" rel="stylesheet" type="text/css" />
	<![endif]-->
</head>
<body>

    <div class="pbd">
        <form runat="server" id="form1" onsubmit="javascript:return checkForm()">
            <div style="display: none;">
                <asp:Label ID="lblDomain" runat="server"></asp:Label></div>
            <div class="item ">
                <label>
                    帐号</label>
                <div class="inputBox" id="divname">
                    <asp:TextBox ID="txtUserName" runat="server" MaxLength="20" CssClass="text" ></asp:TextBox></div>
            </div>
            <div class="item">
                <label>
                    密码</label>
                <div class="inputBox" id="divpass">
                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="20" TextMode="Password" CssClass="text password"></asp:TextBox></div>
                <div class="forget">
                    <span>(?)</span>
                    <p>
                        如果<em>遗忘了您的个人密码</em>，请与您企业的系统管理员联系办理密码找回手续</p>
                </div>
            </div>
            <div class="item i2">
                <label>
                    验证码</label>
                <div class="inputBox" id="divVal">
                    <input type="text" id="txtVal" name="val" maxlength="4" style="width: 60px;" class="text" /></div>
                <asp:Image ID="imgVal" runat="server" />
                <a href="" onclick="refreshCode()">看不清？</a>
            </div>
            <div class="ctrl">
                <input type="hidden" name="valcode" value="<%=valcode%>" />
                <asp:Button ID="submit" OnClick="submit_Click" runat="server" Text="登 录" CssClass="button">
                </asp:Button>
            </div>
        </form>
    </div>

    <script type="text/javascript" language="javascript">
        function refreshCode()
        {
            var num = parseInt(Math.random()*9999+1).toString();
            var img = document.getElementById("<%=imgVal.ClientID%>");
            if( num.length < 4) num = "0" + num;
            document.forms[0].valcode.value = num;
            img.src = "/imageval.aspx?id=" + num;
        }	
        function checkForm()
        {
             if( form1.txtUserName.value == "")
            {
                alert("请输入帐号!");
                form1.txtUserName.focus();
                document.getElementById("divname").className = "inputBox err";
                return false;
            }
            else
            {
                 document.getElementById("divname").className = "inputBox";
            }
            if( form1.txtPassword.value == "")
            {
                alert("请输入密码!");
                form1.txtPassword.focus();
                document.getElementById("divpass").className = "inputBox err";
                return false;
            }
            else
            {
                 document.getElementById("divpass").className = "inputBox";
            }
            if( form1.txtVal.value == "")
            {
                alert("请输入验证码!");
                form1.txtVal.focus();
                document.getElementById("divVal").className = "inputBox err";
                return false;
            }
            else
            {
                 document.getElementById("divVal").className = "inputBox";
            }
            return true;
        }
        
    </script>

</body>
</html>