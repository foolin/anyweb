<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ChangeGoodsList.aspx.cs" Inherits="ChangeGoodsList" Title="积分礼品管理" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph2" Runat="Server">
<li>兑换商品</li>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    积分礼品列表<span class="listadd"><a href="ChangeGoodsEidt.aspx?mode=insert">添加积分礼品</a></span></h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                    
                        <thead>
                            <tr>
                                <th class="fst">
                                   商品名称</th>
                                <th>
                                    商品图片</th>
                                <th>
                                    价格</th>
                                 <th>
                                    兑换积分</th>
                                <th>
                                    起始时间</th>
                                 <th>
                                    截止时间</th>
                              
                                 <th class="end">
                                    操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repCategory" runat="server" DataSourceID="ods1">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                           <a href='http://<%=ShopInfo.ShopDomain%>/Score/<%#Eval("ID")%>.aspx ' target="_blank"><%#Eval("Name") %></a> 
                                        </td>
                                        <td>
                                            <img src='<%#Eval("Image") %>' alt='<%#Eval("Name") %>' />
                                        </td>
                                        <td><%#Eval("Price","{0:c}") %></td>
                                        <td><%#Eval("Score") %></td>
                                        <td>
                                            <%#Eval("StartTime","{0:yyyy-MM-dd}") %>
                                        </td> 
                                         <td>
                                            <%#Eval( "EndTime" , "{0:yyyy-MM-dd}" )%>
                                        </td> 
                                        <td>
                                            <a href="ChangeGoodsEidt.aspx?cid=<%#Eval("ID") %>&mode=update">修改</a> <a href="ChangeGoodsEidt.aspx?cid=<%#Eval("ID") %>&mode=delete" onclick="javascript:return confirm('确定删除？');">删除</a></td>
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
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <asp:ObjectDataSource ID="ods1" runat="server" SelectMethod="GetChangeGoodsAll" TypeName="Common.Agent.ChangeGoodsAgent" OnSelected="ods1_Selected" >
        <SelectParameters>
            <asp:ControlParameter Name="pagesize" Type="int32" PropertyName="pageSize" ControlID="PN1" />
            <asp:ControlParameter Name="pageno" Type="int32" PropertyName="pageIndex" ControlID="PN1" />
            <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>


