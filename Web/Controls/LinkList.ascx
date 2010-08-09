<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkList.ascx.cs" Inherits="Controls_LinkList" %>
<div class="box-title">
    <span class="titletxt">--== 友情链接 ==--</span></div>
<div class="box-content"  style="text-align:center;">
    <div class="picLinks">
        <asp:Repeater ID="repImage" runat="server">
            <ItemTemplate>
                <a href="<%#Eval("LinkUrl") %>" target="_blank">
                    <%#Eval("LinkName") %></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="txtLinks">
        <asp:DropDownList ID="drpLink" runat="server" DataTextField="LinkName" DataValueField="LinkUrl">
        </asp:DropDownList>
    </div>
</div>
<script type="text/jscript">
//    function linkSelect(){
//        var obj = document.getElementById("<%=drpLink.ClientID %>");
//        window.open(obj.value,"","","");
//    }
    function ForceWindow ()
    {
        this.r = document.documentElement;
        this.f = document.createElement("FORM");
        this.f.target = "_blank";
        this.f.method = "post";
        this.r.insertBefore(this.f, this.r.childNodes[0]);
    }
    ForceWindow.prototype.open = function (sUrl)
    {
        this.f.action = sUrl;
        this.f.submit();
    }
    function linkSelect(){
        var myWindow = new ForceWindow(); 
        var obj = document.getElementById("<%=drpLink.ClientID %>");
        //window.showModelessDialog(obj.value,'dialogwin','scroll:0;status:0;help:1;resizable:1;dialogWidth:480px;dialogHeight:320px');
        myWindow.open(obj.value);
    }
</script>
