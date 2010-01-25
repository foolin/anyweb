<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ShopStat.aspx.cs" Inherits="Admin_ShopStat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">

    <script type="text/javascript">
    function search()
    {
        var url = 'ShopStat.aspx?status='+document.getElementById('<%= drpStatus.ClientID %>').value;
        url += '&startDate='+document.getElementById('<%= txtStartDate.ClientID %>').value;
        url += '&endDate='+document.getElementById('<%= txtEndDate.ClientID %>').value;
        location =url;
    } 
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                统计报表</h3>
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
                CssClass="text"></asp:TextBox>&nbsp;到&nbsp;<asp:TextBox ID="txtEndDate" runat="server"
                    onclick="setday(this);" CssClass="text"></asp:TextBox>&nbsp;
            <input type="button" value="查询" onclick="search()" />
        </div>
        <div class="mbd">
            <div style="margin: 5px;">
                <ul>
                    <li>订单数：<%=this.OrderCount%></li>
                    <li>订单销售金额总和：<%=this.GoodsPrice.ToString("c")%></li>
                    <li>订单付款金额总和：<%=this.PayPrice.ToString("c")%></li>
                    <li style="display: none;">收益总和：0</li>
                </ul>
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
</asp:Content>
