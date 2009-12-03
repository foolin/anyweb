<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="LogList.aspx.cs" Inherits="LogList" Title="日志管理" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">

<li>对于管理员对商城各种操作的完全记录。是一份操作档案。</li>
           
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">

 <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    日志列表</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    
                    <table class="iList iArticle" id="tbGoods">
                        <caption>
                            操作类型：<asp:DropDownList ID="drpType" runat="server">
                            <asp:ListItem Value="0" Selected="True">所有日志</asp:ListItem>
                            <asp:ListItem Value="1">登陆</asp:ListItem>
                            <asp:ListItem Value="2">添加</asp:ListItem>
                            <asp:ListItem Value="3">修改</asp:ListItem>
                            <asp:ListItem Value="4">删除</asp:ListItem>
                                        </asp:DropDownList>
                         <asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click" CssClass="button1"  />
                        </caption>
                        <thead>
                            <tr>
                                <th class="fst">
                                    时间</th>
                                <th>
                                    IP</th>
                                <th>
                                    类型</th>
                                <th>
                                    名称</th>
                                <th class="end" style=" width:340px; line-height:22px;  word-break:break-all;">
                                    描述</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repCategory" runat="server" DataSourceID="ods3">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%#Eval( "RaiseAt" )%>
                                        </td>
                                       
                                        <td>
                                            <%#Eval( "FromIP")%>
                                        </td>
                                        <td>
                                            <%#status((int)Eval( "EventType" ))%>
                                        </td>
                                        <td>
                                            <%#Eval( "EventName" )%>
                                        </td>
                                           <td style=" width:340px; line-height:22px;word-break:break-all;">
                                            <%#Eval( "Description" )%>
                                        </td>
                                        
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div class="iPagination">
                        <cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="18">
                        </cc1:PageNaver>
                    </div>
                </form>
                <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetLogList" TypeName="Common.Agent.EventLogAgent" OnSelected="ods3_Selected">
            <SelectParameters>
              <asp:ControlParameter Type="int32" PropertyName="pagesize" Name="pagesize" ControlID="PN1" />
              <asp:ControlParameter Type="int32" PropertyName="pageindex" Name="pageno" ControlID="PN1" />
              <asp:QueryStringParameter Type="int32" QueryStringField="eventid" Name="eventid"  DefaultValue="0" />
              
                <asp:Parameter Direction="Output" Name="record" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>

