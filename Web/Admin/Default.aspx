<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="后台首页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content">
        <div id="content">
            <asp:Label ID="LoginUserTips" runat="server" Text="Label" ForeColor="Green" Font-Size="14px" Height="25px"></asp:Label>
            <div class="NewsList">
                <table width="100%" cellspacing="0" border="0">
                    <tr bgcolor="#E6F2FF">
                        <td width="4%">
                            <input type="checkbox" name="GroupID" value="" /></td>
                        <td width="3%">
                            ID</td>
                        <td width="8%">
                            类别</td>
                        <td width="45%">
                            标题</td>
                        <td width="5%">
                            操作</td>
                        <td width="5%">
                            审核</td>
                        <td width="5%">
                            置顶</td>
                        <td width="5%">
                            删除</td>
                    </tr>
                    <tr onmouseover="this.style.background='#E6F2FF';" onmouseout="this.style.background='#FFFFFF'">
                        <td>
                            <input type="checkbox" name="GroupID" value="17" />
                        </td>
                        <td>
                            <a href="#" target="_blank">17</a>
                        </td>
                        <td>
                            <a href="#">本站公告</a></td>
                        <td>
                            <a href="#" target="_blank">《南方日报》首席记者梅志清莅临广大！</a></td>
                        <td>
                            <a href="#">编辑</a></td>
                        <td>
                            <a href="#" title="点击取消通过审核">已审</a></td>
                        <td>
                            <a href="#" title="点击置顶">否</a></td>
                        <td>
                            <a href="#" onclick="return confirm('删除将不能恢复！\n\n是否真的删除？')" title="删除新闻">删除</a></td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            <input type="button" value="全选" />
                            <input type="button" value="反选" />
                            &nbsp;&nbsp;
                            <input type="button" value="审核" />
                            <input type="button" value="取消审核" />
                            &nbsp;&nbsp;
                            <input type="button" value="顶置" />
                            <input type="button" value="取消顶置" />
                            &nbsp;&nbsp;
                            <input type="button" value="删除" />
                        </td>
                    </tr>
                </table>
                <div class="pagebar">
                    [<strong>1</strong>] ...[<strong>1</strong>]</div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="navmenu">
        <dl>
            <dt><a href="#">控制面板</a></dt>
            <dd>
                <a href="Default.aspx">管理首页</a></dd>
            <dd>
                <a href="Setting/UserInfo.aspx">修改密码</a></dd>
            <dd>
                <a href="#" style="cursor: help;">帮助文档</a></dd>
            <dd>
                <a href="Logout.aspx" target="_top">退出管理</a></dd>
        </dl>
    </div>
</asp:Content>
