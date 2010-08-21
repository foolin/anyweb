<%@ Page Title="" Language="C#" MasterPageFile="~/Inner.master" AutoEventWireup="true"
    CodeFile="Article.aspx.cs" Inherits="Article" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="ConBox detailTopBg column">
        <div class="DetTop">
            <h1>
                <asp:Literal ID="litTitle" runat="server"></asp:Literal>
            </h1>
            <p class="subMark">
                [ 字体：<a href="javascript:void(0);" onclick="changeFontSize(this,'f14');">大</a> <a
                    href="javascript:void(0);" onclick="changeFontSize(this,'f13');">中</a> <a href="javascript:void(0);"
                        onclick="changeFontSize(this,'f12');" class="cur">小</a> ] [ <a href="javascript:window.print();">
                            打印</a> ] [ <a href="javascript:window.close();">关闭</a> ]
            </p>
        </div>
        <div class="DetCon" id="ConDetail">
            <asp:Literal ID="litContent" runat="server"></asp:Literal>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function() { selMenu("<%=strColumn %>"); });
    </script>
</asp:Content>
