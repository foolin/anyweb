<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SetMailBox.aspx.cs" Inherits="SetMailBox" Title="设置邮箱"   validateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
   
                <li>设置邮箱，填写一个您已开通的邮箱 邮箱密码 ，选择邮箱端口 </li>
                <li>邮件内容的用途：在确认一个用户订单发货后，系统将自动向用户发送您填写的邮件内容。</li>
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    设置邮箱</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                    <!--表单部分[[-->
                    <!--最后用label标签里的for属性和input里的id相对应-->
                            <table class="iEditForm iEditBaseInf">
                                <tr class="odd edit">
                                    <th style="width:120px;">
                                        商店邮箱：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="input" errmsg="请输入正确的商店邮箱" MaxLength="50" require="1" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        邮箱密码：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtEmailPass" runat="server" CssClass="input" TextMode="Password" ></asp:TextBox>&nbsp;不更改请留空。
                                        <asp:HiddenField ID="hidEmailPass" runat="server"  />
                                    </td>
                                </tr>
                                <tr class="odd edit">
                                    <th>
                                        邮箱发送端口：
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpSend" runat="server">
                                            <asp:ListItem value="1">smtp.163.com</asp:ListItem>
                                            <asp:ListItem value="2">smtp.126.com</asp:ListItem>
                                            <asp:ListItem value="3">smtp.sina.com.cn</asp:ListItem>
                                            <asp:ListItem value="4">smtp.mail.yahoo.com.cn</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtSend" runat="server" CssClass="input" MaxLength="50" ></asp:TextBox>
                                        <asp:CheckBox ID="chk1" runat="server" onclick="setMailShow(this.checked);" />其他端口
                                    </td>
                                </tr>
                                <tr class="edit odd">
                                    <th>
                                        邮件内容设置：
                                    </th>
                                    <td>
                                        <sw:TinyMce ID="txtEmailContent" runat="server" Height="500px" />
                                    </td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存资料" CssClass="submit" OnClick="btnSave_Click"></asp:Button>
                                <button id="btnBack" onclick="window.location='ArticleList.aspx';">取 消</button>
                            </div>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
<script type="text/javascript">
   
      if( document.getElementById("<%=txtSend.ClientID %>").value +""!="")
      {
        setMailShow(1);
        document.getElementById("<%=chk1.ClientID %>").checked=true;
       
      }
      else
      {
        setMailShow(0);
      }
    
    function setMailShow(chk1)
    {
        if(chk1)
        {  
            document.getElementById("<%=txtSend.ClientID %>").style.display="";
            document.getElementById("<%=drpSend.ClientID %>").style.display="none";
        }
        else     
        {
            document.getElementById("<%=txtSend.ClientID %>").style.display="none";
            document.getElementById("<%=drpSend.ClientID %>").style.display="";
        }
    }
</script>
</asp:Content>
