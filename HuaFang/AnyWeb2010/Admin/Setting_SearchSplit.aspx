<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="Setting_SearchSplit.aspx.cs" Inherits="Admin_Setting_SearchSplit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                搜索分词</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <asp:TextBox ID="txtWord" TextMode="MultiLine" runat="server" Width="400px" Height="500px"
                    CssClass="text"></asp:TextBox>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存设置" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>用户在前台执行搜索的情况下，如果含有设置中的词语，将会被拆开进行搜索</li>
            <li>一行输入一个词</li>
        </ul>
    </div>
</asp:Content>
