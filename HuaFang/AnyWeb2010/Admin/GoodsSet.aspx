<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="GoodsSet.aspx.cs" Inherits="Admin_GoodsSet" Title="商品促销" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                设置商品促销时间</h3>
        </div>
        <div class="mbd">
            <table>
                <thead>
                    <tr>
                        <th>
                            编号
                        </th>
                        <th>
                            名称
                        </th>
                        <th>
                            价格
                        </th>
                        <th>
                            促销价
                        </th>
                        <th>
                            促销开始时间
                        </th>
                        <th>
                            促销结束时间
                        </th>
                        <th>
                            库存
                        </th>
                        <th>
                            点击/评论/评分
                        </th>
                        <th class="end">
                            状态
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="repGoodses" runat="server">
                    <ItemTemplate>
                        <tr align="center" class="editalt">
                            <td style="width: 30px;">
                                <asp:Label ID="lblGoodsId" Text='<%# Eval("fdGoodID")%>' runat="server"></asp:Label>
                            </td>
                            <td>
                                <%# Eval("fdGoodName")%>
                            </td>
                            <td>
                                <%# Eval("fdGoodSalePrice", "{0:0.00}")%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPromPrice" CssClass="text" Width="60px" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPromStartAt" CssClass="text" Width="70px" onclick="setday(this)"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPromEndAt" CssClass="text" Width="70px" onclick="setday(this)"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <%# Eval("fdGoodStockNum")%>
                            </td>
                            <td>
                                <%# Eval("fdGoodClickCount")%>/<%# Eval("fdGoodCommentCount")%>/<%# Eval("fdGoodScoreAverage","{0:0.0}")%>
                            </td>
                            <td style="width: 30px;">
                                <%# Eval("fdGoodStatus").ToString() == "1" ? "正常" : "下架"%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="mft">
        </div>
        <div class="fi fiBtns">
            <asp:Button ID="btnSave" CssClass="submit" OnClick="btnSave_Click" runat="server"
                Text="保存" />
            <asp:HyperLink ID="linkRefer" runat="server">返回</asp:HyperLink>
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>设置促销时需要设置每个商品的促销价格和时间</li>
            <li>请确保输入的数据的准确性。</li>
        </ul>
    </div>
</asp:Content>
