<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="HelpTypeList.aspx.cs" Inherits="Admin_HelpTypeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="HelpTypeAdd.aspx">添加帮助分类</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                帮助分类</h3>
        </div>
        <div class="mbd">
            <table>
                <thead>
                    <tr>
                        <th>
                            编号
                        </th>
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
                            <td>
                                <%#Eval("fdTypeID")%>
                            </td>
                            <td>
                                <%#Eval("fdTypeName")%>
                            </td>
                            <td>
                                <a href="HelpTypeEdit.aspx?id=<%# Eval("fdTypeID")%>">修改</a> <a href="HelpTypeSort.aspx?type=up&id=<%# Eval("fdTypeID")%>">
                                    排前</a> <a href="HelpTypeSort.aspx?type=down&id=<%# Eval("fdTypeID")%>">排后</a>
                                <a href="HelpTypeDel.aspx?id=<%# Eval("fdTypeID")%>" onclick="return confirm('您确定要删除吗?')">
                                    删除</a>
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
            <li>该页显示帮助分类列表，可使用排前和排后对分类进行排序</li>
        </ul>
    </div>
</asp:Content>
