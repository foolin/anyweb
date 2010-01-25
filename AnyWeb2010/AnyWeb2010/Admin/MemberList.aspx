<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="MemberList.aspx.cs" Inherits="Admin_MemberList" Title="会员管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="MemberAdd.aspx">添加会员</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                会员管理</h3>
        </div>
        <div class="fi filter">
            登陆邮箱：<asp:TextBox ID="compName" CssClass="text" Width="80px" runat="server" />
            注册时间：从<asp:TextBox ID="compFrom" CssClass="text" Width="80px" onclick="setday(this)"
                runat="server" />到<asp:TextBox ID="compTo" CssClass="text" Width="80px" onclick="setday(this)"
                    runat="server" />
            状态：<asp:DropDownList ID="compStatus" runat="server">
                <asp:ListItem Value="">--所有--</asp:ListItem>
                <asp:ListItem Value="1">正常</asp:ListItem>
                <asp:ListItem Value="2">锁定</asp:ListItem>
            </asp:DropDownList>
            <input type="button" value="搜索" onclick="search()" />

            <script type="text/javascript">
                        function search(){
                            var url = "MemberList.aspx?name="+document.getElementById("<%=compName.ClientID %>").value;
                            url += "&from="+document.getElementById("<%=compFrom.ClientID %>").value;
                            url += "&to="+document.getElementById("<%=compTo.ClientID %>").value;
                            url += "&status="+document.getElementById("<%=compStatus.ClientID %>").value;
                            window.location = url;
                        }
            </script>

        </div>
        <div class="mbd">
            <table>
                <thead>
                    <tr>
                        <th>
                            编号
                        </th>
                        <th>
                            邮箱
                        </th>
                        <th>
                            手机
                        </th>
                        <th>
                            昵称
                        </th>
                        <th>
                            真实姓名
                        </th>
                        <th>
                            注册时间
                        </th>
                        <th>
                            状态
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="compRep" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt">
                            <td>
                                <%#Eval("fdMembID")%>
                            </td>
                            <td>
                                <%#Eval("fdMembEmail")%>
                            </td>
                            <td>
                                <%#Eval("fdMembMobile")%>
                            </td>
                            <td>
                                <%#Eval("fdMembName")%>
                            </td>
                            <td>
                                <%#Eval("fdMembTrueName")%>
                            </td>
                            <td>
                                <%#Eval("fdMembRegAt", "{0:yyyy-MM-dd HH:mm:ss}")%>
                            </td>
                            <td>
                                <%# (int)Eval("fdMembStatus") == 1 ? "正常" : "<span style='color:Red'>锁定</span>"%>
                            </td>
                            <td>
                                <a href="MemberInfo.aspx?id=<%# Eval("fdMembID")%>">详情</a> <a href="MemberEdit.aspx?id=<%# Eval("fdMembID")%>">
                                    修改</a> <a href="MemberLock.aspx?id=<%# Eval("fdMembID")%>&status=<%# (int)Eval("fdMembStatus")==1?2:1 %>"
                                        onclick="return confirm('是否确认？')">
                                        <%#(int)Eval("fdMembStatus")==1?"锁定":"解锁" %></a> <a href="MemberDel.aspx?id=<%# Eval("fdMembID")%>"
                                            onclick="return confirm('您确定要删除吗?')">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div class="smtPager">
                <sw:PageNaver ID="PN1" runat="server" StyleID="2" PageSize="20">
                </sw:PageNaver>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>该页显示所有注册会员列表</li>
        </ul>
    </div>
</asp:Content>
