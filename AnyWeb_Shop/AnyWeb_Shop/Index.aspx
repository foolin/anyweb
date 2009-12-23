<%@ Page Title="������" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="Index" %>
<%@ Register Src="~/Controls/CategoryLeft.ascx" TagName="CategoryLeft" TagPrefix="cate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="col-left">
            <!-- ��Ŀ -->
            <cate:CategoryLeft runat="server" />
            <!-- category end -->
            <!-- ��Ŀ -->
            <div class="category">
                <div class="title">
                    ��Ʒ����</div>
                <div class="content">
                    <h3>
                        ͼ���������</h3>
                    <div class="line">
                        <span><a href="">DVD</a></span> <span><a href="">Ӱ��</a></span> <span><a href="">����</a></span>
                        <span><a href="">����</a></span> <span><a href="">����</a></span> <span><a href="">��s��</a></span>
                        <span><a href="">��s��</a></span> <span><a href="">��s��</a></span> <span><a href="">DVD</a></span>
                        <span><a href="">Ӱ��</a></span> <span><a href="">����</a></span> <span><a href="">����</a></span>
                        <span><a href="">����</a></span> <span><a href="">��s��</a></span> <span><a href="">��s��</a></span>
                        <span><a href="">��s��</a></span>
                        <div class="clear">
                        </div>
                    </div>
                    <h3>
                        ͼ���������</h3>
                    <div class="line">
                        <span><a href="">DVD</a></span> <span><a href="">Ӱ��</a></span> <span><a href="">����</a></span>
                        <span><a href="">����</a></span> <span><a href="">����</a></span> <span><a href="">��s��</a></span>
                        <span><a href="">��s��</a></span> <span><a href="">��s��</a></span> <span><a href="">DVD</a></span>
                        <span><a href="">Ӱ��</a></span> <span><a href="">����</a></span> <span><a href="">����</a></span>
                        <span><a href="">����</a></span> <span><a href="">��s��</a></span> <span><a href="">��s��</a></span>
                        <span><a href="">��s��</a></span>
                        <div class="clear">
                        </div>
                    </div>
                    <h3>
                        ͼ���������</h3>
                    <div class="line">
                        <span><a href="">DVD</a></span> <span><a href="">Ӱ��</a></span> <span><a href="">����</a></span>
                        <span><a href="">����</a></span> <span><a href="">����</a></span> <span><a href="">��s��</a></span>
                        <span><a href="">��s��</a></span> <span><a href="">��s��</a></span> <span><a href="">DVD</a></span>
                        <span><a href="">Ӱ��</a></span> <span><a href="">����</a></span> <span><a href="">����</a></span>
                        <span><a href="">����</a></span> <span><a href="">��s��</a></span> <span><a href="">��s��</a></span>
                        <span><a href="">��s��</a></span>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <!-- content end -->
            </div>
            <!-- category end -->
        </div>
        <!-- col-left -->
        <div class="col-main">
            <div class="container-images">
                <div class="slide-container" id="slide-container">
                    <table id="slide-images" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <a href="saaa">
                                    <img src="pictures/slide01.jpg" /></a>
                            </td>
                            <td>
                                <a href="saaa">
                                    <img src="http://images.amazon.cn/w/wjf_091102_email_80.jpg?15" /></a>
                            </td>
                            <td>
                                <a href="saaa">
                                    <img src="http://images.amazon.cn/h/hl_091202_bea470_water.jpg??15" /></a>
                            </td>
                            <td>
                                <a href="saaa">
                                    <img src="http://images.amazon.cn/w/wj_091204_homecare_470-200_quilt2.jpg??15" /></a>
                            </td>
                            <td>
                                <a href="saaa">
                                    <img src="http://images.amazon.cn/l/lll_091203_dn470_basics.jpg?15" /></a>
                            </td>
                        </tr>
                    </table>
                    <ul class="num" id="idNum">
                    </ul>
                </div>
                <!-- slide-container end -->
            </div>
            <!-- container-images end -->

            <script>
///////////////////////////////////////////////////////////
var forEach = function(array, callback, thisObject){
	if(array.forEach){
		array.forEach(callback, thisObject);
	}else{
		for (var i = 0, len = array.length; i < len; i++) { callback.call(thisObject, array[i], i, array); }
	}
}

var st = new SlideTrans("slide-container", "slide-images", 5, { Vertical: false });

var nums = [];
//��������
for(var i = 0, n = st._count - 1; i <= n;){
	(nums[i] = $("idNum").appendChild(document.createElement("li"))).innerHTML = ++i;
}

forEach(nums, function(o, i){
	o.onmouseover = function(){ o.className = "on"; st.Auto = false; st.Run(i); }
	o.onmouseout = function(){ o.className = ""; st.Auto = true; st.Run(); }
})

//���ð�ť��ʽ
st.onStart = function(){
	forEach(nums, function(o, i){ o.className = st.Index == i ? "on" : ""; })
}

st.Run();
            </script>

            <div class="container">
                <div class="goods-container">
                    <div class="title">
                        �ȼ���Ʒ</div>
                    <div class="goods">
                        <!-- Index Item -->
                        <div class="index-item">
                            <div class="pic">
                                <a href="#test">
                                    <img src="pictures/04.jpg" border="0" alt="0" /></a>
                            </div>
                            <div class="name">
                                <a href="#test">���ͼ��</a>
                            </div>
                        </div>
                        <ul class="items">
                            <li><a href="#test">���ͼ��</a></li>
                            <li><a href="#test">���ͼ��</a></li>
                            <li><a href="#test">���ͼ��</a></li>
                            <li><a href="#test">���ͼ��</a></li>
                        </ul>
                    </div>
                    <!-- goods end-->
                    <div class="goods">
                        <!-- Index Item -->
                        <div class="index-item">
                            <div class="pic">
                                <a href="#test">
                                    <img src="pictures/04.jpg" border="0" alt="0" /></a>
                            </div>
                            <div class="name">
                                <a href="#test">���ͼ��</a>
                            </div>
                        </div>
                        <ul class="items">
                            <li><a href="#test">���ͼ��</a></li>
                            <li><a href="#test">���ͼ��</a></li>
                            <li><a href="#test">���ͼ��</a></li>
                            <li><a href="#test">���ͼ��</a></li>
                        </ul>
                    </div>
                    <!-- goods end-->
                    <div class="goods">
                        <!-- Index Item -->
                        <div class="index-item">
                            <div class="pic">
                                <a href="#test">
                                    <img src="pictures/04.jpg" border="0" alt="0" /></a>
                            </div>
                            <div class="name">
                                <a href="#test">���ͼ��</a>
                            </div>
                        </div>
                        <ul class="items">
                            <li><a href="#test">���ͼ��</a></li>
                            <li><a href="#test">���ͼ��</a></li>
                            <li><a href="#test">���ͼ��</a></li>
                            <li><a href="#test">���ͼ��</a></li>
                        </ul>
                    </div>
                    <!-- goods end-->
                    <div class="clear">
                    </div>
                </div>
                <!-- goods-container end -->
                <div class="goods-container">
                    <div class="title">
                        �ȼ���Ʒ</div>
                    <div class="goods">
                        <!-- Index Item -->
                        <div class="index-item">
                            <div class="pic">
                                <a href="#test">
                                    <img src="pictures/04.jpg" border="0" alt="0" /></a>
                            </div>
                            <div class="name">
                                <a href="#test">���ͼ��</a>
                            </div>
                        </div>
                        <ul class="items">
                            <li><a href="#test">���ͼ��</a></li>
                            <li><a href="#test">���ͼ��</a></li>
                            <li><a href="#test">���ͼ��</a></li>
                            <li><a href="#test">���ͼ��</a></li>
                        </ul>
                    </div>
                    <!-- goods end-->
                    <div class="goods">
                        <!-- Index Item -->
                        <div class="index-item">
                            <div class="pic">
                                <a href="#test">
                                    <img src="pictures/04.jpg" border="0" alt="0" /></a>
                            </div>
                            <div class="name">
                                <a href="#test">���ͼ��</a>
                            </div>
                        </div>
                        <ul class="items">
                            <li><a href="#test">ħ��С���ʱ�ϵͳ39Ԫ��</a></li>
                            <li><a href="#test">ħ��С���ʱ�ϵͳ39Ԫ��</a></li>
                            <li><a href="#test">���ͼ��</a></li>
                            <li><a href="#test">���ͼ��</a></li>
                        </ul>
                    </div>
                    <!-- goods end-->
                    <div class="goods">
                        <!-- Index Item -->
                        <div class="index-item">
                            <div class="pic">
                                <a href="#test">
                                    <img src="pictures/04.jpg" border="0" alt="0" /></a>
                            </div>
                            <div class="name">
                                <a href="#test">���ͼ��</a>
                            </div>
                        </div>
                        <ul class="items">
                            <li><a href="#test">ħ��С���ʱ�ϵͳ39Ԫ��</a></li>
                            <li><a href="#test">ħ��С���ʱ�ϵͳ39Ԫ��</a></li>
                            <li><a href="#test">���ͼ��</a></li>
                            <li><a href="#test">���ͼ��</a></li>
                        </ul>
                    </div>
                    <!-- goods end-->
                    <div class="clear">
                    </div>
                </div>
                <!-- goods-container end -->
            </div>
            <!-- container end -->
        </div>
        <!-- col-main -->
        <div class="col-right">
            <div class="topic-box">
                <!-- ����ר�⿪ʼ -->
                <div class="title">
                    ����ר��</div>
                <div class="topic-goods">
                    <div class="goods-pic">
                        <a href="#links">
                            <img src="pictures/01.jpg" width="90" height="90" alt="" border="0" />
                        </a>
                    </div>
                    <div class="goods-intro">
                        <div class="content">
                            <h5>
                                ��������ר��������5����</h5>
                            ����������һ��ӵ��70������ʷ��������Ƶ��Ʒ�����̣��������г����ʢ��������Ʒ��֮һ����׿Խ����ѷ��������ר���꿪ҵȫ���������5����!
                        </div>
                        <div class="more">
                            <a href="#details.aspx">�鿴����>></a></div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <!-- topic-goods end-->
                <div class="topic-goods">
                    <div class="goods-pic">
                        <a href="#links">
                            <img src="pictures/02.jpg" width="90" height="90" alt="" border="0" />
                        </a>
                    </div>
                    <div class="goods-intro">
                        <div class="content">
                            <h5>
                                ��������ר��������5����</h5>
                            ����������һ��ӵ��70������ʷ��������Ƶ��Ʒ�����̣��������г����ʢ��������Ʒ��֮һ����׿Խ����ѷ��������ר���꿪ҵȫ���������5����!
                        </div>
                        <div class="more">
                            <a href="#details.aspx">�鿴����>> </a>
                        </div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <!-- topic-goods end-->
                <!-- ����ר����� -->
                <div style="height: 10px;">
                    <!-- �ָ� -->
                </div>
                <div class="title">
                    ���Ӱ����Ʒ</div>
                <div class="hot-goods">
                    <div class="goods-pic">
                        <a href="#links">
                            <img src="pictures/01.jpg" width="90" height="90" alt="" border="0" />
                        </a>
                    </div>
                    <div class="goods-list">
                        <ol>
                            <li><a href="#hotgoods.aspx?id=3">����(DVD ��װ��) </a></li>
                            <li><a href="#hotgoods.aspx?id=3">���ν��2(2DVD9���) </a></li>
                            <li><a href="#hotgoods.aspx?id=3">�׾��İ���(8DVD+��)(�ټҽ�̳) </a></li>
                        </ol>
                        <div class="more">
                            <a href="#more">�������а�</a></div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <!-- hot-goods end -->
                <div class="title">
                    ���Ӱ����Ʒ</div>
                <div class="hot-goods">
                    <div class="goods-pic">
                        <a href="#links">
                            <img src="pictures/01.jpg" width="90" height="90" alt="" border="0" />
                        </a>
                    </div>
                    <div class="goods-list">
                        <ol>
                            <li><a href="#hotgoods.aspx?id=3">����(DVD ��װ��) </a></li>
                            <li><a href="#hotgoods.aspx?id=3">���ν��2(2DVD9���) </a></li>
                            <li><a href="#hotgoods.aspx?id=3">�׾��İ���(8DVD+��)(�ټҽ�̳) </a></li>
                        </ol>
                        <div class="more">
                            <a href="#more">�������а�</a></div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <!-- hot-goods end -->
                <div class="title">
                    ���Ӱ����Ʒ</div>
                <div class="hot-goods">
                    <div class="goods-pic">
                        <a href="#links">
                            <img src="pictures/01.jpg" width="90" height="90" alt="" border="0" />
                        </a>
                    </div>
                    <div class="goods-list">
                        <ol>
                            <li><a href="#hotgoods.aspx?id=3">����(DVD ��װ��) </a></li>
                            <li><a href="#hotgoods.aspx?id=3">���ν��2(2DVD9���) </a></li>
                            <li><a href="#hotgoods.aspx?id=3">�׾��İ���(8DVD+��)(�ټҽ�̳) </a></li>
                        </ol>
                        <div class="more">
                            <a href="#more">�������а�</a></div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <!-- hot-goods end -->
            </div>
            <!-- topic-box end -->
        </div>
        <!-- col-right -->
        <div class="clear">
        </div>
    </div>
    <!-- main end -->
    <div class="ad-banner">
        ר�⼰�������ۻ
    </div>
    <!-- ad-banner end -->
</asp:Content>
