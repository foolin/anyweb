<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="GiftPackGoodsEdit.aspx.cs"
 Inherits="Admin_GiftPackGoodsEdit" Title="管理大礼包商品" %>

<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
    <li><asp:Label ID="lblTips2" Font-Size="14px" ForeColor="Red" runat="server" Text=""></asp:Label></li>     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">

                <form id="form1" runat="server">
                    
   <script type="text/javascript">
        function SelectAll(v) {
            var e_all = document.all.tags('INPUT');
            for (var i = 0; i < e_all.length; i++) {
                if (e_all[i].tagName == "INPUT") {
                    if ((e_all[i].type) && (e_all[i].name)) {
                        if ((e_all[i].type == "checkbox") && (e_all[i].name != "boxAll")) {
                            e_all[i].checked = v;
                        }
                    }
                }
            }
        }	
    </script>

 <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    <asp:HyperLink ID="hlkGiftPackage" runat="server">大礼包</asp:HyperLink>的商品 <span class="listadd"><a href="GiftPackGoodsAdd.aspx?pid=<%=QS("pid") %>">添加商品</a></span>
                    
                </h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <table class="iList iArticle" id="tbGoods">
                    <caption>
                        
                    </caption>
                    <thead>
                        <tr>
                            <th class="fst">
                                <input type="checkbox" onclick="SelectAll(this.checked)" title="点击全选" />
                            </th>
                            <th style="width: 140px; line-height: 23px;">
                                商品名称
                            </th>
                            <th>
                                商品图片
                            </th>
                            <th>
                                商品价格
                            </th>
                            <th>
                                市场价格
                            </th>
                            <th>
                                状态
                            </th>
                            <th class="end">
                                操作
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="repCategory" runat="server" DataSourceID="ods3">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <input type="checkbox" name="ids" value='<%#Eval("ID")%>' title="点击选择" />
                                    </td>
                                    <td style="width: 140px; line-height: 23px;">
                                        <a href='/Good.aspx?gid=<%#Eval( "ID" )%>' target="_blank">
                                            <%#Eval( "GoodsName" )%>
                                        </a>
                                    </td>
                                    <td>
                                        <img src='<%#(string)Eval( "image" )=="" ? "../images/wait.jpg":(string)Eval( "image" ) %>'
                                            alt="<%#Eval("GoodsName") %>" width="50px" />
                                    </td>
                                    <td>
                                        <%#Eval("Price", "{0:c}")%>
                                    </td>
                                    <td>
                                        <%#Eval("MarketPrice", "{0:c}")%>
                                    </td>
                                    <td>
                                        <%# CheckStatus((int)Eval("Status"))%>
                                    </td>
                                    <td>
                                        <a href="GoodsEdit.aspx?mode=select&gid=<%#Eval("ID")%>">查看详情</a>
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
                <div class="iSubmit">
                    <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="submit" OnClick="btnDel_Click" />
                    <button id="btnViewGiftPackage" onclick="window.location='GiftPackageEdit.aspx?mode=select&packID=<%=QS("pid") %>';" type="button">
                                查看大礼包</button>  
                    <button id="btnBack" onclick="history.go(-1);" type="button">
                                返回</button>            
                </div>
                <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetGoodsListByPackID" TypeName="Common.Agent.GiftPackageAgent">
                    <SelectParameters>
                        <asp:QueryStringParameter Type="Int32" Name="packID" DefaultValue="0" QueryStringField="pid" />
                        <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>


                </form>
                

</asp:Content>


