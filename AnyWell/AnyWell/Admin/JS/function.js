function $$(obj) {
    return document.getElementById(obj);
}

var isIE = (document.all) ? true : false;

/*---------------- 主界面 --------------------------*/
//初始化iframe高度
function initFrame() {
    $("#left").height(document.documentElement.clientHeight - 58);
    $("#mainFrame").height(document.documentElement.clientHeight - 58);
}

//初始化内容区高度
function initContent() {
    $("#Content").height(document.documentElement.clientHeight - 32);
}

/*---------------- 导航栏 --------------------------*/
function initMenu() {
    $.ajax({
        type: "GET",
        url: "Ajax/GetMenu.aspx",
        cache: false,
        success: function(xml) {
            $(xml).find("DropMenuItem[id=0]>DropMenuItem").each(function() {
                var mi = menu.addItem(new menu.MenuItem($(this).attr("id"), $(this).attr("name"), "", "", true));
                if ($(this).attr("id") > 10) {
                    initSystemMenu(mi, this);
                } else {
                    initDropMenu(mi, this);
                }
            });
            menu.init(document.getElementById("mainmenu"));
        }
    });
}

function initDropMenu(menuItem, xmlItem) {
    $(xmlItem).children().each(function() {
        if ($(this).children().length == 0) {
            menuItem.addItem(new menu.MenuItem($(this).attr("id"), $(this).attr("name"), $(this).attr("url"), $(this).attr("target")));
        } else {
            var mi = menuItem.addItem(new menu.MenuItem($(this).attr("id"), $(this).attr("name")));
            initDropMenu(mi, this);
        }
        if ($(this).attr("separator") == "true") {
            menuItem.addItem(new menu.Separator());
        }
    });
}

function initSystemMenu(menuItem, xmlItem) {
    $(xmlItem).children().each(function() {
        if ($(this).children().length == 0) {
            menuItem.addItem(new menu.MenuItem($(this).attr("id"), $(this).attr("name"), "SysIndex.aspx?mid=" + $(this).attr("id"), "sys"));
        } else {
            var mi = menuItem.addItem(new menu.MenuItem($(this).attr("id"), $(this).attr("name")));
            initSystemMenu(mi, this);
        }
        if ($(this).attr("separator") == "true") {
            menuItem.addItem(new menu.Separator());
        }
    });
}

/*---------------- 中间弹出层 --------------------------*/
//显示对话层
function goPopupUrl(width, height, url) {
    $("#popupDiv").width(width);
    $("#popupDiv").height(height);
    window.top.popup.location = url;
    loadPopup();
}

//初始化对话层
function loadPopup(width, height) {
    $("#popupDiv").width(width);
    $("#popupDiv").height(height);
    $("#backgroundPopup").css("opacity", "0.4");
    $("#backgroundPopup").fadeIn("fast");
    $("#popupDiv").fadeIn("fast");
    popupStatus = 1;
    centerPopup();
}

//弹出对话层
function centerPopup() {
    var windowWidth = document.documentElement.clientWidth;
    var windowHeight = document.documentElement.clientHeight;
    var popupHeight = $("#popupDiv").height();
    var popupWidth = $("#popupDiv").width();
    var top = (windowHeight - popupHeight) / 2 > 0 ? (windowHeight - popupHeight) / 2 : 0;
    $("#popupDiv").css({
        "position": "absolute",
        "top": top,
        "left": (windowWidth - popupWidth) / 2
    });
    $("#backgroundPopup").css({
        "height": document.documentElement.clientHeight
    });
}

//对话层拖放
function setDrag(obj, pid) {
    var parent = $("#" + pid);
    var div = $("#movePopup");
    obj.css("cursor", "move");
    obj.mousedown(function(e) {
        if (e.target.nodeName.toLowerCase() == 'img') return;
        div.css({
            height: parent.height(),
            width: parent.width(),
            top: parent.css("top"),
            left: parent.css("left"),
            opacity: 0.2
        });
        parent.hide();
        if (isIE) {
            $$("movePopup").setCapture();
        }

        var offset = obj.offset();
        var x = e.clientX;
        var y = e.clientY;

        $(document).bind("mousemove", function(event) {
            var currentX = event.clientX - x;
            var currentY = event.clientY - y;
            if (currentX < 0) currentX = 0;
            if (currentY < 0) currentY = 0;
            if (currentX + div.width() > document.documentElement.clientWidth)
                currentX = document.documentElement.clientWidth - div.width();
            if (currentY + div.height() > document.documentElement.clientHeight)
                currentY = document.documentElement.clientHeight - div.height();

            div.css({
                left: currentX,
                top: currentY
            });
        });

        $(document).mouseup(function() {
            $(document).unbind("mousemove");
            if (isIE) {
                $$("movePopup").releaseCapture();
            }
            parent.css({
                top: div.css("top"),
                left: div.css("left")
            });
            div.css({
                width: 0,
                height: 0
            });
            parent.show();
        });

        return false;
    });
}

//关闭对话层
function disablePopup() {
    $("#popupDiv").width("0");
    $("#popupDiv").height("0");
    $("#backgroundPopup").fadeOut("fast");
    $("#popupDiv").fadeOut("fast");
    window.top.popup.location = "/Admin/loading.htm";
}

//添加站点
function addSite() {
    goPopupUrl(485, 319, "/Admin/Site/SiteAdd.aspx");
}

//修改站点
function editSite(sid) {
    goPopupUrl(485, 319, "/Admin/Site/SiteEdit.aspx?id=" + sid);
}

//删除站点
function delSite(sid) {
    goPopupUrl(485, 363, "/Admin/Site/SiteDel.aspx?id=" + sid);
}

//添加站点栏目
function addSiteColumn(sid) {
    goPopupUrl(485, 339, "/Admin/Column/ColumnAdd.aspx?sid=" + sid);
}

//添加栏目
function addColumn(cid) {
    goPopupUrl(485, 339, '/Admin/Column/ColumnAdd.aspx?cid=' + cid);
}

//修改栏目
function editColumn(cid) {
    goPopupUrl(485, 339, '/Admin/Column/ColumnEdit.aspx?cid=' + cid);
}

//删除栏目
function delColumn(cid) {
    goPopupUrl(485, 363, "/Admin/Column/ColumnDel.aspx?cid=" + cid);
}

//批量删除栏目
function delColumns() {
    var ids = getSelect();
    if (ids) {
        parent.goPopupUrl(485, 363, "/Admin/Column/ColumnsDel.aspx?ids=" + ids);
    } else {
        parent.showError("系统提示信息", "请选择档目！", 485, 223);
    }
}

//删除文档
function recycleArticle(aid) {
    if (aid) {
        goPopupUrl(485, 363, "/Admin/Content/ArticleRecycle.aspx?ids=" + aid);
    } else {
        var ids = getSelect();
        if (ids) {
            parent.goPopupUrl(485, 363, "/Admin/Content/ArticleRecycle.aspx?ids=" + ids);
        } else {
            parent.showError("系统提示信息", "请选择文档！", 485, 223);
        }
    }
}

//移动文档
function moveArticle(aid) {
    if (aid) {
        goPopupUrl(485, 483, "/Admin/Content/ArticleMove.aspx?ids=" + aid + "&type=0"); 
    }
    else {
        var ids = getSelect();
        if (ids) {
            parent.goPopupUrl(485, 483, "/Admin/Content/ArticleMove.aspx?ids=" + ids + "&type=0");
        } else {
            parent.showError("系统提示信息", "请选择文档！", 485, 223);
        } 
    }
}

//复制文档
function copyArticle(aid) {
    if (aid) {
        goPopupUrl(485, 483, "/Admin/Content/ArticleCopy.aspx?ids=" + aid + "&type=0"); 
    }else {
        var ids = getSelect();
        if (ids) {
            parent.goPopupUrl(485, 483, "/Admin/Content/ArticleCopy.aspx?ids=" + ids + "&type=0");
        } else {
            parent.showError("系统提示信息", "请选择文档！", 485, 223);
        }
    }
}

//引用文档
function pointArticle(aid) {
    if (aid) {
        goPopupUrl(485, 483, "/Admin/Content/ArticlePoint.aspx?ids=" + aid + "&type=0");
    } else {
        var ids = getSelect();
        if (ids) {
            parent.goPopupUrl(485, 483, "/Admin/Content/ArticlePoint.aspx?ids=" + ids + "&type=0");
        } else {
            parent.showError("系统提示信息", "请选择文档！", 485, 223);
        }
    }
}

//导航栏添加栏目
function addColumnByMenu() {
    var activeItem = window.frames["left"].window.activeItem;
    if (activeItem) {
        if (activeItem.objecttype == "site") {
            addSiteColumn(activeItem.id);
        } else if (activeItem.objecttype == "column") {
            addColumn(activeItem.id);
        } else {
            showError("系统提示信息", "请选择站点或栏目！", 485, 223);
        }
    } else {
        showError("系统提示信息", "请选择站点或栏目！", 485, 223);
    }
}

//恢复文档
function revokeArticle() {
    var ids = getSelect();
    if (ids) {
        parent.goPopupUrl(485, 363, "/Admin/Content/ArticleRevoke.aspx?ids=" + ids);
    } else {
        parent.showError("系统提示信息", "请选择文档！", 485, 223);
    }
}

//彻底删除文档
function deleteArticle() {
    var ids = getSelect();
    if (ids) {
        parent.goPopupUrl(485, 363, "/Admin/Content/ArticleDel.aspx?ids=" + ids);
    } else {
        parent.showError("系统提示信息", "请选择文档！", 485, 223);
    }
}

//删除产品
function recycleProduct(pid) {
    if (pid) {
        goPopupUrl(485, 363, "/Admin/Product/ProductRecycle.aspx?ids=" + pid);
    } else {
        var ids = getSelect();
        if (ids) {
            parent.goPopupUrl(485, 363, "/Admin/Product/ProductRecycle.aspx?ids=" + ids);
        } else {
            parent.showError("系统提示信息", "请选择文档！", 485, 223);
        }
    }
}

//移动产品
function moveProduct(pid) {
    if (pid) {
        goPopupUrl(485, 483, "/Admin/Product/ProductMove.aspx?ids=" + pid + "&type=1");
    }
    else {
        var ids = getSelect();
        if (ids) {
            parent.goPopupUrl(485, 483, "/Admin/Product/ProductMove.aspx?ids=" + ids + "&type=1");
        } else {
            parent.showError("系统提示信息", "请选择产品！", 485, 223);
        }
    }
}

//复制产品
function copyProduct(pid) {
    if (pid) {
        goPopupUrl(485, 483, "/Admin/Product/ProductCopy.aspx?ids=" + pid + "&type=1");
    } else {
        var ids = getSelect();
        if (ids) {
            parent.goPopupUrl(485, 483, "/Admin/Product/ProductCopy.aspx?ids=" + ids + "&type=1");
        } else {
            parent.showError("系统提示信息", "请选择产品！", 485, 223);
        }
    }
}

//引用产品
function pointProduct(pid) {
    if (pid) {
        goPopupUrl(485, 483, "/Admin/Product/ProductPoint.aspx?ids=" + pid + "&type=1");
    } else {
        var ids = getSelect();
        if (ids) {
            parent.goPopupUrl(485, 483, "/Admin/Product/ProductPoint.aspx?ids=" + ids + "&type=1");
        } else {
            parent.showError("系统提示信息", "请选择产品！", 485, 223);
        }
    }
}

//恢复产品
function revokeProduct() {
    var ids = getSelect();
    if (ids) {
        parent.goPopupUrl(485, 363, "/Admin/Product/ProductRevoke.aspx?ids=" + ids);
    } else {
        parent.showError("系统提示信息", "请选择产品！", 485, 223);
    }
}

//彻底删除产品
function deleteProduct() {
    var ids = getSelect();
    if (ids) {
        parent.goPopupUrl(485, 363, "/Admin/Product/ProductDel.aspx?ids=" + ids);
    } else {
        parent.showError("系统提示信息", "请选择产品！", 485, 223);
    }
}

//删除模板
function delTemplate(sid) {
    var ids = getSelect();
    if (ids) {
        parent.goPopupUrl(485, 363, "/Admin/Template/TemplateDel.aspx?sid=" + sid + "&ids=" + ids);
    } else {
        parent.showError("系统提示信息", "请选择模板！", 485, 223);
    }
}

//设置模板
function setTemplate(sid, type, cid) {
    var url = "/Admin/Template/TemplateSet.aspx?sid=" + sid + "&type=" + type;
    if (cid) {
        url += "&column=true&cid=" + cid;
    }
    parent.goPopupUrl(485, 363, url);
}

//锁定用户
function lockUser() {
    var ids = getSelect();
    if (ids) {
        parent.goPopupUrl(485, 363, "/Admin/User/UserLock.aspx?ids=" + ids);
    } else {
        parent.showError("系统提示信息", "请选择用户！", 485, 223);
    }
}

//锁定用户
function unlockUser() {
    var ids = getSelect();
    if (ids) {
        parent.goPopupUrl(485, 363, "/Admin/User/UserUnlock.aspx?ids=" + ids);
    } else {
        parent.showError("系统提示信息", "请选择用户！", 485, 223);
    }
}

//删除用户
function deleteUser() {
    var ids = getSelect();
    if (ids) {
        parent.goPopupUrl(485, 363, "/Admin/User/UserDel.aspx?ids=" + ids);
    } else {
        parent.showError("系统提示信息", "请选择用户！", 485, 223);
    }
}

//删除产品
function deletePublish() {
    var ids = getSelect();
    if (ids) {
        parent.goPopupUrl(485, 363, "/Admin/Sys/PublishDel.aspx?ids=" + ids);
    } else {
        parent.showError("系统提示信息", "请选择发布日志！", 485, 223);
    }
}

//显示错误提示层
function showError(title, msg, width, height) {
    if (!title) title = "系统提示信息";
    var url = "/Admin/Error.aspx?title=" + escape(title) + "&msg=" + escape(msg);
    goPopupUrl(width, height, url);
}

/*---------------- 栏目树 --------------------------*/
function site(id, name, index) {
    //编号
    this.id = id;
    //名称
    this.name = name;
    //索引
    this.index = index;
    //子栏目
    this.columns = new Array();
    //链接
    this.url = "/Admin/Site/SiteMain.aspx?id=" + this.id;
    //是否展开
    this.expanded = false;
    //对象类型
    this.objecttype = "site";
    //展开/收起图标
    this.img = undefined;
    //所属表格行
    this.row = undefined;
    //超链接标签
    this.a = undefined;
    //右键菜单
    this.menu = undefined;
    //查找子栏目
    this.findColumn = function(cid) {
        return findColumn(this.columns, cid);
    };
}

function column(site, id, name, index, type, haschild) {
    //编号
    this.id = id;
    //名称
    this.name = name;
    //索引
    this.index = index;
    //类型
    this.type = type;
    //是否存在子栏目
    this.haschild = haschild;
    //子栏目
    this.children = new Array();
    //所属站点
    this.site = site;
    //是否展开
    this.expanded = false;
    //链接
    switch (this.type) {
        case 'Article':
            this.url = "/Admin/Content/ArticleList.aspx?cid=" + this.id;
            break;
        case 'Product':
            this.url = "/Admin/Product/ProductList.aspx?cid=" + this.id;
            break;
        case 'Album':
            this.url = "/Admin/Album/AlbumList.aspx?cid=" + this.id;
            break;
        case 'Single':
            this.url = "/Admin/Content/SingleArticle.aspx?cid=" + this.id;
            break;
    }
    //对象类型
    this.objecttype = "column";
    //展开/收起图标
    this.img = undefined;
    //所属表格行
    this.row = undefined;
    //超链接标签
    this.a = undefined;
    //右键菜单
    this.menu = undefined;
    //父级栏目
    this.parent = undefined;
    //查找子栏目
    this.findColumn = function(cid) {
        return findColumn(this.children, cid);
    };
}

//获取站点列表
function getSites() {
    $.ajax({
        url: "Ajax/GetSites.aspx",
        cache: false,
        success: function(result) {
            eval(result);
            for (i = 0; i < sites.length; i++) {
                addSiteRow(sites[i]);
            }
        }
    });
}

//添加站点
function addTreeSite(sid, sname) {
    var s = new site(sid, sname, sites.length + 1);
    sites.push(s);
    addSiteRow(s);
    focusItem(s, true);
}

//添加站点
function editTreeSite(sid, sname) {
    var s = findSite(sid);
    if (!s) {
        return;
    }
    s.a.innerHTML = sname;
    focusItem(s, true);
}

//删除站点
function delTreeSite(sid) {
    var site = findSite(sid);
    if (!site) return;
    sites.splice(site.index - 1, 1);
    $(site.row).remove();
    if (window.activeColumn == site) {
        if (sites.length > 0) {
            focusItem(sites[0], true);
        } else {
            window.open("/Admin/mainfra.html", "mainFrame");
        }
    }
}

//清除站点
function clearSite(s, ownerDel) {
    while (s.columns.length > 0) {
        clearColumn(s.columns[0], true);
    }
    s.columns = new Array();
    if (ownerDel) {
        $(s.row).remove();
        sites.splice(s.index, 1);
    }
}

//删除栏目
function delTreeColumn(cid, isMulti) {
    var ids = cid.split(","), column;
    var rows = $$("treemenu").rows;

    for (var i = 0; i < ids.length; i++) {
        for (var j = 0; j < rows.length; j++) {
            if (rows[j].column && rows[j].column.id == ids[i]) {
                column = rows[j].column;
                clearColumn(column, true);
            }
        }
    }

    if (isMulti) {
        parent.window.frames["mainFrame"].window.location.reload();
    } else {
        if (!column)
            return;
        if (window.activeItem != null && window.activeItem.objecttype == 'column' && window.activeItem.id == cid) {
            column = window.activeItem;
            if (column.parent) {
                focusItem(column.parent, true);
            } else {
                focusItem(column.site, true);
            }
        }
    }
}

//清除栏目
function clearColumn(c, ownerDel) {
    while (c.children.length > 0) {
        clearColumn(c.children[0], true);
    }
    if (ownerDel) {
        $(c.row).remove();
        if (c.parent) {
            c.parent.children.shift();
        } else {
            c.site.columns.shift();
        }
    }
}

//定位到站点
function gotoSite(siteID) {
    var site = findSite(siteID);
    if (site == null) {
        return;
    }
    expandSite(site);

}

//添加栏目
function addTreeColumn(sid, colpath) {
    var ids = colpath.split(".");
    var site = findSite(sid);
    if (site == null || ids.length == 0) {
        return;
    }

    if (site.columns.length > 0) {
        clearSite(site, false);
    }

    site.expanded = false;
    gotoColumn(sid, colpath);
}

//修改栏目
function editTreeColumn(sid, colpath) {
    var ids = colpath.split(".");
    var site = findSite(sid);
    if (site == null || ids.length == 0) {
        return;
    }

    if (site.columns.length > 0) {
        clearSite(site, false);
    }

    site.expanded = false;
    gotoColumn(sid, colpath);
}

//定位栏目
function gotoColumn(sid, path) {
    var ids = path.split(".");
    var site = findSite(sid);
    if (site == null || ids.length == 0) {
        return;
    }

    if (site.columns.length == 0) {
        expandSite(site, path);
        return;
    }
    else {
        if (site.expanded != true) {
            expandSite(site);
        }
    }
    var parent = site.findColumn(ids[0]);
    if (parent == null) {
        return;
    }

    for (var i = 1; i < ids.length; i++) {
        if (parent.haschild == true && parent.children.length == 0) {
            expandColumn(parent, i, path);
            return;
        }
        else {
            if (parent.expanded != true) {
                expandColumn(parent);
            }
        }
        parent = parent.findColumn(ids[i]);
    }
    if (parent != null) {
        focusItem(parent, true);
    }
}

//查找栏目
function findColumn(children, id) {
    if (children == null || children.length == 0) {
        return null;
    }
    for (var i = 0; i < children.length; i++) {
        if (children[i].id == id) {
            return children[i];
        }
    }
    return null;
}

//添加站点行
function addSiteRow(s) {
    var row = $$("treemenu").insertRow(-1);
    row.insertCell(-1);
    s.row = row;

    var img = document.createElement("IMG");
    img.align = "absbottom";
    img.src = "images/plus.gif";
    s.img = img;

    $(img).click(function(i) {
        if (s.expanded)
            packUpSite(s);
        else
            expandSite(s);
    });

    var typeimg = document.createElement("IMG");
    typeimg.align = "bottom";
    typeimg.src = "images/icons/site.gif";
    typeimg.style.height = "16px";
    typeimg.style.width = "16px";

    var a = document.createElement("A");
    a.href = s.url;
    a.target = "mainFrame";
    a.innerHTML = "<strong>" + s.name + "</strong>";
    a.title = s.name + "(id:" + s.id + ")";
    $(a).click(function() {
        focusItem(s);
    });
    $(a).bind("contextmenu", null, function(e) { return parent.showSiteMenu(s, e); });
    s.a = a;

    row.cells[0].appendChild(img);
    row.cells[0].appendChild(typeimg);
    row.cells[0].appendChild(a);

    if ($("#treemenu tr").length == 1)
        expandSite(s);
}

//展开站点
function expandSite(s, path) {
    s.img.src = "images/-.gif";
    if (s.columns.length == 0) {
        $.ajax({
            url: "Ajax/GetColumns.aspx?siteid=" + s.id,
            cache: false,
            success: function(result) {
                var columns = new Array(), c;
                eval(result);
                s.columns = columns;
                for (i = 0; i < s.columns.length; i++) {
                    s.columns[i].row = addColumnRow(s.columns[i]);
                }

                if (path) {
                    gotoColumn(s.id, path);
                }
            }
        });
    }
    else {
        for (i = 0; i < s.columns.length; i++) {
            s.columns[i].row.style.display = "block";
        }
    }
    s.expanded = true;
}

//收缩站点
function packUpSite(s) {
    s.img.src = "images/plus.gif";
    for (i = 0; i < s.columns.length; i++) {
        hideChild(s.columns[i]);
    }
    s.expanded = false;
}

//展开栏目
function expandColumn(c, idx, path) {
    c.img.src = "images/-.gif";
    if (c.children.length == 0) {
        var url = "ajax/getcolumns.aspx?parentid=" + c.id;
        $.ajax({
            url: url,
            cache: false,
            success: function(result) {
                var columns = new Array(), child;
                eval(result);
                if (columns.length == 0) {
                    c.img.src = "images/=.gif";
                    $(c.img).unbind("click");
                    return;
                }
                c.children = columns;
                for (i = 0; i < c.children.length; i++) {
                    c.children[i].row = addColumnRow(c.children[i]);
                }

                if (idx != null && path != null) {
                    var ids = path.split('.');
                    var child = c.findColumn(ids[idx]);
                    if (idx < ids.length - 1) {
                        expandColumn(child, idx + 1, path);
                    }
                    else {
                        focusItem(child, true);
                    }
                }
            }
        });
    }
    else {
        for (i = 0; i < c.children.length; i++) {
            c.children[i].row.style.display = "block";
        }
    }
    c.expanded = true;
}

//收起栏目
function packUpColumn(c) {
    c.img.src = "images/plus.gif";
    for (i = 0; i < c.children.length; i++) {
        hideChild(c.children[i]);
    }
    c.expanded = false;
}

//隐藏子栏目
function hideChild(c) {
    c.row.style.display = "none";
    if (c.expanded) {
        c.img.src = "images/plus.gif";
        c.expanded = false;
    }
    for (var i = 0; i < c.children.length; i++) {
        hideChild(c.children[i]);
    }
}

//添加栏目行
function addColumnRow(c) {
    var idx = 0;
    if (c.site != null)
        idx = c.site.row.rowIndex + c.index;
    else
        idx = c.parent.row.rowIndex + c.index;

    var row = $$("treemenu").insertRow(idx);
    row.insertCell(-1);

    var img = document.createElement("IMG");
    img.align = "absbottom";
    img.src = "images/plus.gif";
    if (c.haschild == false) {
        img.src = "images/=.gif";
    }
    c.img = img;
    $(img).click(function(i) {
        if (c.expanded)
            packUpColumn(c);
        else
            expandColumn(c);
    });

    var typeimg = document.createElement("IMG");
    typeimg.align = "absbottom";
    typeimg.src = "images/icons/col_" + c.type + ".gif";

    var a = document.createElement("a");
    a.href = c.url;
    a.innerHTML = c.name;
    a.target = "mainFrame";
    a.style.marginLeft = "3px";
    a.title = c.name + "(id:" + c.id + ")";
    $(a).click(function() {
        focusItem(c);
    });
    $(a).bind("contextmenu", null, function(e) { return parent.showColumnMenu(c, e); });
    c.a = a;

    row.cells[0].appendChild(img);
    row.cells[0].appendChild(typeimg);
    row.cells[0].appendChild(a);

    row.column = c;

    var padding = 15;
    if (c.parent != null) {
        if (c.parent.padding == null) {
            c.parent.padding = padding;
        }
        c.padding = c.parent.padding + padding;
    }
    else {
        c.padding = padding;
    }
    row.cells[0].style.paddingLeft = c.padding.toString() + "px";
    row.cells[0].nowrap = "nowrap";

    return row;
}

//查找站点
function findSite(siteID) {
    for (var i = 0; i < sites.length; i++) {
        if (sites[i].id == siteID) {
            return sites[i];
        }
    }
    return null;
}

//点击定位到项
function focusItem(c, go) {
    if (window.activeItem != null) {
        window.activeItem.a.className = "";
    }
    c.a.className = "selected";
    window.activeItem = c;

    if (!c.expanded) {
        if (c.objecttype == 'site') {
            expandSite(c);
        } else {
            expandColumn(c);
        }
    }

    if (go == true) {
        window.open(c.url, "mainFrame");
        if (c.row.offsetTop > document.documentElement.clientHeight) {
            window.scroll(0, parseInt(c.row.offsetTop));
        }
    }
}

//栏目排序
function sortColumn(cid) {
    var item = window.activeItem;
    if (item.objecttype == 'site') {
        clearSite(item, false);
        expandSite(item);
        focusItem(item, false);
    } else {
        clearColumn(item, false);
        expandColumn(item);
        focusItem(item, false);
    }
}

/*---------------- 弹出层树形菜单 --------------------------*/
//获取站点列表
function getPopupSites() {
    $.ajax({
        url: "../Ajax/GetSites.aspx",
        cache: false,
        success: function(result) {
            eval(result);
            for (i = 0; i < sites.length; i++) {
                addPopupSiteRow(sites[i]);
            }
        }
    });
}

//添加站点行
function addPopupSiteRow(s) {
    var row = $$("treemenu").insertRow(-1);
    row.insertCell(-1);
    s.row = row;

    var img = document.createElement("IMG");
    img.align = "absbottom";
    img.src = "../images/plus.gif";
    s.img = img;

    $(img).click(function(i) {
        if (s.expanded)
            packUpPopupSite(s);
        else
            expandPopupSite(s);
    });

    var typeimg = document.createElement("IMG");
    typeimg.align = "bottom";
    typeimg.src = "../images/icons/site.gif";
    typeimg.style.height = "16px";
    typeimg.style.width = "16px";

    var span = document.createElement("SPAN");
    span.innerHTML = "<strong>" + s.name + "</strong>";
    span.title = s.name;

    row.cells[0].appendChild(img);
    row.cells[0].appendChild(typeimg);
    row.cells[0].appendChild(span);
}

//展开站点
function expandPopupSite(s) {
    s.img.src = "../images/-.gif";
    var url = "../Ajax/GetColumns.aspx?siteid=" + s.id;
    if (s.columns.length == 0) {
        $.ajax({
            url: url,
            cache: false,
            success: function(result) {
                var columns = new Array(), c;
                eval(result);
                s.columns = columns;
                for (i = 0; i < s.columns.length; i++) {
                    s.columns[i].row = addPopupColumnRow(s.columns[i]);
                }
            }
        });
    }
    else {
        for (i = 0; i < s.columns.length; i++) {
            s.columns[i].row.style.display = "block";
        }
    }
    s.expanded = true;
}

//收缩站点
function packUpPopupSite(s) {
    s.img.src = "../images/plus.gif";
    for (i = 0; i < s.columns.length; i++) {
        hideChild(s.columns[i]);
    }
    s.expanded = false;
}

//添加栏目行
function addPopupColumnRow(c) {
    var idx = 0;
    if (c.site != null)
        idx = c.site.row.rowIndex + c.index;
    else
        idx = c.parent.row.rowIndex + c.index;

    var row = $$("treemenu").insertRow(idx);
    row.insertCell(-1);

    var img = document.createElement("IMG");
    img.align = "absbottom";
    img.src = "../images/plus.gif";
    if (c.haschild == false) {
        img.src = "../images/=.gif";
    }
    c.img = img;
    $(img).click(function(i) {
        if (c.expanded)
            packUpPopupColumn(c);
        else
            expandPopupColumn(c);
    });

    var typeimg = document.createElement("IMG");
    typeimg.align = "absbottom";
    typeimg.src = "../images/icons/col_" + c.type + ".gif";

    var span = document.createElement("span");
    span.innerHTML = c.name;
    span.style.marginLeft = "3px";
    span.title = c.name;

    row.cells[0].appendChild(img);

    var html = "";
    if (treetype == 'radiobox') {
        html = "<input name='cids' value='" + c.id + "' type='radio'" + (c.type == type ? "" : " disabled='disabled'") + " />";
    }
    if (treetype == 'checkbox') {
        html = "<input name='cids' value='" + c.id + "' type='checkbox'" + (c.type == type ? "" : " disabled='disabled'") + " />";
    }
    $(row.cells[0]).append(html);

    row.cells[0].appendChild(typeimg);
    row.cells[0].appendChild(span);

    row.column = c;

    var padding = 15;
    if (c.parent != null) {
        if (c.parent.padding == null) {
            c.parent.padding = padding;
        }
        c.padding = c.parent.padding + padding;
    }
    else {
        c.padding = padding;
    }
    row.cells[0].style.paddingLeft = c.padding.toString() + "px";
    row.cells[0].nowrap = "nowrap";

    return row;
}

//展开栏目
function expandPopupColumn(c) {
    c.img.src = "../images/-.gif";
    if (c.children.length == 0) {
        var url = "../ajax/getcolumns.aspx?parentid=" + c.id;
        $.ajax({
            url: url,
            cache: false,
            success: function(result) {
                var columns = new Array(), child;
                eval(result);
                if (columns.length == 0) {
                    c.img.src = "../images/=.gif";
                    $(c.img).unbind("click");
                    return;
                }
                c.children = columns;
                for (i = 0; i < c.children.length; i++) {
                    c.children[i].row = addPopupColumnRow(c.children[i]);
                }
            }
        });
    }
    else {
        for (i = 0; i < c.children.length; i++) {
            c.children[i].row.style.display = "block";
        }
    }
    c.expanded = true;
}

//收起栏目
function packUpPopupColumn(c) {
    c.img.src = "../images/plus.gif";
    for (i = 0; i < c.children.length; i++) {
        hidePopupChild(c.children[i]);
    }
    c.expanded = false;
}

//隐藏子栏目
function hidePopupChild(c) {
    c.row.style.display = "none";
    if (c.expanded) {
        c.img.src = "../images/plus.gif";
        c.expanded = false;
    }
    for (var i = 0; i < c.children.length; i++) {
        hidePopupChild(c.children[i]);
    }
}

/*---------------- 系统管理栏目树 --------------------------*/
function menu(id, name, url, index, haschild) {
    //编号
    this.id = id;
    //名称
    this.name = name;
    //链接
    this.url = url;
    //索引
    this.index = index;
    //是否展开
    this.expanded = false;
    //是否存在子菜单
    this.haschild = haschild;
    //子菜单
    this.children = new Array();
    //展开/收起图标
    this.img = undefined;
    //所属表格行
    this.row = undefined;
    //超链接标签
    this.a = undefined;
    //查找子栏目
    this.findMenu = function(mid) {
        return findMenu(this.children, mid);
    };
}

//添加行
function createMenuRow(m) {
    var idx = 0;
    if (m.parent != null) {
        idx = m.parent.row.rowIndex + m.index;
    }
    else
        idx = m.index;

    var row = $$("treemenu").insertRow(idx);
    row.insertCell(-1);

    var img = document.createElement("IMG");
    img.align = "absbottom";
    img.src = "images/plus.gif";
    img.menu = m;
    row.menu = m;
    m.img = img;
    m.row = row;
    if (m.haschild == false) {
        img.src = "images/=.gif";
    }

    var typeimg = document.createElement("IMG");
    typeimg.align = "absbottom";
    if (m.parent == null) {
        typeimg.src = "images/icons/site.gif";
    }
    else {
        if (m.haschild == true) {
            typeimg.src = "images/icons/folder.gif";
        }
        else {
            typeimg.src = "images/icons/col_Single.gif";
        }
    }


    var a = document.createElement("a");
    $(a).click(function(e) {
        focusMenu(m, true);
    });
    a.style.marginLeft = "3px";
    a.innerHTML = m.name;
    a.style.cursor = "pointer";
    m.a = a;

    row.cells[0].appendChild(img);
    row.cells[0].appendChild(typeimg);
    row.cells[0].appendChild(a);

    var padding = 10;
    if (m.parent != null) {
        if (m.parent.padding == null) {
            m.parent.padding = padding;
        }
        m.padding = m.parent.padding + padding;
    }
    else {
        m.padding = 0;
    }
    row.cells[0].style.paddingLeft = m.padding.toString() + "px";
    row.cells[0].nowrap = "nowrap";
    $(img).click(function(i) {
        if (m.expanded != true)
            expandMenu(m);
        else
            inpectMenu(m);
    });
    if (m.parent != null) {
        row.style.display = "none";
    }
    return row;
}

//展开菜单
function expandMenu(m, idx, idpath) {
    m.img.src = "images/-.gif";
    if (m.children.length == 0) {
        var url = "Ajax/GetSysMenu.aspx?parentid=" + m.id;
        $.get(url, function(result) {
            var columns = new Array();
            try {
                eval(result);
            }
            catch (e) { alert(e); }
            if (columns.length == 0) {
                m.img.src = "images/=.gif";
                $(m.img).unbind("click");
                return;
            }
            m.children = columns;
            for (i = 0; i < m.children.length; i++) {
                m.children[i].row.style.display = "block";
            }
            //定位到子栏目
            if (idx != null && idpath != null) {
                var ids = idpath.split('.');
                var child = m.findMenu(ids[idx]);
                //继续展开
                if (idx < ids.length - 1) { 
                    expandMenu(child, idx + 1, idpath);
                }
                else {
                    focusMenu(child, true);
                }
            }
        });
    }
    else {
        for (i = 0; i < m.children.length; i++) {
            m.children[i].row.style.display = "block";
        }
    }
    m.expanded = true;
}

//收起菜单
function inpectMenu(m) {
    m.img.src = "images/plus.gif";
    for (i = 0; i < m.children.length; i++) {
        hideChild(m.children[i]);
    }
    m.expanded = false;
}

//隐藏子菜单
function hideChild(m) {
    m.row.style.display = "none";
    m.expanded = false;
    if (m.img.src.indexOf("-") > 0) {
        m.img.src = "images/plus.gif";
    }
    for (var i = 0; i < m.children.length; i++) {
        hideChild(m.children[i]);
    }
}

//定位到菜单
function gotoMenu(idPath) {
    var ids = idPath.split(".");
    var parent = rootMenu;
    for (var i = 1; i < ids.length; i++) {
        if (parent.haschild == true && parent.children.length == 0) {
            expandMenu(parent, i, idPath);
            return;
        }
        else {
            if (parent.expanded != true) {
                expandMenu(parent);
            }
        }
        parent = parent.findMenu(ids[i]);
    }
    if (parent != null) {
        focusMenu(parent);
    }
}

//点击菜单
function focusMenu(m, go) {
    if (window.activeMenu != null) {
        window.activeMenu.a.className = "";
    }
    m.a.className = "selected";
    window.activeMenu = m;
    if (go == true) {
        if (m.url != "") {
            window.open(m.url, "mainFrame");
        }
        else {
            if (m.haschild == true) {
                if (m.expanded == true) {
                    inpectMenu(m);
                }
                else {
                    expandMenu(m);
                }
            }
        }
    }
}

//查找菜单
function findMenu(children, id) {
    if (children == null || children.length == 0) {
        return null;
    }
    for (var i = 0; i < children.length; i++) {
        if (children[i].id == id) {
            return children[i];
        }
    }
    return null;
}

/*---------------- 右键菜单 --------------------------*/
function ContextMenu() {
    this.items = new Array();

    var panel = document.createElement("DIV");
    panel.className = "contextmenu";
    panel.style.visibility = "hidden";
    panel.style.position = "absolute";
    document.body.appendChild(panel);
    this.panel = panel;
    panel.obj = this;
    this.isIE = navigator.appName.indexOf("Netscape") == -1;
}

ContextMenu.prototype = {
    Item: function(text, title, url, target, img, enabled) {
        this.text = text;
        this.title = title;
        this.url = url;
        this.img = img;
        this.enabled = enabled;
        this.target = target;
        var itemCtl = document.createElement("DIV");
        itemCtl.className = "item";
        if (img != null) {
            itemCtl.style.backgroundImage = img;
        }
        itemCtl.title = title;
        itemCtl.innerHTML = text;
        this.itemCtl = itemCtl;
        itemCtl.obj = this;
        itemCtl.objType = "menuitem";
    },
    addItem: function(item) {
        this.panel.appendChild(item.itemCtl);
        item.itemCtl.disabled = item.enabled == false;
        item.contextMenu = this;
        if (this.isIE == false) {
            item.itemCtl.addEventListener("mouseover", function(e) {
                e.target.obj.contextMenu.focus(e.target.obj);
            }, false);
            item.itemCtl.addEventListener("mouseout", function(e) {
                e.target.obj.contextMenu.blur(e.target.obj);
            }, false);
            item.itemCtl.addEventListener("click", function(e) {
                e.target.obj.contextMenu.click(e.target.obj);
            }, false);
        }
        else {
            item.itemCtl.attachEvent("onmouseover", function(e) {
                e.srcElement.obj.contextMenu.focus(e.srcElement.obj);
            });
            item.itemCtl.attachEvent("onmouseout", function(e) {
                e.srcElement.obj.contextMenu.blur(e.srcElement.obj);
            });
            item.itemCtl.attachEvent("onclick", function(e) {
                e.srcElement.obj.contextMenu.click(e.srcElement.obj);
            });
        }
        this.items.push(item)
    },
    addSeparator: function() {
        var separator = document.createElement("DIV");
        separator.className = "separator";
        this.panel.appendChild(separator);
    },
    focus: function(e) {
        e.itemCtl.className = "item over";
    },
    blur: function(e) {
        e.itemCtl.className = "item";
    },
    click: function(e) {
        if (!e.url || e.url == "") {
            return;
        }
        if (e.url.indexOf("javascript:") == 0) {
            eval(e.url);
        }
        else {
            window.open(e.url, e.target);
        }
    },
    show: function(x, y) {
        if (window.activeContextMenu != null) {
            window.activeContextMenu.hide();
        }
        window.activeContextMenu = this;
        if (y + this.panel.offsetHeight > document.body.clientHeight) {
            y = y - this.panel.offsetHeight;
        }
        this.panel.style.left = x + "px";
        this.panel.style.top = y + "px";
        this.panel.style.visibility = "visible";
    },
    hide: function() {
        this.panel.style.visibility = "hidden";
    },
    getOffset: function(e) {
        var t = e.offsetTop;
        var l = e.offsetLeft;
        while (e = e.offsetParent) {
            t += e.offsetTop;
            l += e.offsetLeft;
        }
        var rec = new Array(1);
        rec[0] = t;
        rec[1] = l;
        return rec;
    }
}

//页面空白区域右键菜单
function createDocumentPopMenu() {
    var menu = new ContextMenu(); var item;
    item = new menu.Item("刷新栏目树", "刷新栏目树", "javascript:window.frames['left'].window.location.href=window.frames['left'].window.location.href;");
    menu.addItem(item);
    window.documentContextMenu = menu;
}

//站点右键菜单
function createSitePopMenu(s) {
    var menu = new ContextMenu(), item;
    item = new menu.Item("修改站点", "修改站点", "javascript:editSite(" + s.id + ")");
    menu.addItem(item);
    item = new menu.Item("删除站点", "删除站点", "javascript:delSite(" + s.id + ")");
    menu.addItem(item);
    menu.addSeparator();
    item = new menu.Item("预览站点首页", "预览站点首页", "../Publish/Builder.aspx?type=site&sid=" + s.id, "_blank");
    menu.addItem(item);
    item = new menu.Item("发布站点首页", "发布这个站点的首页", "javascript:publishSiteHome(" + s.id + ")");
    menu.addItem(item);
    item = new menu.Item("增量发布站点", "仅发布尚未发布的文档并更新相关栏目首页和站点首页", "javascript:publishSiteAdditional(" + s.id + ")");
    menu.addItem(item);
    item = new menu.Item("完全发布站点", "发布这个站点的所有内容页并更新相关栏目首页和站点首页", "javascript:publishSiteAll(" + s.id + ")");
    menu.addItem(item);
    item = new menu.Item("撤销发布站点", "删除该站点已经发布的静态文件", "javascript:publishSiteCancel(" + s.id + ")");
    menu.addItem(item);
    menu.addSeparator();
    item = new menu.Item("新建站点", "创建新站点", "javascript:addSite()");
    menu.addItem(item);
    item = new menu.Item("新建栏目", "创建新栏目", "javascript:addSiteColumn(" + s.id + ")");
    menu.addItem(item);
    item = new menu.Item("新建模板", "创建新模板", "Template/TemplateAdd.aspx?sid=" + s.id, "template");
    item.enabled = true;
    menu.addItem(item);

    s.menu = menu;
}

//文档栏目右键菜单
function createArticleColumnPopMenu(c) {
    var menu = new ContextMenu(), item;
    item = new menu.Item("修改该栏目", "修改该栏目", "javascript:editColumn(" + c.id + ")");
    menu.addItem(item);
    item = new menu.Item("删除该栏目", "删除该栏目", "javascript:delColumn(" + c.id + ")");
    menu.addItem(item);
    menu.addSeparator();
    item = new menu.Item("预览栏目首页", "预览栏目首页", "../Publish/Builder.aspx?cid=" + c.id, "_blank");
    menu.addItem(item);
    item = new menu.Item("发布栏目首页", "发布栏目首页", "javascript:pubishColumnHome(" + c.id + ")");
    menu.addItem(item);
    item = new menu.Item("增量发布栏目", "仅发布尚未发布的文档并更新相关栏目首页和站点首页", "javascript:publishColumnAdditional(" + c.id + ")");
    menu.addItem(item);
    item = new menu.Item("完全发布栏目", "发布这个栏目的所有内容页并更新相关栏目首页和站点首页", "javascript:publishColumnAll(" + c.id + ")");
    menu.addItem(item);
    item = new menu.Item("撤销发布栏目", "删除本栏目及下级栏目已经发布的静态文件", "javascript:publishColumnCancel(" + c.id + ")");
    menu.addItem(item);
    menu.addSeparator();
    item = new menu.Item("新建文档", "新建文档", "Content/ArticleAdd.aspx?cid=" + c.id);
    menu.addItem(item);
    item = new menu.Item("新建子栏目", "创建子栏目", "javascript:addColumn(" + c.id + ")");
    menu.addItem(item);

    c.menu = menu;
}

//单篇文档栏目右键菜单
function createSingleArticleColumnPopMenu(c) {
    var menu = new ContextMenu(), item;
    item = new menu.Item("修改该栏目", "修改该栏目", "javascript:editColumn(" + c.id + ")");
    menu.addItem(item);
    item = new menu.Item("删除该栏目", "删除该栏目", "javascript:delColumn(" + c.id + ")");
    menu.addItem(item);
    menu.addSeparator();
    item = new menu.Item("预览栏目首页", "预览栏目首页", "../Publish/Builder.aspx?cid=" + c.id, "_blank");
    menu.addItem(item);
    item = new menu.Item("发布栏目首页", "发布栏目首页", "javascript:pubishSingleArticle(" + c.id + ")");
    menu.addItem(item);
    item = new menu.Item("增量发布栏目", "仅发布尚未发布的文档并更新相关栏目首页和站点首页", "javascript:publishColumnAdditional(" + c.id + ")");
    menu.addItem(item);
    item = new menu.Item("完全发布栏目", "发布这个栏目的所有内容页并更新相关栏目首页和站点首页", "javascript:publishColumnAll(" + c.id + ")");
    menu.addItem(item);
    item = new menu.Item("撤销发布栏目", "删除本栏目及下级栏目已经发布的静态文件", "javascript:publishColumnCancel(" + c.id + ")");
    menu.addItem(item);
    menu.addSeparator();
    item = new menu.Item("新建子栏目", "创建子栏目", "javascript:addColumn(" + c.id + ")");
    menu.addItem(item);

    c.menu = menu;
}

//图片栏目右键菜单
function createAlbumColumnPopMenu(c) {
    var menu = new ContextMenu(), item;
    //新建栏目
    item = new menu.Item("新建栏目", "创建栏目", "javascript:addColumn(" + c.id + ")");
    menu.addItem(item);
    //修改栏目
    item = new menu.Item("修改栏目", "修改栏目", "javascript:editColumn(" + c.id + ")");
    menu.addItem(item);
    //删除栏目
    item = new menu.Item("删除栏目", "删除栏目", "javascript:delColumn(" + c.id + ")");
    menu.addItem(item);

    c.menu = menu;
}

//产品栏目右键菜单
function createProductColumnPopMenu(c) {
    var menu = new ContextMenu(), item;
    item = new menu.Item("修改该栏目", "修改该栏目", "javascript:editColumn(" + c.id + ")");
    menu.addItem(item);
    item = new menu.Item("删除该栏目", "删除该栏目", "javascript:delColumn(" + c.id + ")");
    menu.addItem(item);
    menu.addSeparator();
    item = new menu.Item("预览栏目首页", "预览栏目首页", "../Publish/Builder.aspx?cid=" + c.id, "_blank");
    menu.addItem(item);
    item = new menu.Item("发布栏目首页", "发布栏目首页", "javascript:pubishColumnHome(" + c.id + ")");
    menu.addItem(item);
    menu.addSeparator();
    item = new menu.Item("新建产品", "新建产品", "Product/ProductAdd.aspx?cid=" + c.id);
    menu.addItem(item);
    item = new menu.Item("新建子栏目", "新建子栏目", "javascript:addColumn(" + c.id + ")");
    menu.addItem(item);

    c.menu = menu;
}

//文档右键菜单
function createArticlePopMenu(obj, aid, cid) {
    var menu = new ContextMenu(), item;
    item = new menu.Item("预览这篇文档", "预览这篇文档", "../Publish/Builder.aspx?cid=" + cid + "&did=" + aid, "_blank");
    menu.addItem(item);
    item = new menu.Item("修改这篇文档", "修改这篇文档", "Content/ArticleEdit.aspx?id=" + aid, "article");
    menu.addItem(item);
    menu.addSeparator();
    item = new menu.Item("发布这篇文档", "发布这篇文档", "javascript:pubishArticle(" + aid + ")");
    menu.addItem(item);
    item = new menu.Item("撤销发布这篇文档", "撤销发布这篇文档", "javascript:cancelPublishArticle(" + aid + ")");
    menu.addItem(item);
    menu.addSeparator();
    item = new menu.Item("移动这篇文档到", "移动这篇文档到", "javascript:moveArticle(" + aid + ")");
    menu.addItem(item);
    item = new menu.Item("复制这篇文档到", "复制这篇文档到", "javascript:copyArticle(" + aid + ")");
    menu.addItem(item);
    item = new menu.Item("引用这篇文档到", "引用这篇文档到", "javascript:pointArticle(" + aid + ")");
    menu.addItem(item);
    item = new menu.Item("放入回收站", "放入回收站", "javascript:recycleArticle(" + aid + ")");
    menu.addItem(item);

    obj.menu = menu;
}

//产品右键菜单
function createProductPopMenu(obj, pid, cid) {
    var menu = new ContextMenu(), item;
    item = new menu.Item("修改这个产品", "修改这个产品", "Product/ProductEdit.aspx?id=" + pid, "product");
    menu.addItem(item);
    item = new menu.Item("放入回收站", "放入回收站", "javascript:recycleProduct(" + pid + ")");
    menu.addItem(item);
    menu.addSeparator();
    item = new menu.Item("预览这个产品", "预览这个产品", "../Publish/Builder.aspx?cid=" + cid + "&did=" + pid, "_blank");
    menu.addItem(item);
    menu.addSeparator();
    item = new menu.Item("移动这个产品到", "移动这个产品到", "javascript:moveProduct(" + pid + ")");
    menu.addItem(item);
    item = new menu.Item("复制这个产品到", "复制这个产品到", "javascript:copyProduct(" + pid + ")");
    menu.addItem(item);
    item = new menu.Item("引用这个产品到", "引用这个产品到", "javascript:pointProduct(" + pid + ")");
    menu.addItem(item);

    obj.menu = menu;
}

//显示站点右键菜单
function showSiteMenu(s, e) {
    if (s.menu == null) {
        createSitePopMenu(s);
    }
    s.menu.show(e.clientX, e.clientY + 55);
    return false;
}

//显示栏目右键菜单
function showColumnMenu(c, e) {
    if (c.menu == null) {
        switch (c.type) {
            case 'Article':
                createArticleColumnPopMenu(c);
                break;
            case 'Album':
                createAlbumColumnPopMenu(c);
                break;
            case 'Product':
                createProductColumnPopMenu(c);
                break;
            case 'Single':
                createSingleArticleColumnPopMenu(c);
        }
    }
    c.menu.show(e.clientX, e.clientY + 55);
    return false;
}

//显示文档右键菜单
function showArticleMenu(obj, aid, cid, e) {
    if (obj.menu == null) {
        createArticlePopMenu(obj, aid, cid);
    }
    obj.menu.show(e.clientX + 201, e.clientY + 55);
    return false;
}

//显示产品右键菜单
function showProductMenu(obj, pid, cid, e) {
    if (obj.menu == null) {
        createProductPopMenu(obj, pid, cid);
    }
    obj.menu.show(e.clientX + 201, e.clientY + 55);
    return false;
}

//显示页面空白区域右键菜单
function showContextMenu(e) {
    if (window.documentContextMenu == null) {
        createDocumentPopMenu();
    }
    window.documentContextMenu.show(e.clientX, e.clientY + 55);
    return false;
}

/*---------------- 页面方法 --------------------------*/
//添加站点回调函数
function addSiteOK(sid, sname) {
    parent.window.frames["left"].addTreeSite(sid, sname);
    parent.disablePopup();
}

//修改站点回调函数
function editSiteOK(sid, sname) {
    parent.window.frames["left"].editTreeSite(sid, sname);
    parent.disablePopup();
}

//删除站点回调函数
function delSiteOK(sid) {
    parent.window.frames["left"].delTreeSite(sid);
    parent.disablePopup();
}

//添加栏目回调函数
function addColumnOK(sid, colpath) {
    parent.window.frames["left"].addTreeColumn(sid, colpath);
    parent.disablePopup();
}

//修改栏目回调函数
function editColumnOK(sid, colpath) {
    parent.window.frames["left"].editTreeColumn(sid, colpath);
    parent.disablePopup();
}

//删除栏目回调函数
function delColumnOK(cid) {
    parent.window.frames["left"].delTreeColumn(cid);
    parent.disablePopup();
}

//批量删除栏目回调函数
function delColumnsOK(ids) {
    parent.window.frames["left"].delTreeColumn(ids, true);
    parent.disablePopup();
}

//排序栏目回调函数
function sortColumnOK(cid) {
    parent.window.frames["left"].sortColumn(cid);
}

//添加文档回调函数
function addArticleOK(sid, colpath, iscontinue) {
    if (sid && colpath) {
        if (opener) {
            if (opener.location.href.toLowerCase().indexOf("index") > 0) {
                opener.window.frames["left"].gotoColumn(sid, colpath);
            }
            else {
                opener.parent.window.frames["left"].gotoColumn(sid, colpath);
            }
        }
        if (iscontinue) {
            window.location.href = window.location.href;
        } else {
            window.close();
        }
    }
}

//修改文档回调函数
function editArticleOK() {
    if (opener) {
        opener.window.location.reload();
    }
    window.close();
}

//删除文档回调函数
function recycleArticleOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//移动文档回调函数
function moveArticleOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//复制文档回调函数
function copyArticleOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//引用文档回调函数
function pointArticleOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//恢复文档回调函数
function revokeArticleOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//彻底删除文档回调函数
function deleteArticleOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//删除模板回调函数
function delTemplateOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//添加模板回调函数
function addTemplateOK(sid) {
    if (opener) {
        if (opener.location.href.toLowerCase().indexOf("index") > 0) {
            var s = opener.window.frames["left"].findSite(sid);
            if (s) {
                opener.window.frames["left"].focusItem(s, false);
            }
            opener.window.frames["mainFrame"].window.location.href = "/Admin/Template/TemplateList.aspx?id=" + sid;
        } else {
            opener.window.location.reload();
        }
    }
    window.close();
}

//修改模板回调函数
function editTemplateOK() {
    if (opener) {
        opener.window.location.reload();
    }
    window.close();
}

//设置模板回调函数
function setTemplateOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//添加产品回调函数
function addProductOK(sid, colpath, iscontinue) {
    if (sid && colpath) {
        if (opener) {
            if (opener.location.href.toLowerCase().indexOf("index") > 0) {
                opener.window.frames["left"].gotoColumn(sid, colpath);
            }
            else {
                opener.parent.window.frames["left"].gotoColumn(sid, colpath);
            }
        }
        if (iscontinue) {
            window.location.href = window.location.href;
        } else {
            window.close();
        }
    }
}

//修改产品回调函数
function editProductOK() {
    if (opener) {
        opener.window.location.reload();
    }
    window.close();
}

//删除产品回调函数
function recycleProductOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//移动产品回调函数
function moveProductOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//复制产品回调函数
function copyProductOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//引用产品回调函数
function pointProductOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//恢复产品回调函数
function revokeProductOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//彻底删除产品回调函数
function deleteProductOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//清空回收站
function clearRecycle(cid, children) {
    var msg = "";
    if (children) {
        msg = "确定清空当前栏目及其子栏目的回收站？";
    } else {
        msg = "确定清空当前栏目的回收站？";
    }
    if (!confirm(msg)) return;
    var url = "../Ajax/ArticleClear.aspx?cid=" + cid;
    if (children) {
        url += "&ch=1";
    }
    $.ajax({
        url: url,
        cache: false,
        success: function(result) {
            if (result.length > 0) {
                alert(result);
            } else {
                window.location.reload();
            }
        }
    });
}

//清空回收站
function clearSiteRecycle(sid) {
    if (!confirm("确定清空当前站点的回收站？")) return;
    var url = "../Ajax/SiteArticleClear.aspx?id=" + sid;
    $.ajax({
        url: url,
        cache: false,
        success: function(result) {
            if (result.length > 0) {
                alert(result);
            } else {
                window.location.reload();
            }
        }
    });
}

//清空回收站
function clearProductRecycle(cid, children) {
    var msg = "";
    if (children) {
        msg = "确定清空当前栏目及其子栏目的回收站？";
    } else {
        msg = "确定清空当前栏目的回收站？";
    }
    if (!confirm(msg)) return;
    var url = "../Ajax/ProductClear.aspx?cid=" + cid;
    if (children) {
        url += "&ch=1";
    }
    $.ajax({
        url: url,
        cache: false,
        success: function(result) {
            if (result.length > 0) {
                alert(result);
            } else {
                window.location.reload();
            }
        }
    });
}

//修改单篇文档回调函数
function editSingleOK() {
    alert("保存成功！");
    window.location.href = window.location.href;
}

//修改密码回调函数
function editPasswordOK() {
    alert("密码修改成功！");
    window.location.href = window.location.href;
}

//修改个人资料回调函数
function editInfoOK() {
    alert("个人资料修改成功！");
    window.location.href = window.location.href;
}

//添加用户回调函数
function addUserOK() {
    alert("用户添加成功！");
    window.location.href = "UserList.aspx";
}

//修改用户回调函数
function editUserOK() {
    alert("用户修改成功！");
    window.location.href = "UserList.aspx";
}

//锁定用户回调函数
function lockUserOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//解锁用户回调函数
function unlockUserOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//删除用户回调函数
function deleteUserOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//彻底删除文档回调函数
function deletePublishOK() {
    parent.window.frames["mainFrame"].window.location.reload();
    parent.disablePopup();
}

//tab导航事件
function selectOption(title, content, index) {
    $("div[id^='" + title + "']").each(function() {
        if ($(this).attr("id") == title + index) {
            $(this).addClass("selected");
        } else {
            $(this).removeClass();
        }
    });
    $("table[id^='" + content + "']").each(function() {
        if ($(this).attr("id") == content + index) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
}

//操作任务显示/隐藏
function showFolder(id) {
    var show;
    $("#" + id + " img:first").each(function() {
        if ($(this).attr("src").indexOf("arrow.gif") > -1) {
            show = false;
            $(this).attr("src", "../images/icons/arrow2.gif");
        } else {
            show = true;
            $(this).attr("src", "../images/icons/arrow.gif");
        }
    });
    var box = $("#" + id + " > .opr-mbd");
    if (show) {
        box.slideUp("fast");
    } else {
        box.slideDown("fast");
    }
}

//更新文章类型
function selectArticleType(val) {
    $("li[id^='type']").each(function() {
        if ($(this).attr("id") == "type" + val) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
}

//选中页脚项
function selectFooter(id) {
    $(".guaid li").each(function() {
        if ($(this).attr("id") == id) {
            $(this).attr("class", "selected");
        } else {
            $(this).attr("class", "");
        }
    });
}

//显示下级栏目文章
function showChildren(cid, getchildren) {
    var url = "?cid=" + cid;
    if (getchildren)
        url += "&getch=1";
    else
        url += "&getch=0";
    window.location.href = url;
}

//选择文章排序
function setArticleOrder(cid, getchildren, field, orderby) {
    var url = "?cid=" + cid;
    if (getchildren)
        url += "&getch=1";
    else
        url += "&getch=0";
    url += "&field=" + field;
    if (orderby)
        url += "&orderby=1";
    else
        url += "&orderby=0";
    window.location.href = url;
}

//选择排序
function setOrder(cid, getchildren, field, orderby) {
    var url = "?cid=" + cid;
    if (getchildren)
        url += "&getch=1";
    else
        url += "&getch=0";
    url += "&field=" + field;
    if (orderby)
        url += "&orderby=1";
    else
        url += "&orderby=0";
    window.location.href = url;
}

//检查栏目选中表单
function checkTreeForm() {
    if ($("input[name='cids']:checked").length == 0) {
        alert("请选择栏目！");
        return false;
    }
    return true;
}

//全选事件
function selectAll() {
    selStatus = selStatus ? false : true;
    $("input[name='ids']").attr("checked", selStatus);
}

//获取选中值
function getSelect() {
    var ids = "";
    $("input[name='ids']:checked").each(function() {
        ids += "," + $(this).val();
    });
    if (ids) ids = ids.substr(1);
    return ids;
}

//清空个人操作日志
function clearPersonLog() {
    if (!confirm("确定清空所有操作日志？")) return;
    var url = "../Ajax/PersonLogClear.aspx";
    $.ajax({
        url: url,
        cache: false,
        success: function(result) {
            if (result.length > 0) {
                alert(result);
            } else {
                window.location.reload();
            }
        }
    });
}

//清空发布日志
function clearPublish() {
    if (!confirm("确定清空所有发布日志(未发布完成的日志无法删除)？")) return;
    var url = "../Ajax/PublishClear.aspx";
    $.ajax({
        url: url,
        cache: false,
        success: function(result) {
            if (result.length > 0) {
                alert(result);
            } else {
                window.location.reload();
            }
        }
    });
}

//显示/隐藏发布错误
function showPublishError(id) {
    var obj = $("#error_" + id);
    if (obj.css("display") == "none") {
        obj.show();
    } else {
        obj.hide();
    }
}

/*---------------- 发布方法 --------------------------*/

//新增发布
function publishAdd(id, type, ptype) {
    var url = "Ajax/PublishAdd.aspx";
    $.post(url, { id: id, type: type, ptype: ptype }, function(result) {
        var pubPop = window.pubPopBox;
        if (pubPop == null) {
            pubPop = new PopBox();
            pubPop.init(377, 189);
            pubPop.style = 2;
            pubPop.waitTimeout = 2000;
            window.pubPopBox = pubPop;
        }
        var item = new pubPop.Item("发布提示", result);
        pubPop.addItem(item);
        if (pubPop.opened == true) {
            pubPop.showItem(pubPop.items[pubPop.items.length - 1]);
        }
        else {
            pubPop.show(pubPop.items[0]);
        }
    }
    );
}

//发布文档
function pubishArticle(id) {
    publishAdd(id, 3, 3);
}

//撤消文档发布
function cancelPublishArticle(id) {
    publishAdd(id, 3, 4);
}

//发布单篇文档栏目
function pubishSingleArticle(id) {
    publishAdd(id, 4, 1);
}

//发布栏目首页
function pubishColumnHome(id) {
    publishAdd(id, 2, 1);
}

//增量发布栏目
function publishColumnAdditional(id) {
    publishAdd(id, 2, 2);
}

//完全发布栏目
function publishColumnAll(id) {
    publishAdd(id, 2, 3);
}

//撤消发布栏目
function publishColumnCancel(id) {
    publishAdd(id, 2, 4);
}

//发布站点首页
function publishSiteHome(id) {
    publishAdd(id, 1, 1);
}

//增量发布站点
function publishSiteAdditional(id) {
    publishAdd(id, 1, 2);
}

//完全发布站点
function publishSiteAll(id) {
    publishAdd(id, 1, 3);
}

//完全发布站点
function publishSiteCancel(id) {
    publishAdd(id, 1, 4);
}
