<%@ Page Title="高闻顾问" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register src="Control/menu.ascx" tagname="menu" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="topMain">
        <div class="colMain">
            <uc1:menu ID="menu1" runat="server" />
            <div class="focus">
                <a href="<%=adList[0].fdAdLink %>"><img src="<%=adList[0].fdAdPic %>" alt="焦点图片" border="0" /></a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="colSider">
            <div class="colBox">
                <div class="colTitle">
                </div>
                <div class="colContent">
                    <div class="text">
                        <a href="<%=adList[1].fdAdLink %>">
                            <img src="<%=adList[1].fdAdPic %>" alt="more" border="0" /></a><br />
                        <br />
                        <a href="<%=adList[2].fdAdLink %>">
                            <img src="<%=adList[2].fdAdPic %>" alt="more" border="0" /></a>
                    </div>
                </div>
                <div class="colButtomCorner">
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
