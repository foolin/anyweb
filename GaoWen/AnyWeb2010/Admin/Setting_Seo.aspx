<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="Setting_Seo.aspx.cs" Inherits="Admin_Setting_Seo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                搜索引擎优化</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    标题附加字：</label>
                <asp:TextBox ID="txtTitleExt" runat="server" CssClass="text" Height="80px" Width="400px"
                    TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="fi even">
                <label>
                    Meta Keywords：</label>
                <asp:TextBox ID="txtMetaKeywords" runat="server" CssClass="text" Height="80px" Width="400px"
                    TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="fi">
                <label>
                    Meta Description：</label>
                <asp:TextBox ID="txtMetaDescription" runat="server" CssClass="text" Height="120px"
                    Width="400px" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存配置" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
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
