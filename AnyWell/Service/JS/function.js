//获取Url参数
function requestParameter(paras) {
    var url = window.location.href;
    var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
    var paraObj = {}
    for (i = 0; j = paraString[i]; i++) {
        paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
    }
    var returnValue = paraObj[paras.toLowerCase()];
    if (typeof (returnValue) == "undefined") {
        return "";
    }
    else {
        return returnValue;
    }
}

function prev(num) {
    $("#regist_" + (num + 1)).hide();
    $("#regist_" + num).show();
    $(document).scrollTop($("#regist_" + num).offset().top);
}

function next(num) {
    $("#regist_" + (num - 1)).hide();
    $("#regist_" + num).show();
    $(document).scrollTop($("#regist_" + num).offset().top);
}

function checkForm1() {
    var error = false, error_top;
    var surname = $.trim($("#surname").val());
    var name = $.trim($("#name").val());
    var position = $.trim($("#position").val());
    var positionType = $("#positionType").val();
    var company = $.trim($("#company").val());
    var address = $.trim($("#address").val());
    var country = $("#country").val();
    var post = $.trim($("#post").val());
    var phohe = $.trim($("#phohe").val());
    var fax = $.trim($("#fax").val());
    var mobile = $.trim($("#mobile").val());
    var email = $.trim($("#email").val());
    var webSite = $.trim($("#webSite").val());

    $("#regist_1").find("[id^='error_']").hide();

    if (webSite.length > 0 && !isUrl(webSite)) {
        $("#error_webSite").show();
        error_top = "webSite";
        error = true;
    }

    if (email.length == 0) {
        $("#error_email_1").show();
        error_top = "email";
        error = true;
    } else if (!isEmail(email)) {
        $("#error_email_2").show();
        error_top = "email";
        error = true;
    }

    if (mobile.lenth > 0 && !isInt(mobile)) {
        $("#error_mobile").show();
        error_top = "mobile";
        error = true;
    }

    if (fax.lenth > 0 && !isInt(fax)) {
        $("#error_fax").show();
        error_top = "fax";
        error = true;
    }

    if (phohe.length == 0) {
        $("#error_phohe_1").show();
        error_top = "phohe";
        error = true;
    } else if (!isInt(phohe)) {
        $("#error_phohe_2").show();
        error_top = "phohe";
        error = true;
    }

    if (post.length == 0) {
        $("#error_post_1").show();
        error_top = "post";
        error = true;
    } else if (!isInt(post)) {
        $("#error_post_2").show();
        error_top = "post";
        error = true;
    }

    if (!country) {
        $("#error_country").show();
        error_top = "country";
        error = true;
    }

    if (address.length == 0) {
        $("#error_address").show();
        error_top = "address";
        error = true;
    }

    if (company.length == 0) {
        $("#error_company").show();
        error_top = "company";
        error = true;
    }

    if (!positionType) {
        $("#error_positionType").show();
        error_top = "positionType";
        error = true;
    }

    if (position.length == 0) {
        $("#error_position").show();
        error_top = "position";
        error = true;
    }

    if (name.length == 0) {
        $("#error_name").show();
        error_top = "name";
        error = true;
    }

    if (surname.length == 0) {
        $("#error_surname").show();
        error_top = "surname";
        error = true;
    }

    if (error) {
        $(document).scrollTop($("#" + error_top).offset().top);
    } else {
        next(2);
    }
}

function resetForm1() {
    $("input[name=appellation]:first").attr("checked", "checked");
    $("#surname").val('');
    $("#name").val('');
    $("#position").val('');
    $("#positionType").val('');
    $("#company").val('');
    $("#address").val('');
    $("#country").val('');
    $("#post").val('');
    $("#phohe").val('');
    $("#fax").val('');
    $("#mobile").val('');
    $("#email").val('');
    $("#webSite").val('');
}

function checkForm2() {
    var error = false, error_top;
    var business = $("input[name=business]:checked").val();
    var business_other = $.trim($("#business_other").val());
    var target1 = $("input[name=target1]:checked").val();
    var target1_other = $.trim($("#target1_other").val());
    var target2 = $("input[name=target2]:checked").val();
    var target3 = $("input[name=target3]:checked").val();
    var target3_other = $.trim($("#target3_other").val());
    var target4 = $("input[name=target4]:checked").val();
    var target5 = $("input[name=target5]:checked").val();
    var target5_other = $.trim($("#target5_other").val());
    var target6 = $("input[name=target6]:checked").val();
    var target6_other = $.trim($("#target6_other").val());
    var func = $("input[name=function]:checked").val();
    var function_other = $.trim($("#function_other").val());
    var purpose = $("input[name=purpose]:checked").val();
    var purpose_other = $.trim($("#purpose_other").val());
    var decision = $("input[name=decision]:checked").val();
    var from = $("input[name=from]:checked").val();
    var from_other = $.trim($("#from_other").val());
    var interest = $("input[name=interest]:checked").val();

    $("#regist_2").find("[id^='error_']").hide();

    if (!interest) {
        $("#error_interest").show();
        error_top = "error_interest";
        error = true;
    }

    if (!from) {
        $("#error_from_1").show();
        error_top = "error_from_1";
        error = true;
    } else if (from.indexOf('10') > -1 && from_other.length == 0) {
        $("#error_from_2").show();
        error_top = "error_from_2";
        error = true;
    }

    if (!decision) {
        $("#error_decision").show();
        error_top = "error_decision";
        error = true;
    }

    if (!purpose) {
        $("#error_purpose_1").show();
        error_top = "error_purpose_1";
        error = true;
    } else if (purpose.indexOf('7') > -1 && purpose_other.length == 0) {
        $("#error_purpose_2").show();
        error_top = "error_purpose_2";
        error = true;
    }

    if (!func) {
        $("#error_function_1").show();
        error_top = "error_function_1";
        error = true;
    } else if (func.indexOf('9') > -1 && function_other.length == 0) {
        $("#error_function_2").show();
        error_top = "error_function_2";
        error = true;
    }

    if (!target1 && !target2 && !target3 && !target4 && !target5 && !target6) {
        $("#error_Target_1").show();
        error_top = "error_Target_1";
        error = true;
    } else if ((target1 && target1.indexOf('9') > -1 && target1_other.length == 0)
        || (target3 && target3.indexOf('10') > -1 && target3_other.length == 0)
        || (target5 && target5.indexOf('7') > -1 && target5_other.length == 0)
        || (target6 && target6.indexOf('3') > -1 && target6_other.length == 0)) {
        $("#error_Target_2").show();
        error_top = "error_Target_2";
        error = true;
    }

    if (!business) {
        $("#error_business_1").show();
        error_top = "error_business_1";
        error = true;
    } else if (business == "10" && business_other.length == 0) {
        $("#error_business_2").show();
        error_top = "error_business_2";
        error = true;
    }

    if (error) {
        $(document).scrollTop($("#" + error_top).offset().top);
    } else {
        initForm3();
        next(3);
    }
}

function resetForm2() {
    $("input[name=business]:checked").attr("checked", "");
    $("#business_other").val("");
    $("input[name=target1]:checked").attr("checked", "");
    $("#target1_other").val("");
    $("input[name=target2]:checked").attr("checked", "");
    $("input[name=target3]:checked").attr("checked", "");
    $("#target3_other").val("");
    $("input[name=target4]:checked").attr("checked", "");
    $("input[name=target5]:checked").attr("checked", "");
    $("#target5_other").val("");
    $("input[name=target6]:checked").attr("checked", "");
    $("#target6_other").val("");
    $("input[name=function]:checked").attr("checked", "");
    $("#function_other").val("");
    $("input[name=purpose]:checked").attr("checked", "");
    $("#purpose_other").val("");
    $("input[name=decision]:checked").attr("checked", "");
    $("input[name=from]:checked").attr("checked", "");
    $("#from_other").val("");
    $("input[name=interest]:checked").attr("checked", "");
}

function initForm3() {
    var appellation = $("input[name=business]:checked").val();
    switch (appellation) {
        case "1":
            $("#view_Appellation").html("先生");
            break;
        case "2":
            $("#view_Appellation").html("小姐");
            break;
        case "3":
            $("#view_Appellation").html("女士");
            break;
        case "4":
            $("#view_Appellation").html("博士");
            break;
    }
    $("#view_Surname").html($.trim($("#surname").val()));
    $("#view_Name").html($.trim($("#name").val()));
    $("#view_Position").html($.trim($("#position").val()));
    var positionType = $("#positionType").val();
    switch (positionType) {
        case "1":
            $("#view_PositionType").html("高级管理层（执行总裁、总裁、企业法人）");
            break;
        case "2":
            $("#view_PositionType").html("董事，总经理，副经理");
            break;
        case "3":
            $("#view_PositionType").html("中级管理层（零售部经理，部门经理等）");
            break;
        case "4":
            $("#view_PositionType").html("经理（销售经理，市场部经理等）");
            break;
        case "5":
            $("#view_PositionType").html("采购部（产品部经理、一般买家）");
            break;
        case "6":
            $("#view_PositionType").html("其他");
            break;
    }
    $("#view_Company").html($.trim($("#company").val()));
    $("#view_Address").html($.trim($("#address").val()));
    $("#view_Post").html($.trim($("#post").val()));
    $("#view_Phone").html($.trim($("#phohe").val()));
    $("#view_Fax").html($.trim($("#fax").val()));
    $("#view_Mobile").html($.trim($("#mobile").val()));
    $("#view_Email").html($.trim($("#email").val()));
    $("#view_WebSite").html($.trim($("#webSite").val()));
}

function submit() {
    var options = {
        success: regist_Success
    };
    $("#regist_Save a").hide();
    $("#saving").css("display", "");
    $("#regist_Form").ajaxSubmit(options);
}

function regist_Success(responseText, statusText) {
    if (statusText == 'success') {
        if (responseText.substr(0, 6) == "error:") {
            alert(responseText.substr(6));
            $("#regist_Save a").css("display", "");
            $("#saving").hide();
        } else {
            $("#regist_4").html(responseText);
            next(4);
        }
    }
}

function isUrl(obj) {
    var url = /^[http:\/\/]*[A-Za-z0-9\-]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;
    if (url.test(obj)) {
        return true;
    }
}

function isEmail(obj) {
    var email = /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/;
    if (email.test(obj)) {
        return true;
    }
}

function isInt(obj) {
    if (obj == "") {
        return false;
    }
    slen = obj.length;
    for (i = 0; i < slen; i++) {
        cc = obj.charAt(i);
        if (cc < "0" || cc > "9") {
            return false;
        }
    }
    return true;
}