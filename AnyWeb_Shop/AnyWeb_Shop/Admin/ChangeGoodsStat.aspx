<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ChangeGoodsStat.aspx.cs" Inherits="ChangeGoodsStat" Title="积分礼品兑换统计" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    积分礼品兑换统计</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <caption>
                            礼品名称：<asp:TextBox ID="txtName" runat="server"></asp:TextBox><asp:Button ID="btnSearch"  CssClass="button1" runat="server" Text="搜索" OnClick="btnSearch_Click" />
                        </caption>
                        <thead>
                            <tr>
                                 <th  class="fst">
                                   礼品编号</th>
                                <th>
                                    礼品名称</th>
                                      <th>
                                    兑换次数
                                </th>
                                <th>
                                    积分
                                </th>
                                <th class="end">
                                    市场价格
                                </th>
                              
                                  
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repChangeGoods" runat="server" DataSourceID="ods1">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                           <%#Eval("ID") %>
                                        </td>
                                        <td>
                                            <%#Eval("Name") %>
                                        </td>
                                        <td>
                                            <%#Eval( "Quantity" )%>
                                        </td>
                                        <td>
                                            <%#Eval("Score")%>
                                        </td>
                                        <td>
                                            <%#Eval("Price","{0:c}")%>
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
                <asp:ObjectDataSource ID="ods1" runat="server" SelectMethod="GetChangeGoodsStat" TypeName="Common.Agent.ChangeGoodsAgent" OnSelected="ods1_Selected" OnSelecting="ods1_Selecting">
                    <SelectParameters>
                         <asp:ControlParameter Name="pagesize" Type="int32" PropertyName="pageSize" ControlID="PN1" />
            <asp:ControlParameter Name="pageno" Type="int32" PropertyName="pageIndex" ControlID="PN1" />
                        <asp:Parameter Name="changename" Type="String" />
                        <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph2" Runat="Server">
</asp:Content>

