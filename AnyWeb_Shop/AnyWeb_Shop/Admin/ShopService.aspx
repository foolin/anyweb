<%@ Page Title="退换货服务管理" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="ShopService.aspx.cs" Inherits="Admin_ShopService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    退换货服务管理</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                <table class="iEditForm iEditBaseInf">
                    <tr class="title">
                        <th>
                            退换货细则：
                        </th>
                        <td>
                            <div style="margin: 10px 0px">
                                【请将字数控制在10000字以内。】</div>
                        </td>
                    </tr>
                    <tr class="edit odd">
                        <td colspan="2">
                            <sw:TinyMce ID="txtContent" runat="server" Height="500px" />
                        </td>
                    </tr>
                </table>
                <div class="iSubmit">
                    <asp:Button ID="btnSave" runat="server" Text="保存退换货细则" OnClick="btnSave_Click" CssClass="submit">
                    </asp:Button>
                </div>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph2" runat="Server">
    
</asp:Content>
