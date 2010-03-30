<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
 CodeFile="GiftPackGoodsAdd.aspx.cs" Inherits="Admin_GiftPackGoodsAdd" Title="添加商品到大礼包" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">

<li> 选中需要添加的商品，点击添加即可！</li>  

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
                    添加商品到大礼包
                    
                    <span class="listadd"><a href="GiftPackGoodsEdit.aspx?pid=<%=QS("pid") %>">查看该大礼包商品</a></span>
                    <span class="listadd"><a href="GiftPackageEdit.aspx?mode=select&packID=<%=QS("pid") %>">查看该大礼包</a></span>
                    
                </h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <table class="iList iArticle" id="tbGoods">
                    <caption>
                        商品类别：<asp:DropDownList ID="drpType" runat="server" DataSourceID="ods4" DataTextField="RelativeName"
                            DataValueField="ID" OnDataBound="drpType_DataBound">
                        </asp:DropDownList>
                        状态：<asp:DropDownList ID="drpStatus" runat="server">
                            <asp:ListItem Value="0">所有商品</asp:ListItem>
                            <asp:ListItem Value="1">有货商品</asp:ListItem>
                            <asp:ListItem Value="2">缺货商品</asp:ListItem>
                            <asp:ListItem Value="3">过期商品</asp:ListItem>
                            <asp:ListItem Value="4">不显示于首页商品</asp:ListItem>
                        </asp:DropDownList>
                        商品名称：<asp:TextBox ID="txtName" runat="server" Width="100" CssClass="text"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click" />
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
                                        <%#Eval("Price", "{0:c}")%>
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
                    <asp:Button ID="btnDel" runat="server" Text="添加到大礼包" CssClass="submit" OnClick="btnAdd_Click" />
                    <button id="btnViewGiftPackage" onclick="window.location='GiftPackageEdit.aspx?mode=select&packID=<%=QS("pid") %>';" type="button">
                                查看该大礼包</button>  
                    <button id="btnBack" onclick="history.go(-1);" type="button">
                                返回</button>          
                </div>
                <asp:ObjectDataSource ID="ods4" runat="server" SelectMethod="GetAllCategoryList"
                    TypeName="Common.Agent.CategoryAgent"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetGoodsList" TypeName="Common.Agent.GoodsAgent"
                    OnSelected="ods3_Selected" OnSelecting="ods3_Selecting">
                    <SelectParameters>
                        <asp:ControlParameter Type="Int32" PropertyName="pagesize" Name="pageSize" ControlID="PN1" />
                        <asp:ControlParameter Type="Int32" PropertyName="pageindex" Name="pageNo" ControlID="PN1" />
                        <asp:Parameter Name="goodsName" Type="String" />
                        <asp:QueryStringParameter Type="Int32" Name="status" DefaultValue="0" QueryStringField="status" />
                        <asp:QueryStringParameter Type="Int32" Name="categoryID" DefaultValue="0" QueryStringField="cid" />
                        <asp:Parameter Name="isrecommend" Type="Boolean" DefaultValue="false" />
                        <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
                        <asp:Parameter Name="ispromoted" Type="Boolean" DefaultValue="false" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>


                </form>
                

</asp:Content>




