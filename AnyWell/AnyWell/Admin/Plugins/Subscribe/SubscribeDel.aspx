<%@ Page Language="C#" MasterPageFile="~/Admin/Master/CenterPopup.master" 
AutoEventWireup="true" CodeFile="SubscribeDel.aspx.cs" Inherits="Admin_Plugins_Subscribe_SubscribeDel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" Runat="Server">
    确定要彻底删除以下订阅？
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="optionhead">
    </div>
    <div class="popmbd">
        <table>
            <tr>
                <td class="popworn">
                    <div>
                        <asp:Repeater ID="repSubscribes" runat="server">
                            <ItemTemplate>
                                <p title="<%#Eval("fdSubsID") %>">
                                    <%#Container.ItemIndex + 1%>.<%#Studio.Web.WebAgent.GetLeft((string)Eval("fdSubsCompany"), 28, false)%></p>
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

