<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="DeliverModeHandle.aspx.cs" Inherits="DeliverModeHandle" Title="配送方式管理"  validateRequest="false"  %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph2" Runat="Server">

     <li></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph1" runat="Server">
<div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                     <asp:Literal ID="litTitle" runat="server"></asp:Literal></h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                    <asp:FormView ID="fv1" runat="server" DataKeyNames="ID" Width="100%" DataSourceID="ods3" OnDataBound="fv1_DataBound">
                        <EditItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr class="name odd">
                                    <th style="width:20%">
                                        配送方式名称：</th>
                                    <td>
                                        <asp:TextBox ID="txtTitle" Text='<%# Bind("Title")%>' CssClass="text" runat="server"  errmsg="请输入正确的配送方式" MaxLength="50"  require="1" Width="240px"></asp:TextBox>最多50个汉字。                                          
                                        <asp:HiddenField ID="hidtype" Value='<%# Bind("Type")%>' runat="server" />
                                    </td>
                                </tr>
                                <tr class="title">
                                    <th>
                                        首 重：

                                    </th>
                                    <td>
                                          <asp:TextBox ID="txtmostPoundage" Text='<%# Bind("MostPoundage") %>' runat="server"  CssClass="text" errmsg="请输入正确的首重"  datatype="double" require="1" ></asp:TextBox> 元/1Kg
                                   </td>
                                </tr>
                                 <tr class="name odd">
                                    <th >
                                        续 重：</th>
                                    <td>
                                        <asp:TextBox ID="txtPoundage"  Text='<%# Bind("Poundage")%>' runat="server"  CssClass="text" errmsg="请输入正确的续重" datatype="double" require="1"></asp:TextBox>元/1Kg
                                    </td>
                                </tr>
                                 <tr class="title">
                                    <th class="edit odd">
                                        配送细则：
                                    </th>
                                    <td>   <div style="margin:10px 0px">【请将字数控制在10000字以内。】</div></td>
                                
                                </tr>
                                <tr  class="edit odd">
                                    <td colspan="2">
                                        <sw:TinyMce ID="txtContent" runat="server" Height="500px" Text='<%# Bind("Content") %>' />
                                    </td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存配送方式" CommandName="Update" CssClass="submit"></asp:Button>
                                <asp:Button ID="btnDelete" runat="server" Text=" 删除配送方式" CommandName="Delete" CssClass="submit" ></asp:Button>
                                <button id="btnBack" onclick="window.location='DeliverMode.aspx';" type="button">取 消</button>
                            </div>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                          <table class="iEditForm iEditBaseInf">
                                <tr class="name odd">
                                    <th style="width:20%">
                                        配送方式名称：</th>
                                    <td>
                                        <asp:TextBox ID="txtTitle" Text='<%# Bind("Title")%>' runat="server"  CssClass="text" Width="240px"></asp:TextBox>
                                          
                                          <asp:DropDownList ID="ddlSysDeliver" CssClass="select" DataTextField="Title" DataValueField="ID" DataSourceID="ods4" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSysDeliver_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="hidtype" Value='<%# Bind("Type")%>' runat="server" />
                                    </td>
                                </tr>
                                <tr class="title">
                                    <th>
                                        首 重：

                                    </th>
                                    <td>
                                          <asp:TextBox ID="txtmostPoundage" Text='<%# Bind("MostPoundage") %>'   CssClass="text" runat="server" errmsg="请输入正确的首重"  require="1" datatype="double"></asp:TextBox> 元/1Kg
                                   </td>
                                </tr>
                                 <tr class="name odd">
                                    <th >
                                        续 重：</th>
                                    <td>
                                        <asp:TextBox ID="txtPoundage" CssClass="text" Text='<%# Bind("Poundage")%>'  runat="server" errmsg="请输入正确的续重"  require="1" datatype="double"></asp:TextBox>元/1Kg
                                    </td>
                                </tr>
                                 <tr class="title">
                                    <th>
                                        配送细则：
                                    </th>
                                    <td> <div style="margin:10px 0px">【请将字数控制在10000字以内。】</div></td>
                                </tr>
                                <tr class="edit odd">
                                    <td colspan="2">
                                        <sw:TinyMce ID="txtContent" runat="server" Height="500px" Text='<%# Bind("Content") %>' />
                                    </td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text=" 保存配送方式" CommandName="Insert" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='DeliverMode.aspx';" type="button">取 消</button>
                            </div>
                        </InsertItemTemplate>
                       
                    </asp:FormView>
                    <asp:ObjectDataSource ID="ods3" runat="server" DataObjectTypeName="Common.Common.Mode" DeleteMethod="DeleteMode" InsertMethod="InsertMode" SelectMethod="GetModeInfo" TypeName="Common.Agent.ModeAgent" UpdateMethod="UpdateMode"  OnInserted="ods3_Inserted" OnUpdated="ods3_Updated" OnDeleted="ods3_Deleted" >
                        <SelectParameters>
                        <asp:QueryStringParameter QueryStringField="mid" Name="modeid" Type="int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ods4" runat="server" SelectMethod="GetModeByType" TypeName="Common.Agent.ModeAgent">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="2" Name="type" Type="Int32" />
                            <asp:Parameter DefaultValue="0" Name="shopid" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>


