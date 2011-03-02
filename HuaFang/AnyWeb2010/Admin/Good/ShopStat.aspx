<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ShopStat.aspx.cs" Inherits="Admin_ShopStat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">

    <script type="text/javascript">
    function search()
    {
        var url = 'ShopStat.aspx?status='+document.getElementById('<%= drpStatus.ClientID %>').value;
        url += '&startDate='+document.getElementById('<%= txtStartDate.ClientID %>').value;
        url += '&endDate='+document.getElementById('<%= txtEndDate.ClientID %>').value;
        location =url;
    } 
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                ͳ�Ʊ���</h3>
        </div>
        <div class="fi filter">
            ����״̬��<asp:DropDownList ID="drpStatus" runat="server">
                <asp:ListItem Value="0">�������Ͷ���</asp:ListItem>
                <asp:ListItem Value="1">������֧��</asp:ListItem>
                <asp:ListItem Value="2">��֧��������</asp:ListItem>
                <asp:ListItem Value="3">�ѷ�����ȷ��</asp:ListItem>
                <asp:ListItem Value="4">��ȷ�����</asp:ListItem>
                <asp:ListItem Value="5">ȱ���Ǽ�</asp:ListItem>
                <asp:ListItem Value="6">�û�ȡ��</asp:ListItem>
                <asp:ListItem Value="7">������Ч</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;�����������ڣ���&nbsp;<asp:TextBox ID="txtStartDate" runat="server" onclick="setday(this);"
                CssClass="text"></asp:TextBox>&nbsp;��&nbsp;<asp:TextBox ID="txtEndDate" runat="server"
                    onclick="setday(this);" CssClass="text"></asp:TextBox>&nbsp;
            <input type="button" value="��ѯ" onclick="search()" />
        </div>
        <div class="mbd">
            <div style="margin: 5px;">
                <ul>
                    <li>��������<%=this.OrderCount%></li>
                    <li>�������۽���ܺͣ�<%=this.GoodsPrice.ToString("c")%></li>
                    <li>�����������ܺͣ�<%=this.PayPrice.ToString("c")%></li>
                    <li style="display: none;">�����ܺͣ�0</li>
                </ul>
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
