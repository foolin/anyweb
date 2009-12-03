<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" CodeFile="Member.aspx.cs"
    Inherits="Member_Member" Title="会员管理" %>
<%@ Register TagPrefix="cc1" Namespace="Studio.Web" Assembly="Studio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">

    <script type="text/javascript" src="/public/date.js"></script>

    <div class="mod">
        <div class="mhd">
            <div class="inner">
                <h2>
                    会员管理</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList">
                        <caption>
                            <asp:DropDownList ID="drpSex" runat="server">
                                <asp:ListItem Value="0">所有性别</asp:ListItem>
                                <asp:ListItem Value="1">男</asp:ListItem>
                                <asp:ListItem Value="2">女</asp:ListItem>
                            </asp:DropDownList>
                            会员编号/帐号：<asp:TextBox ID="txtMember" runat="server" Width="80" CssClass="text"></asp:TextBox>
                            注册时间：从
                            <asp:TextBox ID="txtStart" runat="server" Width="80" onclick="setday(this);" CssClass="text"></asp:TextBox>
                            到
                            <asp:TextBox ID="txtEnd" runat="server" Width="80" onclick="setday(this);" CssClass="input"></asp:TextBox>
                            <input type="button" value="搜索会员" class="button1" onclick="search();" />
                        </caption>
                        <thead>
                        <tr>
                        <th class="fst">会员编号</th>
                        <th>会员姓名</th>
                        <th>等级</th>
                        <th>性别</th>
                        <th>注册时间</th>
                        <th>积分</th>
                        </tr>
                        </thead>
                        <tbody>
                        <asp:Repeater ID="repMember" runat="server">
                        <ItemTemplate>
                        <td><%# Eval("MemberID") %></td>
                        <td><%# Eval("MemberName") %></td>
                        <td><%# Eval("Sex") %></td>
                        <td><%# Eval("CreateAt") %></td>
                        <td><%# Eval("Point") %></td>
                        </ItemTemplate>
                        </asp:Repeater>
                        </tbody>
                    </table>
                </form>
            </div>
        </div>
        <div class="iPagination">
        <cc1:PageNaver ID="PN1" runat="server" StyleID="2"></cc1:PageNaver>
        </div>
    </div>

    <script type="text/javascript">
				function search()
				{
					var url = "?start=" + document.all('<%=txtStart.ClientID %>').value;
					url += "&end=" + document.all('<%=txtEnd.ClientID %>').value;
					url += "&sex=" + document.all('<%=drpSex.ClientID %>').value;
					url += "&member=" + document.all('<%=txtMember.ClientID %>').value;
					window.location = url;
				}
    </script>

</asp:Content>
