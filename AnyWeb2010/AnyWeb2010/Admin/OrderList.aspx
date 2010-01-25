<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="OrderList.aspx.cs" Inherits="Admin_OrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="orderadd.aspx">��Ӷ���</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                �����б�</h3>
        </div>
        <div class="fi filter">
            ����״̬��<asp:DropDownList ID="drpStatus" runat="server">
                <asp:ListItem Value="0">�������Ͷ���</asp:ListItem>
                <asp:ListItem Value="1">������֧��</asp:ListItem>
                <asp:ListItem Value="2">��֧��������</asp:ListItem>
                <asp:ListItem Value="3">�ѷ�����ȷ��</asp:ListItem>
                <asp:ListItem Value="4">��ȷ�����</asp:ListItem>
                <asp:ListItem Value="5">ȱ���Ǽ�</asp:ListItem>
                <asp:ListItem Value="6">�û�ȡ��</asp:ListItem>
                <asp:ListItem Value="7">������Ч</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;�����������ڣ���&nbsp;<asp:TextBox ID="txtStartDate" runat="server" onclick="setday(this);"
                CssClass="text" Width="80px"></asp:TextBox>&nbsp;��&nbsp;<asp:TextBox ID="txtEndDate"
                    runat="server" onclick="setday(this);" CssClass="text" Width="80px"></asp:TextBox>&nbsp;<asp:Button
                        ID="btnSearch" runat="server" Text="��ѯ" OnClick="btnSearch_Click" />&nbsp;&nbsp;
            <input id="btnDel" type="button" value="����ɾ��" />
        </div>
        <div class="mbd">
            <table>
                <thead>
                    <tr>
                        <th>
                            <input type="checkbox" onclick="selectAll(this.checked);" title="���ȫѡ" />
                        </th>
                        <th>
                            �û�����
                        </th>
                        <th>
                            �����ܶ�
                        </th>
                        <th>
                            ֧����ʽ
                        </th>
                        <th>
                            �µ�ʱ��
                        </th>
                        <th class="end">
                            �� ��
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr id="rowNull" runat="server" class="nodata" visible="false">
                        <td colspan="6">
                            ��û���κζ�����
                        </td>
                    </tr>
                    <asp:Repeater ID="repOrders" runat="server" EnableViewState="False">
                        <ItemTemplate>
                            <tr align="center" class="editalt">
                                <td style="width: 30px;">
                                    <input type="checkbox" name="ids" value="<%#Eval("fdOrdeID")%>" />
                                </td>
                                <td>
                                    <%# Eval("fdOrdeUserName")%>
                                </td>
                                <td>
                                    <%# Eval("fdOrdePayPrice")%>
                                </td>
                                <td>
                                    <%# Eval("PayMode")%>
                                </td>
                                <td>
                                    <%# Eval("fdOrdeCreateAt")%>
                                </td>
                                <td>
                                    <a href="OrderDetails.aspx?id=<%#Eval("fdOrdeID") %>">������ϸ</a> <a href="orderEdit.aspx?id=<%# Eval("fdOrdeID")%>">
                                        �޸�</a> <a href="?type=del&id=<%# Eval("fdOrdeID")%>" onclick="return confirm('��ȷ��Ҫɾ����?')">
                                            ɾ��</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tfoot id="tableFooter" runat="server" visible="true">
                    <tr>
                        <td colspan="6">
                            <span class="total">��<strong><asp:Literal ID="litRecords" runat="server">0</asp:Literal></strong>
                                ������</span>
                            <ul class="pagination">
                                <sw:PageNaver ID="PN1" runat="server" PageSize="10" StyleID="2">
                                </sw:PageNaver>
                            </ul>
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li></li>
        </ul>
    </div>

    <script>
        $(function() {
            $("#btnDel").click(function() {
                var list = document.getElementsByTagName("input");
                var selected = false;

                for (var i = 0; i < list.length; i++) {
                    if (list[i].name == "ids" && list[i].type == "checkbox" && list[i].checked) {
                        selected = true;
                        break;
                    }
                }
                if (selected == false) {
                    alert("��ѡ�񶩵�");
                    return;
                }
                if (confirm("��ȷ��ɾ��ѡ���Ķ�����?")) {
                    $("form").attr("action", "?type=dels");
                    $("form").submit();
                }
            });
        });
    </script>

</asp:Content>
