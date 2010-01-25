<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="FileList.aspx.cs" Inherits="Admin_FileList" %>

<%@ Register TagPrefix="cc1" Namespace="Studio.Web" Assembly="Studio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="FileFolderAdd.aspx?path=<%=QS("path")%>">新建文件夹</a></li>
        <li><a href="FileAdd.aspx?path=<%=QS("path")%>">上传文件</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                当前目录:&nbsp;&nbsp;<span style="font-size: 14px; font-weight: normal;"><asp:Label ID="txtPath"
                    runat="server"></asp:Label></span></h3>
        </div>
        <div class="mbd">
            <table>
                <thead>
                    <tr>
                        <th class="fst">
                            文件
                        </th>
                        <th>
                            大小
                        </th>
                        <th>
                            创建日期
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <tbody style="margin-left: 80px">
                    <tr align="center" type="folder" path="<%=GetUpperFolderPath()%>" style="display: <%=QS("path") == "/" || QS("path") == "" ? "none" : ""%>">
                        <td align="left" title="鼠标双击返回上一级目录">
                            <img alt="" src="/tiny_mce/plugins/advimage/img/icon_folder.gif" align="absbottom"
                                vspace="2" />……
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <asp:Repeater ID="repFolders" runat="server" EnableViewState="False">
                        <ItemTemplate>
                            <tr align="center" type="folder" path="<%#GetFolderRelativePath(Eval("FullName").ToString())%>">
                                <td align="left" title="鼠标双击进入目录">
                                    <img alt="" src="/tiny_mce/plugins/advimage/img/icon_folder.gif" align="absbottom"
                                        vspace="2" /><%# System.IO.Path.GetFileName(Eval("FullName").ToString())%>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <%#Eval("CreationTime","{0:yyyy-MM-dd}")%>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="repFiles" runat="server" EnableViewState="False">
                        <ItemTemplate>
                            <tr align="center" type="files" path="<%#GetFileRelativePath(Eval("FullName").ToString())%>"
                                style="display: <%#System.IO.Path.GetExtension(Eval("FullName").ToString()) == ".db" ? "none" : ""%>">
                                <td align="left" title="鼠标双击浏览文件">
                                    <%# System.IO.Path.GetFileName(Eval("FullName").ToString())%>
                                </td>
                                <td style="text-align: right; padding-right: 10px;">
                                    <%#GetFileLength((long)Eval("Length"))%>
                                </td>
                                <td>
                                    <%#Eval("CreationTime","{0:yyyy-MM-dd}")%>
                                </td>
                                <td>
                                    <a href="FileEdit.aspx?path=<%=QS("path")%>&link=<%#System.IO.Path.GetFileName(Eval("FullName").ToString())%>">
                                        修改</a> <a style="display: none;" href="FileDel.aspx?path=<%=QS("path")%>&link=<%#System.IO.Path.GetFileName(Eval("FullName").ToString())%>"
                                            onclick="return confirm('您确定删除吗?')">删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <div class="smtPager">
                <cc1:PageNaver ID="PN1" runat="server" StyleID="2" PageSize="30">
                </cc1:PageNaver>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>双击进入子目录</li>
            <li>允许上传的文件有gif png jpg doc ppt </li>
            <li>请不要修改DLL、config后缀的文件</li>
        </ul>
    </div>

    <script type="text/javascript">
        $(document).ready(function(){
            
            $("div.DataList table tbody tr").each(function(){
                $(this).find("td:eq(0)").css("cursor","pointer");
                if($(this).attr("type") == "folder")
                {
                    $(this).dblclick(function(){
                        window.location = "?path=" + $(this).attr("path");
                    });
                }
                else
                {
                    $(this).dblclick(function(){
                        window.open($(this).attr("path"));
                    });
                }
            });
            
        });
    </script>

</asp:Content>
