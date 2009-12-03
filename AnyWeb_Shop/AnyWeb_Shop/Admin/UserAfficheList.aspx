<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="UserAfficheList.aspx.cs" Inherits="UserAfficheList" Title="用户公告管理" %>

<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    
                <li>用户公告，是商城向指定的用户发布的公告。例如：处理用户订单和投诉反馈时，系统将自动向用户发送相关公告。</li>
                  <li>用户公告由用户自由管理。</li>
           
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    用户公告管理
                </h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <thead>
                            <tr>
                                <th class="fst">
                                    公告标题</th>
                                <th>
                                    用户浏览情况</th>
                                <th>
                                    发布时间</th>
                                <th class="end">
                                    操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rep1" runat="server" DataSourceID="ods3">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%#Eval("Title") %>
                                        </td>
                                        <td>
                                            <%#(int)Eval( "Type" ) == 1 ? "<font color='red'>未浏览</a>" : "<font color='green'>已浏览</font>"%>
                                        </td>
                                        <td>
                                            <%#Eval("CreateAt","{0:yyyy-MM-dd}") %>
                                        </td>
                                        <td>
                                            <a href='UserAfficheEdit.aspx?affid=<%#Eval("ID") %>'>查看详情</a> <%--<a href='UserAfficheEdit.aspx?affid=<%#Eval("ID") %>&mode=update'>修改</a>--%>
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
                <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetAfficheList" TypeName="Common.Agent.AfficheAgent" OnSelected="ods3_Selected">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="PN1" Type="Int32" Name="pagesize" PropertyName="pagesize" />
                        <asp:ControlParameter ControlID="PN1" Type="Int32" Name="pageno" PropertyName="pageindex" />
                        <asp:QueryStringParameter QueryStringField="mid" Name="memberID" Type="Int32" DefaultValue="1" />
                        <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
