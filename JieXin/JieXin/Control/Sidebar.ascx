<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Sidebar.ascx.cs" Inherits="Control_Sidebar" %>
<div class="listSideTop">
    相关导航</div>
<div class="bg gray">
    <div class="blank20px">
    </div>
    <ul class="menuBar" id="sidebar">
        <li><a href="/Notice.aspx">公告栏</a>
            <div class="fdiv">
                <p class="wbg">
                </p>
                <dl class="">
                </dl>
                <span class="blank10px"></span>
            </div>
        </li>
        <aw:ColumnList ID="ColumnList1" ColumnID="-1" runat="server">
            <ItemTemplate>
                <li><a href="/c/<%#Eval("fdColuID") %>.aspx">
                    <%#Eval("fdColuName") %></a>
                    <div class="fdiv">
                        <p class="wbg">
                        </p>
                        <dl class="">
                            <aw:ColumnList ID="ColumnList2" runat="server" DataSource='<%#Eval("Children") %>'>
                                <ItemTemplate>
                                    <dd>
                                        <a href="/c/<%#Eval("fdColuID") %>.aspx">
                                            <%#Eval("fdColuName") %></a></a></dd>
                                </ItemTemplate>
                            </aw:ColumnList>
                        </dl>
                        <span class="blank10px"></span>
                    </div>
                </li>
            </ItemTemplate>
        </aw:ColumnList>
    </ul>
    <div class="blank5px">
    </div>
</div>

<script type="text/javascript">
        var menus = document.getElementById("sidebar");
        var lis = menus.getElementsByTagName("li");
        var liLen = lis.length;

        var order = 0;
        for (var i = 0; i < liLen; i++) {
            var curStyle;
            lis[i].order = i;
            lis[i].onmouseover = function() {
                if (this.getElementsByTagName("div")[0].getElementsByTagName("dd").length > 0) {
                    changeTab(this, this.order, true, curStyle = this.className);
                }
            }
            lis[i].onmouseout = function() {
                if (this.getElementsByTagName("div")[0].getElementsByTagName("dd").length > 0) {
                    if (!(curStyle == "cur")) {
                        changeTab(this, this.order, false);
                    } else {
                        return false;
                    }
                }
            }
        }
        function changeTab(curObj, curOrder, bool) {
            if (bool) {
                curObj.className = "cur";
            } else {
                curObj.className = "";
                if (curOrder == 0) curObj.className = "nobg";
            }
        }
</script>

