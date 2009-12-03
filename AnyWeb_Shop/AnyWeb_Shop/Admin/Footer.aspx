<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Footer.aspx.cs" Inherits="Footer" Title="页脚管理"   validateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
 <li>对页脚的内容进行设置，建议填写简单的内容。</li>
          
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
<div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                   页脚管理</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                    <!--表单部分[[-->
                    <!--最后用label标签里的for属性和input里的id相对应-->
                    <asp:FormView ID="fv1" runat="server" DataKeyNames="ID" Width="100%" DataSourceID="ods3" DefaultMode="Edit">
                        <EditItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                             <tr class="title">
                                    <th>
                                        『 页脚 』内容设置：
                                    </th>
                             </tr>
                              <tr class="edit odd">
                                  <td>
                                        <sw:TinyMce ID="txtFooter" runat="server" Height="500px" Text='<%#Bind("Footer") %>' />
                                  </td>
                              </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存内容" CommandName="Update" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='BasicInfoManage.aspx';">
                                    取 消</button>
                            </div>
                        </EditItemTemplate>
                    </asp:FormView>
               <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetShopInfo" TypeName="Common.Agent.ShopAgent"  DataObjectTypeName="Common.Common.Shop" UpdateMethod="UpdateFooter" OnSelecting="ods3_Selecting" OnUpdated="ods3_Updated"  >
                    <SelectParameters>
                        <asp:Parameter Name="shopid" Type="Int32"  />
                    </SelectParameters>
                </asp:ObjectDataSource>   
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>

