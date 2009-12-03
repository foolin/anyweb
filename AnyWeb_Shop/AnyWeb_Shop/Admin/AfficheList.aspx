<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="AfficheList.aspx.cs" Inherits="AfficheList" Title="系统公告管理" %>

<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
  
 <li>系统公告是发布系统信息的一个平台</li>
          
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    系统公告管理 <span class="listadd"> <a href="AfficheEdit.aspx?mode=insert">添加系统公告</a></span>
                </h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <thead>
                            <tr>
                                <th class="fst">
                                    公告标题</th>    
                                <th>
                                    创建时间</th>
                                <th class="end">
                                    操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rep1" runat="server" DataSourceID="ods3">
                                <ItemTemplate>
                                      <tr>
                                        <td>
                                        <a href='http://<%=ShopInfo.ShopDomain %>/a/<%#Eval("ID") %>.aspx' target="_blank"> <%#Eval("Title") %></a>
                                        </td>
                                       
                                        <td>
                                            <%#Eval("CreateAt","{0:yyyy-MM-dd}") %>
                                        </td>
                                        <td>
                                           <a href='AfficheEdit.aspx?affid=<%#Eval("ID") %>&mode=update'>修改 </a> <a href='AfficheEdit.aspx?affid=<%#Eval("ID") %>&mode=delete' onclick="javascript:return confirm('确定删除？');">删除</a>
                                        </td>
                                      </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div class="iPagination" >
                        <cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="18">
                        </cc1:PageNaver>
                    </div>
                </form>
                <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetAfficheList" TypeName="Common.Agent.AfficheAgent" OnSelected="ods3_Selected">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="PN1" Type="Int32" Name="pagesize" PropertyName="pagesize" />
                        <asp:ControlParameter ControlID="PN1" Type="Int32" Name="pageno" PropertyName="pageindex" />
                        <asp:Parameter Name="memberID" Type="Int32" DefaultValue="0" />
                        <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
