<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="Setting_Payment.aspx.cs" Inherits="Admin_Setting_Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <style>
        .content
        {
            border: 1px solid #ccc;
            margin: 3px 5px;
        }
    </style>
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                ֧����ʽ����</h3>
        </div>
        <div class="mbd">
            <div id="payWay1" class="content">
                <span>
                    <input id="cbWay1" type="checkbox" onclick="show(this, 1);" runat="server" />ʹ��֧����</span>
                <div id="content1" style="display: none;">
                    <div class="fi even">
                        <label>
                            ֧�����ʺţ�</label>
                        <asp:TextBox ID="txtWay1_acc" runat="server" CssClass="text"></asp:TextBox>
                    </div>
                    <div class="fi">
                        <label>
                            ���������(partnerID)��</label>
                        <asp:TextBox ID="txtWay1_partnerID" runat="server" CssClass="text"></asp:TextBox>
                    </div>
                    <div class="fi even">
                        <label>
                            ��ȫУ����(key)��</label>
                        <asp:TextBox ID="txtWay1_key" runat="server" CssClass="text"></asp:TextBox>
                    </div>
                    <div class="fi">
                        <label>
                            �ӿ����ͣ�</label>
                        <asp:DropDownList ID="drpWay1_service" runat="server">
                            <asp:ListItem Value="trade_create_by_buyer">��׼˫�ӿ�</asp:ListItem>
                            <asp:ListItem Value="create_partner_trade_by_buyer">�������׽ӿ�</asp:ListItem>
                            <asp:ListItem Value="create_direct_pay_by_user">��ʱ���ʽ��׽ӿ�</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div id="payWay2" class="content">
                <span>
                    <input id="cbWay2" type="checkbox" onclick="show(this, 2);" runat="server" />ʹ����������</span>
                <div id="content2" style="display: none;">
                    <div class="fi even">
                        <label>
                            �̻���ţ�</label>
                        <asp:TextBox ID="txtWay2_id" runat="server" CssClass="text"></asp:TextBox>
                    </div>
                    <div class="fi">
                        <label>
                            MD5��Կ��</label>
                        <asp:TextBox ID="txtWay2_key" runat="server" CssClass="text"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div id="payWay3" class="content">
                <span>
                    <input id="cbWay3" type="checkbox" onclick="show(this, 3);" runat="server" />ʹ������ת��/���</span>
                <div id="content3" style="display: none;">
                    <div class="fi even">
                        <label>
                            ������Ϣ��</label>
                        <div class="cont editor">
                            <asp:TextBox ID="txtWay3_des" runat="server" TextMode="MultiLine" CssClass="text"
                                Width="100%" Height="280px"></asp:TextBox></div>
                    </div>
                </div>
            </div>
            <div id="payWay4" class="content">
                <span>
                    <input id="cbWay4" type="checkbox" onclick="show(this, 4);" runat="server" />ʹ�û�������</span>
                <div id="content4" style="display: none;">
                    <div class="fi even">
                        <label>
                            ������Ϣ��</label>
                        <div class="cont editor">
                            <asp:TextBox ID="txtWay4_des" runat="server" TextMode="MultiLine" CssClass="text"
                                Width="100%" Height="280px"></asp:TextBox></div>
                    </div>
                </div>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="��������" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li></li>
        </ul>
    </div>

    <script type="text/javascript" src="../tiny_mce/tiny_mce.js"></script>

    <script>
        //��ʼ����ʾ����
        if ($("#<%=this.cbWay1.ClientID %>").attr("checked")) {
            $("#content1").show();
        }
        if ($("#<%=this.cbWay2.ClientID %>").attr("checked")) {
            $("#content2").show();
        }
        if ($("#<%=this.cbWay3.ClientID %>").attr("checked")) {
            $("#content3").show();
        }
        if ($("#<%=this.cbWay4.ClientID %>").attr("checked")) {
            $("#content4").show();
        }
        
        /**
         * ��ʾ/��������
         */
        function show(o, v) {
            if ($(o).attr("checked")) {
                $("#content" + v).slideDown("fast");
            } else {
                $("#content" + v).slideUp("fast");
            }
        }

        //�༭������
        tinyMCE.init({
            mode: "exact",
            elements: "<%=txtWay3_des.ClientID%>",
            theme: "advanced",
            language: "zh",
            plugins: "safari,pagebreak,style,layer,table,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,profile,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,pageseparator,iboximage",
            content_css: "/tiny_mce/css/content.css",
            template_external_list_url: "/tiny_mce/lists/template_list.js",
            external_link_list_url: "/tiny_mce/lists/link_list.js",
            external_image_list_url: "/tiny_mce/lists/image_list.js",
            media_external_list_url: "/tiny_mce/lists/media_list.js",
            template_replace_values: {
                username: "Some User",
                staffid: "991234"
            }
        });
        tinyMCE.init({
            mode: "exact",
            elements: "<%=txtWay4_des.ClientID%>",
            theme: "advanced",
            language: "zh",
            plugins: "safari,pagebreak,style,layer,table,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,profile,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,pageseparator,iboximage",
            content_css: "/tiny_mce/css/content.css",
            template_external_list_url: "/tiny_mce/lists/template_list.js",
            external_link_list_url: "/tiny_mce/lists/link_list.js",
            external_image_list_url: "/tiny_mce/lists/image_list.js",
            media_external_list_url: "/tiny_mce/lists/media_list.js",
            template_replace_values: {
                username: "Some User",
                staffid: "991234"
            }
        });
    </script>

</asp:Content>
