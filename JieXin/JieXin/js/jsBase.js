function openwin(url, name, width, height, left, top) {
    window.open(url, name, "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,width=" + width + ",height=" + height + ",left=" + left + ",top=" + top);
}

function openwinscroll(url, name, width, height, left, top) {
    window.open(url, name, "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,width=" + width + ",height=" + height + ",left=" + left + ",top=" + top);
}

//判断是否是Email
function isEmail(str) {
    var regu = "^(([0-9a-zA-Z]+)|([0-9a-zA-Z]+[_.0-9a-zA-Z-]*))@([a-zA-Z0-9-]+[.])+([a-zA-Z]{2}|net|com|gov|mil|org|edu|int|name|asia)$";
    var re = new RegExp(regu);
    if (str.search(re) == -1) {
        return false;
    }
    else {
        return true;
    }
}

// 判断是否含有大写字母
function hasCapital(str) {
    var result = str.match(/^.*[A-Z]+.*$/);
    if (result == null) return false;
    return true;
}

// 判断是否含有小写字母
function hasLowercase(str) {
    var result = str.match(/^.*[a-z]+.*$/);
    if (result == null) return false;
    return true;
}

// 判断是否含有数字
function hasNumber(str) {
    var result = str.match(/^.*[0-9]+.*$/);
    if (result == null) return false;
    return true;
}

// 判断是否含有其他字符
function hasOther(str) {
    var result = str.match(/^.*[^0-9A-Za-z]+.*$/);
    if (result == null) return false;
    return true;
}

function isValidDate(year, month, day) {
    year = parseInt(year, 10);
    month = parseInt(month, 10);
    day = parseInt(day, 10);

    if ((month == 4) || (month == 6) || (month == 9) || (month == 11)) {
        if ((day < 1) || (day > 30)) {
            return (false);
        }
    }
    else {
        if (month != 2) {
            if ((day < 1) || (day > 31)) {
                return (false);
            }
        }
        else { // month == 2
            if ((year % 100) != 0 && (year % 4 == 0) || (year % 100) == 0 && (year % 400) == 0) {
                if ((day < 1) || day > 29) {
                    return (false);
                }
            }
            else {
                if ((day < 1) || day > 28) {
                    return (false);
                }
            }
        }
    }
    return (true);
}

function isValidDate_e(year, month, day) {
    year = parseInt(year, 10);
    month = parseInt(month, 10);
    day = parseInt(day, 10);

    if ((month == 4) || (month == 6) || (month == 9) || (month == 11)) {
        if ((day < 1) || (day > 30)) {
            return (false);
        }
    }
    else {
        if (month != 2) {
            if ((day < 1) || (day > 31)) {
                return (false);
            }
        }
        else { // month == 2
            if ((year % 100) != 0 && (year % 4 == 0) || (year % 100) == 0 && (year % 400) == 0) {
                if (day > 29) {
                    return (false);
                }
            }
            else {
                if (day > 28) {
                    return (false);
                }
            }
        }
    }
    return (true);
}

function DateCompare(YearFrom, MonthFrom, YearTo, MonthTo) {
    YearFrom = parseInt(YearFrom, 10);
    MonthFrom = parseInt(MonthFrom, 10);
    YearTo = parseInt(YearTo, 10);
    MonthTo = parseInt(MonthTo, 10);

    if (YearFrom > YearTo)
    { return false; }
    else {
        if (YearFrom == YearTo) {
            if (MonthFrom > MonthTo)
                return false;
        }
    }
    return true;
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

function EncodeUrl(city, address, searchdomain, lonlat) {
    src = searchdomain + '/jobsearch/tranToMap.php?city=' + encodeURIComponent(city) + '&address=' + encodeURIComponent(address) + '&lonlat=' + lonlat;
    window.open(src, 'ShowMap', 'width=800,height=480,top=50, left=50,resizable=yes');
}

function codehtml(str) {
    var s = "";
    if (str.length == 0) return "";
    for (var i = 0; i < str.length; i++) {
        switch (str.substr(i, 1)) {
            case "<": s += "&lt;"; break;
            case ">": s += "&gt;"; break;
            case "&": s += "&amp;"; break;
            case "   ": s += "&nbsp;"; break;
            case "\'": s += "&#39;"; break;
            case "\"": s += "&quot;"; break;
            case "\n": s += "<br>"; break;
            default: s += str.substr(i, 1); break;
        }
    }
    return s;
}

function copyToClipboard(txt) {
    if (window.clipboardData) {
        window.clipboardData.clearData();
        window.clipboardData.setData("text", txt);
    } else if (navigator.userAgent.indexOf("Opera") != -1) {
        window.location = txt;
    } else if (window.netscape) {
        try {
            netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
        } catch (e) {
            alert("被浏览器拒绝！\n请在浏览器地址栏输入'about:config'并回车\n然后将'signed.applets.codebase_principal_support'设置为'true'");
            return;
        }
        var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
        if (!clip) return;
        var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
        if (!trans) return;
        trans.addDataFlavor('text/unicode');
        var str = new Object();
        var len = new Object();
        str = Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);
        var copytext = txt;
        str.data = copytext;
        trans.setTransferData("text/unicode", str, copytext.length * 2);
        var clipid = Components.interfaces.nsIClipboard;
        if (!clip) return false;
        clip.setData(trans, null, clipid.kGlobalClipboard);
        alert("复制成功")
    }
}