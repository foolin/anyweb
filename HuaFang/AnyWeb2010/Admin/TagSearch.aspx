<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TagSearch.aspx.cs" Inherits="Admin_TagSearch" %>

<dl>
    <dt>所有标签：</dt>
    <asp:repeater id="compRep" runat="server">
        <ItemTemplate>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,1);"><%#Eval("fdTagName") %></a></dd>
        </ItemTemplate>
    </asp:repeater>
</dl>
<dl>
    <sw:PageNaver ID="PN1" runat="server" StyleID="6" PageSize="1">
    </sw:PageNaver>
</dl>
<script type="text/javascript">


    function jump(obj) {
        var i = parseInt(obj.previousSibling.value);
        if (!i && i != 0)
            return false;
        if (i <= 0)
            i = 1;
        if (i > <%=PN1.PageCount %>) 
            i = <%=PN1.PageCount %>;
        SearchTag(i);
    }
</script>
