<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="OrderList.aspx.cs" Inherits="Admin_OrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="orderadd.aspx">添加订单</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                订单列表</h3>
        </div>
        <div class="fi filter">
            订单状态：<asp:DropDownList ID="drpStatus" runat="server">
                <asp:ListItem Value="0">所有类型订单</asp:ListItem>
                <asp:ListItem Value="1">新增待支付</asp:ListItem>
                <asp:ListItem Value="2">已支付待发货</asp:ListItem>
                <asp:ListItem Value="3">已发货待确认</asp:ListItem>
                <asp:ListItem Value="4">已确认完成</asp:ListItem>
                <asp:ListItem Value="5">缺货登记</asp:ListItem>
                <asp:ListItem Value="6">用户取消</asp:ListItem>
                <asp:ListItem Value="7">测试无效</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;订单创建日期：从&nbsp;<asp:TextBox ID="txtStartDate" runat="server" onclick="setday(this);"
                CssClass="text" Width="80px"></asp:TextBox>&nbsp;到&nbsp;<asp:TextBox ID="txtEndDate"
                    runat="server" onclick="setday(this);" CssClass="text" Width="80px"></asp:TextBox>&nbsp;<asp:Button
                        ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />&nbsp;&nbsp;
            <input id="btnDel" type="button" value="批量删除" />
        </div>
        <div class="mbd">
            <table>
                <thead>
                    <tr>
                        <th>
                            <input type="checkbox" onclick="selectAll(this.checked);" title="点击全选" />
                        </th>
                        <th>
                            用户名称
                        </th>
                        <th>
                            交易总额
                        </th>
                        <th>
                            支付方式
                        </th>
                        <th>
                            下单时间
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr id="rowNull" runat="server" class="nodata" visible="false">
                        <td colspan="6">
                            还没有任何订单。
                        </td>
                    </tr>
                    <asp:Repeater ID="repOrders" runat="server" EnableViewState="False">
                        <ItemTemplate>
                            <tr align="center" class="editalt">
                                <td style="width: 30px;">
                                    <input type="checkbox" name="ids" value="<%#Eval("fdOrdeID")%>" />
                                </td>
                                <td>
                                    <%# Eval("fdOrdeUserName")%>
                                </td>
                                <td>
                                    <%# Eval("fdOrdePayPrice")%>
                                </td>
                                <td>
                                    <%# Eval("PayMode")%>
                                </td>
                                <td>
                                    <%# Eval("fdOrdeCreateAt")%>
                                </td>
                                <td>
                                    <a href="OrderDetails.aspx?id=<%#Eval("fdOrdeID") %>">订单明细</a> <a href="orderEdit.aspx?id=<%# Eval("fdOrdeID")%>">
                                        修改</a> <a href="?type=del&id=<%# Eval("fdOrdeID")%>" onclick="return confirm('您确定要删除吗?')">
                                            删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tfoot id="tableFooter" runat="server" visible="true">
                    <tr>
                        <td colspan="6">
                            <span class="total">共<strong><asp:Literal ID="litRecords" runat="server">0</asp:Literal></strong>
                                个订单</span>
                            <ul class="pagination">
                                <sw:PageNaver ID="PN1" runat="server" PageSize="10" StyleID="2">
                                </sw:PageNaver>
                            </ul>
                        </td>
                    </tr>
                </tfoot>
            </table>
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
        $(function() {
            $("#btnDel").click(function() {
                var list = document.getElementsByTagName("input");
                var selected = false;

                for (var i = 0; i < list.length; i++) {
                    if (list[i].name == "ids" && list[i].type == "checkbox" && list[i].checked) {
                        selected = true;
                        break;
                    }
                }
                if (selected == false) {
                    alert("请选择订单");
                    return;
                }
                if (confirm("你确定删除选定的订单吗?")) {
                    $("form").attr("action", "?type=dels");
                    $("form").submit();
                }
            });
        });
    </script>

</asp:Content>
