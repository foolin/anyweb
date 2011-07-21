<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" 
CodeFile="LibraryList.aspx.cs" Inherits="Admin_LibraryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
    <ul class="Opr">
        <li><a href="LibraryAdd.aspx">添加名人/品牌</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <script type="text/javascript">
        function Change()
        {
            var url="?library="+document.getElementById("<%=drpLibrary.ClientID %>").value
                    +"&firstLetter="+document.getElementById("<%=drpFirstLetter.ClientID %>").value;
            window.location=url;
        }
        
        function SelectAll(v) {
            var list = document.getElementsByTagName("input");
            for (var i = 0; i < list.length; i++) {
                if (list[i].name == "ids" && list[i].type == "checkbox") {
                    list[i].checked = v;
                }
            }
        }
        
        function delLibrarys() {
            var list = document.getElementsByTagName("input");
            var selected = false;
            var form0;
            form0 = document.createElement("form");
            form0.method = "POST";
            form0.action = "LibrarysDel.aspx";
            for (var i = 0; i < list.length; i++) {
                if (list[i].name == "ids" && list[i].type == "checkbox" && list[i].checked) {
                    input1 = document.createElement("input");
                    input1.type = "hidden";
                    input1.name = "ids";
                    input1.value = list[i].value;
                    form0.appendChild(input1);
                    selected = true;
                }
            }
            if (selected == false) {
                alert("请选择信息");
                return;
            }
            var msg = "你确认要删除选定的信息吗?";
            if (confirm(msg)) {
                document.body.appendChild(form0);
                form0.submit();
            }
        }
    </script>
    <div id="content">
        <div class="mhd">
            <h3>
                两库管理</h3>
        </div>
        <div class="mbd">
            <div>
                分类：
                <asp:DropDownList ID="drpLibrary" runat="server" onchange="Change()">
                    <asp:ListItem Text="名人库" Value="1"></asp:ListItem>
                    <asp:ListItem Text="品牌库" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="drpFirstLetter" runat="server" onchange="Change()">
                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                    <asp:ListItem Text="B" Value="B"></asp:ListItem>
                    <asp:ListItem Text="C" Value="C"></asp:ListItem>
                    <asp:ListItem Text="D" Value="D"></asp:ListItem>
                    <asp:ListItem Text="E" Value="E"></asp:ListItem>
                    <asp:ListItem Text="F" Value="F"></asp:ListItem>
                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                    <asp:ListItem Text="H" Value="H"></asp:ListItem>
                    <asp:ListItem Text="I" Value="I"></asp:ListItem>
                    <asp:ListItem Text="J" Value="J"></asp:ListItem>
                    <asp:ListItem Text="K" Value="K"></asp:ListItem>
                    <asp:ListItem Text="L" Value="L"></asp:ListItem>
                    <asp:ListItem Text="M" Value="M"></asp:ListItem>
                    <asp:ListItem Text="N" Value="N"></asp:ListItem>
                    <asp:ListItem Text="O" Value="O"></asp:ListItem>
                    <asp:ListItem Text="P" Value="P"></asp:ListItem>
                    <asp:ListItem Text="Q" Value="Q"></asp:ListItem>
                    <asp:ListItem Text="R" Value="R"></asp:ListItem>
                    <asp:ListItem Text="S" Value="S"></asp:ListItem>
                    <asp:ListItem Text="T" Value="T"></asp:ListItem>
                    <asp:ListItem Text="U" Value="U"></asp:ListItem>
                    <asp:ListItem Text="V" Value="V"></asp:ListItem>
                    <asp:ListItem Text="W" Value="W"></asp:ListItem>
                    <asp:ListItem Text="X" Value="X"></asp:ListItem>
                    <asp:ListItem Text="Y" Value="Y"></asp:ListItem>
                    <asp:ListItem Text="Z" Value="Z"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <table width="100%" cellspacing="0" border="0">
                    <tr bgcolor="#E6F2FF">
                        <th style="width: 30px;">
                            <input type="checkbox" class="checkbox" onclick="SelectAll(this.checked)" title="全选" />
                        </th>
                        <th align="center">
                            名称</th>
                        <th align="center">
                            英文名称</th>
                        <th align="center">
                            介绍</th>
                        <th align="center">
                            操作</th>
                    </tr>
                    <asp:Repeater ID="repLibrary" runat="server">
                        <ItemTemplate>
                            <tr onmouseover="this.style.background='#E6F2FF';" onmouseout="this.style.background='#FFFFFF'" style="height:60px;">
                                <td style="width: 30px;">
                                    <input type="checkbox" name="ids" value="<%# Eval("fdLibrID")%>" />
                                </td>
                                <td align="center">
                                    <%#Eval("fdLibrName")%>
                                </td>
                                <td align="center">
                                    <%#Eval("fdLibrEnName")%>
                                </td>
                                <td align="center">
                                    <%#Eval("fdLibrDesc")%>
                                </td>
                                <td align="center">
                                    <a href="LibraryEdit.aspx?id=<%#Eval("fdLibrID") %>" title="修改信息" style="color:Blue">修改</a> 
                                    <a href="LibraryDel.aspx?id=<%#Eval("fdLibrID") %>" onclick="return confirm('确定要删除信息？')" 
                                    title="删除信息" style="color:Blue">删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="smtPager">
                <sw:PageNaver ID="PN1" runat="server" StyleID="2" PageSize="20">
                </sw:PageNaver>
            </div>
        </div>
        <div class="mft">
        </div>
        <button onclick="delLibrarys()" style="height: 28px;" type="button">
            批量删除</button>
    </div>
</asp:Content>

