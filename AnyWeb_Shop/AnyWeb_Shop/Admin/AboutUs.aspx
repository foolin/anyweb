<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" Title="关于我们" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
  
 <li>在此填写公司的介绍性文字，例如公司历史，公司宗旨，公司规格等.</li>
          
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    关于我们</h2>
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
                                        『 关于我们 』内容设置：
                                    </th>
                                </tr>
                                <tr class="edit odd">
                                    <td>
                                        <sw:TinyMce ID="txtEmailContent" runat="server" Height="500px" Text='<%#Bind("AboutUs") %>' />
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
                    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetShopInfo" TypeName="Common.Agent.ShopAgent" OnSelecting="ods3_Selecting" DataObjectTypeName="Common.Common.Shop" UpdateMethod="UpdateAboutUs" OnUpdated="ods3_Updated">
                        <SelectParameters>
                            <asp:Parameter Name="shopid" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
