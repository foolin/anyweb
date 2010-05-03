<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="RelationEdit.aspx.cs" Inherits="Admin_RelationEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <script type="text/javascript">
        var child = new Array;
        <asp:Literal ID="litJs" runat="server"></asp:Literal>
        function columnChange(){
            var i, index;
            index = document.getElementById("<%=drpColumn.ClientID %>").selectedIndex;
            var objChild = document.getElementById("<%=drpChild.ClientID %>");
            var iCount = child[index].length;
            for (i = objChild.options.length - 1; i >= 0; i--) {
                objChild.remove(i);
            }            
            var option = document.createElement("OPTION");
            option.value = "0";
            option.text = "不选择二级栏目";
            objChild.options.add(option);
            for (i = 0; i <= iCount - 1; i++) {
                var option = document.createElement("OPTION");
                option.value = child[index][i].substring(0,child[index][i].indexOf(":"));
                option.text = child[index][i].substring(child[index][i].indexOf(":")+1,child[index][i].length);
                objChild.options.add(option);
            }
        }
    </script>
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改文章</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    信息标题：</label>
                <asp:TextBox ID="txtTitle" MaxLength="200" Width="400px" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="txtTitle" ValidateType="Required" ErrorText="请输入标题"
                    ErrorMessage="请输入标题" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    所属栏目：</label>
                <asp:DropDownList ID="drpColumn" DataTextField="fdColuName" DataValueField="fdColuID"
                    runat="server" onchange="columnChange()">
                </asp:DropDownList>
                <asp:DropDownList ID="drpChild" runat="server"></asp:DropDownList>
            </div>
            <div class="fi">
                <label>
                    链接地址：</label>
                <asp:TextBox ID="txtLink" MaxLength="400" Width="400px" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator2" ControlID="txtLink" ValidateType="Required" ErrorText="请输入链接地址"
                    ErrorMessage="请输入链接地址" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    文章排序：</label>
                <asp:TextBox ID="txtSort" runat="server" Text="0" CssClass="text" Width="80"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator3" ControlID="txtSort" ValidateType="Required" ErrorText="请输入排序"
                    ErrorMessage="请输入排序" runat="server">
                </sw:Validator>
                <sw:Validator ID="Validator4" ControlID="txtSort" ValidateType="DataType" DataType="Integer"
                    ErrorText="请输入正确的排序" ErrorMessage="请输入正确的排序" runat="server">
                </sw:Validator>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click">
                </asp:Button>
                <a href="javascript:history.back();">返回列表</a>
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

