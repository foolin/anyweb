<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/List.master" AutoEventWireup="true"
    CodeFile="ColumnList.aspx.cs" Inherits="Admin_Content_ColumnList" %>

<%@ Register Src="../Control/ColumnOperation.ascx" TagName="ColumnOperation" TagPrefix="uc1" %>
<%@ Register Src="../Control/ColumnInfo.ascx" TagName="ColumnInfo" TagPrefix="uc1" %>
<%@ Register Src="../Control/ColumnFooter.ascx" TagName="ColumnFooter" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
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
                    var id = ui.item.attr("id").replace("col_", "");
                    var nid = 0;
                    if ($(ui.item).next().length == 1) {
                        nid = $(ui.item).next().attr("id").replace("col_", "");
                    } else {
                        nid = -1;
                    }
                    $.ajax({
                        url: "../ajax/ColumnSort.aspx?cid=" + id + "&nid=" + nid,
                        type: 'GET',
                        success: function(msg) {
                            if (msg.substr(0, 8) == 'success:') {
                                var str = msg.substr(8, msg.length - 8);
                                eval(str);
                            }else {
                                alert(msg);
                                window.location.reload();
                            }
                        }
                    });
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="Server">
    栏目列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="noDatas" runat="server" visible="false" class="nodatas">
        未找到栏目，<a href="javascript:parent.addColumn(<%=CurrentColumn.fdColuID %>);">点击这里</a>新建一个栏目</div>
    <ul class="imglist" id="imglist">
        <asp:Repeater ID="repColumns" runat="server">
            <ItemTemplate>
                <li id="col_<%#Eval("fdColuID")%>"><span class="imglistbackground">
                    <img class="imglistmove" src="../images/default/site.png" alt="<%#Eval("fdColuName")%>" />
                </span>
                    <label class="checkbox">
                        <input type="checkbox" value="<%#Eval("fdColuID")%>" name="ids" class="checkbox" /><%#Eval( "fdColuName" )%>
                    </label>
                    <img class="imglistedit" onclick="parent.editColumn(<%#Eval("fdColuID")%>)" src="../images/icons/edit.gif"
                        alt="" />
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphOpr" runat="Server">
    <uc1:ColumnOperation runat="server" />
    <uc1:ColumnInfo runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" runat="Server">
    <uc1:ColumnFooter runat="server" />
    <script type="text/javascript">
        selectFooter("Column");
    </script>
</asp:Content>
