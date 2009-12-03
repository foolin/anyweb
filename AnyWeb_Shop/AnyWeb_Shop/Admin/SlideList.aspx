<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SlideList.aspx.cs" Inherits="SlideList" Title="flash动画管理" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
<li>自定义Flash，可以上传5张图片（保持长宽一致），用途可以是做产品推广、广告等，在商城首页中幻灯展示。</li>
<li>建议图片的长宽大小为：642px 206px;</li>         
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
<div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    Flash动画管理<span style="float:right; margin-top:-16px; line-height:28px; padding-right:26px;"><a href="SlideEidt.aspx">编辑flash</a></span></h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <thead>
                            <tr>
                               <th >
                                   幻灯图片</th>
                                <th>
                                    链接地址</th>
                                <th>
                                   排序</th>
        
                       <th class="end">
                                    操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repCurrency" runat="server" DataSourceID="ods3">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <img src='<%=ShopInfo.DataPath%>/Slide<%# Eval("SlideFile") %>' width="90px" />
                                        </td>
                                        <td>
                                            <%# (string)Eval( "SlideLink" ) == "" ? "无链接" : Eval( "SlideLink" )%>
                                        </td>
                                        <td>
                                            <%# Eval("Sort") %>
                                        </td>
                                        <td>
                                          <a href='SlideEidt.aspx?sid=<%# Eval("ID")%>' >修改</a> <a href='SlideList.aspx?sid=<%# Eval("ID")%>&mode=delete' onclick="javascript:return confirm('确定删除？');" >删除</a>      
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </form>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetSlideList" TypeName="Common.Agent.SlideAgent"></asp:ObjectDataSource>
</asp:Content>

