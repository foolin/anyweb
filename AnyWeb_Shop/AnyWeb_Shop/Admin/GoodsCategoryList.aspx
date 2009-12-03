<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="GoodsCategoryList.aspx.cs" Inherits="GoodsCategoryList" Title="商品类别管理" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server"> 
 <li>商品类别为一级时，该类别将自动生成商城导航的栏目</li>
<li>系统允许建立两级类别，即一个类别下面可以开设子类别，如“显示器”下面可以设立“三星”和“联想”两个子类别 </li>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    商品类别管理 <span class="listadd"> <a href="GoodsCategorhandle.aspx?mode=insert">添加商品类别</a></span></h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                     
                        <thead>
                            <tr>
                                <th class="fst">
                                    商品类别名称</th>
                                <th>
                                    创建时间</th>
                                <th>
                                    文件名称</th>
                                <th class="end">
                                    操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repCategory" runat="server" DataSourceID="ods1" OnItemDataBound="repCategory_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                          <a href='<%#Eval("BackUrl") %>' target="_blank"> <%#Eval("Name") %></a>
                                        </td>
                                        <td>
                                            <%#Eval("CreateAt","{0:yyyy-MM-dd}") %>
                                        </td>
                                        <td>
                                            <%#Eval("Path") %>
                                        </td>
                                        <td>
                                            <a href="GoodsCategorhandle.aspx?mode=update&cid=<%#Eval("ID")%>">修改</a> <a href="GoodsCategorhandle.aspx?mode=delete&cid=<%#Eval("ID")%>" onclick="javascript:return confirm('删除此商品类别会将相关前台显示内容一并移除，确定删除？')">删除</a></td>
                                    </tr>
                                    <asp:Repeater ID="rep2" runat="server">
                                        <ItemTemplate>   
                                  
                                            <tr style="background-color:#f5f5f5; width:500px;">
                                                <td style="text-align: center;">
                                                   <a href='<%#Eval("BackUrl") %>' target="_blank"><%#Eval("Name") %></a> 
                                                </td>
                                                <td>
                                                    <%#Eval("CreateAt","{0:yyyy-MM-dd}") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Path") %>
                                                </td>
                                                <td>
                                                    <a href="GoodsCategorhandle.aspx?mode=update&cid=<%#Eval("ID")%>">修改</a> <a href="GoodsCategorhandle.aspx?mode=delete&cid=<%#Eval("ID")%>" onclick="javascript:return confirm('删除此商品类别会将相关前台显示内容一并移除，确定删除？')">删除</a></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
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
    <asp:ObjectDataSource ID="ods1" runat="server" SelectMethod="GetCategoryList" TypeName="Common.Agent.CategoryAgent" OnSelected="ods1_Selected">
        <SelectParameters>
            <asp:Parameter Type="Int32" DefaultValue="2" Name="type"/>
            <asp:ControlParameter ControlID="PN1" Name="PageSize" Type="int32" DefaultValue="20" PropertyName="pagesize" />
            <asp:ControlParameter Name="PageNo" ControlID="PN1" Type="int32" DefaultValue="1" PropertyName="pageindex" />
            <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
</asp:Content>

