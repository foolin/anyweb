<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="OrderEdit.aspx.cs" Inherits="Admin_OrderEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改订单</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    实际付款金额：</label>
                <asp:TextBox ID="txtPayPrice" runat="server" CssClass="text"></asp:TextBox><sw:Validator
                    ID="Validator1" ControlID="txtPayPrice" ValidateType="datatype" DataType="Integer"
                    ErrorText="要求输入数字" ErrorMessage="要求输入数字" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    备注：</label>
                <asp:TextBox ID="txtRemark" runat="server" Rows="5" TextMode="MultiLine" Width="300px"></asp:TextBox>
            </div>
            <div class="fi">
                <label>
                    订单状态：</label>
                <asp:DropDownList ID="drpStatus" runat="server">
                    <asp:ListItem Value="1">新增待支付</asp:ListItem>
                    <asp:ListItem Value="2">已支付待发货</asp:ListItem>
                    <asp:ListItem Value="3">已发货待确认</asp:ListItem>
                    <asp:ListItem Value="4">已确认完成</asp:ListItem>
                    <asp:ListItem Value="5">缺货登记</asp:ListItem>
                    <asp:ListItem Value="6">用户取消</asp:ListItem>
                    <asp:ListItem Value="7">测试无效</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="fi even" id="details_status2" style="display: <%=this.Order.fdOrdeStatus==2?"block":"none"%>;">
                <label>
                    支付时间：</label>
                <asp:TextBox ID="txtPayAt" runat="server" onclick="setday(this);" Width="120px" CssClass="text"></asp:TextBox>
            </div>
            <div class="fi even" id="details_status3" style="display: <%=this.Order.fdOrdeStatus==3?"block":"none"%>;">
                <label>
                    发货时间：</label>
                <asp:TextBox ID="txtDeliverTime" runat="server" onclick="setday(this);" Width="120px"
                    CssClass="text"></asp:TextBox>
            </div>
            <div class="fi even" id="details_status6" style="display: <%=this.Order.fdOrdeStatus==6?"block":"none"%>;">
                <label>
                    取消理由：</label>
                <asp:TextBox ID="txtCancelReson" runat="server" Rows="5" TextMode="MultiLine" Width="300px"
                    CssClass="text"></asp:TextBox>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存修改" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
                <a href="orderList.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li></li>
        </ul>
    </div>

    <script>
        /**
         * 根据选择订单状态显示
         */
        function showDetails(status) {
            for (var i = 1; i <= 7; i++) {
                if (i == status) {
                    try{
                        $("#details_status" + i).fadeIn("fast");
                    } catch (e) {
                        //
                    }
                } else {
                    try {
                        $("#details_status" + i).fadeOut("fast");
                    } catch (e) {
                        //
                    }
                }
            }
        }
    </script>

</asp:Content>
