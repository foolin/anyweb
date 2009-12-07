<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="OrderItem.aspx.cs" Inherits="OrderItem" Title="订单管理" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <li></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    订单明细</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                <!--表单部分[[-->
                <!--最后用label标签里的for属性和input里的id相对应-->
                <div style="text-align: center; padding: 10px 0px;">
                    <div style="border-bottom: dotted 1px gray; padding-bottom: 10px; margin-bottom: 5px;
                        text-align: right; padding-right: 20px;">
                        <asp:ImageButton ID="btnDeal" runat="server" OnClick="btnDeal_Click" ImageUrl="~/images/send.jpg" />
                        <asp:ImageButton ID="btnCancle" runat="server" OnClick="btnCancle_Click" ImageUrl="~/images/cancel.jpg" /><asp:Literal
                            ID="litmsg" runat="server"></asp:Literal></div>
                    <asp:Panel ID="paneReason" runat="server" BackColor="#f5f5f5" BorderStyle="inset"
                        BorderWidth="1px" BorderColor="black">
                        <strong>需要向用户？<input id="chkAffiche" type="checkbox" runat="server" checked="checked" />发布公告<input
                            id="chkEmail" type="checkbox" runat="server" checked="checked" />发送邮件</strong>
                        <table class="iEditForm iEditBaseInf">
                            <tr>
                                <th style="width: 110px;">
                                    呢称：
                                </th>
                                <td align="left">
                                    <asp:TextBox ID="txtRegard" runat="server" MaxLength="100" Height="20px" CssClass="text"
                                        Width="80%" errmsg="请输入呢称" require="1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="edit">
                                <th>
                                    内容：
                                </th>
                                <td>
                                    <sw:TinyMce ID="txtContent" runat="server" Height="500px" />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    原因：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtCancleReson" runat="server" CssClass="text" Height="100px" Width="99%"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="btnSendEmail" runat="server" Text="确 认" OnClick="btnSendEmail_Click" />
                        <asp:Button ID="btncancle2" runat="server" Text="取 消" OnClick="btncancle2_Click1" />
                    </asp:Panel>
                </div>
                <asp:FormView ID="fv1" runat="server" DataKeyNames="ID" DataSourceID="ods3" OnDataBound="fv1_DataBound"
                    Width="100%">
                    <ItemTemplate>
                        <table class="iEditForm iEditBaseInf">
                            <tr style='display: <%#(int)Eval("Status")==3 ?"":"none" %>; color: gray; font-size: 14px;'>
                                <th style="width: 100px;">
                                    取消原因：
                                </th>
                                <td colspan="3">
                                    <%#Eval( "CancleReson" )%>
                                </td>
                            </tr>
                            <tr class="name">
                                <th style="width: 100px;">
                                    订单编号：
                                </th>
                                <td style="width: 220px;">
                                    <asp:Literal ID="litid" Text='<%#Eval("ID") %>' runat="server"></asp:Literal>
                                </td>
                                <th style="width: 100px;">
                                    下单日期：
                                </th>
                                <td>
                                    <%#Eval( "CreateAt","{0:yyyy-MM-dd}" )%>
                                </td>
                            </tr>
                            <tr class="name time">
                                <th>
                                    用户编号：
                                </th>
                                <td>
                                    <asp:Literal ID="lituid" Text='<%#Eval("UserID")%>' runat="server"></asp:Literal>
                                </td>
                                <th>
                                    用户名称：
                                </th>
                                <td>
                                    <asp:Literal ID="litUserName" Text='<%#Eval("UserName")%>' runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr class="name time">
                                <th>
                                    联系电话：
                                </th>
                                <td>
                                    <%#Eval( "UserPhone" )%>
                                </td>
                                <th>
                                    移动电话：
                                </th>
                                <td>
                                    <%#Eval( "Mobile" )%>
                                </td>
                            </tr>
                            <tr class="name time">
                                <th>
                                    邮编：
                                </th>
                                <td>
                                    <%#Eval( "Postalcode" )%>
                                </td>
                                <th>
                                    Email：
                                </th>
                                <td>
                                    <asp:Literal ID="litEmail" Text='<%#Eval("UserEmail")%>' runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr class="name time">
                                <th>
                                    送货方式：
                                </th>
                                <td>
                                    <%#Eval( "OfSendMode.Title" )%>
                                </td>
                                <th>
                                    送货时间：
                                </th>
                                <td>
                                    <%#Eval( "Delivertime","{0:yyyy-MM-dd}" )%>
                                </td>
                            </tr>
                            <tr class="name time">
                                <th>
                                    支付方式：
                                </th>
                                <td>
                                    <%#Eval( "OfPayMode.Title" )%>
                                </td>
                                <th>
                                    手续费用：
                                </th>
                                <td>
                                    <%#Eval( "Deliverprice","{0:c}" )%>
                                    ( 配送费用 )+
                                    <%#Eval( "Paymentprice","{0:c}" )%>
                                    ( 支付费用 )
                                </td>
                            </tr>
                            <tr class="name time">
                                <th>
                                    商品总额：
                                </th>
                                <td style="color: red; font-size: 14px; font-weight: bolder;">
                                    <%#Eval( "TotalPrice" , "{0:c}" )%>
                                </td>
                                <th>
                                    用户花费总额：
                                </th>
                                <td style="color: red; font-size: 14px; font-weight: bolder;">
                                    <%#Eval( "Price","{0:c}" )%>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    可获积分：
                                </th>
                                <td colspan="3" style="color: red; font-size: 14px; font-weight: bolder;">
                                    <asp:Literal ID="litScore" Text='<%#Eval( "MathScore" )%>' runat="server"></asp:Literal>分
                                </td>
                            </tr>
                            <tr class="name time">
                                <th>
                                    送货地址：
                                </th>
                                <td colspan="3">
                                    <%#Eval( "Address" )%>
                                </td>
                            </tr>
                            <tr class="name time">
                                <th>
                                    备注：
                                </th>
                                <td colspan="3">
                                    <%#Eval("Remark")%>
                                </td>
                                <asp:HiddenField ID="litStatus" Value='<%#Eval("Status") %>' runat="server" />
                            </tr>
                        </table>
                        <!---ChangeList-->
                        <table class="iList iArticle">
                            <thead>
                                <tr>
                                    <th class="fst">
                                        商品名称
                                    </th>
                                    <th>
                                        图片
                                    </th>
                                    <th>
                                        价格
                                    </th>
                                    <th>
                                        积分
                                    </th>
                                    <th class="end">
                                        数量
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="repCategory" runat="server" DataSource='<%# Eval("OrderItems") %>'>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%#Eval( "OfGoods.GoodsName" )%>
                                            </td>
                                            <td>
                                                <a href='<%#Eval("OfGoods.LinkUrl")%>' target="_blank">
                                                    <img src='<%#Eval( "OfGoods.Image" )%>' alt='<%#Eval( "OfGoods.GoodsName" )%>' border="0" /></a>
                                            </td>
                                            <td>
                                                <%#Eval( "OfGoods.Price","{0:c}" )%>
                                            </td>
                                            <td>
                                                <%#Eval( "OfGoods.Score" )%>
                                            </td>
                                            <td>
                                                <%#Eval( "Quantity" )%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <div class="iSubmit">
                            <asp:Button ID="btnDelete" runat="server" Text="删除该订单" CommandName="Delete" CssClass="submit">
                            </asp:Button>
                            <button id="btnBack" onclick="window.location='OrderList.aspx';" type="button">
                                返回列表</button>
                        </div>
                    </ItemTemplate>
                </asp:FormView>
                </form>
                <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetOrderByID" TypeName="Common.Agent.OrderAgent"
                    DeleteMethod="OrderDeleteByID" DataObjectTypeName="Common.Common.Order" OnDeleted="ods3_Deleted">
                    <SelectParameters>
                        <asp:QueryStringParameter Type="Int32" Name="oid" QueryStringField="oid" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
