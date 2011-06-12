<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/InnerList.master"
    AutoEventWireup="true" CodeFile="ExhibitorList.aspx.cs" Inherits="Admin_Plugins_Exhibitor_ExhibitorList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script type="text/javascript" src="../../JS/jquery.tablednd.js"></script>

    <script type="text/javascript">
        var selStatus = false;
        $(function() {
            $("#datatable").tableDnD({
                onDrop: function(table, row) {
                    var rows = table.tBodies[0].rows;
                    var exhibitorId = row.id.replace("row_", "");
                    var nextId = "0";
                    var previewId = "0";
                    var total = rows.length;
                    if (total <= 1) return;
                    var startIndex = <%=PN1.PageSize*(PN1.PageIndex-1)+1%>;
                    for (i = 0; i < rows.length; i++) {
                        rows[i].className = i % 2 == 0 ? "even" : "";
                        if (rows[i].id == "row_" + exhibitorId) {
                            if (i == 0)
                                nextId = rows[i + 1].id.replace("row_", "");
                            else if (i + 1 == total)
                                previewId = rows[i - 1].id.replace("row_", "");
                            else
                                previewId = rows[i - 1].id.replace("row_", "");
                        }
                        $(rows[i]).find("td:first").html(startIndex + i);
                    }

                    var url = "/Admin/Ajax/ExhibitorSort.aspx?id=" + exhibitorId + "&previewid=" + previewId + "&nextid=" + nextId + "&sid=" + <%=GetSiteID() %>;
                    $.ajax({
                        url: url,
                        cache: false,
                        success: function(result) {
                            if (result.length > 0) {
                                alert(result);
                                window.location.href = window.location.href;
                            }
                        }
                    });
                }
            });
            
            $("#datatable tbody tr").hover(function(){
                $(this).addClass("hover"); 
            },function(){
                $(this).removeClass("hover");
            });
        });
            
        function change(obj){
            window.location = "?sid=" + obj;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="Server">
    <form runat="server">
    <ul>
        <li style="color: #000; font-size: 12px; font-weight: normal;">
            <asp:DropDownList ID="drpSite" runat="server" onchange="change(this.value);">
            </asp:DropDownList>
        </li>
    </ul>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="noDatas" runat="server" visible="false" class="nodatas">
        未找到展商，<a href="javascript:parent.addExhibitor(<%=QS("sid") %>);">点击这里</a>新建一个展商</div>
    <div class="datas">
        <table id="datatable">
            <asp:Repeater ID="repExhibitors" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th class="edit">
                                序号
                            </th>
                            <th>
                                公司名称
                            </th>
                            <th>
                                英文名称
                            </th>
                            <th>
                                创建时间
                            </th>
                            <th class="edit">
                                修改
                            </th>
                            <th class="edit">
                                <a href="javascript:selectAll()" title="选中列表中所有展商">全选</a>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id="row_<%#Eval("fdExhiID")%>" class="<%# Container.ItemIndex % 2 == 0 ? "" : "even" %>">
                        <td class="dragTd" title="点击拖动排序">
                            <%#Eval("fdAutoID")%>
                        </td>
                        <td>
                            <%#Eval( "fdExhiName" )%>
                        </td>
                        <td>
                            <%#Eval( "fdExhiEnName" )%>
                        </td>
                        <td style="width: 100px; text-align: center;">
                            <%# Eval( "fdExhiCreateAt", "{0:yy-MM-dd HH:mm}" )%>
                        </td>
                        <td>
                            <a href="javascript:parent.editExhibitor(<%# Eval("fdExhiID")%>);" title="点击修改展商">
                                <img src="../../images/icons/icon04.gif" alt="" /></a>
                        </td>
                        <td>
                            <input type="checkbox" name="ids" value="<%# Eval("fdExhiID")%>" class="checkbox" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>
            <tfoot id="tableFooter" runat="server">
                <tr>
                    <td colspan="8">
                        <span class="record">共<strong><asp:Literal ID="litRecords" runat="server">0</asp:Literal></strong>个展商</span>
                        <ul class="pager">
                            <sw:PageNaver ID="PN1" runat="server" PageSize="20" StyleID="2">
                            </sw:PageNaver>
                        </ul>
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphOpr" runat="Server">
    <div class="operation" id="ExhibitorOpr">
        <h3 class="opr-mhd">
            <a href="javascript:showFolder('ExhibitorOpr')">
                <img src="../../images/icons/arrow2.gif" /></a>展商操作任务</h3>
        <div class="opr-mbd">
            <ul>
                <li class="new"><a href="javascript:parent.addExhibitor(<%=GetSiteID() %>);">添加展商</a></li>
                <li class="delFile"><a href="javascript:deleteExhibitor();">删除展商</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
