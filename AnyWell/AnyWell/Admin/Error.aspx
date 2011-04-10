<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Admin_Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>错误</title>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />
    <link href="class/style.css" rel="stylesheet" type="text/css" />
    <!--[if lte IE 6]>
	<link href="class/forIE6.css" rel="stylesheet" type="text/css" />
	<![endif]-->

    <script type="text/javascript" src="js/jquery.js"></script>

    <script type="text/javascript" src="js/function.js"></script>
    
</head>
<body>
    <div class="pbd">
        <div>
            <div class="popmhd" id="PopupTitle">
                <a href="javascript:parent.disablePopup();">
                    <img src="images/icons/close.gif" alt="" /></a>
                <h3>
                    <%=QS("title")%>
                </h3>
            </div>
            <div class="optionhead"></div>
            <div class="popmbd">
                <table>
                    <tbody>
                        <tr>
                            <td class="msg">
                                <%=QS("msg")%>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="popmft">
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function() {
            parent.setDrag($("#PopupTitle"), 'popupDiv');
        });
    </script>
</body>
</html>
