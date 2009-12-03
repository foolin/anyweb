<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ShopArticleSet.aspx.cs" Inherits="ShopArticleSet" Title="商城指南设置" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                   商城指南设置</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                    <!--表单部分[[-->
                    <!--最后用label标签里的for属性和input里的id相对应-->
                   
                        <table class="iEditForm iEditBaseInf">
                            <tr class="name">
                                <th style="width: 120px;">
                                    是否在首页显示：</th>
                                <td>
                                   <asp:CheckBox ID="chkShow" runat="server" />不显示请留空。</td>
                            </tr>
                        </table>
               
                  <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存提交" CssClass="submit" OnClick="btnSave_Click"></asp:Button>
                                 <button id="btnBack" onclick="window.location='ShopArticleList.aspx';">
                                    取 消</button>
                            </div></form>
            </div> 
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph2" Runat="Server">
</asp:Content>

