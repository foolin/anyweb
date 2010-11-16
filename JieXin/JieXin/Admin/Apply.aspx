<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="Apply.aspx.cs" Inherits="Admin_Apply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div>
        <div class="mbd">
            <table width="450" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <th>搜索类别</th>
                    <td>
                        <asp:DropDownList ID="drpType" runat="server" Width="80px">
                            <asp:ListItem Value="1" Text="全文"></asp:ListItem>
                            <asp:ListItem Value="2" Text="职务名"></asp:ListItem>
                            <asp:ListItem Value="3" Text="公司名"></asp:ListItem>
                            <asp:ListItem Value="4" Text="学校名"></asp:ListItem>
                            <asp:ListItem Value="5" Text="证书"></asp:ListItem>
                            <asp:ListItem Value="6" Text="工作经历"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>关键字</th>
                    <td>
                        <asp:TextBox ID="txtKey" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>目前居住地</th>
                    <td>
                        <asp:TextBox ID="txtAddr" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>行业</th>
                    <td>
                        <asp:TextBox ID="txtTrade" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>工作年限</th>
                    <td>
                        <asp:DropDownList ID="drpWorkFrom" runat="server" Width="140px">
                            <asp:ListItem Value="0" Text="不限"></asp:ListItem>
                            <asp:ListItem Value="1" Text="1年以下"></asp:ListItem>
                            <asp:ListItem Value="2" Text="1-2年"></asp:ListItem>
                            <asp:ListItem Value="3" Text="2-5年"></asp:ListItem>
                            <asp:ListItem Value="4" Text="5-10年"></asp:ListItem>
                            <asp:ListItem Value="5" Text="10年以上"></asp:ListItem>
                        </asp:DropDownList>
                        <span>&nbsp;到</span>
                        <asp:DropDownList ID="drpWorkTo" runat="server" Width="140px">
                            <asp:ListItem Value="0" Text="不限"></asp:ListItem>
                            <asp:ListItem Value="1" Text="1年以下"></asp:ListItem>
                            <asp:ListItem Value="2" Text="1-2年"></asp:ListItem>
                            <asp:ListItem Value="3" Text="2-5年"></asp:ListItem>
                            <asp:ListItem Value="4" Text="5-10年"></asp:ListItem>
                            <asp:ListItem Value="5" Text="10年以上"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>学历</th>
                    <td>
                        <asp:DropDownList ID="drpEduFrom" runat="server" Width="140px">
                            <asp:ListItem Value="0" Text="-请选择-"></asp:ListItem>
                            <asp:ListItem Value="1" Text="初中"></asp:ListItem>
                            <asp:ListItem Value="2" Text="高中"></asp:ListItem>
                            <asp:ListItem Value="3" Text="中技"></asp:ListItem>
                            <asp:ListItem Value="4" Text="中专"></asp:ListItem>
                            <asp:ListItem Value="5" Text="大专"></asp:ListItem>
                            <asp:ListItem Value="6" Text="本科"></asp:ListItem>
                            <asp:ListItem Value="7" Text="MBA"></asp:ListItem>
                            <asp:ListItem Value="8" Text="硕士"></asp:ListItem>
                            <asp:ListItem Value="9" Text="博士"></asp:ListItem>
                            <asp:ListItem Value="10" Text="其他"></asp:ListItem>
                        </asp:DropDownList>
                        <span>&nbsp;到</span>
                        <asp:DropDownList ID="drpEduTo" runat="server" Width="140px">
                            <asp:ListItem Value="0" Text="-请选择-"></asp:ListItem>
                            <asp:ListItem Value="1" Text="初中"></asp:ListItem>
                            <asp:ListItem Value="2" Text="高中"></asp:ListItem>
                            <asp:ListItem Value="3" Text="中技"></asp:ListItem>
                            <asp:ListItem Value="4" Text="中专"></asp:ListItem>
                            <asp:ListItem Value="5" Text="大专"></asp:ListItem>
                            <asp:ListItem Value="6" Text="本科"></asp:ListItem>
                            <asp:ListItem Value="7" Text="MBA"></asp:ListItem>
                            <asp:ListItem Value="8" Text="硕士"></asp:ListItem>
                            <asp:ListItem Value="9" Text="博士"></asp:ListItem>
                            <asp:ListItem Value="10" Text="其他"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>年龄</th>
                    <td>
                        <asp:TextBox ID="txtAgeFrom" runat="server" Width="140px"></asp:TextBox>
                        <span>&nbsp;到</span>
                        <asp:TextBox ID="txtAgeTo" runat="server" Width="140px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>性别</th>
                    <td>
                        <asp:RadioButton ID="radio1" runat="server" Text="不限" GroupName="sex" checked="true"/>
                        <asp:RadioButton ID="radio2" runat="server" Text="男" GroupName="sex"/>
                        <asp:RadioButton ID="radio3" runat="server" Text="女" GroupName="sex"/>
                    </td>
                </tr>
                <tr>
                    <th>目前月薪</th>
                    <td>
                        <asp:TextBox ID="txtSalaryFrom" runat="server" Width="140px"></asp:TextBox>
                        <span>&nbsp;到</span>
                        <asp:TextBox ID="txtSalaryTo" runat="server" Width="140px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>专业</th>
                    <td>
                        <asp:TextBox ID="txtMajor" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>简历更新</th>
                    <td>
                        <asp:DropDownList ID="drpResuUpdate" runat="server" Width="300px">
                            <asp:ListItem Value="1" Text="两个月内"></asp:ListItem>
                            <asp:ListItem Value="2" Text="三个月内"></asp:ListItem>
                            <asp:ListItem Value="3" Text="半年内"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <div>
            </div>
            <div>
                <asp:Button ID="btnSearch" runat="server" Text="查询" style="position:relative;left:300px; " />
            </div>
        </div>
    </div>
</asp:Content>
