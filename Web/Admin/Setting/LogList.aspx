<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="LogList.aspx.cs" Inherits="Admin_Setting_LogList" Title="操作日志列表" %>
<%@ Register TagPrefix="cc1" Namespace="Studio.Web" Assembly="Studio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div id="navmenu">
        <dl>
            <dt>操作菜单</dt>
            <dd>
                <a href="/Admin/Content/ArticleList.aspx">清空日志</a></dd>
        </dl>
        <dl>
            <dt>使用帮助</dt>
            <dd>
                <ul>
                    <li>该列表显示所有用户的操作日志。</li>
                </ul>
            </dd>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    操作日志列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main_content">
        <div id="content">
            <div class="NewsList">
                <div>
                    选择操作用户：
                    <asp:DropDownList ID="drpUser" runat="server" DataTextField="UserName" DataValueField="UserAcc" OnSelectedIndexChanged="SelectUser" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <table width="100%" cellspacing="0" border="0">
                    <tr bgcolor="#e6f2ff">
                        <td>
                            <input type="checkbox" id="chkAll" onclick="SelectAll(this.checked)" /></td>
                        <td>
                            事件</td>
                        <td>
                            用户名</td>
                        <td>
                            操作IP</td>
                        <td>
                            时间</td>
                        <td>
                            操作</td>
                    </tr>
                    <asp:Repeater ID="repEventLog" runat="server">
                        <ItemTemplate>
                            <tr onmouseover="this.style.background='#E6F2FF';" onmouseout="this.style.background='#FFFFFF'">
                                <td>
                                    <input type="checkbox" name="ids" value='<%# Eval("EvenID") %>'></td>
                                <td>
                                    <%#Eval("EvenDesc")%>
                                </td>
                                <td>
                                    <%#Eval("EvenUserAcc") %>
                                </td>
                                <td>
                                    <%#Eval("EvenIP") %>
                                </td>
                                <td>
                                    <%#Eval("EvenAt")%>
                                </td>
                                <td>
                                    <a href="ArticleEdit.aspx?id=<%#Eval("EvenID") %>" title="删除该记录">删除</a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="7">
                            <input type="button" onclick="DeleteSelected()" value="批量删除" />
                            <input type="button" onclick="ClearLog()" value="清空记录" />
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
				alert("请先选择日志!");
				return;
			}
			if(!confirm("确定要把日志删除吗?")){
				return ;
			}
			var form1;
			form1 = document.createElement('form');
			form1.method = 'POST';
			form1.action = 'LogDel.aspx';
				
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
		
		
		function ClearLog()
		{
			if(!confirm("确定要清除全部日志吗?")){
				return ;
			}
			var form1;
			form1 = document.createElement('form');
			form1.method = 'POST';
			form1.action = 'LogClear.aspx?act=clear';
			document.body.insertBefore(form1);
			form1.submit();
		}
			
    </script>
</asp:Content>

