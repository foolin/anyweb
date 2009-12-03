<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ComplaintsEdit.aspx.cs" ValidateRequest="false" Inherits="ComplaintsEdit" Title="回复投诉" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
  <li></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
   <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    回复投诉</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                    <!--表单部分[[-->
                    <!--最后用label标签里的for属性和input里的id相对应-->
                 
                            <table class="iEditForm iEditBaseInf">
                                <tr class="name ">
                                    <th style="width: 90px;">
                                        投诉内容：</th>
                                    <td>
                                       <div style="line-height:28px; background:url(images/pl.gif) 0 0 no-repeat; padding-left:25px; margin:8px 16px 0px 0px;">
                                        <asp:Literal ID="litContent" runat="server"></asp:Literal></div>
                                    </td>
                                </tr>
                                <tr class="odd edit">
                                    <th>
                                        回复投诉：
                                    </th>
                                    <td>
                                        <sw:TinyMce ID="txtReplay" runat="server" Height="500px" />
                                    </td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="回复投诉"  CssClass="submit" OnClick="btnSave_Click"></asp:Button>
                                <button id="btnBack" onclick="window.location='ComplaintsList.aspx';" type="button">返 回</button>
                            </div>

                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>

