<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="AfficheEdit.aspx.cs" Inherits="AfficheEdit" Title="系统公告管理" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    
<li>发布的公告能够在系统公告模块中直接查看</li>
          
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
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
                    <asp:FormView ID="fv1" runat="server" DataSourceID="ods3" DataKeyNames="ID" Width="100%">
                        <InsertItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr class="name">
                                    <th style="width: 90px;">
                                        公告标题：</th>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" Text='<%#Bind("Title") %>' errmsg="请输入正确的公告标题" require="1" CssClass="text" Width="380px" MaxLength="50"></asp:TextBox>最多50个汉字。
                                    </td>
                                </tr>
                                <tr class="edit odd">
                                    <th>
                                        公告内容：
                                    </th>
                                    <td>
                                        <sw:TinyMce ID="txtContent" runat="server" Height="500px" Text='<%# Bind("Context") %>' />
                                    </td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text=" 保存公告" CommandName="Insert" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='AfficheList.aspx';" type="button">
                                    取 消</button>
                            </div>
                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr class="name">
                                    <th style="width: 90px;">
                                        公告标题：</th>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" Text='<%#Bind("Title") %>' CssClass="text" Width="380px" MaxLength="50" errmsg="请输入正确的公告标题" require="1"></asp:TextBox>最多50个汉字。
                                    </td>
                                </tr>
                                <tr class="edit odd">
                                    <th>
                                        公告内容：
                                    </th>
                                    <td>
                                        <sw:TinyMce ID="txtContent" runat="server" Height="500px" Text='<%# Bind("Context") %>' />
                                    </td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存公告" CommandName="Update" CssClass="submit"></asp:Button>
                                <asp:Button ID="btnDelete" runat="server" Text="删除该公告" CommandName="Delete" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='AfficheList.aspx';">
                                    取 消</button>
                            </div>
                        </EditItemTemplate>
                    </asp:FormView>
                </form>
                <asp:ObjectDataSource ID="ods3" runat="server" DataObjectTypeName="Common.Common.Affiche" DeleteMethod="AfficheDelete" InsertMethod="AfficheAdd" SelectMethod="GetAfficheByID" TypeName="Common.Agent.AfficheAgent" UpdateMethod="AfficheUpdate" OnInserted="ods3_Inserted" OnUpdated="ods3_Updated" OnUpdating="ods3_Updating" OnDeleted="ods3_Deleted">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="affID" Type="int32" QueryStringField="affid" DefaultValue="0" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
