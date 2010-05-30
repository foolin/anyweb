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
                        <th>
                            栏目图片
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
                                <a href="/column.aspx?id=<%#Eval("fdColuID") %>" target="_blank"><%#Eval("fdColuName")%></a>
                            </td>
                            <td>
                                <img width="100" height="65" alt="<%#Eval("fdColuName")%>" src="<%#Eval("fdColuPicture") %>" style="display:<%#(String)Eval("fdColuPicture")==""?"none":"" %>" />
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
                                        <a href="/column.aspx?id=<%#Eval("fdColuID") %>" target="_blank"><%#Eval("fdColuName")%></a>
                                    </td>
                                    <td>
                                        <img width="100" height="65" alt="<%#Eval("fdColuName")%>" src="<%#Eval("fdColuPicture") %>" style="display:<%#(String)Eval("fdColuPicture")==""?"none":"" %>" />
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
