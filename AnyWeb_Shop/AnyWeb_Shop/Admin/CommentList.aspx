<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="CommentList.aspx.cs" Inherits="CommentList1" Title="评论管理" %>

<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">

                    <li>此评论来自于用户对于产品、文章的看法的管理。你可以点击“回复评论”对其回复。</li>
                    <li>可对评论批量删除。在评论前小框打勾，点击“批量删除”按钮即可。</li>
              
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    评论管理
                </h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <caption>
                              <input id="chkchoose" type="checkbox" onclick="chooseAll();" />全选  用户名：<asp:TextBox ID="txtName" runat="server" CssClass="text" MaxLength="50"></asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click"  CssClass="button1"/>
                        </caption>
                        <asp:Repeater ID="rep1" runat="server" DataSourceID="ods3">
                            <ItemTemplate>
                                <tbody>
                                <tr>
                                    <td >
                                      
                                        <div class="comment_container" >
                                            <h3><input type="checkbox" name="ids" value='<%#Eval("ID") %>'>
                                            发表人：<%# Eval ("UserName")%>
                                            发表时间：<%# Eval( "CommentAt" , "{0:yyyy-MM-dd HH:mm}" )%>
                                            IP：<%# Eval("IP")%>&nbsp;来源：<%# Eval("Area")%>
                                            <span style="float: right; margin-top: -16px; padding-right: 20px; ">
                                              <a href='CommentReplay.aspx?cid=<%# Eval("ID") %>' style=" color:black; font-weight:bold;">
                                                    <img src="images/mbi_004.gif" alt="回复评论" border="0" />回复评论</a></span></h3>
                                        <div class="comment_content">
                                            <%# Eval("Content")%>
                                            <span style="display: block; margin: 5px 0px;"><a href='<%# Eval("UrlRef") %>' target="_blank">
                                                来源网址：<%# Eval("UrlRef") %>
                                            </a></span>
                                            <%#Eval("Replay").ToString() == "" ? "" :
																"<div class=message_reply style=margin:10px 0px 10px 0px;>" + "<strong>店长回复</strong>："+Eval("Replay").ToString().Replace("\r\n","") + "(" + Eval("ReplayAt").ToString() + ")</div>"
                                            %></div></div>
                                        </div>
                                    
                                    </td>
                                </tr>
                                </tbody>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div class="iPagination">
                        <cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="12">
                        </cc1:PageNaver>
                    </div>
                    <div class="iSubmit">
                         <input id="chkChooseAll" type="checkbox" onclick="chooseAll();" />全选  <asp:Button ID="btnDel" runat="server" CssClass="submit" Text="批量删除" OnClick="btnDel_Click" />
                         <button id="btnBack" onclick="history.back(-1);">返 回</button>
                    </div>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetCommentList" TypeName="Common.Agent.CommentAgent" OnSelecting="ods3_Selecting" OnSelected="ods3_Selected">
        <SelectParameters>
            <asp:ControlParameter ControlID="PN1" Type="Int32" Name="pageSize" PropertyName="pagesize" />
            <asp:ControlParameter ControlID="PN1" Type="Int32" Name="pageNo" PropertyName="pageindex" />
            <asp:QueryStringParameter DefaultValue="0" Name="typeId" QueryStringField="tid" Type="Int32" />
            <asp:QueryStringParameter Name="sourceId" Type="Int32" DefaultValue="0" QueryStringField="sid" />
            <asp:Parameter Name="userName" Type="String" DefaultValue="ta" />
            <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
     <script type="text/javascript">
        var choosed=false;
	    function chooseAll()
	    {
		    choosed=!choosed;
		    var chks = document.getElementsByName("ids");
		    for(i=0;i<chks.length;i++)
		    {
			    chks[i].checked=choosed;
		    }
	    }
    </script>
</asp:Content>
