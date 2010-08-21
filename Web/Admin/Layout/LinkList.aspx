<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="LinkList.aspx.cs" Inherits="Layout_LinkList" Title="链接列表" %>

<%@ Register TagPrefix="cc1" Namespace="Studio.Web" Assembly="Studio" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    链接列表
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="navmenu">
        <dl>
            <dt>操作菜单</dt>
            <dd>
                <a href="/Admin/Layout/LinkAdd.aspx">添加链接</a></dd>
            <dd>
                <a href="/Admin/Layout/LinkList.aspx">链接列表</a></dd>
        </dl>
        <dl>
            <dt>使用帮助</dt>
            <dd>
                <ul>
                    <li>友情链接按序号从小到大排序</li>
                </ul>
            </dd>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content">
        <div id="content">
            <div class="NewsList">
                <div>
                    分类：
                    <asp:DropDownList ID="type" runat="server" onchange="searchLink()">
                        <asp:ListItem Text="政府部门网站" Value="1"></asp:ListItem>
                        <asp:ListItem Text="省外供销网站" Value="2"></asp:ListItem>
                        <asp:ListItem Text="广州市供销合作社" Value="3"></asp:ListItem>
                        <asp:ListItem Text="社有企业网站" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <table width="100%" cellspacing="0" border="0">
                    <tr bgcolor="#E6F2FF">
                        <td>
                            名称</td>
                        <td>
                            类别</td>
                        <td>
                            排序</td>
                        <td>
                            操作</td>
                    </tr>
                    <asp:Repeater ID="repLink" runat="server">
                        <ItemTemplate>
                            <tr onmouseover="this.style.background='#E6F2FF';" onmouseout="this.style.background='#FFFFFF'" style="height:60px;">
                                <td>
                                    <a href="<%#Eval("LinkUrl") %>" target="_blank"><%#Eval("LinkName")%></a>
                                </td>
                                <td>
                                    <%#getCateName((int)Eval("LinkCateID")) %>
                                </td>
                                <td>
                                    <%#Eval("LinkOrder") %>
                                </td>
                                <td>
                                    <a href="LinkEdit.aspx?id=<%#Eval("LinkID") %>" title="修改友情链接">修改</a> <a href="LinkDel.aspx?id=<%#Eval("LinkID") %>"
                                        onclick="return confirm('确定要删除友情链接？')" title="冻结用户">删除</a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div class="pagebar">
                    <cc1:PageNaver ID="PN1" runat="server" StyleID="1" PageSize="10">
                    </cc1:PageNaver>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function searchLink()
        {
            var url="?type="+document.getElementById("<%=type.ClientID %>").value;
            window.location=url;
        }
    </script>
</asp:Content>
