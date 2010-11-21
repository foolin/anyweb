<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ObjeSave.aspx.cs" Inherits="User_ObjeSave" %>

<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
            &nbsp;工作类型
        </th>
        <td>
            <span class="right">&nbsp;&nbsp;<input type="button" class="btn60_28" id="btn_obje_save"
                value="修 改" onclick="editinfo('obje',<%=bean.fdResuID %>,'btn_obje_save','obje')" /></span>
            <%=getObjeType( bean.fdResuObjeType )%>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;地&nbsp;&nbsp;&nbsp;&nbsp;点
        </th>
        <td>
            <%=bean.fdResuObjeAreaID1 == 0 ? "" : bean.fdResuObjeArea1 + ";"%>
            <%=bean.fdResuObjeAreaID2 == 0 ? "" : bean.fdResuObjeArea2 + ";"%>
            <%=bean.fdResuObjeAreaID3 == 0 ? "" : bean.fdResuObjeArea3 + ";"%>
            <%=bean.fdResuObjeAreaID4 == 0 ? "" : bean.fdResuObjeArea4 + ";"%>
            <%=bean.fdResuObjeAreaID5 == 0 ? "" : bean.fdResuObjeArea5 + ";"%>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;行&nbsp;&nbsp;&nbsp;&nbsp;业
        </th>
        <td>
            <%=bean.fdResuObjeIndustryID1 == 0 ? "" : bean.fdResuObjeIndustry1 + ";"%>
            <%=bean.fdResuObjeIndustryID2 == 0 ? "" : bean.fdResuObjeIndustry2 + ";"%>
            <%=bean.fdResuObjeIndustryID3 == 0 ? "" : bean.fdResuObjeIndustry3 + ";"%>
            <%=bean.fdResuObjeIndustryID4 == 0 ? "" : bean.fdResuObjeIndustry4 + ";"%>
            <%=bean.fdResuObjeIndustryID5 == 0 ? "" : bean.fdResuObjeIndustry5 + ";"%>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;职&nbsp;&nbsp;&nbsp;&nbsp;能
        </th>
        <td>
            <%=bean.fdResuObjeFuncTypeID1 == 0 ? "" : bean.fdResuObjeFuncType1 + ";"%>
            <%=bean.fdResuObjeFuncTypeID2 == 0 ? "" : bean.fdResuObjeFuncType2 + ";"%>
            <%=bean.fdResuObjeFuncTypeID3 == 0 ? "" : bean.fdResuObjeFuncType3 + ";"%>
            <%=bean.fdResuObjeFuncTypeID4 == 0 ? "" : bean.fdResuObjeFuncType4 + ";"%>
            <%=bean.fdResuObjeFuncTypeID5 == 0 ? "" : bean.fdResuObjeFuncType5 + ";"%>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;期望薪水
        </th>
        <td>
            <%=bean.fdResuObjeSalery == 0 ? "面议" : getObjeSaleryString( bean.fdResuObjeSalery ) + "/月"%>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;到岗时间
        </th>
        <td>
            <%=getEntryTimeString( bean.fdResuObjeEntryTime )%>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;部&nbsp;&nbsp;&nbsp;&nbsp;门
        </th>
        <td>
            <%=bean.fdResuObjeDepartment %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;公司性质
        </th>
        <td>
            <%=getCompanyTypeString(bean.fdResuObjeCompType)%>
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
                        <%=bean.fdResuObjeIntro.Replace( "\n", "<br />" )%>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<div class="blank6px">
</div>
