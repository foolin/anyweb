//添加信息模块
function addinfo(info_id, resu_id) {
    var numbers = Math.random();
    $.get("/User/" + info_id + "Get.aspx", { id: resu_id, numbers: numbers }, function(result) {
        $("#" + info_id).append(result);
    });
}

function editinfo(info, info_id, ReSumeID) {
    var numbers = Math.random();
    switch (info) {
        case "Edu":
            $.get("/User/EduEdit.aspx", { eduid: info_id, numbers: numbers }, function(result) {
                $("#Edu_" + info_id).html(result);
            });
            break;
//        case "Awd":
//            $.get(MYPATH + "/cv/in/Resume/AwdAction.php", { NextAction: "edit", AwardID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {
//                $("#Awd_edit" + "_" + info_id).html(result);
//            });
//            break;
//        case "Exp":
//            $.get(MYPATH + "/cv/in/Resume/ExpAction.php", { NextAction: "edit", PracID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {
//                $("#Exp_edit" + "_" + info_id).html(result);
//            });
//            break;
//        case "Exp1":
//            $.get(MYPATH + "/cv/in/Resume/Exp1Action.php", { NextAction: "edit", PracID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {
//                $("#Exp1_edit" + "_" + info_id).html(result);
//            });
//            break;
//        case "Work":
//            $.get(MYPATH + "/cv/in/Resume/WorkAction.php", { NextAction: "edit", WorkID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {
//                $("#Work_edit" + "_" + info_id).html(result);
//            });
//            break;
//        case "Lan":
//            $.get(MYPATH + "/cv/in/Resume/LanAction.php", { NextAction: "edit", LangID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {
//                $("#Lan_edit" + "_" + info_id).html(result);
//            });
//            break;
//        case "IT":
//            $.get(MYPATH + "/cv/in/Resume/ITAction.php", { NextAction: "edit", ITID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {
//                $("#IT_edit" + "_" + info_id).html(result);
//            });
//            break;
//        case "Tra":
//            $.get(MYPATH + "/cv/in/Resume/TraAction.php", { NextAction: "edit", TrainID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {
//                $("#Tra_edit" + "_" + info_id).html(result);
//            });
//            break;
//        case "Prj":
//            $.get(MYPATH + "/cv/in/Resume/PrjAction.php", { NextAction: "edit", ProjectID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {
//                $("#Prj_edit" + "_" + info_id).html(result);
//            });
//            break;
//        case "Cert":
//            $.get(MYPATH + "/cv/in/Resume/CertAction.php", { NextAction: "edit", CertID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {
//                $("#Cert_edit" + "_" + info_id).html(result);
//            });
//            break;
//        case "Attach":
//            $.get(MYPATH + "/cv/in/Resume/AttachAction.php", { NextAction: "edit", AttachID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {

//                $("#Attach_edit" + "_" + info_id).html(result);
//            });
//            break;
//        case "Misc":
//            $.get(MYPATH + "/cv/in/Resume/MiscAction.php", { NextAction: "edit", MiscID: info_id, show_num: show_num, ReSumeID: $(".rew_top").find("#ReSumeID").val(), isEnglish: $(".rew_top").find("#isEnglish").val(), numbers: numbers }, function(result) {
//                $("#Misc_edit" + "_" + info_id).html(result);
//            });
//            break;
    }
}

//保存教育经历
function Edu_save(info_id) {
    if (Edu_check(info_id)) {
        var options = {
            success: EduResponse
        };
        $("#active").val(info_id.replace("form_", ""));
        $("#" + info_id).ajaxSubmit(options);
    }
}

function EduResponse(responseText, statusText) {
    if (statusText == 'success') {
        var info_id = $("#active").val();
        $("#" + info_id).html(responseText);
    }
}

//教育经历数据验证
function Edu_check(info_id) {
    $("#" + info_id).find("[id^='errorMsg_']").hide();
    var err = true;
    if ($("#" + info_id).find("#FromYear").val() == "0" || $("#" + info_id).find("#FromMonth").val() == "0" || ($("#" + info_id).find("#ToYear").val() == "0" && $("#" + info_id).find("#ToMonth").val() != "0") || ($("#" + info_id).find("#ToYear").val() != "0" && $("#" + info_id).find("#ToMonth").val() == "0")) {
        $("#" + info_id).find("#errorMsg_2_1").show();
        err = false;
    }
    if (err && $("#" + info_id).find("#ToYear").val() != "0") {
        if (!DateCompare($("#" + info_id).find("#FromYear").val(), $("#" + info_id).find("#FromMonth").val(), $("#" + info_id).find("#ToYear").val(), $("#" + info_id).find("#ToMonth").val())) {
            $("#" + info_id).find("#errorMsg_2_2").show();
            err = false;
        }
    }
    if ($.trim($("#" + info_id).find("#SchoolName").val()) == "" || $.trim($("#" + info_id).find("#SchoolName").val()).length > 100) {
        $("#" + info_id).find("#errorMsg_2_3").show();
        err = false;
    }
    if (($.trim($("#" + info_id).find("#Degree").val()) == "0") || ("" == $.trim($("#" + info_id).find("#Degree").val()))) {
        $("#" + info_id).find("#errorMsg_2_5").show();
        err = false;
    }
    var SubMajor = $.trim($("#" + info_id).find("#SubMajor").val());
    var MoreMajor = $.trim($("#" + info_id).find("#MoreMajor").val());
    if ((SubMajor == '' || SubMajor == '0') && (MoreMajor == '若无合适选项请在此处填写' || MoreMajor == '')) {
        $("#" + info_id).find("#errorMsg_2_4").show();
        err = false;
    }
    return err;
} 