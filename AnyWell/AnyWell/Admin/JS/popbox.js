function $i(i) {
    try {
        return parseInt(i);
    } catch (ex) {
        return 0;
    }
}   

function PopBox() {
    this.items = new Array();
    
    var panel = document.createElement("DIV");
    panel.className = "popbox";
    panel.style.visibility = "hidden";
	panel.style.position = "absolute";
	document.body.appendChild(panel);
	this.panel = panel;
	panel.obj = this;
    this.isIE = navigator.appName.indexOf("Netscape") == -1;
}

PopBox.prototype = {
    Item: function(title, html) {
        this.title = title;
        this.html = html;
    },
    addItem: function(item) {
        this.items.push(item);
        item.index = this.items.length - 1;
    },
    addEvent: function(o, e, fn) {
        if (this.isIE == false) {
            o.addEventListener(e, fn, false);
        }
        else {
            o.attachEvent(e, fn);
        }
    },
    init: function(width, height) {
        this.panel.style.width = width;
        this.panel.style.height = height;
        this.height = this.panel.offsetHeight;
        this.width = this.panel.offsetWidth;
        this.docWidth = document.body.clientWidth;
        this.docHeight = document.body.clientHeight;
        this.timeout = 150;
        this.speed = 10;
        this.step = 5;
        this.pause = false;
        this.close = false;
        this.autoClose = true;
        this.waitTimeout = 5000;
        this.style = 1;
        var me = this;

        var title = document.createElement("DIV");
        title.className = "title";
        var stxt = document.createElement("DIV");
        stxt.className = "txt";
        title.appendChild(stxt);
        this.titleCtl = stxt;

        var snav = document.createElement("DIV");
        snav.className = "nav";
        var pre = document.createElement("A");
        pre.innerHTML = "&lt;";
        pre.style.cursor = "pointer";
        pre.title = "显示前一条消息";
        this.addEvent(pre, "onclick", function() { me.movePre(); });
        snav.appendChild(pre);
        this.preCtl = pre;
        pre.pop = this;

        var count = document.createElement("SPAN");
        snav.appendChild(count);
        this.countCtl = count;

        var next = document.createElement("A");
        next.innerHTML = "&gt;";
        next.style.cursor = "pointer";
        next.title = "显示后一条消息";
        this.addEvent(next, "onclick", function() { me.moveNext(); });
        snav.appendChild(next);
        this.nextCtl = next;
        next.pop = this;
        title.appendChild(snav);

        var closeCtl = document.createElement("DIV");
        closeCtl.innerHTML = "关闭";
        closeCtl.className = "close";
        closeCtl.style.cursor = "pointer";
        closeCtl.title = "关闭消息框";
        this.closeCtl = closeCtl;
        closeCtl.pop = this;
        this.addEvent(closeCtl, "onclick", function() { me.hide(); });
        title.appendChild(closeCtl);
        this.panel.appendChild(title);

        var msg = document.createElement("DIV");
        msg.className = "msg";
        this.msgCtl = msg;
        this.panel.appendChild(msg);
    },

    show: function(item) {
        if (this.items.length == 0) {
            return;
        }
        if (item) {
            this.showItem(item);
        }
        var me = this;
        var mess = this.panel;
        var checkAutoClose = function() {
            if (me.autoClose == true) {
                me.closeTimer = window.setInterval(function() { me.hide(); }, me.waitTimeout);
            }
        }
        if (me.style == 1) { //右下角上浮式窗口
            mess.onmouseover = function() { me.pause = true; };
            mess.onmouseout = function() { me.pause = false; };
            mess.style.top = $i(document.body.scrollTop) + this.docHeight + 10;
            mess.style.left = $i(document.body.scrollLeft) + this.docWidth - this.width;
            mess.style.visibility = 'visible';
            var moveUp = function() {
                var tHeight = me.height;

                if ($i(mess.style.top) <= (me.docHeight - tHeight + $i(document.body.scrollTop))) {
                    me.timeout--;
                    if (me.timeout == 0) {
                        window.clearInterval(me.timer);
                        //auto close
                        checkAutoClose();
                    }
                } else {
                    mess.style.top = $i(mess.style.top) - me.step;
                }
            }
            this.timer = window.setInterval(moveUp, this.speed);
        }
        else { //居中弹窗
            mess.style.top = ($i(document.body.scrollTop) + this.docHeight - this.width) / 2;
            mess.style.left = ($i(document.body.scrollLeft) + this.docWidth - this.width) / 2;
            mess.style.visibility = 'visible';
            //auto close
            checkAutoClose();
        }
        this.opened = true;
    },

    showItem: function(item) {
        this.titleCtl.innerHTML = item.title;
        this.msgCtl.innerHTML = item.html;
        this.countCtl.innerHTML = "[" + (item.index + 1) + "/" + this.items.length + "]";
        this.panel.style.visibility = "visible";
        this.preCtl.disabled = item.index == 0;
        this.nextCtl.disabled = item.index == this.items.length - 1;
        this.currentIndex = item.index;
    },
    hide: function() {
        var me = this;
        var mess = this.panel;
        if (this.timer > 0) {
            window.clearInterval(me.timer);
        }
        if (this.closeTimer > 0) {
            window.clearInterval(me.closeTimer);
        }
        if (this.style == 1) {
            var moveDown = function() {
                // if (me.pause == false) {
                if ($i(mess.style.top) >= ($i(document.body.scrollTop) + me.docHeight + 10)) {
                    window.clearInterval(me.timer);
                    mess.style.visibility = 'hidden';
                } else {
                    mess.style.top = $i(mess.style.top) + me.step;
                }
                // }
            }
            this.timer = window.setInterval(moveDown, this.speed);
        }
        else {
            mess.style.visibility = 'hidden';
        }
        this.opened = false;
        this.items = new Array();
    },

    movePre: function() {
        if (this.currentIndex > 0) {
            var item = this.items[this.currentIndex - 1];
            this.showItem(item);
        }
    },

    moveNext: function() {
        if (this.currentIndex < this.items.length - 1) {
            var item = this.items[this.currentIndex + 1];
            this.showItem(item);
        }
    }
}