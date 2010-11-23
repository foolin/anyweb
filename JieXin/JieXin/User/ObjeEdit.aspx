<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ObjeEdit.aspx.cs" Inherits="User_ObjeEdit" %>

<form action="/User/ObjeSave.aspx?id=<%=QS("id") %>" id="obje_form" method="post">
<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
            &nbsp;工作类型
        </th>
        <td>
            <select id="Obje_Type" name="Obje_Type">
                <option value="1" <%=bean.fdResuObjeType==1?"selected=\"selected\"":"" %>>全职</option>
                <option value="2" <%=bean.fdResuObjeType==2?"selected=\"selected\"":"" %>>兼职</option>
                <option value="3" <%=bean.fdResuObjeType==3?"selected=\"selected\"":"" %>>实习</option>
                <option value="4" <%=bean.fdResuObjeType==4?"selected=\"selected\"":"" %>>全/兼职</option>
            </select>
        </td>
        <th scope="row">
            &nbsp;地&nbsp;&nbsp;&nbsp;&nbsp;点
        </th>
        <td>
            <span class="right">&nbsp;&nbsp;<input type="button" id="btn_obje_save" class="btn60_28"
                value="保 存" onclick="obje_save('obje_form')" /></span> <a href="javascript:void(0);"
                    id="Obje_Area" class="btn28H" style="font-size: 12px;" title="<%=getAreaName()%>">
                    <%=getAreaName()%></a>
            <input type="hidden" id="Obje_AreaID" name="Obje_AreaID" value="<%=bean.fdResuObjeAreaID1 == 0 ? "" : bean.fdResuObjeAreaID1 + ";"%><%=bean.fdResuObjeAreaID2 == 0 ? "" : bean.fdResuObjeAreaID2 + ";"%><%=bean.fdResuObjeAreaID3 == 0 ? "" : bean.fdResuObjeAreaID3 + ";"%><%=bean.fdResuObjeAreaID4 == 0 ? "" : bean.fdResuObjeAreaID4 + ";"%><%=bean.fdResuObjeAreaID5 == 0 ? "" : bean.fdResuObjeAreaID5 + ";"%>" />
            <input type="hidden" id="Obje_AreaName" name="Obje_AreaName" value="<%=bean.fdResuObjeAreaID1 == 0 ? "" : bean.fdResuObjeArea1 + ";"%><%=bean.fdResuObjeAreaID2 == 0 ? "" : bean.fdResuObjeArea2 + ";"%><%=bean.fdResuObjeAreaID3 == 0 ? "" : bean.fdResuObjeArea3 + ";"%><%=bean.fdResuObjeAreaID4 == 0 ? "" : bean.fdResuObjeArea4 + ";"%><%=bean.fdResuObjeAreaID5 == 0 ? "" : bean.fdResuObjeArea5 + ";"%>%>" />
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;行&nbsp;&nbsp;&nbsp;&nbsp;业
        </th>
        <td>
            <a href="javascript:void(0);" id="Obje_Industry" class="btn28H" style="font-size: 12px;"
                title="<%=getIndustryName()%>" onclick="ChooseIndustry2(this,'ChooseIndustry2','Obje_IndustryID','Obje_IndustryName');return false;">
                <%=getIndustryName()%></a>
            <input type="hidden" id="Obje_IndustryID" name="Obje_IndustryID" value="<%=bean.fdResuObjeIndustryID1 == 0 ? "" : bean.fdResuObjeIndustryID1 + ";"%><%=bean.fdResuObjeIndustryID2 == 0 ? "" : bean.fdResuObjeIndustryID2 + ";"%><%=bean.fdResuObjeIndustryID3 == 0 ? "" : bean.fdResuObjeIndustryID3 + ";"%><%=bean.fdResuObjeIndustryID4 == 0 ? "" : bean.fdResuObjeIndustryID4 + ";"%><%=bean.fdResuObjeIndustryID5 == 0 ? "" : bean.fdResuObjeIndustryID5 + ";"%>" />
            <input type="hidden" id="Obje_IndustryName" name="Obje_IndustryName" value="<%=bean.fdResuObjeIndustryID1 == 0 ? "" : bean.fdResuObjeIndustry1 + ";"%><%=bean.fdResuObjeIndustryID2 == 0 ? "" : bean.fdResuObjeIndustry2 + ";"%><%=bean.fdResuObjeIndustryID3 == 0 ? "" : bean.fdResuObjeIndustry3 + ";"%><%=bean.fdResuObjeIndustryID4 == 0 ? "" : bean.fdResuObjeIndustry4 + ";"%><%=bean.fdResuObjeIndustryID5 == 0 ? "" : bean.fdResuObjeIndustry5 + ";"%>" />
        </td>
        <th scope="row">
            &nbsp;职&nbsp;&nbsp;&nbsp;&nbsp;能
        </th>
        <td>
            <a href="javascript:void(0);" id="Obje_FuncType" class="btn28H" style="font-size: 12px;"
                title="<%=getFuncTypeName() %>" onclick="choosePosition2(this,'ChoosePosition2','Obje_FuncTypeID','Obje_FuncTypeName');return false;">
                <%=getFuncTypeName() %></a>
            <input type="hidden" id="Obje_FuncTypeID" name="Obje_FuncTypeID" value="<%=bean.fdResuObjeFuncTypeID1 == 0 ? "" : bean.fdResuObjeFuncTypeID1 + ";"%><%=bean.fdResuObjeFuncTypeID2 == 0 ? "" : bean.fdResuObjeFuncTypeID2 + ";"%><%=bean.fdResuObjeFuncTypeID3 == 0 ? "" : bean.fdResuObjeFuncTypeID3 + ";"%><%=bean.fdResuObjeFuncTypeID4 == 0 ? "" : bean.fdResuObjeFuncTypeID4 + ";"%><%=bean.fdResuObjeFuncTypeID5 == 0 ? "" : bean.fdResuObjeFuncTypeID5 + ";"%>" />
            <input type="hidden" id="Obje_FuncTypeName" name="Obje_FuncTypeName" value="<%=bean.fdResuObjeFuncTypeID1 == 0 ? "" : bean.fdResuObjeFuncType1 + ";"%><%=bean.fdResuObjeFuncTypeID2 == 0 ? "" : bean.fdResuObjeFuncType2 + ";"%><%=bean.fdResuObjeFuncTypeID3 == 0 ? "" : bean.fdResuObjeFuncType3 + ";"%><%=bean.fdResuObjeFuncTypeID4 == 0 ? "" : bean.fdResuObjeFuncType4 + ";"%><%=bean.fdResuObjeFuncTypeID5 == 0 ? "" : bean.fdResuObjeFuncType5 + ";"%>" />
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;期望薪水
        </th>
        <td>
            <select id="Obje_Salery" name="Obje_Salery">
                <option value="0" <%=bean.fdResuObjeSalery==0?"selected=\"selected\"":"" %>>面议</option>
                <option value="1" <%=bean.fdResuObjeSalery==1?"selected=\"selected\"":"" %>>1500以下</option>
                <option value="2" <%=bean.fdResuObjeSalery==2?"selected=\"selected\"":"" %>>1500-1999</option>
                <option value="3" <%=bean.fdResuObjeSalery==3?"selected=\"selected\"":"" %>>2000-2999</option>
                <option value="4" <%=bean.fdResuObjeSalery==4?"selected=\"selected\"":"" %>>3000-4499</option>
                <option value="5" <%=bean.fdResuObjeSalery==5?"selected=\"selected\"":"" %>>4500-5999</option>
                <option value="6" <%=bean.fdResuObjeSalery==6?"selected=\"selected\"":"" %>>6000-7999</option>
                <option value="7" <%=bean.fdResuObjeSalery==7?"selected=\"selected\"":"" %>>8000-9999</option>
                <option value="8" <%=bean.fdResuObjeSalery==8?"selected=\"selected\"":"" %>>10000-14999</option>
                <option value="9" <%=bean.fdResuObjeSalery==9?"selected=\"selected\"":"" %>>15000-19999</option>
                <option value="10" <%=bean.fdResuObjeSalery==10?"selected=\"selected\"":"" %>>20000-29999</option>
                <option value="11" <%=bean.fdResuObjeSalery==11?"selected=\"selected\"":"" %>>30000-49999</option>
                <option value="12" <%=bean.fdResuObjeSalery==12?"selected=\"selected\"":"" %>>50000及以上</option>
            </select>
            /月
        </td>
        <th scope="row">
            &nbsp;到岗时间
        </th>
        <td>
            <select id="Obje_EntryTime" name="Obje_EntryTime">
                <option value="1" <%=bean.fdResuObjeEntryTime==1?"selected=\"selected\"":"" %>>即时</option>
                <option value="2" <%=bean.fdResuObjeEntryTime==2?"selected=\"selected\"":"" %>>一周以内</option>
                <option value="3" <%=bean.fdResuObjeEntryTime==3?"selected=\"selected\"":"" %>>一个月内</option>
                <option value="4" <%=bean.fdResuObjeEntryTime==4?"selected=\"selected\"":"" %>>1-3个月</option>
                <option value="5" <%=bean.fdResuObjeEntryTime==5?"selected=\"selected\"":"" %>>三个月后</option>
                <option value="6" <%=bean.fdResuObjeEntryTime==6?"selected=\"selected\"":"" %>>待定</option>
            </select>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;部&nbsp;&nbsp;&nbsp;&nbsp;门
        </th>
        <td>
            <input type="text" id="Obje_Department" name="Obje_Department" class="pwdinput" maxlength="20"
                value="<%=bean.fdResuObjeDepartment %>" />
        </td>
        <th scope="row">
            &nbsp;公司性质
        </th>
        <td>
            <select id="Obje_CompType" name="Obje_CompType">
                <option value="1" <%=bean.fdResuObjeCompType==1?"selected=\"selected\"":"" %>>外资(欧美)</option>
                <option value="2" <%=bean.fdResuObjeCompType==2?"selected=\"selected\"":"" %>>外资(非欧美)</option>
                <option value="3" <%=bean.fdResuObjeCompType==3?"selected=\"selected\"":"" %>>合资(欧美)</option>
                <option value="4" <%=bean.fdResuObjeCompType==4?"selected=\"selected\"":"" %>>合资(非欧美)</option>
                <option value="5" <%=bean.fdResuObjeCompType==5?"selected=\"selected\"":"" %>>国企</option>
                <option value="6" <%=bean.fdResuObjeCompType==6?"selected=\"selected\"":"" %>>民营公司</option>
                <option value="7" <%=bean.fdResuObjeCompType==7?"selected=\"selected\"":"" %>>外企代表处</option>
                <option value="8" <%=bean.fdResuObjeCompType==8?"selected=\"selected\"":"" %>>政府机关</option>
                <option value="9" <%=bean.fdResuObjeCompType==9?"selected=\"selected\"":"" %>>事业单位</option>
                <option value="10" <%=bean.fdResuObjeCompType==10?"selected=\"selected\"":"" %>>非盈利机构</option>
                <option value="11" <%=bean.fdResuObjeCompType==11?"selected=\"selected\"":"" %>>其它性质</option>
            </select>
        </td>
    </tr>
    <tr>
        <th scope="row">
        </th>
        <td colspan="3">
            <span class="tipW red hidden" id="errorMsg_Intro">输入错误。请控制在500个汉字以内！</span>
        </td>
    </tr>
    <tr>
        <th scope="row" valign="top">
            &nbsp;自我评价
        </th>
        <td colspan="3">
            <table width="486" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <textarea id="Obje_Intro" name="Obje_Intro" class="txtArea" style="width: 495px;"
                            onkeyup="str_limit('obje',this.value,'Obje_IntroLength')" onchange="str_limit('obje',this.value,'Obje_IntroLength')"><%=bean.fdResuObjeIntro%></textarea>
                    </td>
                </tr>
                <tr style="color: #999;">
                    <td>
                        <p class="lh20">
                            限500个中文字，输入您对自己的简短评价。请简明扼要的说明您最大的优势是什么，避免使 用一些空洞老套的话。</p>
                        <p class="lh20">
                            限500个中文字，已输入<span class="orange" id="Obje_IntroLength"><%=bean.fdResuObjeIntro.Length%></span>个字</p>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<div class="blank6px">
</div>
</form>
