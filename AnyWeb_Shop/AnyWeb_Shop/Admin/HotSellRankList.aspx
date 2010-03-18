<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="HotSellRankList.aspx.cs" Inherits="Admin_HotSellRankList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
 <li> 添加畅销商品请到商品列表进行操作</li>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph2" Runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    畅销商品<span class="listadd"><a href="GoodsList.aspx">添加畅销商品</a></span></h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                <table class="iList iArticle" id="tbGoods">
                    <thead>
                        <tr>
                            <th class="fst">
                                <input type="checkbox" onclick="SelectAll(this.checked)" title="点击全选" />
                            </th>
                            <th style="width: 140px; line-height: 23px;">
                                商品名称
                            </th>
                            <th>
                                商品图片
                            </th>
                            <th>
                                商品价格
                            </th>
                            <th>
                                市场价格
                            </th>
                            <th>
                                状态
                            </th>
                            <th>
                                排序
                            </th>
                            <th class="end">
                                操作
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="repCategory" runat="server" DataSourceID="ods3">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <input type="checkbox" name="ids" value='<%#Eval("ID")%>' title="点击选择" />
                                    </td>
                                    <td style="width: 140px; line-height: 23px;">
                                        <a href='/Good.aspx?gid=<%#Eval( "HotSellID" )%>' target="_blank">
                                            <%#Eval( "OfGoods.GoodsName" )%>
                                        </a>
                                    </td>
                                    <td>
                                        <img src='<%#(string)Eval( "OfGoods.image" )=="" ? "../images/wait.jpg":(string)Eval( "OfGoods.image" ) %>'
                                            alt="<%#Eval("OfGoods.GoodsName") %>" width="50px" />
                                    </td>
                                    <td>
                                        <%#Eval("OfGoods.Price", "{0:c}")%>
                                    </td>
                                    <td>
                                        <%#Eval("OfGoods.MarketPrice", "{0:c}")%>
                                    </td>
                                    <td>
                                    <td>
                                        <%# CheckStatus((int)Eval("OfGoods.Status"))%>
                                    </td>
                                    <td>
                                        <%#Eval("Sort") %>
                                    </td>
                                    <td>
                                        <a href="GoodsEdit.aspx?mode=update&gid=<%#Eval("HotSellID")%>">修改</a>
                                        <a href="GoodsEdit.aspx?mode=select&gid=<%#Eval("GoodsID")%>">查看详情</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div class="iSubmit">               
                </div>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>

    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetHotSellRankList" TypeName="Common.Agent.HotSellRankAgent">
        <SelectParameters>
            <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

