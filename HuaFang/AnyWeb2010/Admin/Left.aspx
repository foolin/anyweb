<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="Admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />
    <style type="text/css">
        <!-- 
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            background-image: url(images/left.gif);
        }
        -->
    </style>
    <link href="class/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript">
        var selected = "";
        function select(idt) {
            var nametu = "xiaotu" + idt;
            if (selected != "") {
                $("#" + selected).attr("src", "images/ico06.gif");
            }
            $("#" + nametu).attr("src", "images/ico05.gif");
            selected = nametu;
        }

        function list(idstr) {
            var name1 = "subtree" + idstr;
            var name2 = "img" + idstr;
            if ($("#" + name1).css("display") != "none") {
                $("#" + name1).hide();
                $("#" + name2).attr("src", "images/ico04.gif");
                return;
            }
            hideAll();
            if ($("#" + name1).css("display") == "none") {
                $("#" + name1).show();
                $("#" + name2).attr("src", "images/ico03.gif");
            }
            else {
                $("#" + name1).hide();
                $("#" + name2).attr("src", "images/ico04.gif");
            }
        }
        function hideAll() {
            $("table[id^='subtree']").each(function() {
                if ($(this).css("display") != "none") {
                    $(this).hide();
                    $("#img" + $(this).attr("id").substr(7)).attr("src", "images/ico04.gif");
                }
            });
        }
    </script>

</head>
<body style="overflow-x:hidden;">
    <table width="198" border="0" cellpadding="0" cellspacing="0" class="left-table01">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="207" height="55" background="images/nav01.gif">
                            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="25%" rowspan="2">
                                        <img src="images/ico02.gif" width="35" height="35" />
                                    </td>
                                    <td width="75%" height="22" class="left-font01">
                                        您好，<span class="left-font02"><%=admin.fdAdmiName%></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" class="left-font01">
                                        [&nbsp;<a href="Logout.aspx" target="_top" class="left-font01">退出</a>&nbsp;]
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:Repeater ID="repMenu" runat="server" OnItemDataBound="repMenu_ItemDataBound">
                    <ItemTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
                            <tr>
                                <td height="29">
                                    <table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="8%">
                                                <img name="img8" id="img<%#Eval("ID") %>" src="images/ico04.gif" width="8" height="11" />
                                            </td>
                                            <td width="92%">
                                                <a href="javascript:" target="mainFrame" class="left-font03" onclick="list('<%#Eval("ID") %>');"><%#Eval("Name")%></a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table id="subtree<%#Eval("ID") %>" style="display: none" width="80%" border="0" align="center"
                            cellpadding="0" cellspacing="0" class="left-table02">
                            <asp:Repeater ID="repChild" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td width="9%" height="20">
                                            <img id="xiaotu<%#Eval("ID") %>" src="images/ico06.gif" width="8" height="12" />
                                        </td>
                                        <td width="91%">
                                            <a href="<%#GetPath()+Eval("Url") %>" target="mainFrame" class="left-font03" onclick="select('<%#Eval("ID") %>');">
                                                <%#Eval("Name")%></a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
    </table>
</body>
</html>
