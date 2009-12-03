<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="UserGrade.aspx.cs" Inherits="User_UserGrade" Title="会员等级设置" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">

<li>设置会员的头衔及对应的积分。</li>
<li>注意：顾客在注册商城时，默认的积分为0分，故第一个级别的起始分从0分开始。</li>     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
 <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    会员等级设置</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <thead>
                            <tr>
                                <th class="fst">
                                     等级</th>
                                <th>
                                     等级名称</th>
                                <th class="end">
                                    起始积分</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repUser"  OnLoad="repUser_Load" runat="server" >
                                <ItemTemplate>
                                    <tr>
                                         <td >
                                            <%# Container.ItemIndex+1 %>
                                            级
                                        </td>
                                        <td >
                                            <asp:TextBox ID="txtGradeName" MaxLength="20" runat="server" CssClass="text" Width="260px" Text='<%#Eval("GradeName") %>'>
                                           </asp:TextBox>
                                        </td>
                                        <td >
                                            <asp:TextBox ID="txtMaxPoint" MaxLength="18" runat="server" Text='<%#Eval("MaxPoint") %>'  CssClass="text">
                                            </asp:TextBox>分
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                      <div class="iSubmit">
                        <asp:Button ID="btnSave" runat="server" Text="修改保存" CssClass="submit" OnClick="btnSave_Click"></asp:Button>
                        <asp:Button ID="btnReset" runat="server" Text="重置" CssClass="button" OnClick="btnReset_Click" ></asp:Button>
                        <input type="button" onclick="location.href='UserList.aspx'" value=" 取消 " class="button" />
                    </div>
                </form>
            </div>
        </div>
    </div>

</asp:Content>

