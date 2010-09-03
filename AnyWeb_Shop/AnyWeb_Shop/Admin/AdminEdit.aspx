<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="AdminEdit.aspx.cs" Inherits="AdminEdit" Debug="true" Title="用户管理"  validateRequest="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <li></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    <asp:Literal ID="litTitle" runat="server"></asp:Literal></h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                    <!--表单部分[[-->
                    <!--最后用label标签里的for属性和input里的id相对应-->
                    <asp:FormView ID="fv1" runat="server" DataKeyNames="ID" Width="100%" DataSourceID="ods3">
                        <ItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr class="name odd">
                                    <th style="width: 120px;">
                                        登录帐号：</th>
                                    <td>
                                        <%#Eval("AdminAcc") %>
                                    </td>
                                </tr>
                                <tr >
                                    <th>
                                        用户名称：</th>
                                    <td>
                                        <%#Eval("AdminName")%>
                                    </td>
                                </tr>
                                <tr >
                                    <th>
                                        登录密码：
                                    </th>
                                    <td>
                                        <%#Eval("AdminPass")%>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr class="name odd">
                                    <th style="width: 120px;">
                                        登录账号：</th>
                                    <td>
                                        <asp:TextBox ID="txtAcc" runat="server" CssClass="input" errmsg="请输入正确的登录账号" MaxLength="50" require="1" Width="308px" Text='<%#Bind("AdminAcc") %>'></asp:TextBox>&nbsp;不超过50个汉字。
                                    </td>
                                </tr>
                                <tr class="name odd">
                                    <th style="width: 120px;">
                                        用户名称：</th>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="input" errmsg="请输入正确的用户名称" MaxLength="50" require="1" Width="308px" Text='<%#Bind("AdminName") %>'></asp:TextBox>&nbsp;不超过50个汉字。
                                    </td>
                                </tr>
                                <tr class="name odd">
                                    <th style="width: 120px;">
                                        登录密码：</th>
                                    <td>
                                        <asp:TextBox ID="txtPwd" runat="server" CssClass="input" TextMode="Password" MaxLength="50" Width="308px" Text='<%#Bind("AdminPass") %>'></asp:TextBox>&nbsp;如不需要修改密码,密码输入框请留空。
                                    </td>
                                </tr>
                                <tr class="name odd">
                                    <th style="width: 120px;">
                                        确认密码：</th>
                                    <td>
                                        <asp:TextBox ID="txtrepPwd" runat="server" CssClass="input" TextMode="Password" MaxLength="50" require="0" Width="308px" Text='<%#Bind("AdminPass") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <asp:CompareValidator id="Compare" ControlToValidate="txtPwd" ControlToCompare="txtrepPwd" ErrorMessage="两次输入密码不一致" runat="server" />
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存用户" CommandName="Update" CssClass="submit"></asp:Button>
                                <asp:Button ID="btnDelete" runat="server" Text="删除该用户" CommandName="Delete" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='AdminList.aspx';">
                                    取 消</button>
                            </div>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr class="name odd">
                                    <th style="width: 120px;">
                                        登录账号：</th>
                                    <td>
                                        <asp:TextBox ID="txtAcc" runat="server" CssClass="input" errmsg="请输入正确的登录账号" MaxLength="50" require="1" Width="308px" Text='<%#Bind("AdminAcc") %>'></asp:TextBox>&nbsp;不超过50个汉字。
                                    </td>
                                </tr>
                                <tr class="name odd">
                                    <th style="width: 120px;">
                                        用户名称：</th>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="input" errmsg="请输入正确的用户名称" MaxLength="50" require="1" Width="308px" Text='<%#Bind("AdminName") %>'></asp:TextBox>&nbsp;不超过50个汉字。
                                    </td>
                                </tr>
                                <tr class="name odd">
                                    <th style="width: 120px;">
                                        登录密码：</th>
                                    <td>
                                        <asp:TextBox ID="txtPwd" runat="server" CssClass="input" TextMode="Password" errmsg="请输入正确的登录密码" MaxLength="50" require="1" Width="308px" Text='<%#Bind("AdminPass") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="name odd">
                                    <th style="width: 120px;">
                                        确认密码：</th>
                                    <td>
                                        <asp:TextBox ID="txtrepPwd" runat="server" CssClass="input" TextMode="Password" errmsg="请输入正确的登录密码" MaxLength="50" require="1" Width="308px" Text='<%#Bind("AdminPass") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <asp:CompareValidator id="Compare" ControlToValidate="txtPwd" ControlToCompare="txtrepPwd" ErrorMessage="两次输入密码不一致" runat="server" />
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text=" 保存用户" CommandName="Insert" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='AdminList.aspx';">
                                    取 消</button>
                            </div>
                        </InsertItemTemplate>
                    </asp:FormView>
                    <asp:ObjectDataSource ID="ods3" runat="server" TypeName="Common.Agent.AdminAgent" DataObjectTypeName="Common.Common.Admin" SelectMethod="GetAdminByID" InsertMethod="AddAdmin" OnInserted="ods3_Inserted" OnUpdating="ods3_Updating" OnUpdated="ods3_Updated" UpdateMethod="UpdateAdmin" DeleteMethod="DeleteAdmin" OnDeleted="ods3_Deleted">
                        <SelectParameters>
                            <asp:Parameter Name="aid" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>

                    <script type="text/javascript">
                      	function showDesc()
						{
							document.getElementById("divDesc").style.display=document.getElementById("_ctl0_cph1_fv1_chkAutoDesc").checked?'none':'block';
							
						} 

                    </script>

                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
