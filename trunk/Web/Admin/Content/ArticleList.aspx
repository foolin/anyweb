<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="ArticleList.aspx.cs" Inherits="Content_ArticleList" Title="文章列表" %>

<%@ Register TagPrefix="cc1" Namespace="Studio.Web" Assembly="Studio" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    文档管理
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="navmenu">
        <dl>
            <dt>操作菜单</dt>
            <dd>
                <a href="/Admin/Content/ArticleAdd.aspx">添加文档</a></dd>
            <dd>
                <a href="/Admin/Content/ArticleList.aspx">文档列表</a></dd>
            <dd>
                <a href="/Admin/Content/ArticleRecycle.aspx">文档回收站</a></dd>
        </dl>
        <dl>
            <dt>使用帮助</dt>
            <dd>
                <ul>
                    <li>添加文章内容。</li>
                    <li>文章排序数字越大文章越靠前。</li>
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
                    搜索：<asp:DropDownList ID="drpCoulumn" runat="server" DataTextField="ColuName" DataValueField="ColuID">
                    </asp:DropDownList>
                    <asp:DropDownList ID="drpUser" runat="server" DataTextField="UserName" DataValueField="UserID">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtTitle" runat="server" ToolTip="文章标题"></asp:TextBox>
                    <input type="button" value="搜 索" id="btnsearch" onclick="return searchArticle();" />
                </div>
                <table width="100%" cellspacing="0" border="0">
                    <tr bgcolor="#E6F2FF">
                        <td>
                            <input type="checkbox" id="chkAll" onclick="SelectAll(this.checked)" /></td>
                        <td>
                            标题</td>
                        <td>
                            栏目</td>
                        <td>
                            用户名</td>
                        <td>
                            创建时间</td>
                        <td>
                            操作</td>
                    </tr>
                    <asp:Repeater ID="repArticle" runat="server">
                        <ItemTemplate>
                            <tr onmouseover="this.style.background='#E6F2FF';" onmouseout="this.style.background='#FFFFFF'">
                                <td>
                                    <input type="checkbox" name="ids" value='<%# Eval("ArtiID") %>'></td>
                                <td>
                                    <%#Eval("ArtiTitle")%>
                                </td>
                                <td>
                                    <%#Eval("ArtiColumnName") %>
                                </td>
                                <td>
                                    <%#Eval("ArtiUserName") %>
                                </td>
                                <td>
                                    <%#Eval("ArtiCreateAt")%>
                                </td>
                                <td>
                                    <a href="ArticleEdit.aspx?id=<%#Eval("ArtiID") %>" title="修改栏目信息">修改</a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="7">
                            <input type="button" onclick="DeleteSelected()" value="批量删除" />
                            <input type="button" onclick="MoveSelected()" value="批量移到栏目" />
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
        function searchArticle()
        {
            var url="?c="+document.getElementById("<%=drpCoulumn.ClientID %>").value;
            url+="&u="+document.getElementById("<%=drpUser.ClientID %>").value;
            url+="&t="+document.getElementById("<%=txtTitle.ClientID %>").value;
            window.location=url;
        }
        
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
				alert("请先选择文章!");
				return;
			}
			if(!confirm("确定要把文章移到回收站吗?")){
				return ;
			}
			var form1;
			form1 = document.createElement('form');
			form1.method = 'POST';
			form1.action = 'ArticleDel.aspx';
				
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
			
		function MoveSelected()
		{
			if( !CheckSeleted())
			{
				alert("请先选择文章!");
				return;
			}
			var form1;
			form1 = document.createElement('form');
			form1.method = 'POST';
			form1.action = 'ArticleMove.aspx';
			form1.submit();
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
