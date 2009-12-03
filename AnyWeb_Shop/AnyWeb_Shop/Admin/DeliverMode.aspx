<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="DeliverMode.aspx.cs" Inherits="DeliverMode" Title="配送方式管理" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph2" Runat="Server">
  <li></li>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph1" runat="Server">
        <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                 配送方式管理 <span class="listadd"><a href="DeliverModeHandle.aspx?mode=insert">添加配送方式</a></span></h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <thead>
                            <tr>
                                <th class="fst">
                                    配送方式编号
                                </th>
                                <th>
                                    配送方式名称</th>
                                    <th>
                                        首重

                                    </th>
                                 <th>
                                    续重</th>
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
                                           <%#Eval("MostPoundage") %>元/1kg

                                        </td>
                                        <td>
                                            <%# Eval("Poundage")  %>元/1kg
                                        </td>
                                        <td>
                                            <%# Eval("CreateAt") %>
                                        </td>
                                        
                                        <td>
                                            <a href='DeliverModeHandle.aspx?mode=update&mid=<%# Eval("ID").ToString() %>'>修改</a> <a href='DeliverModeHandle.aspx?mode=delete&mid=<%# Eval("ID").ToString() %>' onclick="javascript:return confirm('确定删除？')">删除</a>
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
            <asp:Parameter DefaultValue="2" Name="type" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

