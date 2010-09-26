<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="KeyWordList.aspx.cs" Inherits="Admin_KeyWordList" Title="�����ؼ��ֹ���" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
    <ul class="Opr">
        <li><a href="KeyWordList.aspx?s=1" <%= status == 1 ? "class='on'" : "" %>>��ʾ</a></li>
        <li><a href="KeyWordList.aspx?s=2" <%= status == 2 ? "class='on'" : "" %>>����ʾ</a></li>
        <li><a href="KeyWordList.aspx?s=-1" <%= status == -1 ? "class='on'" : "" %>>ȫ��</a></li>
        <li><a href="KeyWordAdd.aspx">��ӹؼ���</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
<script type="text/javascript" src="js/jquery.tablednd.js"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $("#datas").tableDnD({
                onDrop: function(table, row) {
                    var rows = table.tBodies[0].rows;
                    var articleId = row.id.replace("row_", "");
                    var nextId = "0";
                    var previewId = "0";
                    var total = rows.length;
                    if (total <= 1)
                        return;
                    for (i = 0; i < rows.length; i++) {
                        rows[i].className = i % 2 == 0 ? "even" : "";
                        if (rows[i].id == "row_" + articleId) {
                            if (i == 0)
                                nextId = rows[i + 1].id.replace("row_", "");
                            else if (i + 1 == total)
                                previewId = rows[i - 1].id.replace("row_", "");
                            else
                                previewId = rows[i - 1].id.replace("row_", "");
                        }
                    }

                    var url = "KeyWordsSort.aspx?id=" + articleId + "&previewid=" + previewId + "&nextid=" + nextId;
                    $.get(url, "", function(htm) { });
                }
            });
        });
        function SelectAll(v) {
            var list = document.getElementsByTagName("input");
            for (var i = 0; i < list.length; i++) {
                if (list[i].name == "ids" && list[i].type == "checkbox") {
                    list[i].checked = v;
                }
            }
        }
        function delKeyWords() {
            var list = document.getElementsByTagName("input");
            var selected = false;
            var form0;
            form0 = document.createElement("form");
            form0.method = "POST";
            form0.action = "KeyWordsDel.aspx";
            for (var i = 0; i < list.length; i++) {
                if (list[i].name == "ids" && list[i].type == "checkbox" && list[i].checked) {
                    input1 = document.createElement("input");
                    input1.type = "hidden";
                    input1.name = "ids";
                    input1.value = list[i].value;
                    form0.appendChild(input1);
                    selected = true;
                }
            }
            if (selected == false) {
                alert("��ѡ��ؼ���");
                return;
            }
            var msg = "��ȷ��Ҫɾ��ѡ���Ĺؼ�����?";
            if (confirm(msg)) {
                document.body.appendChild(form0);
                form0.submit();
            }
        }
    </script>

    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                ��������</h3>
        </div>
        <div class="mbd">
            <table id="datas">
                <thead>
                    <tr>
                        <th style="width: 30px;">
                            <input type="checkbox" class="checkbox" onclick="SelectAll(this.checked)" title="ȫѡ" />
                        </th>
                        <th>
                            �ؼ���
                        </th>
                        <th>
                            ����ʱ��
                        </th>
                        <th class="end">
                            �� ��
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="compRep" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt" id="row_<%# Eval("fdKeyWID")%>">
                            <td style="width: 30px;">
                                <input type="checkbox" name="ids" value="<%# Eval("fdKeyWID")%>" />
                            </td>
                            <td style="text-align: left;" class="dragTd" title="�϶�����">
                                <%#Eval("fdKeyWName")%><%# (int)Eval("fdKeyWIsShow")==2 ? "<span style='color:red'> (����ʾ)</span>" : "" %>
                            </td>
                            <td>
                                <%#Eval("fdKeyWCreateAt","{0:yyyy-MM-dd HH:mm}")%>
                            </td>
                            <td>
                                <a href="KeyWordEdit.aspx?id=<%#Eval("fdKeyWID") %>">�޸�</a>
                                        <a href="KeyWordDel.aspx?id=<%#Eval("fdKeyWID") %>" onclick="return confirm('��ȷ��Ҫɾ����?')">ɾ��</a>
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
        <button onclick="delKeyWords()" style="height: 28px;" type="button">
            ����ɾ��</button>
    </div>
    <div>
        <ul class="Help">
            <li>��ҳ��ʾ���������ؼ����б������������У������޸�����������ź͹ؼ����Ƿ���ǰ̨������������ʾ��</li>
        </ul>
    </div>
</asp:Content>

