function resizeImg(img,maxw,maxh)
{ 
}

function imageLoad(tempImg)
{
    var img = tempImg.friend;
    if( !tempImg.maxw)tempImg.maxw = 150;
    if( !tempImg.maxh)tempImg.maxh = 150;
    if( img.maxw)tempImg.maxw = img.maxw;
    if( img.maxh)tempImg.maxh = img.maxh;
    var flScale = Math.min( 1, Math.min( (tempImg.maxw / tempImg.width), (tempImg.maxh / tempImg.height) ) ); 
    img.style.width = Math.round( tempImg.width * flScale) + "px"; 
    img.style.height = Math.round( tempImg.height * flScale) + "px";
}

/******
* 全选
******/
function selectAll(v) {
    var list = document.getElementsByTagName("input");
    for (var i = 0; i < list.length; i++) {
        if (list[i].name == "ids" && list[i].type == "checkbox") {
            list[i].checked = v;
        }
    }
}

/*********************
* 根据name返回DOM元素
*********************/
function $name(n) {
    return document.getElementsByName(n);
}


function GoToPage(url){
    window.location = url;
}