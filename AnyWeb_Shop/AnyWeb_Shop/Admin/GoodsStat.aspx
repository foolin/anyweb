<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="GoodsStat.aspx.cs" Inherits="GoodsStat" Title="商品流量统计" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                     商品流量统计</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <caption>
                            <asp:DropDownList ID="ddlCategory" AutoPostBack="true" DataValueField="ID" DataTextField="Name" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                            
                            </asp:DropDownList>
                        </caption>
                        <thead>
                            <tr>
                                 <th >
                                   商品编号</th>
                                <th>
                                    商品名称</th>
                                 <th>
                                    商品点击次数</th>
                                      <th>
                                        评论数
                                    </th>
                                    <th>
                                        所属类别
                                    </th>
                                    <th>
                                        是否为推荐商品
                                    </th>
                                    <th>
                                        出售金额
                                    </th>
                                  
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repGoods" runat="server" >
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                           <%#Eval("ID") %>
                                        </td>
                                        <td>
                                            <%#Eval("GoodsName") %>
                                        </td>
                                        <td>
                                            <%#Eval("Clicks")%>
                                        </td>
                                        <td>
                                            <%#Eval("Comments")%>
                                        </td>
                                        <td>
                                            <%#Eval("OfCategory.Name")%>
                                        </td>
                                        <td>
                                            <%# (bool)Eval("IsRecommend") == true ? "是":"否"%>
                                        </td>
                                        
                                        <td>
                                            <%#Eval("Price","{0:c}")%>
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
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph2" Runat="Server">

</asp:Content>

