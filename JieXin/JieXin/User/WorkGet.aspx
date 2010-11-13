<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkGet.aspx.cs" Inherits="User_WorkGet" %>

<div id="work_<%=workID %>">
    <form action="/User/WorkSave.aspx?id=<%=QS("id") %>&workid=<%=workID %>&type=add"
    id="work_form_<%=workID %>" method="post">
    <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <th scope="row">
            </th>
            <td colspan="3">
                <span class="tipW red hidden" id="errorMsg_Date_1">请选择时间！</span> <span class="tipW red hidden"
                    id="errorMsg_Date_2">结束时间不能小于起始时间！</span>
            </td>
        </tr>
        <tr>
            <th scope="row">
                <span class="orange">*</span>时&nbsp;&nbsp;&nbsp;&nbsp;间
            </th>
            <td colspan="3">
                <span class="right">
                    <input type="button" id="btn_work_del" class="btn60_28_gray" value="删 除" onclick="delinfo('work',<%=workID %>,'btn_work_del','work_<%=workID %>')" />
                    &nbsp;&nbsp;<input type="button" id="btn_work_save" class="btn60_28" value="保 存"
                        onclick="work_save('work_form_<%=workID %>')" /></span>
                <select id="Work_FromYear" name="Work_FromYear">
                    <option selected="selected" value="0">年</option>
                    <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                      { %>
                    <option value="<%=i%>">
                        <%=i%></option>
                    <%} %>
                </select>
                <select id="Work_FromMonth" name="Work_FromMonth">
                    <option selected="selected" value="0">月</option>
                    <%for( int i = 1; i <= 12; i++ )
                      { %>
                    <option value="<%=i%>">
                        <%=i%></option>
                    <%} %>
                </select>
                到
                <select id="Work_ToYear" name="Work_ToYear">
                    <option selected="selected" value="0">年</option>
                    <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                      { %>
                    <option value="<%=i%>">
                        <%=i%></option>
                    <%} %>
                </select>
                <select id="Work_ToMonth" name="Work_ToMonth">
                    <option selected="selected" value="0">月</option>
                    <%for( int i = 1; i <= 12; i++ )
                      { %>
                    <option value="<%=i%>">
                        <%=i%></option>
                    <%} %>
                </select>
                <span class="lgray">(后两项不填表示至今)</span>
            </td>
        </tr>
        <tr>
            <th scope="row">
            </th>
            <td>
                <span class="tipW red hidden" id="errorMsg_Name">公司名称不能为空！</span>
            </td>
            <th scope="row">
            </th>
            <td>
                <span class="tipW red hidden" id="errorMsg_Industry">请选择行业！</span>
            </td>
        </tr>
        <tr>
            <th scope="row">
                <span class="orange">*</span>公&nbsp;&nbsp;&nbsp;&nbsp;司
            </th>
            <td>
                <input type="text" id="Work_Name" name="Work_Name" class="pwdinput" maxlength="50" />
            </td>
            <th scope="row">
                <span class="orange">*</span>行&nbsp;&nbsp;&nbsp;&nbsp;业
            </th>
            <td>
                <a href="javascript:void(0);" id="place" class="btn28H" style="font-size: 12px;">选择/修改</a>
                <input type="hidden" id="Work_IndustryID" name="Work_IndustryID" value="1000001" />
                <input type="hidden" id="Work_Industry" name="Work_Industry" value="计算机软件" />
            </td>
        </tr>
        <tr>
            <th scope="row">
            </th>
            <td>
            </td>
            <th scope="row">
            </th>
            <td>
                <span class="tipW red hidden" id="errorMsg_Type">请选择公司性质！</span>
            </td>
        </tr>
        <tr>
            <th scope="row">
                &nbsp;公司规模
            </th>
            <td>
                <select id="Work_Dimension" name="Work_Dimension">
                    <option value="0">请选择公司规模</option>
                    <option value="1">少于50人</option>
                    <option value="2">50-150人</option>
                    <option value="3">150-500人</option>
                    <option value="4">500人以上</option>
                </select>
            </td>
            <th scope="row">
                <span class="orange">*</span>公司性质
            </th>
            <td>
                <select id="Work_Type" name="Work_Type">
                    <option value="0">请选择公司性质</option>
                    <option value="1">外资(欧美)</option>
                    <option value="2">外资(非欧美)</option>
                    <option value="3">合资(欧美)</option>
                    <option value="4">合资(非欧美)</option>
                    <option value="5">国企</option>
                    <option value="6">民营公司</option>
                    <option value="7">外企代表处</option>
                    <option value="8">政府机关</option>
                    <option value="9">事业单位</option>
                    <option value="10">非盈利机构</option>
                    <option value="11">其它性质</option>
                </select>
            </td>
        </tr>
        <tr>
            <th scope="row">
            </th>
            <td>
                <span class="tipW red hidden" id="errorMsg_Department">部门不能为空！</span>
            </td>
            <th scope="row">
            </th>
            <td>
                <span class="tipW red hidden" id="errorMsg_Job">请选择或者手动填写职位（限20个汉字）！</span>
            </td>
        </tr>
        <tr>
            <th scope="row">
                <span class="orange">*</span>部&nbsp;&nbsp;&nbsp;&nbsp;门
            </th>
            <td>
                <input type="text" id="Work_Department" name="Work_Department" class="pwdinput" maxlength="20" />
            </td>
            <th scope="row">
                <span class="orange">*</span>职&nbsp;&nbsp;&nbsp;&nbsp;位
            </th>
            <td>
                <a href="javascript:void(0);" id="place" class="btn28H" style="font-size: 12px;">选择/修改</a>
                <input type="text" id="Work_OtherJob" name="Work_OtherJob" class="pwdinput" value="若无合适项，请在此填写"
                    style="color: #999;" onclick="if('若无合适项，请在此填写'==this.value){this.value='';this.style.color='#000';}"
                    onblur="if(this.value==''){this.value = '若无合适项，请在此填写';this.style.color='#999';}" />
                <input type="hidden" id="Work_JobID" name="Work_JobID" />
                <input type="hidden" id="Work_Job" name="Work_Job" />
            </td>
        </tr>
        <tr>
            <th scope="row">
            </th>
            <td colspan="3">
                <span class="tipW red hidden" id="errorMsg_Intro_1">工作描述不能为空！</span> <span class="tipW red hidden"
                    id="errorMsg_Intro_2">输入错误。请控制在2000个汉字以内！</span>
            </td>
        </tr>
        <tr>
            <th scope="row" valign="top">
                <span class="orange">*</span>工作描述
            </th>
            <td colspan="3">
                <table width="486" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="2">
                            <textarea id="Work_Intro" name="Work_Intro" class="txtArea" style="width: 495px;"
                                onkeyup="str_limit('work_<%=workID %>',this.value,'Work_IntroLength')" onchange="str_limit('work_<%=workID %>',this.value,'Work_IntroLength')"></textarea>
                        </td>
                    </tr>
                    <tr style="color: #999;">
                        <td width="295">
                            请详细描述您的职责范围、工作任务以及取得的成绩等
                        </td>
                        <td align="right" width="174">
                            限2000个中文字，已输入<span class="orange" id="Work_IntroLength">0</span>个字
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <th scope="row">
                海外工作经历
            </th>
            <td>
                <input type="radio" name="Work_IsOverSeas" value="0" checked="checked" />是
                <input type="radio" value="1" name="Work_IsOverSeas" />否
            </td>
            <th scope="row">
            </th>
            <td>
            </td>
        </tr>
    </table>
    <div class="blank12px">
    </div>
    </form>
</div>
