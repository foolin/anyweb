<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="MappingList.aspx.cs" Inherits="Admin_MappingList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
    <ul class="Opr">
        <li><a href="MappingAdd.aspx">添加映射</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                映射管理</h3>
        </div>
        <div class="mbd">
            <table>
                <thead>
                    <tr>
                        <th>
                            模版名称
                        </th>
                        <th>
                            访问路径
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="repMapping" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt">
                            <td style="text-align: left;">
                                <%#Eval("Template.fdTempName")%>
                            </td>
                            <td>
                                <%#Eval("fdMappPath")%>
                            </td>
                            <td>
                                <a href="MappingEdit.aspx?id=<%# Eval("fdMappID")%>">修改</a> <a href="MappingDel.aspx?id=<%# Eval("fdMappID")%>"
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
            <li></li>
        </ul>
    </div>
</asp:Content>

