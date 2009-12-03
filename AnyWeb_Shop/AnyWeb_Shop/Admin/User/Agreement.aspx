<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Agreement.aspx.cs"
    Inherits="User_Agreement" Title="注册协议设置" ValidateRequest="false"%>
 
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
<script type="text/javascript" src="../public/ajax.js"></script>
   
<li>设置会员在注册时的协议内容。</li>
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    注册协议</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                    <!--表单部分[[-->
                    <!--最后用label标签里的for属性和input里的id相对应-->
                    <table class="iEditForm iEditBaseInf">
                        <tr class="title">
                            <th>
                                『 注册协议 』内容设置：
                            </th>
                        </tr>
                        <tr class="edit odd">
                            <td>
                                <sw:TinyMce ID="txtAgreement" runat="server" Height="500px" />
                            </td>
                        </tr>
                    </table>
                    <div class="iSubmit">
                        <asp:Button ID="btnSave" CssClass="submit" runat="server" Text="保存内容" OnClick="btnSave_Click"></asp:Button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
