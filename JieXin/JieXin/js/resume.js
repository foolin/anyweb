var EDU_ACTIVE_ID, REW_ACTIVE_ID, POS_ACTIVE_ID, WORK_ACTIVE_ID, LANG_ACTIVE_ID, CERT_ACTIVE_ID;

function warnuser() {
//    if ($("form").length > 0) {
//        return true;
//    }
}

window.onbeforeunload = warnuser;

function upload() {
    showMsgBox('UploadPic', 538, 150);
}

function delphoto() {
    $("#imgPhoto").attr("src", "../images/img_personPhoto.png");
    $("#photo").val("");
}

function uploadPhoto() {
    $("#results").html("正在上传...").show().css("color", "red");
    $.ajaxFileUpload(
   {
       url: "PhotoUpload.aspx?type=1",
       secureuri: false,
       fileElementId: "filePhoto",
       dataType: 'script',
       success: function(data, status) {
           var r = data.toString();
           var msg = r.substring(2);
           if (r.substr(0, 1) == "0") {
               $('#results').html("上传成功!").css("color", "green");
               $("#imgPhoto").attr("src", msg);
               $("#photo").val(msg);
               closeWindow("UploadPic");
           }
           else {
               $('#results').html(r.substring(2)).css("color", "red");
           }
       },
       error: function(data, status, e) {
           $('#results').html('上传失败！').css("color", "red");
       }
   });
}

function object_toggle(obj) {
    $("#" + obj).toggle();
    $("#" + obj + "_up").toggle();
    $("#" + obj + "_down").toggle();
}

function info_save() {
    if (info_check()) {
        var options = {
            success: info_response
        };
        $("#info").find("#btn_info_save").val("正在保存");
        $("#Info_form").ajaxSubmit(options);
    }
}

function info_response(responseText, statusText) {
    if (statusText == 'success') {
        $("#info").html(responseText);
    }
}

function edu_save(edu_id) {
    if (edu_check(edu_id)) {
        var options = {
            success: edu_response
        };
        EDU_ACTIVE_ID = edu_id.replace("form_", "");
        $("#" + edu_id).find("#btn_edu_save").val("正在保存");
        $("#" + edu_id).ajaxSubmit(options);
    }
}

function edu_response(responseText, statusText) {
    if (statusText == 'success') {
        $("#" + EDU_ACTIVE_ID).html(responseText);
    }
}

function rew_save(rew_id) {
    if (rew_check(rew_id)) {
        var options = {
            success: rew_response
        };
        REW_ACTIVE_ID = rew_id.replace("form_", "");
        $("#" + rew_id).find("#btn_rew_save").val("正在保存");
        $("#" + rew_id).ajaxSubmit(options);
    }
}

function rew_response(responseText, statusText) {
    if (statusText == 'success') {
        $("#" + REW_ACTIVE_ID).html(responseText);
    }
}

function pos_save(pos_id) {
    if (pos_check(pos_id)) {
        var options = {
            success: pos_response
        };
        POS_ACTIVE_ID = pos_id.replace("form_", "");
        $("#" + pos_id).find("#btn_pos_save").val("正在保存");
        $("#" + pos_id).ajaxSubmit(options);
    }
}

function pos_response(responseText, statusText) {
    if (statusText == 'success') {
        $("#" + POS_ACTIVE_ID).html(responseText);
    }
}

function work_save(work_id) {
    if (work_check(work_id)) {
        var options = {
            success: work_response
        };
        WORK_ACTIVE_ID = work_id.replace("form_", "");
        $("#" + work_id).find("#btn_work_save").val("正在保存");
        $("#" + work_id).ajaxSubmit(options);
    }
}

function work_response(responseText, statusText) {
    if (statusText == 'success') {
        $("#" + WORK_ACTIVE_ID).html(responseText);
    }
}

function lang_save(lang_id) {
    if (lang_check(lang_id)) {
        var options = {
            success: lang_response
        };
        LANG_ACTIVE_ID = lang_id.replace("form_", "");
        $("#" + lang_id).find("#btn_lang_save").val("正在保存");
        $("#" + lang_id).ajaxSubmit(options);
    }
}

function lang_response(responseText, statusText) {
    if (statusText == 'success') {
        $("#" + LANG_ACTIVE_ID).html(responseText);
    }
}

function level_save(level_id) {
    if (level_check(level_id)) {
        var options = {
            success: level_response
        };
        $("#" + level_id).find("#btn_level_save").val("正在保存");
        $("#" + level_id).ajaxSubmit(options);
    }
}

function level_response(responseText, statusText) {
    if (statusText == 'success') {
        $("#level").html(responseText);
    }
}

function cert_save(cert_id) {
    if (cert_check(cert_id)) {
        var options = {
            success: cert_response
        };
        CERT_ACTIVE_ID = cert_id.replace("form_", "");
        $("#" + cert_id).find("#btn_cert_save").val("正在保存");
        $("#" + cert_id).ajaxSubmit(options);
    }
}

function cert_response(responseText, statusText) {
    if (statusText == 'success') {
        $("#" + CERT_ACTIVE_ID).html(responseText);
    }
}

//添加信息模块
function addinfo(info, resuid) {
    $("#" + info).parent().find("#btn_info_add").html("正在增加");
    switch (info) {
        case "edu":
            $.ajax({
                type: "GET",
                url: "/User/EduGet.aspx",
                cache: false,
                data: { id: resuid },
                success: function(result) {
                    $("#" + info).append(result);
                },
                error: function() {
                    alert("系统繁忙，请稍候再试！");
                },
                complete: function() {
                    $("#" + info).parent().find("#btn_info_add").html("继续添加");
                }
            });
            break;
        case "rew":
            $.ajax({
                type: "GET",
                url: "/User/RewardsGet.aspx",
                cache: false,
                data: { id: resuid },
                success: function(result) {
                    $("#" + info).append(result);
                },
                error: function() {
                    alert("系统繁忙，请稍候再试！");
                },
                complete: function() {
                    $("#" + info).parent().find("#btn_info_add").html("继续添加");
                }
            });
            break;
        case "pos":
            $.ajax({
                type: "GET",
                url: "/User/PositionGet.aspx",
                cache: false,
                data: { id: resuid },
                success: function(result) {
                    $("#" + info).append(result);
                },
                error: function() {
                    alert("系统繁忙，请稍候再试！");
                },
                complete: function() {
                    $("#" + info).parent().find("#btn_info_add").html("继续添加");
                }
            });
            break;
        case "work":
            $.ajax({
                type: "GET",
                url: "/User/WorkGet.aspx",
                cache: false,
                data: { id: resuid },
                success: function(result) {
                    $("#" + info).append(result);
                },
                error: function() {
                    alert("系统繁忙，请稍候再试！");
                },
                complete: function() {
                    $("#" + info).parent().find("#btn_info_add").html("继续添加");
                }
            });
            break;
        case "lang":
            $.ajax({
                type: "GET",
                url: "/User/LangGet.aspx",
                cache: false,
                data: { id: resuid },
                success: function(result) {
                    $("#" + info).append(result);
                },
                error: function() {
                    alert("系统繁忙，请稍候再试！");
                },
                complete: function() {
                    $("#" + info).parent().find("#btn_info_add").html("继续添加");
                }
            });
            break;
        case "cert":
            $.ajax({
                type: "GET",
                url: "/User/CertGet.aspx",
                cache: false,
                data: { id: resuid },
                success: function(result) {
                    $("#" + info).append(result);
                },
                error: function() {
                    alert("系统繁忙，请稍候再试！");
                },
                complete: function() {
                    $("#" + info).parent().find("#btn_info_add").html("继续添加");
                }
            });
            break;
    }
}

function editinfo(info, id, btnId, infoId) {
    $("#" + infoId).find("#" + btnId).val("正在修改");
    switch (info) {
        case "info":
            $.ajax({
                type: "GET",
                url: "/User/InfoEdit.aspx",
                cache: false,
                data: { id: id },
                success: function(result) {
                    $("#info").html(result);
                },
                error: function() {
                    $("#" + infoId).find("#" + btnId).val("修 改");
                    alert("系统繁忙，请稍候再试！");
                }
            });
            break;
        case "edu":
            $.ajax({
                type: "GET",
                url: "/User/EduEdit.aspx",
                cache: false,
                data: { eduid: id },
                success: function(result) {
                    $("#edu").find("#" + infoId).html(result);
                },
                error: function() {
                    $("#" + infoId).find("#" + btnId).val("修 改");
                    alert("系统繁忙，请稍候再试！");
                }
            });
            break;
        case "rew":
            $.ajax({
                type: "GET",
                url: "/User/RewardsEdit.aspx",
                cache: false,
                data: { rewid: id },
                success: function(result) {
                    $("#rew").find("#" + infoId).html(result);
                },
                error: function() {
                    $("#" + infoId).find("#" + btnId).val("修 改");
                    alert("系统繁忙，请稍候再试！");
                }
            });
            break;
        case "pos":
            $.ajax({
                type: "GET",
                url: "/User/PositionEdit.aspx",
                cache: false,
                data: { posid: id },
                success: function(result) {
                    $("#pos").find("#" + infoId).html(result);
                },
                error: function() {
                    $("#" + infoId).find("#" + btnId).val("修 改");
                    alert("系统繁忙，请稍候再试！");
                }
            });
            break;
        case "work":
            $.ajax({
                type: "GET",
                url: "/User/WorkEdit.aspx",
                cache: false,
                data: { workid: id },
                success: function(result) {
                    $("#work").find("#" + infoId).html(result);
                },
                error: function() {
                    $("#" + infoId).find("#" + btnId).val("修 改");
                    alert("系统繁忙，请稍候再试！");
                }
            });
            break;
        case "lang":
            $.ajax({
                type: "GET",
                url: "/User/LangEdit.aspx",
                cache: false,
                data: { langid: id },
                success: function(result) {
                    $("#lang").find("#" + infoId).html(result);
                },
                error: function() {
                    $("#" + infoId).find("#" + btnId).val("修 改");
                    alert("系统繁忙，请稍候再试！");
                }
            });
            break;
        case "level":
            $.ajax({
                type: "GET",
                url: "/User/LevelEdit.aspx",
                cache: false,
                data: { id: id },
                success: function(result) {
                    $("#level").html(result);
                },
                error: function() {
                    $("#" + infoId).find("#" + btnId).val("修 改");
                    alert("系统繁忙，请稍候再试！");
                }
            });
            break;
        case "cert":
            $.ajax({
                type: "GET",
                url: "/User/CertEdit.aspx",
                cache: false,
                data: { certid: id },
                success: function(result) {
                    $("#cert").find("#" + infoId).html(result);
                },
                error: function() {
                    $("#" + infoId).find("#" + btnId).val("修 改");
                    alert("系统繁忙，请稍候再试！");
                }
            });
            break;
    }
}

function delinfo(info, id, btnId, infoId) {
    if (!confirm("是否确认删除？")) {
        return;
    }
    $("#" + infoId).find("#" + btnId).val("正在删除");
    switch (info) {
        case "edu":
            $.ajax({
                type: "GET",
                url: "/User/EduDel.aspx",
                cache: false,
                data: { eduid: id },
                success: function(result) {
                    $("#edu").find("#" + infoId).html(result);
                },
                error: function() {
                    $("#" + infoId).find("#" + btnId).val("删 除");
                    alert("系统繁忙，请稍候再试！");
                }
            });
            break;
        case "rew":
            $.ajax({
                type: "GET",
                url: "/User/RewardsDel.aspx",
                cache: false,
                data: { rewid: id },
                success: function(result) {
                    $("#rew").find("#" + infoId).html(result);
                },
                error: function() {
                    $("#" + infoId).find("#" + btnId).val("删 除");
                    alert("系统繁忙，请稍候再试！");
                }
            });
            break;
        case "pos":
            $.ajax({
                type: "GET",
                url: "/User/PositionDel.aspx",
                cache: false,
                data: { posid: id },
                success: function(result) {
                    $("#pos").find("#" + infoId).html(result);
                },
                error: function() {
                    $("#" + infoId).find("#" + btnId).val("删 除");
                    alert("系统繁忙，请稍候再试！");
                }
            });
            break;
        case "work":
            $.ajax({
                type: "GET",
                url: "/User/WorkDel.aspx",
                cache: false,
                data: { workid: id },
                success: function(result) {
                    $("#work").find("#" + infoId).html(result);
                },
                error: function() {
                    $("#" + infoId).find("#" + btnId).val("删 除");
                    alert("系统繁忙，请稍候再试！");
                }
            });
            break;
        case "lang":
            $.ajax({
                type: "GET",
                url: "/User/LangDel.aspx",
                cache: false,
                data: { langid: id },
                success: function(result) {
                    $("#lang").find("#" + infoId).html(result);
                },
                error: function() {
                    $("#" + infoId).find("#" + btnId).val("删 除");
                    alert("系统繁忙，请稍候再试！");
                }
            });
            break;
        case "cert":
            $.ajax({
                type: "GET",
                url: "/User/CertDel.aspx",
                cache: false,
                data: { certid: id },
                success: function(result) {
                    $("#cert").find("#" + infoId).html(result);
                },
                error: function() {
                    $("#" + infoId).find("#" + btnId).val("删 除");
                    alert("系统繁忙，请稍候再试！");
                }
            });
            break;
    }
}

function info_check() {
    var info_id = "info";
    var mailValid = /^\w+([-+.]\w+)*@\w+([-.]\\w+)*\.\w+([-.]\w+)*$/;
    var err = true;
    $("#" + info_id).find("[id^='errorMsg_']").hide();
    if ($.trim($("#" + info_id).find("#userName").val()) == "") {
        $("#" + info_id).find("#errorMsg_Name").show();
        err = false;
    }
    if (!isValidDate($("#" + info_id).find("#BirYear").val(), $("#" + info_id).find("#BirMonth").val(), $("#" + info_id).find("#BirDay").val())) {
        $("#" + info_id).find("#errorMsg_Bir").show();
        err = false;
    }
    if ($("#" + info_id).find("#Exp").val() == 0) {
        $("#" + info_id).find("#errorMsg_Exp").show();
        err = false;
    }
    if ($("#" + info_id).find("#IdenID").val() == 0) {
        $("#" + info_id).find("#errorMsg_IdenID").show();
        err = false;
    }
    if ($.trim($("#" + info_id).find("#IdenNum").val()) == "") {
        $("#" + info_id).find("#errorMsg_IdenNum").show();
        err = false;
    }
    if ($.trim($("#" + info_id).find("#AddressID").val()) == "" || $.trim($("#" + info_id).find("#AddressID").val()) == "0" || $.trim($("#" + info_id).find("#Address").val()) == "") {
        $("#" + info_id).find("#errorMsg_Address").show();
        err = false;
    }
    if ($.trim($("#" + info_id).find("#email").val()) == "") {
        $("#" + info_id).find("#errorMsg_Email_1").show();
        err = false;
    } else if (!mailValid.test($.trim($("#" + info_id).find("#email").val()))) {
        $("#" + info_id).find("#errorMsg_Email_2").show();
        err = false;
    }
    if ($("#" + info_id).find("#CurrSitu").val() == 0) {
        $("#" + info_id).find("#errorMsg_CurrSitu").show();
        err = false;
    }
    if ($.trim($("#" + info_id).find("#Height").val()) != "" && !parseInt($.trim($("#" + info_id).find("#Height").val()))) {
        $("#" + info_id).find("#errorMsg_Height").show();
        err = false;
    }
    return err;
}

function edu_check(edu_id) {
    $("#" + edu_id).find("[id^='errorMsg_']").hide();
    var err = true;
    if ($("#" + edu_id).find("#Edu_FromYear").val() == "0" || $("#" + edu_id).find("#Edu_FromMonth").val() == "0" || ($("#" + edu_id).find("#Edu_ToYear").val() == "0" && $("#" + edu_id).find("#Edu_ToMonth").val() != "0") || ($("#" + edu_id).find("#Edu_ToYear").val() != "0" && $("#" + edu_id).find("#Edu_ToMonth").val() == "0")) {
        $("#" + edu_id).find("#errorMsg_Date_1").show();
        err = false;
    }
    if (err && $("#" + edu_id).find("#Edu_ToYear").val() != "0") {
        if (!DateCompare($("#" + edu_id).find("#Edu_FromYear").val(), $("#" + edu_id).find("#Edu_FromMonth").val(), $("#" + edu_id).find("#Edu_ToYear").val(), $("#" + edu_id).find("#Edu_ToMonth").val())) {
            $("#" + edu_id).find("#errorMsg_Date_2").show();
            err = false;
        }
    }
    if (!$.trim($("#" + edu_id).find("#Edu_School").val())) {
        $("#" + edu_id).find("#errorMsg_School").show();
        err = false;
    }
    if (($.trim($("#" + edu_id).find("#Edu_Degree").val()) == "0")) {
        $("#" + edu_id).find("#errorMsg_Degree").show();
        err = false;
    }
    var speciality = $.trim($("#" + edu_id).find("#Edu_SpecialityID").val());
    var specialityname = $.trim($("#" + edu_id).find("#Edu_Speciality").val());
    var otherspeciality = $.trim($("#" + edu_id).find("#Edu_OtherSpeciality").val());
    if ((speciality == '' || otherspeciality == '0' || specialityname == '') && (otherspeciality == '若无合适项，请在此填写' || otherspeciality == '')) {
        $("#" + edu_id).find("#errorMsg_Speciality").show();
        err = false;
    }
    if ($.trim($("#" + edu_id).find("#Edu_Intro").val()) && $.trim($("#" + edu_id).find("#Edu_Intro").val()).length > 2000) {
        $("#" + edu_id).find("#errorMsg_Intro").show();
        err = false;
    }
    return err;
}

function rew_check(rew_id) {
    $("#" + rew_id).find("[id^='errorMsg_']").hide();
    var err = true;
    if ($("#" + rew_id).find("#Rew_FromYear").val() == "0" || $("#" + rew_id).find("#Rew_FromMonth").val() == "0" || ($("#" + rew_id).find("#Rew_ToYear").val() == "0" && $("#" + rew_id).find("#Rew_ToMonth").val() != "0") || ($("#" + rew_id).find("#Rew_ToYear").val() != "0" && $("#" + rew_id).find("#Rew_ToMonth").val() == "0")) {
        $("#" + rew_id).find("#errorMsg_Date_1").show();
        err = false;
    }
    if (err && $("#" + rew_id).find("#Rew_ToYear").val() != "0") {
        if (!DateCompare($("#" + rew_id).find("#Rew_FromYear").val(), $("#" + rew_id).find("#Rew_FromMonth").val(), $("#" + rew_id).find("#Rew_ToYear").val(), $("#" + rew_id).find("#Rew_ToMonth").val())) {
            $("#" + rew_id).find("#errorMsg_Date_2").show();
            err = false;
        }
    }
    if (!$.trim($("#" + rew_id).find("#Rew_Name").val())) {
        $("#" + rew_id).find("#errorMsg_Name").show();
        err = false;
    }
    return err;
}

function pos_check(pos_id) {
    $("#" + pos_id).find("[id^='errorMsg_']").hide();
    var err = true;
    if ($("#" + pos_id).find("#Pos_FromYear").val() == "0" || $("#" + pos_id).find("#Pos_FromMonth").val() == "0" || ($("#" + pos_id).find("#Pos_ToYear").val() == "0" && $("#" + pos_id).find("#Pos_ToMonth").val() != "0") || ($("#" + pos_id).find("#Pos_ToYear").val() != "0" && $("#" + pos_id).find("#Pos_ToMonth").val() == "0")) {
        $("#" + pos_id).find("#errorMsg_Date_1").show();
        err = false;
    }
    if (err && $("#" + pos_id).find("#Pos_ToYear").val() != "0") {
        if (!DateCompare($("#" + pos_id).find("#Pos_FromYear").val(), $("#" + pos_id).find("#Pos_FromMonth").val(), $("#" + pos_id).find("#Pos_ToYear").val(), $("#" + pos_id).find("#Pos_ToMonth").val())) {
            $("#" + pos_id).find("#errorMsg_Date_2").show();
            err = false;
        }
    }
    if (!$.trim($("#" + pos_id).find("#Pos_Name").val())) {
        $("#" + pos_id).find("#errorMsg_Name").show();
        err = false;
    }
    if (!$.trim($("#" + pos_id).find("#Pos_Org").val())) {
        $("#" + pos_id).find("#errorMsg_Org").show();
        err = false;
    }
    if ($.trim($("#" + pos_id).find("#Pos_Intro").val()) && $.trim($("#" + pos_id).find("#Pos_Intro").val()).length > 2000) {
        $("#" + pos_id).find("#errorMsg_Intro").show();
        err = false;
    }
    return err;
}

function work_check(work_id) {
    $("#" + work_id).find("[id^='errorMsg_']").hide();
    var err = true;
    if ($("#" + work_id).find("#Work_FromYear").val() == "0" || $("#" + work_id).find("#Work_FromMonth").val() == "0" || ($("#" + work_id).find("#Work_ToYear").val() == "0" && $("#" + work_id).find("#Work_ToMonth").val() != "0") || ($("#" + work_id).find("#Work_ToYear").val() != "0" && $("#" + work_id).find("#Work_ToMonth").val() == "0")) {
        $("#" + work_id).find("#errorMsg_Date_1").show();
        err = false;
    }
    if (err && $("#" + work_id).find("#Work_ToYear").val() != "0") {
        if (!DateCompare($("#" + work_id).find("#Work_FromYear").val(), $("#" + work_id).find("#Work_FromMonth").val(), $("#" + work_id).find("#Work_ToYear").val(), $("#" + work_id).find("#Work_ToMonth").val())) {
            $("#" + work_id).find("#errorMsg_Date_2").show();
            err = false;
        }
    }
    if (!$.trim($("#" + work_id).find("#Work_Name").val())) {
        $("#" + work_id).find("#errorMsg_Name").show();
        err = false;
    }
    if ($.trim($("#" + work_id).find("#Work_IndustryID").val()) == "" || $.trim($("#" + work_id).find("#Work_IndustryID").val()) == "0" || $.trim($("#" + work_id).find("#Work_Industry").val()) == "") {
        $("#" + work_id).find("#errorMsg_Industry").show();
        err = false;
    }
    if (($.trim($("#" + work_id).find("#Work_Type").val()) == "0")) {
        $("#" + work_id).find("#errorMsg_Type").show();
        err = false;
    }
    if (!$.trim($("#" + work_id).find("#Work_Department").val())) {
        $("#" + work_id).find("#errorMsg_Department").show();
        err = false;
    }
    var jobid = $.trim($("#" + work_id).find("#Work_JobID").val());
    var job = $.trim($("#" + work_id).find("#Work_Job").val());
    var otherjob = $.trim($("#" + work_id).find("#Work_OtherJob").val());
    if ((jobid == '' || jobid == '0' || job == '') && (otherjob == '若无合适项，请在此填写' || otherjob == '')) {
        $("#" + work_id).find("#errorMsg_Job").show();
        err = false;
    }
    if (!$.trim($("#" + work_id).find("#Work_Intro").val())) {
        $("#" + work_id).find("#errorMsg_Intro_1").show();
        err = false;
    } else if ($.trim($("#" + work_id).find("#Work_Intro").val()).length > 2000) {
        $("#" + work_id).find("#errorMsg_Intro_2").show();
        err = false;
    }
    return err;
}

function lang_check(lang_id) {
    $("#" + lang_id).find("[id^='errorMsg_']").hide();
    var err = true;
    if (($("#" + lang_id).find("#Lang_Type").val() == "0")) {
        $("#" + lang_id).find("#errorMsg_Type").show();
        err = false;
    }
    return err;
}

function level_check(level_id) {
    $("#" + level_id).find("[id^='errorMsg_']").hide();
    var err = true;
    if (($("#" + level_id).find("#Level_EnLevel").val() == "0")) {
        $("#" + level_id).find("#errorMsg_EnLevel").show();
        err = false;
    }
    if ($.trim($("#" + level_id).find("#Level_TOEFL").val()) && !parseInt($.trim($("#" + level_id).find("#Level_TOEFL").val()))) {
        $("#" + level_id).find("#errorMsg_TOEFL").show();
        err = false;
    }
    if ($.trim($("#" + level_id).find("#Level_GRE").val()) && !parseInt($.trim($("#" + level_id).find("#Level_GRE").val()))) {
        $("#" + level_id).find("#errorMsg_GRE").show();
        err = false;
    }
    if ($.trim($("#" + level_id).find("#Level_GMAT").val()) && !parseInt($.trim($("#" + level_id).find("#Level_GMAT").val()))) {
        $("#" + level_id).find("#errorMsg_GMAT").show();
        err = false;
    }
    if ($.trim($("#" + level_id).find("#Level_IELTS").val()) && !parseInt($.trim($("#" + level_id).find("#Level_IELTS").val()))) {
        $("#" + level_id).find("#errorMsg_IELTS").show();
        err = false;
    }
    return err;
}

function cert_check(cert_id) {
    $("#" + cert_id).find("[id^='errorMsg_']").hide();
    var err = true;
    if ($("#" + cert_id).find("#Cert_Year").val() == 0 || $("#" + cert_id).find("#Cert_Month").val() == 0) {
        $("#" + cert_id).find("#errorMsg_Date").show();
        err = false;
    }
    if (!$.trim($("#" + cert_id).find("#Cert_Name").val())) {
        $("#" + cert_id).find("#errorMsg_Name").show();
        err = false;
    }
    if ($.trim($("#" + cert_id).find("#Cert_Scores").val()) && !parseInt($.trim($("#" + cert_id).find("#Cert_Scores").val()))) {
        $("#" + cert_id).find("#errorMsg_Scores").show();
        err = false;
    }
    return err;
}






//function editinfo(info, info_id, ReSumeID) {
//    var numbers = Math.random();
//    switch (info) {
//        case "Edu":
//            $.get("/User/EduEdit.aspx", { eduid: info_id, numbers: numbers }, function(result) {
//                $("#Edu_" + info_id).html(result);
//            });
//            break;
//        //        case "Awd":    
//        //            $.get(MYPATH + "/cv/in/Resume/AwdAction.php", { NextAction: "edit", AwardID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {    
//        //                $("#Awd_edit" + "_" + info_id).html(result);    
//        //            });    
//        //            break;    
//        //        case "Exp":    
//        //            $.get(MYPATH + "/cv/in/Resume/ExpAction.php", { NextAction: "edit", PracID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {    
//        //                $("#Exp_edit" + "_" + info_id).html(result);    
//        //            });    
//        //            break;    
//        //        case "Exp1":    
//        //            $.get(MYPATH + "/cv/in/Resume/Exp1Action.php", { NextAction: "edit", PracID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {    
//        //                $("#Exp1_edit" + "_" + info_id).html(result);    
//        //            });    
//        //            break;    
//        //        case "Work":    
//        //            $.get(MYPATH + "/cv/in/Resume/WorkAction.php", { NextAction: "edit", WorkID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {    
//        //                $("#Work_edit" + "_" + info_id).html(result);    
//        //            });    
//        //            break;    
//        //        case "Lan":    
//        //            $.get(MYPATH + "/cv/in/Resume/LanAction.php", { NextAction: "edit", LangID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {    
//        //                $("#Lan_edit" + "_" + info_id).html(result);    
//        //            });    
//        //            break;    
//        //        case "IT":    
//        //            $.get(MYPATH + "/cv/in/Resume/ITAction.php", { NextAction: "edit", ITID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {    
//        //                $("#IT_edit" + "_" + info_id).html(result);    
//        //            });    
//        //            break;    
//        //        case "Tra":    
//        //            $.get(MYPATH + "/cv/in/Resume/TraAction.php", { NextAction: "edit", TrainID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {    
//        //                $("#Tra_edit" + "_" + info_id).html(result);    
//        //            });    
//        //            break;    
//        //        case "Prj":    
//        //            $.get(MYPATH + "/cv/in/Resume/PrjAction.php", { NextAction: "edit", ProjectID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {    
//        //                $("#Prj_edit" + "_" + info_id).html(result);    
//        //            });    
//        //            break;    
//        //        case "Cert":    
//        //            $.get(MYPATH + "/cv/in/Resume/CertAction.php", { NextAction: "edit", CertID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {    
//        //                $("#Cert_edit" + "_" + info_id).html(result);    
//        //            });    
//        //            break;    
//        //        case "Attach":    
//        //            $.get(MYPATH + "/cv/in/Resume/AttachAction.php", { NextAction: "edit", AttachID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {    

//        //                $("#Attach_edit" + "_" + info_id).html(result);    
//        //            });    
//        //            break;    
//        //        case "Misc":    
//        //            $.get(MYPATH + "/cv/in/Resume/MiscAction.php", { NextAction: "edit", MiscID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {    
//        //                $("#Misc_edit" + "_" + info_id).html(result);    
//        //            });    
//        //            break;    
//    }
//}

////教育经历数据验证
//function Edu_check(info_id) {
//    $("#" + info_id).find("[id^='errorMsg_']").hide();
//    var err = true;
//    if ($("#" + info_id).find("#FromYear").val() == "0" || $("#" + info_id).find("#FromMonth").val() == "0" || ($("#" + info_id).find("#ToYear").val() == "0" && $("#" + info_id).find("#ToMonth").val() != "0") || ($("#" + info_id).find("#ToYear").val() != "0" && $("#" + info_id).find("#ToMonth").val() == "0")) {
//        $("#" + info_id).find("#errorMsg_2_1").show();
//        err = false;
//    }
//    if (err && $("#" + info_id).find("#ToYear").val() != "0") {
//        if (!DateCompare($("#" + info_id).find("#FromYear").val(), $("#" + info_id).find("#FromMonth").val(), $("#" + info_id).find("#ToYear").val(), $("#" + info_id).find("#ToMonth").val())) {
//            $("#" + info_id).find("#errorMsg_2_2").show();
//            err = false;
//        }
//    }
//    if ($.trim($("#" + info_id).find("#SchoolName").val()) == "" || $.trim($("#" + info_id).find("#SchoolName").val()).length > 100) {
//        $("#" + info_id).find("#errorMsg_2_3").show();
//        err = false;
//    }
//    if (($.trim($("#" + info_id).find("#Degree").val()) == "0") || ("" == $.trim($("#" + info_id).find("#Degree").val()))) {
//        $("#" + info_id).find("#errorMsg_2_5").show();
//        err = false;
//    }
//    var SubMajor = $.trim($("#" + info_id).find("#SubMajor").val());
//    var MoreMajor = $.trim($("#" + info_id).find("#MoreMajor").val());
//    if ((SubMajor == '' || SubMajor == '0') && (MoreMajor == '若无合适选项请在此处填写' || MoreMajor == '')) {
//        $("#" + info_id).find("#errorMsg_2_4").show();
//        err = false;
//    }
//    return err;
//} 