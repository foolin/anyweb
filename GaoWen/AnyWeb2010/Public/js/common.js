//设为首页
function SetHome(obj) {
    var url = "http://gwsme.com/";
    try {
        obj.style.behavior = 'url(#default#homepage)'; obj.setHomePage(url);
    }
    catch (e) {
        if (window.netscape) {
            try {
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
            }
            catch (e) {
                alert("此操作被浏览器拒绝！\n请在浏览器地址栏输入“about:config”并回车\n然后将 [signed.applets.codebase_principal_support]的值设置为'true',双击即可。");
            }
            var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
            prefs.setCharPref('browser.startup.homepage', url);
        }
    }
}
//添加到收藏夹
function AddFavorite() {
    var url = "http://gwsme.com/";
    try {
        window.external.addFavorite(url, "高闻顾问有限公司");
    }
    catch (e) {
        try {
            window.sidebar.addPanel("高闻顾问有限公司", url, "");
        }
        catch (e) {
            alert("加入收藏失败，请使用Ctrl+D进行添加");
        }
    }
}
function search() {
    if ($("#keyword").val()) {
        window.location = "search.aspx?keyword=" + encodeURI($.trim($("#keyword").val()));
    } else {
        alert("请输入搜索关键词！");
    }
}
$(document).ready(function() {
    $("#keyword").keydown(function(event) {
        if (event.keyCode == 13) {
            search();
        }
    });
}); 