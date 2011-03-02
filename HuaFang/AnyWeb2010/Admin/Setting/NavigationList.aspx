<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="NavigationList.aspx.cs" Inherits="Admin_NavigationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="NavigationAdd.aspx">添加导航栏</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                导航栏设置</h3>
        </div>
        <div class="mbd">
            <table>
                <thead>
                    <tr>
                        <th>
                            名称
                        </th>
                        <th>
                            类型
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="compRep" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt">
                            <td style="text-align: left; padding-left: 20px;">
                                <a href="<%#Eval("fdNaviLink") %>" target="_blank">
                                    <%#Eval("fdNaviTitle")%></a>
                            </td>
                            <td>
                                <%#getTypeName((int)Eval("fdNaviType"))%>
                            </td>
                            <td>
                                <a href="NavigationEdit.aspx?id=<%# Eval("fdNaviID")%>">修改</a> <a href="NavigationSort.aspx?type=up&id=<%# Eval("fdNaviID")%>">
                                    排前</a> <a href="NavigationSort.aspx?type=down&id=<%# Eval("fdNaviID")%>">排后</a><a
                                        href="NavigationDel.aspx?id=<%# Eval("fdNaviID")%>" onclick="return confirm('您确定要删除吗?')">
                                        删除</a>
                            </td>
                        </tr>
                        <asp:Repeater ID="compChild" runat="server" DataSource='<%#Eval("Children") %>'>
                            <ItemTemplate>
                                <tr align="center" class="editalt">
                                    <td style="text-align: left; padding-left: 40px;">
                                        <a href="<%#Eval("fdNaviLink") %>" target="_blank">
                                            <%#Eval("fdNaviTitle")%></a>
                                    </td>
                                    <td>
                                        <%#getTypeName((int)Eval("fdNaviType"))%>
                                    </td>
                                    <td>
                                        <a href="NavigationEdit.aspx?id=<%# Eval("fdNaviID")%>">修改</a> <a href="NavigationSort.aspx?type=up&id=<%# Eval("fdNaviID")%>">
                                            排前</a> <a href="NavigationSort.aspx?type=down&id=<%# Eval("fdNaviID")%>">排后</a><a
                                                href="NavigationDel.aspx?id=<%# Eval("fdNaviID")%>" onclick="return confirm('您确定要删除吗?')">
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
            <li>导航栏最多可支持二级导航</li>
        </ul>
    </div>
</asp:Content>
