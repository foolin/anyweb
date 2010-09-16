<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResuAddTemp.aspx.cs" Inherits="User_ResuAddTemp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" src="../js/jquery.js"></script>

    <script type="text/javascript" src="../js/form.js"></script>

    <script type="text/javascript" src="../js/jsBase.js"></script>

    <script type="text/javascript" src="../js/resume.js"></script>

</head>
<body>
    <div id="Bpi">
        <form action="http://my.51job.com/cv/in/Resume/BPIAction.php" id="BPI_form" method="post"
        name="BPI_form">
        <table cellspacing="0" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <td align="right">
                    </td>
                    <td align="left" colspan="3">
                        <span style="display: none;" id="er_name">
                            <img height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"
                                alt="" />请输入姓名</span>
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span>*</span>姓名
                    </td>
                    <td>
                        <label>
                            <input type="text" maxlength="20" value="蔡壮茂" id="Name" style="width: 157px;" name="Name" />
                        </label>
                    </td>
                    <td align="left">
                        <span>*</span>性别
                    </td>
                    <td class="">
                        <input type="radio" checked="checked" value="0" name="Gender" />男<input type="radio"
                            value="1" name="Gender" />女
                    </td>
                    <td align="left" style="text-align: right;">
                        <img style="cursor: pointer;" onclick="Bpi_save(1);" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_save1.gif"
                            alt="" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td align="left">
                        <span style="display: none;" id="er_birthday">
                            <img height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"
                                alt="" />请选择出生日期</span>
                    </td>
                    <td align="right">
                    </td>
                    <td align="left">
                        <span style="display: none;" id="er_workyear">
                            <img height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"
                                alt="" />请选择工作年限</span>
                    </td>
                    <td align="center">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span>*</span>出生日期
                    </td>
                    <td>
                        <select id="YearOfBirthday" name="YearOfBirthday">
                            <option value="2000">2000</option>
                            <option value="1999">1999</option>
                            <option value="1998">1998</option>
                            <option value="1997">1997</option>
                            <option value="1996">1996</option>
                            <option value="1995">1995</option>
                            <option value="1994">1994</option>
                            <option value="1993">1993</option>
                            <option value="1992">1992</option>
                            <option value="1991">1991</option>
                            <option value="1990">1990</option>
                            <option value="1989">1989</option>
                            <option value="1988">1988</option>
                            <option value="1987">1987</option>
                            <option value="1986">1986</option>
                            <option value="1985">1985</option>
                            <option selected="" value="1984">1984</option>
                            <option value="1983">1983</option>
                            <option value="1982">1982</option>
                            <option value="1981">1981</option>
                            <option value="1980">1980</option>
                            <option value="1979">1979</option>
                            <option value="1978">1978</option>
                            <option value="1977">1977</option>
                            <option value="1976">1976</option>
                            <option value="1975">1975</option>
                            <option value="1974">1974</option>
                            <option value="1973">1973</option>
                            <option value="1972">1972</option>
                            <option value="1971">1971</option>
                            <option value="1970">1970</option>
                            <option value="1969">1969</option>
                            <option value="1968">1968</option>
                            <option value="1967">1967</option>
                            <option value="1966">1966</option>
                            <option value="1965">1965</option>
                            <option value="1964">1964</option>
                            <option value="1963">1963</option>
                            <option value="1962">1962</option>
                            <option value="1961">1961</option>
                            <option value="1960">1960</option>
                            <option value="1959">1959</option>
                            <option value="1958">1958</option>
                            <option value="1957">1957</option>
                            <option value="1956">1956</option>
                            <option value="1955">1955</option>
                            <option value="1954">1954</option>
                            <option value="1953">1953</option>
                            <option value="1952">1952</option>
                            <option value="1951">1951</option>
                            <option value="1950">1950</option>
                            <option value="1949">1949</option>
                            <option value="1948">1948</option>
                            <option value="1947">1947</option>
                            <option value="1946">1946</option>
                            <option value="1945">1945</option>
                            <option value="1944">1944</option>
                            <option value="1943">1943</option>
                            <option value="1942">1942</option>
                            <option value="1941">1941</option>
                            <option value="1940">1940</option>
                        </select>年<select id="MonthOfBirthday" name="MonthOfBirthday"><option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                            <option value="9">9</option>
                            <option selected="" value="10">10</option>
                            <option value="11">11</option>
                            <option value="12">12</option>
                        </select>月<select id="DayOfBirthday" name="DayOfBirthday"><option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option selected="" value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                            <option value="9">9</option>
                            <option value="10">10</option>
                            <option value="11">11</option>
                            <option value="12">12</option>
                            <option value="13">13</option>
                            <option value="14">14</option>
                            <option value="15">15</option>
                            <option value="16">16</option>
                            <option value="17">17</option>
                            <option value="18">18</option>
                            <option value="19">19</option>
                            <option value="20">20</option>
                            <option value="21">21</option>
                            <option value="22">22</option>
                            <option value="23">23</option>
                            <option value="24">24</option>
                            <option value="25">25</option>
                            <option value="26">26</option>
                            <option value="27">27</option>
                            <option value="28">28</option>
                            <option value="29">29</option>
                            <option value="30">30</option>
                            <option value="31">31</option>
                        </select>日
                    </td>
                    <td align="left">
                        <span>*</span>&nbsp;工作年限
                    </td>
                    <td>
                        <select id="WorkYear" style="width: 154px;" name="WorkYear">
                            <option value="0">---请选择---</option>
                            <option value="1">在读学生</option>
                            <option value="2">应届毕业生</option>
                            <option value="3">一年以上</option>
                            <option value="4">二年以上</option>
                            <option value="5">三年以上</option>
                            <option value="6">五年以上</option>
                            <option value="7">八年以上</option>
                            <option value="8">十年以上</option>
                        </select>
                    </td>
                    <td align="center" valign="top" style="margin: 0pt; padding: 0pt;" rowspan="12">
                        <table cellspacing="0" cellpadding="0" border="0" width="100%" style="margin: 0pt;
                            padding: 0pt;">
                            <tbody>
                                <tr>
                                    <td align="left">
                                        <div style="display: none;" id="nophoto">
                                            <img height="110" width="90" src="http://img01.51jobcdn.com/im/2009/cv/no_pic.gif"
                                                alt="" />
                                        </div>
                                        <div style="" id="photo">
                                            <img height="110" width="90" src="/cv/CV_Attach_Read.php?ReSumeID=69897533&amp;AttachID=11334631&amp;25947"
                                                alt="" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <span>&gt;&gt;</span><a onfocus="blur()" style="text-decoration: none;" href="#"
                                            onclick="Upload('69897533','0')">编辑</a>&nbsp;&nbsp;&nbsp;<span>&gt;&gt;</span>&nbsp;<a
                                                onfocus="blur()" style="text-decoration: none;" onclick="delAtttach('69897533')"
                                                href="#">删除</a><input type="hidden" value="11334631" name="AttachID" id="AttachID" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td align="left" colspan="4">
                        <span style="display: none;" id="er_idnumber">
                            <img height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"
                                alt="" />填写有误。身份证号需核对位数和出生日期</span>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span><span>*</span>&nbsp;</span>证件类型
                    </td>
                    <td>
                        <select style="width: 162px;" id="CardType" name="CardType">
                            <option selected="" value="0">身份证</option>
                            <option value="1">护照</option>
                            <option value="2">军人证</option>
                            <option value="4">香港身份证</option>
                            <option value="3">其它</option>
                        </select>
                    </td>
                    <td align="left">
                        <span><span>*</span></span>证件号
                    </td>
                    <td>
                        <input type="text" maxlength="25" value="440582198410047435" id="IDNumber" name="IDNumber" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td align="left" colspan="4">
                        <span style="display: none;" id="er_location">
                            <img height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif" />请选择居住地</span>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span>*</span>居住地
                    </td>
                    <td>
                        <input type="button" onfocus="blur()" value="天河区" id="btnLocation" name="btnLocation" />
                        <input type="hidden" value="9904" id="Location" name="Location" />
                    </td>
                    <td align="left">
                        <span><span>*</span></span>Email
                    </td>
                    <td>
                        <input type="text" disabled="disabled" value="70785748@qq.com" id="email" name="email" /><a
                            onfocus="blur()" href="#" onclick="Modify_Info('My_ModifyE');">修改</a>
                    </td>
                </tr>
                <tr>
                    <td style="border: 0pt none;" colspan="4">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        目前年薪
                    </td>
                    <td>
                        <select id="Salary" name="Salary">
                            <option value="0">---请选择---</option>
                            <option value="01">2万以下</option>
                            <option value="02">2-3万</option>
                            <option value="03">3-4万</option>
                            <option value="04">4-5万</option>
                            <option value="05">5-6万</option>
                            <option value="06">6-8万</option>
                            <option value="07">8-10万</option>
                            <option value="08">10-15万</option>
                            <option value="09">15-30万</option>
                            <option value="10">30-50万</option>
                            <option value="11">50-100万</option>
                            <option value="12">100万以上</option>
                        </select>/年&nbsp;&nbsp;&nbsp;&nbsp;<a target="_blank" href="http://my.51job.com/my/Salary_report.php">薪酬查询</a>
                    </td>
                    <td align="left">
                        币种
                    </td>
                    <td>
                        <select id="CurrType" style="width: 154px;" name="CurrType">
                            <option selected="" value="01">人民币</option>
                            <option value="02">港币</option>
                            <option value="03">美元</option>
                            <option value="04">日元</option>
                            <option value="05">欧元</option>
                            <option value="06">其它</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left" colspan="4">
                        <span style="display: none;" id="er_phone">
                            <img height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"
                                alt="" />请输入正确的联系方式（只支持数字且数字之间不要用分隔符） </span>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span>*</span>联系方式
                    </td>
                    <td>
                        （请至少填写一项）
                    </td>
                    <td align="left">
                        <span>*</span>求职状态
                    </td>
                    <td>
                        <select id="current_situation" style="width: 154px;" name="current_situation">
                            <option selected="" value="0">目前正在找工作</option>
                            <option value="1">半年内无换工作的计划</option>
                            <option value="2">一年内无换工作的计划</option>
                            <option value="3">观望有好的机会再考虑</option>
                            <option value="4">我暂时不想找工作</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td colspan="4">
                        <span style="display: none;" id="errorMsg_5">
                            <img height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"
                                alt="" />&nbsp;&nbsp;请至少填写一项电话联系方式并且所填号码必须为数字！</span>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        手机号码
                    </td>
                    <td valign="middle">
                        <input type="text" value="020" maxlength="5" name="MPNation" id="MPNation" />&nbsp;-&nbsp;<input
                            type="text" style="width: 115px;" value="13631494997" maxlength="20" name="Mobile"
                            id="Mobile" /><img src="http://img01.51jobcdn.com/im/2009/cv/cresume/mobile_tips.gif"
                                title="请及时更新手机号，以便您的简历被企业浏览时能及时收到提示短信。" style="vertical-align: middle; margin-left: 5px;"
                                alt="" />
                    </td>
                    <td align="left">
                        公司电话
                    </td>
                    <td colspan="5">
                        <input type="text" value="086" maxlength="5" class="weight30" name="FPNation" id="FPNation" />&nbsp;-&nbsp;<input
                            type="text" value="区号" maxlength="5" name="FPCity" id="FPCity" />&nbsp;-&nbsp;<input
                                type="text" value="总机号码" maxlength="20" style="width: 62px;" name="FPNumber"
                                id="FPNumber" />&nbsp;-&nbsp;<input type="text" value="分机" maxlength="10" size="4"
                                    name="FPExtension" id="FPExtension" />
                    </td>
                </tr>
                <tr>
                    <td style="border: 0pt none;" colspan="5">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        家庭电话
                    </td>
                    <td>
                        <input type="text" value="086" maxlength="5"
                            name="HPNation" id="HPNation" />&nbsp;-&nbsp;<input type="text" value="区号" maxlength="5"
                                size="3" name="HPCity" id="HPCity"
                                />&nbsp;-&nbsp;<input type="text" value="电话号码" maxlength="20" name="HPNumber"
                                    style="width: 70px;" id="HPNumber" />
                    </td>
                    <td align="left" class="col_name">
                        &nbsp;户&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;口
                    </td>
                    <td colspan="5">
                        <input type="button" onfocus="blur()" onclick="searchInit(this,document.BPI_form.HuKouNew,this,ja_new,'户口',7, false, 4, 'Province');$('#btnHuKou').removeAttr('onclick');"
                            value="选择/修改" id="btnHuKou" class="choose" name="btnHuKou"><input type="hidden" value=""
                                id="HuKouNew" name="HuKouNew">
                    </td>
                </tr>
                <tr>
                    <td class="noborder">
                    </td>
                    <td align="left" class="noborder" colspan="2">
                        <span style="display: none;" class="text_red" id="er_resumekey">
                            <img height="15" align="absmiddle" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"></span>
                    </td>
                    <td colspan="5" class="noborder">
                    </td>
                </tr>
                <tr>
                    <td align="left" class="col_name">
                        关键词
                    </td>
                    <td colspan="2">
                        <textarea name="resumekey" id="resumekey" cols="45" rows="2"></textarea>
                    </td>
                    <td style="color: rgb(129, 129, 129);" colspan="5">
                        请输入代表你个人的关键词，限<span style="color: rgb(255, 0, 0);">10</span>个，用空格隔开。如行业、特长、业绩等，每词不超过6个汉字(12个英文字母)。
                    </td>
                </tr>
            </tbody>
        </table>
        <table cellspacing="0" cellpadding="0" border="0" class="weight780_mdf noborder">
            <tbody>
                <tr>
                    <td align="left" class="padding_l20 noborder">
                        <span class="orareg"><a style="cursor: pointer;" onfocus="blur()" onclick="More_show('BPI_info','Bpi_more')"
                            class="orange1">查看更多个人信息</a><font style="display: none;" id="up">↑</font><font style=""
                                id="down">↓</font></span>
                    </td>
                </tr>
            </tbody>
        </table>
        <table cellspacing="0" cellpadding="0" border="0" style="display: none;" id="Bpi_more"
            class="weight780_mdf">
            <tbody>
                <tr>
                    <td class="noborder" colspan="3">
                    </td>
                    <td align="left" class="noborder">
                        <span style="display: none;" class="text_red" id="er_stature">
                            <img height="15" align="absmiddle" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif">输入错误。身高请输入数字。</span>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="col_name">
                        国家或地区
                    </td>
                    <td class="weight220">
                        <input type="button" onfocus="blur()" onclick="searchInit(this,document.BPI_form.Nationality,this,na,'国家或地区',5);$('#btnNationality').removeAttr('onclick');"
                            value="选择/修改" id="btnNationality" class="choose" name="btnNationality"><input type="hidden"
                                value="" id="Nationality" name="Nationality">
                    </td>
                    <td align="left" class="col_name">
                        身&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;高
                    </td>
                    <td>
                        <input type="text" maxlength="3" value="" id="stature" class="weight30" onblur="checkinputstr('stature','er_stature')"
                            name="stature">cm
                    </td>
                </tr>
                <tr>
                    <td style="border: 0pt none;" colspan="3">
                    </td>
                    <td align="left" style="border: 0pt none;">
                        <span style="display: none;" class="text_red" id="er_alitalk">
                            <img height="15" align="absmiddle" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif">输入错误。该旺旺（淘宝版）ID已经存在。</span>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="col_name">
                        婚姻状况
                    </td>
                    <td>
                        <select id="marriage" style="width: 164px;" name="marriage">
                            <option value="">---请选择---</option>
                            <option value="0">未婚</option>
                            <option value="1">已婚</option>
                            <option value="2">保密</option>
                        </select>
                    </td>
                    <td align="left" class="col_name">
                        旺旺ID
                    </td>
                    <td>
                        <input type="text" maxlength="100" value="" id="alitalk" onblur="checkinputstr('alitalk','er_alitalk')"
                            class="weight150" name="alitalk">&nbsp;&nbsp;<a onfocus="blur()" target="_blank"
                                class="orange1" href="http://member1.taobao.com/member/register.jhtml">注册旺旺</a>&nbsp;&nbsp;<a
                                    onfocus="blur()" target="_blank" class="orange1" href="http://www.taobao.com/wangwang/download.php">下载阿里旺旺</a><input
                                        type="hidden" class="ErrorSave" value="0" id="ErrorSave" name="ErrorSave"><input
                                            type="hidden" value="update" id="NextAction" name="NextAction"><input type="hidden"
                                                id="isEnglish" value="0" name="isEnglish"><input type="hidden" class="ReSumeID" value="69897533"
                                                    id="ReSumeID" name="ReSumeID"><input type="hidden" value="2" name="OldBase" id="OldBase"><input
                                                        type="hidden" value="" name="newReSume" id="newReSume"><input type="hidden" value="0"
                                                            name="showtrace" id="showtrace">
                    </td>
                </tr>
                <tr>
                    <td class="noborder">
                    </td>
                    <td align="left" class="noborder" colspan="3">
                        <span style="display: none;" class="text_red" id="er_address">
                            <img height="15" align="absmiddle" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif">地址和邮政编码请同时填写（香港：000000），邮编需为6位数字。</span>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="col_name">
                        邮&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;编
                    </td>
                    <td>
                        <input type="text" maxlength="6" value="" id="ZipCode" class="weight160" onblur="checkinputstr('Address','er_address')"
                            name="ZipCode">
                    </td>
                    <td align="left" class="col_name">
                        地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址
                    </td>
                    <td>
                        <input type="text" class="weight150" maxlength="150" value="" id="Address" onblur="checkinputstr('Address','er_address')"
                            name="Address">
                    </td>
                </tr>
                <tr>
                    <td class="noborder">
                    </td>
                    <td align="left" class="noborder" colspan="3">
                        <span style="display: none;" class="text_red" id="er_homepage">
                            <img height="15" align="absmiddle" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif">输入错误。请控制在200个汉字以内。</span>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="col_name">
                        个人主页
                    </td>
                    <td colspan="3">
                        <input type="text" class="weight160" maxlength="200" value="" id="HomePage" onblur="checkinputstr('HomePage','er_homepage')"
                            name="HomePage">
                    </td>
                </tr>
            </tbody>
        </table>
        </form>
    </div>
    <div id="Edu">
        <div id="Edu_<%=EduID %>">
            <form action="/User/EduSave.aspx?id=<%=QS("id") %>&eduid=<%=EduID %>&type=add" id="Edu_form_<%=EduID %>"
            method="post">
            <table>
                <tbody>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <span style="display: none;" id="errorMsg_2_1">
                                <img height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"
                                    alt="" />&nbsp;&nbsp;请选择时间!</span><span style="display: none;" id="errorMsg_2_2"><img
                                        height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"
                                        alt="" />&nbsp;&nbsp;结束时间不能小于起始时间!</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>* </span>时间
                        </td>
                        <td>
                            <select id="FromYear" name="FromYear">
                                <option selected="selected" value="0">年</option>
                                <%for (int i = DateTime.Now.Year; i >= 1940; i--)
                                  { %>
                                <option value="<%=i%>">
                                    <%=i%></option>
                                <%} %>
                            </select>
                            <select id="FromMonth" name="FromMonth">
                                <option selected="selected" value="0">月</option>
                                <%for (int i = 1; i <= 12; i++)
                                  { %>
                                <option value="<%=i%>">
                                    <%=i%></option>
                                <%} %>
                            </select>
                            到
                            <select id="ToYear" name="ToYear">
                                <option selected="selected" value="0">年</option>
                                <%for (int i = DateTime.Now.Year + 5; i >= 1940; i--)
                                  { %>
                                <option value="<%=i%>">
                                    <%=i%></option>
                                <%} %>
                            </select>
                            <select id="ToMonth" name="ToMonth">
                                <option selected="selected" value="0">月</option>
                                <%for (int i = 1; i <= 12; i++)
                                  { %>
                                <option value="<%=i%>">
                                    <%=i%></option>
                                <%} %>
                            </select>
                            (后两项不填表示至今)
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <span style="display: none;" id="errorMsg_2_3">
                                <img height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"
                                    alt="" />&nbsp;&nbsp;请输入学校名称（限50个汉字）</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>*</span> 学校
                        </td>
                        <td>
                            <input type="text" maxlength="100" value="" id="SchoolName" style="width: 353px;"
                                name="SchoolName" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <span style="display: none;" id="errorMsg_2_4">
                                <img height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"
                                    alt="" />&nbsp;&nbsp;请选择或者手动填写专业名称（限50个汉字）</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>* </span>专业
                        </td>
                        <td>
                            <input type="button" style="cursor: pointer;" value="选择/修改" id="btnSubMajor" /><input
                                type="hidden" value="" id="SubMajor" name="SubMajor" />&nbsp;&nbsp;<input type="text"
                                    maxlength="100" value="若无合适选项请在此处填写" id="MoreMajor" name="MoreMajor" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <span style="display: none;" id="errorMsg_2_5">
                                <img height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"
                                    alt="" />&nbsp;&nbsp;请选择学历！</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>* </span>学历
                        </td>
                        <td>
                            <select id="Degree" name="Degree">
                                <option value="">请选择 </option>
                                <option value="1">初中</option>
                                <option value="2">高中</option>
                                <option value="3">中技</option>
                                <option value="4">中专</option>
                                <option value="5">大专</option>
                                <option value="6">本科</option>
                                <option value="7">MBA</option>
                                <option value="8">硕士</option>
                                <option value="9">博士</option>
                                <option value="10">其他</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            专业描述
                        </td>
                        <td>
                            <textarea id="EduDetail" cols="10" rows="6" name="EduDetail"></textarea><br />
                            <span>填写您所学专业包括什么课程，您的毕业设计等等</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <img style="cursor: pointer;" onclick="Edu_save('Edu_form_<%=EduID %>');" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_save1.gif"
                                alt="" />
                        </td>
                    </tr>
                </tbody>
            </table>
            </form>
        </div>
    </div>
    <div>
        <img hspace="5" vspace="10" id="Edu_add" style="cursor: pointer;" onclick="addinfo('Edu',<%=QS("id") %>);"
            src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_addcontinue.gif" alt="" /></div>
    <input type="hidden" id="active" name="active" />
</body>
</html>
