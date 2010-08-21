<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkList.ascx.cs" Inherits="Controls_LinkList" %>
<div class="friendLink">
    <div class="subtit">
        <h3>
            社区服务中心</h3>
    </div>
    <div class="con">
        <select class="select" onchange="selectLink(this)">
            <option>政府部门网站</option>
            <asp:Repeater ID="repZFWZ" runat="server">
                <ItemTemplate>
                    <option value="<%#Eval("LinkUrl") %>"><%#Eval("LinkName") %></option>
                </ItemTemplate>
            </asp:Repeater>
        </select>
        <select class="select" onchange="selectLink(this)">
            <option>省外供销网站</option>
            <asp:Repeater ID="repGXWZ" runat="server">
                <ItemTemplate>
                    <option value="<%#Eval("LinkUrl") %>"><%#Eval("LinkName") %></option>
                </ItemTemplate>
            </asp:Repeater>
        </select>
        <select class="select" onchange="selectLink(this)">
            <option>广州市供销合作社</option>
            <asp:Repeater ID="repGXHZS" runat="server">
                <ItemTemplate>
                    <option value="<%#Eval("LinkUrl") %>"><%#Eval("LinkName") %></option>
                </ItemTemplate>
            </asp:Repeater>
        </select>
        <select class="select" onchange="selectLink(this)">
            <option>社有企业网站</option>
            <asp:Repeater ID="repSYWZ" runat="server">
                <ItemTemplate>
                    <option value="<%#Eval("LinkUrl") %>"><%#Eval("LinkName") %></option>
                </ItemTemplate>
            </asp:Repeater>
        </select>
    </div>
</div>

<script type="text/javascript">
    function ForceWindow() {
        this.r = document.documentElement;
        this.f = document.createElement("FORM");
        this.f.target = "_blank";
        this.f.method = "get";
        this.r.insertBefore(this.f, this.r.childNodes[0]);
    }
    ForceWindow.prototype.open = function(sUrl) {
        this.f.action = sUrl;
        this.f.submit();
    }
    function selectLink(obj) {
        var myWindow = new ForceWindow();
        myWindow.open(obj.value);
    }
</script>

