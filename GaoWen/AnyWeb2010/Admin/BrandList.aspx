<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="BrandList.aspx.cs" Inherits="Admin_BrandList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="brandadd.aspx">添加品牌</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                商品品牌</h3>
        </div>
        <div class="mbd">
            <table>
                <thead>
                    <tr>
                        <th>
                            编号
                        </th>
                        <th>
                            名称
                        </th>
                        <th>
                            图片
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="repBrands" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt">
                            <td style="width: 30px;">
                                <%# Eval("fdBranID")%>
                            </td>
                            <td style="text-align: left; padding-left: 10px">
                                <%# Eval("fdBranName")%>
                            </td>
                            <td>
                                <img alt="" src="<%# Eval("fdBranPicture")%>" style="width: 100px; height: 40px;" />
                            </td>
                            <td style="text-align: left; padding-left: 10px">
                                <a href="brandedit.aspx?id=<%# Eval("fdBranID")%>">修改</a> <a href="brandsort.aspx?type=up&id=<%# Eval("fdBranID")%>">
                                    排前</a> <a href="brandsort.aspx?type=down&id=<%# Eval("fdBranID")%>">排后</a> <a href="branddel.aspx?type=del&id=<%# Eval("fdBranID")%>"
                                        onclick="return confirm('您确定要删除吗?')">删除</a>
                            </td>
                        </tr>
                        <asp:Repeater ID="repBrands" runat="server" EnableViewState="False" DataSource='<%#Eval("Children")%>'>
                            <ItemTemplate>
                                <tr align="center" class="editalt">
                                    <td style="width: 30px;">
                                        <%# Eval("fdBranID")%>
                                    </td>
                                    <td style="text-align: left; padding-left: 30px">
                                        <%# Eval("fdBranName")%>
                                    </td>
                                    <td>
                                        <img alt="" src="<%# Eval("fdBranPicture")%>" style="width: 100px; height: 40px;" />
                                    </td>
                                    <td style="text-align: left; padding-left: 10px">
                                        <a href="brandedit.aspx?id=<%# Eval("fdBranID")%>">修改</a> <a href="brandsort.aspx?type=up&id=<%# Eval("fdBranID")%>">
                                            排前</a> <a href="brandsort.aspx?type=down&id=<%# Eval("fdBranID")%>">排后</a> <a href="branddel.aspx?type=del&id=<%# Eval("fdBranID")%>"
                                                onclick="return confirm('您确定要删除吗?')">删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>系统最多支持二级商品品牌结构。</li>
            <li>当删除品牌时，品牌中的商品不会受到影响。</li>
        </ul>
    </div>
</asp:Content>
