<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="UserList.aspx.cs"
    Inherits="User_UserList" Title="会员管理" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
 <script type="text/javascript" src="../public/ajax.js"></script>
 
<li>对于商城注册会员管理。可查看会员的详细信息，冻结、删除会员。</li>
          
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    会员管理</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                       <caption>
                            会员帐号：<asp:TextBox ID="txtacc" runat="server" CssClass="text"  MaxLength="50" ></asp:TextBox>
                            会员名称：<asp:TextBox ID="txtname" runat="server" CssClass="text"  MaxLength="50" ></asp:TextBox>
                            会员状态：
                            <asp:DropDownList ID="drpType" runat="server">
                                 <asp:ListItem Value="10">所有会员</asp:ListItem>
                                 <asp:ListItem Value="0">有效会员</asp:ListItem>
                                 <asp:ListItem Value="1">冻结会员</asp:ListItem>
                            </asp:DropDownList><asp:Button ID="btnSearch"  CssClass="button1" runat="server" Text="搜索" OnClick="btnSearch_Click"/>
                        </caption>
                        <thead>
                            <tr>
                                <th class="fst">
                                    会员编号</th>
                                <th>
                                    会员帐号</th>
                                <th>
                                    会员名称</th>
                                <th>
                                    注册时间</th>
                                <th>
                                    状态</th>
                                <th class="end">
                                    操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repUser" runat="server" DataSourceID="ods3">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("ID") %>
                                            <td>
                                                <%# Eval("MemberAcc") %>
                                            </td>
                                            <td>
                                                <%# Eval("MemberName") %>
                                            </td>
                                            <td>
                                                <%# ((DateTime)Eval("CreateAt")).ToString("yyyy-MM-dd") %>
                                            </td>
                                            <td>
                                                <%# Convert.ToInt32( Eval( "Status" ) ) == 0 ? "<font color='green'>有效</font>" : "<font color='red'>冻结</font>"%>
                                            </td>
                                            <td>
                                                <a href='UserInfo.aspx?userid=<%#Eval("ID") %>'>详细信息</a> 
                                                <a href='../OrderList.aspx?userid=<%#Eval("ID") %>'>查看订单</a>
                                                 <%# Convert.ToInt32(Eval("Status")) == 0 ? "<a href='DeleteUser.aspx?type=1&userid=" + Eval("ID") + "'>冻结</a>" : "<a href='DeleteUser.aspx?type=0&userid=" + Eval("ID") + "'>恢复</a>"%>
                                                <a href='DeleteUser.aspx?type=2&userid=<%# Eval("ID") %>' onclick="javascript:return confirm('确定删除？');">删除</a> 
                                            </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div class="iPagination">
                        <cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="18">
                        </cc1:PageNaver>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetUserList2" TypeName="Common.Agent.UserAgent"
        OnSelected="ods3_Selected" OnSelecting="ods3_Selecting">
        <SelectParameters>
            <asp:QueryStringParameter Name="status" Type="Int32" DefaultValue="10"  QueryStringField="status" />
            <asp:Parameter Name="userName" Type="string"   />
            <asp:Parameter Name="useracc" Type="string"  />
            <asp:ControlParameter ControlID="PN1" Name="pageSize" PropertyName="pagesize" Type="Int32" />
            <asp:ControlParameter ControlID="PN1" Name="pageNo" PropertyName="pageindex" Type="Int32" />
            <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
