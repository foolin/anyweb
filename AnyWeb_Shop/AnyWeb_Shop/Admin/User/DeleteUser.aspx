<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteUser.aspx.cs" Inherits="User_DeleteUser"  MasterPageFile="~/Admin/Admin.master" ValidateRequest="false"%>
 
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
<script type="text/javascript" src="../public/ajax.js"></script>
   
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    冻结用户</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                    <!--表单部分[[-->
                    <!--最后用label标签里的for属性和input里的id相对应-->
                    <table class="iEditForm iEditBaseInf">
                        <tr class="title" style="width:12px;">
                            <th>
                                请填写冻结该用户的原因：
                            </th>
                        </tr>
                        <tr class="edit odd">
                            <td>
                                <sw:TinyMce ID="txtReason" runat="server" Height="500px" />
                            </td>
                        </tr>
                    </table>
                    <div class="iSubmit">
                        <asp:Button ID="btnSave" CssClass="submit" runat="server" Text="确定提交" OnClick="btnSave_Click" ></asp:Button>
                         <button id="btnBack" onclick="window.location='UserList.aspx';" type="button">
                                    取消</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
