<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="AdminEdit.aspx.cs" Inherits="AdminEdit" Debug="true" Title="用户管理" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <li>登录帐号一经创建后不允许修改。</li>
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
                    <EditItemTemplate>
                        <table class="iEditForm iEditBaseInf">
                            <tr class="name odd">
                                <th style="width: 120px;">
                                    登录账号：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtAcc" runat="server" CssClass="input" errmsg="请输入正确的登录账号" MaxLength="20" ReadOnly="true"
                                        require="1" Width="200px" Text='<%#Bind("AdminAcc") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="name odd">
                                <th style="width: 120px;">
                                    用户名称：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="input" errmsg="请输入正确的用户名称" MaxLength="50"
                                        require="1" Width="200px" Text='<%#Bind("AdminName") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="name odd">
                                <th style="width: 120px;">
                                    登录密码：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtPwd" runat="server" CssClass="input" TextMode="Password" MaxLength="16"
                                        Width="200px" Text='<%#Bind("AdminPass") %>' require="0" max="16" min="0" datatype="len"></asp:TextBox>&nbsp;如不需要修改密码,密码输入框请留空。
                                </td>
                            </tr>
                            <tr class="name odd">
                                <th style="width: 120px;">
                                    确认密码：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtrepPwd" runat="server" CssClass="input" TextMode="Password" MaxLength="16"
                                        Width="200px" Text='<%#Bind("AdminPass") %>' require="0" errmsg="两次输入的密码不相同" datatype="custom" exp="checkPwd()"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <div class="iSubmit">
                            <asp:Button ID="btnSave" runat="server" Text="保存用户" CommandName="Update" CssClass="submit">
                            </asp:Button>
                            <asp:Button ID="btnDelete" runat="server" Text="删除该用户" CommandName="Delete" CssClass="submit">
                            </asp:Button>
                            <button id="btnBack" type="button" onclick="javascript:history.back();">
                                取 消</button>
                        </div>
                        <script type="text/javascript">
                            function checkPwd() {
                                var txtUserPass = document.getElementById('<%=fv1.FindControl("txtPwd").ClientID %>');
                                var txtUserPass2 = document.getElementById('<%=fv1.FindControl("txtrepPwd").ClientID %>');

                                return txtUserPass2.value == txtUserPass.value;
                            }
                        </script>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table class="iEditForm iEditBaseInf">
                            <tr class="name odd">
                                <th style="width: 120px;">
                                    登录账号：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtAcc" runat="server" CssClass="input" errmsg="请输入正确的登录账号" MaxLength="20"
                                        require="1" Width="200px" Text='<%#Bind("AdminAcc") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="name odd">
                                <th style="width: 120px;">
                                    用户名称：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="input" errmsg="请输入正确的用户名称" MaxLength="50"
                                        require="1" Width="200px" Text='<%#Bind("AdminName") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="name odd">
                                <th style="width: 120px;">
                                    登录密码：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtPwd" runat="server" CssClass="input" TextMode="Password" errmsg="请输入正确的登录密码"
                                        MaxLength="16" require="1" Width="200px" Text='<%#Bind("AdminPass") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="name odd">
                                <th style="width: 120px;">
                                    确认密码：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtrepPwd" runat="server" CssClass="input" TextMode="Password" errmsg="两次输入的密码不相同"
                                        MaxLength="16" require="1" datatype="custom" exp="checkPwd()" Width="200px" Text='<%#Bind("AdminPass") %>'></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <div class="iSubmit">
                            <asp:Button ID="btnSave" runat="server" Text=" 保存用户" CommandName="Insert" CssClass="submit">
                            </asp:Button>
                            <button id="btnBack" type="button" onclick="javascript:history.back();">
                                取 消</button>
                        </div>

                        <script type="text/javascript">
                            function checkPwd() {
                                var txtUserPass = document.getElementById('<%=fv1.FindControl("txtPwd").ClientID %>');
                                var txtUserPass2 = document.getElementById('<%=fv1.FindControl("txtrepPwd").ClientID %>');

                                return txtUserPass2.value == txtUserPass.value;
                            }
                        </script>

                    </InsertItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="ods3" runat="server" TypeName="Common.Agent.AdminAgent"
                    DataObjectTypeName="Common.Common.Admin" SelectMethod="GetAdminByID" InsertMethod="AddAdmin"
                    OnInserting="ods3_Inserting" OnInserted="ods3_Inserted" OnUpdating="ods3_Updating" OnUpdated="ods3_Updated"
                    UpdateMethod="UpdateAdmin" DeleteMethod="DeleteAdmin" OnDeleting="ods3_Deleting" OnDeleted="ods3_Deleted" OnSelecting="ods3_Selecting" OnSelected="ods3_Selected">
                    <SelectParameters>
                        <asp:Parameter Name="aid" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>

                <script type="text/javascript">
                    function showDesc() {
                        document.getElementById("divDesc").style.display = document.getElementById("_ctl0_cph1_fv1_chkAutoDesc").checked ? 'none' : 'block';

                    } 
   
                </script>

                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
