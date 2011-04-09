//树形菜单,可支持多级.
Array.prototype.clear = function() {
    this.length = 0;
};
/*                            
* 方法:Array.remove(obj)     
* 功能:删除数组元素.        
* 参数:要删除的对象.    
* 返回:在原数组上修改数组   
*/

Array.prototype.remove = function(obj) {
    if (null == obj) { return; }
    for (var i = 0, n = 0; i < this.length; i++) {
        if (this[i] != obj) {
            this[n++] = this[i];
        }
    }
    this.length -= 1
};


//获取当前HTML元素的位置
function getOffset(e) {
    var t = e.offsetTop;
    var l = e.offsetLeft;
    while (e = e.offsetParent) {
        t += e.offsetTop;
        l += e.offsetLeft;
    }
    var rec = new Object()
    rec.y = t;
    rec.x = l;
    return rec;
}

//绑定事件
function addEvent(o, e, fn) {
    var isIE = navigator.appName.indexOf("Netscape") == -1;
    if (isIE == false) {
        o.addEventListener(e.replace("on", ""), fn, false);
    }
    else {
        o.attachEvent(e, fn);
    }
}

function addClass(o, className) {
    if (!o.className) { o.className = className; }
    if (o.className.indexOf(className) == -1) { o.className += " " + className; }
}

function removeClass(o, className) {
    if (!o.className) { return; }
    o.className = o.className.replace(" " + className, "").replace(className, "");
}

function ensureClass(o, className, cond) {
    if (cond == true)
        addClass(o, className);
    else
        removeClass(o, className);
}
//Web树形菜单
function WebMenu() {
    this.items = new Array();
    this.isIE = navigator.appName.indexOf("Netscape") == -1;
    this.actived = false;
    var f1 = document.createElement("IFRAME");
    f1.style.position = "absolute";
    f1.style.visibility = "hidden";
    f1.style.zIndex = 999;
    this.iframe = f1;
}

WebMenu.prototype = {
    //菜单项,ismain=true表示主菜单项,否则为下拉菜单项
    MenuItem: function(id, text, url, target, ismain, shortCut, type, enabled) {
        this.id = id;
        this.text = text;
        this.url = url;
        this.target = target;
        this.shortCut = shortCut;
        this.ismain = ismain;
        this.type = type || 1; //1:普通;2:Check;3:Select

        if (enabled == null) enabled = true;
        this.enabled = enabled;

        //设置check和select类型的属性
        this.selected = false;
        this.stateChanged = null; //当type=2或3时改变属性值触发的事件


        this.children = new Array();

        var ctl;
        //顶级菜单使用A标记水平放置,//下级菜单项使用DIV
        if (ismain == true) {
            ctl = document.createElement("A");
        }
        else {
            ctl = document.createElement("DIV");
        }
        ctl.className = "item";
        ctl.innerHTML = text;
        ctl.id = "menu_" + id.toString();
        this.ctl = ctl;
        ctl.menu = this;

        var me = this;
        //鼠标划过并且已经激活菜单则显示下级
        addEvent(ctl, "onmouseover", function(e) {
            if (me.menu.actived == true) {
                me.show();
            }
            addClass(me.ctl, "over");
        });
        //鼠标移除
        addEvent(ctl, "onmouseout", function(e) {
            removeClass(me.ctl, "over");
        });
        //点击菜单项,当点击顶级菜单时显示下级菜单,点击没有下级的菜单项执行操作
        addEvent(ctl, "onclick", function(e) {
            if (me.ismain == true) {
                me.menu.actived = true;
                if (me.children.length > 0) {
                    me.show();
                }
            }
            if (me.children.length == 0) {
                me.click();
            }
        });
        //添加下级菜单项
        this.addItem = function(ci) {
            this.children.push(ci);
            ci.parent = this;
            ci.menu = me.menu;
            addClass(this.ctl, "hasChild");
            //this.ctl.className = "item hasChild";
            return ci;
        };
        //添加分隔符
        this.addSeparator = function(s) {
            this.children.push(s);
        };
        //显示下级菜单
        this.show = function() {
            //改变活动菜单
            if (this.parent.activeItem != null) {
                this.parent.activeItem.hide();
            }
            this.parent.activeItem = this;
            if (this.children.length > 0) {
                var childPanel = this.childPanel;
                if (childPanel == null) {
                    childPanel = document.createElement("DIV");
                    childPanel.className = "child";
                    childPanel.style.position = "absolute";
                    childPanel.style.zIndex = 1000;
                    for (i = 0; i < this.children.length; i++) {
                        childPanel.appendChild(this.children[i].ctl);
                        this.children[i].ctl.disabled = this.children[i].enabled == false;
                    }
                    this.menu.container.appendChild(childPanel);
                    this.childPanel = childPanel;
                }
                //显示菜单列表的同时显示隔层iframe
                if (childPanel.style.visibility != "visible") {
                    if (this.ismain == true) {
                        childPanel.style.left = this.menu.iframe.style.left = getOffset(this.ctl).x + "px";
                        childPanel.style.top = this.menu.iframe.style.top = getOffset(this.ctl).y + this.ctl.offsetHeight + "px";
                        this.menu.iframe.style.height = childPanel.clientHeight + "px";
                        this.menu.iframe.style.width = childPanel.clientWidth + "px";
                    }
                    else {
                        childPanel.style.left = this.menu.iframe.style.left = getOffset(this.ctl).x + this.ctl.offsetWidth + "px";
                        childPanel.style.top = this.menu.iframe.style.top = getOffset(this.ctl).y + "px";
                        this.menu.iframe.style.height = childPanel.clientHeight + "px";
                        this.menu.iframe.style.width = childPanel.clientWidth + "px";
                    }
                    childPanel.style.visibility = this.menu.iframe.style.visibility = "visible";
                }
            }
        };
        //隐藏下级菜单,同时关闭活动菜单项的下级菜单列表
        this.hide = function() {
            if (this.childPanel != null) {
                this.childPanel.style.visibility = this.menu.iframe.style.visibility = "hidden";

                if (this.activeItem != null) {
                    this.activeItem.hide();
                }
            }
        };
        //执行操作,并关闭菜单
        this.click = function() {
            this.menu.activeItem.hide();
            this.menu.actived = false;

            //check或select菜单项仅改变状态并触发事件
            if (this.type == 2 || this.type == 3) {
                this.selected = !this.selected;
                if (this.stateChanged != null) {
                    this.stateChanged(this);
                }
                this.select(this.selected);
            }
            if (this.url && this.url.length > 0) {
                if (this.url.indexOf("javascript:") == 0) {
                    eval(this.url);
                }
                else {
                    if (this.target) {
                        window.open(this.url, this.target);
                    } else {
                        window.location = this.url;
                    }
                }
            }
        },
        //清除子菜单
        this.clear = function() {
            if (this.childPanel != null) {
                this.menu.container.removeChild(this.childPanel);
                this.childPanel = null;
            }
            this.children.clear();
        },
        //清除指定顺序的菜单
        this.removeAt = function(idx) {
            var child = this.children[idx];
            if (child != null) {
                if (child.childPanel != null) {
                    this.menu.container.removeChild(child.childPanel);
                }
                this.children.remove(child);
            }
        },
        //设置Check属性
        this.select = function(value) {
            this.selected = value == true;
            if (this.type == 2) {
                ensureClass(this.ctl, "checked", this.selected == true);
            }
            if (this.type == 3) {
                ensureClass(this.ctl, "selected", this.selected == true);
            }
        },
        //选中下级当前项
        this.selectItem = function(url) {
            for (i = 0; i < this.children.length; i++) {
                var child = this.children[i];
                if (child.url && url.toLowerCase().indexOf(child.url.toLowerCase()) > 0) {
                    child.select(true);
                }
                else
                    child.select(false);
            }
        }
    },
    //分隔符,一个高度为1px的DIV
    Separator: function() {
        var div = document.createElement("DIV");
        div.className = "separator";
        this.ctl = div;
    },
    //添加顶级菜单项
    addItem: function(mi) {
        this.items.push(mi);
        mi.menu = this;
        mi.parent = this;
        return mi;
    },
    //初始化菜单数据,并显示顶级菜单项.绑定页面点击事件到关闭活动菜单
    init: function(container) {
        this.container = container;
        for (i = 0; i < this.items.length; i++) {
            container.appendChild(this.items[i].ctl);
        }
        container.appendChild(this.iframe);

        var closeMenu = function(e) {
            var src = e.srcElement || e.target;
            if (src && src.menu) {
                return;
            }
            if (menu && menu.activeItem) {
                menu.activeItem.hide();
                menu.actived = false;
            }
            if (window.activeContextMenu) {
                window.activeContextMenu.hide();
            }
        };
        addEvent(document, "onclick", closeMenu);
        addEvent(window.frames['left'].document, "onclick", closeMenu);
        addEvent(window.frames['mainFrame'].document, "onclick", closeMenu);
        addEvent(document, "onpropertychange", function() {
            for (i = 0; i < document.frames.length; i++) {
                addEvent(document.frames[i].document, "onclick", closeMenu);
            }
        });
    }
}

