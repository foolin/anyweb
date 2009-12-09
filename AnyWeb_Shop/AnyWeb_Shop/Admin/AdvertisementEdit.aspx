<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="AdvertisementEdit.aspx.cs" Inherits="AdvertisementEdit" Title="广告管理"  validateRequest="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">

 <li>您也可以将这里设置成海报,使您的商店受到更大的关注</li>
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
<div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    <asp:Literal ID="litTitle" runat="server"></asp:Literal>
                </h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <asp:FormView ID="fv1" runat="server" DataSourceID="ods3" DataKeyNames="ID" Width="100%" >
                        <ItemTemplate>  
                         <table class="iEditForm iEditBaseInf">
                                <tr >
                                    <th style="width: 90px;">
                                        广告标题：</th>
                                    <td >
                                        <%#Eval("AdTitle") %>
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="2">
                                        广告内容：
                                    </th>
                                    
                                </tr>
                                <tr >
                                    <td colspan="2">
                                     
                                         <%# Eval("AdContent") %>
        
                                    </td>
                                </tr>
                            </table>
                                 <div class="iSubmit">
                                     <button id="Button1" onclick="window.location='AdvertisementEdit.aspx?adid=<%#Eval("ID") %>&mode=update';" class="submit">编辑该广告
                                    </button>
                                    <asp:Button ID="btnDelete" runat="server" Text="删除该广告" CommandName="Delete" CssClass="submit"></asp:Button>
                                    <button id="btnBack" onclick="window.location='AdvertisementList.aspx';">
                                    返 回</button>
                            </div>
                        </ItemTemplate>
                         <InsertItemTemplate>
                           <table class="iEditForm iEditBaseInf">
                                <tr class="name">
                                    <th style="width: 90px;">
                                        广告标题：</th>
                                    <td >
                                        <asp:TextBox ID="txtName" runat="server" Text='<%#Bind("AdTitle") %>' errmsg="请输入正确的广告标题"  require="1" CssClass="text" Width="380px" MaxLength="100"></asp:TextBox>最多100个汉字。
                                    </td>
                                </tr>
                                <tr class="adv">
                                    <th colspan="2">
                                          广告内容：
                                    </th>
                                    </tr>
                                    <tr class="edit odd">
                                     <td colspan="2">
                                        <sw:TinyMce ID="txtContent" runat="server" Height="500px" Text='<%# Bind("AdContent") %>' />
                                    </td>
                                    
                                </tr>
                                   <tr class="name">
                                    <th >
                                        排序：</th>
                                    <td >
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%#Bind("Sort") %>' errmsg="请输入正确的排序"  require="1" CssClass="text" MaxLength="3" datatype="number"></asp:TextBox>

                                    </td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                            <asp:Button ID="btnSave" runat="server" Text=" 保存广告" CommandName="Insert" CssClass="submit"></asp:Button>
                            <button id="btnBack" onclick="window.location='AdvertisementList.aspx';" type="button">
                                取 消</button>
                            </div>
                         </InsertItemTemplate>
                        <EditItemTemplate>
                         <table class="iEditForm iEditBaseInf">
                                <tr class="name">
                                    <th style="width: 90px;">
                                        广告标题：</th>
                                    <td >
                                        <asp:TextBox ID="txtName" runat="server" Text='<%#Bind("AdTitle") %>' CssClass="text" Width="380px" MaxLength="100" errmsg="请输入正确的广告标题"  require="1"></asp:TextBox>最多100个汉字。
                                        
                                    </td>
                                </tr>
                                <tr class="adv">
                                    <th colspan="2">
                                        广告内容：
                                    </th>
                                    </tr>
                                 <tr class="edit odd">
                                     <td colspan="2">
                                        <sw:TinyMce ID="txtContent" runat="server" Height="500px" Text='<%# Bind("AdContent") %>' />
                                    </td>
                                    
                                </tr>
                                    <tr class="name">
                                    <th >
                                        排序：</th>
                                    <td >
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%#Bind("Sort") %>' errmsg="请输入正确的排序"  require="1" CssClass="text"  MaxLength="3" type="integer"></asp:TextBox>

                                    </td>
                                </tr>
                            </table>
                                 <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存广告" CommandName="Update" CssClass="submit"></asp:Button>
                                <asp:Button ID="btnDelete" runat="server" Text="删除该广告" CommandName="Delete" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="javascript:history.back(-1);">
                                    取 消</button>
                            </div>
                        </EditItemTemplate>
                    </asp:FormView>
                </form>
                <asp:ObjectDataSource ID="ods3" runat="server" DataObjectTypeName="Common.Common.Advertisement" DeleteMethod="AdDelete" InsertMethod="AdAdd" SelectMethod="GetAdverByID" TypeName="Common.Agent.AdvertisementAgent" UpdateMethod="AdUpdate" OnInserted="ods3_Inserted" OnUpdated="ods3_Updated" OnDeleted="ods3_Deleted" >
                    <SelectParameters>
                        <asp:QueryStringParameter QueryStringField="adid" Name="adID" Type="int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="mft">
        </div>
</div>
</asp:Content>

