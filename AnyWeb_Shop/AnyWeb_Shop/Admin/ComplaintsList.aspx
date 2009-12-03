<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ComplaintsList.aspx.cs" Inherits="ComplaintsList" Title="投诉管理" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
  
 <li>投诉列表，点击回复投诉链接到回复页面。</li>
             
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
<div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    投诉管理
                </h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                    <caption> <input id="Checkbox1" type="checkbox" onclick="chooseAll();" />全选</caption>
                        <asp:Repeater ID="rep1" runat="server" DataSourceID="ods3">
                            <ItemTemplate>
                                <tbody>
                                <tr>
                                    <td >
                                        <div class="comment_container" >
                                            <h3><input type="checkbox"  name="ck1" value='<%#Eval("ID") %>'>
                                            投诉人：<a href='User/UserInfo.aspx?userid=<%#Eval("UserID")%>'><%# Eval( "OfUser.MemberName" )%></a>
                                            投诉时间：<%# Eval( "CreateAt" , "{0:yyyy-MM-dd HH:mm}" )%>
                                            <span style='float: right; margin-top: -16px; padding-right: 20px; display:<%#(int)Eval("Status")==0 ? "":"none" %>'>
                                              <a href='ComplaintsEdit.aspx?cid=<%# Eval("ID") %>&mid=<%#Eval("UserID") %>' >
                                                    <img src="images/mbi_004.gif" alt="回复投诉" border="0" /> 回复投诉</a></span>
                                            <span style=" background:url(./images/right.gif) 0px -2px no-repeat;float: right; margin-top: -16px; padding:0px 20px;display:<%#(int)Eval("Status")==1 ? "":"none" %>">  &nbsp;已回复 <a href='UserAfficheEdit.aspx?affid=<%#Eval("AfficheID") %>'>查看回复信息</a></span>
                                            </h3>
                                            <div class="comment_content">
                                                <%# Eval("Content")%> 
                                             </div>
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
                    </div>
                    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetComplaintsList" TypeName="Common.Agent.ComplaintsAgent" OnSelected="ods3_Selected" >
                        <SelectParameters>
                            <asp:ControlParameter ControlID="PN1" Type="Int32" Name="pageSize" PropertyName="pagesize" />
                            <asp:ControlParameter ControlID="PN1" Type="Int32" Name="pageNo" PropertyName="pageindex" />
                            <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
                        </SelectParameters>
                        
                    </asp:ObjectDataSource>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <script type="text/javascript">
        var choosed=false;
	    function chooseAll()
	    {
		    choosed=!choosed;
		    var chks = document.getElementsByName("ck1");
		    for(i=0;i<chks.length;i++)
		    {
			    chks[i].checked=choosed;
		    }
	    }
    </script>
</asp:Content>

