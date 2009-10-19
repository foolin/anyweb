<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Notice.ascx.cs" Inherits="Controls_Notice" %>
<div class="box-title">
    <span class="titletxt">--== 通知公告 ==--</span><span class="more"><a href="NoticeList.aspx">更多>></a></span></div>
<div class="box-content">
    <marquee direction="up" onmouseover="this.stop()" onmouseout="this.start()" scrollamount="4">
        <ul>
            <asp:Repeater ID="repNotice" runat="server">
                <ItemTemplate>
                    <li><a href="article.aspx?id=<%#Eval("NotiArtiID") %>" title="<%#Eval("Title") %>"><%#Studio.Web.WebAgent.GetLeft(Eval("Title").ToString(),20) %></a><span class="time">[<%#Eval("NotiCreateAt","{0:yyyy-MM-dd HH:mm}")%>]</span></li>
                </ItemTemplate>
            </asp:Repeater>    
        </ul>
    </marquee>
</div>
