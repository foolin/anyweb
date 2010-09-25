<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ScrollADList.aspx.cs" Inherits="Admin_ScrollADList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript" src="js/jquery.tablednd.js"></script>

    <script type="text/javascript">
        $(document).ready(function() 
        {
            $("#datas").tableDnD({
                onDrop: function(table, row) 
                {
                    var rows = table.tBodies[0].rows;
                    var ADId = row.id.replace("row_", "");
                    var nextId = "0";
                    var previewId = "0";
                    var total = rows.length;
                    if (total <= 1)
                        return;
                    for (i = 0; i < rows.length; i++) 
                    {
                        rows[i].className = i % 2 == 0 ? "even" : "";
                        if (rows[i].id == "row_" + ADId) 
                        {
                            if (i == 0)
                                nextId = rows[i + 1].id.replace("row_", "");
                            else if (i + 1 == total)
                                previewId = rows[i - 1].id.replace("row_", "");
                            else
                                previewId = rows[i - 1].id.replace("row_", "");
                        }
                    }

                    var url = "ScroolADSort.aspx?id=" + ADId + "&previewid=" + previewId + "&nextid=" + nextId;
                    $.get(url, "", function(htm) { });
                }
            });
        });
        function columnchange() 
        {
            window.location = "ScrollADList.aspx?type=" + $("#<%=drpType.ClientID %>").val();
        }
    </script>

    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                滚动广告管理</h3>
        </div>
        <div class="fi filter">
            类型：
            <asp:DropDownList ID="drpType" onchange="columnchange()" runat="server">
                <asp:ListItem Value="4" Text="合作院校"></asp:ListItem>
                <asp:ListItem Value="5" Text="专题图片"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="mbd">
            <table id="datas">
                <thead>
                    <tr>
                        <th>
                            标题
                        </th>
                        <th>
                            图片
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="compRep" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt" id="row_<%# Eval("fdScrollAdID")%>">
                            <td style="text-align: left;" class="dragTd" title="拖动排序">
                                <a href="<%#Eval("fdScrollAdLink") %>" target="_blank">
                                    <%#Eval("fdScrollAdName")%></a>
                            </td>
                            <td>
                                <a href="<%#Eval("fdScrollAdPic") %>" target="_blank">
                                    <img src="<%#Eval("fdScrollAdPic") %>" alt="" width="100" height="65" /></a>
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
            <li></li>
        </ul>
    </div>
</asp:Content>

