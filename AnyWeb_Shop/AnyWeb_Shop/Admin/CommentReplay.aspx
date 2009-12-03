<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="CommentReplay.aspx.cs" Inherits="CommentReplay" Title="回复评论"  ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">

       <li></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    回复评论</h2>
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
                                <tr class="name ">
                                    <th style="width: 90px;">
                                        评论内容：</th>
                                    <td  >
                                       <div style="text-decoration:underline; ">【<%#Eval( "CommentAt" , "{0:yyyy年MM月dd日}" )%> <%#"<span style='font-size:14px;color:#990000;font-weight:bold'>"+Eval("UserName")+"</span>" %> 说：】</div>
                                       <div style="line-height:28px; background:url(images/pl.gif) 0 0 no-repeat; padding-left:25px; margin:8px 16px 0px 0px;"><%#Eval("Content") %></div>
                                    </td>
                                </tr>
                                <tr class="odd edit">
                                    <th>
                                        店长回复：
                                    </th>
                                    <td>
                                        <sw:TinyMce ID="txtReplay" runat="server" Height="500px" />
                                    </td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="回复评论" CommandName="Update" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='CommentList.aspx';" type="button">返 回</button>
                            </div>
                        </EditItemTemplate>
                    </asp:FormView>
                    
                    <asp:ObjectDataSource ID="ods3" runat="server" DataObjectTypeName="Common.Common.Comment" SelectMethod="GetReplayByID" TypeName="Common.Agent.CommentAgent" UpdateMethod="UpdateReplay" OnUpdated="ods3_Updated" >
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="0" Name="cid" QueryStringField="cid" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
