<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="GoodsCategorhandle.aspx.cs" Inherits="GoodsCategorhandle" Title="商品类别管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">

<li>添加一个类别，系统自动创建一个组件,您可以放到相应位置,以方便用户浏览</li>
               
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
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
                    <asp:FormView ID="fv1" runat="server" DataKeyNames="ID" Width="100%" DefaultMode="Edit" OnDataBound="fv1_DataBound" DataSourceID="ods3">
                        <EditItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr>
                                    <th>
                                        商品类别名称：</th>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="input" errmsg="请输入正确的商品类别" MaxLength="50" require="1" Width="308px" Text='<%#Bind("Name") %>'></asp:TextBox>&nbsp;不超过50个汉字。</td>
                                </tr>
                                <tr id="ofType">
                                    <th>
                                        所属类别：
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpPater" runat="server" DataSourceID="ods4" DataTextField="Name" DataValueField="ID">
                                        </asp:DropDownList></td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存类别" CommandName="Update" CssClass="submit"></asp:Button>
                                <asp:Button ID="btnDelete" runat="server" Text="删除该商品类别" CommandName="Delete" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='GoodsCategoryList.aspx';" type="button">
                                    取 消</button>
                            </div>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr>
                                    <th>
                                        商品类别名称：</th>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="input" errmsg="请输入正确的商品类别" MaxLength="50" require="1" Width="408px" Text='<%#Bind("Name") %>'></asp:TextBox>&nbsp;不超过50个汉字。</td>
                                </tr>
                                <tr  id="ofType">
                                    <th>
                                        所属类别：
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpPater" runat="server" DataSourceID="ods4" DataTextField="Name" DataValueField="ID">
                                        </asp:DropDownList></td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存类别" CommandName="Insert" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='GoodsCategoryList.aspx';">
                                    取 消</button>
                            </div>
                        </InsertItemTemplate>
                    </asp:FormView>
                    <asp:ObjectDataSource ID="ods3" runat="server" DataObjectTypeName="Common.Common.Category" DeleteMethod="DeleteCategory" InsertMethod="AddCategory" SelectMethod="GetCategoryByid" TypeName="Common.Agent.CategoryAgent" UpdateMethod="UpdateCategory" OnDeleted="ods3_Deleted" OnInserted="ods3_Inserted" OnUpdated="ods3_Updated" OnInserting="ods3_Inserting" OnUpdating="ods3_Updating">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="id" QueryStringField="cid" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ods4" runat="server" TypeName="Common.Agent.CategoryAgent" SelectMethod="GetCategoryList"></asp:ObjectDataSource>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
