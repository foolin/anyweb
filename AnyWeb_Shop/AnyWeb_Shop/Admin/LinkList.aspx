<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="LinkList.aspx.cs" Inherits="LinkList" Title="链接管理" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
   
 <li> 在此添加友情链接，其会在链接组件里显示出来。</li>  
         
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    链接管理 <span class="listadd"><a href="LinkEdit.aspx?mode=insert">添加链接</a></span>
                </h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <thead>
                            <tr>
                                <td class="fst">
                                    链接名称
                                </td>
                                <td>
                                    链接图片
                                </td>
                                
                                <td>
                                    链接地址
                                </td>
                                <td>
                                    创建时间
                                </td>
                                <td class="end">
                                    操作</td>
                            </tr>
                        </thead>
                        <asp:Repeater ID="rep1" runat="server" DataSourceID="ods3">
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td>
                                        <%#Eval("Name") %>
                                        </td>
                                         <td>
                                        <img src='<%#Eval("Image") %>' alt=""  style="display:<%#(string)Eval("Image")==""? "none":"block" %>; width:38px;"/>
                                        </td>
                                       
                                         <td>
                                        <%#Eval( "LinkUrl" )%>
                                        </td> 
                                         <td>
                                        <%#Eval("CreateAt","{0:yyyy-MM-dd}") %>
                                        </td>
                                        <td>
                                        <a href="LinkEdit.aspx?lid=<%#Eval("ID")%>&mode=update">修改</a> <a href="LinkEdit.aspx?lid=<%#Eval("ID")%>&mode=delete" onclick="javascript:return confirm('确定删除？');">删除</a>
                                        </td>
                                    </tr>
                                </tbody>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div class="iPagination">
                        <cc1:pagenaver id="PN1" styleid="2" runat="server" pagesize="18">
                        </cc1:pagenaver>
                    </div>
                </form>
                <asp:ObjectDataSource ID="ods3" runat="server" DataObjectTypeName="Common.Common.Link"  SelectMethod="GetLinkList2" TypeName="Common.Agent.LinkAgent" OnSelected="ods3_Selected">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="PN1" Name="pagesize" PropertyName="pagesize"  Type="int32"/>
                        <asp:ControlParameter ControlID="PN1" Name="pageno" PropertyName="pageindex"  Type="int32"/>
                        <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
