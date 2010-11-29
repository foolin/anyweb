<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ResumeExport.ascx.cs"
    Inherits="Admin_Control_ResumeExport" %>
<style>
    body
    {
        margin: 0;
        padding: 0;
        font-family: "宋体" ,Arial, Helvetica, sans-serif;
        font-size: 12px;
        color: #000;
    }
    div, form, p, img, ul, li, ol, dl, dt, dd
    {
        margin: 0;
        padding: 0;
        border: 0;
    }
    li
    {
        list-style: none;
    }
    h1, h2, h3, h4, h5
    {
        font-size: 100%;
        font-weight: normal;
        margin: 0;
        padding: 0;
    }
    img
    {
        border: 0px;
        vertical-align: middle;
    }
    table
    {
        border-collapse: collapse;
        border-spacing: 0;
    }
    input, select, img, textarea
    {
        vertical-align: middle;
        font-size: 12px;
    }
    /*----default link-----*/a
    {
        text-decoration: none;
    }
    a:hover
    {
    }
    /*----text color-----*/.black, .black a
    {
        color: #000;
        text-decoration: none;
    }
    .black a:hover
    {
        color: #000;
        text-decoration: underline;
    }
    .white, .white a
    {
        color: #FFF;
        text-decoration: none;
    }
    .white a:hover
    {
        color: #FFF;
    }
    .red, .red a
    {
        color: #FD0100;
        text-decoration: none;
    }
    .red a:hover
    {
        color: #FD0100;
    }
    .blue, .blue a
    {
        color: #0166b4;
        text-decoration: none;
    }
    .blue a:hover
    {
        color: #0066CC;
    }
    .dblue, dblue a
    {
        color: #0066CC;
    }
    .dblue a:hover
    {
        color: #00366F;
    }
    .lblue, .lblue a
    {
        color: #0483ad;
        text-decoration: none;
    }
    .lblue a:hover
    {
        color: #0483ad;
    }
    .gray, .gray a
    {
        color: #666666;
        text-decoration: none;
    }
    .gray a:hover
    {
        color: #666666;
        text-decoration: none;
    }
    .green, .green a
    {
        color: #59A901;
        text-decoration: none;
    }
    .green a:hover
    {
        color: #59A901;
    }
    .orange, .orange a
    {
        color: #FB8402;
        text-decoration: none;
    }
    .orange a:hover
    {
        color: #FB8402;
    }
    .dorange, dorange a
    {
        color: #F04B22;
    }
    .dorange a:hover
    {
        color: #F04B22;
    }
    .brown, .brown a
    {
        color: #EB6100;
        text-decoration: none;
    }
    .brown a:hover
    {
        color: #EB6100;
    }
    .yellow, .yellow a
    {
        color: #e4ff00;
        text-decoration: none;
    }
    .yellow a:hover
    {
        color: #e4ff00;
    }
    /*----font-weight-----*/.fbold
    {
        font-weight: bold;
    }
    .fnormal
    {
        font-weight: normal;
    }
    /*----font-size-----*/.f9
    {
        font-size: 9px;
    }
    .f12
    {
        font-size: 12px;
    }
    .f13
    {
        font-size: 13px;
    }
    .f14
    {
        font-size: 14px;
    }
    /*----line-height-----*/.lh18
    {
        line-height: 18px;
    }
    .lh20
    {
        line-height: 20px;
    }
    .lh22
    {
        line-height: 22px;
    }
    .lh24
    {
        line-height: 24px;
    }
    .lh26
    {
        line-height: 26px;
    }
    .lh30
    {
        line-height: 30px;
    }
    /*----word direction-----*/.tl
    {
        text-align: left;
    }
    .tc
    {
        text-align: center;
    }
    .tr
    {
        text-align: right;
    }
    /*----float direction-----*/.left
    {
        float: left;
    }
    .right
    {
        float: right;
    }
    .clear
    {
        width: 1px;
        line-height: 1px;
        height: 0;
        visibility: hidden;
        clear: both;
        font-size: 1px;
    }
    /*----layer state-----*/.hidden
    {
        display: none;
    }
    .block
    {
        display: block;
    }
    .inline
    {
        display: inline;
    }
    .flowhidden
    {
        overflow: hidden;
    }
    .borderBtm
    {
        border-bottom: 1px dashed #e4e4e4;
    }
    /*----font decoration-----*/.unline, .unline a
    {
        text-decoration: none;
    }
    .line, .line a
    {
        text-decoration: underline;
    }
    /*----clear space-----*/.noborder
    {
        border: 0px;
    }
    .nomar
    {
        margin: 0;
    }
    .nopad
    {
        padding: 0;
    }
    .nobg
    {
        background-image: none;
    }
    /*--------blank gap---------*/.blank5px, .blank6px, .blank8px, .blank10px, .blank12px, .blank15px, .blank20px, .blank30px
    {
        display: block;
        clear: both;
        font-size: 1px;
        overflow: hidden;
    }
    .blank5px
    {
        height: 5px;
        line-height: 5px;
    }
    .blank6px
    {
        height: 6px;
        line-height: 6px;
    }
    .blank8px
    {
        height: 8px;
        line-height: 8px;
    }
    .blank10px
    {
        height: 10px;
        line-height: 10px;
    }
    .blank12px
    {
        height: 12px;
        line-height: 12px;
    }
    .blank15px
    {
        height: 15px;
        line-height: 15px;
    }
    .blank20px
    {
        height: 20px;
        line-height: 20px;
    }
    .blank30px
    {
        height: 30px;
        line-height: 30px;
    }
    /*--------padding space 1em---------*/.padt1em
    {
        padding-top: 1em;
    }
    .padr1em
    {
        padding-right: 1em;
    }
    .padb1em
    {
        padding-bottom: 1em;
    }
    .padl1em
    {
        padding-left: 1em;
    }
    /*--------position---------*/.relate
    {
        position: relative;
    }
    .absolute
    {
        position: absolute;
    }
    /**/.ohtxt
    {
        text-indent: -9999px;
        overflow: hidden;
    }
    .btn96_35
    {
        width: 96px;
        height: 35px;
        display: inline-block;
        background: url(../images/btn_96x35.gif) no-repeat;
        text-align: center;
        line-height: 35px;
        color: #fff;
        font-size: 14px;
        border: 0;
        font-weight: bold;
        cursor: pointer;
    }
    /*resume*/.resume
    {
        width: 658px;
        margin: 14px auto;
    }
    .resume .topBtn
    {
        height: 48px;
    }
    .resume .resBox
    {
    }
    .resume .resBox .greenLine
    {
        height: 2px;
        overflow: hidden;
    }
    .resume .lineTop
    {
        background: url(../images/bg_line_t.png) no-repeat;
    }
    .resume .lineBtm
    {
        background: url(../images/bg_line_b.png) no-repeat;
    }
    .resume .resBox .Content
    {
        height: auto !important;
        min-height: 1552px;
        _height: 1552px;
    }
    .resume .resBox h1
    {
        height: 63px;
        font-size: 28px;
        line-height: 63px;
        padding-left: 27px;
        font-weight: bold;
    }
    .resume .brief
    {
        width: 610px;
        border: 1px solid #88B4E0;
        margin: 12px auto;
        background-color: #F5F9FD;
        padding: 10px 10px 0px;
    }
    .resume .brief table
    {
        line-height: 26px;
    }
    .resume .tit
    {
        height: 26px;
        border-bottom: 4px solid #CCCCCC;
        clear: both;
        margin-bottom: 5px;
    }
    .resume .tit h2
    {
        position: relative;
        width: 70px;
        margin-bottom: -4px;
        border-bottom: 4px solid #88B4E0;
        line-height: 26px;
        font-weight: bold;
        font-size: 14px;
        color: #3183AD;
    }
    .resume .resColumn
    {
        width: 610px;
        margin: 0px auto;
    }
    .resume .item
    {
        overflow: hidden;
        margin-bottom: 8px;
    }
    .resume .underLine
    {
        border-bottom: 1px solid #CCC;
        margin-bottom: 6px;
        padding-top: 5px;
    }
</style>
<div class=3D"resume">
    <div class=3D"resBox">
        <div class=3D"Content">
            <table width=3D"100%" border=3D"0" cellspacing=3D"0" cellpadding=3D"0" style=3D"border: 2px solid #3183AD">
                <tr>
                    <td>
                        <table width=3D"100%" border=3D"0" cellspacing=3D"0" cellpadding=3D"0" style=3D"border-bottom: 1px dashed #CCCCCC;
                            background-color: #F4F8FD; line-height: 63px;">
                            <tr>
                                <td>
                                    <h1>
                                        <%=bean.fdResuUserName %></h1>
                                </td>
                                <td width=3D"90">
                                    <span style=3D"display: block; float: right; margin: 10px 26px 0px 0px;">
                                        <img height=3D"44" border=3D"0" width=3D"76" src=3D"/images/logo_jiexin.png"></span>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div class=3D"brief">
                            <table width=3D"100%" border=3D"0" cellspacing=3D"0" cellpadding=3D"0">
                                <tr>
                                    <td colspan=3D"2">
                                        <table width=3D"100%" border=3D"0" cellspacing=3D"0" cellpadding=3D"0">
                                            <tr>
                                                <td class=3D"fbold lblue" colspan=3D"2">
                                                    <%=getExpString( bean.fdResuExperience )%>工作经验 |
                                                    <%=bean.fdResuSex == 0 ? "男" : "女"%>
                                                    |
                                                    <%=DateTime.Now.Year-bean.fdResuBirthday.Year %>岁（<%=bean.fdResuBirthday.ToString("yyyy年MM月dd日") %>）
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    居住地：<%=bean.fdResuAddress %>
                                                </td>
                                                <td>
                                                    户 口：<%=bean.fdResuHouseAddress %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan=3D"2">
                                                    电 话：
                                                    <%=getPhone() %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan=3D"2" class=3D"lblue">
                                                    Email：<span class=3D"line"><a href=3D"mailto:<%=bean.fdResuEmail %>"><%=bean.fdResuEmail %></a></span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width=3D"90" rowspan=3D"4" class=3D"tc gray">
                                        <img src=3D"<%=bean.fdResuPhoto==""?"../images/img_personPhoto.png":bean.fdResuPhoto %>"
                                            width=3D"90" height=3D"110" /><br />
                                        ID:<%=bean.fdResuID %>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class=3D"resColumn">
                            <%if( bean.EducationList.Count > 0 )
                              { %>
                            <div class=3D"item">
                                <div class=3D"tit">
                                    <h2>
                                        最高学历</h2>
                                </div>
                                <div class=3D"lh24">
                                    <%if( education != null )
                                      { %>
                                    <table width=3D"100%" border=3D"0" cellspacing=3D"0" cellpadding=3D"0">
                                        <tr>
                                            <td width=3D"10%">
                                                学 历：
                                            </td>
                                            <td width=3D"90%">
                                                <%=getDegreeString( education.fdEducDegree )%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                专 业：
                                            </td>
                                            <td>
                                                <%=education.fdEducSpecialityID == 0 ? education.fdEducOtherSpecialty : education.fdEducSpeciality%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                学 校：
                                            </td>
                                            <td>
                                                <%=education.fdEducSchool %>
                                            </td>
                                        </tr>
                                    </table>
                                    <%} %>
                                </div>
                            </div>
                            <%} %>
                            <%if( bean.fdResuObjeIntro.Length > 0 )
                              { %>
                            <div class=3D"item">
                                <div class=3D"tit">
                                    <h2>
                                        自我评价</h2>
                                </div>
                                <div class=3D"lh24">
                                    <table width=3D"100%" border=3D"0" cellspacing=3D"0" cellpadding=3D"0">
                                        <tr>
                                            <td>
                                                <%=bean.fdResuObjeIntro.Replace( "\n", "<br />" )%>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <%} %>
                            <div class=3D"item">
                                <div class=3D"tit">
                                    <h2>
                                        求职意向</h2>
                                </div>
                                <div class=3D"lh24">
                                    <table width=3D"100%" border=3D"0" cellspacing=3D"0" cellpadding=3D"0">
                                        <tr>
                                            <td width=3D"15%">
                                                到岗时间：
                                            </td>
                                            <td width=3D"90%">
                                                <%=getEntryTimeString( bean.fdResuObjeEntryTime )%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                工作性质：
                                            </td>
                                            <td>
                                                <%=getObjeType( bean.fdResuObjeType )%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                希望行业：
                                            </td>
                                            <td>
                                                <%=bean.fdResuObjeIndustryID1 == 0 ? "" : bean.fdResuObjeIndustry1 + ";"%>
                                                <%=bean.fdResuObjeIndustryID2 == 0 ? "" : bean.fdResuObjeIndustry2 + ";"%>
                                                <%=bean.fdResuObjeIndustryID3 == 0 ? "" : bean.fdResuObjeIndustry3 + ";"%>
                                                <%=bean.fdResuObjeIndustryID4 == 0 ? "" : bean.fdResuObjeIndustry4 + ";"%>
                                                <%=bean.fdResuObjeIndustryID5 == 0 ? "" : bean.fdResuObjeIndustry5 + ";"%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                目标地点：
                                            </td>
                                            <td>
                                                <%=bean.fdResuObjeAreaID1 == 0 ? "" : bean.fdResuObjeArea1 + ";"%>
                                                <%=bean.fdResuObjeAreaID2 == 0 ? "" : bean.fdResuObjeArea2 + ";"%>
                                                <%=bean.fdResuObjeAreaID3 == 0 ? "" : bean.fdResuObjeArea3 + ";"%>
                                                <%=bean.fdResuObjeAreaID4 == 0 ? "" : bean.fdResuObjeArea4 + ";"%>
                                                <%=bean.fdResuObjeAreaID5 == 0 ? "" : bean.fdResuObjeArea5 + ";"%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                期望月薪：
                                            </td>
                                            <td>
                                                <%=bean.fdResuObjeSalery == 0 ? "面议" : getObjeSaleryString( bean.fdResuObjeSalery ) + "/月"%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                目标职能：
                                            </td>
                                            <td>
                                                <%=bean.fdResuObjeFuncTypeID1 == 0 ? "" : bean.fdResuObjeFuncType1 + ";"%>
                                                <%=bean.fdResuObjeFuncTypeID2 == 0 ? "" : bean.fdResuObjeFuncType2 + ";"%>
                                                <%=bean.fdResuObjeFuncTypeID3 == 0 ? "" : bean.fdResuObjeFuncType3 + ";"%>
                                                <%=bean.fdResuObjeFuncTypeID4 == 0 ? "" : bean.fdResuObjeFuncType4 + ";"%>
                                                <%=bean.fdResuObjeFuncTypeID5 == 0 ? "" : bean.fdResuObjeFuncType5 + ";"%>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <%if( bean.WorkList.Count > 0 )
                              { %>
                            <div class=3D"item">
                                <div class=3D"tit">
                                    <h2>
                                        工作经验
                                    </h2>
                                </div>
                                <div class=3D"lh24">
                                    <asp:Repeater ID="repWork" runat="server">
                                        <ItemTemplate>
                                            <table width=3D"100%" border=3D"0" cellspacing=3D"0" cellpadding=3D"0">
                                                <%#Container.ItemIndex==0?"":"<tr><td colspan=3D\"2\" class=3D\"underLine\"></td></tr>" %>
                                                <tr>
                                                    <td colspan=3D"2">
                                                        <%#Eval( "fdWorkBegin", "{0:yyyy/M}" )%>--<%#( ( DateTime ) Eval( "fdWorkEnd" ) ).Year != 1900 ? Eval( "fdWorkEnd", "{0:yyyy/M}" ) : "至今"%>：<%#Eval( "fdWorkName" )%><%#( int ) Eval( "fdWorkDimension" ) == 0 ? "" : "(" + getDimensionString( ( int ) Eval( "fdWorkDimension" ) ) + ")"%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width=3D"26%">
                                                        所属行业：
                                                    </td>
                                                    <td width=3D"74%">
                                                        <%#Eval( "fdWorkIndustry" )%>
                                                    </td>
                                                </tr>
                                                <tr class=3D"fbold">
                                                    <td>
                                                        <%#Eval( "fdWorkDepartment" )%>
                                                    </td>
                                                    <td>
                                                        <%#( int ) Eval( "fdWorkJobID" ) == 0 ? Eval( "fdWorkJobID" ) : Eval( "fdWorkJob" )%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan=3D"2">
                                                        <%#((string)Eval( "fdWorkIntro" )).Replace("\n","<br />")%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <%} %>
                            <%if( bean.AwardList.Count > 0 )
                              { %>
                            <div class=3D"item">
                                <div class=3D"tit">
                                    <h2>
                                        所获奖项
                                    </h2>
                                </div>
                                <div class=3D"lh24">
                                    <asp:Repeater ID="repAwar" runat="server">
                                        <ItemTemplate>
                                            <table width=3D"100%" border=3D"0" cellspacing=3D"0" cellpadding=3D"0">
                                                <%#Container.ItemIndex==0?"":"<tr><td colspan=3D\"2\" class=3D\"underLine\"></td></tr>" %>
                                                <tr>
                                                    <td width=3D"23%">
                                                        <%#( ( DateTime ) Eval( "fdAwarDate" ) ).Year != 1900 ? Eval( "fdAwarDate", "{0:yyyy年MM月}" ) : ""%>
                                                    </td>
                                                    <td width=3D"77%">
                                                        <%#Eval( "fdAwarName" )%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <%} %>
                            <%if( bean.EducationList.Count > 0 )
                              { %>
                            <div class=3D"item">
                                <div class=3D"tit">
                                    <h2>
                                        教育经历</h2>
                                </div>
                                <div class=3D"lh24">
                                    <asp:Repeater ID="repEdu" runat="server">
                                        <ItemTemplate>
                                            <table width=3D"100%" border=3D"0" cellspacing=3D"0" cellpadding=3D"0">
                                                <%#Container.ItemIndex==0?"":"<tr><td colspan=3D\"4\" class=3D\"underLine\"></td></tr>" %>
                                                <tr>
                                                    <td width=3D"27%">
                                                        <%#Eval("fdEducBegin","{0:yyyy/M}") %>--<%#( ( DateTime ) Eval( "fdEducEnd" ) ).Year != 1900?Eval("fdEducEnd","{0:yyyy/M}"):"至今"%>
                                                    </td>
                                                    <td width=3D"25%">
                                                        <%#Eval("fdEducSchool") %>
                                                    </td>
                                                    <td width=3D"38%">
                                                        <%#( int ) Eval( "fdEducSpecialityID" ) == 0 ? Eval( "fdEducOtherSpecialty" ) : Eval( "fdEducSpeciality" )%>
                                                    </td>
                                                    <td width=3D"10%">
                                                        <%#getDegreeString( (int)Eval( "fdEducDegree" ) )%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan=3D"4">
                                                        <%#( ( string ) Eval( "fdEducIntro" ) ).Replace( "\n", "<br />" )%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <%} %>
                            <%if( bean.RewardList.Count > 0 )
                              { %>
                            <div class=3D"item">
                                <div class=3D"tit">
                                    <h2>
                                        所获奖励
                                    </h2>
                                </div>
                                <div class=3D"lh24">
                                    <asp:Repeater ID="repRew" runat="server">
                                        <ItemTemplate>
                                            <table width=3D"100%" border=3D"0" cellspacing=3D"0" cellpadding=3D"0">
                                                <%#Container.ItemIndex==0?"":"<tr><td colspan=3D\"2\" class=3D\"underLine\"></td></tr>" %>
                                                <tr>
                                                    <td width=3D"23%">
                                                        <%#Eval( "fdRewaBegin", "{0:yyyy/M}" )%>--<%#( ( DateTime ) Eval( "fdRewaEnd" ) ).Year != 1900 ? Eval( "fdRewaEnd", "{0:yyyy/M}" ) : "至今"%>
                                                    </td>
                                                    <td width=3D"77%">
                                                        <%#Eval("fdRewaName") %>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <%} %>
                            <%if( bean.PositionList.Count > 0 )
                              { %>
                            <div class=3D"item">
                                <div class=3D"tit">
                                    <h2>
                                        职务
                                    </h2>
                                </div>
                                <div class=3D"lh24">
                                    <asp:Repeater ID="repPos" runat="server">
                                        <ItemTemplate>
                                            <table width=3D"100%" border=3D"0" cellspacing=3D"0" cellpadding=3D"0">
                                                <%#Container.ItemIndex==0?"":"<tr><td colspan=3D\"3\" class=3D\"underLine\"></td></tr>" %>
                                                <tr>
                                                    <td width=3D"23%">
                                                        <%#Eval( "fdPosiBegin", "{0:yyyy/M}" )%>--<%#( ( DateTime ) Eval( "fdPosiEnd" ) ).Year != 1900 ? Eval( "fdPosiEnd", "{0:yyyy/M}" ) : "至今"%>
                                                    </td>
                                                    <td width=3D"47%">
                                                        <%#Eval( "fdPosiName" )%>
                                                    </td>
                                                    <td width=3D"30%">
                                                        <%#Eval( "fdPosiOrg" )%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan=3D"3">
                                                        <%#( ( string ) Eval( "fdPosiIntro" ) ).Replace( "\n", "<br />" )%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <%} %>
                            <%if( bean.CertList.Count > 0 )
                              { %>
                            <div class=3D"item">
                                <div class=3D"tit">
                                    <h2>
                                        证书</h2>
                                </div>
                                <div class=3D"lh24">
                                    <asp:Repeater ID="repCert" runat="server">
                                        <ItemTemplate>
                                            <table width=3D"100%" border=3D"0" cellspacing=3D"0" cellpadding=3D"0">
                                                <%#Container.ItemIndex==0?"":"<tr><td colspan=3D\"3\" class=3D\"underLine\"></td></tr>" %>
                                                <tr>
                                                    <td width=3D"23%">
                                                        <%#Eval( "fdCertDate", "{0:yyyy/MM}" )%>
                                                    </td>
                                                    <td width=3D"47%">
                                                        <%#Eval( "fdCertName" )%>
                                                    </td>
                                                    <td width=3D"30%">
                                                        <%#( int ) Eval( "fdCertScore" ) == 0 ? "" : Eval( "fdCertScore" )+"分"%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <%} %>
                            <div class=3D"item">
                                <div class=3D"tit">
                                    <h2>
                                        语言能力
                                    </h2>
                                </div>
                                <div class=3D"lh24">
                                    <table width=3D"100%" border=3D"0" cellspacing=3D"0" cellpadding=3D"0">
                                        <tr>
                                            <td width=3D"34%">
                                                英语等级：<%=getEnLevelString( bean.fdResuEnLevel )%>
                                            </td>
                                            <td width=3D"33%">
                                                TOEFL：<%=bean.fdResuTOEFL == 0 ? "" : bean.fdResuTOEFL.ToString()%>
                                            </td>
                                            <td width=3D"33%">
                                                GRE：<%=bean.fdResuGRE == 0 ? "" : bean.fdResuGRE.ToString()%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width=3D"34%">
                                                日语等级：<%=getJpLevelString( bean.fdResuJpLevel )%>
                                            </td>
                                            <td width=3D"33%">
                                                GMAT：<%=bean.fdResuGMAT == 0 ? "" : bean.fdResuGMAT.ToString()%>
                                            </td>
                                            <td width=3D"33%">
                                                IELTS：<%=bean.fdResuIELTS == 0 ? "" : bean.fdResuIELTS.ToString()%>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Repeater ID="repLan" runat="server">
                                        <ItemTemplate>
                                            <table width=3D"100%" border=3D"0" cellspacing=3D"0" cellpadding=3D"0">
                                                <tr><td colspan=3D"4" class=3D"underLine"></td></tr>
                                                <tr>
                                                    <td width=3D"20%">
                                                        语言类别：
                                                    </td>
                                                    <td width=3D"30%">
                                                        <%#getLangTypeString( ( int ) Eval( "fdLangType" ) )%>
                                                    </td>
                                                    <td width=3D"20%">
                                                        掌握程度：
                                                    </td>
                                                    <td width=3D"30%">
                                                        <%#getLangAbilityString( ( int ) Eval( "fdLangMaster" ) )%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width=3D"20%">
                                                        读写能力：
                                                    </td>
                                                    <td width=3D"30%">
                                                        <%#getLangAbilityString( ( int ) Eval( "fdLangRWAbility" ) )%>
                                                    </td>
                                                    <td width=3D"20%">
                                                        听说能力：
                                                    </td>
                                                    <td width=3D"30%">
                                                        <%#getLangAbilityString( ( int ) Eval( "fdLangLiAbility" ) )%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <%if( bean.SkillList.Count > 0 )
                              { %>
                            <div class=3D"item">
                                <div class=3D"tit">
                                    <h2>
                                        技能
                                    </h2>
                                </div>
                                <div class=3D"lh24">
                                    <asp:Repeater ID="repSkill" runat="server">
                                        <ItemTemplate>
                                            <table width=3D"100%" border=3D"0" cellspacing=3D"0" cellpadding=3D"0">
                                                <%#Container.ItemIndex==0?"":"<tr><td colspan=3D\"3\" class=3D\"underLine\"></td></tr>" %>
                                                <tr>
                                                    <td width=3D"34%">
                                                        <%#Eval( "fdSkilName" )%>
                                                    </td>
                                                    <td width=3D"33%">
                                                        掌握程度：<%#getSkillLevelString( ( int ) Eval( "fdSkilLevel" ) )%>
                                                    </td>
                                                    <td width=3D"33%">
                                                        时间：<%#Eval( "fdSkilMonth" )%>月
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <%} %>
                            <div class=3D"blank5px">
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
