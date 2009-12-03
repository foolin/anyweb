<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Service.aspx.cs" Inherits="Service" Title="服务条款" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">

                <li> 在此填写公司的联系方式、可具体到某个负责人。</li>
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
  <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    服务条款</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                
                    <table class="iEditForm iEditBaseInf">
                        <tr class="title">
                            <th>
                                『 服务条款 』内容设置：
                            </th>
                        </tr>
                        <tr class="edit odd">
                            <td>
                                <sw:TinyMce ID="txtContent" runat="server" Height="500px" />
                            </td>
                        </tr>
                    </table>
                    <div class="iSubmit">
                        <asp:Button ID="btnSave" runat="server" Text="保存内容" CommandName="Update" CssClass="submit" OnClick="btnSave_Click"></asp:Button>
                        <button id="btnBack" onclick="window.location='BasicInfoManage.aspx';" type="button">取 消</button>
                    </div>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>

