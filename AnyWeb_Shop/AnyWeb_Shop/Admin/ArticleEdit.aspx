<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ArticleEdit.aspx.cs" Inherits="ArticleEdit" Debug="true" Title="文章管理"  validateRequest="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <li></li>
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
                    <asp:FormView ID="fv1" runat="server" DataKeyNames="ID" Width="100%" DataSourceID="ods3" OnDataBound="fv1_DataBound">
                        <ItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr class="name odd">
                                    <th style="width: 120px;">
                                        文章标题：</th>
                                    <td>
                                        <%#Eval("Title") %>
                                    </td>
                                </tr>
                                <tr >
                                    <th>
                                        创建时间：</th>
                                    <td>
                                        <%#Eval("CreateAt","{0:yyyy-MM-dd}")%>
                                    </td>
                                </tr>
                                <tr >
                                    <th>
                                        所属类别：
                                    </th>
                                    <td>
                                        <%#Eval("OfCategory.Name") %>
                                    </td>
                                </tr>
                                <tr >
                                    <th>
                                        文章内容：
                                    </th>
                                    <td style="width: 660px; overflow: hidden; line-height:25px;">
                                        <%#Eval("Content") %>
                                    </td>
                                </tr>
                                <tr >
                                    <th>
                                        是否允许评论：
                                    </th>
                                    <td>
                                        <%#(bool)Eval("IsComment")==true ? "允许评论":"不允许评论"%>
                                    </td>
                                </tr>
                                <tr >
                                    <th>
                                        点击数：
                                    </th>
                                    <td>
                                        <%#Eval("ClickCount") %>
                                    </td>
                                </tr>
                                <tr style="display: <%#(bool)Eval("IsComment")==true? "block":"none"%>">
                                    <th>
                                        评论数：
                                    </th>
                                    <td>
                                        <%#Eval("CommentCount") %>
                                        条评论
                                    </td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <span style="display: <%#(bool)Eval("IsComment")==true? "":"none"%>">
                                    <button id="btnComment" onclick="window.location='CommentList.aspx?tid=1&sid=<%#Eval("ID") %>';" type="button" class="submit">
                                        查看该文章评论</button></span>
                                <asp:Button ID="btnDelete" runat="server" Text="删除该文章" CommandName="Delete" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='ArticleList.aspx';">
                                    返回列表</button>
                            </div>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr class="name odd">
                                    <th style="width: 120px;">
                                        文章标题：</th>
                                    <td>
                                        <asp:TextBox ID="txtTitle" runat="server" CssClass="input" errmsg="请输入正确的文章标题" MaxLength="50" require="1" Width="308px" Text='<%#Bind("Title") %>'></asp:TextBox>&nbsp;不超过50个汉字。</td>
                                </tr>
                                <tr class="title">
                                    <th>
                                        所属类别：
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpType" runat="server" DataSourceID="ods4" DataValueField="ID" DataTextField="Name">
                                        </asp:DropDownList> 
                                    </td>
                                </tr>
                                <tr class="title odd">
                                    <th >
                                        文章内容：                                           
                                    </th>
                                    <td> <div style="margin: 10px 0px">
                                            【请将字数控制在10000字以内。】</div></td>
                                    
                                </tr>
                                <tr class="edit odd">
                                    <td colspan="2">
                                        <sw:TinyMce ID="compArtiContent" runat="server" Height="500px" Text='<%# Bind("Content") %>' />
                                    </td>
                                </tr>      
                                <tr>
                                    <th>
                                        是否允许评论：
                                    </th>
                                    <td>
                                        <asp:CheckBox ID="chkComm" runat="server" Checked='<%#Bind("IsComment")%>' />允许评论 【不允许请留空。】
                                    </td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存文章" CommandName="Update" CssClass="submit"></asp:Button>
                                <asp:Button ID="btnDelete" runat="server" Text="删除该文章" CommandName="Delete" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='ArticleList.aspx';">
                                    取 消</button>
                            </div>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr class="name odd">
                                    <th style="width: 120px;">
                                        文章标题：</th>
                                    <td>
                                        <asp:TextBox ID="txtTitle" runat="server" CssClass="input" errmsg="请输入正确的文章标题" MaxLength="50" require="1" Width="308px" Text='<%#Bind("Title") %>'></asp:TextBox>&nbsp;不超过50个汉字。</td>
                                </tr>
                                <tr class="title">
                                    <th>
                                        所属类别：
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpType" runat="server" DataSourceID="ods4" DataValueField="ID" DataTextField="Name">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr class="title odd">
                                    <th>
                                        文章内容：
                                    </th>
                                    <td>
                                        <div style="margin: 10px 0px">
                                            【请将字数控制在10000字以内。】</div>
                                       
                                    </td>
                                </tr>
                                <tr class="edit odd"><td colspan="2">
                                     <sw:TinyMce ID="compArtiContent" runat="server" Height="500px" Text='<%# Bind("Content") %>' /></td>
                                </tr>
                                <tr>
                                    <th>
                                        是否允许评论：E:\Documents and Settings\Administrator\桌面\AnyWeb_Shop\Common\Common\Complaints.cs
                                    </th>
                                    <td>
                                        <asp:CheckBox ID="chkComm" runat="server" Checked='<%#Bind("IsComment")%>' />允许评论 【不允许请留空。】
                                    </td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text=" 保存文章" CommandName="Insert" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='ArticleList.aspx';">
                                    取 消</button>
                            </div>
                        </InsertItemTemplate>
                    </asp:FormView>
                    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetArticleByid" TypeName="Common.Agent.ArticleAgent" OnSelecting="ods3_Selecting" OnInserting="ods3_Inserting" DataObjectTypeName="Common.Common.Article" InsertMethod="AddArticle" OnInserted="ods3_Inserted" OnUpdated="ods3_Updated" OnUpdating="ods3_Updating" UpdateMethod="UpdateArticle" DeleteMethod="ArticlesDeletes" OnDeleted="ods3_Deleted">
                        <SelectParameters>
                            <asp:Parameter Name="id" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ods4" runat="server" SelectMethod="GetArticleType" TypeName="Common.Agent.CategoryAgent"></asp:ObjectDataSource>

                    <script type="text/javascript">
                      	function showDesc()
						{
							document.getElementById("divDesc").style.display=document.getElementById("_ctl0_cph1_fv1_chkAutoDesc").checked?'none':'block';
							
						} 

                    </script>

                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
