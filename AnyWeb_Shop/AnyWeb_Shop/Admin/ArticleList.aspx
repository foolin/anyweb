<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ArticleList.aspx.cs" Inherits="ArticleList" Title="文章管理"  Debug="true"  EnableViewState="false"%>

<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
<li>不得发布黄色、反动、迷信等违反国家有关法律法规的内容，并请遵守您企业对个人内容发布的有关规定，违者后果自负。</li>
           
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
<script type="text/javascript">
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
		
</script>
      <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    文章管理 <span class="listadd"><a href="ArticleEdit.aspx?mode=insert">添加文章</a></span></h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <caption>
                            文章类别：<asp:DropDownList ID="drpType" runat="server"  DataSourceID="ods4" DataTextField="Name" DataValueField="ID" OnDataBound="drpType_DataBound"></asp:DropDownList>
                            文章标题：<asp:TextBox ID="txtTitle" runat="server" CssClass="text"  MaxLength="50" ></asp:TextBox><asp:Button ID="btnSearch"  CssClass="button1" runat="server" Text="搜索" OnClick="btnSearch_Click" />
                        </caption>
                        <thead>
                            <tr>
                                <th class="fst">
                                   <input type="checkbox" onclick="SelectAll(this.checked)" title="点击全选" /></th>
                                <th >
                                   文章标题</th>
                                <th>
                                    创建时间</th>
                                <th>
                                    所属类别</th>
                                 <th>
                                    点击数</th>
                                <th>
                                    是否允许评论</th>
                                <th class="end">
                                    操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repCategory" runat="server" DataSourceID="ods3">
                                <ItemTemplate>
                                    <tr>
                                    <td><input type="checkbox" name="ids" value='<%#Eval("ID")%>' /></td>
                                        <td>
                                            <a href='<%#Eval("BackUrl")%>' target="_blank"><%#Eval("Title") %></a>
                                        </td>
                                        <td>
                                            <%#Eval("CreateAt","{0:yyyy-MM-dd}") %>
                                        </td>
                                        <td>
                                            <%#Eval( "OfCategory.Name" )%>
                                        </td>
                                        <td>
                                            <%#Eval("ClickCount") %>
                                        </td>
                                         <td>
                                             <asp:CheckBox ID="chkComm" runat="server" Checked='<%#(bool)Eval("IsComment")%>' Enabled="false"/>
                                        </td>
                                        <td>
                                            <a href="ArticleEdit.aspx?mode=update&aid=<%#Eval("ID")%>">修改文章</a> <a href="ArticleEdit.aspx?mode=select&aid=<%#Eval("ID")%>">查看文章</a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div class="iPagination">
                        <cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="18">
                        </cc1:PageNaver>
                    </div>
                   <div class="iSubmit">
                        <asp:Button ID="btnDel" runat="server" CssClass="submit" Text="批量删除" OnClick="btnDel_Click" />
                    </div>   
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
   <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetArticleList" TypeName="Common.Agent.ArticleAgent" OnSelected="ods3_Selected" OnSelecting="ods3_Selecting" >
                        <SelectParameters>
                            <asp:ControlParameter ControlID="PN1" Name="pageSize" PropertyName="pagesize"  Type="Int32" />
                            <asp:ControlParameter ControlID="PN1" Name="pageNo" PropertyName="pageindex" Type="Int32" />
                            <asp:QueryStringParameter  Name="categoryId" Type="Int32" QueryStringField="cid" DefaultValue="0"/>
                            <asp:Parameter Name="title" Type="string"  />
                            <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ods4" runat="server" SelectMethod="GetArticleType" TypeName="Common.Agent.CategoryAgent">
                    </asp:ObjectDataSource>
                    
                    
                    
            
</asp:Content>

