<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SetAdminPass.aspx.cs" Inherits="SetAdminPass" Title="设置登陆信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
   
                <li>设置登陆信息，您可以修改登陆商城后台的用户名和密码。</li>
          
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    设置登陆信息</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                    <!--表单部分[[-->
                    <!--最后用label标签里的for属性和input里的id相对应-->
                    <asp:FormView ID="fv1" runat="server" DataKeyNames="ID" Width="100%" DataSourceID="ods3" DefaultMode="edit">
                        <EditItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr class="odd edit">
                                    <th style="width:100px;">
                                        管理员帐号：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtUserAcc" runat="server" CssClass="input" errmsg="请输入正确的管理员帐号" MaxLength="50"  max="20" require="1"  Text='<%#Bind("AdminAcc") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        登陆密码：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtUserPwd" runat="server" CssClass="input"  Width="200px" Text='<%#Bind("AdminPass") %>' TextMode="Password"  errmsg="请输入正确的用户密码，6-20位任意字符"  max="20" require="1"   MaxLength="16" min="6" datatype="len" ></asp:TextBox> 规则：6-20位任意字符
                                        <asp:HiddenField ID="hidAdminpass" runat="server" Value='<%#Eval("AdminPass") %>' />
                                    </td>
                                </tr>
                                 <tr>
                                    <th>
                                        确认登陆密码：
                                    </th>
                                    <td>
                                        <input  style=" width:200px;" class="text" id="Password1" datatype="custom" errmsg="两次输入的密码不相同" exp="document.all.Password1.value==document.all._ctl0_cph1_fv1_txtUserPwd.value" maxlength="16" require="1"  type="password" />
                                    </td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存资料" CommandName="Update" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='BasicInfoManage.aspx';" nocheck="false">取 消</button>
                            </div>
                        </EditItemTemplate>
                    </asp:FormView>
                </form>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetShopBasicInfo" TypeName="Common.Agent.ShopAgent" DataObjectTypeName="Common.Common.Shop" UpdateMethod="UpdateAdminPass" OnUpdating="ods3_Updating" OnUpdated="ods3_Updated"></asp:ObjectDataSource>
</asp:Content>
