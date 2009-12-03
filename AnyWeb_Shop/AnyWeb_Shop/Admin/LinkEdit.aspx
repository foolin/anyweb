<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="LinkEdit.aspx.cs" Inherits="LinkEdit" Title="链接管理" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">

 <li>上传图片则直接在商城首页显示图片，图片按上传图片的大小显示。</li>
         
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
               
                    <asp:FormView ID="fv1" runat="server" DataSourceID="ods3" DataKeyNames="ID" Width="100%">
                         <InsertItemTemplate>
                           <table class="iEditForm iEditBaseInf">
                                <tr class="name odd">
                                    <th style="width: 120px;">
                                        链接名称：</th>
                                    <td >
                                        <asp:TextBox ID="txtName" runat="server" Text='<%#Bind("Name") %>'  CssClass="text" MaxLength="50" errmsg="请输入正确的链接名称"  require="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="name">
                                    <th>
                                        链接图片：
                                    </th>
                                      <td>
                                        <asp:FileUpload ID="fileImg" runat="server" Width="300px"  CssClass="text"  />【图片按上传图的大小显示】
                                     
                                    </td>
                                    
                                </tr>
                                 <tr class="name odd">
                                    <th >
                                        链接地址：</th>
                                    <td >
                                    <asp:TextBox ID="txtUrl" runat="server" Width="300px" Text='<%#Bind("LinkUrl") %>'  CssClass="text" MaxLength="100" errmsg="请输入正确的链接地址"  require="1"></asp:TextBox>
                                        
                                    </td>
                                </tr>
                                 <tr class="name">
                                    <th >
                                        排序：</th>
                                    <td >
                                    <asp:TextBox ID="txtSort" runat="server" Text='<%#Bind("Sort") %>'  CssClass="text" MaxLength="3" Width="100px" errmsg="请输入正确的排序"  require="1" datatype="integer"></asp:TextBox>
                                      
                                    </td>
                                </tr>
                                </table>
                                <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text=" 保存链接" CommandName="Insert" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='LinkList.aspx';" type="button">
                                    取 消</button>
                            </div>
                         </InsertItemTemplate>
                        <EditItemTemplate>
                        <table class="iEditForm iEditBaseInf">
                                <tr class="name odd">
                                    <th style="width: 120px;">
                                        链接名称：</th>
                                    <td >
                                        <asp:TextBox ID="txtName" runat="server" Text='<%#Bind("Name") %>'  CssClass="text" MaxLength="50"  errmsg="请输入正确的商品名称"  require="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="name">
                                    <th>
                                        链接图片：
                                    </th>
                                        
                                    <td>
                                        <asp:FileUpload ID="fileImg" runat="server" Width="300px" />【图片按上传图的大小显示】
                                       <span style="display:<%#(string)Eval("Image")==""? "none":"block" %>"><img src="<%#Eval("Image") %>" alt=""  /><asp:Button ID="btnDelImg" runat="server" Text="删除图片" OnClick="btnDelImg_Click" /></span> 
                                        <asp:HiddenField ID="hidImg" runat="server"  Value='<%#Eval("Image") %>'/>
                                    </td>
                                    
                                </tr>
                                 <tr class="name odd">
                                    <th >
                                        链接地址：</th>
                                    <td >
                                    <asp:TextBox ID="txtUrl" runat="server" Width="300px" Text='<%#Bind("LinkUrl") %>'  CssClass="text" MaxLength="100" errmsg="请输入正确的链接地址"  require="1"></asp:TextBox>
                                        
                                    </td>
                                </tr>
                                 <tr class="name">
                                    <th >
                                        排序：</th>
                                    <td >
                                    <asp:TextBox ID="txtSort" runat="server" Text='<%#Bind("Sort") %>'  CssClass="text" MaxLength="3" Width="100px" errmsg="请输入正确的排序"  require="1" datatype="number"></asp:TextBox>
                                      
                                    </td>
                                </tr>
                                </table>
                                 <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存链接" CommandName="Update" CssClass="submit"></asp:Button>
                                <asp:Button ID="btnDelete" runat="server" Text="删除该链接" CommandName="Delete" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='LinkList.aspx';">
                                    取 消</button>
                            </div>
                        </EditItemTemplate>
                    </asp:FormView>
                </form>
                <asp:ObjectDataSource ID="ods3" runat="server" DataObjectTypeName="Common.Common.Link" DeleteMethod="LinkDelete" SelectMethod="GetLinkByID" TypeName="Common.Agent.LinkAgent" OnInserting="ods3_Inserting" OnDeleted="ods3_Deleted" OnInserted="ods3_Inserted" OnUpdated="ods3_Updated" OnUpdating="ods3_Updating" UpdateMethod="LinkUpdate" InsertMethod="LinkAdd" >
                    <SelectParameters>
                        <asp:QueryStringParameter Name="linkid" QueryStringField="lid" Type="Int32" DefaultValue="0" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="mft">
        </div>
</div>
</asp:Content>

