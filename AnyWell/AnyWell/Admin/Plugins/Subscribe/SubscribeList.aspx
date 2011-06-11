<%@ Page Language="C#" MasterPageFile="~/Admin/Master/List.master" AutoEventWireup="true" 
CodeFile="SubscribeList.aspx.cs" Inherits="Admin_Plugins_Subscribe_SubscribeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script type="text/javascript" src="../../JS/jquery.tablednd.js"></script>

    <script type="text/javascript">
        var selStatus = false;
        $(function() {
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

<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" Runat="Server">
    <form id="Form1" runat="server">
    <ul>
        <li style="color: #000; font-size: 12px; font-weight: normal;">
            <asp:DropDownList ID="drpSite" runat="server" onchange="change(this.value);">
            </asp:DropDownList>
        </li>
    </ul>
    </form>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">
    <div id="noDatas" runat="server" visible="false" class="nodatas">
        未找到订阅，<a href="javascript:parent.addSubscribe(<%=QS("sid") %>)">点击这里</a>新建一个订阅
    </div>
    <div class="datas">
        <table id="datatable">
            <asp:Repeater ID="repSubscribes" runat="server">
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
                                姓氏
                            </th>
                            <th>
                                名称
                            </th>
                            <th>
                                电子邮件
                            </th>
                            <th class="edit">
                                修改
                            </th>
                            <th class="edit">
                                <a href="javascript:selectAll()" title="选中列表中所有订阅">全选</a>
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
                            <%#Eval("fdSubsCompany")%>
                        </td>
                        <td style="text-align: center;">
                            <%#Eval("fdSubsSurname")%>
                        </td>
                        <td style="text-align: center;">
                            <%#Eval("fdSubsName")%>
                        </td>
                        <td style="text-align: center;">
                            <%# Eval("fdSubsEmail")%>
                        </td>
                        <td>
                            <a href="javascript:parent.editSubscribe(<%# Eval("fdSubsID")%>);" title="点击修改订阅">
                                <img src="../../images/icons/icon04.gif" alt="" /></a>
                        </td>
                        <td>
                            <input type="checkbox" name="ids" value="<%# Eval("fdSubsID")%>" class="checkbox" />
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
                        <span class="record">共<strong><asp:Literal ID="litRecords" runat="server">0</asp:Literal></strong>个订阅</span>
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

<asp:Content ID="Content4" ContentPlaceHolderID="cphOpr" Runat="Server">
    <div class="operation" id="SubscribeOpr">
        <h3 class="opr-mhd">
            <a href="javascript:showFolder('SubscribeOpr')">
                <img src="../../images/icons/arrow2.gif" /></a>订阅操作任务</h3>
        <div class="opr-mbd">
            <ul>
                <li class="new"><a href="javascript:parent.addSubscribe(<%=QS("sid") %>);">添加订阅</a></li>
                <li class="delFile"><a href="javascript:delSubscribe();">删除订阅</a></li>
                <li><a href="javascript:exportSubscribe(<%=QS("sid") %>);">导出订阅</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
