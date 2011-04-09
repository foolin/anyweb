<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="Admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="text/html;charset=UTF-8" http-equiv="Content-Type" />
    <link href="class/style.css" rel="stylesheet" type="text/css" />
    <!--[if lte IE 6]>
	<link href="/Admin/class/forIE6.css" rel="stylesheet" type="text/css" />
	<![endif]-->
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/function.js"></script>
    <title></title>
    <style type="text/css">
         body
        {
            background-image: url(images/left.gif);
			font-size:12px;
			border-top:2px solid #B8C9D6;
			margin:0;
        }
    </style>
    <script type="text/javascript">
        var sites = new Array();
        $(document).ready(function() {
            $(document).bind("contextmenu", null, function(e) { return parent.showContextMenu(e); });
            getSites();
        });
    </script>
</head>
<body style="overflow-x: hidden;">
    <table id="treemenu" cellspacing="0" cellpadding="0" border="0" width="198">
        <tbody>
        </tbody>
    </table>
</body>
</html>
