function addCookie(){　 // 加入收藏夹
    if (document.all) {
        window.external.addFavorite('http://www.thshcoop.com', '广州市天河区沙河供销合作社');
    } else if (window.sidebar) {
        window.sidebar.addPanel('广州市天河区沙河供销合作社', 'http://www.thshcoop.com', "");
    }
}   
  
function setHomepage(){　 // 设置首页   
    if (document.all){   
        document.body.style.behavior = 'url(#default#homepage)';   
        document.body.setHomePage('http://www.thshcoop.com');   
    }else if (window.sidebar){   
        if (window.netscape){   
            try {   
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");   
            }catch (e) {   
                alert("该操作被浏览器拒绝，如果想启用该功能，请在地址栏内输入 about:config,然后将项 signed.applets.codebase_principal_support 值该为true");   
            }   
        }   
        var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);   
        prefs.setCharPref('browser.startup.homepage', 'http://www.thshcoop.com');   
    }   
}

function selMenu(id) {  //设置菜单选中
    $("#menu i").each(function() {
        if ($(this).attr("id") == id) {
            $(this).addClass("cur");
        } else {
            $(this).removeClass("cur");
        }
    });
}

function changeFontSize(obj, Fsize) {   //字体设置
    var objParent = obj.parentNode;
    var aArray = objParent.getElementsByTagName("a");
    for (var i = 0; i < aArray.length; i++) {
        aArray[i].className = "";
    }
    obj.className = "cur";
    document.getElementById("ConDetail").className = "DetCon " + Fsize;
}

function setDate() {    //设置日期
    $("#date").html(new Date().toLocaleString() + ' 星期' + '日一二三四五六'.charAt(new Date().getDay()));
}