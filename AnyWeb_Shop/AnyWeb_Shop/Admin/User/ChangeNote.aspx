<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ChangeNote.aspx.cs" Inherits="User_ChangeNote" Title="积分兑换记录" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    积分兑换记录
                </h2>
                  
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                     <table class="iList iArticle">
                    <thead>
                        <tr>
                            <th class="fst">兑换礼品名称</th>
                            <th>图片</th>
                            <th>价格</th>
                            <th>花费积分</th>
                            <th>兑换时间</th>
                            <th class="end">发货状态</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="repChangeNote" runat="server" EnableViewState="false"  DataSourceID="ods3">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Eval( "OfChangeGoods.Name" )%>
                                    </td>
                                    <td>
                                       
                                       <img src='<%#Eval( "OfChangeGoods.Image" )%>' alt='<%#Eval( "OfChangeGoods.Name" )%>' border="0" /></a>
                                    </td>
                                    <td>
                                        <%#Eval( "OfChangeGoods.Price" , "{0:c}" )%>
                                    </td>
                                      <td>
                                        <%#Eval( "OfChangeGoods.Score" )%>
                                    </td>
                                    <td>
                                        <%#Eval("NoteTime","{0:yyyy-MM-dd}")%>
                                    </td>
                                     <td>
                                        <%#(int)Eval("SendStatus")==2 ?"<font color='green'>已发货</font>":"<font color='red'>未发货</font>"%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>         
                    </tbody>
                </table>
                   <div class="iPagination" >
                        <cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="18">
                        </cc1:PageNaver>
                    </div>
                       <div class="iSubmit">
                                <button id="btnBack" onclick="window.location='UserList.aspx';" type="button">
                                    返回</button>
                            </div>
                </form>
            <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetUserChangeNote" TypeName="Common.Agent.ChangeNoteAgent" OnSelecting="ods3_Selecting" OnSelected="ods3_Selected">
                <SelectParameters>
                    <asp:Parameter Name="userid" Type="Int32" />
                    <asp:Parameter Name="status" Type="Int32"  DefaultValue="0"/>
                     <asp:ControlParameter ControlID="PN1" Name="pagesize" PropertyName="pagesize" Type="Int32" />
                    <asp:ControlParameter ControlID="PN1" Name="pageno" PropertyName="pageindex" Type="Int32" />
                    <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
                </SelectParameters>
                  
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph2" Runat="Server">

</asp:Content>

