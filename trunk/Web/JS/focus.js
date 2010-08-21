function $$(id) { return document.getElementById(id); }
function moveElement(elementID, final_x, final_y, interval) {
    if (!document.getElementById) return false;
    if (!document.getElementById(elementID)) return false;
    var elem = document.getElementById(elementID);
    if (elem.movement) {
        clearTimeout(elem.movement);
    }
    if (!elem.style.left) {
        elem.style.left = "0px";
    }
    if (!elem.style.top) {
        elem.style.top = "0px";
    }
    var xpos = parseInt(elem.style.left);
    var ypos = parseInt(elem.style.top);
    if (xpos == final_x && ypos == final_y) {
        return true;
    }
    if (xpos < final_x) {
        var dist = Math.ceil((final_x - xpos) / 10);
        xpos = xpos + dist;
    }
    if (xpos > final_x) {
        var dist = Math.ceil((xpos - final_x) / 10);
        xpos = xpos - dist;
    }
    if (ypos < final_y) {
        var dist = Math.ceil((final_y - ypos) / 10);
        ypos = ypos + dist;
    }
    if (ypos > final_y) {
        var dist = Math.ceil((ypos - final_y) / 10);
        ypos = ypos - dist;
    }
    elem.style.left = xpos + "px";
    elem.style.top = ypos + "px";
    var repeat = "moveElement('" + elementID + "'," + final_x + "," + final_y + "," + interval + ")";
    elem.movement = setTimeout(repeat, interval);
}
function classNormal() {
    var focusBtnList = $$('focus_btn').getElementsByTagName('a');
    var focusTit = $$('focus').getElementsByTagName('p');
    for (var i = 0; i < focusBtnList.length; i++) {
        focusBtnList[i].className = '';
        focusTit[i].className = "hidden";
    }
}
function focusChange() {
    var focusBtnList = $$('focus_btn').getElementsByTagName('a');
    var focusTit = $$('focus').getElementsByTagName('p');
    for (var i = 0; i < focusBtnList.length; i++) {
        focusBtnList[i].onmouseover = function() {
            var index = this.getAttribute("ref");
            moveElement('focus_list', -247 * index, 0, 5);
            classNormal();
            focusBtnList[index].className = 'cur';
            focusTit[index].className = "block";
        }
    }
}
setInterval('autoFocusChange()', 5000);
var atuokey = false;
function autoFocusChange() {
    $$('focus').onmouseover = function() { atuokey = true }
    $$('focus').onmouseout = function() { atuokey = false }
    if (atuokey) return;
    var focusBtnList = $$('focus_btn').getElementsByTagName('a');
    var focusTit = $$('focus').getElementsByTagName('p');
    for (var i = 0; i < focusBtnList.length; i++) {
        if (focusBtnList[i].className == 'cur') {
            var currentNum = i;
        }
    }
    for (var i = 0; i < focusBtnList.length; i++) {
        if (currentNum == i) {
            if (i == focusBtnList.length - 1) {
                moveElement('focus_list', -247, 0, 5);
            } else {
                moveElement('focus_list', -247 * (i + 1), 0, 5);
            }
            classNormal();
            if (i == focusBtnList.length - 1) {
                focusBtnList[0].className = 'cur'
                focusTit[0].className = "block";
            } else {
                focusBtnList[i + 1].className = 'cur'
                focusTit[i + 1].className = "block";
            }
        }
    }
}
