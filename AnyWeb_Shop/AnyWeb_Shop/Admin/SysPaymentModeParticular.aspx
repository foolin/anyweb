<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SysPaymentModeParticular.aspx.cs" Inherits="SysPaymentModeParticular" Title="支付方式详情" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph2" Runat="Server">
<li></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph1" runat="Server">
<div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    查看支付方式详情</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                    <asp:FormView ID="fv1" runat="server" DataKeyNames="ID" Width="100%" DataSourceID="ods3" >
                        <ItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr >
                                    <th style="width:20%">
                                        支付方式名称:</th>
                                    <td>
                                       <%# Eval("Title")%>
                                    </td>
                                </tr>
                               <%-- <tr >
                                    <th>
                                        最低收费
                                    </th>
                                    <td>
                                        <%# Eval("MostPoundage") %>
                                   </td>
                                </tr>
                                 <tr >
                                    <th >
                                        手续费:</th>
                                    <td>
                                       <%# Eval("Poundage")%>
                                    </td>
                                </tr>--%>
                                 <tr >
                                    <th>
                                        支付细则:
                                    </th>
                                    <td style="line-height:25px;">   <%# Eval("Content") %></td>
                                </tr>
                               
                            </table>
                            <div class="iSubmit">
                                <input id="btnSave" type="button" value="使用该支付方式" onclick="window.location='UseDeliver.aspx?mid=<%# Eval("ID") %>'" class="submit" />
                                <button id="btnBack" onclick="window.location='PaymentModeList.aspx';" type="button">取 消</button>
                            </div>
                        </ItemTemplate>
                    </asp:FormView>
                    <asp:ObjectDataSource ID="ods3" runat="server" DataObjectTypeName="Common.Common.Mode"  SelectMethod="GetModeInfo" TypeName="Common.Agent.ModeAgent" >
                        <SelectParameters>
                        <asp:QueryStringParameter QueryStringField="mid" Name="modeid" Type="int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
