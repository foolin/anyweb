<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/CenterPopup.master"
    AutoEventWireup="true" CodeFile="TemplateSet.aspx.cs" Inherits="Admin_Content_TemplateSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script type="text/javascript">
        function search() {
            var url = "?sid=<%=QS("sid") %>&type=<%=QS("type") %>&key=" + $("#txtKey").val();
            if(<%=QS("column")=="true"?"true":"false" %>){ 
                url += "&column=<%=QS("column") %>&cid=<%=QS("cid") %>";
            }
            window.location.href = url;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="Server">
    选择模板
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="optionhead">
        <input type="text" id="txtKey" value="<%=QS("key") %>" />
        <button type="button" onclick="search()">
            搜索
        </button>
    </div>
    <div class="popmbd">
        <table>
            <tr>
                <td class="popworn">
                    <div>
                        <asp:Repeater ID="repTemplate" runat="server">
                            <ItemTemplate>
                                <p title="<%#Eval("fdTempName") %>">
                                    <input type="radio" class="radio" name="ids" value="<%#Eval("fdTempID") %>" />
                                    <%#Container.ItemIndex + 1%>.<%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdTempName" ), 26, false )%></p>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="popmft">
        <button id="Saving" type="button" style="display: none;" disabled="disabled">
            正在保存</button>
        <button id="btnStart" type="submit" onclick="disableButton()">
            确 认</button>
        <button type="button" onclick="parent.disablePopup()">
            取 消</button>
    </div>
</asp:Content>
