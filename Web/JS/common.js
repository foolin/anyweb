//判断浏览器是否为IE
function isIE(){
      return (document.all && window.ActiveXObject && !window.opera) ? true : false;
} 

//判断浏览器是否是ie
var isFF = navigator.userAgent.indexOf("Firefox") > 0;

//设为主页
function HomePage(){
    if(isIE){
        this.style.behavior='url(#default#homepage)';this.setHomePage(this.document.location.href);
    }
    return false;
}

//添加收藏
function Love(){
    if(isIE){
        window.external.AddFavorite(this.document.location.href,'蜜酿工房培训加盟网');
    }
    if(isFF){
        alert("你的浏览器是Firefox，收藏可按 Ctrl + D");
    }
    return false;
}