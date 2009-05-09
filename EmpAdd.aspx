<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmpAdd.aspx.cs" Inherits="EmpAdd" Title="添加雇员" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content1" Runat="Server">
    <div id="childmenu">
        <a class="menu" href="emplist.aspx">返回列表</a>
    </div>
    <asp:FormView ID="frm1" runat="server" DataKeyNames="id" DataSourceID="Data1"
        DefaultMode="Insert" OnDataBound="frm1_DataBound">
        <HeaderTemplate>
            <table id="edit_header" align="center" cellpadding="4" cellspacing="0">
                <tr id="edithead">
                    <td>
                        添加雇员信息</td>
                </tr>
            </table>
        </HeaderTemplate>
        <FooterTemplate>
            <table id="edit_footer" align="center" cellpadding="4" cellspacing="0">
                <tr id="editcmd">
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text=" 保存 " CommandName="Insert"></asp:Button>&nbsp;
                        <button onclick="window.navigate('emplist.aspx');"> 取消 </button>
                    </td>
                </tr>
            </table>
        </FooterTemplate>
        <EditItemTemplate>
            <table id="edit_form" align="center" cellpadding="4" cellspacing="0">
                <tr>
                    <td class="edittitle">
                        雇员编号：</td>
                    <td class="textvalue">
                        <asp:TextBox ID="txtEmpID" runat="server" require="1" errmsg="请输入雇员编号" Width="180px" Text='<%# Bind("ID") %>' MaxLength="9"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="edittitle">
                        雇员姓名：</td>
                    <td class="textvalue">
                        <asp:TextBox ID="txtFirstName" runat="server" require="1" errmsg="请输入First Name" Width="100px" Text='<%# Bind("FirstName") %>' MaxLength="20"></asp:TextBox>
                        <asp:TextBox ID="txtLastName" runat="server" require="1" errmsg="请输入Last Name" Width="100px" Text='<%# Bind("LastName") %>' MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="edittitle">
                        职位信息：</td>
                    <td class="textvalue">
                        <asp:DropDownList id="drpJob" runat="server" DataTextField="name" DataValueField="id">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="edittitle">
                        入职时间：</td>
                    <td class="textvalue">
                        <asp:TextBox ID="txtHireDate" runat="server" require="1" errmsg="请输入入职时间" Width="80px" Text='<%# Bind("HireDate") %>' MaxLength="10"></asp:TextBox>例如：<%=DateTime.Now.ToString("yyyy-MM-dd")%>
                    </td>
                </tr>
            </table>
        </EditItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="Data1" runat="server" InsertMethod="AddEmployee" DataObjectTypeName="Employee" TypeName="EmployeeAgent" OnInserting="Data1_Inserting" OnInserted="Data1_Inserted">
        <InsertParameters>
            <asp:ControlParameter ControlID="emp" ConvertEmptyStringToNull="False" Name="emp"
                Type="Object" />
        </InsertParameters>
    </asp:ObjectDataSource>
</asp:Content>

