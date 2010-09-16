<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="FileEdit.aspx.cs" Inherits="Admin_FileEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="albumAdd">
        <div class="mhd">
            <h3>
                修改文件</h3>
        </div>
        <div class="mbd">
            <div class="fi even">
                <label>
                    当前位置</label>
                <div class="cont">
                    <asp:Literal ID="litPath" runat="server">D:</asp:Literal>
                </div>
            </div>
            <div class="fi">
                <label>
                    文件内容</label>
                <div class="cont">
                    <asp:TextBox ID="txtContent" runat="server" Width="100%" Height="400px" TextMode="MultiLine">
                    </asp:TextBox>
                </div>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnSave" CssClass="submit" runat="server" Text="保存文件 " OnClick="btnSave_Click">
                </asp:Button>
                <a href="filelist.aspx?path=<%=QS("path")%>">取 消</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>允许修改的文件类型包括:txt htm html aspx ascx</li>
        </ul>
    </div>
</asp:Content>
