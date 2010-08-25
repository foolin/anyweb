<%@ Page Title="" Language="C#" MasterPageFile="~/Inner.master" AutoEventWireup="true"
    CodeFile="HR.aspx.cs" Inherits="HR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="ConBox detailTopBg column">
        <div class="DetTop">
            <h1>
                广州市杰信人力资源有限公司经营及管理
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
                我社在经营传统业务的同时紧跟市场发展潮流，抓紧机遇，进行二次创业。杰信公司便是我社二次创业的产物，我社在原有的资源基础上进行整合及有效利用，创办杰信公司开拓人力资源领域方向的相关业务。杰信公司的业务包括：人事代理、人才招聘、企业咨询、培训、劳务派遣、代理劳动关系手续办理（劳动年审、社会保险办理等）等相关业务。</p>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function() { selMenu("JXRLZY"); });
    </script>
</asp:Content>
