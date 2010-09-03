<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="AdminList.aspx.cs" Inherits="Admin_AdminList" Title="用户管理"  Debug="true"  EnableViewState="false"%>

<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
<li>不得发布黄色、反动、迷信等违反国家有关法律法规的内容，并请遵守您企业对个人内容发布的有关规定，违者后果自负。</li>
           
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
      <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    用户管理 <span class="listadd"><a href="AdminEdit.aspx?mode=insert">添加用户</a></span></h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <thead>
                            <tr>
                                <th >
                                    账号</th>
                                <th>
                                    名称</th>
                                <th class="end">
                                    操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repAdmins" runat="server" DataSourceID="ods3">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%#Eval("AdminAcc") %>
                                        </td>
                                        <td>
                                            <%#Eval( "AdminName" )%>
                                        </td>
                                        <td>
                                            <a href="AdminEdit.aspx?mode=update&aid=<%#Eval("ID")%>">修改</a> <a href="AdminEdit.aspx?mode=delete&aid=<%#Eval("ID")%>" onclick="return confirm('您确定要删除吗?')">删除</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div class="iPagination">
                        <cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="18">
                        </cc1:PageNaver>
                    </div>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
   <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetAdmins" TypeName="Common.Agent.AdminAgent" OnSelected="ods3_Selected" >
                        <SelectParameters>
                            <asp:ControlParameter ControlID="PN1" Name="pageSize" PropertyName="pagesize"  Type="Int32" />
                            <asp:ControlParameter ControlID="PN1" Name="pageNo" PropertyName="pageindex" Type="Int32" />
                            <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    
                    
            
</asp:Content>

