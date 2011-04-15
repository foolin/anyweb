<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/CenterPopup.master"
    AutoEventWireup="true" CodeFile="ColumnDel.aspx.cs" Inherits="Admin_Content_ColumnDel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="Server">
    删除不可恢复，您确定要删除以下栏目吗？
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="optionhead">
    </div>
    <div class="popmbd">
        <table>
            <tr>
                <td class="popworn">
                    <div>
                        <asp:Repeater ID="repColumns" runat="server">
                            <ItemTemplate>
                                <p>
                                    <%#Container.ItemIndex + 1%>.<%#Eval("fdColuName") %></p>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="popmft">
        <button id="Saving" type="button" style="display:none;" disabled="disabled">正在保存</button>
        <button id="btnStart" type="submit" onclick="disableButton()">
            确 认</button>
        <button type="button" onclick="parent.disablePopup()">
            取 消</button>
    </div>
</asp:Content>
