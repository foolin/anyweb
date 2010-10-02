<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="AdminEdit.aspx.cs" Inherits="Admin_AdminEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改用户</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    登录帐号：</label>
                <asp:TextBox ID="txtAcc" MaxLength="50" runat="server" CssClass="text" ReadOnly="true"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator5" ControlID="txtAcc" ValidateType="Required" ErrorText="请输入登录帐号"
                    ErrorMessage="请输入登录帐号" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    用户名称：</label>
                <asp:TextBox ID="txtName" MaxLength="50" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator3" ControlID="txtName" ValidateType="Required" ErrorText="请输入用户名称"
                    ErrorMessage="请输入用户名称" runat="server">
                </sw:Validator>
            </div>
            <div class="fi">
                <label>
                    登录密码：</label>
                <asp:TextBox ID="txtPwd" MaxLength="50" runat="server" CssClass="text" TextMode="Password"></asp:TextBox>
            </div>
            <div class="fi even">
                <label>
                    用户级别：</label>
                <div class="cont">
                    <asp:RadioButton ID="radio1" runat="server" GroupName="level" Text="超管" CssClass="checkbox" />
                    <asp:RadioButton ID="radio2" runat="server" GroupName="level" Text="普通" Checked="true"
                        CssClass="checkbox" />
                </div>
            </div>
            <div class="fi" id="purviewArea" runat="server">
                <label>
                    用户权限：</label>
                <div class="cont">
                    <asp:Repeater ID="repPurviews" runat="server" OnItemDataBound="repPurviews_OnItemDataBound">
                        <ItemTemplate>
                            <div style="margin-bottom: 15px;">
                                <label class="checkbox">
                                    <input id="boxs" runat="server" type="checkbox" name="purviews" /><strong><%#Eval("Name")%></strong></label>
                                <div style="">
                                    <asp:Repeater ID="repChildren" runat="server" DataSource='<%#Eval("Children")%>'
                                        OnItemDataBound="repChildren_OnItemDataBound">
                                        <ItemTemplate>
                                            <label class="checkbox">
                                                <input id="boxs" runat="server" type="checkbox" name="purviews" /><%#Eval("Name")%></label>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <input type="hidden" name="purviews" id="purviews" value="<%=bean.fdAdmiPurview%>" />
                </div>
            </div>

            <script type="text/javascript">
                        function checkChildren(box)
                        {
                             $(box).parent("label").parent("div").find("div input").each(function() { 
                                 $(this).attr("checked", $(box).attr("checked")); 
                                 modifyPurviews($(this).val(),$(box).attr("checked"));
                             });
                        }
                        $(document).ready(function(){
                            $("#<%=purviewArea.ClientID%> input:checkbox").click(function(){
                                modifyPurviews($(this).val(), $(this).attr("checked"));
                            });
                        });
                        function modifyPurviews(moduleId, add)
                        {
                            if(add)
                            {
                                if($("#purviews").val() == "")
                                    $("#purviews").val(moduleId);
                                else
                                    $("#purviews").val($("#purviews").val()+","+moduleId);
                            }
                            else
                            {
                                var val = $("#purviews").val();
                                if(val == moduleId)
                                    $("#purviews").val("");
                                else if(val.indexOf(moduleId) == 0)
                                    $("#purviews").val(val.substr(0,moduleId.length));
                                else if( val.indexOf(moduleId) == val.length - moduleId.length)
                                    $("#purviews").val(val.substr(0,val.length - moduleId.length - 1));
                                else
                                    $("#purviews").val(val.replace(","+moduleId+",",","));
                            }
                        }
            </script>

            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存用户" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
                <a href="adminlist.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>如不需要修改密码,密码输入框请留空</li>
        </ul>
    </div>
</asp:Content>
