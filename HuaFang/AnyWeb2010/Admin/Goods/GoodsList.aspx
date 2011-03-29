<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="GoodsList.aspx.cs" Inherits="Admin_GoodsList" %>

<%@ Register TagPrefix="cc1" Namespace="Studio.Web" Assembly="Studio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="goodsadd.aspx">添加商品</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript" src="/Admin/js/jquery.tablednd.js"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $("#datas").tableDnD({
                onDrop: function(table, row) {
                    var rows = table.tBodies[0].rows;
                    var goodsId = row.id.replace("row_", "");
                    var nextId = "0";
                    var previewId = "0";
                    var total = rows.length;
                    if (total <= 1)
                        return;
                    for (i = 0; i < rows.length; i++) {
                        rows[i].className = i % 2 == 0 ? "even" : "";
                        if (rows[i].id == "row_" + goodsId) {
                            if (i == 0)
                                nextId = rows[i + 1].id.replace("row_", "");
                            else if (i + 1 == total)
                                previewId = rows[i - 1].id.replace("row_", "");
                            else
                                previewId = rows[i - 1].id.replace("row_", "");
                        }
                    }

                    var url = "GoodsSort.aspx?id=" + goodsId + "&previewid=" + previewId + "&nextid=" + nextId;
                    $.get(url, "", function(htm) { });
                }
            });
        });
    </script>

    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                商品列表</h3>
        </div>
        <div class="fi filter">
            分类：<asp:DropDownList ID="drpCategory" runat="server">
                <asp:ListItem Value="0">所有分类</asp:ListItem>
            </asp:DropDownList>
            品牌：<asp:DropDownList ID="drpBrand" runat="server">
                <asp:ListItem Value="0">所有品牌</asp:ListItem>
            </asp:DropDownList>
            状态：<asp:DropDownList ID="drpStatus" runat="server">
                <asp:ListItem Value="0">所有状态</asp:ListItem>
                <asp:ListItem Value="1">正常</asp:ListItem>
                <asp:ListItem Value="2">下架</asp:ListItem>
            </asp:DropDownList>
            推荐：<asp:DropDownList ID="drpRecommend" runat="server">
                <asp:ListItem Value="-1">所有</asp:ListItem>
                <asp:ListItem Value="2">劲爆推荐</asp:ListItem>
                <asp:ListItem Value="3">美酒推荐</asp:ListItem>
                <asp:ListItem Value="4">名牌推荐</asp:ListItem>
            </asp:DropDownList>
            促销：<asp:DropDownList ID="drpPromotion" runat="server">
                <asp:ListItem Value="-1">所有</asp:ListItem>
                <asp:ListItem Value="0">正常</asp:ListItem>
                <asp:ListItem Value="1">促销</asp:ListItem>
            </asp:DropDownList>
            编号：<asp:TextBox ID="txtGoodsID" runat="server" CssClass="text" Width="80px"></asp:TextBox>
            名称：<asp:TextBox ID="txtGoodsName" runat="server" CssClass="text" Width="80px"></asp:TextBox>
            <br />
            排序：<asp:DropDownList ID="drpSort" runat="server">
                <asp:ListItem Value="0">默认</asp:ListItem>
                <asp:ListItem Value="1">销量(高-低)</asp:ListItem>
                <asp:ListItem Value="2">销量(低-高)</asp:ListItem>
                <asp:ListItem Value="3">价格(高-低)</asp:ListItem>
                <asp:ListItem Value="4">价格(低-高)</asp:ListItem>
                <asp:ListItem Value="5">点击(高-低)</asp:ListItem>
                <asp:ListItem Value="6">点击(低-高)</asp:ListItem>
                <asp:ListItem Value="7">评论数(高-低)</asp:ListItem>
                <asp:ListItem Value="8">评论数(低-高)</asp:ListItem>
                <asp:ListItem Value="9">得分(高-低)</asp:ListItem>
                <asp:ListItem Value="10">得分(低-高)</asp:ListItem>
                <asp:ListItem Value="11">收藏数(高-低)</asp:ListItem>
                <asp:ListItem Value="12">收藏数(低-高)</asp:ListItem>
            </asp:DropDownList>
            <button onclick="search()">
                搜索</button>

            <script type="text/javascript">
                function search() {
                    var url = "?category=" + document.getElementById("<%=drpCategory.ClientID%>").value;
                    url += "&brand=" + document.getElementById("<%=drpBrand.ClientID%>").value;
                    url += "&status=" + document.getElementById("<%=drpStatus.ClientID%>").value;
                    url += "&id=" + document.getElementById("<%=txtGoodsID.ClientID%>").value;
                    url += "&name=" + document.getElementById("<%=txtGoodsName.ClientID%>").value;
                    url += "&recommend=" + document.getElementById("<%=drpRecommend.ClientID%>").value;
                    url += "&promotion=" + document.getElementById("<%=drpPromotion.ClientID%>").value;
                    url += "&sort=" + document.getElementById("<%=drpSort.ClientID%>").value;
                    window.location = url;
                }
                function SelectAll(v) {
                    var list = document.getElementsByTagName("input");
                    for (var i = 0; i < list.length; i++) {
                        if (list[i].name == "ids" && list[i].type == "checkbox") {
                            list[i].checked = v;
                        }
                    }
                }
                function setGoods(target, action, status) {
                    var list = document.getElementsByTagName("input");
                    var selected = false;
                    var form0;
                    form0 = document.createElement("form");
                    form0.method = "POST";
                    form0.action = "GoodsSet.aspx?action=" + action + "&status=" + status;
                    for (var i = 0; i < list.length; i++) {
                        if (list[i].name == "ids" && list[i].type == "checkbox" && list[i].checked) {
                            input1 = document.createElement("input");
                            input1.type = "hidden";
                            input1.name = "ids";
                            input1.value = list[i].value;
                            form0.appendChild(input1);
                            selected = true;
                        }
                    }
                    if (selected == false) {
                        alert("请选择商品");
                        return;
                    }
                    var msg = "你确认要" + target.innerHTML + "选定的商品吗?";
                    if (target.innerHTML == "促销" || confirm(msg)) {
                        document.body.appendChild(form0);
                        form0.submit();
                    }
                }
            </script>

        </div>
        <div class="mbd">
            <table id="datas">
                <thead>
                    <tr>
                        <th style="width: 80px">
                            <label class="checkbox">
                                <input type="checkbox" class="checkbox" onclick="SelectAll(this.checked)" />全选</label>
                        </th>
                        <th>
                            名称
                        </th>
                        <th>
                            价格
                        </th>
                        <th>
                            分类
                        </th>
                        <th>
                            品牌
                        </th>
                        <th>
                            点击/评论/评分
                        </th>
                        <th>
                            状态
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="repGoodses" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt" id="row_<%# Eval("fdGoodID")%>">
                            <td style="width: 30px;">
                                <input type="checkbox" name="ids" value="<%# Eval("fdGoodID")%>" /><%# Eval("fdGoodID")%>
                            </td>
                            <td align="left" class="dragTd" title="拖动排序">
                                <a href="<%#Eval("PathStr") %>" target="_blank"><%# Eval("fdGoodName")%></a>
                                <%# (int)Eval("fdGoodIsPromotion") == 1 ? "<img alt='促销商品' src='/public/images/promotion.gif' />" : ""%>
                                <%# (int)Eval("fdGoodIsRecommend") == 1 ? "<img alt='推荐商品' src='/public/images/recommend.gif' />" : ""%>
                            </td>
                            <td>
                                <%# Eval("fdGoodSalePrice", "{0:0.00}")%>
                            </td>
                            <td>
                                <%# Eval("Category.fdCateName")%>
                            </td>
                            <td>
                                <%# Eval("Brand") == null ? "--" : Eval("Brand.fdBranName").ToString()%>
                            </td>
                            <td>
                                <%# Eval("fdGoodClickCount")%>/<%# Eval("fdGoodCommentCount")%>/<%# Eval("fdGoodScoreAverage","{0:0.0}")%>
                            </td>
                            <td style="width: 30px;">
                                <%# Eval("fdGoodStatus").ToString() == "1" ? "正常" : "<span style='color:red'>下架</span>"%>
                            </td>
                            <td>
                                <a href="goodsedit.aspx?id=<%# Eval("fdGoodID")%>">修改</a> <a href="goodsdel.aspx?type=del&id=<%# Eval("fdGoodID")%>"
                                    onclick="return confirm('您确定要删除吗?')">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div class="smtPager">
                <cc1:PageNaver ID="PN1" runat="server" StyleID="2" PageSize="20">
                </cc1:PageNaver>
            </div>
        </div>
        <div class="mft">
        </div>
        <button onclick="setGoods(this,'del',0)" style="height: 28px;">
            批量删除</button>
        <button onclick="setGoods(this,'status',1)" style="height: 28px;">
            上架</button>
        <button onclick="setGoods(this,'status',2)" style="height: 28px;">
            下架</button>
        <button onclick="setGoods(this,'promotion',1)" style="height: 28px;">
            促销</button>
        <button onclick="setGoods(this,'promotion',0)" style="height: 28px;">
            取消促销</button>
        <button onclick="setGoods(this,'recommend',1)" style="height: 28px; display: none;">
            推荐</button>
        <button onclick="setGoods(this,'recommend',0)" style="height: 28px; display: none;">
            取消推荐</button>
    </div>
    <div>
        <ul class="Help">
            <li>存在订单数据的商品不能删除，但可设置状态为“下架”，前台不会显示下架商品。</li>
            <li>库存数量为“0”的商品买家不能提交到购物车。</li>
            <li>可拖动商品名称列进行商品排序调整。</li>
        </ul>
    </div>
</asp:Content>
