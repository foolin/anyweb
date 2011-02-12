<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index_Old.aspx.cs" Inherits="Admin_Index_Old" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>商城管理系统</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta http-equiv="Content-Type" content="text/html;charset=gb2312" />
    <link href="class/style.css" rel="stylesheet" type="text/css" />
    <!--[if lte IE 6]>
	<link href="/public/class/forIE6.css" rel="stylesheet" type="text/css" />
	<![endif]-->

    <script language="javascript" type="text/javascript" src="js/menu.js"></script>

    <script language="javascript" type="text/javascript" src="js/jquery.js"></script>

    <script type="text/javascript">
        function goPage(url) {
            document.getElementById("ifrContent").src = url;
        }
    </script>

</head>
<body class="pInner">
    <form id="form1" runat="server">
    <div class="phd">
        <h1 class="Logo">
            <a href="/" target="_blank">
                <img alt="商城管理系统" src="/public/images/smtLogo.jpg" /></a></h1>
        <div class="Name">
            aofei
        </div>
        <div class="SmtNav" id="mainmenu">
            <div class="refresh" style="display: none;">
                <a href="" target="_blank"></a>
            </div>
            <div class="logout">
                <a href="/Admin/logout.aspx">注销登录</a></div>
            <iframe id="if1"></iframe>
            <iframe id="if2"></iframe>
        </div>
    </div>
    <div class="Location" id="NavLocation">
        当前位置：<a href="javascript:goPage('/Admin/Desktop.aspx')">首页</a> &gt;
        <asp:Literal ID="compPos" runat="server"></asp:Literal>
    </div>
    <iframe id="ifrContent" src="Desktop.aspx" width="100%" height="800" frameborder="0"
        scrolling="no"></iframe>
    <div class="pft">
        <div class="Copyright">
            <p>
                CopyRight &copy; FortuneAge 2009
            </p>
        </div>
    </div>

    <script type="text/javascript" src="/admin/getmenuitems.aspx"></script>

    <asp:Literal ID="litEndJs" runat="server"></asp:Literal>
    </form>
</body>
</html>
