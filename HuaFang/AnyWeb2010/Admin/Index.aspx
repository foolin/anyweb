<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Admin_Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>华纺后台管理系统</title>

    <script type="text/javascript" src="js/jquery.js"></script>

    <style type="text/css">
        #popupContact
        {
            border: 0 none;
            display: none;
            padding: 0;
            position: fixed;
            z-index: 3;
        }
    </style>
</head>
<body scroll="no">

    <script type="text/javascript">
        $(document).ready(function() {
            $("#left").height(document.documentElement.clientHeight - 75);
            $("#mainFrame").height(document.documentElement.clientHeight - 75);
        });
    </script>

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="59" background="images/top.gif">
                            <table width="99%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="1%">
                                        <a href="../index.aspx" target="_blank">
                                            <img src="images/Logo.png" border="0" alt="" /></a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="201" style="overflow: hidden">
                <iframe id="left" frameborder="0" height="100%" width="201" src="Left.aspx"></iframe>
            </td>
            <td>
                <iframe id="mainFrame" name="mainFrame" frameborder="0" height="100%" width="100%"
                    src="mainfra.html"></iframe>
            </td>
        </tr>
    </table>
    <div id="popupContact">
        <iframe frameborder="0" height="100%" width="100%" id="popup" name="popup" scrolling="no"
            src="mainfra.html"></iframe>
    </div>
</body>
</html>
