<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="BasicInfoManage.aspx.cs" Inherits="BasicInfoManage" Title="商户资料管理" %>

<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    
                <li>企业基本资料填写页面，除商店域名不可修改、自定义域名可不填写外，其它信息都为必填项。</li>
                <li>商店标志，建议上传gif、jpg格式的图片。</li>
           
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    商户资料管理</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                    <!--表单部分[[-->
                    <!--最后用label标签里的for属性和input里的id相对应-->
                    <asp:FormView ID="fv1" runat="server" DataKeyNames="ID" Width="100%" DataSourceID="ods3" DefaultMode="Edit" >
                        <EditItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr class="name odd">
                                    <th style="width: 120px;">
                                        店主名称：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtOwner" runat="server" CssClass="input" errmsg="请输入正确的店主姓名" MaxLength="50" require="1" Width="308px" Text='<%#Bind("ShopMaster") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        商店域名：</th>
                                    <td>
                                        <%#Eval("ShopAcc") %>
                                    </td>
                                </tr>
                                <tr class="title odd">
                                    <th>
                                        商店名称：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtShopName" runat="server" CssClass="input" errmsg="请输入正确的商店名称" MaxLength="50" require="1" Width="308px" Text='<%#Bind("Name") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="logo">
                                    <th>
                                        商店标志：
                                    </th>
                                    <td id="tdimg" >
                                        <asp:FileUpload ID="fileLog" runat="server" Width="300px" />&nbsp;不修改请留空。
                                        <asp:HiddenField ID="hidLogo" runat="server" Value='<%#Eval("Logo") %>' />
                                        <span style='display:<%#(string)Eval("Logo")==""?"none":"block"%>'><img src='<%=ShopInfo.DataPath%><%#Eval("Logo")%>' alt='<%#Eval("Name") %>'  />
                                        <asp:Button ID="btnDelImg" runat="server" Text="删除logo" nocheck="true" OnClick="btnDelImg_Click" /></span>
                                    </td>
                                </tr>
                                <%--<tr class="acc odd">
                                    <th>
                                        自定义域名：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtDomain" runat="server" CssClass="input" MaxLength="50" Text='<%#Bind("DomainName") %>'></asp:TextBox>
                                    </td>
                                </tr>--%>
                                <tr class="phone">
                                    <th>
                                        电话：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPhone" runat="server" CssClass="input" errmsg="请输入正确的电话" MaxLength="50"  Text='<%#Bind("TelePhone") %>' datatype="phone"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="mobile odd">
                                    <th>
                                        手机：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtMobile" runat="server" CssClass="input" errmsg="请输入正确的手机号码" MaxLength="50"  Width="200px" Text='<%#Bind("Mobile") %> ' datatype="mobile"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="post">
                                        邮政编码：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPost" runat="server" CssClass="input" errmsg="请输入正确的邮编" MaxLength="10"  Text='<%#Bind("PostCode") %>' datatype="zip"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="fax odd">
                                    <th>
                                        传真：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtFax" runat="server" CssClass="input" errmsg="请输入正确的传真" MaxLength="30"  Text='<%#Bind("Fax") %>'  datatype="fax"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="addr">
                                        地址：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtAddr" runat="server" CssClass="input" errmsg="请输入正确的地址" MaxLength="200" require="1" Width="600px" Text='<%#Bind("Address") %>'></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存资料" CommandName="Update" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="javascript:history.back(-1);">
                                    取 消</button>
                            </div>
                        </EditItemTemplate>
                    </asp:FormView>
                    
                    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetShopBasicInfo" TypeName="Common.Agent.ShopAgent" DataObjectTypeName="Common.Common.Shop" UpdateMethod="UpdateBasicInfo" OnUpdating="ods3_Updating" OnUpdated="ods3_Updated"></asp:ObjectDataSource>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
