<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="KeyWordList.aspx.cs" Inherits="Admin_KeyWordList" Title="�����ؼ��ֹ���" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="KeyWordList.aspx?s=1" <%= status == 1 ? "class='on'" : "" %>>��ʾ</a></li>
        <li><a href="KeyWordList.aspx?s=0" <%= status == 0 ? "class='on'" : "" %>>����ʾ</a></li>
        <li><a href="KeyWordList.aspx?s=-1" <%= status == -1 ? "class='on'" : "" %>>ȫ��</a></li>
        <li><a href="KeyWordAdd.aspx">��ӹؼ���</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript" src="js/jquery.tablednd.js"></script>

    <script type="text/javascript">
        //    $(document).ready(function() {
        //        $("#datas").tableDnD({
        //            onDrop: function(table, row) {
        //                //debugger;
        //                var rows = table.tBodies[0].rows;
        //                var keyWID = row.id.replace("row_", "");
        //                var nextId = "0";
        //                var previewId = "0";
        //                var total = rows.length;
        //                if (total <= 1)
        //                    return;
        //                for (i = 0; i < rows.length; i++) {
        //                    rows[i].className = i % 2 == 0 ? "even" : "";
        //                    if (rows[i].id == "row_" + keyWID) {
        //                        if (i == 0)
        //                            nextId = rows[i + 1].id.replace("row_", "");
        //                        else if (i + 1 == total)
        //                            previewId = rows[i - 1].id.replace("row_", "");
        //                        else
        //                            previewId = rows[i - 1].id.replace("row_", "");
        //                    }
        //                }

        //                var url = "KeyWordsSort.aspx?id=" + keyWID + "&previewid=" + previewId + "&nextid=" + nextId;
        //                $.get(url, "", function(htm) { });

        //            }
        //        });
        //    });
    </script>

    <style type="text/css">
        .pbd .part .Mod .mbd table thead tr th
        {
            line-height: normal;
        }
        .pbd .part .Mod .mbd .smtPager span input
        {
            height: auto;
            line-height: 15px;
            margin: 0;
            padding: 1px;
            vertical-align: middle;
        }
        .tDnD_whileDrag td
        {
            color: #999;
        }
    </style>
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                �����ؼ��ֹ���</h3>
        </div>
        <div class="mbd">
            <table id="datas">
                <thead>
                    <tr>
                        <th>
                            �ؼ���
                        </th>
                        <th>
                            �����
                        </th>
                        <th>
                            ����ʱ��
                        </th>
                        <th class="end">
                            �� ��
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="repKeyWord" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt" id="row_<%# Eval("fdKeyWID")%>">
                            <td class="dragTd">
                                <%#Eval("fdKeyWName")%><%# (int)Eval("fdKeyWIsShow")==0 ? "<span style='color:red'> (����ʾ)</span>" : "" %>
                            </td>
                            <td>
                                <%#Eval("fdKeyWSort")%>
                            </td>
                            <td>
                                <%#Eval("fdKeyWCreateAt","{0:yyyy-MM-dd HH:mm}")%>
                            </td>
                            <td>
                                <a href="KeyWordEdit.aspx?id=<%#Eval("fdKeyWID") %>">�޸�</a> <a href="KeyWordDel.aspx?id=<%#Eval("fdKeyWID") %>"
                                    onclick="return confirm('��ȷ��Ҫɾ����?')">ɾ��</a>
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
            <li>��ҳ��ʾ���������ؼ����б������������������У������޸�����������ź͹ؼ����Ƿ���ǰ̨������������ʾ��</li>
        </ul>
    </div>
</asp:Content>
