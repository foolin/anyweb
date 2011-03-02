<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="HelpList.aspx.cs" Inherits="Admin_HelpList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="HelpAdd.aspx?tid=<%=QS("tid")%>">添加帮助</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                帮助管理</h3>
        </div>
        <div class="fi filter">
            分类：<asp:DropDownList ID="compType" onchange="window.location='HelpList.aspx?tid='+this.value"
                DataTextField="fdTypeName" DataValueField="fdTypeID" runat="server">
            </asp:DropDownList>
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
                            <td>
                                <%#Eval("fdHelpQuestion")%>
                            </td>
                            <td>
                                <a href="HelpEdit.aspx?id=<%# Eval("fdHelpID")%>">修改</a>
                                <% if (QS("tid") != "" && QS("key") == "")
                                   { %>
                                <a href="HelpSort.aspx?type=up&id=<%# Eval("fdHelpID")%>">排前</a> <a href="HelpSort.aspx?type=down&id=<%# Eval("fdHelpID")%>">
                                    排后</a>
                                <%} %>
                                <a href="HelpDel.aspx?id=<%# Eval("fdHelpID")%>" onclick="return confirm('您确定要删除吗?')">
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
            <li>该页显示所有帮助列表，可针对某个分类使用排前和排后进行排序操作</li>
        </ul>
    </div>
</asp:Content>
