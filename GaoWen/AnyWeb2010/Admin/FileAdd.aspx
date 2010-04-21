<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="FileAdd.aspx.cs" Inherits="Admin_FileAdd" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="pbd pEdit">
        <div class="part pt1 ptSidebar">
            <h2 class="PageTitle">
                上传文件</h2>
            <ul class="Help">
                <li>允许上传的文件类型包括:jpg gif bmp png zip rar doc xls ppt pdf </li>
            </ul>
        </div>
        <div class="part pt2">
        </div>
        <div class="part pt3">
            <div class="Mod Form MainForm" id="albumAdd">
                <div class="mhd">
                    <h3>
                        上传文件</h3>
                </div>
                <div class="mbd">
                    <div class="fi even">
                        <label>
                            当前文件</label>
                        <div class="cont">
                            <asp:Literal ID="litPath" runat="server">D:</asp:Literal>
                        </div>
                    </div>
                    <div class="fi">
                        <label>
                            上传文件</label>
                        <asp:FileUpload ID="file1" runat="server" Width="300px" />
                        <sw:Validator ID="Validator1" ControlID="file1" ValidateType="Required"
                            ErrorText="请上传文件" ErrorMessage="请上传文件" runat="server">
                        </sw:Validator>
                    </div>
                    <div class="fi even">
                        <label>
                            重复设置</label>
                        <div class="cont">
                            <asp:RadioButton ID="radio1" GroupName="GroupSet" runat="server" Checked="true" Text="自动重命名" CssClass="select" />
                            <asp:RadioButton ID="radio2" GroupName="GroupSet" runat="server" Text="覆盖" CssClass="select" />
                            <asp:RadioButton ID="radio3" GroupName="GroupSet" runat="server" Text="停止上传" CssClass="select" />
                        </div>
                    </div>
                    <div class="fi fiBtns">
                        <asp:Button ID="btnSave" CssClass="submit" runat="server" Text="保存文件 " OnClick="btnSave_Click">
                        </asp:Button>
                        <a href="filelist.aspx?path=<%=QS("path")%>">取 消</a>
                    </div>
                </div>
                <div class="mft">
                </div>
            </div>
        </div>
    </div>

</asp:Content>
