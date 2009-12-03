<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ChangeGoodsEidt.aspx.cs" Inherits="ChangeGoodsEidt" Title="积分礼品管理" ValidateRequest="false"%>
<asp:Content ID="Content2" ContentPlaceHolderID="cph2" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
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
                    <!--表单部分[[-->
                    <!--最后用label标签里的for属性和input里的id相对应-->
                    <asp:FormView ID="fv1" runat="server" DataKeyNames="ID" Width="100%" DataSourceID="ods3">
                        <EditItemTemplate>
                           <table class="iEditForm iEditBaseInf">
                                <tr class="name">
                                    <th style="width: 100px;">
                                        礼品名称：</th>
                                    <td>
                                        <asp:TextBox ID="txtTitle" runat="server" CssClass="input" errmsg="请输入礼品名称" MaxLength="50" require="1" Width="308px" Text='<%#Bind("Name") %>'></asp:TextBox>不超过50个汉字。</td>
                                </tr>
                                <tr class="title">
                                    <th>
                                        礼品价格：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtprice" runat="server" CssClass="input" errmsg="请输入正确的礼品价格" MaxLength="20" require="1" datatype="double"  Text='<%#Bind("Price") %>'></asp:TextBox>RBM&nbsp;</td>
                                </tr>
                                <tr class="title">
                                    <th >
                                        礼品图片：                                           
                                    </th>
                                    <td>
                                        <asp:FileUpload ID="txtImage" runat="server" Width="280px" />不更改请留空.
                                        <asp:HiddenField ID="hidimg" runat="server" Value='<%# Bind("Image") %>' />
                                    </td> 
                                </tr>
                                <tr>
                                    <th >换购积分：</th>
                                    <td>
                                     <asp:TextBox ID="txtScore" runat="server" CssClass="input" errmsg="请输入正确的积分" datatype="integer" require="1"  Text='<%#Bind("Score") %>'></asp:TextBox>
                                    </td>
                                </tr>   
                                <tr class="edit">
                                    <th >
                                     日期设置：
                                    </th>
                                    <td>
                                     起始日期：<asp:TextBox ID="txtStartTime" runat="server" CssClass="input"  require="1"  errmsg="请输入正确的起始日期"  onclick="setday(this);" Text='<%#Bind("StartTime") %>'></asp:TextBox>
                                     截止日期：<asp:TextBox ID="txtEndTime" runat="server" CssClass="input"  require="1"  errmsg="请输入正确的截止日期"  onclick="setday(this);" Text='<%#Bind("EndTime") %>'></asp:TextBox>
                                    </td>
                                </tr>   
                                 <tr  class="edit odd">
                                    <th>简介：</th>
                                    <td>
                                        <sw:TinyMce ID="txtDesc" runat="server" Height="500px" Text='<%# Bind("Intro") %>' />
                                    </td>
                                </tr>   
                            </table>
                                      
                                    
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存礼品" CommandName="Update" CssClass="submit"></asp:Button>
                                <asp:Button ID="btnDelete" runat="server" Text="删除该礼品" CommandName="Delete" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='ChangeGoodsList.aspx';">
                                    取 消</button>
                            </div>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr class="name">
                                    <th style="width: 100px;">
                                        礼品名称：</th>
                                    <td>
                                        <asp:TextBox ID="txtTitle" runat="server" CssClass="input" errmsg="请输入礼品名称" MaxLength="50" require="1" Width="308px" Text='<%#Bind("Name") %>'></asp:TextBox>不超过50个汉字。</td>
                                </tr>
                                <tr class="title">
                                    <th>
                                        礼品价格：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtprice" runat="server" CssClass="input" errmsg="请输入正确的礼品价格" MaxLength="20" require="1" datatype="double"  Text='<%#Bind("Price") %>'></asp:TextBox>RBM &nbsp;</td>
                                </tr>
                                <tr class="title">
                                    <th >
                                        礼品图片：                                           
                                    </th>
                                    <td>
                                        <asp:FileUpload ID="txtImage" runat="server" Width="280px" />
                                    </td> 
                                </tr>
                                
                                <tr>
                                    <th >换购积分：</th>
                                    <td>
                                     <asp:TextBox ID="txtScore" runat="server" CssClass="input" errmsg="请输入正确的积分" datatype="integer" require="1"  Text='<%#Bind("Score") %>'></asp:TextBox>
                                    </td>
                                </tr>   
                                <tr class="edit">
                                    <th >
                                     截止日期：
                                    </th>
                                    <td>
                                     <asp:TextBox ID="txtEndTime" runat="server" CssClass="input" errmsg="截止日期格式不正确" onclick="setday(this);" Text='<%#Bind("EndTime") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr class="edit odd">
                                    <th >简介：</th>
                                    <td>
                                        <sw:TinyMce ID="txtContent" runat="server" Height="500px" Text='<%# Bind("Intro") %>' />
                                    </td>
                                </tr>      
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text=" 保存礼品" CommandName="Insert" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='ChangeGoodsList.aspx';">
                                    取 消</button>
                            </div>
                        </InsertItemTemplate>
                    </asp:FormView>
                    <asp:ObjectDataSource ID="ods3" runat="server" DataObjectTypeName="Common.Common.ChangeGoods" InsertMethod="AddChangeGoods" SelectMethod="GetChangeGoodsByID" TypeName="Common.Agent.ChangeGoodsAgent" UpdateMethod="UpdateChangeGoods" OnSelecting="ods3_Selecting" OnInserted="ods3_Inserted" OnInserting="ods3_Inserting" OnUpdating="ods3_Updating" OnUpdated="ods3_Updated" DeleteMethod="DeleteChangeGoods" OnDeleted="ods3_Deleted" >
                        <SelectParameters>
                            <asp:Parameter Name="cid" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>

