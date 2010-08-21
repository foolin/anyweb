<%@ Page Title="" Language="C#" MasterPageFile="~/Inner.master" AutoEventWireup="true"
    CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="ConBox detailTopBg column">
        <div class="DetTop">
            <h1>
                联系方式
            </h1>
            <p class="subMark">
                [ 字体：<a href="javascript:void(0);" onclick="changeFontSize(this,'f14');">大</a> <a
                    href="javascript:void(0);" onclick="changeFontSize(this,'f13');">中</a> <a href="javascript:void(0);"
                        onclick="changeFontSize(this,'f12');" class="cur">小</a> ] [ <a href="javascript:window.print();">
                            打印</a> ] [ <a href="javascript:window.close();">关闭</a> ]
            </p>
        </div>
        <div class="DetCon" id="ConDetail">
            <p>
                主任室：020-87563088</p>
            <p>
                副主任室：020-87599811</p>
            <p>
                财务科：020-87597663</p>
            <p>
                物业科：020-87599910</p>
            <p>
                人事科：020-87590122</p>
            <p>
                杰信人力资源公司：020-87590122</p>
            <p>
                龙口东市场办公室：020-85266182</p>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function() { selMenu("LXWM"); });
    </script>
</asp:Content>
