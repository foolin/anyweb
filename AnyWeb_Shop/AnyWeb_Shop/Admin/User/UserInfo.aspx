<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="User_UserInfo" Title="查看详细" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
<script type="text/javascript" src="../public/ajax.js"></script>
      <li></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
<div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    会员详细信息</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                    <asp:FormView ID="fv1" runat="server" DataKeyNames="ID" Width="100%" DataSourceID="ods3">
                        <ItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr>
                                    <th style="width: 120px;">
                                        会员编号：</th>
                                    <td style="width: 220px;">
                                        <%#Eval("ID") %>
                                    </td>
                                    <th style="width: 120px;">
                                        登陆帐号：</th>
                                    <td>
                                        <%#Eval("MemberAcc")%>
                                    </td>
                                </tr>
                                <tr >
                                    <th>
                                    姓名：
                                    </th>
                                    <td>
                                        <%# Eval("MemberName") %>
                                    </td>
                                    <th>
                                        注册时间：
                                    </th>
                                    <td>
                                        <%# Eval("CreateAt","{0:yyyy-MM-dd}") %>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        性别：
                                    </th>
                                    <td>
                                       <%# Convert.ToInt32(Eval("Sex")) == 1 ?"男":"女" %>
                                    </td>
                                       <th>
                                        等级：
                                    </th>
                                    <td>
                                        <%#Eval( "GradeName" )%>( <%#Eval( "GradeID" )%>级)
                                    </td>
                                  
                                </tr>
                               
                                <tr >
                                    <th>
                                        积分：
                                    </th>
                                    <td>
                                        <%#Eval("Point")%>
                                    </td> 
                                     <th>
                                        预付款：

                                    </th>
                                    <td >
                                        <%#Eval("Advance", "{0:c}")%>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        邮政编码：
                                    </th>
                                    <td>
                                        <%#Eval("Postalcode")%>
                                    </td>
     
                                    <th>
                                        状态：
                                    </th>
                                    <td>
                                          <%# Convert.ToInt32(Eval("Status")) ==0?"<font color='green'>正常</font>":"<font color='red'>冻结</font>"  %>
                                    </td>
                                </tr>
                                 <tr>
                                    <th>
                                        移动电话：
                                    </th>
                                    <td>
                                        <%#Eval("Mobile")%>
                                    </td>
                                   <th>
                                       固话：
                                    </th>
                                    <td>
                                        <%# Eval("Phone")%>
                                    </td>
                                </tr>
                               
                               
                                 <tr >
                                    <th>
                                        Email：
                                    </th>
                                    <td>
                                        <%#Eval("Email")%>
                                    </td>
                                    <th>
                                        QQ：
                                    </th>
                                    <td>
                                        <%#Eval("QQ")%>
                                    </td>
                                </tr>
                                 <tr >
                                    <th>
                                        MSN：
                                    </th>
                                    <td>
                                        <%#Eval("MSN")%>
                                    </td>
                                    
                                     <th>
                                        其他联系方式：
                                    </th>
                                    <td >
                                        <%#Eval("OtherContact")%>
                                    </td>
                                </tr>
                                 <tr style='display:<%#Convert.ToInt32(Eval("Status"))==1?"":"none" %>'>
                                      <th>
                                        冻结原因：
                                    </th>
                                    <td colspan="3">
                                        <%#Eval( "FreezeReson" )%>
                                    </td>
                                </tr>
                                <tr>
                                      <th>
                                        详细地址：
                                    </th>
                                    <td colspan="3">
                                        <%#Eval("Address")%>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:FormView>
                    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetUserInfo" TypeName="Common.Agent.UserAgent">
                        <SelectParameters>
                        <asp:QueryStringParameter Type ="Int32" Name="id" QueryStringField="userid" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <div class="iSubmit">
                        <asp:Button ID="btnBACK" runat="server" Text="返回" CssClass="button" OnClick="btnDelete_Click" />
                    </div>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>

