<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Notice.ascx.cs" Inherits="Controls_Notice" %>
<div class="notice">
    <div class="tit">
        <h2>
            通知公告</h2>
        <span class="more"><a href="NoticeList.aspx">更多>></a></span>
    </div>
    <div class="con">
        <div class="list">
            <marquee direction="up" onmouseover="this.stop()" onmouseout="this.start()" scrollamount="4">
            <asp:Repeater ID="repNotice" runat="server">
                <ItemTemplate>
                    <dl>
                        <dt><a href="article.aspx?id=<%#Eval("NotiArtiID") %>" title="<%#Eval("Title") %>">
                            <%#Studio.Web.WebAgent.GetLeft(Eval("Title").ToString(),20) %></a></dt>
                        <dd>
                            [<%#Eval("NotiCreateAt","{0:yyyy-MM-dd HH:mm}")%>]</dd>
                    </dl>
                </ItemTemplate>
            </asp:Repeater>
            </marquee>
        </div>
    </div>
</div>
