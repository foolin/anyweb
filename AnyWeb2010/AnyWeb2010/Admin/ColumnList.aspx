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
                新闻栏目</h3>
        </div>
        <div class="mbd">
            <table>
                <thead>
                    <tr>
                        <th>
                            名称
                        </th>
                        <th>
                            路径
                        </th>
                        <th>
                            首页显示
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
                                <%#Eval("fdColuName")%>
                            </td>
                            <td>
                                <%# Studio.Web.WebAgent.IsInt32(Eval("fdColuPath").ToString()) ? "" : Eval("fdColuPath")%>
                            </td>
                            <td>
                                <%# (int)Eval("fdColuShowIndex")==0?"<span style='color:red'>否</span>":"是" %>
                            </td>
                            <td>
                                <a href="ColumnEdit.aspx?id=<%# Eval("fdColuID")%>">修改</a> <a href="ColumnSort.aspx?type=up&id=<%# Eval("fdColuID")%>">
                                    排前</a> <a href="ColumnSort.aspx?type=down&id=<%# Eval("fdColuID")%>">排后</a>
                                <a href="ColumnDel.aspx?id=<%# Eval("fdColuID")%>" onclick="return confirm('您确定要删除吗?')">
                                    删除</a>
                            </td>
                        </tr>
                        <asp:Repeater ID="compChild" runat="server" DataSource='<%#Eval("Children") %>'>
                            <ItemTemplate>
                                <tr align="center" class="editalt">
                                    <td title="<%#Eval("fdColuDescription") %>" style="text-align: left; padding-left: 40px;">
                                        <%#Eval("fdColuName")%>
                                    </td>
                                    <td>
                                        <%# Studio.Web.WebAgent.IsInt32(Eval("fdColuPath").ToString()) ? "" : Eval("fdColuPath")%>
                                    </td>
                                    <td>
                                        <%# (int)Eval("fdColuShowIndex")==0?"<span style='color:red'>否</span>":"是" %>
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
</asp:Content>
