<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="OrderDetails.aspx.cs" Inherits="Admin_OrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="pbd pEdit">
        <div class="part pt1 ptSidebar">
            <h2 class="PageTitle">
                订单明细</h2>
            <ul class="Help">
                <li></li>
            </ul>
        </div>
        <div class="part pt2">
        </div>
        <div class="part pt3">
            <div class="Mod Form MainForm" id="InfoEdit">
                <div class="mhd">
                    <h3>
                        订单明细</h3>
                </div>
                <div class="mbd">
                    <div class="fi group" style="border: 1px solid #ccc; margin-bottom: 5px;">
                        <div class="fi">
                            <label>
                                订单号：</label>
                            <%=this.Order.fdOrdeNO %>
                        </div>
                        <div class="fi">
                            <label>
                                下单时间：</label>
                            <%=this.Order.fdOrdeCreateAt %>
                        </div>
                        <div class="fi">
                            <label>
                                用户名称：</label>
                            <%=this.Order.fdOrdeUserName %>
                        </div>
                        <div class="fi">
                            <label>
                                商品总额：</label>
                            <%=this.Order.fdOrdeGoodsPrice %>
                        </div>
                        <div class="fi">
                            <label>
                                邮费：</label>
                            <%=this.Order.fdOrdeDeliverPrice %>
                        </div>
                        <div class="fi">
                            <label>
                                实际付款：</label>
                            <%=this.Order.fdOrdePayPrice %>
                        </div>
                        <div class="fi">
                            <label>
                                调整处理：</label>
                            <%=this.Order.fdOrdeRemark == "" ? "不需处理" : this.Order.fdOrdeRemark%>
                        </div>
                        <div class="fi">
                            <label>
                                用户备注信息：</label>
                            <%=this.Order.fdOrderNote %>
                        </div>
                        <div class="fi" style="display:<%=this.Order.fdOrdeInvoiceTitle==""?"none":"block"%>">
                            <label>
                                发票抬头：</label>
                            <%=this.Order.fdOrdeInvoiceTitle %>
                        </div>
                    </div>
                    <div class="fi group" style="border: 1px solid #ccc; margin-bottom: 5px;">
                        <%--<div class="fi">
                            <label>
                                Email：</label>
                            <%=this.Order.fdOrdeUserEmail %>
                        </div>--%>
                        <div class="fi">
                            <label>
                                电话：</label>
                            <%=this.Order.fdOrdeUserPhone %>
                        </div>
                        <%--<div class="fi">
                            <label>
                                移动电话：</label>
                            <%=this.Order.fdOrdeUserMobile %>
                        </div>--%>
                        <div class="fi">
                            <label>
                                收货地址：</label>
                            <%=AnyWeb.AW.Configs.AreaConfigs.GetConfigs().funcGetProvinceById(this.Order.fdOrdeUserProvinceID).Name+"省"
                                +AnyWeb.AW.Configs.AreaConfigs.GetConfigs().funcGetProvinceById(this.Order.fdOrdeUserProvinceID).funcGetCityById(this.Order.fdOrdeUserCityID).Name+"市"%><%=AnyWeb.AW.Configs.AreaConfigs.GetConfigs().funcGetProvinceById(this.Order.fdOrdeUserProvinceID).funcGetCityById(this.Order.fdOrdeUserCityID).funcGetAreaById(this.Order.fdOrdeUserAreaID)!=null?AnyWeb.AW.Configs.AreaConfigs.GetConfigs().funcGetProvinceById(this.Order.fdOrdeUserProvinceID).funcGetCityById(this.Order.fdOrdeUserCityID).funcGetAreaById(this.Order.fdOrdeUserAreaID).Name+"区":""%><%=this.Order.fdOrdeUserAddress %>
                        </div>
                        <div class="fi">
                            <label>
                                邮编：</label>
                            <%=this.Order.fdOrdeUserPostcode %>
                        </div>
                    </div>
                    <div class="fi group" style="border: 1px solid #ccc; margin-bottom: 5px;">
                        <div class="fi">
                            <label>
                                订单状态：</label>
                            <%=this.Order.Status%>
                        </div>
                        <div class="fi" style="display:<%=this.Order.fdOrdeStatus==6?"block":"none"%>">
                            <label>
                                取消原因：</label>
                            <%=this.Order.fdOrdeCancelReson %>
                        </div>
                        <div class="fi">
                            <label>
                                付款方式：</label>
                            <%=this.Order.PayMode %>
                        </div>
                        <div class="fi" style="display: <%=this.Order.fdOrdePayAt.ToString()=="1900-1-1 0:00:00"?"none":"block" %>">
                            <label>
                                支付时间：</label>
                            <%=this.Order.fdOrdePayAt %>
                        </div>
                        <div class="fi" style="display: <%=this.Order.fdOrdeDeliverTime.ToString()=="1900-1-1 0:00:00"?"none":"block" %>">
                            <label>
                                发货时间：</label>
                            <%=this.Order.fdOrdeDeliverTime %>
                        </div>
                        <div class="fi">
                            <label>
                                物流配送方式：</label>
                            <%=this.Order.DeliverMode%>
                        </div>
                        <%--<div class="fi">
                            <label>
                                投递公司：</label>
                            <%=this.Order.fdOrdeDeliverCompany %>
                        </div>
                        <div class="fi">
                            <label>
                                快递单号：</label>
                            <%=this.Order.fdOrdeDeliverFormNo %>
                        </div>
                        <div class="fi">
                            <label>
                                投递电话：</label>
                            <%=this.Order.fdOrdeSenderPhone %>
                        </div>--%>
                    </div>
                    <div class="fi group" style="border: 1px solid #ccc; margin-bottom: 5px;">
                        <table cellspacing="1" bgcolor="#CCCCCC">
                            <thead>
                                <tr>
                                    <th height="20" align="center" valign="middle" bgcolor="#FFFFFF">
                                        编号
                                    </th>
                                    <th align="center" valign="middle" bgcolor="#FFFFFF">
                                        名称
                                    </th>
                                    <th align="center" valign="middle" bgcolor="#FFFFFF">
                                        图片
                                    </th>
                                    <th align="center" valign="middle" bgcolor="#FFFFFF">
                                        单价
                                    </th>
                                    <th align="center" valign="middle" bgcolor="#FFFFFF" class="end">
                                        数量
                                    </th>
                                </tr>
                            </thead>
                            <asp:Repeater ID="repGoods" runat="server" EnableViewState="False">
                                <ItemTemplate>
                                    <tr align="center">
                                        <td bgcolor="#FFFFFF" width="50" style="padding:5px;">
                                            <%# Eval("Goods.fdGoodID")%>
                                        </td>
                                        <td bgcolor="#FFFFFF" width="100" style="padding:5px;">
                                            <%# Eval("Goods.fdGoodName")%>
                                        </td>
                                        <td bgcolor="#FFFFFF" width="150" style="padding:5px;">
                                            <a href="/goods-<%#Eval("Goods.fdGoodID") %>.aspx"><img alt="<%# Eval("Goods.fdGoodName")%>" src="<%# Eval("Goods.fdGoodListImage")%>"
                                                style="width: 100px; height: 40px;" /></a>
                                        </td>
                                        <td bgcolor="#FFFFFF" width="100" style="padding:5px;">
                                            <%# Eval("fdItemGoodsPrice")%>
                                        </td>
                                        <td bgcolor="#FFFFFF" width="100" style="padding:5px;">
                                            <%# Eval("fdItemQuantity")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="fi fiBtns">
                        <a href="orderList.aspx">返回列表</a>
                    </div>
                </div>
                <div class="mft">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
