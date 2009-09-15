<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkList.ascx.cs" Inherits="Controls_LinkList" %>
<div class="box-title">
    <span class="titletxt">--== 友情链接 ==--</span></div>
<div class="box-content">
    <div class="picLinks">
        <asp:Repeater ID="repImage" runat="server">
            <ItemTemplate>
                <a href="<%#Eval("LinkUrl") %>" target="_blank">
                    <img src="<%#Eval("LinkImage") %>" class="img" width="120" alt="<%#Eval("LinkName") %>" /></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="txtLinks">
        <asp:DropDownList ID="drpLink" runat="server" DataTextField="LinkName" DataValueField="LinkUrl">
        </asp:DropDownList>
    </div>
</div>
<script type="text/jscript">
    function linkSelect(){
        var obj = document.getElementById("<%=drpLink.ClientID %>");
        window.open(obj.value,"","","");
    }
</script>
