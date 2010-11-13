<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LangEdit.aspx.cs" Inherits="User_LangEdit" %>

<form action="/User/LangSave.aspx?langid=<%=bean.fdLangID %>&type=edit"
id="lang_form_<%=bean.fdLangID %>" method="post">
<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
        </th>
        <td>
            <span class="tipW red hidden" id="errorMsg_Type">请选择语言类别！</span>
        </td>
        <th scope="row">
        </th>
        <td>
        </td>
    </tr>
    <tr>
        <th scope="row">
            <span class="orange">*</span>语言类别
        </th>
        <td>
            <select id="Lang_Type" name="Lang_Type">
                <option value="0" <%=bean.fdLangType==0?"selected=\"selected\"":"" %>>请选择语言类别</option>
                <option value="1" <%=bean.fdLangType==1?"selected=\"selected\"":"" %>>英语</option>
                <option value="2" <%=bean.fdLangType==2?"selected=\"selected\"":"" %>>日语</option>
                <option value="3" <%=bean.fdLangType==3?"selected=\"selected\"":"" %>>俄语</option>
                <option value="4" <%=bean.fdLangType==4?"selected=\"selected\"":"" %>>阿拉伯语</option>
                <option value="5" <%=bean.fdLangType==5?"selected=\"selected\"":"" %>>法语</option>
                <option value="6" <%=bean.fdLangType==6?"selected=\"selected\"":"" %>>德语</option>
                <option value="7" <%=bean.fdLangType==7?"selected=\"selected\"":"" %>>西班牙语</option>
                <option value="8" <%=bean.fdLangType==8?"selected=\"selected\"":"" %>>葡萄牙语</option>
                <option value="9" <%=bean.fdLangType==9?"selected=\"selected\"":"" %>>意大利语</option>
                <option value="10" <%=bean.fdLangType==10?"selected=\"selected\"":"" %>>韩语/朝鲜语</option>
                <option value="11" <%=bean.fdLangType==11?"selected=\"selected\"":"" %>>普通话</option>
                <option value="12" <%=bean.fdLangType==12?"selected=\"selected\"":"" %>>粤语</option>
                <option value="13" <%=bean.fdLangType==13?"selected=\"selected\"":"" %>>闽南语</option>
                <option value="14" <%=bean.fdLangType==14?"selected=\"selected\"":"" %>>上海话</option>
                <option value="15" <%=bean.fdLangType==15?"selected=\"selected\"":"" %>>其它</option>
            </select>
        </td>
        <th scope="row">
            <span class="orange">*</span>掌握程度
        </th>
        <td>
            <span class="right">
                <input type="button" id="btn_lang_del" class="btn60_28_gray" value="删 除" onclick="delinfo('lang',<%=bean.fdLangID %>,'btn_lang_del','lang_<%=bean.fdLangID %>')" />
                &nbsp;&nbsp;<input type="button" id="btn_lang_save" class="btn60_28" value="保 存"
                    onclick="lang_save('lang_form_<%=bean.fdLangID %>')" /></span>
            <select id="Lang_Master" name="Lang_Master">
                <option value="0" <%=bean.fdLangMaster==0?"selected=\"selected\"":"" %>>不限</option>
                <option value="1" <%=bean.fdLangMaster==1?"selected=\"selected\"":"" %>>一般</option>
                <option value="2" <%=bean.fdLangMaster==2?"selected=\"selected\"":"" %>>良好</option>
                <option value="3" <%=bean.fdLangMaster==3?"selected=\"selected\"":"" %>>熟练</option>
                <option value="4" <%=bean.fdLangMaster==4?"selected=\"selected\"":"" %>>精通</option>
            </select>
        </td>
    </tr>
    <tr>
        <th scope="row">
            <span class="orange">*</span>读写能力
        </th>
        <td>
            <select id="Lang_RW" name="Lang_RW">
                <option value="0" <%=bean.fdLangRWAbility==0?"selected=\"selected\"":"" %>>不限</option>
                <option value="1" <%=bean.fdLangRWAbility==1?"selected=\"selected\"":"" %>>一般</option>
                <option value="2" <%=bean.fdLangRWAbility==2?"selected=\"selected\"":"" %>>良好</option>
                <option value="3" <%=bean.fdLangRWAbility==3?"selected=\"selected\"":"" %>>熟练</option>
                <option value="4" <%=bean.fdLangRWAbility==4?"selected=\"selected\"":"" %>>精通</option>
            </select>
        </td>
        <th scope="row">
            <span class="orange">*</span>听说能力
        </th>
        <td>
            <select id="Lang_Listen" name="Lang_Listen">
                <option value="0" <%=bean.fdLangLiAbility==0?"selected=\"selected\"":"" %>>不限</option>
                <option value="1" <%=bean.fdLangLiAbility==1?"selected=\"selected\"":"" %>>一般</option>
                <option value="2" <%=bean.fdLangLiAbility==2?"selected=\"selected\"":"" %>>良好</option>
                <option value="3" <%=bean.fdLangLiAbility==3?"selected=\"selected\"":"" %>>熟练</option>
                <option value="4" <%=bean.fdLangLiAbility==4?"selected=\"selected\"":"" %>>精通</option>
            </select>
        </td>
    </tr>
</table>
<div class="blank6px">
</div>
</form>
