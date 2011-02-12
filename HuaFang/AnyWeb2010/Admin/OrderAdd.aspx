<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="OrderAdd.aspx.cs" Inherits="Admin_OrderAdd" Title="��Ӷ���" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <style>
        .goods
        {
            width: 240px;
            margin: 0px;
            border: 1px solid #ddd;
        }
        .goods th
        {
            font-weight: 100;
            color: #ce0000;
            background: url(../images/FavoritesTTBG.gif) repeat-x 0 0;
            height: 25px;
            border: 1px solid #ddd;
        }
        .goods td
        {
            height: 25px;
            border: 1px solid #ddd;
            text-align: center;
        }
        .goods input
        {
            text-align: center;
            width: 50px;
            border: 1px solid #ccc;
            height: 15px;
            padding: 1px;
            margin: 0;
        }
        .msg
        {
            color: #ff0000;
        }
    </style>
    <div class="pbd pEdit">
        <div class="Mod Form MainForm" id="InfoEdit">
            <div class="mhd">
                <h3>
                    ��Ӷ�����Ϣ</h3>
            </div>
            <div class="mbd">
                <div class="fi">
                    <label>
                        ��Ա��ţ�</label>
                    <asp:TextBox ID="txtMemberID" MaxLength="50" Width="50px" runat="server" CssClass="text" />
                    <input id="btnReadMember" type="button" value="��ȡ��Ա��Ϣ" />&nbsp;<span id="msg_memberID"
                        class="msg"></span>
                </div>
                <div class="fi even">
                    <label>
                        ������Ʒ��</label>
                    <div class="cont">
                        <input id="goodsCount" name="goodsCount" type="hidden" value="1" />
                        <input id="totalPrice" name="totalPrice" type="hidden" value="0" />
                        <table class="goods">
                            <thead>
                                <tr>
                                    <th>
                                        ��ƷID
                                    </th>
                                    <th>
                                        ��Ʒ����
                                    </th>
                                    <th>
                                        ��������
                                    </th>
                                    <th width="20">
                                        <a href="javascript:;" onclick="addGoods();" title="���">+</a>
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="tbGoods">
                                <tr id="trGoods1">
                                    <td>
                                        <input id="txtGoodsID1" name="txtGoodsID1" onblur="getPrice(1);" onkeyup="mustNum(this);" />
                                    </td>
                                    <td>
                                        <input id="txtPrice1" name="txtPrice1" visible="false" readonly />
                                    </td>
                                    <td>
                                        <input id="txtQuantity1" name="txtQuantity1" value="1" onkeyup="mustNum(this);" />
                                    </td>
                                    <td>
                                        <%--<a href="javascript:;" onclick="delGoods('trGoods1');" title="ɾ��">��</a>--%>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="fi">
                    <label>
                        ֧����ʽ��</label>
                    <div class="cont">
                        <input name="rdPayMode" type="radio" value="4" checked="checked" />��������
                        <input name="rdPayMode" type="radio" value="5" />����
                        <input name="rdPayMode" type="radio" value="1" />֧����
                        <input name="rdPayMode" type="radio" value="2" />��������
                        <input name="rdPayMode" type="radio" value="3" />����ת��/���
                    </div>
                </div>
                <div class="fi even">
                    <label>
                        ���ͷ�ʽ��</label>
                    <div class="cont">
                        <%--<input name="rdDeliverMode" type="radio" value="1" />ƽ��
                            <input name="rdDeliverMode" type="radio" value="2" />���
                            <input name="rdDeliverMode" type="radio" value="3" />EMS--%>
                        <input name="rdDeliverMode" type="radio" value="4" checked="checked" />����
                        <input name="rdDeliverMode" type="radio" value="5" />����
                    </div>
                </div>
                <div class="fi">
                    <label>
                        �ʷѣ�</label>
                    <div class="cont">
                        <input id="txtDeliverPrice" name="txtDeliverPrice" type="text" class="text" style="width: 50px;" />&nbsp;Ԫ
                    </div>
                </div>
                <div class="fi even">
                    <label>
                        �ջ���ַ��</label>
                    <div class="cont">
                        <select id="drpProvince" name="drpProvince">
                        </select>ʡ<select id="drpCity" name="drpCity"></select>��<select id="drpArea" name="drpArea"></select>��
                        <br />
                        <asp:TextBox ID="txtAddr" MaxLength="50" runat="server" CssClass="text" />&nbsp;<span
                            id="msg_addr" class="msg"></span>
                    </div>
                </div>
                <div class="fi">
                    <label>
                        �ջ��ˣ�</label>
                    <div class="cont">
                        <asp:TextBox ID="txtUserName" MaxLength="30" runat="server" CssClass="text" Width="100px" />&nbsp;<span
                            id="msg_userName" class="msg"></span>
                    </div>
                </div>
                <div class="fi even">
                    <label>
                        �������룺</label>
                    <asp:TextBox ID="txtPostcode" MaxLength="10" runat="server" CssClass="text" Width="100px" />&nbsp;<span
                        id="msg_postcode" class="msg"></span>
                </div>
                <div class="fi">
                    <label>
                        ��ϵ�绰��</label>
                    <asp:TextBox ID="txtPhone" MaxLength="30" runat="server" CssClass="text" Width="150px" />&nbsp;<span
                        id="msg_phone" class="msg"></span>
                </div>
                <div class="fi even">
                    <label>
                        �Ƿ���Ҫ��Ʊ��</label><select name="drpIsInvoice" onchange="if($(this).val()==1){$('#invoiceTitle').show();}else{$('#invoiceTitle').hide();}">
                            <option value="1">��</option>
                            <option value="0" selected>��</option>
                        </select>
                </div>
                <div id="invoiceTitle" class="fi" style="display: none;">
                    <label>
                        ��Ʊ̧ͷ��</label><asp:TextBox ID="txtInvoiceTitle" MaxLength="30" runat="server" CssClass="text" />
                </div>
                <div class="fi">
                    <label>
                        �û���ע��</label><asp:TextBox ID="txtNote" runat="server" CssClass="text" TextMode="MultiLine"
                            Rows="6" Width="450px" />
                </div>

                <script type="text/javascript">
                        var arrSelectName = new Array(document.getElementById("drpProvince"),document.getElementById("drpCity"),document.getElementById("drpArea"));
		                var arrList = new Array(<%=RenderAreaJs()%>);
		                var arrDefault = new Array();
		                arrDefault[0] = '6';
		                arrDefault[1] = '84';
		                arrDefault[2] = '0';
		                
		                //���޼�����select�������
                        (function (strInitID, arrSelect, arrMatrix, arrDefValue) {
                            function doChange(iIndex) {
                                var iCount = 0;
                                var sParentID = strInitID;
                                if (iIndex > 0) sParentID = arrSelect[iIndex - 1].options[arrSelect[iIndex - 1].selectedIndex].ID;
                                with (arrSelect[iIndex]) {
                                    length = 0;
                                    for (var i = 0; i < arrMatrix.length; i++) {
                                        if (String(arrMatrix[i][1]) == String(sParentID)) {
                                            var oNewOption = new Option(arrMatrix[i][2], arrMatrix[i][3], false, false);
                                            oNewOption.ID = arrMatrix[i][0];
                                            options[iCount++] = oNewOption;
					                        if(arrMatrix[i][3] == arrDefValue[iIndex])options[iCount - 1].selected = true;
                                        };
                                    };
                                    if (iCount == 0) {
                                        var oNull = new Option("--", null, false, true);
                                        oNull.ID = "_0x" + (new Date()).getTime();
                                        options[0] = oNull;
                                    };
                                    if (++iIndex < arrSelect.length) doChange(iIndex);
                                };
                            };
                            if (!arrDefValue) arrDefValue = [];
                            for (var i = 0; i < arrSelect.length - 1; i++) {
                                eval("arrSelect[" + i + "].onchange = function(){ doChange(" + (i + 1) + "); };");
                            }
                            doChange(0);
                            arrDefValue = [];
                        })(0,arrSelectName,arrList,arrDefault);
                </script>

                <div class="fi fiBtns">
                    <asp:Button ID="btnOk" runat="server" Text="����" OnClick="btnOk_Click" CssClass="submit">
                    </asp:Button>
                    <a href="OrderList.aspx">�����б�</a>
                </div>
            </div>
            <div class="mft">
            </div>
        </div>
        <div>
            <ul class="Help">
                <li>��ҳʵ����Ӷ�������</li>
            </ul>
        </div>

        <script>
        $(function() {
            //�ջ���ַ��ʱ��֤
            $("#<%=this.txtUserName.ClientID %>").blur(function() {
                if ($.trim($(this).val()) == "") {
                    $("#msg_userName").html("�������ջ�������");
                } else {
                    $("#msg_userName").html("");
                }
            });
            $("#<%=this.txtAddr.ClientID %>").blur(function() {
                if ($.trim($(this).val()) == "") {
                    $("#msg_addr").html("�������ջ��˵�ַ");
                } else {
                    $("#msg_addr").html("");
                }
            });
            $("#<%=this.txtPostcode.ClientID %>").blur(function() {
                if ($.trim($(this).val()) == "") {
                    $("#msg_postcode").html("�������ʱ�");
                } else {
                    $("#msg_postcode").html("");
                }
            });
            $("#<%=this.txtPhone.ClientID %>").blur(function() {
                if ($.trim($(this).val()) == "") {
                    $("#msg_phone").html("��������ϵ�绰");
                } else {
                    $("#msg_phone").html("");
                }
            });
            //������keyup�¼�
            $("#<%=this.txtMemberID.ClientID %>").keyup(function() {
                mustNum($(this));
            });

            /************************
            * ���ݻ�ԱID��ȡ��Ա��Ϣ
            ************************/
            $("#btnReadMember").click(function() {
                $("#msg_memberID").html("");

                if ($("#<%=this.txtMemberID.ClientID %>").val() == "") {
                    $("#msg_memberID").html("�������ԱID");
                    return;
                }
                $.ajax({
                    type: "GET",
                    url: "/Ajax/MemberGetByID.aspx?id=" + $("#<%=this.txtMemberID.ClientID %>").val(),
                    async: true,
                    cache: false,
                    success: function(msg) {
                        //����������Ϣ
                        var code = msg.substring(0, 1);
                        info = msg.substring(msg.indexOf(":") + 1); //�ó���Ա��Ϣ
                        switch (code) {
                            case "0":
                                var o = eval("(" + info + ")");

                                //�������
                                $("#drpProvince").val(o.provID.toString());
                                $("#drpProvince").change();
                                $("#drpCity").val(o.cityID.toString());
                                $("#drpCity").change();
                                $("#drpArea").val(o.areaID.toString());
                                $("#<%=this.txtAddr.ClientID %>").val(o.address);
                                $("#<%=this.txtUserName.ClientID %>").val(o.name);
                                $("#<%=this.txtPostcode.ClientID %>").val(o.postcode);
                                $("#<%=this.txtPhone.ClientID %>").val(o.phone);
                                break;
                            case "1":
                                $("#msg_memberID").html(info);
                                break;
                            default:
                                break;
                        }
                    },
                    error: function() {
                        alert("�������");
                    }
                });
                //window.open("/Ajax/MemberGetByID.aspx?id=" + $("#<%=this.txtMemberID.ClientID %>").val());
            });

            /**********
            * �������
            ***********/
            $("#tbGoods>tr>td>input").blur(function() {
                calGoodsPrice();
                calDeliverPrice();
            });
            $("#tbGoods>tr>td>input").focus(function() {
                calGoodsPrice();
                calDeliverPrice();
            });

            /*****************************
            * ����������仯ʱ�������˷�
            *****************************/
            $("#drpArea").change(function() {
                calDeliverPrice();
            });
        });

        /********************
        * ������ƷID��ȡ�۸�
        ********************/
        function getPrice(i) {
            var id = $("#txtGoodsID" + i).val();
            $.ajax({
                type: "GET",
                url: "/Ajax/GoodsGetPriceByID.aspx?id=" + id,
                async: true,
                cache: false,
                success: function(msg) {
                    //����������Ϣ
                    tem = msg.split(":");
                    var code = tem[0];
                    var info = tem[1];
                    switch (code) {
                        case "0":
                            $("#txtPrice" + i).val(info);
                            break;
                        case "1":
                            alert(info);
                            $("#txtGoodsID" + i).select();
                            break;
                        default:
                            break;
                    }
                },
                error: function() {
                    alert("�������");
                }
            });
        }

        /**********
        * �����Ʒ
        **********/
        function addGoods() {
            var template = "";
            template = "<tr id='trGoods{$i$}'>";
            template += "<td><input id='txtGoodsID{$i$}' name='txtGoodsID{$i$}' onblur='getPrice(\"{$i$}\");' onkeyup='mustNum(this);'/></td>";
            template += "<td><input id='txtPrice{$i$}' name='txtPrice{$i$}' visible='false' readonly /></td>";
            template += "<td><input id='txtQuantity{$i$}' name='txtQuantity{$i$}' value='1' onkeyup='mustNum(this);'/></td>";
            template += "<td><a href='javascript:;' onclick='delGoods(\"trGoods{$i$}\");' title='ɾ��'>��</a></td></tr>";

            var lastNO = parseInt($("#goodsCount").val()) + 1;
            $("#goodsCount").val(lastNO);
            var html = template.replace(/\{\$i\$\}/g, lastNO);
            //alert(html);
            $("#tbGoods").html($("#tbGoods").html() + html);

            /**********
            * �������
            ***********/
            $("#tbGoods>tr>td>input").blur(function() {
                calGoodsPrice();
                calDeliverPrice();
            });
            $("#tbGoods>tr>td>input").focus(function() {
                calGoodsPrice();
                calDeliverPrice();
            });
        }

        /**********
        * ɾ����Ʒ
        **********/
        function delGoods(id) {
            $("#" + id).remove();
        }

        /**********
        * ������֤
        **********/
        function check() {
            var pass = true;

            //���������֤��Ϣ
            $("#msg_memberID").html("");
            $("msg_payMode").html("");
            $("msg_deliverMode").html("");
            $("msg_addr").html("");
            $("msg_userName").html("");
            $("msg_postcode").html("");
            $("msg_phone").html("");

            //��ԱID��֤
            if ($("#<%=this.txtMemberID.ClientID %>").val() == "") {
                $("#msg_memberID").html("�������ԱID");
                pass = false;
            } else if (!memberExists($("#<%=this.txtMemberID.ClientID %>").val())) {
                pass = false;
            }
            //֧����ʽ��֤
            isChecked = false;
            for (var i = 0; i < $name("rdPayMode").length; i++) {
                if ($name("rdPayMode")[i].checked) {
                    isChecked = true;
                    break;
                }
            }
            if (!isChecked) {
                $("#msg_payMode").html("��ѡ��һ��֧����ʽ");
                pass = false;
            }
            //���ͷ�ʽ��֤
            isChecked = false;
            for (var i = 0; i < $name("rdDeliverMode").length; i++) {
                if ($name("rdDeliverMode")[i].checked) {
                    isChecked = true;
                    break;
                }
            }
            if (!isChecked) {
                $("#msg_deliverMode").html("��ѡ��һ�����ͷ�ʽ");
                pass = false;
            }
            //��ϵ��Ϣ��֤
            if (($("#drpProvince").val() == "") || ($("#drpCity").val() == "")) {
                $("#msg_addr").html("������ʡ��");
                pass = false;
            }
            if ($("#<%=this.txtAddr.ClientID %>").val() == "") {
                $("#msg_addr").html("�������ջ��˵�ַ");
                pass = false;
            }
            if ($("#<%=this.txtUserName.ClientID %>").val() == "") {
                $("#msg_userName").html("�������ջ�������");
                pass = false;
            }

            if ($("#<%=this.txtPostcode.ClientID %>").val() == "") {
                $("#msg_postcode").html("�������ʱ�");
                pass = false;
            }

            if ($("#<%=this.txtPhone.ClientID %>").val() == "") {
                $("#msg_phone").html("��������ϵ�绰");
                pass = false;
            }
            return pass;
        }

        /**********************
        * ��֤��Ա�Ƿ��Ѿ�����
        **********************/
        function memberExists(id) {
            var exists = true;
            $.ajax({
                type: "GET",
                url: "/Ajax/MemberIDExists.aspx?id=" + id,
                async: true,
                cache: false,
                success: function(msg) {
                    //����������Ϣ
                    var code = msg.substring(0, 1);
                    info = msg.substring(msg.indexOf(":") + 1);
                    switch (code) {
                        case "0":
                            //
                            break;
                        case "1":
                            $("#msg_memberID").html(info);
                            exists = false;
                            break;
                        default:
                            break;
                    }
                },
                error: function() {
                    alert("�������");
                }
            });
            return exists;
        }

        /**************
        * ֻ����������
        **************/
        function mustNum(o) {
            $(o).val($(o).val().replace(/[^0-9]/g, '').replace(/^[^1-9]/g, 1));
        }

        /***************
        * ������Ʒ�ܼ�
        ***************/
        function calGoodsPrice() {
            var totalPrice = 0;
            for (var i = 1; i <= parseInt($("#goodsCount").val()); i++) {
                if ($("#txtPrice" + i).val() == "") continue;

                //�ۼ���Ʒ�ܼ�
                var priceI = parseInt($("#txtQuantity" + i).val()) * parseFloat($("#txtPrice" + i).val());
                totalPrice = totalPrice + priceI;
                //alert("ii:" + $("#txtQuantity" + i));
            }
            $("#totalPrice").val(totalPrice);
            //return totalPrice;
        }
        
        /************************
        * �ͻ��������󣺼����˷�
        ************************/
        function calDeliverPrice() {
            var totalSalePrice = parseFloat($("#totalPrice").val());
            var priceLine = 500; //���ʷѽ���
            var deliverPrice = 0;
            //<priceLine�����˷�
            if (totalSalePrice < priceLine) {
                if ((parseInt($("#drpArea").val()) >= 1001) && (parseInt($("#drpArea").val()) <= 1008)) {
                    //���ڹ����ϰ���
                    deliverPrice = 30;
                } else {
                    deliverPrice = 50;
                }
            }
            $("#txtDeliverPrice").val(deliverPrice);
        }
        </script>
</asp:Content>
