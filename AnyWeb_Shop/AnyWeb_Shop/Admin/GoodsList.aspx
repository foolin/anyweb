<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="GoodsList.aspx.cs" Debug="true" Inherits="GoodsList" Title="商品管理" EnableViewState="false" %>

<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">

    <script type="text/javascript" src="../public/setRecom.js"></script>

    <li>用列表上的搜索工具条可对列表中的商品进行过滤。</li>
    <li>可以在推荐列里设置该商品是否为推荐商品。</li>
    <li>可以批量删除商品。</li>
    <li>改变商品的状态，必须进入到修改页对商品状态进行处理。</li>
    <li>对查看商品的详细信息，并对其进行相关的操作。</li>
    <li>商品排序以商品类别在所有商品的状态为准。</li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

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
        ///////////////////////////////创建xmlHttpRequest对象////////////////////////////////////

        /////////////////////End///////////////////////////////////

        function test() {
            var divNode = document.createElement("div");
            divNode.style.position = "absolute";
            divNode.style.width = "100px";
            divNode.style.height = "14px";

            divNode.style.left = document.body.scrollLeft + event.clientX - 100;
            divNode.style.top = document.documentElement.scrollTop + event.clientY - 60;


            divNode.style.border = "1px solid #ccc";
            divNode.style.padding = "10px 10px 10px 30px";
            divNode.style.backgroundColor = "#ffe";
            divNode.style.backgroundImage = "url(/skins/loading.gif)";
            divNode.style.backgroundPosition = "5px 50%";
            divNode.style.backgroundRepeat = "no-repeat";

            bodyNode = document.getElementById("tbGoods");
            bodyNode.appendChild(divNode);
            return divNode;
        }
   
		
    </script>

    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    商品管理<span class="listadd"><a href="GoodsEdit.aspx?mode=insert">添加商品</a></span></h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
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
                        <a href="GoodsList.aspx?recommd=true">查看推荐商品</a>
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
                                所属类别
                            </th>
                            <th>
                                推荐
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
                                        <a href='<%#Eval( "LinkUrl" )%>' target="_blank">
                                            <%#Eval( "GoodsName" )%>
                                        </a>
                                    </td>
                                    <td>
                                        <img src='<%#(string)Eval( "image" )=="" ? "../images/wait.jpg":(string)Eval( "image" ) %>'
                                            alt="<%#Eval("GoodsName") %>" width="50px" />
                                    </td>
                                    <td>
                                        <%#Eval( "Price","{0:c}")%>
                                    </td>
                                    <td>
                                        <%#Eval( "MarketPrice","{0:c}")%>
                                    </td>
                                    <td>
                                        <%#Eval( "OfCategory.Name" )%>
                                    </td>
                                    <td>
                                        <input id="chkRecomm" type="checkbox" onclick='javascript:recommSet(<%# Eval("ID") %>,<%# ((bool)Eval("IsRecommend")) == true ? 1: 0 %>);'
                                            <%#(bool)Eval("IsRecommend")==true ? "checked" :""%> title="点击推荐" />
                                    </td>
                                    <td>
                                        <%# CheckStatus((int)Eval( "Status" )  ,(DateTime)Eval( "EndTime" ) )%>
                                    </td>
                                    <td>
                                        <a href="GoodsEdit.aspx?mode=update&gid=<%#Eval("ID")%>">修改</a>
                                        <a href="GoodsImage.aspx?goodsid=<%#Eval("ID")%>">相关图片</a>
                                        <a href="GoodsEdit.aspx?mode=select&gid=<%#Eval("ID")%>">查看详情</a>
                                        <a href="goodsSort.aspx?action=up&id=<%#Eval("ID")%>">排前</a>
                                        <a href="goodsSort.aspx?action=down&id=<%#Eval("ID")%>">排后</a>
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
                    <asp:Button ID="btnDel" runat="server" Text="批量删除" CssClass="submit" OnClick="btnDel_Click" />
                </div>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div id="enlarge_images">
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
        </SelectParameters>
    </asp:ObjectDataSource>

    <script type="text/javascript">

        function recommSet(goodsid, typeid) {


            var req = GetRequest();

            var data = "gid=" + goodsid + "&type=" + typeid;

            req.onreadystatechange = function handler() {
                if (req.readyState == 4) {

                    if (req.status == 200) {

                        var result = req.responseText;

                        if (result == "0") {
                            alert("设置成功");
                        }
                        if (result == "1") {
                            alert("设置失败");
                        }
                    }
                }
            }
            req.open("post", "/Admin/GoodsRecomm.aspx", true);
            req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            req.send(data);
        }

        function GetRequest() {
            var req = null;
            if (window.XMLHttpRequest) {
                req = new XMLHttpRequest();
                if (req.overrideMimeType) {
                    req.overrideMimeType("text/xml");
                }
            }
            else {
                if (window.ActiveXObject) {
                    try {
                        req = new ActiveXObject("Msxml3.XMLHTTP");
                    }
                    catch (e) {
                        try {
                            req = new ActiveXObject("Msxml2.XMLHTTP");
                        }
                        catch (e) {
                            try {
                                req = new ActiveXObject("Microsoft.XMLHTTP");
                            }
                            catch (e) {
                            }
                        }
                    }
                }
            }

            return req;
        }
    </script>

</asp:Content>
