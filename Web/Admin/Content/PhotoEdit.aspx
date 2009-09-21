<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="PhotoEdit.aspx.cs" Inherits="Admin_Content_PhotoEdit" Title="修改图片信息" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div id="navmenu">
        <dl>
            <dt>操作菜单</dt>
            <dd>
                <a href="/Admin/Content/PhotoAdd.aspx">上传图片</a></dd>
            <dd>
                <a href="/Admin/Content/PhotoList.aspx">图片列表</a></dd>
        </dl>
        <dl>
            <dt>使用帮助</dt>
            <dd>
                <ul>
                    <li>首页显示前8张图片</li>
                    <li>图片排序数字越大图片越靠前。</li>
                    <li>图片删除将不能恢复。</li>
                </ul>
            </dd>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    编辑图片
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main_content">
        <div id="content">
            <div class="tableForm">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="15%" align="right">
                            图片名称：</td>
                        <td width="85%" align="left">
                            <asp:TextBox ID="txtPhotName" runat="server" Width="200" MaxLength="50" require="1" errmsg="请输入图片名称" ToolTip="最多50个字符"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            连接地址：</td>
                        <td>
                            <asp:TextBox ID="txtPhotUrl" runat="server" Width="400" MaxLength="200" require="1" errmsg="请输入图片描述" ToolTip="最多200个字符" Text=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trupload">
                        <td>
                            上传图片：
                        </td>
                        <td colspan="2" align="center">
                            <asp:FileUpload ID="imgupload" runat="server" Width="275" />
                            <div>
                                <asp:Image ID="imgPhoto" Width="600" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            图片排序：</td>
                        <td>
                            <asp:TextBox ID="txtPhotSort" runat="server" Width="50" require="1" errmsg="排序格式不正确" datatype="number" Text="0"></asp:TextBox> （必须为数字）
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnEditPhoto" runat="server" Text="修改图片" OnClick="btnEidtPhoto_Click" />
                            <input type="button" onclick="window.top.location.href='PhotoList.aspx';" value="取消" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

