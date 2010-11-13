<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LangGet.aspx.cs" Inherits="User_LangGet" %>

<div id="lang_<%=langID %>">
    <form action="/User/LangSave.aspx?id=<%=QS("id") %>&langid=<%=langID %>&type=add"
    id="lang_form_<%=langID %>" method="post">
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
                    <option value="0">请选择语言类别</option>
                    <option value="1">英语</option>
                    <option value="2">日语</option>
                    <option value="3">俄语</option>
                    <option value="4">阿拉伯语</option>
                    <option value="5">法语</option>
                    <option value="6">德语</option>
                    <option value="7">西班牙语</option>
                    <option value="8">葡萄牙语</option>
                    <option value="9">意大利语</option>
                    <option value="10">韩语/朝鲜语</option>
                    <option value="11">普通话</option>
                    <option value="12">粤语</option>
                    <option value="13">闽南语</option>
                    <option value="14">上海话</option>
                    <option value="15">其它</option>
                </select>
            </td>
            <th scope="row">
                <span class="orange">*</span>掌握程度
            </th>
            <td>
                <span class="right">
                    <input type="button" id="btn_lang_del" class="btn60_28_gray" value="删 除" onclick="delinfo('lang',<%=langID %>,'btn_lang_del','lang_<%=langID %>')" />
                    &nbsp;&nbsp;<input type="button" id="btn_lang_save" class="btn60_28" value="保 存"
                        onclick="lang_save('lang_form_<%=langID %>')" /></span>
                <select id="Lang_Master" name="Lang_Master">
                    <option value="0" selected="selected">不限</option>
                    <option value="1">一般</option>
                    <option value="2">良好</option>
                    <option value="3">熟练</option>
                    <option value="4">精通</option>
                </select>
            </td>
        </tr>
        <tr>
            <th scope="row">
                <span class="orange">*</span>读写能力
            </th>
            <td>
                <select id="Lang_RW" name="Lang_RW">
                    <option value="0" selected="selected">不限</option>
                    <option value="1">一般</option>
                    <option value="2">良好</option>
                    <option value="3">熟练</option>
                    <option value="4">精通</option>
                </select>
            </td>
            <th scope="row">
                <span class="orange">*</span>听说能力
            </th>
            <td>
                <select id="Lang_Listen" name="Lang_Listen">
                    <option value="0" selected="selected">不限</option>
                    <option value="1">一般</option>
                    <option value="2">良好</option>
                    <option value="3">熟练</option>
                    <option value="4">精通</option>
                </select>
            </td>
        </tr>
    </table>
    <div class="blank6px">
    </div>
    </form>
</div>
