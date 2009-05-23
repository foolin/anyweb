<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ColumnList.aspx.cs" Inherits="Content_ColumnList" Title="栏目列表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="navmenu">
        <dl>
            <dt>操作菜单</dt>
            <dd>
                <a href="/Content/ColumnAdd.aspx">添加栏目</a></dd>
            <dd>
                <a href="/Content/ColumnList.aspx">栏目列表</a></dd>
        </dl>
        <dl>
            <dt>使用帮助</dt>
            <dd>
                <ul>
                    <li>文章栏目列表。</li>
                    <li>删除文章栏目时将同时删除子栏目，请确认该栏目下没有文章，否则将删除失败。</li>
                </ul>
            </dd>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content">
        <div id="content">
            <div class="NewsList">
                <table width="100%" cellspacing="0" border="0">
                    <tr bgcolor="#E6F2FF">
                        <td>
                            栏目名称</td>
                        <td>
                            栏目描述</td>
                        <td>
                            创建时间</td>
                        <td>
                            操作</td>
                    </tr>
                    <asp:Repeater ID="repColumn" runat="server" OnItemDataBound="repColumn_ItemDataBound">
                        <ItemTemplate>
                            <tr onmouseover="this.style.background='#E6F2FF';" onmouseout="this.style.background='#FFFFFF'">
                                <td>
                                    <%#Eval("ColuName")%>
                                </td>
                                <td>
                                    <%#Studio.Web.WebAgent.GetLeft((String)Eval("ColuDesc"),20) %>
                                </td>
                                <td>
                                    <%#Eval("ColuCreateAt")%>
                                </td>
                                <td>
                                    <a href="ColumnEdit.aspx?id=<%#Eval("ColuID") %>" title="修改栏目信息">修改</a> <a href="ColumnDel.aspx?id=<%#Eval("ColuID") %>"
                                        onclick="return confirm('确定要删除该栏目？')" title="删除栏目">删除</a></td>
                            </tr>
                            <asp:Repeater ID="repChildren" runat="server">
                                <ItemTemplate>
                                    <tr onmouseover="this.style.background='#E6F2FF';" onmouseout="this.style.background='#FFFFFF'">
                                        <td>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("ColuName")%>
                                        </td>
                                        <td>
                                            <%#Studio.Web.WebAgent.GetLeft((String)Eval("ColuDesc"),20) %>
                                        </td>
                                        <td>
                                            <%#Eval("ColuCreateAt")%>
                                        </td>
                                        <td>
                                            <a href="ColumnEdit.aspx?id=<%#Eval("ColuID") %>" title="修改栏目信息">修改</a> <a href="ColumnDel.aspx?id=<%#Eval("ColuID") %>"
                                                onclick="return confirm('确定要删除该栏目？')" title="删除栏目">删除</a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
