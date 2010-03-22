<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="HotSellRankAdd.aspx.cs" Inherits="Admin_HotSellRankAdd" Title="添加畅销商品" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">

<li> <asp:Label ID="lblTips2" Font-Size="14px" ForeColor="Red" runat="server" Text=""></asp:Label></li>  

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
                    替换并添加新畅销商品 
                    
                </h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <table class="iList iArticle" id="tbGoods">
                    <caption>
                        <asp:Label ID="lblTips" Font-Size="14px" ForeColor="Red" runat="server" Text=""></asp:Label>
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
                                        <input type="checkbox" name="ids" value='<%#Eval("GoodsID")%>' title="点击选择" />
                                    </td>
                                    <td style="width: 140px; line-height: 23px;">
                                        <a href='/Good.aspx?gid=<%#Eval( "GoodsID" )%>' target="_blank">
                                            <%#Eval( "OfGoods.GoodsName" )%>
                                        </a>
                                    </td>
                                    <td>
                                        <img src='<%#(string)Eval( "OfGoods.image" )=="" ? "../images/wait.jpg":(string)Eval( "OfGoods.image" ) %>'
                                            alt="<%#Eval("OfGoods.GoodsName") %>" width="50px" />
                                    </td>
                                    <td>
                                        <%#Eval("OfGoods.Price", "{0:c}")%>
                                    </td>
                                    <td>
                                        <%#Eval("OfGoods.MarketPrice", "{0:c}")%>
                                    </td>
                                    <td>
                                        <%# CheckStatus((int)Eval("OfGoods.Status"))%>
                                    </td>
                                    <td>
                                        <a href="GoodsEdit.aspx?mode=select&gid=<%#Eval("GoodsID")%>" target="_blank">查看详情</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div class="iSubmit">
                    <asp:TextBox ID="txbAddIds" runat="server" Text="" Visible="False"></asp:TextBox>
                    <asp:Button ID="btnDel" runat="server" Text="替换并继续操作" CssClass="submit" OnClick="btnDel_Click" />
                    <input type="button" class="submit" value="返回重新选择" onclick="history.go(-1);" />            
                </div>
                <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetHotSellRankList" TypeName="Common.Agent.HotSellRankAgent">
                    <SelectParameters>
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

