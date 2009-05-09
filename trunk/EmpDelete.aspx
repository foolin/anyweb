<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmpDelete.aspx.cs" Inherits="EmpDelete" Title="删除雇员" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content1" Runat="Server">
    <div id="childmenu">
        <a class="menu" href="emplist.aspx">返回列表</a>
    </div>
    <asp:FormView ID="frm1" runat="server" DataSourceID="Data1"
        DefaultMode="ReadOnly" OnDataBound="frm1_DataBound">
        <HeaderTemplate>
            <table id="edit_header" align="center" cellpadding="4" cellspacing="0">
                <tr id="edithead">
                    <td>
                        删除雇员信息</td>
                </tr>
            </table>
        </HeaderTemplate>
        <FooterTemplate>
            <table id="edit_footer" align="center" cellpadding="4" cellspacing="0">
                <tr id="editcmd">
                    <td>
                        <asp:Button ID="btnDelete" runat="server" Text=" 删除 " CommandName="Delete"></asp:Button>&nbsp;
                        <button onclick="window.navigate('emplist.aspx');"> 取消 </button>
                    </td>
                </tr>
            </table>
        </FooterTemplate>
        <ItemTemplate>
            <table id="edit_form" align="center" cellpadding="4" cellspacing="0">
                <tr>
                    <td class="edittitle">
                        雇员编号：</td>
                    <td class="textvalue">
                        <asp:TextBox ID="txtEmpID" runat="server" require="1" errmsg="请输入雇员编号" Width="180px" Text='<%# Eval("ID") %>' MaxLength="9"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="edittitle">
                        雇员姓名：</td>
                    <td class="textvalue">
                        <asp:TextBox ID="txtFirstName" runat="server" require="1" errmsg="请输入First Name" Width="100px" Text='<%# Eval("FirstName") %>' MaxLength="20" ReadOnly="true"></asp:TextBox>
                        <asp:TextBox ID="txtLastName" runat="server" require="1" errmsg="请输入Last Name" Width="100px" Text='<%# Eval("LastName") %>' MaxLength="20" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="edittitle">
                        职位信息：</td>
                    <td class="textvalue">
                        <asp:DropDownList id="drpJob" runat="server" DataTextField="name" DataValueField="id" Enabled="false">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="edittitle">
                        入职时间：</td>
                    <td class="textvalue">
                        <asp:TextBox ID="txtHireDate" runat="server" require="1" errmsg="请输入入职时间" Width="80px" Text='<%# Eval("HireDate") %>' MaxLength="10" ReadOnly="true"></asp:TextBox>例如：<%=DateTime.Now.ToString("yyyy-MM-dd")%>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="Data1" runat="server" SelectMethod="GetEmployInfo"
        TypeName="EmployeeAgent" DeleteMethod="DeleteEmployee" OnDeleted="Data1_Deleted">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="empID" QueryStringField="id" Type="String" />
        </SelectParameters>
        <DeleteParameters>
            <asp:QueryStringParameter Name="empID" QueryStringField="id" Type="String" />
        </DeleteParameters>
    </asp:ObjectDataSource>
</asp:Content>

