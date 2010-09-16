<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="FileFolderAdd.aspx.cs" Inherits="Admin_FileFolderAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="addColumn">
        <div class="mhd">
            <h3>
                新建文件夹</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    当前位置</label>
                <div class="cont">
                    <asp:Literal ID="litPath" runat="server">D:</asp:Literal>
                </div>
            </div>
            <div class="fi even" id="names">
                <label>
                    文件夹名称</label>
                <div class="cont">
                    <asp:TextBox CssClass="text" ID="txtName" runat="server" Width="242px" MaxLength="50"
                        ToolTip="最多50个汉字"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="fi fiBtns">
            <asp:Button ID="btnSave" CssClass="submit" runat="server" Text="保存文件夹" OnClick="btnSave_Click">
            </asp:Button>
            <a href="filelist.aspx?path=<%=QS("path")%>">取 消</a>
        </div>
    </div>
    <div class="mft">
    </div>
    <div>
        <ul class="Help">
            <li>文件夹名称不能包含有特殊字符</li>
        </ul>
    </div>

    <script type="text/javascript">
        $("#names input").change(function(){
            var name = $(this).val();
            var valid = '\/:*?"<>|';
            for( var i=0;i<valid.length;i++)
            {
                if(name.indexOf(valid.substr(i,1)))
                    name = name.replace(valid.substr(i,1),"");
            }
            
            if($(this).val() != name)
                $(this).val(name);
        });
    </script>

</asp:Content>
