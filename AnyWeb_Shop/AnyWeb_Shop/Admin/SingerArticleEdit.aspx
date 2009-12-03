<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SingerArticleEdit.aspx.cs" Inherits="SingerArticleEdit" Title="编辑单篇文章栏目" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
   <li>文件名称最好填写与栏目意思相近的英文名称。例:栏目为书，文件名为book。</li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
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
                    <asp:Panel ID="Panel1" runat="server">
                            <table class="iEditForm iEditBaseInf">
                                <tr class="name odd">
                                    <th style="width:120px;">
                                        文章栏目名称：</th>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="input" errmsg=" *请输入正确的文章标题"  require="1" MaxLength="50" Width="308px" Text='<%#Eval("OfCategory.Name") %>'></asp:TextBox>&nbsp;不超过50个汉字。</td>
                                </tr>
                                <tr class="path">
                                    <th>
                                        文件名称：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPath" runat="server" datatype="english" CssClass="input" errmsg=" *请输入正确的文件名称,英文格式" MaxLength="20" require="1" Width="208px" Text='<%#Eval("OfCategory.Path") %>'></asp:TextBox>&nbsp;请输入字母名称，不超过20个字。例：book</td>
                                </tr>
                                 <tr class="odd edit">
                                    <th>
                                        文章内容：
                                    </th>
                                    <td>
                                        <sw:TinyMce ID="txtContent" runat="server" Height="500px" /></td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSaveUpdate" runat="server" Text="保存类别" CommandName="Update" CssClass="submit" OnClick="btnSaveUpdate_Click"></asp:Button>
                                <asp:Button ID="btnDelete" runat="server" Text="删除该栏目" CommandName="Delete" CssClass="submit" OnClick="btnDelete_Click"></asp:Button>
                                <button  onclick="window.location='/ArticleCategoryList.aspx';" type="button">取 消</button>
                            </div>
                      </asp:Panel>
                       <asp:Panel ID="Panel2" runat="server">
                            <table class="iEditForm iEditBaseInf" >
                                <tr class="name odd">
                                    <th  style="width:120px;">
                                        文章栏目名称：</th>
                                    <td>
                                        <asp:TextBox ID="txtNameAdd" runat="server" CssClass="input" errmsg=" *请输入正确的类别标题" MaxLength="50" require="1" Width="408px" Text=""></asp:TextBox>&nbsp;不超过50个汉字。</td>
                                </tr>
                                <tr class="path">
                                    <th>
                                        文件名称：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPathAdd" runat="server" CssClass="input" errmsg=" *请输入正确的文件名称,英文格式" datatype="english" MaxLength="20" require="1" Width="208px" Text=""></asp:TextBox>&nbsp;请输入字母名称，不超过20个字。例：book</td>
                                </tr>
                                <tr class="odd edit">
                                    <th>
                                        文章内容：
                                    </th>
                                    <td>
                                        <sw:TinyMce ID="txtContentAdd" runat="server" Height="500px" Text='<%# Bind("AdContent") %>' />
                                    </td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSaveAdd" runat="server" Text="保存类别" CommandName="Insert" CssClass="submit"  OnClick="btnSaveAdd_Click"></asp:Button>
                                <button id="btnBack" onclick="window.location='/ArticleCategoryList.aspx';">
                                    取 消</button>
                            </div>
                        </asp:Panel>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>

