<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ColumnList.aspx.cs" Inherits="Admin_ColumnList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="ColumnAdd.aspx">添加栏目</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                文章栏目</h3>
        </div>
        <div class="mbd">
            <table>
                <thead>
                    <tr>
                        <th>
                            名称
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="compRep" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt">
                            <td title="<%#Eval("fdColuDescription") %>" style="text-align: left; padding-left: 20px;">
                                <a href="<%#Eval("fdColuPath") %>" target="_blank">
                                    <%#Eval("fdColuName")%></a> <a href="javascript:childShow(<%#Eval("fdColuID") %>)"
                                        id="show_<%#Eval("fdColuID") %>" style="color: blue">[展开]</a> <a href="javascript:childHide(<%#Eval("fdColuID") %>)"
                                            id="hide_<%#Eval("fdColuID") %>" style="display: none; color: blue;">[收缩]</a>
                            </td>
                            <td>
                                <a href="ColumnEdit.aspx?id=<%# Eval("fdColuID")%>">修改</a> <a href="ColumnSort.aspx?type=up&id=<%# Eval("fdColuID")%>">
                                    排前</a> <a href="ColumnSort.aspx?type=down&id=<%# Eval("fdColuID")%>">排后</a><a href="ColumnDel.aspx?id=<%# Eval("fdColuID")%>"
                                        onclick="return confirm('您确定要删除吗?')"> 删除</a>
                            </td>
                        </tr>
                        <asp:Repeater ID="compChild" runat="server" DataSource='<%#Eval("Children") %>'>
                            <ItemTemplate>
                                <tr align="center" class="editalt" name="child_<%#Eval("Parent.fdColuID") %>" style="display: none;">
                                    <td title="<%#Eval("fdColuDescription") %>" style="text-align: left; padding-left: 40px;">
                                        <a href="<%#Eval("fdColuPath") %>" target="_blank">
                                            <%#Eval("fdColuName")%></a>
                                    </td>
                                    <td>
                                        <a href="ColumnEdit.aspx?id=<%# Eval("fdColuID")%>">修改</a> <a href="ColumnSort.aspx?type=up&id=<%# Eval("fdColuID")%>">
                                            排前</a> <a href="ColumnSort.aspx?type=down&id=<%# Eval("fdColuID")%>">排后</a>
                                        <a href="ColumnDel.aspx?id=<%# Eval("fdColuID")%>" onclick="return confirm('您确定要删除吗?')">
                                            删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>栏目最多可支持二级栏目</li>
        </ul>
    </div>

    <script type="text/javascript">
        function childShow(obj) {
            $("tr[name='child_" + obj + "']").show();
            $("#show_" + obj).hide();
            $("#hide_" + obj).show();
        }
        function childHide(obj) {
            $("tr[name='child_" + obj + "']").hide();
            $("#show_" + obj).show();
            $("#hide_" + obj).hide();
        }
    </script>

</asp:Content>
