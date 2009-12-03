<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SetCurrencyList.aspx.cs" Inherits="SetCurrencyList" Title="支付货币管理" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
<div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    支付货币管理</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <thead>
                            <tr>
                               <th >
                                   货币名称</th>
                                <th>
                                    货币符号</th>
                                <th>
                                   与人民币的汇率</th>
                                 <th>
                                    所属国家</th>
                                <th>
                                    设置时间</th>
                                <th class="end">
                                    操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repCurrency" runat="server" DataSourceID="ods3">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("OfCurrency.Name") %>
                                        </td>
                                        <td>
                                            <%# Eval("OfCurrency.Denotation") %>
                                        </td>
                                        <td>
                                            <%# Eval("OfCurrency.ExchangeRate") %>
                                        </td>
                                        <td>
                                            <%# Eval("OfCurrency.Country") %>
                                        </td>
                                        <td>
                                            <%# Eval("CreateAt") %>
                                        </td>
                                        <td>
                                          <a href='DeleteSetCurrency.aspx?sid=<%# Eval("ID").ToString() %>' >删除</a>   
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </form>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetSettingCurrencyByShop" TypeName="Common.Agent.CurrencyAgent">
    </asp:ObjectDataSource>
    
</asp:Content>

