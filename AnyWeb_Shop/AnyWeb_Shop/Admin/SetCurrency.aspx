<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SetCurrency.aspx.cs" Inherits="SetCurrency" Title="支付货币管理0" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
<div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    添加支付货币管理</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
            <form id="form1" runat="server" >
                请选择你要添加的支付货币种类 ：<asp:DropDownList ID="ddlCurrency" runat="server" DataTextField="Name" DataValueField="ID">
                </asp:DropDownList>
                <div>
                    <asp:Button ID="btnOK" runat="server" Text="添加" OnClick="btnOK_Click" />
                </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>

