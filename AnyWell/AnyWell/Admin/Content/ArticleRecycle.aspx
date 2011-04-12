<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/CenterPopup.master" AutoEventWireup="true" CodeFile="ArticleRecycle.aspx.cs" Inherits="Admin_Content_ArticleRecycle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" Runat="Server">
    确定要将以下文档放入回收站？
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="optionhead">
    </div>
    <div class="popmbd">
        <table>
            <tr>
                <td class="popworn">
                    <div>
                        <asp:Repeater ID="repArticles" runat="server">
                            <ItemTemplate>
                                <p title="<%#Eval("fdArtiTitle") %>">
                                    <%#Container.ItemIndex + 1%>.<%#Studio.Web.WebAgent.GetLeft((string)Eval("fdArtiTitle"),28,false) %></p>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="popmft">
        <button id="btnStart" type="submit">
            确 认</button>
        <button type="button" onclick="parent.disablePopup()">
            取 消</button>
    </div>
</asp:Content>

