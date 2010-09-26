<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="AdminList.aspx.cs" Inherits="Admin_AdminList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="adminadd.aspx">添加用户</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                用户管理</h3>
        </div>
        <div class="mbd">
            <table>
                <thead>
                    <tr>
                        <th>
                            帐号
                        </th>
                        <th>
                            名称
                        </th>
                        <th>
                            级别
                        </th>
                        <th>
                            登录时间
                        </th>
                        <th>
                            登录IP
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="repAdmins" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt">
                            <td>
                                <%# Eval("fdAdmiAccount")%>
                            </td>
                            <td>
                                <%# Eval("fdAdmiName")%>
                            </td>
                            <td>
                                <%# Eval("fdAdmiLevel").ToString() == "1" ? "超管" : "普通"%>
                            </td>
                            <td>
                                <%# ((DateTime)Eval("fdAdmiLoginAt")).ToString("yyyy-MM-dd") == "1900-01-01" ? "未登录" : Eval("fdAdmiLoginAt", "{0:yyyy-MM-dd HH:mm}")%>
                            </td>
                            <td>
                                <%# Eval("fdAdmiLoginIP")%>
                            </td>
                            <td style="text-align: left; padding-left: 10px">
                                <a href="adminedit.aspx?id=<%# Eval("fdAdmiID")%>">修改</a> <a href="admindel.aspx?id=<%# Eval("fdAdmiID")%>"
                                    onclick="return confirm('您确定要删除吗?')">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>SuperAdmin用户不能删除。</li>
        </ul>
    </div>
</asp:Content>
