<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="Setting_Email.aspx.cs" Inherits="Admin_Setting_Email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                邮件配置</h3>
        </div>
        <div class="mbd">
            <table>
                <thead>
                    <tr>
                        <th style="display: none">
                            编号
                        </th>
                        <th>
                            邮件地址
                        </th>
                        <th>
                            服务器
                        </th>
                        <th>
                            端口
                        </th>
                        <th>
                            SSL
                        </th>
                        <th>
                            用户名
                        </th>
                        <th>
                            密码
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="repSmtp" runat="server" OnItemCommand="repSmtp_ItemCommand">
                    <ItemTemplate>
                        <tr align="center" class="editalt">
                            <td style="width: 30px; display: none;">
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSender" runat="server" Text='<%# Eval("Sender")%>' CssClass="text"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtServerAddress" runat="server" Text='<%# Eval("ServerAddress")%>'
                                    CssClass="text"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPort" runat="server" Width="40px" Text='<%# Eval("Port")%>' CssClass="text"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CheckBox ID="boxEnableSsl" runat="server" Checked='<%#Eval("EnableSsl")%>' />
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" Text='<%# Eval("UserName")%>' CssClass="text"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" Text='<%# Eval("Password")%>' CssClass="text"></asp:TextBox>
                            </td>
                            <td>
                                <asp:LinkButton ID="btnSave" runat="server" CommandName="Update">保存</asp:LinkButton>
                                <asp:LinkButton ID="btnDel" runat="server" CommandName="Delete">删除</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tfoot>
                    <tr align="center" class="editalt">
                        <td style="width: 30px; display: none;">
                            -
                        </td>
                        <td>
                            <asp:TextBox ID="txtSender" runat="server" CssClass="text"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtServerAddress" runat="server" CssClass="text"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPort" runat="server" Width="40px" CssClass="text">25</asp:TextBox>
                        </td>
                        <td>
                            <asp:CheckBox ID="boxEnableSsl" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="text"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="text"></asp:TextBox>
                        </td>
                        <td>
                            <asp:LinkButton ID="btnNew" runat="server" OnClick="btnNew_Click">新增</asp:LinkButton>
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
            <li>配置多个SMTP邮件服务时，系统会轮流使用这些SMTP配置发送邮件</li>
            <li>如使用Gmail发送邮件，端口使用587，并启用SSL</li>
            <li>如使用QQ发送邮件，端口使用25，并关闭SSL</li>
        </ul>
    </div>
</asp:Content>
