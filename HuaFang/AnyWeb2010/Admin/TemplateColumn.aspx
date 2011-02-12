<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="TemplateColumn.aspx.cs" Inherits="Admin_TemplateColumn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">

    <script type="text/javascript">
        function search() {
            window.location = "?id="+<%=QS("id") %>+"&ttype="+<%=QS("ttype") %>+"&type="+<%=QS("type") %>+"&name=" + $("#<%=txtName.ClientID %>").val();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm">
        <div class="mhd">
            <h3>
                设置模版</h3>
        </div>
        <div class="fi filter">
            模版名称：<asp:TextBox ID="txtName" runat="server" CssClass="text" Width="120"></asp:TextBox>
            <button onclick="search()">
                搜索</button>
        </div>
        <div class="mbd">
            <div style="margin-left: 300px;">
                <asp:Repeater ID="repTemplate" runat="server">
                    <ItemTemplate>
                        <p>
                            <label style="width: 100%">
                                <input type="radio" name="template" value="<%#Eval("fdTempID") %>" /><%#Eval("fdTempName") %>&nbsp;&nbsp;[<%#Eval("fdTempCreateAt","{0:yyyy-MM-dd HH:mm}") %>]</label></p>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div style="margin: 20px 0 0 200px;">
                <asp:CheckBox ID="chkUpdate" runat="server" CssClass="checkbox" Text="级联更新子栏目" />
                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click"
                    Style="margin-right: 20px; cursor: pointer; width: 164px; height: 35px; line-height: 35px;
                    padding: 0; border: 0; background: url(/public/images/modBgs.gif) 0 -415px; font-size: 14px;
                    color: #000;"></asp:Button>
                <a href="<%=RefUrl %>">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li></li>
        </ul>
    </div>
</asp:Content>
