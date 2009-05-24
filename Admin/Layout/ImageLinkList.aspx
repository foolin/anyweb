<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ImageLinkList.aspx.cs" Inherits="Layout_ImageLinkList" Title="图片链接列表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="navmenu">
        <dl>
            <dt>操作菜单</dt>
            <dd>
                <a href="/Layout/LinkAdd.aspx">添加连接</a></dd>
            <dd>
                <a href="/Layout/LinkList.aspx">文字链接列表</a></dd>
            <dd>
                <a href="/Layout/ImageLinkList.aspx">图片链接列表</a></dd>
        </dl>
        <dl>
            <dt>使用帮助</dt>
            <dd>
                <ul>
                    <li>如何管理友情链接？</li>
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
                            名称</td>
                        <td>
                            图片</td>
                        <td>
                            URL</td>
                        <td>
                            排序</td>
                        <td>
                            操作</td>
                    </tr>
                    <asp:Repeater ID="imgLink" runat="server">
                        <ItemTemplate>
                            <tr onmouseover="this.style.background='#E6F2FF';" onmouseout="this.style.background='#FFFFFF'">
                                <td>
                                    <%#Eval("LinkName")%>
                                </td>
                                <td>
                                    <a href="<%#Eval("LinkUrl") %>" target="_blank">
                                        <img src="<%#Eval("LinkImage")%>" class="img" alt="<%#Eval("LinkName")%>" /></a></td>
                                <td>
                                    <%#Eval("LinkUrl") %>
                                </td>
                                <td>
                                    <%#Eval("LinkSort") %>
                                </td>
                                <td>
                                    <a href="LinkEdit.aspx?id=<%#Eval("LinkID") %>" title="修改友情链接">修改</a> <a href="LinkDel.aspx?id=<%#Eval("LinkID") %>"
                                        onclick="return confirm('确定要删除友情链接？')" title="冻结用户">删除</a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
