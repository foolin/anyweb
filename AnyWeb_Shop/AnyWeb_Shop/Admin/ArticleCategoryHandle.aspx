<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ArticleCategoryHandle.aspx.cs" Inherits="ArticleCategoryHandle" Title="文章栏目管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
   
<li>添加一个栏目系统将动态生成一个组件，您可以把它放到系统的相应位置,以方便客户浏览</li>
         
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
                    <asp:FormView ID="fv1" runat="server" DataKeyNames="ID" DefaultMode="Edit" Width="100%" DataSourceID="ods3">
                        <EditItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr class="name odd">
                                    <th>
                                        文章栏目名称：</th>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="input" errmsg="请输入正确的文章标题"  require="1" MaxLength="50" Width="308px" Text='<%#Bind("Name") %>'></asp:TextBox>&nbsp;不超过50个汉字。</td>
                                </tr>
                                <tr class="path">
                                    <th>
                                        文件名称：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPath" runat="server" CssClass="input" errmsg="请输入正确的文件名称" MaxLength="20" require="1" Width="208px" Text='<%#Bind("Path") %>'></asp:TextBox>&nbsp;请输入与栏目意思相近的英文名称。例:book。</td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存类别" CommandName="Update" CssClass="submit"></asp:Button>
                                <asp:Button ID="btnDelete" runat="server" Text="删除该栏目" CommandName="Delete" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='ArticleCategoryList.aspx';" type="button">
                                    取 消</button>
                            </div>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr class="name odd">
                                    <th>
                                        类别名称：</th>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="input" errmsg="请输入正确的类别标题" MaxLength="50" require="1" Width="408px" Text='<%#Bind("Name") %>'></asp:TextBox>&nbsp;不超过50个汉字。</td>
                                </tr>
                                <tr class="path">
                                    <th>
                                        文件名称：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPath" runat="server" CssClass="input" errmsg="请输入正确的文件名称" MaxLength="20" require="1" Width="208px" Text='<%#Bind("Path") %>'></asp:TextBox>&nbsp;请输入与栏目意思相近的英文名称。例:book。</td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="提交保存" CommandName="Insert" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='ArticleCategoryList.aspx';">
                                    取 消</button>
                            </div>
                        </InsertItemTemplate>
                    </asp:FormView>
                    <asp:ObjectDataSource ID="ods3" runat="server" DataObjectTypeName="Common.Common.Category" DeleteMethod="DeleteCategory" InsertMethod="AddCategory" SelectMethod="GetCategoryByid" TypeName="Common.Agent.CategoryAgent" UpdateMethod="UpdateCategory" OnDeleted="ods3_Deleted" OnInserted="ods3_Inserted" OnUpdated="ods3_Updated" OnInserting="ods3_Inserting" OnUpdating="ods3_Updating" OnDeleting="ods3_Deleting">
                        <DeleteParameters>
                            <asp:Parameter Name="id" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:QueryStringParameter Name="id" QueryStringField="cid" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
