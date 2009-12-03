<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ShopArticleEdit.aspx.cs" Inherits="ShopArticleEdit" Title="商城文章编辑" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
<li></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    商城指南编辑</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                    <!--表单部分[[-->
                    <!--最后用label标签里的for属性和input里的id相对应-->
                    <asp:FormView ID="fv1" runat="server" DataKeyNames="ID" Width="100%" DataSourceID="ods3"  DefaultMode="Edit">
                        <EditItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr >
                                    <th style="width: 100px;">
                                        商城指南标题：</th>
                                    <td>
                                        <asp:TextBox ID="txtTitle" runat="server" CssClass="input" errmsg="请输入正确的文章标题" MaxLength="50" require="1" Width="308px" Text='<%#Bind("Title") %>'></asp:TextBox>&nbsp;不超过50个汉字。</td>
                                </tr>
                                <tr class="edit odd">
                                    <th >
                                        指南内容：                                           
                                    </th>
                                    <td> <div style="margin: 10px 0px">
                                            【请将字数控制在10000字以内。】</div></td>
                                    
                                </tr>
                                <tr class="edit odd">
                                    <td colspan="2">
                                        <sw:TinyMce ID="txtContent" runat="server" Height="500px" Text='<%# Bind("Content") %>' />
                                    </td>
                                </tr>      
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存文章" CommandName="Update" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='ShopArticleList.aspx';">
                                    取 消</button>
                            </div>
                        </EditItemTemplate>
                    </asp:FormView>
                    <asp:ObjectDataSource ID="ods3" runat="server" DataObjectTypeName="Common.Common.Article" SelectMethod="GetArticleByid" TypeName="Common.Agent.ArticleAgent" UpdateMethod="UpdateSysArticle" OnSelecting="ods3_Selecting" OnUpdated="ods3_Updated" >
                        <SelectParameters>
                            <asp:Parameter Name="id" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>

