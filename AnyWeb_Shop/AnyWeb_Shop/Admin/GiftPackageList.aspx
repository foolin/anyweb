<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="GiftPackageList.aspx.cs" Inherits="Admin_GiftPackageList" Title="大礼包管理" %>

<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
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
    </script>

    <div class="mod mEdit">
        <form id="form1" runat="server">
        <div class="mhd">
            <div class="inner">
                <h2>
                    大礼包管理 <span class="listadd"><a href="GiftPackageEdit.aspx?mode=insert">添加大礼包</a></span></h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <table class="iList iArticle" id="tbGoods">
                    <caption>
                        <asp:Label ID="lblTips" Font-Size="12px" runat="server" Text=""></asp:Label>
                    </caption>
                    <thead>
                        <tr>
                            <th class="fst">
                                <input type="checkbox" onclick="SelectAll(this.checked)" title="点击全选" />
                            </th>
                            <th>
                                编号
                            </th>
                            <th style="width: 140px; line-height: 23px;">
                                名称
                            </th>
                            <th>
                                图片
                            </th>
                            <th>
                                价格
                            </th>
                            <th>
                                是否显示
                            </th>
                            <th>
                                排序
                            </th>
                            <th>
                                所属商品
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
                                        <input type="checkbox" name="ids" value='<%#Eval("PackID")%>' title="点击选择" />
                                    </td>
                                    <td>
                                        <%#Eval("PackNo")%>
                                    </td>
                                    <td style="width: 140px; line-height: 23px;">
                                        <a href='/GiftPackage.aspx?pid=<%#Eval( "PackID" )%>' target="_blank">
                                            <%#Eval( "PackName" )%>
                                        </a>
                                    </td>
                                    <td>
                                        <img src='<%#(string)Eval( "Image" )=="" ? "../images/wait.jpg":(string)Eval( "Image" ) %>'
                                            alt="<%#Eval("PackName") %>" width="50px" />
                                    </td>
                                    <td>
                                        <%#Eval("Price", "{0:c}")%>
                                    </td>
                                    <td>
                                        <input name="chkShow" type="checkbox" onclick='javascript:SetShow(<%# Eval("PackID") %>,<%# ((bool)Eval("IsShow")) == true ? 1: 0 %>);'
                                            <%#(bool)Eval("IsShow")==true ? "checked" :""%> title="点击显示" />
                                    </td>
                                    <td>
                                        <%#Eval("Sort") %>
                                    </td>
                                    <td>
                                        <a href="GiftPackGoodsEdit.aspx?pid=<%#Eval("PackID")%>">查看商品</a>
                                    </td>
                                    <td>
                                        <a href="GiftPackageEdit.aspx?mode=update&packID=<%#Eval("PackID")%>">编辑</a> <a href="GiftPackageEdit.aspx?mode=select&packID=<%#Eval("PackID")%>">
                                            查看详情</a>
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
                <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetGiftPackageList"
                    TypeName="Common.Agent.GiftPackageAgent" OnSelected="ods3_Selected">
                    <SelectParameters>
                        <asp:ControlParameter Type="Int32" PropertyName="pagesize" Name="pageSize" ControlID="PN1" />
                        <asp:ControlParameter Type="Int32" PropertyName="pageindex" Name="pageNo" ControlID="PN1" />
                        <asp:Parameter Name="isShow" Type="Boolean" DefaultValue="false" />
                        <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="mft">
        </div>
        </form>
    </div>

    <script type="text/javascript">

        function SetShow(packID, isShow) {


            var req = GetRequest();

            var data = "pid=" + packID + "&type=" + isShow;

            req.onreadystatechange = function handler() {
                if (req.readyState == 4) {

                    if (req.status == 200) {

                        var result = req.responseText;

                        if (result == "1") {
                            alert("设置成功");
                        }
                        if (result == "0") {
                            alert("设置失败");
                        }
                    }
                }
            }
            req.open("post", "/Admin/GiftPackSetShow.aspx", true);
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
