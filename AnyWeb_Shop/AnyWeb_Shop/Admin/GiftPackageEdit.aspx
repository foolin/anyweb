<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
 CodeFile="GiftPackageEdit.aspx.cs" Inherits="Admin_GiftPackageEdit" Title="大礼包管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
    <li>查看大礼包时，点击[编辑大礼包]可以编辑大礼包</li>
    <li>查看大礼包时，点击[管理商品]可以对该大礼包商品进行添加、删除</li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    <asp:Literal ID="litTitle" runat="server"></asp:Literal>
                    <span class="listadd"><a href="GiftPackGoodsAdd.aspx?pid=<%=QS("packID") %>">添加商品</a></span>
                    <span class="listadd"><a href="GiftPackGoodsEdit.aspx?pid=<%=QS("packID") %>">管理商品</a></span>
                </h2>
                    
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                <!--表单部分[[-->
                <!--最后用label标签里的for属性和input里的id相对应-->
                <asp:FormView ID="fv1" runat="server" DataKeyNames="ID" Width="100%" DataSourceID="ods3"
                    OnDataBound="fv1_DataBound">
                    <ItemTemplate>
                        <table class="iEditForm iEditBaseInf">
                            <tr>
                                <th style="width: 110px;">
                                    礼包名称：
                                </th>
                                <td colspan="2">
                                    <%#Eval("PackName") %>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    礼包编号：
                                </th>
                                <td>
                                    <%#Eval( "PackNo" )%>
                                </td>
                                <td rowspan="8" style="text-align: center; width: 226px; background-color: White;
                                    border-left: solid 1px gray; border-right: solid 1px gray;">
                                    <img src='<%#(string)Eval( "Image" )=="" ? "../images/wait.jpg":(string)Eval( "Image" ) %>'
                                        alt="点击查看原图" onload="javascript:if(this.width>200)this.width=200" onclick="window.open(this.src);"
                                        style="cursor: hand;" />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    价格：
                                </th>
                                <td>
                                    <%#Eval("Price","{0:c}")%>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    前台显示：
                                </th>
                                <td>
                                    <%#(bool)Eval("IsShow")==true? "是":"否"%>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                  大礼包介绍
                                </th>
                                <td>
                                    <%#Eval("Intro")%>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    商品：
                                </th>
                                <td>
                                    <%#Eval("GoodsIds")%>  &nbsp;&nbsp;<button id="btnViewGoods1" onclick="window.location='GiftPackGoodsEdit.aspx?pid=<%#Eval("PackID")%>';"
                                type="button">
                                查看商品</button>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    详细情况：
                                </th>
                                <td colspan="2" style="padding-right: 10px; line-height: 23px;">
                                    <%#Eval( "Description" )%>
                                </td>
                            </tr>
                        </table>
                        <div class="iSubmit">
                            <button id="btnViewGoods2" onclick="window.location='GiftPackGoodsEdit.aspx?pid=<%#Eval("PackID")%>';"
                                type="button" class="submit">
                                管理商品</button>
                            <button id="btnEdit" onclick="window.location='GiftPackageEdit.aspx?mode=update&packID=<%#Eval("PackID")%>';"
                                type="button" class="submit">
                                编辑大礼包</button>
                            <asp:Button ID="btnDelete" runat="server" Text="删除该大礼包" CommandName="Delete" CssClass="submit">
                            </asp:Button>
                            <button id="btnBack" onclick="history.go(-1);" type="button">
                                返回</button>
                        </div>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <table class="iEditForm iEditBaseInf">
                            <tr>
                                <th style="width: 120px;">
                                    大礼包名称：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtPackName" runat="server" CssClass="input" errmsg="请输入正确的大礼包名称" MaxLength="50"
                                        require="1" Width="308px" Text='<%#Bind("PackName") %>'></asp:TextBox>&nbsp;不超过50个汉字。
                                </td>
                            </tr>
                            <tr class="name">
                                <th>
                                    大礼包编号：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtPackNo" runat="server" Text='<%#Bind("PackNo")%>' CssClass="input"
                                        errmsg="请输入正确的编号" MaxLength="50" require="1" Width="200px"></asp:TextBox>
                                        参考：AF0101-0108
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    礼包图片：
                                </th>
                                <td>
                                    <div style="margin: 10px 0px;">
                                        <asp:FileUpload ID="txtImage" runat="server" Width="280px" />不更改请留空.</div>
                                    <asp:HiddenField ID="hidimg" runat="server" Value='<%# Bind("Image") %>' />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    价格：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtPrice" runat="server" CssClass="input"
                                        MaxLength="10" Width="100px" Text='<%# Bind("Price") %>'></asp:TextBox>RMB
                                    该大礼包的价格
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    大礼包简介：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtIntro" runat="server" Text='<%#Bind("Intro")%>' CssClass="input"
                                        TextMode="MultiLine" MaxLength="1000" Height="60px" Width="500px"></asp:TextBox>不超过1000个字。
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    其他设置：
                                </th>
                                <td>
                                    <asp:CheckBox ID="chkIsShow" runat="server" Checked='<%#Bind("IsShow")%>' />是否前台显示
                                    【不允许请留空。】
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    大礼包描述：
                                </th>
                                <td>
                                    【请将字数控制在250字以内。】
                                </td>
                            </tr>
                            <tr class="edit odd" style="text-align: center;">
                                <td colspan="2">
                                    <sw:TinyMce ID="txtDescription" runat="server" Height="500px" Text='<%# Bind("Description") %>' />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    排序：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtSort" runat="server" Text='<%#Bind("Sort") %>' CssClass="input" require="1" errmsg="请输入正确的排序"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <div class="iSubmit">
                            <asp:Button ID="btnSave" runat="server" Text="保存大礼包" CommandName="Update" CssClass="submit">
                            </asp:Button>
                            <asp:Button ID="btnDelete" runat="server" Text="删除该大礼包" CommandName="Delete" CssClass="submit">
                            </asp:Button>
                            <button id="btnBack" onclick="window.location='GiftPackageList.aspx';">
                                取 消</button>
                        </div>

                    

                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table class="iEditForm iEditBaseInf">
                            <tr>
                                <th style="width: 120px;">
                                    大礼包名称：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtPackName" runat="server" CssClass="input" errmsg="请输入正确的大礼包名称" MaxLength="50"
                                        require="1" Width="308px" Text='<%#Bind("PackName") %>'></asp:TextBox>&nbsp;不超过50个汉字。
                                </td>
                            </tr>
                            <tr class="name">
                                <th>
                                    大礼包编号：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtPackNo" runat="server" Text='<%#Bind("PackNo")%>' CssClass="input"
                                        errmsg="请输入正确的大礼包型号" MaxLength="50" require="1" Width="200px"></asp:TextBox>
                                        参考：AF0101-0108
                                </td>
                            </tr>
                       
                            <tr>
                                <th>
                                    商品图片：
                                </th>
                                <td>
                                    <div style="margin: 10px 0px;">
                                        <asp:FileUpload ID="txtImage" runat="server" Width="300px" /></div>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    价格：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtPrice" runat="server" CssClass="input" Text='<%# Bind("Price") %>'
                                        MaxLength="10" require="1" errmsg="请输入正确的大礼包价格"  Width="100px"></asp:TextBox>RMB
                                    该大礼包销售价格
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    其它设置：
                                </th>
                                <td>
                                    <asp:CheckBox ID="chkIsShow" runat="server" Checked='<%#Bind("IsShow")%>' />设置为前台显示
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    大礼包介绍：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtIntro" runat="server" Text='<%#Bind("Intro")%>' CssClass="input"
                                        TextMode="MultiLine" MaxLength="1000" Width="500px" Height="60px"></asp:TextBox>不超过250个字。
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    详细信息：
                                </th>
                                <td>
                                    【请将字数控制在10000字以内。】
                                </td>
                            </tr>
                            <tr class="edit odd" style="text-align: center;">
                                <td colspan="2">
                                    <sw:TinyMce ID="txtDescription" runat="server" Height="500px" Text='<%# Bind("Description") %>' />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    排序：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtSort" runat="server" Text='0' CssClass="input"></asp:TextBox>排序为0时系统自动分配
                                </td>
                            </tr>
                        </table>
                        <div class="iSubmit">
                            <asp:Button ID="btnSave" runat="server" Text=" 保存大礼包并继续" CommandName="Insert" CssClass="submit">
                            </asp:Button>
                            <button id="btnBack" onclick="window.location='GiftPackageList.aspx';" type="button">
                                取 消</button>
                        </div>

                     

                    </InsertItemTemplate>
                </asp:FormView>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>

    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetGiftPackageByID" TypeName="Common.Agent.GiftPackageAgent"
        OnSelecting="ods3_Selecting" OnInserted="ods3_Inserted" OnInserting="ods3_Inserting"
        OnUpdated="ods3_Updated" OnUpdating="ods3_Updating" DataObjectTypeName="Common.Common.GiftPackage"
        InsertMethod="AddGiftPackage" UpdateMethod="UpdateGiftPackage" DeleteMethod="DeleteGiftPackage"
        OnDeleted="ods3_Deleted" OnDeleting="ods3_Deleting">
        <SelectParameters>
            <asp:Parameter Name="packID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
</asp:Content>

