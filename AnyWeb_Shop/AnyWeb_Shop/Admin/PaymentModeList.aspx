<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="PaymentModeList.aspx.cs"
    Inherits="PaymentModeList" Title="支付方式管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">

     <li></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    支付方式管理<span class="listadd"><a href="ModeHandle.aspx?mode=insert">添加支付方式</a></span></h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <thead>
                            <tr>
                                <th class="fst">
                                    支付方式编号
                                </th>
                                <th>
                                    支付方式名称</th>
                                <th>
                                    设置时间</th>
                                <th class="end">
                                    操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repMode" runat="server" DataSourceID="ods3">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("ID") %>
                                        </td>
                                        <td>
                                            <%# Eval("Title") %>
                                        </td>
                                        <td>
                                            <%# Eval("CreateAt") %>
                                        </td>
                                        
                                        <td>
                                            <a href='ModeHandle.aspx?mode=update&mid=<%# Eval("ID").ToString() %>'>修改</a>
                                             <a href='ModeHandle.aspx?mode=delete&mid=<%# Eval("ID").ToString() %>' onclick="javascript:return confirm('确定删除？')">删除</a>
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
    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetModeByType" TypeName="Common.Agent.ModeAgent">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="type" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
