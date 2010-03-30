<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ToolTip.ascx.cs" Inherits="Controls_ToolTip" %>
<div id="tooltip" class="tooltip" onmouseout="ToolTipHide()">
<div id="toolContent" class="toolContent">
    <asp:Repeater ID="repCate" runat="server" OnItemDataBound="repCategory_ItemDataBound">
        <ItemTemplate>
            <h4>
                <a href="Category.aspx?cid=<%#Eval("ID") %>" class="abc">
                    <%#Eval("Name")%></a></h4>
            <div class="link">
                <asp:Repeater ID="repChiled" runat="server">
                    <ItemTemplate>
                        <a href="Category.aspx?cid=<%#Eval("ID") %>" >
                            <%#Eval("Name")%></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
</div>
<script type="text/javascript">
    var tId = document.getElementById("tooltip");
    var vWidth = "500";
    var vHeight = "500";
    tId.style.display = "none";
    function ToolTipHide()
    {
        tId.style.display = "none";
    }
    function ToolTipShow()
    {
        tId.style.display = "block";
    }
</script>
