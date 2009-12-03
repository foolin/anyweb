<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="UserAfficheEdit.aspx.cs" Inherits="UserAfficheEdit" Title="用户公告管理" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
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
                               <tr>
                                    <th  style="width: 90px;">
                                        用户编号：</th>
                                    <td>
                                        <%#Eval("MemberID") %> <a href='User/UserInfo.aspx?userid=<%#Eval("MemberID") %>'>【查看用户资料】</a>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        公告标题：</th>
                                    <td>
                                        <%#Eval("Title") %>
                                    </td>
                                </tr>
                                <tr >
                                    <th>
                                        公告内容：
                                    </th>
                                    <td style="padding:6px; line-height:25px;">
                                        <%# Eval("Context") %>
                                    </td>
                                </tr>
                            </table>
                                 <div class="iSubmit">
                                    <button id="btnBack" onclick="window.location='UserAfficheList.aspx';">
                                    返 回</button>
                            </div>
                        </ItemTemplate>
                    </asp:FormView>
                </form>
                <asp:ObjectDataSource ID="ods3" runat="server" DataObjectTypeName="Common.Common.Affiche" SelectMethod="GetAfficheByID" TypeName="Common.Agent.AfficheAgent" UpdateMethod="AfficheUpdate" OnUpdated="ods3_Updated" OnUpdating="ods3_Updating">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="affID" Type="Int32" QueryStringField="affid"  />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>

