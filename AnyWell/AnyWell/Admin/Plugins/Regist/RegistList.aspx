<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/InnerList.master"
    AutoEventWireup="true" CodeFile="RegistList.aspx.cs" Inherits="Admin_Plugins_Regist_RegistList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script type="text/javascript">
        var selStatus = false;
        $(function() {
            $("#datatable tbody tr").hover(function() {
                $(this).addClass("hover");
            }, function() {
                $(this).removeClass("hover");
            });
        });

        function change(obj) {
            var url = "?sid=" + obj;
            window.location = url;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="Server">
    <form runat="server">
    <ul>
        <li style="color: #000; font-size: 12px; font-weight: normal;">
            <asp:DropDownList ID="drpSite" runat="server" onchange="change(this.value)">
            </asp:DropDownList>
        </li>
    </ul>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="noDatas" runat="server" visible="false" class="nodatas">
        未找到观众预登记
    </div>
    <div class="datas">
        <table id="datatable">
            <asp:Repeater ID="repRegist" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th class="edit">
                                序号
                            </th>
                            <th>
                                姓
                            </th>
                            <th>
                                名
                            </th>
                            <th>
                                称谓
                            </th>
                            <th>
                                国家/城市
                            </th>
                            <th>
                                电话
                            </th>
                            <th>
                                注册号
                            </th>
                            <th>
                                邮箱
                            </th>
                            <th class="edit">
                                <a href="javascript:selectAll()" title="选中列表中所有登记">全选</a>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="<%# Container.ItemIndex % 2 == 0 ? "" : "even" %>">
                        <td style="text-align: center;">
                            <%#Eval("fdAutoID")%>
                        </td>
                        <td style="text-align: center;">
                            <%#Eval( "fdRegiSurname" )%>
                        </td>
                        <td style="text-align: center;">
                            <%#Eval( "fdRegiName" )%>
                        </td>
                        <td style="text-align: center;">
                            <%#Eval( "Appellation" )%>
                        </td>
                        <td style="text-align: center;">
                            <%#Eval( "Country" )%>
                        </td>
                        <td style="text-align: center;">
                            <%#Eval( "fdRegiPhone" )%>
                        </td>
                        <td style="text-align: center;">
                            <%#83000000 + ( int ) Eval( "fdRegiID" )%>
                        </td>
                        <td>
                            <%#Eval( "fdRegiEmail" )%>
                        </td>
                        <td>
                            <input type="checkbox" name="ids" value="<%# Eval("fdRegiID")%>" class="checkbox" />
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
                        <span class="record">共<strong><asp:Literal ID="litRecords" runat="server">0</asp:Literal></strong>个登记</span>
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
    <div class="operation" id="RegistOpr">
        <h3 class="opr-mhd">
            <a href="javascript:showFolder('RegistOpr')">
                <img src="../../images/icons/arrow2.gif" /></a>登记操作任务</h3>
        <div class="opr-mbd">
            <ul>
                <li class="delFile"><a href="javascript:delRegist();">删除登记</a></li>
                <li class="downloadFile"><a href="javascript:exportRegist(<%=GetSiteID() %>);">导出登记</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
