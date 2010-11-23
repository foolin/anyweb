<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Error.aspx.cs" Inherits="AnyWell_Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="subBanner">
        <a href="/index.aspx">
            <img src="images/subbanner.jpg" width="953" height="90" /></a>
    </div>
    <div class="blank8px">
    </div>
    <div class="unFind">
        <b class="f14 green">抱歉，无法找到该页!</b><br />
        <b class="gray">您正在搜索的页面可能已经删除、更名或暂时不可用。</b><br />
        <b class="eng">Sorry，the page you seek can not be found!</b><div class="blank15px">
        </div>
        <a href="/Index.aspx" class="btn96_35">首 页</a>&nbsp;&nbsp;&nbsp;<a href="javascript:history.back();" class="btn96_35">后
            退</a>
    </div>
</asp:Content>
