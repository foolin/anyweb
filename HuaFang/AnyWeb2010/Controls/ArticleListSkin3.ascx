<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleListSkin3.ascx.cs"
    Inherits="Controls_ArticleListSkin3" %>
<div class="PicBlack_Roll">
    <div class="PicB_win">
        <div class="PicBReel cs-clear">
            <asp:Repeater ID="rep1" runat="server">
                <ItemTemplate>
                    <a class="PicBlack_mod2" href="#">
                        <img src="<%#Eval("fdArtiPic") %>" class="nobor" />
                        <div class="PicBlack_tit PicBlack_tit2">
                            <h2>
                                <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiTitle" ), 30, false )%></h2>
                            <p>
                                <%#Studio.Web.WebAgent.GetLeft( ( string ) Eval( "fdArtiDesc" ), 65, false )%></p>
                        </div>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <ul class="PicBlack_tab cs-clear">
        <asp:Repeater ID="rep2" runat="server">
            <ItemTemplate>
                <li <%#Container.ItemIndex==0?"class=\"active\"":"" %> href="" rel="<%#Container.ItemIndex+1 %>">
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
