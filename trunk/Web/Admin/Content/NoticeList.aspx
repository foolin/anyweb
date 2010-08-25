<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="NoticeList.aspx.cs" Inherits="Admin_Content_NoticeList" Title="流动通知管理" %>
<%@ Register TagPrefix="cc1" Namespace="Studio.Web" Assembly="Studio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div id="navmenu">
        <dl>
            <dt>操作菜单</dt>
            <dd>
                <a href="/Admin/Content/ArticleList.aspx">添加通知</a></dd>
            <dd>
                <a href="/Admin/Content/NoticeList.aspx">通知列表</a></dd>
        </dl>
        <dl>
            <dt>使用帮助</dt>
            <dd>
                <ul>
                    <li>排序数字越大通知越靠前。</li>
                </ul>
            </dd>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    流动通知管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main_content">
        <div id="content">
            <div class="NewsList">
                <table width="100%" cellspacing="0" border="0">
                    <tr bgcolor="#E6F2FF">
                        <td>
                            <input type="checkbox" id="chkAll" onclick="SelectAll(this.checked)" /></td>
                        <td>
                            标题</td>
                        <td>
                            创建时间</td>
                        <td>
                            操作</td>
                    </tr>
                    <asp:Repeater ID="repNotice" runat="server">
                        <ItemTemplate>
                            <tr onmouseover="this.style.background='#E6F2FF';" onmouseout="this.style.background='#FFFFFF'">
                                <td>
                                    <input type="checkbox" name="ids" value='<%# Eval("NotiID") %>'></td>
                                <td>
                                    <%#Eval("Title")%>
                                </td>
                                <td>
                                    <%#Eval("NotiCreateAt")%>
                                </td>
                                <td>
                                    <a href="NoticeEdit.aspx?id=<%#Eval("NotiID") %>" title="修改通知信息">修改</a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="7">
                            <input type="button" onclick="DeleteSelected()" value="批量删除" />
                        </td>
                    </tr>
                </table>
                <div class="pagebar">
                    <cc1:PageNaver ID="PN1" runat="server" StyleID="1">
                    </cc1:PageNaver>
                </div>
            </div>
        </div>
    </div>
    <script type="text/jscript">
        function SelectAll(v)
		{
			var e_all = document.all.tags('INPUT');
			for(var i=0;i<e_all.length;i++)
			{
				if (e_all[i].tagName=="INPUT")
				{
					if ((e_all[i].type) && (e_all[i].name))
					{
						if ((e_all[i].type=="checkbox") && (e_all[i].name!="boxAll"))
						{
							e_all[i].checked = v;
						}
					}
				}
			}
		}		
		function CheckSeleted()
		{
			var e_all = document.all.tags('INPUT');
			for(var i=0;i<e_all.length;i++)
			{
				if (e_all[i].tagName=="INPUT")
				{
					if ((e_all[i].type) && (e_all[i].name))
					{
						if ((e_all[i].type=="checkbox") && (e_all[i].name!="boxAll"))
						{
							if( e_all[i].checked)	return true;
						}
					}
				}
			}
			return false;
		}
        function DeleteSelected()
		{
			if( !CheckSeleted())
			{
				alert("请先选择流动通知!");
				return;
			}
			if(!confirm("确定要把删除流动通知吗?")){
				return ;
			}
			var form1;
			form1 = document.createElement('form');
			form1.method = 'POST';
			form1.action = 'NoticeDel.aspx';
				
			var e_all = document.all.tags('INPUT');
			for(var i=0;i<e_all.length;i++)
			{
				if (e_all[i].tagName=="INPUT")
				{
					if ((e_all[i].type) && (e_all[i].name))
					{
						if ((e_all[i].type=="checkbox") && (e_all[i].name!="boxAll"))
						{
							if( e_all[i].checked)
							{					
								input1 = document.createElement('input');
								input1.type = 'hidden';
								input1.name = 'id';
								input1.value = e_all[i].value;
								form1.insertBefore(input1);
							}
						}
					}
				}
			}
			document.body.insertBefore(form1);
			form1.submit();
		}
    </script>
</asp:Content>

