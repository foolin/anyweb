<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SiteList.aspx.cs" Inherits="Admin_Content_SiteList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>站点列表</title>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />
    <link href="/Admin/class/style.css" rel="stylesheet" type="text/css" />
    <!--[if lte IE 6]>
	<link href="/Admin/class/forIE6.css" rel="stylesheet" type="text/css" />
	<![endif]-->
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.core.js"></script>
	<script type="text/javascript" src="../js/jquery.ui.widget.js"></script>
	<script type="text/javascript" src="../js/jquery.ui.mouse.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.sortable.js"></script>

    <script type="text/javascript">
        $(function() {
            $("#imglist").sortable({
                items: '> li',
                handle: 'img.imglistmove',
                cursor: 'move',
                appendTo: 'body',
                start: function(e, ui) {
                    ui.helper.css("width", ui.item.width());
                },
                update: function(e, ui) {
                    if (ui.sender) {
                        var w = ui.element.width();
                        ui.placeholder.width(w);
                        ui.helper.css("width", ui.element.children().width());
                    }
                    var id = ui.item.attr("id").replace("site_", "");
                    var nid = 0;
                    if ($(ui.item).next().length == 1) {
                        nid = $(ui.item).next().attr("id").replace("site_", "");
                    } else {
                        nid = -1;
                    }
                    $.ajax({
                        url: "../ajax/SiteSort.aspx?sid=" + id + "&nid=" + nid,
                        type: 'GET',
                        success: function(msg) {
                            if ($.trim(msg).length > 0) {
                                alert(msg);
                                window.location.reload();
                            } else {
                                parent.window.frames["left"].location.reload();
                            }
                        }
                    });
                }
            });
        });
    </script>

</head>
<body>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="Location">
                <div>
                    站点列表
                </div>
            </td>
        </tr>
    </table>
    <div id="Content" style="overflow: scroll">
        <div id="noDatas" runat="server" visible="false" class="nodatas">
            未找到站点，<a href="javascript:parent.addSite();">点击这里</a>新建一个站点</div>
        <ul class="imglist" id="imglist">
            <asp:Repeater ID="repSites" runat="server">
                <ItemTemplate>
                    <li id="site_<%#Eval("fdSiteID")%>">
                        <span class="imglistbackground">
                            <img class="imglistmove" src="../images/default/site.png" alt="<%#Eval("fdSiteName")%>" />
                        </span>
                        <label class="checkbox">
                            <input type="checkbox" value="<%#Eval("fdSiteID")%>" name="ids" class="checkbox" /><%#Eval("fdSiteName")%>
                        </label>
                        <img class="imglistedit" onclick="parent.editSite(<%#Eval("fdSiteID")%>)" src="../images/icons/edit.gif"
                                alt="" />
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>

    <script type="text/javascript">
        $(document).ready(function() {
            initContent();
        });
    </script>

</body>
</html>
