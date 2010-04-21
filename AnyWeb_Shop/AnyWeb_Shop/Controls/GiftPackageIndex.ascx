<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GiftPackageIndex.ascx.cs" Inherits="Controls_GiftPackageIndex" %>
<div class="box" style="margin-left: 2px;">
    <div class="title">
        <div class="txt">
            畅销大礼包</div>
        <div class="ico">
            <img src="Images/box1_title_rbg.gif" width="66" height="33" /></div>
    </div>
    <div class="content">
        <asp:Repeater ID="repList" runat="server">
            <ItemTemplate>
                <div class="indexTopic">
                    <div class="topicImage">
                        <a href="GiftPackage.aspx?pid=<%#Eval("PackID") %>">
                            <img src="<%#(string)Eval( "Image" )=="" ? "../images/wait.jpg":(string)Eval( "Image" ) %>"
                                alt="<%#Eval("PackName") %>" border="0" />
                        </a>
                    </div>
                    <div class="topicDesc">
                        <h4>
                            <a href="GiftPackage.aspx?pid=<%#Eval("PackID") %>">
                                <%#Studio.Web.WebAgent.GetLeft(Eval("PackName").ToString(),9)%></a></h4>
                        <%#Studio.Web.WebAgent.GetLeft(Studio.Web.WebAgent.stripHtml(Eval("Intro").ToString()),24)%>
                        <br />
                        <a href="GiftPackage.aspx?pid=<%#Eval("PackID") %>" class="more">详细信息</a>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>