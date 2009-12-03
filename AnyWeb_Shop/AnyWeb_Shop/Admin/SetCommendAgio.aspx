<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SetCommendAgio.aspx.cs"
    Inherits="SetCommendAgio" Title="设置推荐折扣" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
<li></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    设置推荐商品折扣
                </h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1"  runat="server">
                    <table class="iEditForm iEditBaseInf">
                        <tr class="name">
                            <th style="width: 120px;">
                                选择折扣方式：</th>
                            <td>
                                <asp:RadioButton ID="rdnull" Text="无折扣" GroupName="commend" value="0" Checked="true"
                                    runat="server" />
                                <asp:RadioButton ID="rd1" Text="全部折扣" GroupName="commend" value="1" runat="server" />
                                <asp:RadioButton ID="rd2" Text="购买折扣" GroupName="commend" value="2" runat="server" />
                            </td>
                        </tr>
                        <tr class="edit odd" id="t1" style="display:none">
                            <th>
                                购买满足金额：
                            </th>
                            <td>
                                <asp:TextBox ID="txtMoney" datatype="zdouble" errmsg="金额必须是数字,请输入正确的金额" MaxLength="8" runat="server"></asp:TextBox>
                                元/RMB
                            </td>
                        </tr>
                        <tr class="edit odd" id="t2" style="display:none">
                            <th>
                                享受折扣：
                            </th>
                            <td>
                                <asp:TextBox ID="txtAgio" datatype="zdouble" errmsg="折扣必须是10以内数字,请输入正确的折扣" MaxLength="3" runat="server"></asp:TextBox>
                                折
                            </td>
                        </tr>
                    </table>
                    <div class="iSubmit">
                        <asp:Button ID="btnSave" runat="server" Text="保存设置" CssClass="submit" OnClick="btnSave_Click">
                        </asp:Button>
                      
                    </div>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <script type="text/javascript"  >
    
    GetAgioMode(<%=Atype %>);
    
        function GetAgioMode(rd)
        {
            var t1 = document.getElementById("t1");
            var t2 = document.getElementById("t2");
            
            if(rd == 0)
            {
                t1.style.display = "none";
                t2.style.display = "none";
            }
            if(rd == 1)
            {
                t1.style.display = "none";
                t2.style.display = "block";
            }
            
            if(rd == 2)
            {
                t1.style.display = "block";
                t2.style.display = "block";
            }
        } 
    
    </script>
</asp:Content>
