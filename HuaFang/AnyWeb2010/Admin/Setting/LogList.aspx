<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="LogList.aspx.cs" Inherits="Admin_LogList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="LogClear.aspx">清除日志</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <script type="text/javascript">
        function change() {
            window.location = "?admin=" + $("#<%=drpAdmin.ClientID %>").val() + "&type=" + $("#<%=drpOper.ClientID %>").val();
        }
    </script>
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                查看操作日志</h3>
        </div>
        <div class="fi filter">
            <asp:DropDownList ID="drpAdmin" runat="server" onchange="change()">
                <asp:ListItem Value="">所有用户</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="drpOper" runat="server" onchange="change()">
                <asp:ListItem Value="0" Text="所有操作"></asp:ListItem>
                <asp:ListItem Value="1" Text="登录"></asp:ListItem>
                <asp:ListItem Value="2" Text="添加"></asp:ListItem>
                <asp:ListItem Value="3" Text="删除"></asp:ListItem>
                <asp:ListItem Value="4" Text="修改"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="mbd">
            <table id="datas">
                <thead>
                    <tr>
                        <th>
                            操作帐号
                        </th>
                        <th>
                            时间
                        </th>
                        <th>
                            IP
                        </th>
                        <th>
                            类型
                        </th>
                        <th>
                            名称
                        </th>
                        <th class="end">
                            描述
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="compRep" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt">
                            <td style="text-align: left;width:90px">
                                <%#Eval("fdLogAccount")%>
                            </td>
                            <td style="width:117px">
                                <%#Eval("fdLogCreateAt","{0:yyyy-MM-dd HH:mm}")%>
                            </td>
                            <td style="width:105px">
                                <%#Eval("fdLogIP")%>
                            </td>
                            <td style="width:33px">
                                <%#getType((int)Eval("fdLogType"))%>
                            </td>
                            <td align="left" style="width:110px">
                                <%#Eval("fdLogName")%>
                            </td>
                            <td align="left">
                                <%#Eval("fdLogDesc")%>
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
            <li>这里列出所有用户的操作日志，可按用户或操作进行筛选查找。</li>
            <li>清除旧日志将所有操作日志记录从系统中清除。</li>
        </ul>
    </div>
</asp:Content>
