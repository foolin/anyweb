<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ArticleCategoryList.aspx.cs" Inherits="ArticleCategoryList" Title="文章栏目管理" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">

<li>"文章栏目"为商城管理员根据需求添加的,区别于商城服务指南下各系统默认栏目!建议发布产品信息,注意事项等等相关产品的文章说明.</li>
                
            
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    文章栏目管理<span class="listadd">  <a href="ArticleCategoryHandle.aspx?mode=insert">添加文章栏目</a><span style="border-left:solid 1px #999999; padding:0px; background:url(./images/ico_add.gif) 5px 0px no-repeat; line-height:30px; padding-left:12px; margin-left:10px;"> <a href="SingerArticleEdit.aspx?mode=insert">添加单篇文章栏目</a></span></span> </h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                    
                        <thead>
                            <tr>
                                <th class="fst">
                                    栏目名称</th>
                                <th>
                                    创建时间</th>
                                    <th>
                                    栏目类型</th>
                                <th>
                                    文件名称</th>
                                <th class="end">
                                    操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repCategory" runat="server" DataSourceID="ods1">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                           <a href='<%#Eval("BackUrl") %>' target="_blank"><%#Eval("Name") %></a> 
                                        </td>
                                        <td>
                                            <%#Eval("CreateAt","{0:yyyy-MM-dd}") %>
                                        </td>
                                        <td><%#(int)Eval("Type")==1?"普通文章栏目":"单篇文章栏目" %></td>
                                        <td>
                                            <%#Eval("Path") %>
                                        </td> 
                                        <td>
                                            <a href="<%#GetUrl((int)Eval("Type"))%>?mode=update&cid=<%#Eval("ID")%> ">修改</a> <a href="<%#GetUrl((int)Eval("Type"))%>?mode=delete&cid=<%#Eval("ID")%>" onclick="javascript:return confirm('确定删除？')">删除</a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
               
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <asp:ObjectDataSource ID="ods1" runat="server" SelectMethod="GetArticleCategory" TypeName="Common.Agent.CategoryAgent" OnSelected="ods1_Selected">
    </asp:ObjectDataSource>
</asp:Content>


