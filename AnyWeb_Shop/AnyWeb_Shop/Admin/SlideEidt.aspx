<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SlideEidt.aspx.cs" Inherits="SlideEidt" Title=" 编辑Falsh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
   
                  <li>编辑Flash，可以一次性编辑所有幻灯图片。</li>
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                   编辑Flash
                </h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                   
                    <table class="iEditForm iEditBaseInf">
                        <tr class="name odd" >
                            <th>
                                幻灯图片1：</th>
                            <td>
                                <asp:FileUpload ID="fud1" runat="server" CssClass="input" /><asp:HiddenField ID="hf1" runat="server" />
                            </td>
                            <td>
                                链接地址：<asp:TextBox ID="txt1" runat="server" CssClass="input"></asp:TextBox></td>
                                <td>排序：<asp:TextBox ID="txts1" runat="server" CssClass="input" Width="60px" Text="1"  MaxLength="2"></asp:TextBox></td>
                            <td>
                                <asp:Image ID="img1" runat="server" Width="100" Height="50" CssClass="image" /></td>
                        </tr>
                        <tr class="photo">
                            <th>
                                幻灯图片2：</th>
                            <td>
                                <asp:FileUpload ID="fud2" runat="server" CssClass="input" /><asp:HiddenField ID="hf2" runat="server" />
                            </td>
                            <td>
                                链接地址：<asp:TextBox ID="txt2" runat="server" CssClass="input"></asp:TextBox></td>
                                 <td>排序：<asp:TextBox ID="txts2" runat="server" CssClass="input" Width="60px"  Text="2" MaxLength="2"></asp:TextBox></td>
                            <td>
                                <asp:Image ID="img2" runat="server" Width="100" Height="50" CssClass="image" /></td>
                        </tr>
                        <tr class="name odd">
                            <th>
                                幻灯图片3：</th>
                            <td>
                                <asp:FileUpload ID="fud3" runat="server" CssClass="input" /><asp:HiddenField ID="hf3" runat="server" />
                            </td>
                            <td>
                                链接地址：<asp:TextBox ID="txt3" runat="server" CssClass="input"></asp:TextBox></td>
                                  <td>排序：<asp:TextBox ID="txts3" runat="server" CssClass="input" Width="60px"  Text="3"  MaxLength="2"></asp:TextBox></td>
                            <td>
                                <asp:Image ID="img3" runat="server" Width="100" Height="50" CssClass="image" /></td>
                        </tr>
                        <tr class="photo">
                            <th>
                                幻灯图片4：</th>
                            <td>
                                <asp:FileUpload ID="fud4" runat="server" CssClass="input" /><asp:HiddenField ID="hf4" runat="server" />
                            </td>
                            <td>
                                链接地址：<asp:TextBox ID="txt4" runat="server" CssClass="input"></asp:TextBox></td>
                                  <td>排序：<asp:TextBox ID="txts4" runat="server" CssClass="input" Width="60px"  Text="4"  MaxLength="2"></asp:TextBox></td>
                            <td>
                                <asp:Image ID="img4" runat="server" Width="100" Height="50" CssClass="image" /></td>
                        </tr>
                        <tr class="name odd">
                            <th>
                                幻灯图片5：</th>
                            <td>
                                <asp:FileUpload ID="fud5" runat="server" CssClass="input" /><asp:HiddenField ID="hf5" runat="server" />
                            </td>
                            <td>
                                链接地址：<asp:TextBox ID="txt5" runat="server" CssClass="input"></asp:TextBox></td>
                                  <td>排序：<asp:TextBox ID="txts5" runat="server" CssClass="input" Width="60px"  Text="5"  MaxLength="2"></asp:TextBox></td>
                            <td>
                                <asp:Image ID="img5" runat="server" Width="100" Height="50" CssClass="image" /></td>
                        </tr>
                    </table>
                    <div class="iSubmit">
                        <asp:Button ID="btnSave" runat="server" Text="保存幻灯"  CssClass="submit" OnClick="btnSave_Click"></asp:Button>
                        <button id="btnBack" onclick="window.location='SlideList.aspx';" type="button">取 消</button>
                    </div></form>
                 
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
