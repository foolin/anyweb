<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SysIndex.aspx.cs" Inherits="Admin_SysIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="class/style.css" rel="stylesheet" type="text/css" />
    <!--[if lte IE 6]>
	<link href="/Admin/class/forIE6.css" rel="stylesheet" type="text/css" />
	<![endif]-->

    <script type="text/javascript" src="js/jquery.js"></script>

    <script type="text/javascript" src="js/webmenu.js"></script>

    <script type="text/javascript" src="js/function.js"></script>

    <script type="text/javascript" src="js/corl.js"></script>

    <title>AnyWell Studio内容管理系统</title>
</head>
<body scroll="no">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                <a href="Logout.aspx" title="点击退出系统" style="float: right; margin: 5px 10px 0 0; font-size: 12px;
                    background: url(images/icons.gif) left 0 no-repeat; padding-left: 16px; line-height: 16px;">
                    注销登录</a> <span style="float: right; margin: 5px 10px 0 0; font-size: 12px; padding-left: 16px;
                        line-height: 16px;">您好，<%=AdminInfo.fdAdmiName%></span> <span style="font-size: 14px;
                            color: #555; padding-left: 20px;">AnyWell Studio内容管理系统</span>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="mainmenu" style="display: block;">
                </div>
            </td>
        </tr>
        <tr>
            <td width="201" style="overflow: hidden">
                <iframe id="left" name="left" frameborder="0" height="100%" width="201" src="SysMenu.aspx">
                </iframe>
            </td>
            <td>
                <iframe id="mainFrame" name="mainFrame" frameborder="0" height="100%" width="100%"
                    src="mainfra.html"></iframe>
            </td>
        </tr>
    </table>
    <div id="popupDiv">
        <iframe frameborder="0" height="100%" width="100%" id="popup" name="popup" scrolling="no"
            src="loading.htm"></iframe>
    </div>
    <div id="backgroundPopup">
    </div>
    <div id="movePopup" style="position: absolute; background: none repeat scroll 0 0 #000000;">
    </div>

    <script type="text/javascript">
        $(function() {
            initFrame();
        });
    </script>

</body>
</html>
