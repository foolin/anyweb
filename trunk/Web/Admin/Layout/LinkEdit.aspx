<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="LinkEdit.aspx.cs" Inherits="Layout_LinkEdit" Title="修改连接" %>

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
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content">
        <div id="content">
            <div class="tableForm">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="15%" align="right">
                            链接类型：</td>
                        <td width="85%" align="left">
                            <asp:DropDownList ID="drpType" runat="server" onchange="typechange(this)">
                                <asp:ListItem Value="0" Text="文字链接"></asp:ListItem>
                                <asp:ListItem Value="1" Text="图片链接"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            链接名称：</td>
                        <td width="85%" align="left">
                            <asp:TextBox ID="txtLinkName" runat="server" Width="200" MaxLength="50" require="1" errmsg="请输入链接名称" ToolTip="最多50个字符"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            链接URL：</td>
                        <td>
                            <asp:TextBox ID="txtLinkUrl" runat="server" Width="200" MaxLength="200" require="1" errmsg="链接URL格式不正确" datatype="url" ToolTip="最多200个字符" Text="http://"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trupload" style="display:none;">
                        <td align="right">
                            链接图片：</td>
                        <td>
                            <asp:FileUpload ID="imgupload" runat="server" Width="275" />
                            <div>
                                <asp:Image ID="imgPhoto" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            链接排序：</td>
                        <td>
                            <asp:TextBox ID="txtLinkSort" runat="server" Width="50" require="1" errmsg="排序格式不正确" datatype="number" Text="0"></asp:TextBox> （必须为数字）
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 24px">
                            <asp:Button ID="btnEditLink" runat="server" Text="保存链接" OnClick="btnEditLink_Click" />
                            <a href="LinkList.aspx">取消</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    
    <script type="text/jscript">
        function typechange(obj)
        {   
            if(obj.value=='0')
            {
                document.getElementById("trupload").style.display="none";
            }
            else
            {
                document.getElementById("trupload").style.display="";
            }
        }
        
        typechange(document.getElementById("<%=drpType.ClientID %>"));
    </script>
    
</asp:Content>
