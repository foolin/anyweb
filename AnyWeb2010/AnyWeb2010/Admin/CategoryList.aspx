<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="CategoryList.aspx.cs" Inherits="Admin_CategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="categoryadd.aspx">添加类别</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                商品分类</h3>
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
                            导航
                        </th>
                        <th>
                            首页模版
                        </th>
                        <th>
                            内容模版
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="repCategories" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt">
                            <td style="width: 30px;">
                                <%# Eval("fdCateID")%>
                            </td>
                            <td style="text-align: left; padding-left: 10px">
                                <a href="<%#Eval("PathStr") %>" target="_blank"><%# Eval("fdCateName")%></a>
                            </td>
                            <td>
                                <span style="color: <%# Eval("Parent") != null || Eval("fdCateIsShow").ToString() == "0" ? "#eee" : ""%>">
                                    显示<span>
                            </td>
                            <td>
                                <%#(int)Eval("fdCateTempIndex") == 0 ? "未设置" : "<a href=\"TemplateEdit.aspx?id="+Eval("IndexTemplate.fdTempID")+"\" title=\"修改模版\">"+Eval("IndexTemplate.fdTempName")+"</a>"%>
                                <a href="TemplateColumn.aspx?ttype=1&type=2&id=<%#Eval("fdCateID") %>" title="设置模版">
                                    <img src="../public/images/set.gif" alt="设置模版" /></a>
                            </td>
                            <td>
                                <%#(int)Eval("fdCateTempContent") == 0 ? "未设置" : "<a href=\"TemplateEdit.aspx?id=" + Eval("ContentTemplate.fdTempID") + "\" title=\"修改模版\">" + Eval("ContentTemplate.fdTempName") + "</a>"%>
                                <a href="TemplateColumn.aspx?ttype=2&type=2&id=<%#Eval("fdCateID") %>" title="设置模版">
                                    <img src="../public/images/set.gif" alt="设置模版" /></a>
                            </td>
                            <td style="text-align: left; padding-left: 10px">
                                <a href="categoryedit.aspx?id=<%# Eval("fdCateID")%>">修改</a> <a href="categorysort.aspx?type=up&id=<%# Eval("fdCateID")%>">
                                    排前</a> <a href="categorysort.aspx?type=down&id=<%# Eval("fdCateID")%>">排后</a>
                                <a href="categorydel.aspx?type=del&id=<%# Eval("fdCateID")%>" onclick="return confirm('您确定要删除吗?')">
                                    删除</a>
                            </td>
                        </tr>
                        <asp:Repeater ID="drpChildren" runat="server" DataSource='<%#Eval("Children")%>'>
                            <ItemTemplate>
                                <tr align="center" class="edit">
                                    <td style="width: 30px;">
                                        <%# Eval("fdCateID")%>
                                    </td>
                                    <td style="text-align: left; padding-left: 30px;">
                                        <%# Eval("fdCateName")%>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <%#(int)Eval("fdCateTempIndex") == 0 ? "未设置" : "<a href=\"TemplateEdit.aspx?id="+Eval("IndexTemplate.fdTempID")+"\" title=\"修改模版\">"+Eval("IndexTemplate.fdTempName")+"</a>"%>
                                        <a href="TemplateColumn.aspx?ttype=1&type=2&id=<%#Eval("fdCateID") %>" title="设置模版">
                                            <img src="../public/images/set.gif" alt="设置模版" /></a>
                                    </td>
                                    <td>
                                        <%#(int)Eval("fdCateTempContent") == 0 ? "未设置" : "<a href=\"TemplateEdit.aspx?id=" + Eval("ContentTemplate.fdTempID") + "\" title=\"修改模版\">" + Eval("ContentTemplate.fdTempName") + "</a>"%>
                                        <a href="TemplateColumn.aspx?ttype=2&type=2&id=<%#Eval("fdCateID") %>" title="设置模版">
                                            <img src="../public/images/set.gif" alt="设置模版" /></a>
                                    </td>
                                    <td style="text-align: left; padding-left: 10px;">
                                        <a href="categoryedit.aspx?id=<%# Eval("fdCateID")%>">修改</a> <a href="categorysort.aspx?type=up&id=<%# Eval("fdCateID")%>">
                                            排前</a> <a href="categorysort.aspx?type=down&id=<%# Eval("fdCateID")%>">排后</a>
                                        <a href="categorydel.aspx?type=del&id=<%# Eval("fdCateID")%>" onclick="return confirm('您确定要删除吗?')">
                                            删除</a>
                                    </td>
                                </tr>
                                <asp:Repeater ID="drpChildren" runat="server" DataSource='<%#Eval("Children")%>'>
                                    <ItemTemplate>
                                        <tr align="center" class="edit">
                                            <td style="width: 50px;">
                                                <%# Eval("fdCateID")%>
                                            </td>
                                            <td style="text-align: left; padding-left: 50px;">
                                                <%# Eval("fdCateName")%>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <%#(int)Eval("fdCateTempIndex") == 0 ? "未设置" : "<a href=\"TemplateEdit.aspx?id="+Eval("IndexTemplate.fdTempID")+"\" title=\"修改模版\">"+Eval("IndexTemplate.fdTempName")+"</a>"%>
                                                <a href="TemplateColumn.aspx?ttype=1&type=2&id=<%#Eval("fdCateID") %>" title="设置模版">
                                                    <img src="../public/images/set.gif" alt="设置模版" /></a>
                                            </td>
                                            <td>
                                                <%#(int)Eval("fdCateTempContent") == 0 ? "未设置" : "<a href=\"TemplateEdit.aspx?id=" + Eval("ContentTemplate.fdTempID") + "\" title=\"修改模版\">" + Eval("ContentTemplate.fdTempName") + "</a>"%>
                                                <a href="TemplateColumn.aspx?ttype=2&type=2&id=<%#Eval("fdCateID") %>" title="设置模版">
                                                    <img src="../public/images/set.gif" alt="设置模版" /></a>
                                            </td>
                                            <td style="text-align: left; padding-left: 10px;">
                                                <a href="categoryedit.aspx?id=<%# Eval("fdCateID")%>">修改</a> <a href="categorysort.aspx?type=up&id=<%# Eval("fdCateID")%>">
                                                    排前</a> <a href="categorysort.aspx?type=down&id=<%# Eval("fdCateID")%>">排后</a>
                                                <a href="categorydel.aspx?type=del&id=<%# Eval("fdCateID")%>" onclick="return confirm('您确定要删除吗?')">
                                                    删除</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
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
            <li>建议使用二级分类结构，系统最多支持三级商品分类。</li>
            <li>当分类中存在商品时，分类不能删除。</li>
        </ul>
    </div>
</asp:Content>
