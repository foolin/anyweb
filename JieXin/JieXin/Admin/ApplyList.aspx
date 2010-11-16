<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" 
CodeFile="ApplyList.aspx.cs" Inherits="Admin_ApplyList"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <div>
        <div class="mhd">
            <h3>
                简历筛选器(仅搜索本职位简历)</h3>
        </div>
        <div class="mbd">
            <div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <th>工作年限</th>
                        <td style="width: 430px">
                            <asp:DropDownList ID="drpExper" runat="server" Width="190px">
                                <asp:ListItem Value="0" Text="-请选择年限-"></asp:ListItem>
                                <asp:ListItem Value="1" Text="1年以下"></asp:ListItem>
                                <asp:ListItem Value="2" Text="1-2年"></asp:ListItem>
                                <asp:ListItem Value="3" Text="2-5年"></asp:ListItem>
                                <asp:ListItem Value="4" Text="5-10年"></asp:ListItem>
                                <asp:ListItem Value="5" Text="10年以上"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <th>职能</th>
                        <td style="width: 256px">
                            <asp:TextBox ID="txtPosiName" runat="server" Width="230px"></asp:TextBox>
                        </td>
                        <th>行业</th>
                        <td>
                           <asp:TextBox ID="txtTrade" runat="server" Width="130px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <th>性别</th>
                        <td style="width: 430px">
                            <asp:RadioButton ID="radio1" runat="server" GroupName="sex" Text="不限" checked="true"/>
                            &nbsp;&nbsp;
                            <asp:RadioButton ID="radio2" runat="server" GroupName="sex" Text="男" />
                            &nbsp;&nbsp;
                            <asp:RadioButton ID="radio3" runat="server" GroupName="sex" Text="女" />
                        </td>
                        <th>学历</th>
                        <td style="width: 256px">
                            
                            <asp:DropDownList ID="drpEduFrom" runat="server" Width="110px">
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
                            <span>到</span>
                            <asp:DropDownList ID="drpEduTo" runat="server" Width="110px">
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
                        <th>年龄</th>
                        <td>
                            <asp:TextBox ID="txtAgeFrom" runat="server" Width="57px"></asp:TextBox>
                            <span>到</span>
                            <asp:TextBox ID="txtAgeTo" runat="server" Width="57px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <th>关键词</th>
                        <td style="width: 430px">
                            
                            <asp:TextBox ID="txtKey" runat="server" Width="260px"></asp:TextBox>
                            &nbsp;
                            <asp:DropDownList ID="drpType" runat="server" Width="130px">
                            </asp:DropDownList>
                            
                        </td>
                        <td>
                        </td>
                        <td style="width: 256px">
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="查询" 
                                style="position:relative;left:25px; top: 0px; width: 85px;"/>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <div style="text-align:right;">
                    <sw:PageNaver ID="PN1" runat="server" StyleID="5" PageSize="12">
                    </sw:PageNaver>
                </div>
                <div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <thead>
                            <tr>
                                <th>
                                    选择
                                </th>
                                <th>
                                    状态
                                </th>
                                <th>
                                    姓名
                                </th>
                                <th>
                                    性别
                                </th>
                                <th>
                                    工作地点
                                </th>
                                <th>
                                    职能
                                </th>
                                <th>
                                    学历
                                </th>
                                <th>
                                    年龄
                                </th>
                                <th>
                                    工作年限
                                </th>
                                <th>
                                    投递时间
                                </th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="rep" runat="server">
                            <ItemTemplate>
                                <tr align="center" id="row_<%# Eval("fdResuID")%>">
                                    <td style="width: 30px;">
                                        <input type="checkbox" name="ids" value="<%# Eval("fdResuID")%>" />
                                    </td>
                                    <td>
                                        
                                    </td>
                                    <td>
                                        <%#Eval("fdResuUserName")%>
                                    </td>
                                    <td>
                                        <%#Eval("fdResuSex")%>
                                    </td>
                                    <td>
                                        
                                    </td>
                                    <td>
                                        <%#Eval("fdPosiName")%>
                                    </td>
                                    <td>
                                        <%#Eval("fdEducDegree")%>
                                    </td>
                                    <td>
                                        
                                    </td>
                                    <td>
                                        <%#Eval("fdUserExperience")%>
                                    </td>
                                    <td>
                                        <%#Eval("fdResuCreateAt")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
                <div style="text-align:right;">
                    <sw:PageNaver ID="PN2" runat="server" StyleID="5" PageSize="12">
                    </sw:PageNaver>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

